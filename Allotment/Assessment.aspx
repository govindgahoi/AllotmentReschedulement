﻿<%@ Page Title="" Language="C#"  ValidateRequest="false"  MasterPageFile="~/MainUser.Master"  EnableViewState="true" CodeBehind="Assessment.aspx.cs" Inherits="Allotment.Assessment" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<%@ Register Src="~/UC_ApplicationFinalViewInternal.ascx" TagPrefix="uc1" TagName="UC_ApplicationFinalViewInternal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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

    </script>
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<asp:ScriptManager ID="ScriptManager1" runat="server" EnableViewState="true" AjaxFrameworkMode="Enabled" EnablePartialRendering="true">
	</asp:ScriptManager>


	<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">
   <ContentTemplate>



	   <cc1:MessageBox ID="MessageBox1" runat="server" />
	

	<div class="row my-new-heading">
		<div class="text-center my-new-heading">
			<span class="col-md-2 col-sm-4 col-xs-6" style="padding-left: 0px !important; padding-right: 2px !important;">
                <asp:button id="btnCancel" runat="server" text="Go to Previous" OnClientClick="JavaScript:window.history.back(1); return false;" />
				<asp:DropDownList ID="ddlApplicant" runat="server" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="ddlApplicant_SelectedIndexChanged" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
			</asp:DropDownList>
			</span>

			<span class="col-md-10 col-sm-8 col-xs-6">Assessment Sheet
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
							<div class="div-view div-scroll" style="max-height: 71vh !important;overflow-y: auto;">
							 <div id="div_doc_status" class="div-status-bottom" runat="server" style="padding: 0px 0;">


									<div class="form-group">

										<asp:GridView ID="gridRequestDoc_Status" runat="server"
											CssClass="table table-bordered request-table request-table-col cmtable-bg myreq-col"
											AutoGenerateColumns="true">
											<EmptyDataTemplate></EmptyDataTemplate>
										</asp:GridView>

										<div class="col-md-10 col-sm-10 col-xs-8" style="padding: 0px !important; margin: 0px !important;">
											<asp:TextBox ID="drpRemarks" placeholder="Write Your Observation..." runat="server" TextMode="MultiLine" Style="padding: 0px !important; margin: 0px !important; height: 54px !important;" CssClass="input-sm similar-select1">
											</asp:TextBox>
										</div>
										<div class="col-md-2 col-sm-2 col-xs-4">
											<asp:DropDownList ID="drp_Doc_Status_Save" runat="server"  Width="100%" Style="padding: 1px 2px !important; background: #ececec;" CssClass=" pull-right btn-sm btn-default dropdown-toggle ">
												 <asp:ListItem Value="2" Text="-- Select -- " />
												 <asp:ListItem Value="1" Text="Verified" />
												 <asp:ListItem Value="0" Text="Issue Identified" />
											 </asp:DropDownList>
											<asp:Button CssClass="btn btn-sm btn-primary pull-right" ID="btn_Doc_Status_Save" OnClick="btn_Doc_Status_Save_Click" Text="Submit Observation" style="margin-top:5px;" Width="100%" runat="server" />
										</div>
										<div class="clearfix"></div>
									</div>


									<div class="clearfix"></div>
								</div>

                              <div  id="FinalPrint">
							   
								<asp:PlaceHolder runat="server" ID="Placeholder" />

                                </div>


							</div>
						</div>



					</div>
				</div>
				<div class="clearfix"></div>


	    <div runat="server" class="row" style="border: 1px solid #c5c506; margin: 6px 0 0 0px; padding: 2px 0;">

                <div class="col-md-1 col-sm-2 col-xs-12">
                    <input type="button" id="DataFacts1" class="btn btn-sm btn-primary" value="Data Facts" style="margin-top:12px;margin-right:10px;" />
                </div>
                <div class="col-md-3 col-sm-2 col-xs-12">
                        <asp:FileUpload ID="fileupload" CssClass="form-control" runat="server" Style="margin-top:10px;" Visible="false" />   
                </div>
				<div class="col-md-6 col-sm-8 col-xs-12" style="padding: 0px !important; margin: 0px !important;">
					<asp:TextBox ID="txtTicketComment" placeholder="Comment Here ..." runat="server" TextMode="MultiLine" Style="padding: 0px !important; margin: 0px !important; height: 54px !important;" CssClass="input-sm similar-select1">
					</asp:TextBox>
				</div>
				<div class="col-md-2 col-sm-2 col-xs-12">
										   
											<asp:DropDownList ID="drpOperate"  runat="server"  Width="100%" Style="padding: 1px 2px !important; background: #ececec;" CssClass=" pull-right btn-sm btn-default dropdown-toggle ">
												<asp:ListItem Text="--Please Select--" Value ="-1" />
												<asp:ListItem Text="Recommended" Value ="1" />
                                                	<asp:ListItem Text="Not Recommended" Value ="0" />
											</asp:DropDownList>


	  <asp:Button runat="server" ID="ChangeTicketStatus"  OnClick="ChangeTicketStatus_Click"   Width="100%" class="ey-bg ey-mainbg pull-left"  style="margin: 2px 5px 0 0;" Text="Change Ticket Status" />
				
                </div>  
	</div>



    



<%--                style="display:none"--%>

                        <div id="AKS_Show_Div1" class="div-applicant-details"   >
            	        <asp:HiddenField ID="AKS_Show_HF1"  ClientIDMode="Static"    EnableViewState="true" runat="server" Value="false" />
                            <asp:PlaceHolder runat="server" ID="PH_AssesmentServiceSpecificEntry" />
                        </div>
	

    

				<script>

                    
                        if ($("#AKS_Show_HF1").val() == "true") {
                            $("#AKS_Show_Div1").toggle(true);
                        } else {
                            $("#AKS_Show_HF1").val("false");
                            $("#AKS_Show_Div1").toggle(false);
                        }
                    


                    $("#DataFacts1").click(function ()
                    {
                        if ($("#AKS_Show_HF1").val() == "true")
                        {
                            $("#AKS_Show_HF1").val("false");
                            $("#AKS_Show_Div1").toggle(false);
                        } else
                        {
                            $("#AKS_Show_HF1").val("true");
                            $("#AKS_Show_Div1").toggle(true);
                        } 
                    });



                    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    prm.add_endRequest(function () {

                      
                        if ($("#AKS_Show_HF1").val() == "true") {
                            $(".div-applicant-details").toggle(true);
                        } else {
                            $("#AKS_Show_HF1").val("false");
                            $(".div-applicant-details").toggle(false);
                        }
                        

                        $("#DataFacts1").click(function ()
                        {
                            if ($("#AKS_Show_HF1").val() == "true") {
                                $("#AKS_Show_HF1").val("false");
                                $(".div-applicant-details").toggle(false);
                            } else {
                                $("#AKS_Show_HF1").val("true");
                                $(".div-applicant-details").toggle(true);

                            }
                        });



                    });

				</script>




			</div>
	</div>
	</div>



               
       	   </ContentTemplate>
		 </asp:UpdatePanel>



	<style>
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
				left: 33%;
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
			max-height: 72vh;
            min-height: 72vh;
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

	</style>


</asp:Content>