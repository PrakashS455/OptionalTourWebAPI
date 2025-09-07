using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OptionalToursAPI.Common.Configuration;
using OptionalToursAPI.Api.Models;
using OptionalToursAPI.Application.Interfaces;
using Microsoft.AspNetCore.Cors;
using System.Web.Http.Description;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace OptionalToursAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableItinerariesController : ControllerBase
    {
        private readonly IAvailableItinerariesService _availableItinerariesService;
        private readonly ILogger<AvailableItinerariesController> _logger;
        private readonly IMapper _mapper;
        private readonly IOptions<CacheSettings> _cacheSettings;

        public AvailableItinerariesController(IAvailableItinerariesService availableItinerariesService, ILogger<AvailableItinerariesController> logger, IOptions<CacheSettings> cacheSettings, IMapper mapper)
        {
            _availableItinerariesService = availableItinerariesService;
            _logger = logger;
            _logger.LogInformation("Nlog triggered");
            _cacheSettings = cacheSettings;
            _mapper = mapper;
        }

        // GET: api/AvailableItineraries
        [EnableCors("CorsPolicy")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<AvailableItinerariesResponseModel>))]
        ////[Authorize] 
        public async Task<IActionResult> Get()
        {
            var result = await _availableItinerariesService.GetAllAvailableItinerariesAsync();
            if (result == null || !result.Any())
            {
                return NotFound();
            }

            var mappedEntity = _mapper.Map<IEnumerable<AvailableItinerariesResponseModel>>(result);

            return Ok(mappedEntity);

        }

    }
}
