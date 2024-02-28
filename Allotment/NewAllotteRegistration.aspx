<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAllotteRegistration.aspx.cs" Inherits="Allotment.NewAllootteeRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    
   <link href="css/bootstrap.min.css" rel="stylesheet" />
	<link href="css/font-awesome.min.css" rel="stylesheet" />
	<link href="css/CssManu.css" rel="stylesheet" />
	<link href="css/Main.css" rel="stylesheet" />
	<link href="css/theme.css" rel="stylesheet" />



	<link href="css/ajax-jquery-ui.css" rel="stylesheet" />
	<link href="css/Footer.css" rel="stylesheet" />

	<script src="js/ajax-jquery-min.js"></script>
	<script src="js/ajax-jquery-ui.js"></script>
	<%--<script src="assets/js/bootstrap-datepicker.min.js"></script>--%>
	<script src="assets/js/bootstrap.min.js"></script>

        





	<script src="/js/jquery1.js"></script>
	<script src="js/jquery-ui.js"></script>
	<script src="/js/jquery.js"></script>
	<script src="/js/bootstrap.min.js"></script>

 
      <style>

        .ui-dialog .ui-dialog-titlebar {
    padding: .4em 1em;
    position: relative;
    background: #D8D8D8 !important;
    border-color: #D8D8D8 !important;
}

        .ui-dialog .ui-dialog-title {
    font-family: serif !important;
    color: black;
}


        .ui-dialog .ui-dialog-buttonpane button {
          
    background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#4c5568), to(#414959)) !important;
    border: 1px solid #fff !important;
    font-weight: normal !important;
     padding: 5px 10px !important;
    font-size: 12px !important;
    line-height: 1.5 !important;
    color: #fff !important;

  
}

        .ui-dialog .ui-dialog-titlebar-close span {
    color:black !important;
}


    </style>



    <script type="text/javascript">     

        function ShowPopup(message) {
            $(function () {
                $("#dialog").html(message);
                $("#dialog").dialog({
                    title: "Alert",
                    buttons: {
                        Close: function () {
                            $(this).dialog('close');
                        }
                    },
                    modal: true
                });
            });
        };
        function ShowMessage1(msg) {
            alert(msg);

        }
        function ShowMessage(msg) {
            alert('Your Request Is Submitted Successfully. Now Complete Your KYC Details For Further Process');
            window.location.href = 'KYCForm.aspx?AllotteeID=' + msg;
           

        }
        function Allotment_keypress() {

            var txt = document.getElementById("<%= txtAllotment.ClientID %>"); 

            if (txt.value.length > 0) {
                txt.style.borderColor = "";
               
            }

        }

        function validatepan() {

            var panVal = document.getElementById("<%= txtPanNo.ClientID %>").value;
             var regpan = /^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$/;
             if (panVal != "") {
                 if (regpan.test(panVal)) {
                     document.getElementById("<%= txtPanNo.ClientID %>").style.borderColor = "";
                    return true;
                } else {
                   
                     alert("Invalid Pan No");
                    document.getElementById("<%= txtPanNo.ClientID %>").value = "";
                    return false;
                }
            }
        }

        function check1() {
            var remark = true;


            var txt = document.getElementById("<%= txtAllotment.ClientID %>");

            var txt1 = document.getElementById("<%= txtPlotNo.ClientID %>");
            var txt2 = document.getElementById("<%= txtCompanyname.ClientID %>");

            var txt9 = document.getElementById("<%= txtIndividualName.ClientID %>");
            var txt10 = document.getElementById("<%= txtIndividualAddress.ClientID %>");
            var txt11 = document.getElementById("<%= txtIndividualEmail.ClientID %>");
            var txt12 = document.getElementById("<%= txtIndividualPhone.ClientID %>");
            var txt13 = document.getElementById("<%= txtAuthorisedSignatory.ClientID %>");
            var txt14 = document.getElementById("<%= txtSignatoryPhone.ClientID %>");
            var txt15 = document.getElementById("<%= txtSignatoryAddress.ClientID %>");
            var txt16 = document.getElementById("<%= txtSignatoryEmail.ClientID %>");
            var ddl = document.getElementById("<%= ddlArea.ClientID%>");
            var ddl1 = document.getElementById("<%= ddlcompanytype.ClientID%>");
          
               
            if (txt.value.length <= 0) {
                txt.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt.style.borderColor = "";
            }
            if (txt1.value.length <= 0) {
                txt1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt1.style.borderColor = "";
            }
       
            
            if (ddl1.selectedIndex == 1) {

                if (txt3.value.length <= 0) {
                    txt3.style.borderColor = '#e52213';
                    remark = false;
                }
                else {

             

                    txt3.style.borderColor = "";
                }
                if (txt4.value.length <= 0) {
                    txt4.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txt4.style.borderColor = "";
                }
                if (txt7.value.length <= 0) {
                    txt7.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txt7.style.borderColor = "";
                }
                if (txt8.value.length <= 0) {
                    txt8.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txt8.style.borderColor = "";
                }

            } else {
                if (txt2.value.length <= 0) {
                    txt2.style.borderColor = '#e52213';
                    remark = false;
                } else {
                    txt2.style.borderColor = "";
                }

            }

            if (ddl1.selectedIndex == 5) {

                if (txt9.value.length <= 0) {
                    txt9.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txt9.style.borderColor = "";
                }
                if (txt10.value.length <= 0) {
                    txt10.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txt10.style.borderColor = "";
                }
                if (txt11.value.length <= 0) {
                    txt11.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txt11.style.borderColor = "";
                }
                if (txt12.value.length <= 0) {
                    txt12.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txt12.style.borderColor = "";
                }

            }
            if (txt13.value.length <= 0) {
                txt13.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt13.style.borderColor = "";
            }
           
            if (txt15.value.length <= 0) {
                txt15.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt15.style.borderColor = "";
            }
           


         

                if (remark == false) {

                    alert("Invalid Phone No");
                    return false;
                } else {
                    return true;
                }

           
        }

        function Validate_signatory_name(evt) {

            var keyCode = (evt.which) ? evt.which : evt.keyCode
            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32) {
                return false;
            }
            else {
                var txt = document.getElementById("<%= txtAuthorisedSignatory.ClientID %>");
                    if (txt.value.length > 0) {
                        txt.style.borderColor = "";
                        return true;
                    }

                }


        }
        function Validate_shareholder_name(evt) {

            var keyCode = (evt.which) ? evt.which : evt.keyCode
            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32) {
                return false;
            }
            else {
                
                var txt = document.getElementById('<%=((TextBox)gridshareholder.FooterRow.FindControl("txtShareholderName_insert")).ClientID %>');
           
                if (txt.value.length > 0) {
                    txt.style.borderColor = "";
                    return true;
                }

            }
        }
        function Validate_director_name(evt) {

            var keyCode = (evt.which) ? evt.which : evt.keyCode
            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32) {
                return false;
            }
            else {

                var txt = document.getElementById('<%=((TextBox)DirectorsGrid.FooterRow.FindControl("txtDirectorName_insert")).ClientID %>');

                if (txt.value.length > 0) {
                    txt.style.borderColor = "";
                    return true;
                }

            }
        }

        function Validate_trustee_name(evt) {

            var keyCode = (evt.which) ? evt.which : evt.keyCode
            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32) {
                return false;
            }
            else {

                var txt = document.getElementById('<%=((TextBox)Trustee_details_grid.FooterRow.FindControl("txtTrusteeName_insert")).ClientID %>');

                if (txt.value.length > 0) {
                    txt.style.borderColor = "";
                    return true;
                }

            }
        }
        function Validate_individual_name(evt) {

            var keyCode = (evt.which) ? evt.which : evt.keyCode
            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32) {
                return false;
            }
            else {
                var txt = document.getElementById("<%= txtIndividualName.ClientID %>");
                if (txt.value.length > 0) {
                    txt.style.borderColor = "";
                    return true;
                }

            }


        }




        function validate_signatory_phone(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode = 46 && charCode > 31
            && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById("<%= txtSignatoryPhone.ClientID %>");
                    if (txt.value.length > 0) {

                        txt.style.borderColor = "";
                        return true;

                    }
                }
            }

            function check_sphone() {
                var txt = document.getElementById("<%= txtSignatoryPhone.ClientID %>");

            if (txt.value.length < 10) {
                alert("Invalid Phone No");
                txt.value = "";
                return false;
            } else {
                return true;
            }
        }
        function validate_individual_phone(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode = 46 && charCode > 31
            && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById("<%= txtIndividualPhone.ClientID %>");
                if (txt.value.length > 0) {

                    txt.style.borderColor = "";
                    return true;

                }
            }
        }
        function validate_shareholder_phone(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode = 46 && charCode > 31
            && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById('<%=((TextBox)gridshareholder.FooterRow.FindControl("txtPhone_insert")).ClientID %>');
           
                if (txt.value.length > 0) {

                    txt.style.borderColor = "";
                    return true;

                }
            }
        }
        function validate_trustee_phone(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode = 46 && charCode > 31
            && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById('<%=((TextBox)Trustee_details_grid.FooterRow.FindControl("txtTPhone_insert")).ClientID %>');

                if (txt.value.length > 0) {

                    txt.style.borderColor = "";
                    return true;

                }
            }
        }
        function validate_partner_phone(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode = 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnerPhone_insert")).ClientID %>');

                if (txt.value.length > 0) {

                    txt.style.borderColor = "";
                    return true;

                }
            }
        }

        function validate_director_phone(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode = 46 && charCode > 31
            && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById('<%=((TextBox)DirectorsGrid.FooterRow.FindControl("txtDirectorPhone_insert")).ClientID %>');

                if (txt.value.length > 0) {

                    txt.style.borderColor = "";
                    return true;

                }
            }
        }
        function check_dphone() {
            var txt  = document.getElementById('<%=((TextBox)DirectorsGrid.FooterRow.FindControl("txtDirectorPhone_insert")).ClientID %>');

            if (txt.value.length < 10) {
                alert("Invalid Phone No");
                txt.value = "";
                return false;
            } else {
                return true;
            }
        }

        function check_parphone() {
            var txt = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnerPhone_insert")).ClientID %>');

             if (txt.value.length < 10) {
                 alert("Invalid Phone No");
                 txt.value = "";
                 return false;
             } else {
                 return true;
             }
         }
        function check_sharephone() {
            var txt = document.getElementById('<%=((TextBox)gridshareholder.FooterRow.FindControl("txtPhone_insert")).ClientID %>');
           
            if (txt.value.length < 10) {
                alert("Invalid Phone No");
                txt.value = "";
                return false;
            } else
            {
                return true;
            }
        }
        function check_Tphone() {
            var txt = document.getElementById('<%=((TextBox)Trustee_details_grid.FooterRow.FindControl("txtTPhone_insert")).ClientID %>');

            if (txt.value.length < 10) {
                alert("Invalid Phone No");
                txt.value = "";
                return false;
            } else {
                return true;
            }
        }

        function check_iphone() {
            var txt = document.getElementById("<%= txtIndividualPhone.ClientID %>");

                if (txt.value.length < 10) {
                    alert("Invalid Phone No");
                    txt.value = "";
                    return false;
                } else {
                    return true;
                }
            }


            function address_keypress()
            {
                var txt = document.getElementById("<%= txtIndividualAddress.ClientID %>");

                if (txt.value.length > 0)
                {
                    txt.style.borderColor = "";

                }

            }

            function plot_keypress()
            {

                var txt = document.getElementById("<%= txtPlotNo.ClientID %>");

                if (txt.value.length > 0)
                {
                    txt.style.borderColor = "";

                }

            }



            function IsValidEmail(email) {
                var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
                return expr.test(email);
            };
            function ValidateSignatoryEmail() {
                var email = document.getElementById("<%= txtSignatoryEmail.ClientID %>").value;
                if (email.length > 0)
                {
                    if (!IsValidEmail(email))
                    {
                        document.getElementById("<%= txtSignatoryEmail.ClientID %>").value = "";
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            function ValidateShareHolderEmail() {
                var email = document.getElementById('<%=((TextBox)gridshareholder.FooterRow.FindControl("txtEmail_insert")).ClientID %>').value;
           
             if (email.value.length > 0) {
                 if (!IsValidEmail(email)) {

                     alert("Invalid Email");
                     email.value = "";
                     return false;

                }
                else {

                     email.style.borderColor = "";
                    return true;
                }
            }
            }
            function ValidatePartnerEmail() {
                var email = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnerEmail_insert")).ClientID %>').value;

            
                  if (!IsValidEmail(email)) {

                      alert("Invalid Email");
                      email.value = "";
                      return false;

                  }
                  else {

                      email.style.borderColor = "";
                      return true;
                  }
            
          }
            function ValidateTrusteeEmail() {
                var email = document.getElementById('<%=((TextBox)Trustee_details_grid.FooterRow.FindControl("txttEmail_insert")).ClientID %>').value;

             
                 if (!IsValidEmail(email)) {

                     alert("Invalid Email");
                     email.value = "";
                     return false;

                 }
                 else {

                     email.style.borderColor = "";
                     return true;
                 }
            
        }
        function ValidateDirectorEmail() {
            var email = document.getElementById('<%=((TextBox)DirectorsGrid.FooterRow.FindControl("txtDirectorEmail_insert")).ClientID %>').value;

            
                if (!IsValidEmail(email)) {

                    alert("Invalid Email");
                    email.value = "";
                    return false;

                }
                else
                {

                    email.style.borderColor = "";
                    return true;
                }
          
        }
        function ValidateIndividualEmail() {
            var email = document.getElementById("<%= txtIndividualEmail.ClientID %>").value;
            if (email.length > 0)
            {
                if (!IsValidEmail(email))
                {
                    alert("invalid Email")
                    document.getElementById("<%= txtIndividualEmail.ClientID %>").value = "";
                    return false;

                }
                else
                {
                    return true;
                }
             }
        }

        

        

 </script>
</head>
    
 
<body id="pagewrap">
    <div id="dialog" style="display: none">
</div> 
     <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
		<%--<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
			<ContentTemplate>--%>
				<%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
					<ProgressTemplate>
						<div class="fgh">
							<div class="hgf">
								<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
							</div>
						</div>
					</ProgressTemplate>
				</asp:UpdateProgress>--%>
        <div class="container">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                        <a href="Default.aspx" class="navbar-brand">
                            <div class="col-md-8">
                                <img class="img-responsive" src="logo.jpg" />
                            </div>
                            <div class="col-md-4">
                                <img class="img-responsive" src="Image.jpg" />
                            </div>
                        </a>

                    </div>
                </div>
                <div id="main_menu" runat="server"> <% Response.WriteFile("top_mainmenu.aspx"); %> </div> 
            </div>
            <div class="row" id="SideDiv">
                <div class="col-md-12">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="row well well-large offset4">
                                <div class="panel panel-default">
                                    <p class="panel-heading text-center"><b>Sign up Form </b></p>
                                    <div class="panel-body">
                                        <div id="tblallotteeinf">
                                            <p class="panel-heading"><b>Allotment Information</b></p>
                                            <div class="form-group">
                                                <label class="col-md-4 text-right">
                                                    <span style="color: Red">*</span>
                                                    Name of Industrial Area in which plot belongs :
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlArea" runat="server" CssClass="input-sm dropdown-toggle similar-select1 margin-left-z" ></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <label class="col-md-4 text-right">
                                                    <span style="color: Red">*</span>
                                                    Allottee Id :
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtAllotment" runat="server" CssClass="similar-select1 input-sm" onkeypress="return Allotment_keypress();" ></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <label class="col-md-4 text-right">
                                                    <span style="color: Red">*</span>
                                                    Allotted Plot No. :
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtPlotNo" runat="server" CssClass="similar-select1 input-sm" onkeypress="return plot_keypress();"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group" style="display:none;">
                                                <label class="col-md-4 text-right">
                                                    <span style="color: Red">*</span>
                                                    File No. :
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtFileNo" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                        </div>
                                        <div id="tblcompanyprofile">
                                            <p class="panel-heading"><b>Particulars of the Allottee in whose name plot/shed is Allotted</b></p>
                                            <div class="form-group">
                                                <label class="col-md-4 text-right">
                                                    <span style="color: Red">*</span>
                                                    Constitution of Firm/Company :
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlcompanytype" runat="server" AutoPostBack="true" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" OnSelectedIndexChanged="CompanyTypeddl_selectedindex_changed"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div runat="server" id="CompanyDiv">
                                            <div class="form-group">
                                                <label class="col-md-4 text-right">
                                                    <span style="color: Red">*</span>
                                                    Name of the Firm/Company :
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtCompanyname" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                                </div>
                                            <div class="form-group">
                                                <label class="col-md-4 text-right">
                                                    Pan No :
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtPanNo" runat="server" CssClass="similar-select1 input-sm" onblur="return validatepan();"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <label class="col-md-4 text-right">
                                                    CIN No :
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtCinNo" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div id="tr5" runat="server" visible="false">
                                                <div class="form-group">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        <asp:Label id="lblnameremark" runat="server" />
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtIndividualName" runat="server" CssClass="similar-select1 input-sm"  onkeypress="return Validate_individual_name(event);"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Address :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtIndividualAddress" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                            <div  id="tr6" runat="server" visible="false">
                                                <div class="form-group">
                                                    <label class="col-md-4 text-right">
                                                       
                                                         Phone :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtIndividualPhone" runat="server" CssClass="input-sm similar-select1" MaxLength="10" onkeypress="retun validate_individual_phone(event);" ></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-4 text-right">
                                                        
                                                         Email Id :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtIndividualEmail" runat="server" CssClass="input-sm similar-select1"  onblur="return ValidateIndividualEmail();"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                            <div   id="tr7" runat="server" visible="false">
                                                <div class="form-group">
                                                    <div class="col-md-12">
                                                        <asp:CheckBox ID="chk2" runat="server" Text="&nbsp;&nbsp;Check if the person who will be operating the application is same as the Allottee" OnCheckedChanged="checkbox2_checked_changed" AutoPostBack="true" />
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-4 text-right">
                                                    <span style="color: Red">*</span>
                                                    Name of the person who  will operate :
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtAuthorisedSignatory" runat="server" CssClass="input-sm similar-select1" onkeypress="return Validate_signatory_name(event);" ></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <label class="col-md-4 text-right">
                                                    <span style="color: Red">*</span>
                                                     Address :
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtSignatoryAddress" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <label class="col-md-4 text-right">
                                                    
                                                     Phone :
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtSignatoryPhone" runat="server" CssClass="input-sm similar-select1" MaxLength="10" onkeypress="return validate_signatory_phone(event);"  ></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <label class="col-md-4 text-right">
                                                  
                                                     Email Id :
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtSignatoryEmail" runat="server" CssClass="input-sm similar-select1" ></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div id="tr2" runat="server" visible="false">
                                                <hr style="margin:8px 0;border-top: 1px solid #9c9999;" />
                                                                <asp:GridView ID="gridshareholder" ViewStateMode ="Enabled"  CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true"  ShowHeaderWhenEmpty="true"  runat="server" ShowFooter="true" AutoGenerateColumns="false"   OnRowDeleting = "ShareHolderDelete_Click" >
                                                    <Columns>

                                                         <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                        </ItemTemplate>
                                                         </asp:TemplateField>

                                     
                                                        <asp:TemplateField ItemStyle-Width="20%" HeaderText="Shareholder Name">
                                                             <ItemTemplate> <asp:Label ID="lblShareholderName" runat="server" Text='<%#Eval("ShareHolderName") %>' ></asp:Label> </ItemTemplate>
                                                              <FooterTemplate><asp:TextBox  ID="txtShareholderName_insert"    CssClass="input-sm similar-select1" runat="server" onkeypress="return Validate_shareholder_name(event);"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="20%"  HeaderText ="Share %">
                                                             <ItemTemplate> <asp:Label ID="lblShareper" runat="server" Text='<%#Eval("SharePer") %>' ></asp:Label> </ItemTemplate>                                                
                                                                 <FooterTemplate><asp:TextBox ID="txtShareper_insert"    runat ="server" CssClass="input-sm similar-select1" onkeypress="return validate_shareper(event);"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField  ItemStyle-Width="20%" HeaderText="Address">
                                                              <ItemTemplate> <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>' ></asp:Label> </ItemTemplate>                                                   
                                                                <FooterTemplate><asp:TextBox ID="txtAddress_insert"  CssClass="input-sm similar-select1" runat="server"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                            <asp:TemplateField  ItemStyle-Width="20%" HeaderText="Phone No">
                                                                  <ItemTemplate> <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone") %>' ></asp:Label> </ItemTemplate>                                                  
                                                                <FooterTemplate><asp:TextBox ID="txtPhone_insert"  CssClass="input-sm similar-select1" MaxLength="10" runat="server" onkeypress="return validate_shareholder_phone(event);" onblur="return check_sharephone();"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField  ItemStyle-Width="20%" HeaderText="Email ID">
                                                             <ItemTemplate> <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>' ></asp:Label> </ItemTemplate>                              
                                                             <FooterTemplate><asp:TextBox ID="txtEmail_insert"  CssClass="input-sm similar-select1" runat="server" onblur="return ValidateShareHolderEmail();"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>

         
                                                              <asp:TemplateField>
                                                            <ItemTemplate>
                                                                 <asp:ImageButton   CommandName="Delete" CssClass="fa fa-trash-o"  ToolTip="Delete" ID="btn_delete" runat="server"  
                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

                                                            </ItemTemplate>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                 <asp:ImageButton  ToolTip="Add"  CssClass="fa fa-plus-square"  ID="ButtonAdd" runat="server"  Height="16px" OnClick="insert_shareholder_details"
                                        ImageUrl="~/images/add.png" Width="16px"  />

                                                        


                                                        
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                         
                                                                    </Columns>
                                                </asp:GridView>

                                            </div>
                                            <div class="clearfix"></div>
                                            <div id="tr4" runat="server" visible="false">
                                                <hr style="margin:8px 0;border-top: 1px solid #9c9999;" />
                                                        <asp:GridView ID="Trustee_details_grid" ViewStateMode ="Enabled"  CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true"  ShowHeaderWhenEmpty="true"  runat="server" ShowFooter="true" AutoGenerateColumns="false"   OnRowDeleting = "TrusteeDelete_Click" >
                                                    <Columns>

                                                         <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                        </ItemTemplate>
                                                         </asp:TemplateField>

                                     
                                                        <asp:TemplateField ItemStyle-Width="25%" HeaderText="Trustee Name">
                                                             <ItemTemplate> <asp:Label ID="lblTrusteeName" runat="server" Text='<%#Eval("TrusteeName") %>' ></asp:Label> </ItemTemplate>
                                                              <FooterTemplate><asp:TextBox  ID="txtTrusteeName_insert"    CssClass="input-sm similar-select1" runat="server" onkeypress="return Validate_trustee_name(event);"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                              
                                                        <asp:TemplateField  ItemStyle-Width="25%" HeaderText="Address">
                                                              <ItemTemplate> <asp:Label ID="lblTAddress" runat="server" Text='<%#Eval("TAddress") %>' ></asp:Label> </ItemTemplate>                                                   
                                                                <FooterTemplate><asp:TextBox ID="txtTAddress_insert"  CssClass="input-sm similar-select1" runat="server"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                            <asp:TemplateField  ItemStyle-Width="25%" HeaderText="Phone No">
                                                                  <ItemTemplate> <asp:Label ID="lblTPhone" runat="server" Text='<%#Eval("TPhone") %>' ></asp:Label> </ItemTemplate>                                                  
                                                                <FooterTemplate><asp:TextBox ID="txtTPhone_insert"  CssClass="input-sm similar-select1" MaxLength="10" runat="server" onkeypress="return validate_trustee_phone(event);" onblur="return check_Tphone();"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField  ItemStyle-Width="25%" HeaderText="Email ID">
                                                             <ItemTemplate> <asp:Label ID="lblTEmail" runat="server" Text='<%#Eval("TEmail") %>' ></asp:Label> </ItemTemplate>                              
                                                             <FooterTemplate><asp:TextBox ID="txtTEmail_insert"  CssClass="input-sm similar-select1" runat="server" onblur="return ValidateTrusteeEmail();"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>

         
                                                              <asp:TemplateField>
                                                            <ItemTemplate>
                                                                 <asp:ImageButton   CommandName="Delete" CssClass="fa fa-trash-o"  ToolTip="Delete" ID="btn_delete" runat="server"  
                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

                                                            </ItemTemplate>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                 <asp:ImageButton  ToolTip="Add"  CssClass="fa fa-plus-square"  ID="ButtonAdd" runat="server"  Height="16px" OnClick="insert_trustee_details"
                                        ImageUrl="~/images/add.png" Width="16px"  />

                                                        


                                                        
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                         
                                                                    </Columns>
                                                </asp:GridView>

                                            </div>
                                            <div class="clearfix"></div>
                                            <div id="tr8" runat="server" visible="false">
                                                <hr style="margin:8px 0;border-top: 1px solid #9c9999;" />
                                                            <asp:GridView ID="DirectorsGrid" ViewStateMode ="Enabled"  CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true"  ShowHeaderWhenEmpty="true"  runat="server" ShowFooter="true" AutoGenerateColumns="false"   OnRowDeleting = "DirectorDelete_Click" >
                                                    <Columns>

                                                         <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                        </ItemTemplate>
                                                         </asp:TemplateField>                
                                                        <asp:TemplateField ItemStyle-Width="20%" HeaderText="Director Name">
                                                             <ItemTemplate> <asp:Label ID="lblDirectorName" runat="server" Text='<%#Eval("DirectorName") %>' ></asp:Label> </ItemTemplate>
                                                              <FooterTemplate><asp:TextBox  ID="txtDirectorName_insert"    CssClass="input-sm similar-select1" runat="server" onkeypress="return Validate_director_name(event);"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="20%"  HeaderText ="Din/Pan">
                                                             <ItemTemplate> <asp:Label ID="lblDIN_PAN" runat="server" Text='<%#Eval("DIN_PAN") %>' ></asp:Label> </ItemTemplate>                                                
                                                                 <FooterTemplate><asp:TextBox ID="txtDIN_PAN_insert"    runat ="server" CssClass="input-sm similar-select1"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField  ItemStyle-Width="20%" HeaderText="Address">
                                                              <ItemTemplate> <asp:Label ID="lblDirectorAddress" runat="server" Text='<%#Eval("DAddress") %>' ></asp:Label> </ItemTemplate>                                                   
                                                                <FooterTemplate><asp:TextBox ID="txtDirectorAddress_insert"  CssClass="input-sm similar-select1" runat="server"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                            <asp:TemplateField  ItemStyle-Width="20%" HeaderText="Phone No">
                                                                  <ItemTemplate> <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("DPhone") %>' ></asp:Label> </ItemTemplate>                                                  
                                                                <FooterTemplate><asp:TextBox ID="txtDirectorPhone_insert"  CssClass="input-sm similar-select1" MaxLength="10" runat="server" onkeypress="return validate_director_phone(event);" onblur="return check_dphone();"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField  ItemStyle-Width="20%" HeaderText="Email ID">
                                                             <ItemTemplate> <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("DEmail") %>' ></asp:Label> </ItemTemplate>                              
                                                             <FooterTemplate><asp:TextBox ID="txtDirectorEmail_insert"  CssClass="input-sm similar-select1" runat="server" onblur="return ValidateDirectorEmail();"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>

         
                                                              <asp:TemplateField>
                                                            <ItemTemplate>
                                                                 <asp:ImageButton   CommandName="Delete" CssClass="fa fa-trash-o"  ToolTip="Delete" ID="btn_delete" runat="server"  
                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

                                                            </ItemTemplate>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                 <asp:ImageButton  ToolTip="Add"  CssClass="fa fa-plus-square"  ID="ButtonAdd" runat="server"  Height="16px" OnClick="insert_Director_details"
                                        ImageUrl="~/images/add.png" Width="16px"  />

                                                        


                                                        
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                         
                                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <div class="clearfix"></div>


                                             <div id="tr9" runat="server" visible="false">
                                                <hr style="margin:8px 0;border-top: 1px solid #9c9999;" />
                                                            <asp:GridView ID="PartnershipFirmGrid" ViewStateMode ="Enabled"  CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true"  ShowHeaderWhenEmpty="true"  runat="server" ShowFooter="true" AutoGenerateColumns="false"   OnRowDeleting = "PartnershipDelete_Click" >
                                                    <Columns>

                                                         <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                        </ItemTemplate>
                                                         </asp:TemplateField>                
                                                        <asp:TemplateField ItemStyle-Width="20%" HeaderText="Partner Name">
                                                             <ItemTemplate> <asp:Label ID="lblPartnerName" runat="server" Text='<%#Eval("PartnerName") %>' ></asp:Label> </ItemTemplate>
                                                              <FooterTemplate><asp:TextBox  ID="txtPartnerName_insert"    CssClass="input-sm similar-select1" runat="server" onkeypress="return Validate_director_name(event);"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="20%"  HeaderText ="Partnership Per">
                                                             <ItemTemplate> <asp:Label ID="lblPartnershipPer" runat="server" Text='<%#Eval("PartnershipPer") %>' ></asp:Label> </ItemTemplate>                                                
                                                                 <FooterTemplate><asp:TextBox ID="txtPartnershipPer_insert"    runat ="server" CssClass="input-sm similar-select1"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField  ItemStyle-Width="20%" HeaderText="Address">
                                                              <ItemTemplate> <asp:Label ID="lblPartnerAddress" runat="server" Text='<%#Eval("ParAddress") %>' ></asp:Label> </ItemTemplate>                                                   
                                                                <FooterTemplate><asp:TextBox ID="txtPartnerAddress_insert"  CssClass="input-sm similar-select1" runat="server"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                            <asp:TemplateField  ItemStyle-Width="20%" HeaderText="Phone No">
                                                                  <ItemTemplate> <asp:Label ID="lblPartnerPhone" runat="server" Text='<%#Eval("ParPhone") %>' ></asp:Label> </ItemTemplate>                                                  
                                                                <FooterTemplate><asp:TextBox ID="txtPartnerPhone_insert"  CssClass="input-sm similar-select1" MaxLength="10" runat="server" onkeypress="return validate_partner_phone(event);" onblur="return check_parphone();"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField  ItemStyle-Width="20%" HeaderText="Email ID">
                                                             <ItemTemplate> <asp:Label ID="lblPartnerEmail" runat="server" Text='<%#Eval("ParEmail") %>' ></asp:Label> </ItemTemplate>                              
                                                             <FooterTemplate><asp:TextBox ID="txtPartnerEmail_insert"  CssClass="input-sm similar-select1" runat="server" onblur="return ValidatePartnerEmail();"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>

         
                                                              <asp:TemplateField>
                                                            <ItemTemplate>
                                                                 <asp:ImageButton   CommandName="Delete" CssClass="fa fa-trash-o"  ToolTip="Delete" ID="btn_delete" runat="server"  
                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

                                                            </ItemTemplate>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                 <asp:ImageButton  ToolTip="Add"  CssClass="fa fa-plus-square"  ID="ButtonAdd" runat="server"  Height="16px" OnClick="insert_Partnership_details"
                                        ImageUrl="~/images/add.png" Width="16px"  />

                                                        


                                                        
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                         
                                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <div class="clearfix"></div>


                                            <div class="form-group" style="margin-top:15px;">
                                                <div class="col-md-4">
                                                        <span style="color: blue" class="pull-left">Field marked with <span style="color: Red">* </span>are mandatory</span>
                                                        <asp:Label runat="server" ID="lblAllotteeID" Visible="false"></asp:Label>
                                                </div>
                                                <div class="col-md-4 text-center">
                                                    <asp:Button ID="btnSubmit" style="margin:0 1px 0 0;width:65px;" CssClass="btn btn-primary btn-sm" ValidationGroup="ValidationButton" runat="server" OnClick="btnSubmit_Click" Text="Submit" OnClientClick="return check1()"/><asp:Button ID="btnReset" style="margin:0;width:65px;" CssClass="btn btn-primary btn-sm" runat="server" OnClick="Reset_Click" Text="Reset" />                                                    
                                                </div>
                                                <div class="col-md-4"></div>
                                            </div>
                                            <div class="clearfix"></div>
                                         

                                         

                                   </div>
                                </div>
                            </div>
                        </div>

                    </div>
              <%--     <footer class="nb-footer">
                        <div class="container">
                            <div class="row">
                               <div class="col-sm-12">
                                    <div class="about">
                                        <img src="images/logo.png" class="img-responsive center-block" alt="">
                                        <div class="social-media">
                                            <ul class="list-inline">
                                                <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-facebook"></i></a></li>
                                                <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-twitter"></i></a></li>
                                                <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-google-plus"></i></a></li>
                                                <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-linkedin"></i></a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 col-sm-6">
                                    <div class="footer-info-single">
                                        <h2 class="title">PUBLIC FORUM</h2>
                                        <ul class="list-unstyled">
                                            <li><a href="Allotments.aspx" title=""><i class="fa fa-angle-double-right"></i>View Allottment Status</a></li>
                                            <li><a href="Inspection.aspx" title=""><i class="fa fa-angle-double-right"></i>View Inspection Detail</a></li>
                                            <li><a href="BuldingPlanDetail.aspx" title=""><i class="fa fa-angle-double-right"></i>Approved Building Plan</a></li>
                                            <li><a href="PviewAllottes.aspx" target="_blank" title=""><i class="fa fa-angle-double-right"></i>View Allotment Document</a></li>
                                            <li><a href="ViewInspectionDocument.aspx" target="_blank" title=""><i class="fa fa-angle-double-right"></i>View Inspection Document</a></li>
                                            <li><a href="ViewBuildingPlanDocument.aspx" target="_blank" title=""><i class="fa fa-angle-double-right"></i>View BuildingPlan Document </a></li>
                                        </ul>
                                    </div>
                                </div>

                                <div class="col-md-3 col-sm-6">
                                    <div class="footer-info-single">
                                        <h2 class="title">UP SIDA</h2>
                                        <ul class="list-unstyled">
                                            <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>UP Industial Development Act</a></li>
                                            <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>UPSIDA Byelaws</a></li>
                                            <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>Inspection Format For Construction Permit</a></li>
                                            <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>Inspection Format For Completion</a></li>
                                            <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>SOP For Computerised Allocation of Inspectors</a></li>
                                        </ul>
                                    </div>
                                </div>

                                <div class="col-md-3 col-sm-6">
                                    <div class="footer-info-single">
                                        <h2 class="title">Security & privacy</h2>
                                        <ul class="list-unstyled">
                                            <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Terms Of Use</a></li>
                                            <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Privacy Policy</a></li>
                                            <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Return / Refund Policy</a></li>
                                            <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Store Locations</a></li>
                                        </ul>
                                    </div>
                                </div>

                                <div class="col-md-3 col-sm-6">
                                    <div class="footer-info-single">
                                        <h2 class="title">Payment</h2>
                                         <ul class="list-unstyled">
                                            <li><a href="PaymentRequest.aspx" title=""><i class="fa fa-angle-double-right"></i>Quick Pay</a></li>
                                                </ul>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <section class="copyright">
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <p>Copyright © 2017. UPSIDC Product Version Alpha 1.0 Release</p>
                                    </div>
                                    <div class="col-sm-6"></div>
                                </div>
                            </div>
                        </section>
                    </footer>--%>

                </div>

            </div>
        </div>
    </div>
    <%-- </ContentTemplate>
		</asp:UpdatePanel>
 --%>
    </form>
</body>
</html>
