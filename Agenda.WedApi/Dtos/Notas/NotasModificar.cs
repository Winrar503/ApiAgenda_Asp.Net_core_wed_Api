using System.ComponentModel.DataAnnotations;
namespace Agenda.WedApi.Dtos.Notas
{
    public class NotasModificar
    {
        [Required(ErrorMessage = "Este campo es requerid")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campos es requerido")]
        public string Contenido {  get; set; } 
    }
}
