using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.API.Modelos
{
    public class UsuarioDTO
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public bool Activo { get; set; }
    }
}
