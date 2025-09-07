using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using  OptionalToursAPI.Common.Configuration;

namespace OptionalToursAPI.Application.Attributes
{
    public class CachingAttribute : Attribute, IAsyncActionFilter
    {
        private readonly IOptions<CacheSettings> _cacheSettings;
        private readonly IMemoryCache _cache;
        private readonly double _absoluteExpiration;
        private readonly double _slidingExpiration;

        public CachingAttribute(IMemoryCache cache, IOptions<CacheSettings> cacheSettings)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _cacheSettings = cacheSettings;
            _absoluteExpiration = Convert.ToDouble(_cacheSettings.Value.AbsoluteExpiration);
            _slidingExpiration = Convert.ToDouble(_cacheSettings.Value.SlidingExpiration);
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {

            var methodType = context.HttpContext.Request.Method;
            string cacheKey = context.HttpContext.Request.Path;
            
            if (methodType.Equals("GET"))
            {
                // before the action executes  
                var cacheValue = _cache.Get(cacheKey);
                if (cacheValue != null)
                {
                    context.Result = new ObjectResult(cacheValue);
                    return;
                }

                ActionExecutedContext resultContext = await next();
                
                //after the action executes  
                if (resultContext.Result != null)
                {
                    var result = (ObjectResult)resultContext.Result;
                    _cache.Set(cacheKey, result.Value, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_absoluteExpiration),
                        SlidingExpiration = TimeSpan.FromMinutes(_slidingExpiration)
                    });
                }
            }
            else
            {
                await next();
                _cache.Remove(cacheKey);
                var routeValues = context.HttpContext.GetRouteData().Values;

                var id = routeValues["id"]?.ToString();
                if (id != null)
                {
                    cacheKey = cacheKey.Replace($"/{id}", string.Empty);
                    _cache.Remove(cacheKey);
                }
            }
        }
    }
}
