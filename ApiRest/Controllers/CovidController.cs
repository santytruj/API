using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidDataController : ControllerBase
    {
        private readonly ICovidService _covidService;

        public CovidDataController(ICovidService covidService)
        {
            _covidService = covidService;
        }

        [HttpGet]
        [Authorize(Roles = "buscador")]
        [Route("statesdata")]
        public async Task<ActionResult<IEnumerable<StateData>>> GetStatesDataAsync()
        {
            try
            {
                var result = await _covidService.GetStateDataAsync();
                if (result != null)
                    return Ok(result);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "ciudadano")]
        [Route("covidcases")]
        public async Task<ActionResult<IEnumerable<CovidCase>>> GetCovidCasesAsync()
        {
            try
            {
                var result = await _covidService.GetCovidCaseAsync();
                if (result != null)
                    return Ok(result);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
