using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Protocols;

    using SnappetChallenge.Models;
    using SnappetChallenge.Models.Interfaces;

    public class MockDataRepository : IDataRepository
    {
        private ICsvReader _csvReader;

        private IConfiguration _configuration;

        public List<ClassAssignment> ClassAssignments { get; set; }

        public MockDataRepository(ICsvReader csvReader, IConfiguration configuration)
        {
            this._csvReader = csvReader;
            this._configuration = configuration;
        }

        public List<ClassAssignment> GetClassAssignments()
        {
            return ClassAssignments ?? (ClassAssignments = this._csvReader.ReadFile(this._configuration["MockDataFile"]));
        }

        public List<ClassAssignment> GetClassAssignmentsByDate(DateTime dateTime)
        {
            return GetClassAssignments().Where(x => x.SubmitDateTime.Date.Equals(dateTime)).ToList();
        }
    }
}
