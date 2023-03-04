using System;
using System.ComponentModel.DataAnnotations;

namespace ExamenAMR.WebSite.Models
{
    public class Tabla
    {
        public int Id { get; set; }

        [Required]
        public string? IdUsuario { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }


    }
}
