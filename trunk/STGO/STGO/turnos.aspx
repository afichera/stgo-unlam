<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaConMenu.master" AutoEventWireup="true"
    CodeBehind="turnos.aspx.cs" Inherits="STGO.turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPagConMenu" runat="server">
    <title>STGO-Turnos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPaginaConMenu" runat="server">
    <div class="grid_12">
        <h1>
            Turnos</h1>
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
        <div class="clear">
        </div>
        <div class="grid_3 alpha">
            <asp:Label ID="lblLiSalas" runat="server" AssociatedControlID="liSalas">Seleccione una Sala: </asp:Label>
        </div>
        <div class="grid_3 omega">
            <asp:DropDownList ID="liSalas" runat="server" AutoPostBack="true" DataValueField="Id"
                DataTextField="Nombre">
            </asp:DropDownList>
            <br />
        </div>
    </div>
    <div class="grid_6" id="almanaque">
        <asp:Calendar ID="Calendario" runat="server" 
            OnSelectionChanged="Calendario_SelectionChanged">
        </asp:Calendar>
    </div>
    <div class="clear">
    </div>
    <div class="grid_6 tabla-datos" id="calendario">
        <asp:GridView ID="GrillaDia" runat="server" AutoGenerateColumns="False" onrowcommand="GrillaDia_RowCommand" 
            >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" Visible="true" />
                <asp:TemplateField HeaderText="Hora">
                    <ItemTemplate>
                        <asp:Label  ID="lblHoraInicio" runat="server" Text='<%# Eval("FechaHoraInicio", "{0:t}") %>'></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblHoraFin" runat="server" Text='<%# Eval("FechaHoraFin", "{0:t}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Reservador" HeaderText=" Nombre del Reservador" Visible="true" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" Visible="true" />
                
                
                
          

         <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="Editar" Text="Editar" runat="server" CommandName="EditarMio"
                            CommandArgument='<%# Eval("id") %>' ImageUrl="~/images/pencil.png" CausesValidation="false"  />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="BorradoMio" Text="Eliminar" runat="server" CommandName="BorradoMio"
                            CommandArgument='<%# Eval("id") %>' ImageUrl="~/images/cross.png" OnClientClick="return confirm('¿Esta seguro que desea eliminar este turno?');" />
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
        </asp:GridView>
    </div>
    <div class="grid_6" id="editTurno">
<div class="grid_3">
<h2>Crear/Editar Turno</h2>
</div>

<div class="clear"></div>
        <asp:TextBox ID="txtEditId" runat="server"></asp:TextBox>
        <div class="grid_2 alpha divlabel">
            <asp:Label ID="lblEditFecha" runat="server" Text="Fecha:"></asp:Label>
        </div>
        <div class="grid_2">
            <asp:TextBox ID="txtEditFecha" runat="server"></asp:TextBox>
        </div>
        <div class="grid_2 omega">
            <asp:RequiredFieldValidator ID="rfvEditFecha" ControlToValidate="txtEditFecha" runat="server" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator> 
        </div>
<div class="clear"></div>

        <div class="grid_2 alpha divlabel">
           <asp:Label ID="lblEditHoraInicio" runat="server" Text="Hora Inicio:"></asp:Label>
        </div>
        <div class="grid_2">
        <asp:TextBox ID="txtEditHoraInicio" runat="server"></asp:TextBox>
        </div>
        <div class="grid_2 omega">
        <asp:RequiredFieldValidator ID="rfvEditHoraInicio" ControlToValidate="txtEditHoraInicio" runat="server" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator> 
        </div>
<div class="clear"></div>
                <div class="grid_2 alpha divlabel">
           <asp:Label ID="lblEditHoraFin" runat="server" Text="Hora Fin:"></asp:Label>
        </div>
        <div class="grid_2">
        <asp:TextBox ID="txtEditHoraFin" runat="server"></asp:TextBox>
        </div>
        <div class="grid_2 omega">
        <asp:RequiredFieldValidator ID="rfvEditHoraFin" ControlToValidate="txtEditHoraFin" runat="server" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator> 
        </div>
<div class="clear"></div>
        <div class="grid_2 alpha divlabel">
        <asp:Label ID="lblEditReservador" runat="server" Text="Reservador:"></asp:Label>
        </div>
        <div class="grid_2">
            <asp:TextBox ID="txtEditReservador" runat="server"></asp:TextBox>
        </div>
        <div class="grid_2 omega">
        <asp:RequiredFieldValidator ID="rfvEditReservador" ControlToValidate="txtEditReservador" runat="server" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator> 
        </div>
<div class="clear"></div>
        <div class="grid_2 alpha divlabel">
        <asp:Label ID="lblEditDescripcion" runat="server" Text="Descripción:"></asp:Label>
        </div>
        <div class="grid_2">
            <asp:TextBox ID="txtEditDescripcion" runat="server"></asp:TextBox>
        </div>
        <div class="grid_2 omega">
        
        </div>
<div class="clear"></div>

        <div class="grid_4 divlabel">
     <asp:Button ID="btnGuardar" class="boton" runat="server" Text="Guardar Cambios" 
         CausesValidation="true"  />
     <asp:HyperLink ID="linkCancelar" runat="server" class="boton" NavigateUrl="~/Turnos.aspx">Cancelar</asp:HyperLink> 
 </div> 

    </div>
</asp:Content>
