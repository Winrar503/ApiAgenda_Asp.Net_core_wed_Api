using Agenda.DAL;
using Agenda.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.BL
{
    public class CategoriasBL
    {
        public async Task<int> CrearAsync(Categorias pCategorias)
        {
            return await CategoriasDAL.CrearAsync(pCategorias);
        }
        public async Task<int> ModificarAsync(Categorias pCategorias)
        {
            return await CategoriasDAL.ModificarAsync(pCategorias);
        }
        public async Task<int> EliminarAsync(Categorias pCategorias)
        {
            return await CategoriasDAL.EliminarAsync(pCategorias);
        }
        public async Task<Categorias> ObtenerPorIdAsync(Categorias pCategorias)
        {
            return await CategoriasDAL.ObtenerPorIdAsync(pCategorias);
        }
        public async Task<List<Categorias>> ObtenerTodosAsync()
        {
            return await CategoriasDAL.ObtenerTodosAsync();
        }
        public async Task<List<Categorias>> BuscarAsync(Categorias pCategorias)
        {
            return await CategoriasDAL.BuscarAsync(pCategorias);
        }
    }
}
