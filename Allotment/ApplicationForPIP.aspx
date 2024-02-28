<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplicationForPIP.aspx.cs" Inherits="Allotment.ApplicationForPIP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
   
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>  
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    
    <link href="css/chosen.min.css" rel="stylesheet" />
    <script src="js/chosen.jquery.min.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <script src="js/jquery-ui.js"></script>
   
    
  <script>
$(document).ready(function(){
	function myinc(){
		$('.myul-tabs a').removeClass('active');
		$('myul-tabs a').click(function(){
			$(this).addClass('active');
            alert("hello");
		});
	}

});
</script>
<style>
    .active{
    	background:#ccc!important;
    }
</style>
       <style>
           .modal-open{
                overflow:auto !important;
           }
           .nav-pills {
                margin-left:0 !important;
           }
           .nav-pills > li + li {
            margin-left: 0px !important;
           }
           .pad-lt0 {
                padding-left:0 !important;
           }
           .pad-rt0 {
                padding-right:0 !important;
           }
               @media only screen and (max-width: 768px) {
                    .form-group label.text-right {
                        text-align:left !important;
                    }
                    .form-group .col-sm-6 {
                        width:50% !important;
                    }
                    .right-niveshban {
                        text-align:center;
                    }
                    .left-niveshban {
                        text-align:center;
                    }
                }
               
            @media only screen and (min-width: 768px) {
                .right-niveshban {
                    text-align:right;
                }
                .left-niveshban {
                    text-align:left;
                }
            }
            .form-group label {
                font-weight:700 !important;
               top: 0px;
               left: 0px;
           }
           .modal-open {
            overflow:auto;
           }
           input[type=file] {
            margin:0 !important;
            width:207px;
           }

           .hide{
               display:none;
           }
           .show{
               display:block;
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
             .MessagePennel {
            background-color: #f4e542;
            width: 100%;
        }

        .check-cross {
            color: #f70000;
            font-size: 18px;
            line-height: 0.7;
            font-weight: 100;
        }

           .nav-pills > li + li {
                margin-left: 0px;
           }
           .myul-tabs {
                margin-left:0 !important;
           }
        .myul-tabs li {
            width: 100%;
            border-top:1px solid #fff;
        }
        .myul-tabs li a:after {
            display:none;
        }
        .myul-tabs li a:before {
            display:none;
        }
        h4.modal-title {
            margin-right:18px !important;
        }
        .mynew-panel-head {
            font-size: 14px !important; 
            font-weight: 600; 
            background: #2d2d2d; 
            color: #ffc511 !important;
            text-align: center !important;
        }
        .modal.fade.in {
            background:rgba(0, 0, 0, 0.51);
        }
        @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 11%;
            }
           .pad-rt0 {
            padding-right:0;
           }
           .pad-lt0 {
            padding-left:0;
           }
        }
        .modal-header{
            padding:2px !important;
        }
        .myreq-col tr td {
			font-size: 12px;
			color: #2d2d2d;
			border: 1px solid #fff !important;
			text-align: left;
			background: #e0e0e0;
			padding: 1px 6px !important;
			font-weight: bold;
		}

		.myreq-col tr th {
			font-size: 12px;
            background-color: #ffe600;
		}

		.myreq-col tr td a {
			color: #337ab7;
			font-weight: bold;
		}
    </style>
     
       <script type="text/javascript">
            $(document).ready(function () {
                Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
            });

            function PageLoaded(sender, args) {
                $(".chosen").chosen();
                $(".MultiSelect").chosen();
            }
        </script>

       <script type="text/javascript">
           function MsgAndRedirect(ID) {
               alert('Form Submitted Succesfully.');
               window.location.href = 'ApplicationForPIP.aspx?ID=' + ID;

           }

           function MessageAndRedirect(par) {
               alert("Objection cleared and form re-submitted successfully");
               window.location.href = 'ApplicationForPIP.aspx?ID=' + par;
           }

           function MsgAndRedirect2() {
               alert('Invalid usage');
               window.location.href = 'RegistrationLogistics.aspx';

           }

         function PrintElemF() {

             Popup($('#FinalPrint').html());
         }

         function PrintElem() {

             Popup($('#Payment_div').html());
         }



         function ShowSignPreview(input) {

             var uploadControl = document.getElementById('FuplodApplicantSign');
             if (uploadControl.files[0].size > 512000) {
                 alert('File size must be less than 500 KB');
                 document.getElementById("FuplodApplicantSign").value = "";
                 return false;
             }


             var val = document.getElementById("FuplodApplicantSign").value;
             var Extension = val.substring(val.lastIndexOf('.') + 1).toLowerCase();


             if (Extension == "jpeg" || Extension == "JPEG" || Extension == "png" || Extension == "jpg") {
                 if (input.files && input.files[0]) {
                     var reader = new FileReader();
                     reader.onload = function (e) {

                         $('#Image2').hide();
                         $('#ImgPrvSign').addClass("show");

                         $('#ImgPrvSign').prop('src', e.target.result)



                         $('#ImgPrvSign').attr('value', e.target.result);


                     };
                     reader.readAsDataURL(input.files[0]);

                 }
             }
             else {
                 document.getElementById("FuplodApplicantSign").value = "";
                 $('#ImgPrvSign').prop('src', '../images/signature.png')

                 alert('Please select correct file format(.PNG,.JPEG,.JPG)');
             }


         }



         function ShowImagePreview(input) {


             var uploadControl = document.getElementById('FuplodApplicantImage');
             if (uploadControl.files[0].size > 512000) {
                 alert('File size must be less than 500 KB');
                 document.getElementById("FuplodApplicantImage").value = "";
                 return false;
             }




             var val = document.getElementById("FuplodApplicantImage").value;
             var Extension = val.substring(val.lastIndexOf('.') + 1).toLowerCase();
             if (Extension == "jpeg" || Extension == "JPEG" || Extension == "png" || Extension == "jpg") {
                 if (input.files && input.files[0]) {
                     var reader = new FileReader();
                     reader.onload = function (e) {

                         $('#Image1').hide();
                         $('#ImgPrv').addClass("show");

                         $('#ImgPrv').prop('src', e.target.result)



                         $('#imgSrc').attr('value', e.target.result);


                     };
                     reader.readAsDataURL(input.files[0]);

                 }
             }
             else {
                 document.getElementById("FuplodApplicantImage").value = "";
                 $('#ImgPrv').prop('src', '../Images/account-icon-5.jpg')

                 alert('Please select correct file format(.PNG,.JPEG,.JPG)');
             }

         }

       </script>


</head>
<body>
     <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
		<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">

			<ContentTemplate>
				<asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
					<ProgressTemplate>
						<div class="fgh">
							<div class="hgf">
								<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
							</div>
						</div>
					</ProgressTemplate>
				</asp:UpdateProgress>
		
        <div>
            <div class="container">
      
				
					<div class="row" id="SideDiv">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="panel panel-default">
                                <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;" runat="server" id="BannerDiv">
									<div class="row">
                                            <div class="col-md-4 col-sm-4 col-xs-12 left-niveshban">
                                                <ul class="mylogo-ul list-inline " style="margin: 0; padding: 6px 0 9px 1px;">
                                                    <li>
                                                        <img src="images/logo-img/govt_up.png" />
                                                       

                                                    <li></li>
                                                </ul>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12 text-center">
                                                <img src="/images/upsidclogo.png" style="width:211px;margin-top: 12px;" alt="Goverment" />

                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12 right-niveshban">
                                                <ul class="mylogo-ul list-inline" style="margin: 0; padding: 6px 0 9px 1px;">
                                                    <li>
                                                     
                                                <img src="images/investup.png" />
                                                </ul>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
								</div>

								<div class="clearfix"></div>
                                <div class="panel-heading font-bold text-center" style="font-size: 14px !important; font-weight: 600; background: #2d2d2d; color: #ffc511 !important;">Application for Issuance of Unique Id for Private Industrial Parks <span class="pull-right">Form No.: <asp:Label runat="server" id="lblFormNo"></asp:Label> </span></div>
                               
                                   <div class="row">

                                     <div class="alert">
                                        
 <strong class="text-center" style="color:red; font:800;"><u>* Disclaimer :  Please do not refresh the page or click the Back button on your browser</u></strong>

    <asp:Button runat="server" ID="btn_backNmswp" Text="⇦ Go Back" CssClass="pull-right btn btn-info" Style="background-color: #02486d; color: #fff; font-weight: 800; padding-top:0px;" OnClick="btn_backNmswp_Click"  />                                     
</div>
       
                                      
                                      
                                                               
</div>
                      
                                
                                <div class="row">
                                            <div class="col-md-2 pad-rt0 pad-rt0">

                                                <style>
                                                    #sub_menu ul {
                                                        margin-left:0 !important;
                                                    }
                                                </style>

                                                   <asp:Menu
                                                        id="sub_menu"
                                                        Orientation="Vertical"   
                                                        OnMenuItemClick="Menu1_MenuItemClick"
                                                        StaticMenuStyle-CssClass="nav nav-pills myul-tabs"
                                                        StaticSelectedStyle-CssClass="active selected highlighted"
                                                        Runat="server" Style="margin-left:0;">      
                                                        <Items>
                                                       
                                                        <asp:MenuItem Text="<span style='color:red;font-weight:800;font-size:larger;'>Objections</span>"  Value="6" />
                                                        <asp:MenuItem Text="Applicant Detail" Value="0" />
                                                        <asp:MenuItem Text="Photo & Sign" Value="1" />
                                                        <asp:MenuItem Text="Project Details" Value="2" />
                                                        <asp:MenuItem Text="Land Details" Value="3" />
                                                        <asp:MenuItem Text="Upload Documents" Value="4" />
                                                        <%--<asp:MenuItem Text="<span style='color:#1B00FD; font-weight:800;font-size:revert;'>Migration Details</span>"  Value="17" />
                                                        --%><asp:MenuItem Text="Make Payment"  Value="18" />
                                                        <asp:MenuItem Text="Final Form" Value="5" />                                                                         
                                                        </Items>    
                                                    </asp:Menu>
                                            </div>
                                            <div class="col-md-10 pad-lt0" style="border-left:1px solid #ccc;">

                                                    <div id="divMessageError" class="MessagePennel" runat="server" style="display:none;">
                            <label>
                                <span class="check-cross" runat="server">✖</span>
                                
                                <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
                            </label>
                        </div>
                               
                                                             <asp:MultiView runat="server" ID="Allotment">  
                                     
                                                                    <asp:View runat="server" ID="View1">
                                                                        <asp:Label runat="server" ID="lblChosePlot" Visible="false"></asp:Label>
                                                                            <div class="panel-heading">Basic Details</div>
                                                                            <div class="table-responsive">
                                                                           <table class="table-bordered table table table-hover request-table myreq-col">
                                                                                <tr> 
                                                                                    <td colspan="6"><b></b></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <th>Authorised Person Name</th>
                                                                                    <th>Email ID</th>
                                                                                    <th>Mobile No</th>
                                                                                    
                                                                                </tr>
                                                                                <tr><td><asp:Label runat="server" ID="lblApplicantName" ></asp:Label></td><td><asp:Label runat="server" ID="lblEmailID"></asp:Label></td><td><asp:Label runat="server" ID="lblMobileNo"></asp:Label></td></tr>
                   
                                                                            </table>
                                                                        </div>
                                                                         <div class="clearfix"></div>
													                   
                                                                   

                                                                        <div class="row">
                                                                            <div class="col-md-12 col-sm-12 col-xs-12">
													                            <p class="panel-heading"><b>Particulars of the Applicant</b></p>
													                            
                                                                                  <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																                            <span style="color: Red">*</span>
																                            Applicant Aadhaar No :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                             <asp:TextBox ID="txtApplicantAadhar" runat="server" CssClass="similar-select1 input-sm" onblur="ValidateRequired(this,'Applicant Aadhar No');"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
                                                                                <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																                            <span style="color: Red">*</span>
																                            Applicant Address :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                             <asp:TextBox ID="txtApplicantAddress" runat="server" CssClass="similar-select1 input-sm" onblur="ValidateRequired(this,'Applicant Address');"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
                                                                                 <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																                            <span style="color: Red">*</span>
																                            Applying as an SPV :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:DropDownList ID="drpSPV" runat="server" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" AutoPostBack="true" OnSelectedIndexChanged="drpSPV_SelectedIndexChanged" >
                                                                                                <asp:ListItem Value="NO"> NO </asp:ListItem>
                                                                                                <asp:ListItem Value="YES"> YES </asp:ListItem>
																                            </asp:DropDownList>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
                                                                                <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																                            <span style="color: Red">*</span>
																                            Constitution of Firm/Company :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:DropDownList ID="ddlcompanytype" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CompanyTypeddl_selectedindex_changed" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" ></asp:DropDownList>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                            <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																                            <span style="color: Red">*</span>
																                            Name of the Firm/Company :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtCompanyname" runat="server" CssClass="similar-select1 input-sm" onblur="ValidateRequired(this,'Name of the Firm/Company');"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
                                                                                <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                            <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																                            <span style="color: Red">*</span>
																                            Address of Firm/Company :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtFirmAddress" runat="server" CssClass="similar-select1 input-sm" onblur="ValidateRequired(this,'Address of the Firm/Company');"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                            <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                            Pan No :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtPanNo" runat="server" CssClass="similar-select1 input-sm" Style="text-transform:uppercase;" onblur="validatepan(this,'Pan No');"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
                                                                                <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                          
													                            <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                           <span style="color: Red">*</span>  
																                            GSTIN No :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtGstNo" runat="server" CssClass="similar-select1 input-sm" Style="text-transform:uppercase;" onblur="validatepan(this,'GSTIN No');"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
                                                                                 <div class="clearfix"></div>
													                            <hr class="myhrline" />
                                                                                  <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                            
																                            UDYAM/IEM/DIC Certificate No :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtUdyogAdhar" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                            <div class="form-group">
														                            <div class="row">

															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">                                                                 
																                            <span style="color: Red">*</span>
                                                                                            Name of Proposed Private Industrial Park :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtProposedPIP" runat="server" onblur="ValidateRequired(this,'Name of Proposed Private Industrial Park');" CssClass="input-sm similar-select1"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
                                                                                   <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                            <div class="form-group">
														                            <div class="row">
                                                                                       
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">                                                                        
																                             <span style="color: Red">*</span>
                                                                                            Project Location :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtProjectLocation" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Project Location');"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                            <div class="form-group">
														                            <div class="row">

															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">                                                                 
																                            <span style="color: Red">*</span>
                                                                                            Region of Proposed Park :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">

                                                                                            <asp:DropDownList ID="drpRegionPIP" runat="server"  CssClass="similar-select1 margin-left-z dropdown-toggle input-sm"  OnSelectedIndexChanged="ddlProjectDetails_SelectedIndexChanged" >
                                                                                                 <asp:ListItem>--Select--</asp:ListItem>
                                                                                                   <asp:ListItem>Bundelkhand</asp:ListItem>
                                                                                                  <asp:ListItem>Poorvanchal</asp:ListItem>
                                                                                                  <asp:ListItem>Madhyanchal</asp:ListItem>
                                                                                                   <asp:ListItem>Paschimanchal</asp:ListItem>
                                                                                             </asp:DropDownList>
																                            
															                            </div>
														                            </div>
													                            </div>
                                                                                <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                     
                                                                            </div>
                                                                           
                                                                        </div>
                                                                        <div class="clearfix"></div>
															                            <div id="tr2" runat="server" visible="false">
																                            <hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
                                                                                            <div class="panel-heading"><b>ShareHolders Details</b></div>
													                           
																                            <asp:GridView ID="gridshareholder" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="ShareHolderDelete_Click">
																	                            <Columns>

																		                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center"><ItemTemplate><asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label></ItemTemplate></asp:TemplateField>


																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Shareholder Name"><ItemTemplate><asp:Label ID="lblShareholderName" runat="server" Text='<%#Eval("ShareHolderName") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtShareholderName_insert" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateFill(this);" onkeypress="return Validate_shareholder_name(event);"></asp:TextBox></FooterTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Share (In %)"><ItemTemplate><asp:Label ID="lblShareper" runat="server" Text='<%#Eval("SharePer") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtShareper_insert" runat="server" CssClass="input-sm similar-select1" MaxLength="3" onblur ="ValidateFill(this);" onkeypress="return isDecimalKey(event);"></asp:TextBox></FooterTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Address"><ItemTemplate><asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtAddress_insert" CssClass="input-sm similar-select1" onblur ="ValidateFill(this);" runat="server"></asp:TextBox></FooterTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Phone No"><ItemTemplate><asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtPhone_insert" CssClass="input-sm similar-select1" MaxLength="15" runat="server" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox></FooterTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Email ID"><ItemTemplate><asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtEmail_insert" CssClass="input-sm similar-select1" runat="server" onblur="return ValidateShareHolderEmail();"></asp:TextBox></FooterTemplate></asp:TemplateField>


																		                            <asp:TemplateField><ItemTemplate><asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" /></ItemTemplate><FooterStyle HorizontalAlign="Right" /><FooterTemplate><asp:Button runat="server" ID="BtnSave" OnClientClick="return checkGrid1();" OnClick="insert_shareholder_details" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" /></FooterTemplate></asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>

															                            </div>
															                            <div class="clearfix"></div>
															                            <div id="tr4" runat="server" visible="false">
																                            <hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
                                                                                            <div class="panel-heading"><b>Trustee Details</b></div>
													                           
																                            <asp:GridView ID="Trustee_details_grid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="TrusteeDelete_Click">
																	                            <Columns>

																		                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center"><ItemTemplate><asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label></ItemTemplate></asp:TemplateField>


																		                            <asp:TemplateField ItemStyle-Width="25%" HeaderText="Trustee Name"><ItemTemplate><asp:Label ID="lblTrusteeName" runat="server" Text='<%#Eval("TrusteeName") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtTrusteeName_insert" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateFill(this);"></asp:TextBox></FooterTemplate></asp:TemplateField>

																		                            <asp:TemplateField ItemStyle-Width="25%" HeaderText="Address"><ItemTemplate><asp:Label ID="lblTAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtTAddress_insert" CssClass="input-sm similar-select1" onblur ="ValidateFill(this);" runat="server"></asp:TextBox></FooterTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="25%" HeaderText="Phone No"><ItemTemplate><asp:Label ID="lblTPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtTPhone_insert" CssClass="input-sm similar-select1" MaxLength="10" runat="server"  onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox></FooterTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="25%" HeaderText="Email ID"><ItemTemplate><asp:Label ID="lblTEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtTEmail_insert" CssClass="input-sm similar-select1" runat="server" onblur="return ValidateTrusteeEmail();"></asp:TextBox></FooterTemplate></asp:TemplateField>


																		                            <asp:TemplateField><ItemTemplate><asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" /></ItemTemplate><FooterStyle HorizontalAlign="Right" /><FooterTemplate><asp:Button runat="server" ID="BtnSave" OnClientClick="return checkGrid2();" OnClick="insert_trustee_details" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" /></FooterTemplate></asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>

															                            </div>
															                            <div class="clearfix"></div>
															                            <div id="tr8" runat="server" visible="false">
																                            <hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
                                                                                            <div class="panel-heading"><b>Directors Details</b></div>
													                           
																                            <asp:GridView ID="DirectorsGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="DirectorDelete_Click">
																	                            <Columns>

																		                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center"><ItemTemplate><asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label></ItemTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Director Name"><ItemTemplate><asp:Label ID="lblDirectorName" runat="server" Text='<%#Eval("DirectorName") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtDirectorName_insert" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateFill(this);" ></asp:TextBox></FooterTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Din/Pan"><ItemTemplate><asp:Label ID="lblDIN_PAN" runat="server" Text='<%#Eval("DIN_PAN") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtDIN_PAN_insert" runat="server" CssClass="input-sm similar-select1" onblur ="ValidateFill(this);"></asp:TextBox></FooterTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Address"><ItemTemplate><asp:Label ID="lblDirectorAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtDirectorAddress_insert" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateFill(this);"></asp:TextBox></FooterTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Phone No"><ItemTemplate><asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtDirectorPhone_insert" CssClass="input-sm similar-select1" MaxLength="10" runat="server" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox></FooterTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Email ID"><ItemTemplate><asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtDirectorEmail_insert" CssClass="input-sm similar-select1" runat="server" onblur="return ValidateDirectorEmail();"></asp:TextBox></FooterTemplate></asp:TemplateField>


																		                            <asp:TemplateField>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" /></ItemTemplate><FooterStyle HorizontalAlign="Right" />
                                                                                                        <FooterTemplate><asp:Button runat="server" ID="BtnSave" OnClientClick="return checkGrid3();" OnClick="insert_Director_details" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" /></FooterTemplate>

																		                            </asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>
															                            </div>
															                            <div class="clearfix"></div>
															                            <div id="tr9" runat="server" visible="false">
																                            <hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
                                                                                            <div class="panel-heading"><b>Partners Details</b></div>
													                           
																                            <asp:GridView ID="PartnershipFirmGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="PartnershipDelete_Click">
																	                            <Columns>

																		                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center"><ItemTemplate><asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label></ItemTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Partner Name"><ItemTemplate><asp:Label ID="lblPartnerName" runat="server" Text='<%#Eval("PartnerName") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtPartnerName_insert" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateFill(this);" ></asp:TextBox></FooterTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Partnership (In %)"><ItemTemplate><asp:Label ID="lblPartnershipPer" runat="server" Text='<%#Eval("PartnershipPer") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtPartnershipPer_insert" runat="server" MaxLength="3" onblur ="ValidateFill(this);" onkeypress="return isDecimalKey(event);" CssClass="input-sm similar-select1"></asp:TextBox></FooterTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Address"><ItemTemplate><asp:Label ID="lblPartnerAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtPartnerAddress_insert" CssClass="input-sm similar-select1" onblur ="ValidateFill(this);" runat="server"></asp:TextBox></FooterTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Phone No"><ItemTemplate><asp:Label ID="lblPartnerPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtPartnerPhone_insert" CssClass="input-sm similar-select1" MaxLength="10" runat="server" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox></FooterTemplate></asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Email ID"><ItemTemplate><asp:Label ID="lblPartnerEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtPartnerEmail_insert" CssClass="input-sm similar-select1" runat="server" onblur="return ValidatePartnerEmail();"></asp:TextBox></FooterTemplate></asp:TemplateField>

                                                                                                     
																		                            <asp:TemplateField>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" /></ItemTemplate>

                                                                                                        <FooterStyle HorizontalAlign="Right" /><FooterTemplate><asp:Button runat="server" ID="BtnSave" OnClientClick="return checkGrid4();" OnClick="insert_Partnership_details"  CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" /></FooterTemplate></asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>
															                            </div>
															                            <div class="clearfix"></div>
                                                                           <div runat="server" id="Screen11" class="col-md-12 col-sm-12 col-xs-12 text-center" ><asp:Button runat="server" ID="BtnSaveApplicant" CssClass="btn btn-sm btn-primary" Text="Save & Proceed" Style="text-align:center;padding: 4px 10px !important;margin: 10px 0;" OnClientClick="return ccheck1();" OnClick="BtnSaveApplicant_Click" /></div>
                                                                          
                                                                        <asp:Label runat="server" ID="LblAllotteeId" Visible="false"></asp:Label>
                                                                          <asp:Label runat="server" ID="LblAllotteeIdMain" Visible="false"></asp:Label>
                                                                           
                                                                          
                            
                                    
                                                                            <asp:Label id="lblImageName" runat="server" Visible="false"></asp:Label>

                                    
                                                                     </asp:View>

                                                                    <asp:View runat="server">


                                        <div class="row">
    <div class="panel panel-default">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="col-md-1 col-sm-12 col-xs-12"></div>
            <div class="col-md-10 col-sm-12 col-xs-12" style="margin-bottom:10px;">
                <div class="row">
                    <div class="col-md-6 col-sm-6 col-xs-12 text-center">
                        <div class="myborder" style="border:1px solid #ccc;">
                            <div class="panel-heading">Photograph</div>
                            <div style="height:200px;padding:5px;"><asp:Image id="ImgPrv" runat="server" src="/images/account-icon-5.jpg" class="img-sign" alt="image" style="height: 200px;margin: 0 auto;"/>
                                   <asp:Image id="Image1" runat="server" style="height: 200px; max-width:100%; margin: 0 auto;" Visible="false"/>
                                   <asp:Label runat ="server" ID="lblImagetype" visible="false"></asp:Label>
                                                                                              
                            </div><br />   
                            <div style="border:1px solid #ccc;padding:5px;">
                                <asp:FileUpload ID="FuplodApplicantImage" onchange="ShowImagePreview(this);" Width="100%" CssClass="form-control" runat="server" />   
                                <button runat="server" id="btnSaveImage" class="btn-primary btn-sm ey-bg" style="padding: 2px 6px;margin:5px 0;" onserverclick="btnSaveImage_ServerClick">Upload Photograph</button>
                                <div class="clearfix"></div>
                            </div>
                        </div>                        
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12 text-center">
                        <div class="myborder" style="border:1px solid #ccc;">
                            <div class="panel-heading">Signature</div>
                            <div style="height:200px;padding:5px;"><img id="ImgPrvSign" src="images/signature.png" runat="server" class="img-sign" alt="image" style="margin:50px auto 0 auto;height:100px;"/>
                                <asp:Image id="Image2" runat="server" style="margin:50px auto 0 auto;height:100px; max-width:100%;" Visible="false"/>

                            </div><br />
                            <div style="border:1px solid #ccc;padding:5px;">
                                <asp:FileUpload ID="FuplodApplicantSign" Width="100%" onchange="ShowSignPreview(this);" CssClass="form-control" runat="server" /> 
                                <button runat="server" id="btnSaveSign" class="btn-primary btn-sm ey-bg" style="padding: 2px 6px;margin:5px 0;" onserverclick="btnSaveSign_ServerClick" >Upload Signature</button>
                                <div class="clearfix"></div>
                            </div>
                        </div> 
                    </div>  
                    <div class="clearfix"></div>
               
                </div>
            </div>
            <div class="col-md-1 col-sm-12 col-xs-12"></div>
        </div>
    </div>
</div>
                                    </asp:View>
                                                                 
                                                                    <asp:View runat="server" ID="View2">


                                                            <div class="panel-heading text-center"><b>Project Details</b></div>
                                                                         <p class="panel-heading font-bold">Proposed Area</p>
                                                                        							     <div class="form-group">
                                                                                    
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                           Total Area of Proposed Industrail Park (In Sqft) :
															                            </label>
															                           <div class="col-md-2 col-sm-6 col-xs-6">
                                                                         <asp:TextBox ID="txtTotalArea" runat="server" CssClass="input-sm similar-select1"  onblur ="ValidateRequired(this,'Total Area');"></asp:TextBox>

                                                                                        
                                                                                        </div>
														                              <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
														                    
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                           Covered Area (In Sqft) :
															                            </label>
															                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                                         <asp:TextBox ID="txtCoveredArea" runat="server" CssClass="input-sm similar-select1"  onblur ="ValidateRequired(this,'Covered Area');"></asp:TextBox>

                                                                                        
                                                                                        </div>
                                                                                   													                                                                                  
                                                          </div>
													       <div class="clearfix"></div>
													       <hr class="myhrline" />
													     <div class="form-group">
                                                                                     <div class="row">
															                            <label class="col-md-6 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                            Type Of Project :
															                            </label>
															                            <div class="col-md-6 col-sm-6 col-xs-6">
																                            
                                                                                             <asp:DropDownList ID="ddlTypeProject" runat="server"  CssClass="chosen margin-left-z input-sm similar-select1" >
                                                                                                 <asp:ListItem>--Select--</asp:ListItem>
                                                                                                  <asp:ListItem>New</asp:ListItem>
                                                                                                  <asp:ListItem>Existing</asp:ListItem>
                                                                                                 <asp:ListItem>Expansion</asp:ListItem>
                                                                                                 <asp:ListItem>Diversified</asp:ListItem>
                                                                                             </asp:DropDownList>
															                          
                                                                                        
                                                                                        </div>
														                            </div>
                                                                                   													                                                                                  
                                                          </div>
													       <div class="clearfix"></div>
													       <hr class="myhrline" />
                                                                               <div class="form-group">
                                                                                     <div class="row">
															                            <label class="col-md-6 col-sm-6 col-xs-6 text-right">                                                                                            
																                            Category Of Project :
															                            </label>
															                            <div class="col-md-6 col-sm-6 col-xs-6">
																                            
                                                                                             <asp:DropDownList ID="ddlCategoryProject" runat="server"  CssClass="chosen margin-left-z input-sm similar-select1" >
                                                                                                 <asp:ListItem>--Select--</asp:ListItem>
                                                                                                  <asp:ListItem>Warehousing Facility</asp:ListItem>
                                                                                                  <asp:ListItem>Silos Facility</asp:ListItem>
                                                                                                  <asp:ListItem>ColdChain Facility</asp:ListItem>
                                                                                                  <asp:ListItem>Container Freight Station or Inland Container Depot</asp:ListItem>                                                                                                 
                                                                                                  <asp:ListItem>Logistic Park</asp:ListItem>
                                                                                                  <asp:ListItem>Inland Vessel Waterway Facility</asp:ListItem>
                                                                                                  <asp:ListItem>Berthing Terminal Waterway Facility</asp:ListItem>
                                                                                                  <asp:ListItem>Cargo Terminals</asp:ListItem>
                                                                                                  <asp:ListItem>Truckers Park</asp:ListItem>
                                                                                             </asp:DropDownList>
															                          
                                                                                        
                                                                                        </div>
														                            </div>
                                                                                   													                                                                                  
                                                          </div>
                                                            <div class="clearfix"></div>
													       <hr class="myhrline" />
                                                                               <div class="form-group">
                                                                                     <div class="row">
															                            <label class="col-md-6 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                            Proposed date for completion :
															                            </label>
															                            <div class="col-md-6 col-sm-6 col-xs-6">                       
                                                                                                 <asp:TextBox ID="txtDateofCompletion" runat="server" CssClass="date input-sm similar-select1"  onblur ="ValidateRequired(this,'Proposed date for Completion');"></asp:TextBox>
                                                                                            
															                           </div>
														                            </div>
                                                                                   													                                                                                  
                                                          </div>

                                                                              <div class="clearfix"></div>
													       <hr class="myhrline" />
                                                                               <div class="form-group">
                                                                                     <div class="row">
															                            <label class="col-md-6 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                          <span style="font-size:11px;"> The date when capital investment has been started, or is proposed to be started :</span>
															                            </label>
															                            <div class="col-md-6 col-sm-6 col-xs-6">                       
                                                                                                 <asp:TextBox ID="txtDateCapitalInvestment" runat="server" CssClass="date input-sm similar-select1"  onblur ="ValidateRequired(this,'Proposed date for setting up PIP unit');"></asp:TextBox>
															                           </div>
														                            </div>
                                                                                   											                                                                                  
                                                          </div>
                                                                                <div class="clearfix"></div>
													       <hr class="myhrline" />
                                                                               <div class="form-group">
                                                                                     <div class="row">
															                            <label class="col-md-6 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                           Proposed Investment (In Cr) :
															                            </label>
															                            <div class="col-md-6 col-sm-6 col-xs-6">                       
                                                                                                 <i class="fa fa-inr"></i> <asp:TextBox ID="txtProposedInvestment" runat="server" CssClass="input-sm similar-select1" Width="98%"  onblur ="ValidateRequired(this,'Proposed date for setting up PIP unit');"></asp:TextBox>
															                           </div>
														                            </div>
                                                                                   													                                                                                  
                                                          </div>
                                                                        <div class="clearfix"></div>
													       <hr class="myhrline" />
                                                                               <div class="form-group">
                                                                                     <div class="row">
															                            <label class="col-md-6 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                           Project Details :
															                            </label>
															                           <div class="col-md-6 col-sm-6 col-xs-6">
																                            
                                                                                             <asp:DropDownList ID="ddlProjectDetails" runat="server"  CssClass="chosen margin-left-z input-sm similar-select1" AutoPostBack="True" OnSelectedIndexChanged="ddlProjectDetails_SelectedIndexChanged" >
                                                                                                 <asp:ListItem>--Select--</asp:ListItem>
                                                                                                   <asp:ListItem>Promoters Contribution</asp:ListItem>
                                                                                                  <asp:ListItem>Term Loan</asp:ListItem>
                                                                                                  <asp:ListItem>Subsidy from Govt</asp:ListItem>
                                                                                                   <asp:ListItem>Any Other</asp:ListItem>
                                                                                             </asp:DropDownList>
															                          
                                                                                        
                                                                                        </div>
														                            </div>
                                                                                   													                                                                                  
                                                          </div>

                                                                        <div class="clearfix"></div>
													       <hr class="myhrline" />
                                                                               <div class="form-group">
                                                                                     <div class="row">
															                            <label class="col-md-6 col-sm-6 col-xs-6 text-right">
                                                                                            <%--<span style="color: Red">*</span>--%>
																                           
															                            </label>
															                           <div class="col-md-6 col-sm-6 col-xs-6">
																                            
                                                                                           <asp:TextBox ID="txtAnyOther" runat="server" CssClass="input-sm similar-select1"  Visible="false"></asp:TextBox>
															                          
                                                                                        
                                                                                        </div>
														                            </div>
                                                                                   													                                                                                  
                                                          </div>
                                                           <div class="clearfix"></div>
													       <hr class="myhrline" />
                                                           <div style="display:none;">
                                                                               <div class="form-group">
                                                                                     <div class="row">
															                            <label class="col-md-6 col-sm-6 col-xs-6 text-right">
                                                                                         <span style="color: Red">*</span>
																                         Registration/Permit for setting PIP Unit :
															                            </label>
															                            <div class="col-md-6 col-sm-6 col-xs-6">                       
                                                                                          <asp:TextBox ID="txtPIPRegistrationNo" runat="server" CssClass="input-sm similar-select1" Width="98%"  onblur ="ValidateRequired(this,'Registration/Permit for setting PIP Unit');"></asp:TextBox>
															                           </div>
														                         </div>
                                                                                   													                                                                                  
                                                          </div>
													       <div class="clearfix"></div>
													       <hr class="myhrline" /></div>
                                                  <p class="panel-heading font-bold">Other Details</p>
                                                                        <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                             Distance from Railway Station(In KM):
															                            </label>
															                            <div class="col-md-2 col-sm-6 col-xs-6">
																                             <asp:TextBox ID="txtDistanceFromRailway" runat="server" CssClass="input-sm similar-select1" Width="93%" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Distance From Railway Station');"></asp:TextBox>
															                            </div>
                                                                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
														                    
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                            Proposed Total Direct Employment:
															                            </label>
															                            <div class="col-md-2 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtProposedDirectEmployment" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Proposed Total Direct Employment');"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
                                                           <div class="clearfix"></div>
													       <hr class="myhrline" />
                                                                             <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                             Distance from Bus Station(In KM):
															                            </label>
															                            <div class="col-md-2 col-sm-6 col-xs-6">
																                             <asp:TextBox ID="txtDistanceFromBus" runat="server" CssClass="input-sm similar-select1" Width="93%" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Cost of the Plant & Machinery');"></asp:TextBox>
															                            </div>
                                                                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
														                    
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                            Proposed Total Indirect Employment:
															                            </label>
															                            <div class="col-md-2 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtProposedIndirectEmployment" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Proposed Total Indirect Employment');"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
                                                                            
                                                                        <div class="clearfix"></div>
													       <hr class="myhrline" />
                                                                             <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                             Distance from Airport(In KM):
															                            </label>
															                            <div class="col-md-2 col-sm-6 col-xs-6">
																                             <asp:TextBox ID="txtDistanceFromAirport" runat="server" CssClass="input-sm similar-select1" Width="93%" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Distance from Airport');"></asp:TextBox>
															                            </div>
                                                                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
														                    
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                             
															                            </label>
															                            <div class="col-md-2 col-sm-6 col-xs-6">
 															                            </div>
														                            </div>
													                            </div>
                                                                        
                                                                         <div class="clearfix"></div>
													       <hr class="myhrline" />
                                                  <p class="panel-heading font-bold">Requested benefits by Applicant</p>

                                                                               <div class="form-group">
                                                                                     <div class="row">
															                            <label class="col-md-6 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                           Total Amount as requested by Applicant (In Cr) :
															                            </label>
															                            <div class="col-md-6 col-sm-6 col-xs-6">                       
                                                                                                 <i class="fa fa-inr"></i> <asp:TextBox ID="txtTotalAmountRequested" runat="server" CssClass="input-sm similar-select1" Width="98%"  onblur ="ValidateRequired(this,'Total Amount as requested by Applicant');"></asp:TextBox>
															                           </div>
														                            </div>
                                                                                   													                                                                                  
                                                                           </div>
													       <div class="clearfix"></div>
													       <hr class="myhrline" />
                                                                              <p class="panel-heading font-bold">Applicant Benefit Details</p>

                                                                               <div class="form-group">
                                                                                     <div class="row">
															                            <label class="col-md-6 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                           Exemption on Stamp Duty (In Cr) :
															                            </label>
															                            <div class="col-md-6 col-sm-6 col-xs-6">                       
                                                                                                 <i class="fa fa-inr"></i> <asp:TextBox ID="txtExemptionOnStamp" runat="server" CssClass="input-sm similar-select1" Width="98%"  ></asp:TextBox>
															                           </div>
														                            </div>
                                                                                   													                                                                                  
                                                                           </div>
													       <div class="clearfix"></div>
													       <hr class="myhrline" />
                                                                             <div class="form-group">
                                                                                     <div class="row">
															                            <label class="col-md-6 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                           Capital Subsidy on Eligible Fixed Capital Investment (In Cr):
															                            </label>
															                            <div class="col-md-6 col-sm-6 col-xs-6">                       
                                                                                                 <i class="fa fa-inr"></i> <asp:TextBox ID="txtSubsidyFixedCapitalInvestment" runat="server" CssClass="input-sm similar-select1" Width="98%"  ></asp:TextBox>
															                           </div>
														                            </div>
                                                                                   													                                                                                  
                                                                           </div>
													       <div class="clearfix"></div>
													       <hr class="myhrline" />
                                                                               <div class="form-group">
                                                                                     <div class="row">
															                            <label class="col-md-6 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red;">*</span>
																                          <span style="font-size:12px;"> 
                                                                                              Capital Subsidy on Cost of Building Hostel/Dormitory Housing (In Cr):</span>
															                            </label>
															                            <div class="col-md-6 col-sm-6 col-xs-6">                       
                                                                                                 <i class="fa fa-inr"></i> <asp:TextBox ID="txtSubsidyHostelDormitory" runat="server" CssClass="input-sm similar-select1" Width="98%"  ></asp:TextBox>
															                           </div>
														                            </div>
                                                                                   													                                                                                  
                                                                           </div>

													       <div class="clearfix"></div>
													       <hr class="myhrline" />
<div runat="server" id="Div1" class="col-md-12 col-sm-12 col-xs-12 text-center" ><asp:Button runat="server" ID="Button1" CssClass="btn btn-sm btn-primary" Text="Save & Proceed" Style="text-align:center;padding: 4px 10px !important;margin: 10px 0;" OnClientClick="return ccheck2();" OnClick="BtnProjectInsert_Click"/></div>
                                                        </asp:View>

                                                                    <asp:View runat="server" ID="View3">
                                                                        <div class="clearfix"></div>


<div runat="server" id="divLand">
    <div class="panel-heading text-center font-bold">Land Breakup Details</div>
    <div class="clearfix"></div>
    <div class="row">
        <div class="panel panel-default">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-5 col-sm-6 col-xs-6 text-right"><span style="color: Red">*</span> District :</label>
                        <div class="col-md-7 col-sm-6 col-xs-6">
                            <asp:DropDownList ID="ddlDistrict" runat="server"  CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" AutoPostBack="true"  ></asp:DropDownList>
                            <asp:TextBox ID="txtDistrict" runat="server" Visible="false" CssClass="similar-select1 input-sm" onblur="ValidateRequired(this,'District');"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-5 col-sm-6 col-xs-6 text-right"><span style="color: Red">*</span>Tehsil :</label>
                        <div class="col-md-7 col-sm-6 col-xs-6">
                            <asp:TextBox ID="txtTehsil" runat="server" CssClass="similar-select1 input-sm" onblur="ValidateRequired(this,'Tehsil');"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-5 col-sm-6 col-xs-6 text-right"><span style="color: Red">*</span>Village :</label>
                        <div class="col-md-7 col-sm-6 col-xs-6">
                            <asp:TextBox ID="txtVillage" runat="server" CssClass="similar-select1 input-sm" onblur="ValidateRequired(this,'Village');"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                        <span style="color: Red">*</span>
                        Land Deed Date :
                        </label>
                        <div class="col-md-7 col-sm-6 col-xs-6">
                            <asp:TextBox ID="txtLandDeedDate" runat="server" CssClass="similar-select1 input-sm date" onblur="ValidateRequired(this,'Land Deed Date');"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                <div class="row">
                <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                <span style="color: Red">*</span>
                Land Area (Hectare) :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                <asp:TextBox ID="txtLandArea" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Land Area');"></asp:TextBox>
                </div>
                </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                <div class="row">
                <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                <span style="color: Red">*</span>
                Khasra Number :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                <asp:TextBox ID="txtKhasraNo" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
                </div>
                </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                <div class="row">
                <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                <span style="color: Red">*</span>
                Value of land as per lease /purchase deed agreement (inr cr) :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                <asp:TextBox ID="txtValueOfLand" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Khasra Number');"></asp:TextBox>
                </div>
                </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                <div class="row">
                <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                <span style="color: Red">*</span>
                Stamp Duty Paid as per lease/purchase agreement (inr cr) :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                <asp:TextBox ID="txtStampDutyPaid" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Khasra Number');"></asp:TextBox>
                </div>
                </div>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                <div class="row">
                <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                <span style="color: Red">*</span>
                Existing Project area land Use and required change with status of land :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:DropDownList ID="ddlExistingLand" runat="server"  CssClass="chosen margin-left-z input-sm similar-select1" AutoPostBack="True" OnSelectedIndexChanged="ddlExistingLand_SelectedIndexChanged" >
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Agri</asp:ListItem>
                    <asp:ListItem>Industrial</asp:ListItem>
                    <asp:ListItem>residential</asp:ListItem>
                    <asp:ListItem>Purchased</asp:ListItem>
                    <asp:ListItem>To be purchased</asp:ListItem>
                    <asp:ListItem>Food Processing</asp:ListItem>
                    <asp:ListItem>IT & Electronics</asp:ListItem>
                    <asp:ListItem>Textiles</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>

                    <asp:TextBox ID="anyOtherExistingProject" runat="server" CssClass="input-sm similar-select1"  Visible="false"></asp:TextBox>
                    
                </div>

                </div>
                </div>
                </div>

                
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                <div class="row">
                <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                <span style="color: Red">*</span>
                Is Project area land contiguous :
                </label>
                <div class="col-md-2 col-sm-6 col-xs-6">
                <asp:DropDownList ID="ddlLandContiguous" runat="server"  CssClass="chosen margin-left-z input-sm similar-select1" AutoPostBack="True" OnSelectedIndexChanged="ddlLandContiguous_SelectedIndexChanged" >
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                                                    
                </asp:DropDownList>
                </div>

                <div class="col-md-5 col-sm-6 col-xs-6">
                <asp:TextBox ID="txtLandContiguous" runat="server" CssClass="similar-select1 input-sm" Visible="false"></asp:TextBox>

                </div>
                </div>
                </div>
                                  
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                <div class="row">
                <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                <span style="color: Red">*</span>
                Is there involvement of any gram sabha/ government land :
                </label>
                <div class="col-md-2 col-sm-6 col-xs-6">
                <asp:DropDownList ID="ddlGramGov" runat="server"  CssClass="chosen margin-left-z input-sm similar-select1" AutoPostBack="True" OnSelectedIndexChanged="ddlGramGov_SelectedIndexChanged" >
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                                                    
                </asp:DropDownList>
                </div>

                <div class="col-md-5 col-sm-6 col-xs-6">
                <asp:TextBox ID="txtGramGov" runat="server" CssClass="similar-select1 input-sm" Visible="false"></asp:TextBox>

                </div>
                </div>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                <div class="row">
                <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                <span style="color: Red">*</span>
                Requirement of Land Exchange :
                </label>
                <div class="col-md-2 col-sm-6 col-xs-6">
                <asp:DropDownList ID="ddlLandExchange" runat="server"  CssClass="chosen margin-left-z input-sm similar-select1" AutoPostBack="True" OnSelectedIndexChanged="ddlLandExchange_SelectedIndexChanged" >
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                                                    
                </asp:DropDownList>
                </div>

                <div class="col-md-5 col-sm-6 col-xs-6">
                <asp:TextBox ID="txtLandExchange" runat="server" CssClass="similar-select1 input-sm" Visible="false"></asp:TextBox>

                </div>
                </div>
                </div>
                                    
                                    
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                <div class="row">
                <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                Any Other Details :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                <asp:TextBox ID="txtPIPOtherDetails" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
                </div>
                </div>
                </div>

                <div class="clearfix"></div>
                <div runat="server" id="Div2" class="col-md-12 col-sm-12 col-xs-12 text-center" >
                    <asp:Button runat="server" ID="btnAddLandDetails" CssClass="btn btn-sm btn-primary" Text="Add Detail" Style="text-align:center;padding: 4px 10px !important;margin: 10px 0;" OnClientClick="return ccheck33();" OnClick="btnAddLandDetails_Click"  />&nbsp;<asp:Button runat="server" ID="btnClearLandDetails" CssClass="btn btn-sm btn-primary" Text="Clear" Style="text-align:center;padding: 4px 10px !important;margin: 10px 0;" OnClick="btnClearLandDetails_Click"  />

                </div>
                <asp:Label runat="server" ID="lblRecordID" Visible="false"></asp:Label>
            <div class="clearfix"></div>                                  
            <hr class="myhrline" />
        </div>
    </div>
</div>
</div>

                                    <div class="panel-heading text-center font-bold">Land Breakup Details Added</div>
                                    <div class="form-group">
                                    <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top:4px;">
                                            <asp:GridView ID="Grid_LandDetails" runat="server"
                                            CssClass="table table-striped table-bordered table-hover request-table"                              
                                            AutoGenerateColumns="False"
                                            ClientIDMode  ="Static"
                                            DataKeyNames  ="ID"
                                            GridLines="Horizontal"
                                            OnRowCommand="Grid_LandDetails_RowCommand"
                                            Width="100%" 
                                            PagerStyle-CssClass="pagination-ys" 
                                            PagerStyle-HorizontalAlign="Right">
                                            <Columns>
                                                 <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center"><ItemTemplate><asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                            
&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; 
                                                            &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; 
&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; 
                                                            </asp:Label></ItemTemplate></asp:TemplateField>

                                                <asp:BoundField DataField="District"           HeaderText = "District" />
                                                <asp:BoundField DataField="Tehsil"             HeaderText = "Tehsil" />
                                                <asp:BoundField DataField="Village"            HeaderText = "Village" />
                                                <asp:BoundField DataField="LandDeedDate"       HeaderText = "Land Deed Date" />
                                                <asp:BoundField DataField="LandArea"           HeaderText = "Land Area (In Hectare)"   />
                                                <asp:BoundField DataField="KhasraNumber"       HeaderText = "Khasra Number"   />
                                                <asp:BoundField DataField="LandValue"          HeaderText = "Value of land (inr cr)"   />
                                                <asp:BoundField DataField="StampDutyPaid"      HeaderText = "Stamp Duty Paid (inr cr)"   />
                                                
                                                <asp:BoundField DataField="ExistingLand"           HeaderText = "Existing Project area land Use" />
                                                <asp:BoundField DataField="anyOtherExistingProject"           HeaderText = "Other: Existing Project area land Use " />
                                                <asp:BoundField DataField="LandContiguousStatus"             HeaderText = "Project area land contiguous" />
                                                <asp:BoundField DataField="LandContiguous"             HeaderText = "Reason: Project area land contiguous" />
                                                <asp:BoundField DataField="GramGovStatus"            HeaderText = "Gram sabha/ government land Involvement" />
                                                <asp:BoundField DataField="GramGov"            HeaderText = "Reason: Gram sabha/ government land Involvement" />
                                                <asp:BoundField DataField="LandExchangeStatus"       HeaderText = "Requirement of Land Exchange" />
                                                <asp:BoundField DataField="LandExchange"       HeaderText = "Reason: Requirement of Land Exchange" />
                                                
                                                <asp:BoundField DataField="PIPOtherDetails"       HeaderText = "Other Details" />
                                                
                                                <asp:TemplateField HeaderText="Edit Record" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp"><ItemTemplate><asp:LinkButton runat="server" ID="btnEdit"  ToolTip="Edit Record" Text='<i class="fa fa-pencil-square-o" aria-hidden="true"></i>'  CommandName="EditRow" CausesValidation="false" CommandArgument='<%# (Container.DataItemIndex) %>' /></ItemTemplate></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete Record" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp"><ItemTemplate><asp:LinkButton runat="server" ID="btnDel"  ToolTip="Delete Record" Text='<i class="fa fa-times" aria-hidden="true"></i>'  CommandName="DeleteRow" CausesValidation="false" CommandArgument='<%# (Container.DataItemIndex) %>' /></ItemTemplate></asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                No Record Available
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                    </div>
            

        </div>
    </div>
</div>
                                    </asp:View>
                                    
                                                                    <asp:View runat="server" ID="View4">

                                         <div class="panel panel-default">
														                            <div class="panel-heading font-bold">
															                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                                            <span style="color: Red" class="">Please upload all document before final submission</span>
                                                                                            <%-- <asp:Panel ID="pnlDemo1" runat="server"> <div>Hello</div></asp:Panel>--%>
                                                                                        </div>
                                                           
                                                                                        <div class="clearfix"></div>
														                            </div>
													
                                     <%--<div class="row" style="margin-top:15px;">--%>

                     <div class="row" style="margin-top:15px;">
                     
                    <div class="text-left">
                         
        <%-- <asp:Button runat="server" Visible="false" ID="btnSample" Text="" OnClick="GetServiceChecklists_SP_BY_Condtion_Function" />  --%>    
                        <asp:HiddenField ID="hfName" runat="server" />
                        <ul class="nav nav-pills myul-tabs" style="margin-left:0;">
                            <asp:Panel ID="pnlDemo" runat="server">
                                <asp:LinkButton ID="LinkButton1" runat="server" Text="List of Documents for PIP" CssClass="font-bold sub_menu_active" OnClick="LinkButton1_Click"></asp:LinkButton>
                                <%--<asp:LinkButton ID="LinkButton2" runat="server" Text="For Applying 1st Stage 2022" CssClass="font-bold sub_menu_active" OnClick="LinkButton2_Click"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" Text="For Applying LOC 2022" CssClass="font-bold sub_menu_active" OnClick="LinkButton3_Click"></asp:LinkButton>
                                --%>
                 </asp:Panel>
                        </ul>

                    </div>
               </div>
               <%--</div>--%>
                                     
                                                                 <asp:GridView ID="GridView2" runat="server" 
                                                    CssClass="table table-striped table-bordered table-hover request-table"
                                                   
                                                    AutoGenerateColumns="False"
                                                    DataKeyNames="ServiceCheckListsID,DocumentID,Path"
                                                    GridLines="Horizontal" 
                                                    OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound"
                                                    Width="100%"
                                                    >
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center"><ItemTemplate><asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                                
&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; 
                                                                &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; 
&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; 
                                                                </asp:Label></ItemTemplate></asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Allottee ID" Visible="false"><HeaderStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Left" /><ItemTemplate><asp:Label runat="server" ID="lblServiceCheckLists" Text='<%#Eval("ServiceCheckListsID") %>'></asp:Label><asp:Label runat="server" ID="DocumentID"  Text='<%#Eval("DocumentID") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Allottee ID" Visible="false"><HeaderStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Left" /><ItemTemplate><asp:Label runat="server" ID="lblServiceTimeLines" Text='<%#Eval("ServiceTimeLinesID") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                                        <asp:BoundField DataField="ServiceTimeLinesCondition" HeaderText="Checklist" SortExpression="ServiceTimeLinesCondition" />
                                                        <asp:BoundField DataField="ServiceTimeLinesDocuments" HeaderText="Checklist Description" SortExpression="ServiceTimeLinesDocuments" />
                                                     
                                                        <asp:TemplateField HeaderText="Action"><HeaderStyle HorizontalAlign="Left" /><ItemStyle  /><ItemTemplate><span class="col-md-10"><asp:FileUpload ID="FileUpload4" runat="server" /></span><span class="col-md-2"><asp:LinkButton ID="imgdocuments" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="Upload" Text='<i class="fa fa-upload"></i>' /></span></ItemTemplate></asp:TemplateField>
                                                       <asp:TemplateField ItemStyle-Width="8%"><HeaderStyle /><HeaderTemplate><asp:Label ID="hlblimg" runat="server" Text=""></asp:Label></HeaderTemplate><ItemTemplate><asp:LinkButton ID="lbView"     runat="server"  CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument"  usesubmitbehavior="true" Text='' ><i class="fa fa-download" aria-hidden="true"></i></asp:LinkButton>/ <asp:LinkButton ID="lbView1"    runat="server"  CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument"    usesubmitbehavior="true"  Text =''><i class="fa fa-file-pdf-o" aria-hidden="true"></i></asp:LinkButton></ItemTemplate></asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        No Record Available
                                                    </EmptyDataTemplate>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle Font-Bold="True" ForeColor="Black" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <RowStyle ForeColor="#000066" HorizontalAlign="Left" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
                                                <asp:Label ID="DocDisable" runat="server" Visible="false"></asp:Label>                                                               
                                                                
                                                             
                                 <%--  <div class="clearfix"></div>--%>
                                             <%--<div runat="server" id="div_final">--%>
                                             <div></div>
                                <div class="form-group" style="margin-top:10px;">
                                    <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                       <asp:Label runat="server" ID="lblmsgDoc" Visible="false" style="color: Red" Text="Please check Uploaded Documents in Final Form."></asp:Label>      
                                        <br />
                                        <asp:CheckBox
                                            ID="Conform_CheckBox_multiview_1"
                                            runat="server"
                                            Text=" &nbsp;&nbsp;I hereby certify that i am authorised by the Company/SPV/Association/Society/Trust/LLP to file and submit the documents and records under my signature. This is also to certify that above records are true and correct to the best of my knowledge and belief. I have gone through Private Industrial Parks Policy and its rule where Terms & Conditions have been enumerated and I hereby give my consent to fulfill all the Terms & Conditions of the policy."                                       
                                            Font-Names="Serif"
                                            Font-Size="14px" />

                                        <asp:Button ID="btnDocConfirm" runat="server" CssClass="btn btn-sm btn-primary" Visible="true" Text="Accept" Style="text-align:center;padding: 4px 10px !important;margin: 10px 0;" OnClick="btnDocConfirm_Click"/>
                                            
                                    </div>
                                </div>
                                       
                                <div class="clearfix"></div>
                                      
</div>
                                                   </asp:View>      
                                                                                   
                                                                                    
                                                                    <asp:View runat="server">

                                       <div class="form-group">
                                    <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                        
                                    </div>
                                </div>
                                      <asp:Button runat="server" ID="btn_final"  Visible="false" Text="Final Submit" CssClass="btn btn-info" OnClick="btn_final_Click" />

                                       <asp:Button ID="btnPrint" runat="server" Text="Print" Style="margin: 6px 2px;" OnClientClick="PrintElemF()" CssClass="btn-primary btn-sm ey-bg pull-right" />
                                       <div class="clearfix"></div>
                                       <div id="FinalPrint">
                                        <asp:PlaceHolder ID="PH_FinalView" runat="server"></asp:PlaceHolder>
                                      </div>
                                      <div class="clearfix"></div>
                                     

                                    </asp:View>
                                                                  
                                                                    <asp:View runat="server" ID="ObjectionView">
                                      <div class="clearfix"></div>
                                     <div id="Objection_Div">
                                        <asp:PlaceHolder ID="PH_Objection" runat="server"></asp:PlaceHolder>
                                     </div>
                                     <div class="clearfix"></div>
                                     <div class="text-center">


                                   </div>
                                 </asp:View>

                                                                 <asp:View runat="server" ID="PaymentView">

                                                                     <div style="background: #e2e2e2; text-align: right; padding: 10px 0; border: 1px solid #cacaca;">
                                                        <asp:Button runat="server" Style="background: #ffc511; border: 1px solid #ccc; color: #000; font-size: 14px;" ID="btnPay" Text="Pay Now" CssClass="btn btn-sm btn-primary" OnClick="btnPay_Click" />

                                                    </div>
                                      <div class="clearfix"></div>
                                     <div id="Payment_div" runat="server">

                                         <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div  id="DivP" style="text-align: center;padding: 15px 25px; margin: 25px 10%;background: #fbfbfb;border: 1px solid #ccc;">
                <div class="div-report" runat="server"  style="text-align: center;">                 
	                <img src = "images/upsidclogo.png" class="header-logo" style="border-top:none;height: 40px;margin-bottom:0;" /><br>
	                <strong>U.P. STATE INDUSTRIAL DEVELOPMENT CORPORATION LIMITED, KANPUR<br>
	                (Head Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024)</strong><br /><br /><div style = "border-top:3px solid #ffc511;">&nbsp;</div>
                                        <%--<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>--%>
                                          <span class="pull-right font-bold"><asp:Label ID="lblPayDateD" runat="server" ></asp:Label></span><br/><h2 style = "text-decoration:underline;" >  Statement of Estimated Deposits</h2><br/>
                              <div class='col- md-6'>
                                  <table class="table-bordered pull-left" width="100%" style="Font-Size:12px;">
                                    <tr> 
                                     <th style='background:#f7f7f7;'>Application Reference Number</th><td class='text-left'><asp:Label ID="lblSERviceNo" runat="server" Text="Label"></asp:Label></td>
                                     <th style='background:#f7f7f7;'>  </th><td class='text-left'> </td></tr>
                                     <tr> <th>Applied in the name of </th><td class='text-left'><asp:Label ID="lblAName" runat="server" ></asp:Label></td>
                                     <th style='background:#f7f7f7;'> Address </th><td class='text-left'><asp:Label ID="lblPAddress" runat="server" ></asp:Label></td></tr>
                                     <tr> <th> Payment Mode </th><td class='text-left'><asp:Label ID="lblPMode" runat="server" ></asp:Label></td>
                                     <th style='background:#f7f7f7;'> Transaction Ref No </th><td class='text-left'><asp:Label ID="lblTransactionNo" runat="server" ></asp:Label></td></tr>
                                     <tr> <th> Payment Received Date </th><td class='text-left'><asp:Label ID="lblPayDate" runat="server" ></asp:Label></td>
                                     <th style='background:#f7f7f7;'> Payment Status </th><td class='text-left'><asp:Label ID="lblPaystatus" runat="server" ></asp:Label></td></tr>
                               </table></div><br/><br/><br/><br/>
                                 
                                  
                                     <div class='row'><label class="col-md-12 col-sm-12 col-xs-12 text-center" style='border-top:dashed'> </label></div>
                                    <br/>
                        <div class='col- md-6'><table class="table-bordered pull-right" width="41%" style="Font-Size:12px;">                                 
                                    <tr style = 'background:#f7f7f7;'>
                                    <th>Applicable Fees</th><th class='text-center'><i class='fa fa-inr'></i>10000</th></tr>

                                 <tr style = 'background:#f7f7f7;'><th> Total Applicable Charges </th><th class='text-center'><i class='fa fa-inr'></i>11800</th>
                                    </tr>
                                </table></div><br /><br/><br/>
                    
                        <table class="table table-bordered table-hover request-table">
                        
                            <tr style = 'background:#f7f7f7;'>
                                <th> S.NO </th>
                                <th> Description </th>
                                <th class="text-center">Amount</th>
                            </tr>
                               <tr><td colspan="3">A. Applicable Fees</td></tr> <tr> <td class='text-center'> 1 </td> <td class='text-center'> Processing Fess Against Application for Issuance of Unique Id for Private Industrial Parks </td> <td class='text-center'> 10000</td> </tr>  <tr> <td class='text-center'> 2 </td> <td class='text-center'> GST 18% </td> <td class='text-center'> 1800</td> </tr> 

                              <tr><td colspan="2" class='text-center'>Total Applicable Fees</th><th class='text-left'><i class='fa fa-inr'></i>10000</td></tr>
                              <tr><th colspan="2" class='text-center'> Total Payable</th><th class='text-left'><i class='fa fa-inr'></i>11800</th></tr> </table>

                                     </div>
                                     <div class="clearfix"></div>
                                     <div class="text-center">


                                   </div>
                <div style = "border-top:3px solid #ffc511;">&nbsp;</div> <br>
                   <%-- <strong>Note-Time Extension fee will be Applicable as per the Prevailing Policy Separate Demand will be only vaild <br>
                        after Payment of Demanded Time Extension fee <br /><br />
                    </strong>--%>

                </div>
            </div>
        </div>
    </div>

                                 </asp:View>

                                                                    <asp:View runat="server" ID="View5">
                                                                        <div class="clearfix"></div>
                                    <div class="panel-heading text-center font-bold">Migration Details</div>
                                   <div class="clearfix"></div>
                                   <div class="row">
                                   <div class="panel panel-default">
                                   <div class="col-md-12 col-sm-12 col-xs-12">
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                    Project Identification No. (PIN Number Allotted by Warehouse Portal/ Online Application  :
                                    </label>
                                    <div class="col-md-7 col-sm-6 col-xs-6">
                                    <asp:TextBox ID="txtProjectIden" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>
                                    </div>
                                    </div>
                                    </div>
                                    <div class="panel-heading text-center font-bol">Detail of Regulatory Approvals received from Govt. of UP</div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                   <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                    Name of Clearance :
                                    </label>
                                    <div class="col-md-7 col-sm-6 col-xs-6">
                                    <asp:TextBox ID="txtNameClear" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>
                                    </div>
                                    </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                    Date of Clearance :
                                    </label>
                                    <div class="col-md-7 col-sm-6 col-xs-6">
                                    <asp:TextBox ID="txtDateClear" runat="server" CssClass="date input-sm similar-select1" placeholder="dd/MM/yyyy"></asp:TextBox>
                                    </div>
                                    </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                    Details of Incentives availed under UP WL Policy 2018 :
                                    </label>
                                    <div class="col-md-7 col-sm-6 col-xs-6">
                                    <asp:TextBox ID="txtIncentives" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>
                                    </div>
                                    </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                    Present Implementation Status :
                                    </label>
                                    <div class="col-md-7 col-sm-6 col-xs-6">
                                    <asp:TextBox ID="txtImplementation" runat="server" CssClass="similar-select1 input-sm"  ></asp:TextBox>
                                    </div>
                                    </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                    Date of Commencement Production/ Activity (estimated) :
                                    </label>
                                    <div class="col-md-7 col-sm-6 col-xs-6">
                                    <asp:TextBox ID="txtDateCommence" runat="server" CssClass="date input-sm similar-select1"  placeholder="dd/MM/yyyy" ></asp:TextBox>
                                    </div>
                                    </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-center">
                                    <%--<span style="color: Red">*</span>--%>
                                     Fixed Capital Investment (in Crore) 
                                    </label>
                                    <label class="col-md-3 col-sm-6 col-xs-6 text-center">
                                   <%-- <span style="color: Red">*</span>--%>
                                     As per DPR
                                    </label>
                                        <label class="col-md-4 col-sm-6 col-xs-6 text-center">
                                   <%-- <span style="color: Red">*</span>--%>
                                     Actual Expenditure Incurred (till date)
                                    </label>
                                    </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                     LAND :
                                    </label>
                                   <div class="col-md-3 col-sm-6 col-xs-6">
                                    <i class="fa fa-inr"></i><asp:TextBox ID="txtLandDPR" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="96%"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-6 col-xs-6">
                                    <i class="fa fa-inr"></i><asp:TextBox ID="txtLandAEI" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="98%"></asp:TextBox>
                                    </div>
                                    </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                     BUILDING  :
                                    </label>
                                     <div class="col-md-3 col-sm-6 col-xs-6">
                                    <i class="fa fa-inr"></i><asp:TextBox ID="txtBUILDINGDPR" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="96%"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-6 col-xs-6">
                                    <i class="fa fa-inr"></i><asp:TextBox ID="txtBUILDINGAEI" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="98%"></asp:TextBox>
                                    </div>
                                    </div>
                                    </div>

                                  <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                    PLANT & MACHINERY :
                                    </label>
                                    <div class="col-md-3 col-sm-6 col-xs-6">
                                    <i class="fa fa-inr"></i><asp:TextBox ID="txtPLANTDPR" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="96%"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-6 col-xs-6">
                                    <i class="fa fa-inr"></i><asp:TextBox ID="txtPLANTAEI" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="98%"></asp:TextBox>
                                    </div>
                                    </div>
                                    </div>
                                  
                                   <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                    OTHERS  :
                                    </label>
                                    <div class="col-md-3 col-sm-6 col-xs-6">
                                    <i class="fa fa-inr"></i><asp:TextBox ID="txtOTHERSDPR" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="96%"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-6 col-xs-6">
                                    <i class="fa fa-inr"></i><asp:TextBox ID="txtOTHERSAEI" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="98%"></asp:TextBox>
                                    </div>
                                    </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                       TOTAL  :
                                    </label>
                                    <div class="col-md-3 col-sm-6 col-xs-6">
                                    <i class="fa fa-inr"></i><asp:TextBox ID="txtTOTALDPR" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="96%"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-6 col-xs-6">
                                    <i class="fa fa-inr"></i><asp:TextBox ID="txtTOTALAEI" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="98%"></asp:TextBox>
                                    </div>
                                    </div>
                                    </div>


                                   <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                       Means of Finance  :
                                    </label>
                                     

                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                       <asp:TextBox ID="txtMeansFinance" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>

                                    </div>
                                    </div>
                                    </div>

                                   <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                      Reasons for Migration to New WL Policy 2022  :
                                    </label>
                                    

                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                       <asp:TextBox ID="txtReasonsMigration" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>

                                    </div>
                                    </div>
                                    </div>


                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                      Do you want to migrate from WL Policy 2018 to WL Policy 2022?  :
                                    </label>
                                     

                                        <div class="col-md-7 col-sm-6 col-xs-6">
<%--                                       <asp:TextBox ID="TextBox14" runat="server" CssClass="similar-select1 input-sm" Visible="false"></asp:TextBox>--%>
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                            </asp:RadioButtonList>
                                    </div>
                                    </div>
                                    </div>


                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-12 col-sm-6 col-xs-6 text-right">
                                   <%-- <span style="color: Red">*</span>--%>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Visible="false" /><asp:Label ID="lblcheck" Visible="False" runat="server" Text="I consent to migrate to WL Policy 2022 and certify that the information and documents uploaded are correct and to the best of my knowledge."></asp:Label>
                                    </label>
                                    <%--<div class="col-md-2 col-sm-6 col-xs-6">
                                    
                                    </div>--%>

                                        <%--<div class="col-md-5 col-sm-6 col-xs-6">
                                       <asp:TextBox ID="TextBox15" runat="server" CssClass="similar-select1 input-sm" Visible="false"></asp:TextBox>

                                    </div>--%>
                                    </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                      Place  :
                                    </label>
                                     

                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                       <asp:TextBox ID="txtPlace" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>

                                    </div>
                                    </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                      Date  :
                                    </label>
                                    

                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                        <asp:TextBox ID="txtDates" runat="server" CssClass="date input-sm similar-select1" placeholder="dd/MM/yyyy" ></asp:TextBox>

                                    </div>
                                    </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                    <div class="row">
                                    <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                      Signature of the Authorized Person (along with seal of the company)  :
                                    </label>
                                     

                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                      <asp:FileUpload ID="FileUploadSignature" Width="100%"   CssClass="form-control" runat="server" />

                                    </div>
                                    </div>
                                    </div>


                                    <div class="clearfix"></div>
                                    <div runat="server" id="Div3" class="col-md-12 col-sm-12 col-xs-12 text-center" >
                                        <asp:Button runat="server" ID="btnConfirm" CssClass="btn btn-sm btn-primary" Text="Confirm and Save" Style="text-align:center;padding: 4px 10px !important;margin: 10px 0;"   OnClick="btnConfirm_Click"  />
                                        <%--&nbsp;<asp:Button runat="server" ID="ButtonClear" CssClass="btn btn-sm btn-primary" Text="Clear" Style="text-align:center;padding: 4px 10px !important;margin: 10px 0;" OnClientClick="return ccheck33();" OnClick="ButtonClear_Click"  /></div>--%>
                                    <asp:Label runat="server" ID="Label1" Visible="false"></asp:Label>
                                   <%-- <div class="clearfix"></div>                                  
                                    <hr class="myhrline" />
                                    <div class="panel-heading text-center font-bold">Land Breakup Details Added</div>--%>
                                     
            

        </div>
    </div>
</div>
                                    </asp:View>

                                                             </asp:MultiView>
                                  <asp:Label runat="server" ID="lblIAID" Visible="false" ></asp:Label>
                                                        </div>
                                                </div>
                                
                               
                            </div>
                        </div>
                    </div>
                </div>
              </div>
               </ContentTemplate></asp:UpdatePanel>
        
    </form>



    
  

   
    <script>

         function AKS() {


             $("#btnCloseModal").click();

         }

         var prm = Sys.WebForms.PageRequestManager.getInstance();
         prm.add_endRequest(function () {
             function AKS() {

                 
                 $("#btnCloseModal").click();

             }
         });

         function CloseModal() {
             $("#btnCloseModal").click();
         }

         function Redirect(parameter) {
            
             window.location.href = 'LandAllottmentApplication.aspx?ServiceReqNo=' + parameter;

         }

         function showError() {
             if (document.getElementById("<%= divMessageError.ClientID %>").style.display == 'none') {
                document.getElementById("<%= divMessageError.ClientID %>").style.display = 'block';

             }

         }
         function hideError() {
             if (document.getElementById("<%= divMessageError.ClientID %>").style.display == 'block') {
                document.getElementById("<%= divMessageError.ClientID %>").style.display = 'none';
            }
            return false;
        }   


            function validatepan() {

             var panVal = document.getElementById("<%= txtPanNo.ClientID %>").value;
             var lblMessageError = document.getElementById("<%= lblMessageError.ClientID %>");
             var regpan = /^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$/;
             if (panVal.length > 0) {
                 if (panVal != "") {
                     if (regpan.test(panVal)) {
                         document.getElementById("<%= txtPanNo.ClientID %>").style.borderColor = "";
                        hideError();
                        return true;
                    } else {

                        document.getElementById("<%= txtPanNo.ClientID %>").style.borderColor = "Red";
                        document.getElementById("<%= txtPanNo.ClientID %>").value = "";
                       document.getElementById("<%= txtPanNo.ClientID %>").focus();
                       showError();
                       document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Invalid Pan Card";
                       return false;
                    }
                }
            } else {
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Pan Card Is Required Field";
                document.getElementById("<%= txtPanNo.ClientID %>").style.borderColor = "Red";

               document.getElementById("<%= txtPanNo.ClientID %>").focus();
               return false;
            }
            }

        function validateGST() {

             var gstVal = document.getElementById("<%= txtGstNo.ClientID %>").value;
             var lblMessageError = document.getElementById("<%= lblMessageError.ClientID %>");
             var reggst = /^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$/;
             if (gstVal.length > 0) {
                 if (gstVal != "") {
                     if (reggst.test(gstVal)) {
                         document.getElementById("<%= txtGstNo.ClientID %>").style.borderColor = "";
                        hideError();
                        return true;
                    } else {

                        document.getElementById("<%= txtGstNo.ClientID %>").style.borderColor = "Red";
                        document.getElementById("<%= txtGstNo.ClientID %>").value = "";
                       document.getElementById("<%= txtGstNo.ClientID %>").focus();
                       showError();
                       document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Invalid GST No";
                       return false;
                    }
                }
            } else {
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "GST NO Is Required Field";
                document.getElementById("<%= txtGstNo.ClientID %>").style.borderColor = "Red";

               document.getElementById("<%= txtGstNo.ClientID %>").focus();
               return false;
            }
        }


            function Validatephone()
         {

         }
            function ccheck1() {
             var remark = true;

             var txtAadharNo = document.getElementById("<%= txtApplicantAadhar.ClientID %>"); 
             var txtAddress         = document.getElementById("<%= txtApplicantAddress.ClientID %>");
             var txtCompanyname     = document.getElementById("<%= txtCompanyname.ClientID %>");
             var txtFirmAddress = document.getElementById("<%= txtFirmAddress.ClientID %>");
             var txtPanNo           = document.getElementById("<%= txtPanNo.ClientID %>");
             var txtGstNo = document.getElementById("<%= txtGstNo.ClientID %>");
             var txtProposedPIP = document.getElementById("<%= txtProposedPIP.ClientID %>");
             var txtProjectLocation = document.getElementById("<%= txtProjectLocation.ClientID %>");
             var ddlcompany = document.getElementById("<%= ddlcompanytype.ClientID %>");
             var drpRegionPIP = document.getElementById("<%= drpRegionPIP.ClientID %>");

            if (txtAadharNo.value.length <= 0) {
                txtAadharNo.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAadharNo.style.borderColor = "";
            }

            if (txtAddress.value.length <= 0) {
                txtAddress.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAddress.style.borderColor = "";
            }

             if (txtCompanyname.value.length <= 0) {
                 txtCompanyname.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtCompanyname.style.borderColor = "";
             }
             
             if (txtFirmAddress.value.length <= 0) {
                 txtFirmAddress.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtFirmAddress.style.borderColor = "";
             }
            
             if (txtPanNo.value.length <= 0) {
                 txtPanNo.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtPanNo.style.borderColor = "";
             }

             if (txtGstNo.value.length <= 0) {
                 txtGstNo.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtGstNo.style.borderColor = "";
             }

             if (txtProposedPIP.value.length <= 0) {
                 txtProposedPIP.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtProposedPIP.style.borderColor = "";
             }

             if (txtProjectLocation.value.length <= 0) {
                 txtProjectLocation.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtProjectLocation.style.borderColor = "";
             }

             if (ddlcompany.selectedIndex == 0) {
                 ddlcompany.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 ddlcompany.style.borderColor = "";
             }

             if (drpRegionPIP.selectedIndex == 0) {
                 drpRegionPIP.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 drpRegionPIP.style.borderColor = "";
             }
            
            
             if (remark == false) {

                 alert("Fill All Required Field");
                 showError();
                 document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

              return false;
             } else {
                 hideError();
                 return true;
             }

        }

        function ccheck2() {
            var remark = true;

            var txtTotalArea = document.getElementById("<%= txtTotalArea.ClientID %>");
            var txtCoveredArea = document.getElementById("<%= txtCoveredArea.ClientID %>");
            var ddlTypeProject = document.getElementById("<%= ddlTypeProject.ClientID %>");
            var txtDateofCompletion = document.getElementById("<%= txtDateofCompletion.ClientID %>");
            var txtDateCapitalInvestment = document.getElementById("<%= txtDateCapitalInvestment.ClientID %>");
            var txtProposedInvestment = document.getElementById("<%= txtProposedInvestment.ClientID %>");
            var ddlProjectDetails = document.getElementById("<%= ddlProjectDetails.ClientID %>");
            var txtDistanceFromRailway = document.getElementById("<%= txtDistanceFromRailway.ClientID %>");
            var txtProposedDirectEmployment = document.getElementById("<%= txtProposedDirectEmployment.ClientID %>");
            var txtDistanceFromBus = document.getElementById("<%= txtDistanceFromBus.ClientID %>");
            var txtProposedIndirectEmployment = document.getElementById("<%= txtProposedIndirectEmployment.ClientID %>");
            var txtDistanceFromAirport = document.getElementById("<%= txtDistanceFromAirport.ClientID %>");
            var txtTotalAmountRequested = document.getElementById("<%= txtTotalAmountRequested.ClientID %>");
            var txtExemptionOnStamp = document.getElementById("<%= txtExemptionOnStamp.ClientID %>");
            var txtSubsidyFixedCapitalInvestment = document.getElementById("<%= txtSubsidyFixedCapitalInvestment.ClientID %>");
            var txtSubsidyHostelDormitory = document.getElementById("<%= txtSubsidyHostelDormitory.ClientID %>");
                        
            if (txtTotalArea.value.length <= 0) { txtTotalArea.style.borderColor = '#e52213'; remark = false; } else { txtTotalArea.style.borderColor = ""; }
            if (txtCoveredArea.value.length <= 0) { txtCoveredArea.style.borderColor = '#e52213'; remark = false; } else { txtCoveredArea.style.borderColor = ""; }
            if (ddlTypeProject.value == '--Select--') { ddlTypeProject.style.borderColor = '#e52213'; remark = false; } else { ddlTypeProject.style.borderColor = ""; }
            if (txtDateofCompletion.value.length <= 0) { txtDateofCompletion.style.borderColor = '#e52213'; remark = false; } else { txtDateofCompletion.style.borderColor = ""; }
            if (txtDateCapitalInvestment.value.length <= 0) { txtDateCapitalInvestment.style.borderColor = '#e52213'; remark = false; } else { txtDateCapitalInvestment.style.borderColor = ""; }
            if (txtProposedInvestment.value.length <= 0) { txtProposedInvestment.style.borderColor = '#e52213'; remark = false; } else { txtProposedInvestment.style.borderColor = ""; }
            if (ddlProjectDetails.value == '--Select--') { ddlProjectDetails.style.borderColor = '#e52213'; remark = false; } else { ddlProjectDetails.style.borderColor = ""; }
            if (txtDistanceFromRailway.value.length <= 0) { txtDistanceFromRailway.style.borderColor = '#e52213'; remark = false; } else { txtDistanceFromRailway.style.borderColor = ""; }
            if (txtProposedDirectEmployment.value.length <= 0) { txtProposedDirectEmployment.style.borderColor = '#e52213'; remark = false; } else { txtProposedDirectEmployment.style.borderColor = ""; }
            if (txtDistanceFromBus.value.length <= 0) { txtDistanceFromBus.style.borderColor = '#e52213'; remark = false; } else { txtDistanceFromBus.style.borderColor = ""; }
            if (txtProposedIndirectEmployment.value.length <= 0) { txtProposedIndirectEmployment.style.borderColor = '#e52213'; remark = false; } else { txtProposedIndirectEmployment.style.borderColor = ""; }
            if (txtDistanceFromAirport.value.length <= 0) { txtDistanceFromAirport.style.borderColor = '#e52213'; remark = false; } else { txtDistanceFromAirport.style.borderColor = ""; }
            if (txtTotalAmountRequested.value.length <= 0) { txtTotalAmountRequested.style.borderColor = '#e52213'; remark = false; } else { txtTotalAmountRequested.style.borderColor = ""; }
            if (txtExemptionOnStamp.value.length <= 0) { txtExemptionOnStamp.style.borderColor = '#e52213'; remark = false; } else { txtExemptionOnStamp.style.borderColor = ""; }
            if (txtSubsidyFixedCapitalInvestment.value.length <= 0) { txtSubsidyFixedCapitalInvestment.style.borderColor = '#e52213'; remark = false; } else { txtSubsidyFixedCapitalInvestment.style.borderColor = ""; }
            if (txtSubsidyHostelDormitory.value.length <= 0) { txtSubsidyHostelDormitory.style.borderColor = '#e52213'; remark = false; } else { txtSubsidyHostelDormitory.style.borderColor = ""; }

            



                if (remark == false) {


                    alert("Fill All Required Field");
                    showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

                return false;
            }
            else {
                hideError();
                return true;
            }


        }
        function ccheck33() {



            var remark = true;
            var ddlDistrict = document.getElementById("<%= ddlDistrict.ClientID %>");
            var txtTehsil                             = document.getElementById("<%= txtTehsil.ClientID %>");
            var txtVillage = document.getElementById("<%= txtVillage.ClientID %>");
            var txtLandDeedDate = document.getElementById("<%= txtLandDeedDate.ClientID %>");
            var txtLandArea = document.getElementById("<%= txtLandArea.ClientID %>");
            var txtKhasraNo                           = document.getElementById("<%= txtKhasraNo.ClientID %>");
            var txtValueOfLand = document.getElementById("<%= txtValueOfLand.ClientID %>");
            var txtStampDutyPaid                      = document.getElementById("<%= txtStampDutyPaid.ClientID %>");

            var ddlExistingLand = document.getElementById("<%= ddlExistingLand.ClientID %>");
            var ddlLandContiguous = document.getElementById("<%= ddlLandContiguous.ClientID %>");
            var ddlGramGov = document.getElementById("<%= ddlGramGov.ClientID %>");
            var ddlLandExchange = document.getElementById("<%= ddlLandExchange.ClientID %>");
            
            if (ddlDistrict.value.length <= 0) { ddlDistrict.style.borderColor = '#e52213'; remark = false; } else { ddlDistrict.style.borderColor = ""; }
            if (txtTehsil.value.length <= 0) { txtTehsil.style.borderColor = '#e52213'; remark = false; } else { txtTehsil.style.borderColor = ""; }
            if (txtVillage.value.length <= 0) { txtVillage.style.borderColor = '#e52213'; remark = false; } else { txtVillage.style.borderColor = ""; }
            if (txtLandDeedDate.value.length <= 0) { txtLandDeedDate.style.borderColor = '#e52213'; remark = false; } else { txtLandDeedDate.style.borderColor = ""; }
            if (txtLandArea.value.length <= 0) { txtLandArea.style.borderColor = '#e52213'; remark = false; } else { txtLandArea.style.borderColor = ""; }
            if (txtKhasraNo.value.length <= 0) { txtKhasraNo.style.borderColor = '#e52213'; remark = false; } else { txtKhasraNo.style.borderColor = ""; }
            if (txtValueOfLand.value.length <= 0) { txtValueOfLand.style.borderColor = '#e52213'; remark = false; } else { txtValueOfLand.style.borderColor = ""; }
            if (txtStampDutyPaid.value.length <= 0) { txtStampDutyPaid.style.borderColor = '#e52213'; remark = false; } else { txtStampDutyPaid.style.borderColor = ""; }
            if (ddlExistingLand.length <= 0) { ddlExistingLand.style.borderColor = '#e52213'; remark = false; } else { ddlExistingLand.style.borderColor = ""; }
            if (ddlLandContiguous.value.length <= 0) { ddlLandContiguous.style.borderColor = '#e52213'; remark = false; } else { ddlLandContiguous.style.borderColor = ""; }
            if (ddlGramGov.value.length <= 0) { ddlGramGov.style.borderColor = '#e52213'; remark = false; } else { ddlGramGov.style.borderColor = ""; }
            if (ddlLandExchange.value.length <= 0) { ddlLandExchange.style.borderColor = '#e52213'; remark = false; } else { ddlLandExchange.style.borderColor = ""; }

            
                 if (remark == false) {


                    alert("Fill All Required Field");
                    showError();
                 document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

                 return false;
             }
             else {
                 hideError();
                 return true;
             }


         }


            function IsValidEmail(email) {
             var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
             return expr.test(email);
         };      
            function ValidateShareHolderEmail() {
            var email = document.getElementById('<%=((TextBox)gridshareholder.FooterRow.FindControl("txtEmail_insert")).ClientID %>');

            if (email.value.length > 0) {
                if (!IsValidEmail(email.value)) {

                    email.value = "";
                    email.style.borderColor = '#e52213';
                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Invalid Email Id";
                    email.focus();
                    return false;
                }
                else {

                    email.style.borderColor = "";
                    hideError();
                    email.innerText = "";

                    return true;
                }
            }
        }
            function ValidatePartnerEmail() {
            var email = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnerEmail_insert")).ClientID %>');

            if (email.value.length > 0) {
                if (!IsValidEmail(email.value)) {

                    email.value = "";
                    email.style.borderColor = '#e52213';
                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Invalid Email Id";
                        return false;

                }
                else {

                    email.style.borderColor = "";
                    hideError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "";
                        return true;
                }

            }
            
        }
            function ValidateTrusteeEmail() {
            var email = document.getElementById('<%=((TextBox)Trustee_details_grid.FooterRow.FindControl("txttEmail_insert")).ClientID %>');


            if (email.value.length > 0) {
                if (!IsValidEmail(email.value)) {

                    email.value = "";
                    email.style.borderColor = '#e52213';
                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Invalid Email Id";
                    return false;

                }
                else {

                    email.style.borderColor = "";
                    hideError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "";
                    return true;
                }

            }
        }
            function ValidateDirectorEmail() {
            var email = document.getElementById('<%=((TextBox)DirectorsGrid.FooterRow.FindControl("txtDirectorEmail_insert")).ClientID %>');


            if (email.value.length > 0) {
                if (!IsValidEmail(email.value)) {

                    email.value = "";
                    email.style.borderColor = '#e52213';
                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Invalid Email Id";
                    return false;

                }
                else {

                    email.style.borderColor = "";
                    hideError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "";
                    return true;
                    }

                }

            }
         
            function validate_shareper(evt) {
                var charCode = (evt.which) ? evt.which : evt.keyCode
                if (charCode != 46 && charCode > 31
                    && (charCode < 48 || charCode > 57)) {
                    return false;
                } else {

                    var txt = document.getElementById('<%#((TextBox)gridshareholder.FooterRow.FindControl("txtShareper_insert")).ClientID %>');

                    if (txt.value.length > 0) {

                        txt.style.borderColor = "";
                        return true;

                    }
                }
            }
            function isDecimalKey(evt) {
                var charCode = (evt.which) ? evt.which : evt.keyCode
                if (charCode != 46 && charCode > 31
                    && (charCode < 48 || charCode > 57)) {
                    return false;
                } else {


                }
            }
            function checkGrid1() {
                var remark = true;
                var txtShareholderName_insert = document.getElementById('<%=((TextBox)gridshareholder.FooterRow.FindControl("txtShareholderName_insert")).ClientID %>');
                var txtShareper_insert = document.getElementById('<%=((TextBox)gridshareholder.FooterRow.FindControl("txtShareper_insert")).ClientID %>');
                var txtAddress_insert = document.getElementById('<%=((TextBox)gridshareholder.FooterRow.FindControl("txtAddress_insert")).ClientID %>');
                var txtPhone_insert = document.getElementById('<%=((TextBox)gridshareholder.FooterRow.FindControl("txtPhone_insert")).ClientID %>');

                if (txtShareholderName_insert.value.length <= 0) {
                    txtShareholderName_insert.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtShareholderName_insert.style.borderColor = "";
                }
                if (txtShareper_insert.value.length <= 0) {
                    txtShareper_insert.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtShareper_insert.style.borderColor = "";
                }
                if (txtAddress_insert.value.length <= 0) {
                    txtAddress_insert.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtAddress_insert.style.borderColor = "";
                }
                if (txtPhone_insert.value.length <= 0) {
                    txtPhone_insert.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPhone_insert.style.borderColor = "";
                }

                if (remark == false) {

                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Value";

                    return false;
                } else {
                    hideError();
                    return true;
                }

            }
            function checkGrid2() {
                var remark = true;
                var txtShareholderName_insert = document.getElementById('<%=((TextBox)Trustee_details_grid.FooterRow.FindControl("txtTrusteeName_insert")).ClientID %>');
                var txtAddress_insert = document.getElementById('<%=((TextBox)Trustee_details_grid.FooterRow.FindControl("txtTAddress_insert")).ClientID %>');
                var txtPhone_insert = document.getElementById('<%=((TextBox)Trustee_details_grid.FooterRow.FindControl("txtTPhone_insert")).ClientID %>');

                  if (txtShareholderName_insert.value.length <= 0) {
                      txtShareholderName_insert.style.borderColor = '#e52213';
                      remark = false;
                  }
                  else {
                      txtShareholderName_insert.style.borderColor = "";
                  }

                  if (txtAddress_insert.value.length <= 0) {
                      txtAddress_insert.style.borderColor = '#e52213';
                      remark = false;
                  }
                  else {
                      txtAddress_insert.style.borderColor = "";
                  }
                  if (txtPhone_insert.value.length <= 0) {
                      txtPhone_insert.style.borderColor = '#e52213';
                      remark = false;
                  }
                  else {
                      txtPhone_insert.style.borderColor = "";
                  }

                  if (remark == false) {

                      showError();
                      document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Value";

                    return false;
                } else {
                    hideError();
                    return true;
                }

               }
            function checkGrid3() {
                   var remark = true;
                   var txtShareholderName_insert = document.getElementById('<%=((TextBox)DirectorsGrid.FooterRow.FindControl("txtDirectorName_insert")).ClientID %>');
                   var txtShareper_insert = document.getElementById('<%=((TextBox)DirectorsGrid.FooterRow.FindControl("txtDIN_PAN_insert")).ClientID %>');
                   var txtAddress_insert = document.getElementById('<%=((TextBox)DirectorsGrid.FooterRow.FindControl("txtDirectorAddress_insert")).ClientID %>');
                   var txtPhone_insert = document.getElementById('<%=((TextBox)DirectorsGrid.FooterRow.FindControl("txtDirectorPhone_insert")).ClientID %>');

                if (txtShareholderName_insert.value.length <= 0) {
                    txtShareholderName_insert.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtShareholderName_insert.style.borderColor = "";
                }
                if (txtShareper_insert.value.length <= 0) {
                    txtShareper_insert.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtShareper_insert.style.borderColor = "";
                }

                if (txtAddress_insert.value.length <= 0) {
                    txtAddress_insert.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtAddress_insert.style.borderColor = "";
                }
                if (txtPhone_insert.value.length <= 0) {
                    txtPhone_insert.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPhone_insert.style.borderColor = "";
                }

                if (remark == false) {

                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Value";

                      return false;
                  } else {
                      hideError();
                      return true;
                  }

            }
            function checkGrid4() {
                var remark = true;
                var txtShareholderName_insert = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnerName_insert")).ClientID %>');
                var txtShareper_insert = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnershipPer_insert")).ClientID %>');

                var txtAddress_insert = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnerAddress_insert")).ClientID %>');
                var txtPhone_insert = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnerPhone_insert")).ClientID %>');

                if (txtShareholderName_insert.value.length <= 0) {
                    txtShareholderName_insert.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtShareholderName_insert.style.borderColor = "";
                }
                if (txtShareper_insert.value.length <= 0) {
                    txtShareper_insert.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtShareper_insert.style.borderColor = "";
                }

                if (txtAddress_insert.value.length <= 0) {
                    txtAddress_insert.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtAddress_insert.style.borderColor = "";
                }
                if (txtPhone_insert.value.length <= 0) {
                    txtPhone_insert.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtPhone_insert.style.borderColor = "";
                }

                if (remark == false) {

                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Value";

                    return false;
                } else {
                    hideError();
                    return true;
                }

               }

            function dosomething(obj) {
                var txtObj = document.getElementById(obj.id);
                alert(txtObj);
            }

            function ValidateRequired(obj, txt) {
                var txtObj = document.getElementById(obj.id);
                if (txtObj.value.length > 0) {
                    txtObj.style.borderColor = "";
                    hideError();
                    return true;
                }
                else {
                    txtObj.style.borderColor = "Red";
                    txtObj.focus();
                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = txt + " " + "Is required Field";

                    return false;
                }

        }

            function ValidateRequired(obj, txt) {
            var txtObj = document.getElementById(obj.id);
            if (txtObj.value.length > 0) {
                txtObj.style.borderColor = "";
                hideError();
                return true;
            }
            else {
                txtObj.style.borderColor = "Red";
                txtObj.focus();
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = txt + " " + "Is required Field";

                 return false;
             }

         }

            function ValidateFill(obj, txt) {
                var txtObj = document.getElementById(obj.id);
                if (txtObj.value.length > 0) {
                    txtObj.style.borderColor = "";
                    hideError();
                    return true;
                }
               

            }
            function PrintElem1() {

                Popup($('#Payment_div').html());
            }


            function Popup(data) {
                var mywindow = window.open('', 'my div', 'height=2000,width=1000');
                mywindow.document.write('<html><head><title style="font-weight:bold;">Application for Issuance of Unique Id for Private Industrial Parks</title>');
                mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/bootstrap.min.css\" type=\"text/css\" />');
                mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/theme.css\" type=\"text/css\"  />');
                mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/print.css\" type=\"text/css\"  />');
                mywindow.document.write('</head><body >');
                mywindow.document.write(data);
                mywindow.document.write('</body></html>');

                setTimeout(function () {
                    mywindow.print();
                    mywindow.close();
                }, 100000);


                return true;
            }

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });;
            $(".date1").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd MM yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });;
        });
    

    </script>

</body>
</html>