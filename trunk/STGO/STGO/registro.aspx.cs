using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Security;
using Services.Service;
using Services.Util;
using Model.Exceptions;
using Model;
using System.Net.Mail;
using log4net;

namespace STGO
{
    public partial class _Registro : System.Web.UI.Page
    {
        private IRegistracionService registracionService = ServiceLocator.Instance.RegistracionService;
        private static ILog logger = log4net.LogManager.GetLogger(typeof(_Registro));
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void enviarMail()
        {
            try
            {
                String mensaje = this.registracionService.obtenerCuerpoMailActivacion(CreateUserWizard1.UserName);
                MailMessage mailMessage = new MailMessage();

                mailMessage.IsBodyHtml = true;
                mailMessage.Body = mensaje;
                mailMessage.Subject = "Bienvenido a STGO : Sistema de Turnos Genérico OnLine.";
                mailMessage.From = new MailAddress("alejandro.fichera@softdoit.com");
                mailMessage.To.Add(new MailAddress(CreateUserWizard1.UserName));
                SmtpClient client = new SmtpClient();
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                logger.Error("Ocurrió un error al enviar el mail de activación. Detalle: " + ex.Message);
                throw ex;
            }

        }

        protected void CreateUserWizard1_CreatingUser(object sender, LoginCancelEventArgs e)
        {

            TextBox txtUserName = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserName");

            try
            {
                this.registracionService.newAccountValidate(txtUserName.Text);
            }
            catch (EMailRegistradoException ex)
            {
                Literal literal = (Literal)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ErrorMessage");
                literal.Text = "El Email ingresado para el registro ya existe. Por favor ingrese otro.";
                logger.Info("El Email ingresado para el registro ya existe. Detalle: " + ex.Message);
            }
            catch (BusinessException ex)
            {
                Literal literal = (Literal)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ErrorMessage");
                logger.Info("No se pudo registrar la cuenta. Detalle: " + ex.Message);
                literal.Text = "No se pudo registrar la cuenta. Detalle: "+ex.Message;
            }

        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
                TextBox txtUserName = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserName");
                TextBox txtPassword = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Password");
                TextBox txtTelefono = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("txtTelefonoReg");
                TextBox txtCUIT = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("txtCuitReg");
                TextBox txtRazonSocial = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("txtRazonSocialReg");
                MembershipUser user = Membership.GetUser(txtUserName.Text);
                try
                {

                    Roles.AddUserToRole(user.UserName, "EMPRESA");
                    CreateUserWizard1.LoginCreatedUser = false;
                    Registracion registracion = new Registracion();
                    registracion.Telefono = txtTelefono.Text;
                    registracion.Cuit = txtCUIT.Text;
                    registracion.RazonSocial = txtRazonSocial.Text;
                    this.registracionService.completarRegistro(registracion, (Guid)user.ProviderUserKey);
                    this.enviarMail();
                }
                catch (BusinessException ex) {
                    Literal literal = (Literal)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ErrorMessage");
                    logger.Error("Ocurrio un error al completar el registro."+ex.Message);
                    literal.Text = "Ocurrio un error al completar el registro. " + ex.Message;
                }
        }

    }
}