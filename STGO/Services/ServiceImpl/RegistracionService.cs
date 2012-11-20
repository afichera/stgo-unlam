using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Services.Service;
using Model;
using Persistence.DAO;
using Persistence.Util;
using Model.Exceptions;
using System.Web.Security;
using log4net;


namespace Services.ServiceImpl
{
    public class RegistracionService : IRegistracionService
    {
        private IRegistracionDAO registracionDAO = DAOLocator.Instance.RegistracionDAO;
        private IParametroDAO parametroDAO = DAOLocator.Instance.ParametroDAO;
        private static ILog logger = log4net.LogManager.GetLogger(typeof(RegistracionService));

        public List<Registracion> getAll()
        {
            throw new NotImplementedException();
        }

        public Registracion getFindById(long id)
        {
            throw new NotImplementedException();
        }

        public Registracion saveOrUpdate(Registracion entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Registracion entity)
        {
            throw new NotImplementedException();
        }

        public void newAccountValidate(string userName)
        {
            Registracion registracion = this.registracionDAO.getFindByUserName(userName);
            if (registracion != null )
            {
                if (registracion.Pendiente)
                {
                    DateTime fechaHoraActual = DateTime.Now;
                    TimeSpan timeSpan = new TimeSpan(0, 30, 0);
                    fechaHoraActual = fechaHoraActual.Subtract(timeSpan);
                    if (registracion.FechaHoraRegistro <= fechaHoraActual)
                    {
                        this.registracionDAO.delete(registracion);
                        Membership.DeleteUser(userName);
                        logger.Info("Se elimino el registro de registración vencido para poder reutilizar el mismo email: " + userName);
                    }
                    else {
                        logger.Info("Se realizo un intento de registro con un usuario que posee una registración pendiente no vencida. Usuario: "+userName);
                        throw new EMailRegistradoException();
                    }                    
                }
                else {
                    logger.Info("No se pudo realizar el registro con el nombre de usuario: " + userName + ", porque ya existe.");
                    throw new EMailRegistradoException();
                }
            }
            
        }


        public void completarRegistro(Registracion registracion, Guid guid)
        {
            this.registracionDAO.crearPendiente(registracion, guid);
            
        }


        public String obtenerCuerpoMailActivacion(String userName)
        {
            StringBuilder mensaje = new StringBuilder();
            Registracion registracion = this.registracionDAO.getFindByUserName(userName);
            Parametro hostActivationURL = this.parametroDAO.getFindByClave("HOST_ACTIVATION_URL");
            mensaje.AppendLine(String.Format("Bienvenido {0}: <br />", registracion.RazonSocial));
            mensaje.AppendLine("Para acceder a nuestro Sistema de gestion de turnos ingrese al siguiente enlace: " + hostActivationURL.Valor + registracion.linkActivacion.ToString() + " <br />");
            mensaje.AppendLine("El mismo caducará a en media hora. <br />");
            mensaje.AppendLine("Muchas Gracias. <br /><br />");
            mensaje.AppendLine("Saluda Atentamente: <br />");
            mensaje.AppendLine("STGO.<br />");
            return mensaje.ToString();
        }


        public void activarCuenta(Guid activationKey)
        {
            Registracion registracion = this.registracionDAO.getFindByActivationKey(activationKey);
            if (registracion != null)
            {
                if (registracion.Pendiente)
                {
                    DateTime fechaHoraActual = DateTime.Now;
                    TimeSpan timeSpan = new TimeSpan(0, 30, 0);
                    fechaHoraActual =  fechaHoraActual.Subtract(timeSpan);
                    if (registracion.FechaHoraRegistro <= fechaHoraActual)
                    {
                        logger.Info("Se intento activar una cuenta cuyo registro expiró. Clave de activación: "+activationKey.ToString());
                        throw new RegistracionExpiradaException();
                    }
                   
                    this.registracionDAO.activarCuenta(activationKey);
                    logger.Info("Se realizó la activación de cuenta. Clave de activación: " + activationKey.ToString());
                }
                else
                {
                    logger.Info("Se intento realizar una activación sobre una cuenta ya activa. No se realizan modificaciones. Clave de activación: "+activationKey.ToString());
                    throw new EMailRegistradoException();
                }
            }
        }
    }
}
