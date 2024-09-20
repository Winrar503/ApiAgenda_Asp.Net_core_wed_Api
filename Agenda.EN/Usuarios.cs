using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.EN
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Rol")]
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }

        [ValidateNever]
        public Rol Rol { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        [NotMapped]
        public string ConfirmPassword_aux { get; set; }
    }

    public enum Estatus_Usuario
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}

