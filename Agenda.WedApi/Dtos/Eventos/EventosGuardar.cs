using System.ComponentModel.DataAnnotations;

namespace Agenda.WedApi.Dtos.Eventos
{
    public class EventosGuardar
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdContactos {  get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime? Fin {  get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime? Inicio { get; set; }
    }
}
