<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Service_Approval.ascx.cs" Inherits="Allotment.UC_Service_Approval" %>


<span class="hide">
<hr />
<div class="row " style="border: 3px solid #c5c506;">
	<div class="col-md-8" >
	<div class="col-left-Service">
		<div class="tab-content clearfix">
			<div class="tab-pane active" id="divoperational">
					<div class="form-group">
						<div class="row">

							<div class="col-md-8" style="border-right: 1px solid #ccc">
								<asp:Label ID="lblServiceID" runat="server" CssClass="my12font">ServiceID</asp:Label>
								<asp:Label ID="lblChecklistID" runat="server" CssClass="my12font">ChecklistID</asp:Label>
								<asp:Label ID="lblPlotsize" runat="server" CssClass="my12font">Plotsize</asp:Label>
								<div class="row" style="margin-top: 28px;">
									<label class="col-md-2 font-bold">
										Operations:
									</label>

									<div class="col-md-10">
										<asp:DropDownList ID="drpOperations" class="input-sm similar-select1" runat="server">
											<asp:ListItem Text="Forward To Division Manager" /> 
											<asp:ListItem Text="Forward To Assistant Manager" /> 
											 <asp:ListItem Text="Approved" /> 
											 <asp:ListItem Text="Rejected" /> 
											 <asp:ListItem Text="Clearification Short From Applicant" /> 
										</asp:DropDownList>
									</div>
								</div>
								<div class="clearfix"></div>
								<hr class="myhrline" />
							</div>
							<div class="col-md-4" style="">
								<div class="panel panel-default">
									<div class="chair-heading-bot font-bold">
										Notesheet Settings
									</div>
									<div class="form-group">
										<div class="row">
											<label class="col-md-6 text-right font-bold">
												Annex Document:
											</label>
											<div class="col-md-6">
												<asp:DropDownList ID="DropDownList1" class="input-sm similar-select1" runat="server"></asp:DropDownList>
											</div>
										</div>
									</div>
									<div class="clearfix"></div>
									<hr class="myhrline" />
									<asp:Button ID="btnCurrentStatus" CssClass ="btn btn-sm btn-primary text-right btn-bpservice" runat="server" Text="Current Status"/>
									<asp:Button ID="btnNotesheet" CssClass ="btn btn-sm btn-primary text-right btn-bpservice" runat="server" Text="Notesheet"/>
								</div>
							</div>
						</div>
					</div>
				<div class="form-group">
					<div class="row">
						<label class="col-md-12 font-bold" >
							Notings/Findings:
						</label>
						<div class="col-md-12">
							<asp:TextBox ID="txtNotesheet" runat="server" CssClass="input-sm similar-select1 margin-left-z multi-bg" style="height:120px;" TextMode="MultiLine"></asp:TextBox>
						</div>
						<div class="col-md-12">
							<asp:Button ID="btnOperaSave" CssClass ="btn btn-sm btn-primary text-right btn-bpservice pull-right" runat="server" Text="Save"/>
						</div>
					</div>
				</div>
				<div class="clearfix"></div>
				<hr class="myhrline" />
			</div>
			<div class="tab-pane" id="divvalidation">
				<asp:TextBox ID="txtValidate" runat="server" CssClass="input-sm similar-select1 margin-left-z multi-bg" style="height:232px;" TextMode="MultiLine"></asp:TextBox>
				<asp:Button ID="btnvalidate" CssClass ="btn btn-sm btn-primary text-right btn-bpservice pull-right" runat="server" Text="Validate" style="margin-left:3px;"/>
				<asp:Button ID="btnclear" CssClass ="btn btn-sm btn-primary text-right btn-bpservice pull-right" runat="server" Text="Clear"/>
			</div>
			<div class="tab-pane" id="divregulations">
				<asp:TextBox ID="TextBox1" runat="server" CssClass="input-sm similar-select1 margin-left-z multi-bg" style="height:232px;" TextMode="MultiLine"></asp:TextBox>
			</div>
			<div class="tab-pane" id="divsectionrecommendation">
				<div class="form-group">
						<div class="row">
							<div class="col-md-12" style="border-right: 1px solid #ccc">
								<asp:Label ID="lblRecommendServiceID" runat="server" CssClass="my12font">ServiceID</asp:Label>
								<asp:Label ID="lblRecommendChecklistID" runat="server" CssClass="my12font">ChecklistID</asp:Label>
								<asp:Label ID="lblRecommendPlotsize" runat="server" CssClass="my12font">Plotsize</asp:Label>
								<div class="row" style="margin-top: 28px;">
									<label class="col-md-3 font-bold">
										Seek Additional Information:
									</label>
									<div class="col-md-9">
										<asp:DropDownList ID="drpSeekUnit" class="input-sm similar-select1" runat="server"></asp:DropDownList>
									</div>
								</div>
								<div class="clearfix"></div>
								<hr class="myhrline" />
							</div>
							<!--<div class="col-md-4" style="">
								<div class="panel panel-default">
									<div class="chair-heading-bot font-bold">
										Notesheet Settings
									</div>
									<div class="form-group">
										<div class="row">
											<label class="col-md-6 text-right font-bold">
												Annex Document:
											</label>
											<div class="col-md-6">
												<asp:DropDownList ID="DropDownList3" class="input-sm similar-select1" runat="server"></asp:DropDownList>
											</div>
										</div>
									</div>
									<div class="clearfix"></div>
									<hr class="myhrline" />
									<asp:Button ID="Button1" CssClass ="btn btn-sm btn-primary text-right btn-bpservice" runat="server" Text="Current Status"/>
									<asp:Button ID="Button2" CssClass ="btn btn-sm btn-primary text-right btn-bpservice" runat="server" Text="Notesheet"/>
								</div>
							</div>-->       
						</div>
					</div>
				<div class="form-group">
					<div class="row">
						<label class="col-md-12 font-bold" >
							Request
						</label>
						<div class="col-md-12">
							<asp:TextBox ID="txtRecommendRequest" runat="server" CssClass="input-sm similar-select1 margin-left-z multi-bg" style="height:130px;" TextMode="MultiLine"></asp:TextBox>
						</div>
						<div class="col-md-12">
							<asp:Button ID="btnSave" CssClass ="btn btn-sm btn-primary text-right btn-bpservice pull-right" runat="server" Text="Save"/>
						</div>
					</div>
				</div>
				<div class="clearfix"></div>
			</div>
			<div class="tab-pane" id="divcurrentstatus">
				
			</div>
		</div>
		<div class="clearfix"></div>
		
		<div class="col-md-12 col-sm-12 col-xs-12"> 
		<!--<asp:Menu id="Menu1" Orientation="Horizontal" CssClass="selected highlighted" StaticMenuStyle-CssClass="nav nav-pills myul-tabs" StaticSelectedStyle-CssClass="active selected highlighted" Runat="server">
	 <Items>
	 <asp:MenuItem Text="Operational" Value="0" NavigateUrl="#1a"/>
	 <asp:MenuItem Text="Validations" Value="1"  NavigateUrl="#2a" />
	 <asp:MenuItem Text="Regulations" Value="2"  NavigateUrl="#3a"/>
	 <asp:MenuItem Text="Section Recommendation" />
	 </Items>    
 </asp:Menu>-->
		 
						<ul class="nav nav-pills myul-tabs">
								<li><a  href="#divoperational" data-toggle="tab" class="font-bold active">Operational</a></li>
								<li><a href="#divvalidation" data-toggle="tab" class="font-bold">Validations</a></li>
								<li><a href="#divregulations" data-toggle="tab" class="font-bold">Regulations</a></li>
								<li><a href="#divsectionrecommendation" data-toggle="tab" class="font-bold">Section Recommendation</a></li>
								<!--<li><a href="#divcurrentstatus" data-toggle="tab" class="font-bold">Current Status</a></li>-->
						</ul>
						
					</div>                    
					
						
					</div>
	</div>
	
	<div class="col-md-4" style="border-left: 1px solid #ccc">
		<div class="panel panel-default">
			<div class="chair-heading-bot font-bold" id="chairman">Chairman</div>
			<div class="form-group">
				<div class="row">
					<label class="col-md-4 text-right font-bold">
						Regional Manager:
					</label>
					<div class="col-md-8">
						<asp:DropDownList ID="drpChairman" class="input-sm similar-select1" runat="server"></asp:DropDownList>
					</div>
				</div>
			</div>
			<div class="clearfix"></div>
			<hr class="myhrline" />
			<div class="clearfix"></div>
			<div class="chair-heading-bot font-bold">Recommending Committee</div>
			<div class="form-group">
				<div class="row">
					<label class="col-md-4 text-right font-bold">
						Executive  Engineer:
					</label>
					<div class="col-md-8">
						<asp:DropDownList ID="drpExecutiveEngineer" class="input-sm similar-select1" runat="server"></asp:DropDownList>
					</div>
				</div>
			</div>
			<div class="clearfix"></div>
			<hr class="myhrline" />
			<div class="form-group">
				<div class="row">
					<label class="col-md-4 text-right font-bold">
						Dy. Manager:
					</label>
					<div class="col-md-8">
						<asp:DropDownList ID="drpDyManager" class="input-sm similar-select1" runat="server"></asp:DropDownList>
					</div>
				</div>
			</div>
			<div class="clearfix"></div>
			<hr class="myhrline" />
			<div class="form-group">
				<div class="row">
					<label class="col-md-4 text-right font-bold">
						Dy. Manager(A/C):
					</label>
					<div class="col-md-8">
						<asp:DropDownList ID="drpDyManagerAC" class="input-sm similar-select1" runat="server"></asp:DropDownList>
					</div>
				</div>
			</div>
			<div class="clearfix"></div>
			<hr class="myhrline" />
			<div class="form-group">
				<div class="row">
					<label class="col-md-4 text-right font-bold">
						Asst. Manager(A/C):
					</label>
					<div class="col-md-8">
						<asp:DropDownList ID="drpAssistantManagerAC" class="input-sm similar-select1" runat="server"></asp:DropDownList>
					</div>
				</div>
			</div>
			<div class="clearfix"></div>
			<hr class="myhrline" />
		</div>
		<!--<hr style="border-top: 1px solid #929090;border-bottom: 1px solid #fff;margin-top: 12px;"/>-->
		<div class="panel panel-default">
			<div class="chair-heading-bot font-bold">Regional Office operators</div>
		</div>
		<div class="form-group">
			<div class="row">
				<label class="col-md-4 text-right font-bold">
					Approver:
				</label>
				<div class="col-md-8">
					<asp:DropDownList ID="drpApprover" class="input-sm similar-select1" runat="server"></asp:DropDownList>
				</div>
			</div>
		</div>
		<div class="clearfix"></div>
		<hr class="myhrline" />
		<div class="form-group">
			<div class="row">
				<label class="col-md-4 text-right font-bold">
					Reviewer:
				</label>
				<div class="col-md-8">
					<asp:DropDownList ID="drpReviewer" class="input-sm similar-select1" runat="server"></asp:DropDownList>
				</div>
			</div>
		</div>
		<div class="clearfix"></div>
		<hr class="myhrline" />
		<div class="form-group">
			<div class="row">
				<label class="col-md-4 text-right font-bold">
					Verifier:
				</label>
				<div class="col-md-8">
					<asp:DropDownList ID="drpVerifier" class="input-sm similar-select1" runat="server"></asp:DropDownList>
				</div>
			</div>
		</div>
		<div class="clearfix"></div>
		<hr class="myhrline" />
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div style="" class="panel-heading" data-toggle="collapse" data-target="#bp-divtabs">Current Status <span class="pull-right"><span class="glyphicon glyphicon-plus"></span></span></div>
		<div class="col-md-12 col-sm-12 col-xs-12 collapse" id="bp-divtabs">
			<div class="">
				  <div style="padding:0;background:#fff;margin-top:20px;" class="table-responsive">
					<div style="overflow-x:scroll;margin-left:10.7em;">
								  <table class="table table-bordered table-hover request-table my-dash-table-status">
									  <tr>
										<th></th>
										<th colspan="3">Regional Office operators</th>
										<th colspan="5">Recommendations</th>
									</tr>
									<tr>
										<th></th>
										<th class="my-heading font-bold">Verifier</th>
										<th class="my-heading font-bold">Reviewer</th>
										<th class="my-heading font-bold">Approver</th>
										<th class="my-heading font-bold">Asst. Manager(A/C)</th>
										<th class="my-heading font-bold">Dy. Manager(A/C)</th>
										<th class="my-heading font-bold">Dy. Manager</th>
										<th class="my-heading font-bold">Executive Engineer</th>
										<th class="my-heading font-bold">Regional Manager</th>
									</tr>
									<tr>
										<td>Checklist1</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
									</tr>
									<tr>
										<td>Checklist2</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
									</tr>
									<tr>
										<td>Checklist3</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
									</tr>
									<tr>
										<td>Checklist4</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										
									</tr>
									<tr>
										<td>Checklist5</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
										<td><div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div><br /><span class="verified-span">Verified</span><br />Elapsed Time: 00:51:00</td>
									</tr>
								</table>
							</div>
						</div>
					</div>
			
		</div>
		
		<div class="panel-heading" style="margin-top:15px;" data-toggle="collapse" data-target="#bp-divtabs-notesheet">Notesheet <span class="pull-right"><span class="glyphicon glyphicon-plus"></span></span></div>
		<div class="col-md-12 col-sm-12 col-xs-12 collapse" id="bp-divtabs-notesheet">
			wefrfrr
		</div>
	</div>
</div>



<hr /><br /><br />

 </span>