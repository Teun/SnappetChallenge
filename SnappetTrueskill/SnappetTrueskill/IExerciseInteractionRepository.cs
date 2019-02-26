using System;
using System.Collections.Generic;

namespace SnappetTrueskill
{
    public interface IExerciseInteractionRepository : IDisposable
    {
        IEnumerable<ExerciseInteraction> GetAll();
        ExerciseInteraction Get(int id);
        void Insert(ExerciseInteraction interaction);
        void Delete(int id);
        void Update(ExerciseInteraction interaction);
        void Save();
    }
}
