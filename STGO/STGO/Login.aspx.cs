using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace STGO
{
    public partial class Login : System.Web.UI.Page
    {
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
            if(Roles.IsUserInRole(loginSTGOId.UserName, "ADMINISTRADOR")){
                Response.Redirect("~/empresas.aspx");
            }
            else if (Roles.IsUserInRole(loginSTGOId.UserName, "EMPRESA"))
            {
                Response.Redirect("~/salas.aspx");
            }
            else {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void loginSTGOId_LoginError(object sender, EventArgs e)
        {

        }

    }
}