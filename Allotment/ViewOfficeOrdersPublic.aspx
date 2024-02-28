<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewOfficeOrdersPublic.aspx.cs" Inherits="Allotment.ViewOfficeOrdersPublic" %>

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
    <link href="css/CssManu.css" rel="stylesheet" />
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" />
<link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.2.2/css/buttons.dataTables.min.css" />
<script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
<script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
<script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>
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

    <script type="text/javascript">
        $(document).ready(function () {
            $('[id*=GridView2]').prepend($("<thead></thead>").append($('[id*=GridView2]').find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 1000,
                buttons: [
                    { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                ]
            });
        });
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
                                <img class="img-responsive" src="https://www.onlineupsidc.com/OfcUser_pdf/upsida-logo-name.png"  />
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
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row well well-large offset4">
                                <div class="col-md-12 well well-large offset4" style="background: #ececec;">
                                    <p style="text-align: center" class="table-myspacing-z">
                                        <label class="font-bold">
                                        UPSIDA Office Orders
                                        </label>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 well well-large offset4">
                        <asp:GridView ID="GridView2" runat="server" 
                            AutoGenerateColumns="False" CellPadding="3" AllowPaging="false" DataKeyNames="ID,DocPath" ClientIDMode="Static" CssClass="table table-striped table-bordered table-hover request-table"
                            GridLines="Horizontal"
                            Width="100%"  BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" OnRowCommand="GridView2_RowCommand">
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />

                            <Columns>
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    <asp:BoundField DataField="OrderRefNo" ItemStyle-HorizontalAlign="Justify" HeaderText="Order Ref No" SortExpression="OrderRefNo"/>
                                 <asp:BoundField DataField="Category" ItemStyle-HorizontalAlign="Justify" HeaderText="Category" SortExpression="Category"/>    
                                <asp:BoundField DataField="IssueYear" HeaderText="Issue Year" SortExpression ="IssueYear" />   
                                    <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" SortExpression ="IssueDate" />
                                    <asp:BoundField DataField="Section" HeaderText="Section"  SortExpression ="Section" />
                                    <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDoc"  runat="server" Text="View/Download"  ToolTip="View Office Order" CommandArgument='<%# Eval("DocPath") %>' CommandName="ViewDoc" CausesValidation="false"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <HeaderStyle HorizontalAlign="center" BackColor="#efefef" Font-Bold="False" ForeColor="black" />
                            <AlternatingRowStyle BackColor="#F7F7F7" />
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
