using Microsoft.AspNetCore.Mvc;
using Backend.Core.Interfaces;
using Backend.API.Modelos;
using Backend.Core.Entities;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var usuarios = _usuarioService.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetUsuario(int id)
        {
            var usuario = _usuarioService.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult CreateUsuario(UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var usuario = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                CorreoElectronico = usuarioDTO.CorreoElectronico,
                FechaNacimiento = usuarioDTO.FechaNacimiento,
                Activo = usuarioDTO.Activo
            };

            _usuarioService.CreateUsuario(usuario);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(int id, UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var usuario = _usuarioService.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Nombre = usuarioDTO.Nombre;
            usuario.Apellido = usuarioDTO.Apellido;
            usuario.CorreoElectronico = usuarioDTO.CorreoElectronico;
            usuario.FechaNacimiento = usuarioDTO.FechaNacimiento;
            usuario.Activo = usuarioDTO.Activo;

            _usuarioService.UpdateUsuario(usuario);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            var usuario = _usuarioService.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _usuarioService.DeleteUsuario(usuario);
            return NoContent();
        }
    }
}