using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services.Service;
using Services.Util;
using Model.Exceptions;

namespace STGO
{
    public partial class activarCuenta : System.Web.UI.Page
    {
        private IRegistracionService registracionService = ServiceLocator.Instance.RegistracionService;

        protected void Page_Load(object sender, EventArgs e)
        {
            String activateAccountKey = Request.Params.Get("key");
            Guid activationKey = new Guid(activateAccountKey);
            try
            {
                this.registracionService.activarCuenta(activationKey);
                //TODO: Mandar a una pagina de Resultado de Activación.
                Response.Redirect("Default.aspx");
                
            }
            catch (RegistracionExpiradaException ex)
            {
                //TODO: Mandar algun mensaje mejor.
                Response.Redirect("Error.aspx");
            }
            catch (BusinessException ex)
            {
                //TODO: Mandar algun mensaje mejor.
                Response.Redirect("Error.aspx");
            }
        }
    }
}