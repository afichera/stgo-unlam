using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Services.Util;
using Services.Service;
using Model;

namespace STGO
{
    public partial class empresas : System.Web.UI.Page
    {
        List<Empresa> todasLasEmpresas;
        IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                this.todasLasEmpresas = empresaService.getAll();
                grid_Empresas.DataSource = this.todasLasEmpresas;
                grid_Empresas.DataBind();
            }

        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            grid_Empresas.Columns[0].Visible = false;

        }

        protected void grid_Empresas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cambiarEstado")
            {
                long id = long.Parse(e.CommandArgument.ToString());
                Empresa empresaACambiar = empresaService.getFindById(id);
                if (empresaACambiar.activo == true)
                    empresaACambiar.activo = false;
                else
                    empresaACambiar.activo = true;

               empresaService.saveOrUpdate(empresaACambiar, empresaACambiar.Usuario.Id);
                
                this.todasLasEmpresas = empresaService.getAll();
                grid_Empresas.DataSource = this.todasLasEmpresas;
                grid_Empresas.DataBind();

            }

            else
                if (e.CommandName == "cambiarCantSalas")
                {
                    String id = e.CommandArgument.ToString();
                    Response.Redirect("cantidadDeSalas.aspx?id=" + id.ToString());
                  
                }

        }
    }
}