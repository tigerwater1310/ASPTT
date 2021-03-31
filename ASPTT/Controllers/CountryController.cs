using ASPTT.Controllers;
using ASPTT.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPTT.Configurations
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _uniOfWork;
        private readonly ILogger<CountryController > _logger;
        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger)
        {
            _uniOfWork = unitOfWork;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try 
            {
                var countries = await _uniOfWork.Countries.GetAll();
                return Ok(countries );
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went wrong in the {nameof (GetCountries) }");
                return StatusCode(500,"Internal Server Error.Please Try Agin Later.");
            }

            
        
        
        }
    }
}
