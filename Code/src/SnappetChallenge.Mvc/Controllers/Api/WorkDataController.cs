using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SnappetChallenge.Mvc.Common;
using SnappetChallenge.Mvc.DataLayer;
using SnappetChallenge.Mvc.Models;

namespace SnappetChallenge.Mvc.Controllers.Api
{
    [Route("api/[controller]")]
    public class WorkDataController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;
        private readonly IWorkItemRespository _workItemRepository;

        public WorkDataController(IMemoryCache memoryCache, IConfiguration configuration, IWorkItemRespository workItemRepository)
        {
            _cache = memoryCache;
            _configuration = configuration;
            _workItemRepository = workItemRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<WorkItem>> GetAll(string url = null)
        {
            Uri uri;
            if (url == null)
            {
                var host = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
                uri = new Uri(new Uri(host), "/data/work.csv");
            }
            else
            {
                uri = new Uri(url);
            }

            WorkItem[] cacheEntry;

            if (!_cache.TryGetValue(CacheKeys.WorkData, out cacheEntry))
            {
                cacheEntry = await _workItemRepository.GetAll(uri);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(double.Parse(_configuration["CacheExprirationInMinutes"])));

                _cache.Set(CacheKeys.WorkData, cacheEntry, cacheEntryOptions);
            }

            return cacheEntry;
        }
    }
}
