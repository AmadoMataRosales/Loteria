using System.ComponentModel.DataAnnotations;

namespace ExamenAMR.WebSite.Models
{
    public class TablaDetalle
    {
        public int Id { get; set; }

        [Required]
        public int IdTabla { get; set; }

        [Required]
        public int IdCarta { get; set; }
    }
}
