using Agenda.WedApi.Dtos.Categorias;
using System.ComponentModel.DataAnnotations;

namespace Agenda.WedApi.Dtos.Contactos
{
    public class ContactosSalida
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Numero { get; set; }
        public string Email { get; set; }
        public string FotoPath { get; set; }
        public string QrCodePath { get; set; }
        public CategoriaSalida Categoria { get; set; }
    }
}
