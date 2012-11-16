<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="salas.aspx.cs" Inherits="STGO.salas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="grid_12">
        <h1>Salas</h1>
        </div>
        <div class="grid_12"><asp:HyperLink ID="lnkAlta" runat="server" class="boton" NavigateUrl="~/sala-alta.aspx">Agregar Sala</asp:HyperLink> </div>
        <div class="grid_12">
        <asp:Label ID="lblListaEmpresas" runat="server" AssociatedControlID="liEmpresas">Seleccione una empresa: </asp:Label>
        <asp:DropDownList ID="liEmpresas" runat="server" DataValueField="Id" DataTextField="RazonSocial"
            AutoPostBack="true" OnSelectedIndexChanged="liEmpresas_SelectedIndexChanged">
            
        </asp:DropDownList>
        <br />
    </div>
    <div class="grid_12 tabla-datos">
        <asp:GridView ID="grid_Salas" runat="server" AutoGenerateColumns="False" OnRowEditing="grid_Salas_RowEditing"
            OnRowCommand="grid_Salas_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id" Visible="true" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Frecuencia" HeaderText="Frecuencia de Turno" HtmlEncode="false"
                    DataFormatString="{0} min." />
                <asp:TemplateField HeaderText="Permite Múltiplos">
                    <ItemTemplate>
                        <asp:Label ID="txtPermiteMultiplo" Text='<%# Eval("PermiteMultiplo").ToString() == "True" ? "Si": "No" %>'
                            runat="server" /></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio" HtmlEncode="false"
                    DataFormatString="{0:t}" />
                <asp:BoundField DataField="HoraCierre" HeaderText="Hora Cierre" HtmlEncode="false"
                    DataFormatString="{0:t}" />
                <asp:CommandField ShowEditButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="BorradoMio" Text="Eliminar" runat="server" CommandName="BorradoMio" 
                            CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar la sala? si posee turnos, los mismos se perderán');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="clear">
    </div>
</asp:Content>
