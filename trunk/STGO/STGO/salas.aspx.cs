using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services.Util;
using Model;
using Services.Service;


namespace STGO
{
    public partial class salas : System.Web.UI.Page
    {
        List<Sala> todasLasSalas;
        ISalaService salaService= ServiceLocator.Instance.SalaService;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.todasLasSalas = salaService.obtenerSalas();
            grid_Salas.DataSource = this.todasLasSalas;
            grid_Salas.DataBind();


        }
    }
}