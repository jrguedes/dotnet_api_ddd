using System;
using System.Net;
using System.Threading.Tasks;
using API.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace API.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)        
        {
            _service = service;
        }
        [HttpGet]
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

    }
}
