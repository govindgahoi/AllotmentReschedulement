<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceTimelinesp.aspx.cs" Inherits="Allotment.ServiceTimelinesp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main-content">
        <div>
            <div class="row">
                <div class="col-md-12 left-heading">
                    <h3>Service Timelines Details</h3>
                </div>
            </div>
            <table style="width: 100%;">
                <tr>
                    <td style="align: center">
                        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" OnDataBound = "OnDataBound" CellPadding="3" DataKeyNames="ServiceTimeLinesID" CssClass="table table-striped table-bordered table-hover"
                            GridLines="Horizontal" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="100" 
                            Width="100%" OnSorting="GridView2_Sorting" BackColor="White"  BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" OnRowCommand="GridView2_RowCommand">
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />

                            <Columns>
                               <%-- <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:BoundField  DataField="ServiceTimeLinesID" HeaderStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ServiceTimeLinesID"/>
                                <asp:BoundField DataField="ServiceTimeLinesDepartMent" HeaderStyle-HorizontalAlign="Center" HeaderText="Land Use Type" SortExpression="ServiceTimeLinesDepartMent" Visible="false" />
                                <asp:BoundField DataField="ServiceTimeLinesActivity" HeaderStyle-HorizontalAlign="Center" HeaderText="Service" SortExpression="ServiceTimeLinesActivity" />
                                <asp:BoundField DataField="ServiceTimeLines" HeaderStyle-HorizontalAlign="Center" HeaderText="RM/PO Level" SortExpression="ServiceTimeLines" />
                                 <asp:BoundField DataField="ServiceTimeLinesHOLevel" HeaderStyle-HorizontalAlign="Center" HeaderText="HQ Level" SortExpression="ServiceTimeLines" />
                                <asp:BoundField DataField="ServiceTimeLinesApprovingLevel" HeaderStyle-HorizontalAlign="Left" HeaderText="Approver" SortExpression="ServiceTimeLinesApprovingLevel" Visible="false" />

                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgdocuments" CssClass="fa fa-check-square-o" runat="server" ImageUrl="~/images/checklist.png" ToolTip="View Checklist" CommandArgument="<%# Container.DataItemIndex %>" CommandName="ViewDoc" CausesValidation="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgApply" Text="Apply Now" runat="server" Visible="false" ImageUrl="~/images/Apply.png" ToolTip="Apply" CommandArgument="<%# Container.DataItemIndex %>" CommandName="ApplyRow" CausesValidation="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <HeaderStyle HorizontalAlign="center"  BackColor="#efefef" Font-Bold="False" Font-Names="robotoregular" ForeColor="black" />
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                        </asp:GridView>
                    </td>
                </tr>

            </table>
        </div>

    </div>
    </form>
</body>
</html>
