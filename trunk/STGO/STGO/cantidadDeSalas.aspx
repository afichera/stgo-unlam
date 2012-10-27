<%@ Page Title="" Language="C#" MasterPageFile="~/popup.Master" Theme="STGO" AutoEventWireup="true" CodeBehind="cantidadDeSalas.aspx.cs" Inherits="STGO.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Label ID="lblCantidadSalas" runat="server" AssociatedControlID="CantSalas">Cantidad máxima de salas: </asp:Label>
    <asp:TextBox ID="CantSalas" runat="server"></asp:TextBox><br /><br /><br />
    <asp:Button ID="Button1" runat="server" Text="Aceptar" />
    <asp:Button ID="Button2" runat="server" Text="Cancelar" />
</asp:Content>