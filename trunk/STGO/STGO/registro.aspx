<%@ Page Title="STGO -Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Registro.aspx.cs" Inherits="STGO._Registro" Theme="STGO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="grid_6">
  
    <asp:CreateUserWizard RequireEmail="true" ID="CreateUserWizard1" CreateUserButtonText="Registrarse"
        runat="server" OnCreatedUser="CreateUserWizard1_CreatedUser" ContinueButtonStyle-CssClass="boton" Create CreateUserButtonStyle-CssClass="boton" OnCreatingUser="CreateUserWizard1_CreatingUser">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <div class="grid_5 ">
                                <td align="center" colspan="2">
                                    <h2>
                                        Registre su Empresa</h2>
                                </td>
                            </div>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">E-mail: </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" Display="Dynamic"
                                    ControlToValidate="UserName" ErrorMessage="El E-mail es requerido." ToolTip="El email es requerido."
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revUserName" runat="server" ValidationExpression="^([a-zA-Z0-9]+[a-zA-Z0-9._%-]*@(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,4})$"
                                    ErrorMessage="El E-mail ingresado es inválido." Display="Dynamic" ControlToValidate="UserName"
                                    ValidationGroup="CreateUserWizard1"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">Confirmar E-mail: </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" Display="Dynamic" runat="server" ControlToValidate="Email"
                                    ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmailValidator" runat="server" ValidationExpression="^([a-zA-Z0-9]+[a-zA-Z0-9._%-]*@(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,4})$"
                                    ErrorMessage="La Confirmación de E-mail ingresada es inválida." Display="Dynamic"
                                    ControlToValidate="UserName" ValidationGroup="CreateUserWizard1"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="Email"
                                    ControlToValidate="UserName" Display="Dynamic" ErrorMessage="El E-email y la confirmación de E-mail deben coincidir."
                                    ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña: </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="La contraseña es requerida." ToolTip="La contraseña es requerida."
                                    ValidationGroup="CreateUserWizard1" Display="Dynamic">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirmar Contraseña: </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                    ErrorMessage="La confirmación de contraeña es requerida." ToolTip="La confirmación de contraeña es requerida."
                                    ValidationGroup="CreateUserWizard1" Display="Dynamic">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblRazonSocialReg" Text="Razón Social: " runat="server" AssociatedControlID="txtRazonSocialReg" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtRazonSocialReg" runat="server" ValidationGroup="CreateUserWizard1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqfRazonSocialReg" runat="server" ControlToValidate="txtRazonSocialReg"
                                    ErrorMessage="Debe completar la Razón Social." Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCuitReg" Text="Cuit: " runat="server" AssociatedControlID="txtCuitReg" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtCuitReg" runat="server" ValidationGroup="CreateUserWizard1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqfCuitReg" runat="server" ControlToValidate="txtCuitReg"
                                    ValidationGroup="CreateUserWizard1" ErrorMessage="Debe completar el cuit." Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revCuitReg" ErrorMessage="El formato del Cuit es inválido."
                                    ToolTip="Ingrese el CUIT. Ej: 99-99999999-9." ControlToValidate="txtCuitReg"
                                    runat="server" ValidationExpression="\d{2}-\d{8}-\d" ValidationGroup="CreateUserWizard1"
                                    Display="Dynamic" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTelefonoReg" Text="Teléfono: " runat="server" AssociatedControlID="txtTelefonoReg" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtTelefonoReg" runat="server" ValidationGroup="CreateUserWizard1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqfTelefonoReg" runat="server" ControlToValidate="txtTelefonoReg"
                                    ErrorMessage="Debe completar el teléfono." ValidationGroup="CreateUserWizard1"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                <%--                                <asp:RegularExpressionValidator ID="revTelefonoReg" ErrorMessage="El formato del telefono es inválido."
                                    ControlToValidate="txtTelefonoReg" runat="server" ValidationGroup="CreateUserWizard1"
                                    Display="Dynamic" ValidationExpression="/^(\(?[0-9]{3,3}\)?|[0-9]{3,3}[-. ]?)[ ][0-9]{4,4}[-. ]?[0-9]{4,4}$/" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                    ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="La contraseña y la confirmación de contraseña deben coincidir."
                                    ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color: Red;">
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td colspan="2">
                            <h1>Registro Completado.</h1>
                            </td>
                        </tr>
                        <tr> 
                            <td>
                                Su cuenta fue creada. A la brevedad se enviará un mail para su activación.
                                Para activarla verifique su casilla de E-Mail.
                                Muchas Gracias.
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                <asp:Button ID="ContinueButton" PostBackUrl="~/Default.aspx" runat="server" CausesValidation="False" CommandName="Continue"
                                    Text="Continuar" CssClass="boton" ValidationGroup="CreateUserWizard1" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>

</div>
</asp:Content>
