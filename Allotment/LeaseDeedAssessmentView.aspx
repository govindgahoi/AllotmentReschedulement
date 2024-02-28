<%@ Page Title="" Language="C#"  ValidateRequest="false"  MasterPageFile="~/MainUser.Master"  EnableViewState="true" CodeBehind="LeaseDeedAssessmentView.aspx.cs" Inherits="Allotment.LeaseDeedAssessmentView" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<%@ Register Src="~/UC_ApplicationFinalViewInternal.ascx" TagPrefix="uc1" TagName="UC_ApplicationFinalViewInternal" %>

<%@ Register Src="~/UC_ProcessApplication.ascx" TagPrefix="uc2" TagName="UC_ProcessApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .sub_menu ul li:nth-last-child(1) {
            background: #b9b9b9;
            border-top:#000;
        } 
        .sub_menu ul li:nth-last-child(2) {
            background: #b9b9b9;
            border-top:#000;
        } 
   
        .pad-lt0 {
        padding-left:0 !important;
        }
        .pad-rt0 {
            padding-right: 0!important;
        }
        .content {
            min-height:500px !important;
            padding: 1px 15px 0px 15px !important;
        }
        .btn-success {
                color: #fff !important;
                background-color: #5cb85c !important;
                border-color: #4cae4c !important;
                padding: 4px 8px !important;
                font-size:12px !important;
                background-image:none !important;
                margin:0 !important;
        }
        .btn-warning {
            color: #fff !important;
            background-color: #f0ad4e !important;
            border-color: #eea236 !important;
            padding: 4px 8px !important;
            font-size: 12px !important;
            background-image:none !important;
            margin:0 !important;
        }
        .btn-danger {
            color: #fff !important;
            background-color: #d9534f !important;
            border-color: #d43f3a !important;
            padding: 4px 8px !important;
            font-size: 12px !important;
            background-image:none !important;
            margin:0 !important;
        }
        .mynewpanelhead {
			font-size: 14px !important;
			font-weight: 600;
			background: #2d2d2d;
			color: #ffc511 !important;
		}
		#myModal h4.modal-title {
			margin-right: 18px;
			text-align: center;
		}
		#myModal{
			background: rgba(0,0,0,0.51);
		}
		.modal-backdrop {
			background:none !important;
		}
		@media only screen and (min-width: 768px) {
			.modal-dialog{
				/*left: 33%;*/
				width:400px;
				margin-top: 3%;
			}
		}
  
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
			max-height: 80vh;
            min-height: 80vh;
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
			/*padding: 0px 0px 0px 0px !important;*/
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

        #ContentPlaceHolder1_sub_menu a
        {
            padding:3px 8px;
            }
#ContentPlaceHolder1_sub_menu ul
{
        list-style: none;
    margin: 0;
    background: #e2e2e2;
    padding: 0;
    width: auto;
    }
		.sub_menu li a {
			white-space: pre-wrap !important;
			color: #000;
		}   


		.sub_menu ul {
			float: none !important;
		}

		.sub_menu li {
			position: relative;
			    font-size: 12px;
    color: #2d2d2d;
    border-bottom: 1px solid #ffffff;
    padding: 1px 1px !important;
    font-weight: 500;
		}

		a.static.selected {
			text-decoration: none;
			border-style: none;
			color: #ffc511;
			background: #000;
		}

	   .sub_menu_active
		{
			color:#ffffff;
		}
        .modal-backdrop {
            display:none;
        }
        @media only screen and (max-width: 768px) {
            .form-group label.text-right {
                text-align:left !important;
            }
            .form-group .col-xs-6 {
                width:50% !important;
            }
        }
        @media only screen and (min-width: 768px) {

        .div-applicant-details {
            position: fixed;
            top: 51px;
            border: 1px solid #ccc;
            left: 0;
            width: 255px;
            z-index: 99999;
            max-height: 89vh;
            overflow-y:auto;
            background: #fff;
        }
        }
            .div-applicant-details .tab-content {
                max-height: 88vh;
                overflow-y: auto;
            }
        .content {
                position: relative;
    z-index: 9;
        }
    </style>

    	



    <script type='text/javascript'>
        document.write('<style type="text/css">body{display:none}</style>');
        jQuery(function ($) {
            $('body').css('display', 'block');
        }); 


        function PrintElem() {

            Popup($('#FinalPrint').html());
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

  

     
        function Redirect(par, par1,par2) {

            window.location.href = ("DocAck.aspx?ServicereqNo=" + par1 + "&AppType=" + par+"&DocID="+par2);
        }
         function MessageAndRedirect(par) {
            alert(par);
            window.location.href = 'ServiceRequestInboxNewLeaseDeed.aspx';
        }


          function ShowRejectModal() {
          $('#RejectionModal').modal('show');
        }

             function ShowClarificationModal() {
          $('#ClarificationModal').modal('show');
        }

         
       function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to save data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
           }
           document.getElementById("<%= hid.ClientID %>").innerText = confirm_value;
        }

 

    </script>
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<asp:ScriptManager ID="ScriptManager1" runat="server" EnableViewState="true" AjaxFrameworkMode="Enabled" EnablePartialRendering="true">
	</asp:ScriptManager>


	<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">
   <ContentTemplate>

        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                    <ProgressTemplate>
                        <div class="fgh">
                            <div class="hgf text-center">
                              <span style="font-size:25px;font-weight:bold;">Please Wait...</span><br /> <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                                
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>


	   <cc1:MessageBox ID="MessageBox1" runat="server" />

       <%---- Modal Section  ----%>


          <div class="modal fade" id="RejectionModal" role="dialog" >
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Reject Application</h4>
                </div>
                <div class="modal-body" >
                    <div class="col-md-12" style="font-size: 12px; padding: 4px 15px;">
                        <asp:TextBox runat="server" ID="txtReasonForRejection" CssClass="input-sm similar-select1 margin-left-z" placeholder="Enter Reason For Rejection" TextMode="MultiLine" Height="250px"></asp:TextBox>
                     

                        

                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="modal-footer">
                    <div class="pull-right border-buttons">

                   </div>
                </div>
            </div>
        </div>
    </div>

       
	<div class="row my-new-heading">
		<div class="text-center my-new-heading">
			<span class="col-md-2 col-sm-4 col-xs-6" style="padding-left: 0px !important; padding-right: 2px !important;">
               <span style="text-align:left !important"><asp:button id="btnCancel" runat="server" class="btn btn-primary btn-sm pull-left" text="Go to Previous" OnClientClick="JavaScript:window.history.back(1); return false;" /> </span>
				<asp:DropDownList ID="ddlApplicant"  runat="server" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="ddlApplicant_SelectedIndexChanged" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
			</asp:DropDownList>
			</span>

			<span class="col-md-8 col-sm-8 col-xs-8">Assessment Sheet
			</span>

           <span class="col-md-2 col-sm-2 col-xs-2"> <asp:Button ID="btnPrint" runat="server" Text="Print" Style="margin: 6px 2px;display:block;margin-top: -4px;padding: 6px 13px 3px 14px;" OnClick="btnPrint_Click" CssClass="btn-primary btn-sm ey-bg pull-right" />
			</span>
		</div>
	</div>


	<div class="row applicant-right-div">
		<div class="col-md-12 col-sm-12 col-xs-12" style="padding: 0;">
			<div class="panel panel-default" style="position: relative; min-height: 80%;">
				<div class="">
					<div class="col-md-3 col-sm-4 col-xs-6 pad-lt0 pad-rt2">
						<div class="div-checklist assess-min-height" style="border: 1px solid #ccc;overflow-y:auto;">
							<div class="panel-heading font-bold">Checklist</div>


							<asp:Menu
								ID="sub_menu"
								Orientation="Vertical"
								Width="100%"
								CssClass="sub_menu"
								StaticSelectedStyle-CssClass="sub_menu_active"
								OnMenuItemClick="sub_menu_MenuItemClick"
								runat="server">
							</asp:Menu>


						</div>
					</div>



					<div class="col-md-9 col-sm-8 col-xs-6 pad-rt0 pad-lt0">
						<div class="div-assesment-applicant assess-min-height" style="border: 1px solid #ccc;">		   
							<div class="div-view div-scroll" style="max-height: 80vh !important;overflow-y: auto;">
							
                              <div  id="FinalPrint">
							   
								<asp:PlaceHolder runat="server" ID="Placeholder" />

                                </div>


							</div>
						</div>



					</div>
				</div>
				<div class="clearfix"></div>


	   
                <div class="col-md-12 col-sm-12 col-xs-12" style="border: 1px solid #c5c506; margin: 6px 0 0 0px; padding: 2px 0;" >
                    <span class="pull-right"></span>
                </div>

	

          
<asp:HiddenField ID="hid" runat="server" />
       


	</div>
	</div>



               
       	   </ContentTemplate>
		 </asp:UpdatePanel>



	


</asp:Content>
