<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advertisement.aspx.cs" Inherits="Allotment.Advertisement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset = "utf-8">
      <meta name = "viewport" content = "width=device-width, initial-scale = 1">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/css/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="/css/theme.css"/>
    <link rel="stylesheet" type="text/css" href="/css/footer.css"/>
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <style>
        /*.navbar-header {
            background: #ffc100;
            background: -moz-linear-gradient(top, #ffc511 0%, #ffe39e 50%, #ffe9a8 54%, #ffe7a0 59%, #ffc511 100%);
            background: -webkit-linear-gradient(top, #f9db7f 0%,#ffe39e 50%,#ffe9a8 54%,#ffe7a0 59%,#ffd75a 100%);
            background: linear-gradient(to bottom, #fff8e2 0%,#ffe39e 50%,#ffe9a8 54%,#ffe7a0 59%,#ffd143 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ffc511', endColorstr='#ffc511',GradientType=0 );
        }*/
        .odd-plotdiv:after {
            left: 100%;
            border: solid transparent;
            content: " ";
            height: 0;
            width: 0;
            position: absolute;
            pointer-events: none;
            border-color: rgba(66, 170, 225, 0);
            border-left-color: #337ab7;
            border-width: 43px;
            top: 35%;
            margin-top: -30px;
        }
        .even-plotdiv:after {
                left: 100%;
                border: solid transparent;
                content: " ";
                height: 0;
                width: 0;
                position: absolute;
                pointer-events: none;
                border-color: rgba(66, 170, 225, 0);
                border-left-color: #08b5a6;
                border-width: 43px;
                top: 35%;
                margin-top: -30px;
        }
        
        .odd-plotdiv {
            position:relative;
            width: 200px;
            background: #337ab7;
            height: 85px;           
            padding: 15px 12px;
            color:#fff;
            margin-top: 1px;
        }
        .odd-plotdiv .odd-main {
            border-right:1px solid #fff;
            display: block;
        }
        .odd-plotdiv .odd-top {
            font-size:20px;
        } 
        .odd-plotdiv .odd-bottom {
            font-size: 15px;
        }
        .even-plotdiv .even-main {
            border-right:1px solid #fff;
            display: block;
        }
        .even-plotdiv .even-top {
            font-size:20px;
            color: #000;
        } 
        .even-plotdiv .even-bottom {
            font-size: 15px;
            color: #000;
        }
        .even-plotdiv {
            position: relative;
            width: 200px;
            background: #08b5a6;
            height: 85px;           
            padding: 17px 12px;
            color: #fff;
            margin-top: 1px;
        }
            .even-plotdiv ul li {
                color:#fff;
            }
        @media only screen and (min-width: 960px) {
            .pad-rt2 {
                padding-right: 2px;
            }

            .pad-lt2 {
                padding-left: 2px;
            }
            .pad-rt0 {
                padding-right: 0px;
            }

            .pad-lt0 {
                padding-left: 0px;
            }
        }
        .bg_header {
	background-repeat : repeat-x;
	min-height : 28px;
	background-position : top;
	background-color : #FFF;
	border-bottom-width : 1px;
	border-bottom-style : solid;
	border-bottom-color : #E0E0E0;
}
/**.flag {
	background-image : url(../images/flag.jpg);
	background-repeat : no-repeat;
	background-position : left;
	min-height : 28px;
}
 **/   
 .mylistarea option {
    border-bottom: 1px dashed #fff;
    padding: 10px;
    color: #fff;
}.table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
   
    line-height: 2.428571 !important;}

    </style>
     <link rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" />
<link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.2.2/css/buttons.dataTables.min.css" />
<script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
<script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
<script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('[id*=Plot_List_Grid]').prepend($("<thead></thead>").append($('[id*=Plot_List_Grid]').find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 50,
                buttons: [
                    { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                ]
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">


        
	<asp:ScriptManager ID="ScriptManager1" runat="server" EnableViewState="true" AjaxFrameworkMode="Enabled" EnablePartialRendering="true">
	</asp:ScriptManager>


<%--	<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
   <ContentTemplate>
--%>


        <!--<div class="container-fluid bg_header">
            <div class="container flag ">
                <div class="row">
                </div>
            </div>
        </div>-->
        <div class="container-fluid" style="border: 1px solid #ccc;">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                        <a href="Default.aspx" class="navbar-brand">
                            <div class="col-md-8">
                                <img class="img-responsive" src="https://www.onlineupsidc.com/OfcUser_pdf/upsida-logo-name.png" />
                            </div>
                            <div class="col-md-4" style="margin-top: 2px;">
                                <img class="img-responsive" src="images/image4.png" />
                            </div>
                        </a>

                    </div>
                </div>
            <div  class="clearfix"></div><div id="main_menu" runat="server"><% Response.WriteFile("top_mainmenu.aspx"); %></div>
            </div>
            <div class="row default-top-header" id="SideDiv" style="background: #fff;">
                <div class="" style="background:#fff;">
                    <div class="" style="background:#001148;">
                        <div class="col-md-3 col-sm-3 col-xs-3">

                        </div>
                        <div class="col-md-6 col-sm-6 col-xs-6">
                            <p style="text-align:center;font-weight: 600;background: #001148;margin-bottom:0;padding:13px 0;"><span style="color:#fff;font-size:20px;">INVITES APPLICATIONS FOR ALLOTMENT OF PLOTS<br /> AT<br /></span> <span style="color:#ffc511;font-size: 21px;font-weight: 600;"><asp:label ID="lblIAName" runat="server"></asp:label><br /> <asp:label ID="lblArea" runat="server"></asp:label></span></p>
                        </div>
                        <div class="col-md-3 col-sm-3 col-xs-3">

                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-3 col-sm-3 col-xs-12 pad-rt0 pad-lt0">  
                        <div style="border-top: 0px solid #ccc;border-right: 0px solid #ccc;border-bottom: 1px solid #ccc;">
                            <asp:ListBox ID="listArea" CssClass="mylistarea" OnSelectedIndexChanged="listArea_SelectedIndexChanged" AutoPostBack="true" runat="server" style="width: 100%;min-height:108vh;background:#08b5a6;margin-left:0;"></asp:ListBox>                        
                        </div>
                    </div>
                    <div class="col-md-9 col-sm-9 col-xs-12 pad-lt0 pad-rt0">
                        <div  id="DivP" style="background: #fff;">
                                <div class="div-report" runat="server"  style="text-align: center;">                    
	                                  <div class="row">
                                    <div class="col-lg-12" >
                                  
                                         <div class="shadow text-center" style="width: 100%;background-color: #0088df;color: #fff;padding: 18px;">
                                                <span class="even-main">
                                                    <span class="even-top MY"><a  href="http://72.167.225.87/nivesh/" target="_blank" style="color: #fff;font-size: 18px;font-family: inherit !important;">APPLY FOR MEGA PROJECT ON NIVESH MITRA</a></span><br />
                                                   
                                                    <span class="even-bottom"><asp:label ID="Label1" runat="server"></asp:label></span>
                                                </span>
                                            </div>
                                       
                                        <%-- <a href="http://72.167.225.87/nivesh/" target="_blank"  class="btn btn-primary ey-bg" >Apply For Mega Project</a>--%>
                                        
                                        <%-- <a href="http://72.167.225.87/nivesh/"  target="_blank" class="btn btn-primary ey-bg" >Apply For Tailor Made Project</a>--%>
                                    </div>
                               

                                        </div>
                                    <marquee direction="left" onmouseover="this.stop();" onmouseout="this.start();" style="background: #e6e6e6;">
									<p style="font-size: 16px;text-align: center;padding: 10px;font-weight: 600;margin-bottom: 4px;background: #e6e6e6;">
									
									 Applications received in a given week from Sunday to Saturday shall be considered for processing - together as one lot.<br /><br />
									Interested parties may visit the website <a href="https://onlineupsida.com/">https://onlineupsida.com/</a> for eligibility criteria, participation, payment procedure and other terms & conditions of e-auction/allotment.</p>
                                    </marquee>
									<div style="clear:both;"></div>
                                    <div class="row">
                                        <div class="col-md-4 col-sm-4 col-xs-12 wrapper-plot-div" >
                                            <div class="shadow odd-plotdiv text-left" style="width:198px;">
                                                <span style="" class="odd-main">
                                                    <span style="" class="odd-top">CURRENT PRICE</span><br />
                                                    <span class="odd-bottom"><asp:label ID="lblReservePrice" runat="server"></asp:label></span>
                                                </span>
                                            </div>
                                            <div class="shadow even-plotdiv text-left" style="width:242px;">
                                                <span class="even-main">
                                                    <span class="even-top">TOTAL AREA</span><br />
                                                    <span class="even-bottom"><asp:label ID="lblTotalArea" runat="server"></asp:label></span>
                                                </span>
                                            </div>
                                            <div class="shadow odd-plotdiv text-left" style="width:286px;">
                                                <span class="odd-main">
                                                    <span class="odd-top">CONTACT INFO</span><br />
                                                    <span class="odd-bottom"><asp:label ID="lblContactInfo" runat="server"></asp:label></span>
                                                </span>
                                            </div>
                                            <div class="shadow even-plotdiv text-left" style="width:322px;padding: 6px 12px;">
                                                <span class="even-main">
                                                    <span class="even-top">LOCATION</span><br />
                                                      <span class="even-bottom"><asp:label ID="lblLocation" runat="server"></asp:label></span>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <table class="table table-bordered table-hover request-table1" style="margin-bottom:0;">
                                                    <tbody>
                                                    <tr style="background-color: #2d2d2d">
                                                        <th colspan="3" class="text-center font-bold">
                                                            <b style="color: #ffffff">LIST OF PLOTS AVAILABLE FOR ALLOTMENT</b>
                                                        </th>
                                                    </tr>
                                                   </tbody>
                                                </table>
                                                 <div class=" panel-primary" style="overflow-x: auto; overflow-y: auto;">
                                                        <div class="col-md-12 panel-primary" style="padding: 0px;">
                                                            <asp:GridView runat="server" ID="Plot_List_Grid" CssClass="table table-striped table-bordered  request-table myreq-col" 
                                                              ClientIDMode="Static" AutoGenerateColumns="false">
                                                               <Columns>
                                                                <asp:BoundField  DataField="RegionalOffice"  HeaderText="Regional Office" SortExpression="RegionalOffice" />
                                                                <asp:BoundField  DataField="IAName"          HeaderText="IA Name"         SortExpression="IAName" />
                                                                <asp:BoundField  DataField="PlotNumber"      HeaderText="Plot No"         SortExpression="PlotNumber" />
                                                                <asp:BoundField  DataField="PlotArea"        HeaderText="Plot Area"       SortExpression="PlotArea" />
                                                                 <asp:TemplateField HeaderText="Start Date">
                                                                    <ItemTemplate>
                                                                        <%# Convert.ToDateTime(Eval("StartDate")).ToString("dd/MM/yyyy")%>
                                                                    </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Site Plan">
                                                                 <HeaderStyle HorizontalAlign="Left" />
                                                                 <ItemStyle HorizontalAlign="Center" />
                                                                 <ItemTemplate>
                                                                 <asp:HyperLink ID="HyperLink1" runat="server" Text="View" NavigateUrl='<%# Eval("PlotMasterID_Main", "TracingDocViewer.aspx?PlotID={0}&DocType=T") %>' target="_blank" />
                                                                 </ItemTemplate>
                                                                 </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Joint Certificate">
                                                                 <HeaderStyle HorizontalAlign="Left" />
                                                                 <ItemStyle HorizontalAlign="Center" />
                                                                 <ItemTemplate>
                                                                 <asp:HyperLink ID="HyperLink1" runat="server" Text="View" NavigateUrl='<%# Eval("PlotMasterID_Main", "TracingDocViewer.aspx?PlotID={0}&DocType=JC") %>' target="_blank"  />
                                                                 </ItemTemplate>
                                                                 </asp:TemplateField>
                                                               </Columns>
                                                               </asp:GridView>
                                                    </div>
                                                    </div>
					                        
                                </div>
                            </div>
                            <div style="clear:both;"></div>
                                
                        </div>
                    </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="" style="background:#f1f1f1;">
                        <div class="col-md--12 col-sm-12 col-xs-12 pad-lt0 pad-rt0 text-center-imp">
                            <div style = "border-top:3px solid #ffc511;"></div>
                            <div style="padding: 14px;background: #001148;color: #fff;">
                                <strong><span style="font-size:18px;font-weight:600;">UTTAR PRADESH STATE INDUSTRIAL DEVELOPMENT CORPORATION LIMITED, KANPUR</span><br/>
	                            <span style="font-size:15px;font-weight:500;"> Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024 | Fax No: 0512-2580797 | e-mail: info@onlineupsidc.com<br />
                                www.onlineupsidc.com | CIN: U26960UP1961SGC002834</span>
                                </strong>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

       <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>
</body>
</html>
