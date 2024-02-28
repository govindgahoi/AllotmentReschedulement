<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_DataFactsEAuction.ascx.cs" Inherits="UpsidaAllottee.RMPanel.UC_DataFactsEAuction" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  

<style>
    body {font-size:14px;}
    .modal-backdrop.fade {
    display:none !important;
    }
    .assess-min-height {
        min-height:628px !important;
    }
    .PreviewClass {
        color: red;
    }

    .input-sm {
        height: 20px !important;
    }

    .request-table tr th[colspan='4'] {
        padding: 0 !important;
    }

    .fade.in {
    opacity: 1 !important;
}

    .modal.fade .modal-dialog {
    transform: translate(0,73px) !important;
}
</style>
 <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();

            $(".MultiSelect").chosen(
               


            );
     }

    
      function openModal() {
               $('#PlotModal').modal('show');
           }

      function MessageAndRedirect() {
          alert("Objection cleared and form re-submitted successfully");
         
      }

    </script>

<div class="row" runat="server" id="TransferDiv" visible="false">


    <div class="col-md-4 col-sm-4 col-xs-6 check-left">
        <div class="div-checklist assess-min-height" style="border: 1px solid #ccc;" >
            <div class="panel-heading font-bold">
                Clause - I
                <asp:Button runat="server" Text="Save" ID="btn_Submit" CssClass="btn btn-sm btn-primary" OnClick="btn_Submit_Click" Style="float: right; padding: 0px 8px !important;" />
            </div>

            <%-- Priyanshu Design And Seeting data  --%>
            <div class="panel panel-default">
                <div class="panel-body gallery">
                    <div class="">
                        <div class="col-md-12" style="padding: 0px !important;">
                            <table class="table table-striped table-responsive table-bordered table-hover request-table">
                                <tr>
                                    <th>Parameters</th>
                                    <th>System Data</th>
                                    <th>Verification</th>
                                    <th>Verified Value</th>
                                </tr>
                                <tr>
                                    <td>Plot No </td>
                                    <td>
                                        <asp:Label ID="lbblPlotNo" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVerifyPlotNo" AutoPostBack="true" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlVerifyPlotNo_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtVerifiedPlot" Enabled="false" CssClass="PlotNo input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtVerifiedPlot_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I1" visible="false"></i><i class="fa fa-check" runat="server" id="I2" visible="false"></i></td>
                                </tr>


                                <tr>
                                    <td>Plot Size (In Sq Mtr)</td>
                                    <td>
                                        <asp:Label ID="lbblPlotSize" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVerifyPlotSize" AutoPostBack="true" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlVerifyPlotSize_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtPlotSizeVerify" Enabled="false" CssClass="PlotSize input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtPlotSizeVerify_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I11" visible="false"></i><i class="fa fa-check" runat="server" id="I21" visible="false"></i></td>
                                </tr>



                                <tr>
                                    <td>Rate of Plot</td>
                                    <td>
                                        <asp:Label ID="lblRateOfPlot" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVerifyRateOfPlot" AutoPostBack="true" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlVerifyRateOfPlot_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtRateOfPlotVerified" CssClass="RateOfPlot input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtRateOfPlotVerified_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I12" visible="false"></i><i class="fa fa-check" runat="server" id="I22" visible="false"></i></td>
                                </tr>

                                <tr>
                                    <td>Transfer Levy (In %)</td>
                                    <td>
                                        <asp:Label ID="lblTransferLevy" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVerifyTransferLevy" Style="padding: 0px 0px !important;" AutoPostBack="true" OnSelectedIndexChanged="ddlVerifyTransferLevy_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtTransferLevyVerified" CssClass="TransferLevyPer input-sm" Enabled="false" AutoPostBack="true" Width="80%" OnTextChanged="txtTransferLevyVerified_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I19" visible="false"></i><i class="fa fa-check" runat="server" id="I29" visible="false"></i></td>
                                </tr>


                                <tr>
                                    <td>Interest Rate (In %) </td>
                                    <td>
                                        <asp:Label ID="lblInterestRate" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVerifyInterestRate" AutoPostBack="true" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlVerifyInterestRate_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtInterestRateVerified" CssClass="IntrestRatePer input-sm" AutoPostBack="true" OnTextChanged="txtInterestRateVerified_TextChanged" Width="80%" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I13" visible="false"></i><i class="fa fa-check" runat="server" id="I23" visible="false"></i></td>
                                </tr>



                                <tr>
                                    <td>EMD Rates (In %) </td>
                                    <td>
                                        <asp:Label ID="lblEMDRates" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVeriFyEmdRates" AutoPostBack="true" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlVeriFyEmdRates_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtEMDRateVerified" CssClass="EmdRatePer input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtEMDRateVerified_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I14" visible="false"></i><i class="fa fa-check" runat="server" id="I24" visible="false"></i></td>
                                </tr>



                                <tr>
                                    <td>Reservation Money (In %)</td>
                                    <td>
                                        <asp:Label ID="lblRegistrationMoneyRate" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVerifyReservationMoney" Style="padding: 0px 0px !important;" AutoPostBack="true" OnSelectedIndexChanged="ddlVerifyReservationMoney_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtRegistrationMoneyRateVerified" CssClass="ReservationMoneyPer input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtRegistrationMoneyRateVerified_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I15" visible="false"></i><i class="fa fa-check" runat="server" id="I25" visible="false"></i></td>
                                </tr>



                                <tr>
                                    <td>Location Charge (In %)</td>
                                    <td>
                                        <asp:Label ID="lblLocationCharge" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVerifyLocationCharge" Style="padding: 0px 0px !important;" AutoPostBack="true" OnSelectedIndexChanged="ddlVerifyLocationCharge_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtLocationChargeVerified" CssClass="LocationChargePer input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtLocationChargeVerified_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I16" visible="false"></i><i class="fa fa-check" runat="server" id="I26" visible="false"></i></td>
                                </tr>


                                <tr>
                                    <td>Rebate (In %)</td>
                                    <td>
                                        <asp:Label ID="lblRebate" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlRebateVerify" Style="padding: 0px 0px !important;" AutoPostBack="true" OnSelectedIndexChanged="ddlRebateVerify_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtRebateVerified" CssClass="RebatePer input-sm" AutoPostBack="true" Width="80%" OnTextChanged="txtRebateVerified_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I17" visible="false"></i><i class="fa fa-check" runat="server" id="I27" visible="false"></i></td>
                                </tr>


                                <tr>
                                    <td>No of Installments</td>
                                    <td>
                                        <asp:Label ID="lblNoOfInstallments" runat="server" onkeypress="return isDecimalKey(event);"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVerifyNoOfInstallment" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlVerifyNoOfInstallment_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtNoOfInstallmentVerified" CssClass="NoOfInsatallment input-sm" Enabled="false" Width="80%" AutoPostBack="true" OnTextChanged="txtNoOfInstallmentVerified_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I18" visible="false"></i><i class="fa fa-check" runat="server" id="I28" visible="false"></i></td>
                                </tr>

                            </table>
                        </div>
                    </div>


                    <div class="">
                        <div class="panel-heading font-bold">Clause - II</div>

                        <div class="col-md-12" style="padding: 0px !important;">
                            <table class="table table-striped table-responsive table-bordered table-hover request-table">
                                <tr>
                                    <th>Parameters</th>
                                    <th>System Data</th>
                                    <th>Verification</th>
                                    <th>Verified Value</th>
                                </tr>


                                <tr>
                                    <td>Towards Premium</td>
                                    <td>
                                        <asp:Label ID="lblPremium" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlPremium" Style="padding: 0px 0px !important;" AutoPostBack="true" OnSelectedIndexChanged="ddlPremium_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtPremiumVerified" CssClass="Premium input-sm" Enabled="false" AutoPostBack="true" Width="80%" OnTextChanged="txtPremiumVerified_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I47" visible="false"></i><i class="fa fa-check" runat="server" id="I48" visible="false"></i></td>
                                </tr>


                                <tr>
                                    <td>Interest On Premium </td>
                                    <td>
                                        <asp:Label ID="lblIntOnPremium" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlIntOnPremium" AutoPostBack="true" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlIntOnPremium_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtIntOnPremiumVerified" CssClass="IntOnPremium input-sm" AutoPostBack="true" OnTextChanged="txtIntOnPremiumVerified_TextChanged" Width="80%" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I49" visible="false"></i><i class="fa fa-check" runat="server" id="I50" visible="false"></i></td>
                                </tr>



                                <tr>
                                    <td>Maintenance Charge </td>
                                    <td>
                                        <asp:Label ID="lblMaintenanceCharge" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlMaintenanceCharge" AutoPostBack="true" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlMaintenanceCharge_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtMaintenanceChargeVerified" CssClass="MaintenanceCharge input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtMaintenanceChargeVerified_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I51" visible="false"></i><i class="fa fa-check" runat="server" id="I52" visible="false"></i></td>
                                </tr>



                                <tr>
                                    <td>Interest On Maintenance Charge</td>
                                    <td>
                                        <asp:Label ID="lblIntOnMaintenanceCharge" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlIntOnMaintenanceCharge" Style="padding: 0px 0px !important;" AutoPostBack="true" OnSelectedIndexChanged="ddlIntOnMaintenanceCharge_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtIntOnMaintenanceCharge" CssClass="IntOnMaintenanceCharge  input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtIntOnMaintenanceCharge_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I53" visible="false"></i><i class="fa fa-check" runat="server" id="I54" visible="false"></i></td>
                                </tr>

                                <tr>
                                    <td>Lease Rent</td>
                                    <td>
                                        <asp:Label ID="lblLeaseRent" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlLeaseRent" Style="padding: 0px 0px !important;" AutoPostBack="true" OnSelectedIndexChanged="ddlLeaseRent_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtLeaseRentVerified" CssClass="LeaseRent input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtLeaseRentVerified_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I41" visible="false"></i><i class="fa fa-check" runat="server" id="I42" visible="false"></i></td>
                                </tr>
                                <tr>
                                    <td>GST On Lease Rent</td>
                                    <td>
                                        <asp:Label ID="lblGSTOnLeaseRent" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlGSTOnLease" Style="padding: 0px 0px !important;" AutoPostBack="true" OnSelectedIndexChanged="ddlGSTOnLease_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtGSTOnLeaseRentVerified" CssClass="GSTOnLeaseRent input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtGSTOnLeaseRentVerified_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I43" visible="false"></i><i class="fa fa-check" runat="server" id="I44" visible="false"></i></td>
                                </tr>

                                <tr>
                                    <td>Time Extension Fee</td>
                                    <td>
                                        <asp:Label ID="lblTEF" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlTEF" Style="padding: 0px 0px !important;" AutoPostBack="true" OnSelectedIndexChanged="ddlTEF_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtTEFVerified" CssClass="TEF input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtTEFVerified_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I45" visible="false"></i><i class="fa fa-check" runat="server" id="I46" visible="false"></i></td>
                                </tr>
                                <tr>
                                    <td>Interest On Time Extension</td>
                                    <td>
                                        <asp:Label ID="lblIntOnTEF" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlIntOnTEF" Style="padding: 0px 0px !important;" AutoPostBack="true" OnSelectedIndexChanged="ddlIntOnTEF_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtIntOnTEFVerified" CssClass="IntOnTEF input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtIntOnTEFVerified_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I55" visible="false"></i><i class="fa fa-check" runat="server" id="I56" visible="false"></i></td>
                                </tr>
                                <tr>
                                    <td>Remaining Lease Period</td>
                                    <td>
                                        <asp:Label ID="lblLeasePeriod" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlLeasePeriod" Style="padding: 0px 0px !important;" AutoPostBack="true" OnSelectedIndexChanged="ddlLeasePeriod_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtLeasePeriodVerified" CssClass="LeasePeriod input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtLeasePeriodVerified_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I57" visible="false"></i><i class="fa fa-check" runat="server" id="I58" visible="false"></i></td>
                                </tr>
                                <tr>
                                    <td>Transfer Levy Criteria</td>
                                    <td colspan="3">
                                        <asp:RadioButton runat="server" ID="LumpSumRad" GroupName="Rad" CssClass="LumpSum" Text="Lump Sum" ClientIDMode="Static" Checked /><asp:RadioButton runat="server" GroupName="Rad" ID="InstallmentRad" ClientIDMode="Static" Text="Installment" /></td>
                                </tr>
                            </table>

                        </div>

                    </div>



                    <div>
                        <div class="row" style="display: none;">
                            <div class="col-md-12" style="padding: 0px !important;">
                                <p class="panel-heading font-bold">Time Extension Fee </p>

                                <asp:GridView ID="gvAll" runat="server" CssClass="table table-striped table-responsive table-bordered table-hover request-table"
                                    AutoGenerateColumns="false" AllowPaging="true"
                                    OnPageIndexChanging="OnPaging" PageSize="10" OnRowDataBound="gvAll_RowDataBound">

                                    <Columns>
                                        <asp:TemplateField>

                                            <HeaderTemplate>

                                                <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);"
                                                    AutoPostBack="true" OnCheckedChanged="CheckBox_CheckChanged" />

                                            </HeaderTemplate>

                                            <ItemTemplate>

                                                <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)"
                                                    AutoPostBack="true" OnCheckedChanged="CheckBox_CheckChanged" />

                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRateId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Rate" HeaderText="Rate" HtmlEncode="false" />
                                        <asp:BoundField DataField="MinPeriod" HeaderText="Min Period"
                                            HtmlEncode="false" />
                                        <asp:BoundField DataField="MaxPeriod" HeaderText="Max Period"
                                            HtmlEncode="false" />
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCheckbox" runat="server" Text='<%#Eval("checkbox") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="col-md-4" style="display: none;">
                                <p class="panel-heading font-bold">Applicable Time Extension Fee </p>
                                <asp:GridView ID="gvSelected" runat="server" CssClass="table table-striped table-responsive table-bordered table-hover request-table"
                                    EmptyDataText="No Records Selected" AutoGenerateColumns="false">

                                    <Columns>

                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Rate" HeaderText="Rate" />

                                        <asp:BoundField DataField="MinPeriod" HeaderText="Min Period" />

                                        <asp:BoundField DataField="MaxPeriod" HeaderText="Max Period" />

                                    </Columns>

                                </asp:GridView>
                                <asp:Label runat="server" ID="lblServiceReqNo" Visible="false"></asp:Label>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12" style="padding: 0px !important;">
                                <p class="panel-heading font-bold">Lease </p>

                                <asp:GridView ID="gvAll1" runat="server" CssClass="table table-striped table-responsive table-bordered table-hover request-table"
                                    AutoGenerateColumns="false" AllowPaging="true"
                                    OnPageIndexChanging="OnPaging1" PageSize="10" OnRowDataBound="gvAll1_RowDataBound">

                                    <Columns>
                                        <asp:TemplateField>

                                            <HeaderTemplate>

                                                <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll1(this);"
                                                    AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckChanged" />

                                            </HeaderTemplate>

                                            <ItemTemplate>

                                                <asp:CheckBox ID="chk" runat="server" onclick="Check1_Click(this)"
                                                    AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckChanged" />

                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRateId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Rate" HeaderText="Rate" HtmlEncode="false" />
                                        <asp:BoundField DataField="MinPeriod" HeaderText="Min Period"
                                            HtmlEncode="false" />
                                        <asp:BoundField DataField="MaxPeriod" HeaderText="Max Period"
                                            HtmlEncode="false" />
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCheckbox" runat="server" Text='<%#Eval("checkbox") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>


                            </div>
                            <div class="col-md-6" style="display: none;">
                                <p class="panel-heading font-bold">Applicable Lease</p>
                                <asp:GridView ID="gvSelected1" runat="server" CssClass="table table-striped table-responsive table-bordered table-hover request-table"
                                    EmptyDataText="No Records Selected" AutoGenerateColumns="false">

                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Rate" HeaderText="Rate" />

                                        <asp:BoundField DataField="MinPeriod" HeaderText="Min Period" />

                                        <asp:BoundField DataField="MaxPeriod" HeaderText="Max Period" />

                                    </Columns>

                                </asp:GridView>

                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </div>


    <div class="col-md-8 col-sm-8 col-xs-6 check-right">
        <div class="div-assesment-applicant assess-min-height" style="">
            <div class="div-view div-scroll" style="max-height: 80vh; overflow-y: auto; border: 1px solid #ccc; background: #fff;">

                <%-- Preview Version  --%>
                <asp:Literal runat="server" ID="Preview_Litral"></asp:Literal>

            </div>
        </div>
    </div>
</div>


<div class="row" runat="server" id="AllotmentDiv" visible="false">

  
    <div class="modal fade" id="PlotModal" role="dialog" style="overflow: hidden;">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-toggle="modal">&times;</button>
                    <h4 class="modal-title">Choose Plot for Allotment</h4>
                </div>
                <div class="modal-body" style="overflow: scroll;">
                    <div class="col-md-12" style="font-size: 12px; padding: 4px 15px; height: 500px;">

                        <asp:GridView ID="GridPlot" runat="server" AutoGenerateColumns="false"
                            CssClass="table table-striped table-bordered table-hover request-table" DataKeyNames="PlotNumber,PlotArea" EmptyDataText="No Plot Available">
                            <Columns>


                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PlotNumber" HeaderText="Plot No" SortExpression="PlotNumber" />
                                <asp:BoundField DataField="PlotArea" HeaderText="Plot Area" SortExpression="PlotArea" />
                                <asp:TemplateField HeaderText="View">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>


                                        <%--<asp:CheckBox runat="server" ID="check" AutoPostBack="true" Class="product-list" OnCheckedChanged="check_CheckedChanged" aria-hidden="true" CommandName="ViewRow" CommandArgument='<%#Eval("PlotNumber") %>' ToolTip="Click here to Choose Plot " />
                                        --%>

                                        <asp:checkbox runat="server" ID="check"  Class="product-list" aria-hidden="true" ToolTip="Click here to Choose Plot " />
                                    </ItemTemplate>

                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>


                        

                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="modal-footer">
                    <div class="pull-right border-buttons">

                       <%-- <asp:Button runat="server" Text="Proceed" data-dismiss="modal" class="btn btn-primary btn-popup" style="margin-right: 0;"  OnClick="btnProceed_Click" ID="btnProceed" /><button type="button" class="btn btn-primary btn-popup" data-dismiss="modal" style="margin-right: 0;">Cancel</button>--%>
                         <asp:Button runat="server" Text="Proceed"  class="btn btn-primary btn-popup" style="margin-right: 0;"  OnClick="btnProceed_Click" ID="btnProceed" /><button type="button" class="btn btn-primary btn-popup" data-dismiss="modal" style="margin-right: 0;">Cancel</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <input type="button" id="btnModalTerms" style="display: none;" data-toggle="modal" data-target="#PlotModal" data-backdrop="static" />

    <div class="col-md-4 col-sm-4 col-xs-6 check-left">
        <div class="div-checklist assess-min-height" style="border: 1px solid #ccc;max-height: 80vh;overflow-y: auto;min-height: 628px;">
            <div class="panel-heading font-bold">
                Facts
                <asp:Button runat="server" Text="Save" ID="LockAllotmentData" CssClass="btn btn-sm btn-primary" OnClick="LockAllotmentData_Click" Style="float: right; padding: 0px 8px !important; background: #ffc511; color: #000;" />
            </div>
            <div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <!--<div class="col-md-6">Choose Plot to Allot</div>-->
                        <div class="col-md-12">

                            <a href="#" class="sdf btn btn-primary ey-bg btn-sm "  style="width: 123px; padding: 0px 8px !important; background: #ffc511; color: #000;" data-toggle="modal" data-target="#PlotModal" data-backdrop="static">Choose Plot to Allot</a>
                        </div>
                        <div class="clearfix"></div>
                    </div>

                </div>
                <div class="form-group">
                    <label class="col-md-3">
                        Plot No
                    </label>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtChooseplot" runat="server" CssClass="PlotNo input-sm similar-select1"  disabled></asp:TextBox>
                    </div>
                    <div class="clearfix"></div>
                    <label class="col-md-3">
                        Plot Area
                    </label>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtChoosePlotArea" runat="server" CssClass="input-sm similar-select1 PlotSize" disabled></asp:TextBox>
                    </div>
                </div>


                <div class="panel-heading font-bold col-md-12">Preferences Opted by applicant</div>


                <div class="form-group">
                   
                    <div class="col-md-3">
                        <asp:TextBox ID="txtpref1" runat="server" CssClass="PlotNo input-sm similar-select1"  disabled></asp:TextBox>
                    </div>
                   
                    <div class="col-md-3">
                        <asp:TextBox ID="txtpref2" runat="server" CssClass="PlotSize input-sm similar-select1" disabled></asp:TextBox>
                    </div>
                   
                    <div class="col-md-3">
                        <asp:TextBox ID="txtpref3"
                            runat="server" CssClass="input-sm similar-select1 " disabled></asp:TextBox>
                    </div>
                    <label class="col-md-3" style="display:none;">
                        Pref Area
                    </label>
                    <div class="col-md-3" style="display:none;">
                        <asp:TextBox ID="txtprefarea" runat="server" CssClass="input-sm similar-select1 SystemPlotSize" disabled></asp:TextBox>
                    </div>
                </div>
            </div><br />
            <%-- Priyanshu Design And Seeting data  --%>
            <div class="panel panel-default">
                <div class="panel-body gallery">
                    <div class="">
                        <div class="col-md-12" style="padding: 0px !important;">
                            <table class="table table-striped table-responsive table-bordered table-hover request-table">
                                <tr>
                                    <th>Parameters</th>
                                    <th>System Data</th>
                                    <th style="display:none;">Verification</th>
                                    <th>Verified Value <span><asp:Button runat="server" Text="Edit" OnClick="Button1_Click" ID="Button1" CssClass="btn btn-sm btn-primary" Style="float: right; padding: 0px 8px !important; background: #ffc511; color: #000;" /></span></th>
                                </tr>
                                <tr style="display: none;">
                                    <td>Plot No </td>
                                    <td>
                                        <asp:Label ID="lblPlotNo" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlPlotNo" Width="100%" AutoPostBack="true" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlPlotNo_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtPlotNoVerified" Enabled="false" CssClass="PlotNo input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtPlotNoVerified_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis11" visible="false"></i><i class="fa fa-check" runat="server" id="IApp11" visible="false"></i></td>
                                </tr>

                                <tr style="display: none;">
                                    <td>Plot Size (In Sq Mtr)</td>
                                    <td>
                                        <asp:Label ID="lblPlotArea" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlPlotArea" AutoPostBack="true" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlPlotArea_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtPlotAreaVerified" Enabled="false" CssClass="input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtPlotAreaVerified_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis12" visible="false"></i><i class="fa fa-check" runat="server" id="IApp12" visible="false"></i></td>
                                </tr>

                                <tr>
                                    <th colspan="4">
                                        <div class="panel-heading font-bold">Clause-3</div>
                                    </th>
                                </tr>

                                <tr>
                                    <td>First Installment Due Date</td>
                                    <td>
                                        <asp:Label ID="lblFirstInstallmentDate" runat="server"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlInstallmentDate" Width="100%" AutoPostBack="true" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlInstallmentDate_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                         <cc1:CalendarExtender ID="cal1" PopupButtonID="Imbtn1" runat="server" TargetControlID="txtFirstInstallmentDate"  
                        Format="dd/MM/yyyy">  
                    </cc1:CalendarExtender>  
                                        <asp:TextBox runat="server" ID="txtFirstInstallmentDate" Enabled="false" CssClass="FirstInstallment input-sm" Width="80%" AutoPostBack="true"  OnTextChanged="txtFirstInstallmentDate_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis13" visible="false"></i><i class="fa fa-check" runat="server" id="IApp13" visible="false"></i></td>
                                </tr>
                                <tr>
                                    <th colspan="4">
                                        <div class="panel-heading font-bold">Clause-3(a)</div>
                                    </th>
                                </tr>

                                <tr>
                                    <td>Existing Construction Value</td>
                                    <td>
                                        <asp:Label ID="lblExistingConstructionValue" runat="server"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlConstructionValue" Width="100%" AutoPostBack="true" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlConstructionValue_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtConstructionValueVerified" Enabled="false" CssClass="ExistingConstructionValue input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtConstructionValueVerified_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis14" visible="false"></i><i class="fa fa-check" runat="server" id="IApp14" visible="false"></i></td>
                                </tr>
                                <tr>
                                    <th colspan="4">
                                        <div class="panel-heading font-bold">Clause-4</div>
                                    </th>
                                </tr>

                                <tr>
                                    <td>Rate Of Plot</td>
                                    <td>
                                        <asp:Label ID="lblPlotRate" runat="server"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlRateOfPlot" AutoPostBack="true" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlRateOfPlot_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtPlotRateVerified" Enabled="false" CssClass="RateOfPlot input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtPlotRateVerified_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis15" visible="false"></i><i class="fa fa-check" runat="server" id="IApp15" visible="false"></i></td>
                                </tr>
                                <tr>
                                    <td>Reservation Money (In %)</td>
                                    <td>
                                        <asp:Label ID="lblReservationMoney" runat="server"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlReservationMoney" AutoPostBack="true" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlReservationMoney_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtReservationMoneyVerified" Enabled="false" CssClass="ReservationMoneyPer input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtReservationMoneyVerified_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis16" visible="false"></i><i class="fa fa-check" runat="server" id="IApp16" visible="false"></i></td>
                                </tr>

                                <tr>
                                    <td>EMD Rate (In %)</td>
                                    <td>
                                        <asp:Label ID="lblEmdRate" runat="server"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlEmdRate" AutoPostBack="true" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlEmdRate_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtEmdRatePerVerified" Enabled="false" CssClass="EmdRatePer input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtEmdRatePerVerified_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis17" visible="false"></i><i class="fa fa-check" runat="server" id="IApp17" visible="false"></i></td>
                                </tr>

                                <tr>
                                    <td> No.of days to deposit Reservation Money</td>
                                    <td>
                                        <asp:Label ID="lblEMDDepositDays" runat="server"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlEmdDepositDays" AutoPostBack="true" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlEmdDepositDays_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtEmdDepositDaysVerified" Enabled="false" CssClass="EmdDepositDays input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtEmdDepositDaysVerified_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis18" visible="false"></i><i class="fa fa-check" runat="server" id="IApp18" visible="false"></i></td>
                                </tr>

                                <tr>
                                    <td>Location Charge (In Rs)</td>
                                    <td>
                                        <asp:Label ID="lblLocationChargeRate" runat="server"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlLocationChargeRate" AutoPostBack="true" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlLocationChargeRate_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtLocationChargeRateVerified" Enabled="false" CssClass="LocationChargeRate input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtLocationChargeRateVerified_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis19" visible="false"></i><i class="fa fa-check" runat="server" id="IApp19" visible="false"></i>
                                    </td>
                                </tr>
                                <tr style="display:none;">
                                    <td>Location Charge (In %)</td>
                                    <td>
                                        <asp:Label ID="lblChargePer" runat="server"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlChargePer" AutoPostBack="true" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlChargePer_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtChargePerVerified" Enabled="false" CssClass="ChargePer input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtChargePerVerified_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis20" visible="false"></i><i class="fa fa-check" runat="server" id="IApp20" visible="false"></i>
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="4">
                                        <div class="panel-heading font-bold">Clause-5</div>
                                    </th>
                                </tr>
                                <tr>
                                    <td>Remaining Premium (In %)</td>
                                    <td>
                                        <asp:Label ID="lblRemPremiumPer" runat="server"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlRemPremiumPer" AutoPostBack="true" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlRemPremiumPer_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtRemPremiumPerVerified" Enabled="false" CssClass="RemPremiumPer input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtRemPremiumPerVerified_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis21" visible="false"></i><i class="fa fa-check" runat="server" id="IApp21" visible="false"></i>
                                    </td>
                                </tr>
                                <tr>
                                    <td>No of Installments</td>
                                    <td>
                                        <asp:Label ID="lblNoOfInstallment" runat="server" onkeypress="return isDecimalKey(event);"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlInstallment" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlInstallment_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtInstallment"  CssClass="NoOfInsatallment input-sm" Enabled="false" Width="80%" AutoPostBack="true" OnTextChanged="txtInstallment_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis22" visible="false"></i><i class="fa fa-check" runat="server" id="IApp22" visible="false"></i></td>
                                </tr>
                                <tr>
                                    <td>Rebate (In %)</td>
                                    <td>
                                        <asp:Label ID="lblRebatePer" runat="server" onkeypress="return isDecimalKey(event);"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlRebate" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlRebate_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtRebate" CssClass="RebatePer input-sm" Enabled="false" Width="80%" AutoPostBack="true" OnTextChanged="txtRebate_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis221" visible="false"></i><i class="fa fa-check" runat="server" id="IApp221" visible="false"></i></td>
                                </tr>
                                <tr>
                                    <th colspan="4">
                                        <div class="panel-heading font-bold">Clause-7(a)</div>
                                    </th>
                                </tr>
                                <tr>
                                    <td>Interest (In %)</td>
                                    <td>
                                        <asp:Label ID="lblInterest" runat="server" onkeypress="return isDecimalKey(event);"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlInterest" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlInterest_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtInterestRate" CssClass="IntrestRatePer input-sm" Enabled="false" Width="80%" AutoPostBack="true" OnTextChanged="txtInterestRate_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis23" visible="false"></i><i class="fa fa-check" runat="server" id="IApp23" visible="false"></i></td>
                                </tr>

                                <tr>
                                    <th colspan="4">
                                        <div class="panel-heading font-bold">Clause-7(c) & 8(c)</div>
                                    </th>
                                </tr>
                                <tr>
                                    <td>Depreciation on Shed (In %)</td>
                                    <td>
                                        <asp:Label ID="lblDepreciation" runat="server" onkeypress="return isDecimalKey(event);"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlDepreciation" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlDepreciation_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDepreciation" CssClass="Depreciation input-sm" Enabled="false" Width="80%" AutoPostBack="true" OnTextChanged="txtDepreciation_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis24" visible="false"></i><i class="fa fa-check" runat="server" id="IApp24" visible="false"></i></td>
                                </tr>

                                <tr>
                                    <th colspan="4">
                                        <div class="panel-heading font-bold">Clause-11</div>
                                    </th>
                                </tr>
                                 <tr >
                                    <td>Production Start Period</td>
                                    <td> <asp:Label ID="lblPoductionStartPeriod" runat="server" onkeypress="return isDecimalKey(event);"></asp:Label></td>
                                    <td> <asp:TextBox runat="server" ID="txtPoductionStartPeriod" onkeypress="return isDecimalKey(event);" CssClass="ProductionStart input-sm" Enabled="false" Width="80%" AutoPostBack="true" OnTextChanged="txtPoductionStartPeriod_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I3" visible="false"></i><i class="fa fa-check" runat="server" id="I4" visible="false"></i></td>
                                        </tr>

                                <tr>
                                    <th colspan="4">
                                        <div class="panel-heading font-bold">Clause-20 (Lease Rent)</div>
                                    </th>
                                </tr>
                                <tr >
                                    <td>Lease Rent (0-30 years)</td>
                                    <td>
                                        <asp:Label ID="lblLeaseRent1" runat="server" onkeypress="return isDecimalKey(event);"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlLeaseRent1" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlLeaseRent1_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtLeaseRent1" CssClass="LeaseRent1 input-sm" Enabled="false" Width="80%" AutoPostBack="true" OnTextChanged="txtLeaseRent1_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis25" visible="false"></i><i class="fa fa-check" runat="server" id="IApp25" visible="false"></i></td>
                                </tr>
                                <tr >
                                    <td>Lease Rent (31-60 years)</td>
                                    <td>
                                        <asp:Label ID="lblLeaseRent2" runat="server" onkeypress="return isDecimalKey(event);"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlLeaseRent2" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlLeaseRent2_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtLeaseRent2" CssClass="LeaseRent2 input-sm" Enabled="false" Width="80%" AutoPostBack="true" OnTextChanged="txtLeaseRent2_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis26" visible="false"></i><i class="fa fa-check" runat="server" id="IApp26" visible="false"></i></td>
                                </tr>
                                <tr >
                                    <td>Lease Rent (61-90 years)</td>
                                    <td>
                                        <asp:Label ID="lblLeaseRent3" runat="server" onkeypress="return isDecimalKey(event);"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlLeaseRent3" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlLeaseRent3_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtLeaseRent3" CssClass="LeaseRent3 input-sm" Enabled="false" Width="80%" AutoPostBack="true" OnTextChanged="txtLeaseRent3_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis27" visible="false"></i><i class="fa fa-check" runat="server" id="IApp27" visible="false"></i></td>
                                </tr>

                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="LeaseRentGrid" runat="server" Visible="false" CssClass="table table-striped table-responsive table-bordered table-hover request-table"
                                            AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="Rate"
                                            PageSize="10" OnPageIndexChanging="OnPaging2" OnRowDataBound="LeaseRentGrid_RowDataBound">

                                            <Columns>
                                                <asp:TemplateField>

                                                    <ItemTemplate>

                                                        <asp:CheckBox ID="chk1" runat="server"
                                                            AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckChanged" />

                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRateId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Rate" HeaderText="Rate" />
                                                <asp:BoundField DataField="MinPeriod" HeaderText="Min Period"
                                                    HtmlEncode="false" />
                                                <asp:BoundField DataField="MaxPeriod" HeaderText="Max Period"
                                                    HtmlEncode="false" />
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCheckbox" runat="server" Text='<%#Eval("checkbox") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:GridView ID="gvSelectedLeaseAllotment" Visible="false" runat="server" CssClass="table table-striped table-responsive table-bordered table-hover request-table"
                                            EmptyDataText="No Records Selected" AutoGenerateColumns="false">

                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Rate" HeaderText="Rate" />

                                                <asp:BoundField DataField="MinPeriod" HeaderText="Min Period" />

                                                <asp:BoundField DataField="MaxPeriod" HeaderText="Max Period" />

                                            </Columns>

                                        </asp:GridView>

                                    </td>
                                </tr>

                                <tr>
                                    <th colspan="4">
                                        <div class="panel-heading font-bold">Clause-23</div>
                                    </th>
                                </tr>
                                <tr>
                                    <td>Covered Area (In %)</td>
                                    <td>
                                        <asp:Label ID="lblCoveredArea" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:Label></td>
                                    <td style="display:none;">
                                        <asp:DropDownList runat="server" ID="ddlCoveredArea" Width="100%" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlCoveredArea_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtCoveredArea" CssClass="CoveredArea input-sm" Enabled="false" Width="80%" AutoPostBack="true" OnTextChanged="txtCoveredArea_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis28" visible="false"></i><i class="fa fa-check" runat="server" id="IApp28" visible="false"></i></td>


                                </tr>

                                       <tr>
                                    <td>Address</td>
                                           <td><label></label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtAddress" CssClass="CoveredArea input-sm" Enabled="false" Width="80%" AutoPostBack="true" OnTextChanged="txtAddress_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis29" visible="false"></i><i class="fa fa-check" runat="server" id="IApp29" visible="false"></i></td>
                                </tr>
                                         <tr>
                                    <td>Product</td>
                                          <td><label></label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtProduct" CssClass="CoveredArea input-sm" Enabled="false" Width="80%" AutoPostBack="true" OnTextChanged="txtProduct_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis30" visible="false"></i><i class="fa fa-check" runat="server" id="IApp30" visible="false"></i></td>
                                </tr>
                            </table>
                            <div class="Annexre_Table">
                             <asp:GridView ID="AnnexreGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="AnnexreDelete_Click">
																	                            <Columns>


																		                            <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			                            </ItemTemplate>
																		                            </asp:TemplateField>


																		                            <asp:TemplateField HeaderText="List Of Additional Clauses" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblClause" runat="server" Text='<%#Eval("Annexures") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtReasonRej" TextMode="MultiLine" Style="min-height:80px;"  CssClass="input-sm similar-select1 margin-left-z" runat="server"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																		                            

																		                            <asp:TemplateField FooterStyle-CssClass="hide_me" ItemStyle-CssClass="hide_me" HeaderStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />

																			                            </ItemTemplate>
																			                            <FooterStyle HorizontalAlign="Right" />
																			                            <FooterTemplate>
																				                               <asp:Button runat="server" ID="BtnSave" OnClick="insert_annexre_details" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />

																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView></div>




                            <div style="width: 100%; min-height: 300px; background: #efefef;">
                                <div class="panel-heading text-center font-bold">EMD Difference</div>
                                <span>Calculation According To Requested Plot Size : <span class="SpanArea1"></span>Sqr.Mtr</span><br />
                                <p>EMD = [<span class="SpanArea1"></span>x<span class="SpanRate"></span>x<span class="SpanEmdPer"></span>]/100</p>
                                <p>Result = <i class="fa fa-rupee"></i><span class="Result1" runat="server" id="Result1"></span></p>
                                <br />
                                <span>Calculation According To Allotted Plot Size : <span class="SpanArea11"></span>Sqr.Mtr</span><br />
                                <p>EMD = [<span class="SpanArea11"></span>x<span class="SpanRate"></span>x<span class="SpanEmdPer"></span>]/100</p>
                                <p>Result = <i class="fa fa-rupee"></i><span class="Result2" runat="server" id="Result2"></span></p>

                                <br />
                                <span class="Message"></span>= <i class="fa fa-rupee"></i>(<span class="Difference" runat="server" id="Difference"></span>)
                            </div>




                            <asp:HiddenField runat="server" ID="lblResultSet1" />
                            <asp:HiddenField runat="server" ID="lblResultSet2" />
                            <asp:HiddenField runat="server" ID="lblResultSet3" />

                        </div>
                    </div>





                </div>
            </div>
        </div>
    </div>


    <div class="col-md-8 col-sm-8 col-xs-6 check-right">
        <div class="div-assesment-applicant assess-min-height" style="">
            <div class="div-view div-scroll" style="max-height:80vh; overflow-y: auto; border: 1px solid #ccc; background: #fff;">

                <%-- Preview Version  --%>
                <asp:Literal runat="server" ID="Literal1"></asp:Literal>

            </div>
        </div>
    </div>
</div>


<div runat="server" id="BuildingDiv" visible="false">


    
    <div class="col-md-4 col-sm-4 col-xs-6 check-left">
        <div class="div-checklist assess-min-height" style="border: 1px solid #ccc;max-height: 80vh;overflow-y: auto;min-height: 628px;">
 
            <div class="panel-heading font-bold">Facts
                <asp:Button runat="server" Text="Lock Data" ID="LockBPData" CssClass="btn btn-sm btn-primary" OnClick="LockBPData_Click"  Style="float: right;padding: 0px 8px !important;background: #ffc511;color: #000;" /></div>
            <div class="panel panel-default">
                <div class="panel-body gallery">
                   
                           
                                   <div class="panel-heading">List Of Additional Clauses</div>
                               <div class="Annexure">
                                  
                                       <asp:GridView ID="BPClauseGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="BPClauseGrid_RowDeleting">
																	                            <Columns>


																		                            <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			                            </ItemTemplate>
																		                            </asp:TemplateField>


																		                            <asp:TemplateField HeaderText="List of Additional Clauses" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblClause" runat="server" Text='<%#Eval("Annexures") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtReasonRej" TextMode="MultiLine" Style="min-height:80px;"  CssClass="input-sm similar-select1 margin-left-z" runat="server"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																		                            

																		                            <asp:TemplateField FooterStyle-CssClass="hide_me" ItemStyle-CssClass="hide_me" HeaderStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />

																			                            </ItemTemplate>
																			                            <FooterStyle HorizontalAlign="Right" />
																			                            <FooterTemplate>
																				                               <asp:Button runat="server" ID="btnSaveBpClause" OnClick="btnSaveBpClause_Click" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />

																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>
                                    

                                </div>
                       
                    

                     <asp:HiddenField runat="server" ID="HiddenField1" />
                            <asp:HiddenField runat="server" ID="HiddenField2" />
                            <asp:HiddenField runat="server" ID="HiddenField3" />
            

                </div>
            </div>
        </div>
    </div>


    <div class="col-md-8 col-sm-8 col-xs-6 check-right">
        <div class="div-assesment-applicant assess-min-height" style="">
            <div class="div-view div-scroll" style="max-height: 628px; overflow-y: auto; border: 1px solid #ccc; background: #fff;">

                <%-- Preview Version  --%>
                <asp:Literal runat="server" ID="Literal2"></asp:Literal>

            </div>
        </div>
    </div>

</div>


<div class="row" runat="server" id="CancelDiv" visible="false">


      


    <div class="col-md-4 col-sm-4 col-xs-6 check-left">
        <div class="div-checklist assess-min-height" style="border: 1px solid #ccc;">
            <div class="panel-heading font-bold">Facts
                <asp:Button runat="server" Text="Lock Data" ID="btnLockPlotCancel" CssClass="btn btn-sm btn-primary" OnClick="btnLockPlotCancel_Click" Style="float: right;padding: 0px 8px !important;background: #ffc511;color: #000;" /></div>

            <%-- Priyanshu Design And Seeting data  --%>
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12" style="padding:0px !important;">
                        
                            <div class="panel-heading">List of Notices</div>
                            <div class="Notices_table">
                                
                                    <div class="table-responsive">
                                         <asp:GridView ID="gridNotices" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table"  ShowHeaderWhenEmpty="true" runat="server" AutoGenerateColumns="false">
																	                            <Columns>



																		                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			                            </ItemTemplate>
																		                            </asp:TemplateField>


																		                            <asp:TemplateField HeaderText="Notice Ref No" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblNoticeRefNo" runat="server" Text='<%#Eval("NoticeRefNo") %>'></asp:Label>
																			                            </ItemTemplate>
																			                           
																		                            </asp:TemplateField>


																		                            <asp:TemplateField  HeaderText="Notice Date" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblNoticeDate" runat="server" Text='<%#Eval("IssueDate") %>'></asp:Label>
																			                            </ItemTemplate>
																			                          
																		                            </asp:TemplateField>
																		                            

																		                           

																	                            </Columns>
																                            </asp:GridView>
                                    </div>
                                </div>
                                   <div class="panel-heading">List of Clauses</div>

                               <div class="Clause_table">
                                   <div class="table-responsive">
                                       <asp:GridView ID="ClauseGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="ClauseDelete_Click">
																	                            <Columns>


																		                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			                            </ItemTemplate>
																		                            </asp:TemplateField>


																		                            <asp:TemplateField HeaderText="Clause" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblClause" runat="server" Text='<%#Eval("Clause") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtClause_insert1" TextMode="MultiLine" Style="min-height:60px;"  CssClass="input-sm similar-select1 margin-left-z" runat="server"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																		                            

																		                            <asp:TemplateField FooterStyle-CssClass="hide_me" ItemStyle-CssClass="hide_me" HeaderStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />

																			                            </ItemTemplate>
																			                            <FooterStyle HorizontalAlign="Right" />
																			                            <FooterTemplate>
																				                               <asp:Button runat="server" ID="BtnSave" OnClick="insert_clause_details" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />

																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>
                                    </div>

                                </div>
                           
                             
                        </div>
                    </div>

                
            

                </div>
            </div>
        </div>
    </div>


    <div class="col-md-8 col-sm-8 col-xs-6 check-right">
        <div class="div-assesment-applicant assess-min-height" style="">
            <div class="div-view div-scroll" style="max-height:628px;overflow-y:auto;border: 1px solid #ccc; background: #fff;">

                <%-- Preview Version  --%>
                <asp:Literal runat="server" ID="Literal3"></asp:Literal>

            </div>
        </div>
    </div>
</div>


<script>

  
    function AnyChangeCallMe() {

        console.log();
            $(".lblPlotNo").html($(".PlotNo").val());
            $(".ListofClause").html($(".Clause_table").html());
            $(".ListofNotices").html($(".Notices_table").html());
            $(".ListofAnnexres").html($(".Annexre_Table").html());
            $(".BP").html($(".Annexure").html());
            




            var PlotNo = $(".PlotNo").val();
            var firstInstallmentDate = $(".FirstInstallment").val();
            var ConstructionValue = (isNaN(parseInt($(".ExistingConstructionValue").val()))) ? 0 : parseInt($(".ExistingConstructionValue").val());
            var SystemPlotSize = (isNaN(parseFloat($(".SystemPlotSize").val()))) ? 0 : parseFloat($(".SystemPlotSize").val());
            var ChoosenSize = (isNaN(parseFloat($(".PlotSize").val()))) ? 0 : parseFloat($(".PlotSize").val());

            var ProductionStart = (isNaN(parseFloat($(".ProductionStart").val()))) ? 0 : parseFloat($(".ProductionStart").val());
            var LeaseRent1 = (isNaN(parseFloat($(".LeaseRent1").val()))) ? 0 : parseFloat($(".LeaseRent1").val());
            var LeaseRent2 = (isNaN(parseFloat($(".LeaseRent2").val()))) ? 0 : parseFloat($(".LeaseRent2").val());
            var LeaseRent3 = (isNaN(parseFloat($(".LeaseRent3").val()))) ? 0 : parseFloat($(".LeaseRent3").val());
            var CoveredArea = (isNaN(parseInt($(".CoveredArea").val()))) ? 0 : parseInt($(".CoveredArea").val());
            var Depreciation = (isNaN(parseInt($(".Depreciation").val()))) ? 0 : parseInt($(".Depreciation").val());
            var EmdDepositDays = (isNaN(parseInt($(".EmdDepositDays").val()))) ? 0 : parseInt($(".EmdDepositDays").val());
            var LocationChargeRate = (isNaN(parseFloat($(".LocationChargeRate").val()))) ? 0 : parseFloat($(".LocationChargeRate").val());
            var ChargePer = (isNaN(parseFloat($(".ChargePer").val()))) ? 0 : parseFloat($(".ChargePer").val());
            var RemPremiumPer = (isNaN(parseFloat($(".RemPremiumPer").val()))) ? 0 : parseFloat($(".RemPremiumPer").val());

            var NoOfInsatallment = (isNaN(parseInt($(".NoOfInsatallment").val()))) ? 0 : parseInt($(".NoOfInsatallment").val());

            var LocationChage = (isNaN(parseFloat($(".LocationChargePer").val()))) ? 0 : parseFloat($(".LocationChargePer").val());
            var RateofPlot = (isNaN(parseFloat($(".RateOfPlot").val()))) ? 0 : parseFloat($(".RateOfPlot").val());
            var PlotSize = (isNaN(parseFloat($(".PlotSize").val()))) ? 0 : parseFloat($(".PlotSize").val());
            var EmdRatePer = (isNaN(parseFloat($(".EmdRatePer").val()))) ? 0 : parseFloat($(".EmdRatePer").val());
            var ReservationMoneyPer = (isNaN(parseFloat($(".ReservationMoneyPer").val()))) ? 0 : parseFloat($(".ReservationMoneyPer").val());
            var TransferLevyPer = (isNaN(parseFloat($(".TransferLevyPer").val()))) ? 0 : parseFloat($(".TransferLevyPer").val());
            var IntrestRatePer = (isNaN(parseFloat($(".IntrestRatePer").val()))) ? 0 : parseFloat($(".IntrestRatePer").val());
            var RebatePer = (isNaN(parseFloat($(".RebatePer").val()))) ? 0 : parseFloat($(".RebatePer").val());
            //var lblTotalLevyamount = ((((RateofPlot + ((LocationChage / 100) * RateofPlot)) * PlotSize) * (TransferLevyPer / 100))).toFixed(2);
            var lblLevyAmount = ((RateofPlot) * (TransferLevyPer / 100)).toFixed(2);
            var lblTotalLevyamount = (lblLevyAmount * PlotSize).toFixed(2);
            // var PrePercentage = (parseFloat(EmdRatePer) + parseFloat(ReservationMoneyPer)).toFixed(2);

            var PrePercentage = (parseFloat(ReservationMoneyPer)).toFixed(2);

            //var lblPreLevyAmt = (((((RateofPlot + ((LocationChage / 100) * RateofPlot)) * PlotSize) * (TransferLevyPer / 100))) * (PrePercentage / 100)).toFixed(2);
            var lblPreLevyAmt = (lblTotalLevyamount * (ReservationMoneyPer / 100)).toFixed(2);

            var lblBallevyAmt = (lblTotalLevyamount - lblPreLevyAmt).toFixed(2);

            var lblDue_Premium = (isNaN(parseInt($(".Premium").val()))) ? 0 : parseInt($(".Premium").val());
            var lblDue_Intt_Premium = (isNaN(parseInt($(".IntOnPremium").val()))) ? 0 : parseInt($(".IntOnPremium").val());
            var lblDue_Maint = (isNaN(parseInt($(".MaintenanceCharge").val()))) ? 0 : parseInt($(".MaintenanceCharge").val());
            var lblDue_Intt_Maint = (isNaN(parseInt($(".IntOnMaintenanceCharge").val()))) ? 0 : parseInt($(".IntOnMaintenanceCharge").val());
            var lblDue_Lease = (isNaN(parseInt($(".LeaseRent").val()))) ? 0 : parseInt($(".LeaseRent").val());
            var lblDue_GST_Lease = (isNaN(parseInt($(".GSTOnLeaseRent").val()))) ? 0 : parseInt($(".GSTOnLeaseRent").val());
            var lblDue_TEF = (isNaN(parseInt($(".TEF").val()))) ? 0 : parseInt($(".TEF").val());
            var lblDue_Intt_TEF = (isNaN(parseInt($(".IntOnTEF").val()))) ? 0 : parseInt($(".IntOnTEF").val());
            var lbl_LeasePeriod = (isNaN(parseInt($(".LeasePeriod").val()))) ? 0 : parseInt($(".LeasePeriod").val());
            var lblTotalBalanceDues = ((lblDue_Premium) + (lblDue_Intt_Premium) + (lblDue_Maint) + (lblDue_Intt_Maint) + (lblDue_Lease) + (lblDue_GST_Lease) + (lblDue_TEF) + (lblDue_Intt_TEF)).toFixed(2);

           var totalPremium1 = (RateofPlot + LocationChargeRate) * PlotSize;
           var totalPremium = (RateofPlot) * SystemPlotSize;

           var Reservationamount1 = (totalPremium1) * ((ReservationMoneyPer+EmdRatePer) / 100);
          // var Reservationamount = (totalPremium) * ((ReservationMoneyPer) / 100);
          var EMDAmount = (totalPremium * (EmdRatePer / 100));
          var Reservationamount = (Reservationamount1) - (EMDAmount);
          




            $(".ExistingConstructionValue").html(ConstructionValue.toString());
            $(".ProductionStart").html(ProductionStart.toString());

            $(".lblPlotNo").html(PlotNo);
            $(".lblPlotSize").html(PlotSize.toString());
            $(".lblPlotRate").html(RateofPlot.toString());
            $(".lblInterestPerAnnum").html(IntrestRatePer.toString());
            $(".lblRebatePer").html(RebatePer.toString());
            $(".lblPrePercent").html((PrePercentage).toString());
            $(".lblbalPercent").html((100 - PrePercentage).toString());
            $(".lblTotalLevyamount").html(lblTotalLevyamount.toString());
            $(".lblLevyAmount").html(lblLevyAmount.toString());
            $(".lblPreLevyAmt").html(lblPreLevyAmt.toString());
            $(".lblbalAmount").html(lblBallevyAmt.toString());
            $(".lblTransferLevyPer").html(TransferLevyPer.toString());

            $(".lblNoInstallment").html(NoOfInsatallment.toString());
            $(".lblDue_Premium").html(lblDue_Premium.toString());
            $(".lblDue_Intt_Premium").html(lblDue_Intt_Premium.toString());
            $(".lblDue_Maint").html(lblDue_Maint.toString());
            $(".lblDue_Intt_Maint").html(lblDue_Intt_Maint.toString());
            $(".lblDue_Lease").html(lblDue_Lease.toString());
            $(".lblDue_GST_Lease").html(lblDue_GST_Lease.toString());
            $(".lblDue_TEF").html(lblDue_TEF.toString());
            $(".lblDue_Intt_TEF").html(lblDue_Intt_TEF.toString());
            $(".lbl_LeasePeriod").html(lbl_LeasePeriod.toString());
            $(".lblTotalBalanceDues").html(lblTotalBalanceDues.toString());
            $(".ReservationAmount").html(Reservationamount.toFixed(2).toString());
            $(".TotalReservationMoneyPer").html(ReservationMoneyPer.toString());
            $(".EMDAmount").html(EMDAmount.toFixed(2).toString());

            var date = new Date();
            date.setDate(date.getDate() + EmdDepositDays);
            var dateFormated = date.toISOString().substr(0, 10);

            $(".EmdAmountDate").html(date.format('dd/MM/yyyy'));
            $(".LocationChargeRate").html(LocationChargeRate);
            $(".ChargePer").html(ReservationMoneyPer);
            $(".RemPremiumPer").html(RemPremiumPer);
            $(".Depreciation").html(Depreciation);
            $(".LeaseRent1").html(LeaseRent1.toFixed(2));
            $(".LeaseRent2").html(LeaseRent2.toFixed(2));
            $(".LeaseRent3").html(LeaseRent3.toFixed(2));
            $(".CoveredArea").html(CoveredArea);
            $(".SpanArea1").html(SystemPlotSize);
            $(".SpanRate").html(RateofPlot);
            $(".SpanEmdPer").html(EmdRatePer);
            $(".SpanArea11").html(ChoosenSize);

            var result1 = (SystemPlotSize * RateofPlot * EmdRatePer) / 100;
            var result2 = (ChoosenSize * RateofPlot * EmdRatePer) / 100;
            $(".Result1").html(result1);
            $(".Result2").html(result2);

            $('#<% =lblResultSet1.ClientID %>').attr('value', result1);
            $('#<% =lblResultSet2.ClientID %>').attr('value', result2);
            if (result1 > result2) {
                var difference = (result1 - result2);
                $(".Message").html("EMD Amount Return/Adjustment");
                $(".Difference").html(difference.toFixed(2));
            } else {
                var difference = (result2 - result1);
                $(".Message").html("EMD Amount Payable");
                $(".Difference").css('color', 'red');
                $(".Difference").html(difference.toFixed(2));
            }

            $(".FirstInstallmentDate").html(firstInstallmentDate);
            $('#<% =lblResultSet3.ClientID %>').attr('value', difference);

        

    }



    $(document).ready(function () {   
        AnyChangeCallMe();
        
    $("select input").change(function () {
        AnyChangeCallMe();
    });

    $("input[type='text']").keyup(function () {
        AnyChangeCallMe();
    });

    function ShowLumpSum() {

        $(".levy_lumpsum").show();
        $(".levy_installment").hide();
    }
    function ShowInstallment() {

        $(".levy_lumpsum").hide();
        $(".levy_installment").show();
    }   
    });

    //Re-bind for callbacks
    var prm = Sys.WebForms.PageRequestManager.getInstance(); 

    prm.add_endRequest(function () { 

        AnyChangeCallMe();
        
       
    $("select input").change(function () {

        AnyChangeCallMe();
    });

    $("input[type='text']").keyup(function () {

        AnyChangeCallMe();
    });

    function ShowLumpSum() {

        $(".levy_lumpsum").show();
        $(".levy_installment").hide();
    }
    function ShowInstallment() {

        $(".levy_lumpsum").hide();
        $(".levy_installment").show();
    }
    }); 

    $(document).ready(function () {
        $("input#LumpSumRad").click(function () {
            //var test = $(this).val();

            $(".levy_lumpsum").show();
            $(".levy_installment").hide();
        });
        $("input#InstallmentRad").click(function () {
            //var test = $(this).val();

            $(".levy_lumpsum").hide();
            $(".levy_installment").show();
        });
    });

   

</script>
