using Microsoft.AspNetCore.Mvc;
using Backend.Core.Interfaces;
using Backend.API.Modelos;
using Backend.Core.Entities;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            var clientes = _clienteService.GetClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetCliente(int id)
        {
            var cliente = _clienteService.GetCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult CreateCliente(ClienteDTO clienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cliente = new Cliente
            {
                Nombre = clienteDTO.Nombre,
                Apellido = clienteDTO.Apellido,
                CorreoElectronico = clienteDTO.CorreoElectronico,
                FechaNacimiento = clienteDTO.FechaNacimiento,
                Activo = clienteDTO.Activo,
                Dirección = clienteDTO.Dirección,
                Teléfono = clienteDTO.Teléfono
            };

            _clienteService.CreateCliente(cliente);
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, ClienteDTO clienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cliente = _clienteService.GetCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Nombre = clienteDTO.Nombre;
            cliente.Apellido = clienteDTO.Apellido;
            cliente.CorreoElectronico = clienteDTO.CorreoElectronico;
            cliente.FechaNacimiento = clienteDTO.FechaNacimiento;
            cliente.Activo = clienteDTO.Activo;
            cliente.Dirección = clienteDTO.Dirección;
            cliente.Teléfono = clienteDTO.Teléfono;

            _clienteService.UpdateCliente(cliente);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = _clienteService.GetCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _clienteService.DeleteCliente(cliente);
            return NoContent();
        }
    }
}
