using Agenda.DAL;
using Agenda.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.BL
{
    public class ContactosBL
    {
        public async Task<int> CrearAsync(Contactos pContactos)

        {
            return await ContactosDAL.CrearAsync(pContactos);
        }

        public async Task<int> ModificarAsync(Contactos pContactos)
        {
            return await ContactosDAL.ModificarAsync(pContactos);
        }

        public async Task<int> EliminarAsync(Contactos pContactos)
        {
            return await ContactosDAL.EliminarAsync(pContactos);
        }

        public async Task<Contactos> ObtenerPorIdAsync(Contactos pContactos)
        {
            return await ContactosDAL.ObtenerPorIdAsync(pContactos);
        }

        public async Task<List<Contactos>> ObtenerTodosAsync()
        {
            return await ContactosDAL.ObtenerTodosAsync();
        }

        public async Task<List<Contactos>> BuscarAsync(Contactos pContactos)
        {
            return await ContactosDAL.BuscarAsync(pContactos);
        }
        //public async Task<List<Notas>> ObtenerTodosPorContactoAsync(Notas pNotas)
        //{
        //    return await NotasDAL.ObtenerTodosPorContactoAsync(pNotas);
        //}

    }
}
