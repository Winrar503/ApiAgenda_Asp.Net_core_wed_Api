using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.EN
{
    public class Eventos
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Contactos")]
        public int? IdContactos { get; set; }

        public string Descripcion { get; set; }
        public DateTime? Fin { get; set; }
        public DateTime? Inicio { get; set; }
        public string Titulo { get; set; }
        

        [NotMapped]
        public int Top_Aux { get; set; }

        [ValidateNever]
        public Contactos Contactos { get; set; }
    }
}
