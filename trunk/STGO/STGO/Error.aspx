﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="STGO.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <div class="grid_12">  
 <h1>ERROR</h1>
    <p>Ocurrio Un Error.</p>
    <br />
    <p>Por favor contactese con el administrador del sitio.</p>
    <p><asp:HyperLink ID="linkCancelar" runat="server" class="boton" NavigateUrl="~/Default.aspx">Ir a la página principal</asp:HyperLink></p>
</div>
</asp:Content>
