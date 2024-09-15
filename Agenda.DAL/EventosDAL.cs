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
    public class EventosDAL
    {
        public static async Task<int> CrearAsync(Eventos pEventos)
        {
            int result  = 0;
            using (var bdContexto = new DBContext())
            {
                bdContexto.Add(pEventos);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Eventos pEventos)
        {
            int result = 0;
            using (var bdContext = new DBContext())
            {
                var eventos = await bdContext.Eventos.FirstOrDefaultAsync(c => c.Id == pEventos.Id);
                eventos.Titulo = pEventos.Titulo;
                eventos.Descripcion = pEventos.Descripcion;
                eventos.Inicio = pEventos.Inicio;
                eventos.Fin = pEventos.Fin;
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Eventos pEventos)
        {
            int result = 0;
            using ( var bdContexto = new DBContext())
            {
                var eventos = await bdContexto.Eventos.FirstOrDefaultAsync(e => e.Id == pEventos.Id);
                bdContexto.Eventos.Remove(pEventos);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Eventos> ObtenerPorIdAsync(Eventos pEventos)
        {
            var eventos = new Eventos();
            using (var bdContexto = new DBContext())
            {
                eventos = await bdContexto.Eventos.FirstOrDefaultAsync(e => e.Id == pEventos.Id);
            }
            return eventos;
        }
        public static async Task<List<Eventos>> ObtenerTodosAsync()
        {
            var eventos = new List<Eventos>();
            using (var bdContexto = new DBContext())
            {
                eventos = await bdContexto.Eventos.ToListAsync();
            }
            return eventos;
        }
        public static IQueryable<Eventos> QuerySelect(IQueryable<Eventos> pQuery, Eventos pEventos)
        {
            if (pEventos.Id > 0)
                pQuery = pQuery.Where(e => e.Id == pEventos.Id);
            if (!string.IsNullOrWhiteSpace(pEventos.Titulo))
                pQuery = pQuery.Where(s => s.Titulo.Contains(pEventos.Titulo));

            //if (pContactos.Zona > 0)
            //    pQuery = pQuery.Where(s => s.Id == pContactos.Zona);

            //pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pEventos.Top_Aux > 0)
                pQuery = pQuery.Take(pEventos.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Eventos>> BuscarAsync(Eventos pEventos)
        {
            var eventos = new List<Eventos>();
            using (var bdContexto = new DBContext())
            {
                var select = bdContexto.Eventos.AsQueryable();
                select = QuerySelect(select, pEventos);
                eventos = await select.ToListAsync();
            }
            return eventos;
        }
    }
}
