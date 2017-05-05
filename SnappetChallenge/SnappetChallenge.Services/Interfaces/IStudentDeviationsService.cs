namespace SnappetChallenge.Services.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Models;

    public interface IStudentDeviationsService
    {
        List<StudentDeviationsModel> Get(DateTime startDateTime, DateTime endDateTime );
    }
}
