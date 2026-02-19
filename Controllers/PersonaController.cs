using API_Practica.Interfaces;
using API_Practica.Models;
using API_Practica.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersona _service;

        public PersonaController(IPersona service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var datos = await _service.GetAllAsync();
            return Ok(datos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dato = await _service.GetByIdAsync(id);
            if(dato == null)
                return NotFound();
            return Ok(dato);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Persona model)
        {
            var created = await _service.CreateAsync(model);

            return CreatedAtAction(nameof(GetById), new { id = created.Id}, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Persona model)
        {
            if(id != model.Id)
                return BadRequest();

            var updated = await _service.UpdateAsync(id, model);
            
            if(!updated)
                return NotFound();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if(!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
