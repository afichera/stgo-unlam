<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaConMenu.master" Theme="STGO" AutoEventWireup="true" CodeBehind="cantidadDeSalas.aspx.cs" Inherits="STGO.cantidadDeSalas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPagConMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPaginaConMenu" runat="server">
<div class="grid_12"><h1>Cambiar cantidad máxima de salas</h1>
</div>
<div class="grid_3 divlabel"><asp:Label ID="lblRazonSocial" runat="server" AssociatedControlID="txtRazonSocial">Empresa: </asp:Label></div>
<div class="grid_2"><asp:TextBox ID="txtRazonSocial" runat="server" Enabled="false"></asp:TextBox></div>
<div class="clear"></div>
<div class="grid_3 divlabel"><asp:Label ID="lblCantidadSalas" runat="server" AssociatedControlID="txtCantSalas">Cantidad máxima de salas: </asp:Label></div>
<div class="grid_2"><asp:TextBox ID="txtCantSalas" runat="server"></asp:TextBox></div>

<div class="grid_3"><asp:RequiredFieldValidator Display="Dynamic" ID="rfvCantSalas" runat="server" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtCantSalas"></asp:RequiredFieldValidator></div>
    <asp:RegularExpressionValidator display="Dynamic" ID="regCantSalas" runat="server" ErrorMessage="Coloque sólo números" ControlToValidate="txtCantSalas" ValidationExpression="-?[0-9]+"></asp:RegularExpressionValidator>
    <div class="clear"></div>


<div class="clear"></div>
 <div class="grid_4 prefix_1 divlabel">
<asp:Button ID="btnGuardar" class="boton" runat="server" Text="Guardar" 
CausesValidation="true" onclick="btnGuardar_Click"  />
<asp:HyperLink ID="linkCancelar" runat="server" class="boton" NavigateUrl="~/empresas.aspx">Cancelar</asp:HyperLink> 
 </div>     
<div class="clear"></div>
<div class="grid_3 prefix_2 ok">
<asp:Label ID="lblResultado"  runat="server" Text=""></asp:Label>
</div>
</asp:Content>