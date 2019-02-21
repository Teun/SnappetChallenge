using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using StudentsAPI.WebApi.Context;
using StudentsAPI.WebApi.DTOs;
using StudentsAPI.WebApi.Models;

namespace StudentsAPI.WebApi.Services
{
    public interface IWorkItemService
    {
        Task<IEnumerable<WorkItem>> GetWorkItemsAsync(GetWorkItemsDTO dto);
    }

    public class WorkItemService : IWorkItemService
    {
        private readonly ILogger<WorkItemService> _logger;
        private readonly IWorkItemRepository _workItemRepository;

        public WorkItemService(ILogger<WorkItemService> logger, IWorkItemRepository workItemRepository)
        {
            _logger = logger;
            _workItemRepository = workItemRepository;
        }

        public async Task<IEnumerable<WorkItem>> GetWorkItemsAsync(GetWorkItemsDTO dto)
        {
            try
            {
                var filter = BuildFilter(dto);
                var x =  await _workItemRepository.GetWorkItemsAsync(filter, dto.PageNumber);
                return x;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has occurred while getting work items");
                throw;
            }
        }

        private FilterDefinition<WorkItem> BuildFilter(GetWorkItemsDTO dto)
        {
            var builder = Builders<WorkItem>.Filter;
            var filter = builder.Empty;

            if (dto.UserId.HasValue)
                filter &= builder.Eq(i => i.UserId, dto.UserId);
            if (dto.SubmitDateTime.HasValue)
            {
                filter &= builder.Gt(i => i.SubmitDateTime, dto.SubmitDateTime);
                filter &= builder.Lt(i => i.SubmitDateTime, dto.SubmitDateTime.Value.AddDays(1));
            }
                
            if (!string.IsNullOrEmpty(dto.Domain))
                filter &= builder.Eq(i => i.Domain, dto.Domain);

            return filter;
        }
    }
}
