<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="DuesClearance.aspx.cs" Inherits="Allotment.DuesClearance" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style>
        .content {
            min-height:600px;
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
         
    </style>
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">


			<ContentTemplate>
				<asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
					<ProgressTemplate>
						<div class="fgh">
							<div class="hgf">
								<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
							</div>
						</div>
					</ProgressTemplate>

                     


				</asp:UpdateProgress>

                 <cc1:MessageBox ID="MessageBox1" runat="server" />
 
    <div class="row">
        <div class="panel panel-default">
            <div class="form-group" style="background: #dadada;padding: 2px 0;margin-bottom: 3px;">
                <div class="">
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        Regional Office :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:DropDownList runat="server" ID="ddloffice" style="background:#fff;" CssClass="input-sm similar-select1" OnSelectedIndexChanged="Regional_Changed" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        Industrial Area :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:DropDownList runat="server" ID="drpdwnIA" style="background:#fff;" CssClass="input-sm similar-select1" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <label class="col-md-1 col-sm-1 col-xs-12">
                        Plot No :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:DropDownList runat="server" ID="ddlPlotNo" style="background:#fff;" CssClass="input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="ddlPlotNo_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-md-1 col-sm-1 col-xs-12">
                        <asp:Button ID="btnfetch" runat="server" Text="Fetch" CssClass="btn-primary ey-bg" Width="100%" />
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
                            Current Allottee Details                        
                        </div>
                        <div class="panel-body" style="padding: 0px !important;">
                            <div class="div-companydetail" style="background: #ececec;">
                                <div class="form-group">
                                    <div class="">
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                           Allotted In Name Of :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                            <span class="text-muted small"><em>
                                                <asp:Label ID="lblAllotteeName" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </span>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                           Date Of Allotment : 
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                            <span class="text-muted small"><em>
                                                <asp:Label ID="lblDateOFAllotment" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </span>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Authorised Signatory :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                            <span class="text-muted small"><em>
                                                <asp:Label ID="lblSignatoryName" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <div class="">                                                                                
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Address :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                            <span class="text-muted small"><em>
                                                <asp:Label ID="lblAddress" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </span>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Phone No :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                            <span class="text-muted small"><em>
                                                <asp:Label ID="lblPhoneNo" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </span>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Email ID :
                                        </label>
                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                            <span class="text-muted small"><em>
                                                <asp:Label ID="lblEmailID" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />

                                <div class="form-group">
                                    <div class="">

                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Firm/Company Constitution :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                            <span class="text-muted small"><em>
                                                <asp:Label ID="lblFirmConstitution" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </span>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Firm/Company Pan No :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                            <span class="text-muted small"><em>
                                                <asp:Label ID="lblPanNo" runat="server" CssClass="font-bold"></asp:Label></>
                                            </span>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Firm/Company Cin No :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                            <span class="text-muted small"><em>
                                                <asp:Label ID="lblCinNo" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />

                                <div class="form-group">
                                    <div class="">                                                                                
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Product Manfactured :
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                            <span class="text-muted small"><em>
                                                <asp:Label ID="lblProduct" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </span>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Date Of Possession :   
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                            <span class="text-muted small"><em>
                                                <asp:Label ID="lblDateOfPossession" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </span>
                                        </div>
                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                            Date Of Lease Deed : 
                                        </label>
                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                            <span class="text-muted small"><em>
                                                <asp:Label ID="lblLeasedeedDate" runat="server" CssClass="font-bold"></asp:Label></em>
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
                <div class="clearfix"></div>
            </div>
            <hr class="separation" />
            <div class="row">
                
                    <div class="col-md-2 col-sm-1 col-xs-12"></div>
                    <div class="col-md-8 col-sm-10 col-xs-12" style="">
                        <div class="row panel panel-default" style="border: 15px solid #ccc;">
                            <div class="col-md-8 col-sm-6 col-xs-12" style="border-right: 4px solid #ccc;padding: 0px !important;">
                                <div class="panel-heading">Dues as of 31/12/2018</div>
                                <table class="table table-striped table-responsive table-bordered table-hover request-table">
                                    <tr>
                                        <asp:Label runat="server" ID="lblAllotteeID" Visible="false"></asp:Label>
                                        <th>Dues</th>
                                        <th>Amount</th>
                                    </tr>
                                    <tr>
                                        <td>Towards Premium</td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesPremium" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Interest On Premium </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesInterestOnPremium" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Maintenance Charge </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesMaintenanceCharge" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Interest On Maintenance Charge</td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesIntOnMaintenanceCharge" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Lease Rent</td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesLeaseRent" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>GST On Lease Rent</td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesGSTOnLeaseRent" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Time Extension Fee</td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesTEF" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Interest On Time Extension</td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesIntOnTEF" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Remaining Lease Period</td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDuesLeasePeriod" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <!--<tr>
                                        <td>Transfer Levy Criteria</td>
                                        <td colspan="3">
                                            <asp:RadioButton runat="server" Style="margin-right:15px;" ID="LumpSumRad" GroupName="Rad" CssClass="LumpSum" Text="Lump Sum" ClientIDMode="Static" Checked /><asp:RadioButton runat="server" GroupName="Rad" ID="InstallmentRad" ClientIDMode="Static" Text="Installment" /></td>
                                    </tr>-->
                                </table>
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <asp:Button ID="btnsavedues" runat="server" Text="Save" CssClass="btn-primary ey-bg pull-right" OnClick="btnsavedues_Click" OnClientClick="return InputValidationDues();" Width="" Style="margin:3px 0;" />
                                </div>

                            </div>
                            <div class="col-md-4 col-sm-6 col-xs-12 pad-rt0 pad-lt0">
                                <div class="panel-heading font-bold">Payment received against dues(If any)</div>
                                <table class="table table-striped table-responsive table-bordered table-hover request-table">
                                    <tr>
                                        <th>Payment</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtPaymentPremium" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtPaymentInterestOnPremium" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtPaymentMaintenanceCharge" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtPaymentIntOnMaintenanceCharge" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtPaymentLeaseRent" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtPaymentGSTOnLeaseRent" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtPaymentTEF" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                             <asp:TextBox runat="server" ID="txtPaymentIntOnTEF" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtPaymentLeasePeriod" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-primary ey-bg pull-right" Width="" Style="margin:3px 0;" OnClientClick="return InputValidationPayment();" OnClick="btnSave_Click" />
                                </div>
                            </div>
                            
                        </div>
                    </div>
                    <div class="col-md-2 col-sm-1 col-xs-12"></div>
                    <div class="clearfix"></div>
                   <div id="divMessageError" class="MessagePennel" runat="server" style="display:none;">
                            <label>
                                <span class="check-cross" runat="server">✖</span>
                                
                                <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
                            </label>
                        </div>
                <br /><br />
                 <div class="col-md-12 col-sm-12 col-sm-12 panel panel-default"><div class="panel-heading">Dues as of 31/12/2018</div></div>
                
                    <div class="col-md-12 col-sm-12 col-sm-12">
                      <div class="table-responsive">
                        <asp:GridView ID="DuesGrid" runat="server" Width="1550px" AutoGenerateColumns="false" DataKeyNames="ID,TowardsPremium,InterestOnPremium,MaintenanceCharge,InterestOnMaintenanceCharge,LeaseRent,GSTOnLeaseRent,TimeExtensionFee,InterestOnTimeExtension,RemainingLeasePeriod" AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" 
                              PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" OnPageIndexChanging="DuesGrid_PageIndexChanging" OnRowCommand="DuesGrid_RowCommand" >
                            <Columns>
                  

                                <asp:TemplateField HeaderText="S.No"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                               </asp:TemplateField>
                                 

                                
                                <asp:BoundField DataField="PlotNo" HeaderText="Plot No"/>
                                <asp:BoundField DataField="TowardsPremium" HeaderText="Towards Premium" />                                
                                <asp:BoundField DataField="InterestOnPremium" HeaderText="Int. On Premium" />                               
                                <asp:BoundField DataField="MaintenanceCharge" HeaderText="Maintenance Charge"  />
                                <asp:BoundField DataField="InterestOnMaintenanceCharge" HeaderText="Int. On Maintenance Charge"/>
                                <asp:BoundField DataField="LeaseRent" HeaderText="Lease Rent" />                                
                                <asp:BoundField DataField="GSTOnLeaseRent" HeaderText="GST On Lease Rent" />                               
                                <asp:BoundField DataField="TimeExtensionFee" HeaderText="Time Extension Fee"  />
                                <asp:BoundField DataField="InterestOnTimeExtension" HeaderText="Int. On Time Extension" />                                
                                <asp:BoundField DataField="RemainingLeasePeriod" HeaderText="Remaining Lease Period" />                               
                                <asp:BoundField DataField="CreatedBy" HeaderText="Created By"  />
                                <asp:BoundField DataField="ModifiedBy" HeaderText="Modified By"  />
                                 
                                  
                                  <asp:TemplateField HeaderText="Update" HeaderStyle-Width="2%">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                   
                                       
                                 <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in"  CommandName="Process"  CommandArgument='<%# (Container.DataItemIndex) %>' ToolTip="Click here For Update Notice " />
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remove" HeaderStyle-Width="2%">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnDelete" class="fa fa-trash" CommandName="DeleteDues" CommandArgument='<%# (Container.DataItemIndex) %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete?');"  ToolTip="Click here to delete Rate" />
                                        </span>  
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>
                        </asp:GridView>
                        </div>
                    </div>
                <div class="clearfix"></div>
                  <div class="col-md-12 col-sm-12 col-sm-12 panel panel-default"><div class="panel-heading">Payment received against dues(If any)</div></div>
                
                    <div class="col-md-12 col-sm-12 col-sm-12">
                        <div class="table-responsive">
                       <asp:GridView ID="PaymentGrid" Width="1550px" runat="server" AutoGenerateColumns="false" DataKeyNames="ID,TowardsPremium,InterestOnPremium,MaintenanceCharge,InterestOnMaintenanceCharge,LeaseRent,GSTOnLeaseRent,TimeExtensionFee,InterestOnTimeExtension,RemainingLeasePeriod" AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" 
                              PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" OnPageIndexChanging="PaymentGrid_PageIndexChanging" OnRowCommand="PaymentGrid_RowCommand" >
                            <Columns>
                  

                                <asp:TemplateField HeaderText="S.No"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                               </asp:TemplateField>
                                 

                                
                                <asp:BoundField DataField="PlotNo" HeaderText="Plot No"/>
                                <asp:BoundField DataField="TowardsPremium" HeaderText="Towards Premium" />                                
                                <asp:BoundField DataField="InterestOnPremium" HeaderText="Int. On Premium" />                               
                                <asp:BoundField DataField="MaintenanceCharge" HeaderText="Maintenance Charge"  />
                                <asp:BoundField DataField="InterestOnMaintenanceCharge" HeaderText="Int. On Maintenance Charge"/>
                                <asp:BoundField DataField="LeaseRent" HeaderText="Lease Rent" />                                
                                <asp:BoundField DataField="GSTOnLeaseRent" HeaderText="GST On Lease Rent" />                               
                                <asp:BoundField DataField="TimeExtensionFee" HeaderText="Time Extension Fee"  />
                                <asp:BoundField DataField="InterestOnTimeExtension" HeaderText="Int. On Time Extension" />                                
                                <asp:BoundField DataField="RemainingLeasePeriod" HeaderText="Remaining Lease Period" />                               
                                <asp:BoundField DataField="CreatedBy" HeaderText="Created By"  />
                                <asp:BoundField DataField="ModifiedBy" HeaderText="Modified By"  />
                                 
                                  
                                  <asp:TemplateField HeaderText="Update" HeaderStyle-Width="2%">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                   
                                       
                                 <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in"  CommandName="Process"  CommandArgument='<%# (Container.DataItemIndex) %>' ToolTip="Click here For Update Notice " />
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remove" HeaderStyle-Width="2%">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnDelete" class="fa fa-trash" CommandName="DeletePayment" CommandArgument='<%# (Container.DataItemIndex) %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete?');"  ToolTip="Click here to delete Rate" />
                                        </span>  
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>
                        </asp:GridView>
                        </div>

                    </div>
            </div>
        </div>
    </div>

     </ContentTemplate>

</asp:UpdatePanel>
    <script>
            function AKS() {
                var g = $("#hidAmt").val();
                $("#btnSleepModal").click();
             //   setTimeout(function () { $(".message").html("Connecting Nivesh Mitra") }, 5000);
                setTimeout(function () { $(".message").html("Registering Consolidated payment To Nivesh Mitra") }, 3000)

                 
              setTimeout(function () { $("#btnCloseModal").click(); $("#hidbtn").click(); }, 5000);
    
            }
            function showError() {
                if (document.getElementById("<%= divMessageError.ClientID %>").style.display == 'none') {
                      document.getElementById("<%= divMessageError.ClientID %>").style.display = 'block';

                }

            }
            function hideError() {
                if (document.getElementById("<%= divMessageError.ClientID %>").style.display == 'block') {
                 document.getElementById("<%= divMessageError.ClientID %>").style.display = 'none';
                  }
                  return false;
              }   
         


            function isDecimalKey(evt) {
                var charCode = (evt.which) ? evt.which : evt.keyCode
                if (charCode != 46 && charCode > 31
                    && (charCode < 48 || charCode > 57)) {
                    return false;
                } else {


                }
            }


            function InputValidationPayment() {
                var remark = true;

                var ddloffice                        = document.getElementById("<%= ddloffice.ClientID %>");
                var drpdwnIA                         = document.getElementById("<%= drpdwnIA.ClientID %>");
                var ddlPlotNo                        = document.getElementById("<%= ddlPlotNo.ClientID %>");
                var txtPaymentPremium                = document.getElementById("<%= txtPaymentPremium.ClientID %>");
                var txtPaymentInterestOnPremium      = document.getElementById("<%= txtPaymentInterestOnPremium.ClientID %>");
                var txtPaymentMaintenanceCharge      = document.getElementById("<%= txtPaymentMaintenanceCharge.ClientID %>");
                var txtPaymentIntOnMaintenanceCharge = document.getElementById("<%= txtPaymentIntOnMaintenanceCharge.ClientID %>");
                var txtPaymentLeaseRent              = document.getElementById("<%= txtPaymentLeaseRent.ClientID %>");
                var txtPaymentGSTOnLeaseRent         = document.getElementById("<%= txtPaymentGSTOnLeaseRent.ClientID %>");
                var txtPaymentTEF                    = document.getElementById("<%= txtPaymentTEF.ClientID %>");
                var txtPaymentIntOnTEF               = document.getElementById("<%= txtPaymentIntOnTEF.ClientID %>");
                var txtPaymentLeasePeriod            = document.getElementById("<%= txtPaymentLeasePeriod.ClientID %>");



                if (ddloffice.selectedIndex == 0) {
                    ddloffice.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    ddloffice.style.borderColor = "";
                }
                if (drpdwnIA.selectedIndex == 0 || drpdwnIA.selectedIndex == -1) {
                    drpdwnIA.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    drpdwnIA.style.borderColor = "";
                }

                if (ddlPlotNo.selectedIndex == 0 || ddlPlotNo.selectedIndex==-1) {
                    ddlPlotNo.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    ddlPlotNo.style.borderColor = "";
                }

                if (txtPaymentPremium.value.length <= 0) {
                    txtPaymentPremium.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentPremium.style.borderColor = "";
                }
                if (txtPaymentInterestOnPremium.value.length <= 0) {
                    txtPaymentInterestOnPremium.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentInterestOnPremium.style.borderColor = "";
                }
                if (txtPaymentMaintenanceCharge.value.length <= 0) {
                    txtPaymentMaintenanceCharge.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentMaintenanceCharge.style.borderColor = "";
                }
                if (txtPaymentIntOnMaintenanceCharge.value.length <= 0) {
                    txtPaymentIntOnMaintenanceCharge.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentIntOnMaintenanceCharge.style.borderColor = "";
                }
                if (txtPaymentLeaseRent.value.length <= 0) {
                    txtPaymentLeaseRent.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentLeaseRent.style.borderColor = "";
                }
                if (txtPaymentGSTOnLeaseRent.value.length <= 0) {
                    txtPaymentGSTOnLeaseRent.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentGSTOnLeaseRent.style.borderColor = "";
                }
                if (txtPaymentTEF.value.length <= 0) {
                    txtPaymentTEF.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentTEF.style.borderColor = "";
                }
                if (txtPaymentIntOnTEF.value.length <= 0) {
                    txtPaymentIntOnTEF.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentIntOnTEF.style.borderColor = "";
                }
                if (txtPaymentLeasePeriod.value.length <= 0) {
                    txtPaymentLeasePeriod.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentLeasePeriod.style.borderColor = "";
                }







                if (remark == false) {


                    ShowMsgBox("Error","Fill All Required Field");
                    //showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

                    return false;
                }
                else {
                   // hideError();
                    return true;
                }


            }
            function InputValidationDues() {
                var remark = true;

                var ddloffice = document.getElementById("<%= ddloffice.ClientID %>");
                var drpdwnIA = document.getElementById("<%= drpdwnIA.ClientID %>");
                var ddlPlotNo = document.getElementById("<%= ddlPlotNo.ClientID %>");
                var txtPaymentPremium = document.getElementById("<%= txtDuesPremium.ClientID %>");
                var txtPaymentInterestOnPremium = document.getElementById("<%= txtDuesInterestOnPremium.ClientID %>");
                var txtPaymentMaintenanceCharge = document.getElementById("<%= txtDuesMaintenanceCharge.ClientID %>");
                var txtPaymentIntOnMaintenanceCharge = document.getElementById("<%= txtDuesIntOnMaintenanceCharge.ClientID %>");
                var txtPaymentLeaseRent = document.getElementById("<%= txtDuesLeaseRent.ClientID %>");
                var txtPaymentGSTOnLeaseRent = document.getElementById("<%= txtDuesGSTOnLeaseRent.ClientID %>");
                var txtPaymentTEF = document.getElementById("<%= txtDuesTEF.ClientID %>");
                var txtPaymentIntOnTEF = document.getElementById("<%= txtDuesIntOnTEF.ClientID %>");
                var txtPaymentLeasePeriod = document.getElementById("<%= txtDuesLeasePeriod.ClientID %>");



                if (ddloffice.selectedIndex == 0) {
                    ddloffice.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    ddloffice.style.borderColor = "";
                }
                if (drpdwnIA.selectedIndex == 0 || drpdwnIA.selectedIndex == -1) {
                    drpdwnIA.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    drpdwnIA.style.borderColor = "";
                }

                if (ddlPlotNo.selectedIndex == 0 || ddlPlotNo.selectedIndex == -1) {
                    ddlPlotNo.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    ddlPlotNo.style.borderColor = "";
                }

                if (txtPaymentPremium.value.length <= 0) {
                    txtPaymentPremium.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentPremium.style.borderColor = "";
                }
                if (txtPaymentInterestOnPremium.value.length <= 0) {
                    txtPaymentInterestOnPremium.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentInterestOnPremium.style.borderColor = "";
                }
                if (txtPaymentMaintenanceCharge.value.length <= 0) {
                    txtPaymentMaintenanceCharge.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentMaintenanceCharge.style.borderColor = "";
                }
                if (txtPaymentIntOnMaintenanceCharge.value.length <= 0) {
                    txtPaymentIntOnMaintenanceCharge.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentIntOnMaintenanceCharge.style.borderColor = "";
                }
                if (txtPaymentLeaseRent.value.length <= 0) {
                    txtPaymentLeaseRent.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentLeaseRent.style.borderColor = "";
                }
                if (txtPaymentGSTOnLeaseRent.value.length <= 0) {
                    txtPaymentGSTOnLeaseRent.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentGSTOnLeaseRent.style.borderColor = "";
                }
                if (txtPaymentTEF.value.length <= 0) {
                    txtPaymentTEF.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentTEF.style.borderColor = "";
                }
                if (txtPaymentIntOnTEF.value.length <= 0) {
                    txtPaymentIntOnTEF.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentIntOnTEF.style.borderColor = "";
                }
                if (txtPaymentLeasePeriod.value.length <= 0) {
                    txtPaymentLeasePeriod.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPaymentLeasePeriod.style.borderColor = "";
                }







                if (remark == false) {


                    ShowMsgBox("Error", "Fill All Required Field");
                    //showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

                    return false;
                }
                else {
                    // hideError();
                    return true;
                }


        }
            function ValidateFill(obj, txt) {
                var txtObj = document.getElementById(obj.id);
                if (txtObj.value.length > 0) {
                    txtObj.style.borderColor = "";
                    hideError();
                    return true;
                }


            }

        </script>


</asp:Content>


