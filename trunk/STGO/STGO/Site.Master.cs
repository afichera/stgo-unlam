﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace STGO
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Membership.GetUser() != null)
            {
                usuarioLogueado.Text = "Bienvenido " + Membership.GetUser().UserName + " - ";
            }

            else
            {
                usuarioLogueado.Text = "";
            }
        }


    }
}
