<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LidaReportGeneration.aspx.cs" Inherits="Allotment.LidaReportGeneration" %>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MainLidaUser.Master" AutoEventWireup="true" CodeBehind="LidaReportGeneration.aspx.cs" Inherits="Allotment.LidaReportGeneration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<%--	<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.4/angular.min.js"></script>--%>


</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<cc1:MessageBox ID="MessageBox1" runat="server" />


	<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
	</asp:ScriptManager>


	<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
   <ContentTemplate>
          <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                    <ProgressTemplate>
                        <div class="fgh">
                            <div class="hgf text-center">
                              <span style="font-size:18px;font-weight:bold;">Please Wait...</span><br /> <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                                
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
	<div >


	<div class="row my-new-heading">
		<div class="text-center my-new-heading">
			<span class="col-md-2 col-sm-4 col-xs-6" style="padding-left: 0px !important; padding-right: 2px !important;">

				<asp:DropDownList ID="ddlApplicant" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlApplicant_SelectedIndexChanged" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
					</asp:DropDownList>
			</span>

			<span class="col-md-10 col-sm-8 col-xs-6">Assessment Sheet
			</span>


			<%--            <span class="col-md-4 col-sm-6 col-xs-6">
				<asp:Label runat="server" ID="lblApplicantName" />
			</span>--%>
		</div>

	</div>




	   <div class="row">
		
		<asp:Menu
		id="sub_menu"
		Orientation="Horizontal"   
		CssClass="selected highlighted"
		OnMenuItemClick="sub_menu_MenuItemClick"
		StaticMenuStyle-CssClass="nav nav-pills myul-tabs"
		StaticSelectedStyle-CssClass="active selected highlighted"
		Runat="server">
		   </asp:Menu>

	   </div>


	   <div class="">
		   <div class="col-md-12 col-sm-12 col-xs-12" style="padding: 0;">


			   <asp:PlaceHolder runat="server" ID="Placeholder" />
		   </div>
	   </div>
</div>
</ContentTemplate>
		 </asp:UpdatePanel>




<%--	<script>
		var app = angular.module('myApp', []);
		app.controller('myCtrl', function ($scope) {
			////    $scope.PlotNo = "A-11";


			//    //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (sender, args) {
			//    //    var elem = angular.element(document.getElementById("angularTemplate"));

			//    //    elem.replaceWith($compile(elem)($scope));
			//    //    $scope.$apply();
			//    //});


		});
</script>--%>




	<style>
		.div-checklist {
			border: 1px solid #ccc;
			background: #f7f7f7;
		}

		.div-companydetail .col-md-3 {
			/*width: 22%;*/
		}

		.ol-checklist li {
			border-bottom: 1px solid #ccc;
		}

		.allottee-details-div .col-md-3 {
			/*width: 22%;
			padding-left: 1px;*/
		}

		.allottee-details-div {
			border: 1px solid #ccc;
		}

			.allottee-details-div .col-md-9 {
				/*width: 74%;*/
			}

		.detail-pattern-bg {
			background: #f9f9f9;
		}

		.div-view {
			padding: 0px 0;
			/*  background: #f7f7f7; */
		}

		.assess-min-height {
			min-height: 800px;
		}

		.content {
			min-height: 300px;
		}

		.view-img {
			max-height: 509px;
			max-width: 765px;
		}

		.div-status-bottom {
			border: 1px solid #ccc;
			margin: 0px 0px;
			margin-bottom: 6px;
			padding: 2px 0;
			/* position: absolute; */
			bottom: 0;
			width: 100%;
		}


		.chair-heading-bot {
			border-bottom: 1px solid #ffc511;
			border-top: 1px solid #ffc511;
			margin-bottom: 3px;
		}

		.my-new-heading {
			padding: 0px 0px 0px 0px !important;
		}




		@media only screen and (min-width: 768px) {
			.check-right {
				padding-left: 2px;
				padding-right: 0px;
			}

			.check-left {
				padding-right: 2px;
				padding-left: 0;
			}
		}



		.sub_menu li a {
			white-space: pre-wrap !important;
			color: #000;
		}

		.sub_menu li {
			position: relative;
			font-size: 11px;
			color: #2d2d2d;
			border: 1px solid #ffc5111f !important;
			padding: 1px 1px !important;
			font-weight: 500;
		}

		a.static.selected {
			text-decoration: none;
			border-style: none;
			/*color: #ffc511;
			background: #000;*/
		}

	   .sub_menu_active
		{
			color:#ffffff;
		}
        #UpdateProgress1 {
               position: fixed;
               width: 100%;
               height: 100%;
               z-index: 99999;
               background: rgba(0,0,0,0.21176470588235294);
           }
           #UpdateProgress1 .fgh{
                position: absolute;
                top: 45%;
                margin: 0px auto;
                left: 45%;
                z-index: 999;
           }
	    .modal-backdrop {
	        display:none !important;
        }

	</style>





</asp:Content>

