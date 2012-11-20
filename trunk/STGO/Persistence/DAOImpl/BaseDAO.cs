using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.DAO;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Model;
using Model.Exceptions;
using System.Configuration;


namespace Persistence.DAOImpl
{
    public abstract class BaseDAO : IBaseDAO
    {
        string sConexion;
        public SqlCommand Command { get; set; }
        public SqlConnection Conexion { get; set; }
        public SqlDataAdapter Adapter { get; set; }
        public SqlTransaction Transaction { get; set; }

        DataTable dtResultado;
        Int32 cantidadParametros = 0;
        Int32 numeroDeRegistro = 0;


        public bool Conectar()
        {
            sConexion = CadenaConexion();

            if (Conexion == null)
                Conexion = new SqlConnection(sConexion);

            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();


            return (Conexion.State == ConnectionState.Open);

        }

        public void Desconectar() {
            if (Conexion != null && Conexion.State == ConnectionState.Open) {
                Conexion.Close();
            }
        }
       
        public String CadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;

        }

        public void ComenzarTransaccion()
        {
            try
            {
                Transaction = Conexion.BeginTransaction();
            }
            catch (SqlException sqlEx)
            {

                throw new BusinessException("No se pudo iniciar la transacción. Causa: " + sqlEx.Message);
            }



        }

        public void FinalizarTransaccion()
        {
            try
            {
                Transaction.Commit();
            }
            catch (SqlException sqlEx)
            {
                Transaction.Rollback();
                throw new BusinessException("No se pudo finalizar la transacción. Causa: " + sqlEx);
            }

        }


        public void CancelarTransaccion()
        {
            try
            {
                Transaction.Rollback();
            }
            catch (SqlException sqlEx)
            {
                throw new BusinessException("No se pudo cancelar la transacción. Causa: " + sqlEx);
            }

        }




        #region Ejemplo 5
        public bool EjecutarStoredProcedure(bool tieneTransaccion, string nombreSP, ArrayList sqlParametros)
        {
            if (Conectar())
            {

                Command = new SqlCommand();		// Instancio el objeto Command de la clase
                Command.Connection = Conexion;	    // Asigno la conexión activa al Command

                Command.CommandType = CommandType.StoredProcedure;	// Indico que se trata de un procedimiento almacenado
                Command.CommandText = nombreSP;		                // Indico cual es el stored procedure

                if (tieneTransaccion)
                    Command.Transaction = Transaction;

                SqlCommandBuilder.DeriveParameters(Command);       // Obtengo los Parametros del SP del SQLServer

                Int32 cantidadParametros;

                if (sqlParametros == null)
                    cantidadParametros = 0;
                else
                    cantidadParametros = sqlParametros.Count;

                if (cantidadParametros == Command.Parameters.Count - 1)
                {
                    for (int i = 1; i <= Command.Parameters.Count - 1; i++)
                    {
                        Command.Parameters[i].Value = sqlParametros[i - 1];		// Agrego el parámetro sqlConn el valor del cod de la provincia para obtener sus localidades
                    }

                    Command.ExecuteNonQuery();

                    return true;
                }

            }

            return false;
        }

        public DataSet DevolverDatos()
        {

            DataSet ds = new DataSet();

            Adapter = new SqlDataAdapter(Command);

            Adapter.Fill(ds);

            return ds;


        }
        #endregion Ejemplo 5

        #region Ejemplo 6
        public bool EjecutarStoredProcedureDataReader(String nombreSP, ArrayList sqlParametros)
        {
            if (Conectar())
            {

                Command = new SqlCommand();		// Instancio el objeto Command de la clase
                Command.Connection = Conexion;	    // Asigno la conexión activa al Command

                Command.CommandType = CommandType.StoredProcedure;	// Indico que se trata de un procedimiento almacenado
                Command.CommandText = nombreSP;		                // Indico cual es el stored procedure


                SqlCommandBuilder.DeriveParameters(Command);       // Obtengo los Parametros del SP del SQLServer

                if (sqlParametros == null)
                    cantidadParametros = 0;
                else
                    cantidadParametros = sqlParametros.Count;

                if (cantidadParametros == Command.Parameters.Count - 1)
                {
                    for (int i = 1; i <= Command.Parameters.Count - 1; i++)
                    {
                        Command.Parameters[i].Value = sqlParametros[i - 1];		// Agrego el parámetro sqlConn el valor del cod de la provincia para obtener sus localidades
                    }

                    numeroDeRegistro = 0;

                    dtResultado = new DataTable();

                    dtResultado.Load(Command.ExecuteReader(CommandBehavior.CloseConnection));

                    return true;
                }

            }

            return false;
        }

        public DataTable DevolverDatosRapido()
        {

            return (dtResultado);	// Retorno el DataSet interno de la clase


        }

        #endregion Ejemplo 6

        #region Ejemplo 7

        public string DevolverRegistro()
        {
            string registro = String.Empty;

            if (dtResultado.Rows.Count > numeroDeRegistro)
            {
                for (int iColumna = 0; iColumna <= dtResultado.Columns.Count - 1; iColumna++)
                {
                    if (registro == String.Empty)
                        registro += dtResultado.Rows[numeroDeRegistro][iColumna].ToString();
                    else
                        registro += "|" + dtResultado.Rows[numeroDeRegistro][iColumna].ToString();
                }

                numeroDeRegistro++;
            }

            return (registro);	// Retorno el Registro Actual


        }

        #endregion Ejemplo 7

        public bool conectar()
        {
            throw new NotImplementedException();
        }

        public string cadenaConexion()
        {
            throw new NotImplementedException();
        }

        public void comenzarTransaccion()
        {
            throw new NotImplementedException();
        }

        public void finalizarTransaccion()
        {
            throw new NotImplementedException();
        }

        public void cancelarTransaccion()
        {
            throw new NotImplementedException();
        }
    }


}
