using SnappetChallenge.Domain.Contracts;
using SnappetChallenge.Domain.Entities;
using SnappetChallenge.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly ISnappetChallengeContext context;

        public ExerciseService(ISnappetChallengeContext context)
        {
            this.context = context;
        }

        public IEnumerable<Exercise> GetAllExercises()
        {
   
            return null;
        }

        public int GetExerciseCount()
        {
            return 5;
        }
    }

}
