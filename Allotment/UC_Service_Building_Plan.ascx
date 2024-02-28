<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="true" CodeBehind="UC_Service_Building_Plan.ascx.cs" Inherits="Allotment.UC_Service_Building_Plan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>


<%@ Register Src="~/UC_Service_Allotteee_Detail.ascx" TagPrefix="uc1" TagName="UC_Service_Allotteee_Detail" %>
<%@ Register Src="~/UC_Service_Doc_Upload_View.ascx" TagPrefix="uc1" TagName="UC_Service_Doc_Upload_View" %>
<%@ Register Src="~/UC_Service_Payment_Detail.ascx" TagPrefix="uc1" TagName="UC_Service_Payment_Detail" %>

   <link href="css/chosen.min.css" rel="stylesheet" />
    <script src="js/chosen.jquery.min.js"></script>
<style>

    .row {
        margin-left: 0px;
        margin-right: 0px;
    }
    a.static.selected {
			text-decoration: none;
			border-style: none;
			color: #000000 !important;
            background: #ffdb6d;
		}
        .iadsashboard-dayul-inbox ul li a {
            text-decoration: none !important;
            white-space: nowrap;
            display: block;
            padding: 4px 6px;
            color: #2b2b2b;
        }

          .iadsashboard-dayul-inbox li {
                /* padding-left: 5px; */
                /* padding-right: 5px; */
                background: #ffc511;
                text-align: center;
                margin: 0px 2px;
                /* width: 127px; */
                /* height: 21px; */
                font-size: 13px;
                font-weight: 600;
                box-shadow: 7px 0 16px #ccc;
                color: #000000;
                border: 1px solid #8e8e8e;
            }

          #ContentPlaceHolder1_sub_menu a
        {
            padding:3px 8px;
            }
#ContentPlaceHolder1_sub_menu ul
{
    list-style-type:none !important;
        list-style: none !important;
    margin: 0;
    background: #e2e2e2;
    padding: 0;
    width: auto;
    }
		

	
		.sub_menu li {
			position: relative;
			    font-size: 12px;
    color: #2d2d2d;
    border-bottom: 1px solid #ffffff;
    padding: 1px 1px !important;
    font-weight: 500;
		}

        #Service_Building_Plan_sub_menu a.static {
    padding-left: 1.15em !important;
    padding-right: 1.15em !important;
}
        ul, menu, dir {
 
    list-style-type: none !important;
   
}

</style>

    <script type="text/javascript">

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();
        }
    function isDecimalKey(evt) {
                var charCode = (evt.which) ? evt.which : evt.keyCode
                if (charCode != 46 && charCode > 31
                    && (charCode < 48 || charCode > 57)) {
                    return false;
                } else {


                }
            }

  function Hutment(txt) {

            var CoveredArea = txt.value;
            if (isNaN(CoveredArea)) {
                alert("Invalid entry");
                txt.value = "";
            } else {
                $('#<%=lblHutmentAmount.ClientID%>').html(Math.round(CoveredArea * (0.25)));

            }
        }

        function OtherCharges(txt) {

            var CoveredArea = txt.value;
            if (isNaN(CoveredArea)) {
                alert("Invalid entry");
                txt.value = "";
            } else {
                var PlotSize = $('#<%=lblPlotSize.ClientID%>').html();
                if (CoveredArea > 0) {
                    if (PlotSize <= 1000) {
                        $('#<%=lblOtherChrges.ClientID%>').html(Math.round((0.25) * (5000)));
                    } else {
                        $('#<%=lblOtherChrges.ClientID%>').html(Math.round((0.25) * (20000)));
                    }
                } else
                {
                    $('#<%=lblOtherChrges.ClientID%>').html(0);
                }
            }
        }

       
        
    </script>

<%--   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always"  >



   <ContentTemplate>--%>
      

<cc1:MessageBox ID="MessageBox1" runat="server" />
<div class="row hidden" runat="server" id="main_menu">
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
    
            

            <div style="float: left; background: #dbdbdb;  border-left: 1px solid #000; font-size: 11px;" class="text-center">
                Navigation<br />
                <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                    <li>
                        <a style="color: #dbdbdb !important;">
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
                        <a style="color: #f1f1f1 !important;">
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
<input type="button" value="Click Me" style="display: none;" id="btnNewGroup" data-toggle="modal" data-target="#myModalB">
<div class="modal fade" id="myModalB" role="dialog">
    <div class="modal-dialog">

        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Confirmation</h4>
            </div>
            <div class="modal-body">
                <div class="col-md-12" style="font-size: 12px; padding: 4px 15px;">Kindly confirm all manatory data and documents have been uploaded before final submission. </div>
                <div class="clearfix"></div>
            </div>
            <div class="modal-footer">
                <div class="pull-right border-buttons">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-sm btn-primary btn-popup" Style="margin-right: 3px;" Text="Submit" OnClick="Pop_Click" />
                    <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal" style="margin-right: 0;">Close</button>
                </div>
            </div>
        </div>

    </div>
</div>





   <asp:Menu
        id="sub_menu"
        Orientation="Horizontal"   
        OnMenuItemClick="Menu1_MenuItemClick"
        CssClass="ist-inline iadsashboard-dayul-inbox"
		StaticSelectedStyle-CssClass="sub_menu_active"
        Runat="server">
      <%--  <Items>
        <asp:MenuItem Text="Allotee Detail"                Value ="0" />
        <asp:MenuItem Text="Payment Checklist"             Value ="1"  />
        <asp:MenuItem Text="Documents Checklist"           Value ="2" />
        <asp:MenuItem Text="Architect/Structural Engineer" Value ="3" />
        <asp:MenuItem Text="Building Specification"        Value ="4" />
        </Items>    --%>
    </asp:Menu>

<asp:MultiView ID="MultiViewBuildingPlan" runat="server">

    <%--PreRequest  --%>
    <asp:View ID="AlloteeDetial" runat="server">
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
            
                        </div>
                        <div class="col-md-4">
                            <div class="btn-group">
                                <%--  <asp:Button ID="btnSubmit" CssClass="btn btn-primary register " runat="server" OnClick="btnSubmit_Click" Text="Save" />--%>
                                <asp:Button ID="btnReset" CssClass="btn btn-primary register " runat="server" Text="Reset" Enabled="false" Style="display: none;" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

           
            <div class="panel-heading font-bold  text-center" style="font-size: 16px !important;">Allottee Detail </div>
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



                    


                </div>






                <table class="table table-striped table-bordered table-hover">
                    <tr style="display: none;">
                        <td colspan="2" style="text-align:left;">
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


                    <tr id="lableMessage" runat="server"  style="display:none;"  visible="false">
                        <td style="display: none;"  colspan="2">
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
            <div  runat="server" id="service_app_type"  visible="false">
                    <div class="clearfix"></div>
                    <div class="panel-heading font-bold">Raise Service Request from here </div>
                    <!--<div class="form-group">
                        <label class="col-md-2">
                            <span style="color: Red">*</span>Application Type
                        </label>
                        <div class="col-md-10">
                            <asp:DropDownList ID="ddlApplication" runat="server" CssClass="btn btn-default dropdown-toggle input-sm similar-select1"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" -->

                  <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-2">
                            <span class="text-right">Raise service request for</span>
                        </label>
                        <div class="col-md-10">
                            <asp:DropDownList ID="ddlCaseType" runat="server" CssClass="btn btn-default dropdown-toggle input-sm similar-select1" OnSelectedIndexChanged="ddlCaseType_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                 <asp:ListItem Value="1">Errect New Building</asp:ListItem>
                                 <asp:ListItem Value="2">Re Errect Building</asp:ListItem>
                                 <asp:ListItem Value="3">Revision/Modification</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="lblArea" runat="server" Text="" Visible="false"></asp:Label>
                        </div>
                       
                    </div>
                  <div class="form-group">
                        <label class="col-md-7">
                            <span class="text-right">GST No (If you want to avail input tax credit please mention GST No)</span>
                        </label>
                        <div class="col-md-5">
                             <asp:TextBox ID="txtGstNo" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox>                       
                        </div>                      
                    </div>
                 <div runat="server" id="Div_NewBuilding" visible="false">
                  <div class="clearfix"></div>
                  <hr class="myhrline" />
                 <div class="form-group">
                        <label class="col-md-2">
                          Covered/Builtup Area
                        </label>
                        <div class="col-md-10">
                          <asp:TextBox ID="txtBuiltUpArea" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                        </div>
                      
                </div>
                     </div>
                   <div runat="server" id="Div_Revision" visible="false">
                  <div class="clearfix"></div>
                  <hr class="myhrline" />
                 <div class="form-group">
                        <label class="col-md-4">
                          Previous Approved Covered/Builtup Area
                        </label>
                        <div class="col-md-2">
                          <asp:TextBox ID="txtPrevBuiltUpArea" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                        </div>
                      <label class="col-md-3">
                          Revised Covered/Builtup Area
                        </label>
                        <div class="col-md-3">
                          <asp:TextBox ID="txtRevBuiltUpArea" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                        </div>
                      
                </div> 
                 <div class="clearfix"></div>
                  <hr class="myhrline" />
                 <div class="form-group">
                        <label class="col-md-4">
                          Previous Fee Details
                        </label>
                        <div class="col-md-4">
                         <asp:CheckBox ID="chk_MalbaPaid" runat="server"  Text="Malba Charges Paid Previously" AutoPostBack="true" OnCheckedChanged="chk_MalbaPaid_CheckedChanged" />
                        </div>
                      <div class="col-md-4">
                         <asp:CheckBox ID="chk_InfraPaid" runat="server" Text="Infrastructure Upgradation Charges Paid Previously" AutoPostBack="true" OnCheckedChanged="chk_InfraPaid_CheckedChanged" />
                        </div>
                   
                </div> 
                       </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                 <div class="text-center">
                          <asp:Button CssClass="btn-primary ey-bg" runat="server" ID="Btn_FirstP" Text="Proceed" OnClick="Btn_FirstP_Click" />
                          <asp:Button CssClass="btn-primary ey-bg" runat="server" ID="btnGenerate" Text="Apply" OnClick="btnGenerate_Click" visible="false"/>
                          <asp:Button CssClass="btn-primary ey-bg" runat="server" ID="btnResetChoice" Text="Reset" OnClick="btnResetChoice_Click" visible="false"/>
                        </div>





                        </div>
            
   
               <%-- <uc1:UC_Service_Payment_Detail runat="server" id="UC_Service_Payment_Detail" />--%>
               <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

           
        </div>

    </asp:View>



    <%--Checklist Documents --%>
    <asp:View ID="DocumentsChecklist" runat="server">
        <div class="panel panel-default">
            <div class="panel-heading" style="width: 100%;">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-4">
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


    <%--Structural Engiineering  --%>
    <asp:View ID="Structural" runat="server">
        <div runat="server" id="building_plan" class="panel panel-default">
            <div class="panel-heading" style="width: 100%;">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-4">
                            <div class="btn-group">
                                <asp:Button ID="Previous1" runat="server" CssClass="btn btn-primary register " Text="Previous" OnClick="btnprev_Click" Style="display: none;" />
                                <asp:Button ID="btnNext1" CssClass="btn btn-primary register " runat="server" OnClick="btnnext_Click" Text="Next" Style="display: none;" />

                            </div>
                        </div>
                        <div class="col-md-4">
                            <p><b>Architect/Structural Engineer Detail</b></p>
                        </div>
                        <div class="col-md-4">
                            <div class="btn-group">
                                <asp:Button ID="btnSubmit" CssClass="btn btn-primary register " runat="server" OnClick="btnSubmit_Click" Text="Save" Style="display: none;" />
                                <asp:Button ID="btnSaveApplicant" CssClass="btn btn-primary register " runat="server" OnClick="btnSaveBuildingSpec_Click" Text="Save" Style="display: none;" />
                                <asp:Button ID="Button4" CssClass="btn btn-primary register " runat="server" Text="Reset" Style="display: none;" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-body">

                <div runat="server" id="hideDiv" visible="false">
                    <div class="panel-heading font-bold">Architect Detail</div>
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Name of Architect
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtNameTechnical" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Architect Licensed No :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtLicensedPerson" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Architect Registration No
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtRegistration" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Address of Architect:
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtAddressPerson" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />

                    <div class="panel-heading font-bold">Structural Engineer Detail</div>
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Name of Structural Engineer
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtStructuralEngineer" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Structural Engineer Licensed No :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtStructuralEngineerLicensedNo" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Structural Engineer Registration No :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtStructuralEngineerRegistratinNo" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Address of Structural Engineer:
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtStructuralEngineerAddress" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                                <asp:Button runat="server" Text="Submit" ID="btnSaveArchitect" CssClass="btn-primary ey-bg" style="float: right;margin: 8px 0;" OnClick="btnSaveArchitect_Click"/>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                   
                </div>
            </div>
        </div>
    </asp:View>


    
    <%--Building Specification--%>
    <asp:View ID="BuildingSpecification" runat="server">
        <div class="panel panel-default">
            <div class="panel-heading" style="width: 100%;">
                <div class="row">
                    <div class="col-md-12">

                        <div class="col-md-4">
                            <div class="btn-group">
                                <asp:Button ID="Previous3" runat="server" CssClass="register btn btn-primary" Text="Previous" OnClick="btnprev_Click" Style="display: none;" />
                                <asp:Button ID="btnNext3" CssClass="register btn btn-primary" runat="server" OnClick="btnnext_Click" Text="Next" Visible="false" Style="display: none;" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <p>
                                <b>
                                    <asp:Label ID="lblHead" runat="server" Text=""></asp:Label></b>
                            </p>
                        </div>
                        <div class="col-md-4 btn-group">
                            <div class="btn-group">
                                <asp:Button ID="btnRisk" CssClass="register btn btn-primary" runat="server" Text="Risk Assessment" Style="display: none;" />
                                <asp:Button ID="btnInspection" CssClass="register btn btn-primary " runat="server" Text="Initiate Inspection" Style="display: none;" />
                                <asp:Button ID="btnFar" CssClass="register btn btn-primary" runat="server" OnClick="btnFar_Click" Text="Save" Style="display: none;" />
                                <asp:Button ID="Button12" CssClass="btn btn-primary register " runat="server" Text="Reset" Style="display: none;" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-body ">

                <div style="text-align:left;">
                    <span class="font-12px">Plot Size :</span>
                    <asp:Label ID="lblPlotSize" runat="server" Text="Label" CssClass="font-12px"></asp:Label><span class="font-12px"> sqr mtr</span>
                </div>

                <div class="table-responsive">
                    <table class="table table-bordered table-hover request-table" id="datatableService">
                        <thead>
                            <tr>
                                <th style="width: 250px">Description</th>
                                <th style="width:50px;">Byelaws </th>
                                <th>Unit</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td><span style="color: Red">* </span>FAR(in Percentage)</td>
                                <td>
                                    <asp:Label ID="lblFarByelaws" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFar" CssClass="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td><span style="color: Red">* </span>Ground Coverage (in Percentage)</td>
                                <td>
                                    <asp:Label ID="lblGroundBylo" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGroundcover" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td><span style="color: Red">* </span>Total Covered Area (in SqrMts)</td>
                                <td>
                                    <asp:Label ID="lblCoveredArea" runat="server" Text="N/A"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCoveredArea" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td><span style="color: Red">* </span>Height(In mts)</td>
                                <td>
                                    <asp:Label ID="lblHeight" runat="server" Text="N/A"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHeight" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align:left;"><span style="color: Red">* </span>Set Back(In mts)</td>
                            </tr>
                            <tr>
                                <td style="text-align:right;"><span style="color: Red">* </span>front</td>
                                <td>
                                    <asp:Label ID="lblSetBackFront" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSetBackFront" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;"><span style="color: Red">* </span>Rear
                                </td>
                                <td>
                                    <asp:Label ID="lblSetBackRear" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSetBackRear" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;"><span style="color: Red">* </span>Side1</td>
                                <td>
                                    <asp:Label ID="lblSetBackSide1" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSetBackSide1" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;"><span style="color: Red">* </span>Side2</td>
                                <td>
                                    <asp:Label ID="lblSetBackSide2" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSetBackSide2" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align:left;"><span style="color: Red">* </span>Classification of Indiustries Based on Degree of Hazard</td>
                            </tr>
                            <tr>
                                <td>Classification of Hazard</td>
                                <td colspan="2">

                                    <asp:DropDownList ID="ddlNature" runat="server" Style="width: 100% !important" CssClass="chosen btn btn-default dropdown-toggle input-sm mynewselect">
                                        
                                    </asp:DropDownList>

                                </td>
                            </tr>


                            <tr>
                                <td><span style="color: Red">* </span>Occupancy</td>
                                <td colspan="2">


                                    <asp:TextBox ID="txtOccupancy" CssClass="input-sm myyellowbgsmall" runat="server"></asp:TextBox>


                                </td>
                            </tr>


                        </tbody>
                    </table>



                    <table class="table table-bordered table-hover request-table" >
                            <thead>
                                <tr>
                                    <th style="width:250px">Floors</th>
                                    <th style="<%= HiddenClassNameEx %>">Existing </th>
                                    <th style="<%= HiddenClassNamePr %>">Proposed</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>BaseMent(in Sqmts)</td>
                                    <td style="<%= HiddenClassNameEx %>">
                                        <asp:TextBox ID="txtBaseMent1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                    </td>
                                    <td style="<%= HiddenClassNamePr %>">
                                        <asp:TextBox ID="txtBaseMent2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ground Floor(in Sqmts)</td>
                                    <td style="<%= HiddenClassNameEx %>">
                                        <asp:TextBox ID="txtGround1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                    </td>
                                    <td style="<%= HiddenClassNamePr %>">
                                        <asp:TextBox ID="txtGround2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>First Floor(in Sqmts)</td>
                                    <td style="<%= HiddenClassNameEx %>">
                                        <asp:TextBox ID="txtFirstfloor1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                    </td>
                                    <td style="<%= HiddenClassNamePr %>">
                                        <asp:TextBox ID="txtFirstfloor2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td >Second Floor(in Sqmts)</td>
                                    <td style="<%= HiddenClassNameEx %>">
                                        <asp:TextBox ID="txtSecondFloor1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                    </td>
                                    <td style="<%= HiddenClassNamePr %>">
                                        <asp:TextBox ID="txtSecondFloor2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                    </td>
                                </tr>                      
                                <tr>
                                    <td style="text-align:left;">Mezzanine Floor(in Sqmts)</td>
                                    <td style="<%= HiddenClassNameEx %>">
                                        <asp:TextBox ID="txtMezzanine1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                    </td>
                                    <td style="<%= HiddenClassNamePr %>">
                                        <asp:TextBox ID="txtMezzanine2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left;">Stilt Floor(in Sqmts)</td>
                                    
                                    <td colspan="2" style="<%= HiddenClassNamePr %>">
                                        <asp:TextBox ID="txtStealth" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left;">Mumti(in Sqmts)</td>
                                    
                                    <td colspan="2" style="<%= HiddenClassNamePr %>">
                                        <asp:TextBox ID="txtMumti" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="text-align:left;">Purpose for which  building Use
                                    </td>
                                      <td colspan="2" style="<%= HiddenClassNamePr %>">
                                        <asp:TextBox ID="txtbuildingPurpose" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                    </td>
                                </tr>
                            </tbody>
                        </table>

                         <table class="table table-bordered table-hover request-table" id="RevisionDetailsTbl" runat="server" visible="false" >
                          <thead>
                                <tr>
                                    <th style="width:250px" >Previous Details</th>
                                    <th></th>
                                  
                                </tr>
                            </thead>
                          <tbody>
                                
                               
                                <tr>
                                    <td style="text-align:left;">Previous Approved Builtup Area (In SqrMts)</td>
                                    <td>
                                    <asp:Label runat="server" ID="prevAppBPArea_lbl"></asp:Label>

                                    </td>
                                </tr>
                               <tr>
                                    <td style="text-align:left;">Malba Charges Paid Previously</td>
                                    <td>
                                       <asp:Label runat="server" ID="MalbaPaid_lbl"></asp:Label>

                                    </td>
                                </tr>
                               <tr>
                                    <td style="text-align:left;">Infrastructure Development Charges Paid Previously</td>
                                    <td>
                                      <asp:Label runat="server" ID="InfraPaid_lbl"></asp:Label>


                                    </td>
                                </tr>
                            </tbody>
                         </table>

                         <table class="table table-bordered table-hover request-table" id="TemporaryStructureDetails" >
                           <thead>
                                <tr>
                                    <th style="width:250px" >Temporary Structure Details</th>
                                    <th></th>
                                  
                                </tr>
                            </thead>
                          <tbody>
                                
                               
                                <tr>
                                    <td style="text-align:left;">Is any temporary structure proposed</td>
                                    <td>
                                     <asp:DropDownList ID="drpTemoraryStructure" runat="server" Style="width: 100% !important" CssClass="chosen btn btn-default dropdown-toggle input-sm mynewselect" AutoPostBack="true" OnSelectedIndexChanged="drpTemoraryStructure_SelectedIndexChanged">
                                         <asp:ListItem Value="2">--Select--</asp:ListItem>
                                         <asp:ListItem Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:DropDownList> 

                                    </td>
                                </tr>
                            </tbody>
                      </table>

                    <table class="table table-bordered table-hover request-table" id="TemporaryStructureUse" runat="server" visible="false"  >
                           
                        
                               
                                <tr>
                                    <td style="text-align:left;width:250px;font-weight:700;">Temporary Structure Use</td>
                                    <td style="text-align:center;width:250px;font-weight:700;">Covered Area (In SQM)</td>
                                     <td style="text-align:center;width:250px;font-weight:700;">Amount</td>
                                    </tr>
                               <tr>
                                    <td style="text-align:left;">
                                  Labour Hutment

                                    </td>
                                    <td>
                                      <asp:TextBox ID="txtHutment" onkeyup="Hutment(this)"  class="input-sm myyellowbgsmall" runat="server"></asp:TextBox> x (0.25)
                                    </td>
                                   <td><asp:Label runat="server" ID="lblHutmentAmount"></asp:Label></td>
                                </tr>
                                 <tr>
                                  
                                    <td>
                                  Other Uses

                                    </td>
                                    <td>
                                      <asp:TextBox ID="txtOtherCharges" onkeyup="OtherCharges(this)" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox> x 25% of applicable processing fee
                                    </td>
                                      <td><asp:Label runat="server" ID="lblOtherChrges"></asp:Label></td>
                                </tr>
                          
                      </table>
                        
                        <table class="table table-bordered table-hover request-table" id="datatableService2" >
                            <thead>
                                <tr>
                                    <th style="width:250px"></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                
                                <tr>
                                    <td style="text-align:left;" colspan="2"><b>Construction Specification</b></td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">Foundation</td>
                                    <td>
                                        <asp:TextBox ID="txtFoundation" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">Walls</td>
                                    <td>
                                        <asp:TextBox ID="txtWalls" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                  <tr>
                                    <td style="text-align:right;">Floors</td>
                                    <td>
                                        <asp:TextBox ID="txtFloors" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="text-align:right;">Roofs</td>
                                    <td>
                                        <asp:TextBox ID="txtRoofs" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">Number of storeys</td>
                                    <td>
                                        <asp:TextBox ID="txtStories" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">Number of latrines</td>
                                    <td>
                                        <asp:TextBox ID="txtLatrines" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">Any Previous Construction </td>
                                    <td>
                                        <asp:TextBox ID="txtPreviousConstruction" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="text-align:right;">Source of Water for Building Purpose </td>
                                    <td>
                                        <asp:TextBox ID="txtWaterSource" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                </tbody>
                            </table>
                            <div>
                                <asp:Button runat="server" Text="Save & Finalise" ID="btnSaveF" CssClass="btn-primary ey-bg" style="float: right;margin: 8px 0;" OnClick="btnSaveF_Click"/>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />

                </div>



            </div>
        </div>
    </asp:View>


    <%--Pay & Submit--%>
    <asp:View ID="View4" runat="server">
        <div class="panel panel-default">
              <div style="background: #e2e2e2;text-align: right;padding: 10px 0;border: 1px solid #cacaca;"><asp:Button runat="server" Style="background: #ffc511;border: 1px solid #ccc;color: #000;font-size: 14px;" ID="btnPay" Text="Pay Now" CssClass="btn btn-sm btn-primary" OnClick="btnPay_Click"/> <asp:Button runat="server" Style="background: #ffc511;border: 1px solid #ccc;color: #000;font-size: 14px;" ID="BtnResubmit" Text="Resubmit" CssClass="btn btn-sm btn-primary" OnClick="BntResubmit_Click" Visible="false"/> <asp:Button runat="server" Style="background: #ffc511;border: 1px solid #ccc;color: #000;font-size: 14px;" ID="btnRePayment" Text="Make Revised Payment" CssClass="btn btn-sm btn-primary" OnClick="btnRePayment_Click" Visible="false"/></div>
             <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
        </div>
    </asp:View>


    <%--Transfer Of Plot--%>
    <asp:View ID="View5" runat="server">
        <div class="panel panel-default">

            <div class="panel-heading" style="width: 100%;">
                <div class="row">
                    <div class="col-md-12">


                        <div class="col-md-12" style="text-align: center;">
                            <p><b>Pre Requisite</b></p>
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
        <div class="panel-body">
            <div class="" style="border: 1px solid #ccc; width: 100%; background: #f1f1f1;">
                <div class="panel-heading" style="font-weight: 700;">Pre-clearance check for applying the Transfer Of Plot :- </div>
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
                    <label class="col-md-2 text-right">Processing Fees :</label>
                    <div class="col-md-1">
                        <asp:Label ID="Label1" runat="server" Text="2000"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <span><i class="fa fa-times" aria-hidden="true" style="color: red" runat="server" id="I1" visible="false"></i></span>
                        <span><i class="fa fa-check" aria-hidden="true" style="color: #3bce3b;" runat="server" id="I2"></i></span>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <label class="col-md-2 text-right">Pending Dues :</label>
                    <div class="col-md-1">
                        <asp:Label ID="Label2" runat="server" Text="0"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <span><i class="fa fa-times" aria-hidden="true" style="color: red" runat="server" id="I3" visible="false"></i></span>
                        <span><i class="fa fa-check" aria-hidden="true" style="color: #3bce3b;" runat="server" id="I4"></i></span>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />

                <div class="form-group">
                    <label class="col-md-2 text-right">Time Extension fees :</label>
                    <div class="col-md-1">
                        <asp:Label ID="Label3" runat="server" Text="0"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <span><i class="fa fa-times" aria-hidden="true" style="color: red" runat="server" id="I5" visible="false"></i></span>
                        <span><i class="fa fa-check" aria-hidden="true" style="color: #3bce3b;" runat="server" id="I6"></i></span>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <label class="col-md-2 text-right">Total :</label>
                    <div class="col-md-1">
                        <asp:Label ID="Label4" runat="server" Text="0"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <span><i class="fa fa-times" aria-hidden="true" style="color: red" runat="server" id="I7" visible="false"></i></span>
                        <span><i class="fa fa-check" aria-hidden="true" style="color: #3bce3b;" runat="server" id="I8"></i></span>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <label class="col-md-2 text-right"><%--Message :--%></label>
                    <div class="col-md-10">
                        <ul class="list-unstyled">
                            <li runat="server" id="Li1">Your Payment and dues are Complete, You can proceed for apply.</li>
                            <li runat="server" id="Li2" visible="false">Before applying for the services, you need to execute the lease deed or clear the pending dues.</li>
                        </ul>
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="form-group">
                    <label class="col-md-2 text-right"><%--Message :--%></label>
                    <div class="col-md-10">
                        <asp:Button ID="paybtn" runat="server" CssClass="btn btn-sm btn-primary" Text="Pay"  Enabled="false" />
                    </div>
                </div>
                <div class="clearfix"></div>

                <asp:Label ID="lblIAID" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblCoveredAreaStatus" runat="server" Visible="false"></asp:Label>
                  <asp:Label ID="lblChangeStatus" runat="server" Visible="false"></asp:Label>
                  <asp:Label ID="lblOldCoveredArea" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblPlotArea" runat="server" Visible="false"></asp:Label>
                <asp:HiddenField runat="server" id="hidAmt" />
                   <asp:HiddenField runat="server" ClientIDMode="Static" EnableViewState="true" ID="HidStatus" />
            </div>


        </div>
       
    </asp:View>


</asp:MultiView>

<asp:Label runat="server" ID="lblallotteName" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblAllotteeAddress" Visible="false"></asp:Label>
<asp:Label runat="server" ID="LblallotteeIA" Visible="false"></asp:Label>
<asp:Label runat="server" ID="LblallotteeReg" Visible="false"></asp:Label>
<asp:Label runat="server" ID="LblallotteePlotNo" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblAllotteePhone" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblAllotteeEmail" Visible="false"></asp:Label>

<%--</ContentTemplate>
         </asp:UpdatePanel>--%>


       <script type="text/javascript">



           $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });

           function ShowMessage() {
               alert('Your Application Is submitted Successfully');
               window.location.href = 'ServiceRequestSubmitted.aspx';

           }
           function ShowGroups() {

               $("#btnNewGroup").click();
           }

           var prm = Sys.WebForms.PageRequestManager.getInstance();
           prm.add_endRequest(function (sender, e) {
               $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });


               function ShowMessage() {
                   alert('Your Application Is submitted Successfully');
                   window.location.href = 'ServiceRequestSubmitted.aspx';

               }
               function ShowGroups() {

                   $("#btnNewGroup").click();
               }

           });
       </script>
