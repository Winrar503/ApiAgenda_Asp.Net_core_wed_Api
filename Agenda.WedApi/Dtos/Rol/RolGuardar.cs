using System.ComponentModel.DataAnnotations;

namespace Agenda.WedApi.Dtos.Rol
{
    public class RolGuardar
    {
        [Required(ErrorMessage = "El nombre del rol es requerido")]
        public string Nombre { get; set; }
    }
}
