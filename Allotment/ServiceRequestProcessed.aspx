<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="ServiceRequestProcessed.aspx.cs" Inherits="Allotment.ServiceRequestProcessed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div><code>In Process</code>
        <asp:GridView ID="GridView2" runat="server"
             CssClass="table table-striped table-bordered table-hover request-table request-table"
            AllowPaging="True"
            AllowSorting="True"
            AutoGenerateColumns="False"
            DataKeyNames="ServiceRequestNO"
            GridLines="Horizontal" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="20"
            OnRowDataBound="GridView2_RowDataBound"
            OnRowCommand="GridView2_RowCommand"
            Width="100%" OnSorting="GridView2_Sorting"
            OnRowDeleting="GridView2_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
        <ASP:HYPERLINKFIELD text="View" datanavigateurlfields="ServiceRequestNO" datanavigateurlformatstring="BPServiceRequestInbox.aspx?serviceId={0}"></ASP:HYPERLINKFIELD>  
     
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
             
                <asp:BoundField DataField="ServiceRequestDepartMent" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                <asp:BoundField DataField="ApplicationType" HeaderText="Application Regarding" SortExpression="ApplicationType" />
                <asp:BoundField DataField="CaseType" HeaderText="Case" SortExpression="CaseType" />
               
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




</asp:Content>
