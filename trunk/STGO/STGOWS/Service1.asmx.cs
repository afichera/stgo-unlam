using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Services.Service;
using Services.Util;

namespace STGOWS
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://localhost:49660/WS/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string getById(int numero) {
            return "Hola" + numero.ToString();
        }

        [WebMethod]  
        public List<Model.Empresa> getAllParametros() {
            IEmpresaService empresaService= ServiceLocator.Instance.EmpresaService;
            return empresaService.getAll();
        }
    }
}