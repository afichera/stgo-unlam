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

        [TestMethod]
        public void getFindByIdTestOK()
        {
            Sala sala= this.salaService.getFindById(2);
            Assert.IsNotNull(sala);
            Assert.IsTrue(sala.Id.Equals(2));
        }

        [TestMethod]
        public void saveOrUpdateUpdateTestOK()
        {
            Sala sala = this.salaService.getFindById(2);
            sala.Nombre = "NUEVO NOMBRE";
            Empresa empresa = new Empresa();
            empresa.Id = 2;
            sala = this.salaService.saveOrUpdate(sala, empresa);
            Assert.IsNotNull(sala);
            Assert.IsTrue(sala.Id.Equals(2));
        }

        [TestMethod]
        public void saveOrUpdateSaveTestOK()
        {
            Sala sala = this.salaService.getFindById(2);
            sala.Id = 0;
            sala.Nombre = "NUEVO NOMBRE";
            Empresa empresa = new Empresa();
            empresa.Id = 2;
            sala = this.salaService.saveOrUpdate(sala, empresa);
            Assert.IsNotNull(sala);
            
        }

        [TestMethod]
        public void deleteTestOK()
        {
            Sala sala = this.salaService.getFindById(5);
            this.salaService.delete(sala);
            Assert.IsTrue(true);

        }

    }
}
