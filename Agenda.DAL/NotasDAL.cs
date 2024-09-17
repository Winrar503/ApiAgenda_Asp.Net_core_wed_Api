using Agenda.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL
{
    public class NotasDAL
    {
        public static async Task<int> CrearAsync(Notas pNotas)
        {
            int result = 0;
            using (var bdContexto = new DBContext())
            {
                bdContexto.Add(pNotas);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Notas pNotas)
        {
            int result = 0;
            using (var bdContext = new DBContext())
            {
                var notas = await bdContext.Notas.FirstOrDefaultAsync(n => n.Id == pNotas.Id);
                notas.Contenido = pNotas.Contenido;
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Notas pNotas)
        {
            int result = 0;
            using (var bdContext = new DBContext())
            {
                var notas = await bdContext.Notas.FirstOrDefaultAsync(c => c.Id == pNotas.Id);
                bdContext.Notas.Remove(notas);
                result = await bdContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Notas> ObtenerPorIdAsync(Notas pNotas)
        {
            var notas = new Notas();
            using (var bdContexto = new DBContext())
            {
                notas = await bdContexto.Notas.FirstOrDefaultAsync(c => c.Id == pNotas.Id);
            }
            return notas;
        }
        public static async Task<List<Notas>> ObtenerTodosAsync()
        {
            var notas = new List<Notas>();
            using (var bdContexto = new DBContext())
            {
                notas = await bdContexto.Notas.ToListAsync();
            }
            return notas;
        }

        internal static IQueryable<Notas> QuerySelect(IQueryable<Notas> pQuery, Notas pNotas)
        {
            if (pNotas.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pNotas.Id);

            if (!string.IsNullOrWhiteSpace(pNotas.Contenido))
                pQuery = pQuery.Where(s => s.Contenido.Contains(pNotas.Contenido));

            //if (pContactos.Zona > 0)
            //    pQuery = pQuery.Where(s => s.Id == pContactos.Zona);

            //pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pNotas.Top_Aux > 0)
                pQuery = pQuery.Take(pNotas.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Notas>> BuscarAsync(Notas pNotas)
        {
            var notas = new List<Notas>();
            using (var bdContexto = new DBContext())
            {
                var select = bdContexto.Notas.AsQueryable();
                select = QuerySelect(select, pNotas);
                notas = await select.ToListAsync();
            }
            return notas;
        }
    }
}
