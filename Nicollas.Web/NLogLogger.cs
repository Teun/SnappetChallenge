//-----------------------------------------------------------------------
// <copyright file="NLogLogger.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Ng
{
    using System;
    using Core;

    /// <summary>
    /// This class implement <see cref="ILogger"/>
    /// </summary>
    public class NLogLogger : ILogger
    {
        /// <summary>
        /// The lazy logger
        /// </summary>
        private static readonly Lazy<NLog.Logger> LazyNLogger = new Lazy<NLog.Logger>(NLog.LogManager.GetCurrentClassLogger());

        /// <summary>
        /// Sets wrapper to NLog Info
        /// </summary>
        public string Info
        {
            set
            {
                LazyNLogger.Value.Info(value);
            }
        }

        /// <summary>
        /// Sets wrapper to NLog Debug
        /// </summary>
        public string Debug
        {
            set
            {
                LazyNLogger.Value.Debug(value);
            }
        }

        /// <summary>
        /// Sets wrapper to NLog Warn
        /// </summary>
        public string Warn
        {
            set
            {
                LazyNLogger.Value.Warn(value);
            }
        }

        /// <summary>
        /// Sets wrapper to NLog Error
        /// </summary>
        public string Error
        {
            set
            {
                LazyNLogger.Value.Error(value);
            }
        }

        /// <summary>
        /// Sets wrapper to NLog Trace
        /// </summary>
        public string Trace
        {
            set
            {
                LazyNLogger.Value.Trace(value);
            }
        }

        /// <summary>
        /// Sets wrapper to NLog Fatal
        /// </summary>
        public string Fatal
        {
            set
            {
                LazyNLogger.Value.Fatal(value);
            }
        }

        /// <summary>
        /// <see cref="ILogger.GetLogger"/>
        /// </summary>
        /// <typeparam name="T">The logger type</typeparam>
        /// <returns>The Type</returns>
        public T GetLogger<T>()
        {
            return (T)Convert.ChangeType(LazyNLogger.Value, typeof(T));
        }
    }
}
