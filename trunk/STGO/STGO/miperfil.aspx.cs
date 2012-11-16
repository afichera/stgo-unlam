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


namespace STGO
{
    public partial class miperfil : System.Web.UI.Page
    {
        IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;
        MembershipUser userLogged = Membership.GetUser(HttpContext.Current.User.Identity.Name);


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Empresa empresa = this.empresaService.getFindByGuid((Guid)userLogged.ProviderUserKey);
                txtMail.Text = empresa.Usuario.EMail.ToString();
                txtRazonSocial.Text = empresa.RazonSocial.ToString();
                txtCuit.Text = empresa.CUIT.ToString();
                txtTelefono.Text = empresa.Telefono.ToString();
            }
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

                   Empresa resultado = empresaService.saveOrUpdate(empresaEdit);

                   if (resultado != null)
                   {
                       lblResultado.Text = "Se han guardado los datos";
                   }
                   else
                   {
                       lblResultado.Text = "Ha habido un error al guardar. Si el error persiste contacte al administrador.";
                   }
               }

        }


    }
}