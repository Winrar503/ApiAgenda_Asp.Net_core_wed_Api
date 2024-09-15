using Agenda.EN;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Agenda.EN;

namespace Agenda.PruebasUnitarias
{
    [TestClass]
    public class ContactosDALTests
    {
        private static Contactos deptoInicial = new Contactos { Id = 2};
        [TestMethod]
        public async Task T1CrearAsyncTest()
        {
            var depto = new Contactos ();
            depto.Nombre = "Darwin";
            depto.

        }
    }
}
