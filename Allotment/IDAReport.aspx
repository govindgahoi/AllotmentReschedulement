<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IDAReport.aspx.cs" Inherits="Allotment.IDAReport" %>


<!DOCTYPE html>
<html>
<head runat="server">
	<title>Uttar Pradesh Chief Minister Office, Lucknow</title>
	<link rel="stylesheet" href="/cmo/css/bootstrap-theme.css">
	<link rel="stylesheet" href="/cmo/css/bootstrap.css">
	<link rel="stylesheet" href="/cmo/css/IDADashboard.css">
	<link rel="stylesheet" href="/cmo/css/menu.css">
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

	<script type="text/javascript" src="js/bootstrap.js"></script>


	<script type="text/javascript" src="/js/loader.js"></script>
	<script type="text/javascript" src="/js/highcharts.js"></script>
	<script type="text/javascript" src="/js/data.js"></script>
	<script type="text/javascript" src="/js/drilldown.js"></script>
    <script src="js/ajax-jquery-min.js"></script>
    <script src="js/jquery-1.11.3.min.js"></script>

	 <style>
	     @media only screen and (min-width: 768px) {
	         .icon-right-head {
	            float:right;
             }
         }
         @media only screen and (max-width: 768px) {
	         .icon-right-head {
	            margin-top:5px;
             }
         }
      
	     .icon-right-head {
	        margin-bottom:0;
         }
	         .icon-right-head li {
	            vertical-align:middle;
             }
	             .icon-right-head li i {
	                color:#000;
                 }
	             .icon-right-head li i.fa-file-pdf-o {
	                color:red;
                 }
		 .request-table-margetop {
	        margin-top:5px;
        }
	    .request-table-col tr th {
	        background-color: #ffe600;
           
        }
	    .tr-total td{
	        color:#000;
        }
	    .request-table-col tr:hover th {
	        color:#000;
        }
	    tr.cm-table-heading {
	        background-color: #2d2d2d;
        }
        tr.cm-table-heading:hover {
	        background-color: #2d2d2d;
        }
	        tr.cm-table-heading th {
	            color: #ffffff !important;
                
            }
	    .cmtable-bg tr td{
	        background:#e0e0e0;
            
        }
	    .cmtable-bg tr th {
	        background-color: #ffe600;
            font-weight:700;
            
        } 
		.border_none > tbody > tr > td {
			border: 1px solid #dddddd08;
		}

		.border_none > tbody > tr > th {
			border: 1px solid #dddddd08;
		}

		.border_none {
			border: 1px solid #dddddd08;
		}


		.tr-upsidc {
			background-color: #368EE0;
		}

			.tr-upsidc td {
				color: #fff;
			}

		.tr-gnida {
			background-color: #00ABA9;
		}

			.tr-gnida td {
				color: #fff;
			}

		.tr-noida {
			background-color: #F8A31F;
		}

			.tr-noida td {
				color: #fff;
			}

		.tr-yeida {
			background-color: #E671B8;
		}

			.tr-yeida td {
				color: #fff;
			}

		.tr-total {
			background-color: #e0e0e0;

		}

			
		.guage-land-div {
			color: #fff;
			padding: 5px 12px 12px 12px;
			margin: 14px 0;
			border-radius: 5px;
		}

			.guage-land-div p {
				font-size: 12px;
				margin: 4px 0 0 0;
			}

			.guage-land-div .guage-heading {
				font-size: 27px;
				margin-bottom: 6px;
			}

		#Allottee_master_grid tr th {
			text-align: center;
			font-size: 13px;
			color: #000;
			font-weight: 600;
		}

		#Allottee_master_grid tr td {
			font-size: 13px;
		}

		.mainbg-div {
			position: relative;
		}

		#GUAGE_UPSIDC {
			position: relative;
			z-index: 1;
		}

		#GUAGE_NOIDA {
			position: relative;
			z-index: 1;
		}

		#GUAGE_GNIDA {
			position: relative;
			z-index: 1;
		}

		#GUAGE_YAMUNA {
			position: relative;
			z-index: 1;
		}

		.bg-div {
			position: absolute;
			z-index: 999;
			width: 100%;
			height: 200px;
			top: 0;
			background: #cccccc40;
		}

		.request-table tr a:before {
			text-align: center !important;
			margin: 0px 14px;
		}
	    .request-table {
	        margin-top:10px;
        }
		.request-table tr th a {
			color: #2d2d2d;
		}

		.request-table tr th {
			font-size: 13px;
			font-weight: 500;
		}

		.request-table tr th {
			color: #2d2d2d;
			font-weight: 600;
		}

		.request-cell-width tr th {
			color: #000;
		}

		.request-cell-width1 tr th {
			color: #459bc5;
		}

		.request-table tr th {
			padding: 0 6px !important;
		}

		.request-table tr td {
			font-size: 12px;
			/*color: #2d2d2d;*/
			text-align: left;
			padding: 1px 6px !important;
		}

		.request-table-col tr td {
		/* color: #fff; */	
			
            

		}
	    .request-table-col tr td {
	        
        }

		.request-table-col tr:hover td {
			color: #000;
		}

		.nav > li > a:hover {
			color: #000;
		}

		.request-table tr a:before {
			color: #000;
		}

		.request-table {
			margin-top: 0 !important;
			margin-bottom: 2px;
		}

			.request-table tr th {
				vertical-align: middle !important;
				font-size: 12px;
			}

			.request-table tr td {
				vertical-align: middle !important;
				font-size: 12px;
			}

		.request-cell-width .font-bold {
			width: 300px;
		}

		.font-bold {
			font-weight: 600;
			font-size: 12px !important;
			padding-top: 2px;
		}

		.request-cell-width1 .font-bold {
			width: 300px;
		}

		.request-cell-width tr {
			border-bottom: 1px solid #ccc;
		}



			.request-cell-width tr td {
				/*border-bottom: 1px solid #949090 !important;*/
			}

		.request-cell-width1 tr td {
			/*border-bottom: 1px solid #949090 !important;*/
		}

		.myreq-col tr td {
			font-size: 10px;
			color: #2d2d2d;
			border: 1px solid #fff !important;
			text-align: left;
			background: #e0e0e0;
			padding: 1px 6px !important;
			font-weight: bold;
		}

		.myreq-col tr th {
			font-size: 10px;
		}

		.myreq-col tr td a {
			color: #337ab7;
			font-weight: bold;
		}
	   
	   
		
	</style>
   

</head>

<body>
    

	<form id="form1" runat="server">

<%--	<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
	</asp:ScriptManager>

	
 
	<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always"  >

	

   <ContentTemplate>
		<asp:UpdateProgress ID="UpdWaitImage" runat="server"  DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
				 <ProgressTemplate>
				 <div class="fgh">
				 <div class="hgf">
								<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>   
							   </div>
							   </div>
	   </ProgressTemplate>
	   </asp:UpdateProgress>--%>
		





		<div class="container-fluid bg_header">
			<div class="container flag ">
				<div class="row">
				</div>
			</div>
		</div>

		<div class="container page">
			<!--header-->
			<div class="row" style="background-image: url(/cmo/images/bg.png);">

				<div class="col-md-1 col-sm-2 col-xs-12">
					<div class="logoforest text-center">
						<a title="Uttar Pradesh Chief minister office Lucknow">
							<img alt="Uttar Pradesh Chief minister office Lucknow" src="/cmo/images/logo_up.png" style="border-width: 0px;"></a>
					</div>
				</div>

				<div class="col-md-7 col-sm-10 col-xs-12">
					<div class="Dep-title">
						<h1 style="color: #CC3300" class="Dep-titleh1">Uttar Pradesh Chief Minister Office, Lucknow</h1>
						<h2 class="Dep-titleh2">Government of Uttar Pradesh, India
						</h2>
					</div>
				</div>

				<div class="col-md-4">
					<div class="logoup">
					<%--	<button onclick="document.getElementById('id01').style.display='block'" type="button" class="btn btn-warning loginbtn11"><i class="fa fa-sign-in fa-fw fa-fw"></i>Login</button>
					--%>   
						<a href="IDADashboard.aspx"><button  type="button" class="btn btn-warning loginbtn11"><i class="fa fa-sign-in fa-fw fa-fw"></i>Dashboard</button></a>

				  

						<!-- The Modal -->
						<div id="id01" class="modal">
							<span onclick="document.getElementById('id01').style.display='none'"
								class="close" title="Close Modal">&times;</span>

							<!-- Modal Content -->
							<div class="modal-content animate">
								<div class="imgcontainer">
								</div>

								<div class="col-md-12" style="background: #fff;">
									<label><b>Username</b></label>
									<asp:TextBox ID="txtUserName" runat="server" ToolTip="UserName" placeholder="UserName"></asp:TextBox>

									<label><b>Password</b></label>

									<asp:TextBox ID="txtPwd" runat="server" ToolTip="Password" type="password" placeholder="Password"></asp:TextBox>
									<asp:Button ID="btnLogin" runat="server" class="btn btn-primary ey-bg" Style="" Text="Login" OnClick="btnLogin_Click" OnClientClick="javascript:return ChkValidVal();" />
									<asp:HyperLink ID="lnkforgetPwd" runat="server">Forgot Password</asp:HyperLink>

								</div>

								<div class="col-md-12r" style="background-color: #f1f1f1">
									<asp:Label ID="lblMessage" runat="server" ForeColor="#FC590A"></asp:Label>

								</div>
							</div>
						</div>
					</div>
				</div>

			</div>
			<!--end header-->










			<!-- menu section start-->
			<div style="margin: 0px; padding: 0px;">

				<div class="container-fluid serchbardiv">
					<div class="col-md-6">
						<div class="col-md-3 padding-off">
							<span>
								<h6 style="color: #ffffff; font-size: 13px; margin-top: 15px !important; font-weight: 600">Apply Your Filters: </h6>
							</span>
						</div>
						<div class="col-md-9 padding-off ">
							<section>
								<div class="search" method="post" action="index.html">
									<input type="text" name="q" placeholder="Search for UPSIDC,GNIDA,NODIA,YEIDA" />
									<ul class="results">

										<li><a href="#"><span>UPSIDC</span></a></li>
										<li><a href="#"><span>Greater Noida</span></a></li>
										<li><a href="#"><span>NODIA</span></a></li>
										<li><a href="#"><span>YEIDA</span></a></li>
									</ul>
								</div>
							</section>
						</div>
					</div>

					<div class="col-md-6">
						<nav class="navbar  nav_menuback">
							<div class="container-fluid">
								<div class="navbar-header">
								</div>
								<ul class="nav navbar-nav">
									<li><a href="#"><i class="fa fa-refresh fa-fw"></i>Reset</a></li>
									<li><a href="#"><i class="fa fa-share-alt fa-fw"></i>Share</a></li>
									<li><a href="#" onclick="PrintElem()"><i class="fa fa-file-pdf-o fa-fw"></i>PDF</a></li>
									<li><a href="#" id="btnExport"><i class="fa fa-file-excel-o fa-fw"></i>Excel</a></li>


								</ul>
							</div>
						</nav>
					</div>

				</div>
				<div class="clearfix"></div>
				<div class="" style="margin-bottom: 0;">
					<div class="text-center">
						<h6 class="font_o" style="background: #713800; color: #fff; padding: 10px 0; margin: 0;">
							<span id="ctl00_ctl00_ContentPlaceHolder1_lblTitle font-bold text-center" style="font-size: 20px;"><b>Dashboard: Industrial Development Corporation/Authority <span style="font-size: 16px;">(For Testing Purpose Only)</span></b> </span></h6>
					
                    </div>
				</div>
				<div class="clearfix"></div>
			</div>
			<!-- end menu section-->

			<!-- middle page content section-->


			<div id="wrapper">
				<!-- Navigation -->
				<div id="page-wrapper" style="">



					<div class="row">
						<div class="">
							<div class="panel panel-default" style="border-color: transparent; border: 0px solid transparent; margin-bottom: 0;">









								<div class="col-md-12 col-sm-12 col-xs-12">
									<div class="">



                <div class="text-center" style="border: 1px solid #ccc; margin: 5px 0;padding: 9px 0 0 10px;">
                    <p style="color:red;font-size:12px;"><strong>*Disclaimer:</strong> The data and representations are only for testing purpose.</p>
                </div>
				<div class="" style="border: 1px solid #ccc;background: #e6e6e6;margin: 5px 0;padding: 5px 0 0 0;">
					<div class="form-group">
                        <label class="col-md-2 col-sm-3 col-xs-6" style="margin-bottom:3px;">
                            Corporation/Authority:
                        </label>
                        <div class="col-md-2 col-sm-3 col-xs-6" style="margin-bottom:3px;">
	                         <asp:DropDownList ID="ddlAuthority" runat="server" OnSelectedIndexChanged="ddlAuthority_SelectedIndexChanged" AutoPostBack="true" CssClass="input-sm dropdown-toggle similar-select1" Width="100%"></asp:DropDownList>
			            </div>
                        <label class="col-md-2 col-sm-3 col-xs-6" style="margin-bottom:3px;">
                            Region/Office/Sectors:
                        </label>
                        <div class="col-md-2 col-sm-3 col-xs-6" style="margin-bottom:3px;">
							<asp:DropDownList ID="dlregion" runat="server" CssClass="input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="dlregion_SelectedIndexChanged" Width="100%"></asp:DropDownList>
						</div>
                        <label class="col-md-2 col-sm-3 col-xs-6" style="margin-bottom:3px;">
                            Industrial Area:
                        </label>
                        <div class="col-md-2 col-sm-3 col-xs-6" style="margin-bottom:3px;">
							<asp:DropDownList ID="IaDdl" runat="server" CssClass="input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="IaDdl_SelectedIndexChanged" Width="100%"></asp:DropDownList>
						</div>
                        <label class="col-md-2 col-sm-3 col-xs-6" style="margin-bottom:3px;">
                            Report Type:
                        </label>
                        <div class="col-md-2 col-sm-3 col-xs-6" style="margin-bottom:3px;">
							<asp:DropDownList ID="ReportType" runat="server" Width="100%"   OnSelectedIndexChanged="ReportType_SelectedIndexChanged"   AutoPostBack="true" CssClass="input-sm dropdown-toggle similar-select1">
											
								<asp:ListItem Text="Vacant or Unallotted Plots" Value="Vacant_or_Unallotted_Plots" />
								<asp:ListItem Text="Production not started" Value="Production_not_started" />
								<asp:ListItem Text="Sick Unit / Production stopped" Value="Sick_Unit" />
								<%--<asp:ListItem Text="new Upcoming Industrial Area" Value="new_Upcoming_Industrial_Area" />
								--%>
							</asp:DropDownList>
						</div>
                        <label class="col-md-2 col-sm-3 col-xs-6" style="margin-bottom:3px;">
                            Filter:
                        </label>
                        <div class="col-md-2 col-sm-3 col-xs-6" style="margin-bottom:3px;">
							<%--OnSelectedIndexChanged="ddlAuthority1_SelectedIndexChanged"--%>

							<asp:DropDownList ID="drlPreConditionType" runat="server" Width="100%"  OnSelectedIndexChanged="drlPreConditionType_SelectedIndexChanged"   AutoPostBack="true" CssClass="input-sm dropdown-toggle similar-select1">
											
								<asp:ListItem Text="No Area Filter" Value="" />
								<asp:ListItem Text="Area less then equel to" Value="AREA_LE" />
								<asp:ListItem Text="Area greater then equel to" Value="AREA_GE" />
							</asp:DropDownList>
						</div>
                        <label class="col-md-2 col-sm-3 col-xs-6" style="margin-bottom:3px;">
                            Value:
                        </label>
                        <div class="col-md-2 col-sm-3 col-xs-6" style="margin-bottom:3px;">
						    <asp:TextBox runat="server" ID="txtPreConditionVal" Width="100%"  TextMode="Number" OnTextChanged="txtPreConditionVal_changed" AutoPostBack="true" placeholder="Value"></asp:TextBox> 
						</div>
					</div>
                    	
        <div class="clearfix"></div>
	</div>





										
										<div class="clearfix"></div>

										<span class="hide">
                                            <hr style="margin-top: 6px; margin-bottom: 6px; border: 0; border-top: 2px solid #f5f5f5;" />
										<div class="row" style="border: 1px solid #ccc; margin: 0px 0;">
											<div class="panel-heading font-bold">
												Details of Vacant or Unallotted Plots<span class="pull-right hide"><asp:Label ID="sum_unalloted_plot"  runat="server" />Acres</span>
                                                
											</div>
											<div class="col-md-8 col-sm-6 col-xs-12">
												<div id="container1" style="width: 100%; height: 400px;"></div>
											</div>
											<div class="col-md-4 col-sm-6 col-xs-12">

												<table class="table table-bordered table-hover request-table">
													<tr>
														<th colspan="3" class="text-center font-bold">
															<b>Total No of UnAllotted Plots</b>
														</th>
													</tr>
													<tr>
														<td colspan="3" style="padding: 0px !important">

															<asp:GridView ID="GridView_UnAllotted_plot"
																runat="server"
																CssClass="table table-bordered table-hover request-table request-table-col"
																AutoGenerateColumns="false" OnRowDataBound="gvdata_RowDataBound"
																OnRowCommand="GridView_UnAllotted_plot_RowCommand">

																<Columns>
																	<asp:BoundField HeaderText="Authority/Corporation" DataField="Authority/Corporation"></asp:BoundField>
																	<asp:BoundField HeaderText="In Units" DataField="In Units"></asp:BoundField>
																	<asp:BoundField HeaderText="In Acres" DataField="In Acres"></asp:BoundField>

																	<asp:TemplateField HeaderText="">
																		<HeaderStyle HorizontalAlign="Left" />
																		<ItemStyle HorizontalAlign="Center" />
																		<ItemTemplate>
																			<asp:LinkButton runat="server" ID="btnView" CssClass="fa fa-eye" aria-hidden="true" CommandName="ViewRow" CommandArgument='<%#Eval("Authority/Corporation") %>' ToolTip="Click here to View Request " />
																		</ItemTemplate>
																	</asp:TemplateField>

																</Columns>
															</asp:GridView>

														</td>
													</tr>
												</table>






												<table class="table table-bordered table-hover request-table">
													<tr>
														<th colspan="3" class="text-center font-bold">
															<b>List of Un-Allotted Plots</b>
														</th>
													</tr>
													<tr>
														<td colspan="3" style="padding: 0px !important">
															<div style="width: 100%; height: 400px; overflow: scroll">
																
									<asp:GridView ID="gridlistunallottedplot"
										runat="server"
										CssClass="table table-bordered table-hover request-table request-table-col"
										AutoGenerateColumns="false" OnRowDataBound="gridlistunallottedplot_RowDataBound">
										<Columns>

											<asp:BoundField HeaderText="CorporationID" Visible="false" DataField="CorporationID"
												SortExpression="CorporationID" ></asp:BoundField>

												<asp:BoundField HeaderText=""  DataField="CorporationName"></asp:BoundField>


											<asp:BoundField HeaderText="Location" DataField="RegionalOffice"
												SortExpression="RegionalOffice"></asp:BoundField>
											<asp:BoundField HeaderText="Industrial Area" DataField="IANAME"
												SortExpression="IANAME"></asp:BoundField>
											<asp:BoundField HeaderText="In SQMts." DataField="Area"
												SortExpression="Area"></asp:BoundField>

										</Columns>
										<EmptyDataTemplate>
											No Record Available
										</EmptyDataTemplate>
									</asp:GridView>
															</div>

														</td>
													</tr>
												</table>

											</div>
										</div>
										<hr style="margin-top: 6px; margin-bottom: 6px; border: 0; border-top: 2px solid #f5f5f5;" />
											</span>


										<div class="clearfix"></div>
										<hr style="margin-top: 6px; margin-bottom: 6px; border: 0; border-top: 2px solid #f5f5f5;" />
										<div class="panel panel-default">

											<div class="row">
												<div class="col-md-12 col-sm-12 col-xs-12">
													<div class="panel-heading">
														<div class="col-md-8 col-sm-4 col-xs-12">
															<h4 class="panel-title" style="margin-top: 7px; font-size: 13px;">
																<b>Details of <asp:Label runat="server" ID="report_name" /></b>
															</h4>
														</div>
														<div class="col-md-4 col-sm-8 col-xs-12 input-group">


															<%--OnSelectedIndexChanged="ddlAuthority_SelectedIndexChanged"--%>


															<asp:DropDownList ID="ddlAuthority1" runat="server" Width="100%" Visible="false"  AutoPostBack="true" CssClass="input-sm dropdown-toggle similar-select1"></asp:DropDownList>
															<!--<span class="input-group-btn">
																<button class="btn btn-sm btn-primary" id="btnExport1" type="button" style="margin-bottom: 0;"><i class="fa fa-file-excel-o" style="padding: 2px 0; color: #fff;"></i></button>
															</span>-->
                                                            <ul class="list-inline icon-right-head">
                                                                <li>
                                                                    <div class="input-group">


												<asp:TextBox runat="server" ID="txtSearch" style="padding: 1px 20px !important;margin:0;" OnTextChanged="txtPreConditionVal_changed" AutoPostBack="true"></asp:TextBox>



															<%--  <asp:TextBox id="txtsearch" runat="server" Width="100%" CssClass="input-sm" OnTextChanged="txtsearch_TextChanged"    AutoPostBack="true"></asp:TextBox>--%>
															<span class="input-group-btn">
																<button class="btn btn-sm btn-primary" type="button" style="margin-bottom: 0;padding: 2px 9px;"><i class="fa fa-search" style="padding: 2px 0; color: #fff;"></i></button>
															</span>
														</div>

                                                                </li>
                                                                <li><a href="#"><i class="fa fa-refresh fa-fw"></i></a></li>
                                                                <li><a href="#"><i class="fa fa-share-alt fa-fw"></i></a></li>
                                                                <li><a href="#"><i class="fa fa-file-pdf-o fa-fw"></i></a></li>
                                                                <li><a href="#"><i class="fa fa-file-excel-o fa-fw"></i></a></li>
                                                            </ul>
														</div>
														<div class="clearfix"></div>

													</div>
												</div>
											</div>
											<div id="menuFore" class="panel-collapse collapse in">
												<div class="panel-body">
													<%-- OnRowDataBound="OnRowDataBound"--%>
													<div class="table-responsive">
                                                        <div id="dvData">
														<asp:GridView ID="master_grid"
															runat="server" ShowFooter="true"
															PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"
															CssClass="request-table table table-striped table-bordered table-hover request-table"
															AutoGenerateColumns="true">
															
														</asp:GridView>
                                                        </div>




													</div>
												</div>

											</div>
										</div>








										<!-- start right side bar-->
										<div class="col-md-9"></div>
										<!-- end right side bar-->

										<!--strart left side bar-->
										<div class="col-md-3">
										</div>
										<!--end left side bar-->
									</div>
									<!-- middle page content section-->

								</div>
								<!-- container page end div-->
							</div>
						</div>
					</div>
				</div>
			</div>


				</div>



<%--	 </ContentTemplate>
	   </asp:UpdatePanel>	
			--%>
		
	</form>
    <script type="text/javascript">
        function isDecimalKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {


            }
        }
        $(document).ready(function () {
            $("#btnExport").click(function () {
                window.open('data:application/vnd.ms-excel,' + encodeURIComponent($('#dvData').html()));
                e.preventDefault();

            });
        });
        $(document).ready(function () {
            $("#btnExport1").click(function () {
                window.open('data:application/vnd.ms-excel,' + encodeURIComponent($('#dvData').html()));
                e.preventDefault();

            });
        });

        function PrintElem() {

            Popup($('#dvData').html());
        }

        function Popup(data) {
            var mywindow = window.open('', 'Report', 'height=2000,width=1000');
            mywindow.document.write('<html><head><title style="font-weight:bold;">Allottee Details</title>');
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
	<asp:Literal ID="Literal1" runat="server"></asp:Literal>
	<asp:Literal ID="Literal2" runat="server"></asp:Literal>
	<asp:Literal ID="Literal3" runat="server"></asp:Literal>
	<asp:Literal ID="Literal4" runat="server"></asp:Literal>

	<asp:Literal ID="Literal5" runat="server"></asp:Literal>
	<asp:Literal ID="Literal6" runat="server"></asp:Literal>
	<asp:Literal ID="Literal7" runat="server"></asp:Literal>
	<asp:Literal ID="Literal8" runat="server"></asp:Literal>




	<style>

.panel .panel-heading {
				 border-bottom: 1px solid #ccc;
				 border-left: none;
				 padding: 2px 3px;
				 color: #333;
				 display: block;
				 margin-bottom: 0px;
				 text-shadow: none;
				 text-transform: none;
				 line-height: 1.5em;
				 background: #efefef;
				 background: -webkit-gradient(linear, left bottom, left top, color-stop(0, #efefef), color-stop(1, #fafafa));
				 background: -ms-linear-gradient(bottom, #efefef, #fafafa);
				 background: -moz-linear-gradient(center bottom, #efefef 0%, #fafafa 100%);
				 background: -o-linear-gradient(bottom, #efefef, #fafafa);
				 filter: progid:dximagetransform.microsoft.gradient(startColorStr='#e3e3e3', EndColorStr='#ffffff');
				 -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorStr='#fafafa',EndColorStr='#efefef')";
				 box-shadow: inset 0px 1px 1px white;
			 }

			 .panel-default .panel-heading {
				 margin-top: 0 !important;
				 color: #000 !important;
				 font-size: 13px !important;
			 }

			 .panel .panel-heading {
				 margin-top: 0;
				 color: #000;
				 box-shadow: inset 0px 1px 1px transparent;
				 font-size: 13px;
			 }
                .font-bold {
				 font-weight: 600;
				 font-size: 12px !important;
				 color: #2d2d2d;
				 padding-top: 2px;
			 }

			 .panel-heading {
				 padding: 10px 15px;
				 border-bottom: 1px solid transparent;
				 border-top-right-radius: 3px;
				 border-top-left-radius: 3px;
			 }

			 </style>
		 



	   
</body>
</html>
































