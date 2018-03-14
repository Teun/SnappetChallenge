// <copyright file="SampleApiController.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
namespace Nicollas.Ng.Api
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Nicollas.Ng.Extensions;
    using Nicollas.Ng.Filters;

    /// <summary>
    /// Sample Api Controller. Needs to be removed.
    /// </summary>
    public class SampleApiController : Controller
    {
        // private DbCondext context;
        // public SampleApiController(DbCondext context)
        // {
        //    this.context = context;
        // }
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SampleApiController"/> class.
        /// </summary>
        /// <param name="mapper">Our Mapper injection</param>
        public SampleApiController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        /// <summary>
        /// The Post Op
        /// </summary>
        /// <param name="cand">An object from http</param>
        /// <returns>The object recived as json</returns>
        [HttpPost]
        public IActionResult PostOp([FromBody]object cand)
        {
            return cand.ToJsonResult(); // new HttpStatusContentResult(cand, System.Net.HttpStatusCode.OK, "Testes post");  need to convert to asp.net core
        }

        /// <summary>
        /// The Put Op
        /// </summary>
        /// <param name="cand">An object from http</param>
        /// <returns>The object recived as json</returns>
        [HttpPut]
        public IActionResult PutOp([FromBody]object cand)
        {
            return cand.ToJsonResult(); // new HttpStatusContentResult(cand, System.Net.HttpStatusCode.OK, "Testes put");  need to convert to asp.net core
        }

        /// <summary>
        /// The Del Op
        /// </summary>
        /// <param name="candidatoId">An integer from http</param>
        /// <returns>An http status OK</returns>
        [HttpDelete]
        public IActionResult DelOp(int candidatoId)
        {
            return this.Ok();
        }

        /// <summary>
        /// Test the NLog
        /// </summary>
        /// <returns>Throws an exception</returns>
        public IActionResult Throw()
        {
            throw new Exception("Testing nlog");
        }

        /// <summary>
        /// Get the sample Angular 2 materials grid
        /// </summary>
        /// <returns>The sample Angular2 materials grid</returns>
        [HttpPost]
        [AntiForgeryToken]
        public IActionResult GetGrid()
        {
            var list = new List<dynamic>
            {
                new { text = "One", cols = 3, rows = 1, color = "lightblue" },
                new { text = "Two", cols = 1, rows = 2, color = "lightgreen" },
                new { text = "Three", cols = 1, rows = 1, color = "lightpink" },
                new { text = "Four", cols = 2, rows = 1, color = "#DDBDF1" }
            };
            return list.ToJsonResult();
        }
    }
}
