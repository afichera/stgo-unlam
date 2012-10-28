using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services.ServiceImpl;
using Model;


namespace STGO
{
    public partial class salas : System.Web.UI.Page
    {
        List<Sala> salas;
        SalaService servicioSala= new SalaService;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.salas = servicioSala.getAll();
           grid_Salas.DataSource=this.salas;
            grid_Salas.DataBind();


        }
    }
}