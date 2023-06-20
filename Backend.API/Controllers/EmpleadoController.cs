using Backend.API.Controllers;
using Backend.API.Modelos;
using Backend.Core.Entities;
using Backend.Core.Interfaces;
using Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }
        [HttpGet]
        public IActionResult GetEmpleados()
        {
            var empleados = _empleadoService.GetEmpleados();
            return Ok(empleados);
        }
        [HttpGet("{id}")]
        public IActionResult GetEmpleado(int id)
        {
            var empleado = _empleadoService.GetEmpleado(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return Ok(empleado);
        }

        [HttpPost]
        public IActionResult CreateEmpleado(EmpleadoDTO empleadoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var empleado = new Empleado
            {
                
                Nombre = empleadoDTO.Nombre,
                Apellido = empleadoDTO.Apellido,
                CorreoElectronico = empleadoDTO.CorreoElectronico,
                FechaNacimiento = empleadoDTO.FechaNacimiento,
                Activo = empleadoDTO.Activo,
                
            };

            _empleadoService.CreateEmpleado(empleado);
            return Ok(empleado);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, EmpleadoDTO empleadoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var empleado = _empleadoService.GetEmpleado(id);
            if (empleado == null)
            {
                return NotFound();
            }

            empleado.Nombre = empleadoDTO.Nombre;
            empleado.Apellido = empleadoDTO.Apellido;
            empleado.CorreoElectronico = empleadoDTO.CorreoElectronico;
            empleado.FechaNacimiento = empleadoDTO.FechaNacimiento;
            empleado.Activo = empleadoDTO.Activo;

            _empleadoService.UpdateEmpleado(empleado);
            return Ok(empleado);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var empleado = _empleadoService.GetEmpleado(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _empleadoService.DeleteEmpleado(empleado);
            return NoContent();
        }
    }
}
     
