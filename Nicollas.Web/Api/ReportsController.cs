// <copyright file="EvaluationController.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
namespace Nicollas.Ng.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Nicollas.Core;
    using Nicollas.Core.Entities;
    using Nicollas.Core.Factories;
    using Nicollas.Core.Services;
    using Nicollas.Dto;
    using Nicollas.Ng.Extensions;
    using Nicollas.Ng.Filters;

    /// <summary>
    /// The Reports Controller
    /// </summary>
    [AllowAnonymous]
    public class ReportsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IChartFactory chartFactory;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportsController"/> class.
        /// </summary>
        /// <param name="mapper">Our Mapper injection</param>
        /// <param name="chartFactory">Evaluation servicer</param>
        /// <param name="logger">The Logger</param>
        public ReportsController(
            IMapper mapper,
            IChartFactory chartFactory,
            ILogger logger)
        {
            this.mapper = mapper;
            this.chartFactory = chartFactory;
            this.logger = logger;
        }

        /// <summary>
        /// </summary>
        /// <returns>The Entity</returns>
        public async Task<IActionResult> GetAplyMonth()
        {
            try
            {
                var query = await this.chartFactory.GetAplyMonth();
                return this.Ok(query);
            }
            catch (Exception ex)
            {
                this.logger.Error = ex.ToString();
                return this.StatusCode(500, "Contact the support");
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>The Entity</returns>
        public async Task<IActionResult> GetAplyWeek()
        {
            try
            {
                var query = await this.chartFactory.GetAplyWeek();
                return this.Ok(query);
            }
            catch (Exception ex)
            {
                this.logger.Error = ex.ToString();
                return this.StatusCode(500, "Contact the support");
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>The Entity</returns>
        public async Task<IActionResult> GetDificultyWeek()
        {
            try
            {
                var query = await this.chartFactory.GetDificultyWeek();
                return this.Ok(query);
            }
            catch (Exception ex)
            {
                this.logger.Error = ex.ToString();
                return this.StatusCode(500, "Contact the support");
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>The Entity</returns>
        public async Task<IActionResult> GetProgressWeek()
        {
            try
            {
                var query = await this.chartFactory.GetProgressWeek();
                return this.Ok(query);
            }
            catch (Exception ex)
            {
                this.logger.Error = ex.ToString();
                return this.StatusCode(500, "Contact the support");
            }
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
