<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Service_WaterConnection.ascx.cs" Inherits="Allotment.UC_Service_WaterConnection" %>

<%@ Register assembly="ProudMonkey.Common.Controls" namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %>  
<%@ Register assembly="AjaxControlToolkit"  namespace="AjaxControlToolkit" tagprefix="asp" %>

    <cc1:MessageBox ID="MessageBox1" runat="server" /> 
      <cc1:confirmbox ID="ConfirmBox1" runat="server" /> 


        <div class="row">
            <div class="col-md-12">
                <div style="background: #dbdbdb;">
                <div style="width: 100px;float: left;background: #dbdbdb;font-size:11px;" class="text-center">
                    <br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li>
                            <a >
                                <i class="fa fa-tachometer" aria-hidden="true"></i><br />Dashboard
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;font-size:11px;" class="text-center">
                    Operate<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li>
                            <a  data-toggle="modal" data-target="#myModal">
                                <i class="fa fa-floppy-o " aria-hidden="true"></i><br />Save
                            </a>
                        </li> 
                        <li>
                            <a>
                                <i class="fa fa-refresh" aria-hidden="true"></i><br />Refresh
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;border-right:1px solid #000;font-size:11px;" class="text-center">
                    Services<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                            <a href="ServiceTimelines.aspx">
                                <i class="fa fa-plus" aria-hidden="true"></i><br />New
                            </a>
                        </li>
                        <li>
                            <a href="ServiceRequestDraft.aspx">
                               <i class="fa fa-pencil-square-o" aria-hidden="true"></i><br />Drafted
                            </a>
                        </li>
                        <li>
                            <a href="ServiceRequestSubmitted.aspx">
                                <i class="fa fa-th-list" aria-hidden="true"></i><br />Submitted
                            </a>
                        </li> 
                           
                        <li>
                            <a style="color:#21202080 !important;">
                                <i class="fa fa-credit-card" aria-hidden="true"></i><br />Track 
                            </a>
                        </li>
                      </ul>
                </div>
                 <div style="float: left;background: #dbdbdb;font-size:11px;" class="text-center">
                    Navigation<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                                <a style="color:#21202080 !important;" >
                                    <i class="fa fa-step-backward" aria-hidden="true"></i><br />Last
                                </a>                        
                        </li>
                        <li>
                            <a runat="server">
                                <i class="fa fa-angle-double-left" aria-hidden="true"></i><br />Previous
                            </a>
                        </li>
                        <li>
                            <a runat="server" id="linext" >
                                <i class="fa fa-angle-double-right" aria-hidden="true"></i><br />Next
                            </a>
                        </li>
                        <li>
                            <a style="color:#21202080 !important;">
                                <i class="fa fa-step-forward" aria-hidden="true"></i><br />Final
                            </a>
                        </li>
                    </ul>
                    </div>
                     <div style="float: left;background: #dbdbdb;font-size:11px;border-left:1px solid #000;">
                        <br />
                        <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                            <li >
                                <a style="color:#21202080 !important;">
                                    <i class="fa fa-credit-card" aria-hidden="true"></i><br />Dues
                                </a>
                            </li>
                         </ul>
                    </div>
                     <div style="float: left;background: #dbdbdb;font-size:11px;border-left:1px solid #000;">
                        <br />
                        <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                            <a style="color:#21202080 !important;">
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


    <br />

      <div class="modal fade"  id="myModal" role="dialog">
    <div class="modal-dialog">
 
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Confirmation</h4>
        </div>
        <div class="modal-body">
     <div class="col-md-12" style="font-size:12px;padding: 4px 15px;">This Is Final Submittion. Kindly Check the Documents Uploaded After This Your Application Is Submitted to UPSIDC Regional Office</div>
<div class="clearfix"></div>
        </div>
        <div class="modal-footer">
            <div class="pull-right border-buttons">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-sm btn-primary btn-popup" style="margin-right: 3px;" Text="Submit" OnClick="Save_ServerClick"/><button type="button" class="btn btn-primary btn-popup" data-dismiss="modal" style="margin-right:0;">Close</button></div>
        </div>
      </div>
      
    </div>
  </div>
    <asp:MultiView ID="MultiViewBuildingPlan" runat="server">
        <asp:View ID="PreRequest" runat="server">
            <div class="panel panel-default">
                <div class="panel-heading" style="width: 100%;">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                <div class="btn-group">
                                    <asp:Button ID="btnPrevious" runat="server" CssClass="btn btn-primary register " Text="Previous" Enabled="false" />
                                    <asp:Button ID="btnNext" CssClass="btn btn-primary register " runat="server" OnClick="Next_Click" Text="Next" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <p><b>Pre Requisite</b></p>
                            </div>
                            <div class="col-md-4">
                                <div class="btn-group">
                                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary register " runat="server" OnClick="btnSubmit_Click" Text="Save" />
                                    <asp:Button ID="btnReset" CssClass="btn btn-primary register " runat="server" Text="Reset" Enabled="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container-fluid">
                    <!-- Breadcrumbs-->
                    <div class="breadcrumb">
                    </div>

                </div>
                <div class="panel-body gallery">
                    <table class="table table-striped table-bordered table-hover">
                        <tr style="display:none;">
                            <td colspan="4" align="left">
                                <span>Executive authority to intimate:</span>
                                <asp:Label ID="lblAuthority" runat="server" Text=""></asp:Label>
                                <span>Email ID:</span>
                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                <span>Phone No:</span>
                                <asp:Label ID="lblPhoneNumber" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <span style="color: Red">*</span>
                                Date of lease deed :
                            </td>
                            <td>
                                <asp:TextBox ID="txtLeaseDeed" runat="server" class="form-control" Width="250px" Enabled="false"></asp:TextBox>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr id="lableMessage" runat="server" visible="false">
                            <td align="left" colspan="4">
                                <span style="color: Red">Your LeaseDeed Details are not Available with us .Kindly Raise a Request to UPSIDE to Update the Records For Your Leased</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">Application Nature 
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2"><span style="color: Red">*</span>Application Type </td>
                            <td>
                                <asp:DropDownList ID="ddlApplication" runat="server"></asp:DropDownList>
                            </td>
                            <td class="auto-style2"><span style="color: Red">*</span>Case Type :</td>
                            <td>
                                <asp:DropDownList ID="ddlCaseType" runat="server"></asp:DropDownList>
                                <asp:Label ID="lblArea" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="lblserRequest" runat="server" ></asp:Label>
                    <asp:Label ID="lblServiceRequestID" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
        </asp:View>





           <asp:View ID="Checklist" runat="server">
            <div class="panel panel-default">
                <div class="panel-heading" style="width: 100%;">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4 btn-group">
                                <div class="btn-group">
                                    <asp:Button ID="Previous2" Enabled="false" runat="server" CssClass="btn btn-primary register " Text="Previous" OnClick="Previous2_Click" Style="display:none;" />
                                    <asp:Button ID="btnNext2" Enabled="false" CssClass="btn btn-primary register " runat="server" OnClick="Next2_Click" Text="Next" Style="display:none;" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <p><b>Application Checklist</b></p>
                            </div>
                            <div class="col-md-4">
                                <div class="btn-group">
                                    <asp:Button ID="btnSave" CssClass="btn btn-primary register " runat="server" OnClick="btnSubmmited_Click" Text="Save" Style="display:none;"  />
                                    <asp:Button ID="btnReset1"  CssClass="btn btn-primary register " runat="server" Text="Reset" Enabled="false" Style="display:none;" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-body gallery">
                    <asp:GridView ID="GridView2" runat="server"
                        CssClass="table table-striped table-bordered table-hover request-table"
                        AllowPaging="True"
                        AutoGenerateColumns="False"
                        DataKeyNames="ServiceCheckListsID"
                        GridLines="Horizontal" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="10"
                        OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound"
                        Width="95%"
                        OnRowDeleting="GridView2_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblServiceCheckLists" Text='<%#Eval("ServiceCheckListsID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblServiceTimeLines" Text='<%#Eval("ServiceTimeLinesID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ServiceTimeLinesCondition" HeaderText="Documents Type" SortExpression="ServiceTimeLinesCondition" />
                            <asp:BoundField DataField="ServiceTimeLinesDocuments" HeaderText="Document Description" SortExpression="ServiceTimeLinesDocuments" />
                            <asp:TemplateField HeaderText="Action">
                                <HeaderStyle HorizontalAlign="Left" />
                               
                                <ItemTemplate>

                                      <span class="col-md-10"><asp:FileUpload ID="FileUpload4" runat="server" /></span><span class="col-md-2"><asp:LinkButton ID="imgdocuments" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="Upload" Text='<i class="fa fa-upload" aria-hidden="true"></i>' /></span>
                                    

                                  </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle />
                                <HeaderTemplate>
                                    <asp:Label ID="hlblimg" runat="server" Text=""></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" Text='<i class="fa fa-download" aria-hidden="true"></i>' />
                                    <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="Delete" Text='<i class="fa fa-times" aria-hidden="true"></i>' />
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
        </asp:View>



        <asp:View ID="View1" runat="server">
            <div runat="server" id="building_plan" class="panel panel-default">
                <div class="panel-heading" style="width: 100%;">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4 btn-group">
                                <div class="btn-group">
                                    <asp:Button ID="Previous1" runat="server" CssClass="btn btn-primary register " Text="Previous" OnClick="Previous1_Click" />
                                    <asp:Button ID="btnNext1" CssClass="btn btn-primary register " runat="server" OnClick="Next1_Click" Text="Next" />

                                </div>
                            </div>
                            <div class="col-md-4">
                                <p><b>Architect/Structural Engineer Detail</b></p>
                            </div>
                            <div class="col-md-4">
                                <div class="btn-group">
                               <%--     <asp:Button ID="btnSaveApplicant" CssClass="btn btn-primary register " runat="server" OnClick="btnSaveBuildingSpec_Click" Text="Save" />--%>
                                    <asp:Button ID="Button4" CssClass="btn btn-primary register " runat="server" Text="Reset" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-body gallery">
                    <table class="table table-striped table-bordered table-hover" style="width: 98%">
                        <tr>
                            <td colspan="4">Application Nature 
                            </td>
                        </tr>

                        <tr>
                            <td colspan="4">Architect Detail
                            </td

                        </tr>

                        <tr>
                            <td class="auto-style2"><span style="color: Red">*</span>Name of Architect </td>
                            <td>
                                <asp:TextBox ID="txtNameTechnical" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style2"><span style="color: Red">*</span>Architect Licensed No :</td>
                            <td>
                                <asp:TextBox ID="txtLicensedPerson" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2"><span style="color: Red">*</span>Architect Registration No </td>
                            <td>
                                <asp:TextBox ID="txtRegistration" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style2"><span style="color: Red">*</span>Address of Architect:</td>
                            <td>
                                <asp:TextBox ID="txtAddressPerson" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">Structural Engineer Detail
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2"><span style="color: Red">*</span>Name of Structural Engineer </td>
                            <td>
                                <asp:TextBox ID="txtStructuralEngineer" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style2"><span style="color: Red">*</span>Structural Engineer Licensed No :</td>
                            <td>
                                <asp:TextBox ID="txtStructuralEngineerLicensedNo" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2"><span style="color: Red">*</span>Structural Engineer Registration No </td>
                            <td>
                                <asp:TextBox ID="txtStructuralEngineerRegistratinNo" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style2"><span style="color: Red">*</span>Address of Structural Engineer:</td>
                            <td>
                                <asp:TextBox ID="txtStructuralEngineerAddress" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>
        </asp:View>
     
        <asp:View ID="View3" runat="server">
            <div class="panel panel-default">
                <div class="panel-heading" style="width: 100%;">
                    <div class="row">
                        <div class="col-md-12">

                            <div class="col-md-2">
                                <div class="btn-group">
                                    <asp:Button ID="Previous3" runat="server" CssClass="register btn btn-primary" Text="Previous" OnClick="Previous3_Click" />
                                    <asp:Button ID="btnNext3" CssClass="register btn btn-primary" runat="server" OnClick="Next3_Click" Text="Next" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <p><b><asp:Label ID="lblHead" runat="server" Text=""></asp:Label></b></p>
                            </div>
                            <div class="col-md-6 btn-group">
                                <div class="btn-group">
                                    <asp:Button ID="btnRisk" CssClass="register btn btn-primary" runat="server" Text="Risk Assessment" />
                                    <asp:Button ID="btnInspection" CssClass="register btn btn-primary " runat="server" Text="Initiate Inspection" />
                                    <asp:Button ID="btnFar" CssClass="register btn btn-primary" runat="server" OnClick="btnFar_Click" Text="Save" />
                                    <asp:Button ID="Button12" CssClass="btn btn-primary register " runat="server" Text="Reset" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-body gallery">
                    <div align="left">
                        <span >Plot Size :</span>
                        <asp:Label ID="lblPlotSize" runat="server" Text="Label"></asp:Label>
                    </div>

                    <div class="table-responsive">
                        <table class="table table-bordered" id="datatableService" width="100%" cellspacing="0">
                            <thead>
                                <tr>
                                    <th style="width:150px">Description</th>
                                    <th>Byelaws </th>
                                    <th>Unit</th>
                                    <th   id="RM">RM</th>
                                    <th   id="JE " >JE /Assistence</th>
                                    <th   id="AssistenceManager" >Assistence Manager</th>
                                    <th   id="Manage" >Manager</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>FAR(in Percentage)</td>
                                    <td>
                                        <asp:Label ID="lblFarByelaws" runat="server" ></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFar" CssClass="form-control" runat="server" Width="80px"></asp:TextBox>
                                    </td>
                                   
                                    <td style="<%= HiddenClassRM %>">
                                        <asp:DropDownList ID="ddlFarByelaws" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>

                                    </td>
                                    <td style="<%= HiddenClassAssistence %>">
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                               
                                    <td style="<%= HiddenClassAssistenceManager %>">
                                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                          <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="<%= HiddenClassManager %>">
                                        <asp:DropDownList ID="DropDownList4" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                           <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td>Ground Coverage (in Percentage)</td>
                                    <td>
                                        <asp:Label ID="lblGroundBylo" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGroundcover" class="form-control" runat="server" Width="80px"></asp:TextBox>
                                    </td>
                                    <td style="<%= HiddenClassRM %>">
                                        <asp:DropDownList ID="ddlGroundcover" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="<%= HiddenClassAssistence %>">
                                        <asp:DropDownList ID="DropDownList5" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                           <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                            
                                     <td style="<%= HiddenClassAssistenceManager %>">
                                        <asp:DropDownList ID="DropDownList7" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                     <td style="<%= HiddenClassManager %>">
                                        <asp:DropDownList ID="DropDownList8" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td >Height(In mts)</td>
                                    <td>
                                        <asp:Label ID="lblHeight" runat="server" Text="N/A"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHeight" class="form-control" runat="server" Width="80px"></asp:TextBox>
                                    </td>
                                    <td style="<%= HiddenClassRM %>">
                                        <asp:DropDownList ID="DropDownList25" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                           <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="<%= HiddenClassAssistence %>">
                                        <asp:DropDownList ID="DropDownList26" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                             <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                            
                                     <td style="<%= HiddenClassAssistenceManager %>">
                                        <asp:DropDownList ID="DropDownList28" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                     <td style="<%= HiddenClassManager %>">
                                        <asp:DropDownList ID="DropDownList29" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                           <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                      
                                <tr>
                                    <td colspan="8" align="left">Set Back(In mts)</td>
                                </tr>
                                <tr>
                                    <td align="right">front</td>
                                    <td>
                                        <asp:Label ID="lblSetBackFront" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSetBackFront" class="form-control" runat="server" Width="80px"></asp:TextBox>
                                    </td>
                                    <td style="<%= HiddenClassRM %>">
                                        <asp:DropDownList ID="DropDownList9" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="<%= HiddenClassAssistence %>">
                                        <asp:DropDownList ID="DropDownList10" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                 

                                     <td style="<%= HiddenClassAssistenceManager %>">
                                        <asp:DropDownList ID="DropDownList12" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                     <td style="<%= HiddenClassManager %>">
                                        <asp:DropDownList ID="DropDownList45" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                             <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">Rear
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSetBackRear" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSetBackRear" class="form-control" runat="server" Width="80px"></asp:TextBox>
                                    </td>
                                    <td style="<%= HiddenClassRM %>">
                                        <asp:DropDownList ID="DropDownList13" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="<%= HiddenClassAssistence %>">
                                        <asp:DropDownList ID="DropDownList14" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                          <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                 
                                     <td style="<%= HiddenClassAssistenceManager %>">
                                        <asp:DropDownList ID="DropDownList16" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                             <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                     <td style="<%= HiddenClassManager %>">
                                        <asp:DropDownList ID="DropDownList46" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">Side1</td>
                                    <td>
                                        <asp:Label ID="lblSetBackSide1" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSetBackSide1" class="form-control" runat="server" Width="80px"></asp:TextBox>
                                    </td>
                                    <td style="<%= HiddenClassRM %>">
                                        <asp:DropDownList ID="DropDownList17" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="<%= HiddenClassAssistence %>">
                                        <asp:DropDownList ID="DropDownList18" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                              
                                     <td style="<%= HiddenClassAssistenceManager %>">
                                        <asp:DropDownList ID="DropDownList20" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                     <td style="<%= HiddenClassManager %>">
                                        <asp:DropDownList ID="DropDownList47" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">Side2</td>
                                    <td>
                                        <asp:Label ID="lblSetBackSide2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSetBackSide2" class="form-control" runat="server" Width="80px"></asp:TextBox>
                                    </td>
                                    <td style="<%= HiddenClassRM %>">
                                        <asp:DropDownList ID="DropDownList21" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="<%= HiddenClassAssistence %>">
                                        <asp:DropDownList ID="DropDownList22" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                  
                                     <td style="<%= HiddenClassAssistenceManager %>">
                                        <asp:DropDownList ID="DropDownList24" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                     <td style="<%= HiddenClassManager %>">
                                        <asp:DropDownList ID="DropDownList48" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8" align="left">Classification of Indiustries Based on Degree of Hazard</td>
                                </tr>

                                            <tr>
                                    <td>Classification of Hazard</td>
                                    <td colspan="2">
                                    
                                        <asp:DropDownList ID="ddlNature" runat="server" CssClass="btn btn-default dropdown-toggle" Width="200px">
                                            <asp:ListItem Text="Dealing with Chemical ,Inflammable and explosives"  Value="Dealing with Chemical ,Inflammable and explosives" />
                                            <asp:ListItem Text="High rise buildings(Hospitals/malls/Hotels)" Value="High rise buildings(Hospitals/malls/Hotels)" />
                                            <asp:ListItem Text="Other" Value="Other" />
                                        </asp:DropDownList>

                                     </td>
                                    <td style="<%= HiddenClassRM %>">
                                        <asp:DropDownList ID="ddlRrmApprroval" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="<%= HiddenClassAssistence %>">
                                        <asp:DropDownList ID="DropDownList36" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                               
                                     <td style="<%= HiddenClassAssistenceManager %>">
                                        <asp:DropDownList ID="DropDownList38" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                             <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                     <td style="<%= HiddenClassManager %>">
                                        <asp:DropDownList ID="DropDownList39" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                             <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                        
                                  <tr>
                                    <td>Occupancy</td>
                                              <td colspan="2">


                                                   <asp:TextBox ID="txtOccupancy" CssClass="form-control" Width="200px" runat="server"></asp:TextBox>


                                     </td>
                                    <td style="<%= HiddenClassRM %>">
                                        <asp:DropDownList ID="DropDownList50" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="<%= HiddenClassAssistence %>">
                                        <asp:DropDownList ID="DropDownList51" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                            <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                 
                                     <td style="<%= HiddenClassAssistenceManager %>">
                                        <asp:DropDownList ID="DropDownList53" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                             <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                     <td style="<%= HiddenClassManager %>">
                                        <asp:DropDownList ID="DropDownList54" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                             <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                            <asp:ListItem Value="1">Permissibile</asp:ListItem>
                                            <asp:ListItem Value="2"> Not Permissibile</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="8" align="left">Service Document
                                    </td>
                                </tr>
                                <tr>
                                    <asp:GridView ID="GridViewService" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" ShowHeader="false" OnRowCommand="GridViewService_RowCommand" Width="100%">
                                        <Columns>
                                            <asp:TemplateField  ItemStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_ServiceTimeLines" runat="server" Text='<%# Eval("ServiceTimeLinesCondition") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="220px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" Text=''>View</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="120px"  >
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlRmVerified" runat="server"  CssClass="btn btn-default dropdown-toggle" Width="120px">
                                                        <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                                        <asp:ListItem Value="1">Verified</asp:ListItem>
                                                        <asp:ListItem Value="2">Some Issued</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="120px" >
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlJEVerified" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                                        <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                                        <asp:ListItem Value="1">Verified</asp:ListItem>
                                                        <asp:ListItem Value="2">Some Issued</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="120px" >
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlDraftManVerified" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                                        <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                                        <asp:ListItem Value="1">Verified</asp:ListItem>
                                                        <asp:ListItem Value="2">Some Issued</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="120px" >
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlAssistanceVerified" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                                        <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                                        <asp:ListItem Value="1">Verified</asp:ListItem>
                                                        <asp:ListItem Value="2">Some Issued</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="120px" >
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlManagerVerified" runat="server" CssClass="btn btn-default dropdown-toggle" Width="120px">
                                                        <asp:ListItem Value="0">-Choose-</asp:ListItem>
                                                        <asp:ListItem Value="1">Verified</asp:ListItem>
                                                        <asp:ListItem Value="2">Some Issued</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <%--<asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" ForeColor="#333333">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:CommandField ShowEditButton="True" />
                            <asp:TemplateField HeaderText="Total Plot Area (in Sqmts)" InsertVisible="False" SortExpression="sno">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPlotArea" runat="server" Text=''></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BaseMent(in Sqmts)" SortExpression="parameters">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtBaseMent1" runat="server" Text=''></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BaseMent(in Sqmts)" SortExpression="unit">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtBaseMent2" runat="server" Text=''></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ground Floor(in Sqmts)" SortExpression="spval">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGround1" runat="server" Text=''></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="torval" SortExpression="torval">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text=''></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="obtval" SortExpression="obtval">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text=''></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>--%>
                    <%--<table class="table table-striped table-bordered table-hover" style="width: 98%">
                        <tr>
                            <td class="auto-style2"><span style="color: Red">*</span>Total Plot Area (in Sqmts).</td>
                            <td>
                                <asp:TextBox ID="txtPlotArea" CssClass="form-control" Width="250px" runat="server"></asp:TextBox></td>
                            <td colspan="2"></td>
                        </tr>
                        <tr style="text-align: center">
                            <td colspan="2">
                                <b>Existing</b>
                            </td>
                            <td colspan="2">
                                <b>Proposed</b>
                            </td>
                        </tr>


                        <tr>
                            <td class="auto-style2">BaseMent(in Sqmts)</td>
                            <td>
                                <asp:TextBox ID="txtBaseMent1" CssClass="form-control" Width="250px" runat="server"></asp:TextBox></td>

                            <td class="auto-style2">BaseMent(in Sqmts)</td>
                            <td>
                                <asp:TextBox ID="txtBaseMent2" CssClass="form-control" Width="250px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Ground Floor(in Sqmts)</td>
                            <td>
                                <asp:TextBox ID="txtGround1" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style2">Ground Floor(in Sqmts)</td>
                            <td>
                                <asp:TextBox ID="txtGround2" CssClass="form-control" Width="250px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">First Floor(in Sqmts)</td>
                            <td>
                                <asp:TextBox ID="txtFirstfloor1" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style2">First Floor(in Sqmts)</td>
                            <td>
                                <asp:TextBox ID="txtFirstfloor2" CssClass="form-control" Width="250px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Second Floor(in Sqmts)</td>
                            <td>
                                <asp:TextBox ID="txtSecondFloor1" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style2">Second Floor(in Sqmts)</td>
                            <td>
                                <asp:TextBox ID="txtSecondFloor2" CssClass="form-control" Width="250px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Mezzanine Floor(in Sqmts)</td>
                            <td>
                                <asp:TextBox ID="txtMezzanine1" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style2">Mezzanine Floor(in Sqmts)</td>
                            <td>
                                <asp:TextBox ID="txtMezzanine2" CssClass="form-control" Width="250px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <b>Purpose/Intention to Use Building</b>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Foundation</td>
                            <td>
                                <asp:TextBox ID="txtFoundation" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style2">Walls(in Sqmts)</td>
                            <td>
                                <asp:TextBox ID="txtWalls" CssClass="form-control" Width="250px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Floors</td>
                            <td>
                                <asp:TextBox ID="txtFloors" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style2">Roofs</td>
                            <td>
                                <asp:TextBox ID="txtRoofs" CssClass="form-control" Width="250px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">No of Stories</td>
                            <td>
                                <asp:TextBox ID="txtStories" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style2">Occupancy</td>
                            <td>
                                <asp:TextBox ID="txtOccupancy" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">No of Latrines</td>
                            <td>
                                <asp:TextBox ID="txtLatrines" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style2">Height</td>
                            <td>
                                <asp:TextBox ID="txtHeight" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                        </tr>
                    </table>--%>
                </div>
            </div>
        </asp:View>
        <asp:View ID="View4" runat="server">
            <div class="panel panel-default">
                <div class="panel-heading" style="width: 100%;">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4 btn-group">
                                <div class="btn-group">
                                    <asp:Button ID="Previous4" runat="server" class="btn btn-primary register" Text="Previous" OnClick="Previous4_Click" />
                                    <asp:Button ID="Button16" CssClass="btn btn-primary register " runat="server" Text="Reset" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <p><b>Pay & Submit</b></p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-body gallery">
                    <table class="table table-striped table-bordered table-hover" style="width: 98%">
                        <tr>
                            <td colspan="4">
                                <b>Pay Now</b>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style2"><span style="color: Red">*</span><b>Integrate with Payment Gateway</b></td>
                            <td>
                                <asp:TextBox ID="txtpayment" CssClass="form-control" Width="250px" runat="server"></asp:TextBox></td>
                            <td colspan="2">
                                <asp:Button ID="btnFinish" CssClass="register " runat="server" Text="Finish" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>