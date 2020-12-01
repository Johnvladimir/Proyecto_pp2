using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Web.Modelos.GeoPortal;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapasController : Controller
    {
        private readonly DbContextSistema _context;

        public MapasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Mapas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<MapaViewModel>> Listar()
        {
            var mapas = await _context.Mapas.ToListAsync();
            return mapas.Select(c => new MapaViewModel
            {
                idMapa = c.idMapa,
                idMedico = c.idMedico,
                NombreLugar = c.NombreLugar,
                Direccion = c.Direccion,
                Imagen = c.Imagen,
                Latitude = c.Latitude,
                Longitude = c.Longitude,
                NombreLugarId = c.NombreLugarId,
            });
        }
    
        private bool MapaExists(int id)
        {
            return _context.Mapas.Any(e => e.idMapa == id);
        }
    }
}
