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
    public class ContactosController : Controller
    {
        private ContactosBL deptoBL = new ContactosBL();

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Contactos>> Get()
        {
            return await deptoBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Contactos> Get(int id)
        {
            Contactos depto = new Contactos();
            depto.Id = id;
            return await deptoBL.ObtenerPorIdAsync(depto);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] Contactos contactos)
        {
            try
            {
                await deptoBL.CrearAsync(contactos);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Contactos contactos)
        {

            if (contactos.Id == id)
            {
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
        public async Task<List<Contactos>> Buscar([FromBody] object pContactos)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strDepto = JsonSerializer.Serialize(pContactos);
            Contactos depto = JsonSerializer.Deserialize<Contactos>(strDepto, option);
            return await deptoBL.BuscarAsync(depto);
        }
    }
}
