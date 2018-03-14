// <copyright file="GlobalExceptionFilter.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Filters
{
    using System;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Nicollas.Core;

    /// <summary>
    /// Class to capture unhandled exceptions and call our logger
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter, IDisposable
    {
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionFilter"/> class.
        /// </summary>
        /// <param name="logger">Our Logger</param>
        public GlobalExceptionFilter(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Capture the exception
        /// </summary>
        /// <param name="context">The context that the exception was throw</param>
        public void OnException(ExceptionContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];

            this.logger.Error = string.Format(
                "Unhandled exception processing {0} for {1}: {2}",
                actionName,
                controllerName + "/" + actionName,
                context.Exception.Message);
        }

#pragma warning disable SA1124 // Do not use regions
        #region IDisposable Support
#pragma warning disable SA1201 // Elements must appear in the correct order
        private bool disposedValue = false; // To detect redundant calls
#pragma warning restore SA1124 // Do not use regions
#pragma warning restore SA1201 // Elements must appear in the correct order

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~GlobalExceptionFilter() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.

        /// <inheritdoc/>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            this.Dispose(true);

            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The Disposable
        /// </summary>
        /// <param name="disposing">Dispose options</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                this.disposedValue = true;
            }
        }
        #endregion
    }
}
