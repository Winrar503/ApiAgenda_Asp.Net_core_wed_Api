using System.ComponentModel.DataAnnotations;

namespace Agenda.WedApi.Dtos.Eventos
{
    public class EventosSalida
    {
        public int Id { get; set; }
        public int IdContactos { get; set; }
        public string Descripcion { get; set; }
        public string Titulo { get; set; }
        public DateTime? Fin { get; set; }
        public DateTime? Inicio { get; set; }

    }
}
