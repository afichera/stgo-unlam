using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Util;
using Services.Service;

namespace ServiceTests
{
    [TestClass]
    public class UsuarioServiceTest
    {
        private IUsuarioService usuarioService = ServiceLocator.Instance.UsuarioService;
        [TestMethod]
        public void TestLoginOK()
        {
            String email = "admin@admin.com";
            String password = "adminadmin";
            long empresaId = usuarioService.login(email, password);
            Assert.IsTrue(empresaId != -1);
        }

        [TestMethod]
        public void TestLoginFail()
        {
            String email = "cualquiera";
            String password = "adminadmin";
            long empresaId = usuarioService.login(email, password);
            Assert.IsTrue(empresaId == -1);
        }
    }
}
