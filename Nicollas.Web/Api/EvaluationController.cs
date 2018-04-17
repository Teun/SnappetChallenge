// <copyright file="EvaluationController.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
namespace Nicollas.Ng.Api
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Nicollas.Core;
    using Nicollas.Core.Entities;
    using Nicollas.Core.Services;
    using Nicollas.Dto;
    using Nicollas.Ng.Extensions;
    using Nicollas.Ng.Filters;

    /// <summary>
    /// Sample Api Controller. Needs to be removed.
    /// </summary>
    public class EvaluationController : Controller
    {
        // private DbCondext context;
        // public SampleApiController(DbCondext context)
        // {
        //    this.context = context;
        // }
        private readonly IMapper mapper;
        private readonly IEvaluationService evaluationService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EvaluationController"/> class.
        /// </summary>
        /// <param name="mapper">Our Mapper injection</param>
        /// <param name="evaluationService">Evaluation servicer</param>
        /// <param name="logger">The Logger</param>
        public EvaluationController(
            IMapper mapper,
            IEvaluationService evaluationService,
            ILogger logger)
        {
            this.mapper = mapper;
            this.evaluationService = evaluationService;
            this.logger = logger;
        }

        /// <summary>
        /// Test propouse Method
        /// </summary>
        /// <param name="evalDto">The DTO</param>
        /// <returns>The Entity</returns>
        public async Task<IActionResult> ProccessInitialData([FromBody] List<EvaluationDto> evalDto)
        {
            try
            {
                await this.evaluationService.InsertEvaluationDataAsync(this.mapper.Map<List<Evaluation>>(evalDto));
            }
            catch (Exception ex)
            {
                this.logger.Error = ex.ToString();
                return this.StatusCode(500, "Contact the support");
            }

            return this.Ok();
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
