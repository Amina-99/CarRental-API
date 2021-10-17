using DiplomskiRad.DTOS;
using DiplomskiRad.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _service;
        private readonly ILogger<AnalyticsController> _logger;

        public AnalyticsController(IAnalyticsService service, ILogger<AnalyticsController> logger)
        {
            _service = service;
            _logger = logger;
        }
    
        [HttpGet("month-income")]
        public async Task<ActionResult<IEnumerable<MonthIncomeDTO>>> GetMonthIncome()
        {   try
            {
                var result = await _service.GetMonthIncomeAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET: /api/Analytics/month-income");
                return StatusCode(500);
            }
        }
    }
}
