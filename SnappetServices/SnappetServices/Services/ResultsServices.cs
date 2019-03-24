using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SnappetServices.DTOs;
using SnappetServices.Models;
using SnappetServices.Repositories;

namespace SnappetServices.Services
{
    public class ResultsServices : IResultsServices
    {
        private readonly IResultsRepository resultsRepository;
        private readonly IMapper mapper;

        public ResultsServices(IResultsRepository resultsRepository, IMapper mapper)
        {
            this.resultsRepository = resultsRepository;
            this.mapper = mapper;
        }

        public IEnumerable<ResultV1Dto> GetAllResults(DateTime date)
        {
            return this.resultsRepository.GetAllResults(date).Select(p => this.mapper.Map<Result, ResultV1Dto>(p)).ToList();
        }
    }
}
