using API_Practica.Interfaces;
using API_Practica.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly IMascota _service;

        public MascotaController(IMascota service)
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
        public async Task<IActionResult> Create(Mascota modelo)
        {
            var created = await _service.CreateAsync(modelo);
            return CreatedAtAction(nameof(GetById), new {id = created.Id}, created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, Mascota modelo)
        {
            var updated = await _service.UpdateAsync(id, modelo);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if(!deleted)
                return NotFound();

            return NoContent();
        }

    }
}
