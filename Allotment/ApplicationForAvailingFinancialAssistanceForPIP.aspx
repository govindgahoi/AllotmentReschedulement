<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplicationForAvailingFinancialAssistanceForPIP.aspx.cs" Inherits="Allotment.ApplicationForAvailingFinancialAssistanceForPIP" %>

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

    <script type="text/javascript">
        function CheckOnlyOneCheckBox(checkbox) {

            var checkBoxList = checkbox.parentNode.parentNode.parentNode;
            var list = checkBoxList.getElementsByTagName("input");
            for (var i = 0; i < list.length; i++) {
                if (list[i] != checkbox && checkbox.checked) {
                    list[i].checked = false;
                }
            }
        }
    </script>
        <script>
        $(document).ready(function () {
            function myinc() {
                $('.myul-tabs a').removeClass('active');
                $('myul-tabs a').click(function () {
                    $(this).addClass('active');
                    alert("hello");
                });
            }

        });
    </script>
    <style>
        .active {
            background: #ccc !important;
        }
    </style>
    <style>
        .modal-open {
            overflow: auto !important;
        }

        .nav-pills {
            margin-left: 0 !important;
        }

            .nav-pills > li + li {
                margin-left: 0px !important;
            }

        .pad-lt0 {
            padding-left: 0 !important;
        }

        .pad-rt0 {
            padding-right: 0 !important;
        }

        @media only screen and (max-width: 768px) {
            .form-group label.text-right {
                text-align: left !important;
            }

            .form-group .col-sm-6 {
                width: 50% !important;
            }

            .right-niveshban {
                text-align: center;
            }

            .left-niveshban {
                text-align: center;
            }
        }

        @media only screen and (min-width: 768px) {
            .right-niveshban {
                text-align: right;
            }

            .left-niveshban {
                text-align: left;
            }
        }

        .form-group label {
            font-weight: 700 !important;
            top: 0px;
            left: 0px;
        }

        .modal-open {
            overflow: auto;
        }

        input[type=file] {
            margin: 0 !important;
            width: 207px;
        }

        .hide {
            display: none;
        }

        .show {
            display: block;
        }

        #UpdateProgress1 {
            position: fixed;
            width: 100%;
            height: 100%;
            z-index: 99999;
            background: rgba(0,0,0,0.21176470588235294);
        }

            #UpdateProgress1 .fgh {
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
            margin-left: 0 !important;
        }

            .myul-tabs li {
                width: 100%;
                border-top: 1px solid #fff;
            }

                .myul-tabs li a:after {
                    display: none;
                }

                .myul-tabs li a:before {
                    display: none;
                }

        h4.modal-title {
            margin-right: 18px !important;
        }

        .mynew-panel-head {
            font-size: 14px !important;
            font-weight: 600;
            background: #2d2d2d;
            color: #ffc511 !important;
            text-align: center !important;
        }

        .modal.fade.in {
            background: rgba(0, 0, 0, 0.51);
        }

        @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 11%;
            }

            .pad-rt0 {
                padding-right: 0;
            }

            .pad-lt0 {
                padding-left: 0;
            }
        }

        .modal-header {
            padding: 2px !important;
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

    <style>
        table {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        td, th {
           /*border: 1px solid #dddddd;*/
            text-align: left;
            padding: 8px;
        }

        tr:nth-child(even) {
            background-color: #dddddd;
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
            window.location.href = 'ApplicationForAvailingFinancialAssistanceForPIP.aspx?ID=' + ID;

        }

        function MessageAndRedirect(par) {
            alert("Objection cleared and form re-submitted successfully");
            window.location.href = 'ApplicationForLAW.aspx?ID=' + par;
        }

        function MsgAndRedirect2() {
            alert('Invalid usage');
            window.location.href = 'RegistrationLogistics.aspx';

        }

        function PrintElemF() {

            Popup($('#FinalPrint').html());
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
                                                <img src="/images/upsidclogo.png" style="width: 211px; margin-top: 12px;" alt="Goverment" />

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

                                    <div class="clearfix"></div>
                                    <div class="panel-heading font-bold text-center" style="font-size: 14px !important; font-weight: 600; background: #2d2d2d; color: #ffc511 !important;">
                                        Application for Availing Financial Assistance for Private Industrial Parks<span class="pull-right">Form No.:
                                        <asp:Label runat="server" ID="lblFormNo"></asp:Label>
                                        </span>
                                    </div>



                                    <%--<div class="row">
                                    <div class="col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Button runat="server" ID="btn_backNmswp" Text="⇦ Go Back" CssClass="pull-right btn btn-info" Style="background-color: #02486d; color: #fff; font-weight: 600;"  />
                                </div>
                                </div>--%>
                                    <div class="row">

                                        <div class="alert">

                                            <%--<span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>--%>
                                            <strong class="text-center" style="color: red; font: 800;"><u>* Disclaimer :  Please do not refresh the page or click the Back button on your browser</u></strong>

                                            <asp:Button runat="server" ID="btn_backNmswp" Text="⇦  Go Back" CssClass="pull-right btn btn-info" Style="background-color: #02486d; color: #fff; font-weight: 800; padding-top: 0px;" OnClick="btn_backNmswp_Click" />
                                        </div>




                                    </div>


                                    <div class="row">
                                        <div class="col-md-2 pad-rt0 pad-rt0">

                                            <style>
                                                #sub_menu ul {
                                                    margin-left: 0 !important;
                                                }
                                            </style>

                                            <asp:Menu
                                                ID="sub_menu"
                                                Orientation="Vertical"
                                                OnMenuItemClick="Menu1_MenuItemClick"
                                                StaticMenuStyle-CssClass="nav nav-pills myul-tabs"
                                                StaticSelectedStyle-CssClass="active selected highlighted"
                                                runat="server" Style="margin-left: 0;">
                                                <Items>

                                                     
                                                        <asp:MenuItem Text="<span style='color:red;font-weight:800;font-size:larger;'>Objections</span>"  Value="6" />
                                                    <asp:MenuItem Text="Applicant Detail" Value="0" />
                                                    <asp:MenuItem Text="Photo & Sign" Value="1" />
                                                    <asp:MenuItem Text="Project Details" Value="2" />
                                                    <asp:MenuItem Text="Land Details" Value="3" />
                                                    <asp:MenuItem Text="Upload Documents" Value="4" />
                                                    <%-- <asp:MenuItem Text="<span style='color:#1B00FD; font-weight:800;font-size:revert;'>Migration Details</span>" Value="17" />--%>
                                                    <%--   <asp:MenuItem Text="Make Payment" Value="18"/>--%>
                                                    <asp:MenuItem Text="Final Form" Value="5" />
                                                </Items>
                                            </asp:Menu>
                                        </div>
                                        <div class="col-md-10 pad-lt0" style="border-left: 1px solid #ccc;">

                                            <div id="divMessageError" class="MessagePennel" runat="server" style="display: none;">
                                                <label>
                                                    <span class="check-cross" runat="server">✖</span>

                                                    <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
                                                </label>
                                            </div>

                                            <asp:MultiView runat="server" ID="Allotment">

                                                <asp:View runat="server" ID="View1">
                                                    <asp:Label runat="server" ID="lblChosePlot" Visible="false"></asp:Label>
                                                 
                                                    <div class="clearfix"></div>


                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                                            <p class="panel-heading"><b>Authorized Signatory Details</b></p>

                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            Name :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                         <asp:TextBox ID="txtApplicantName" runat="server" class="similar-select1 input-sm" ></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            Email :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtApplicantEmail" runat="server" class="similar-select1 input-sm" ></asp:TextBox>
                                                                         
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />




                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            Designation :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtApplicantDesignation" runat="server" class="similar-select1 input-sm" ></asp:TextBox>
                                                                          
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            Mobile No :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtApplicantMobileNo" runat="server" MaxLength="10" onkeypress="return isDecimalKey(event);" class="similar-select1 input-sm" ></asp:TextBox>

                                                                         </div>
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />



                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            PAN :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtPanNo" runat="server" CssClass="similar-select1 input-sm" Style="text-transform: uppercase;" ></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            Address :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />

                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                                            <p class="panel-heading"><b>Developer/ Promoter/ SPV Details </b></p>



                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            Name :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtPromoterName" runat="server" class="similar-select1 input-sm"></asp:TextBox>
                                                                         
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            Email :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtPromoterEmail" runat="server" class="similar-select1 input-sm" ></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                              <div class="clearfix"></div>
                                                            <hr class="myhrline" />
                                                                   <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            SPV :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                                 <asp:DropDownList ID="ddlSPV" runat="server" AutoPostBack="true"  CssClass="similar-select1 margin-left-z dropdown-toggle input-sm"  OnSelectedIndexChanged="ddlSPV_SelectedIndexChanged">
                                                                                          <asp:ListItem Value="NO">NO</asp:ListItem>
                                                                                 <asp:ListItem Value="YES">YES</asp:ListItem>
                                                                           </asp:DropDownList>
                                                                     </div>
                                                                    </div>
                                                                </div>

                                                            </div>




                                                         
                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            Person Contact No :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtPersonContactNo" runat="server" class="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                                          
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>

                                                               <div class="clearfix"></div>
                                                            <hr class="myhrline" />
                                                          
                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                         <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            Website :
															                           
                                                                        </label>
                                                                         <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtWebsite" runat="server" class="similar-select1 input-sm" ></asp:TextBox>
                                                                          
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                              

                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                       <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            Address :
															                           
                                                                        </label>
                                                            
                                                                                 <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtPromoterAddress" runat="server" class="similar-select1 input-sm" ></asp:TextBox>
                                                                        
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                           
                                                              <div class="clearfix"></div>
                                                            <hr class="myhrline" />
                                                                <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                             Constitution of Firm/Company :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                           
                                                                           <asp:DropDownList ID="ddlcompanytype" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CompanyTypeddl_selectedindex_changed"    CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" ></asp:DropDownList>
                                                                     </div>
                                                                    </div>
                                                                </div>

                                                            </div>




                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />

                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                                            <p class="panel-heading"><b>Beneficiary Bank Details for Disbursal of Incentives</b></p>



                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            Beneficiary Name :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtBeneficiaryName" runat="server" class="similar-select1 input-sm" ></asp:TextBox>
                                                                          
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            Bank Account No. :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtBankAccountNo" runat="server" class="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                                         
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />




                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            Type of Account :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:DropDownList ID="txtTypeOfAccount" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" runat="server"  >
                                                                              
                                                                               <asp:ListItem Text="Savings" Value="0" Selected="True">--Select--</asp:ListItem>
                                                                                <asp:ListItem Text="Savings" Value="1">Savings</asp:ListItem>
                                                                                <asp:ListItem Text="Current" Value="2">Current</asp:ListItem>
                                                                                <asp:ListItem Text="Salary" Value="3">Salary</asp:ListItem>
                                                                                <asp:ListItem Text="NRI" Value="4">NRI</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            IFSC Code :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtIFSCCode" runat="server" class="similar-select1 input-sm" ></asp:TextBox>
                                                                          
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />



                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            Name of Bank :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtNameofBank" runat="server" class="similar-select1 input-sm" ></asp:TextBox>
                                                                        
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-left">
                                                                            <span style="color: Red">*</span>
                                                                            Branch Address :
															                           
                                                                        </label>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtBranchAddress" runat="server" class="similar-select1 input-sm" ></asp:TextBox>
                                                                         
                                                                        </div>
                                                                    </div>
                                                                </div>






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
                                                            <div runat="server" id="Screen11" class="col-md-12 col-sm-12 col-xs-12 text-center">
                                                                <asp:Button runat="server" ID="BtnSaveApplicant" CssClass="btn btn-sm btn-primary" Text="Proceed" Style="text-align: center; padding: 4px 10px !important; margin: 10px 0;" OnClientClick="return ccheck1();" OnClick="BtnSaveApplicant_Click" />
                                                            </div>

                                                            <asp:Label runat="server" ID="LblAllotteeId" Visible="false"></asp:Label>
                                                            <asp:Label runat="server" ID="LblAllotteeIdMain" Visible="false"></asp:Label>




                                                            <asp:Label ID="lblImageName" runat="server" Visible="false"></asp:Label>
                                                </asp:View>

                                                <asp:View runat="server">


                                                    <div class="row">
                                                        <div class="panel panel-default">
                                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                <div class="col-md-1 col-sm-12 col-xs-12"></div>
                                                                <div class="col-md-10 col-sm-12 col-xs-12" style="margin-bottom: 10px;">
                                                                    <div class="row">
                                                                        <div class="col-md-6 col-sm-6 col-xs-12 text-center">
                                                                            <div class="myborder" style="border: 1px solid #ccc;">
                                                                                <div class="panel-heading">Photograph</div>
                                                                                <div style="height: 200px; padding: 5px;">
                                                                                    <asp:Image ID="ImgPrv" runat="server" src="/images/account-icon-5.jpg" class="img-sign" alt="image" Style="height: 200px; margin: 0 auto;" />
                                                                                    <asp:Image ID="Image1" runat="server" Style="height: 200px; margin: 0 auto;" Visible="false" />
                                                                                    <asp:Label runat="server" ID="lblImagetype" Visible="false"></asp:Label>

                                                                                </div>
                                                                                <br />
                                                                                <div style="border: 1px solid #ccc; padding: 5px;">
                                                                                    <asp:FileUpload ID="FuplodApplicantImage" onchange="ShowImagePreview(this);" Width="100%" CssClass="form-control" runat="server" />
                                                                                    <button runat="server" id="btnSaveImage" class="btn-primary btn-sm ey-bg" style="padding: 2px 6px; margin: 5px 0;" onserverclick="btnSaveImage_ServerClick">Upload Photograph</button>
                                                                                    <div class="clearfix"></div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6 col-sm-6 col-xs-12 text-center">
                                                                            <div class="myborder" style="border: 1px solid #ccc;">
                                                                                <div class="panel-heading">Signature</div>
                                                                                <div style="height: 200px; padding: 5px;">
                                                                                    <img id="ImgPrvSign" src="images/signature.png" runat="server" class="img-sign" alt="image" style="margin: 50px auto 0 auto; height: 100px;" />
                                                                                    <asp:Image ID="Image2" runat="server" Style="margin: 50px auto 0 auto; height: 100px;" Visible="false" />

                                                                                </div>
                                                                                <br />
                                                                                <div style="border: 1px solid #ccc; padding: 5px;">
                                                                                    <asp:FileUpload ID="FuplodApplicantSign" Width="100%" onchange="ShowSignPreview(this);" CssClass="form-control" runat="server" />
                                                                                    <button runat="server" id="btnSaveSign" class="btn-primary btn-sm ey-bg" style="padding: 2px 6px; margin: 5px 0;" onserverclick="btnSaveSign_ServerClick">Upload Signature</button>
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


                                                    <div class="panel-heading text-center"><b>Applicant Project Details</b></div>
                                                    <p class="panel-heading font-bold">Proposed Area</p>
                                                    <div class="form-group">
                                                    </div>
                                                  
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 text-left">
                                                                <span style="color: Red">*</span>
                                                                Name of Industrial Park :
                                                            </label>
                                                            <div class="col-md-6 col-sm-6 col-xs-6  text-left">
                                                                <asp:TextBox ID="PANameofIndustrialPark"  runat="server" CssClass=" input-sm similar-select1"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                                        <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 text-left">
                                                                <span style="color: Red">*</span>
                                                                Area of Industrial Park (in Acres) :
                                                            </label>
                                                            <div class="col-md-6 col-sm-6 col-xs-6 text-left" >
                                                             
                                                                <asp:TextBox ID="PAAreaofIndustrialParkinAcres" runat="server" 
                                                                    onkeypress="return isDecimalKey(event);" CssClass="input-sm similar-select1" Width="98%" ></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                                  
                                                  
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div style="display: none;">
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-6 col-sm-6 col-xs-6 text-left">
                                                                    <span style="color: Red">*</span>
                                                                    Registration/Permit for setting Logistic and Warehousing Unit :
                                                                </label>
                                                                <div class="col-md-6 col-sm-6 col-xs-6 text-left"">
                                                                    <asp:TextBox ID="txtRegistrationNo" runat="server" CssClass="input-sm similar-select1" Width="98%" onblur="ValidateRequired(this,'Registration/Permit for setting Logistic and Warehousing Unit');"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                    </div>
                                                    <p class="panel-heading font-bold">FAR Details</p>
                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                              <span></span>  FAR
                                                            </label>
                                                            <label class="col-md-3 col-sm-2 col-xs-2 text-left">
                                                                As Per Guidelines
                                                            </label>
                                                            <label class="col-md-1 col-sm-6 col-xs-6 text-left">
                                                                Utilized
                                                            </label>

                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />

                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-left">
                                                                <span style="color: Red">*</span>  Industrial:
                                                            </label>
                                                          
                                                            <label class="col-md-2 col-sm-2 col-xs-2 text-left">
                                                                5
                                                            </label>

                                                            <div class="col-md-6 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtFarIndustrialAsPerGuidelines" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                      <div class="form-group">
                                                    <div class="row">
                                                        <label class="col-md-4 col-sm-6 col-xs-6 text-left">
                                                            <span style="color: Red">*</span>  Commercial:
                                                        </label>
                                                      
                                                        <label class="col-md-2 col-sm-2 col-xs-2 text-left">
                                                            4
                                                        </label>

                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="FarCommercialAsPerGuidelines" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                         
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="row">
                                                        <label class="col-md-4 col-sm-6 col-xs-6 text-left">
                                                            <span style="color: Red">*</span>  Roads:
                                                        </label>
                                                      
                                                        <label class="col-md-2 col-sm-2 col-xs-2 text-left">
                                                            3
                                                        </label>

                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="FarRoadsAsPerGuidelines" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                        </div>
                                                    </div>


                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="row">
                                                        <label class="col-md-4 col-sm-6 col-xs-6 text-left">
                                                            <span style="color: Red">*</span>  Green and Open Spaces:
                                                        </label>
                                                     
                                                        <label class="col-md-2 col-sm-2 col-xs-2 text-left">
                                                            2
                                                        </label>

                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="FarGreenandOpenSpacesAsPerGuidelines" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="row">
                                                        <label class="col-md-4 col-sm-6 col-xs-6 text-left">
                                                             <span style="color: Red">*</span> Utilities:
                                                        </label>
                                                     
                                                        <label class="col-md-2 col-sm-2 col-xs-6 text-left">
                                                            1
                                                        </label>

                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="FarUtilitiesAsPerGuidelines" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                        </div>
                                                    </div>


                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="row">
                                                        <label class="col-md-4 col-sm-6 col-xs-6 text-left">
                                                            <span style="color: Red">*</span>  Hostel/ Dormitory:
                                                        </label>
                                                      
                                                        <label class="col-md-2 col-sm-2 col-xs-2 text-left">
                                                            7
                                                        </label>

                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="FarHostelDormitoryAsPerGuidelines" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                                        </div>
                                                    </div>

 </div>


                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <p class="panel-heading font-bold">Benefit Details</p>






                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 text-left">
                                                                <span style="color: Red">*</span>
                                                                Exemption on Stamp Duty (in Cr)
                                                            </label>
                                                            <div class="col-md-6 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="ExemptiononStampDutyinCr" onkeypress="return isDecimalKey(event);" runat="server" CssClass=" input-sm similar-select1" ></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                              <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 text-left">
                                                                <span style="color: Red">*</span>
                                                                Capital Subsidy on Eligible Fixed Capital Investment (in Cr)
                                                            </label>
                                                            <div class="col-md-6 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="CapitalSubsidyonEligibleFixedCapitalInvestmentinCr" onkeypress="return isDecimalKey(event);" runat="server" CssClass=" input-sm similar-select1"  ></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                              <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 text-left">
                                                                <span style="color: Red">*</span>
                                                                Capital Subsidy on Cost of Building Hostel/ Dormitory Housing (in Cr):	
                                                            </label>
                                                            <div class="col-md-6 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="CapitalSubsidyonCostofBuildingHostelDormitoryHousinginCr" onkeypress="return isDecimalKey(event);" runat="server" CssClass=" input-sm similar-select1"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                              <hr class="myhrline" />

                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 text-left">
                                                                 <span style="color: Red">*</span> Total Amount of Financial Assistance Sought (in Cr):		
                                                            </label>
                                                            <div class="col-md-6 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="TotalAmountofFinancialAssistanceSoughtinCr" onkeypress="return isDecimalKey(event);" runat="server" CssClass=" input-sm similar-select1"  ></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                             
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <p class="panel-heading font-bold">Fixed Capital Investment</p>


                                                   


                                                       <div class="form-group">
                                                  <div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 text-left">
                                                                Infrastructure
                                                            </label>
                                                        <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                               Area(in Acres)
                                                            </label>
                                                        <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                              Cost(in Cr.)
                                                            </label>
                                                        </div>
  <hr class="myhrline" />
                                                        <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                               1
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                             Roads & Streetlighting
                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                             <asp:TextBox ID="IRoadsStreetlightingAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                          <asp:TextBox ID="IRoadsStreetlightingCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                                         </div>
                                                       </div>
                                                             <hr class="myhrline" />
                                                            <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            2
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           
                                                                   Water
                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:TextBox ID="IWaterAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="IWaterCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>

                                                         </div>
                                                       </div>
                                                             <hr class="myhrline" />
                                                            <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            3
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           
                                                                   Sewerage & Drainage
                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="ISewerageDrainageAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                          
                                                           <asp:TextBox ID="ISewerageDrainageCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                         </div>
                                                       </div>  
                                                             <hr class="myhrline" />
                                                        <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            4
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Power Supply

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="IPowerSupplyAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                          
                                                          
                                                         
                                                         

                                                         <asp:TextBox ID="IPowerSupplyCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                         </div>
                                                       </div>
                                                             <hr class="myhrline" />
                                                             <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            5
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Warehousing

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                          <asp:TextBox ID="IWarehousingAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                          
                                                           <asp:TextBox ID="IWarehousingCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                                         </div>
                                                       </div>
                                                             <hr class="myhrline" />
                                                      

  <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            6
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Parking & Trucking Bays

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:TextBox ID="IParkingTruckingBaysAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                             <asp:TextBox ID="IParkingTruckingBaysCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>

                                                         </div>
                                                       </div>
                                                           
                     <hr class="myhrline" />                                  

  <div class="row">
                                                              <label class="col-md-6 col-sm-6 col-xs-6 text-left">
                                                            Common Facilities
                                                            </label>
                                                            
                                                           
                                                       </div>
                                                            <hr class="myhrline" />   
                                                            

  <div class="row">
      
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            7
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Weight Bridge

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:TextBox ID="CFWeightBridgeAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                          
                                                           <asp:TextBox ID="CFWeightBridgeCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                         </div>
                                                       </div>
  <hr class="myhrline" />

                                                      

  <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            8
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Skill Development Centre

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:TextBox ID="CFSkillDevelopmentCentreAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:TextBox ID="CFSkillDevelopmentCentreCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>

                                                         </div>
                                                       </div>
                                                                                <hr class="myhrline" />   
                                                    

  <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            9
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Computer Centre

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="CFComputerCentreAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:TextBox ID="CFComputerCentreCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>

                                                         </div>
                                                       </div>
                                                                           <hr class="myhrline" />   

  <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            10
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Product Development Centre

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="CFProductDevelopmentCentreAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                             <asp:TextBox ID="CFProductDevelopmentCentreCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>

                                                         </div>
                                                       </div>
                                                                                <hr class="myhrline" />   
                                                      <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            11
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Testing Centre

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:TextBox ID="CFTestingCentreAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                          
                                                           <asp:TextBox ID="CFTestingCentreCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                         </div>
                                                       </div>
                                                                            <hr class="myhrline" />   
                                                             <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            12
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           
                                                                   R & D Centre
                                                            </label>
                                                                  <div class="col-md-3 col-sm-3 col-xs-3">
                                                          <asp:TextBox ID="CFRandDCentreAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>

                                                         </div>
                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:TextBox ID="CFRandDCentreCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                                           </div>
                                                    
                                                       </div>
                                                                           <hr class="myhrline" />   

                                                             <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            13
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Container Freight Station

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="CFContainerFreightStationAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="CFContainerFreightStationCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>

                                                         </div>
                                                       </div>
                                                            <hr class="myhrline" />   

                                                    <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            14
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Repair workshop for Vehicles

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:TextBox ID="CFRepairworkshopforVehiclesAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="CFRepairworkshopforVehiclesCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>

                                                         </div>
                                                       </div>
 <hr class="myhrline" />   
                                                         <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            15
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           
                                                                   Business & Commercial Facilities
                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="BCFFacilitiesCanteenAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="BCFFacilitiesCanteenCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>

                                                         </div>
                                                       </div>
                                                            <hr class="myhrline" />   
                                                             <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            16
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Medical Centre

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="BCFMedicalCentreAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="BCFMedicalCentreCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>

                                                         </div>
                                                       </div>
                                                        <hr class="myhrline" />   
                                                             <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            17
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Petrol Pump

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                             <asp:TextBox ID="BCFPetrolPumpAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                          
                                                          <asp:TextBox ID="BCFPetrolPumpCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                         </div>
                                                       </div>
                                                      <hr class="myhrline" />   
                                                      <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            18
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Banking & Finance

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="BCFBankingandFinanceAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                          

                                                         <asp:TextBox ID="BCFBankingandFinanceCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>

                                                         </div>
                                                       </div>
                                                            <hr class="myhrline" />   
                                                            <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           19
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Office Space

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:TextBox ID="BCFOfficeSpaceAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                             <asp:TextBox ID="BCFOfficeSpaceCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>

                                                         </div>
                                                       </div> <hr class="myhrline" />   
                                                        <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            20
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Hotel/ Restaurants

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:TextBox ID="BCFHotelRestaurantsAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="BCFHotelRestaurantsCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'');"></asp:TextBox></td>

                                                         </div>
                                                       </div>
                                                       <hr class="myhrline" />   
                                                            <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            21
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                        
Hospital/Dispensary
                                                            </label>
                                                                 <div class="col-md-3 col-sm-3 col-xs-3">
                                                              <asp:TextBox ID="BCFHospitalDispensaryAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'');"></asp:TextBox></td>

                                                         </div>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:TextBox ID="BCFHospitalDispensaryCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'');"></asp:TextBox></td>
                                                           </div>
                                                    
                                                       </div>
                                                            <hr class="myhrline" />   
                                                    <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            22
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Administration Office

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:TextBox ID="BCFAdministrationOfficeAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'');"></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                          <asp:TextBox ID="BCFAdministrationOfficeCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'');"></asp:TextBox></td>

                                                         </div>
                                                       </div>
                                                            <hr class="myhrline" />   
                                                   <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            23
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Warehousing Facilities

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="BCFWarehousingFacilitiesAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'');"></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                          <asp:TextBox ID="BCFWarehousingFacilitiesCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'');"></asp:TextBox></td>
                                                         </div>
                                                       </div>
                                                            <hr class="myhrline" />   
                                                       <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            24
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           Housing/ Dormitory/ Hostel for Domicile Worke

                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="BCFHousingDormitoryHostelforDomicileWorkeAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'');"></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:TextBox ID="BCFHousingDormitoryHostelforDomicileWorkeCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'');"></asp:TextBox></td>

                                                         </div>
                                                       </div>
                                                            <hr class="myhrline" />   
                                                       <div class="row">
                                                              <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                            25
                                                            </label>
                                                               <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                           
                                                                   Other
                                                            </label>

                                                      <div class="col-md-3 col-sm-3 col-xs-3">
                                                             <asp:TextBox ID="OtherAreainAcres" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'');"></asp:TextBox></td>
                                                           </div>
                                                     <div class="col-md-3 col-sm-3 col-xs-3">
                                                           <asp:TextBox ID="OtherCostinCr" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'');"></asp:TextBox></td>

                                                         </div>
                                                       </div>

                                                         <hr class="myhrline" />   

                                                           

                                               



                                      
                                         <div class="clearfix"></div>
                                                    <p class="panel-heading font-bold">Unit Details</p>



                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 text-left">
                                                              
                                                            </label>
                                                            <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                                Unit Name
                                                            </label>
                                                            <label class="col-md-3 col-sm-3 col-xs-3 text-left">
                                                                Type
                                                            </label>


                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />

                                                        <div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 text-left">
                                                                <span style="color: Red">*</span> 1
                                                            </label>

                                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="udunitname1" runat="server" CssClass="input-sm similar-select1"  ></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="udunitnametype1" runat="server" CssClass="input-sm similar-select1" ></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />

                                                        <div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 text-left">
                                                               <span style="color: Red">*</span>  2
                                                            </label>

                                                            <div class="col-md-3 col-sm-3 col-xs-3">
                                                                <asp:TextBox ID="udunitname2" runat="server" CssClass="input-sm similar-select1"  ></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-3 col-sm-3 col-xs-3">
                                                                <asp:TextBox ID="udunitnametype2" runat="server" CssClass="input-sm similar-select1"  ></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />

                                                        <div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 text-left">
                                                              <span style="color: Red">*</span>   3
                                                            </label>

                                                            <div class="col-md-3 col-sm-3 col-xs-3">
                                                                <asp:TextBox ID="udunitname3" runat="server" CssClass="input-sm similar-select1"  ></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-3 col-sm-3 col-xs-3">
                                                                <asp:TextBox ID="udunitnametype3" runat="server" CssClass="input-sm similar-select1"  ></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />

                                                        <div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 text-left">
                                                              <span style="color: Red">*</span>   4
                                                            </label>

                                                            <div class="col-md-3 col-sm-3 col-xs-3">
                                                                <asp:TextBox ID="udunitname4" runat="server" CssClass="input-sm similar-select1" ></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-3 col-sm-3 col-xs-3">
                                                                <asp:TextBox ID="udunitnametype4" runat="server" CssClass="input-sm similar-select1" ></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />

                                                        <div class="row">
                                                            <label class="col-md-6 col-sm-6 col-xs-6 text-left">
                                                              <span style="color: Red">*</span>   5
                                                            </label>

                                                            <div class="col-md-3 col-sm-3 col-xs-3">
                                                                <asp:TextBox ID="udunitname5" runat="server" CssClass="input-sm similar-select1"  ></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-3 col-sm-3 col-xs-3">
                                                                <asp:TextBox ID="udunitnametype5" runat="server" CssClass="input-sm similar-select1"  ></asp:TextBox>
                                                            </div>
                                                        </div>
                                                

                                                    <p class="panel-heading font-bold">
                                                         <label><span style="color: Red">*</span>    Implementation Schedule</label>     
                                                    </p>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />

                                                    <div class="form-group">
                                                    
                                                        <div >
                                                            <label  style="width: 3%; vertical-align:top;">
                                                                Year
                                                            </label>
                                                            <label  style="width: 14%;vertical-align:top;">
                                                                Date of acquiring  land
                                                            </label>
                                                            <label   style="width: 15%;vertical-align:top;">
                                                                Start of Construction Date
                                                            </label>
                                                            <label   style="width: 16%;vertical-align:top;">
                                                                Completion of Infrastructure Date  
                                                            </label>

                                                            <label   style="width: 17%;vertical-align:top;">
                                                                Date of Placing order for Plant & Machinery    
                                                            </label>
                                                            <label   style="width: 15%;vertical-align:top;">
                                                                Installation/Erection Date    
                                                            </label>
                                                            <label   style="width: 16%;vertical-align:top;">
                                                                Date of Commercial Operation
                                                            </label>




                                                        </div>

                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                           <label  class="col-md-1 col-sm-6 col-xs-6  text-left style" style="width:3%">
                                                             1
                                                            </label>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:14%">
                                                                <asp:TextBox ID="Dateofacquiringlandyear1" runat="server" CssClass="date input-sm similar-select1" ></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:15%" >
                                                                <asp:TextBox ID="StartofConstructionDateyear1" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:16%">
                                                                <asp:TextBox ID="CompletionofInfrastructureDateyear1" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:17%">
                                                                <asp:TextBox ID="DateofPlacingorderforPlantandMachineryyear1"  runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:15%">
                                                                <asp:TextBox ID="InstallationErectionDateyear1" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:16%">
                                                                <asp:TextBox ID="Proposeddateforcompletionyear1" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                        </div>

                                                        <hr class="myhrline" />

                                                        <div class="row">
                                                            <label class="col-sm-1  col-xs-6 text-left" style="width:3%">
                                                                2
                                                            </label>
                                                            <div class="col-md-1 col-sm-6 col-xs-6  text-left" style="width:14%">
                                                                <asp:TextBox ID="Dateofacquiringlandyear2" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left"  style="width:15%">
                                                                <asp:TextBox ID="StartofConstructionDateyear2" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left"  style="width:16%">
                                                                <asp:TextBox ID="CompletionofInfrastructureDateyear2" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left"  style="width:17%">
                                                                <asp:TextBox ID="DateofPlacingorderforPlantandMachineryyear2" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left"  style="width:15%">
                                                                <asp:TextBox ID="InstallationErectionDateyear2" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left"  style="width:16%">
                                                                <asp:TextBox ID="Proposeddateforcompletionyear2" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-sm-1  col-xs-6 text-left" style="width:3%">
                                                                3
                                                            </label>
                                                            <div class="col-md-1 col-sm-6 col-xs-6  text-left" style="width:14%">
                                                                <asp:TextBox ID="Dateofacquiringlandyear3" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:15%">
                                                                <asp:TextBox ID="StartofConstructionDateyear3" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:16%">
                                                                <asp:TextBox ID="CompletionofInfrastructureDateyear3" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:17%">
                                                                <asp:TextBox ID="DateofPlacingorderforPlantandMachineryyear3"  runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:15%">
                                                                <asp:TextBox ID="InstallationErectionDateyear3" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:16%">
                                                                <asp:TextBox ID="Proposeddateforcompletionyear3" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-sm-1  col-xs-6 text-left" style="width:3%">
                                                                4
                                                            </label>
                                                            <div class="col-md-1 col-sm-6 col-xs-6  text-left" style="width:14%">
                                                                <asp:TextBox ID="Dateofacquiringlandyear4" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:15%">
                                                                <asp:TextBox ID="StartofConstructionDateyear4" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:16%">
                                                                <asp:TextBox ID="CompletionofInfrastructureDateyear4" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:17%">
                                                                <asp:TextBox ID="DateofPlacingorderforPlantandMachineryyear4" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left"style="width:15%">
                                                                <asp:TextBox ID="InstallationErectionDateyear4" runat="server"  CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:16%">
                                                                <asp:TextBox ID="Proposeddateforcompletionyear4" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-sm-1  col-xs-6 text-left" style="width:3%">
                                                                5
                                                            </label>
                                                            <div class="col-md-1 col-sm-6 col-xs-6  text-left" style="width:14%">
                                                                <asp:TextBox ID="Dateofacquiringlandyear5" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:15%">
                                                                <asp:TextBox ID="StartofConstructionDateyear5" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:16%">
                                                                <asp:TextBox ID="CompletionofInfrastructureDateyear5" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:17%">
                                                                <asp:TextBox ID="DateofPlacingorderforPlantandMachineryyear5" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:15%">
                                                                <asp:TextBox ID="InstallationErectionDateyear5" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  text-left" style="width:16%">
                                                                <asp:TextBox ID="Proposeddateforcompletionyear5" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row" runat="server" id="sixrows" visible="false">
                                                            <label class="col-sm-1  col-xs-6 text-left" style="width:3%">
                                                                6
                                                            </label>

                                                            <div class="col-md-1 col-sm-6 col-xs-6" style="width:14%">
                                                                <asp:TextBox ID="Dateofacquiringlandyear6"  runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6" style="width:15%">
                                                                <asp:TextBox ID="StartofConstructionDateyear6" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6" style="width:16%">
                                                                <asp:TextBox ID="CompletionofInfrastructureDateyear6" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6" style="width:17%">
                                                                <asp:TextBox ID="DateofPlacingorderforPlantandMachineryyear6" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6" style="width:15%">
                                                                <asp:TextBox ID="InstallationErectionDateyear6" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6" style="width:16%">
                                                                <asp:TextBox ID="Proposeddateforcompletionyear6" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>

                                                            </div>
                                                        </div>

                                                    </div>

                                                    <p class="panel-heading font-bold">
                                                        Other Details 
                                                    </p>



                                                    <div class="form-group">

                                                        <div class="row">

                                                            <label class="col-md-3 col-xs-6 text-left">
                                                               <span style="color: Red">*</span>  Environmental Clearances
                                                            </label>
                                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                                <asp:CheckBoxList ID="EnvironmentalClearances" runat="server" RepeatDirection="Horizontal">
                                                                       <asp:ListItem Value="1"  onclick="CheckOnlyOneCheckBox(this);"> Yes </asp:ListItem>
                                                                      <asp:ListItem Value="0"  onclick="CheckOnlyOneCheckBox(this);"> NO </asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </div>



                                         


                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">

                                                            <label class="col-md-4 col-xs-6 text-left">
                                                              <span style="color: Red">*</span>   Operations and Maintenance to be Taken up by
                                                            </label>
                                                            <div class="col-md-6 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="OperationsandMaintenancetobeTakenupby" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>

                                                            </div>

                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-12 col-xs-6 text-left">
                                                                Detailed Project Report Summary
                                                            </label>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">

                                                            <label class="col-md-4 col-xs-6 text-left">
                                                              <span style="color: Red">*</span>   Cash Flow Projections
                                                            </label>


                                                            <div class="col-md-6 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="CashFlowProjections" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-xs-6 text-left">
                                                                Year
                                                            </label>
                                                            <label class="col-md-4 col-xs-6 text-left">
                                                               <span style="color: Red">*</span>  Projected Inflow (in Cr)
                                                            </label>
                                                            </label>
                                                                    <label class="col-md-4 col-xs-6 text-left">
                                                          <span style="color: Red">*</span>   Projected Outflow (in Cr)
                                                         
                                                                     
                                                        </div>

                                                        <hr class="myhrline" />
                                                        <div class="row">


                                                            <label class="col-md-4 col-xs-6 text-left">
                                                                1
                                                            </label>
                                                            <div class="col-md-4 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="ProjectedInflowinCrYear1" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-4 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="ProjectedOutflowinCrYear1" onkeypress="return isDecimalKey(event);" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>

                                                            </div>
                                                        </div>

                                                        <hr class="myhrline" />
                                                        <div class="row">


                                                            <label class="col-md-4 col-xs-6 text-left">
                                                                2
                                                            </label>
                                                            <div class="col-md-4 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="ProjectedInflowinCrYear2" onkeypress="return isDecimalKey(event);" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-4 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="ProjectedOutflowinCrYear2" onkeypress="return isDecimalKey(event);" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>

                                                            </div>




                                                        </div>







                                                        <hr class="myhrline" />
                                                        <div class="row">


                                                            <label class="col-md-4 col-xs-6 text-left">
                                                                3
                                                            </label>
                                                            <div class="col-md-4 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="ProjectedInflowinCrYear3" onkeypress="return isDecimalKey(event);" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-4 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="ProjectedOutflowinCrYear3" onkeypress="return isDecimalKey(event);" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>

                                                            </div>
                                                        </div>

                                                        <hr class="myhrline" />
                                                        <div class="row">


                                                            <label class="col-md-4 col-xs-6 text-left">
                                                                4
                                                            </label>
                                                            <div class="col-md-4 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="ProjectedInflowinCrYear4" onkeypress="return isDecimalKey(event);" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-4 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="ProjectedOutflowinCrYear4" onkeypress="return isDecimalKey(event);" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>

                                                            </div>
                                                        </div>

                                                        <hr class="myhrline" />
                                                        <div class="row">


                                                            <label class="col-md-4 col-xs-6 text-left">
                                                                5
                                                            </label>
                                                            <div class="col-md-4 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="ProjectedInflowinCrYear5" onkeypress="return isDecimalKey(event);" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-4 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="ProjectedOutflowinCrYear5" onkeypress="return isDecimalKey(event);" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>

                                                            </div>
                                                        </div>


                                                    </div>
                                                    <hr class="myhrline" />

                                                    <div class="row">
                                                        <label class="col-md-4 col-sm-6 col-xs-6 text-left">
                                                            <span style="color: Red">*</span> Building Plan Approval Status:
                                                        </label>


                                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                                            <asp:DropDownList ID="BuildingPlanApprovalStatus" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" runat="server">
                                                                <asp:ListItem Text="--Select--" Value="0" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Approved" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Under Process" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Rejected" Value="3"></asp:ListItem>
                                                            </asp:DropDownList>


                                                        </div>
                                                    </div>

                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="row">
                                                        <label class="col-md-4 col-sm-6 col-xs-6 text-left">
                                                             <span style="color: Red">*</span>Building Plan Approved from (Authority)
                                                        </label>
                                                        <%-- <div class="col-md-4 col-sm-6 col-xs-6">
                                                            <i class="fa fa-inr"></i>
                                                            <asp:TextBox ID="TextBox7" runat="server" CssClass="input-sm similar-select1" Width="93%" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Cost of the Land');"></asp:TextBox>
                                                        </div>--%>
                                                        <%--<div class="hidden-lg hidden-md">
                                                                <div class="clearfix"></div>
                                                            </div>--%>


                                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                                            <asp:DropDownList ID="BuildingPlanApprovedfromAuthority" runat="server" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" AutoPostBack="true" OnSelectedIndexChanged="BuildingPlanApprovedfromAuthority_SelectedIndexChanged">
                                                                <asp:ListItem Text="--Select--" Value="0" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="YEIDA" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="UPSIDA" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="LIDA" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="UPEIDA" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="GNIDA" Value="5"></asp:ListItem>
                                                                <asp:ListItem Text="GIDA" Value="6"></asp:ListItem>
                                                                <asp:ListItem Text="NOIDA" Value="7"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>


                                                    </div>


                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="row" id="txthide" visible="false" runat="server">
                                                        <label class="col-md-4 col-sm-6 col-xs-6 text-left">
                                                            <span style="color: Red">*</span> Building Plan Application Id (OBPAS)	
                                                        </label>

                                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="BuildingPlanApplicationIdOBPAS"  runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="row">
                                                        <label class="col-md-4 col-sm-6 col-xs-6 text-left">
                                                           <span style="color: Red">*</span>  Ownership of Hostel/ Dormitory (Company):
                                                        </label>
                                                       


                                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="OwnershipofHostelDormitoryCompany" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                                        </div>
                                                    </div>





                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="row">
                                                        <label class="col-md-4 col-sm-6 col-xs-6 text-left">
                                                           <span style="color: Red">*</span>  Any Other Information	
                                                        </label>
                                                     

                                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="AnyOtherInformation" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                                        </div>
                                                    </div>








                                                    </div>

                                                           </div>













                                                  
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div runat="server" id="Div1" class="col-md-12 col-sm-12 col-xs-12 text-center">
                                                        <asp:Button runat="server" ID="Button1" CssClass="btn btn-sm btn-primary" Text="Submit" Style="text-align: center; padding: 4px 10px !important; margin: 10px 0;" OnClientClick="return ccheck2();" OnClick="BtnProjectInsert_Click" />
                                                    </div>
                                                </asp:View>

                                                <asp:View runat="server" ID="View3">
                                                    <div class="clearfix"></div>
                                                    <div class="panel-heading text-center font-bold">Land Breakup Details</div>
                                                    <div class="clearfix"></div>
                                                    <div class="row">
                                                        <div class="panel panel-default">
                                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-right"><span style="color: Red">*</span> District :</label>
                                                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                                                            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" AutoPostBack="true"></asp:DropDownList>
                                                                            <asp:TextBox ID="txtDistrict" runat="server" Visible="false" CssClass="similar-select1 input-sm" onblur="ValidateRequired(this,'District');"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                                                            <span style="color: Red">*</span>
                                                                            Tehsil :
                                                                        </label>
                                                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="txtTehsil" runat="server" CssClass="similar-select1 input-sm" onblur="ValidateRequired(this,'Tehsil');"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                                                            <span style="color: Red">*</span>
                                                                            Village :
                                                                        </label>
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
                                                                            <asp:TextBox ID="txtKhasraNo" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Khasra Number');"></asp:TextBox>
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
                                                                            <asp:TextBox ID="txtValueOfLand" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'  Value of land as per lease /purchase deed agreement (inr cr)');"></asp:TextBox>
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
                                                                            <asp:TextBox ID="txtStampDutyPaid" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,' Stamp Duty Paid as per lease/purchase agreement (inr cr) ');"></asp:TextBox>
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
                                                                            <asp:DropDownList ID="ddlExistingLand" runat="server" CssClass="chosen margin-left-z input-sm similar-select1" AutoPostBack="True" OnSelectedIndexChanged="ddlProjectDetails_SelectedIndexChanged">
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
                                                                            <asp:TextBox ID="anyOtherExistingProject" runat="server" CssClass="input-sm similar-select1" Visible="false"></asp:TextBox>
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
                                                                            <asp:DropDownList ID="ddlLandContiguous" runat="server" CssClass="chosen margin-left-z input-sm similar-select1" AutoPostBack="True" OnSelectedIndexChanged="ddlLandContiguous_SelectedIndexChanged">
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
                                                                            <asp:DropDownList ID="ddlGramGov" runat="server" CssClass="chosen margin-left-z input-sm similar-select1" AutoPostBack="True" OnSelectedIndexChanged="ddlGramGov_SelectedIndexChanged">
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
                                                                            <asp:DropDownList ID="ddlLandExchange" runat="server" CssClass="chosen margin-left-z input-sm similar-select1" AutoPostBack="True" OnSelectedIndexChanged="ddlLandExchange_SelectedIndexChanged" >
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
                                                                            <span style="color: Red">*</span>
                                                                            Land Conversion Charges Paid, if any (in Cr):
                                                                        </label>
                                                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="LandConversionChargesPaidifanyinCr" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'');"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <label class="col-md-5 col-sm-6 col-xs-6 text-right">
                                                                            <span style="color: Red">*</span>
                                                                            Registration Fees Paid (in Cr):
                                                                        </label>
                                                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                                                            <asp:TextBox ID="RegistrationFeesPaidinCr" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Registration Fees Paid');"></asp:TextBox>
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
                                                                            <asp:TextBox ID="txtPIPOtherDetails" runat="server" CssClass="similar-select1 input-sm" onblur="ValidateRequired(this,'Any Other Details');"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="clearfix"></div>
                                                                <div runat="server" id="Div2" class="col-md-12 col-sm-12 col-xs-12 text-center">
                                                                    <asp:Button runat="server" ID="btnAddLandDetails" CssClass="btn btn-sm btn-primary" Text="Add Detail" Style="text-align: center; padding: 4px 10px !important; margin: 10px 0;" OnClientClick="return ccheck33();" OnClick="btnAddLandDetails_Click" />&nbsp;<asp:Button runat="server" ID="btnClearLandDetails" CssClass="btn btn-sm btn-primary" Text="Clear" Style="text-align: center; padding: 4px 10px !important; margin: 10px 0;" OnClick="btnClearLandDetails_Click" />
                                                                </div>
                                                                <asp:Label runat="server" ID="lblRecordID" Visible="false"></asp:Label>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="panel-heading text-center font-bold">Land Breakup Details Added</div>
                                                    <div class="form-group">
                                                                    <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top: 4px;">
                                                                        <asp:GridView ID="Grid_LandDetails" runat="server"
                                                                            CssClass="table table-striped table-bordered table-hover request-table"
                                                                            AutoGenerateColumns="False"
                                                                            ClientIDMode="Static"
                                                                            DataKeyNames="ID"
                                                                            GridLines="Horizontal"
                                                                            OnRowCommand="Grid_LandDetails_RowCommand"
                                                                            Width="100%"
                                                                            PagerStyle-CssClass="pagination-ys"
                                                                            PagerStyle-HorizontalAlign="Right">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                            
&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; 
                                                            &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; 
&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; 
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:BoundField DataField="District" HeaderText="District" />
                                                                                <asp:BoundField DataField="Tehsil" HeaderText="Tehsil" />
                                                                                <asp:BoundField DataField="Village" HeaderText="Village" />
                                                                                <asp:BoundField DataField="LandDeedDate" HeaderText="Land Deed Date" />
                                                                                <asp:BoundField DataField="LandArea" HeaderText="Land Area (In Hectare)" />
                                                                                <asp:BoundField DataField="KhasraNumber" HeaderText="Khasra Number" />
                                                                                <asp:BoundField DataField="LandValue" HeaderText="Value of land as per lease /purchase deed agreement (inr cr)" />
                                                                                <asp:BoundField DataField="StampDutyPaid" HeaderText="Stamp Duty Paid as per lease/purchase agreement (inr cr)" />
                                                                                  <asp:BoundField DataField="ExistingLand"  HeaderText = "Existing Project area land Use and required change with status of land :" />
                                                                                 <asp:BoundField DataField="anyOtherExistingProject"           HeaderText = "Other: Existing Project area land Use " />
                                                                                  <asp:BoundField DataField="LandContiguousStatus"            HeaderText = "Is Project area land contiguous :" />
                                                                                
                                                                                  <asp:BoundField DataField="GramGovStatus"       HeaderText = "Is there involvement of any gram sabha/ government land" />
                                                                                
                                                                                   <asp:BoundField DataField="LandExchangeStatus"            HeaderText = "Requirement of Land Exchange" />
                                              <asp:BoundField DataField="LandConversionChargesPaidifanyinCr"           HeaderText = "Land Conversion Charges Paid, if any (in Cr):" />
                                                <asp:BoundField DataField="RegistrationFeesPaidinCr"             HeaderText = "Registration Fees Paid (in Cr):" />
                                                <asp:BoundField DataField="AnyOtherDetails"             HeaderText = "Any Other Details :" />
                                                                                     <asp:BoundField DataField="GramGov"             HeaderText = "Is there involvement of any gram sabha/ government land Use" />
                                                                                     <asp:BoundField DataField="LandExchange"             HeaderText = "Requirement of Land Exchange Use" />

                                                                                   <asp:BoundField DataField="LandContiguous"            HeaderText = "Is Project area land contiguous Use :" />
                                                                        




                                                                                
                                                                                



   




                                       
                                        
    

                                                                                  
                                         












                                         
                                                                            

                                                                                <asp:TemplateField HeaderText="Edit Record" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton runat="server" ID="btnEdit" ToolTip="Edit Record" Text='<i class="fa fa-pencil-square-o" aria-hidden="true"></i>' CommandName="EditRow" CausesValidation="false" CommandArgument='<%# (Container.DataItemIndex) %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Delete Record" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton runat="server" ID="btnDel" ToolTip="Delete Record" Text='<i class="fa fa-times" aria-hidden="true"></i>' CommandName="DeleteRow" CausesValidation="false" CommandArgument='<%# (Container.DataItemIndex) %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
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

                                                        <div class="row" style="margin-top: 15px;">

                                                            <div class="text-left">

                                                                <%-- <asp:Button runat="server" Visible="false" ID="btnSample" Text="" OnClick="GetServiceChecklists_SP_BY_Condtion_Function" />  --%>
                                                                <asp:HiddenField ID="hfName" runat="server" />
                                                                <ul class="nav nav-pills myul-tabs" style="margin-left: 0;">
                                                                    <asp:Panel ID="pnlDemo" runat="server">
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" Text="List of Documents for AFA" CssClass="font-bold sub_menu_active" OnClick="LinkButton1_Click"></asp:LinkButton>
                                                                    <%--    <asp:LinkButton ID="LinkButton2" runat="server" Text="For Applying 1st Stage 2022" CssClass="font-bold sub_menu_active" OnClick="LinkButton2_Click"></asp:LinkButton>
                                                                        <asp:LinkButton ID="LinkButton3" runat="server" Text="For Applying LOC 2022" CssClass="font-bold sub_menu_active" OnClick="LinkButton3_Click"></asp:LinkButton>--%>
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
                                       <asp:Label runat="server" ID="lblmsgDoc" Visible="false" style="color: Red" Text="Please check Uploaded Documents in FInal Form."></asp:Label>      
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
                                                    <asp:Button runat="server" ID="btn_final" Visible="false" Text="Final Submit" CssClass="btn btn-info" OnClick="btn_final_Click" />

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
                                                                <div id="DivP" style="text-align: center; padding: 15px 25px; margin: 25px 10%; background: #fbfbfb; border: 1px solid #ccc;">
                                                                    <div class="div-report" runat="server" style="text-align: center;">
                                                                        <img src="images/upsidclogo.png" class="header-logo" style="border-top: none; height: 40px; margin-bottom: 0;" /><br>
                                                                        <strong>U.P. STATE INDUSTRIAL DEVELOPMENT CORPORATION LIMITED, KANPUR<br>
                                                                            (Head Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024)</strong><br /><br /><div style="border-top: 3px solid #ffc511;">&nbsp;</div>
                                                                        <%--<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>--%>
                                                                        <span class="pull-right font-bold">Dated:  May 18, 2023</span><br />
                                                                        <h2 style="text-decoration: underline;">Statement of Estimated Deposits</h2>
                                                                        <br />
                                                                        <div class='col- md-6'>
                                                                            <table class="table-bordered pull-left" width="100%" style="font-size: 12px;">
                                                                                <tr>
                                                                                    <th style='background: #f7f7f7;'>Application Reference Number</th>
                                                                                    <td class='text-left'>
                                                                                        <asp:Label ID="lblSERviceNo" runat="server" Text="Label"></asp:Label></td>
                                                                                    <th style='background: #f7f7f7;'></th>
                                                                                    <td class='text-left'></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <th>Applied in the name of </th>
                                                                                    <td class='text-left'>
                                                                                        <asp:Label ID="lblAName" runat="server"></asp:Label></td>
                                                                                    <th style='background: #f7f7f7;'>Address </th>
                                                                                    <td class='text-left'>
                                                                                        <asp:Label ID="lblPAddress" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <th>Payment Mode </th>
                                                                                    <td class='text-left'>
                                                                                        <asp:Label ID="lblPMode" runat="server"></asp:Label></td>
                                                                                    <th style='background: #f7f7f7;'>Transaction Ref No </th>
                                                                                    <td class='text-left'>
                                                                                        <asp:Label ID="lblTransactionNo" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <th>Payment Received Date </th>
                                                                                    <td class='text-left'>
                                                                                        <asp:Label ID="lblPayDate" runat="server"></asp:Label></td>
                                                                                    <th style='background: #f7f7f7;'>Payment Status </th>
                                                                                    <td class='text-left'>
                                                                                        <asp:Label ID="lblPaystatus" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                        <br />
                                                                        <br />
                                                                        <br />
                                                                        <br />


                                                                        <div class='row'>
                                                                            <label class="col-md-12 col-sm-12 col-xs-12 text-center" style='border-top: dashed'></label>
                                                                        </div>
                                                                        <br />
                                                                        <div class='col- md-6'>
                                                                            <table class="table-bordered pull-right" width="41%" style="font-size: 12px;">
                                                                                <tr style='background: #f7f7f7;'>
                                                                                    <th>Applicable Fees</th>
                                                                                    <th class='text-center'><i class='fa fa-inr'></i>10000</th>
                                                                                </tr>

                                                                                <tr style='background: #f7f7f7;'>
                                                                                    <th>Total Applicable Charges </th>
                                                                                    <th class='text-center'><i class='fa fa-inr'></i>11800</th>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                        <br />
                                                                        <br />
                                                                        <br />

                                                                        <table class="table table-bordered table-hover request-table">

                                                                            <tr style='background: #f7f7f7;'>
                                                                                <th>S.NO </th>
                                                                                <th>Description </th>
                                                                                <th class="text-center">Amount</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3">A. Applicable Fees</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class='text-center'>1 </td>
                                                                                <td class='text-center'>Processing Fess Against Application Under Warehousing & Logistic </td>
                                                                                <td class='text-center'>10000</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class='text-center'>2 </td>
                                                                                <td class='text-center'>GST 18% </td>
                                                                                <td class='text-center'>1800</td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td colspan="2" class='text-center'>Total Applicable Fees</th><th class='text-left'><i class='fa fa-inr'></i>
                                                                                    10000</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th colspan="2" class='text-center'>Total Payable</th>
                                                                                <th class='text-left'><i class='fa fa-inr'></i>11800</th>
                                                                            </tr>
                                                                        </table>

                                                                    </div>
                                                                    <div class="clearfix"></div>
                                                                    <div class="text-center">
                                                                    </div>
                                                                    <div style="border-top: 3px solid #ffc511;">&nbsp;</div>
                                                                    <br>
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
                                                                            <asp:TextBox ID="txtProjectIden" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
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
                                                                            <asp:TextBox ID="txtNameClear" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
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
                                                                            <asp:TextBox ID="txtIncentives" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
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
                                                                            <asp:TextBox ID="txtImplementation" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
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
                                                                            <asp:TextBox ID="txtDateCommence" runat="server" CssClass="date input-sm similar-select1" placeholder="dd/MM/yyyy"></asp:TextBox>
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
                                                                            <i class="fa fa-inr"></i>
                                                                            <asp:TextBox ID="txtLandDPR" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="96%"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                                                            <i class="fa fa-inr"></i>
                                                                            <asp:TextBox ID="txtLandAEI" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="98%"></asp:TextBox>
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
                                                                            <i class="fa fa-inr"></i>
                                                                            <asp:TextBox ID="txtBUILDINGDPR" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="96%"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                                                            <i class="fa fa-inr"></i>
                                                                            <asp:TextBox ID="txtBUILDINGAEI" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="98%"></asp:TextBox>
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
                                                                            <i class="fa fa-inr"></i>
                                                                            <asp:TextBox ID="txtPLANTDPR" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="96%"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                                                            <i class="fa fa-inr"></i>
                                                                            <asp:TextBox ID="txtPLANTAEI" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="98%"></asp:TextBox>
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
                                                                            <i class="fa fa-inr"></i>
                                                                            <asp:TextBox ID="txtOTHERSDPR" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="96%"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                                                            <i class="fa fa-inr"></i>
                                                                            <asp:TextBox ID="txtOTHERSAEI" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="98%"></asp:TextBox>
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
                                                                            <i class="fa fa-inr"></i>
                                                                            <asp:TextBox ID="txtTOTALDPR" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="96%"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                                                            <i class="fa fa-inr"></i>
                                                                            <asp:TextBox ID="txtTOTALAEI" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" Width="98%"></asp:TextBox>
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
                                                                            <asp:TextBox ID="txtMeansFinance" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>

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
                                                                            <asp:TextBox ID="txtReasonsMigration" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>

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
                                                                            <asp:TextBox ID="txtPlace" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>

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
                                                                            <asp:TextBox ID="txtDates" runat="server" CssClass="date input-sm similar-select1" placeholder="dd/MM/yyyy"></asp:TextBox>

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
                                                                            <asp:FileUpload ID="FileUploadSignature" Width="100%" CssClass="form-control" runat="server" />

                                                                        </div>
                                                                    </div>
                                                                </div>


                                                                <div class="clearfix"></div>
                                                                <div runat="server" id="Div3" class="col-md-12 col-sm-12 col-xs-12 text-center">
                                                                    <asp:Button runat="server" ID="btnConfirm" CssClass="btn btn-sm btn-primary" Text="Confirm and Save" Style="text-align: center; padding: 4px 10px !important; margin: 10px 0;" OnClick="btnConfirm_Click" />
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
                                            <asp:Label runat="server" ID="lblIAID" Visible="false"></asp:Label>
                                        </div>
                                    </div>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

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
     
        function ccheck1() {
            var remark = true;
            var ddlcompany = document.getElementById("<%= ddlcompanytype.ClientID %>");
            var txtTypeOfAccount = document.getElementById("<%= txtTypeOfAccount.ClientID %>");
       
            if (txtApplicantName.value.length <= 0) {
                txtApplicantName.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtApplicantName.style.borderColor = "";
            }
            if (txtApplicantEmail.value.length <= 0) {
                txtApplicantEmail.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtApplicantEmail.style.borderColor = "";
            }

            if (txtApplicantDesignation.value.length <= 0) {
                txtApplicantDesignation.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtApplicantDesignation.style.borderColor = "";
            }

            if (txtApplicantMobileNo.value.length <= 0) {
                txtApplicantMobileNo.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtApplicantMobileNo.style.borderColor = "";
            }

            if (txtPanNo.value.length <= 0) {
                txtPanNo.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtPanNo.style.borderColor = "";
            }
            if (txtAddress.value.length <= 0) {
                txtAddress.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAddress.style.borderColor = "";
            }

            if (txtPromoterName.value.length <= 0) {
                txtPromoterName.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtPromoterName.style.borderColor = "";
            }
            if (txtPromoterName.value.length <= 0) {
                txtPromoterName.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtPromoterName.style.borderColor = "";
            }

            if (txtPromoterEmail.value.length <= 0) {
                txtPromoterEmail.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtPromoterEmail.style.borderColor = "";
            }



            //if (ddlSPV.selectedIndex == 0) {
            //    ddlSPV.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    drpSPV.style.borderColor = "";
            //}


            if (txtTypeOfAccount.selectedIndex == 0) {
                txtTypeOfAccount.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtTypeOfAccount.style.borderColor = "";
            }


            if (txtPersonContactNo.value.length <= 0) {
                txtPersonContactNo.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtPersonContactNo.style.borderColor = "";
            }

            if (txtPromoterAddress.value.length <= 0) {
                txtPromoterAddress.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtPromoterAddress.style.borderColor = "";
            }

            if (ddlcompany.selectedIndex == 0) {
                ddlcompany.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ddlcompany.style.borderColor = "";
            }

            if (txtBeneficiaryName.value.length <= 0) {
                txtBeneficiaryName.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtBeneficiaryName.style.borderColor = "";
            }

            if (txtBankAccountNo.value.length <= 0) {
                txtBankAccountNo.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtBankAccountNo.style.borderColor = "";
            }


            if (txtIFSCCode.value.length <= 0) {
                txtIFSCCode.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtIFSCCode.style.borderColor = "";
            }

            if (txtNameofBank.value.length <= 0) {
                txtNameofBank.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtNameofBank.style.borderColor = "";
            }


            if (txtBranchAddress.value.length <= 0) {
                txtBranchAddress.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtBranchAddress.style.borderColor = "";
            }

          
            //


            
            

          


            //if (txtDirectorName1.value.length <= 0) {
            //    txtDirectorName1.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtDirectorName1.style.borderColor = "";
            //}



            //if (txtCategoryOfDirectorship1.value.length <= 0) {
            //    txtCategoryOfDirectorship1.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtCategoryOfDirectorship1.style.borderColor = "";
            //}


            //if (txtDirectorName2.value.length <= 0) {
            //    txtDirectorName2.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtDirectorName2.style.borderColor = "";
            //}



            //if (txtCategoryOfDirectorship2.value.length <= 0) {
            //    txtCategoryOfDirectorship2.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtCategoryOfDirectorship2.style.borderColor = "";
            //}


            //if (txtDirectorName3.value.length <= 0) {
            //    txtDirectorName3.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtDirectorName3.style.borderColor = "";
            //}


            //if (txtCategoryOfDirectorship3.value.length <= 0) {
            //    txtCategoryOfDirectorship3.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtCategoryOfDirectorship3.style.borderColor = "";
            //}


            //


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

        function ccheck12() {
            var remark = true;
          <%--  var ddlcompany = document.getElementById("<%= ddlcompanytype.ClientID %>");--%>
          <%--  var txtCompanyname = document.getElementById("<%= txtCompanyname.ClientID %>");--%>
            var txtPanNo = document.getElementById("<%= txtPanNo.ClientID %>");
            <%--  var txtProjectLocation = document.getElementById("<%= txtProjectLocation.ClientID %>");--%>
                <%--var txtAadharNo = document.getElementById("<%= txtApplicantAadhar.ClientID %>");
                var txtAddress = document.getElementById("<%= txtApplicantAddress.ClientID %>");--%>



            //if (ddlcompany.selectedIndex == 0) {
            //    ddlcompany.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    ddlcompany.style.borderColor = "";
            //}
            //if (txtAddress.value.length <= 0) {
            //    txtAddress.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtAddress.style.borderColor = "";
            //}

            //if (txtApplicantName.value.length <= 0) {
            //    txtApplicantName.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtApplicantName.style.borderColor = "";
            //}




            //if (txtApplicantDesignation.value.length <= 0) {
            //    txtApplicantDesignation.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtApplicantDesignation.style.borderColor = "";
            //}


            //if (txtPanNo.value.length <= 0) {
            //    txtPanNo.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtPanNo.style.borderColor = "";
            //}

            //if (txtApplicantMobileNo.value.length <= 0) {
            //    txtApplicantMobileNo.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtApplicantMobileNo.style.borderColor = "";
            //}

            //if (txtPromoterName.value.length <= 0) {
            //    txtPromoterName.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtPromoterName.style.borderColor = "";
            //}

            //if (txtPromoterEmail.value.length <= 0) {
            //    txtPromoterEmail.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtPromoterEmail.style.borderColor = "";
            //}


          

            //if (txtTypeOfAccount.selectedIndex == 0) {
            //    txtTypeOfAccount.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtTypeOfAccount.style.borderColor = "";
            //}


            //if (txtPersonContactNo.value.length <= 0) {
            //    txtPersonContactNo.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtPersonContactNo.style.borderColor = "";
            //}

            //if (txtPromoterAddress.value.length <= 0) {
            //    txtPromoterAddress.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtPromoterAddress.style.borderColor = "";
            //}

            //if (txtBeneficiaryName.value.length <= 0) {
            //    txtBeneficiaryName.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtBeneficiaryName.style.borderColor = "";
            //}

            //if (txtBankAccountNo.value.length <= 0) {
            //    txtBankAccountNo.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtBankAccountNo.style.borderColor = "";
            //}

            //if (txtTypeOfAccount.value.length <= 0) {
            //    txtTypeOfAccount.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtTypeOfAccount.style.borderColor = "";
            //}

            //if (txtIFSCCode.value.length <= 0) {
            //    txtIFSCCode.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtIFSCCode.style.borderColor = "";
            //}

            //if (txtNameofBank.value.length <= 0) {
            //    txtNameofBank.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtNameofBank.style.borderColor = "";
            //}


            //if (txtBranchAddress.value.length <= 0) {
            //    txtBranchAddress.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtBranchAddress.style.borderColor = "";
            //}











            //if (ddlcompany.selectedIndex == 0) {
            //    ddlcompany.style.borderColor = '#e52213';
            //    remark = false;
            //}

            //if (txtCompanyname.value.length <= 0) {
            //    txtCompanyname.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtCompanyname.style.borderColor = "";
            //}
            //if (txtAadharNo.value.length <= 0) {
            //    txtAadharNo.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtAadharNo.style.borderColor = "";
            //}


            //if (txtPanNo.value.length <= 0) {
            //    txtPanNo.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtPanNo.style.borderColor = "";
            //}
            //if (txtProjectLocation.value.length <= 0) {
            //    txtProjectLocation.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    txtProjectLocation.style.borderColor = "";
            //}




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





        function ValidateIFSCCODE() {

            var panVal = document.getElementById("<%= txtIFSCCode.ClientID %>").value;
            var lblMessageError = document.getElementById("<%= lblMessageError.ClientID %>");
            var regpan = /^[A-Z]{4}0[A-Z0-9]{6}$/;
            if (panVal.length > 0) {
                if (panVal != "") {
                    if (regpan.test(panVal)) {
                        document.getElementById("<%= txtIFSCCode.ClientID %>").style.borderColor = "";
                        hideError();
                        return true;
                    } else {

                        document.getElementById("<%= txtIFSCCode.ClientID %>").style.borderColor = "Red";
                        document.getElementById("<%= txtIFSCCode.ClientID %>").value = "";
                        document.getElementById("<%= txtIFSCCode.ClientID %>").focus();
                        showError();
                        document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Invalid IFSC Code";
                        return false;
                    }
                }
            } else {
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "IFSC Code Is Required Field";
                document.getElementById("<%= txtIFSCCode.ClientID %>").style.borderColor = "Red";

                document.getElementById("<%= txtIFSCCode.ClientID %>").focus();
                return false;
            }
        }

        function ccheck2() {
            var remark = true;


            BuildingPlanApprovalStatus
            
         

            if (PANameofIndustrialPark.value.length <= 0) {
                PANameofIndustrialPark.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                PANameofIndustrialPark.style.borderColor = "";
            }

           
            if (PAAreaofIndustrialParkinAcres.value.length <= 0) {
                PAAreaofIndustrialParkinAcres.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                PAAreaofIndustrialParkinAcres.style.borderColor = "";
            }


            if (txtFarIndustrialAsPerGuidelines.value.length <= 0) {
                txtFarIndustrialAsPerGuidelines.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtFarIndustrialAsPerGuidelines.style.borderColor = "";
            }
            
            if (FarCommercialAsPerGuidelines.value.length <= 0) {
                FarCommercialAsPerGuidelines.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                FarCommercialAsPerGuidelines.style.borderColor = "";
            }

            if (FarRoadsAsPerGuidelines.value.length <= 0) {
                FarRoadsAsPerGuidelines.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                FarRoadsAsPerGuidelines.style.borderColor = "";
            }
           
            if (FarGreenandOpenSpacesAsPerGuidelines.value.length <= 0) {
                FarGreenandOpenSpacesAsPerGuidelines.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                FarGreenandOpenSpacesAsPerGuidelines.style.borderColor = "";
            }

            

            if (FarUtilitiesAsPerGuidelines.value.length <= 0) {
                FarUtilitiesAsPerGuidelines.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                FarUtilitiesAsPerGuidelines.style.borderColor = "";
            }

            

            if (FarHostelDormitoryAsPerGuidelines.value.length <= 0) {
                FarHostelDormitoryAsPerGuidelines.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                FarHostelDormitoryAsPerGuidelines.style.borderColor = "";
            }

            if (ExemptiononStampDutyinCr.value.length <= 0) {
                ExemptiononStampDutyinCr.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ExemptiononStampDutyinCr.style.borderColor = "";
            }

            if (CapitalSubsidyonEligibleFixedCapitalInvestmentinCr.value.length <= 0) {
                CapitalSubsidyonEligibleFixedCapitalInvestmentinCr.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                CapitalSubsidyonEligibleFixedCapitalInvestmentinCr.style.borderColor = "";
            }

            if (CapitalSubsidyonCostofBuildingHostelDormitoryHousinginCr.value.length <= 0) {
                CapitalSubsidyonCostofBuildingHostelDormitoryHousinginCr.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                CapitalSubsidyonCostofBuildingHostelDormitoryHousinginCr.style.borderColor = "";
            }

            if (TotalAmountofFinancialAssistanceSoughtinCr.value.length <= 0) {
                TotalAmountofFinancialAssistanceSoughtinCr.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                TotalAmountofFinancialAssistanceSoughtinCr.style.borderColor = "";
            }

            
            
            if (udunitname1.value.length <= 0) {
                udunitname1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                udunitname1.style.borderColor = "";
            }

            if (udunitnametype1.value.length <= 0) {
                udunitnametype1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                udunitnametype1.style.borderColor = "";
            }

            if (udunitname2.value.length <= 0) {
                udunitname2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                udunitname2.style.borderColor = "";
            }

            if (udunitnametype2.value.length <= 0) {
                udunitnametype2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                udunitnametype2.style.borderColor = "";
            }

            if (udunitname3.value.length <= 0) {
                udunitname3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                udunitname3.style.borderColor = "";
            }

            if (udunitnametype3.value.length <= 0) {
                udunitnametype3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                udunitnametype3.style.borderColor = "";
            }

            if (udunitname4.value.length <= 0) {
                udunitname4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                udunitname4.style.borderColor = "";
            }

            if (udunitnametype4.value.length <= 0) {
                udunitnametype4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                udunitnametype4.style.borderColor = "";
            }


            if (udunitname5.value.length <= 0) {
                udunitname5.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                udunitname5.style.borderColor = "";
            }

            if (udunitnametype5.value.length <= 0) {
                udunitnametype5.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                udunitnametype5.style.borderColor = "";
            }









            if (Dateofacquiringlandyear1.value.length <= 0) {
                Dateofacquiringlandyear1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Dateofacquiringlandyear1.style.borderColor = "";
            }

            if (StartofConstructionDateyear1.value.length <= 0) {
                StartofConstructionDateyear1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                StartofConstructionDateyear1.style.borderColor = "";
            }



           

            if (CompletionofInfrastructureDateyear1.value.length <= 0) {
                CompletionofInfrastructureDateyear1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                CompletionofInfrastructureDateyear1.style.borderColor = "";
            }

            if (DateofPlacingorderforPlantandMachineryyear1.value.length <= 0) {
                DateofPlacingorderforPlantandMachineryyear1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                DateofPlacingorderforPlantandMachineryyear1.style.borderColor = "";
            }
            
            if (InstallationErectionDateyear1.value.length <= 0) {
                InstallationErectionDateyear1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                InstallationErectionDateyear1.style.borderColor = "";
            }

            if (Proposeddateforcompletionyear1.value.length <= 0) {
                Proposeddateforcompletionyear1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Proposeddateforcompletionyear1.style.borderColor = "";
            }
            

            if (CompletionofInfrastructureDateyear2.value.length <= 0) {
                CompletionofInfrastructureDateyear2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                CompletionofInfrastructureDateyear2.style.borderColor = "";
            }
            if (DateofPlacingorderforPlantandMachineryyear2.value.length <= 0) {
                DateofPlacingorderforPlantandMachineryyear2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                DateofPlacingorderforPlantandMachineryyear2.style.borderColor = "";
            }

            if (InstallationErectionDateyear2.value.length <= 0) {
                InstallationErectionDateyear2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                InstallationErectionDateyear2.style.borderColor = "";
            }

            if (Proposeddateforcompletionyear2.value.length <= 0) {
                Proposeddateforcompletionyear2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Proposeddateforcompletionyear2.style.borderColor = "";
            }

            if (Dateofacquiringlandyear2.value.length <= 0) {
                Dateofacquiringlandyear2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Dateofacquiringlandyear2.style.borderColor = "";
            }

            if (StartofConstructionDateyear2.value.length <= 0) {
                StartofConstructionDateyear2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                StartofConstructionDateyear2.style.borderColor = "";
            }




            if (CompletionofInfrastructureDateyear2.value.length <= 0) {
                CompletionofInfrastructureDateyear2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                CompletionofInfrastructureDateyear2.style.borderColor = "";
            }
            if (DateofPlacingorderforPlantandMachineryyear2.value.length <= 0) {
                DateofPlacingorderforPlantandMachineryyear2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                DateofPlacingorderforPlantandMachineryyear2.style.borderColor = "";
            }

            if (InstallationErectionDateyear2.value.length <= 0) {
                InstallationErectionDateyear2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                InstallationErectionDateyear2.style.borderColor = "";
            }

            if (Dateofacquiringlandyear2.value.length <= 0) {
                Dateofacquiringlandyear2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Dateofacquiringlandyear2.style.borderColor = "";
            }

            if (StartofConstructionDateyear2.value.length <= 0) {
                StartofConstructionDateyear2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                StartofConstructionDateyear2.style.borderColor = "";
            }

            


            if (StartofConstructionDateyear3.value.length <= 0) {
                StartofConstructionDateyear3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                StartofConstructionDateyear3.style.borderColor = "";
            }


            if (Dateofacquiringlandyear3.value.length <= 0) {
                Dateofacquiringlandyear3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Dateofacquiringlandyear3.style.borderColor = "";
            }

            if (Proposeddateforcompletionyear3.value.length <= 0) {
                Proposeddateforcompletionyear3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Proposeddateforcompletionyear3.style.borderColor = "";
            }

            if (CompletionofInfrastructureDateyear3.value.length <= 0) {
                CompletionofInfrastructureDateyear3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                CompletionofInfrastructureDateyear3.style.borderColor = "";
            }

            if (DateofPlacingorderforPlantandMachineryyear3.value.length <= 0) {
                DateofPlacingorderforPlantandMachineryyear3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                DateofPlacingorderforPlantandMachineryyear3.style.borderColor = "";
            }

            if (InstallationErectionDateyear3.value.length <= 0) {
                InstallationErectionDateyear3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                InstallationErectionDateyear3.style.borderColor = "";
            }

            if (CompletionofInfrastructureDateyear3.value.length <= 0) {
                CompletionofInfrastructureDateyear3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                CompletionofInfrastructureDateyear3.style.borderColor = "";
            }

            if (DateofPlacingorderforPlantandMachineryyear3.value.length <= 0) {
                DateofPlacingorderforPlantandMachineryyear3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                DateofPlacingorderforPlantandMachineryyear3.style.borderColor = "";
            }

            if (InstallationErectionDateyear3.value.length <= 0) {
                InstallationErectionDateyear3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                InstallationErectionDateyear3.style.borderColor = "";
            }

            if (Proposeddateforcompletionyear3.value.length <= 0) {
                Proposeddateforcompletionyear3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Proposeddateforcompletionyear3.style.borderColor = "";
            }


            if (StartofConstructionDateyear4.value.length <= 0) {
                StartofConstructionDateyear4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                StartofConstructionDateyear4.style.borderColor = "";
            }


            if (Dateofacquiringlandyear4.value.length <= 0) {
                Dateofacquiringlandyear4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Dateofacquiringlandyear4.style.borderColor = "";
            }

            if (Proposeddateforcompletionyear4.value.length <= 0) {
                Proposeddateforcompletionyear4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Proposeddateforcompletionyear4.style.borderColor = "";
            }

            if (CompletionofInfrastructureDateyear4.value.length <= 0) {
                CompletionofInfrastructureDateyear4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                CompletionofInfrastructureDateyear4.style.borderColor = "";
            }

            if (DateofPlacingorderforPlantandMachineryyear4.value.length <= 0) {
                DateofPlacingorderforPlantandMachineryyear4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                DateofPlacingorderforPlantandMachineryyear4.style.borderColor = "";
            }

            if (InstallationErectionDateyear4.value.length <= 0) {
                InstallationErectionDateyear4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                InstallationErectionDateyear4.style.borderColor = "";
            }

            if (CompletionofInfrastructureDateyear4.value.length <= 0) {
                CompletionofInfrastructureDateyear4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                CompletionofInfrastructureDateyear4.style.borderColor = "";
            }

            if (DateofPlacingorderforPlantandMachineryyear4.value.length <= 0) {
                DateofPlacingorderforPlantandMachineryyear4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                DateofPlacingorderforPlantandMachineryyear4.style.borderColor = "";
            }

            if (InstallationErectionDateyear4.value.length <= 0) {
                InstallationErectionDateyear4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                InstallationErectionDateyear4.style.borderColor = "";
            }

            if (Proposeddateforcompletionyear4.value.length <= 0) {
                Proposeddateforcompletionyear4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Proposeddateforcompletionyear4.style.borderColor = "";
            }


            if (StartofConstructionDateyear5.value.length <= 0) {
                StartofConstructionDateyear5.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                StartofConstructionDateyear5.style.borderColor = "";
            }


            if (Dateofacquiringlandyear5.value.length <= 0) {
                Dateofacquiringlandyear5.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Dateofacquiringlandyear5.style.borderColor = "";
            }

            if (Proposeddateforcompletionyear5.value.length <= 0) {
                Proposeddateforcompletionyear5.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Proposeddateforcompletionyear5.style.borderColor = "";
            }

            if (CompletionofInfrastructureDateyear5.value.length <= 0) {
                CompletionofInfrastructureDateyear5.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                CompletionofInfrastructureDateyear5.style.borderColor = "";
            }

            if (DateofPlacingorderforPlantandMachineryyear5.value.length <= 0) {
                DateofPlacingorderforPlantandMachineryyear5.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                DateofPlacingorderforPlantandMachineryyear5.style.borderColor = "";
            }

            if (InstallationErectionDateyear5.value.length <= 0) {
                InstallationErectionDateyear5.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                InstallationErectionDateyear5.style.borderColor = "";
            }

            if (CompletionofInfrastructureDateyear5.value.length <= 0) {
                CompletionofInfrastructureDateyear5.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                CompletionofInfrastructureDateyear5.style.borderColor = "";
            }

            if (DateofPlacingorderforPlantandMachineryyear5.value.length <= 0) {
                DateofPlacingorderforPlantandMachineryyear5.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                DateofPlacingorderforPlantandMachineryyear5.style.borderColor = "";
            }

            if (InstallationErectionDateyear5.value.length <= 0) {
                InstallationErectionDateyear5.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                InstallationErectionDateyear5.style.borderColor = "";
            }

            if (Proposeddateforcompletionyear5.value.length <= 0) {
                Proposeddateforcompletionyear5.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Proposeddateforcompletionyear5.style.borderColor = "";
            }




            if (StartofConstructionDateyear5.value.length <= 0) {
                StartofConstructionDateyear5.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                StartofConstructionDateyear5.style.borderColor = "";
            }



            if (OperationsandMaintenancetobeTakenupby.value.length <= 0) {
                OperationsandMaintenancetobeTakenupby.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                OperationsandMaintenancetobeTakenupby.style.borderColor = "";
            }

            if (CashFlowProjections.value.length <= 0) {
                CashFlowProjections.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                CashFlowProjections.style.borderColor = "";
            }


            if (ProjectedInflowinCrYear1.value.length <= 0) {
                ProjectedInflowinCrYear1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ProjectedInflowinCrYear1.style.borderColor = "";
            }


            if (ProjectedOutflowinCrYear1.value.length <= 0) {
                ProjectedOutflowinCrYear1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ProjectedOutflowinCrYear1.style.borderColor = "";
            }


            if (ProjectedInflowinCrYear2.value.length <= 0) {
                ProjectedInflowinCrYear2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ProjectedInflowinCrYear2.style.borderColor = "";
            }


            if (ProjectedOutflowinCrYear2.value.length <= 0) {
                ProjectedOutflowinCrYear2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ProjectedOutflowinCrYear2.style.borderColor = "";
            }
            if (ProjectedInflowinCrYear3.value.length <= 0) {
                ProjectedInflowinCrYear3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ProjectedInflowinCrYear3.style.borderColor = "";
            }


            if (ProjectedOutflowinCrYear3.value.length <= 0) {
                ProjectedOutflowinCrYear3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ProjectedOutflowinCrYear3.style.borderColor = "";
            }

            if (ProjectedInflowinCrYear4.value.length <= 0) {
                ProjectedInflowinCrYear4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ProjectedInflowinCrYear4.style.borderColor = "";
            }

            if (ProjectedOutflowinCrYear4.value.length <= 0) {
                ProjectedOutflowinCrYear4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ProjectedOutflowinCrYear4.style.borderColor = "";
            }

            if (ProjectedInflowinCrYear5.value.length <= 0) {
                ProjectedInflowinCrYear5.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ProjectedInflowinCrYear5.style.borderColor = "";
            }

            if (ProjectedOutflowinCrYear5.value.length <= 0) {
                ProjectedOutflowinCrYear5.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ProjectedOutflowinCrYear5.style.borderColor = "";
            }
            var BuildingPlanApprovalStatus = document.getElementById("<%= BuildingPlanApprovalStatus.ClientID %>");


          
            if (BuildingPlanApprovalStatus.selectedIndex == 0) {
                BuildingPlanApprovalStatus.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                BuildingPlanApprovalStatus.style.borderColor = "";
            }
            var BuildingPlanApprovedfromAuthority = document.getElementById("<%= BuildingPlanApprovedfromAuthority.ClientID %>");
            if (BuildingPlanApprovedfromAuthority.selectedIndex == 0) {
                BuildingPlanApprovedfromAuthority.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                BuildingPlanApprovedfromAuthority.style.borderColor = "";
                if (BuildingPlanApplicationIdOBPAS.value.length <= 0) {
                    BuildingPlanApplicationIdOBPAS.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    BuildingPlanApplicationIdOBPAS.style.borderColor = "";
                }
            }

            if (OwnershipofHostelDormitoryCompany.value.length <= 0) {
                OwnershipofHostelDormitoryCompany.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                OwnershipofHostelDormitoryCompany.style.borderColor = "";
            }

            if (AnyOtherInformation.value.length <= 0) {
                AnyOtherInformation.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                AnyOtherInformation.style.borderColor = "";


            }

            //if (BuildingPlanApplicationIdOBPAS.value.length <= 0) {
            //    BuildingPlanApplicationIdOBPAS.style.borderColor = '#e52213';
            //    remark = false;
            //}
            //else {
            //    BuildingPlanApplicationIdOBPAS.style.borderColor = "";
            //}

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
            <%-- var ddlDistrict = document.getElementById("<%= ddlDistrict.ClientID %>");--%>
            <%--  var txtLandDeedDate = document.getElementById("<%= txtLandDeedDate.ClientID %>");
             var txtLandArea = document.getElementById("<%= txtLandArea.ClientID %>");
             var txtValueOfLand = document.getElementById("<%= txtValueOfLand.ClientID %>");
             var txtKhasraNo = document.getElementById("<%= txtKhasraNo.ClientID %>");
             var txtStampDutyPaid = document.getElementById("<%= txtStampDutyPaid.ClientID %>");
             var txtDistrict = document.getElementById("<%= txtDistrict.ClientID %>");
             var txtTehsil = document.getElementById("<%= txtTehsil.ClientID %>");
             
             var LandConversionChargesPaidifanyinCr = document.getElementById("<%= LandConversionChargesPaidifanyinCr.ClientID %>");--%>
           <%--  var ddlExistingLand = document.getElementById("<%= ddlExistingLand.ClientID %>");
             var ddlGramGov = document.getElementById("<%= ddlGramGov.ClientID %>");
             var ddlLandContiguous = document.getElementById("<%= ddlLandContiguous.ClientID %>");
             --%>
             
             

             //if (ddlDistrict.selectedIndex == 0) {
             //    ddlDistrict.style.borderColor = '#e52213';
             //    remark = false;
             //}
             //else {
             //    ddlDistrict.style.borderColor = "";
             //}
             if (txtTehsil.value.length <= 0) {
                 txtTehsil.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtTehsil.style.borderColor = "";
             }

             if (txtVillage.value.length <= 0) {
                 txtVillage.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtVillage.style.borderColor = "";
             }


             if (txtLandDeedDate.value.length <= 0) {
                 txtLandDeedDate.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtLandDeedDate.style.borderColor = "";
             }



             if (txtLandArea.value.length <= 0) {
                 txtLandArea.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtLandArea.style.borderColor = "";
             }

             if (txtKhasraNo.value.length <= 0) {
                 txtKhasraNo.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtKhasraNo.style.borderColor = "";
             }

             if (txtValueOfLand.value.length <= 0) {
                 txtValueOfLand.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtValueOfLand.style.borderColor = "";
             }


            


             if (txtStampDutyPaid.value.length <= 0) {
                 txtStampDutyPaid.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtStampDutyPaid.style.borderColor = "";
             }

             //if (ddlExistingLand.selectedIndex == 0) {
             //    ddlExistingLand.style.borderColor = '#e52213';
             //    remark = false;
             //}
             //else {
             //    ddlExistingLand.style.borderColor = "";
             //}
             //if (ddlLandContiguous.selectedIndex == 0) {
             //    ddlLandContiguous.style.borderColor = '#e52213';
             //    remark = false;
             //}
             //else {
             //    ddlLandContiguous.style.borderColor = "";
             //}
             //if (ddlGramGov.selectedIndex == 0) {
             //    ddlGramGov.style.borderColor = '#e52213';
             //    remark = false;
             //}
             //else {
             //    ddlGramGov.style.borderColor = "";
             //}
             

             //if (txtDistrict.value.length <= 0) {
             //    txtDistrict.style.borderColor = '#e52213';
             //    remark = false;
             //}
             //else {
             //    txtDistrict.style.borderColor = "";
             //}
            
           


             if (LandConversionChargesPaidifanyinCr.value.length <= 0) {
                 LandConversionChargesPaidifanyinCr.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 LandConversionChargesPaidifanyinCr.style.borderColor = "";
             }
           
             if (RegistrationFeesPaidinCr.value.length <= 0) {
                 RegistrationFeesPaidinCr.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 RegistrationFeesPaidinCr.style.borderColor = "";
             }

             if (txtPIPOtherDetails.value.length <= 0) {
                 txtPIPOtherDetails.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtPIPOtherDetails.style.borderColor = "";
             }
             
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


            function ValidateEmail() {
                var email = document.getElementById("<%= txtPromoterEmail.ClientID %>");
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
        function ValidateEmail2() {
                var email = document.getElementById("<%= txtApplicantEmail.ClientID %>");
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


        <%--   function ValidateShareHolderEmail() {
                var email = document.getElementById('<%=((TextBox)gridshareholder.FooterRow.FindControl("txtEmail_insert")).ClientID %>');   --%>

             <%--    if (email.value.length > 0) {
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
        }--%>
     <%--   function ValidatePartnerEmail() {
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

            }--%>
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

      

      <%--  function checkGrid1() {
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

            }--%>
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
        <%--function checkGrid3() {
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

            }--%>
        function checkGrid4() {
            var remark = true;
         <%--   var txtShareholderName_insert = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnerName_insert")).ClientID %>');--%>
           <%-- var txtShareper_insert = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnershipPer_insert")).ClientID %>');--%>

<%--            var txtAddress_insert = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnerAddress_insert")).ClientID %>');
            var txtPhone_insert = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnerPhone_insert")).ClientID %>');--%>

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






