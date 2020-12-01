using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Registro;
using Sistema.Web.Modelos.Registro;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedientesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ExpedientesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Expedientes/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ExpedienteViewModel>> Listar()
        {
            var expediente = await _context.Expedientes.ToListAsync();
            return expediente.Select(c => new ExpedienteViewModel { 
                idExpediente = c.idExpediente,
                idUsuario = c.idUsuario,
                idMedico = c.idMedico,
                Nombre = c.Nombre,
                Nombre_Medico= c.Nombre_Medico,
                Nombre_Usuario = c.Nombre_Usuario,
                Fecha = c.Fecha,
                Detalles_Estudios = c.Detalles_Estudios,
                Detalles_Examenes = c.Detalles_Examenes,
                Recetas = c.Recetas,
                Costo_Cita = c.Costo_Cita
            });
        }

        // GET: api/Expedientes/ListarId
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<ExpedienteViewModel>> ListarId([FromRoute] int id)
        {
            var expediente = await _context.Expedientes
                .Where(c => c.idUsuario == id)
                .ToListAsync();
            return expediente.Select(c => new ExpedienteViewModel
            {
                idExpediente = c.idExpediente,
                idUsuario = c.idUsuario,
                idMedico = c.idMedico,
                Nombre = c.Nombre,
                Nombre_Medico = c.Nombre_Medico,
                Nombre_Usuario = c.Nombre_Usuario,
                Fecha = c.Fecha,
                Detalles_Estudios = c.Detalles_Estudios,
                Detalles_Examenes = c.Detalles_Examenes,
                Recetas = c.Recetas,
                Costo_Cita = c.Costo_Cita
            });
        }

        // PUT: api/Expedientes/Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.idExpediente <= 0)
            {
                return BadRequest();
            }

            var expediente = await _context.Expedientes.FirstOrDefaultAsync(c => c.idExpediente == model.idExpediente);

            if (expediente == null)
            {
                return NotFound();
            }

            expediente.idExpediente = model.idExpediente;
            expediente.idMedico = model.idMedico;
            expediente.idUsuario = model.idUsuario;
            expediente.Nombre = model.Nombre;
            expediente.Nombre_Medico = model.Nombre_Medico;
            expediente.Nombre_Usuario = model.Nombre_Usuario;
            expediente.Fecha = model.Fecha;
            expediente.Detalles_Estudios = model.Detalles_Estudios;
            expediente.Detalles_Examenes = model.Detalles_Examenes;
            expediente.Recetas = model.Recetas;
            expediente.Costo_Cita = model.Costo_Cita;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Expedientes/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Expediente expediente = new Expediente
            {
                idMedico = model.idMedico,
                idUsuario = model.idUsuario,
                Nombre = model.Nombre,
                Nombre_Medico = model.Nombre_Medico,
                Nombre_Usuario = model.Nombre_Usuario,
                Fecha = model.Fecha,
                Detalles_Estudios = model.Detalles_Estudios,
                Detalles_Examenes = model.Detalles_Examenes,
                Recetas = model.Recetas,
                Costo_Cita = model.Costo_Cita,
                
            };

            _context.Expedientes.Add(expediente);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }

            return Ok();
        }

        //Un informe para administradores
        // GET: api/Expedientes/Informe
        [HttpGet("[action]/{fechaInicio}/{fechaFin}")]
        public async Task<IEnumerable<InformeViewModel>> Informe([FromRoute] DateTime fechaInicio, DateTime fechaFin)
        {
            var cabinas = await _context.Expedientes
                .Where(i => i.Fecha.HasValue && i.Fecha.Value.Date >= fechaInicio.Date)
                .Where(i => i.Fecha.HasValue && i.Fecha.Value.Date <= fechaFin.Date)
                .OrderBy(i => i.idExpediente)
                .ToListAsync();

            return cabinas.Select(c => new InformeViewModel
            {
                Nombre = c.Nombre,
                Nombre_Medico = c.Nombre_Medico,
                Nombre_Usuario = c.Nombre_Usuario,
                Fecha = c.Fecha,
                Detalles_Estudios = c.Detalles_Estudios,
                Detalles_Examenes = c.Detalles_Examenes,
                Recetas = c.Recetas,
                Costo_Cita = c.Costo_Cita
            });
        }

        //Un informe para usuario
        // GET: api/Expedientes/InformeID
        [HttpGet("[action]/{fechaInicio}/{fechaFin}/{id}")]
        public async Task<IEnumerable<InformeViewModel>> InformeID([FromRoute] DateTime fechaInicio, DateTime fechaFin, int id)
        {
            var cabinas = await _context.Expedientes
                .Where(i => i.idUsuario == id)
                .Where(i => i.Fecha.HasValue && i.Fecha.Value.Date >= fechaInicio.Date)
                .Where(i => i.Fecha.HasValue && i.Fecha.Value.Date <= fechaFin.Date)
                .OrderBy(i => i.idExpediente)
                .ToListAsync();

            return cabinas.Select(c => new InformeViewModel
            {
                Nombre = c.Nombre,
                Nombre_Medico = c.Nombre_Medico,
                Nombre_Usuario = c.Nombre_Usuario,
                Fecha = c.Fecha,
                Detalles_Estudios = c.Detalles_Estudios,
                Detalles_Examenes = c.Detalles_Examenes,
                Recetas = c.Recetas,
                Costo_Cita = c.Costo_Cita
            });
        }

        // DELETE: api/Expedientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Expediente>> DeleteExpediente(int id)
        {
            var expediente = await _context.Expedientes.FindAsync(id);
            if (expediente == null)
            {
                return NotFound();
            }

            _context.Expedientes.Remove(expediente);
            await _context.SaveChangesAsync();

            return expediente;
        }

        private bool ExpedienteExists(int id)
        {
            return _context.Expedientes.Any(e => e.idExpediente == id);
        }
    }
}
