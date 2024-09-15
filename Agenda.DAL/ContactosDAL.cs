using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.EN;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Agenda.DAL
{
    public class ContactosDAL
    {
        public static async Task<int> CrearAsync(Contactos pContactos)
        {
            int result = 0;
            using (var bdContexto = new DBContext())
            {
                bdContexto.Add(pContactos);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Contactos pContactos)
        {
            int result = 0;
            using (var bdContext = new DBContext())
            {
                var contactos = await bdContext.Contactos.FirstOrDefaultAsync(c => c.Id == pContactos.Id);
                contactos.Nombre = pContactos.Nombre;
                contactos.Numero = pContactos.Numero;
                contactos.QrCodePath = pContactos.QrCodePath;
                contactos.FotoPath = pContactos.FotoPath;
                contactos.Email = pContactos.Email; 
                contactos.Eliminado = pContactos.Eliminado; 
                contactos.IdCategoria = pContactos.IdCategoria;
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Contactos pContactos)
        {
            int result = 0;
            using (var bdContext = new DBContext())
            {
                var contactos = await bdContext.Contactos.FirstOrDefaultAsync(c => c.Id == pContactos.Id);
                bdContext.Contactos.Remove(contactos);
                result = await bdContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Contactos> ObtenerPorIdAsync(Contactos pContactos)
        {
            var contactos = new Contactos();
            using (var bdContexto = new DBContext())
            {
                contactos = await bdContexto.Contactos.FirstOrDefaultAsync(c => c.Id == pContactos.Id);
            }
            return contactos;
        }
        public static async Task<List<Contactos>> ObtenerTodosAsync()
        {
            var contactos = new List<Contactos>();
            using (var bdContexto = new DBContext())
            {
                contactos = await bdContexto.Contactos.ToListAsync();
            }
            return contactos;
        }

        internal static IQueryable<Contactos> QuerySelect(IQueryable<Contactos> pQuery, Contactos pContactos)
        {
            if (pContactos.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pContactos.Id);

            if (!string.IsNullOrWhiteSpace(pContactos.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pContactos.Nombre));

            //if (pContactos.Zona > 0)
            //    pQuery = pQuery.Where(s => s.Id == pContactos.Zona);

            //pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pContactos.Top_Aux > 0)
                pQuery = pQuery.Take(pContactos.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Contactos>> BuscarAsync(Contactos pContactos)
        {
            var contactos = new List<Contactos>();
            using (var bdContexto = new DBContext())
            {
                var select  = bdContexto.Contactos.AsQueryable();
                select = QuerySelect(select, pContactos);
                contactos =  await select.ToListAsync();
            }
            return contactos;
        }
    }
}
