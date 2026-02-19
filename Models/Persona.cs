using System.ComponentModel.DataAnnotations;

namespace API_Practica.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime Fecha_Nacimiento { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;


    }
}
