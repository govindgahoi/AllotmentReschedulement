<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="ServiceRequestSubmitted.aspx.cs" Inherits="Allotment.ServiceRequestSubmitted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
            <div class="col-md-12" style="background: #dbdbdb;">
                <div>
                <div style="width: 100px;float: left;background: #dbdbdb;font-size:11px;" class="text-center">
                    <br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li class="disabled">
                            <a href="#" class="disable">
                                <i class="fa fa-tachometer" aria-hidden="true"></i><br />Dashboard
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;font-size:11px;" class="text-center">
                    Operate<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-floppy-o " aria-hidden="true"></i><br />Save
                            </a>
                        </li> 
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-refresh" aria-hidden="true"></i><br />Refresh
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;border-right:1px solid #000;font-size:11px;" class="text-center">
                    Services<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                            <a href="ServiceTimelines.aspx" class="disable">
                                <i class="fa fa-plus" aria-hidden="true"></i><br />New
                            </a>
                        </li>
                        <li>
                            <a href="ServiceRequestDraft.aspx" class="disable">
                                <i class="fa fa-pencil-square-o" aria-hidden="true"></i><br />Drafted
                            </a>
                        </li>
                        <li>
                            <a href="ServiceRequestSubmitted.aspx" class="disable">
                                <i class="fa fa-th-list" aria-hidden="true"></i><br />Submitted
                            </a>
                        </li> 
                           
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-credit-card" aria-hidden="true"></i><br />Track 
                            </a>
                        </li>
                      </ul>
                </div>
                 <div style="float: left;background: #dbdbdb;font-size:11px;" class="text-center">
                    Navigation<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                                <a href="#" class="disable">
                                    <i class="fa fa-step-backward" aria-hidden="true"></i><br />Last
                                </a>                        
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-angle-double-left" aria-hidden="true"></i><br />Previous
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-angle-double-right" aria-hidden="true"></i><br />Next
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-step-forward" aria-hidden="true"></i><br />Final
                            </a>
                        </li>
                    </ul>
                    </div>
                     <div style="float: left;background: #dbdbdb;font-size:11px;border-left:1px solid #000;">
                        <br />
                        <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                            <li >
                                <a href="#" class="disable">
                                    <i class="fa fa-credit-card" aria-hidden="true"></i><br />Dues
                                </a>
                            </li>
                         </ul>
                    </div>
                     <div style="float: left;background: #dbdbdb;font-size:11px;border-left:1px solid #000;">
                        <br />
                        <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-database" aria-hidden="true"></i><br />Repository
                            </a>
                        </li>
                      </ul>
                 </div>
               <%--  <div style="float: left;background: #dbdbdb;font-size:11px;border-left:1px solid #000;font-size:11px;" class="text-center">
                     Administration<br />
                     <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li >                            
                            <a data-toggle="modal" data-target="#myModal1">
                                <i class="fa fa-sign-in" aria-hidden="true" ></i><br />Sign In
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <i class="fa fa-sign-out" aria-hidden="true"></i><br />Sign Out
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <i class="fa fa-sign-out" aria-hidden="true"></i><br />Password
                            </a>
                        </li>
                    </ul>
                  </div>--%>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    <div><code>Application Submmited</code>
        <asp:GridView ID="GridView2" runat="server"
           CssClass="table table-striped table-bordered table-hover request-table request-table"
            AllowPaging="True"
            AllowSorting="True"
            PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"
            AutoGenerateColumns="False"
            DataKeyNames="ServiceRequestNO"
            GridLines="Horizontal" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="20"
            OnRowDataBound="GridView2_RowDataBound"
            OnRowCommand="GridView2_RowCommand"
             OnSorting="GridView2_Sorting"
            OnRowDeleting="GridView2_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
      <%--   <ASP:HYPERLINKFIELD text="Process" datanavigateurlfields="ServiceRequestNO" datanavigateurlformatstring="BuildingPlan.aspx?serviceId={0}"></ASP:HYPERLINKFIELD>  
       <asp:TemplateField  HeaderText="Service Request">
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
                 <asp:BoundField DataField="Sttatus" HeaderText="Status" SortExpression="Sttatus" />
                <%--<asp:BoundField DataField="ApplicationType" HeaderText="Application Regarding" SortExpression="ApplicationType" />
                                    <asp:BoundField DataField="CaseType" HeaderText="Case" SortExpression="CaseType" />--%>
                <%-- <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/images/document_edit.png" ToolTip="Edit Record" CommandArgument="<%# Container.DataItemIndex %>" CommandName="EditRow" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgDel" runat="server" ImageUrl="~/images/document_delete.png" ToolTip="Delete Record" CommandArgument="<%# Container.DataItemIndex %>" CommandName="DeleteRow" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
