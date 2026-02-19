using API_Practica.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Practica.Context
{
    public class MascotaContext: DbContext
    {
        public MascotaContext(DbContextOptions<MascotaContext> db) : base(db)
        {
        }
        public DbSet<Mascota> Mascotas { get; set; }
    }
}
