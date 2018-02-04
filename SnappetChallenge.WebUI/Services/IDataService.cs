namespace SnappetChallenge.WebUI.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SnappetChallenge.WebUI.Models;

    public interface IDataService
    {
        Task<IEnumerable<StudentResultModel>> GetByDate(DateTime from, DateTime to);
    }
}