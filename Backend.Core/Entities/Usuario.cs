using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Entities
{
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int UsuarioId { get; set; }

        [Column("first_name")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Column("last_name")]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Column("email")]
        [StringLength(100)]
        public string CorreoElectronico { get; set; }

        [Column("date_of_birth", TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }

        [Column("is_active")]
        public bool Activo { get; set; }


    }
}
