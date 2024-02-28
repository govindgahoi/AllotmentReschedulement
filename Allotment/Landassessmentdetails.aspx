<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Landassessmentdetails.aspx.cs" Inherits="Allotment.Landassessmentdetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

     <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />

    
    
   
    <script src="js/ajax-jquery-min.js"></script>
    <script src="js/ajax-jquery-ui.js"></script>

    <script src="/js/jquery1.js"></script>
    
    <script src="/js/jquery.js"></script>

  
  

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet" />
     <script src="js/jquery-ui.js"></script>
    <script src="js/chosen.jquery.min.js"></script>
     <link href="css/Footer.css" rel="stylesheet" />
    


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

        .ui-dialog {
            top: 130% !important;
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
                color: black !important;
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

        function ValidateIndividualEmail() {
            var email = document.getElementById("<%= txtEmail.ClientID %>").value;
            if (email.length > 0) {
                if (!IsValidEmail(email)) {

                    ShowPopup("<img src='/images/alert.jpg' width='38' height='38'> &nbsp;&nbsp;<span style='font-family:serif !important'>Invalid Email Id</span>");
                    document.getElementById("<%= txtEmail.ClientID %>").value = "";
                        document.getElementById("<%= txtEmail.ClientID %>").style.borderColor = '#e52213';

                        return false;

                    }
                    else {

                        document.getElementById("<%= txtEmail.ClientID %>").style.borderColor = "";
                        return true;
                    }
                }
            }


    


        function IsValidEmail(email) {
            var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            return expr.test(email);
        };





        function isDecimalKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {


            }
        }



    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();

            $(".MultiSelect").chosen(
               


            );
        }

    </script>
</head>
<body id="pagewrap">
    <div id="dialog" style="display: none">
       
    </div>
     <%--<cc1:MessageBox ID="MessageBox1" runat="server" />--%>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
          
        <div class="container">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                          <a href="Default.aspx" class="navbar-brand" style="width:100%;">
                            <div class="col-md-8">
                                <img class="img-responsive" src="http://www.onlineupsidc.com/OfcUser_pdf/upsida-logo-name.png" />
                            </div>
                            <div class="col-md-4" style="margin-top: 2px;">
                                <img class="img-responsive" src="images/image4.png" />
                            </div>
                        </a>

                    </div>
                </div>
                <div id="main_menu" runat="server"><% Response.WriteFile("top_mainmenu.aspx"); %> </div>
            </div>
            <div class="row" id="SideDiv">
                <div class="col-md-12">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="row well well-large offset4">
                                <div class="panel panel-default">
                                    <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <%--<ul class="mylogo-ul list-inline" style="margin:0;padding: 6px 0 9px 1px;">
                                                    <li><img src="/images/logo-img/pm_modi.jpg" alt="Goverment" style="box-shadow: 7px 4px 8px #ccc;"/></li>
                                                    <li><img src="/images/logo-img/govt_up.png" alt="Goverment" /></li>
                                                </ul>--%>
                                            </div>
                                            <%--<div class="col-md-6 text-center">
                                                <div style="font-size: 34px;font-weight: 600;margin-top: 10px;">Nivesh Mitra</div><span style="font-size: 17px;">Single Window Portal ,Govt. of Uttar Pradesh</span>
                                            </div>
                                            <div class="col-md-3 text-right">
                                                <ul class="mylogo-ul list-inline" style="margin:0;padding: 6px 0 9px 1px;">
                                                    <li><img src="/images/logo-img/logo_udhyog_bandu_b.png" alt="Goverment" /></li>
                                                    <li><img src="/images/logo-img/yogi.jpg" alt="Goverment" style="box-shadow: 7px 4px 8px #ccc;"/></li>
                                                </ul>
                                            </div>--%>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <p class="panel-heading text-center" style="font-size:12px"><b>Land Requisition Form</b></p>
                                    <div class="panel-body">
                                        <div id="tblallotteeinf">
                                            <p class="panel-heading"><b>Applicant Profile </b></p>

                                            <div class="form-group">
                                                <div class="row">
                                                   
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        District :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="ddlDistrict" runat="server"  CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true"  ></asp:DropDownList> 
                                                      <%--<asp:DropDownList ID="ddlregion" runat="server"  CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" OnSelectedIndexChanged="ddlregion_SelectedIndexChanged" AutoPostBack="true"  ></asp:DropDownList>--%> 
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">                                                   
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                       Sub District :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="ddlSubDistrict" runat="server"  CssClass="similar-select1 margin-left-z dropdown-toggle input-sm"  ></asp:DropDownList> 
                                                        <%--<asp:ListBox runat="server" ID="drpIndustriesArea" CssClass="MultiSelect" SelectionMode="Multiple" Width="100%"></asp:ListBox>--%>
                                                     
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                   
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Name of Investor :
                                                    </label>
                                                    <div class="col-md-8">
                                                       <asp:TextBox ID="txtInvestorName" runat="server"  CssClass="similar-select1 input-sm" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />

                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Address :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>
                                                        <%--<asp:TextBox ID="txtCompanyRegistration" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>--%>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />

                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Country:
                                                        
                                                    </label>
                                                    <div class="col-md-8">
                                                       <asp:DropDownList ID="ddlCountry" runat="server" CssClass="similar-select1 input-sm" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                       <%--<asp:TextBox ID="txtPanNo" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>--%>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        State:
                                                    </label>
                                                    <div class="col-md-8">
                                                           <asp:DropDownList ID="ddlState" runat="server" CssClass="similar-select1 input-sm"></asp:DropDownList>
                                                        <%--<asp:TextBox ID="txtGSTNO" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>--%>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />

                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        City:
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtcity" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Mobile No.:
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="similar-select1 input-sm" MaxLength="10"  onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        E-mail :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="similar-select1 input-sm" onblur="return ValidateIndividualEmail();"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                        </div>
                                        <div id="tblcompanyprofile">
                                            <p class="panel-heading"><b>Existing Company details</b></p>
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Address of Present unit :
                                                    </label>
                                                    <div class="col-md-8">
                                                         <asp:TextBox ID="txtAddressofPresentunit" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Annual Turnover :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtAnnualTurnover" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        Plot area of unit:
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtPlotareaofunit" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        F.S.I. Consumed :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtFSIConsumed" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        Water Consumed :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtWaterConsumed" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        Employment Generated :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtEmploymentGenerated" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        Remarks :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtRemarks" TextMode="MultiLine" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                              
                                            <div id="tblProjectDetails">
                                                <p class="panel-heading"><b>Proposed Project Details</b></p>
                                              
                                                <div class="form-group">
                                                    <div class="row">
                                                        <label class="col-md-4 text-right">
                                                            Nature of Project :
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtNatureofProject" runat="server" CssClass="input-sm similar-select1 margin-left-z" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                
                                                <div class="form-group">
                                                    <div class="row">
                                                        <label class="col-md-4 text-right">
                                                           Raw Material :
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtRawMaterial" runat="server" CssClass="input-sm similar-select1 margin-left-z" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />

                                                <div class="form-group">
                                                    <div class="row">
                                                        <label class="col-md-4 text-right">
                                                            Parposed Product :
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtParposedProduct1" runat="server" CssClass="input-sm similar-select1 margin-left-z" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />

                                                <div class="form-group">
                                                    <div class="row">
                                                        <label class="col-md-4 text-right">
                                                           Finance Agreement-self/Bank/FDI/Others :
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtFinanceAgreement" runat="server" CssClass="input-sm similar-select1 margin-left-z" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />

                                                <div class="form-group">
                                                    <div class="row">
                                                        <label class="col-md-4 text-right">
                                                           Total Project Cost :
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtTotalProjectCost" runat="server" CssClass="input-sm similar-select1 margin-left-z" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />

                                                <div class="form-group">
                                                    <div class="row">
                                                        <label class="col-md-4 text-right">
                                                           Built up Area :
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtBuiltupArea" runat="server" CssClass="input-sm similar-select1 margin-left-z" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />

                                                 <div class="form-group">
                                                    <div class="row">
                                                        <label class="col-md-4 text-right">
                                                           Water requirement-Domestic/Industrial:
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtWaterrequirement" runat="server" CssClass="input-sm similar-select1 margin-left-z" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <div class="row">
                                                        <label class="col-md-4 text-right">
                                                          Total No. of Employees-Skilled/Unskilled:
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtTotalNoofEmployees" runat="server" CssClass="input-sm similar-select1 margin-left-z" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                
                                                
                                                <p class="panel-heading font-bold"><b>Land Requirement Details</b></p>
                                                <div class="form-group">
                                                    <div class="row">
                                                        <label class="col-md-4 text-right">
                                                           Industry Type:
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtIndustryType" runat="server" CssClass="input-sm similar-select1" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <div class="row">
                                                        <label class="col-md-4 text-right">
                                                           Manufacturing Activity:
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtManufacturingActivity" runat="server" CssClass="input-sm similar-select1" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />

                                                <div class="form-group">
                                                    <div class="row">
                                                        <label class="col-md-4 text-right">
                                                           Preferred Location:
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtPreferredLocation" runat="server" CssClass="input-sm similar-select1" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                 <div class="form-group">
                                                    <div class="row">
                                                        <label class="col-md-4 text-right">
                                                           Required Land Size in Sq Mtr.:
                                                        </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtRequiredLandSizeinSqMtr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                
                                                
                                            </div>
                                        </div>

                                    </div>

                                    <div class="form-group" id="mandatory" style="margin-top: 15px;" runat="server">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <span style="color: blue" class="pull-left">Field marked with <span style="color: Red">* </span>are mandatory</span>
                                            </div>
                                            <div class="col-md-4 text-center">
                                                <asp:Button ID="btnSubmit" Style="margin: 0 1px 0 0; width: 65px;" CssClass="btn btn-primary btn-sm" ValidationGroup="ValidationButton" runat="server" OnClick="btnSubmit_Click"  Text="Save" /><asp:Button ID="btnReset" Style="margin: 0; width: 65px;" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnReset_Click"  Text="Reset" />
                                            </div>
                                            <div class="col-md-4"></div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>




                                </div>

                            </div>
                        </div>
                    </div>

                </div>
                <footer class="nb-footer">
                    <div class="container">
                        <div class="row">
                            <%--<div class="col-sm-12">
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
                                </div>--%>
                            <div class="col-md-3 col-sm-6">
                                <div class="footer-info-single">
                                    <h2 class="title">PUBLIC FORUM</h2>
                                    <ul class="list-unstyled">
                                        <%--<li><a href="Allotments.aspx" title=""><i class="fa fa-angle-double-right"></i>View Allottment Status</a></li>--%>
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
                </footer>

            </div>

        </div>

    </form>
 

</body >
</html >
