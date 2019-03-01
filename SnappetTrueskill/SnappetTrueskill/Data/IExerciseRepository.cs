using Moserware.Skills;
using SnappetTrueskill.Domain;
using System.Collections.Generic;

namespace SnappetTrueskill.Data
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> GetAll();
        Exercise Get(int id);
        void Insert(Exercise exercise);
        bool Contains(int id);
        void UpdateRating(int id, Rating newRating);
    }
}
