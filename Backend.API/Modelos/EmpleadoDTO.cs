using System.ComponentModel.DataAnnotations;

namespace Backend.API.Modelos
{
    public class EmpleadoDTO : UsuarioDTO
    {
        [Required]
        public int Salary { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime hireDate { get; set; }


        [Required]
        public string Rol { get; set; }
    }
}
