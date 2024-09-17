using Agenda.DAL;
using Agenda.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.BL
{
    public class NotasBL
    {
        public async Task<int> CrearAsync(Notas pNotas)
        {
            return await NotasDAL.CrearAsync(pNotas);
        }

        public async Task<int> ModificarAsync(Notas pNotas)
        {
            return await NotasDAL.ModificarAsync(pNotas);
        }

        public async Task<int> EliminarAsync(Notas pNotas)
        {
            return await NotasDAL.EliminarAsync(pNotas);
        }

        public async Task<Notas> ObtenerPorIdAsync(Notas pNotas)
        {
            return await NotasDAL.ObtenerPorIdAsync(pNotas);
        }

        public async Task<List<Notas>> ObtenerTodosAsync()
        {
            return await NotasDAL.ObtenerTodosAsync();
        }

        public async Task<List<Notas>> BuscarAsync(Notas pNotas)
        {
            return await NotasDAL.BuscarAsync(pNotas);
        }
    }
}
