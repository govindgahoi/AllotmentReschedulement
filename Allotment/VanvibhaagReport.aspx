<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VanvibhaagReport.aspx.cs" Inherits="Allotment.VanvibhaagReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />
    <style>
        #GridView2 tr th {
            text-align: center;
        }
    </style>
</head>
<body>
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
            <!--<div class="row">
                <div class="col-md-12">
                    <div>
                        <div class="panel panel-default">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-6" style="margin-top: 12px;">
                                    <b>Allottee Master</b>
                                </div>
                                <div class="input-group col-md-4 col-sm-12" style="float: right; padding: 2px;">
                                    <asp:TextBox ID="txtSearch" Width="100%" CssClass="input-sm" runat="server" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged" />
                                    <span class="input-group-btn">
                                        <button class="btn btn-sm btn-primary" type="button">Search</button>
                                    </span>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                            </div>
                        </div>
                    </div>
                </div>

            </div>-->
            <div class="row" id="SideDiv">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row well well-large offset4">
                                <div class="col-md-6 well well-large offset4" style="background: #ececec;">
                                    <p style="text-align: center" class="table-myspacing-z">
                                        <label class="font-bold">Inspection Report for Falling trees within the industrial area limits </label>
                                    </p>
                                </div>
                                <div class="input-group col-md-4 col-sm-12" style="float: right; padding: 2px;margin-top: 5px;">
                                    <asp:TextBox ID="txtSearch1" Width="100%" CssClass="input-sm" runat="server" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged" />
                                    <span class="input-group-btn">
                                        <button class="btn btn-sm btn-primary" type="button" style="margin-right:0;"><i class="fa fa-search" style="color:#fff;"></i></button>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 well well-large offset4 well-minht">
                            <asp:GridView ID="GridView2" runat="server" OnRowDataBound="GridView2_RowDataBound"
                                AutoGenerateColumns="False" CellPadding="3" CssClass="table table-striped table-bordered table-hover request-table"
                                GridLines="Horizontal" OnPreRender="gridView_PreRender" OnRowCommand="gridView_RowCommand"
                                Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />

                                <Columns>
                                    <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="selectDocument" CommandArgument='<%#Eval("Industrial Area")%>' OnClientClick="return openInNewTab();"><i class="fa fa-file-pdf-o" style="font-size:25px; color:red;" aria-hidden="true"  ></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Industrial Area" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="30%" HeaderText="Name of Industrial Area" />
                                    <asp:BoundField DataField="Location Address" HeaderStyle-HorizontalAlign="Center" HeaderText="Location Address" />
                                    <asp:BoundField DataField="PlotNo" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30%"  HeaderText="Plot No" />
                                    <asp:BoundField DataField="PlotSize" HeaderStyle-HorizontalAlign="Center" HeaderText="Plot size (Square meter)" />
                                    <asp:BoundField DataField="Species of Trees" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="10%"  HeaderText="Species of Trees" />
                                    <asp:BoundField DataField="No of Trees" HeaderStyle-HorizontalAlign="Left" HeaderText="No of Trees According to Species at Plot" />
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
        <script type="text/javascript">
            function openInNewTab() {
                window.document.forms[0].target = '_blank';
                setTimeout(function () { window.document.forms[0].target = ''; }, 0);
            }
        </script>
    </form>
</body>
</html>
