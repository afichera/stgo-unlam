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

        public bool conectar()
        {
            sConexion = cadenaConexion();

            if (Conexion == null)
                Conexion = new SqlConnection(sConexion);

            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();


            return (Conexion.State == ConnectionState.Open);

        }

        public void desconectar() {
            if (Conexion != null && Conexion.State == ConnectionState.Open) {
                Conexion.Close();
            }
        }
       
        public String cadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;

        }

        public void comenzarTransaccion()
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

        public void finalizarTransaccion()
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


        public void cancelarTransaccion()
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
    }


}
