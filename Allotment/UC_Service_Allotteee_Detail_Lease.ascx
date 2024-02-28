<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Service_Allotteee_Detail_Lease.ascx.cs" Inherits="Allotment.UC_Service_Allotteee_Detail_Lease" %>

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



<div runat="server" id="uc_alloottee_details">
    <div class="col-md-12 col-sm-12 col-xs-12" >
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
                
                
                
                
                </div>





            </div>

    
         
                <div class="clearfix"></div>
                <hr class="myhrline" />
        </div>
     <div class="col-md-12 col-sm-12 col-xs-12" >
           <div style="border:1px solid #ccc;">
                <div class="font-bold" style="background: #efefef;">JE Site Inspection Details</div>
                        <div class="form-group">
                      
                    <label class="col-md-2 col-sm-12 col-xs-12">
                        Existing Construction Value :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblExistingConstruction" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Plot Area (As Per Tracing) :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblAreaPerTracing" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                            <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                       Site Inspction Date :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblSiteInspectionDate" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                         
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                <label class="col-md-2 col-sm-12 col-xs-12">
                       Plot Dimension :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblPlotDimension" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                <label class="col-md-2 col-sm-12 col-xs-12">
                        Plot Direction :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblPlotDirection" runat="server" CssClass="font-bold"></asp:Label>
                    </div> 
                  <label class="col-md-2 col-sm-12 col-xs-12">
                        
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                      
                    </div>
              <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="font-bold" style="background: #efefef;">Lease Deed Details</div>
                         <div class="form-group">
                      
                    <label class="col-md-3 col-sm-12 col-xs-12">
                        Lease Registration Date :
                    </label>
                    <div class="col-md-9 col-sm-12 col-xs-12">
                        <asp:Label ID="lblRegistrationDate" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                   
                         
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="font-bold" style="background: #efefef;">Possession Details</div>
                        <div class="form-group">
                          <div class="form-group">
                      
                    <label class="col-md-2 col-sm-12 col-xs-12">
                        Possession Area Given :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblPossessionAreaGiven" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                        Possession Given To :
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblPossessionGivenTo" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                            <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                       Possession Date:
                    </label>
                    <div class="col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="lblPossessionGivenDate" runat="server" CssClass="font-bold"></asp:Label>
                    </div>
                         
                        </div>
                        </div>
                        <div class="clearfix"></div>
                       
                    </div>

            



        </div>
    
        
    </div>

