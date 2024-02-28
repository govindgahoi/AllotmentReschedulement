<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="Evaluation.aspx.cs" Inherits="Allotment.Evaluation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style>
	    .modal-backdrop {
	        display:none  !important;
        }
	    .modal-open{
            overflow:scroll !important;	        
        }
	    .content {
            z-index:1 !important;
	    }

	    .ul-boxicon li a:before {
	        margin: 0 !important;
	    }

	    .navbar-collapse {
	        z-index: 9;
	    }

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


	
	<script type="text/javascript">

        function pageLoad() {
            $('.recc').click(function () {

                var id = this.id;

                var c = $(this).closest('span').find('.' + id + '').text();
                alert(c);
                $("#<%=ServiceRequestNo_lbl.ClientID%>").val('');
                $("#<%=ServiceRequestNo_lbl.ClientID%>").attr('value', c.trim());

            });

            $(".collapse.in").each(function () {
                $(this).siblings(".panel-heading").find(".glyphicon").addClass("glyphicon-minus").removeClass("glyphicon-plus");
            });

            // Toggle plus minus icon on show hide of collapse element
            $(".collapse").on('show.bs.collapse', function () {
                $(this).parent().find(".glyphicon").removeClass("glyphicon-plus").addClass("glyphicon-minus");
            }).on('hide.bs.collapse', function () {
                $(this).parent().find(".glyphicon").removeClass("glyphicon-minus").addClass("glyphicon-plus");
            });


        }
            function shrinkandgrow(input) {
                var displayIcon = "img" + input;
                if ($("#" + displayIcon).attr("src") == "grow.png") {
                    $("#" + displayIcon).closest("tr")
                        .after("<tr><td></td><td colspan = '100%'>" + $("#" + input)
                            .html() + "</td></tr>");
                    $("#" + displayIcon).attr("src", "shrink.png");
                } else {
                    $("#" + displayIcon).closest("tr").next().remove();
                    $("#" + displayIcon).attr("src", "grow.png");
                }
            }
        
	</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




	
	 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" >
</asp:ScriptManager>

	<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">   
   <ContentTemplate>


          <cc1:MessageBox ID="MessageBox1" runat="server" />
	

<%--       <i class="fa fa-calculator" aria-hidden="true"></i>--%>


	<div class="row">
		<div class="col-md-12 col-sm-12 col-xs-12" style="padding: 0;">
			<div class="panel panel-default">
				<div class="row">
					<div class="col-md-12 col-sm-12 col-xs-12" style="">
						<div class="text-center my-new-heading"><span style="text-align:left !important"><asp:button id="btnCancel" runat="server" text="Go to Previous" OnClientClick="JavaScript:window.history.back(1); return false;" /> </span>Evaluation Status Sheet</div>
						<div class="table-responsive">
						</div>
						<div class="panel-heading">
							<asp:Label ID="lblheader" runat="server" ></asp:Label>
						</div>
                        

						<div class="table-responsive" style="overflow-y: auto; border: 1px solid #ccc;">
							<asp:GridView ID="GridViewApplicants" Width="1800px" runat="server" AutoGenerateColumns="true"
								OnRowDataBound="GridViewApplicants_OnRowDataBound"
								OnRowCommand="GridViewApplicants_RowCommand"
								DataKeyNames="RequestNo"
								CssClass="table table-bordered table-hover request-table">
								<Columns>


									<asp:TemplateField HeaderText="Process" >
										<HeaderStyle HorizontalAlign="Left" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>


                                            <ul class="list-inline ul-boxicon" style="margin-left:0;margin-bottom:0;border: 1px solid #797979; background: #d8d8d8;">

                                                <li title="Assessment">
                                                    <asp:LinkButton runat="server" aria-hidden="true" ID="btnSelectApplicant" CssClass="fa fa-calculator" CommandName="Select_Applicant_for_process" CommandArgument='<%#Eval("RequestNo") %>' ToolTip="Click here For Individual Assesment" />
                                                </li>
                                                <li title="ViewMinutes">
                                                    <asp:LinkButton runat="server" aria-hidden="true" ID="btnMinutes" CssClass="fa fa-download" CommandName="ViewMinutes" CommandArgument='<%#Eval("RequestNo") %>' ToolTip="Click here For Committee Minutes" />
                                                </li>

                                                <li title="Recommend">
                                                       <asp:LinkButton runat="server" ID="btnSelectApplicant_Recommendation" CssClass="fa fa-ban" Visible="false" CommandName="Reject_Application" CommandArgument='<%#Eval("RequestNo") %>' OnClientClick="javascript:return confirm('Are you sure wanted to reject this application?');" ToolTip="Click here to reject application" />
                                                </li

                                                     <li title="Sanction Letter">
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
					</div>
				</div>





				<div class="clearfix"></div>
				<hr class="hr-separation" />
				<div class="evaluation-row">
					<div class="eval-div-left">

                        <div class="panel-heading font-bold">Objective Criteria</div>
                        <div class="table-responsive" style="min-height: 100px; max-height: 300px; overflow-y: auto; border: 1px solid #ccc;">
                            <asp:GridView runat="server" ID="EvaluationChecklistGrid" CssClass="table table-bordered table-hover request-table" AutoGenerateColumns="true" />
                        </div>



						<div class="panel-heading font-bold">System Evaluation Based On Criteria</div>
						<div class="table-responsive" style="min-height: 100px; max-height: 300px; overflow-y: auto; border: 1px solid #ccc;">
						
                            <asp:GridView runat="server" ID="grid_Evaluation" AutoGenerateColumns="true"

                                EnableViewState="False"  OnRowCreated="grid_Evaluation_RowCreated" OnRowDataBound="grid_Evaluation_RowDataBound"

								CssClass="table table-bordered table-hover request-table">
								
							</asp:GridView>
                        </div>
                    </div>

                        

                        
                    


					<div class="eval-div-right">
						<div class="panel-heading font-bold">Approving Authority</div>
						<div class="table-responsive" style="min-height: 100px; max-height: 300px; overflow-y: auto; border: 1px solid #ccc;">
							<asp:GridView runat="server" ID="GridCommittee" AutoGenerateColumns="false"
								CssClass="table table-bordered table-hover request-table">
								<Columns>
									<asp:BoundField HeaderText="EMPLOYEENAME" DataField="EMPLOYEENAME" />
									<asp:BoundField HeaderText="Designation" DataField="Designation" />
									<asp:BoundField HeaderText="MemberType" DataField="MemberType" />

								</Columns>
								<EmptyDataTemplate>
									Committee not defined.  
								</EmptyDataTemplate>
							</asp:GridView>

						</div>

                        <div class="">
						<div class="panel-heading font-bold">Land Applicability based on Proposed Investment</div>
						<div class="table-responsive" style="max-height: 300px; overflow-y: auto; border: 1px solid #ccc;">
							<asp:GridView runat="server" ID="GridLAPI" AutoGenerateColumns="false"
								CssClass="table table-bordered table-hover request-table">
								<Columns>
									<asp:BoundField HeaderText="ApplicantName" DataField="ApplicantName" />
									<asp:BoundField HeaderText="basedonproposedinvestment" DataField="basedonproposedinvestment" />
								</Columns>
								<EmptyDataTemplate>
									Per Unit Land Apllicability .  
								</EmptyDataTemplate>
							</asp:GridView>

						</div>

                            <div class="">
						<div class="panel-heading font-bold">Land Applicability based on Covered Area</div>
						<div class="table-responsive" style="max-height: 300px; overflow-y: auto; border: 1px solid #ccc;">
							<asp:GridView runat="server" ID="GridViewca" AutoGenerateColumns="false"
								CssClass="table table-bordered table-hover request-table">
								<Columns>
									<asp:BoundField HeaderText="ApplicantName" DataField="ApplicantName" />
									<asp:BoundField HeaderText="basedoncoveredArea" DataField="basedoncoveredArea" />
								</Columns>
								<EmptyDataTemplate>
									 not defined.  
								</EmptyDataTemplate>
							</asp:GridView>

						</div>
                          <div class="">
						<div class="panel-heading font-bold">Land Applicability based on Proposed Investment and Current Land Rates</div>
						<div class="table-responsive" style="max-height: 300px; overflow-y: auto; border: 1px solid #ccc;">
							<asp:GridView runat="server" ID="GridViewratio" AutoGenerateColumns="false"
								CssClass="table table-bordered table-hover request-table">
								<Columns>
									<asp:BoundField HeaderText="ApplicantName" DataField="ApplicantName" />
									<asp:BoundField HeaderText="basedonRateofIA" DataField="basedonRateofIA" />
								</Columns>
								<EmptyDataTemplate>
									 not defined.  
								</EmptyDataTemplate>
							</asp:GridView>

						</div>




						<span class="hide">
						<div class="panel-heading font-bold">First Come First Serve</div>
						<div class="  table-responsive" style="max-height: 300px; overflow-y: auto; border: 1px solid #ccc;">


		<%--					<asp:GridView ID="Grid_fcfs" AutoGenerateColumns="false" CssClass="table table-bordered table-hover request-table" runat="server">
								<Columns>
								  

								   <asp:TemplateField>
									   <ItemTemplate>

									   </ItemTemplate>
								   </asp:TemplateField>



									<asp:BoundField HeaderText="Applicant" DataField="Applicantid" />
									<asp:BoundField HeaderText="ApplicantName" DataField="ApplicantName" />
									<asp:BoundField HeaderText="App. Received On" DataField="Applicationsubmissiondate" />
								</Columns>
							</asp:GridView>--%>


							<table class="table table-bordered table-hover request-table hide" style="width: 100%;">
								<tr>
									<th style="width: 5%">Sr No</th>
									<th style="width: 22%">Criteria</th>
									<th style="width: 8%">Value</th>
								</tr>
								<tr>
									
								</tr>
								<tr>
									<td>2</td>
									<td>Based on covered area.</td>
									<td>Content3</td>
								</tr>
								<tr>
									<td>3</td>
									<td>Investment vs IA Rates</td>
									<td>Content3</td>
								</tr>
								<tr>
									<td colspan="2"><strong class="pull-right">Land Admissible</strong></td>
									<td><strong>Content3</strong></td>
								</tr>
							</table>
					
							
						</div>
						</span>

						<span class="hide">
						<div class="panel-heading font-bold">Counter Application on Plots</div>
						<div class="table-responsive" style="min-height: 100px; max-height: 300px; overflow-y: auto; border: 1px solid #ccc;">
							
							<table class="table table-bordered table-hover request-table" style="width: 100%;">
								<tr>
									<th style="width: 5%">Sr No</th>
									<th style="width: 22%">Criteria</th>
									<th style="width: 8%">Value</th>
								</tr>
								<tr>
									<td>1</td>
									<td>Based on proposed investment.</td>
									<td>Content3</td>
								</tr>
								<tr>
									<td>2</td>
									<td>Based on covered area.</td>
									<td>Content3</td>
								</tr>
								<tr>
									<td>3</td>
									<td>Investment vs IA Rates</td>
									<td>Content3</td>
								</tr>
								<tr>
									<td colspan="2"><strong class="pull-right">Land Admissible</strong></td>
									<td><strong>Content3</strong></td>
								</tr>
							</table>
						</div>
							</span>

                        <span class="hide">
						<div class="panel-heading font-bold">Rule Book</div>
						<div class="table-responsive" style="border: 1px solid #ccc;">
							<asp:GridView runat="server" Width="900px" ID="grid_Evaluation_Criteria" OnPreRender="gridView_PreRender"
								CssClass="table table-bordered table-hover request-table"  />
						</div>
                        </span>


					</div>
				</div>

                <br /><br />
                            </div></div>


                <div class='clearfix'></div>
              <div><div>
                  <hr class="separation" />
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                           <asp:Label ID="DivNotesheet" runat="server" />
                    </div>
                 </div>



				<div class="clearfix"></div>
				<hr class="hr-separation" />
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

       

<!-- Modal -->

   
<div id="evalrecommend" tabindex="-1" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" id="closeModelBtn" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title" style="background:#000;color:#fff;margin-right:18px;padding-left:5px;">Recommendation / Approval</h4>
      </div>
      <div class="modal-body">
          <div class="modal-first">
              <div class="modal-second row">
                  <div class="col-md-4 col-sm-6 col-xs-6 col-rec-left" style="padding:0;">
                         Set Recommendation: 
                   </div> 
                  <div class="col-md-8 col-sm-6 col-xs-6 col-rec-right" style="padding:0;">

                      <asp:TextBox runat="server"  CssClass="hide" ID="ServiceRequestNo_lbl" />
                      
                          <asp:DropDownList ID="drp_Recommendation"  runat="server" CssClass="input-sm similar-select1 " Width="100%">
                             <asp:ListItem Text="--Please Select--" Value ="" />
		                     <asp:ListItem Text="Recommended" Value ="1" />
                              <asp:ListItem Text="Not Recommended" Value ="0" />
                         </asp:DropDownList>


                      <asp:DropDownList ID="drpOperate"  runat="server" CssClass="input-sm similar-select1 " Width="100%" Visible="false">
                             <asp:ListItem Text="-- Select Ticket Status--" Value ="0" />
		                     <asp:ListItem Text="Close" Value ="7" Selected />
                         </asp:DropDownList>
                    </div>
                  <div class="clearfix"></div>
                    <div class="col-md-12 col-sm-6 col-xs-6" style="padding:0;">
                         <asp:TextBox ID="txtTicketComment" TextMode="multiline"  placeholder="Comment Here ..."  runat="server" Style="margin-top:5px;background: #fffdf7;height:340px;" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                    </div>
                      <div class="clearfix"></div>
                       <hr class="myhrline" />
                      <div class="col-md-12">
                            <asp:Button runat="server" ID="ChangeTicketStatus"  OnClick="ChangeTicketStatus_Click"   Width="100%" class="ey-bg ey-mainbg pull-right"  style="margin: 2px 5px 0 0;" Text="Close Ticket" />
                      </div>
              </div>
          </div>
      </div>
    </div>

  </div>
</div>


<input type="button" id="btnModalRec" style="display: none;" data-toggle="modal" data-target="#evalrecommend"  data-backdrop="false"  /> 
<input type="button" id="btnModalRecClose" style="display: none;" data-dismiss="modal"  data-backdrop="false"  /> 
<script>
   
        // Add minus icon for collapse element which is open by default
      
    
</script>

    <script>
        function ShowModel(ModelOpenClose) {

            $('#closeModelBtn').click(function () {
                $('#evalrecommend').removeClass('fade');
            });

            if (ModelOpenClose == "open") {
                $('#evalrecommend').modal('show');
            }

            if (ModelOpenClose == "close") {
                $('#evalrecommend').modal('hide');
            }
        }
        

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('#closeModelBtn').click(function () {
                $('.modal-backdrop').remove();
            });




            //function ShowModel(ModelOpenClose)
            //{

            //    if (ModelOpenClose == "open")
            //    {
            //        $('#btnModalRec').click();
            //        alert('clicl-2  open');
            //    }

            //    if (ModelOpenClose == "close")
            //    {
            //        $('#btnModalRecClose').click();
            //        alert('clicl -2  close');
            //    }
            //}

        });


        </script>


	   </ContentTemplate>
		</asp:UpdatePanel>


</asp:Content>
