<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KycForm.aspx.cs" Inherits="Allotment.KycForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />



   <%-- <link href="/css/datepicker.css" rel="stylesheet" type="text/css" />--%>

    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
   <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
     <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
        <script src="/js/jquery.knob.js"></script>

        <script type="text/javascript">
            $(function () {
                $(".knob").knob();
            });
    </script>


    <script src="/js/jquery1.js"></script>


<script src="js/jquery-ui.js"></script>
  <%--  <script src="/js/jquery.js"></script>--%>
    <script src="/js/bootstrap.min.js"></script>
<%--<script src="/js/bootstrap-datepicker.js"></script>--%>

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
        function ShowMessage(msg) {
            alert(msg);
           
        }
        </script>

    
      <style>
          
          @media print {
              .ddd-date {
                color: #ccc !important;
               
                -webkit-print-color-adjust: exact;
}

              input-txtdate::placeholder {
                  color: #ccc;
                  opacity: 1; /* Firefox */
              }

              .input-txtdate:-ms-input-placeholder { /* Internet Explorer 10-11 */
                  color: #ccc;
              }

              .input-txtdate::-ms-input-placeholder { /* Microsoft Edge */
                  color: #ccc;
              }


              }

              @media print and (-webkit-min-device-pixel-ratio:0) {
                .ddd-date {
                    color: #ccc !important;
                    
                    -webkit-print-color-adjust: exact;
                }
                input-txtdate::placeholder {
                  color: #ccc;
                  opacity: 1; /* Firefox */
              }

              .input-txtdate:-ms-input-placeholder { /* Internet Explorer 10-11 */
                  color: #ccc;
              }

              .input-txtdate::-ms-input-placeholder { /* Microsoft Edge */
                  color: #ccc;
              }
              }
           

          .ddd-date {
                
              }
          .input-txtdate::placeholder {
                  color: #ccc;
                  opacity: 1; /* Firefox */
              }

              .input-txtdate:-ms-input-placeholder { /* Internet Explorer 10-11 */
                  color: #ccc;
              }

              .input-txtdate::-ms-input-placeholder { /* Microsoft Edge */
                  color: #ccc;
              }
         
      .header-ul li {
        text-align:left;
        font-weight:700;
        }
        .div-4col {
        width:33.3%;
        float:left;
        }
          .div-6col {
            width:50%;
            float:left;
          }
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
          body, h1, h2, h3, h4, h5, h6, p, a, .h1, .h2, .h3, .h4, .h5, .h6 {
                font-family: Arial;
                font-size:13px;
          }

          p {
            font-size:13px;
            text-align:justify;
            font-family: Arial;
          }

        .ui-dialog .ui-dialog-titlebar-close span {
    color:black !important;
}

          u.myultext {
              border-bottom: 1px dotted #000;
              text-decoration: none;
              font-weight:700;
          }
          .div-6col-inleft {
            width: 34%;
            float: left;
            margin: 0px 10px;
          }
          .div-6col-inright
          {
                width: 56%;
                float: left;
                margin: 0px 10px;
          }
    </style>
  

</head>
<body>
    <div id="dialog" style="display: none">
</div> 
     <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                
            </div>
            <div class="row" id="SideDiv">
                <div class="col-md-12">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="row well well-large offset4">
                                <div class="panel panel-default">
                                  
                                    <div class="panel-body">
                                          <hr style="margin: 4px 0;border-top: 1px solid #d8d8d8;"  />
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">

            <div class="form-group" style="background: #e6e6e6;padding: 4px 10px;display:none;">
                <div class="row">
                    <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                        Enter Service Request: 
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <asp:TextBox runat="server" ID="txt1"></asp:TextBox> <asp:Button runat="server" ID="btn" Text="Find" OnClick="btn_Click" /> 
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <a runat="server" onclick="PrintElem()" class="pull-right" style="font-size: 16px;">
                            <i class="fa fa-print" aria-hidden="true"></i>
                        </a>
                    </div>
                </div>
                    
            </div>
           <div class="clearfix"></div>
            <hr class="myhrline" style="border-bottom:1px solid #d8d8d8;"/>
            <div style="background: #f5f5f5; padding: 14px; border: 1px solid #ccc;text-align: center;margin-top: 10px;color: #1b1b1b;font-size: 14px;font-weight: 500;">
                Thank You for Signing with us! We value your relationship with UPSIDC. Our team will verify your request and activate your eService account soon. You will shortly receive an email with the credentials to login to the system at your shared email with us.
<br /><br />Please be informed that the shared email and phone no would be your registered email ID and Phone no for any further communication.<br /><br />

We respect your patronage with us.
            </div>

        </div>
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div  id="DivP" style="padding: 15px 25px; margin: 12px 10%;background: #fbfbfb;border: 1px solid #ccc;" runat="server">
                <div class="div-report" runat="server"  style="">

                    
	                <div class="row">
                        <div style="text-align:center;">
                            <span style="font-size:22px;"><b>UTTAR PRADESH STATE INDUSTRIAL DEVELOPMENT CORPORATION</b></span><br /><span style="font-size:19px;">UPSIDC COMPLEX, PLOT NO - A-1/4, 9TH FLOOR LAKHANPUR<br /> KANPUR- 208024</span>
                        </div>                        
                    
                        <div class="clearfix"></div>
                        <div class="div-6col" style="width:50%;float:left;">
                            <span style="margin-left:30%;">Website: www.onlineupsidc.com</span>
                        </div>
                        <div class="div-6col" style="width:50%;float:left;">
                            <span style="float:right;margin-right:30%;">Email id: - info@onlineupsidc.com</span>
                        </div><br /><br />
                        <div style="text-align:center;">
                            <span style="font-size:25px;"><b>KNOW YOUR ALLOTTEE (KYA) FORM</b></span><br /><span style="font-size:20px;"><b>(ENTIRE FORM IS TO BE FILLED IN BLOCK LETTERS ONLY)</b></span>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div style = "border-top:3px solid #ffc511;">&nbsp;</div>                    
                    <div class="clearfix"></div>
                    <span style="float:right;">Dated: <input class="date input-txtdate" type="text" placeholder="DD/MM/YYYY" /><!---<span class="ddd-date" style=" border: 1px solid #ccc;padding: 4px 14px;background: #fff;color:#ccc;">DD/MM/YYYY</span>--></span><br />
                    <div class="clearfix"></div>
                    <ul class="list-unstyled header-ul pull-left">
                        <li><br />The Regional Manager (Property),</li>
                        <li><b><u class="myultext"><asp:Label runat="server" ID="lblIAName" Text="Industrial Area Name"></asp:Label></u></b></li>
                        <li><b><u class="myultext"><asp:Label runat="server" ID="lblIAAddress" Text="Industrial Area Address"></asp:Label></u></b></li>
                        <li><b><u class="myultext"><asp:Label runat="server" ID="lblPhoneNo" Text="1234567890"></asp:Label></u></b></li>
                    </ul>
                    <div class="clearfix"></div><br />
                    <div class="div-6col" style="width:50%;float:left;">
                        <div class="div-6col-inleft">Allottee Name:</div><div class="div-6col-inright"><asp:Textbox runat="server" ID="txtAllotteeName" CssClass="input-sm similar-select1"></asp:Textbox></div>
                    </div>
                    <div class="div-6col" style="width:50%;float:left;">
                       <div class="div-6col-inleft">Plot/Flat/Property No:</div><div class="div-6col-inright"><asp:Textbox runat="server" ID="txtPlotNo" CssClass="input-sm similar-select1"></asp:Textbox> </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="div-6col" style="width:50%;float:left;">
                        <div class="div-6col-inleft">Father/Spouse Name:</div><div class="div-6col-inright"><asp:Textbox runat="server" ID="txtFatherName" CssClass="input-sm similar-select1"></asp:Textbox></div>
                    </div>
                    <div class="div-6col" style="width:50%;float:left;">
                        <div class="div-6col-inleft">Block/Estate:</div><div class="div-6col-inright"><asp:Textbox runat="server" ID="txtBlockState" CssClass="input-sm similar-select1"></asp:Textbox></div> 
                    </div>
                    <div class="clearfix"></div>
                    <div class="div-6col" style="width:50%;float:left;">
                         <div class="div-6col-inleft">Sector:</div><div class="div-6col-inright"><asp:Textbox runat="server" ID="txtSector" CssClass="input-sm similar-select1"></asp:Textbox></div> 
                    </div>
                    <div class="div-6col" style="width:50%;float:left;">
                         <div class="div-6col-inleft">Allotment Date:</div><div class="div-6col-inright"><asp:Textbox runat="server" ID="txtAllotmentDate" CssClass="date input-sm similar-select1"></asp:Textbox></div> 
                    </div>
                    <div class="clearfix"></div>
                    <div class="div-6col" style="width:50%;float:left;">
                         <div class="div-6col-inleft">Allotment No:</div><div class="div-6col-inright"><asp:Textbox runat="server" ID="txtAllotmentNo" CssClass="input-sm similar-select1"></asp:Textbox></div> 
                    </div>
                    <div class="div-6col" style="width:50%;float:left;">
                         <div class="div-6col-inleft">Plot Size(Sq Mtr):</div><div class="div-6col-inright"><asp:Textbox runat="server" ID="txtPlotsize" CssClass="input-sm similar-select1"></asp:Textbox></div> 
                    </div>
                    <div class="clearfix"></div><br /><br />
                    <span><b>1. ALLOTTEE NAME</b></span><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 1: <asp:Textbox runat="server" ID="txtAllotteeName1" CssClass="input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <asp:Textbox runat="server" ID="txtAllotteeName2" CssClass="input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    <div class="clearfix"></div><br />
                    <span><b>2. ADDRESS</b></span> (Please provide/update your correspondence and permanent address.)<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;<b>A. Correspondence Address</b>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Textbox runat="server" ID="txtlblCorrAddress" CssClass="input-sm similar-select1" TextMode="MultiLine" Width="96%"></asp:Textbox> <br /><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;<b>B. Permanent Address</b>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Textbox runat="server" ID="txtPermanentAddress" CssClass="input-sm similar-select1 " TextMode="MultiLine" Width="96%"></asp:Textbox>
                    <div class="clearfix"></div><br />
                    <span><b>3. CONTACT NO (MOBILE / TELEPHONE)</b> (Please add area code before the number. e.g. 0120-12345678) </span><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 1: <asp:Textbox runat="server" ID="txtContact1" CssClass="input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <asp:Textbox runat="server" ID="txtContact2" CssClass="input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    <div class="clearfix"></div><br />
                    <span><b>4. E-MAIL ID</b></span><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 1: <asp:Textbox runat="server" ID="txtEmail1" CssClass="input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <asp:Textbox runat="server" ID="txtEmail2" CssClass="input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    <div class="clearfix"></div><br />
                    <span><b>5. DATE OF BIRTH</b></span><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 1: <asp:Textbox runat="server" ID="txtBirth1"  CssClass="date input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <asp:Textbox runat="server" ID="txtBirth2" CssClass="date input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    <div class="clearfix"></div><br />
                    <span><b>6.  IDENTITY PROOF / DOCUMENT</b><br /> &nbsp;&nbsp;&nbsp;&nbsp;(Please provide at least ONE of the following information and affix a photocopy of the same. ) </span><br />
                    <b>A. PAN No.</b><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 1: <asp:Textbox runat="server" ID="txtPan1" CssClass="input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <asp:Textbox runat="server" ID="txtPan2" CssClass="input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    <div class="clearfix"></div><br />
                    <b>B. Aadhar Card No.</b><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 1: <asp:Textbox runat="server" ID="txtAdhaar1" CssClass="input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <asp:Textbox runat="server" ID="txtAdhaar2" CssClass="input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    <div class="clearfix"></div><br />
                    <b>C. Voters ID Card No.</b><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 1: <asp:Textbox runat="server" ID="txtVote1" CssClass="input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <asp:Textbox runat="server" ID="txtVote2" CssClass="input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    <div class="clearfix"></div><br />
                    <b>D. Driving License No.</b><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 1: <asp:Textbox runat="server" ID="txtDL1" CssClass="input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <asp:Textbox runat="server" ID="txtDL2" CssClass="input-sm similar-select1 kyc-input"></asp:Textbox><br />
                    <div class="clearfix"></div><br />
                    <br />
                    <div style = "border-top:3px solid #ffc511;">&nbsp;</div> 	
                    <div class="mail-disclaimer">
	                <p><b>Declaration:</b></p>
                    <p>This is to certify that I/we am/are allottee(s) of the above mentioned residential/commercial/industrial/institutional property/plot/flat/building and all the information provided in this “KYA Form” is correct and true to the best of my/our knowledge and belief.</p><br /><br /><br /><br />
                    <div class="col-md-12 text-right">
                        <div class="pull-right text-center">
                            <ul class="list-unstyled">
                                <li>___________________________________________</li>
                                <li>Allottee(s) Signature</li>
                            </ul>
                        </div>
                        
                    </div><br /><br /><br /><br />
                    <p><b>PLEASE NOTE:</b></p>
                    <p>1. Please complete the entire form in BLOCK LETTERS only.</p>
                    <p>2. For any kind of assistance in filling the above form, please contact <b><u class="myultext"><asp:Label runat="server" ID="lblRMName" Text="Regional Manager Name"></asp:Label></u></b>. He can be contacted on <b><u class="myultext"><asp:Label runat="server" ID="lblPhone" Text="Mobile No"></asp:Label></u></b>, between 10 AM to 4 PM, on working days. </p>
                    <p>3. Your contact numbers & Email IDs will assist the authority in communicating efficiently with you. Once available, the authority will be able to send timely alerts regarding current & future developments.</p>
                    </div>
                </div>
            </div>

            <div  id="DivP1" style="padding: 15px 25px; margin: 25px 10%;background: #fbfbfb;border: 1px solid #ccc;" runat="server" visible="false">
                <div class="div-report" runat="server"  style="">

                    
	                <div class="row">
                        <div style="text-align:center;">
                            <span style="font-size:20px;"><b>UTTAR PRADESH STATE INDUSTRIAL DEVELOPMENT CORPORATION</b></span><br /><span style="font-size:18px;">UPSIDC COMPLEX, PLOT NO - A-1/4, 9TH FLOOR LAKHANPUR<br /> KANPUR- 208024</span>
                        </div>                        
                    
                        <div class="clearfix"></div>
                        <div class="div-6col" style="width:50%;float:left;">
                            <span style="margin-left:30%;">Website: www.onlineupsidc.com</span>
                        </div>
                        <div class="div-6col" style="width:50%;float:left;">
                            <span style="float:right;margin-right:30%;">Email id: - info@onlineupsidc.com</span>
                        </div><br /><br />
                        <div style="text-align:center;">
                            <span style="font-size:20px;"><b>KNOW YOUR ALLOTTEE (KYA) FORM</b></span><br /><span style="font-size:18px;"><b>(ENTIRE FORM IS TO BE FILLED IN BLOCK LETTERS ONLY)</b></span>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div style = "border-top:3px solid #ffc511;">&nbsp;</div>                    
                    <div class="clearfix"></div>
                    <span style="float:right;">Dated: <!--<input class="input-txtdate" type="text" placeholder="DD/MM/YYYY" />--><span class="ddd-date" style=" border: 1px solid #ccc;padding: 4px 14px;background: #fff;color: #ccc;">DD/MM/YYYY</span></span><br />
                    <div class="clearfix"></div>
                    <ul class="list-unstyled header-ul pull-left">
                        <li><br />The Regional Manager (Property),</li>
                        <li><b><u class="myultext"><asp:Label runat="server" ID="Label1" Text="Industrial Area Name"></asp:Label></u></b></li>
                        <li><b><u class="myultext"><asp:Label runat="server" ID="Label2" Text="Industrial Area Address"></asp:Label></u></b></li>
                        <li><b><u class="myultext"><asp:Label runat="server" ID="Label3" Text="1234567890"></asp:Label></u></b></li>
                    </ul>
                    <div class="clearfix"></div><br />
                    <div class="div-6col" style="width:50%;float:left;">
                        Allottee Name: <b><u class="myultext"><asp:Label runat="server" ID="lblAllotteeName" Text="Name of Allottee"></asp:Label></u></b>
                    </div>
                    <div class="div-6col" style="width:50%;float:left;">
                       Plot/Flat/Property No: <b><u class="myultext"><asp:Label runat="server" ID="lblPropertyNo" Text="Property No"></asp:Label></u></b>
                    </div>
                    <div class="clearfix"></div>
                    <div class="div-6col" style="width:50%;float:left;">
                        Father/Spouse Name: <b><u class="myultext"><asp:Label runat="server" ID="lblFatherName" Text="Father Name"></asp:Label></u></b>
                    </div>
                    <div class="div-6col" style="width:50%;float:left;">
                        Block/Estate: <b><u class="myultext"><asp:Label runat="server" ID="lblBlockState" Text="Block"></asp:Label></u></b>
                    </div>
                    <div class="clearfix"></div>
                    <div class="div-6col" style="width:50%;float:left;">
                         Sector: <b><u class="myultext"><asp:Label runat="server" ID="lblSector" Text="Sector Name"></asp:Label></u></b>
                    </div>
                    <div class="div-6col" style="width:50%;float:left;">
                         Allotment Date: <b><u class="myultext"><asp:Label runat="server" ID="lblAllotmentDate" Text="12/01/2017"></asp:Label></u></b>
                    </div>
                    <div class="clearfix"></div>
                    <div class="div-6col" style="width:50%;float:left;">
                         Allotment No: <b><u class="myultext"><asp:Label runat="server" ID="lblAllotmentNo" Text="Allotment No"></asp:Label></u></b>
                    </div>
                    <div class="div-6col" style="width:50%;float:left;">
                         Plot Size(Sq Mtr): <b><u class="myultext"><asp:Label runat="server" ID="lblPlotsize" Text="12345"></asp:Label></u></b>
                    </div>
                    <div class="clearfix"></div><br /><br />
                    <span><b>1. ALLOTTEE NAME</b></span><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 1: <b><u class="myultext"><asp:Label runat="server" ID="lblAllotmentNo1name" Text="12345"></asp:Label></u></b><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <b><u class="myultext"><asp:Label runat="server" ID="lblAllotmentNo2name" Text="12345"></asp:Label></u></b><br /><br />
                    <span><b>2. ADDRESS</b></span> (Please provide/update your correspondence and permanent address.)<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;<b>A. Correspondence Address</b><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;<b><u class="myultext"><asp:Label runat="server" ID="lblCorrAddress" Text="Address"></asp:Label></u></b><br /><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;<b>B. Permanent Address</b><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;<b><u class="myultext"><asp:Label runat="server" ID="lblPermanentAddress" Text="Address"></asp:Label></u></b><br /><br />
                    <span><b>3. CONTACT NO (MOBILE / TELEPHONE)</b> (Please add area code before the number. e.g. 0120-12345678) </span><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 1: <b><u class="myultext"><asp:Label runat="server" ID="lblPhoneAllotNo1" Text="1234567809"></asp:Label></u></b><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <b><u class="myultext"><asp:Label runat="server" ID="lblPhoneAllotNo2" Text="1234567809"></asp:Label></u></b><br /><br />
                    <span><b>4. E-MAIL ID</b></span><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 1: <b><u class="myultext"><asp:Label runat="server" ID="lblEmailAllottee1" Text="Allottee1@gmail.com"></asp:Label></u></b><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <b><u class="myultext"><asp:Label runat="server" ID="lblEmailAllottee2" Text="Allottee2@gmail.com"></asp:Label></u></b><br /><br />
                    <span><b>5. DATE OF BIRTH</b></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 1: <b><u class="myultext"><asp:Label runat="server" ID="lblAllottee1date" Text="12/02/2017"></asp:Label></u></b><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <b><u class="myultext"><asp:Label runat="server" ID="lblAllottee2date" Text="12/02/2017"></asp:Label></u></b><br /><br />
                    <span><b>6.  IDENTITY PROOF / DOCUMENT</b><br /> &nbsp;&nbsp;&nbsp;&nbsp;(Please provide at least ONE of the following information and affix a photocopy of the same. ) </span><br />
                    <b>A. PAN No.</b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 1: <u class="myultext"><asp:Label runat="server" ID="lblPanNo1" Text="1234567809"></asp:Label></u><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <b><u class="myultext"><asp:Label runat="server" ID="lblPanNo2" Text="1234567809"></asp:Label></u></b><br /><br />
                    <b>B. Aadhar Card No.</b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 1: <u class="myultext"><asp:Label runat="server" ID="lblAdhaarAllottee1" Text="1234567809"></asp:Label></u><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <b><u class="myultext"><asp:Label runat="server" ID="lblAdhaarAllottee2" Text="1234567809"></asp:Label></u></b><br /><br />
                    <b>C. Voters ID Card No.</b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 1: <u class="myultext"><asp:Label runat="server" ID="lblVoterIDAllottee1" Text="1234567809"></asp:Label></u><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <b><u class="myultext"><asp:Label runat="server" ID="lblVoterIDAllottee2" Text="1234567809"></asp:Label></u></b><br /><br />
                    <b>D. Driving License No.</b> &nbsp;&nbsp; Allottee No. 1: <u class="myultext"><asp:Label runat="server" ID="lblDLNoAllottee1" Text="1234567809"></asp:Label></u><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Allottee No. 2: <b><u class="myultext"><asp:Label runat="server" ID="lblDLNoAllottee2" Text="1234567809"></asp:Label></u></b><br /><br />
                    <br />
                    <div style = "border-top:3px solid #ffc511;">&nbsp;</div> 	
                    <div class="mail-disclaimer">
	                <p><b>Declaration:</b></p>
                    <p>This is to certify that I/we am/are allottee(s) of the above mentioned residential/commercial/industrial/institutional property/plot/flat/building and all the information provided in this “KYA Form” is correct and true to the best of my/our knowledge and belief.</p><br /><br /><br /><br />
                    <div class="col-md-12 text-right">
                        <div class="pull-right text-center">
                            <ul class="list-unstyled">
                                <li>___________________________________________</li>
                                <li>Allottee(s) Signature</li>
                            </ul>
                        </div>
                        
                    </div><br /><br /><br /><br />
                    <p><b>PLEASE NOTE:</b></p>
                    <p>1. Please complete the entire form in BLOCK LETTERS only.</p>
                    <p>2. For any kind of assistance in filling the above form, please contact <b><u class="myultext"><asp:Label runat="server" ID="Label4" Text="Regional Manager Name"></asp:Label></u></b>. He can be contacted on <b><u class="myultext"><asp:Label runat="server" ID="Label5" Text="Mobile No"></asp:Label></u></b>, between 10 AM to 4 PM, on working days. </p>
                    <p>3. Your contact numbers & Email IDs will assist the authority in communicating efficiently with you. Once available, the authority will be able to send timely alerts regarding current & future developments.</p>
                    </div>
                </div>
            </div>

            <div class="text-center">
                <asp:Button ID="btnSubmit1" runat="server" CssClass="btn btn-sm btn-primary ey-bg" Text="Submit Your KYC Form" OnClick="btnSubmit1_Click" style="margin-bottom:10px;"/>
                <a runat="server" onclick="PrintElem()" style="font-size: 16px;"><i class="fa fa-print" aria-hidden="true"></i></a>                                                                                        
            </div>


        </div>
    </div>

                    </div>
                    <footer class="nb-footer" style="display:none;">
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
        </div>
    </div>
      
    </form>
    <style>
        .kyc-input {
            width:87%;
            background:#efefef !important;
        }
        .div-6col-inright input{
            background:#efefef !important;
        }
    </style>
      <script type="text/javascript">

          function PrintElem() {

              Popup($('#DivP1').html());
          }


          function Popup(data) {
              var mywindow = window.open('', 'my div', 'height=2000,width=2000');
              mywindow.document.write('<html><head><title style="font-weight:bold;"></title>');
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
      <script  type="text/javascript">
          $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
              $(this).blur();
              $(this).datepicker('hide');
          });;

          var prm = Sys.WebForms.PageRequestManager.getInstance();
          prm.add_endRequest(function () {
              $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
                  $(this).blur();
                  $(this).datepicker('hide');
              });;
          });
  </script>
     
</body>
</html>
