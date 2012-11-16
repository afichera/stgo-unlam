using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Persistence.DAO;
using Model;
using Persistence.Util;
using log4net;

namespace Persistence.DAOImpl
{
    public class ParametroDAO : BaseDAO, IParametroDAO
    {
        private static ILog logger = log4net.LogManager.GetLogger(typeof(ParametroDAO));
        public List<Parametro> getAll()
        {
            List<Parametro> parametros = null;
            try
            {
                if (base.Conectar())
                {
                    SqlDataReader dataReader;
                    base.Command = new SqlCommand();
                    Parametro parametro;

                    base.Command.Connection = base.Conexion;
                    Command.CommandText = "SELECT clave, valor FROM parametro";
                    Command.CommandType = CommandType.Text;
                    dataReader = Command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        parametro = new Parametro();
                        parametro.Clave = dataReader.GetSqlString(0).ToString();
                        parametro.Valor = dataReader.GetSqlString(1).ToString();
                        parametros.Add(parametro);
                    }

                }
                else
                {
                    logger.Error(Constantes.ERROR_BDD_CONEXION);
                    throw new BDDException();
                }
                return parametros;
            }
            catch (SqlException ex)
            {
                logger.Error("Error al intentar obtener los parametros de la Base de Datos. Detalle: " + ex.Message);
                throw new BDDException("Error al intentar obtener los parametros de la Base de Datos. Detalle: " + ex.Message);
            }
            finally
            {
                base.Desconectar();
            }
        }

        public Parametro getFindByClave(String clave)
        {
            Parametro parametro = null;
            try
            {
                if (base.Conectar())
                {
                    SqlDataReader dataReader;
                    base.Command = new SqlCommand();


                    base.Command.Connection = base.Conexion;
                    Command.CommandText = "SELECT id, clave, valor FROM parametro WHERE clave = @clave";
                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("clave", clave);

                    dataReader = Command.ExecuteReader();

                    //Deberia entrar solo una vez.
                    while (dataReader.Read())
                    {
                        parametro = new Parametro();
                        parametro.Id = long.Parse(dataReader.GetSqlInt64(0).ToString());
                        parametro.Clave = dataReader.GetSqlString(1).ToString();
                        parametro.Valor = dataReader.GetSqlString(2).ToString();
                    }

                }
                else
                {
                    logger.Error(Constantes.ERROR_BDD_CONEXION);
                    throw new BDDException();
                }
                return parametro;
            }
            catch (SqlException ex)
            {
                logger.Error("Error al intentar obtener Parametro de la Base de datos. Detalle: " + ex.Message);
                throw new BDDException("Error al intentar obtener Parametro de la Base de datos. Detalle: " + ex.Message);
            }
            finally
            {
                base.Desconectar();
            }

        }

        public Parametro getFindById(long id)
        {
            throw new NotImplementedException();
        }

        public Parametro saveOrUpdate(Parametro entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Parametro entity)
        {
            throw new NotImplementedException();
        }
    }
}
