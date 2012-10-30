<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaConMenu.master" AutoEventWireup="true"
    CodeBehind="empresas.aspx.cs" Inherits="STGO.empresas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPagConMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPaginaConMenu" runat="server">
    <div class="grid_12">
        <h1>
            Empresas</h1>
    </div>
    <div class="grid_12 tabla-datos">
        <asp:GridView ID="grid_Empresas" runat="server" AutoGenerateColumns="False" 
            onrowcommand="grid_Empresas_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id" Visible="true" />
                <asp:BoundField DataField="razonSocial" HeaderText="Razón Social" />
                <asp:BoundField DataField="cuit" HeaderText="CUIT" />
                <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="maximoSalas" HeaderText="Cantidad de Salas" />
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:Label ID="txtPermiteMultiplo" Text='<%# Eval("activo").ToString() == "True" ? "Activa": "Inactiva" %>'
                            runat="server" /></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="cambiarEstado" Text="Activar/Desactivar" runat="server" CommandName="cambiarEstado"
                            CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm('¿Esta seguro que desea cambiar el estado?');" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="cambiarCantSalas" Text="Cambiar cantidad de salas" runat="server"
                            CommandName="cambiarCantSalas" CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="clear">
    </div>
</asp:Content>
