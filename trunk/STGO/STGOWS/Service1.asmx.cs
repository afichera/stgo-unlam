using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Services.Service;
using Services.Util;
using System.Web.Script.Services;
using Model;

namespace STGOWS
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://localhost:49174/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Turno ObtenerTurno(long idSala, long idTurno) {
            ITurnoService turnoService = ServiceLocator.Instance.TurnoService;
            return turnoService.obtenerTurno(idSala, idTurno);
        }
    }
}