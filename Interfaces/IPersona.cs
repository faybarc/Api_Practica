using API_Practica.Models;

namespace API_Practica.Interfaces
{
    public interface IPersona
    {
        Task<IEnumerable<Persona>> GetAllAsync();
        Task<Persona?> GetByIdAsync(int id);
        Task<Persona> CreateAsync(Persona model);
        Task<bool> UpdateAsync(int id, Persona model);
        Task<bool> DeleteAsync(int id);
    }
}
