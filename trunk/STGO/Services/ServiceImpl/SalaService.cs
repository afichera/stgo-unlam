using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Services.Service;
using Persistence.DAO;
using Persistence.Util;
using log4net;
using Model.Exceptions;

namespace Services.ServiceImpl
{
    public class SalaService:ISalaService
    {
        private ISalaDAO salaDAO = DAOLocator.Instance.SalaDAO;
        private ITurnoDAO turnoDAO = DAOLocator.Instance.TurnoDAO;
        private static ILog logger = log4net.LogManager.GetLogger(typeof(SalaService));

        public List<Sala> getAll()
        {
            return salaDAO.getAll();
        }

        public Sala getFindById(long id)
        {
            return this.salaDAO.getFindById(id);
        }
        //TODO: Debería ser transaccional para evitar problemas de concurrencia... si queda tiempo vemos como.
        public Sala saveOrUpdate(Sala sala, Empresa empresa) {
            // Si ocurre esto es un update, debo validar.
            Sala salaAux;
            String msgTurnosError = "";
            List<Turno> turnosFuturo = new List<Turno>();
            if(sala.Id >0){
                //Para comparar el estado previo del actual.
                salaAux = this.salaDAO.getFindById(sala.Id);
                if (salaAux == null) {
                    logger.Error("La sala fue eliminada por otro usuario mientras se estaba editando.");
                    throw new BusinessException("La sala fue eliminada por otro usuario mientras se estaba editando.");
                }
                
                turnosFuturo = this.turnoDAO.obtenerTurnosFuturo(sala.Id);
                if ((salaAux.PermiteMultiplo && !sala.PermiteMultiplo) && turnosFuturo != null && turnosFuturo.Count > 0)
                {                    
                    logger.Info("La sala Id: "+sala.Id+" permitía Multiplo y posee turnos a futuro. No se puede realizar la modificación.");
                    throw new BusinessException("La sala permitía Multiplo y posee turnos a futuro. No se puede realizar la modificación.");
                }

                if ((salaAux.Frecuencia != sala.Frecuencia) && turnosFuturo != null && turnosFuturo.Count > 0) {
                    logger.Info("La sala Id: " + sala.Id + " posee turnos a futuro. No se puede realizar la modificación de la frecuencia.");
                    throw new BusinessException("La sala posee turnos a futuro. No se puede realizar la modificación de la frecuencia.");                    
                }

                foreach (var turno in turnosFuturo)
                {
                    if ((((turno.FechaHoraInicio.Hour * 60) + turno.FechaHoraInicio.Minute) < ((sala.HoraInicio.Hour * 60) + sala.HoraInicio.Minute)) ||
                        (((turno.FechaHoraFin.Hour * 60) + turno.FechaHoraFin.Minute) > ((sala.HoraCierre.Hour * 60) + sala.HoraCierre.Minute)))
                    {
                        msgTurnosError += "Reservador: " + turno.Reservador + " Hora Inicio: " + turno.FechaHoraInicio.ToString()+" Hora Fin: "+ turno.FechaHoraFin.ToString();
                    }
                    
                }
                if (!msgTurnosError.Equals("")) {
                    logger.Info("No se puedo modificar la Sala porque tiene turnos a futuro que interfieren con la configuración elegida. Detalle: " + msgTurnosError);
                    throw new BusinessException("No se puedo modificar la Sala porque tiene turnos a futuro que interfieren con la configuración elegida. Detalle: " + msgTurnosError);
                }


            }

            return this.salaDAO.saveOrUpdate(sala, empresa.Id);
        }

        public Sala saveOrUpdate(Sala entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Sala entity)
        {
            this.salaDAO.delete(entity);
        }

        public List<Sala> obtenerSalas()
        {
            return this.getAll();
        }

        public List<Sala> obtenerSalasEmpresa(long idEmpresa)
        {
            return this.salaDAO.obtenerSalasEmpresa(idEmpresa);
        }

        public int cantidadSalasEmpresa(long idEmpresa)
        {
            return this.salaDAO.cantidadSalasEmpresa(idEmpresa);
        }
    }
}
