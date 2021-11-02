using System;
using System.Net;
using System.Threading.Tasks;
using API.Domain.Interfaces.Services.UF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Application.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UFsController : ControllerBase
    {
        private IUFService _service;

        public UFsController(IUFService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _service.GetAllAsync());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _service.GetAsync(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
