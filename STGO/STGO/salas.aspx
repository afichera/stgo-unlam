<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaConMenu.master" AutoEventWireup="true"
    CodeBehind="salas.aspx.cs" Inherits="STGO.salas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPagConMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPaginaConMenu" runat="server">
    <div class="grid_12">
        <h1>
            Salas</h1>
        <asp:Label ID="lblListaEmpresas" runat="server" AssociatedControlID="liEmpresas">Seleccione una empresa: </asp:Label>
        <asp:DropDownList ID="liEmpresas" runat="server" DataValueField="Id"  
            DataTextField="RazonSocial" AutoPostBack="true" 
            onselectedindexchanged="liEmpresas_SelectedIndexChanged">
        <asp:ListItem Value="0" Enabled="true" Selected="True" Text="Todas" />
        </asp:DropDownList>
       <br />
    </div>
    <div class="grid_12 tabla-datos">
        <asp:GridView ID="grid_Salas" runat="server" AutoGenerateColumns="False" 
           onrowediting="grid_Salas_RowEditing" onrowcommand="grid_Salas_RowCommand">
            <Columns>
            <asp:BoundField DataField="id"  HeaderText="Id" Visible="true" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Frecuencia" HeaderText="Frecuencia de Turno" HtmlEncode="false"
                    DataFormatString="{0} min." />
                <asp:TemplateField HeaderText="Permite Múltiplos">
                    <ItemTemplate>
                        <asp:Label ID="txtPermiteMultiplo" Text='<%# Eval("PermiteMultiplo").ToString() == "True" ? "Si": "No" %>'
                            runat="server" /></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio" HtmlEncode="false"
                    DataFormatString="{0:T}" />
                <asp:BoundField DataField="HoraCierre" HeaderText="Hora Cierre" HtmlEncode="false"
                    DataFormatString="{0:T}" />
                <asp:CommandField ShowEditButton="True" />
                <asp:ButtonField CommandName="BorradoMio" Runat="server" Text="Eliminar"   />

            
         

            </Columns>
        </asp:GridView>
    </div>
    <div class="clear">
    </div>
</asp:Content>
