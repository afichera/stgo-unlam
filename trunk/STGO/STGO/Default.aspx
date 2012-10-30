<%@ Page Title="STGO - Bienvenidos" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="STGO._Default"
    Theme="STGO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="grid_12">
        <h1>
            Bienvenidos a STGO</h1>
        <br />
        <br />
        STGO (Sistema de Turnos Genérico Online) le facilitá a su compañías y-o pymes la
        administración de salas/servicios que funcionan bajo la modalidad de “turnos”, dando
        un seguimiento de disponibilidad de los mismos y además proveer una API para el
        consumo de esta información. Con STGO ud pordrá administrar sus propias salas, clientes
        y turnos.
        <br />
        Si su empresa aún no se registro, haga clic en "registrese". Al finalizar el registro
        se le enviará un mail para confirmar el mismo.
        <br />
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
            <asp:LinkButton ForeColor="DarkGray" ID="linkBtnRegistrese" PostBackUrl="~/Registro.aspx"
                runat="server">Registrarse</asp:LinkButton>
            <asp:LinkButton ForeColor="DarkGray" ID="linkBtnLogin" PostBackUrl="~/Login.aspx"
                runat="server">Ingresar</asp:LinkButton>
        </asp:Panel>
        <div class="clear">
        </div>
    </div>
    <%--    Todo lo que esta aca abajo es lo viejo Juan.

        <div class="grid_6">
        <h2>
            Ingrese al Sistema</h2>
        <br />
        <div class="grid_2 alpha divlabel">
            <asp:Label ID="lblUsuarioLogin" Text="Usuario: " runat="server" AssociatedControlID="txtUsuarioLogin" /></div>
        <div class="grid_2">
            <asp:TextBox ID="txtUsuarioLogin" runat="server" ValidationGroup="valGrupoLogin"></asp:TextBox></div>
        <div class="grid_2 omega">
            <asp:RequiredFieldValidator ID="rqfTxtUsuarioLogin" runat="server" ControlToValidate="txtUsuarioLogin"
                ErrorMessage="Debe ingresar el usuario/email" Display="Dynamic" ValidationGroup="valGrupoLogin"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revTxtUsuarioLogin" runat="server" ValidationExpression="^([a-zA-Z0-9]+[a-zA-Z0-9._%-]*@(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,4})$"
                ErrorMessage="El nombre de usuario debe tener formato de email." Display="Dynamic"
                ControlToValidate="txtUsuarioLogin" ValidationGroup="valGrupoLogin"></asp:RegularExpressionValidator></div>
        <div class="clear">
        </div>
        <div class="grid_2 alpha divlabel">
            <asp:Label ID="lblPasswordLogin" Text="Contraseña: " runat="server" AssociatedControlID="txtPasswordLogin" /></div>
        <div class="grid_2">
            <asp:TextBox ID="txtPasswordLogin" runat="server" TextMode="Password" ValidationGroup="valGrupoLogin"></asp:TextBox></div>
        <div class="grid_2 omega">
            <asp:RequiredFieldValidator ID="rqfTxtPasswordLogin" runat="server" ErrorMessage="Debe ingresar el password."
                ControlToValidate="txtPasswordLogin" Display="Dynamic" ValidationGroup="valGrupoLogin"></asp:RequiredFieldValidator></div>
        <div class="clear">
        </div>
        <div class="grid_2 alpha prefix_2">
            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CausesValidation="true"
                ValidationGroup="valGrupoLogin" /></div>
    </div>
    <div class="grid_6 ">
        <form id="frmRegistro" action="default.aspx" method="post">
        <h2>
            Registre su Empresa</h2>
    </div>
    <div class="grid_6  columnaDestacada">
        <div class="grid_2 alpha divlabel">
            <asp:Label ID="lblRazonSocialReg" Text="Razón Social: " runat="server" AssociatedControlID="txtRazonSocialReg" /></div>
        <div class="grid_2">
            <asp:TextBox ID="txtRazonSocialReg" runat="server" ValidationGroup="valGrupoReg"></asp:TextBox></div>
        <div class="grid_2 omega">
            <asp:RequiredFieldValidator ID="rqfRazonSocialReg" runat="server" ControlToValidate="txtRazonSocialReg"
                ErrorMessage="Debe completar la razón social." Display="Dynamic"></asp:RequiredFieldValidator></div>
        <div class="clear">
        </div>
        <div class="grid_2 alpha divlabel">
            <asp:Label ID="lblCuitReg" Text="Cuit: " runat="server" AssociatedControlID="txtCuitReg" /></div>
        <div class="grid_2">
            <asp:TextBox ID="txtCuitReg" runat="server" ValidationGroup="valGrupoReg"></asp:TextBox></div>
        <div class="grid_2 omega">
            <asp:RequiredFieldValidator ID="rqfCuitReg" runat="server" ControlToValidate="txtCuitReg"
                ValidationGroup="valGrupoReg" ErrorMessage="Debe completar el cuit." Display="Dynamic"></asp:RequiredFieldValidator></div>
        <div class="clear">
            <asp:RegularExpressionValidator ID="revCuitReg" ErrorMessage="El formato del Cuit es inválido."
                ControlToValidate="txtCuitReg" runat="server" ValidationExpression="\d{2}-\d{8}-\d"
                ValidationGroup="valGrupoReg" Display="Dynamic" /></div>
        <div class="grid_2 alpha divlabel">
            <asp:Label ID="lblTelefonoReg" Text="Teléfono: " runat="server" AssociatedControlID="txtTelefonoReg" /></div>
        <div class="grid_2">
            <asp:TextBox ID="txtTelefonoReg" runat="server" ValidationGroup="valGrupoReg"></asp:TextBox></div>
        <div class="grid_2 omega">
            <asp:RequiredFieldValidator ID="rqfTelefonoReg" runat="server" ControlToValidate="txtTelefonoReg"
                ErrorMessage="Debe completar el teléfono." Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revTelefonoReg" ErrorMessage="El formato del telefono es inválido."
                ControlToValidate="txtTelefonoReg" runat="server" ValidationGroup="valGrupoReg"
                Display="Dynamic" ValidationExpression="/^(\(?[0-9]{3,3}\)?|[0-9]{3,3}[-. ]?)[ ][0-9]{4,4}[-. ]?[0-9]{4,4}$/" /></div>
        <div class="clear">
        </div>
        <div class="grid_2 alpha divlabel">
            <asp:Label ID="lblUsuarioReg" Text="EMail: " runat="server" AssociatedControlID="txtUsuarioReg" /></div>
        <div class="grid_2">
            <asp:TextBox ID="txtUsuarioReg" runat="server" ValidationGroup="valGrupoReg" ToolTip="El Email lo identificará como futuro usuario en el sistema."></asp:TextBox></div>
        <div class="grid_2 omega">
            <asp:RequiredFieldValidator ID="rqfUsuarioReg" runat="server" ValidationGroup="valGrupoReg"
                ErrorMessage="Debe completar el email." Display="Dynamic" ControlToValidate="txtUsuarioReg"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revUsuarioReg" runat="server" ValidationExpression="^([a-zA-Z0-9]+[a-zA-Z0-9._%-]*@(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,4})$"
                ErrorMessage="El email ingresado es inválido." Display="Dynamic" ControlToValidate="txtUsuarioReg"
                ValidationGroup="valGrupoReg"></asp:RegularExpressionValidator></div>
        <div class="clear">
        </div>
        <div class="grid_2 alpha divlabel">
            <asp:Label ID="lblPasswordReg" Text="Contraseña: " runat="server" AssociatedControlID="txtPasswordReg" /></div>
        <div class="grid_2">
            <asp:TextBox ID="txtPasswordReg" runat="server" ValidationGroup="valGrupoReg"></asp:TextBox></div>
        <div class="grid_2 omega">
            <asp:RequiredFieldValidator ID="rqfPasswordReg" runat="server" ControlToValidate="txtPasswordReg"
                ErrorMessage="Debe ingresar una contraseña." ValidationGroup="valGrupoReg"></asp:RequiredFieldValidator></div>
        <div class="clear">
        </div>
        <div class="grid_2 alpha divlabel">
            <asp:Label ID="lblPasswordConfirmReg" Text="Repetir Contraseña: " runat="server"
                AssociatedControlID="txtPasswordConfirmReg" /></div>
        <div class="grid_2">
            <asp:TextBox ID="txtPasswordConfirmReg" runat="server" ValidationGroup="valGrupoReg"></asp:TextBox></div>
        <div class="grid_2 omega">
            <asp:RequiredFieldValidator ID="rqfPasswordConfirmReg" runat="server" ControlToValidate="txtPasswordConfirmReg"
                ErrorMessage="Debe confirmar la contraseña." ValidationGroup="valGrupoReg" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cmvPasswordConfirmReg" runat="server" ControlToValidate="txtPasswordConfirmReg"
                ControlToCompare="txtPasswordReg" Operator="Equal" ValidationGroup="valGrupoReg"
                ErrorMessage="Las contraseñas ingresadas deben ser iguales." Display="Dynamic"></asp:CompareValidator></div>
        <div class="clear">
        </div>
        <div class="grid_2 alpha prefix_2">
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CausesValidation="true"
                ValidationGroup="valGrupoReg" />
        </div>
    </div>
    --%>
</asp:Content>
