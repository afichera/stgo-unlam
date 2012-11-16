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

namespace STGO
{
    public partial class Login : System.Web.UI.Page
    {
        private IUsuarioService usuarioService = ServiceLocator.Instance.UsuarioService;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Membership.CreateUser("adminadmin", "adminadmin");
            //Membership.CreateUser("empresa1", "empresa1");
            //Membership.CreateUser("empresa2", "empresa2");
            //Roles.AddUserToRole("adminadmin", "ADMINISTRADOR");
            //Roles.AddUserToRole("empresa1", "EMPRESA");
            //Roles.AddUserToRole("empresa2", "EMPRESA");

        }

        protected void loginSTGOId_Authenticate(object sender, AuthenticateEventArgs e)
        {

            MembershipUser user = Membership.GetUser(loginSTGOId.UserName);
            if (user != null && Membership.ValidateUser(user.UserName, loginSTGOId.Password))
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                if (Roles.IsUserInRole(user.UserName, Constantes.ROLES_ADMIN))
                {
                    Context.Response.Redirect("~/empresas.aspx", true);

                }
                else if (Roles.IsUserInRole(user.UserName, Constantes.ROLES_EMPRESA))
                {
                    if (this.usuarioService.login(user.UserName, loginSTGOId.Password) != -1)
                    {
                        Context.Response.Redirect("~/turnos.aspx", true);
                    }
                    else
                    {
                        Session.Abandon();
                        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                        loginSTGOId.FailureText = "Usuario Inactivo o Inexistente.";
                    }

                }
                else
                {
                    Response.Redirect("~/Error.aspx");
                }


            }



        }

        protected void loginSTGOId_LoginError(object sender, EventArgs e)
        {
            Console.Write("Sonamos");
        }

    }
}

