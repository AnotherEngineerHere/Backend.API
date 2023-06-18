using Backend.API.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.API.Modelos
{
    public class ClienteDTO : UsuarioDTO
    {
 
        public string Dirección { get; set; }

        public string Teléfono { get; set; }
    }
}
