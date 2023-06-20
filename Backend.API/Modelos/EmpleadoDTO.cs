using System.ComponentModel.DataAnnotations;

namespace Backend.API.Modelos
{
    public class EmpleadoDTO : UsuarioDTO
    {
        [Required]
        public int Salary { get; set; }

        [Required]
        public DateTime hireDate { get; set; }
    }
}
