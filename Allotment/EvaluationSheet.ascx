<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EvaluationSheet.ascx.cs" Inherits="Allotment.EvaluationSheet" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

	<style>
	
	    @media only screen and (min-width: 768px) {
	        .evaluation-row .eval-div-left {
	            width: 62.8%;
	            float: left;
	            margin-right: 1px;
	        }

	        .evaluation-row .eval-div-right {
	            width: 37%;
	            float: left;
	            margin-left: 1px;
	        }
	    }

	    @media only screen and (max-width: 768px) {
	        .evaluation-row .eval-div-left {
	            width: 100%;
	            float: left;
	            margin-right: 1px;
	        }

	        .evaluation-row .eval-div-right {
	            width: 100%;
	            float: left;
	            margin-left: 1px;
	        }
	    }
	</style>


	
	
	<script type='text/javascript'>
      

        function PrintElem() {

            Popup($('#DivP').html());
        }

        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=1000');
            mywindow.document.write('<html><head><title style="font-weight:bold;">Land Allotment Application</title>');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/bootstrap.min.css\" type=\"text/css\" />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/theme.css\" type=\"text/css\"  />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/print.css\" type=\"text/css\"  />');
            mywindow.document.write('</head><body >');
            mywindow.document.write(data);
            mywindow.document.write('</body></html>');

            setTimeout(function () {
                mywindow.print();
                mywindow.close();
            }, 1000);


            return true;
        }

    </script>



                  <cc1:MessageBox ID="MessageBox1" runat="server" />
	


	<div class="text-center my-new-heading">Evaluation Sheet</div>
				
					
					                    
						<div class="table-responsive" style="overflow-y: auto; border: 1px solid #ccc;">
							<asp:GridView ID="GridViewApplicants" Width="1800px" runat="server" AutoGenerateColumns="true"
								OnRowDataBound="GridViewApplicants_OnRowDataBound"
								OnRowCommand="GridViewApplicants_RowCommand"
								DataKeyNames="RequestNo"
								CssClass="table table-bordered table-hover request-table">
								<Columns>


									<asp:TemplateField HeaderText="Process" Visible="false" >
										<HeaderStyle HorizontalAlign="Left" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>


                                            <ul class="list-inline ul-boxicon" style="margin-left:0;margin-bottom:0;border: 1px solid #797979; background: #d8d8d8;">

                                               
                                                <li title="ViewMinutes">
                                                    <asp:LinkButton runat="server" aria-hidden="true" ID="btnMinutes" CssClass="fa fa-download" CommandName="ViewMinutes" CommandArgument='<%#Eval("RequestNo") %>' ToolTip="Click here For Committee Minutes" />
                                                </li>

                                                <li title="Recommend" style="display:none;">
                                                    <asp:LinkButton runat="server" ID="btnSelectApplicant_Recommendation" CssClass="fa fa-ban" Visible="false" CommandName="Reject_Application" CommandArgument='<%#Eval("RequestNo") %>' OnClientClick="javascript:return confirm('Are you sure wanted to reject this application?');" ToolTip="Click here to reject application" />
                                                </li

                                                     <li title="Sanction Letter" style="display:none;">
                                                    <asp:LinkButton runat="server" aria-hidden="true" ID="btnSelectApplicantLetter" CssClass="fa fa-envelope-o" Visible="false" CommandName="Select_Applicant_for_letter_generation" CommandArgument='<%#Eval("RequestNo") %>' ToolTip="Click here to Procced to Allot/Reject Application./" />
                                                </li>
                                            </ul>


                                        </ItemTemplate>
									</asp:TemplateField>

                                    <asp:TemplateField  Visible="false" >
                                            <ItemTemplate> <asp:HiddenField ID="IsRec" runat="server" Value='<%# Eval("Rec").ToString().ToLower()%>' /></ItemTemplate>
                                            </asp:TemplateField>

								</Columns>
							</asp:GridView>
						</div>
					
			





				<div class="clearfix"></div>
				<hr class="hr-separation" />
				<div class="evaluation-row">
					

                        <div class="panel-heading font-bold">Objective Criteria</div>
                        <div class="table-responsive" style="min-height: 100px; max-height: 300px; overflow-y: auto; border: 1px solid #ccc;">
                            <asp:GridView runat="server" ID="EvaluationChecklistGrid" CssClass="table table-bordered table-hover request-table" AutoGenerateColumns="true" />
                        </div>



						<div class="panel-heading font-bold">System Evaluation Based On Criteria</div>
						<div class="table-responsive" style="min-height: 100px; max-height: 300px; overflow-y: auto; border: 1px solid #ccc;">
						
                            <asp:GridView runat="server" ID="grid_Evaluation" AutoGenerateColumns="false"
                                ShowFooter="true"
                                EnableViewState="False"   OnRowDataBound="grid_Evaluation_RowDataBound"

								CssClass="table table-bordered table-hover request-table">
                                <Columns>
                                    <asp:BoundField HeaderText="Description" DataField="Description" />
                                    <asp:BoundField HeaderText="Max Marks" DataField="Max_Marks" />
									<asp:BoundField HeaderText="Applicant Quotes" DataField="Quotation" />
                                    <asp:BoundField HeaderText="Obtained Marks" DataField="Obtained_Marks" />
                                    <asp:BoundField HeaderText="Verifier Quotes" DataField="VerifiedVal" />
                                     <asp:BoundField HeaderText="Obtained Marks" DataField="verifiedmarks" />
									
                                    
                                	</Columns>
								
							</asp:GridView>
                        </div>
                  

                        

                        
                    


					
					

                        
						<div class="panel-heading font-bold">Land Applicability based on Proposed Investment</div>
						<div class="table-responsive" style="max-height: 300px; border: 1px solid #ccc;">
							<asp:GridView runat="server" ID="GridLAPI" AutoGenerateColumns="false"
								CssClass="table table-bordered table-hover request-table">
								<Columns>
									<asp:BoundField HeaderText="ApplicantName" DataField="ApplicantName" />
									<asp:BoundField HeaderText="Based On Proposed Investment" DataField="basedonproposedinvestment" />
								</Columns>
								<EmptyDataTemplate>
									Per Unit Land Apllicability .  
								</EmptyDataTemplate>
							</asp:GridView>

						</div>

                            <div class="">
						<div class="panel-heading font-bold">Land Applicability based on Covered Area</div>
						<div class="table-responsive" style="max-height: 300px;  border: 1px solid #ccc;">
							<asp:GridView runat="server" ID="GridViewca" AutoGenerateColumns="false"
								CssClass="table table-bordered table-hover request-table">
								<Columns>
									<asp:BoundField HeaderText="ApplicantName" DataField="ApplicantName" />
									<asp:BoundField HeaderText="Based On Covered Area" DataField="basedoncoveredArea" />
								</Columns>
								<EmptyDataTemplate>
									 not defined.  
								</EmptyDataTemplate>
							</asp:GridView>

						</div>
                          <div class="">
						<div class="panel-heading font-bold">Land Applicability based on Proposed Investment and Current Land Rates</div>
						<div class="table-responsive" style="max-height: 300px;border: 1px solid #ccc;">
							<asp:GridView runat="server" ID="GridViewratio" AutoGenerateColumns="false"
								CssClass="table table-bordered table-hover request-table">
								<Columns>
									<asp:BoundField HeaderText="ApplicantName" DataField="ApplicantName" />
									<asp:BoundField HeaderText="Based On Rate of IA" DataField="basedonRateofIA" />
								</Columns>
								<EmptyDataTemplate>
									 not defined.  
								</EmptyDataTemplate>
							</asp:GridView>

						</div>




				
			</div>
		</div>
	</div>



       <!-- Trigger the modal with a button -->

       <style>
           @media only screen and (min-width: 768px) {
               #evalrecommend .modal-dialog {
                   width: 65%;
               }
           }

           @media only screen and (max-width: 768px) {
               #evalrecommend .col-rec-left {
                   width: 38% !important;
               }

               #evalrecommend .col-rec-right {
                   width: 62% !important;
               }
           }

           #evalrecommend .col-rec-right {
           }

           #evalrecommend .col-rec-right {
           }

           #evalrecommend .modal-first {
               border: 1px solid #ccc;
               padding: 5px;
               margin: 6px;
           }

           #evalrecommend .modal-second {
               border: 20px solid #ccc;
               padding: 0px;
               margin: 0px;
           }

           #evalrecommend .modal-header {
               padding: 0;
           }
       </style>

       



   







   