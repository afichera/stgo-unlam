<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaConMenu.master" AutoEventWireup="true"
    CodeBehind="turnos.aspx.cs" Inherits="STGO.turnos" Theme="wdCalendar" %>
    

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPagConMenu" runat="server">
       <script src="Scripts/wdCalendar/src/jquery.js" type="text/javascript"></script>  
    <script src="Scripts/wdCalendar/src/Plugins/Common.js" type="text/javascript"></script>    
    <script src="Scripts/wdCalendar/src/Plugins/datepicker_lang_ES.js" type="text/javascript"></script>     
    <script src="Scripts/wdCalendar/src/Plugins/jquery.datepicker.js" type="text/javascript"></script>
    <script src="Scripts/wdCalendar/src/Plugins/jquery.alert.js" type="text/javascript"></script>    
    <script src="Scripts/wdCalendar/src/Plugins/jquery.ifrmdailog.js" defer="defer" type="text/javascript"></script>
    <script src="Scripts/wdCalendar/src/Plugins/wdCalendar_lang_ES.js" type="text/javascript"></script>    
    <script src="Scripts/wdCalendar/src/Plugins/jquery.calendar.js" type="text/javascript"></script>
    <script src="Scripts/wdCalendar/src/jquery.getQueryParam.min.js" type="text/javascript"></script>
    <script src="Scripts/wdCalendar/lanzaCalendar.js" type="text/javascript"></script>

   
   
    <title>STGO-Turnos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPaginaConMenu" runat="server">
    <div class="grid_12">
        <h1>Turnos</h1>
        <asp:Label ID="lblListaEmpresas" runat="server" AssociatedControlID="liEmpresas">Seleccione una Empresa: </asp:Label>
        <asp:DropDownList ID="liEmpresas" runat="server">
        </asp:DropDownList>
        (sólo para superusuario)<br />
        <asp:Label ID="lblLiSalas" runat="server" AssociatedControlID="liSalas">Seleccione una Sala: </asp:Label>
        <asp:DropDownList ID="liSalas" runat="server">
        </asp:DropDownList><br />
       
   
    </div>



    <div class="grid_12">
            
          <div id="calhead" style="padding-left:1px;padding-right:1px;">          
                <div class="cHead"><div class="ftitle">Turnos</div>
                <div id="loadingpannel" class="ptogtitle loadicon" style="display: none;">Recuperando información...</div>
                 <div id="errorpannel" class="ptogtitle loaderror" style="display: none;">No se pudo obtener la información, vuelva a intentarlo</div>
                </div>          
                
                <div id="caltoolbar" class="ctoolbar">
                  <div id="faddbtn" class="fbutton">
                    <div><span title='Clic para crear un nuevo turno' class="addcal">

                    Nuevo Turno                
                    </span></div>
                </div>
                <div class="btnseparator"></div>
                 <div id="showtodaybtn" class="fbutton">
                    <div><span title='Clic para volver al día de hoy ' class="showtoday">
                    Hoy</span></div>
                </div>
                  <div class="btnseparator"></div>

                <div id="showdaybtn" class="fbutton">
                    <div><span title='Día' class="showdayview">Día</span></div>
                </div>
                  <div  id="showweekbtn" class="fbutton fcurrent">
                    <div><span title='Semana' class="showweekview">Semana</span></div>
                </div>
                  <div  id="showmonthbtn" class="fbutton">
                    <div><span title='Mes' class="showmonthview">Mes</span></div>

                </div>
                <div class="btnseparator"></div>
                  <div  id="showreflashbtn" class="fbutton">
                    <div><span title='Recargar pantalla' class="showdayflash">Recargar</span></div>
                    </div>
                 <div class="btnseparator"></div>
                <div id="sfprevbtn" title="Anterior"  class="fbutton">
                  <span class="fprev"></span>

                </div>
                <div id="sfnextbtn" title="Próximo" class="fbutton">
                    <span class="fnext"></span>
                </div>
                <div class="fshowdatep fbutton">
                        <div>
                            <input type="hidden" name="txtshow" id="hdtxtshow" />
                            <span id="txtdatetimeshow">Semana Actual</span>

                        </div>
                </div>
                
                <div class="clear"></div>
                </div>
          </div>
          <div style="padding:1px;">

            <div class="t1 chromeColor">
                &nbsp;</div>
            <div class="t2 chromeColor">
                &nbsp;</div>
            <div id="dvCalMain" class="calmain printborder">
                <div id="gridcontainer" style="overflow-y: visible;">
                </div>
            </div>
            <div class="t2 chromeColor">

                &nbsp;</div>
            <div class="t1 chromeColor">
                &nbsp;
            </div>   
            </div>
         
      </div>
</asp:Content>
