using System;
using System.Net;
using System.Threading.Tasks;
using API.Domain.Entities;
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
        
        [HttpGet("{id}", Name = "GetById")]                
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

        [HttpPost]
        public  async Task<ActionResult> Post([FromBody] UserEntity user)
        {
            try
            {
                 var result = await _service.PostAsync(user);
                 if (result != null){
                     //Retorna no Header o link de acesso ao objeto
                     return Created(new Uri(Url.Link("GetById", new {id = result.Id})), result);
                 }
                 return  BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


    }
}
