using System.ComponentModel.DataAnnotations;

namespace Agenda.WedApi.Dtos.Usuario
{
    public class UsuarioModificar
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "El rol es requerido")]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
