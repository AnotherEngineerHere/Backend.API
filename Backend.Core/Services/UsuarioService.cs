using Backend.Core.Entities;
using Backend.Core.Interfaces;
using System.Collections.Generic;

namespace Backend.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository<Usuario> _repository;
        public UsuarioService(IRepository<Usuario> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return (IEnumerable<Usuario>)_repository.GetAll();
        }

        public Usuario GetUsuario(int id)
        {
            return _repository.GetById(id);
        }

        public void CreateUsuario(Usuario usuario)
        {
            _repository.Add(usuario);
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _repository.Update(usuario);
        }

        public void DeleteUsuario(Usuario usuario)
        {
            _repository.Delete(usuario);
        }
    }
}
