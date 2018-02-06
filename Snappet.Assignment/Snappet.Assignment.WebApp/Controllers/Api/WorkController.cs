using Microsoft.AspNetCore.Mvc;
using Snappet.Assignment.Business.Interfaces;
using Snappet.Assignment.Entities.DomainObjects;
using Snappet.Assignment.Entities.DTOs;
using Snappet.Assignment.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet.Assignment.WebApp.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class WorkController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IEnumerable<WorkDto>> GetAll()
        {
            var works = (await _unitOfWork.WorkRepository.GetAllAsync(null, c => c.User, c => c.Exercise)).ToList();

            return _mapper.Map<IEnumerable<Work>, IEnumerable<WorkDto>>(works);
        }

        [HttpGet]
        public async Task<IEnumerable<WorkDto>> GetToday()
        {
            //TodayDate
            var today = new DateTime(2015, 03, 24, 11, 30, 00);


            var works = (await _unitOfWork.WorkRepository.GetAllAsync(
                                                                    c => c.SubmitDateTime.Year == today.Year &&
                                                                    c.SubmitDateTime.Month == today.Month &&
                                                                    c.SubmitDateTime.Day == today.Day &&
                                                                    c.SubmitDateTime.Hour <= today.Hour &&
                                                                    c.SubmitDateTime.Minute <= today.Minute,
                                                                    c => c.User, c => c.Exercise)).ToList();
            return _mapper.Map<IEnumerable<Work>, IEnumerable<WorkDto>>(works);
        }

    }
}