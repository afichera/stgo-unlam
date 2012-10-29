using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services.Util;
using Model;
using Services.Service;
using System.Web.Security;


namespace STGO
{
    public partial class salas : System.Web.UI.Page
    {
        List<Empresa> todasLasEmpresas;
        IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;
        List<Sala> todasLasSalas;
        ISalaService salaService = ServiceLocator.Instance.SalaService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.todasLasEmpresas = empresaService.getAll();
                liEmpresas.DataSource = this.todasLasEmpresas;
                liEmpresas.DataBind();
                liEmpresas.Items.Insert(0, new ListItem("TODAS", "0"));

                this.todasLasSalas = salaService.obtenerSalas();
                grid_Salas.DataSource = this.todasLasSalas;
                grid_Salas.DataBind();
            }




        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            grid_Salas.Columns[0].Visible = false;

            if (Roles.IsUserInRole("admin"))
            {
                lblListaEmpresas.Visible = true;
                liEmpresas.Visible = true;
            }
            else
            {
                lblListaEmpresas.Visible = false;
                liEmpresas.Visible = false;
            }

        }

        //protected void grid_Salas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    string id = grid_Salas.Rows[e.RowIndex].Cells[1].Text;
        //    long id2 = (long)Convert.ToDouble(id);
        //    salaService.delete(salaService.getFindById(id2));
        //    this.todasLasSalas = salaService.obtenerSalas();
        //    grid_Salas.DataSource = this.todasLasSalas;
        //    grid_Salas.DataBind();
        //}

        protected void liEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liEmpresas.SelectedValue == "0")
            {
                this.todasLasSalas = salaService.obtenerSalas();

            }

            else
            {
                this.todasLasSalas = salaService.obtenerSalasEmpresa((long)Convert.ToDouble(liEmpresas.SelectedValue));
            }

            grid_Salas.DataSource = this.todasLasSalas;
            grid_Salas.DataBind();
        }

        protected void grid_Salas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id= grid_Salas.Rows[e.NewEditIndex].Cells[0].Text;

            Response.Redirect("sala-editar.aspx?id=" + id.ToString());



        }

        protected void grid_Salas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            

                if (e.CommandName == "BorradoMio")
                {
                    long id=(long)Convert.ToDouble(e.CommandArgument.ToString());

                    salaService.delete(salaService.getFindById(id));
                    this.todasLasSalas = salaService.obtenerSalas();
                    grid_Salas.DataSource = this.todasLasSalas;
                    grid_Salas.DataBind();

                }




        }






    }
}