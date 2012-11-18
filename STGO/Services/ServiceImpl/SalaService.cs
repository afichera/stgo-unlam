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
                //TODO: Buscar los turnos a futuro y si no hay lanzar excepcion.

                if (salaAux.PermiteMultiplo && !sala.PermiteMultiplo && turnosFuturo != null && turnosFuturo.Count > 0)
                {                    
                    logger.Error("La sala Id: "+sala.Id+" permitía Multiplo y posee turnos a futuro. No se puede realizar la modificación.");
                    throw new BusinessException("La sala permitía Multiplo y posee turnos a futuro. No se puede realizar la modificación.");
                }

                foreach (var turno in turnosFuturo)
                {
                    if ((((turno.FechaHoraInicio.Hour * 60) + turno.FechaHoraInicio.Minute) < ((sala.HoraInicio.Hour * 60) + sala.HoraInicio.Minute))) {
                        msgTurnosError += "Reservador: " + turno.Reservador + " Hora Inicio: " + turno.FechaHoraInicio.ToString();
                    }
                    
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
