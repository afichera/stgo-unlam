using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Model.Exceptions;

namespace STGO
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            //log4net.Config.DOMConfigurator.Configure();

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
        }

        void Session_Start(object sender, EventArgs e)
        {
            Session["EmpresaId"] = -1;


        }

        void Session_End(object sender, EventArgs e)
        {
            Session["EmpresaId"] = -1;
        }

    }
}
