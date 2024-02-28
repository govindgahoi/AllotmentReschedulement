<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="ServicelineChecklist.aspx.cs" Inherits="Allotment.ServicelineChecklist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <link href="../css/index.css" rel="stylesheet" />--%>
      <style type="text/css">.hideGridColumn{display:none;}</style>
    <script>
        $(function () {
            $('#CheckBox1').click(function () {
                if ($(this).is(':checked')) {
                    $('#btnApply').removeAttr('disabled');
                } else {
                    $('#btnApply').attr('disabled', 'disabled');
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

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



        <div class="row">
            <div class="col-md-12">            
                <h5>Service Request</h5>
            </div>
        </div>
        <hr style="height: 1px; border-top: 1px solid #000000" />
        <h5 class="font-12px">Prerequisites</h5>
        <p class="font-12px">Before filing for UPSIDC service, Please make sure that the listed below mandatory documents are readily available with you. Your application, once submitted will flow through the following status before the clearances/NOC’s is completed. You may use this information to track the status of your application </p>
        <div class="panel panel-primary">
            <div class="panel-heading">Checklists /mandatory Documents</div>
            <div class="panel-body" style="margin-top: 10px;">
                <asp:GridView ID="ShowCheckList"  runat="server"
                    CssClass="table table-striped table-bordered table-hover request-table"
                    PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"
                    AllowPaging="True"
                    AllowSorting="True" 
                    AutoGenerateColumns="False" OnRowCommand="ShowCheckList_RowCommand"
                    DataKeyNames="ServiceCheckListsID,ServiceTimeLinesID"
                    GridLines="Horizontal" OnPageIndexChanging="ShowCheckList_PageIndexChanging" PageSize="8"
                    OnRowDataBound="ShowCheckList_RowDataBound"
                    Width="95%" OnSorting="ShowCheckList_Sorting"
                    OnSelectedIndexChanged="ShowCheckList_SelectedIndexChanged"
                    OnRowDeleting="ShowCheckList_RowDeleting">
                    
                    <Columns>
                         <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="ID" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                        <asp:BoundField HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn" DataField="Name" HeaderText="ID" SortExpression="ServiceCheckListsID"  />
                        <asp:BoundField HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn" DataField="ContentType" HeaderText="ID" SortExpression="ServiceCheckListsID"  />
                        <asp:BoundField HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn" DataField="Documents" HeaderText="ID" SortExpression="ServiceCheckListsID"  />
                  

                        <asp:BoundField HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn" DataField="ServiceCheckListsID" HeaderText="ID" SortExpression="ServiceCheckListsID"  />
                        <asp:BoundField DataField="ServiceTimeLinesCondition" HeaderText="Checklist" SortExpression="ServiceTimeLinesCondition" />
                        <asp:BoundField DataField="ServiceTimeLinesDocuments" HeaderText="Checklist Description" SortExpression="ServiceTimeLinesDocuments" />
                    
                  
                              <asp:TemplateField HeaderText="Document" ItemStyle-Width="150px" ItemStyle-CssClass="text-center text-center-imp">
                                                <ItemTemplate>
                                                    <asp:LinkButton usesubmitbehavior="true" ID="lbView" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" Text=''><i class="fa fa-download" aria-hidden="true"></i></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              
                        

                    </Columns>
                    <EmptyDataTemplate>
                        No Record Available
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle Font-Bold="True" ForeColor="Black" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <p>
                    <asp:CheckBox
                        ID="Conform_CheckBox_multiview_1"
                        runat="server"
                        Text="I hereby Declared & certify that the Allotetment Record are true and correct to the best of my knowledge. I understand that a false statement may disqualify me for benefits."
                        OnCheckedChanged="Conform_CheckBox_multiview_1_CheckChanged"
                        AutoPostBack="true"
                        Font-Names="Serif"
                        Font-Size="Medium" />
                </p>
            </div>
        </div>
        <div class="login-btn" style="margin-top: 10px">
            <asp:Button ID="btnApply" CssClass="btn-primary ey-bg" runat="server" Text="Apply Now" OnClick="btnLogin_Click" Enabled="false" />
        </div>
    </div>
    <%--<div >
        <div class="header">
            <h1 class="page-title">Service Request: Building Plan</h1>
                    <ul class="breadcrumb">
            <li><a href="index.html">Home</a> </li>
            <li class="active">Users</li>
        </ul>
        </div>
        <h5>Prerequisites</h5>
        <p>Before filing for UPSIDC service, Please make sure that the listed below mandatory documents are readily available with you. Your application, once submitted will flow through the following status before the clearances/NOC’s is completed. You may use this information to track the status of your application </p>
        <div class="row">
            <div class="col-sm-12">
                <div class="panel panel-default">
            <p class="panel-heading">Checklists /mandatory Documents</p>
            <div class="panel-body gallery">
                <div>
                    <div >
                        <h4 class="widget-title">Checklists /mandatory Documents</h4>
                    </div>
                    <div >
                        <div >
                            <div class="row">
                                <div class="col-sm-12">
                                    <ol>
                                        <li>Ownership documents: copies of allotment letter (transfer letter in case of transfer) possession certificate, the lease deed (transfer deed in case of transfer), and dimension plan issued by the Authority)</li>
                                        <li>Form for first application to erect, re-erect, or to make material alteration in a building <a href="#">(Appendix 1)</a></li>
                                        <li>Certificate prescribed in <a href="#">Appendix-2</a>  for undertaking the supervision by the licensed technical person.  Any change of the technical personnel during construction work shall be intimated to the Authorized Officer in writing.</li>
                                        <li>Structural stability certificate from the Architect/Structural Engineers as per <a href="#">Appendix-3</a>
                                        </li>
                                        <li>Certificate for sanction of Building Plan as per <a href="#">Appendix-4</a></li>
                                        <li>Indemnity bond as per <a href="#">Appendix-5</a> in case where basement is proposed to be   constructed on Rs.100/- stamp paper duly attested by a Notary</li>
                                        <li>Specification of proposed building as per <a href="#">Appendix-6</a> </li>
                                        <li>Application for drainage of premises as per <a href="#">Appendix-7 </a></li>
                                        <li>Photocopy of the registration of the licensed technical person as per <a href="#">Appendix-12</a>  duly authenticated with Plot No. for which it is submitted.</li>
                                        <li>Application form for water and sewer connection</li>
                                        <li>Photocopy of receipt of fees deposited, water and sewer connection charges, service connection and ramp charges and such other charges if any as required by the Authority from time to time.</li>
                                        <li>Three copies of drawings (one cloth mounted) duly signed by the Licensed Technical Person and Owner.</li>
                                        <li>Any other document as may be required by the Authority from time to time</li>
                                    </ol>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-xs-12">
                                    <p>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                        I hereby confirm that I have prepared all the documents mentioned above as suggested an I want to apply for the service requested above</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--<asp:GridView ID="GridView2" runat="server"
                                CssClass="table table-striped table-bordered table-hover"
                                AllowPaging="True"
                                AllowSorting="True"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceTimeLinesID"
                                GridLines="Horizontal" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="20"
                                OnRowDataBound="GridView2_RowDataBound"
                                OnRowCommand="GridView2_RowCommand"
                                Width="100%" OnSorting="GridView2_Sorting"
                                OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
                                OnRowDeleting="GridView2_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ServiceTimeLinesID" ItemStyle-HorizontalAlign="Justify" HeaderText="ID" SortExpression="ServiceTimeLinesID" Visible="false" />
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/images/document_edit.png" ToolTip="Edit Record" CommandArgument="<%# Container.DataItemIndex %>" CommandName="EditRow" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgDel" runat="server" ImageUrl="~/images/document_delete.png" ToolTip="Delete Record" CommandArgument="<%# Container.DataItemIndex %>" CommandName="DeleteRow" CausesValidation="false" />
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
                            </asp:GridView>--%>
    <%-- </div>
            </div>
        </div>
                <div >
                    
                </div>
            </div>
        </div>
        <div class="login-btn" style="margin-top: 10px">
            <asp:Button ID="btnLogin" CssClass="register" runat="server" Text="Apply Now" OnClick="btnLogin_Click"   />
        </div>
    </div>--%>
</asp:Content>
