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
                lblResultado.Text = "Su cuenta ha sido Activada. Presione Ingresar para Acceder al Sistema.";
                btnVolver.Text = "Ingresar";
                btnVolver.PostBackUrl = "~/Login.aspx";                                
            }
            catch (RegistracionExpiradaException ex)
            {
                lblResultado.Text = "El registro se expiró. Registrarse para volver a registrarse en el sistema.";
                btnVolver.Text = "Volver";
                btnVolver.PostBackUrl = "~/Registro.aspx";      
            }
            catch (BusinessException ex)
            {
                lblResultado.Text = "No se pudo activar la cuenta. Presione volver para ir a la página principal.";
                btnVolver.Text = "Volver";
                btnVolver.PostBackUrl = "~/Default.aspx";    
            }
            
        }
    }
}