<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="MISReportAllServiceWise.aspx.cs" Inherits="Allotment.MISReportAllServiceWise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "images/plus.png");
            $(this).closest("tr").next().remove();
        });
        //$(document).ready(function () {
        //    $("[src*=plus]").trigger("click");
        //});
        function PrintElem() {

            Popup($('#FinalPrint').html());
        }
        function PrintElemOffice() {

            Popup($('#PrintReginaloffice').html());
        }
        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=1000');
            mywindow.document.write('<html><head><title style="font-weight:bold;">Land Allotment Application</title>');
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr style="margin: 4px 0; border-top: 1px solid #d8d8d8;" />
    <div class="row">
        <div class="form-group" style="background: #dadada; padding: 2px 0; margin-bottom: 3px;">
            <div class="">
                <label class="col-md-2 col-sm-2 col-xs-12">
                    Regional Office :
                </label>
                <div class="col-md-4 col-sm-4 col-xs-12">
                    <asp:DropDownList runat="server" ID="ddloffice" Style="background: #fff;" CssClass="input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="Regional_Changed"></asp:DropDownList>
                </div>
                <label class="col-md-2 col-sm-1 col-xs-12">
                    Service Name :
                </label>
                <div class="col-md-4 col-sm-4 col-xs-12">
                    <asp:DropDownList runat="server" ID="ddlService" Style="background: #fff;" CssClass="input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="ddlService_SelectedIndexChanged">
                        <asp:ListItem Text="--ALL--" Value="ALL"></asp:ListItem>
                        <asp:ListItem Value="1003">Change Of Project</asp:ListItem>
                        <asp:ListItem Value="1004">Addition Of Product</asp:ListItem>
                        <asp:ListItem Value="1001">Request For Execution & Registration of Lease Deed </asp:ListItem>
                        <asp:ListItem Value="200">Online Payment of Reservation Money</asp:ListItem>
                        <asp:ListItem Value="1005">Request For Issuance Of NOC For Mortage</asp:ListItem>
                        <asp:ListItem Value="1006">Request For Issuance Of NOC For Joint Mortgage</asp:ListItem>
                        <asp:ListItem Value="1007">Request For Permission For Creation Of Second Charge</asp:ListItem>
                        <asp:ListItem Value="1011">Application for  Transfer of lease deed</asp:ListItem>
                        <asp:ListItem Value="1002">Application for  Time Extenstion Fee</asp:ListItem>
                        <asp:ListItem Value="4">Request for Transfer of Plot</asp:ListItem>
                        <asp:ListItem Value="1023">Request for No Dues Certificate</asp:ListItem>
                        <asp:ListItem Value="1027">Request for Outstanding dues position</asp:ListItem>
                        <asp:ListItem Value="1021">Request for legal heir after death</asp:ListItem>
                        <asp:ListItem Value="1017">Request for handover of lease deed to the lessee</asp:ListItem>
                        <asp:ListItem Value="1008">Request for reconstitution allottee firm / company</asp:ListItem>
                        <asp:ListItem Value="1014">Application for  Start of Production Certificate</asp:ListItem>
                        <asp:ListItem Value="1012">Application for Restoration of plot</asp:ListItem>
                        <asp:ListItem Value="1024">Request for Surrender of Plot</asp:ListItem>
                        <asp:ListItem Value="1025">Request for Establishment of Additional Unit</asp:ListItem>
                        <asp:ListItem Value="1026">Request for Subletting of Plot </asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <%-- <label class="col-md-2 col-sm-2 col-xs-12">
                    From Date :
                </label>
                <div class="col-md-4 col-sm-4 col-xs-12">
                    <asp:TextBox runat="server" ID="txtTransactionFromDate" Style="background: #fff;" CssClass="date1 input-sm similar-select1"></asp:TextBox>
                </div>
                <label class="col-md-2 col-sm-2 col-xs-12">
                    To Date :
                </label>
                <div class="col-md-4 col-sm-4 col-xs-12">
                    <asp:TextBox runat="server" ID="txtTransactionToDate" Style="background: #fff;" CssClass="date1 input-sm similar-select1"></asp:TextBox>
                </div>--%>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="col-md-12 col-sm-2 col-xs-12">
                    <asp:Button ID="btnFetch" runat="server" Text="Fetch" Style="padding: 2px 27px; margin: 10px 0;" CssClass="btn-primary ey-bg pull-right" OnClick="btnFetch_Click" />
                </div>

            </div>
            <div class="clearfix"></div>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="clearfix"></div>
            <hr class="myhrline" style="border-bottom: 1px solid #d8d8d8;" />
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div id="DivP" style="text-align: center; padding: 15px 25px; margin: 25px 0%; background: #fbfbfb; border: 1px solid #ccc;">
                <div class="div-report" runat="server" style="text-align: center;">
                    <img src="images/upsidclogo.png" class="header-logo" style="border-top: none; height: 40px; margin-bottom: 0;" /><br>
                    <strong>U.P. STATE INDUSTRIAL DEVELOPMENT AUTHORITY LIMITED, KANPUR<br>
                        (Head Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024)</strong><br />
                    <br />

                    <div style="border-top: 3px solid #ffc511;">&nbsp;</div>
                    <%-- CssClass="table table-striped table-bordered table-hover request-table request-table"--%>
                    <div class="bg-mywhite table-divinbox">
                        <div class="panel panel-default">
                            <span class="pull-right">
                                <a id="A1" runat="server" onclick="PrintElem()" style="cursor: pointer;">
                                    <i style="font-size: 18px;" class="fa fa-print" aria-hidden="true"></i>
                                </a>
                            </span>
                        </div>
                        <div style="overflow-x: auto; overflow-y: auto; max-height: 100%;" id="FinalPrint">
                            <h2 style='background-color: #4CAF50; text-align: center; font-size: 16px; color: #ffffff;'>Consolidated Statement of UPSIDA Citizen services Period from 01-10-2019 till
                             <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></h2>
                            <asp:GridView ID="GridView2" runat="server" OnRowCreated="GridViewWithDynamicHeader_RowCreated"
                                CssClass="table table-striped table-bordered table-hover request-table myreq-col"
                                AutoGenerateColumns="False"
                                DataKeyNames="RegionalOffice,Total_Received,Total_Pending,Total_Completed,Total_Rejection,Total_Objection,DAPending,RMPending,JEPending,AccountantPending,MOPending,AMPending,DMPending,CMIAPending,JMDPending,MDPending"
                                GridLines="Horizontal" OnRowDataBound="GridView2_RowDataBound"
                                Width="100%"
                                ItemStyle-Width="10%">
                                <Columns>
                                    <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="1%">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" Style="cursor: pointer" ImageUrl="~/images/plus.png" />
                                            <asp:Panel ID="pnlAllotmentRequest" runat="server" Style="display: none">
                                                <div id="PrintReginaloffice">
                                                    <span class="center-block"></span>
                                                    <span class="center-block"></span>
                                                    <h2 style='background-color: #4CAF50; text-align: center; font-size: 16px; color: #ffffff;'>
                                                        <asp:Label ID="ReginalOfficeName" runat="server" Text=""></asp:Label>Period from 01-10-2019 till
                                        <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></h2>
                                                    <asp:GridView ID="GridViewAllotmentRequest" runat="server" OnRowCreated="GridViewWithServiceHeader_RowCreated" AutoGenerateColumns="False" CssClass="request-table table table-hover table-bordered cm-table-heading myreq-col">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="ServiceTimelinesActivity" ItemStyle-Wrap="false" Visible="True" HeaderText="Service Name" SortExpression="ServiceTimelinesActivity" ItemStyle-Width="2%" />
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="Total_Received" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0},ReportType={1}&ServiceTimeLine={2}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"1",HttpUtility.UrlEncode(Eval("ServiceTimeLinesID").ToString())) %>' Text='<%# Eval("Total_Received").ToString()%>'> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="Total_Objection" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0},ReportType={1}&ServiceTimeLine={2}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"2",HttpUtility.UrlEncode(Eval("ServiceTimeLinesID").ToString())) %>' Text='<%# Eval("Total_Objection").ToString()%>'> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="Total_Completed" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0},ReportType={1}&ServiceTimeLine={2}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"3",HttpUtility.UrlEncode(Eval("ServiceTimeLinesID").ToString())) %>' Text='<%# Eval("Total_Completed").ToString()%>'> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="Total_Rejection" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0},ReportType={1}&ServiceTimeLine={2}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"4",HttpUtility.UrlEncode(Eval("ServiceTimeLinesID").ToString())) %>' Text='<%# Eval("Total_Rejection").ToString()%>'> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="Total_Pending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0},ReportType={1}&ServiceTimeLine={2}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"5",HttpUtility.UrlEncode(Eval("ServiceTimeLinesID").ToString())) %>' Text='<%# Eval("Total_Pending").ToString()%>'> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="DAPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0},ReportType={1}&ServiceTimeLine={2}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"6",HttpUtility.UrlEncode(Eval("ServiceTimeLinesID").ToString())) %>' Text='<%# Eval("DAPending").ToString()%>'> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="RMPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0},ReportType={1}&ServiceTimeLine={2}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"7",HttpUtility.UrlEncode(Eval("ServiceTimeLinesID").ToString())) %>' Text='<%# Eval("RMPending").ToString()%>'> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="JEPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0},ReportType={1}&ServiceTimeLine={2}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"8",HttpUtility.UrlEncode(Eval("ServiceTimeLinesID").ToString())) %>' Text='<%# Eval("JEPending").ToString()%>'> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="AccountantPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}&ServiceTimeLine={2}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"9",HttpUtility.UrlEncode(Eval("ServiceTimeLinesID").ToString())) %>' Text='<%# Eval("AccountantPending").ToString()%>'> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="MOPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}&ServiceTimeLine={2}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"10",HttpUtility.UrlEncode(Eval("ServiceTimeLinesID").ToString())) %>' Text='<%# Eval("MOPending").ToString()%>'> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="AMPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}&ServiceTimeLine={2}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"11",HttpUtility.UrlEncode(Eval("ServiceTimeLinesID").ToString())) %>' Text='<%# Eval("AMPending").ToString()%>'> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="DMPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}&ServiceTimeLine={2}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"12",HttpUtility.UrlEncode(Eval("ServiceTimeLinesID").ToString())) %>' Text='<%# Eval("DMPending").ToString()%>'> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="CMIAPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}&ServiceTimeLine={2}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"13",HttpUtility.UrlEncode(Eval("ServiceTimeLinesID").ToString())) %>' Text='<%# Eval("CMIAPending").ToString()%>'> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="JMDPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}&ServiceTimeLine={2}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"14",HttpUtility.UrlEncode(Eval("ServiceTimeLinesID").ToString())) %>' Text='<%# Eval("JMDPending").ToString()%>'> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="MDPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}&ServiceTimeLine={2}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"15",HttpUtility.UrlEncode(Eval("ServiceTimeLinesID").ToString())) %>' Text='<%# Eval("MDPending").ToString()%>'> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <%--<asp:BoundField DataField="Total_Received" ItemStyle-Wrap="false" Visible="True" HeaderText="Applications Received" SortExpression="Total_Received" ItemStyle-Width="2%" />
                                                            <asp:BoundField DataField="Total_Objection" HeaderText="Applications Under Objection" SortExpression="Total_Objection" ItemStyle-Width="2%" />
                                                            <asp:BoundField DataField="Total_Completed" HeaderText="Approved" SortExpression="Total_Completed" ItemStyle-Width="2%" />
                                                            <asp:BoundField DataField="Total_Rejection" HeaderText="Rejected" SortExpression="Total_Rejection" ItemStyle-Width="2%" />
                                                            <asp:BoundField DataField="Total_Pending" ItemStyle-Wrap="false" Visible="True" HeaderText="Total Pending" SortExpression="Total_Pending" ItemStyle-Width="2%" />
                                                            <asp:BoundField DataField="DAPending" HeaderText="Pending at DA" SortExpression="DAPending" ItemStyle-Width="2%" />
                                                            <asp:BoundField DataField="RMPending" HeaderText="Pending at RM" SortExpression="RMPending" ItemStyle-Width="2%" />
                                                            <asp:BoundField DataField="JEPending" HeaderText="Pending at JE" SortExpression="JEPending" ItemStyle-Width="2%" />
                                                            <asp:BoundField DataField="AccountantPending" HeaderText="Pending at Accountant" SortExpression="AccountantPending" ItemStyle-Width="2%" />
                                                            <asp:BoundField DataField="MOPending" HeaderText="Pending at MO" SortExpression="MOPending" ItemStyle-Width="2%" />
                                                            <asp:BoundField DataField="AMPending" HeaderText="Pending at AM" SortExpression="AMPending" ItemStyle-Width="2%" />
                                                            <asp:BoundField DataField="DMPending" HeaderText="Pending at DM" SortExpression="DMPending" ItemStyle-Width="2%" />
                                                            <asp:BoundField DataField="CMIAPending" HeaderText="Pending at CMIA" SortExpression="CMIAPending" ItemStyle-Width="2%" />
                                                            <asp:BoundField DataField="JMDPending" HeaderText="Pending at JMD" SortExpression="JMDPending" ItemStyle-Width="2%" />
                                                            <asp:BoundField DataField="MDPending" HeaderText="Pending at MD" SortExpression="MDPending" ItemStyle-Width="2%" />--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="RegionalOffice" ItemStyle-Wrap="false" Visible="True" HeaderText="Regional Office" SortExpression="RegionalOffice" ItemStyle-Width="2%" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="Total_Received" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"1") %>' Text='<%# Eval("Total_Received").ToString()%>'> </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="Total_Objection" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"2") %>' Text='<%# Eval("Total_Objection").ToString()%>'> </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="Total_Completed" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"3") %>' Text='<%# Eval("Total_Completed").ToString()%>'> </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="Total_Rejection" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"4") %>' Text='<%# Eval("Total_Rejection").ToString()%>'> </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="Total_Pending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"5") %>' Text='<%# Eval("Total_Pending").ToString()%>'> </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="DAPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"6") %>' Text='<%# Eval("DAPending").ToString()%>'> </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="RMPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"7") %>' Text='<%# Eval("RMPending").ToString()%>'> </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="JEPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"8") %>' Text='<%# Eval("JEPending").ToString()%>'> </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="AccountantPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"9") %>' Text='<%# Eval("AccountantPending").ToString()%>'> </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="MOPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"10") %>' Text='<%# Eval("MOPending").ToString()%>'> </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="AMPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"11") %>' Text='<%# Eval("AMPending").ToString()%>'> </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="DMPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"12") %>' Text='<%# Eval("DMPending").ToString()%>'> </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="CMIAPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"13") %>' Text='<%# Eval("CMIAPending").ToString()%>'> </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="JMDPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"14") %>' Text='<%# Eval("JMDPending").ToString()%>'> </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="MDPending" NavigateUrl='<%# string.Format("IAServiceApplicantDetails.aspx?RegionalOffice={0}&ReportType={1}",HttpUtility.UrlEncode(Eval("RegionalOffice").ToString()),"15") %>' Text='<%# Eval("MDPending").ToString()%>'> </asp:HyperLink>
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
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
