using System;
using System.Net;
using System.Threading.Tasks;
using API.Domain.Dtos.Endereco;
using API.Domain.Interfaces.Services.Endereco;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecosController : ControllerBase
    {
        private IEnderecoService _service;

        public EnderecosController(IEnderecoService service)
        {
            _service = service;
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


        [HttpGet("porCEP/{cep}")]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<ActionResult> GetByCEP(string cep)
        {
            try
            {
                return Ok(await _service.GetByCEPAsync(cep));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Post([FromBody] EnderecoDto endereco)
        {
            try
            {
                var result = await _service.PostAsync(endereco);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetById", new { id = result.Id })), result);
                }
                return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Put([FromBody] EnderecoDto endereco)
        {
            try
            {
                var result = await _service.PutAsync(endereco);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
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
