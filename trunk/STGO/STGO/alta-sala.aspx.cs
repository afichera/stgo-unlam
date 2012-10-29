﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Services.Service;
using Services.Util;



namespace STGO
{
    public partial class Formulario_web3 : System.Web.UI.Page
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


                    long idSala = (long)Convert.ToDouble(Request.QueryString["id"]);

                    sala = salaService.getFindById(idSala);

                    txtId.Text = Convert.ToString(sala.Id);
                    txtNombre.Text = sala.Nombre;
                    if (sala.PermiteMultiplo == true)
                        ddlPermiteMultiplos.SelectedValue = "true";
                    else
                        ddlPermiteMultiplos.SelectedValue = "false";
                    txtFrecuencia.Text = Convert.ToString(sala.Frecuencia);
                    txtHoraInicio.Text = Convert.ToString(sala.HoraInicio.TimeOfDay);
                    txtHoraFin.Text = Convert.ToString(sala.HoraCierre.TimeOfDay);


                }


            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Sala salaEdit = new Sala();
            salaEdit.Id = (long)Convert.ToDouble(txtId.Text);
            String ufa = txtNombre.Text;
            salaEdit.Nombre = txtNombre.Text;
            if (ddlPermiteMultiplos.SelectedItem.Text == "Si")
                salaEdit.PermiteMultiplo = true;
            else
                salaEdit.PermiteMultiplo = false;

            salaEdit.Frecuencia = Convert.ToInt32(txtFrecuencia.Text);
            salaEdit.HoraInicio = Convert.ToDateTime(txtHoraInicio.Text);
            salaEdit.HoraCierre = Convert.ToDateTime(txtHoraFin.Text);
            IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;
            Empresa empresa = empresaService.getFindById(1);
            Sala resultado = salaService.saveOrUpdate(salaEdit, empresa);

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