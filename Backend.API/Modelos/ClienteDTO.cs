using Backend.API.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.API.Modelos
{
    public class ClienteDTO : UsuarioDTO
    {

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Telefono { get; set; }


    }
}
