using Microsoft.AspNetCore.Mvc;
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
    public class Categorias
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }

        [NotMapped]
        public int Top_Aux {  get; set; }

        
     
        [ValidateNever]
        public List<Contactos> Contactos { get; set; }
    }
}
