<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaConMenu.master" AutoEventWireup="true" CodeBehind="empresas.aspx.cs" Inherits="STGO.empresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPagConMenu" runat="server">
<script type="text/javascript" src="Scripts/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="Scripts/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="Scripts/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script type="text/javascript" src="Scripts/fancybox/launch.fancybox.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPaginaConMenu" runat="server">
<div class="grid_12"><h1>Empresas</h1>
</div>

<div class="grid_12 tabla-titulo">
<div class="grid_2 alpha">CUIT</div>
<div class="grid_3">Razón Social</div>
<div class="grid_2">Teléfono</div>
<div class="grid_2">Email</div>
<div class="grid_1">Salas</div>
<div class="grid_1 omega">Activa/Inactiva</div>
</div>
<div class="clear"></div>
<div class="grid_12 tabla-item">
<div class="grid_2 alpha">30-12345678</div>
<div class="grid_3">Clínica de Ejemplo S.A.</div>
<div class="grid_2">49876-7896</div>
<div class="grid_2">clinica@ejemplo.com</div>
<div class="grid_1"><a href="cantidadDeSalas.aspx" class="fancy">5</a> </div>
<div class="grid_1 omega"><a href="activar-desactivar-salas.aspx" class="fancy">Activa</a></div>
</div>
<div class="clear"></div>
<div class="grid_12 tabla-item">
<div class="grid_2 alpha">30-12345678</div>
<div class="grid_3">Clínica de Ejemplo S.A.</div>
<div class="grid_2">49876-7896</div>
<div class="grid_2">clinica@ejemplo.com</div>
<div class="grid_1"><a href="cantidadDeSalas.aspx" class="fancy">5</a> </div>
<div class="grid_1 omega"><a href="activar-desactivar-salas.aspx" class="fancy">Activa</a></div>
</div>
<div class="clear"></div>
<div class="grid_12 tabla-item">
<div class="grid_2 alpha">30-12345678</div>
<div class="grid_3">Clínica de Ejemplo S.A.</div>
<div class="grid_2">49876-7896</div>
<div class="grid_2">clinica@ejemplo.com</div>
<div class="grid_1"><a href="cantidadDeSalas.aspx" class="fancy">5</a> </div>
<div class="grid_1 omega"><a href="activar-desactivar-salas.aspx" class="fancy">Activa</a></div>
</div>
<div class="clear"></div>
<div class="grid_12 tabla-item">
<div class="grid_2 alpha">30-12345678</div>
<div class="grid_3">Clínica de Ejemplo S.A.</div>
<div class="grid_2">49876-7896</div>
<div class="grid_2">clinica@ejemplo.com</div>
<div class="grid_1"><a href="cantidadDeSalas.aspx" class="fancy">5</a> </div>
<div class="grid_1 omega"><a href="activar-desactivar-salas.aspx" class="fancy">Activa</a></div>
</div>
<div class="clear"></div>



</asp:Content>
