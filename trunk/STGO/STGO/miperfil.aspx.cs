using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Model;
using Services.Service;
using Services.Util;
using Model.Exceptions;
using log4net;


namespace STGO
{
    public partial class miperfil : System.Web.UI.Page
    {
        IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;
        MembershipUser userLogged = Membership.GetUser(HttpContext.Current.User.Identity.Name);
        private static ILog logger = log4net.LogManager.GetLogger(typeof(miperfil));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                inicializar();
            }
        }

        private void inicializar()
        {
            Empresa empresa = this.empresaService.getFindByGuid((Guid)userLogged.ProviderUserKey);
            
            txtMail.Text = empresa.Usuario.EMail.ToString();
            txtRazonSocial.Text = empresa.RazonSocial.ToString();
            txtCuit.Text = empresa.CUIT.ToString();
            txtTelefono.Text = empresa.Telefono.ToString();
        }

        protected void btnGuardarPerfil_Click(object sender, EventArgs e)
        {

            Page.Validate("valGrupoEdicion");
               if (Page.IsValid )
               {
                   Empresa empresaEdit = this.empresaService.getFindByGuid((Guid)userLogged.ProviderUserKey);
                   empresaEdit.RazonSocial = txtRazonSocial.Text;
                   empresaEdit.CUIT = txtCuit.Text;
                   empresaEdit.Telefono = txtTelefono.Text;

                   try
                   {
                       empresaService.saveOrUpdate(empresaEdit);
                       lblResultado.Text = "Se han guardado los datos";
                   }
                   catch (BusinessException ex)
                   {
                       logger.Error("Ha ocurrido un error al guardar los datos de la empresa Id: " + empresaEdit.Id + ". Detalle: " + ex.Message);
                       lblResultado.Text = "Ha ocurrido un error al guardar. Si el error persiste contacte al administrador.";
                   }

               }

        }


    }
}