<%@ Page Title="Ingreso al Sistema" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="STGO.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="grid_4 prefix_4">
        <asp:Login ID="loginSTGOId" runat="server" OnAuthenticate="loginSTGOId_Authenticate"
            OnLoginError="loginSTGOId_LoginError">
            <LayoutTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0">
                                <div class="grid_6 ">
                                    <tr>
                                        <td  colspan="2">
                                            <h1>Ingrese al Sistema</h1>
                                        </td>
                                    </tr>
                                </div>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" MaxLength="256" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            ErrorMessage="Debe ingresar el usuario." ToolTip="El nombre de usuario es requerido."
                                            ValidationGroup="loginSTGOId">*</asp:RequiredFieldValidator>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            ErrorMessage="Debe Ingresar la Contraseña." ToolTip="La Contraseña es requerida."
                                            ValidationGroup="loginSTGOId">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color: Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td><td>
                                        <asp:Button ID="LoginButton" class="boton" runat="server" CommandName="Login" Text="Ingresar" ValidationGroup="loginSTGOId" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>
    </div>
</asp:Content>
