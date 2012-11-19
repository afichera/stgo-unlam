using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Services.Service;
using Services.Util;
using Model.Exceptions;


namespace STGO
{
    public partial class Formulario_web21 : System.Web.UI.Page
    {
        ISalaService salaService = ServiceLocator.Instance.SalaService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Sala sala;

                string id = "";
                if (Request.QueryString["id"] == null)
                    Response.Redirect("salas.aspx");
                else
                {


                    long idSala = long.Parse(Request.QueryString["id"]);

                    sala = salaService.getFindById(idSala);

                    txtId.Text = Convert.ToString(sala.Id);
                    txtNombre.Text = sala.Nombre;
                    if (sala.PermiteMultiplo == true)
                        ddlPermiteMultiplos.SelectedValue = "true";
                    else
                        ddlPermiteMultiplos.SelectedValue = "false";
                    txtFrecuencia.Text = Convert.ToString(sala.Frecuencia);
                    txtHoraInicio.Text = sala.HoraInicio.TimeOfDay.ToString();
                    txtHoraFin.Text = sala.HoraCierre.TimeOfDay.ToString();


                }


            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                try
                {


                    Sala salaEdit = new Sala();
                    salaEdit.Id = long.Parse(txtId.Text);
                    salaEdit.Nombre = txtNombre.Text;
                    if (ddlPermiteMultiplos.SelectedItem.Text == "Si")
                        salaEdit.PermiteMultiplo = true;
                    else
                        salaEdit.PermiteMultiplo = false;

                    salaEdit.Frecuencia = Convert.ToInt32(txtFrecuencia.Text);
                    salaEdit.HoraInicio = Convert.ToDateTime(txtHoraInicio.Text);
                    salaEdit.HoraCierre = Convert.ToDateTime(txtHoraFin.Text);
                    IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;
                    Empresa empresa = empresaService.getFindById(1);//hay que tomar el id de empresa de la sesion
                    Sala resultado = salaService.saveOrUpdate(salaEdit, empresa);

                    if (resultado != null)
                    {
                        lblResultado.Text = "Se han guardado los datos";
                        lblerrorGuardar.Text = "";
                    }
                    else
                    {
                        lblResultado.Text = "Ha habido un error al guardar. Si el error persiste contacte al administrador.";
                    }
                }

                catch (BusinessException ex)
                {
                    lblResultado.Text = "";
                    lblerrorGuardar.Text = ex.Message;
                }


            }
        }
    }
}