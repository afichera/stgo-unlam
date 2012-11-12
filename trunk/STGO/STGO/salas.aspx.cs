using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services.Util;
using Model;
using Services.Service;
using System.Web.Security;


namespace STGO
{
    public partial class salas : System.Web.UI.Page
    {
        List<Empresa> todasLasEmpresas;
        IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;
        List<Sala> todasLasSalas;
        ISalaService salaService = ServiceLocator.Instance.SalaService;

        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser userLogged = Membership.GetUser(HttpContext.Current.User.Identity.Name);

            if (Roles.IsUserInRole(userLogged.UserName, Constantes.ROLES_ADMIN))
            {
                lblListaEmpresas.Visible = true;
                liEmpresas.Visible = true;
            }
            else
            {
                lblListaEmpresas.Visible = false;
                liEmpresas.Visible = false;
            }

            if (!Page.IsPostBack)
            {


                if (Roles.IsUserInRole(userLogged.UserName, Constantes.ROLES_ADMIN))
                {
                    this.todasLasEmpresas = empresaService.getAll();


                    liEmpresas.DataSource = this.todasLasEmpresas;

                    liEmpresas.DataBind();
                    liEmpresas.Items.Insert(0, new ListItem("TODAS", "0"));
                    this.todasLasSalas = salaService.obtenerSalas();
                }
                else
                {
                    this.todasLasEmpresas = new List<Empresa>();
                    Empresa empresa = this.empresaService.getFindByGuid((Guid)userLogged.ProviderUserKey);
                    this.todasLasSalas = salaService.obtenerSalasEmpresa(empresa.Id);
                }


                grid_Salas.DataSource = this.todasLasSalas;
                grid_Salas.DataBind();
            }

        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            grid_Salas.Columns[0].Visible = false;

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

            grid_Salas.DataSource = this.todasLasSalas;
            grid_Salas.DataBind();
        }

        protected void grid_Salas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = grid_Salas.Rows[e.NewEditIndex].Cells[0].Text;

            Response.Redirect("sala-editar.aspx?id=" + id.ToString());



        }

        protected void grid_Salas_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "BorradoMio")
            {

                long id = long.Parse(e.CommandArgument.ToString());

                salaService.delete(salaService.getFindById(id));


                MembershipUser userLogged = Membership.GetUser(HttpContext.Current.User.Identity.Name);
                if (Roles.IsUserInRole(userLogged.UserName, Constantes.ROLES_ADMIN))
                {
                    this.todasLasSalas = salaService.obtenerSalas();
                }
                else
                {
                    this.todasLasEmpresas = new List<Empresa>();
                    Empresa empresa = this.empresaService.getFindByGuid((Guid)userLogged.ProviderUserKey);
                    this.todasLasSalas = salaService.obtenerSalasEmpresa(empresa.Id);
                }

                grid_Salas.DataSource = this.todasLasSalas;
                grid_Salas.DataBind();








            }
        }






    }
}