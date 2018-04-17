// <copyright file="ViewController.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
namespace Nicollas.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;

    /// <summary>
    /// Our controller to handle the Core MVC
    /// </summary>
    public class ViewController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewController"/> class.
        /// </summary>
        /// <param name="env">The enviroment</param>
        public ViewController(IHostingEnvironment env) => this.HostingEnv = env;

        /// <summary>
        /// Gets the HostingEnviroment
        /// </summary>
        private IHostingEnvironment HostingEnv { get; }

        /// <summary>
        /// The default fallback route
        /// </summary>
        /// <returns>return Our view that starts the Angular</returns>
        [AllowAnonymous]
        public IActionResult Index()
        {
            // return this.View();
            return new PhysicalFileResult(
                   System.IO.Path.Combine(this.HostingEnv.WebRootPath, "index.html"),
                   new MediaTypeHeaderValue("text/html"));
        }
    }
}
