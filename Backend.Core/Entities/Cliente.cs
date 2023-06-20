using Backend.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Entities
{
    public class Cliente : Usuario
    {
        [Column("address")]
        [StringLength(1000)]
        public string Direccion { get; set; }

        [Column("phone_number")]
        [StringLength(100)]
        public string Telefono { get; set; }
    }
}
