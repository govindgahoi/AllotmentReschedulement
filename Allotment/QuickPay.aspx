<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuickPay.aspx.cs" Inherits="Allotment.QuickPay" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">   
    <title></title>
     <meta http-equiv="Page-Enter" content="Alpha(opacity=100)"/>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />
    <style>
        * {
            box-sizing: border-box;
        }

        .dash {
            border: 0 none;
            border-top: 1px dashed #FFD200;
            background: none;
            height: 0;
        }

        .mySlides {
            display: none;
        }

        /* Slideshow container */
        .slideshow-container {
            max-width: 1000px;
            position: relative;
            margin: auto;
        }

        /* Caption text */

        .active {
            background-color: #717171;
        }

        /* Fading animation */
        .fade {
            -webkit-animation-name: fade;
            -webkit-animation-duration: 1.5s;
            animation-name: fade;
            animation-duration: 1.5s;
        }

        @-webkit-keyframes fade {
            from {
                opacity: .4;
            }

            to {
                opacity: 1;
            }
        }

        @keyframes fade {
            from {
                opacity: .4;
            }

            to {
                opacity: 1;
            }
        }

        /* On smaller screens, decrease text size */
        @media only screen and (max-width: 300px) {
            .text {
                font-size: 11px;
            }
        }
    </style>

</head>
<body id="pagewrap">
     <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                        <a href="Default.aspx" class="navbar-brand">
                            <div class="col-md-8">
                                <img class="img-responsive" src="logo.jpg" />
                            </div>
                            <div class="col-md-4" style="margin-top: 10px;">
                                <img class="img-responsive" src="images/image4.png" />
                            </div>
                        </a>

                    </div>
                </div>
                <div  class="clearfix"></div><div id="main_menu" runat="server"><% Response.WriteFile("top_mainmenu.aspx"); %></div></div>
            <div class="row default-top-header" id="SideDiv">
 
                <div class="col-md-12">
                    <div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">

                            <div class="row well well-large offset4">
                                <div class="col-md-12 well well-large offset4">
                                    <div class="main-container ace-save-state" id="main-container">
                                        <div class="main-content">
                                            <div class="main-content-inner">
                                                <div class="page-content">
                                                    <div class="row">
                                                        <div class="col-xs-12">
                                                            <div class="row">
                                                                <div class="col-xs-12">
                                                                    Please Enter your <b>Allotment Letter Number</b> to View & Pay your Dues.
                                                                    <br />
                                                                    <asp:Label runat="server" Text="" ID="lblResponse"></asp:Label>
                                                                    <br />
                                                                    <br />
                                                                    Enter Allottement Letter No.
                                                                    <asp:TextBox runat="server" ID="txtAllotmentLetterNo" Text="" ToolTip="AllotmentLetterNo"></asp:TextBox>
                                                                    <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" />
                                                                    <br />
                                                                    <br />
                                                                    <asp:GridView ID="gdvDue" runat="server" AutoGenerateColumns="false" DataKeyNames="TransactionId,Allotmentletterno"
                                                                        AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" OnRowCommand="gdvDue_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="S No.">
                                                                                <ItemTemplate>
                                                                                    <%#Container.DataItemIndex+1 %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Name" HeaderText="Allotee's Name" />
                                                                            <asp:TemplateField HeaderText="Due Date">
                                                                                <ItemTemplate>
                                                                                    <%# Convert.ToDateTime(Eval("DueDate")).ToString("dd/MM/yyyy") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="DueAmount" HeaderText="Due Amount" />
                                                                            <asp:BoundField DataField="MobileNo" HeaderText="Mobile" />
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    
                                                                                    <asp:Button runat="server" Text="Pay" ID="btnPay" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                                                                                    
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <EmptyDataTemplate>
                                                                            No Record Found.
                                                                        </EmptyDataTemplate>
                                                                    </asp:GridView>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- PAGE CONTENT ENDS -->
                                                    </div>
                                                    <!-- /.col -->
                                                </div>
                                                <!-- /.row -->
                                            </div>
                                            <!-- /.page-content -->
                                        </div>
                                    </div>
                                    <!-- /.main-content -->

                                </div>
                            </div>
                        </div>
                    </div>


                </div>


                    <div id="footer_id" runat="server"> <% Response.WriteFile("public_footer.aspx"); %> </div>  

                </div>

            </div>
        </div>
    </form>
</body>
</html>