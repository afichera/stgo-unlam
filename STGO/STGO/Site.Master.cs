using System;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Model;

namespace STGO
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser();
            if (user != null)
            {
                usuarioLogueado.Text = "Bienvenido " + user.UserName + " - ";
            }

            else
            {
                usuarioLogueado.Text = "";
            }
        }

 
    }


}
