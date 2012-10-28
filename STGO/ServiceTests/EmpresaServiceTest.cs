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
    public class EmpresaServiceTest
    {
        private IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;

        [TestMethod]
        public void getAllOKTestMethod()
        {
            List<Empresa> empresas = empresaService.getAll();
            Assert.IsNotNull(empresas);
            Assert.IsTrue(empresas.Count > 0);
        }

        [TestMethod]
        public void getSaveOrUpdateOKTestMethod()
        {
            List<Empresa> empresas = empresaService.getAll();
            Empresa empresaACambiar = empresas[0];
            empresaACambiar.Telefono = "111111111";
            empresaACambiar = this.empresaService.saveOrUpdate(empresaACambiar, empresaACambiar.Usuario.Id);
            Assert.IsTrue(true);
        }
    }
}
