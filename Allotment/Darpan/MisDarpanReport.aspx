<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MisDarpanReport.aspx.cs" Inherits="Allotment.Darpan.MisDarpanReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MisReport</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <style>

        .gridview {
    width: 100%; 
    word-wrap:break-word;
    table-layout: fixed;
}

    </style>
</head>
<body style="background-color:#ccc; color:#000; vertical-align:middle; padding:20px; text-align:center;">
    <form id="form1" runat="server">
        <div class="table" style="background-color:#ccc; color:#000; vertical-align:middle; width:100%; margin:0px; text-align:center;" >
            <table">
                <tr>
                    <td>
                        <asp:Image ID="Image1" CssClass="img-responsive" runat="server" ImageUrl="/images/top_header.jpg" style="background-color:#ccc; color:#000; vertical-align:middle; width:100%;" />
                    </td>
                </tr>
            </table>
            <h3><asp:Label ID="lblServiceType" Text="" runat="server"></asp:Label></h3>

        

            <asp:GridView ID="GridMisReportAll" class="table table-bordered table-condensed table-hover" runat="server" AutoGenerateColumns="false" Width="100%">
            
                 <Columns>
                <%--
                    <asp:TemplateField HeaderText="S.No." HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>              
                <ASP:HYPERLINKFIELD text="View" datanavigateurlfields="NM_District_ID"  datanavigateurlformatstring="Darpan/MisDarpanReport.aspx?DistrictId={0}"></ASP:HYPERLINKFIELD>--%>
                <asp:BoundField DataField="DistrictName" HeaderText="Office" ItemStyle-Width="15%" />
                <asp:BoundField DataField="TotalApplications" HeaderText="Total Applications" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="Completed" HeaderText="Application Approved" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="Rejected" HeaderText="Application Rejected" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="InTime" HeaderText="Application In Time(In Process)" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="OutTime" HeaderText="Application Out Time(In Process)" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" />
            </Columns>
            <HeaderStyle BackColor="#000000" Font-Bold="true" ForeColor="White" />
       </asp:GridView>
 
        
        <div class="table" style="background-color:#fff; color:#000; vertical-align:middle; margin:0px !important;" >
            <h4 style="padding:5px; margin:0px !important;" >
  <div class="row"  style="padding:0px !important; margin:0px !important;">
      <div class="col-md-2" style="text-align:left;"><asp:Label runat="server"><b>Total Count</b></asp:Label></div>
       <div class="col-md-2" style="text-align:left;">Total: <asp:HyperLink ID="hyperlink1"  Text="" runat="server" /></div>
       <div class="col-md-2" style="text-align:left;">Approved: <asp:HyperLink ID="hyperlink2"  Text="" runat="server" /></div>
       <div class="col-md-2" style="text-align:left;">Rejected: <asp:HyperLink ID="hyperlink3" Text="" runat="server" /></div>
       <div class="col-md-2" style="text-align:left;">In Process: <asp:HyperLink ID="hyperlink4" Text="" runat="server" /></div>
      <div class="col-md-2" style="text-align:left;">Our Process: <asp:HyperLink ID="hyperlink5" Text="" runat="server" /></div>
  </div>
                </h4>
       </div>
            <asp:Label ID="lblentreprenure" Text="" runat="server"></asp:Label>
        <asp:GridView ID="grdTotalApplications" runat="server" CssClass="gridview table table-striped table-bordered table-hover request-table request-table"
                            ClientIDMode="Static"
                            AutoGenerateColumns="true"                           
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
             <HeaderStyle BackColor="#000000" Font-Bold="false" ForeColor="White" />
                        </asp:GridView>
        </div>
       
    </form>
</body>
</html>
