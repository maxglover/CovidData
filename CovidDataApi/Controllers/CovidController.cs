using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CovidDataApi.Models;
using CovidDataApi.Services;
using Microsoft.AspNetCore.Cors;


namespace CovidDataApi.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class CovidDataController : ControllerBase
    {
        private readonly CdcService _cdcService;

        public CovidDataController(CdcService cdcService)
        {
            _cdcService = cdcService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _cdcService.GetCovidDeathDataAsync();
            return Ok(data);
        }
    }
}