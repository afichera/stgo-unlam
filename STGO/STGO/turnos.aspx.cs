﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Services.Util;
using Services.Service;
using System.Web.Security;
using Model.Exceptions;
using System.Web.UI.HtmlControls;

namespace STGO
{
    public partial class turnos : System.Web.UI.Page
    {
        List<Turno> todosLosTurnos;
        ITurnoService turnoService = ServiceLocator.Instance.TurnoService;
        List<Sala> todasLasSalas;
        ISalaService salaService = ServiceLocator.Instance.SalaService;
        List<Empresa> todasLasEmpresas = new List<Empresa>();
        IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;
        Empresa miEmpresa;
        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser userLogged = Membership.GetUser(HttpContext.Current.User.Identity.Name);


            if (!Page.IsPostBack)
            {
                fondoTurno.Visible = false;
                editTurno.Visible = false;
                if (Roles.IsUserInRole(userLogged.UserName, Constantes.ROLES_ADMIN))
                {
                    this.todasLasEmpresas = empresaService.getAll();
                    liEmpresas.DataSource = this.todasLasEmpresas;
                    liEmpresas.DataBind();
                    liEmpresas.Items.Insert(0, new ListItem("TODAS", "0"));
                }
                else
                {
                    miEmpresa = this.empresaService.getFindByGuid((Guid)userLogged.ProviderUserKey);
                    this.todasLasEmpresas.Add(miEmpresa);
                    liEmpresas.DataSource = this.todasLasEmpresas;
                    liEmpresas.DataBind();
                }
                


                if (liEmpresas.SelectedValue == "0")
                {
                    this.todasLasSalas = salaService.obtenerSalas();
                }
                else
                {
                    this.todasLasSalas = salaService.obtenerSalasEmpresa(long.Parse(liEmpresas.SelectedValue));
                }
                if (this.todasLasSalas.Count ==0)
                {
                    Response.Redirect("~/sala-alta.aspx");
                }
                else
                {
                    liSalas.DataSource = this.todasLasSalas;
                    liSalas.DataBind();
                }
                if (liSalas != null && (!liSalas.SelectedValue.Equals("")))
                {
                    todosLosTurnos = turnoService.obtenerTurnos(long.Parse(liSalas.SelectedValue), DateTime.Now);

                }
                else {
                    todosLosTurnos = new List<Turno>();
                }
                
                GrillaDia.DataSource = todosLosTurnos;
                GrillaDia.DataBind();
            }







        }


        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            MembershipUser userLogged = Membership.GetUser(HttpContext.Current.User.Identity.Name);

            GrillaDia.Columns[0].Visible = false;
            txtEditId.Visible = false;

            if (!(Roles.IsUserInRole(userLogged.UserName, Constantes.ROLES_ADMIN)))
            {
                lblListaEmpresas.Visible = false;
                liEmpresas.Visible = false;
            }

        }

        protected void Calendario_SelectionChanged(object sender, EventArgs e)
        {

            todosLosTurnos = turnoService.obtenerTurnos(long.Parse(liSalas.SelectedValue), Calendario.SelectedDate);
            GrillaDia.DataSource = todosLosTurnos;
            GrillaDia.DataBind();
        }

        protected void liEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liEmpresas.SelectedValue == "0")
            {
                this.todasLasSalas = salaService.obtenerSalas();
            }
            else
            {
                this.todasLasSalas = salaService.obtenerSalasEmpresa(long.Parse(liEmpresas.SelectedValue));
            }
            liSalas.DataSource = this.todasLasSalas;
            liSalas.DataBind();

        }

        protected void GrillaDia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarMio")
            {

                lblerrorGuardar.Text = "";
                long id = long.Parse(e.CommandArgument.ToString());

                Turno turno = turnoService.obtenerTurno(long.Parse(liSalas.SelectedValue), id);

                txtEditId.Visible = true;
                txtEditId.Text = turno.Id.ToString();
                txtEditFecha.Text = turno.FechaHoraInicio.Date.ToShortDateString();
                txtEditHoraInicio.Text = turno.FechaHoraInicio.TimeOfDay.ToString();
                txtEditHoraFin.Text = turno.FechaHoraFin.TimeOfDay.ToString();
                txtEditReservador.Text = turno.Reservador.ToString();
                txtEditDescripcion.Text = turno.Descripcion.ToString();

                fondoTurno.Visible = true;
                editTurno.Visible = true;
                txtEditId.Visible = false;
            }
            else if (e.CommandName == "BorradoMio")
            {
                long id = long.Parse(e.CommandArgument.ToString());
                if (id != 0)
                {
                    turnoService.eliminarTurno(long.Parse(liSalas.SelectedValue), id);
                }
                todosLosTurnos = turnoService.obtenerTurnos(long.Parse(liSalas.SelectedValue), Calendario.SelectedDate);
                GrillaDia.DataSource = todosLosTurnos;
                GrillaDia.DataBind();
            }

            else if (e.CommandName == "NuevoMio")
            {

                lblerrorGuardar.Text = "";

                txtEditId.Visible = true;

                txtEditId.Text = "";
                txtEditFecha.Text = Calendario.SelectedDate.ToShortDateString();
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                txtEditHoraInicio.Text = arg[0];
                txtEditHoraFin.Text = arg[1];
                txtEditReservador.Text = "";
                txtEditDescripcion.Text = "";

                fondoTurno.Visible = true;
                editTurno.Visible = true;
                txtEditId.Visible = false;
            }

        }

        protected void GrillaDia_RowCreated(object sender, GridViewRowEventArgs e)
        {



        }

        protected void GrillaDia_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            string t = "";
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                t = DataBinder.Eval(e.Row.DataItem, "id").ToString();
                if (!(t.Equals("0")))
                {
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                    ImageButton nuevo = e.Row.FindControl("NuevoMio") as ImageButton;
                    nuevo.Visible = false;
                }

                else
                {
                    ImageButton borrar = e.Row.FindControl("BorradoMio") as ImageButton;
                    borrar.Visible = false;
                    ImageButton editar = e.Row.FindControl("EditarMio") as ImageButton;
                    editar.Visible = false;

                }


            }


        }

        protected void Calendario_Init(object sender, EventArgs e)
        {
            Calendario.SelectedDate = DateTime.Now;
        }

        protected void liSalas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dia = Calendario.SelectedDate;
            todosLosTurnos = turnoService.obtenerTurnos(long.Parse(liSalas.SelectedValue), dia);
            GrillaDia.DataSource = todosLosTurnos;
            GrillaDia.DataBind();
        }

        protected void btnNuevoTurno_Click(object sender, EventArgs e)
        {
            lblerrorGuardar.Text = "";
            fondoTurno.Visible = true;
            editTurno.Visible = true;






            txtEditId.Text = "";
            txtEditFecha.Text = Calendario.SelectedDate.Date.ToShortDateString();
            txtEditHoraInicio.Text = "";
            txtEditHoraFin.Text = "";
            txtEditReservador.Text = "";
            txtEditDescripcion.Text = "";


        }

        protected void linkCancelar_Click(object sender, EventArgs e)
        {
            txtEditId.Text = "";
            txtEditFecha.Text = "";
            txtEditHoraInicio.Text = "";
            txtEditHoraFin.Text = "";
            txtEditReservador.Text = "";
            txtEditDescripcion.Text = "";

            fondoTurno.Visible = false;
            editTurno.Visible = false;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {Page.Validate();
        if (Page.IsValid)
        {

            try
            {
                if (txtEditId.Text == "")
                {
                    turnoService.reservarTurno(long.Parse(liSalas.SelectedValue), txtEditReservador.Text, txtEditDescripcion.Text, DateTime.Parse(txtEditFecha.Text + " " + txtEditHoraInicio.Text), DateTime.Parse(txtEditFecha.Text + " " + txtEditHoraFin.Text));
                }

                else
                {
                    Turno turno = new Turno();
                    turno.Id = long.Parse(txtEditId.Text);
                    turno.FechaHoraInicio = DateTime.Parse(txtEditFecha.Text + " " + txtEditHoraInicio.Text);
                    turno.FechaHoraFin = DateTime.Parse(txtEditFecha.Text + " " + txtEditHoraFin.Text);
                    turno.Reservador = txtEditReservador.Text;
                    turno.Descripcion = txtEditDescripcion.Text;
                    turnoService.updateTurno(turno, long.Parse(liSalas.SelectedValue));
                }
                todosLosTurnos = turnoService.obtenerTurnos(long.Parse(liSalas.SelectedValue), Calendario.SelectedDate);
                GrillaDia.DataSource = todosLosTurnos;
                GrillaDia.DataBind();
                fondoTurno.Visible = false;
                editTurno.Visible = false;

            }

            catch (TurnoInvalidoException ex)
            {
                lblerrorGuardar.Text = ex.Message;
            }

            catch (BusinessException ex)
            {
                lblerrorGuardar.Text = ex.Message;
            }

        }
        }





    }
}