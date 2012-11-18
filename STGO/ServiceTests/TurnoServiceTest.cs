using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.ServiceImpl;
using Model;
using System.Diagnostics;
using Services.Service;
using Services.Util;

namespace ServiceTests
{
    [TestClass]
    public class TurnoServiceTest
    {
        private ITurnoService turnoService = ServiceLocator.Instance.TurnoService;

       //[TestMethod]
        public void TestExtraerTurnosReservados()
        {
            List<Turno> turnosTotales = new List<Turno>();
            List<Turno> turnosReservados = new List<Turno>();
            int frecuencia = 15;
            int cantidadTurnos = 20;
            Turno turnoTotal1;
            for (int i = 0; i < cantidadTurnos; i++)
			{
                turnoTotal1 = new Turno();
                turnoTotal1.FechaHoraInicio = DateTime.Now.AddMinutes(frecuencia*(i+1));
                turnoTotal1.FechaHoraFin = turnoTotal1.FechaHoraInicio.AddMinutes(frecuencia);
                turnosTotales.Add(turnoTotal1);
			}
            Turno turnoReservado1 = new Turno();
            turnoReservado1.FechaHoraInicio = DateTime.Now.AddMinutes(frecuencia * 2);
            turnoReservado1.FechaHoraInicio = turnoReservado1.FechaHoraInicio.AddMinutes(frecuencia);

            Turno turnoReservado2 = new Turno();
            turnoReservado2.FechaHoraInicio = DateTime.Now.AddMinutes(frecuencia * 3);
            turnoReservado2.FechaHoraInicio = turnoReservado1.FechaHoraInicio.AddMinutes(frecuencia);
            
            turnosReservados.Add(turnoReservado1);
            turnosReservados.Add(turnoReservado2);

            TurnoService turnoService = new TurnoService();//Voy testear metodo privado.
            List<Turno> turnosLibres =  turnoService.extraerTurnosOcupados(turnosTotales, turnosReservados);
            
            Trace.WriteLine("-----Turnos Totales-----");
            foreach (var turnoTotal in turnosTotales)
            {
                Trace.WriteLine("Fecha Hora Inicial: " + turnoTotal.FechaHoraInicio.ToLongTimeString() + ", Fecha Hora Final: " + turnoTotal.FechaHoraFin.ToLongTimeString());
            }
            Trace.WriteLine("Turnos Reservados");
            foreach (var turnoReservado in turnosReservados)
        	{
                Trace.WriteLine("Fecha Hora Inicial: " + turnoReservado.FechaHoraInicio.ToLongTimeString() + ", Fecha Hora Final: " + turnoReservado.FechaHoraFin.ToLongTimeString());
	        }

            Trace.WriteLine("Turnos Libres");
            foreach (var turnoLibre in turnosLibres)
            {
                Trace.WriteLine("Fecha Hora Inicial: " + turnoLibre.FechaHoraInicio.ToLongTimeString() + ", Fecha Hora Final: " + turnoLibre.FechaHoraFin.ToLongTimeString());
            }
            
            Assert.IsTrue(turnosLibres.Count == 17);
        }

       // [TestMethod]
        public void TestReservarTurno() { 
            DateTime horaInicio = DateTime.Now;
            DateTime horaFin = DateTime.Now.AddMinutes(30);
            this.turnoService.reservarTurno(1, "carlos", "Turno de Psicologia", horaInicio, horaFin);
            Assert.IsTrue(true);
        }
       // [TestMethod]
        public void TestEliminarTurno(){
            long idSala = 1;
            long idTurno = 100;
            this.turnoService.eliminarTurno(idSala, idTurno);
            Assert.IsTrue(true);
        }

        //[TestMethod]
        public void TestUpdateTurno() {
            Turno turno = new Turno();
            turno.Id = 100;
            turno.Descripcion = "TURNO DE PRUEBA";
            turno.Reservador = "PEPE";
            turno.FechaHoraInicio = DateTime.Now;
            turno.FechaHoraFin = turno.FechaHoraInicio.AddMinutes(30);
            this.turnoService.updateTurno(turno, 1);
            Assert.IsTrue(true);

        }

        [TestMethod]
        public void TestObtenerTurnos() {
            List<Turno> turnos = this.turnoService.obtenerTurnos(1, DateTime.Now);

            Assert.IsTrue(true);

        }

    }
}
