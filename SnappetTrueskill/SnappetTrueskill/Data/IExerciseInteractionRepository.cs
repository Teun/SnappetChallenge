using System;
using System.Collections.Generic;

namespace SnappetTrueskill.Data
{
    public interface IExerciseInteractionRepository : IDisposable
    {
        IEnumerable<ExerciseInteraction> GetAll();
    }
}
