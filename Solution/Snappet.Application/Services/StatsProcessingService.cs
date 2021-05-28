using Snappet.Common.Helpers;
using Snappet.Data;
using Snappet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snappet.Application.Services
{
    public class StatsProcessingService : IStatsProcessingService
    {
        private readonly IAnswersDataProvider _answersDataProvider;
        private readonly IAnswersRepository _answersRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public StatsProcessingService(
            IAnswersDataProvider answersDataProvider,
            IAnswersRepository answersRepository,
            IDateTimeProvider dateTimeProvider)
        {
            _answersDataProvider = answersDataProvider;
            _answersRepository = answersRepository;
            _dateTimeProvider = dateTimeProvider;
        }
      
        public async Task ProcessStats()
        {
            //if data already loaded for the date, return
            if (_answersRepository.DataExistsForDate(_dateTimeProvider.Now))
                return;

            //read data from file and load into database
            var answerEntities = await _answersDataProvider.GetSubmittedAnswers();
            await _answersRepository.Insert(answerEntities);
           
        }
    }
}
