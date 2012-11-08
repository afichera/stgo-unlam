using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.DAO;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace Persistence.DAOImpl
{
    public class TurnoDAO : BaseDAO, ITurnoDAO
    {

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

        public Turno obtenerTurno(long idSala, long idTurno)
        {

            Turno turno = null;

            if (base.Conectar())
            {
                SqlDataReader dataReader;
                base.Command = new SqlCommand();


                base.Command.Connection = base.Conexion;
                Command.CommandText = "SELECT t.id, t.reservador, t.fechaHoraInicio, t.fechaHoraFin, t.descripcion, t.salaId  FROM Turno t WHERE t.Id = @idTurno AND t.fechaHoraBaja is null";

                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue("idTurno", idTurno);

                dataReader = Command.ExecuteReader();

                while (dataReader.Read())
                {

                    turno = new Turno();
                    turno.Id = long.Parse(dataReader.GetSqlInt64(0).ToString());
                    turno.Reservador = dataReader.GetSqlString(1).ToString();
                    turno.FechaHoraInicio = DateTime.Parse(dataReader.GetSqlDateTime(2).ToString());
                    turno.FechaHoraFin = DateTime.Parse(dataReader.GetSqlDateTime(3).ToString());
                    turno.Descripcion = dataReader.GetSqlString(4).ToString();

                }
                base.Desconectar();

            }
            return turno;

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
            List<Turno> turnos = new List<Turno>();

            if (base.Conectar())
            {
                SqlDataReader dataReader;
                base.Command = new SqlCommand();
                Turno turno;

                base.Command.Connection = base.Conexion;
                Command.CommandText = "SELECT t.id, t.reservador, t.fechaHoraInicio, t.fechaHoraFin, t.descripcion, t.salaId  FROM Turno t WHERE t.salaId = @salaId AND t.fechaHoraBaja is null";

                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue("salaId", salaId);

                dataReader = Command.ExecuteReader();

                while (dataReader.Read())
                {

                    turno = new Turno();
                    turno.Id = long.Parse(dataReader.GetSqlInt64(0).ToString());
                    turno.Reservador = dataReader.GetSqlString(1).ToString();
                    turno.FechaHoraInicio = DateTime.Parse(dataReader.GetSqlDateTime(2).ToString());
                    turno.FechaHoraFin = DateTime.Parse(dataReader.GetSqlDateTime(3).ToString());
                    turno.Descripcion = dataReader.GetSqlString(4).ToString();
                    turnos.Add(turno);
                }
                base.Desconectar();

            }
            return turnos;
        }

    }
}
