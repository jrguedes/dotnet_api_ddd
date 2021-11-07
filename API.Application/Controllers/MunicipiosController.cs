using System;
using System.Net;
using System.Threading.Tasks;
using API.Domain.Dtos.Municipio;
using API.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipiosController : ControllerBase
    {
        private IMunicipioService _service;

        public MunicipiosController(IMunicipioService service)
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

        [HttpGet("{id}", Name = "GetMunicipioById")]
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


        [HttpGet("porCodIBGE/{codIBGE}")]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<ActionResult> GetByIBGE(int codIBGE)
        {
            try
            {
                return Ok(await _service.GetByIBGEAsync(codIBGE));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Post([FromBody] MunicipioDto municipio)
        {
            try
            {
                var result = await _service.PostAsync(municipio);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetMunicipioById", new { id = result.Id })), result);
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
        public async Task<ActionResult> Put([FromBody] MunicipioDto municipio)
        {
            try
            {
                var result = await _service.PutAsync(municipio);
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
