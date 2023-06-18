
using Backend.Core.Entities;
using System.Collections.Generic;

namespace Backend.Core.Interfaces
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetClientes();
        Cliente GetCliente(int id);
        void CreateCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(Cliente cliente);
    }
}
