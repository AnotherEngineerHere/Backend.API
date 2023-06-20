using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public interface IEmpleadoService
    {
        IEnumerable<Empleado> GetEmpleados();
        Empleado GetEmpleado(int id);
        void CreateEmpleado(Empleado empleado);
        void UpdateEmpleado(Empleado empleado);
        void DeleteEmpleado(Empleado empleado);
    }
}