using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Services.Service;
using Persistence.DAO;
using Persistence.Util;
using Model.Exceptions;

namespace Services.ServiceImpl
{
    public class TurnoService:ITurnoService
    {
        private ITurnoDAO turnoDAO = DAOLocator.Instance.TurnoDAO;
        private ISalaDAO salaDAO = DAOLocator.Instance.SalaDAO;

        public List<Turno> getAll()
        {
            throw new NotImplementedException();
        }

        public Turno getFindById(long id)
        {
            throw new NotImplementedException();
        }

        public Turno saveOrUpdate(Turno entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Turno entity)
        {
            throw new NotImplementedException();
        }

        public List<Turno> obtenerTurnosReservados(long idSala, DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public List<Turno> obtenerTurnosLibres(long idSala, DateTime fecha)
        {
            Sala sala = this.salaDAO.getFindById(idSala);
            List<Turno> turnosReservados = this.obtenerTurnosReservados(idSala, fecha);
            List<Turno> turnosTotales = new List<Turno>();
            List<Turno> turnosLibres;
            Turno turno;
            DateTime horarioInicioAux;
            DateTime horarioFinAux;
            int horaInicio = sala.HoraInicio.Hour;
            int horaFin = sala.HoraCierre.Hour;
            int minutosInicio = sala.HoraInicio.Minute;
            int minutosFin = sala.HoraCierre.Minute;
            int frecuencia = sala.Frecuencia;
            
            if((horaInicio*60+minutosInicio)>=(horaFin*60+minutosFin)){
                throw new TurnoInvalidoException("La configuración de Horario de Inicio y Fin de turnos de la sala son inválidos.");
            }
            //Inicializo en el primer horario
            horarioInicioAux = sala.HoraInicio;
            horarioFinAux = sala.HoraInicio.AddMinutes(frecuencia);
            int totalMinutosDia = (((horaFin * 60) + minutosFin) / ((horaInicio * 60) + minutosInicio));            
            int maximoTurnosDia = totalMinutosDia / frecuencia;
            for (int i = 0; i < maximoTurnosDia; i++)
            {
                turno = new Turno();
                turno.FechaHoraInicio = horarioInicioAux;
                turno.FechaHoraFin = horarioFinAux;
                turno.Descripcion = "";
                turno.Reservador = "";
                
                horarioFinAux = horarioFinAux.AddMinutes(frecuencia);
                horarioInicioAux = horarioInicioAux.AddMinutes(frecuencia);
                turnosTotales.Add(turno);
            }
            turnosLibres = this.extraerTurnosOcupados(turnosTotales, turnosReservados);
            turnosLibres.Sort();
            return turnosLibres;
        }

        public List<Turno> extraerTurnosOcupados(List<Turno> turnosTotales, List<Turno> turnosReservados){
            List<Turno> turnosLibres = new List<Turno>();
            int minutoInicialTurnoReservado;
            int minutoFinalTurnoReservado;
            int minutoInicialLibre;
            int minutoFinalLibre;
            bool agregarTurno;
            if (turnosReservados != null && turnosReservados.Count > 0)
            {
                foreach (var turnoLibre in turnosTotales)
                {
                    agregarTurno = true;
                    minutoInicialLibre = turnoLibre.FechaHoraInicio.Hour * 60 + turnoLibre.FechaHoraInicio.Minute;
                    minutoFinalLibre = turnoLibre.FechaHoraFin.Hour * 60 + turnoLibre.FechaHoraFin.Minute;

                    foreach (var turnoReservado in turnosReservados)
                    {
                        minutoInicialTurnoReservado = turnoReservado.FechaHoraInicio.Hour * 60 + turnoReservado.FechaHoraInicio.Minute;
                        minutoFinalTurnoReservado = turnoReservado.FechaHoraFin.Hour * 60 + turnoReservado.FechaHoraFin.Minute;

                        if ((minutoInicialTurnoReservado >= minutoInicialLibre && minutoInicialTurnoReservado <= minutoFinalLibre)
                            || (minutoFinalTurnoReservado >= minutoInicialLibre && minutoFinalTurnoReservado <= minutoFinalLibre))
                        {
                            agregarTurno = false;
                        }
                        
                    }

                    if (agregarTurno) {
                        turnosLibres.Add(turnoLibre);
                    }
                }
            }
            else {
                turnosLibres = turnosTotales;
            }
            
            return turnosLibres;
        }

        public Turno obtenerTurno(long idSala, long idTurno)
        {
            return this.turnoDAO.obtenerTurno(idSala, idTurno);
        }

        public void reservarTurno(long idSala, string nombreReservador, string descripcion, DateTime horaInicio, DateTime horaFin)
        {
            throw new NotImplementedException();
        }

        public void eliminarTurno(long idSala, long idTurno)
        {
            throw new NotImplementedException();
        }

        public List<Turno> obtenerTurnos(long salaId, DateTime dateTime)
        {
            return this.turnoDAO.obtenerTurnos(salaId, dateTime);

        }

    }
}
