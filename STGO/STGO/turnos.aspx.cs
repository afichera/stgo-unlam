using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Services.Util;
using Services.Service;
using System.Web.Security;

namespace STGO
{
    public partial class turnos : System.Web.UI.Page
    {
        List<Turno> todosLosTurnos;
        ITurnoService turnoService = ServiceLocator.Instance.TurnoService;
        List<Sala> todasLasSalas;
        ISalaService salaService = ServiceLocator.Instance.SalaService;
         List<Empresa> todasLasEmpresas;
        IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;

        protected void Page_Load(object sender, EventArgs e)
        {     
         
             if (!Page.IsPostBack)
            {
                //MembershipUser userLogged = Membership.GetUser();

                //if (Roles.IsUserInRole(userLogged.UserName, Constantes.ROLES_ADMIN))
                if (true)
                {
                    this.todasLasEmpresas = empresaService.getAll();
                    liEmpresas.Items.Insert(0, new ListItem("TODAS", "0"));
                    this.todasLasSalas = salaService.obtenerSalas();
                }
                else
                {
                    this.todasLasEmpresas = new List<Empresa>();
                    liEmpresas.Visible = false;
                    //Empresa empresa = this.empresaService.getFindByGuid(new Guid(userLogged.ProviderUserKey.toString()));                  
                    //this.todasLasSalas = salaService.obtenerSalasEmpresa();
                }

                liEmpresas.DataSource = this.todasLasEmpresas;
                liEmpresas.DataBind();
                liSalas.DataSource = this.todasLasSalas;
                liSalas.DataBind();

           
               

        }

        protected void Calendario_SelectionChanged(object sender, EventArgs e)
        {
           // todosLosTurnos = turnoService.obtenerTurnos(liSalas.SelectedValue, Calendario.SelectedDate); //Crear servicio que trae todos los turnos
           // GrillaDia.DataSource = todosLosTurnos;
           // GrillaDia.DataBind();
        }

        protected void liEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}