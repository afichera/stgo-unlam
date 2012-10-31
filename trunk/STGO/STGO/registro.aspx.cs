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

namespace STGO
{
    public partial class _Registro : System.Web.UI.Page
    {
        private IRegistracionService registracionService = ServiceLocator.Instance.RegistracionService;

        protected void Page_Load(object sender, EventArgs e)
        {
           //Membership.DeleteUser("alejandrofichera@gmail.com");
        }

        private void enviarMail()
        {
            String mensaje = this.registracionService.obtenerCuerpoMailActivacion(CreateUserWizard1.UserName);
            MailMessage mailMessage = new MailMessage();
            //Modificamos el cuerpo y el asunto
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = mensaje;
            mailMessage.Subject = "Bienvenido a STGO : Sistema de Turnos Genérico OnLine.";
            mailMessage.From = new MailAddress("alejandro.fichera@softdoit.com");
            mailMessage.To.Add(new MailAddress(CreateUserWizard1.UserName));
            //Send the message
            SmtpClient client = new SmtpClient();
            try
            {
                client.Send(mailMessage);
            }
            catch (Exception ex) {
                Console.WriteLine("Error al Enviar Mail.");
            }
            
        }

        protected void CreateUserWizard1_CreatingUser(object sender, LoginCancelEventArgs e)
        {
            //Aca Todas las validaciones de si existe el usuario previamente. Si esta en Registro Pendiente, etc.            
            TextBox txtUserName = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserName");
            
            try
            {
                this.registracionService.newAccountValidate(txtUserName.Text);
            }
            catch (EMailRegistradoException ex)
            {
                //TODO: Hacer Algo
            }
            catch (BusinessException ex) { 
                //TODO HAcer algo con el error.
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
            Roles.AddUserToRole(user.UserName, "EMPRESA");
            CreateUserWizard1.LoginCreatedUser = false;
            Registracion registracion = new Registracion();
            registracion.Telefono = txtTelefono.Text;
            registracion.Cuit = txtCUIT.Text;
            registracion.RazonSocial = txtRazonSocial.Text;
            this.registracionService.completarRegistro(registracion, (Guid)user.ProviderUserKey);            
            this.enviarMail();
        }

    }
}