using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Services.Util;
using Services.Service;

namespace STGO
{
    public partial class cantidadDeSalas : System.Web.UI.Page
    {
        IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;
        Empresa empresa;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {   
                if (Request.QueryString["id"] == null)
                    Response.Redirect("empresas.aspx");
                else
                {


                    long idEmpresa = long.Parse(Request.QueryString["id"]);

                    this.empresa = empresaService.getFindById(idEmpresa);

                    txtRazonSocial.Text =empresa.RazonSocial;
                    txtCantSalas.Text = empresa.maximoSalas.ToString();
                    

                }


            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
             Page.Validate();
             if (Page.IsValid)
             {
                 long idEmpresa = (long)Convert.ToDouble(Request.QueryString["id"]);

                 this.empresa = empresaService.getFindById(idEmpresa);

                 this.empresa.maximoSalas = Convert.ToInt32(txtCantSalas.Text);
                 Empresa resultado = empresaService.saveOrUpdate(empresa, empresa.Usuario.Id);

                 if (resultado != null)
                 {
                     lblResultado.Text = "Se han guardado los datos";
                 }
                 else
                 {
                     lblResultado.Text = "Ha habido un error al guardar. Si el error persiste contacte al administrador.";
                 }


             }
        }
    }
}