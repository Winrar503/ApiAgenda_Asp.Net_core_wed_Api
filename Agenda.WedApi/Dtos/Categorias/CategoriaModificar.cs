using System.ComponentModel.DataAnnotations;

namespace Agenda.WedApi.Dtos.Categorias
{
    public class CategoriaModificar
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
    }
}
