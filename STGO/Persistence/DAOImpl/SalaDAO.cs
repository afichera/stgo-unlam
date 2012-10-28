using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.DAO;
using Model;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace Persistence.DAOImpl
{
    public class SalaDAO:BaseDAO,ISalaDAO
    {
        
        public List<Sala> obtenerSalasEmpresa(long idEmpresa)
        {
            List<Sala> salas = new List<Sala>();
            
            if (base.Conectar())
            {
                SqlDataReader dataReader;
                base.Command = new SqlCommand();
                Sala sala;

                base.Command.Connection = base.Conexion;
                Command.CommandText = "SELECT s.id, s.nombre, s.permiteMultiplo, s.frecuencia, s.horaInicio, s.horaFin FROM Sala S WHERE s.empresaId = @empresaId AND s.fechaHoraBaja is null";
                
                Command.CommandType = CommandType.Text;                
                Command.Parameters.AddWithValue("empresaId", idEmpresa);
                
                dataReader = Command.ExecuteReader();

                while (dataReader.Read())
                {
                    sala = new Sala();
                    sala.Id = long.Parse(dataReader.GetSqlInt64(0).ToString());
                    sala.Nombre= dataReader.GetSqlString(1).ToString();
                    sala.PermiteMultiplo = Convert.ToBoolean(dataReader.GetSqlByte(2).Value);
                    sala.Frecuencia = int.Parse(dataReader.GetSqlInt32(3).ToString());
                    sala.HoraInicio = DateTime.Parse(dataReader.GetSqlDateTime(4).ToString());
                    sala.HoraCierre = DateTime.Parse(dataReader.GetSqlDateTime(5).ToString());
                    salas.Add(sala);
                }

            }
            return salas;
        }

        public List<Sala> getAll()
        {
            List<Sala> salas = new List<Sala>();
            if (base.Conectar())
            {
                SqlDataReader dataReader;
                base.Command = new SqlCommand();
                Sala sala;

                base.Command.Connection = base.Conexion;
                Command.CommandText = "SELECT s.id, s.nombre, s.permiteMultiplo, s.frecuencia, s.horaInicio, s.horaFin FROM Sala S WHERE s.fechaHoraBaja is null";
                Command.CommandType = CommandType.Text;
                dataReader = Command.ExecuteReader();

                while (dataReader.Read())
                {
                    sala = new Sala();
                    sala.Id = long.Parse(dataReader.GetSqlInt64(0).ToString());
                    sala.Nombre = dataReader.GetSqlString(1).ToString();
                    sala.PermiteMultiplo = Convert.ToBoolean(dataReader.GetSqlByte(2).Value);
                    sala.Frecuencia = int.Parse(dataReader.GetSqlInt32(3).ToString());
                    sala.HoraInicio = DateTime.Parse(dataReader.GetSqlDateTime(4).ToString());
                    sala.HoraCierre = DateTime.Parse(dataReader.GetSqlDateTime(5).ToString());
                    salas.Add(sala);
                }

            }
            return salas;
        }

        public Sala getFindById(long id)
        {
            Sala sala = null;

            if (base.Conectar())
            {
                SqlDataReader dataReader;
                base.Command = new SqlCommand();
               
                base.Command.Connection = base.Conexion;
                Command.CommandText = "SELECT s.id, s.nombre, s.permiteMultiplo, s.frecuencia, s.horaInicio, s.horaFin FROM Sala S WHERE s.id = @id";

                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue("id", id);
                
                dataReader = Command.ExecuteReader();

                while (dataReader.Read())
                {
                    sala = new Sala();
                    sala.Id = long.Parse(dataReader.GetSqlInt64(0).ToString());
                    sala.Nombre = dataReader.GetSqlString(1).ToString();
                    sala.PermiteMultiplo = Convert.ToBoolean(dataReader.GetSqlByte(2).Value);
                    sala.Frecuencia = int.Parse(dataReader.GetSqlInt32(3).ToString());
                    sala.HoraInicio = DateTime.Parse(dataReader.GetSqlDateTime(4).ToString());
                    sala.HoraCierre = DateTime.Parse(dataReader.GetSqlDateTime(5).ToString());
                    
                }

            }
            return sala;
        }

        public Sala saveOrUpdate(Sala entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Sala entity)
        {
            throw new NotImplementedException();
        }

        public List<Sala> obtenerSalas()
        {
            throw new NotImplementedException();
        }
    }
}
