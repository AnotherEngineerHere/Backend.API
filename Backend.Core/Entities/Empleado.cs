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
        [StringLength(1000)]
        DateTime FechaDeIngreso { get; set; }
    }
}
