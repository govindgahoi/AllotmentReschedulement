<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCompletionCertificate.aspx.cs" Inherits="Allotment.ViewCompletionCertificate" %>
                                                                                                                 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head" runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/CssManu.css" rel="stylesheet" />
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
<body>
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
                                <div class="col-md-12 well well-large offset4">
                                    <p style="text-align: center">
                                        <label>Disclosure of the UPSIDC Registerd Allotments </label>
                                    </p>
                                </div>
                                <div class="col-md-12 well well-large offset4">
                                    <p style="text-align: center">
                                        <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="Search Allotment No." Width="200px"></asp:TextBox>
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="fa-search" OnClick="btnSearch_Click"/>
                                    </p>
                                </div>
                                <div class="panel panel-default">                                   
                                    <div class="panel-body gallery">
                                        <asp:Label ID="lblStatus1" runat="server" Text=""></asp:Label>
                                        <asp:GridView ID="GridViewDocument" runat="server" AutoGenerateColumns="false" OnRowCommand="GridViewDocument_RowCommand"
                                AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover"
                                OnPageIndexChanging="OnPagingChange">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColName" runat="server" Text='<%#Eval("ColName") %>'> 
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# (Container.DataItemIndex)+1 %>'
                                                CommandName="selectDocument" Text='<%#Eval("ColName") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                </Columns>

                                <EmptyDataTemplate>
                                    No Record Available
                                </EmptyDataTemplate>
                            </asp:GridView>
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
