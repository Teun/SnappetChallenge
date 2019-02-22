using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using StudentsAPI.WebApi.Context;
using StudentsAPI.WebApi.DTOs;
using StudentsAPI.WebApi.Models;

namespace StudentsAPI.WebApi.Services
{
    public interface IProgressService
    {
        Task<Progress> GetProgressAsync(int userId, GetProgressDTO dto);
    }

    public class ProgressService : IProgressService
    {
        private readonly ILogger<WorkItemService> _logger;
        private readonly IWorkItemRepository _workItemRepository;

        public ProgressService(ILogger<WorkItemService> logger, IWorkItemRepository workItemRepository)
        {
            _logger = logger;
            _workItemRepository = workItemRepository;
        }

        public async Task<Progress> GetProgressAsync(int userId, GetProgressDTO dto)
        {
            try
            {
                var result = new Progress();
                var filter = BuildFilter(userId, dto);
                result.ProgressItems = (await _workItemRepository.GetProgressAsync(filter)).ToList();

                if (result.ProgressItems.Any())
                {
                    result.TotalMonthProgress = result.ProgressItems.Sum(i => i.TotalProgress);
                    result.AverageProgress = result.TotalMonthProgress / result.ProgressItems.Count();
                }
                
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has occurred while getting progress");
                throw;
            }
        }

        private FilterDefinition<WorkItem> BuildFilter(int userId, GetProgressDTO dto)
        {
            var monthStart = new DateTime(dto.Year.Value, dto.Month.Value, 1);

            var builder = Builders<WorkItem>.Filter;
            var filter = builder.Empty;

            filter &= builder.Eq(i => i.UserId, userId);
            filter &= builder.Gte(i => i.SubmitDateTime, monthStart);
            filter &= builder.Lt(i => i.SubmitDateTime, monthStart.AddMonths(1));

            if (dto.Domain.HasValue)
                filter &= builder.Eq(i => i.Domain, dto.Domain.ToString().Replace("Dash", "-"));

            return filter;
        }
    }
}
