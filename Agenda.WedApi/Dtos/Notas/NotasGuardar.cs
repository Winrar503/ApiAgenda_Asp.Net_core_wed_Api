using System.ComponentModel.DataAnnotations;

namespace Agenda.WedApi.Dtos.Notas
{
    public class NotasGuardar
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdContactos { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Contenido { get; set; }

    }
}
