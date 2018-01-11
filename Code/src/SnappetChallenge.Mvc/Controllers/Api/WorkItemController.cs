using System;
using System.Collections.Generic;
using System.Linq;
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
    public class WorkItemController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;
        private readonly IWorkItemRespository _workItemRepository;

        public WorkItemController(IMemoryCache memoryCache, IConfiguration configuration, IWorkItemRespository workItemRepository)
        {
            _cache = memoryCache;
            _configuration = configuration;
            _workItemRepository = workItemRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<WorkItem>> Get(string url = null, int top = 10, int skip = 0)
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

            IEnumerable<WorkItem> cacheEntry;
            var key = CacheKeys.GetWorkDataKey(url);

            if (!_cache.TryGetValue(key, out cacheEntry))
            {
                cacheEntry = await _workItemRepository.GetAll(uri);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(double.Parse(_configuration["CacheExprirationInMinutes"])));

                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }

            IEnumerable<WorkItem> result = cacheEntry.ToList();
            result = result.Skip(skip);
            if (top >= 0)
                result = result.Take(top);

            return result;
        }
    }
}
