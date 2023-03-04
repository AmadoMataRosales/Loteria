using Microsoft.Build.Framework;

namespace ExamenAMR.WebSite.Models
{
    public class Carta
    {
        public int Id { get; set; }

        [Required]   
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public string Imagen { get; set; } = string.Empty;
    }
}
