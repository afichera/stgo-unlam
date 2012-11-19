using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Services.Service;
using Services.Util;
using System.Web.Script.Services;
using Model;
using Model.Exceptions;

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

        ITurnoService turnoService = ServiceLocator.Instance.TurnoService;
        ISalaService salaService = ServiceLocator.Instance.SalaService;


        [WebMethod]
        public List<Sala> ObtenerSalas()        {
            return salaService.getAll();
        }

        [WebMethod]
        public List<Sala> ObtenerSalasEmpresa(long idEmpresa) {
            return this.salaService.obtenerSalasEmpresa(idEmpresa);
        }

        [WebMethod]
        public List<Turno> ObtenerTurnosReservados(long idSala, DateTime fecha) {
            return this.turnoService.obtenerTurnosReservados(idSala, fecha);
        }


        [WebMethod]
        public List<Turno> ObtenerTurnosLibres(long idSala, DateTime fecha)
        {
            return this.turnoService.obtenerTurnosLibres(idSala, fecha);
        }

        [WebMethod]
        public Turno ObtenerTurno(long IdSala, long IdTurno)
        {
            return this.turnoService.obtenerTurno(IdSala, IdTurno);
        }

        [WebMethod]
        public String ReservarTurno(long IdSala, String NombreReservador, String Descripcion, DateTime HoraInicio, DateTime HoraFin)
        {
            try
            {
                this.turnoService.reservarTurno(IdSala, NombreReservador, Descripcion, HoraInicio, HoraFin);
                return "Turno Reservado Correctamente.";
            }
            catch (BusinessException e)
            {
                return "Ocurrió un Error No se pudo Reservar el turno."+e.Message;
            }
            
        }   


        [WebMethod]
        public String EliminarTurno(long IdSala, long IdTurno)
        {
            
            try
            {
                this.turnoService.eliminarTurno(IdSala, IdTurno);
                return "Turno Eliminado Correctamente.";
            }
            catch (BusinessException e)
            {
                return "Ocurrió un Error No se pudo Eliminar el turno." + e.Message;
            }
        }   

    }
}