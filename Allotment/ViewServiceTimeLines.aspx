<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewServiceTimeLines.aspx.cs" Inherits="Allotment.ViewServiceTimeLines" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .hideGridColumn {
            display: none;
        }
    </style>
     <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />
    <style type="text/css">.hideGridColumn{display:none;}</style>
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
        function ErrorClose() {
            var divError = document.getElementById("divError");
            divError.style.display = "none";
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
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row well well-large offset4">
                                <div class="col-md-12 well well-large offset4" style="background: #ececec;">
                                    <p style="text-align: center" class="table-myspacing-z">
                                        <label class="font-bold">
                                            UPSIDC Provide the Below Mentioned Services to the Register Allottees.
                        All Service are Mandated Through Service Delivery Timeline to know.
                        The Documents Timeline for Prevailing to Service Please Click on Checklist</label>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 well well-large offset4">
                        <asp:GridView ID="GridView2" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3" DataKeyNames="ServiceTimeLinesID" 
                            CssClass="table table-striped table-bordered table-hover request-table"
                            GridLines="Horizontal"
                            Width="100%" OnSorting="GridView2_Sorting"  OnRowCommand="GridView2_RowCommand">
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <Columns>
                                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ServiceTimeLinesDepartMent" HeaderStyle-HorizontalAlign="Center" HeaderText="Land Use Type" SortExpression="ServiceTimeLinesDepartMent" Visible="false" />
                                <asp:BoundField DataField="ServiceTimeLinesActivity" HeaderStyle-HorizontalAlign="Center" HeaderText="Service" SortExpression="ServiceTimeLinesActivity" />
                                <asp:BoundField DataField="ServiceTimeLines" HeaderStyle-HorizontalAlign="Center" HeaderText="Service Time Line" SortExpression="ServiceTimeLines" />
                                <asp:BoundField DataField="ServiceTimeLinesHOLevel" HeaderStyle-HorizontalAlign="Center" HeaderText="HO Level" SortExpression="ServiceTimeLines" Visible="false" />
                                <asp:BoundField DataField="ServiceTimeLinesApprovingLevel" HeaderStyle-HorizontalAlign="Left" HeaderText="Approver" SortExpression="ServiceTimeLinesApprovingLevel" Visible="false" />
                                 <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgdocuments" CssClass="fa fa-check-square-o" runat="server" ImageUrl="~/images/checklist.png" ToolTip="View Checklist" CommandArgument='<%# Eval("ServiceTimeLinesID") %>' CommandName="ViewDoc" CausesValidation="false" />
                                        <asp:ImageButton ID="ImageButton1" CssClass="fa fa-check-square-o" runat="server" ImageUrl="~/images/Apply.png" ToolTip="Apply"   CommandName="Apply" CausesValidation="false" />

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
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
                            </div>
                    </div>
                    <div id="footer_id" runat="server"><% Response.WriteFile("public_footer.aspx"); %> </div>
                </div>

            </div>
        </div>
    </form>
</body>

</html>
