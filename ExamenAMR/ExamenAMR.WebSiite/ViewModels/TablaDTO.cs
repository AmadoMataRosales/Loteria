using System.ComponentModel.DataAnnotations;

namespace ExamenAMR.WebSite.ViewModels
{
    public class TablaDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }
    }
}
