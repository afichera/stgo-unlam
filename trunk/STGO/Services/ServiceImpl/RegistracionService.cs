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


namespace Services.ServiceImpl
{
    public class RegistracionService : IRegistracionService
    {
        private IRegistracionDAO registracionDAO = DAOLocator.Instance.RegistracionDAO;
        private IParametroDAO parametroDAO = DAOLocator.Instance.ParametroDAO;

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
                        //TODO: Duda, Eliminamos el registro, lo marcamos como historico o bien impedimos que se vuelva a registrar???
                        //Loggear que se va a hacer pelota el registro caducado y hacer pelota el registro caducado y demas.

                        //throw new RegistracionExpiradaException("Expiro el tiempo para activar la cuenta. Se deberán eliminar registros para permitir la reutilización.");
                    }
                    else {
                        throw new EMailRegistradoException();
                    }                    
                }
                else {
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
                        //Loggear que se va a hacer pelota el registro caducado y hacer pelota el registro caducado y demas.
                        throw new RegistracionExpiradaException();
                    }
                    else
                    {
                        this.registracionDAO.activarCuenta(activationKey);
                    }
                }
                else
                {
                    throw new EMailRegistradoException();
                }
            }
        }
    }
}
