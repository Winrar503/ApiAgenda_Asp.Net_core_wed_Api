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
    public class Contactos
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Categorias")]
       
        public int? IdCategoria { get; set; }
        public bool Eliminado { get; set; }
        public string Email { get; set; }       
        public string FotoPath { get; set; }       
        public string Nombre { get; set; }
        public string Numero { get; set; }
        public string QrCodePath { get; set; }
       
        [NotMapped]
        [ValidateNever]
        public Categorias Categorias { get; set; }
        public int Top_Aux {  get; set; }
        [ValidateNever]
        public List<Eventos> Eventos { get; set; }
        [ValidateNever]
        public List<Notas> Notas { get; set; }

    }
}
