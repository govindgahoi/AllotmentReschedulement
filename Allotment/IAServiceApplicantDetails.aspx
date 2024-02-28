<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IAServiceApplicantDetails.aspx.cs" Inherits="Allotment.IAServiceApplicantDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />
    <script src="js/jquery-ui.js"></script>
    <style>
        @media only screen and (max-width:992px) {
            .form-group label.text-right {
                text-align: left !important;
            }
        }

        table tr th[colspan="8"] {
            background: #bfbfbf !important;
        }

        .request-table tr .head-IAname {
            background: #ccc !important;
        }

        .request-table tr .head-region {
            background: #ccc !important;
        }

        .request-table tr .head-total {
            background: #656565 !important;
            color: #fff;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableViewState="true" AjaxFrameworkMode="Enabled" EnablePartialRendering="true">
        </asp:ScriptManager>
        <div class="form-group" style="background: #e6e6e6; padding: 4px 10px;">
            <div class="row">

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <ul class="pull-right list-inline">
                        <li>
                            <a runat="server" onclick="PrintElem()" style="cursor: pointer;">
                                <i style="font-size: 18px;" class="fa fa-print" aria-hidden="true"></i>
                            </a>
                        </li>
                        <li>
                            <a href="#" id="btnExport">
                                <i style="font-size: 18px;" class="fa fa-file-excel-o fa-fw"></i>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="clearfix"></div>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div id="DivP" style="text-align: center; padding: 15px 25px; margin: 25px 0%; background: #fbfbfb; border: 1px solid #ccc;">
                <div class="div-report" runat="server" style="text-align: center;">


                    <img src="images/upsidclogo.png" class="header-logo" style="border-top: none; height: 40px; margin-bottom: 0;" /><br>
                    <strong>U.P. STATE INDUSTRIAL DEVELOPMENT AUTHORITY LIMITED, KANPUR<br>
                        (Head Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024)</strong><br />
                    <br />

                    <div style="border-top: 3px solid #ffc511;">&nbsp;</div>
                    <asp:GridView ID="AllGrid" runat="server"
                        CssClass="table table-striped table-bordered table-hover request-table request-table"
                        AutoGenerateColumns="true"
                        DataKeyNames="ApplicationID"
                        GridLines="Horizontal"
                        Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
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
                    <br />
                    <br />
                    <br />
                    <br />
                    <div style="border-top: 3px solid #ffc511;">&nbsp;</div>
                    <div class="mail-disclaimer">
                        <p class="text-justify"><strong>Disclaimer:</strong>The information contained in this Report  is intended solely for the use of the individual or entity to whom it is addressed and others authorized to receive it. It may contain confidential or legally privileged information. If you are not the intended recipient you are hereby notified that any disclosure, copying, distribution or taking any action in reliance on the contents of this information is strictly prohibited and may be unlawful. If you have received this Report in error, please notify us immediately by responding at info[at]upsidc[dot]com  and then delete it from your system. In case of any query please contact us at info[at]upsidc[dot]com.</p>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>

<script type="text/javascript">

    function PrintElem() {

        Popup($('#DivP').html());
    }


    function Popup(data) {
        var mywindow = window.open('', 'my div', 'height=2000,width=1000');
        mywindow.document.write('<html><head><title style="font-weight:bold;">Janhit Report </title>');
        mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/bootstrap.min.css\" type=\"text/css\" />');
        mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/theme.css\" type=\"text/css\"  />');
        mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/print.css\" type=\"text/css\"  />');
        mywindow.document.write('</head><body >');
        mywindow.document.write(data);
        mywindow.document.write('</body></html>');

        setTimeout(function () {
            mywindow.print();
            mywindow.close();
        }, 1000);


        return true;
    }



</script>
</html>

