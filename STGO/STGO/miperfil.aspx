<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="miperfil.aspx.cs" Inherits="STGO.miperfil" Theme="STGO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript" src="/Scripts/validarLargos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="grid_7">
        <h1>
            Mis datos</h1>
        <p>
            Modificar los datos de su Empresa.</p>
        <br />
        <div class="grid_2 divlabel alpha">
            <asp:Label ID="lblMail" Text="E-mail (usuario): " runat="server" AssociatedControlID="txtMail" /></div>
        <div class="grid_2">
            <asp:TextBox ID="txtMail" runat="server" Enabled="false"></asp:TextBox></div>
        <div class="clear">
        </div>
        <div class="grid_2 divlabel alpha">
            <asp:Label ID="lblRazonSocial" Text="Razón Social: " runat="server" AssociatedControlID="txtRazonSocial" /></div>
        <div class="grid_2">
            <asp:TextBox ID="txtRazonSocial" runat="server" ValidationGroup="valGrupoEdicion"></asp:TextBox></div>
        <div class="grid_3 omega">
            <asp:RequiredFieldValidator ID="rqfRazonSocial" runat="server" ControlToValidate="txtRazonSocial"
                ErrorMessage="Debe completar la razón social." Display="Dynamic" ValidationGroup="valGrupoEdicion"></asp:RequiredFieldValidator>
                
                <asp:CustomValidator ID="customRazonSocial" runat="server"  ValidationGroup="valGrupoEdicion" Display="Dynamic" ControlToValidate="txtRazonSocial" ErrorMessage="El nombre no puede tener más de 100 caracteres" ClientValidationFunction="validaLargo100"></asp:CustomValidator>
                </div>
        <div class="clear">
        </div>
        <div class="grid_2 divlabel alpha">
            <asp:Label ID="lblCuit" Text="Cuit: " runat="server" AssociatedControlID="txtCuit" /></div>
        <div class="grid_2">
            <asp:TextBox ID="txtCuit" runat="server" ValidationGroup="valGrupoEdicion"></asp:TextBox></div>
        <div class="grid_3 omega">
            <asp:RequiredFieldValidator ID="rqfCuit" runat="server" ControlToValidate="txtCuit"
                ErrorMessage="Debe completar el cuit." Display="Dynamic" ValidationGroup="valGrupoEdicion"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="revCuitReg" ErrorMessage="El formato del Cuit es inválido."
                                    ToolTip="Ingrese el CUIT. Ej: 99-99999999-9." ControlToValidate="txtCuit"
                                    runat="server" ValidationExpression="\d{2}-\d{8}-\d" ValidationGroup="valGrupoEdicion"
                                    Display="Dynamic" /></div>
        <div class="clear">
        </div>
        <div class="grid_2 divlabel alpha">
            <asp:Label ID="lblTelefono" Text="Teléfono: " runat="server" AssociatedControlID="txtTelefono" /></div>
        <div class="grid_2">
            <asp:TextBox ID="txtTelefono" runat="server" ValidationGroup="valGrupoEdicion"></asp:TextBox>
            <asp:CustomValidator ID="CustomTelefono" runat="server"  ValidationGroup="valGrupoEdicion" Display="Dynamic" ControlToValidate="txtTelefono" ErrorMessage="El teléfono no puede tener más de 20 caracteres" ClientValidationFunction="validaLargo20"></asp:CustomValidator>
            
            </div>
        <div class="grid_3 omega">
            <asp:RequiredFieldValidator ID="rqfTelefono" runat="server" ControlToValidate="txtTelefono"
                ErrorMessage="Debe completar el teléfono." ValidationGroup="valGrupoEdicion"
                Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        <div class="clear">
        </div>
        <div class="grid_2 alpha guardar_perfil">
            <asp:Button ID="btnGuardarPerfil" runat="server" Text="Guardar" CausesValidation="true"
                ValidationGroup="valGrupoEdicion" onclick="btnGuardarPerfil_Click" /></div>
        <div class="grid_2 omega guardar_perfil">
            <asp:Button ID="btnCancelarEditarPerfil" runat="server" Text="Cancelar" CausesValidation="false" /></div>
    
    <div class="clear"></div>
<div class="grid_3 prefix_2 ok">
<asp:Label ID="lblResultado"  runat="server" Text=""></asp:Label>
</div>
    
    </div>



    <div class="grid_5">
        <h1>
            Cambiar Contraseña</h1>
        <asp:ChangePassword ID="ChangePassword1" runat="server">
            <ChangePasswordTemplate>
                <div class="grid_2 alpha">
                    <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Contraseña:</asp:Label></div>
                <div class="grid_3 omega">
                    <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" ValidationGroup="ChangePassword1"></asp:TextBox></div>
                <div class="clear">
                </div>
                <div class="grid_3 omega prefix_2">
                    <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                        ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria."
                        Display="None" ValidationGroup="ChangePassword1"></asp:RequiredFieldValidator></div>
                <div class="clear">
                </div>
                <div class="grid_2 alpha">
                    <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">Nueva contraseña:</asp:Label></div>
                <div class="grid_3 omega">
                    <asp:TextBox ID="NewPassword" runat="server" ValidationGroup="ChangePassword1" TextMode="Password"></asp:TextBox></div>
                <div class="clear">
                </div>
                <div class="grid_3 omega prefix_2">
                    <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                        ErrorMessage="La nueva contraseña es obligatoria." Display="None" ToolTip="La nueva contraseña es obligatoria."
                        ValidationGroup="ChangePassword1"></asp:RequiredFieldValidator></div>
                <div class="clear">
                </div>
                <div class="grid_2 alpha">
                    <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirmar la nueva contraseña:</asp:Label></div>
                <div class="grid_3 omega">
                    <asp:TextBox ID="ConfirmNewPassword" ValidationGroup="ChangePassword1" runat="server" TextMode="Password"></asp:TextBox></div>
                <div class="clear">
                </div>
                <div class="grid_3 omega prefix_2">
                    <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                        Display="None" ErrorMessage="Confirmar la nueva contraseña es obligatorio." ToolTip="Confirmar la nueva contraseña es obligatorio."
                        ValidationGroup="ChangePassword1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                        ControlToValidate="ConfirmNewPassword" Display="None" ErrorMessage="Confirmar la nueva contraseña debe coincidir con la entrada Nueva contraseña."
                        ValidationGroup="ChangePassword1"></asp:CompareValidator>
                </div>
                <div class="clear">
                </div>
                <div class="grid_4 alpha validaciones">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ChangePassword1" />
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></div>
                <div class="clear">
                </div>
                <div class="grid_3 alpha">
                    <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                        Text="Cambiar contraseña" ValidationGroup="ChangePassword1" CausesValidation="true" /></div>
                <div class="grid_2 omega">
                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="Cancelar" /></div>
            </ChangePasswordTemplate>
            <SuccessTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0">
                                <tr>
                                    <td align="center" colspan="2">
                                        Cambio de contraseña completado
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Se ha cambiado su contraseña
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </SuccessTemplate>
        </asp:ChangePassword>
    </div>
</asp:Content>
