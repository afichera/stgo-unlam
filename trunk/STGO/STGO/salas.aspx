<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaConMenu.master" AutoEventWireup="true"
    CodeBehind="salas.aspx.cs" Inherits="STGO.salas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPagConMenu" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPaginaConMenu" runat="server">
    <div class="grid_12">
        <h1>
            Salas</h1>
        <asp:Label ID="lblListaEmpresas" runat="server" AssociatedControlID="liEmpresas">Seleccione una empresa: </asp:Label>
        <asp:DropDownList ID="liEmpresas" runat="server">
        </asp:DropDownList>
        (sólo para superusuario)<br />
    
    </div>

<div class="grid_12 tabla-titulo">
<div class="grid_3 alpha">Nombre</div>
<div class="grid_1">F. Turno</div>
<div class="grid_1">Múltiplos</div>
<div class="grid_1">Inicio</div>
<div class="grid_1">Cierre</div>
<div class="grid_1 omega"></div>
</div>

<div class="clear"></div>
<div class="grid_12 tabla-item">
<div class="grid_3 alpha">Kinesiología</div>
<div class="grid_1">15 min.</div>
<div class="grid_1">Si</div>
<div class="grid_1">8:00</div>
<div class="grid_1">21:00</div>
<div class="grid_1 omega"><a href="" class="fancy">Editar</a></div>
</div>
<div class="clear"></div>
<div class="grid_12 tabla-item">
<div class="grid_3 alpha">Kinesiología</div>
<div class="grid_1">15 min.</div>
<div class="grid_1">Si</div>
<div class="grid_1">8:00</div>
<div class="grid_1">21:00</div>
<div class="grid_1 omega"><a href="" class="fancy">Editar</a></div>
</div>
<div class="clear"></div>
<div class="grid_12 tabla-item">
<div class="grid_3 alpha">Kinesiología</div>
<div class="grid_1">15 min.</div>
<div class="grid_1">Si</div>
<div class="grid_1">8:00</div>
<div class="grid_1">21:00</div>
<div class="grid_1 omega"><a href="" class="fancy">Editar</a></div>
</div>
<div class="clear"></div>
<div class="grid_12 tabla-item">
<div class="grid_3 alpha">Kinesiología</div>
<div class="grid_1">15 min.</div>
<div class="grid_1">Si</div>
<div class="grid_1">8:00</div>
<div class="grid_1">21:00</div>
<div class="grid_1 omega"><a href="" class="fancy">Editar</a></div>
</div>
<div class="clear"></div>



</asp:Content>
