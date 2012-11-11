<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="activarCuenta.aspx.cs" Inherits="STGO.activarCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <div class="grid_6"> 
 <h1>Activación de cuenta</h1>
        <p><asp:Label ID="lblResultado" runat="server" Text=""></asp:Label></p>
        <br /><asp:Button ID="btnVolver"  PostBackUrl="~/Default.aspx"
            runat="server" Text="Continuar" CssClass="boton" />

</div>
</asp:Content>
