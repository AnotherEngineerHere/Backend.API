using Backend.Core.Entities;
using Backend.Core.Interfaces;

using System.Collections.Generic;

namespace Backend.Core.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IRepository<Cliente> _repository;
        public ClienteService(IRepository<Cliente> repository)
        {
           _repository = repository;
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _repository.GetAll();
        }

        public Cliente GetCliente(int id)
        {
            return _repository.GetById(id);
        }

        public void CreateCliente(Cliente cliente)
        {
            _repository.Add(cliente);
        }

        public void UpdateCliente(Cliente cliente)
        {
            _repository.Update(cliente);
        }

        public void DeleteCliente(Cliente cliente)
        {
            _repository.Delete(cliente);
        }
    }
}
