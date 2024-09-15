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
    public class CategoriasController : Controller
    {
        private CategoriasBL deptoBL = new CategoriasBL();

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Categorias>> Get()
        {
            return await deptoBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Categorias> Get(int id)
        {
            Categorias depto = new Categorias();
            depto.Id = id;
            return await deptoBL.ObtenerPorIdAsync(depto);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] Categorias categorias)
        {
            try
            {
                await deptoBL.CrearAsync(categorias);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Categorias categorias)
        {

            if (categorias.Id == id)
            {
                await deptoBL.ModificarAsync(categorias);
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
                Categorias depto = new Categorias();
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
        public async Task<List<Categorias>> Buscar([FromBody] object pCategorias)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strDepto = JsonSerializer.Serialize(pCategorias);
            Categorias depto = JsonSerializer.Deserialize<Categorias>(strDepto, option);
            return await deptoBL.BuscarAsync(depto);
        }
    }
}
