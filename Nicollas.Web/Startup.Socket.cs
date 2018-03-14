// <copyright file="Startup.Socket.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas
{
    using Microsoft.AspNetCore.Builder;
    using Nicollas.Ng.Middlewares;

    /// <summary>
    /// Startup for Sockets
    /// </summary>
    public partial class Startup
    {
        private void ConfigureSocket(IApplicationBuilder app)
        {
            app.UseWebSockets();

            app.UseMiddleware<WebSocketMiddleware>();
        }
    }
}
