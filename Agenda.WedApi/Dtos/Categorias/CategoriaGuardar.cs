using System.ComponentModel.DataAnnotations;
namespace Agenda.WedApi.Dtos.Categorias
{
    public class CategoriaGuardar
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }

    }
}
