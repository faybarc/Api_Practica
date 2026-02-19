using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace API_Practica.Models
{
    public class Mascota
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especie { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Foto { get; set; } = string.Empty;

    }
}
