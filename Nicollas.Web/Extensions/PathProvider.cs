// <copyright file="PathProvider.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Extensions
{
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    using Nicollas.Core;

    /// <summary>
    /// Implementation of <see cref="IPathProvider"/>
    /// </summary>
    public class PathProvider : IPathProvider
    {
        private IHostingEnvironment hostingEnvironment;
        private ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PathProvider"/> class.
        /// </summary>
        /// <param name="environment">The IHostingEnvironment</param>
        /// <param name="logger">The logger</param>
        public PathProvider(IHostingEnvironment environment, ILogger logger)
        {
            this.hostingEnvironment = environment;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public string MapPath(string path)
        {
            var filePath = Path.Combine(this.hostingEnvironment.WebRootPath, path);
            this.logger.Info = $"Requested the path: {filePath}";
            Directory.CreateDirectory(filePath);
            return filePath;
        }
    }
}