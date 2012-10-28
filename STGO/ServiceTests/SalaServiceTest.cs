using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Service;
using Services.Util;
using Model;

namespace ServiceTests
{
    [TestClass]
    public class SalaServiceTest
    {
        private ISalaService salaService = ServiceLocator.Instance.SalaService;
        
        [TestMethod]
        public void getAllTestOK()
        {
            List<Sala> salas =  this.salaService.getAll();
            Assert.IsNotNull(salas);
            Assert.IsTrue(salas.Count > 0);
        }


        [TestMethod]
        public void obtenerSalasEmpresaTestOK()
        {
            List<Sala> salas = this.salaService.obtenerSalasEmpresa(2);
            Assert.IsNotNull(salas);
            Assert.IsTrue(salas.Count > 0);
        }
    }
}
