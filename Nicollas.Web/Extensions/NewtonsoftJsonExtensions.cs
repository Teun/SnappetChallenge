// <copyright file="NewtonsoftJsonExtensions.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
namespace Nicollas.Ng.Extensions
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// This class is a tool to facilite return objects in json result
    /// </summary>
    public static class NewtonsoftJsonExtensions
    {
        /// <summary>
        /// Extends the ToJsonResult for all objects
        /// </summary>
        /// <param name="obj">The Object</param>
        /// <param name="handleLoopReference">The handler</param>
        /// <returns>The object as JsonActionResult</returns>
        public static ActionResult ToJsonResult(this object obj, ReferenceLoopHandling handleLoopReference = ReferenceLoopHandling.Error)
        {
            var content = new ContentResult()
            {
                Content = JsonConvert.SerializeObject(
                    obj,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = handleLoopReference, ContractResolver = new CamelCasePropertyNamesContractResolver() }),
                ContentType = "application/json"
            };
            return content;
        }

        /// <summary>
        /// Extends the ToJsonString for all objects
        /// </summary>
        /// <param name="obj">The Object</param>
        /// <param name="handleLoopReference">The handler</param>
        /// <returns>The string json representation of the object</returns>
        public static string ToJsonString(this object obj, ReferenceLoopHandling handleLoopReference = ReferenceLoopHandling.Error)
        {
            new CamelCasePropertyNamesContractResolver();
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = handleLoopReference, ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        /// <summary>
        /// Extends the FromJsonString for all strings
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="value">The string json representation of the Object</param>
        /// <returns>The object</returns>
        public static T FromJsonString<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
