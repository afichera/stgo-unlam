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
        Empresa miEmpresa;
        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser userLogged = Membership.GetUser(HttpContext.Current.User.Identity.Name);


            if (!Page.IsPostBack)
            {
            if (Roles.IsUserInRole(userLogged.UserName, Constantes.ROLES_ADMIN))
            {
                this.todasLasEmpresas = empresaService.getAll();
                liEmpresas.DataSource = this.todasLasEmpresas;
                liEmpresas.DataBind();
                liEmpresas.Items.Insert(0, new ListItem("TODAS", "0"));
            }
            else
            {
                miEmpresa = this.empresaService.getFindByGuid((Guid)userLogged.ProviderUserKey);
                this.todasLasEmpresas.Add(miEmpresa);
                liEmpresas.DataSource = this.todasLasEmpresas;
                liEmpresas.DataBind();
            }

                           

            if (liEmpresas.SelectedValue == "0")
            {
                this.todasLasSalas = salaService.obtenerSalas();
            }
            else
            {
                this.todasLasSalas = salaService.obtenerSalasEmpresa(long.Parse(liEmpresas.SelectedValue));
            }
            liSalas.DataSource = this.todasLasSalas;
            liSalas.DataBind();
                
                
                todosLosTurnos = turnoService.obtenerTurnos(long.Parse(liSalas.SelectedValue), DateTime.Now); 
                GrillaDia.DataSource = todosLosTurnos;
                GrillaDia.DataBind();

            }
        }


        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {

            GrillaDia.Columns[0].Visible = false;
            txtEditId.Visible = false;
        }

        protected void Calendario_SelectionChanged(object sender, EventArgs e)
        {

            todosLosTurnos = turnoService.obtenerTurnos(long.Parse(liSalas.SelectedValue), Calendario.SelectedDate); 
            GrillaDia.DataSource = todosLosTurnos;
            GrillaDia.DataBind();
        }

        protected void liEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liEmpresas.SelectedValue == "0")
            {
                this.todasLasSalas = salaService.obtenerSalas();
            }
            else
            {
                this.todasLasSalas = salaService.obtenerSalasEmpresa(long.Parse(liEmpresas.SelectedValue));
            }
            liSalas.DataSource = this.todasLasSalas;
            liSalas.DataBind();

        }

        protected void GrillaDia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarMio")
            {
                long id = long.Parse(e.CommandArgument.ToString());

                Turno turno = turnoService.obtenerTurno(long.Parse(liSalas.SelectedValue), id);


                txtEditId.Text = turno.Id.ToString();
                txtEditFecha.Text = turno.FechaHoraInicio.ToString();
                txtEditHoraInicio.Text = turno.FechaHoraInicio.ToString();
                txtEditHoraFin.Text = turno.FechaHoraFin.ToString();
                txtEditReservador.Text = turno.Reservador.ToString();
                txtEditDescripcion.Text = turno.Descripcion.ToString();
            }
            else if (e.CommandName == "BorradoMio")
            {
                long id = long.Parse(e.CommandArgument.ToString());
                if (id != null)
                {
                    turnoService.delete(turnoService.getFindById(id));
                    todosLosTurnos = turnoService.obtenerTurnos(long.Parse(liSalas.SelectedValue), DateTime.Now); 
                    GrillaDia.DataSource = todosLosTurnos;
                    GrillaDia.DataBind();
                }
            }

        }

        protected void GrillaDia_RowCreated(object sender, GridViewRowEventArgs e)
        {
            

            
        }

        protected void GrillaDia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
                string t = "";
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    t = DataBinder.Eval(e.Row.DataItem, "id").ToString();
                    if (!(t.Equals("")))
                    {
                        e.Row.BackColor = System.Drawing.Color.LightGreen;

                    }


                }
            //else quitar botón eliminar

        }

        protected void Calendario_Init(object sender, EventArgs e)
        {
            Calendario.SelectedDate = DateTime.Now;
        }

        protected void liSalas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dia = Calendario.SelectedDate;
            todosLosTurnos = turnoService.obtenerTurnos(long.Parse(liSalas.SelectedValue), dia);
            GrillaDia.DataSource = todosLosTurnos;
            GrillaDia.DataBind();
        }





    }
}