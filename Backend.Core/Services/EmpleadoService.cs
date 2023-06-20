using Backend.Core.Entities;
using Backend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IRepository<Empleado> _repository;
        public EmpleadoService(IRepository<Empleado> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Empleado> GetEmpleados()
        {
            return _repository.GetAll();
        }

        public Empleado GetEmpleado(int id)
        {
            return _repository.GetById(id);
        }

        public void CreateEmpleado(Empleado empleado)
        {
            _repository.Add(empleado);
        }

        public void UpdateEmpleado(Empleado empleado)
        {
            _repository.Update(empleado);
        }

        public void DeleteEmpleado(Empleado empleado)
        {
            _repository.Delete(empleado);
        }
    }
}

