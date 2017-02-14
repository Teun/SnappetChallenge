using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using SnappetChallenge.DataAccessLayer.DTO;
using SnappetChallenge.DataAccessLayer.Interfaces;

namespace SnappetChallenge.DataAccessLayer.Repositories
{
    public class SubmittedAnswerJsonRepository : ISubmittedAnswerRepository
    {
        private readonly string _embeddedFilePath;
        private readonly int _getRecordsDefaultLimit;

        public SubmittedAnswerJsonRepository(string embeddedFilePath, int getRecordsDefaultLimit = 1000000)
        {
            if (String.IsNullOrEmpty(embeddedFilePath)) throw new ArgumentNullException(nameof(embeddedFilePath));

            _embeddedFilePath = embeddedFilePath;
            _getRecordsDefaultLimit = getRecordsDefaultLimit;
        }

        #region Data
        private IQueryable<SubmittedAnswerDto> GetAllSubmittedAnswers()
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(_embeddedFilePath))
            using (var reader = new StreamReader(stream))
            {
                var serializer = new JsonSerializer()
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                var submittedAsnwerList = (List<SubmittedAnswerDto>)serializer.Deserialize(reader, typeof(List<SubmittedAnswerDto>));
                return submittedAsnwerList.AsQueryable();
            }
        }

        #endregion Data

        public IQueryable<SubmittedAnswerDto> GetAll()
        {
            return GetAll(_getRecordsDefaultLimit);
        }

        public IQueryable<SubmittedAnswerDto> GetAll(int limit)
        {
            return GetAllSubmittedAnswers()
                .Take(limit);
        }
    }
}
