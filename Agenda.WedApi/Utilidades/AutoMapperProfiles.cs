using Agenda.EN;
using Agenda.WedApi.Dtos.Categorias;
using Agenda.WedApi.Dtos.Contactos;
using Agenda.WedApi.Dtos.Eventos;
using Agenda.WedApi.Dtos.Notas;
using Agenda.WedApi.Dtos.Rol;
using Agenda.WedApi.Dtos.Usuario;
using AutoMapper;

namespace Agenda.WedApi.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CategoriaGuardar, Categorias>();
            CreateMap<CategoriaModificar, Categorias>();
            CreateMap<Categorias, CategoriaSalida>();

            CreateMap<ContactosGuardar, Contactos>();
            CreateMap<ContactosModifcar, Contactos>();
            CreateMap<Contactos, ContactosSalida>();


            CreateMap<EventosGuardar, Eventos>();
            CreateMap<EventosModificar, Eventos>();
            CreateMap<Eventos, EventosSalida>();

            CreateMap<NotasGuardar, Notas>();
            CreateMap<NotasModificar, Notas>();
            CreateMap<Notas, NotasSalida>();

            CreateMap<RolGuardar, Rol>();
            CreateMap<RolModificar, Rol>();
            CreateMap<Rol, RolSalida>();

            CreateMap<UsuarioGuardar, Usuarios>();
            CreateMap<UsuarioModificar, Usuarios>();
            CreateMap<UsuarioLogin, Usuarios>();
            CreateMap<Usuarios, UsuarioSalida>();

        }
    }
}
