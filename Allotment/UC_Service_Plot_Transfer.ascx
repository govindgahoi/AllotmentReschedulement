<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Service_Plot_Transfer.ascx.cs" Inherits="Allotment.UC_Service_Plot_Transfer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>


<%@ Register Src="~/UC_Service_Allotteee_Detail.ascx" TagPrefix="uc1" TagName="UC_Service_Allotteee_Detail" %>
<%@ Register Src="~/UC_Service_Doc_Upload_View.ascx" TagPrefix="uc1" TagName="UC_Service_Doc_Upload_View" %>
<%@ Register Src="~/UC_Service_Doc_Upload_View.ascx" TagPrefix="uc1" TagName="UC_Service_Doc_Upload_View1" %>

<%@ Register Src="~/UC_Service_Payment_Detail.ascx" TagPrefix="uc1" TagName="UC_Service_Payment_Detail" %>



<style>

    .row {
        margin-left: 0px;
        margin-right: 0px;
    }

</style>


<%--    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
<%--    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always"  >



   <ContentTemplate>
      <asp:UpdateProgress ID="UpdWaitImage" runat="server"  DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                 <ProgressTemplate>
                 <div class="fgh">
                 <div class="hgf">
                                <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>   
                               </div>
                               </div>
       </ProgressTemplate>
       </asp:UpdateProgress>--%>

<cc1:MessageBox ID="MessageBox1" runat="server" />
<div class="row" runat="server" id="main_menu">
    <div class="col-md-12" style="background: #dbdbdb;">
        <div style="background: #dbdbdb;">
            <div style="width: 100px; float: left; background: #dbdbdb; font-size: 11px;" class="text-center">
                <br />
                <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                    <li>
                        <a data-toggle="modal" data-target="#myModal1">
                            <i class="fa fa-tachometer" aria-hidden="true"></i>
                            <br />
                            Dashboard
                        </a>
                    </li>
                </ul>
            </div>
            <div style="float: left; background: #dbdbdb; border-left: 1px solid #000; font-size: 11px;" class="text-center">
                Operate<br />
                <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                    <li>
                        <a runat="server" id="lisave" onserverclick="btnSaveAll_Click">
                            <i class="fa fa-floppy-o " aria-hidden="true"></i>
                            <br />
                            Save
                        </a>
                    </li>
                    <li>
                        <a data-toggle="modal" data-target="#myModal1">
                            <i class="fa fa-refresh" aria-hidden="true"></i>
                            <br />
                            Refresh
                        </a>
                    </li>
                </ul>
            </div>
     <%--       <div style="float: left; background: #dbdbdb; border-left: 1px solid #000; border-right: 1px solid #000; font-size: 11px;" class="text-center">
                Services<br />
                <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                    <li>
                        <a href="ServiceTimelines.aspx">
                            <i class="fa fa-plus" aria-hidden="true"></i>
                            <br />
                            New
                        </a>
                    </li>
                    <li>
                        <a href="ServiceRequestDraft.aspx">
                            <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                            <br />
                            Drafted
                        </a>
                    </li>
                    <li>
                        <a href="ServiceRequestSubmitted.aspx">
                            <i class="fa fa-th-list" aria-hidden="true"></i>
                            <br />
                            Submitted
                        </a>
                    </li>

                    <li>
                        <a style="color: #21202080 !important;">
                            <i class="fa fa-credit-card" aria-hidden="true"></i>
                            <br />
                            Track 
                        </a>
                    </li>
                </ul>
            </div>--%>
            <div style="float: left; background: #dbdbdb;  border-left: 1px solid #000; font-size: 11px;" class="text-center">
                Navigation<br />
                <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                    <li>
                        <a style="color: #eee !important;">
                            <i class="fa fa-step-backward" aria-hidden="true"></i>
                            <br />
                            Last
                        </a>
                    </li>
                    <li>
                        <a runat="server" onserverclick="btnprev_Click">
                            <i class="fa fa-angle-double-left" aria-hidden="true"></i>
                            <br />
                            Previous
                        </a>
                    </li>
                    <li>
                        <a runat="server" id="linext" onserverclick="btnnext_Click">
                            <i class="fa fa-angle-double-right" aria-hidden="true"></i>
                            <br />
                            Next
                        </a>
                    </li>
                    <li>
                        <a style="color:#eee !important;">
                            <i class="fa fa-step-forward" aria-hidden="true"></i>
                            <br />
                            Final
                        </a>
                    </li>
                </ul>
            </div>
       

        </div>
    </div>
    <div class="clearfix"></div>
</div>
<br />

<br />
<input type="button" value="Click Me" style="display: none;" id="btnNewGroup" data-toggle="modal" data-target="#myModal">
<div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">

        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Confirmation</h4>
            </div>
            <div class="modal-body">
                <div class="col-md-12" style="font-size: 12px; padding: 4px 15px;">Kindly confirm all mendatory data and Document have been uploaded before submiting. </div>
                <div class="clearfix"></div>
            </div>
            <div class="modal-footer">
                <div class="pull-right border-buttons">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-sm btn-primary btn-popup" Style="margin-right: 3px;" Text="Submit" OnClick="pop_Click" />
                    <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal" style="margin-right: 0;">Close</button>
                </div>
            </div>
        </div>

    </div>
</div>



   <asp:Menu
        id="sub_menu"
        Orientation="Horizontal"   
        CssClass="selected highlighted"
        OnMenuItemClick="Menu1_MenuItemClick"
        StaticMenuStyle-CssClass="nav nav-pills myul-tabs"
        StaticSelectedStyle-CssClass="active selected highlighted"
        Runat="server">
       
        <Items>
        <asp:MenuItem Text="Transfror Detail" Value="0" />
        <asp:MenuItem Text="Payment Checklist" Value="1" />
        <asp:MenuItem Text="Documents Checklist" Value="2" />

           <%-- Entry on below  and Submit Request--%>
        <asp:MenuItem Text="Proposed  Transfree" Value="3" />

            <%-- develop view on below views from your page --%>
                    <asp:MenuItem Text="Transfree Details" Value="4" />
                    <asp:MenuItem Text="Transfree Project" Value="5" />
                    <asp:MenuItem Text="Transfree Documents" Value="6" />

        </Items>    

    </asp:Menu>




<asp:MultiView ID="MultiViewBuildingPlan" runat="server">

    <%--PreRequest  --%>
    <asp:View ID="PreRequest" runat="server">
        <div class="panel panel-default">

            <div class="panel-heading" style="width: 100%;">
                <div class="row">
                    <div class="col-md-12">

                        <div class="col-md-4">
                            <div class="btn-group">
                                <asp:Button ID="btnPrevious" runat="server" CssClass="btn btn-primary register " Text="Previous" Enabled="false" Style="display: none;" />
                                <asp:Button ID="btnNext" CssClass="btn btn-primary register " runat="server" OnClick="btnnext_Click" Text="Next" Style="display: none;" />
                            </div>
                        </div>

                        <div class="col-md-4">
                            <p><b>Pre Requisite</b></p>
                        </div>
                        <div class="col-md-4">
                            <div class="btn-group">
                                <asp:Button ID="btnSubmit" CssClass="btn btn-primary register " runat="server" OnClick="btnSubmit_Click" Text="Save"  Style="display: none;"/>
                                <asp:Button ID="btnReset" CssClass="btn btn-primary register " runat="server" Text="Reset" Enabled="false" Style="display: none;" />
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



            <uc1:UC_Service_Allotteee_Detail runat="server" ID="UC_Service_Allotteee_Detail" />

            <div class="panel-body">
                <div class="" style="border: 1px solid #ccc; width: 100%; background: #f1f1f1;">

                    <div class="hide">
                        <div class="panel-heading" style="font-weight: 700;">Pre-clearance check for applying the service :- </div>
                        <div class="form-group">
                            <label class="col-md-2 text-right"></label>
                            <div class="col-md-1">
                            </div>
                            <div class="col-md-2">
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-2 text-right">Lease Deed :</label>
                            <div class="col-md-1">
                                <asp:Label ID="LeaseDeedLbl" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <span><i class="fa fa-times" aria-hidden="true" style="color: red" runat="server" id="cross1" visible="false"></i></span>
                                <span><i class="fa fa-check" aria-hidden="true" style="color: #3bce3b;" runat="server" id="check1" visible="false"></i></span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-2 text-right">Pending Dues :</label>
                            <div class="col-md-1">
                                <asp:Label ID="PendinDuesLbl" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <span><i class="fa fa-times" aria-hidden="true" style="color: red" runat="server" id="cross2" visible="false"></i></span>
                                <span><i class="fa fa-check" aria-hidden="true" style="color: #3bce3b;" runat="server" id="check2" visible="false"></i></span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-2 text-right"><%--Message :--%></label>
                            <div class="col-md-10">
                                <ul class="list-unstyled">
                                    <li runat="server" id="msg1" visible="false">Your lease deed and dues are Complete, You can proceed for apply.</li>
                                    <li runat="server" id="msg2" visible="false">Before applying for the services, you need to execute the lease deed or clear the pending dues.</li>
                                </ul>
                            </div>
                        </div>

                    </div>


                    <div runat="server" id="service_app_type" visible="false">
                        <div class="clearfix"></div>
                        <div class="panel-heading font-bold">Application Nature </div>
                        <div class="form-group" style="display:none;">
                            <label class="col-md-2">
                                <span style="color: Red">*</span>Application Type
                            </label>
                            <div class="col-md-10">
                                <asp:DropDownList ID="ddlApplication" runat="server" CssClass="btn btn-default dropdown-toggle input-sm similar-select1"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-2">
                                <span style="color: Red">*</span>Case Type :
                            </label>
                            <div class="col-md-10">
                                <asp:DropDownList ID="ddlCaseType" runat="server" CssClass="btn btn-default dropdown-toggle input-sm similar-select1"></asp:DropDownList>
                                <asp:Label ID="lblArea" runat="server" Text="" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                    </div>
                </div>






                <table class="table table-striped table-bordered table-hover">
                    <tr style="display: none;">
                        <td colspan="2" align="left">
                            <span>Executive authority to intimate:</span>
                            <asp:Label ID="lblAuthority" runat="server" Text=""></asp:Label>
                            <span>Email ID:</span>
                            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                            <span>Phone No:</span>
                            <asp:Label ID="lblPhoneNumber" runat="server" Text=""></asp:Label>
                            <asp:Label runat="server" ID="checkcon" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td class="auto-style2">
                            <span style="color: Red">*</span>
                            Date of lease deed :
                        </td>
                        <td>
                            <asp:TextBox ID="txtLeaseDeed" runat="server" class="form-control" Width="250px" Enabled="false"></asp:TextBox>
                        </td>

                    </tr>
                    <tr id="lableMessage" runat="server" style="display:none;" visible="false">
                        <td align="left" colspan="2">
                            <span style="color: Red">Your LeaseDeed Details are not Available with us .Kindly Raise a Request to UPSIDE to Update the Records For Your Leased</span>
                        </td>
                    </tr>

                </table>
                <asp:Label ID="lblserRequest" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblServiceRequestID" runat="server" Visible="false"></asp:Label>
            </div>
        </div>
    </asp:View>

    <%--Payment check --%>
    <asp:View ID="PaymentChecklist" runat="server">

        <div class="panel panel-default">
            <div class="panel-body gallery">
                <uc1:UC_Service_Payment_Detail runat="server" ID="UC_Service_Payment_Detail" />
            </div>
        </div>

    </asp:View>

    <%--Checklist Documents --%>
    <asp:View ID="DocumentsChecklist" runat="server">

        <div class="panel panel-default">
            <div class="panel-heading" style="width: 100%;">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-4 btn-group">
                            <div class="btn-group">
                                <asp:Button ID="Previous2" runat="server" CssClass="btn btn-primary register " Text="Previous" OnClick="btnprev_Click" Style="display: none;" />
                                <asp:Button ID="btnNext2" CssClass="btn btn-primary register " runat="server" OnClick="btnnext_Click" Text="Next" Style="display: none;" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <p><b>Application Checklist</b></p>
                        </div>
                        <div class="col-md-4">
                            <div class="btn-group">
                                <asp:Button ID="btnSave" CssClass="btn btn-primary register " runat="server" Text="Save" Enabled="false" Style="display: none;" />
                                <asp:Button ID="btnReset1" CssClass="btn btn-primary register " runat="server" Text="Reset" Enabled="false" Style="display: none;" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="panel-body gallery">
                <uc1:UC_Service_Doc_Upload_View runat="server" ID="UC_Service_Doc_Upload_View" />

            </div>


        </div>

    </asp:View>

    <%--Transfree/Transferrer Details  --%>
    <asp:View ID="View2" runat="server">
        <div runat="server" id="Div1" class="panel panel-default">
            <div class="panel-heading" style="width: 100%;">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-4 btn-group">
                            <div class="btn-group">
                            <%--    <asp:Button ID="Button3" CssClass="btn btn-primary register " runat="server" OnClick="Next1_Click" Text="Next" Style="display: none;" />--%>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <p><b>Transfree/Transferrer Details</b></p>
                        </div>
                        <div class="col-md-4">
                            <div class="btn-group">
<%--                                <asp:Button ID="Button5" CssClass="btn btn-primary register " runat="server" OnClick="btnSubmit_Click" Text="Save" Style="display: none;" />
                                <asp:Button ID="Button6" CssClass="btn btn-primary register " runat="server" OnClick="btnSaveBuildingSpec_Click" Text="Save" Style="display: none;" />
                                <asp:Button ID="Button7" CssClass="btn btn-primary register " runat="server" Text="Reset" Style="display: none;" />--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-body">

                <div runat="server" id="Div2">
                    <div class="panel-heading font-bold">Application form for Transfer of Industrial Plot</div>
                  
                    
<%-- style="display:none;"--%>


                    <span >
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                Plot No :
                            </label>
                            <div class="col-md-9">
                                <asp:Label ID="lblPlotNo" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                Name of the Area :
                            </label>
                            <div class="col-md-9">
                                <asp:Label ID="lblAreaName" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>

                        <span style="display:none;">
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                Name of Allottee :
                            </label>
                            <div class="col-md-9">
                                <asp:Label ID="lblNameofAllottee" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                Tel. No. :
                            </label>
                            <div class="col-md-9">
                                <asp:Label ID="lblTelNo" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                GIR/PAN No. :
                            </label>
                            <div class="col-md-9">
                                <asp:Label ID="lblPanNo" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>

                        </span>

                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                        </span>



                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                Name of Proposed Transferee :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtProposedTransfereeName" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                Address of Proposed Transferee :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtProposedTransfereeAddress" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                Tel. No. of Proposed Transferee:
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtTransfereeTelNo" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                            </div>
                        </div>
                    </div>



                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                               Email of Proposed Transferee *:
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtTransfereeEmail"   CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>




                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                GIR/PAN No. :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtTransfereePan" CssClass="input-sm similar-select1" runat="server" onblur="validatepan1()"></asp:TextBox>
                            </div>
                        </div>
                    </div>




                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                Reason of Transfer :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox TextMode="MultiLine" ID="txtReasonofTransfer" runat="server" CssClass="similar-select1 margin-left-z input-sm"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />

                </div>
            </div>
        </div>
    </asp:View>



        <%--Transfree Details View --%>
    <asp:View ID="View4" runat="server">

         <div class="row" style="display:none;">
                                                        <div class="col-md-12 col-sm-12 col-xs-12">

                                                            <div class="panel panel-default">
                                                                <div class="panel-heading font-bold">
                                                                    Applicant Details  <span class="pull-right">Application No: <asp:Label ID="lblApplicationNo" runat="server" CssClass="font-bold"></asp:Label></span>                       
                                                                </div>
                                                                <div class="panel-body" style="padding: 0px !important;">
                                                                    <div class="div-companydetail" style="background: #ececec;">
                                                                        <div class="form-group">
                                                                            <div class="row">
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Regional Office :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblRegionalOffice" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Industrial Area : 
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblIndustrialArea" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />
                                                                        <div class="form-group">
                                                                            <div class="row">
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Date of Application :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblDateofApplication" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Required Plot Size :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblRequiredplot" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />

                                                                        <div class="form-group">
                                                                            <div class="row">
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Firm/Company Name :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblFirmCompanyName" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Firm/Company Constitution :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblCompanyConstitution" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />
                                                                        <div class="form-group">
                                                                            <div class="row">

                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Firm/Company PAN No :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="Label1" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Firm/Company CIN No :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblCinNo" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />

                                                                        <div class="form-group">
                                                                            <div class="row">

                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Authorised Signatory :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblAuthorisedSignatory" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Signatory Mobile :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblSignatoryMobile" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />
                                                                        <div class="form-group">
                                                                            <div class="row">
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Address :   
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblAddress" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Signatory Email : 
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblSIgnatoryEmail" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />
                                                                        <div class="form-group">
                                                                            <div class="row">
                                                                                <label class="col-md-6 col-sm-6 col-xs-6 text-right font-bold" style="width:58%;    font-size: 13px !important;">
                                                                                    Application Current Status:
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6" style="width:32%;"">
                                                                                    <span class="pull-left text-muted small"><em>
                                                                                        <asp:Label ID="lblStatusAsonDate" runat="server" CssClass="font-bold"> </asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />

                                                                    </div>


                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 col-sm-12 col-xs-12">


                                                            <div class="panel panel-default">
                                                                <p class="panel-heading font-bold" runat="server" id="P2">Shareholding</p>
                                                                <div class="panel-body gallery">

                                                                    <asp:Label ID="Label32" runat="server" Text=""></asp:Label>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                                            <Columns>


                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label16" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                                        </asp:Label>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="AllotteeName" HeaderText="Name" SortExpression="AllotteeName" />
                                                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                                                <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                                                <asp:BoundField DataField="emailID" HeaderText="EmailId" SortExpression="EmailId" />

                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="table-responsive">

                                                                        <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                                            <Columns>


                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label17" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                                        </asp:Label>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="DirectorName" HeaderText="Director Name" SortExpression="DirectorName" />
                                                                                <asp:BoundField DataField="DIN_PAN" HeaderText="Din/Pan" SortExpression="DIN_PAN" />
                                                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                                                <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="Phone" />
                                                                                <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                                            </Columns>


                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                                            <Columns>


                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                                        </asp:Label>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="ShareholderName" HeaderText="Shareholder Name" SortExpression="ShareholderName" />
                                                                                <asp:BoundField DataField="SharePer" HeaderText="Share %" SortExpression="SharePer" />
                                                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                                                <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                                                <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                                            </Columns>

                                                                            <EmptyDataTemplate>
                                                                                No Record Available
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                                            <Columns>


                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                                        </asp:Label>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="PartnerName" HeaderText="Partner Name" SortExpression="PartnerName" />
                                                                                <asp:BoundField DataField="PartnershipPer" HeaderText="Partnership %" SortExpression="PartnershipPer" />
                                                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                                                <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                                                <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                                            </Columns>

                                                                            <EmptyDataTemplate>
                                                                                No Record Available
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                                            <Columns>


                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label19" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                                        </asp:Label>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="TrusteeName" HeaderText="Trustee Name" SortExpression="TrusteeName" />
                                                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                                                <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="Phone" />
                                                                                <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                                            </Columns>

                                                                            <EmptyDataTemplate>
                                                                                No Record Available
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                                            <Columns>


                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label20" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                                        </asp:Label>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="AllotteeName" HeaderText="Individual Name" SortExpression="AllotteeName" />
                                                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                                                <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                                                <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>

                                                                </div>
                                                            </div>

                                                        </div>

                                                    </div>

        													<div id="tblallotteeinf">
															<p class="panel-heading"><b>Transfree Information</b></p>

															<div class="form-group">
																<div class="row">
																	<label class="col-md-4 text-right">
																		<span style="color: Red">*</span>
																		Name of Industrial Area in which plot belongs :
																	</label>
																	<div class="col-md-8">
																		<asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="true" disabled CssClass="input-sm dropdown-toggle similar-select1 margin-left-z"></asp:DropDownList>
																	</div>
																</div>
															</div>
															<div class="clearfix"></div>
															<hr class="myhrline" />

															<div class="form-group">
																<div class="row">
																	<label class="col-md-4 text-right">
																		<span style="color: Red">*</span>
																		Plot No :
																	</label>
																	<div class="col-md-8">
																		<asp:TextBox ID="txtPlotNo" runat="server" CssClass="similar-select1 input-sm" placeholder="Enter Plot Size In Sqr.Mtr" onkeypress="return isDecimalKey(event);" onblur="ValidatePlotSize()" Enabled="false"></asp:TextBox>
																	</div>
                                                                   
                                                                   
																</div>
															</div>
                                                                <div class="clearfix"></div>
															<hr class="myhrline" />

															<div class="form-group">
																<div class="row">
																	<label class="col-md-4 text-right">
																		<span style="color: Red">*</span>
																		Plot Size :
																	</label>
																	<div class="col-md-8">
																		<asp:TextBox ID="txtPlotSize" runat="server" CssClass="similar-select1 input-sm" placeholder="Enter Plot Size In Sqr.Mtr" onkeypress="return isDecimalKey(event);" onblur="ValidatePlotSize()" Enabled="false"></asp:TextBox>
																	</div>
                                                                   
                                                                   
																</div>
															</div>
															
															<div class="clearfix"></div>
															<hr class="myhrline" />
															
														</div>
														<div id="tblcompanyprofile">
															<asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
															<asp:Label ID="LblAllotteeId" runat="server" Visible="false"></asp:Label>
															<p class="panel-heading"><b>Particulars of the Transfree in whose Name plot/shed to be Allotted</b></p>
															<div class="form-group">
																<div class="row">
																	<label class="col-md-4 text-right">
																		<span style="color: Red">*</span>
																		Constitution of Firm/Company :
																	</label>
																	<div class="col-md-8">
																		<asp:DropDownList ID="ddlcompanytype" runat="server" AutoPostBack="true" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" OnSelectedIndexChanged="CompanyTypeddl_selectedindex_changed"></asp:DropDownList>
																	</div>
																</div>
															</div>
															<div class="clearfix"></div>
															<hr class="myhrline" />
															<div class="form-group">
																<div class="row">
																	<label class="col-md-4 text-right">
																		<span style="color: Red">*</span>
																		Name of the Firm/Company :
																	</label>
																	<div class="col-md-8">
																		<asp:TextBox ID="txtCompanyname" runat="server" CssClass="similar-select1 input-sm" onblur="ValidateCompanyName()"></asp:TextBox>
																	</div>
																</div>
															</div>
															<div class="clearfix"></div>
															<hr class="myhrline" />
															<div class="form-group">
																<div class="row">
																	<label class="col-md-4 text-right">
                                                                        <span style="color: Red">*</span>
																		Pan No :
																	</label>
																	<div class="col-md-8">
																		<asp:TextBox ID="txtPanNo" runat="server" CssClass="similar-select1 input-sm" onblur="return validatepan();"></asp:TextBox>
																	</div>
																</div>
															</div>
															<div class="clearfix"></div>
															<hr class="myhrline" />
															<div class="form-group">
																<div class="row">

																	<label class="col-md-4 text-right">
                                                                        
																		CIN No :
																	</label>
																	<div class="col-md-8">
																		<asp:TextBox ID="txtCinNo" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
																	</div>
																</div>
															</div>
															<div class="clearfix"></div>
															<hr class="myhrline" />
															<div id="tr5" runat="server" visible="false">
																<div class="form-group">
																	<div class="row">
																		<label class="col-md-4 text-right">
																			<span style="color: Red">*</span>
																			<asp:Label ID="lblnameremark" runat="server" />
																		</label>
																		<div class="col-md-8">
																			<asp:TextBox ID="txtIndividualName" runat="server" CssClass="similar-select1 input-sm" onkeypress="return Validate_individual_name(event);"></asp:TextBox>
																		</div>
																	</div>
																</div>
																<div class="clearfix"></div>
																<hr class="myhrline" />
																<div class="form-group">
																	<div class="row">
																		<label class="col-md-4 text-right">
																			<span style="color: Red">*</span>
																			Address :
																		</label>
																		<div class="col-md-8">
																			<asp:TextBox ID="txtIndividualAddress" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
																		</div>
																	</div>
																</div>
																<div class="clearfix"></div>
																<hr class="myhrline" />
															</div>
															<div id="tr6" runat="server" visible="false">
																<div class="form-group">
																	<div class="row">
																		<label class="col-md-4 text-right">
																			<span style="color: Red">*</span>
																			Phone :
																		</label>
																		<div class="col-md-8">
																			<asp:TextBox ID="txtIndividualPhone" runat="server" CssClass="input-sm similar-select1" MaxLength="15" onkeypress="retun validate_individual_phone(event);" onblur="return check_iphone();"></asp:TextBox>
																		</div>
																	</div>
																</div>
																<div class="clearfix"></div>
																<hr class="myhrline" />
																<div class="form-group">
																	<div class="row">
																		<label class="col-md-4 text-right">
																			<span style="color: Red">*</span>
																			Email Id :
																		</label>
																		<div class="col-md-8">
																			<asp:TextBox ID="txtIndividualEmail" runat="server" CssClass="input-sm similar-select1" onblur="return ValidateIndividualEmail();"></asp:TextBox>
																		</div>
																	</div>
																</div>
																<div class="clearfix"></div>
																<hr class="myhrline" />
															</div>
															<div id="tr7" runat="server" visible="false">
																<div class="form-group">
																	<div class="row">
																		<div class="col-md-12">
																			<asp:CheckBox ID="chk2" runat="server" Text="&nbsp;&nbsp;Check if the person who will be operating the application is same as the Allottee" OnCheckedChanged="checkbox2_checked_changed" AutoPostBack="true" />
																		</div>
																	</div>
																</div>
																<div class="clearfix"></div>
																<hr class="myhrline" />
															</div>
															<div class="form-group">
																<div class="row">
																	<label class="col-md-4 text-right">
																		<span style="color: Red">*</span>
																		Name of the person who  will operate :
																	</label>
																	<div class="col-md-8">
																		<asp:TextBox ID="txtAuthorisedSignatory" runat="server" CssClass="input-sm similar-select1" onkeypress="return Validate_signatory_name(event);"></asp:TextBox>
																	</div>
																</div>
															</div>
															<div class="clearfix"></div>
															<hr class="myhrline" />
															<div class="form-group">
																<div class="row">
																	<label class="col-md-4 text-right">
																		<span style="color: Red">*</span>
																		Address :
																	</label>
																	<div class="col-md-8">
																		<asp:TextBox ID="txtSignatoryAddress" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
																	</div>
																</div>
															</div>
															<div class="clearfix"></div>
															<hr class="myhrline" />
															<div class="form-group">
																<div class="row">
																	<label class="col-md-4 text-right">
																		<span style="color: Red">*</span>
																		Phone :
																	</label>
																	<div class="col-md-8">
																		<asp:TextBox ID="txtSignatoryPhone" runat="server" CssClass="input-sm similar-select1" MaxLength="15" onkeypress="return validate_signatory_phone(event);" onblur="return check_sphone();"></asp:TextBox>
																	</div>
																</div>
															</div>
															<div class="clearfix"></div>
															<hr class="myhrline" />
															<div class="form-group">
																<div class="row">
																	<label class="col-md-4 text-right">
																		<span style="color: Red">*</span>
																		Email Id :
																	</label>
																	<div class="col-md-8">
																		<asp:TextBox ID="txtSignatoryEmail" runat="server" CssClass="input-sm similar-select1" onblur="ValidateSignatoryEmail()"></asp:TextBox>
																	</div>
																</div>
															</div>
															<div class="clearfix"></div>
															<hr class="myhrline" />
															<div id="tr2" runat="server" visible="false">
																<hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
																<asp:GridView ID="gridshareholder" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="ShareHolderDelete_Click">
																	<Columns>

																		<asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
																			<ItemTemplate>
																				<asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			</ItemTemplate>
																		</asp:TemplateField>


																		<asp:TemplateField ItemStyle-Width="20%" HeaderText="Shareholder Name">
																			<ItemTemplate>
																				<asp:Label ID="lblShareholderName" runat="server" Text='<%#Eval("ShareHolderName") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtShareholderName_insert" CssClass="input-sm similar-select1" runat="server" onkeypress="return Validate_shareholder_name(event);"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="20%" HeaderText="Share %">
																			<ItemTemplate>
																				<asp:Label ID="lblShareper" runat="server" Text='<%#Eval("SharePer") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtShareper_insert" runat="server" CssClass="input-sm similar-select1" onkeypress="return validate_shareper(event);"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="20%" HeaderText="Address">
																			<ItemTemplate>
																				<asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtAddress_insert" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="20%" HeaderText="Phone No">
																			<ItemTemplate>
																				<asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtPhone_insert" CssClass="input-sm similar-select1" MaxLength="10" runat="server" onkeypress="return validate_shareholder_phone(event);" onblur="return check_sharephone();"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="20%" HeaderText="Email ID">
																			<ItemTemplate>
																				<asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtEmail_insert" CssClass="input-sm similar-select1" runat="server" onblur="return ValidateShareHolderEmail();"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>


																		<asp:TemplateField>
																			<ItemTemplate>
																				<asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

																			</ItemTemplate>
																			<FooterStyle HorizontalAlign="Right" />
																			<FooterTemplate>
																				<asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square" ID="ButtonAdd" runat="server" Height="16px" OnClick="insert_shareholder_details"
																					ImageUrl="~/images/add.png" Width="16px" />





																			</FooterTemplate>
																		</asp:TemplateField>


																	</Columns>
																</asp:GridView>

															</div>
															<div class="clearfix"></div>
															<div id="tr4" runat="server" visible="false">
																<hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
																<asp:GridView ID="Trustee_details_grid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="TrusteeDelete_Click">
																	<Columns>

																		<asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
																			<ItemTemplate>
																				<asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			</ItemTemplate>
																		</asp:TemplateField>


																		<asp:TemplateField ItemStyle-Width="25%" HeaderText="Trustee Name">
																			<ItemTemplate>
																				<asp:Label ID="lblTrusteeName" runat="server" Text='<%#Eval("TrusteeName") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtTrusteeName_insert" CssClass="input-sm similar-select1" runat="server" onkeypress="return Validate_trustee_name(event);"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>

																		<asp:TemplateField ItemStyle-Width="25%" HeaderText="Address">
																			<ItemTemplate>
																				<asp:Label ID="lblTAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtTAddress_insert" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="25%" HeaderText="Phone No">
																			<ItemTemplate>
																				<asp:Label ID="lblTPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtTPhone_insert" CssClass="input-sm similar-select1" MaxLength="10" runat="server" onkeypress="return validate_trustee_phone(event);" onblur="return check_Tphone();"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="25%" HeaderText="Email ID">
																			<ItemTemplate>
																				<asp:Label ID="lblTEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtTEmail_insert" CssClass="input-sm similar-select1" runat="server" onblur="return ValidateTrusteeEmail();"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>


																		<asp:TemplateField>
																			<ItemTemplate>
																				<asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

																			</ItemTemplate>
																			<FooterStyle HorizontalAlign="Right" />
																			<FooterTemplate>
																				<asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square" ID="ButtonAdd" runat="server" Height="16px" OnClick="insert_trustee_details"
																					ImageUrl="~/images/add.png" Width="16px" />
																			</FooterTemplate>
																		</asp:TemplateField>


																	</Columns>
																</asp:GridView>

															</div>
															<div class="clearfix"></div>
															<div id="tr8" runat="server" visible="false">
																<hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
																<asp:GridView ID="DirectorsGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="DirectorDelete_Click">
																	<Columns>

																		<asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
																			<ItemTemplate>
																				<asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			</ItemTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="20%" HeaderText="Director Name">
																			<ItemTemplate>
																				<asp:Label ID="lblDirectorName" runat="server" Text='<%#Eval("DirectorName") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtDirectorName_insert" CssClass="input-sm similar-select1" runat="server" onkeypress="return Validate_director_name(event);"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="20%" HeaderText="Din/Pan">
																			<ItemTemplate>
																				<asp:Label ID="lblDIN_PAN" runat="server" Text='<%#Eval("DIN_PAN") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtDIN_PAN_insert" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="20%" HeaderText="Address">
																			<ItemTemplate>
																				<asp:Label ID="lblDirectorAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtDirectorAddress_insert" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="20%" HeaderText="Phone No">
																			<ItemTemplate>
																				<asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtDirectorPhone_insert" CssClass="input-sm similar-select1" MaxLength="10" runat="server" onkeypress="return validate_director_phone(event);" onblur="return check_dphone();"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="20%" HeaderText="Email ID">
																			<ItemTemplate>
																				<asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtDirectorEmail_insert" CssClass="input-sm similar-select1" runat="server" onblur="return ValidateDirectorEmail();"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>


																		<asp:TemplateField>
																			<ItemTemplate>
																				<asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

																			</ItemTemplate>
																			<FooterStyle HorizontalAlign="Right" />
																			<FooterTemplate>
																				<asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square" ID="ButtonAdd" runat="server" Height="16px" OnClick="insert_Director_details"
																					ImageUrl="~/images/add.png" Width="16px" />





																			</FooterTemplate>
																		</asp:TemplateField>


																	</Columns>
																</asp:GridView>
															</div>
															<div class="clearfix"></div>


															<div id="tr9" runat="server" visible="false">
																<hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
																<asp:GridView ID="PartnershipFirmGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="PartnershipDelete_Click">
																	<Columns>

																		<asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
																			<ItemTemplate>
																				<asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			</ItemTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="20%" HeaderText="Partner Name">
																			<ItemTemplate>
																				<asp:Label ID="lblPartnerName" runat="server" Text='<%#Eval("PartnerName") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtPartnerName_insert" CssClass="input-sm similar-select1" runat="server" onkeypress="return Validate_director_name(event);"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="20%" HeaderText="Partnership Per">
																			<ItemTemplate>
																				<asp:Label ID="lblPartnershipPer" runat="server" Text='<%#Eval("PartnershipPer") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtPartnershipPer_insert" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="20%" HeaderText="Address">
																			<ItemTemplate>
																				<asp:Label ID="lblPartnerAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtPartnerAddress_insert" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="20%" HeaderText="Phone No">
																			<ItemTemplate>
																				<asp:Label ID="lblPartnerPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtPartnerPhone_insert" CssClass="input-sm similar-select1" MaxLength="10" runat="server" onkeypress="return validate_partner_phone(event);" onblur="return check_parphone();"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>
																		<asp:TemplateField ItemStyle-Width="20%" HeaderText="Email ID">
																			<ItemTemplate>
																				<asp:Label ID="lblPartnerEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
																			</ItemTemplate>
																			<FooterTemplate>
																				<asp:TextBox ID="txtPartnerEmail_insert" CssClass="input-sm similar-select1" runat="server" onblur="return ValidatePartnerEmail();"></asp:TextBox>
																			</FooterTemplate>
																		</asp:TemplateField>


																		<asp:TemplateField>
																			<ItemTemplate>
																				<asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

																			</ItemTemplate>
																			<FooterStyle HorizontalAlign="Right" />
																			<FooterTemplate>
																				<asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square" ID="ButtonAdd" runat="server" Height="16px" OnClick="insert_Partnership_details"
																					ImageUrl="~/images/add.png" Width="16px" />





																			</FooterTemplate>
																		</asp:TemplateField>


																	</Columns>
																</asp:GridView>
															</div>
															<div class="clearfix"></div>
														</div>
        	<div class="form-group" style="margin-top: 15px;">
														<div class="row">
															<div class="col-md-4">
																<span style="color: blue" class="pull-left">Field marked with <span style="color: Red">* </span>are mandatory</span>
															</div>
															<div class="col-md-4 text-center" style="display:none;">
																
                                                                
                                                            </div>
															<div class="col-md-4"></div>
														</div>
													</div>
													<div class="clearfix"></div>

    </asp:View>

        <%--Transfree Project Details View --%>
    <asp:View ID="View5" runat="server">

          <div class="row" style="display:none;">
                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="allottee-details-div">
                                                <div class="panel panel-default">
                                                    <div class="panel-heading font-bold">
                                                        Project Details                        
                                                    </div>
                                                    <div class="panel-body ">
                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Proposed industry</div>
                                                            <div class="panel-body" style="padding: 0px !important;">
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        <label for="">Description&nbsp;:</label>
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                            </div>
                                                        </div>

                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Project Costing Details</div>
                                                            <div class="panel-body" style="padding: 0px !important;">
                                                                <div class="form-group">
                                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        <label for="">Estimated Cost :</label>
                                                                    </div>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <i class="fa fa-inr"></i> <asp:Label ID="lblEstimatedCost" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        <label for="">Estimated employment:</label>
                                                                    </div>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <i class="fa fa-inr"></i> <asp:Label ID="LabelblEstimatedEmployment" runat="server"></asp:Label>
                                                                    </div> 
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                            </div>
                                                        </div>


                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Layout plan of land indicating broadly</div>
                                                            <div class="panel-body" style="padding: 0px !important;">
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Covered Area&nbsp;(In %)&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblCoveredArea" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Open area required(In %)&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblOpenArea" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                            </div>
                                                        </div>



                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Details of the investment (in <i class="fa fa-inr"></i>)</div>
                                                            <div class="panel-body" style="padding: 0px !important;">
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right" title="date ofsubmission">
                                                                        Land&nbsp;(In Lacs)&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <i class="fa fa-inr"></i> <asp:Label ID="lblLand" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Building&nbsp;(In Lacs)&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <i class="fa fa-inr"></i> <asp:Label ID="lblBuilding" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Machinery & Equipments&nbsp;(In Lacs)&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <i class="fa fa-inr"></i> <asp:Label ID="lblMachineryEquipment" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Other Fixed Assets&nbsp;(In Lacs)&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <i class="fa fa-inr"></i> <asp:Label ID="lblOtherAssets" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Other Expenses&nbsp;(In Lacs)&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <i class="fa fa-inr"></i> <asp:Label ID="lblOtherExpenses" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />

                                                            </div>
                                                        </div>



                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Any fumes generated in the process of manufacture and if so, their nature and quantity &nbsp; <span runat="server" id="Span1"></span></div>
                                                            <div class="panel-body" style="padding: 0px !important;" id="Div3" runat="server" visible="false">
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Nature&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblNature" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Quantity&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                            </div>
                                                        </div>



                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Industrial Effluents </div>
                                                            <div class="panel-body" style="padding: 0px !important;">
                                                                <table class="table table-hover table-bordered request-table" style="width: 100%;">
                                                                    <tr>
                                                                        <th style="width: 24%;text-align:center;">Name</th>
                                                                        <th style="width: 38%;text-align:center;">Quantity</th>
                                                                        <th style="width: 38%;text-align:center;">Chemical Composition</th>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><span class="pull-right">(i)&nbsp;Solid :</span></td>
                                                                        <td>
                                                                            <asp:Label ID="lblQtySolid" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblChemicalSolid" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><span class="pull-right">(ii)&nbsp;Liquid :</span></td>
                                                                        <td>
                                                                            <asp:Label ID="lblQtyLiquid" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblChemicalLiquid" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><span class="pull-right">(iii)&nbsp;Gaseous :</span></td>
                                                                        <td>
                                                                            <asp:Label ID="lblQtyGaseous" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblChemicalGaseous" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </table>



                                                            </div>
                                                        </div>



                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Effluent Treatment Measures</div>
                                                            <div class="panel-body" style="padding: 0px !important;">


                                                                <div class="row aks-row">

                                                                    <div class="col-md-4 col-sm-12 col-xs-12 form-inline font-12px">
                                                                        <asp:Label ID="lblmeasure1" runat="server"></asp:Label></div>

                                                                    <div class="col-md-4 col-sm-12 col-xs-12 form-inline font-12px">
                                                                        <asp:Label ID="lblmeasure2" runat="server"></asp:Label>

                                                                    </div>



                                                                    <div class="col-md-4 col-sm-12 col-xs-12 form-inline font-12px">
                                                                        <asp:Label ID="lblmeasure3" runat="server"></asp:Label></div>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>

                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Power Requirement (in KW)</div>
                                                            <div class="panel-body" style="padding: 0px !important;">


                                                                <div class="form-group">

                                                                    <label class="col-md-3 col-sm-6 col-xs-6 form-inline text-right">Units &nbsp;:</label>

                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblUnits" runat="server"></asp:Label>

                                                                    </div>


                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                            </div>
                                                        </div>

                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Telephone Requirement</div>
                                                            <div class="panel-body" style="padding: 0px !important;">


                                                                <div class="form-group">

                                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">First Year&nbsp;:</div>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblFirstYear1" runat="server"></asp:Label>&nbsp;&nbsp;
                               <asp:Label ID="lblFirstYear2" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">Ultimate Requirement&nbsp;:</div>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblUltimateRequirement1" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;
                              <asp:Label ID="lblUltimateRequirement2" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="sub-heading font-bold">Other Relevant Information</div>
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                    Net Worth Turnover :
                                                                </label>
                                                                <div class="col-md-9 col-sm-6 col-xs-6">
                                                                    <asp:Label ID="lblNetworth" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                    Expansion Of Land :
                                                                </label>
                                                                <div class="col-md-9 col-sm-6 col-xs-6">
                                                                    <asp:Label ID="lblExpansionland" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                    100% Export Oriented Industry :
                                                                </label>
                                                                <div class="col-md-9 col-sm-6 col-xs-6">
                                                                    <asp:Label ID="lblExportOriented" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Is the applicant under priority category ? Please specify clearly &nbsp; <span runat="server" id="Span2"></span></div>
                                                            <div id="Div4" class="panel-body" style="padding: 0px !important;" runat="server" visible="false">
                                                                <div class="row aks-row">


                                                                    <div class="col-md-3 col-sm-6 col-xs-6">Specification&nbsp;:</div>

                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblSpecification" runat="server"></asp:Label></div>

                                                                </div>
                                                            </div>
                                                        </div>



                                                    </div>
                                                </div>

                                                </div>

                                            </div>


                                        </div>
        				<p class="panel-heading"><b>Allottee Project Details</b></p>
													<p class="panel-heading font-bold">Type of industry to be set up</p>
													<div class="form-group">
														<div class="row">
															<label class="col-md-4 text-right">
                                                                <span style="color: Red">*</span>
																Description :
															</label>
															<div class="col-md-8">
																<asp:TextBox ID="txttypeofindustry" runat="server" CssClass="input-sm similar-select1 margin-left-z" TextMode="MultiLine"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />
													<p class="panel-heading font-bold">Project Costing Details</p>
													<div class="form-group">
														<div class="row">
															<label class="col-md-4 text-right">
                                                                <span style="color: Red">*</span>
																Estimated Cost of the project:
															</label>
															<div class="col-md-8">
																 <i class="fa fa-inr"></i><asp:TextBox ID="txtestimatedcost" runat="server" CssClass="input-sm similar-select1" Width="99%" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />
													<div class="form-group">
														<div class="row">
															<label class="col-md-4 text-right">
                                                                <span style="color: Red">*</span>
																Estimated Employment Generation&nbsp;:
															</label>
															<div class="col-md-8">
																<asp:TextBox ID="txtestimatedemployment" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />
													<div class="form-group">
														<div class="row">
															<label class="col-md-4 text-right">
                                                                <span style="color: Red">*</span>
																Estimated Project Start Period(In Months)&nbsp;:
															</label>
															<div class="col-md-8">
																<asp:TextBox ID="txtProjectStartMonths" runat="server" CssClass="input-sm similar-select1" MaxLength="2" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />
													<div class="form-group">
														<div class="row">
															<label class="col-md-4 text-right">
                                                                <span style="color: Red">*</span>
																Related Work Experience(In Months)&nbsp;:
															</label>
															<div class="col-md-8">
																<asp:TextBox ID="txtWorkExperience" runat="server" CssClass="input-sm similar-select1" MaxLength="4" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />
													<p class="panel-heading font-bold">Layout plan of land</p>
													<div class="form-group">
														<div class="row">
															<label class="col-md-4 text-right">
                                                                <span style="color: Red">*</span>
																Covered Area&nbsp;(In %)&nbsp;:
															</label>
															<div class="col-md-8">
																<asp:TextBox ID="txtcoveredarea" runat="server" MaxLength="2" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />
													<div class="form-group">
														<div class="row">
															<label class="col-md-4 text-right">
                                                                <span style="color: Red">*</span>
																Open Area &nbsp;(In %)&nbsp;:
															</label>
															<div class="col-md-8">
																<asp:TextBox ID="txtopenarearequired" runat="server" MaxLength="2" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />
													<p class="panel-heading font-bold">Details of the investment(in Rs)</p>
													<div class="form-group">
														<div class="row">
															<label class="col-md-4 text-right" title="date ofsubmission">
                                                                <span style="color: Red">*</span>
																Land&nbsp;(In Lacs)&nbsp;:
															</label>
															<div class="col-md-8">
																<i class="fa fa-inr"></i><asp:TextBox ID="txtland" MaxLength="5" Width="99%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />
													<div class="form-group">
														<div class="row">
															<label class="col-md-4 text-right">
                                                                <span style="color: Red">*</span>
																Building&nbsp;(In Lacs)&nbsp;:
															</label>
															<div class="col-md-8">
																<i class="fa fa-inr"></i><asp:TextBox ID="txtbuilding" MaxLength="5" Width="99%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />
													<div class="form-group">
														<div class="row">
															<label class="col-md-4 text-right">
                                                                <span style="color: Red">*</span>
																Machinery & Equipments&nbsp;(In Lacs)&nbsp;:
															</label>
															<div class="col-md-8">
																<i class="fa fa-inr"></i><asp:TextBox ID="txtmachinery" MaxLength="5" Width="99%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>

													<div class="clearfix"></div>
													<hr class="myhrline" />
													<div class="form-group">
														<label class="col-md-4 text-right">
                                                            <span style="color: Red">*</span>
															Other Fixed Assets&nbsp;(In Lacs):
														</label>
														<div class="col-md-8">
															<i class="fa fa-inr"></i><asp:TextBox ID="txtFixedAssets" MaxLength="5" CssClass="input-sm similar-select1" Width="99%" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>

														</div>
													</div>

													<div class="clearfix"></div>
													<hr class="myhrline" />
													<div class="form-group">
														<label class="col-md-4 text-right">
                                                             <span style="color: Red">*</span>
															Other Expenses&nbsp;(In Lacs)&nbsp;:
                                                           
														</label>
														<div class="col-md-8">
															<i class="fa fa-inr"></i><asp:TextBox ID="txtOtherExpenses" MaxLength="5" Width="99%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>

														</div>
													</div>

													<div class="clearfix"></div>
													<hr class="myhrline" />
													<p class="panel-heading">
														Any fumes generated in the process of manufacture if so, their nature and quantity &nbsp; <span class="checkbox-inline" style="padding-bottom: 20px;">
															<asp:CheckBox runat="server" ID="chkfumes" AutoPostBack="true" OnCheckedChanged="chkfumes_CheckedChanged" /></span>
													</p>
													<div id="fumesdiv" runat="server" visible="false">
														<div class="form-group">
															<div class="row">
																<label class="col-md-4 text-right">
																	Nature&nbsp;:
																</label>
																<div class="col-md-8">
																	<asp:TextBox ID="txtfumenature" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																</div>
															</div>
														</div>
														<div class="clearfix"></div>
														<hr class="myhrline" />
														<div class="form-group">
															<div class="row">
																<label class="col-md-4 text-right">
																	Quantity&nbsp;:
																</label>
																<div class="col-md-8">
																	<asp:TextBox ID="txtfumeqty" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																</div>
															</div>
														</div>
														<div class="clearfix"></div>
														<hr class="myhrline" />
													</div>


													<div class="panel panel-default">
														<div class="panel-heading font-bold">Industrial Effluents </div>
														<div class="panel-body" style="padding: 0px !important;">

															<table class="table table-bordered table-hover request-table">
																<tr>
																	<th>Name</th>
																	<th>Quantity</th>
																	<th>Chemical Composition</th>
																</tr>
																<tr>
																	<td><span class="pull-right">(i)&nbsp;Solid :</span></td>
																	<td>
																		<asp:TextBox ID="txteffluentsolidqty" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
																	<td>
																		<asp:TextBox ID="txteffluentsolidcomposition" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
																</tr>
																<tr>
																	<td style="width: 33.7%;"><span class="pull-right">(ii)&nbsp;Liquid :</span></td>
																	<td>
																		<asp:TextBox ID="txteffluentliquidqty" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
																	<td>
																		<asp:TextBox ID="txteffluentliquidcomposition" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
																</tr>
																<tr>
																	<td><span class="pull-right">(iii)&nbsp;Gaseous :</span></td>
																	<td>
																		<asp:TextBox ID="txteffluentgaseousqty" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
																	<td>
																		<asp:TextBox ID="txteffluentgaseouscomposition" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
																</tr>

															</table>

														</div>
													</div>



													<div class="panel panel-default">

														<div class="panel-body" style="padding: 0px !important;">


															<div class="form-group">
																<div class="row">
																	<label class="col-md-4 text-right">
																		Effluent Treatment Measures :
																	</label>
																	<div class="col-md-8 col-sm-6 col-xs-12 form-inline font-12px">
																		<asp:TextBox ID="txteffluenttreatmentmeasure1" CssClass="input-sm similar-select1" runat="server"></asp:TextBox><br />
																		<hr class="myhrline" />
																		<asp:TextBox ID="txteffluenttreatmentmeasure2" CssClass="input-sm similar-select1" runat="server"></asp:TextBox><br />
																		<hr class="myhrline" />
																		<asp:TextBox ID="txteffluenttreatmentmeasure3" CssClass="input-sm similar-select1" runat="server"></asp:TextBox><br />
																		<hr class="myhrline" />
																	</div>
																</div>
															</div>
															<div class="clearfix"></div>

														</div>
														<div class="clearfix"></div>
														<div class="panel panel-default">
															<div class="panel-heading font-bold">Power Requirement (in KW)</div>
															<div class="panel-body" style="padding: 0px !important;">
																<div class="row aks-row">
																	<label class="col-md-4 col-sm-6 col-xs-12 form-inline text-right">
                                                                        <span style="color: Red">*</span>
																		Units &nbsp;:
																	</label>
																	<div class="col-md-8 col-sm-6 col-xs-12">
																		<asp:TextBox ID="txtpowerreq" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																	</div>
																</div>
															</div>
														</div>
														<div class="clearfix"></div>
														<div class="panel panel-default">
															<div class="panel-heading font-bold">Telephone Requirement</div>
															<div class="panel-body" style="padding: 0px !important;">
																<div class="row aks-row">
																	<label class="col-md-4 col-sm-6 col-xs-12 text-right">
																		First Year&nbsp;:
																	</label>
																	<div class="col-md-4 col-sm-6 col-xs-12">
																		<asp:TextBox ID="txttelephonefirstyearreq1" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																	</div>
																	<div class="col-md-4 col-sm-6 col-xs-12">
																		<asp:TextBox ID="txttelephonefirstyearreq2" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																	</div>
																</div>
																<div class="row aks-row">
																	<label class="col-md-4 col-sm-6 col-xs-12 text-right">
																		Ultimate Requirement&nbsp;:
																	</label>
																	<div class="col-md-4 col-sm-6 col-xs-12">
																		<asp:TextBox ID="txttelephoneUltimateyearreq1" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																	</div>
																	<div class="col-md-4 col-sm-6 col-xs-12">
																		<asp:TextBox ID="txttelephoneUltimateyearreq2" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																	</div>
																</div>
															</div>
														</div>
														<div class="clearfix"></div>
														<hr class="myhrline" />
														<p class="panel-heading font-bold">Other Relevant Information</p>
														<div class="form-group">
															<div class="row">
																<label class="col-md-4 text-right">
                                                                    <span style="color: Red">*</span>
																	Net Worth Turnover:
																</label>
																<div class="col-md-8">
																	<i class="fa fa-inr"></i><asp:TextBox ID="txtNetWorth" Width="99%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
																</div>
															</div>
														</div>
														<div class="clearfix"></div>
														<hr class="myhrline" />
														<div class="form-group">
															<div class="row">
																<label class="col-md-4 text-right">
                                                                    <span style="color: Red">*</span>
																	Is Plot Require Expansion Of Land:

																</label>
																<div class="col-md-8">
																	<asp:DropDownList runat="server" ID="Ddl_Expansion" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm">
																		<asp:ListItem>--Select--</asp:ListItem>
																		<asp:ListItem Value="YES">YES</asp:ListItem>
																		<asp:ListItem Value="No">No</asp:ListItem>
																	</asp:DropDownList>
																</div>
															</div>
														</div>
														<div class="clearfix"></div>
														<hr class="myhrline" />
														<div class="form-group">
															<div class="row">
																<label class="col-md-4 text-right">
                                                                    <span style="color: Red">*</span>
																	Whether The Company Is 100% Export Oriented Industry:
																</label>
																<div class="col-md-8">
																	<asp:DropDownList runat="server" ID="Drop1" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm">
																		<asp:ListItem>--Select--</asp:ListItem>
																		<asp:ListItem Value="YES">YES</asp:ListItem>
																		<asp:ListItem Value="No">No</asp:ListItem>
																	</asp:DropDownList>
																</div>
															</div>
														</div>
														<div class="panel panel-default">
															<div class="panel-heading">
																Is the applicant under priority category ? Please specify clearly &nbsp; <span class="checkbox-inline" style="padding-bottom: 20px;">
																	<asp:CheckBox runat="server" ID="chkpriority" AutoPostBack="true" OnCheckedChanged="chkpriority_CheckedChanged" /></span>
															</div>
															<div id="prioritydiv" class="panel-body" style="padding: 0px !important;" runat="server" visible="false">
																<div class="row aks-row">
																	<div class="col-md-4 col-sm-6 col-xs-12">
																		Specification&nbsp;:
																	</div>
																	<div class="col-md-8 col-sm-6 col-xs-12">
																		<asp:DropDownList runat="server" ID="ddlPriority" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm"></asp:DropDownList>
																		<asp:TextBox ID="txtapplicantpriorityspecification" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
																	</div>
																</div>
															</div>
														</div>
														<div class="form-group" style="margin-top: 15px;">
															<div class="row">
																<div class="col-md-4">
																	<span style="color: blue" class="pull-left">Field marked with <span style="color: Red">* </span>are mandatory</span>
																</div>
																<div class="col-md-4 text-center" style="display:none;">
																	<span class="text-center"><a href="#" runat="server" class="btn btn-default" style="padding: 3px 6px;" onserverclick="BtnProjectInsert_Click">Save & Proceed&nbsp;<i class="fa fa-long-arrow-right" aria-hidden="true"></i></a></span>
																	<asp:Button ID="BtnProjectInsert" Style="margin: 0 1px 0 0; width: 200px;" Visible="false" CssClass="btn btn-primary btn-sm" ValidationGroup="ValidationButton" OnClick="BtnProjectInsert_Click" runat="server" Text="Save & Proceed" /><asp:Button ID="Button2" Style="margin: 0; width: 65px;" CssClass="btn btn-primary btn-sm" runat="server" OnClick="Reset_Click" Text="Reset" Visible="false" />
																</div>
																<div class="col-md-4"></div>
															</div>
														</div>

    </asp:View>

            <%--Transfree Documents Checklist view --%>
    <asp:View ID="View6" runat="server">
        <asp:Label runat="server" ID="checkid" Visible="false"></asp:Label>
        <div class="panel panel-default">
            <div class="panel-body gallery">
           
             <uc1:UC_Service_Doc_Upload_View1 runat="server" ID="UC_Service_Doc_Upload_View1" />
                <asp:Label runat="server" ID="lblServiceReqNo" Visible="false"></asp:Label>

            </div>
        </div>

    </asp:View>



</asp:MultiView>




<asp:Label runat="server" ID="lblallotteName" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblAllotteeAddress" Visible="false"></asp:Label>
<asp:Label runat="server" ID="LblallotteeIA" Visible="false"></asp:Label>
<asp:Label runat="server" ID="LblallotteeReg" Visible="false"></asp:Label>
<asp:Label runat="server" ID="LblallotteePlotNo" Visible="false"></asp:Label>

<%--</ContentTemplate>
         </asp:UpdatePanel>--%>


       <script type="text/javascript">


           $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });

           function ShowMessage(page_name) {
               alert('Your Application Is submitted Successfully');
                      window.location.href = page_name;
               
           }

           function ShowGroups() {
               $("#btnNewGroup").click();
           }
           function validatepan() {

               var panVal = document.getElementById("<%= txtPanNo.ClientID %>").value;
               var regpan = /^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$/;
               if (panVal != "") {
                   if (regpan.test(panVal)) {
                       document.getElementById("<%= txtPanNo.ClientID %>").style.borderColor = "";
                    return true;
                } else {
                    alert("Invalid Pan Card");
                    document.getElementById("<%= txtPanNo.ClientID %>").style.borderColor = "Red";
                    document.getElementById("<%= txtPanNo.ClientID %>").value = "";

                    return false;
                }
            }
           }
           function validatepan1() {

               var panVal = document.getElementById("<%= txtTransfereePan.ClientID %>").value;
               var regpan = /^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$/;
               if (panVal != "") {
                   if (regpan.test(panVal)) {
                       document.getElementById("<%= txtTransfereePan.ClientID %>").style.borderColor = "";
                       return true;
                   } else {
                       alert("Invalid Pan Card");
                       document.getElementById("<%= txtTransfereePan.ClientID %>").style.borderColor = "Red";
                    document.getElementById("<%= txtTransfereePan.ClientID %>").value = "";

                    return false;
                   }
               }
           }
           function isDecimalKey(evt) {
               var charCode = (evt.which) ? evt.which : evt.keyCode
               if (charCode != 46 && charCode > 31
                   && (charCode < 48 || charCode > 57)) {
                   return false;
               } else {


               }
           }

           function IsValidEmail(email) {
               var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
               return expr.test(email);
           };
           function ValidateSignatoryEmail() {
               var email = document.getElementById("<%= txtSignatoryEmail.ClientID %>").value;
            if (email.length > 0) {
                if (!IsValidEmail(email)) {
                    alert("Invalid Email Id");
                    document.getElementById("<%= txtSignatoryEmail.ClientID %>").value = "";
                    document.getElementById("<%= txtSignatoryEmail.ClientID %>").style.borderColor = '#e52213';
                    return false;
                }
                else {

                    document.getElementById("<%= txtSignatoryEmail.ClientID %>").style.borderColor = "";
                    return true;
                }
            }
           }
           function ValidateIndividualEmail() {
               var email = document.getElementById("<%= txtIndividualEmail.ClientID %>").value;
               if (email.length > 0) {
                   if (!IsValidEmail(email)) {

                       //ShowPopup("<img src='/images/alert.jpg' width='38' height='38'> &nbsp;&nbsp;<span style='font-family:serif !important'>Invalid Email Id</span>");
                       alert("Invalid Email Id");
                       document.getElementById("<%= txtIndividualEmail.ClientID %>").value = "";
                        document.getElementById("<%= txtIndividualEmail.ClientID %>").style.borderColor = '#e52213';

                        return false;

                    }
                    else {

                        document.getElementById("<%= txtIndividualEmail.ClientID %>").style.borderColor = "";
                        return true;
                    }
                }
           }
           

           var prm = Sys.WebForms.PageRequestManager.getInstance();
           prm.add_endRequest(function (sender, e) {
               $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });


               function ShowMessage(page_name) {
                   alert('Your Application Is submitted Successfully');
                   window.location.href = page_name;

               }
               function ShowGroups() {

                   $("#btnNewGroup").click();
               }
               

           });
       </script>
