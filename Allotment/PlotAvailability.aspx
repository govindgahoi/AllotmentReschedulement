<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlotAvailability.aspx.cs" Inherits="Allotment.PlotAvailability" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/Main.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />


    <link href="css/ajax-jquery-ui.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />

    <script src="js/ajax-jquery-min.js"></script>
    <script src="js/ajax-jquery-ui.js"></script>
    <script src="assets/js/bootstrap-datepicker.min.js"></script>
    <script src="js/jquery-1.11.3.min"></script>
    <script src="js/bootstrap.min.js"></script>

    <style>

        .request-table tr td a {
     color: white; 
    font-weight: bold;
}
        .panel {
    /* border: 1px solid #ffd200; */
    background: white;
    border-radius: 3px;
    margin-top: 20px;
}
        footer {
    padding: 1em;
    margin-top: 36em;
    color: #666;
    font-size: .85em;
    line-height: 1.3em;
    /* margin: 4em -3px 0em -3px; */
}


        .mynewnavmenu {
    background: #424242;
    margin-top: 40px;
}
        .ui-dialog .ui-dialog-titlebar {
            padding: .4em 1em;
            position: relative;
            background: #D8D8D8 !important;
            border-color: #D8D8D8 !important;
        }

        .ui-dialog .ui-dialog-title {
            font-family: serif !important;
            color: black;
        }
        
        .ui-dialog {
            top: 130% !important;
        }

            .ui-dialog .ui-dialog-buttonpane button {
                background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#4c5568), to(#414959)) !important;
                border: 1px solid #fff !important;
                font-weight: normal !important;
                padding: 5px 10px !important;
                font-size: 12px !important;
                line-height: 1.5 !important;
                color: #fff !important;
            }




            .ui-dialog .ui-dialog-titlebar-close span {
                color: black !important;
            }
    </style>

    <script type="text/javascript">     

        function ShowPopup(message) {
            $(function () {
                $("#dialog").html(message);
                $("#dialog").dialog({
                    title: "Alert",
                    buttons: {
                        Close: function () {
                            $(this).dialog('close');
                        }
                    },
                    modal: true
                });
            });
        };

        

        function IsValidEmail(email) {
            var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            return expr.test(email);
        };

        function isDecimalKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

            }
        }
    </script>
</head>
<body id="pagewrap">
    <div id="dialog" style="display: none">
    </div>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="container">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                       <a href="Default.aspx" class="navbar-brand" style="width:100%;">
                            <div class="col-md-8">
                                <img class="img-responsive" src="http://www.onlineupsidc.com/OfcUser_pdf/upsida-logo-name.png" />
                            </div>
                            <div class="col-md-4" style="margin-top: 2px;">
                                <img class="img-responsive" src="images/image4.png" />
                            </div>
                        </a>

                    </div>
                </div>
                <div id="main_menu" runat="server"><% Response.WriteFile("top_mainmenu.aspx"); %> </div>
            </div>
            <div class="row" id="SideDiv">
                <div class="col-md-12"  style="border-top: 4px solid #b78c33">
                    
                    <div class="row">
                        <div class="col-md-12">
                             <div class="row" style="background-color:gainsboro">
                                            <div class="col-md-3"></div>
                                            <div class="col-md-5"></div>
                                            <div class="col-md-4"><h3>Unable to find a plot     :<span><asp:LinkButton runat="server" id="SomeLinkButton" href="Landassessmentdetails.aspx" target="_blank" CssClass="btn btn-primary btn-sm" ToolTip="Submit Your Request" >Submit Your Request</asp:LinkButton></span></h3></div>
                                            
                                            
                                        
                                         </div>
                            <div class="row" style="border-top: 4px solid #b78c33">

                            </div>
                            <div class="row well well-large offset4">
                                <div class="panel panel-default">
                                    <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;">
                                      
                                       
                                    <p class="panel-heading text-center" style="font-size:12px"><b>Find A Plot</b></p>
                                    <div class="panel-body">
                                        <div id="tblallotteeinf">
                                         
                                            <div class="form-group">
                                                

                                                <div class="row">                                                   
                                                    <label class="col-md-2 text-right">
                                                        <span style="color: Red">*</span>
                                                         District Name :
                                                    </label>
                                                    <div class="col-md-2">
                                                          <asp:DropDownList ID="ddlDistrict" runat="server"  CssClass="similar-select1 margin-left-z dropdown-toggle input-sm"  OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true"  ></asp:DropDownList> 
                                                    </div>
                                                     <label class="col-md-2 text-right">
                                                        <span style="color: Red">*</span>
                                                        Industrial Area :
                                                    </label>
                                                    <div class="col-md-2">
                                                       <asp:DropDownList ID="ddlIA" runat="server"  CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" OnSelectedIndexChanged="ddlIA_SelectedIndexChanged" AutoPostBack="true"  ></asp:DropDownList> 
                                                    </div>

                                                      <label class="col-md-2 text-right">
                                                       
                                                         Area filter (In Sq.mtr.):
                                                    </label>
                                                    <div class="col-md-2" >                                                   
                                                       <asp:DropDownList ID="ddlArea" runat="server"  CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> 
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />                                                                                                                                
                                        </div> 
                                       
                                        <div id="tblplotdetails" runat="server">
                                        <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="row" style="margin-top: 12px; text-align:center ; font-size:16px" >
                                    Plot available as on <span><%= System.DateTime.Now.ToString() %></span>
                                </div>
                            
                                <div class="clearfix"></div>

                            </div>
                            <div class="panel-body gallery  table-responsive">
                                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="gridplotavailability" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" CssClass="table table-striped table-bordered table-hover request-table"  OnPageIndexChanging="gridplotavailability_PageIndexChanging"
                         PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right">
                                    <Columns>


                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField DataField="Region" HeaderText="District Name" SortExpression="Region" />
                                         <asp:BoundField DataField="IndustrialArea" HeaderText="Industrial Area" SortExpression="IndustrialArea" />
                                        <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                                        <asp:BoundField DataField="PlotArea" HeaderText="Plot Area (Sq.mtr.)" SortExpression="PlotArea" />                                      
                <asp:TemplateField HeaderText = "" >
            <ItemTemplate>              
                 <asp:HyperLink runat="server" NavigateUrl='<%# Eval("GISIAID", "http://118.185.3.27/gisupsidc/default.aspx?ID={0}") %>'
                   target="_blank"   CssClass="btn btn-primary btn-xs"   Text='View On GIS' ToolTip="View On GIS" />
            </ItemTemplate>
        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        
                                       <div class="row" style="background-color:gainsboro">
                                            <div class="col-md-3"></div>
                                            <div class="col-md-5"></div>
                                            <div class="col-md-4" style=""><h3>Unable to find a plot     :<span><asp:LinkButton runat="server" id="SomeLinkButton" href="Landassessmentdetails.aspx" target="_blank"  CssClass="btn btn-primary btn-sm" ToolTip="Submit Your Request"  >Submit Your Request</asp:LinkButton></span></h3></div>                                                                                                                                
                                         </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                 
                            </div>
                        </div>
                    </div>
                                            </div>
                                        
                                    </div>   
                                        


                                        
                </div>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
                <footer class="nb-footer">
                    <div class="container">
                        <div class="row">
                            
                            <div class="col-md-3 col-sm-6">
                                <div class="footer-info-single">
                                    <h2 class="title">PUBLIC FORUM</h2>
                                    <ul class="list-unstyled">
                                       
                                        <li><a href="Inspection.aspx" title=""><i class="fa fa-angle-double-right"></i>View Inspection Detail</a></li>
                                        <li><a href="BuldingPlanDetail.aspx" title=""><i class="fa fa-angle-double-right"></i>Approved Building Plan</a></li>
                                        <li><a href="PviewAllottes.aspx" target="_blank" title=""><i class="fa fa-angle-double-right"></i>View Allotment Document</a></li>
                                        <li><a href="ViewInspectionDocument.aspx" target="_blank" title=""><i class="fa fa-angle-double-right"></i>View Inspection Document</a></li>
                                        <li><a href="ViewBuildingPlanDocument.aspx" target="_blank" title=""><i class="fa fa-angle-double-right"></i>View BuildingPlan Document </a></li>
                                    </ul>
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-6">
                                <div class="footer-info-single">
                                    <h2 class="title">UP SIDA</h2>
                                    <ul class="list-unstyled">
                                        <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>UP Industial Development Act</a></li>
                                        <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>UPSIDA Byelaws</a></li>
                                        <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>Inspection Format For Construction Permit</a></li>
                                        <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>Inspection Format For Completion</a></li>
                                        <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>SOP For Computerised Allocation of Inspectors</a></li>
                                    </ul>
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-6">
                                <div class="footer-info-single">
                                    <h2 class="title">Security & privacy</h2>
                                    <ul class="list-unstyled">
                                        <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Terms Of Use</a></li>
                                        <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Privacy Policy</a></li>
                                        <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Return / Refund Policy</a></li>
                                        <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Store Locations</a></li>
                                    </ul>
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-6">
                                <div class="footer-info-single">
                                    <h2 class="title">Payment</h2>
                                    <ul class="list-unstyled">
                                        <li><a href="PaymentRequest.aspx" title=""><i class="fa fa-angle-double-right"></i>Quick Pay</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>

                    <section class="copyright">
                        <div class="container">
                            <div class="row">
                                <div class="col-sm-6">
                                    <p>Copyright © 2017. UPSIDC Product Version Alpha 1.0 Release</p>
                                </div>
                                <div class="col-sm-6"></div>
                            </div>
                        </div>
                    </section>
                </footer>

            </div>

        </div>

    </form>
 

</body >
</html>
