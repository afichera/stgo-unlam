using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services.Service;
using Services.Util;
using Model;

namespace STGO
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        ISalaService salaService = ServiceLocator.Instance.SalaService;
        IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {


                        int cantidadSalas = salaService.cantidadSalasEmpresa(1);
            // int maxSalas = empresaService.cantidadSalasEmpresa(1);

                        if (cantidadSalas >= 5) //poner maxSalas cuando esté implementada
                            lblResultado.Text = "Ha alcanzado la cantidad máxima de salas permitidas para su empresa.";
                        else
                        {

                            Sala salaEdit = new Sala();

                            salaEdit.Nombre = txtNombre.Text;
                            if (ddlPermiteMultiplos.SelectedItem.Text == "Si")
                                salaEdit.PermiteMultiplo = true;
                            else
                                salaEdit.PermiteMultiplo = false;

                            salaEdit.Frecuencia = Convert.ToInt32(txtFrecuencia.Text);
                            salaEdit.HoraInicio = Convert.ToDateTime(txtHoraInicio.Text);
                            salaEdit.HoraCierre = Convert.ToDateTime(txtHoraFin.Text);
                            IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;
                            Empresa empresa = empresaService.getFindById(1); //hay que tomar el id de empresa de la sesion
                            Sala resultado = salaService.saveOrUpdate(salaEdit, empresa);

                            if (resultado != null)
                            {
                                Response.Redirect("salas.aspx");
                            }
                            else
                            {
                                lblResultado.Text = "Ha habido un error al guardar. Si el error persiste contacte al administrador.";
                            }

                        }

        }
    }
}