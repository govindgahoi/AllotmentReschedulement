<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="true" CodeBehind="UC_Assesment_Entry_Allotment.ascx.cs" Inherits="Allotment.UC_Assesment_Entry_Allotment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>
   <cc1:MessageBox ID="MessageBox1" runat="server" />




  <div class="tab-content clearfix">
								<div class="form-group">
									<style>
									    .pad-rt0 {
									        padding-right:0;
                                        }
                                        .pad-lt0 {
									        padding-left:0;
                                        }
									    .font700 {
									        font-weight:700;
                                        }
									    .my-new-heading {
									        margin-bottom:0;
                                        }
									</style>

                                    <div class="hide">
													<div class="clearfix"></div>
													<hr class="myhrline" />
													<p class="my-new-heading font-bold">Project Details</p>
                                                    <p class="panel-heading font700">Estimated Cost (In Lacs) :</p>
													<div class="form-group">
														<div class="row">
															<label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Applicant Quote :
															</label>

                                                            <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0" title="(In Lacs)">
																 <i class="fa fa-inr"></i><asp:Label  ID="txtestimatedcost_lbl" runat="server" />
															</div>
                                                            <div class="clearfix"></div>
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Observer Quote :
															</label>
															<div class="col-md-6 col-sm-6 col-xs-6 pad-lt0" title="(In Lacs)">
																<i class="fa fa-inr"></i><asp:TextBox ID="txtestimatedcost" Width="93%" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />

                                    </div>

                                                    <p class="panel-heading font700">Employment (In Numbers) :</p>
													<div class="form-group">
														<div class="row">
															<label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Applicant Quote :
															</label>															
                                                            <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0" title="(In Numbers)">
																 <asp:Label  ID="txtestimatedemployment_lbl" runat="server" />
															</div>
                                                            <div class="clearfix"></div>
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Observer Quote :
															</label>                                                            
                                                            <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0" title="(In Numbers)">
																<asp:TextBox ID="txtestimatedemployment" Width="93%" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />
                                                    <!--<div class="my-new-heading font-bold">Related Work Experience & Proposed Start Period</div>-->
                                                    <p class="panel-heading font700">Work Experience (In Months) :</p>
                                                    <div class="form-group">
														<div class="row">
															<label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Applicant Quote :
															</label>
															
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																 <asp:Label  ID="txtWorkExperience_lbl" runat="server" />
															</label>
                                                            <div class="clearfix"></div>
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Observer Quote :
															</label>                                                             
                                                            <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																<asp:TextBox ID="txtWorkExperience" runat="server" CssClass="input-sm similar-select1" Width="93%" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />
                                                    <p class="panel-heading font700">Start Period (In Months) :</p>
													<div class="form-group">
														<div class="row">
															<label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Applicant Quote :
															</label>															
                                                            <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																 <asp:Label  ID="txtProjectStartMonths_lbl" runat="server" />
															</div>
                                                            <div class="clearfix"></div>
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Observer Quote :
															</label>                                                            
                                                            <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																<asp:TextBox ID="txtProjectStartMonths" Width="93%" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />
													
													<div class="panel-heading font700">Layout plan of land</div>
                                                    <p class="panel-heading font700">Covered Area (In %) :</p>
													<div class="form-group">
														<div class="row">
															<label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Applicant Quote :
															</label>                                                            
                                                            <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																 <asp:Label  ID="txtcoveredarea_lbl" runat="server" />
															</div>
                                                            <div class="clearfix"></div>
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Observer Quote :
															</label>                                                               
                                                            <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																<asp:TextBox ID="txtcoveredarea" Width="93%" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />
													<div class="form-group" style="display:none;">
														<div class="row">
															<label class="col-md-4">
																Open area required and its purpose:
															</label>
															
                                                            <label class="col-md-4 font-bold">
																 <asp:Label  ID="txtopenarearequired_lbl" runat="server" />
															</label>

                                                            
                                                            <div class="col-md-4">
																<asp:TextBox ID="txtopenarearequired" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
                                                    <div class="panel-heading font700">Investment Details (In INR)</div>
                                     
                                          <p class="panel-heading font700">In Plant/Machinery (In Lacs)</p>
										            <div class="form-group">
														<div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Applicant Quote :
															</label> 
															<label class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																 <asp:Label  ID="txtmachinery_lbl" runat="server" />
															</label>
															<div class="clearfix"></div>
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Observer Quote :
															</label> 
                                                            <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																<i class="fa fa-inr"></i><asp:TextBox ID="txtmachinery" Width="93%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
													
                                          
                                    
                                    <div class="hide">           



                                    <p class="panel-heading font700">In Land (In Lacs)</p>
											 
                                    


                                          
                                          <div class="form-group">
														<div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Applicant Quote :
															</label> 
															<label class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																 <asp:Label  ID="txtland_lbl" runat="server" />
															</label>
															<div class="clearfix"></div>
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Observer Quote :
															</label> 
                                                            <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																<i class="fa fa-inr"></i><asp:TextBox ID="txtland" Width="93%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox> 
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />
                                                    <p class="panel-heading font700">In Building (In Lacs)</p>
													<div class="form-group">
														<div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Applicant Quote :
															</label> 
															<label class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																 <asp:Label  ID="txtbuilding_lbl" runat="server" />
															</label>
															<div class="clearfix"></div>
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Observer Quote :
															</label> 
                                                            <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																<i class="fa fa-inr"></i><asp:TextBox ID="txtbuilding" Width="93%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
														</div>
													</div>
													<div class="clearfix"></div>
													<hr class="myhrline" />
                                                   <div class="clearfix"></div>
													<hr class="myhrline" />
                                                    <p class="panel-heading font700">Fixed Assets (In Lacs)</p>
													<div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Applicant Quote :
															</label> 
															<label class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																 <asp:Label  ID="txtFixedAssets_lbl" runat="server" />
															</label>
															<div class="clearfix"></div>
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Observer Quote :
															</label> 
                                                            <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																<i class="fa fa-inr"></i><asp:TextBox ID="txtFixedAssets" Width="93%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox> 
															</div>														    
                                                        </div>
													</div>

													<div class="clearfix"></div>
													<hr class="myhrline" />
                                                    <p class="panel-heading font700">Other Expenses (In Lacs)</p>
													<div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Applicant Quote :
															</label> 
															<label class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																 <asp:Label  ID="txtOtherExpenses_lbl" runat="server" />
															</label>
															<div class="clearfix"></div>
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Observer Quote :
															</label> 
                                                            <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																<i class="fa fa-inr"></i><asp:TextBox ID="txtOtherExpenses" Width="93%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox> 
															</div>
                                                        </div>
													</div>

													<div class="clearfix"></div>
													<hr class="myhrline" />


                                        </div>


													<div class="panel panel-default">

							
														<hr class="myhrline" />
                                                        <div class="panel-heading font700">Net Worth Turnover</div>
                                                        <p class="panel-heading font700">Net Worth (In Lacs)</p>
                                                        <div class="form-group">
															<div class="row">
                                                                <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Applicant Quote :
															</label> 
															<label class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																 <asp:Label  ID="txtNetWorth_lbl" runat="server" />
															</label>
															<div class="clearfix"></div>
                                                            <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																Observer Quote :
															</label> 
                                                            <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																<i class="fa fa-inr"></i><asp:TextBox ID="txtNetWorth" CssClass="input-sm similar-select1" Width="93%" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															</div>
															</div>
														</div>
														<div class="clearfix"></div>
														<hr class="myhrline" />
                                                        <div class="panel-heading font700">Other Relevant Information of Land</div>
                                                        <p class="panel-heading font700">Project Expansion</p>
														<div class="form-group">
															<div class="row">
                                                                <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																    Applicant Quote :
															    </label> 
															    <label class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																     <asp:Label  ID="Ddl_Expansion_lbl" runat="server" />
															    </label>
															    <div class="clearfix"></div>
                                                                <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																    Observer Quote :
															    </label> 
                                                                <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																    <asp:DropDownList runat="server" ID="Ddl_Expansion" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm">
																		<asp:ListItem>--Select--</asp:ListItem>
																		<asp:ListItem Value="Yes">Yes</asp:ListItem>
																		<asp:ListItem Value="No">No</asp:ListItem>
																	</asp:DropDownList>
															    </div>																
															</div>
														</div>



														<div class="clearfix"></div>
														<hr class="myhrline" />
                                                        <p class="panel-heading font700">If Export Oriented</p>
														<div class="form-group">
															<div class="row">
                                                                <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																    Applicant Quote :
															    </label> 
															    <label class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																     <asp:Label  ID="Drop1_lbl" runat="server" />
															    </label>
															    <div class="clearfix"></div>
                                                                <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																    Observer Quote :
															    </label> 
                                                                <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																   <asp:DropDownList runat="server" ID="Drop1" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm">
																		<asp:ListItem>--Select--</asp:ListItem>
																		<asp:ListItem Value="Yes">Yes</asp:ListItem>
																		<asp:ListItem Value="No">No</asp:ListItem>
																	</asp:DropDownList>
															    </div>																
															</div>
														</div>









                                                        
														<div class="clearfix"></div>
														<hr class="myhrline" />
                                                        <p class="panel-heading font700">Priority Category</p>
                                                        <div class="form-group">
															<div class="row">
                                                                <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																    Applicant Quote :
															    </label> 
															    <label class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																<asp:Label  ID="drpPriorityCategory_lbl" runat="server" />
												
                                                                    </label>
															    <div class="clearfix"></div>
                                                                <label class="col-md-6 col-sm-6 col-xs-6 pad-rt0">
																    Observer Quote :
															    </label> 
                                                                <div class="col-md-6 col-sm-6 col-xs-6 pad-lt0">
																   
                                                                <asp:DropDownList runat="server" ID="drpPriorityCategory" AutoPostBack="true" OnSelectedIndexChanged="drpPriorityCategory_SelectedIndexChanged"   CssClass="similar-select1 margin-left-z dropdown-toggle input-sm">
																		<asp:ListItem Value="">--Select--</asp:ListItem>
																		<asp:ListItem Value="YES">Yes</asp:ListItem>
																		<asp:ListItem Value="NO">No</asp:ListItem>
																	</asp:DropDownList>
														
																<asp:DropDownList  Visible="false" runat="server" ID="ddlPriority" EnableViewState="true" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm"></asp:DropDownList>
																	    
                                                                
                                                                </div>
															</div>









														<div class="panel panel-default" style="display:none;">
															<div class="panel-heading" style="display:none;">
																Is the applicant under priority category ? Please specify clearly &nbsp; <span class="checkbox-inline" style="padding-bottom: 20px;">
																	<asp:CheckBox runat="server" ID="chkpriority" AutoPostBack="true"  /></span>
															</div>
															<div id="prioritydiv" class="panel-body" style="padding: 0px !important;" runat="server" visible="false">
																<div class="row aks-row">
																	<div class="col-md-4 col-sm-6 col-xs-12" style="display:none;">
																		Specification&nbsp;:
																	</div>

																	<div class="col-md-4 col-sm-6 col-xs-12" style="display:none;">
																		
																	
																		
																	</div>


																	<div class="col-md-4 col-sm-6 col-xs-12">
																		
																		
																	</div>
																</div>
															</div>
														</div>
														


														<div class="form-group" style="margin-top: 15px;">
															<div class="row">
																<div class="col-md-4 text-center pull-right">
																	<span class="text-center"><a href="#" runat="server" class="btn btn-default" style="padding: 0px 6px;margin:2px 0;" onserverclick="Set_EvaluationCheckListData_ForPacketApplicant">Save &nbsp;<i class="fa fa-long-arrow-right" aria-hidden="true"></i></a></span>
																</div>
																<div class="col-md-4"></div>
															</div>
														</div>
														
								</div>
							</div>
						</div>
				
      </div>