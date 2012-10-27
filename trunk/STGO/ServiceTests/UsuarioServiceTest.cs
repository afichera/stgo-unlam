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
            String email = "adminadmin";
            String password = "adminadmin";
            usuarioService.login(email, password);
        }
    }
}
