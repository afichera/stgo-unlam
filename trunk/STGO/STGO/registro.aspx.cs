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
           Membership.DeleteUser("alejandrofichera@gmail.com");
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
            client.Send(mailMessage);
        }


        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            TextBox txtUserName =  (TextBox) CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserName");
            TextBox txtPassword =  (TextBox) CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Password");
            TextBox txtTelefono = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("txtTelefonoReg");
            TextBox txtCUIT = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("txtCuitReg");
            TextBox txtRazonSocial =  (TextBox) CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("txtRazonSocialReg");
            MembershipCreateStatus createStatus;
            
            MembershipUser newUser = Membership.CreateUser(txtUserName.Text, txtPassword.Text, txtUserName.Text, "", "", false, out createStatus);
            switch (createStatus)
            {
                case MembershipCreateStatus.Success:
                   // CreateUserWizard1. CreateAccountResults.Text = "La cuenta se creo exitosamente. Para activar su cuenta verifique su E-mail.";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    //CreateAccountResults.Text = "El E-Mail ingresado ya existe.";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
//                    CreateAccountResults.Text = "El E-Mail ingresado ya existe.";
                    break;
                case MembershipCreateStatus.InvalidEmail:
  //                  CreateAccountResults.Text = "El E-Mail provisto es Inválido.";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
    //                CreateAccountResults.Text = "There security answer was invalid.";
                    break;
                case MembershipCreateStatus.InvalidPassword:
      //              CreateAccountResults.Text = "EL Password Provisto es Inválido. Debe contener al menos 7 carateres.";

                    break;
                default:
                    //CreateAccountResults.Text = "Ocurrio un error. El usuario no se ha creado";
                    break;
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

            Registracion registracion = new Registracion();
            registracion.Telefono = txtTelefono.Text;
            registracion.Cuit = txtCUIT.Text;
            registracion.RazonSocial = txtRazonSocial.Text;
            

            this.registracionService.completarRegistro(registracion, (Guid)user.ProviderUserKey);            
            
            if (user.IsOnline) {
                user.IsApproved = false;
                Membership.UpdateUser(user);
            }
            this.enviarMail();
        }

    }
}