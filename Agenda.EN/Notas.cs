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
    public class Notas
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Contactos")]
        
        [Display(Name = "Contactos")]
        public int? IdContactos { get; set; }
        [Required(ErrorMessage = "Escriba una nota")]

        [Display(Name = "Contenido")]
        public string contenido { get; set; }
        public bool Eliminado { get; set; }
        

        [NotMapped]
        public int Top_Aux {  get; set; }
        [ValidateNever]
        public Contactos Contactos { get; set; }

    }
}
