//Test Commit
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using OptionalToursAPI.Application.Models;
using OptionalToursAPI.Api.Models;
using OptionalToursAPI.Application.Interfaces;
using OptionalToursAPI.Common.Configuration;
using OptionalToursAPI.Api.Mapper;
using OptionalToursAPI.Core.Entities;
using AutoMapper;
using System.Linq;
using System.Web.Http.Description;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Authorization;
using System.DirectoryServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.Extensions;


namespace OptionalToursAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableShipsController : ControllerBase
    {
        private readonly IAvailableShipsService _availableShipsService;
        private readonly ILogger<AvailableShipsController> _logger;
        private readonly IMapper _mapper;
        private readonly IOptions<CacheSettings> _cacheSettings;

        public AvailableShipsController(IAvailableShipsService availableShipsService, ILogger<AvailableShipsController> logger, IOptions<CacheSettings> cacheSettings, IMapper mapper)
        {
            _availableShipsService = availableShipsService;
            _logger = logger;
            _logger.LogInformation("Nlog triggered");
            _cacheSettings = cacheSettings;
            _mapper = mapper;
        }

        // GET: api/AvailableShips
        [EnableCors("CorsPolicy")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<AvailableShipsResponseModel>))]
        ////[Authorize] 
         public async Task<IActionResult> Get()
        {
            var result = await  _availableShipsService.GetAllAvailableShipsAsync();
            if (result == null || !result.Any())
            {
                return NotFound();
            }

            var mappedEntity = _mapper.Map<IEnumerable<AvailableShipsResponseModel>>(result);
            
                return Ok(mappedEntity);
            
        }

        

        
    } 
}
