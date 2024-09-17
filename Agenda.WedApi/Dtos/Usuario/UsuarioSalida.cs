using Agenda.WedApi.Dtos.Rol;

namespace Agenda.WedApi.Dtos.Usuario
{
    public class UsuarioSalida
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string Login { get; set; }

        public RolSalida Rol { get; set; }
    }
}
