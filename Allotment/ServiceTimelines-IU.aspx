<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="ServiceTimelines-IU.aspx.cs" 
     Inherits="Allotment.ServiceTimelinesIU" %>

<%--<%@ Register TagPrefix="CP" TagName="TitleBar" Src="~/WebUserControl1.ascx" %>
--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../css/index.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content">
        <div>
            <div class="row">
            <div class="col-md-12" style="background: #dbdbdb;">
                <div>
                <div style="width: 100px;float: left;background: #dbdbdb;font-size:11px;" class="text-center">
                    <br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li>
                            <a href="#">
                                <i class="fa fa-tachometer" aria-hidden="true"></i><br />Dashboard
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;font-size:11px;" class="text-center">
                    Operate<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li>
                            <a href="#">
                                <i class="fa fa-floppy-o " aria-hidden="true"></i><br />Save
                            </a>
                        </li> 
                        <li>
                            <a href="#">
                                <i class="fa fa-refresh" aria-hidden="true"></i><br />Refresh
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;border-right:1px solid #000;font-size:11px;" class="text-center">
                    Services<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                            <a href="#">
                                <i class="fa fa-plus" aria-hidden="true"></i><br />New
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <i class="fa fa-pencil-square-o" aria-hidden="true"></i><br />Drafted
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <i class="fa fa-th-list" aria-hidden="true"></i><br />Submitted
                            </a>
                        </li> 
                           
                        <li>
                            <a style="color:#21202080 !important;" href="#">
                                <i class="fa fa-credit-card" aria-hidden="true"></i><br />Track 
                            </a>
                        </li>
                      </ul>
                </div>
                 <div style="float: left;background: #dbdbdb;font-size:11px;" class="text-center">
                    Navigation<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                                <a style="color:#21202080 !important;" href="#">
                                    <i class="fa fa-step-backward" aria-hidden="true"></i><br />Last
                                </a>                        
                        </li>
                        <li>
                            <a href="#">
                                <i class="fa fa-angle-double-left" aria-hidden="true"></i><br />Previous
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <i class="fa fa-angle-double-right" aria-hidden="true"></i><br />Next
                            </a>
                        </li>
                        <li>
                            <a style="color:#21202080 !important;" href="#">
                                <i class="fa fa-step-forward" aria-hidden="true"></i><br />Final
                            </a>
                        </li>
                    </ul>
                    </div>
                     <div style="float: left;background: #dbdbdb;font-size:11px;border-left:1px solid #000;">
                        <br />
                        <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                            <li >
                                <a style="color:#21202080 !important;" href="#">
                                    <i class="fa fa-credit-card" aria-hidden="true"></i><br />Dues
                                </a>
                            </li>
                         </ul>
                    </div>
                     <div style="float: left;background: #dbdbdb;font-size:11px;border-left:1px solid #000;">
                        <br />
                        <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                            <a style="color:#21202080 !important;" href="#">
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


          <%--   <CP:TitleBar id="asdf" Title="User Control Test" TextColor="green" Padding=10 runat="server" />--%>





            <div class="row">
                <div class="col-md-12 left-heading">
                   <p class="my12font">UPSIDC provide the below mentioned services to the registred allottees.
                        All services are mandated through service delivery timelines.
                        Please click on checklist to know about timelines and cheklists else You can Apply Directly
                   </p>
                </div>
            </div>
            <table style="width: 100%;">
                <tr>
                    <td>

                <%--        OnSorting="GridView2_Sorting"--%>
                        <asp:GridView ID="GridView2" runat="server"  AllowSorting="True"
                            AutoGenerateColumns="False"  CellPadding="3" DataKeyNames="ServiceTimeLinesID" CssClass="table table-striped table-bordered table-hover request-table"
                            GridLines="Horizontal"
                            Width="100%"  BackColor="White"  BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" OnRowCommand="GridView2_RowCommand">
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />

                            <Columns>
                                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField  DataField="ServiceTimeLinesID" HeaderStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ServiceTimeLinesID"/>
                                <asp:BoundField DataField="ServiceTimeLinesDepartMent" HeaderStyle-HorizontalAlign="Center" HeaderText="Land Use Type" SortExpression="ServiceTimeLinesDepartMent" Visible="false" />
                                <asp:BoundField DataField="ServiceTimeLinesActivity" HeaderStyle-HorizontalAlign="Center" HeaderText="Service" SortExpression="ServiceTimeLinesActivity" />
                                <asp:BoundField DataField="ServiceTimeLines" HeaderStyle-HorizontalAlign="Center" HeaderText="RM/PO (in days)" SortExpression="ServiceTimeLines" />
                                 <asp:BoundField DataField="ServiceTimeLinesHOLevel" HeaderStyle-HorizontalAlign="Center" HeaderText="HQ (in days)" SortExpression="ServiceTimeLines" />
                                <asp:BoundField DataField="ServiceTimeLinesApprovingLevel" HeaderStyle-HorizontalAlign="Left" HeaderText="Approver" SortExpression="ServiceTimeLinesApprovingLevel" Visible="false" />
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgdocuments" CssClass="fa fa-check-square-o" runat="server" ImageUrl="~/images/checklist.png" ToolTip="View Checklist" CommandArgument='<%# Eval("ServiceTimeLinesID") %>'  CommandName="ViewDoc" CausesValidation="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgApply" Text="Apply Now" runat="server"  ImageUrl="~/images/Apply.png" ToolTip="Apply" CommandArgument='<%# Eval("ServiceTimeLinesID") %>' CommandName="ApplyRow" CausesValidation="false" />
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
</asp:Content>
