<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_DataFactsT.ascx.cs" Inherits="Allotment.UC_DataFactsT" %>


<style>
    .modal-backdrop.fade {
    display:none !important;
    }
    .assess-min-height {
        min-height:725px !important;
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
                                    <td>Existing Allotment Date </td>
                                    <td>
                                        <asp:Label ID="lblAllotmentDate" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVeriFyEmdRates" AutoPostBack="true" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlVeriFyEmdRates_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtAllotmentDateVerified" CssClass="EmdRatePer input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtEMDRateVerified_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I14" visible="false"></i><i class="fa fa-check" runat="server" id="I24" visible="false"></i></td>
                                </tr>



                                <tr>
                                    <td>Agreement Date</td>
                                    <td>
                                        <asp:Label ID="lblAgreementDate" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVerifyReservationMoney" Style="padding: 0px 0px !important;" AutoPostBack="true" OnSelectedIndexChanged="ddlVerifyReservationMoney_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtAgreementDateVerified" CssClass="AgreementDate input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtRegistrationMoneyRateVerified_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I15" visible="false"></i><i class="fa fa-check" runat="server" id="I25" visible="false"></i></td>
                                </tr>



                                <tr>
                                    <td>Existing Possession Date</td>
                                    <td>
                                        <asp:Label ID="lblPossessionDate" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVerifyLocationCharge" Style="padding: 0px 0px !important;" AutoPostBack="true" OnSelectedIndexChanged="ddlVerifyLocationCharge_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtPossessionDateVerified" CssClass="PossessionDate input-sm" Width="80%" AutoPostBack="true" OnTextChanged="txtLocationChargeVerified_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I16" visible="false"></i><i class="fa fa-check" runat="server" id="I26" visible="false"></i></td>
                                </tr>


                                <tr>
                                    <td>Existing Lease Deed Date</td>
                                    <td>
                                        <asp:Label ID="lblLeaseDeedDate" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlRebateVerify" Style="padding: 0px 0px !important;" AutoPostBack="true" OnSelectedIndexChanged="ddlRebateVerify_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtLeaseDeedDateVerified" CssClass="LeaseDeedDate input-sm" AutoPostBack="true" Width="80%" OnTextChanged="txtRebateVerified_TextChanged" Enabled="false"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I17" visible="false"></i><i class="fa fa-check" runat="server" id="I27" visible="false"></i></td>
                                </tr>


                                <tr>
                                    <td>District Treasury Name</td>
                                    <td>
                                        <asp:Label ID="lblTreasuryName" runat="server" onkeypress="return isDecimalKey(event);"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVerifyNoOfInstallment" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlVerifyNoOfInstallment_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtTreasuryNameVerified" CssClass="TreasuryName input-sm" Enabled="false" Width="80%" AutoPostBack="true" OnTextChanged="txtNoOfInstallmentVerified_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I18" visible="false"></i><i class="fa fa-check" runat="server" id="I28" visible="false"></i></td>
                                </tr>
                                <tr >
                                    <td>Lease Rent (0-30 years)</td>
                                    <td>
                                        <asp:Label ID="lblLeaseRent1" runat="server" onkeypress="return isDecimalKey(event);"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlLeaseRent1" Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlLeaseRent1_SelectedIndexChanged" AutoPostBack="true">
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
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlLeaseRent2"  Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlLeaseRent2_SelectedIndexChanged" AutoPostBack="true">
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
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlLeaseRent3"  Style="padding: 0px 0px !important;" OnSelectedIndexChanged="ddlLeaseRent3_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtLeaseRent3" CssClass="LeaseRent3 input-sm" Enabled="false" Width="80%" AutoPostBack="true" OnTextChanged="txtLeaseRent3_TextChanged"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="IDis27" visible="false"></i><i class="fa fa-check" runat="server" id="IApp27" visible="false"></i></td>
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
                       
                              
                            </table>

                        </div>

                    </div>


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


                    <asp:Label runat="server" ID="lblServiceReqNo" Visible="false" ></asp:Label>
                   


                </div>
            </div>
        </div>
    </div>


    <div class="col-md-8 col-sm-8 col-xs-6 check-right">
        <div class="div-assesment-applicant assess-min-height" style="">
            <div class="div-view div-scroll" style="max-height: 628px; overflow-y: auto; border: 1px solid #ccc; background: #fff;">

                <%-- Preview Version  --%>
                <asp:Literal runat="server" ID="Preview_Litral"></asp:Literal>

            </div>
        </div>
    </div>
</div>

<script>


    function AnyChangeCallMe() {


        $(".lblPlotNo").html($(".PlotNo").val());
        $(".ListofClause").html($(".Clause_table").html());
        $(".ListofNotices").html($(".Notices_table").html());
        $(".ListofAnnexres").html($(".Annexre_Table").html());
        $(".BP").html($(".Annexure").html());





        var PlotNo = $(".PlotNo").val();
        var LeaseDate = $(".LeaseDeedDate").val();
        var PossessionDate = $(".PossessionDate").val();
        var AgreementDate = $(".AgreementDate").val();
        var firstInstallmentDate = $(".FirstInstallment").val();
        var DistTreasury = $(".TreasuryName").val();
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

        var Reservationamount1 = (totalPremium1) * ((ReservationMoneyPer + EmdRatePer) / 100);
        // var Reservationamount = (totalPremium) * ((ReservationMoneyPer) / 100);
        var EMDAmount = (totalPremium * (EmdRatePer / 100));
        var Reservationamount = (Reservationamount1) - (EMDAmount);





        $(".ExistingConstructionValue").html(ConstructionValue.toString());
        $(".ProductionStart").html(ProductionStart.toString());
        $(".DistTreasury").html(DistTreasury.toString());

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

        $(".lbl_Lease_Deed_dated").html(LeaseDate.toString());
        $(".lbl_Possession_Memo_dated").html(PossessionDate.toString());
        $(".lbl_Agreement_dated").html(AgreementDate.toString());
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


    });





</script>



