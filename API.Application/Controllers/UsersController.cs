using System;
using System.Net;
using System.Threading.Tasks;
using API.Domain.Dtos.User;
using API.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Manager")]
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

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public  async Task<ActionResult> Post([FromBody] UserDto user)
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

        [HttpPut]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Put([FromBody] UserDto user)
        {
            try
            {
                 var result = await _service.PutAsync(user);
                 if (result != null){                     
                     return Ok(result);
                 }
                 return  BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPatch]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<ActionResult> Patch([FromBody] UserDto user)
        {
            //verificar esta implementação
            await Task.Delay(500);
            return NoContent();
            /*
            try
            {
                 var result = await _service.PutAsync(user);
                 if (result != null){                     
                     return Ok(result);
                 }
                 return  BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
            */
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await _service.DeleteAsync(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


    }
}
