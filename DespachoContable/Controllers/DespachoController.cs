using DespachoContable.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DespachoContable.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    public class DespachoController : Controller
    {
        public readonly DESPACHOContext _dbcontext;

        public DespachoController(DESPACHOContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Empleado> lista = new List<Empleado>();

            try
            {
                lista = _dbcontext.Empleados.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }


        [HttpGet]
        [Route("Obtener/{idEmpleado:int}")]
        public IActionResult Obtener(int idEmpleado)
        {
            Empleado oEmpleado = _dbcontext.Empleados.Find(idEmpleado);

            if (oEmpleado == null)
            {
                return BadRequest("Empleado no encontrado");

            }

            try
            {

                oEmpleado = _dbcontext.Empleados.Where(p => p.EmpleadoId == idEmpleado).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oEmpleado });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oEmpleado });


            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Empleado objeto)
        {

            try
            {
                _dbcontext.Empleados.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Empleado objeto)
        {
            Empleado oEmpleado = _dbcontext.Empleados.Find(objeto.EmpleadoId);

            if (oEmpleado == null)
            {
                return BadRequest("Empleado no encontrado");

            }

            try
            {
                oEmpleado.Nombre = objeto.Nombre is null ? oEmpleado.Nombre : objeto.Nombre;
                oEmpleado.ApellidoPaterno = objeto.ApellidoPaterno is null ? oEmpleado.ApellidoPaterno : objeto.ApellidoPaterno;
                oEmpleado.ApellidoMaterno = objeto.ApellidoMaterno is null ? oEmpleado.ApellidoMaterno : objeto.ApellidoMaterno;
                oEmpleado.Edad = objeto.Edad is null ? oEmpleado.Edad : objeto.Edad;
                oEmpleado.FechaNacimiento = objeto.FechaNacimiento is null ? oEmpleado.FechaNacimiento : objeto.FechaNacimiento;
                oEmpleado.Genero = objeto.Genero is null ? oEmpleado.Genero : objeto.Genero;
                oEmpleado.EstadoCivil = objeto.EstadoCivil is null ? oEmpleado.EstadoCivil : objeto.EstadoCivil;
                oEmpleado.Rfc = objeto.Rfc is null ? oEmpleado.Rfc : objeto.Rfc;
                oEmpleado.Direccion = objeto.Direccion is null ? oEmpleado.Direccion : objeto.Direccion;
                oEmpleado.Email = objeto.Email is null ? oEmpleado.Email : objeto.Email;
                oEmpleado.Telefono = objeto.Telefono is null ? oEmpleado.Telefono : objeto.Telefono;
                oEmpleado.Puesto = objeto.Puesto is null ? oEmpleado.Puesto : objeto.Puesto;
                oEmpleado.FechaAlta = objeto.FechaAlta is null ? oEmpleado.FechaAlta : objeto.FechaAlta;
                oEmpleado.FechaBaja = objeto.FechaBaja is null ? oEmpleado.FechaBaja : objeto.FechaBaja;

                _dbcontext.Empleados.Update(oEmpleado);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }

        [HttpDelete]
        [Route("Eliminar/{idEmpleado:int}")]
        public IActionResult Eliminar(int idEmpleado)
        {

            Empleado oEmpleado = _dbcontext.Empleados.Find(idEmpleado);

            if (oEmpleado == null)
            {
                return BadRequest("Empleado no encontrado");

            }

            try
            {
                _dbcontext.Empleados.Remove(oEmpleado);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }


        }


    }
}
