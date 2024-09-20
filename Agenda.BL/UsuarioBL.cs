using Agenda.DAL;
using Agenda.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.BL
{
    public class UsuarioBL
    {
        public async Task<int> CrearAsync(Usuarios pUsuario)
        {
            return await UsuarioDAL.CrearAsync(pUsuario);
        }

        public async Task<int> ModificarAsync(Usuarios pUsuario)
        {
            return await UsuarioDAL.ModificarAsync(pUsuario);
        }

        public async Task<int> EliminarAsync(Usuarios pUsuario)
        {
            return await UsuarioDAL.EliminarAsync(pUsuario);
        }

        public async Task<Usuarios> ObtenerPorIdAsync(Usuarios pUsuario)
        {
            return await UsuarioDAL.ObtenerPorIdAsync(pUsuario);
        }

        public async Task<List<Usuarios>> ObtenerTodosAsync()
        {
            return await UsuarioDAL.ObtenerTodosAsync();
        }

        public async Task<List<Usuarios>> BuscarAsync(Usuarios pUsuario)
        {
            return await UsuarioDAL.BuscarAsync(pUsuario);
        }

        public async Task<Usuarios> LoginAsync(Usuarios pUsuario)
        {
            return await UsuarioDAL.LoginAsync(pUsuario);
        }

        public async Task<int> CambiarPasswordAsync(Usuarios pUsuario, string pPasswordAnt)
        {
            return await UsuarioDAL.CambiarPasswordAsync(pUsuario, pPasswordAnt);
        }

        public async Task<List<Usuarios>> BuscarIncluirRolesAsync(Usuarios pUsuario)
        {
            return await UsuarioDAL.BuscarIncluirRolesAsync(pUsuario);
        }
    }
}
