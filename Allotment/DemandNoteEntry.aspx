<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="DemandNoteEntry.aspx.cs" Inherits="Allotment.DemandNoteEntry" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



    <style>
         @media screen and (max-width: 768px) {
            .form-group .col-xs-6 {
                width: 50% !important;
            }
        }
        .div-companydetail label {
            font-weight:700 !important;
        }
        .content {
            min-height:600px;
        }
        .request-table tr a:before {
            margin: 0px 3px;
        }
          #UpdateProgress1 {
               position: fixed;
               width: 100%;
               height: 100%;
               z-index: 99999;
               background: rgba(0,0,0,0.21176470588235294);
           }
           #UpdateProgress1 .fgh{
                position: absolute;
                top: 45%;
                margin: 0px auto;
                left: 45%;
                z-index: 999;
           }

           .btn-change{
    height: 27px;
    width: 57px;
    background: #ffc511;
    margin: 20px;
    float: left;
    box-shadow: 0 0 1px #ccc;
    -webkit-transition: all 0.5s ease-in-out;
    border: 0px;
    color: #464646;
}
.btn-change:hover{
    -webkit-transform: scale(1.07);
    background: #c5980a;
    color: #fff;
}
         
    </style>
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
   
    
    
       <%-- <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
			<ContentTemplate>
				<asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
					<ProgressTemplate>
						<div class="fgh">
							<div class="hgf">
								<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
							</div>
						</div>
					</ProgressTemplate>
				</asp:UpdateProgress>--%>

                 <cc1:MessageBox ID="MessageBox1" runat="server" />
 
    <div class="row">
        <div class="panel panel-default">
            <div class="form-group" style="background: #dadada;padding: 2px 0;margin-bottom: 3px;">
                <div class="">
                    <label class="col-md-2 col-sm-2 col-xs-6">
                        Regional Office :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-6">
                        <asp:DropDownList runat="server" ID="ddloffice" style="background:#fff;" CssClass="input-sm similar-select1" OnSelectedIndexChanged="Regional_Changed" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div  class="hidden-sm hidden-md hidden-lg clearfix"></div>
                    <label class="col-md-2 col-sm-2 col-xs-6">
                        Industrial Area :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-6">
                        <asp:DropDownList runat="server" ID="drpdwnIA" style="background:#fff;" CssClass="input-sm similar-select1" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div  class="hidden-sm hidden-md hidden-lg clearfix"></div>
                    <label class="col-md-1 col-sm-1 col-xs-6">
                        Plot No :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-6">
                        <asp:DropDownList runat="server" ID="ddlPlotNo" style="background:#fff;" CssClass="input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="ddlPlotNo_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div  class="hidden-sm hidden-md hidden-lg clearfix"></div>
                    <div class="col-md-1 col-sm-1 col-xs-12">
                        <asp:Button ID="btnfetch" runat="server" Text="Fetch" CssClass="btn-primary ey-bg pull-right"/>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="panel panel-default" style="border:1px solid #ccc;">
                <div class="col-md-12 col-sm-12 col-xs-12 pad-rt0 pad-lt0">
                    <div class="">
                        <div class="panel-heading font-bold">
                            Applicant Details                         
                        </div>
                        <div class="panel-body" style="padding: 0px !important;">
                            <div class="div-companydetail" style="background: #ececec;">
                                <div class="form-group">
                                    <div class="">
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Regional Office :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6"><em>
                                                <asp:Label ID="lblRegionalOffice" runat="server" CssClass="font-bold"></asp:Label></em>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Industrial Area : 
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6"><em>
                                                <asp:Label ID="lblIndustrialArea" runat="server" CssClass="font-bold"></asp:Label></em>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Date of Allotment :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6"><em>
                                                <asp:Label ID="lblDateofApplication" runat="server" CssClass="font-bold"></asp:Label></em>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <div class="">                                                                                
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Application Date :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6"><em>
                                                <asp:Label ID="lblApplicationDate" runat="server" CssClass="font-bold"></asp:Label></em>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Allottment Letter No :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6"><em>
                                                <asp:Label ID="lblAllotmentLetterNo" runat="server" CssClass="font-bold"></asp:Label></em>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Plot No :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6"><em>
                                                <asp:Label ID="lblPlotNo" runat="server" CssClass="font-bold"></asp:Label></em>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <div class="">                                                                                
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                             Plot Area :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6"><em>
                                                <asp:Label ID="lblplotarea" runat="server" CssClass="font-bold"></asp:Label></em>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Firm/Company Name :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6"><em>
                                                <asp:Label ID="lblFirmCompanyName" runat="server" CssClass="font-bold"></asp:Label></em>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Constitution :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6"><em>
                                                <asp:Label ID="lblCompanyConstitution" runat="server" CssClass="font-bold"></asp:Label></em>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />

                                <div class="form-group">
                                    <div class="">

                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Firm/Company PAN No :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6"><em>
                                                <asp:Label ID="lblPanNo" runat="server" CssClass="font-bold"></asp:Label></em>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Firm/Company CIN No :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6"><em>
                                                <asp:Label ID="lblCinNo" runat="server" CssClass="font-bold"></asp:Label></em>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Authorised Signatory :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6"><em>
                                                <asp:Label ID="lblAuthorisedSignatory" runat="server" CssClass="font-bold"></asp:Label></em>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />

                                <div class="form-group">
                                    <div class="">                                                                                
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Signatory Mobile :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6"><em>
                                                <asp:Label ID="lblSignatoryMobile" runat="server" CssClass="font-bold"></asp:Label></em>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Address :   
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6"><em>
                                                <asp:Label ID="lblAddress" runat="server" CssClass="font-bold"></asp:Label></em>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Signatory Email : 
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6"><em>
                                                <asp:Label ID="lblSIgnatoryEmail" runat="server" CssClass="font-bold"></asp:Label></em>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <div class="row">
                                                                                
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                              
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
            <hr class="separation" />
            <div class="">
                
                    <div class="col-md-5 col-sm-12 col-xs-12" style="">
                        <div class="row" style="border: 15px solid #ccc;">
                            <div class="col-md-12 col-sm-12 col-xs-12" style="border-right: 4px solid #ccc;padding: 0px !important;">
                                  <table class="table table-striped table-responsive table-bordered table-hover request-table">
                                 
                                    <tr>
                                        <td>Demand Notice As On </td>
                                        <td >
                                            <asp:TextBox runat="server" ID="txtDemandDate" CssClass="date input-sm similar-select1" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                      </table>
                              <%--  <div class="panel-heading font-bold">Dues as of 31/12/2018</div>--%>
                           <asp:GridView ID = "GridView1" CssClass="table table-striped table-responsive table-bordered table-hover request-table" runat = "server" ShowFooter="true" AutoGenerateColumns="false">
             <Columns>
                   <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                 <asp:TemplateField HeaderText="Dues" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>' ></asp:Label> 
                    </ItemTemplate> 
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dues">
                    <ItemTemplate>
                        <asp:Label ID="lblPayDescription" runat="server" Text='<%#Eval("Description") %>' ></asp:Label> 
                    </ItemTemplate> 
                    <FooterTemplate>
                       <asp:Label ID="lbl" runat="server" Text="Grand Total" CssClass="text-right" ></asp:Label> 
        </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Values">
                    <ItemTemplate>
                        <asp:TextBox ID = "txtAmount" runat = "server" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);"></asp:TextBox> 
                    </ItemTemplate> 
                      <FooterTemplate>
                       <asp:Label ID="lbltotal" runat="server"  ></asp:Label> 
        </FooterTemplate>
                </asp:TemplateField> 

            </Columns> 
        </asp:GridView>

                                <div class="clearfix"></div>

                                <table class="table table-striped table-responsive table-bordered table-hover request-table" style="display:none;">
                                    <tr>
                                        <asp:Label runat="server" ID="lblAllotteeID" Visible="false"></asp:Label>
                                       
                                        <th style="width:70%;">Dues</th>
                                        <th style="width:30%;">Amount(In Rs)</th>
                                    </tr>
                                    <tr>
                                        <td>Installment Of Premium</td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesPremium" CssClass="input-sm similar-select1" Width="100%" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Interest On Premium </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesInterestOnPremium" CssClass="input-sm similar-select1" Width="100%" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Maintenance Charge </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesMaintenanceCharge" CssClass="input-sm similar-select1" Width="100%" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Interest On Maintenance Charge</td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesIntOnMaintenanceCharge" CssClass="input-sm similar-select1" Width="100%" ></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Lease Rent</td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesLeaseRent" CssClass="input-sm similar-select1" Width="100%" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>GST On Lease Rent</td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesGSTOnLeaseRent" CssClass="input-sm similar-select1" Width="100%" ></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Time Extension Fee</td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesTEF" CssClass="input-sm similar-select1" Width="100%" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Interest On Time Extension</td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesIntOnTEF" CssClass="input-sm similar-select1" Width="100%" ></asp:TextBox>
                                        </td>
                                    </tr>
                                  
                                    <tr>
                                        <td><span class="pull-right"><strong>Total</strong></span></td>
                                        <td>
                                            <i class="fa fa-inr"></i> <asp:Label runat="server" ID="lblTotalAmount" Text="12345" ></asp:Label>
                                        </td>
                                    </tr>
                                    <!--<tr>
                                        <td>Transfer Levy Criteria</td>
                                        <td colspan="3">
                                            <asp:RadioButton runat="server" Style="margin-right:15px;" ID="LumpSumRad" GroupName="Rad" CssClass="LumpSum" Text="Lump Sum" ClientIDMode="Static" Checked /><asp:RadioButton runat="server" GroupName="Rad" ID="InstallmentRad" ClientIDMode="Static" Text="Installment" /></td>
                                    </tr>-->
                                </table>
                                
                                <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top:5px;">
                                    <div class="form-group">
                                        <label class="col-md-5 col-sm-6 col-xs-6 text-right">Upload Document<br /><span class="myred">(Pdf of size upto 1mb only)</span></label>
                                        <div class="col-md-5 col-sm-6 col-xs-6">
                                            <asp:FileUpload ID="fileupload" CssClass="form-control" runat="server" />                                                    
                                        </div>
                                        <div class="col-md-3" style="display:none;">
                                            <span>
                                                <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-primary ey-bg btn-sm" style="margin:0 1px 0 0;width:65px;" Text="Upload" />                                                        
                                            </span>
                                        </div>
                                        <div class="col-md-2 col-sm-12 col-xs-12">
                                            <asp:Button ID="btnsavedues" runat="server" Text="Submit" CssClass="btn-change  pull-right"   Width="" Style="margin:3px 0;" OnClick="btnsavedues_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    
                                </div>

                            </div>
                    
                        </div>
                    </div>
                    <div class="col-md-7 col-sm-12 col-xs-12">
                        <div class="panel-heading">Existing Demand Note</div>
                        <asp:GridView ID="ApplicationGrid" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"  CssClass="table table-striped table-bordered table-hover request-table" OnRowCommand="ApplicationGrid_RowCommand" OnRowDataBound="ApplicationGrid_RowDataBound"  >
                                    <Columns>
                                               <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Style="cursor: pointer" ImageUrl="~/images/plus.png" />
                                
                                        <asp:Panel ID="pnlAllotmentRequest" runat="server" Style="display: none">


                                            <asp:GridView ID="GridViewPayment" runat="server" AutoGenerateColumns="False" CssClass="request-table table table-hover table-bordered cm-table-heading myreq-col">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                  
                                                    <asp:BoundField DataField="PayDesc" HeaderText="Amount Description"  SortExpression="PayDesc" />
                                                    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="GSTFormFees" />
                                                   
                                                

                                                </Columns>
                                            </asp:GridView>

                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:BoundField DataField="DemandNo"      HeaderText ="Demand Ref No"  SortExpression ="DemandNo" />
                                         <asp:BoundField DataField="AllotteeId"      HeaderText ="Allotment Letter No"               SortExpression ="AllotteeId" />
                                         <asp:BoundField DataField="GeneratedDate"               HeaderText ="Demand Date"             SortExpression ="GeneratedDate" />
                                        <asp:BoundField DataField="DueAmount"               HeaderText ="Due Amount"             SortExpression ="DueAmount" />
                                         <asp:BoundField DataField="DueDate"               HeaderText ="Due Date"             SortExpression ="DueDate" />
                                        

                                        	<asp:TemplateField HeaderText="Process" >
										<HeaderStyle HorizontalAlign="Left" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>


                                            <ul class="list-inline ul-boxicon" style="margin-left:0;margin-bottom:0;border: 1px solid #797979; background: #d8d8d8;">

                                                <li title="Assessment">
                                                    <asp:LinkButton runat="server" aria-hidden="true" ID="btnSelectApplicant" CssClass="fa fa-trash" CommandName="DeleteDemand" CommandArgument='<%#Eval("ID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete this demand note?');" ToolTip="Click here to delete demand notice" />
                                                </li>
                                                 <li title="">
                                                    <asp:LinkButton runat="server" aria-hidden="true" ID="LinkButton1" CssClass="fa fa-file-pdf-o" CommandName="ViewDemand" CommandArgument='<%#Eval("ID") %>'  ToolTip="Click here to delete demand notice" />
                                                </li>
                                                </ul>
                                            </ItemTemplate>

                                        	</asp:TemplateField>
                                       
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                    </div>
                    
                    <div class="clearfix"></div>
                    <hr class="separation" />
                   
                    
                    <div class="clearfix"></div>
                    <hr />
            </div>  
        </div>
    </div>
<asp:Label ID="msg" runat="server"></asp:Label>
     </ContentTemplate>

</asp:UpdatePanel>
    <script>

        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "images/plus.png");
            $(this).closest("tr").next().remove();
        });

         
         function isDecimalKey(evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode
        if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57)) {
            return false;
        } else {


        }
        }


        $("[id*=GridView1] input[type=text]").live("blur", function () {
            Calculate1(this);
        });
        $("[id*=GridView1] input[type=text]").live("keyup", function () {
            Calculate(this);
        });
        $("[id*=GridView1] input[type=text]").live("keydown", function () {
            Calculate(this);
        });
       
        function Calculate(t) {
           // if (!jQuery.trim($(t).val()) == '') {
                if (!isNaN(parseFloat($(t).val()))) {
                    var row = $("tr:last-child", $(t).closest("table"));
                    var idx = $(t).closest("td").index();
              }
          // } else {
           //     $(t).val('0');
            //}
            var grandTotal = 0;
            $("[id*=GridView1] tr").each(function () {
                if ($(this).index() != $("[id*=GridView1] tr:first-child").index() && $(this).index() != $("[id*=GridView1] tr:last-child").index()) {
                grandTotal = parseFloat(grandTotal) + (isNaN(parseFloat($("input", $("td", this).eq(idx)).val())) ? 0 : parseFloat($("input", $("td", this).eq(idx)).val()));
                }
            });
            $("td", "[id*=GridView1] tr:last-child").eq(idx).html(grandTotal);
        }
        function Calculate1(t) {
            if (!jQuery.trim($(t).val()) == '') {
                if (!isNaN(parseFloat($(t).val()))) {
                    var row = $("tr:last-child", $(t).closest("table"));
                    var idx = $(t).closest("td").index();
                }
            } else {
                $(t).val('0');
            }
            var grandTotal = 0;
            $("[id*=GridView1] tr").each(function () {
                if ($(this).index() != $("[id*=GridView1] tr:first-child").index() && $(this).index() != $("[id*=GridView1] tr:last-child").index()) {
                    grandTotal = parseFloat(grandTotal) + (isNaN(parseFloat($("input", $("td", this).eq(idx)).val())) ? 0 : parseFloat($("input", $("td", this).eq(idx)).val()));
                }
            });
            $("td", "[id*=GridView1] tr:last-child").eq(idx).html(grandTotal);
        }
       
            
        function ValidateFill(obj, txt) {
            var txtObj = document.getElementById(obj.id);
            if (txtObj.value.length > 0) {
                txtObj.style.borderColor = "";
                hideError();
                return true;
            }


        }

         
                
        $(function () {

            $("#ddlPlotNo").customselect();

        });

        $(function () {
            
            $("#ddlPlotNo").customselect({
                
"csclass":"custom-select",  // Class to match
               
"search": true, // Is searchable?
               
"numitems":     4,    // Number of results per page
               
"searchblank":  false,// Search blank value options?
                
"showblank":    true, // Show blank value options?
               
"searchvalue":  false,// Search option values?
               
"hoveropen":    false,// Open the select on hover?
               
"emptytext":    "",   // Change empty option text to a set value
                
"showdisabled": false,// Show disabled options
               
"mobilecheck":  function() {// Mobile check function / boolean
                    
                    return;
}});
            
        });

</script>


      

</asp:Content>


