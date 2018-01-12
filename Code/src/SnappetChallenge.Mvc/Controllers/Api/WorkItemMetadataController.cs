using System;
using System.Collections;
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
    public class WorkItemMetadataController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;
        private readonly IWorkItemRespository _workItemRepository;

        public WorkItemMetadataController(IMemoryCache memoryCache, IConfiguration configuration,
            IWorkItemRespository workItemRepository)
        {
            _cache = memoryCache;
            _configuration = configuration;
            _workItemRepository = workItemRepository;
        }

        [HttpGet]
        public async Task<WorkItemsMetadata> Get(string url = null)
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

            IList<WorkItem> cacheEntry;
            var key = CacheKeys.GetWorkDataKey(url);

            if (!_cache.TryGetValue(key, out cacheEntry))
            {
                cacheEntry = await _workItemRepository.GetAll(uri);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(
                        TimeSpan.FromMinutes(double.Parse(_configuration["CacheExprirationInMinutes"])));

                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }

            return new WorkItemsMetadata
            {
                AllCorrects = cacheEntry.Select(x => x.Correct).Distinct().ToArray(),
                AllDomains = cacheEntry.Select(x => x.Domain).Distinct().ToArray(),
                AllExerciseIds = cacheEntry.Select(x => x.ExerciseId).Distinct().ToArray(),
                AllProgresses = cacheEntry.Select(x => x.Progress).Distinct().ToArray(),
                AllUserIds = cacheEntry.Select(x => x.UserId).Distinct().ToArray(),
                AllSubjects = cacheEntry.Select(x => x.Subject).Distinct().ToArray(),
                TotalCount = cacheEntry.Count
            };
        }

        private static int? ToNullableInt(string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }

        private static decimal? ToNullableDecimal(string s)
        {
            decimal i;
            if (decimal.TryParse(s, out i)) return i;
            return null;
        }
    }
}
