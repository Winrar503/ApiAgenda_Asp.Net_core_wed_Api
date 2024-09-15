using Agenda.DAL;
using Agenda.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.BL
{
    public class EventosBL
    {
        public async Task<int> CrearAsync(Eventos pEventos)

        {
            return await EventosDAL.CrearAsync(pEventos);
        }

        public async Task<int> ModificarAsync(Eventos pEventos)
        {
            return await EventosDAL.ModificarAsync(pEventos);
        }

        public async Task<int> EliminarAsync(Eventos pEventos)
        {
            return await EventosDAL.EliminarAsync(pEventos);
        }

        public async Task<Eventos> ObtenerPorIdAsync(Eventos pEventos)
        {
            return await EventosDAL.ObtenerPorIdAsync(pEventos);
        }

        public async Task<List<Eventos>> ObtenerTodosAsync()
        {
            return await EventosDAL.ObtenerTodosAsync();
        }
         
        public async Task<List<Eventos>> BuscarAsync(Eventos pEventos)
        {
            return await EventosDAL.BuscarAsync(pEventos);
        }
    }
}
