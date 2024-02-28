<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Assesment_Entry_BP.ascx.cs" Inherits="Allotment.UC_Assesment_Entry_BP" %>


<%@ Register assembly="ProudMonkey.Common.Controls" namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %>
	 <cc1:MessageBox ID="MessageBox1" runat="server" /> 

<div class="panel panel-default">
			   <div style="text-align:right;font-weight:bold;" class="panel-heading">
					<span class="">Plot Size :</span>
					<asp:Label ID="lblPlotSize" runat="server" Text="Label" CssClass=""></asp:Label> (In Sqmt)
				</div>
        
            


					<table class="table table-bordered table-hover request-table" id="datatableService" style="width:100%;">
						
							<tr>								
								<th style="width:30%;">Byelaws </th>
								<th style="width:30%;">Applicants Quotes</th>
								<th style="width:40%;">Scrutiny</th>
							</tr>
                    </table>
    <div style="max-height:300px;overflow-y:auto;">
                    <div class="panel-heading">Permissibility</div>
			        <table class="table table-bordered table-hover request-table" style="width:100%;">
                           
							<tr>

							   
								<td style="width:30%;">Use Premises No.48</td>


								<td style="width:30%;"><asp:DropDownList ID="drp_permisesUse" Visible="false" runat="server" Style="width: 100px !important" CssClass="btn btn-default dropdown-toggle input-sm mynewselect">
									</asp:DropDownList>

									<asp:Label ID="drp_permisesUse_lbl" runat="server"></asp:Label>
								</td>


								<td style="width:40%;">
										<asp:DropDownList ID="drp_permissibility" OnSelectedIndexChanged="drp_permissibility_SelectedIndexChanged" AutoPostBack="true" runat="server" Style="width: 100% !important" CssClass="btn btn-default dropdown-toggle input-sm mynewselect">
										<asp:ListItem Text="Use Premises No.43" Value="43" />
										<asp:ListItem Text="Use Premises No.45" Value="45" />
										<asp:ListItem Text="Use Premises No.48" Selected="true" Value="48" />
										</asp:DropDownList>
								</td>

							</tr>
                        </table>
            <div class="panel-heading">FAR(in Percentage)</div>

    <table class="table table-bordered table-hover request-table" style="width:100%">
                            
							
							<tr>
								<td style="width:30%"><asp:Label ID="lblFarByelaws" runat="server"></asp:Label></td>
								<td style="width:30%"><asp:Label ID="txtFar_lbl" runat="server"></asp:Label></td>
								<td style="width:40%"><asp:TextBox ID="txtFar" Style="width: 100% !important" CssClass="input-sm myyellowbgsmall" runat="server"></asp:TextBox></td>
							</tr>
                    </table>
            <div class="panel-heading">Ground Coverage (in Percentage)</div>

    <table class="table table-bordered table-hover request-table" style="width:100%">
                            

							<tr>
								<td style="width:30%"><asp:Label ID="lblGroundBylo" runat="server" Text="Label"></asp:Label></td>
								<td style="width:30%"><asp:Label ID="txtGroundcover_lbl" runat="server"></asp:Label></td>
								<td style="width:40%"><asp:TextBox ID="txtGroundcover" Style="width: 100% !important" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox></td>

							</tr>
        </table>
							
	<div class="panel-heading">Set Back(In mts)</div>
    <div class="panel-heading">front</div>
								
	    <table class="table table-bordered table-hover request-table" style="width:100%">			
							
							<tr>
								<td style="width:30%"><asp:Label ID="lblSetBackFront" runat="server"></asp:Label></td>
								<td style="width:30%"><asp:Label ID="txtSetBackFront_lbl" runat="server"></asp:Label></td>
								<td style="width:40%"><asp:TextBox ID="txtSetBackFront" Style="width: 100% !important" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox></td>
							</tr>

             </table>
							
	
    <div class="panel-heading">Rear</div>
								
	    <table class="table table-bordered table-hover request-table" style="width:100%">
							<tr>
								<td style="width:30%"><asp:Label ID="lblSetBackRear" runat="server" Text="Label"></asp:Label></td>
								<td style="width:30%"><asp:Label ID="txtSetBackRear_lbl" runat="server"></asp:Label></td>
								<td style="width:40%"><asp:TextBox ID="txtSetBackRear" Style="width: 100% !important" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox></td>
							</tr>
             </table>
							
	
    <div class="panel-heading">Side1</div>
								
	    <table class="table table-bordered table-hover request-table" style="width:100%">

							<tr>
								<td style="width:30%"><asp:Label ID="lblSetBackSide1" runat="server" Text="Label"></asp:Label></td>
								<td style="width:30%"><asp:Label ID="txtSetBackSide1_lbl" runat="server"></asp:Label></td>
								<td style="width:40%"><asp:TextBox ID="txtSetBackSide1" Style="width: 100% !important" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox></td>
							</tr>
				
		</table>
							
	
    <div class="panel-heading">Side2</div>
								
	    <table class="table table-bordered table-hover request-table" style="width:100%">					

							<tr>
								<td style="width:30%"><asp:Label ID="lblSetBackSide2" runat="server" Text="Label"></asp:Label></td>
								<td style="width:30%"><asp:Label ID="txtSetBackSide2_lbl" runat="server"></asp:Label></td>
								<td style="width:40%"><asp:TextBox ID="txtSetBackSide2" Style="width: 100% !important" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox></td>
							</tr>
							
		</table>
							
	
    <div class="panel-heading"></div>
								
	    <table class="table table-bordered table-hover request-table" style="width:100%">					
							




							<tr>
								<th colspan="4" style="text-align:left;">Classification of Indiustries Based on Degree of Hazard</th>
							</tr>


							<tr>
								<td>Classification of Hazard</td>
								<td colspan="2">
									<asp:Label ID="ddlNature_lbl" runat="server" />
									<asp:DropDownList ID="ddlNature" runat="server" Visible="false"  CssClass="btn btn-default dropdown-toggle input-sm mynewselect"></asp:DropDownList>                                </td>
								<td> <asp:Label ID="ddlNature_Risklbl" runat="server" /> </td>
							</tr>


							<tr>
								<td>Occupancy</td>
								<td colspan="2"><asp:Label ID="txtOccupancy_lbl" runat="server"></asp:Label></td>
								<td> <asp:Label ID="Occupancy_Risklbl" runat="server" /> </td>
							</tr>



							<tr>
								<td>Height(In mts)</td>
								<td colspan="2"><asp:Label ID="txtHeight_lbl" runat="server"></asp:Label></td>
								<td> <asp:Label ID="Height_Risklbl" runat="server" /> </td>
							</tr>
						



							 <tr>
								<td>Overall Risk</td>
								<td colspan="2"><asp:Label ID="Label1" runat="server"></asp:Label></td>
								
								<td>
									<asp:Label ID="lblRisk"  runat="server" />
								</td>
							</tr>
						




							<tr class="hide">
								<td colspan="4" style="text-align:left;">       
									<asp:Label ID="riskDetail" runat="server"  />
								</td>
							</tr>


					</table>
        


    
    <div class="table-responsive">


					<table class="table table-bordered table-hover request-table hide" id="datatableService1">
							<thead>
								<tr>
									<th style="width:150px">Floors</th>
									<th style="width:100px">Existing </th>
									<th>Proposed</th>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td>BaseMent(in Sqmts)</td>
									<td>
										<asp:TextBox ID="txtBaseMent1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
									</td>
									<td>
										<asp:TextBox ID="txtBaseMent2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>Ground Floor(in Sqmts)</td>
									<td>
										<asp:TextBox ID="txtGround1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
									</td>
									<td>
										<asp:TextBox ID="txtGround2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>First Floor(in Sqmts)</td>
									<td>
										<asp:TextBox ID="txtFirstfloor1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
									</td>
									<td>
										<asp:TextBox ID="txtFirstfloor2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td >Second Floor(in Sqmts)</td>
									<td>
										<asp:TextBox ID="txtSecondFloor1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
									</td>
									<td>
										<asp:TextBox ID="txtSecondFloor2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
									</td>
								</tr>                      
								<tr>
									<td style="text-align:left;">Mezzanine Floor(in Sqmts)</td>
									<td>
										<asp:TextBox ID="txtMezzanine1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
									</td>
									<td>
										<asp:TextBox ID="txtMezzanine2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
									</td>
								</tr>
							</tbody>
						</table>

					<table class="table table-bordered table-hover request-table hide" id="datatableService2" >
							<thead>
								<tr>
									<th style="width:150px"></th>
									<th></th>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td style="text-align:right;">Purpose for which  building Use
									</td>
									<td>
										<asp:TextBox ID="txtbuildingPurpose" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="text-align:left;" colspan="2"><b>Construction Specification</b></td>
								</tr>
								<tr>
									<td style="text-align:right;">Foundation</td>
									<td>
										<asp:TextBox ID="txtFoundation" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="text-align:right;">Walls</td>
									<td>
										<asp:TextBox ID="txtWalls" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
									</td>
								</tr>
								  <tr>
									<td style="text-align:right;">Floors</td>
									<td>
										<asp:TextBox ID="txtFloors" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
									</td>
								</tr>
								 <tr>
									<td style="text-align:right;">Roofs</td>
									<td>
										<asp:TextBox ID="txtRoofs" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="text-align:right;">Number of storeys</td>
									<td>
										<asp:TextBox ID="txtStories" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="text-align:right;">Number of latrines</td>
									<td>
										<asp:TextBox ID="txtLatrines" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="text-align:right;">Any Previous Construction </td>
									<td>
										<asp:TextBox ID="txtPreviousConstruction" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
									</td>
								</tr>
								 <tr>
									<td style="text-align:right;">Source of Water for Building Purpose </td>
									<td>
										<asp:TextBox ID="txtWaterSource" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
									</td>
								</tr>
								</tbody>
							</table>



					<div class="form-group" style="margin-top: 15px;">
						<div class="row">
							<div class="col-md-4 text-center pull-right">
								<span class="text-center"><a href="#" runat="server" class="btn btn-default" style="padding: 0px 6px; margin: 2px 0;" onserverclick="Set_EvaluationCheckListData_ForPacketApplicant">Save &nbsp;<i class="fa fa-long-arrow-right" aria-hidden="true"></i></a></span>
							</div>
							<div class="col-md-4"></div>
						</div>
					</div>



				</div>

    </div>


			   <div class="" id="inspector_div1" runat="server" style="border: 1px solid #ccc;margin-top: 15px;">
						<div class="form-group text-center">
							

							<label class="col-md-12">
										<asp:DropDownList ID="drpInspector" AutoPostBack="true" runat="server" Style="width: 100px !important;margin-top:5px;" CssClass="btn btn-default dropdown-toggle input-sm mynewselect">
										</asp:DropDownList>
							</label>


							<label class="col-md-12">
								 <asp:Button ID="btnInspection" Style="margin-top:5px;" OnClick="InspectorSelecor_Click" runat="server" Text="Initiate Inspection" CssClass="btn-primary ey-bg" />
							</label>


							<div class="col-md-12"  runat="server" id="Div1" Style="margin-top:5px;"> 
								<asp:Label ID="lbl_Inspection" Visible="false" runat="server" Text=''></asp:Label>
                               <div class="table-responsive"
								<asp:GridView ID="GridView2" runat="server"
									CssClass="table table-striped table-bordered table-hover request-table request-table"
									OnRowDataBound="GridView2_RowDataBound"
									OnRowCommand="GridView2_RowCommand"
									AutoGenerateColumns="False"
									DataKeyNames="ServiceRequestNO"
									GridLines="Horizontal"
									Width="100%">
									<Columns>

										<asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
										<asp:BoundField DataField="IndustrialArea" ItemStyle-HorizontalAlign="Justify" HeaderText="Industrial Area" SortExpression="ServiceRequestActivity" />
										<asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="ApplicationType" />
										<asp:BoundField DataField="EMPLOYEENAME" HeaderText="Inspector" SortExpression="ApplicationType" />
										<asp:BoundField DataField="Remark" HeaderText="Remark" ItemStyle-Wrap="true" ItemStyle-Width="200px" SortExpression="CaseType" />

										<asp:TemplateField HeaderText="Inspection Report">
											<ItemTemplate>
												<asp:Label ID="file_name" Text='<%# Eval("ColName") %>' runat="server" Visible="false" />
												<asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" Text='<i class="fa fa-download" aria-hidden="true"></i>' />
											</ItemTemplate>
										</asp:TemplateField>

									</Columns>
									<EmptyDataTemplate>
										No Record Available
									</EmptyDataTemplate>
									<FooterStyle BackColor="White" ForeColor="#000066" />
									<HeaderStyle Font-Bold="True" ForeColor="Black" />
									<PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
									<RowStyle ForeColor="#000066" />
									<SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
									<SortedAscendingCellStyle BackColor="#F1F1F1" />
									<SortedAscendingHeaderStyle BackColor="#007DBB" />
									<SortedDescendingCellStyle BackColor="#CAC9C9" />
									<SortedDescendingHeaderStyle BackColor="#00547E" />
								</asp:GridView>

                                </div>

							</div>
							
					<div class="clearfix"></div>
				 
					</div> 

</div>
	  </div>