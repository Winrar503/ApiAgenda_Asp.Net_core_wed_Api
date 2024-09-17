using Agenda.BL;
using Agenda.EN;
using Agenda.WedApi.Dtos.Categorias;
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
    public class CategoriasController : Controller
    {
        private CategoriasBL deptoBL = new CategoriasBL();
        private IMapper mapper;
        //Inyeccion de dependencia
        public CategoriasController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<CategoriaSalida>> Get()
        {
            List<Categorias> categorias = await deptoBL.ObtenerTodosAsync();
            return mapper.Map<IEnumerable<CategoriaSalida>>(categorias); 
        }

        [HttpGet("{id}")]
        public async Task<CategoriaSalida> Get(int id)
        {
            Categorias depto = await deptoBL.ObtenerPorIdAsync(new Categorias { Id = id });
            return mapper.Map<CategoriaSalida>(depto);

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] CategoriaGuardar categoriaGuardar)
        {
            try
            {
                Categorias categorias = mapper.Map<Categorias>(categoriaGuardar);
                await deptoBL.CrearAsync(categorias);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaModificar categoriaModificar)
        {

            if (categoriaModificar.Id == id)
            {
                Categorias categorias = mapper.Map<Categorias>(categoriaModificar);
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
        public async Task<List<CategoriaSalida>> Buscar([FromBody] object pCategorias)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strDepto = JsonSerializer.Serialize(pCategorias);
            Categorias depto = JsonSerializer.Deserialize<Categorias>(strDepto, option);
            List<Categorias> categorias = await deptoBL.BuscarAsync(depto);
            return mapper.Map<List<CategoriaSalida>>(categorias);
        }
    }
}
