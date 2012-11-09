<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="STGO.Formulario_web3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <div class="grid_12">  
 <h1>Página no encontrada (404)</h1>
    <p>La página que busca no existe o no fue encontrada.</p>
    <br />
    <p><asp:HyperLink ID="linkCancelar" runat="server" class="boton" NavigateUrl="~/Default.aspx">Ir a la página principal</asp:HyperLink></p>
</div>
</asp:Content>
