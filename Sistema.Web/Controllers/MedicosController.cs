using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Empleado;
using Sistema.Web.Modelos.Empleado;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public MedicosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Medicos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<MedicoViewModel>> Listar()
        {
            var medico = await _context.Medicos.ToListAsync();
            return medico.Select(c => new MedicoViewModel
            {
                idMedico = c.idMedico,
                Nombre = c.Nombre,
                Direccion = c.Direccion,
                Telefono = c.Telefono,
                Correo = c.Correo,
                Profesion = c.Profesion
            });
        }

        // GET: api/Medicos/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> MostrarMedico([FromRoute] int id)
        {
            var medico = await _context.Medicos.FindAsync(id);

            if (medico == null)
            {
                return NotFound();
            }

            return Ok(new MedicoViewModel
            {
                idMedico = medico.idMedico,
                Nombre = medico.Nombre,
                Direccion = medico.Direccion,
                Telefono = medico.Telefono,
                Correo = medico.Correo,
                Profesion = medico.Profesion
            });
        }

        // PUT: api/Medicos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.idMedico <= 0)
            {
                return BadRequest();
            }

            var medico = await _context.Medicos.FirstOrDefaultAsync(c => c.idMedico == model.idMedico);

            medico.idMedico = model.idMedico;
            medico.Nombre = model.Nombre;
            medico.Direccion = model.Direccion;
            medico.Telefono = model.Telefono;
            medico.Correo = model.Correo;

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

        // POST: api/Medicos/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Medico medico = new Medico
            {
                Nombre = model.Nombre,
                Telefono = model.Telefono,
                Correo = model.Correo,
                Direccion = model.Direccion,
                Profesion = model.Profesion
            };

            _context.Medicos.Add(medico);
            try
            {
                await _context.SaveChangesAsync();

            } catch(Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Medicos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Medico>> DeleteMedico(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }

            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();

            return medico;
        }

        private bool MedicoExists(int id)
        {
            return _context.Medicos.Any(e => e.idMedico == id);
        }
    }
}
