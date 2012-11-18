<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="turnos.aspx.cs" Inherits="STGO.turnos" Theme="STGO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>STGO-Turnos</title>
    <script type="text/javascript" src="/Scripts/validarLargos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="grid_6">
        <h1>
            Turnos</h1>
        <div class="grid_3 alpha">
            <asp:Label ID="lblListaEmpresas" runat="server" AssociatedControlID="liEmpresas">Seleccione una Empresa: </asp:Label>
        </div>
        <div class="grid_3 omega">
            <asp:DropDownList ID="liEmpresas" runat="server" DataValueField="Id" DataTextField="RazonSocial"
                AutoPostBack="true" OnSelectedIndexChanged="liEmpresas_SelectedIndexChanged">
                <asp:ListItem Value="0" Enabled="true" Selected="True" Text="Todas" />
            </asp:DropDownList>
        </div>
        <div class="grid_3 alpha">
            <asp:Label ID="lblLiSalas" runat="server" AssociatedControlID="liSalas">Seleccione una Sala: </asp:Label>
        </div>
        <div class="grid_3 omega">
            <asp:DropDownList ID="liSalas" runat="server" AutoPostBack="true" DataValueField="Id"
                DataTextField="Nombre" OnSelectedIndexChanged="liSalas_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
        </div>
        <div class="clear">
        </div>
        <div class="grid_6 alpha omega">
            <asp:LinkButton ID="btnNuevoTurno" class="boton" runat="server" Text="Nuevo Turno"
                CausesValidation="false" OnClick="btnNuevoTurno_Click" />
        </div>
        <div class="grid_6 alpha omega" id="almanaque">
            <asp:Calendar ID="Calendario" runat="server" OnSelectionChanged="Calendario_SelectionChanged"
                SelectedDayStyle-CssClass="dia_seleccionado" OnInit="Calendario_Init"></asp:Calendar>
        </div>
    </div>
    <div class="grid_6 tabla-datos">
        <asp:GridView ID="GrillaDia" runat="server" AutoGenerateColumns="False" OnRowCommand="GrillaDia_RowCommand"
            OnRowCreated="GrillaDia_RowCreated" OnRowDataBound="GrillaDia_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" Visible="true" />
                <asp:TemplateField HeaderText="Hora">
                    <ItemTemplate>
                        <asp:Label ID="lblHoraInicio" runat="server" Text='<%# Eval("FechaHoraInicio", "{0:t}") %>'></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblHoraFin" runat="server" Text='<%# Eval("FechaHoraFin", "{0:t}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>



                <asp:BoundField DataField="Reservador" HeaderText=" Nombre del Reservador" Visible="true" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" Visible="true" />
            
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="NuevoMio" runat="server" CommandName="NuevoMio" CommandArgument='<%#Eval("FechaHoraInicio", "{0:HH:mm}") + ";" +Eval("FechaHoraFin", "{0:HH:mm}")%>' 
                            ImageUrl="~/images/plus.png" CausesValidation="false" />
   
                        <asp:ImageButton ID="EditarMio" runat="server" CommandName="EditarMio" CommandArgument='<%# Eval("id") %>'
                            ImageUrl="~/images/pencil.png" CausesValidation="false" />
    
                        <asp:ImageButton ID="BorradoMio" runat="server" CommandName="BorradoMio" CommandArgument='<%# Eval("id") %>'
                            ImageUrl="~/images/cross.png" OnClientClick="return confirm('¿Esta seguro que desea eliminar este turno?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="clear">
    </div>
    <%--A partir de acá está el overlay de editar turnos--%>
    <div class="fondoTurno" id="fondoTurno" runat="server">
        <div class="grid_6 editTurno" id="editTurno" runat="server">
            <div class="grid_3">
                <h2>
                    Crear/Editar Turno</h2>
            </div>
            <div class="clear">
            </div>
            <asp:TextBox ID="txtEditId" runat="server"></asp:TextBox>
            <div class="grid_2 alpha divlabel">
                <asp:Label ID="lblEditFecha" runat="server" Text="Fecha:"></asp:Label>
            </div>
            <div class="grid_2">
                <asp:TextBox ID="txtEditFecha" runat="server"></asp:TextBox>
            </div>
            <div class="grid_2 omega">
                <asp:RequiredFieldValidator ID="rfvEditFecha" ControlToValidate="txtEditFecha" runat="server"
                    ErrorMessage="Este campo es obligatorio" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display="Dynamic" ID="regEditFecha" runat="server"
                    ErrorMessage="El formato de fecha no es válidp" ControlToValidate="txtEditFecha"
                    ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$"></asp:RegularExpressionValidator>
            </div>
            <div class="clear">
            </div>
            <div class="grid_2 alpha divlabel">
                <asp:Label ID="lblEditHoraInicio" runat="server" Text="Hora Inicio:"></asp:Label>
            </div>
            <div class="grid_2">
                <asp:TextBox ID="txtEditHoraInicio" runat="server"></asp:TextBox>
            </div>
            <div class="grid_2 omega">
                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEditHoraInicio" ControlToValidate="txtEditHoraInicio"
                    runat="server" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display="Dynamic" ID="ergEditHoraInicio" runat="server"
                    ErrorMessage="El formato de hora no es válidp" ControlToValidate="txtEditHoraInicio"
                    ValidationExpression="^([0-1]?[0-9]|2[0-4]):([0-5][0-9])(:[0-5][0-9])?$"></asp:RegularExpressionValidator>
            </div>
            <div class="clear">
            </div>
            <div class="grid_2 alpha divlabel">
                <asp:Label ID="lblEditHoraFin" runat="server" Text="Hora Fin:"></asp:Label>
            </div>
            <div class="grid_2">
                <asp:TextBox ID="txtEditHoraFin" runat="server"></asp:TextBox>
            </div>
            <div class="grid_2 omega">
                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEditHoraFin" ControlToValidate="txtEditHoraFin"
                    runat="server" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display="Dynamic" ID="regEditHoraFin" runat="server"
                    ErrorMessage="El formato de hora no es válidp" ControlToValidate="txtEditHoraFin"
                    ValidationExpression="^([0-1]?[0-9]|2[0-4]):([0-5][0-9])(:[0-5][0-9])?$"></asp:RegularExpressionValidator>
            </div>
            <div class="clear">
            </div>
            <div class="grid_2 alpha divlabel">
                <asp:Label ID="lblEditReservador" runat="server" Text="Reservador:"></asp:Label>
            </div>
            <div class="grid_2">
                <asp:TextBox ID="txtEditReservador" runat="server"></asp:TextBox>
            </div>
            <div class="grid_2 omega">
                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEditReservador" ControlToValidate="txtEditReservador"
                    runat="server" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="customReservador" runat="server" Display="Dynamic" ControlToValidate="txtEditReservador"
                    ErrorMessage="El reservador no puede tener más de 100 caracteres" ClientValidationFunction="validaLargo100"></asp:CustomValidator>
            </div>
            <div class="clear">
            </div>
            <div class="grid_2 alpha divlabel">
                <asp:Label ID="lblEditDescripcion" runat="server" Text="Descripción:"></asp:Label>
            </div>
            <div class="grid_2">
                <asp:TextBox ID="txtEditDescripcion" runat="server"></asp:TextBox>
            </div>
            <div class="grid_2 omega">
                <asp:CustomValidator ID="customEditDescripcion" runat="server" Display="Dynamic"
                    ControlToValidate="txtEditDescripcion" ErrorMessage="La descripción no puede tener más de 200 caracteres"
                    ClientValidationFunction="validaLargo200"></asp:CustomValidator>
            </div>
            <div class="clear">
            </div>
            <div class="grid_4 divlabel">
                <asp:Button ID="btnGuardar" class="boton" runat="server" Text="Guardar Cambios" CausesValidation="true"
                    OnClick="btnGuardar_Click" UseSubmitBehavior="True" />
                <asp:Button ID="btnCancelar" runat="server" class="boton" Text="Cancelar" CausesValidation="False"
                    OnClick="linkCancelar_Click" />
            </div>
            <div class="grid_6 alpha omega" id="errorGuardaTurno">
                <asp:Label ID="lblerrorGuardar" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
