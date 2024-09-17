using Agenda.BL;
using Agenda.EN;
using Agenda.WedApi.Dtos.Rol;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Agenda.WedApi.Controllers
{
    [Route("api/roles")]
    [ApiController]
    [Authorize]
    public class RolController : ControllerBase
    {
        private RolBL rolBL = new RolBL();
        private IMapper mapper;

        public RolController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RolSalida>> Get()
        {
            List<Rol> roles = await rolBL.ObtenerTodosAsync();
            return mapper.Map<IEnumerable<RolSalida>>(roles);
        }

        [HttpGet("{id}")]
        public async Task<RolSalida> Get(int id)
        {
            Rol rol = await rolBL.ObtenerPorIdAsync(new Rol { Id = id });
            return mapper.Map<RolSalida>(rol);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolGuardar rolGuardar)
        {
            try
            {
                Rol rol = mapper.Map<Rol>(rolGuardar);
                await rolBL.CrearAsync(rol);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RolModificar rolModificar)
        {

            if (rolModificar.Id == id)
            {
                Rol rol = mapper.Map<Rol>(rolModificar);
                await rolBL.ModificarAsync(rol);
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
                await rolBL.EliminarAsync(new Rol { Id = id });
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<RolSalida>> Buscar([FromBody] object pRol)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strRol = JsonSerializer.Serialize(pRol);
            Rol rol = JsonSerializer.Deserialize<Rol>(strRol, option);
            List<Rol> roles = await rolBL.BuscarAsync(rol);
            return mapper.Map<List<RolSalida>>(roles);

        }
    }
}
