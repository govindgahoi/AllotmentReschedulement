<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBuildingPlanDocument.aspx.cs" Inherits="Allotment.ViewBuildingPlanDocument" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register assembly="ProudMonkey.Common.Controls" namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %> <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />
    <script src="js/ajax-jquery-min.js"></script>
    <script src="js/ajax-jquery-ui.js"></script>
    <script src="assets/js/bootstrap-datepicker.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <style type="text/css">
        .hideGridColumn {
            display: none;
        }
    </style>
    <style>
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

        #BuildingPlanGridView tr th {
            text-align:center;
        }
         #BuildingPlanGridView tr td {
            text-align:center;
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
        <asp:ScriptManager runat="server" ID="scriptmanager1"> </asp:ScriptManager>
         <cc1:MessageBox ID="MessageBox1" runat="server" /> 
         
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
                <div id="main_menu" runat="server"> <% Response.WriteFile("top_mainmenu.aspx"); %> </div> 
            </div>
            <div class="row" id="SideDiv">
                <div class="col-md-12">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="row well well-large offset4 well-minht">
                                <div class="col-md-12 well well-large offset4">
                                    <p style="text-align: center;margin-bottom:0;">
                                        <label><b>Disclosure of the UPSIDC Building Plan Releted Document</b> </label>
                                    </p>
                                </div>
                                <div class="col-md-12 well well-large offset4">
                                    <div class="form-group">
                                        <label class="col-md-2">
                                            <span style="color: Red">*</span>
                                            Industrial Area Name :
                                        </label>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="ddlArea" runat="server" style="margin-left:0;" AutoPostBack="true" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" Width="100%" CssClass="input-sm dropdown-toggle similar-select"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlArea" InitialValue="0"
                                                ErrorMessage="Select Industrial Area" ValidationGroup="ValidationButton" ToolTip=" Select Industrial Area"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3">                                            
                                            <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="e.g Allotment No,Plot No" style="margin-left:0;" Width="100%" CssClass="input-sm similar-select" onblur="Validateadhar()"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSearch"
                                                        ErrorMessage="Enter AllottmentLetter Number/Plot Number" ValidationGroup="ValidationButton" ToolTip="Can't be Empty"
                                                        ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="Col-md-4">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-primary ey-bg" ValidationGroup="ValidationButton" OnClick="btnSearch_Click" Style="padding: 5px 11px;" />
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-body gallery">
                                        <asp:Label ID="lblStatus1" runat="server" Text=""></asp:Label>
                                        <asp:GridView ID="BuildingPlanGridView" runat="server" AutoGenerateColumns="false" OnRowCommand="BuildingPlanGridView_RowCommand"
                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table">
                                            <Columns>
                                                <asp:BoundField DataField="ID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" HeaderText="" />
                                                <asp:TemplateField HeaderText="S.No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name of Allottee " >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'> 
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Allottment Letter Number">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAllottmentNumber" runat="server" Text='<%#Eval("AllottmentNumber") %>'> 
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%-- <asp:BoundField DataField="IndustrialArea"  HeaderText="Industrial Area"  />--%>
                                                <asp:BoundField DataField="PlotNo" HeaderText="Allotted Plot " />
                                                <asp:BoundField DataField="ColValue" HeaderText="Date " DataFormatString="{0:dd/MM/yyyy}" />
                                                <%-- <asp:TemplateField HeaderText="Document" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblColName" runat="server" Text='<%#Eval("ColName") %>'> 
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>

                                                <asp:TemplateField HeaderText="Certificate" >
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("ID") + ";" +Eval("ColName")%>'
                                                            CommandName="selectDocument" Text='<%#Eval("ColName") %>' OnClientClick="return openInNewTab();"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                            <%-- <EmptyDataTemplate>
                                                <span style="color: red">No Document Available For the Search Criteria Enter Above</span>
                                            </EmptyDataTemplate>--%>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div id="footer_id" runat="server"><% Response.WriteFile("public_footer.aspx"); %> </div>

                </div>

            </div>
        </div>
               
        <script type="text/javascript">
            function openInNewTab() {
                window.document.forms[0].target = '_blank';
                setTimeout(function () { window.document.forms[0].target = ''; }, 0);
            }
</script>
    </form>
</body>
</html>
