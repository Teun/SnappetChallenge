using Moserware.Skills;
using SnappetTrueskill.Domain;
using System.Collections.Generic;

namespace SnappetTrueskill.Data
{
    public class InMemoryExerciseRepository : IExerciseRepository
    {
        private readonly Dictionary<int, Exercise> _exercises = new Dictionary<int, Exercise>();

        public bool Contains(int id)
        {
            return _exercises.ContainsKey(id);
        }

        public Exercise Get(int id)
        {
            return _exercises[id];
        }

        public IEnumerable<Exercise> GetAll()
        {
            return _exercises.Values;
        }

        public void Insert(Exercise exercise)
        {
            _exercises.Add(exercise.Id, exercise);
        }

        public void UpdateRating(int id, Rating newRating)
        {
            _exercises[id].Rating = newRating;
        }
    }
}
