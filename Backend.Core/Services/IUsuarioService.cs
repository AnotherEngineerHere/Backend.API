using Backend.Core.Entities;
using System.Collections.Generic;

namespace Backend.Core.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetUsuarios();
        Usuario GetUsuario(int id);
        void CreateUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(Usuario usuario);
    }
}
