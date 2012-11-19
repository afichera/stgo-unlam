using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Services.Service;
using Services.Util;
using Model;
using Model.Exceptions;
using log4net;

namespace STGO
{
    public partial class Login : System.Web.UI.Page
    {
        private IUsuarioService usuarioService = ServiceLocator.Instance.UsuarioService;
        private static ILog logger = log4net.LogManager.GetLogger(typeof(Login));
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginSTGOId_Authenticate(object sender, AuthenticateEventArgs e)
        {

            MembershipUser user = Membership.GetUser(loginSTGOId.UserName);
            try
            {
                if (user != null)
                {
                   
                    long retorno = this.usuarioService.login(loginSTGOId.UserName, loginSTGOId.Password);
                    switch (retorno)
                    {

                        case 0:
                            //Usuario administrador.
                            FormsAuthentication.SetAuthCookie(user.UserName, false);
                            Context.Response.Redirect("~/empresas.aspx", true);
                            break;
                        case -1:
                            //inactivo o inexistente.
                            Session.Abandon();
                            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                            loginSTGOId.FailureText = "Usuario Inactivo o Inexistente.";
                            break;
                        default:
                            //Usuario Empresa.
                            FormsAuthentication.SetAuthCookie(user.UserName, false);
                            Context.Response.Redirect("~/turnos.aspx", true);
                            break;
                    }
                }
                else
                {
                    Session.Abandon();
                    Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                    loginSTGOId.FailureText = "Usuario Inactivo o Inexistente.";
                }
            }
            catch (BusinessException ex)
            {
                logger.Info("Ocurrió un error durante el logueo del usuario: " + loginSTGOId.UserName + ". Detalle: " + ex.Message);
                Response.Redirect("~/Error.aspx");
            }

        }

        protected void loginSTGOId_LoginError(object sender, EventArgs e)
        {
            Console.Write("Sonamos");
        }

    }
}

