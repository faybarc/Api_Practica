using API_Practica.Context;
using API_Practica.Interfaces;
using API_Practica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace API_Practica.Services
{
    public class PersonaServices : IPersona
    {
        private readonly PersonaContext _context;

        public PersonaServices(PersonaContext context)
        {
            _context = context;
        }

        public async Task<Persona> CreateAsync(Persona modelo)
        {
            await _context.Personas.AddAsync(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var registro = await _context.Personas.FindAsync(id);

            if(registro == null)
                return false;

            _context.Personas.Remove(registro);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<Persona?> GetByIdAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, Persona modelo)
        {
            var persona = await _context.Personas.FindAsync(id);

            if(persona == null)
                return false;

            persona.Nombre = modelo.Nombre;
            persona.Telefono = modelo.Telefono;
            persona.Direccion = modelo.Direccion;
            persona.Fecha_Nacimiento = modelo.Fecha_Nacimiento;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
