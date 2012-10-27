<%@ Page Title="" Language="C#" MasterPageFile="~/popup.Master"  Theme="STGO" AutoEventWireup="true" CodeBehind="activar-desactivar-salas.aspx.cs" Inherits="STGO.Formulario_web2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblActInac" AssociatedControlID="DropDownList1">Estado: </asp:label>
    <asp:DropDownList ID="DropDownList1" runat="server">
    <asp:ListItem>Activa</asp:ListItem>
    <asp:ListItem>Inactiva</asp:ListItem>
    </asp:DropDownList>
    <br /><br /><br />
    <asp:Button ID="Button1" runat="server" Text="Aceptar" />
    <asp:Button ID="Button2" runat="server" Text="Cancelar" />
</asp:Content>
