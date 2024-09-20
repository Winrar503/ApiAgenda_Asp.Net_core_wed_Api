using Agenda.EN;

namespace Agenda.WedApi.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(Usuarios pUsuario);
    }
}
