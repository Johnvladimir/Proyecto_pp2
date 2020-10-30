using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
                fecha = c.fecha,
                Detalles_Estudios = c.Detalles_Estudios,
                Detalles_Examenes = c.Detalles_Examenes,
                Recetas = c.Recetas,
                Costo_Cita = c.Costo_Cita
            });
        }

        // GET: api/Expedientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expediente>> GetExpediente(int id)
        {
            var expediente = await _context.Expedientes.FindAsync(id);

            if (expediente == null)
            {
                return NotFound();
            }

            return expediente;
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

            expediente.Nombre = model.Nombre;
            expediente.Nombre_Medico = model.Nombre_Medico;
            expediente.Nombre_Usuario = model.Nombre_Usuario;
            expediente.fecha = model.fecha;
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
                idExpediente = model.idExpediente,
                idMedico = model.idMedico,
                idUsuario = model.idUsuario,
                Nombre = model.Nombre,
                Nombre_Medico = model.Nombre_Medico,
                Nombre_Usuario = model.Nombre_Usuario,
                fecha = model.fecha,
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
