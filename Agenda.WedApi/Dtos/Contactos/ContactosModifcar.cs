using System.ComponentModel.DataAnnotations;

namespace Agenda.WedApi.Dtos.Contactos
{
    public class ContactosModifcar
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public int CategoriasId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Email { get; set; }
        public string FotoPath { get; set; }
        public string QrCodePath { get; set; }
    }
}
