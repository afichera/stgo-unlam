<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaConMenu.master" AutoEventWireup="true"
    CodeBehind="turnos.aspx.cs" Inherits="STGO.turnos" Theme="wdCalendar" %>
    

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPagConMenu" runat="server">
  
   
    <title>STGO-Turnos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPaginaConMenu" runat="server">
    <div class="grid_12">
        <h1>Turnos</h1>
        </div>
<div class="grid_6"> 
    <div class="grid_3 alpha">
        <asp:Label ID="lblListaEmpresas" runat="server" AssociatedControlID="liEmpresas">Seleccione una Empresa: </asp:Label>
</div>
<div class="grid_3 omega">
<asp:DropDownList ID="liEmpresas" runat="server" DataValueField="Id" DataTextField="RazonSocial"
            AutoPostBack="true" OnSelectedIndexChanged="liEmpresas_SelectedIndexChanged">
            <asp:ListItem Value="0" Enabled="true" Selected="True" Text="Todas" />
        </asp:DropDownList>
</div>
<div class="clear"></div>
<div class="grid_3 alpha">
<asp:Label ID="lblLiSalas" runat="server" AssociatedControlID="liSalas">Seleccione una Sala: </asp:Label>
</div>
<div class="grid_3 omega">
    
        <asp:DropDownList ID="liSalas" runat="server" AutoPostBack="true" DataValueField="Id" DataTextField="Nombre">
        </asp:DropDownList><br />
       
   
    </div>
</div>


    <div class="grid_6">
     
     
    <asp:Calendar ID="Calendario" runat="server" 
            onselectionchanged="Calendario_SelectionChanged" ></asp:Calendar>
     </div>
     <div class="clear"> </div>
      <div class="grid_12">
        <asp:GridView ID="GrillaDia" runat="server">
        </asp:GridView>
        
        </div>
     
            

         
      </div>
</asp:Content>
