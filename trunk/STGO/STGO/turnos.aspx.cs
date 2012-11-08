using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Services.Util;
using Services.Service;
using System.Web.Security;

namespace STGO
{
    public partial class turnos : System.Web.UI.Page
    {
        List<Turno> todosLosTurnos;
        ITurnoService turnoService = ServiceLocator.Instance.TurnoService;
        List<Sala> todasLasSalas;
        ISalaService salaService = ServiceLocator.Instance.SalaService;
         List<Empresa> todasLasEmpresas;
        IEmpresaService empresaService = ServiceLocator.Instance.EmpresaService;
        long idSala;
        protected void Page_Load(object sender, EventArgs e)
        {
            GrillaDia.Columns[0].Visible = false;
            txtEditId.Visible = false;

            if (!Page.IsPostBack)
            {
                    this.todasLasEmpresas = empresaService.getAll();
                    
                    
              

                liEmpresas.DataSource = this.todasLasEmpresas;
                liEmpresas.DataBind();
                liEmpresas.Items.Insert(0, new ListItem("TODAS", "0"));

               idSala=3;
               todosLosTurnos = turnoService.obtenerTurnos(idSala, DateTime.Now); //Crear servicio que trae todos los turnos
                GrillaDia.DataSource = todosLosTurnos;
                GrillaDia.DataBind();
                
            }
           
              

        }

        protected void Calendario_SelectionChanged(object sender, EventArgs e)
        {
            idSala = 3;
            todosLosTurnos = turnoService.obtenerTurnos(3, Calendario.SelectedDate); //Crear servicio que trae todos los turnos
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
                long id = long.Parse(e.CommandArgument.ToString());

                Turno turno = turnoService.obtenerTurno(3, id);


                txtEditId.Text = turno.Id.ToString();
                txtEditFecha.Text = turno.FechaHoraInicio.ToString();
                txtEditHoraInicio.Text = turno.FechaHoraInicio.ToString();
                txtEditHoraFin.Text = turno.FechaHoraFin.ToString();
                txtEditReservador.Text = turno.Reservador.ToString();
                txtEditDescripcion.Text = turno.Descripcion.ToString();
            }
        }




    }
}