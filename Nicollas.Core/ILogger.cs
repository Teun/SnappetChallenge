//-----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core
{
    /// <summary>
    /// This interface define a Logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Sets wrapper to Log Info
        /// </summary>
        string Info { set; }

        /// <summary>
        /// Sets wrapper to Log Debug
        /// </summary>
        string Debug { set; }

        /// <summary>
        /// Sets wrapper to Log Warn
        /// </summary>
        string Warn { set; }

        /// <summary>
        /// Sets wrapper to Log Error
        /// </summary>
        string Error { set; }

        /// <summary>
        /// Sets wrapper to Log Trace
        /// </summary>
        string Trace { set; }

        /// <summary>
        /// Sets wrapper to Log Fatal
        /// </summary>
        string Fatal { set; }

        /// <summary>
        /// Obtain the NLog implementation
        /// </summary>
        /// <typeparam name="T">The logger provider</typeparam>
        /// <returns>The NLog implementation</returns>
        T GetLogger<T>();
    }
}
