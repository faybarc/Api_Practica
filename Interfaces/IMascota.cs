using API_Practica.Models;

namespace API_Practica.Interfaces
{
    public interface IMascota
    {
        Task<IEnumerable<Mascota>> GetAllAsync();
        Task<Mascota?> GetByIdAsync(int id);
        Task<Mascota> CreateAsync(Mascota modelo);
        Task<bool> UpdateAsync(int id, Mascota modelo);
        Task<bool> DeleteAsync(int id);

    }
}
