using API_Practica.Context;
using API_Practica.Interfaces;
using API_Practica.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Practica.Services
{
    public class MascotaServices: IMascota
    {
        private readonly MascotaContext _context;

        public MascotaServices(MascotaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mascota>> GetAllAsync()
        {
            return await _context.Mascotas
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<Mascota?> GetByIdAsync(int id)
        {
            return await _context.Mascotas.FindAsync(id);
        }

        public async Task<Mascota> CreateAsync(Mascota modelo)
        {
            await _context.Mascotas.AddAsync(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> UpdateAsync(int id, Mascota modelo)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            
            if(mascota == null)
                return false;

            mascota.Nombre = modelo.Nombre;
            mascota.Especie = modelo.Especie;
            mascota.Edad = modelo.Edad;
            mascota.Foto = modelo.Foto;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var registro = await _context.Mascotas.FindAsync(id);
            
            if(registro == null) 
                return false;

            _context.Mascotas.Remove(registro);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
