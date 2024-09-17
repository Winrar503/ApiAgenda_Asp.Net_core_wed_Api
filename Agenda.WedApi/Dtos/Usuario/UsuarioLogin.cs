using System.ComponentModel.DataAnnotations;

namespace Agenda.WedApi.Dtos.Usuario
{
    public class UsuarioLogin
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Clave { get; set; }
    }
}
