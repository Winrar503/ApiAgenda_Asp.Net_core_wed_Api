using Agenda.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL
{
    public class CategoriasDAL
    {
        public static async Task<int> CrearAsync(Categorias pCategorias)
        {
            int result = 0;
            using (var bdContexto = new DBContext())
            {
                bdContexto.Add(pCategorias);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Categorias pCategorias)
        {
            int result = 0;
            using (var bdContexto = new DBContext())
            {
                var categorias = await bdContexto.Categorias.FirstOrDefaultAsync(c => c.Id == pCategorias.Id);
                categorias.Nombre = pCategorias.Nombre;
                

            }
            return result;
        }

        public static async Task<int> EliminarAsync(Categorias pCategorias)
        {
            int result = 0;
            using (var bdContexto = new DBContext())
            {
                var categprias = await bdContexto.Categorias.FirstOrDefaultAsync(c => c.Id == pCategorias.Id);
                bdContexto.Categorias.Remove(categprias);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Categorias> ObtenerPorIdAsync(Categorias pcategorias)
        {
            var categorias = new Categorias();
            using(var bdContexto = new DBContext())
            {
                categorias = await bdContexto.Categorias.FirstOrDefaultAsync(c => c.Id == pcategorias.Id);
            }
            return categorias;
        }

        public static async Task<List<Categorias>> ObtenerTodosAsync()
        {
            var categorias = new List<Categorias>();
            using (var bdContexto = new DBContext())
            {
                categorias = await bdContexto.Categorias.ToListAsync();
            }
            return categorias;
        }

        internal static IQueryable<Categorias> QuerySelect(IQueryable<Categorias> pQuery, Categorias pCategorias)
        {
            if (pCategorias.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pCategorias.Id);

            if (!string.IsNullOrWhiteSpace(pCategorias.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pCategorias.Nombre));

            //if (pContactos.Zona > 0)
            //    pQuery = pQuery.Where(s => s.Id == pContactos.Zona);

            //pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pCategorias.Top_Aux > 0)
                pQuery = pQuery.Take(pCategorias.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Categorias>> BuscarAsync(Categorias pCategorias)
        {
            var categorias = new List<Categorias>();
            using (var bdContexto = new DBContext())
            {
                var select = bdContexto.Categorias.AsQueryable();
                select = QuerySelect(select, pCategorias);
                categorias = await select.ToListAsync();
            }
            return categorias;
        }
    }
}
