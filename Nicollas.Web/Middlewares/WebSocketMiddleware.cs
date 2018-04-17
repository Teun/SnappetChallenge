// <copyright file="WebSocketMiddleware.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Middlewares
{
    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Net.WebSockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Nicollas.Ng.Extensions;

    /// <summary>
    /// This class handle Sockets
    /// </summary>
    public class WebSocketMiddleware
    {
        private static ConcurrentDictionary<string, WebSocket> sockets = new ConcurrentDictionary<string, WebSocket>();

        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebSocketMiddleware"/> class.
        /// </summary>
        /// <param name="next">The request delegate</param>
        public WebSocketMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// The invoke operation
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>An async worker</returns>
        public async Task Invoke(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest || context.Request.Path != "/ws")
            {
                await this.next.Invoke(context);
                return;
            }

            CancellationToken ct = context.RequestAborted;
            WebSocket currentSocket = await context.WebSockets.AcceptWebSocketAsync();
            var socketId = Guid.NewGuid().ToString();

            sockets.TryAdd(socketId, currentSocket);
            await SendRealtimeAsync(currentSocket, new Dto.Realtime.RealtimeDto { ActionNeeded = Dto.Realtime.ActionNeeded.Init, Result = socketId });

            while (true)
            {
                if (ct.IsCancellationRequested)
                {
                    break;
                }

                var response = await ReceiveStringAsync(currentSocket, ct);
                if (string.IsNullOrEmpty(response))
                {
                    if (currentSocket.State != WebSocketState.Open)
                    {
                        break;
                    }

                    continue;
                }
            }

            sockets.TryRemove(socketId, out WebSocket dummy);

            await currentSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", ct);
            currentSocket.Dispose();
        }

        /// <summary>
        /// Send an message with broadcast
        /// </summary>
        /// <param name="realtimeObject">The message to send</param>
        /// <param name="ignoreFor">The socket to be ignored</param>
        /// <returns>An async worker</returns>
        internal static async Task BroadcastMessage(Dto.Realtime.RealtimeDto realtimeObject, string ignoreFor)
        {
            foreach (var socket in sockets)
            {
                if (socket.Value.State != WebSocketState.Open || socket.Key == ignoreFor)
                {
                    continue;
                }

                await SendRealtimeAsync(socket.Value, realtimeObject);
            }
        }

        private static Task SendStringAsync(WebSocket socket, string data, CancellationToken ct = default(CancellationToken))
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            var segment = new ArraySegment<byte>(buffer);
            return socket.SendAsync(segment, WebSocketMessageType.Text, true, ct);
        }

        private static Task SendRealtimeAsync(WebSocket socket, Dto.Realtime.RealtimeDto realtimeObject, CancellationToken ct = default(CancellationToken))
        {
            return SendStringAsync(socket, realtimeObject.ToJsonString(), ct);
        }

        private static async Task<string> ReceiveStringAsync(WebSocket socket, CancellationToken ct = default(CancellationToken))
        {
            var buffer = new ArraySegment<byte>(new byte[8192]);
            using (var ms = new MemoryStream())
            {
                WebSocketReceiveResult result;
                do
                {
                    ct.ThrowIfCancellationRequested();

                    result = await socket.ReceiveAsync(buffer, ct);
                    ms.Write(buffer.Array, buffer.Offset, result.Count);
                }
                while (!result.EndOfMessage);

                ms.Seek(0, SeekOrigin.Begin);
                if (result.MessageType != WebSocketMessageType.Text)
                {
                    return null;
                }

                // Encoding UTF8: https://tools.ietf.org/html/rfc6455#section-5.6
                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
    }
}
