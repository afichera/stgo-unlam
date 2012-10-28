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
    <asp:GridView ID="grid_Salas" runat="server">
        <Columns>
            <asp:ButtonField CommandName="Edit" HeaderText="Editar" ShowHeader="True" 
                Text="Editar" />
        </Columns>
    </asp:GridView>
</div>
<div class="clear"></div>



</asp:Content>
