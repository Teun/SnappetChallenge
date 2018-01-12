using System;
using System.Collections.Generic;
using System.Globalization;
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
        public async Task<IEnumerable<WorkItem>> Get(
            string url = null,
            int top = 10,
            int skip = 0,
            string from = "",
            string to = "",
            string nullDifficulty = "",
            string minDifficulty = "",
            string maxDifficulty = "",
            string correct = "",
            string userId = "",
            string domain = "",
            string minProgress = "",
            string maxProgress = "",
            string subject = "",
            string excercise = "")
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
 
            bool bNullDifficulty;
            if (bool.TryParse(nullDifficulty, out bNullDifficulty))
            {
                if (!bNullDifficulty)
                {
                    result = result.Where(x => x.Difficulty != "NULL");
                }
            }

            decimal dMinDifficulty;
            if (decimal.TryParse(minDifficulty, out dMinDifficulty))
            {
                result = result.Where(x =>
                {
                    decimal dd;
                    if (decimal.TryParse(x.Difficulty, out dd))
                    {
                        return dd >= dMinDifficulty;
                    }
                    else
                    {
                        return true;
                    }
                });
            }

            decimal dMaxDifficulty;
            if (decimal.TryParse(maxDifficulty, out dMaxDifficulty))
            {
                result = result.Where(x =>
                {
                    decimal dd;
                    if (decimal.TryParse(x.Difficulty, out dd))
                    {
                        return dd <= dMaxDifficulty;
                    }
                    else
                    {
                        return true;
                    }
                });
            }

            decimal dMinProgress;
            if (decimal.TryParse(minProgress, out dMinProgress))
            {
                result = result.Where(x => x.Progress >= dMinProgress);
            }

            decimal dMaxProgress;
            if (decimal.TryParse(maxProgress, out dMaxProgress))
            {
                result = result.Where(x => x.Progress <= dMaxProgress);
            }

            DateTime tFrom;
            if (DateTime.TryParseExact(from, "yyyy-MM-ddThh:mm:ss", null, DateTimeStyles.RoundtripKind, out tFrom))
            {
                result = result.Where(x => x.SubmitDateTime >= tFrom);
            }

            DateTime tTo;
            if (DateTime.TryParseExact(to, "yyyy-MM-ddThh:mm:ss", null, DateTimeStyles.RoundtripKind, out tTo))
            {
                result = result.Where(x => x.SubmitDateTime <= tTo);
            }

            if (!string.IsNullOrWhiteSpace(correct))
            {
                var iaCorrect = WebUtility.UrlDecode(correct).Split(',').Select(x => int.Parse(x.Trim())).ToList();
                result = result.Where(x => iaCorrect.Contains(x.Correct));
            }

            if (!string.IsNullOrWhiteSpace(userId))
            {
                var iaUser = WebUtility.UrlDecode(userId).Split(',').Select(x => int.Parse(x.Trim())).ToList();
                result = result.Where(x => iaUser.Contains(x.UserId));
            }

            if (!string.IsNullOrWhiteSpace(domain))
            {
                var saDomain = WebUtility.UrlDecode(domain).Split(',').ToList();
                result = result.Where(x => saDomain.Contains(x.Domain));
            }

            if (!string.IsNullOrWhiteSpace(subject))
            {
                var saSubject = WebUtility.UrlDecode(subject).Split(',').ToList();
                result = result.Where(x => saSubject.Contains(x.Subject));
            }

            int iExcercise;
            if (!string.IsNullOrWhiteSpace(excercise) && int.TryParse(WebUtility.UrlDecode(excercise), out iExcercise) )
            {
                result = result.Where(x => iExcercise == x.ExerciseId);
            }

            result = result.Skip(skip);
            if (top >= 0)
                result = result.Take(top);

            return result;
        }
    }
}
