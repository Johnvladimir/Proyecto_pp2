using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Web.Modelos.Roles;
using Sistema.Web.Modelos.Usuarios;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RolesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Roles/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<RolViewModel>> Listar()
        {
            var rol = await _context.Roles.ToListAsync();
            return rol.Select(r => new RolViewModel
            {
                idRol = r.idRol,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion,
                Condicion = r.Condicion
            });
        }

        // GET: api/Roles/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var rol = await _context.Roles.Where(r => r.Condicion == true).ToListAsync();

            return rol.Select(r => new SelectViewModel
            {
                idRol = r.idRol,
                Nombre = r.Nombre
            });
        }

        private bool RolExists(int id)
        {
            return _context.Roles.Any(e => e.idRol == id);
        }
    }
}
