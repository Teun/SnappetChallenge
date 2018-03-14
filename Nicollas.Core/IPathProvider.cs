// <copyright file="IPathProvider.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>

namespace Nicollas.Core
{
    /// <summary>
    /// Provider for Server Paths
    /// </summary>
    public interface IPathProvider
    {
        /// <summary>
        /// Map an path from WebRootPath
        /// </summary>
        /// <param name="path">The path to map</param>
        /// <returns>The absolut path</returns>
        string MapPath(string path);
    }
}
