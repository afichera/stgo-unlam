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


        public Turno saveOrUpdate(long idSala, Turno entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Turno entity)
        {
            throw new NotImplementedException();
        }

        public List<Turno> obtenerTurnosReservados(long idSala, DateTime fecha)
        {
           return this.turnoDAO.obtenerTurnos(idSala, fecha);
        }

        public List<Turno> obtenerTurnosLibres(long idSala, DateTime fecha){
            List<Turno> turnosLibres;
            List<Turno> turnosReservados = this.obtenerTurnosReservados(idSala, fecha);
            List<Turno> turnosTotales = obtenerPlantillaTurnos(idSala);
            turnosLibres = this.extraerTurnosOcupados(turnosTotales, turnosReservados);
            turnosLibres.Sort();
            return turnosLibres;
        }

        //Genera dada una sala la plantilla de turnos completa para un dia
        private List<Turno> obtenerPlantillaTurnos(long idSala)
        {
            List<Turno> turnosTotales = new List<Turno>();
            Sala sala = this.salaDAO.getFindById(idSala);

            Turno turno;
            DateTime horarioInicioAux;
            DateTime horarioFinAux;
            int horaInicio = sala.HoraInicio.Hour;
            int horaFin = sala.HoraCierre.Hour;
            int minutosInicio = sala.HoraInicio.Minute;
            int minutosFin = sala.HoraCierre.Minute;
            int frecuencia = sala.Frecuencia;

            if ((horaInicio * 60 + minutosInicio) >= (horaFin * 60 + minutosFin))
            {
                throw new TurnoInvalidoException("La configuración de Horario de Inicio y Fin de turnos de la sala son inválidos.");
            }
            //Inicializo en el primer horario
            horarioInicioAux = sala.HoraInicio;
            horarioFinAux = sala.HoraInicio.AddMinutes(frecuencia);
            int totalMinutosDia = (((horaFin * 60) + minutosFin) - ((horaInicio * 60) + minutosInicio));
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
            return turnosTotales;
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
        
        public void reservarTurno(long idSala, String nombreReservador, String descripcion, DateTime horaInicio, DateTime horaFin)
        {
            Sala sala = this.salaDAO.getFindById(idSala);
            if (sala == null) {
                throw new BusinessException("No se encontró la sala del turno a reservar.");
            }
            if((sala.HoraInicio.Hour*60+sala.HoraInicio.Minute)>(horaInicio.Hour*60+horaInicio.Minute) || (sala.HoraCierre.Hour*60+sala.HoraCierre.Minute)<(horaFin.Hour*60+horaFin.Minute)){
                throw new TurnoInvalidoException("El turno esta fuera del rango horario de la configuración de la Sala.");
            }
            Turno turno = new Turno();
            List<Turno> turnosAOcupar = new List<Turno>();
            turno.FechaHoraFin = horaFin;
            turno.FechaHoraInicio = horaInicio;
            turnosAOcupar.Add(turno);
            List<Turno> turnosDelDia = this.obtenerTurnos(idSala, horaInicio);
            if (turnosDelDia != null && turnosDelDia.Count>0) {
                List<Turno> turnosLibres = this.extraerTurnosOcupados(turnosDelDia, turnosAOcupar);
                if (turnosLibres != null && (turnosLibres.Count != turnosDelDia.Count)) {
                    throw new TurnoInvalidoException("La Reserva del Turno no se pudo realizar. Turno Ocupado");             
                }
            }
            
            this.turnoDAO.reservarTurno(idSala, nombreReservador, descripcion, horaInicio, horaFin);
        }

        public void eliminarTurno(long idSala, long idTurno)
        {
            Sala sala = this.salaDAO.getFindById(idSala);
            if (sala == null) {
                throw new BusinessException("No se puede eliminar el turno porque la sala no existe.");
            }

            this.turnoDAO.eliminarTurno(idSala, idTurno);
        }

        public List<Turno> obtenerTurnos(long salaId, DateTime dateTime)
        {
           List<Turno> turnosReservados =  this.turnoDAO.obtenerTurnos(salaId, dateTime);
           List<Turno> turnosDelDia = this.obtenerTurnosLibres(salaId, dateTime);
           turnosDelDia.AddRange(turnosReservados);
           turnosDelDia.Sort();
           return turnosDelDia;
        }

        public void updateTurno(Turno turno, long salaId) {

            try
            {
                this.turnoDAO.updateTurno(turno, salaId);
            }

            catch (BDDException ex)
            {
                throw new TurnoInvalidoException(ex.Message);
            }
        }
    }
}
