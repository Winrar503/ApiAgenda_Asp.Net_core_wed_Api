using Agenda.BL;
using Agenda.EN;
using Agenda.WedApi.Dtos.Contactos;
using Agenda.WedApi.Dtos.Eventos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Agenda.WedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EventosController : Controller
    {
        private EventosBL deptoBL = new EventosBL();
        private IMapper mapper;
        public EventosController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        //[AllowAnonymous]
        public async Task<IEnumerable<EventosSalida>> Get()
        {
            List<Eventos> eventos= await deptoBL.ObtenerTodosAsync();
            return mapper.Map<IEnumerable<EventosSalida>>(eventos);
        }

        [HttpGet("{id}")]
        public async Task<EventosSalida> Get(int id)
        {
            Eventos eventos = await deptoBL.ObtenerPorIdAsync(new Eventos { Id = id });
            return mapper.Map<EventosSalida>(eventos  );
        }

        [HttpPost]
        //[AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] EventosGuardar eventosGuardar)
        {
            try
            {
                Eventos eventos = mapper.Map<Eventos>(eventosGuardar);
                await deptoBL.CrearAsync(eventos);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EventosModificar eventosModificar)
        {

            if (eventosModificar.Id == id)
            {
                Eventos eventos = mapper.Map<Eventos>(eventosModificar);
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
        public async Task<List<EventosSalida>> Buscar([FromBody] object pEventos)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strDepto = JsonSerializer.Serialize(pEventos);
            Eventos depto = JsonSerializer.Deserialize<Eventos>(strDepto, option);
            List<Eventos> eventos = await deptoBL.BuscarAsync(depto);
            return mapper.Map<List<EventosSalida>>(depto);
        }
    }
    
   }
