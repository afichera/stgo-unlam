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
        List<Empresa> todasLasEmpresas;
        IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;
        List<Sala> todasLasSalas;
        ISalaService salaService= ServiceLocator.Instance.SalaService;

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.todasLasEmpresas = empresaService.obtenerEmpresas();

            this.todasLasSalas = salaService.obtenerSalas();
            grid_Salas.DataSource = this.todasLasSalas;
            grid_Salas.DataBind();
        }

        protected void Page_SaveStateComplete (object sender, EventArgs e){
            grid_Salas.Columns[0].Visible = false ;
        }

        protected void grid_Salas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
         long id =(long) Convert.ToDouble(grid_Salas.Rows[e.RowIndex].Cells[0].Text);
            salaService.delete(salaService.getFindById(id));
            this.todasLasSalas = salaService.obtenerSalas();
            grid_Salas.DataSource = this.todasLasSalas;
            grid_Salas.DataBind();
        }

      
    }
}