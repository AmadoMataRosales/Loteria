using System.ComponentModel.DataAnnotations;

namespace ExamenAMR.WebSite.ViewModels
{
    public class TablaDetalleDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int IdTabla { get; set; }

        [Required]
        public int IdCarta { get; set; }
    }
}
