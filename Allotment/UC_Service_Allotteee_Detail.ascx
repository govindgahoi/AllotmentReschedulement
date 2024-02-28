<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Service_Allotteee_Detail.ascx.cs" Inherits="Allotment.UC_Service_Allotteee_Detail" %>

<style>
    .pad-left0 {
        padding-left: 0;
    }

    @media only screen and (max-width: 992px) {
        .form-group label.text-right {
            text-align: left !important;
        }
    }

    label {
        margin-bottom: 0;
    }
</style>



<div runat="server" id="uc_alloottee_details" class="row">
    <div class="col-md-12 col-sm-12 col-xs-12" style="padding: 0;">
        <div class="panel panel-default" style="border: 1px solid #e6e6e6;">

            <div style="background: #ececec; margin-top: 0px;">
                <div class="form-group">
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Regional Office :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblAllotteeRegionalOffice" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12  text-right">
                        Industrial Area :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblIndustrialArea" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12  text-right">
                        Plot No :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblPlotNo" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Allotted in Name of :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12 ">
                        <asp:Label ID="lblAllottedinNameof" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Authorized User :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblAuthorizedUser" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Allotted Area :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblAllottedArea" runat="server" CssClass="font-bold"></asp:Label>
                    </div>

                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Firm/Company Name :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblFirmCompanyConstruction" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Firm/Company Constitution :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblFirmConstitution" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        CIN No :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblCINNo" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        PAN No :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblPANNo" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Email Id :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblEmail" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Phone No :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblPhoneNo" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                </div>




                <%--                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                                Correspondence Address :
                            </label>
                            <div class="col-md-2 col-sm-12 col-xs-12">
                                <asp:Label ID="lblCorAddress" runat="server" CssClass="font-bold"></asp:Label>
                            </div>
                            <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                                Application Id :
                            </label>
                            <div class="col-md-2 col-sm-12 col-xs-12">
                                <asp:Label ID="lblApplicationId" runat="server" CssClass="font-bold"></asp:Label>
                            </div>
                            
                        </div>--%>
                <div class="clearfix"></div>
                <hr class="myhrline" />
            </div>

            <div>
                <div class="panel-heading font-bold">Important Facts</div>
                <div class="form-group">
                    <div class="col-md-2 col-sm-12 col-xs-12  font-bold border-rt">
                        Allotment
                    </div>

                    <label class="col-md-2 col-sm-12 col-xs-12">
                        Allotment No :
                    </label>

                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblAllotmentNo" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Allotment Date :
                    </label>

                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblALlotmentDate" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Application Letter :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblApplicationLetter" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                </div>


                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-2 col-sm-12 col-xs-12 font-bold border-rt">
                        Possession
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12">
                        Possession No :
                    </label>
                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblPossessionNo" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Possession Date :
                    </label>
                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblPossessionDate" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Area Under Possession:
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblPossessionArea" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-2 col-sm-12 col-xs-12  font-bold border-rt">
                        Lease Deed
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12">
                        Lease Deed Date :
                    </label>
                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblLeaseDeedDate" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Lease Deed Execution Date :
                    </label>
                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblLeaseDeedExecutionDate" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Lease Deed :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblLeaseDeed" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                </div>


                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-2 col-sm-12 col-xs-12  font-bold border-rt">
                        Building Plan Submission
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12">
                        Submission Date :
                    </label>
                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblBPSubmissiondate" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Approval Date :
                    </label>
                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblBPApprovalDate" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Approval Letter :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblBPApprovalLetter" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-2 col-sm-12 col-xs-12  font-bold border-rt">
                        Inspection for Construction
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12">
                        Inspection Date :
                    </label>
                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblCOnstructionInspection" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Inspection Report :
                    </label>
                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblInspectionConstructreport" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Inspected by:
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblInspectedby" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-2 col-sm-12 col-xs-12  font-bold border-rt">
                        Inspection for Completion
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12">
                        Inspection Date :
                    </label>
                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblInspectionDate" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Inspection Report :
                    </label>
                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblInspectionReport" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Inspected by:
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblCompletionInspectedby" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-2 col-sm-12 col-xs-12  font-bold border-rt">
                        Building plan completion
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12">
                        Completion Date :
                    </label>
                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblBPCompletionDate" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Completion Letter issue Date :
                    </label>
                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblCompletionissuedate" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Completion Letter No:
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblCompletionletterNo" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-2 col-sm-12 col-xs-12  font-bold border-rt">
                        Occupancy certificate
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12">
                        Release Date :
                    </label>
                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblOccupancyReleaseDate" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Certificate issue Date :
                    </label>
                    <div class="col-md-1 col-sm-12 col-xs-12">
                        <asp:Label ID="lblCertificateissueDate" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Certificate No:
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblOccupancyCertificateNo" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                </div>
                
                
                
                



                    <%--                            <label class="col-md-2 col-sm-12 col-xs-12">
                                Map Approval Charges :
                            </label>
                            <div class="col-md-10 col-sm-12 col-xs-12">
                                <i class="fa fa-inr"></i><asp:Label ID="lblMapApprovalCharges" runat="server" CssClass="font-bold"></asp:Label>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-2 col-sm-12 col-xs-12">
                                Inspection Charges :
                            </label>
                            <div class="col-md-10 col-sm-12 col-xs-12">
                                <i class="fa fa-inr"></i><asp:Label ID="lblInspectionCharges" runat="server" CssClass="font-bold"></asp:Label>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-2 col-sm-12 col-xs-12">
                                Malwa Charges :
                            </label>
                            <div class="col-md-10 col-sm-12 col-xs-12">
                                <i class="fa fa-inr"></i><asp:Label ID="lblMalwaCharges" runat="server" CssClass="font-bold"></asp:Label>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-2 col-sm-12 col-xs-12">
                                Pending Dues :
                            </label>
                            <div class="col-md-10 col-sm-12 col-xs-12">
                                <i class="fa fa-inr"></i><asp:Label ID="lblPendingDues" runat="server" CssClass="font-bold"></asp:Label>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:Button CssClass="btn btn-sm pull-right pay-btn" Text="Pay Now" runat="server"/>
                        </div>
                        <div class="clearfix"></div>--%>
                </div>





            </div>

        <div class="clearfix"></div>

            <div class="Other_section" style="padding: 10px;margin: 10px 0;">

                <div class="clearfix"></div>
                <div class="panel-heading font-bold">Objection from sections</div>
                <div class="font-bold" style="background: #efefef;">Industrial Area</div>
                        <div class="form-group">
                            <asp:GridView ID="clearence4" runat="server" CssClass="table table-striped table-bordered table-hover request-table request-table" AutoGenerateColumns="true" ShowHeader="true" Width="100%">
                                <EmptyDataTemplate>No Objection Found</EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                <div style="border:1px solid #ccc;">
                        <div class="font-bold" style="background: #efefef;">Land Acquisition</div>
                        <div class="form-group">
                            <asp:GridView ID="clearence1" runat="server" AutoGenerateColumns="true" ShowHeader="true" >
                                <EmptyDataTemplate>No Objection Found</EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="font-bold" style="background: #efefef;">ATP & Layout</div>
                        <div class="form-group">
                            <asp:GridView ID="clearence2" runat="server" AutoGenerateColumns="true" ShowHeader="true">
                                <EmptyDataTemplate>No Objection Found</EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="font-bold" style="background: #efefef;">Engineering</div>
                        <div class="form-group">
                            <asp:GridView ID="clearence3" runat="server" AutoGenerateColumns="true" ShowHeader="true">
                                <EmptyDataTemplate>No Objection Found</EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        

                        <div class="font-bold" style="background: #efefef;">Legal</div>
                        <div class="form-group">
                            <asp:GridView ID="clearence5" runat="server" AutoGenerateColumns="true" ShowHeader="true">
                                <EmptyDataTemplate>No Objection Found</EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="font-bold" style="background: #efefef;">Finance</div>
                        <div class="form-group">
                            <asp:GridView ID="clearence6" runat="server" AutoGenerateColumns="true" ShowHeader="true">
                                <EmptyDataTemplate>No Objection Found</EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                </div>

            </div>




        </div>
    
        
    </div>

