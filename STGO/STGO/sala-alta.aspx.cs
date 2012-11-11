using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services.Service;
using Services.Util;
using Model;
using System.Web.Security;

namespace STGO
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        ISalaService salaService = ServiceLocator.Instance.SalaService;
        IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;
        List<Empresa> todasLasEmpresas;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                MembershipUser userLogged = Membership.GetUser(HttpContext.Current.User.Identity.Name);

                if (Roles.IsUserInRole(userLogged.UserName, Constantes.ROLES_ADMIN))
                {
                    this.todasLasEmpresas = empresaService.getAll();



                }
                else
                {
                    this.todasLasEmpresas = new List<Empresa>();
                    Empresa empresa = this.empresaService.getFindByGuid((Guid)userLogged.ProviderUserKey);
                    todasLasEmpresas.Add(empresa);
                    liEmpresas.Visible = false;
                    lblListaEmpresas.Visible = false;

                }
                liEmpresas.DataSource = this.todasLasEmpresas;
                liEmpresas.DataBind();

            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            Page.Validate();
            if (Page.IsValid)
            {
                MembershipUser userLogged = Membership.GetUser(HttpContext.Current.User.Identity.Name);
                Empresa empresa = this.empresaService.getFindById(long.Parse(liEmpresas.SelectedValue.ToString()));
                int cantidadSalas = salaService.cantidadSalasEmpresa(empresa.Id);
                if (cantidadSalas >= empresa.maximoSalas) //poner maxSalas cuando esté implementada
                    lblResultado.Text = "Ha alcanzado la cantidad máxima de salas permitidas para su empresa.";
                else
                {

                    Sala salaEdit = new Sala();

                    salaEdit.Nombre = txtNombre.Text;
                    if (ddlPermiteMultiplos.SelectedItem.Text == "Si")
                        salaEdit.PermiteMultiplo = true;
                    else
                        salaEdit.PermiteMultiplo = false;

                    salaEdit.Frecuencia = Convert.ToInt32(txtFrecuencia.Text);
                    salaEdit.HoraInicio = Convert.ToDateTime(txtHoraInicio.Text);
                    salaEdit.HoraCierre = Convert.ToDateTime(txtHoraFin.Text);


                    Sala resultado = salaService.saveOrUpdate(salaEdit, empresa);

                    if (resultado != null)
                    {
                        Response.Redirect("salas.aspx");
                    }
                    else
                    {
                        lblResultado.Text = "Ha habido un error al guardar. Si el error persiste contacte al administrador.";
                    }

                }
            }

        }
    }
}