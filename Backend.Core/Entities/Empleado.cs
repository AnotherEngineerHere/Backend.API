using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Entities
{
    public class Empleado : Usuario
    {

        [Column("salary")]
        [StringLength(1000)]
        int Salario { get; set; }


        [Column("hiringDate")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [StringLength(1000)]
        DateTime FechaDeIngreso { get; set; }

        [Column("role")]
        [StringLength(1000)]
        string Rol { get; set; }
    }
}
