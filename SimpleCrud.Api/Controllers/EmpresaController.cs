using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Application.Interfaces;
using SimpleCrud.Application.Models;
using SimpleCrud.Domain.Models;

namespace SimpleCrud.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _service;

        public EmpresaController(IEmpresaService service)
        {
            _service = service;
        }

        //GET api/v1/empresa
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var empresas = await _service.GetAll();
            
            if (empresas != null)
                return Ok(empresas);
            
            return BadRequest(new SimpleResponse(500, 500, "Erro ao obter empresas."));
        }

        //POST api/v1/empresa
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Empresa empresa)
        {
            var response = await _service.Add(empresa);
            
            return StatusCode(response.Status, response);
        }

        //PUT api/v1/empresa/
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Empresa empresa)
        {
            var response = await _service.Update(empresa);

            return StatusCode(response.Status, response);
        }

        //DELETE api/v1/empresa/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _service.Delete(id);

            return StatusCode(response.Status, response);
        }
    }
}