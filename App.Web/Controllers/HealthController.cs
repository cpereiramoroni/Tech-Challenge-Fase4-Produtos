using App.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Threading.Tasks;

namespace App.WebAPI.Controllers
{
    [Produces("application/json")]
    [AllowAnonymous]
    public class HealthController : Controller
    {
        private readonly IHealthCheckService _healthCheckAppService;
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public HealthController(IHealthCheckService healthCheckAppService)
        {
            _healthCheckAppService = healthCheckAppService;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet("live")]
        [SwaggerOperation(
        Summary = "EndPoint para Devops"
        )]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public IActionResult Live()
        {
            return Ok(string.Empty);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet("read")]
        [SwaggerOperation(
        Summary = "EndPoint para Devops"
        )]
        [SwaggerResponse(202)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public async Task<IActionResult> Read()
        {
            if (await _healthCheckAppService.HealthCheck())
                return StatusCode((int)HttpStatusCode.Accepted);

            return BadRequest();
        }
    }
}