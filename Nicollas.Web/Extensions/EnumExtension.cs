// <copyright file="EnumExtension.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Extensions
{
    using System;

    /// <summary>
    /// Extensions methods to Enums
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Try to convert integer to Enum
        /// </summary>
        /// <typeparam name="T">The enum to parse</typeparam>
        /// <param name="value">value to parse</param>
        /// <param name="result">result</param>
        /// <returns>boolean indicating success</returns>
        public static bool TryParse<T>(int value, out T result)
            where T : struct, IConvertible
        {
            result = default(T);
            bool success = Enum.IsDefined(typeof(T), value);
            if (success)
            {
                result = (T)Enum.ToObject(typeof(T), value);
            }

            return success;
        }
    }
}
