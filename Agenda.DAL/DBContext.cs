using Agenda.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL
{
    public class DBContext : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Contactos> Contactos { get; set; }
        public DbSet<Notas> Notas { get; set; } 
        public DbSet<Eventos> Eventos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = DARWIN;
                                            Initial Catalog = Contacto;
                                            Integrated Security = True; 
                                            encrypt = false; 
                                            trustServerCertificate = True");
        }
    }
}
