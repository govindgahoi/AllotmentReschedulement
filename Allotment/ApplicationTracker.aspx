<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplicationTracker.aspx.cs" Inherits="Allotment.ApplicationTracker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="/js/jquery1.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script src="/js/jquery.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet" />
    <script src="js/chosen.jquery.min.js"></script>
  




    <style type="text/css">
        
        h4.modal-title {
            margin-right: 18px !important;
        }

        .mynew-panel-head {
            font-size: 14px !important;
            font-weight: 600;
            background: #2d2d2d;
            color: #ffc511 !important;
            text-align: center !important;
        }

        .modal.fade.in {
            background: rgba(0, 0, 0, 0.51);
        }

        @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 1%;
            }
        }
        .fill-view-mytable td {
            font-size:16px !important;
        }
        .modal-header {
            padding: 2px !important;
        }

        @media screen and (max-width: 768px) {
            .form-group .col-xs-6 {
                width: 50% !important;
            }
        }

        .content {
            min-height: 600px;
        }


            .my-app-status li:after{
               content: "\f178";
               font-family: FontAwesome;
               font-weight: 800;
               font-style: normal;
               margin:0 0 0px 5px;
               text-decoration:none;

            }
            .my-app-status {
                    margin: 10px auto;
                    border: 1px solid #ccc;
                    padding: 14px 0px;
                    text-align: center;
                    background: #dfdfdf;
                    border: 1px solid #ccc;
            }
            .my-app-status li span{
                border:1px solid #ccc;
                padding: 8px 6px;
                font-size: 11px;
                background: #f4cd4c;
            }
             .my-app-status li:nth-last-child(1):after{
                 display:none !important;
             }
            .my-app-status li{
                margin: 10px 0;
                padding: 0;
             }
            .my-app-status li span.orange{
                background: orange;
                color: #fff;
            }
            .my-app-status li span.red{
                background: red;
                color: #fff;
            }
            .my-app-status li span.green{
                background: green;
                color: #fff;
            }
    </style>

     <script type="text/javascript">
         function ShowTermsAndCondition() {
             $("#btnModalTerms").click();
         }
</script>
</head>
<body>
    <form id="form1" runat="server">



               
          <div class="modal fade" id="MyPopup" role="dialog" tabindex="-1">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title mynew-panel-head text-center">Application Proceedings</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="scr" id="agreement" style="font-size: 12px; padding: 4px 15px; overflow: auto; height: 321px;">
                                      	<asp:PlaceHolder runat="server" ID="Placeholder" />
                                            </div>
                                        <div class="clearfix"></div>
                                    </div>
                                 
                                </div>
                            </div>
                        </div>
                        <input type="button" id="btnModalTerms" style="display: none;" data-toggle="modal" data-target="#myModal" data-backdrop="static" />

    
        <div class="container">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                        <a href="Default.aspx" class="navbar-brand">
                            <div class="col-md-8">
                                <img class="img-responsive" src="logo.jpg" />
                            </div>
                            <div class="col-md-4">
                                <img class="img-responsive" src="Image.jpg" />
                            </div>
                        </a>

                    </div>
                </div>
                <div id="main_menu" runat="server"><% Response.WriteFile("top_mainmenu.aspx"); %> </div>
            </div>
            <div class="row" id="SideDiv">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading text-center">Application Tracker</div>
                        <hr class="separation" />
                        <div class="">
                            <div class="col-md-9 col-sm-9 col-xs-8" style="">
                                <div class="row" style="border: 15px solid #ccc;">
                                    <div class="col-md-12 col-sm-6 col-xs-12" style="border-right: 4px solid #ccc; padding: 0px !important;">
                                        <div class="panel-heading font-bold"></div>
                                            <table class="table table-striped table-responsive table-bordered table-hover request-table">                            
                                            <tr>
                                                <td style="width:50%;">Service Request No</td>
                                                <td style="width:50%;">
                                                    <asp:TextBox ID="txtServiceReqNo" runat="server" CssClass="input-sm similar-select1" OnTextChanged="txtServiceReqNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Applicant Name</td>
                                                <td>
                                                    <asp:Label ID="lblApplicantName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Company Name</td>
                                                <td>
                                                    <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                                 <tr>
                                                <td>Industrial Area</td>
                                                <td>
                                                    <asp:Label ID="lblIaname" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Application Date</td>
                                                <td>
                                                    <asp:Label ID="lblApplicationDate" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Plot Preference 1</td>
                                                <td>
                                                    <asp:Label ID="lblPlotPreference1" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Plot Preference 2</td>
                                                <td>
                                                    <asp:Label ID="lblPlotPreference2" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Plot Preference 3</td>
                                                <td>
                                                    <asp:Label ID="lblPlotPreference3" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Payment Amount</td>
                                                <td>
                                                    <asp:Label ID="lblPaymentAmount" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Payment Date</td>
                                                <td>
                                                    <asp:Label ID="lblPaymentDate" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Payment Status</td>
                                                <td>
                                                    <asp:Label ID="lblPaymentStatus" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Application Status</td>
                                                <td>
                                                    <asp:Label ID="lblApplicationStatus" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                        
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3 col-xs-4 text-center">
                                <asp:Image id="ImgPrv" runat="server"  class="img-sign img-responsive" alt="image" style="height: 150px;margin: 12% auto 0 auto;" Visible="false"/>
                            </div>
                        </div>   
                        <div class="clearfix"></div>
                        <hr class="separation" />
                        <ul class="list-inline my-app-status">
                            <li><span id="stage1" runat="server">Application</span></li>
                            <li><span id="stage2" runat="server">Payment</span></li>
                            <li><span id="stage3" runat="server">Final Submission</span></li>
                            <li><span id="stage4" runat="server">Account Clearance</span></li>
                            <li><span id="stage5" runat="server">Data Verification</span></li>
                            <li><span id="stage6" runat="server">RM Approval</span></li>
                            <li><span id="stage7" runat="server">CMIA Recommendation</span></li>
                            <li><span id="stage8" runat="server">MD Recommendation</span></li>
                            <li><span id="stage9" runat="server">Allotment Completed</span></li>
                        </ul>
                    </div>
                </div>

                 <div class="panel panel-default">
                        <div class="panel-heading text-center">Applications Received On Selected Plots</div>
                        <hr class="separation" />
                        <div class="">
                                 <asp:GridView ID="Application_Grid" runat="server"
             CssClass="table table-striped table-bordered table-hover request-table request-table"
            AutoGenerateColumns="False"
            DataKeyNames="ApplicationID"
            GridLines="Horizontal"
    
            Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ApplicationID" HeaderText="Application ID" SortExpression="ApplicationID" />
             
                <asp:BoundField DataField="CompanyName" HeaderText="Applicant" SortExpression="CompanyName" />
                <asp:TemplateField HeaderText="View Proceedings">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/ViewProceedings.aspx?ServiceRequestNo={0}",HttpUtility.UrlEncode(Eval("ApplicationID").ToString())) %>' Text="View" > </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                     <asp:TemplateField HeaderText="View Marking">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/ViewMarking.aspx?ServiceRequestNo={0}",HttpUtility.UrlEncode(Eval("ApplicationID").ToString())) %>' Text="View" > </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                     <asp:TemplateField HeaderText="View Minutes">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="Hyper3" Target="_blank" NavigateUrl='<%# string.Format("~/DocViewerMinutes.aspx?ServiceReqNo={0}",HttpUtility.UrlEncode(Eval("ApplicationID").ToString())) %>' Text="View" > </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>

            </Columns>
            <EmptyDataTemplate>
                No Record Available
            </EmptyDataTemplate>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>

                        </div>
                     </div>

            </div>
        </div>
        
    </form>
</body>
</html>
