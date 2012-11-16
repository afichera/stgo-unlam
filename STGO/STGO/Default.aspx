<%@ Page Title="STGO - Bienvenidos" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="STGO._Default"
    Theme="STGO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="grid_12">
        <h1>
            Bienvenidos a STGO</h1>
    </div>
    <div class="grid_6">
        <p>
            STGO (Sistema de Turnos Genérico Online) le facilitá a su compañías y-o pymes la
            administración de salas/servicios que funcionan bajo la modalidad de “turnos”, dando
            un seguimiento de disponibilidad de los mismos y además proveer una API para el
            consumo de esta información. Con STGO ud pordrá administrar sus propias salas, clientes
            y turnos.</p>
        <p>
            Si su empresa aún no se registro, haga clic en "registrese". Al finalizar el registro
            se le enviará un mail para confirmar el mismo.</p>
    </div>
    <div class="grid_6">
    <h2>Si ya posee una cuenta ingrese desde el botón ingresar.<br />Si aún no está registrado ¡hágalo ahora mismo!</h2>
    <br /></div>

    <div class="grid_2 prefix_1">
        <asp:LinkButton  ID="linkBtnLogin" PostBackUrl="~/Login.aspx"
            runat="server" class="boton">Ingresar</asp:LinkButton>
    </div>
    <div class="grid_2">
        <asp:LinkButton  ID="linkBtnRegistrese" PostBackUrl="~/Registro.aspx"
            runat="server" class="boton">Registrarse</asp:LinkButton>
        <br />
    </div>
    <div class="clear">
    </div>
</asp:Content>
