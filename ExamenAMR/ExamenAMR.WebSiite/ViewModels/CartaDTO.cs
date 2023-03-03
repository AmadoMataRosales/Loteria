using System.ComponentModel.DataAnnotations;

namespace ExamenAMR.WebSite.ViewModels
{
    public class CartaDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Descripcion { get; set; }

        [Required]
        public string? Imagen { get; set; }
    }
}
