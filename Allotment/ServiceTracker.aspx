<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceTracker.aspx.cs" Inherits="Allotment.ServiceTracker" %>

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


    
</head>
<body>
    <form id="form1" runat="server">

         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

           <div class="modal fade" id="myModal" role="dialog"  >
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title mynew-panel-head text-center">Application Proceedings</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="scr" id="agreement" style="font-size: 12px; padding: 4px 15px; overflow: auto; height: 321px;">
                                      	<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  CssClass="table table-striped table-bordered table-hover request-table">
                                    <Columns>


                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField DataField="From" HeaderText="From"  />
                                         <asp:BoundField DataField="To"  HeaderText ="To"  />
                                         <asp:BoundField DataField="Status" HeaderText="Status" />
                                         <asp:BoundField DataField="Remarks" HeaderText="Remarks"  />                                                                              
                                         <asp:BoundField DataField="Entry_Time" HeaderText="Date" />
                                        
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                            </div>
                                        <div class="clearfix"></div>
                                    </div>
                                 
                                       <div class="modal-footer">
              <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal">Close</button></div>
        
                                </div>
                            </div>
                        </div>
                     
    
        <div class="container">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                        <a href="Default.aspx" class="navbar-brand">
                            <div class="col-md-8">
                                <img class="img-responsive" src="https://www.onlineupsidc.com/OfcUser_pdf/upsida-logo-name.png" />
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
                        <div class="panel-heading text-center">Service Tracker</div>
                        <hr class="separation" />
                        <div class="row">
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 text-center" >
                               Service Request No 
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                               <asp:TextBox ID="txtServiceReqNo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 text-center">
                                <asp:Button ID="Go" runat="server" CssClass="btn btn-primary btn-sm" Text="Go" OnClick="Go_Click" />
                                </div>
                        </div>
                       
                        <div class="clearfix"></div>
                        <hr class="separation" />
                        
                    </div>
                </div>

                 <div class="panel panel-default">                      
                        <hr class="separation" />
                        <div class="">
                            <asp:GridView ID="gridServiceTracker" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="3" CssClass="table table-striped table-bordered table-hover request-table" 
                                       PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right">
                                    <Columns>


                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField DataField="RegionalOffice" HeaderText="Regional Office" SortExpression="RegionalOffice" />
                                        <asp:BoundField DataField="IAName" HeaderText="Industrial Area" SortExpression="IAName" />
                                         <asp:BoundField DataField="ServiceRequestNo" HeaderText="Service Request No" SortExpression="ServiceRequestNo" />
                                         <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" SortExpression="ApplicantName" />                                                                              
                                        <asp:BoundField DataField="ServiceName" HeaderText="Service Name" SortExpression="ServiceName" />
                                        <asp:BoundField DataField="FinalSubmissionDate" HeaderText="Final Submission Date" SortExpression="FinalSubmissionDate" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                        <asp:TemplateField>
			                              <ItemTemplate>
											 <i class="fa fa-comments" style="cursor:pointer;" data-toggle="modal" data-target="#myModal" data-backdrop="static" aria-hidden="true"></i>
                                         </ItemTemplate>
                                            </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                 

                        </div>
                     </div>
               
                        <div class="row">                                                      
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                               <asp:Button ID="btn_ViewApp" runat="server" Visible="false" CssClass="btn btn-primary btn-sm" Text="View Application " OnClick="tbn_ViewApp_Click"  />
                               <asp:Button ID="btnView" runat="server" CssClass="btn btn-primary btn-sm" Text="View NOC " OnClick="btnView_Click"  />
                               <asp:Button ID="Btnview1" runat="server" CssClass="btn btn-primary btn-sm" Text="View rejection letter" OnClick="Btnview1_Click"  />
                            

                                </div>
                         </div>
                    
                       
                       
                 
                       
                        
                        
                   
            </div>
        </div>
        
    </form>

      
</body>
</html>
