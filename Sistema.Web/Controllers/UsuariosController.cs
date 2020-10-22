using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Usuarios;
using Sistema.Web.Modelos.Usuarios;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public UsuariosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Usuarios/Listar
        [HttpGet]
        public async Task<IEnumerable<UsuarioViewModel>> Listar()
        {
            var usuario = await _context.Usuarios.ToListAsync();
            return usuario.Select(c => new UsuarioViewModel
            {
                idUsuario = c.idUsuario,
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                Correo = c.Correo,
                Direccion = c.Direccion,
            });
        }

        // GET: api/Usuarios/MostrarUsuario/id
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> MostrarUsuario([FromRoute] int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {   
                return NotFound();
            }

            return Ok(new UsuarioViewModel
            {
                idUsuario = usuario.idUsuario,
                Nombre = usuario.Nombre,
                Telefono = usuario.Telefono,
                Correo = usuario.Correo,
                Direccion = usuario.Direccion,
            });
        }

        // PUT: api/Usuarios/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.idUsuario <= 0)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(c => c.idUsuario == model.idUsuario);

            usuario.idUsuario = model.idUsuario;
            usuario.Nombre = model.Nombre;
            usuario.Telefono = model.Telefono;
            usuario.Correo = model.Correo;
            usuario.Direccion = model.Direccion;
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

        // POST: api/Usuarios/Crear
        [HttpPost]
        public async Task<ActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Usuario usuario = new Usuario
            {
                Nombre = model.Nombre,
                Telefono = model.Telefono,
                Correo = model.Correo,
                Direccion = model.Direccion
            };

            _context.Usuarios.Add(usuario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.idUsuario == id);
        }
    }
}
