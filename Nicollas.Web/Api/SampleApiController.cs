// <copyright file="SampleApiController.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
namespace Nicollas.Ng.Api
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Nicollas.Core.Entities;
    using Nicollas.Dto;
    using Nicollas.Ng.Extensions;
    using Nicollas.Ng.Filters;

    /// <summary>
    /// Sample Api Controller. Needs to be removed.
    /// </summary>
    [AllowAnonymous]
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
        /// Test propouse Method
        /// </summary>
        /// <param name="evalDto">The DTO</param>
        /// <returns>The Entity</returns>
        public IActionResult MapToEntity([FromBody] EvaluationDto evalDto)
        {
            return this.Ok(this.mapper.Map<Evaluation>(evalDto));
        }

        /// <summary>
        /// Test propouse Method
        /// </summary>
        /// <param name="evalEntity">The Entity</param>
        /// <returns>The Dto</returns>
        public IActionResult MapToDto([FromBody] Evaluation evalEntity)
        {
            return this.Ok(this.mapper.Map<EvaluationDto>(evalEntity));
        }
    }
}
