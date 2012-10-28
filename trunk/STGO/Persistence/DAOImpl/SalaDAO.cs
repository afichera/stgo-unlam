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
                base.Desconectar();

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
                base.Desconectar();
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
                base.Desconectar();
            }
            return sala;
        }

        public Sala saveOrUpdate(Sala entity, long empresaId)
        {
            Sala sala = entity;

            if (base.Conectar())            {
                
                string sp = "SP_SALA_SAVE_OR_UPDATE";
                SqlCommand Command = new SqlCommand(sp, base.Conexion);
                Command.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId =  new SqlParameter("id", SqlDbType.BigInt);
                SqlParameter paramFrecuencia = new SqlParameter("frecuencia", SqlDbType.Int);
                SqlParameter paramHoraCierre = new SqlParameter("horaCierre", SqlDbType.DateTime);
                SqlParameter paramHoraInicio = new SqlParameter("horaInicio", SqlDbType.DateTime);
                SqlParameter paramNombre = new SqlParameter("nombre", SqlDbType.VarChar);
                SqlParameter paramPermiteMultiplo = new SqlParameter("permiteMultiplo", SqlDbType.TinyInt);
                SqlParameter paramEmpresaId = new SqlParameter("empresaId", SqlDbType.BigInt);
                paramId.Direction = ParameterDirection.InputOutput;
                paramId.Value = sala.Id;                
                paramFrecuencia.Direction = ParameterDirection.Input;
                paramFrecuencia.Value = sala.Frecuencia;
                paramHoraCierre.Direction = ParameterDirection.Input;
                paramHoraCierre.Value = sala.HoraCierre;
                paramHoraInicio.Direction = ParameterDirection.Input;
                paramHoraInicio.Value = sala.HoraInicio;
                paramNombre.Direction = ParameterDirection.Input;
                paramNombre.Value = sala.Nombre;
                paramPermiteMultiplo.Direction = ParameterDirection.Input;
                paramPermiteMultiplo.Value = sala.PermiteMultiplo;
                paramEmpresaId.Direction = ParameterDirection.Input;
                paramEmpresaId.Value = empresaId;

                Command.Parameters.Add(paramId);
                Command.Parameters.Add(paramFrecuencia);
                Command.Parameters.Add(paramHoraCierre);
                Command.Parameters.Add(paramHoraInicio);
                Command.Parameters.Add(paramNombre);
                Command.Parameters.Add(paramPermiteMultiplo);
                Command.Parameters.Add(paramEmpresaId);

                int filasAfectadas = Command.ExecuteNonQuery();
                
                sala.Id = long.Parse(Command.Parameters["id"].Value.ToString());
                base.Desconectar();
            }
            return sala;
        }

        public Sala saveOrUpdate(Sala entity) {
            throw new NotImplementedException();
        }
        public void delete(Sala entity)
        {
            //[SP_SALA_DELETE]
            Sala sala = entity;

            if (base.Conectar())
            {
                string sp = "SP_SALA_DELETE";
                SqlCommand Command = new SqlCommand(sp, base.Conexion);
                Command.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("id", SqlDbType.BigInt);
                paramId.Direction = ParameterDirection.Input;
                paramId.Value = sala.Id;
                Command.Parameters.Add(paramId);                
                int filasAfectadas = Command.ExecuteNonQuery();
                base.Desconectar();
            }            
        }
    }
}
