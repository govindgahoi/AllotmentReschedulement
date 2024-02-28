<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_MarkingsVerification.ascx.cs" Inherits="Allotment.UC_MarkingsVerification" %>
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
                                    <div class="table-responsive">
                                         <table class="request-table" style="width:100%;">
                                             <tr>
                                                 <th>Objective Criteria</th>
                                                 <th>By Applicant</th>
                                                 <th>By Verifier</th>
                                             </tr>
                                             <tr>
                                                 <td>Employment (In Numbers)</td>
                                                 <td> <asp:Label  ID="txtestimatedemployment_lbl" runat="server" /></td>
                                                 <td><asp:TextBox ID="txtestimatedemployment" Width="100%" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                             </tr>
                                             <tr>
                                                 <td>Work Experience (In Months)</td>
                                                 <td> <asp:Label  ID="txtWorkExperience_lbl" runat="server" /></td>
                                                 <td><asp:TextBox ID="txtWorkExperience" runat="server" CssClass="input-sm similar-select1" Width="100%" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                             </tr>
                                             <tr>
                                                 <td>Start Period (In Months)</td>
                                                 <td><asp:Label  ID="txtProjectStartMonths_lbl" runat="server" /></td>
                                                 <td><asp:TextBox ID="txtProjectStartMonths" Width="100%" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                             </tr>
                                             <tr>
                                                 <td>Covered Area (In %)</td>
                                                 <td><asp:Label  ID="txtcoveredarea_lbl" runat="server" /></td>
                                                 <td><asp:TextBox ID="txtcoveredarea" Width="100%" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                             </tr>
                                             <tr>
                                                 <td>In Machinery (In Lacs)</td>
                                                 <td><asp:Label  ID="txtmachinery_lbl" runat="server" /></td>
                                                 <td><i class="fa fa-inr"></i><asp:TextBox ID="txtmachinery" Width="93%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                             </tr>
                                             <tr>
                                                 <td>In Plant or Building (In Lacs)</td>
                                                 <td><asp:Label  ID="txtbuilding_lbl" runat="server" /></td>
                                                 <td><i class="fa fa-inr"></i><asp:TextBox ID="txtbuilding" Width="93%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                             </tr>
                                              <tr>
                                                 <td>In Land (In Lacs)</td>
                                                 <td><asp:Label  ID="lblLand" runat="server" /></td>
                                                 <td><i class="fa fa-inr"></i><asp:TextBox ID="txtLand" Width="93%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                             </tr>
                                             <tr>
                                                 <td>Net Worth (In Lacs)</td>
                                                 <td><asp:Label  ID="txtNetWorth_lbl" runat="server" /></td>
                                                 <td><i class="fa fa-inr"></i><asp:TextBox ID="txtNetWorth" CssClass="input-sm similar-select1" Width="93%" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                             </tr>
                                             <tr>
                                                 <td>Project Expansion</td>
                                                 <td><asp:Label  ID="Ddl_Expansion_lbl" runat="server" /></td>
                                                 <td>
                                                     <asp:DropDownList runat="server" ID="Ddl_Expansion" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm">
														<asp:ListItem>--Select--</asp:ListItem>
														<asp:ListItem Value="Yes">Yes</asp:ListItem>
														<asp:ListItem Value="No">No</asp:ListItem>
													</asp:DropDownList>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>If Export Oriented</td>
                                                 <td><asp:Label  ID="Drop1_lbl" runat="server" /></td>
                                                 <td>
                                                     <asp:DropDownList runat="server" ID="Drop1" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm">
														<asp:ListItem>--Select--</asp:ListItem>
														<asp:ListItem Value="Yes">Yes</asp:ListItem>
														<asp:ListItem Value="No">No</asp:ListItem>
													</asp:DropDownList>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>Priority Category</td>
                                                 <td><asp:Label  ID="drpPriorityCategory_lbl" runat="server" /></td>
                                                 <td>
                                                    <asp:DropDownList runat="server" ID="drpPriorityCategory" AutoPostBack="true" OnSelectedIndexChanged="drpPriorityCategory_SelectedIndexChanged"   CssClass="similar-select1 margin-left-z dropdown-toggle input-sm">
														<asp:ListItem Value="">--Select--</asp:ListItem>
														<asp:ListItem Value="YES">Yes</asp:ListItem>
														<asp:ListItem Value="NO">No</asp:ListItem>
													</asp:DropDownList>
														
												<asp:DropDownList  Visible="false" runat="server" ID="ddlPriority" EnableViewState="true" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm"></asp:DropDownList>
																
                                                 </td>
                                             </tr>
                                         </table>
                                    </div>
                                   

                                                
									
                       
											 
                                    
                                    <div class="hide">           



                                  
													<hr class="myhrline" />
                                                    <p class="panel-heading font700">In Building (In Lacs)</p>
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
																<i class="fa fa-inr"></i><asp:TextBox ID="txtbuildingg" Width="93%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
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
															<div class="">
																<div class="col-md-4 text-center pull-right">
																	<span class="text-center"><a href="#" runat="server" class="btn-primary pull-right btn-sm" style="padding:5px 13px;" onserverclick="Set_EvaluationCheckListData_ForPacketApplicant">Save &nbsp;<i class="fa fa-long-arrow-right" aria-hidden="true" style="color:#fff;"></i></a></span>
																</div>
																<div class="col-md-4"></div>
															</div>
														</div>
														
								</div>
							</div>
						</div>
				
      </div>