using System;
using System.Collections.Generic;
using Snappet_challenge_api.Models;

namespace Snappet_challenge_api.Services
{
    public interface IStudentsService
    {
        public List<UserSummary> GetStudents();
    }
}
