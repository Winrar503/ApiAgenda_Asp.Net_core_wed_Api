using Agenda.BL;
using Agenda.EN;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Agenda.WedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventosController : Controller
    {
        private EventosBL deptoBL = new EventosBL();

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Eventos>> Get()
        {
            return await deptoBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Eventos> Get(int id)
        {
            Eventos depto = new Eventos();
            depto.Id = id;
            return await deptoBL.ObtenerPorIdAsync(depto);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] Eventos eventos)
        {
            try
            {
                await deptoBL.CrearAsync(eventos);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Eventos eventos)
        {

            if (eventos.Id == id)
            {
                await deptoBL.ModificarAsync(eventos);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Eventos depto = new Eventos();
                depto.Id = id;
                await deptoBL.EliminarAsync(depto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Eventos>> Buscar([FromBody] object pEventos)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strDepto = JsonSerializer.Serialize(pEventos);
            Eventos depto = JsonSerializer.Deserialize<Eventos>(strDepto, option);
            return await deptoBL.BuscarAsync(depto);
        }
    }
    
   }
