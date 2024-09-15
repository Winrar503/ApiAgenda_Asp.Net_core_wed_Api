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
        [Required(ErrorMessage = "Rol es obligatorio")]
        [Display(Name = "Contactos")]
        public int? IdContactos { get; set; }
        //Opcional
        [Display(Name = "Descipcion")]
        public string Descripcion { get; set; }
        public DateTime? Fin { get; set; }
        public DateTime? Inicio { get; set; }
        [Required(ErrorMessage = "El titulo es requerido")]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }
        

        [NotMapped]
        public int Top_Aux { get; set; }

        [ValidateNever]
        public Contactos Contactos { get; set; }
    }
}
