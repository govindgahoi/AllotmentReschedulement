<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="ServiceRequestInboxClose.aspx.cs" Inherits="Allotment.ServiceRequestClose" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-default"><div class="panel-heading">Complete-(Approve/Reject)</div>
        <div class="table-responsive"><asp:GridView ID="GridView2" runat="server"
             CssClass="table table-striped table-bordered table-hover request-table request-table"
            
            AllowSorting="True"
            AutoGenerateColumns="False"
            DataKeyNames="ServiceRequestNO"
            GridLines="Horizontal" OnPageIndexChanging="GridView2_PageIndexChanging" 
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
       
       <%-- <asp:TemplateField  HeaderText="Service Request">
        <ItemTemplate>
                <asp:HyperLink ID="ServiceRequestNO" runat="server" DataNavigateUrlFields="ServiceRequestNO" NavigateUrl='<%# "~/BuildingPlan.aspx?name={0}" %>' 
                        Text='<%# Eval("ServiceRequestNO") %>' ></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
              
                <asp:BoundField DataField="ServiceRequestID" ItemStyle-HorizontalAlign="Justify" HeaderText="ID" SortExpression="ServiceRequestID" />--%>
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
              <%--  <asp:BoundField DataField="AllotteeID" ItemStyle-HorizontalAlign="Justify" HeaderText="Allottee" SortExpression="AllotteeID" />
                <asp:BoundField DataField="ServiceTimeLinesID" HeaderText="Service ID" SortExpression="ServiceTimeLinesID" />--%>
                <asp:BoundField DataField="ServiceRequestDepartMent" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                <asp:BoundField DataField="ApplicationType" HeaderText="Application Regarding" SortExpression="ApplicationType" />
                <asp:BoundField DataField="CaseType" HeaderText="Case" SortExpression="CaseType" />
                <%--<asp:BoundField DataField="ApplicationType" HeaderText="Application Regarding" SortExpression="ApplicationType" />
                                    <asp:BoundField DataField="CaseType" HeaderText="Case" SortExpression="CaseType" />--%>
                <%-- <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/images/document_edit.png" ToolTip="Edit Record" CommandArgument="<%# Container.DataItemIndex %>" CommandName="EditRow" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                  <%--  <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgPrint" runat="server" ImageUrl="~/images/document_edit.png" ToolTip="Print" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Print" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>


                             <asp:TemplateField HeaderText="View">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/LetterView_ByServiceRequestNo.aspx?ServiceRequestNo={0}",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField>


                <asp:TemplateField HeaderText="Upload Your Signed Document" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
               <asp:LinkButton ID="lbView"     runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="Upload"  usesubmitbehavior="true" Text='<i class="fa fa-pencil-square-o" aria-hidden="true"></i>' /> 
                                </ItemTemplate></asp:TemplateField>
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




</asp:Content>
