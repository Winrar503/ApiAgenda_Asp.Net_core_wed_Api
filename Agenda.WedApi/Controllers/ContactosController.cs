using Agenda.BL;
using Agenda.EN;
using Agenda.WedApi.Dtos.Categorias;
using Agenda.WedApi.Dtos.Contactos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Agenda.WedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactosController : Controller
    {
        private ContactosBL deptoBL = new ContactosBL();
        private IMapper mapper;

        public ContactosController()
        {
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ContactosSalida>> Get()
        {
            List<Contactos> contactos = await deptoBL.ObtenerTodosAsync();
            return mapper.Map<IEnumerable<ContactosSalida>>(contactos);
        }

        [HttpGet("{id}")]
        public async Task<ContactosSalida> Get(int id)
        {
            Contactos depto = await deptoBL.ObtenerPorIdAsync(new Contactos { Id = id });
            return mapper.Map<ContactosSalida>(depto);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] ContactosGuardar contactosGuardar)
        {
            try
            {
                Contactos contactos = mapper.Map<Contactos>(contactosGuardar);
                await deptoBL.CrearAsync(contactos);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ContactosModifcar contactosModifcar)
        {

            if (contactosModifcar.Id == id)
            {
                Contactos contactos = mapper.Map<Contactos>(contactosModifcar);
                await deptoBL.ModificarAsync(contactos);
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
                Contactos depto = new Contactos();
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
        public async Task<List<ContactosSalida>> Buscar([FromBody] object pContactos)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strDepto = JsonSerializer.Serialize(pContactos);
            Contactos depto = JsonSerializer.Deserialize<Contactos>(strDepto, option);
            List<Contactos> contactos = await deptoBL.BuscarAsync(depto);
            return mapper.Map<List<ContactosSalida>>(depto);
        }
    }
}
