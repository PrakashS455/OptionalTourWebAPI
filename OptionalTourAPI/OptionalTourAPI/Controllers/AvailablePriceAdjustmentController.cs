using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Cors;
using OptionalToursAPI.Api.Models;
using OptionalToursAPI.Application.Interfaces;
using OptionalToursAPI.Common.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace OptionalToursAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailablePriceAdjustmentController : ControllerBase
    {
        private readonly IAvailablePriceAdjustmentService _availablePriceAdjustmentService;
        private readonly ILogger<AvailablePriceAdjustmentController> _logger;
        private readonly IMapper _mapper;
        private readonly IOptions<CacheSettings> _cacheSettings;

        public AvailablePriceAdjustmentController(IAvailablePriceAdjustmentService availablePriceAdjustmentService, ILogger<AvailablePriceAdjustmentController> logger, IOptions<CacheSettings> cacheSettings, IMapper mapper)
        {
            _availablePriceAdjustmentService = availablePriceAdjustmentService;
            _logger = logger;
            _logger.LogInformation("Nlog triggered");
            _cacheSettings = cacheSettings;
            _mapper = mapper;
        }

        // GET: api/AvailablePriceAdjustment
        [EnableCors("CorsPolicy")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<AvailablePriceAdjustmentResponseModel>))]
        ////[Authorize] 
        public async Task<IActionResult> Get()
        {
            var result = await _availablePriceAdjustmentService.GetAllAvailablePriceAdjustmentAsync();
            if (result == null || !result.Any())
            {
                return NotFound();
            }

            var mappedEntity = _mapper.Map<IEnumerable<AvailablePriceAdjustmentResponseModel>>(result);

            return Ok(mappedEntity);

        }
    }
}
