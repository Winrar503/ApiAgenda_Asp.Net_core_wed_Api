using Agenda.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL
{
    public class UsuarioDAL
    {
        private static void EncriptarMD5(Usuarios pUsuario)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(pUsuario.Password));
                var strEncriptar = "";
                for (int i = 0; i < result.Length; i++)
                    strEncriptar += result[i].ToString("x2").ToLower();
                pUsuario.Password = strEncriptar;
            }
        }

        private static async Task<bool> ExisteLogin(Usuarios pUsuario, DBContext pDbContext)
        {
            bool result = false;
            var loginUsuarioExiste = await pDbContext.Usuarios.FirstOrDefaultAsync(s => s.Login == pUsuario.Login && s.Id != pUsuario.Id);
            if (loginUsuarioExiste != null && loginUsuarioExiste.Id > 0 && loginUsuarioExiste.Login == pUsuario.Login)
                result = true;
            return result;
        }

        public static async Task<int> CrearAsync(Usuarios pUsuario)
        {
            int result = 0;
            using (var bdContexto = new DBContext())
            {
                bool existeLogin = await ExisteLogin(pUsuario, bdContexto);
                if (existeLogin == false)
                {
                    pUsuario.FechaRegistro = DateTime.Now;
                    EncriptarMD5(pUsuario);
                    bdContexto.Add(pUsuario);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("Login ya existe");
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Usuarios pUsuario)
        {
            int result = 0;
            using (var bdContexto = new DBContext())
            {
                bool existeLogin = await ExisteLogin(pUsuario, bdContexto);
                if (existeLogin == false)
                {
                    var usuario = await bdContexto.Usuarios.FirstOrDefaultAsync(s => s.Id == pUsuario.Id);
                    usuario.IdRol = pUsuario.IdRol;
                    usuario.Nombre = pUsuario.Nombre;
                    usuario.Apellido = pUsuario.Apellido;
                    usuario.Login = pUsuario.Login;
                    usuario.Estatus = pUsuario.Estatus;
                    bdContexto.Update(usuario);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("Login ya existe");
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Usuarios pUsuario)
        {
            int result = 0;
            using (var bdContexto = new DBContext())
            {
                var usuario = await bdContexto.Usuarios.FirstOrDefaultAsync(s => s.Id == pUsuario.Id);
                bdContexto.Usuarios.Remove(usuario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Usuarios> ObtenerPorIdAsync(Usuarios pUsuario)
        {
            var usuario = new Usuarios();
            using (var bdContexto = new DBContext())
            {
                usuario = await bdContexto.Usuarios.FirstOrDefaultAsync(s => s.Id == pUsuario.Id);
            }
            return usuario;
        }

        public static async Task<List<Usuarios>> ObtenerTodosAsync()
        {
            var usuarios = new List<Usuarios>();
            using (var bdContexto = new DBContext())
            {
                usuarios = await bdContexto.Usuarios.ToListAsync();
            }
            return usuarios;
        }

        internal static IQueryable<Usuarios> QuerySelect(IQueryable<Usuarios> pQuery, Usuarios pUsuario)
        {
            if (pUsuario.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pUsuario.Id);
            if (pUsuario.IdRol > 0)
                pQuery = pQuery.Where(s => s.IdRol == pUsuario.IdRol);
            if (!string.IsNullOrWhiteSpace(pUsuario.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pUsuario.Nombre));
            if (!string.IsNullOrWhiteSpace(pUsuario.Apellido))
                pQuery = pQuery.Where(s => s.Apellido.Contains(pUsuario.Apellido));
            if (!string.IsNullOrWhiteSpace(pUsuario.Login))
                pQuery = pQuery.Where(s => s.Login.Contains(pUsuario.Login));
            if (pUsuario.Estatus > 0)
                pQuery = pQuery.Where(s => s.Estatus == pUsuario.Estatus);
            if (pUsuario.FechaRegistro.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pUsuario.FechaRegistro.Year, pUsuario.FechaRegistro.Month, pUsuario.FechaRegistro.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FechaRegistro >= fechaInicial && s.FechaRegistro <= fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pUsuario.Top_Aux > 0)
                pQuery = pQuery.Take(pUsuario.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Usuarios>> BuscarAsync(Usuarios pUsuario)
        {
            var Usuarios = new List<Usuarios>();
            using (var bdContexto = new DBContext())
            {
                var select = bdContexto.Usuarios.AsQueryable();
                select = QuerySelect(select, pUsuario);
                Usuarios = await select.ToListAsync();
            }
            return Usuarios;
        }

        public static async Task<List<Usuarios>> BuscarIncluirRolesAsync(Usuarios pUsuario)
        {
            var usuarios = new List<Usuarios>();
            using (var bdContexto = new DBContext())
            {
                var select = bdContexto.Usuarios.AsQueryable();
                select = QuerySelect(select, pUsuario).Include(s => s.Rol).AsQueryable();
                usuarios = await select.ToListAsync();
            }
            return usuarios;
        }

        public static async Task<Usuarios> LoginAsync(Usuarios pUsuario)
        {
            var usuario = new Usuarios();
            using (var bdContexto = new DBContext())
            {
                EncriptarMD5(pUsuario);
                usuario = await bdContexto.Usuarios.FirstOrDefaultAsync(s => s.Login == pUsuario.Login &&
                s.Password == pUsuario.Password && s.Estatus == (byte)Estatus_Usuario.ACTIVO);
            }
            return usuario;
        }

        public static async Task<int> CambiarPasswordAsync(Usuarios pUsuario, string pPasswordAnt)
        {
            int result = 0;
            var usuarioPassAnt = new Usuarios { Password = pPasswordAnt };
            EncriptarMD5(usuarioPassAnt);
            using (var bdContexto = new DBContext())
            {
                var usuario = await bdContexto.Usuarios.FirstOrDefaultAsync(s => s.Id == pUsuario.Id);
                if (usuarioPassAnt.Password == usuario.Password)
                {
                    EncriptarMD5(pUsuario);
                    usuario.Password = pUsuario.Password;
                    bdContexto.Update(usuario);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("El password actual es incorrecto");
            }
            return result;
        }
    }
}
