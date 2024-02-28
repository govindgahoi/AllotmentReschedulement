<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewServicelineChecklist.aspx.cs" Inherits="Allotment.ViewServicelineChecklist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/Main.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/ajax-jquery-ui.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />
    <script src="js/ajax-jquery-min.js"></script>
    <script src="js/ajax-jquery-ui.js"></script>
    <script src="/js/jquery1.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script src="/js/jquery.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet" />
    <script src="js/chosen.jquery.min.js"></script>
    

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
    <script type="text/ecmascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();
        }

        function ErrorClose() {
            var divError = document.getElementById("divError");
            divError.style.display = "none";
        }
        function ShowTermsAndCondition() {
            $("#btnModalTerms").click();
        }
        function ChkValidVal() {

            var user_email = document.getElementById("txtUserName");
            var user_password = document.getElementById("txtPwd");
            var IsvalidEmail = 1;

            if (user_email.value == "") {

                alert("Please User ID.")
                return false;
            }

            if (user_password.value == "") {
                alert("Please enter password.");
                return false;
            }
        }
    </script>
</head>

<body id="pagewrap">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left">
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
            </div>
            <div class="row" id="SideDiv">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row well well-large offset4">
                                <div class="col-md-12 well well-large offset4" style="background: #ececec;">
                                    <p style="text-align: center" class="table-myspacing-z">
                                        <label>
                                            UPSIDC Provide the Below Mentioned Services to the Register Allottees.
                        All Service are Mandated Through Service Delivery Timeline to know.
                        The Documents Timeline for Prevailing to Service Please Click on Checklist
                                        </label>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 well well-large offset4">
                            <div>
                                <h5>Prerequisites</h5>
                                <p class="font-size12">Before filing for UPSIDC service, Please make sure that the listed below mandatory documents are readily available with you. Your application, once submitted will flow through the following status before the clearances/NOC’s is completed. You may use this information to track the status of your application </p>
                                <div class="panel panel-primary">
                                    <div class="">
                                        <h5>Checklists /mandatory Documents</h5>
                                    </div>
                                    <div class="panel-body" style="margin-top: 10px;">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView2" runat="server"
                                                CssClass="table table-striped table-bordered table-hover request-table"
                                                AllowSorting="True"
                                                AutoGenerateColumns="False"
                                                DataKeyNames="ServiceCheckListsID"
                                                GridLines="Horizontal" OnPageIndexChanging="GridView2_PageIndexChanging"
                                                OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound"
                                                Width="95%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblServiceCheckLists" Text='<%#Eval("ServiceCheckListsID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblServiceTimeLines" Text='<%#Eval("ServiceTimeLinesID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ServiceTimeLinesCondition" HeaderText="Documents Type" SortExpression="ServiceTimeLinesCondition" />
                                                    <asp:BoundField DataField="ServiceTimeLinesDocuments" HeaderText="Document Description" SortExpression="ServiceTimeLinesDocuments" />
                                                    <asp:TemplateField>
                                                        <HeaderStyle />
                                                        <HeaderTemplate>
                                                            <asp:Label ID="hlblimg" runat="server" Text="ChecklistDocument"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" Visible="false" usesubmitbehavior="true" Text='<i class="fa fa-download" aria-hidden="true"></i>' />
                                                            / 
                                    <asp:LinkButton ID="lbView1" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument" Visible="false" usesubmitbehavior="true" Text=''><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    No Record Available
                                                </EmptyDataTemplate>
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle Font-Bold="True" ForeColor="Black" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" HorizontalAlign="Left" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                            </asp:GridView>
                                            <%--<div class="modal fade" id="myModal" role="dialog" tabindex="-1">
                                                <div class="modal-dialog">
                                                    <!-- Modal content-->
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        </div>
                                                        <div class="modal-body">
                                                            <div class="scr" id="agreement" style="font-size: 12px; padding: 4px 15px; overflow: auto; height: 321px;">
                                                                <div class="panel">
                                                                    <div class="row">
                                                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                                                            <div class="panel-heading font-bold" style="text-align: center;">
                                                                                CheckList Viewer                        
                                                                            </div>

                                                                            <div class="bp-divviewer">
                                                                                <asp:Literal ID="ltEmbed" runat="server" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                    <div id="footer_id" runat="server"><% Response.WriteFile("public_footer.aspx"); %> </div>
                </div>
            </div>
        </div>
    </form>
</body>



</html>
