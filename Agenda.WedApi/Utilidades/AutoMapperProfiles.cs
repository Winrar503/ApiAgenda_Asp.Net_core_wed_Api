using Agenda.EN;
using Agenda.WedApi.Dtos.Categorias;
using Agenda.WedApi.Dtos.Contactos;
using Agenda.WedApi.Dtos.Eventos;
using AutoMapper;

namespace Agenda.WedApi.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CategoriaGuardar, Categorias>();
            CreateMap<CategoriaModificar, Categorias>();
            CreateMap<Categorias, CategoriaGuardar>();

            CreateMap<ContactosGuardar, Contactos>();
            CreateMap<ContactosModifcar, Contactos>();
            CreateMap<Contactos, ContactosSalida>();

            CreateMap<EventosGuardar, Eventos>();
            CreateMap<EventosModificar, Eventos>();
            CreateMap<Eventos, EventosSalida>();
               
        }
    }
}
