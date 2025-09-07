using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OptionalToursAPI.Api.Models;
using OptionalToursAPI.Application.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace OptionalToursAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CachingController : ControllerBase
    {
        private readonly IAppCache _cache;

        public CachingController(IAppCache cache)
        {
            _cache = cache;
        }

        [EnableCors("CorsPolicy")]
        [HttpGet]
        public IActionResult ListCache()
        {
            var result = _cache.Select(t => new
            {
                Key = t.Key,
                Value = t.Value
            }).ToArray();
            return new JsonResult(result);
        }

        [EnableCors("CorsPolicy")]
        [HttpPut]
        public IActionResult ClearAllCache()
        {
            this._cache.Clear();
            return new JsonResult(true);
        }

        // POST: api/Caching
        [EnableCors("CorsPolicy")]
        [HttpPost]
        public IActionResult Post([FromBody] CachingModel cachingModel)
        {
            // url input should be given in this format - /api/{controllername}
            string cacheKey = cachingModel.Url;
            _cache.Remove(cacheKey);
            return Ok();
        }
    }
}
