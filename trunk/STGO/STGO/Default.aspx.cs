﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace STGO
{
    public partial class _Default : System.Web.UI.Page
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(_Default));
        protected void Page_Load(object sender, EventArgs e)
        {
            logger.Info("Esto es una prueba del Log4Net");
        }
    }
}