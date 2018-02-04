namespace SnappetChallenge.WebApi.Helpers
{
    using System;
    using System.Collections.Generic;

    using SnappetChallenge.WebApi.Models;

    public interface IFileRepository<T>
        where T : class
    {
        IList<T> GetByData(DateTime from, DateTime to);

        IEnumerable<StudentModel> GetGroupedListByData(DateTime from, DateTime to);
    }
}
