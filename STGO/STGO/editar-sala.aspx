﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaConMenu.Master" AutoEventWireup="true" CodeBehind="editar-sala.aspx.cs" Inherits="STGO.Formulario_web3" Theme="STGO"%>
<%@ PreviousPageType VirtualPath="~/salas.aspx"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPagConMenu" runat="server">
<script type="text/javascript" src="/Scripts/validarLargos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPaginaConMenu" runat="server">

<div class="grid_2 divlabel">
<asp:Label ID="lblId" Text="Id: " runat="server" AssociatedControlID="txtId" Visible="false" /></div>
<div class="grid_2"><asp:TextBox ID="txtId" runat="server"  Visible="false"></asp:TextBox></div>
<div class="clear"></div>

<div class="grid_2 divlabel">
<asp:Label ID="lblNombre" Text="Nombre: " runat="server" AssociatedControlID="txtNombre" /></div>
<div class="grid_2"><asp:TextBox ID="txtNombre" runat="server" ></asp:TextBox></div>
<div class="grid_3">
    <asp:RequiredFieldValidator  Display="Dynamic" ID="rfvNombre" runat="server" ErrorMessage="Este nombre es obligatorio" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
    <asp:CustomValidator ID="customNombre" runat="server" Display="Dynamic" ControlToValidate="txtNombre" ErrorMessage="El nombre no puede tener más de 100 caracteres" ClientValidationFunction="validaLargo100"></asp:CustomValidator>
    </div>

<div class="clear"></div>

<div class="grid_2 divlabel">
<asp:Label ID="lblPermiteMultiplos" Text="Permite Múltiplos: " runat="server" AssociatedControlID="ddlPermiteMultiplos"></asp:Label></div>
<div class="grid_2"><asp:DropDownList ID="ddlPermiteMultiplos" runat="server" >
<asp:ListItem Value="true" Text="Si" />
<asp:ListItem Value="false" Text="No" />
</asp:DropDownList></div>
<div class="grid_2"></div>
<div class="clear"></div>

<div class="grid_2 divlabel">
<asp:Label ID="lblFrecuencia" Text="Frecuencia (en mins.): " runat="server" AssociatedControlID="txtFrecuencia" /></div>
<div class="grid_2"><asp:TextBox ID="txtFrecuencia" runat="server" ></asp:TextBox></div>
<div class="grid_3"><asp:RequiredFieldValidator Display="Dynamic" ID="rfvFrecuencia" runat="server" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtFrecuencia"></asp:RequiredFieldValidator></div>
    <asp:RegularExpressionValidator display="Dynamic" ID="regFrecuencia" runat="server" ErrorMessage="Coloque sólo números" ControlToValidate="txtFrecuencia" ValidationExpression="-?[0-9]+"></asp:RegularExpressionValidator>
    <div class="clear"></div>

<div class="grid_2 divlabel">
<asp:Label ID="lblHoraInicio" Text="Hora Inicio (HH:mm:ss): " runat="server" AssociatedControlID="txtHoraInicio" /></div>
<div class="grid_2"><asp:TextBox ID="txtHoraInicio" runat="server" ></asp:TextBox></div>
<div class="grid_3"><asp:RequiredFieldValidator ID="rfvHoraInicio" Display="Dynamic" runat="server" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtHoraInicio"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="regHoraInicio" runat="server" ErrorMessage="La hora debe tener formato HH:mm:ss" ControlToValidate="txtHoraInicio"
     ValidationExpression="^(0[1-9]|1\d|2[0-3]):([0-5]\d):([0-5]\d)$" Display="Dynamic"></asp:RegularExpressionValidator></div>
<div class="clear"></div>

<div class="grid_2 divlabel">
<asp:Label ID="lblHoraFin" Text="Hora Fin (HH:mm:ss): " runat="server" AssociatedControlID="txtHoraFin" /></div>
<div class="grid_2"><asp:TextBox ID="txtHoraFin" runat="server" ></asp:TextBox></div>
<div class="grid_3"><asp:RequiredFieldValidator Display="Dynamic" ID="rfvHoraFin" runat="server" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtHoraFin"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="regHoraFin" runat="server" ErrorMessage="La hora debe tener formato HH:mm:ss" ControlToValidate="txtHoraFin"
     ValidationExpression="^(0[1-9]|1\d|2[0-3]):([0-5]\d):([0-5]\d)$" Display="Dynamic"></asp:RegularExpressionValidator>

</div>
<div class="clear"></div>
 <div class="grid_4 prefix_1 divlabel">
     <asp:Button ID="btnGuardar" class="boton" runat="server" Text="Guardar" 
         CausesValidation="true" onclick="btnGuardar_Click"  />
     <asp:HyperLink ID="linkCancelar" runat="server" class="boton" NavigateUrl="~/salas.aspx">Cancelar</asp:HyperLink> 
 </div>     
<div class="clear"></div>
<div class="grid_3 prefix_2 ok">
<asp:Label ID="lblResultado"  runat="server" Text=""></asp:Label>
</div>
</asp:Content>
