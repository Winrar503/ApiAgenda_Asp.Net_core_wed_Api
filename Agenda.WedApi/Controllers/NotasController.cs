using Agenda.BL;
using Agenda.EN;
using Agenda.WedApi.Dtos.Categorias;
using Agenda.WedApi.Dtos.Contactos;
using Agenda.WedApi.Dtos.Eventos;
using Agenda.WedApi.Dtos.Notas;
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
    public class NotasController : Controller
    {
        private NotasBL notasBL = new NotasBL();
        private IMapper mapper;

        public NotasController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<NotasSalida>> Get()
        {
            List<Notas> proyectos = await notasBL.ObtenerTodosAsync();
            return mapper.Map<IEnumerable<NotasSalida>>(proyectos);
        }

        [HttpGet("{id}")]
        public async Task<NotasSalida> Get(int id)
        {
            Notas nota = await notasBL.ObtenerPorIdAsync(new Notas { Id = id });
            return mapper.Map<NotasSalida>(nota);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] NotasGuardar notasGuardar)
        {
            try
            {
                Notas notas = mapper.Map<Notas>(notasGuardar);
                await notasBL.CrearAsync(notas);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] NotasModificar notasModificar)
        {

            if (notasModificar.Id == id)
            {
                Notas notas = mapper.Map<Notas>(notasModificar);
                await notasBL.ModificarAsync(notas);
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
                Notas depto = new Notas();
                depto.Id = id;
                await notasBL.EliminarAsync(depto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<NotasSalida>> Buscar([FromBody] object pProyecto)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strProyecto = JsonSerializer.Serialize(pProyecto);
            Notas nota = JsonSerializer.Deserialize<Notas>(strProyecto, option);
            List<Notas> notas = await notasBL.BuscarAsync(nota);
            return mapper.Map<List<NotasSalida>>(notas);
        }

        //[HttpGet("contacto/{contactoId}")]
        //public async Task<IEnumerable<NotasSalida>> GetByContactoId(int contactoId)
        //{
        //    List<Notas> notas = await notasBL.ObtenerPorContactoIdAsync(contactoId);
        //    return mapper.Map<IEnumerable<NotasSalida>>(notas);
        //}

    }
}
