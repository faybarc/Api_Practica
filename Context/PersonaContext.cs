using API_Practica.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Practica.Context
{
    public class PersonaContext : DbContext
    {
        public PersonaContext(DbContextOptions<PersonaContext> db): base(db)
        {
        }
        public DbSet<Persona> Personas { get; set; }
    }
}
