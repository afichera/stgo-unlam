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
using Model.Exceptions;
using log4net;

namespace STGO
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        ISalaService salaService = ServiceLocator.Instance.SalaService;
        IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;
        private static ILog logger = log4net.LogManager.GetLogger(typeof(Formulario_web12));
        List<Empresa> todasLasEmpresas;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                inicializar();
            }

        }

        private void inicializar()
        {
            try
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
            catch (BusinessException ex)
            {
                logger.Error("No se pudieron cargar obtener datos de la empresa. Detalle: "+ex.Message);
                lblResultado.Text = "Ocurrió un error al obtener datos de la empresa. Contactese con el administrador.";
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            Page.Validate();
            if (Page.IsValid)
            {
                guardarSala();
            }

        }

        private void guardarSala()
        {
            try
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
                    {
                        salaEdit.PermiteMultiplo = true;
                    }
                    else
                    {
                        salaEdit.PermiteMultiplo = false;
                    }

                    salaEdit.Frecuencia = Convert.ToInt32(txtFrecuencia.Text);
                    salaEdit.HoraInicio = Convert.ToDateTime(txtHoraInicio.Text);
                    salaEdit.HoraCierre = Convert.ToDateTime(txtHoraFin.Text);


                    salaService.saveOrUpdate(salaEdit, empresa);
                    Response.Redirect("salas.aspx");
                }
            }
            catch (BusinessException ex)
            {
                logger.Error("Ha ocurrido un error al guardar. Detalle: "+ex.Message);
                lblResultado.Text = "Ha ocurrido un error al guardar. Si el error persiste contacte al administrador.";
            }

        }
    }
}