<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ApplicationFinalViewIAServiceModule1.ascx.cs" Inherits="Allotment.UC_ApplicationFinalViewIAServiceModule1" %>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<link rel="stylesheet" href="css/bootstrap.min.css" />
<style>
    @media only screen and (max-width:992px) {
        .form-group label.text-right {
            text-align: left !important;
        }
    }

    body, h1, h2, h3, h4, h5, h6, p, a, .h1, .h2, .h3, .h4, .h5, .h6 {
        font-family: Segoe UI, Helvetica, Calibri;
    }

    .request-table tr {
        font-size: 12px;
        color: #2d2d2d;
        border: 1px solid #fff !important;
        text-align: left;
        font-weight: 600;
        background: #e0e0e0;
        padding: 1px 6px !important;
    }

        .request-table tr th {
            font-size: 12px;
            background-color: #ffe600;
        }

        .request-table tr td a {
            color: #337ab7;
            font-weight: bold;
        }
</style>
<link type="text/css" rel="stylesheet" href="css/theme.css" />
<script type='text/javascript'>


    function PrintElem() {

        Popup($('#DivP').html());
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
<div class="col-md-12 col-sm-12 col-xs-12">
    
    <div id="DivP" style="padding: 15px 25px; margin: 25px; background: #fbfbfb; border: 1px solid #ccc;">
        <div class="div-report" runat="server" style="text-align: center;">


            <img src="images/upsidclogo.png" class="header-logo" style="border-top: none; height: 40px; margin-bottom: 0;" /><br />
            <strong>U.P. STATE INDUSTRIAL DEVELOPMENT CORPORATION LIMITED, KANPUR<br>
                (Head Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024)</strong><br />
            <br />
            <div style="border-top: 3px solid #ffc511;">&nbsp;</div>
        </div>
        <style>
            .my-div-report label {
                font-weight: 600;
            }

            .my-div-report .col-md-3 {
                margin: 0px 0;
            }

            .my-div-report .col-md-9 {
                margin: 0px 0;
            }

            .my-div-report .col-md-12 {
                margin-top: 15px;
            }

            .main-head {
                background: #8a8a8a;
                color: #fff;
                margin-top: 0 !important;
                border-bottom: 1px solid #ccc;
                padding: 4px 15px;
            }
        </style>


        <div class="my-div-report">
            <div style="text-align: center; font-size: 18px; font-weight: 600;">
                <asp:Label runat="server" ID="lblFormName"></asp:Label>
            </div>
            <br />
            <div style="clear: both;"></div>
            <div style="width: 75%; float: left; font-weight: 600;" class="col-md-9">
                To,<br />
                &nbsp;&nbsp;&nbsp;&nbsp;The Regional Manager,<br />
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblOfficeName"></asp:Label><br />
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblAddressOffice"></asp:Label><br />
                <br />
                Dear Sir/Madam,<br />
                &nbsp;&nbsp;&nbsp;&nbsp;I Hereby submit the request for
                <asp:Label runat="server" ID="lblServiceName"></asp:Label>
                as per the following details.<br />
            </div>
            <div style="width: 25%; float: left;" class="col-md-3">
                <%--<asp:Image runat="server" ID="Image1" style="max-height:190px;"/>--%>
                <img src="" runat="server" id="ImageSrc" style="max-height: 150px; max-width: 195px;" />

            </div>

            <div style="clear: both;"></div>
            <!--<asp:PlaceHolder ID="ph" runat="server" />-->
            <div class="applicant-detail" style="border: 2px solid #ccc; margin-top: 20px;" runat="server" id="applicantdetail" visible="false">
                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>A. Applicant Details</b></div>
                <br />
                <div style="clear: both;"></div>


                <div class="col-md-12 col-sm-12 col-xs-12"><b>Particulars of the Applicant</b></div>
                <br />
                <div style="clear: both;"></div>
                <label style="width: 35%; float: left;" class="col-md-4">Constitution of Firm/Company :</label>
                <div style="width: 60%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                    <asp:Label ID="lblFirmConstitution" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-9">Name of the Firm/Company :</label>
                <div style="width: 60%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <div style="width: 75%; float: left; display: none;" class="col-md-9"><b>Whether Application is for 100% export oriented unit?</b></div>
                <div style="width: 25%; float: left; display: none;" class="col-md-3">
                    <asp:Label ID="lblexportoriented" runat="server"></asp:Label>
                </div>

                <div class="col-md-12" style="display: none;"><b>B. Particulars of the Applicant</b></div>
                <div style="clear: both;"></div>
                <label style="width: 35%; float: left;" class="col-md-3">Authorised Person :</label>
                <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Pan No :</label>
                <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblPanNo" runat="server"></asp:Label>
                </div>
                <label style="width: 35%; float: left;" class="col-md-3">CIN No :</label>
                <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblCINNo" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Phone :</label>
                <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblTelephone" runat="server"></asp:Label>
                </div>
                <label style="width: 25%; float: left;" class="col-md-3">Email Id :</label>
                <div style="width: 25%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblEmailInd" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Address :</label>
                <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-9">
                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Plot No :</label>
                <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblPlotNo" runat="server"></asp:Label>
                </div>
                <label style="width: 35%; float: left;" class="col-md-3">Plot Size :</label>
                <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblPlotSize" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Application Ref No :</label>
                <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-9">
                    <asp:Label ID="lblServiceReqno" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Application Date :</label>
                <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-9">
                    <asp:Label ID="lblApplicationDate" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <div class="hidden">
                <hr class="myhrline" />
                <label style="width: 35%; float: left; visibility:hidden" class="col-md-3">Application Re-submission Date :</label>
                <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-9 hidden">
                    <asp:Label ID="lblApplicationReDate" runat="server"></asp:Label>
                </div>
                    </div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <div class="col-md-12">
                    <b>
                        <asp:Label runat="server" ID="Headerlbl"></asp:Label></b>
                </div>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <asp:PlaceHolder runat="server" ID="PH1"></asp:PlaceHolder>
                </div>
                <div style="clear: both;"></div>
            </div>
            <div style="clear: both;"></div>
            <div class="project-detail" runat="server" id="SurrenderofPlotDetails" visible="false" style="border: 2px solid #ccc; margin-top: 20px;">
                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>B. Surrender of Plot Details</b></div>
                <br />
                <div style="clear: both;"></div>
                <label style="width: 35%; float: left;" class="col-md-3">Paid Status :</label>
                <div style="width: 45%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblSurrenderofPlotPaidStatus" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Description :</label>
                <div style="width: 45%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblSurrenderofPlotDescription" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />

            </div>
            <div style="clear: both;"></div>
            <div class="project-detail" runat="server" id="Restorationofplot" visible="false" style="border: 2px solid #ccc; margin-top: 20px;">
                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>B. Restoration of plot Details</b></div>
                <br />
                <div style="clear: both;"></div>
                <label style="width: 35%; float: left;" class="col-md-3">Paid Status :</label>
                <div style="width: 45%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblRestorationPaidStatus" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Description :</label>
                <div style="width: 45%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblRestorationdescription" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />

            </div>
            <div style="clear: both;"></div>
            <div class="project-detail" runat="server" id="AdditionalUnit" visible="false" style="border: 2px solid #ccc; margin-top: 20px;">
                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>B. Additional Unit Details</b></div>
                <br />
                <div style="clear: both;"></div>
                <label style="width: 35%; float: left;" class="col-md-3">Paid Status :</label>
                <div style="width: 45%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblAdditionalUnitStatus" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Description :</label>
                <div style="width: 45%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblAdditionalUnitDescription" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />

            </div>
            <div style="clear: both;"></div>
            <div class="project-detail" runat="server" id="SublettingofPlot" visible="false" style="border: 2px solid #ccc; margin-top: 20px;">
                <div class="applicant-detail" style="border: 2px solid #ccc; margin-top: 20px;">
                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>A. Subletting Applicant Details</b></div>
                    <br />
                    <label style="width: 35%; float: left;" class="col-md-3">District :</label>
                    <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblDistrict" runat="server"></asp:Label>
                    </div>
                    <label style="width: 35%; float: left;" class="col-md-3">Industrial Area :</label>
                    <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblIA" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Plot Area :</label>
                    <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblPlotArea" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Plot Number :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblPreferredPlot" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>

                    <div style="clear: both;"></div>
                    <div class="col-md-12 col-sm-12 col-xs-12"><b>Particulars of the Applicant</b></div>
                    <br />
                    <div style="clear: both;"></div>
                    <label style="width: 35%; float: left;" class="col-md-4">Constitution of Firm/Company :</label>
                    <div style="width: 60%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="lblFirmConstitutionSubletting" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-9">Name of the Firm/Company :</label>
                    <div style="width: 60%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblCompanyNameSubletting" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <div class="col-md-12" style="display: none;"><b>B. Particulars of the Applicant</b></div>
                    <div style="clear: both;"></div>
                    <label style="width: 35%; float: left;" class="col-md-3">Authorised Person :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblSublettingName" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Pan No :</label>
                    <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblPanNoSubletting" runat="server"></asp:Label>
                    </div>
                    <label style="width: 35%; float: left;" class="col-md-3">CIN No :</label>
                    <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblCINNoSubletting" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Phone :</label>
                    <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblTelephoneSubletting" runat="server"></asp:Label>
                    </div>
                    <label style="width: 25%; float: left;" class="col-md-3">Email Id :</label>
                    <div style="width: 25%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblEmailIndSubletting" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Address :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-9">
                        <asp:Label ID="lblAddressSubletting" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Application Ref No :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-9">
                        <asp:Label ID="lblServiceReqnoSubletting" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Application Date :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-9">
                        <asp:Label ID="lblApplicationDateSubletting" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Application Re-submission Date :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-9">
                        <asp:Label ID="lblApplicationReDateSubletting" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <asp:PlaceHolder runat="server" ID="PHSubletting"></asp:PlaceHolder>
                    </div>
                    <div style="clear: both;"></div>
                </div>
                <div style="clear: both;"></div>
                <div class="project-detail" style="border: 2px solid #ccc; margin-top: 20px;">
                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>B. Project Details</b></div>
                    <br />
                    <div style="clear: both;"></div>
                    <label style="width: 35%; float: left;" class="col-md-3">Type of industry :</label>
                    <div style="width: 45%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="ddlTypeOfIndustry" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Proposed Product :</label>
                    <div style="width: 45%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblIndustrytype" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <div class="col-md-12 col-sm-12 col-xs-12"><b>Project Costing Details</b></div>
                    <br />
                    <div style="clear: both;"></div>
                    <label style="width: 35%; float: left;" class="col-md-3">Estimated Cost of the project(In Lacs) :</label>
                    <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">&#x20B9;<asp:Label ID="lblTotalProjectCost" runat="server"></asp:Label></div>
                    <label style="width: 35%; float: left;" class="col-md-3">Estimated Employment Generation(In Nos)</label>
                    <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblEstimatedEmployment" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <div style="width: 75%; float: left; display: none;" class="col-md-9"><b>Whether the networth/turnover of previous year is more than 10 crores?</b></div>
                    <div style="width: 25%; float: left; display: none;" class="col-md-3">
                        <asp:Label ID="lblNetworth" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <div style="width: 75%; float: left; display: none;" class="col-md-9"><b></b></div>
                    <div style="width: 25%; float: left; display: none;" class="col-md-3"></div>
                    <div style="clear: both;"></div>
                    <div class="col-md-12 col-sm-12 col-xs-12"><b>Layout plan of land</b></div>
                    <br />
                    <div style="clear: both;"></div>
                    <label style="width: 35%; float: left;" class="col-md-3">Covered area(In %) :</label>
                    <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblCoveredarea" runat="server"></asp:Label>
                    </div>
                    <label style="width: 35%; float: left;" class="col-md-3">Open area(In %) :</label>
                    <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblOpenArea" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <hr class="myhrline" />
                    <label style="width: 80%; float: left;" class="col-md-9"><b>Will any fumes be generated in the process of manufacture and if so, their nature and quantity?</b></label>
                    <div style="width: 20%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblFumesGenerated" runat="server"></asp:Label>
                    </div>
                    <hr class="myhrline" />
                    <div style="clear: both;"></div>
                    <div runat="server" id="DivFume" visible="false">
                        <label style="width: 35%; float: left;" class="col-md-3">Fume Quantity :</label>
                        <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                            <asp:Label ID="lblFumeQty" runat="server"></asp:Label>
                        </div>
                        <label style="width: 35%; float: left;" class="col-md-3">Fume Nature :</label>
                        <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                            <asp:Label ID="lblFumeNature" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                    </div>
                    <hr class="myhrline" />
                    <div style="clear: both;"></div>
                    <label style="width: 35%; float: left;" class="col-md-9"><b>Industrial Category</b></label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblIndustrialCategory" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <div id="DivPollution" runat="server" visible="false">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <b>Industrial Effluents :</b>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <table class="table table-hover table-bordered request-table" style="width: 100%;">
                                <tr>
                                    <th>Name</th>
                                    <th>Quantity</th>
                                    <th>Chemical composition</th>
                                </tr>
                                <tr>
                                    <td>(i)Liquid</td>
                                    <td>
                                        <asp:Label ID="lblLiquidQuantity" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblLiquidComposition" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>(ii)Solid</td>
                                    <td>
                                        <asp:Label ID="lblSolidQuantity" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblSolidComposition" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>(iii)Gaseous</td>
                                    <td>
                                        <asp:Label ID="lblGasQuantity" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblGasComposition" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </div>
                        <div style="clear: both;"></div>
                        <label style="width: 35%; float: left;" class="col-md-3">Is ETP Required:</label>
                        <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                            <asp:Label ID="lblEtp" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                        <hr class="myhrline" />
                        <div runat="server" id="MeasureDiv" visible="false">
                            <label style="width: 75%; float: left;" class="col-md-12">Proposed effluent treatment measures :</label>
                            <div style="width: 25%; float: left;" class="col-md-3"></div>
                            <div style="clear: both;"></div>
                            <div style="width: 25%; float: left; font-size: 12px; font-weight: 600;" class="col-md-3">
                                1.
                                <asp:Label ID="lblProposedEffluents1" runat="server"></asp:Label>
                            </div>
                            <div style="width: 25%; float: left; font-size: 12px; font-weight: 600;" class="col-md-3">
                                2.
                                <asp:Label ID="lblProposedEffluents2" runat="server"></asp:Label>
                            </div>
                            <div style="width: 25%; float: left; font-size: 12px; font-weight: 600;" class="col-md-3">
                                3.
                                <asp:Label ID="lblProposedEffluents3" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div style="clear: both;"></div>
                        <hr class="myhrline" />
                    </div>
                    <div class="col-md-12 col-sm-12 col-xs-12"><b>Power Requirement (in KW)</b></div>
                    <br />
                    <div style="clear: both;"></div>
                    <label style="width: 35%; float: left;" class="col-md-3">In KW :</label>
                    <div style="width: 45%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                        <asp:Label ID="lblPowerrequirement" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                </div>
                <div style="clear: both;"></div>
            </div>



            <div class="project-detail" runat="server" id="BPSpecification_Div" visible="false" style="border: 2px solid #ccc; margin-top: 20px;">
                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>B. Specification Of Constructed Building For Which Completion Certificate Is Requested</b></div>
                <br />
                <div style="clear: both;"></div>
                <div class="panel-body ">



                    <div class="table-responsive">
                        <table class="table table-bordered table-hover request-table" id="datatableService">
                            <thead>
                                <tr>
                                    <th style="width: 250px">Description</th>
                                    <th style="width: 50px;">Byelaws </th>
                                    <th>Unit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td><span style="color: Red">* </span>FAR(in Percentage)</td>
                                    <td>
                                        <asp:Label ID="lblFarByelaws" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtFar" CssClass="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span style="color: Red">* </span>Ground Coverage (in Percentage)</td>
                                    <td>
                                        <asp:Label ID="lblGroundBylo" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtGroundcover" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span style="color: Red">* </span>Total Covered Area (in SqrMts)</td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="N/A"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtCoveredAreaA" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span style="color: Red">* </span>Height(In mts)</td>
                                    <td>
                                        <asp:Label ID="lblHeight" runat="server" Text="N/A"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtHeight" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: left;"><span style="color: Red">* </span>Set Back(In mts)</td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;"><span style="color: Red">* </span>front</td>
                                    <td>
                                        <asp:Label ID="lblSetBackFront" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtSetBackFront" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;"><span style="color: Red">* </span>Rear
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSetBackRear" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtSetBackRear" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;"><span style="color: Red">* </span>Side1</td>
                                    <td>
                                        <asp:Label ID="lblSetBackSide1" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtSetBackSide1" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;"><span style="color: Red">* </span>Side2</td>
                                    <td>
                                        <asp:Label ID="lblSetBackSide2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtSetBackSide2" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: left;"><span style="color: Red">* </span>Classification of Indiustries Based on Degree of Hazard</td>
                                </tr>
                                <tr>
                                    <td>Classification of Hazard</td>
                                    <td colspan="2">

                                        <asp:Label ID="ddlNature" runat="server">
                                        
                                        </asp:Label>

                                    </td>
                                </tr>


                                <tr>
                                    <td><span style="color: Red">* </span>Occupancy</td>
                                    <td colspan="2">


                                        <asp:Label ID="txtOccupancy" CssClass="input-sm myyellowbgsmall" runat="server"></asp:Label>


                                    </td>
                                </tr>


                            </tbody>
                        </table>



                        <table class="table table-bordered table-hover request-table">
                            <thead>
                                <tr>
                                    <th style="width: 250px">Floors</th>
                                    <th>Constructed </th>
                                    <th style="display: none;">Proposed</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>BaseMent(in Sqmts)</td>
                                    <td>
                                        <asp:Label ID="txtBaseMent1" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                    <td style="display: none;">
                                        <asp:Label ID="txtBaseMent2" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ground Floor(in Sqmts)</td>
                                    <td>
                                        <asp:Label ID="txtGround1" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                    <td style="display: none;">
                                        <asp:Label ID="txtGround2" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>First Floor(in Sqmts)</td>
                                    <td>
                                        <asp:Label ID="txtFirstfloor1" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                    <td style="display: none;">
                                        <asp:Label ID="txtFirstfloor2" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Second Floor(in Sqmts)</td>
                                    <td>
                                        <asp:Label ID="txtSecondFloor1" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                    <td style="display: none;">
                                        <asp:Label ID="txtSecondFloor2" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">Mezzanine Floor(in Sqmts)</td>
                                    <td>
                                        <asp:Label ID="txtMezzanine1" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                    <td style="display: none;">
                                        <asp:Label ID="txtMezzanine2" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">Stilt Floor(in Sqmts)</td>

                                    <td colspan="2">
                                        <asp:Label ID="txtStealth" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">Mumti(in Sqmts)</td>

                                    <td colspan="2">
                                        <asp:Label ID="txtMumti" class="input-sm myyellowbgsmall" runat="server" ssss></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="table table-bordered table-hover request-table" id="datatableService2">
                            <thead>
                                <tr>
                                    <th style="width: 250px"></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td style="text-align: right;">Purpose for which  building Use
                                    </td>
                                    <td>
                                        <asp:Label ID="txtbuildingPurpose" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" colspan="2"><b>Construction Specification</b></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">Foundation</td>
                                    <td>
                                        <asp:Label ID="txtFoundation" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">Walls</td>
                                    <td>
                                        <asp:Label ID="txtWalls" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">Floors</td>
                                    <td>
                                        <asp:Label ID="txtFloors" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">Roofs</td>
                                    <td>
                                        <asp:Label ID="txtRoofs" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">Number of storeys</td>
                                    <td>
                                        <asp:Label ID="txtStories" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">Number of latrines</td>
                                    <td>
                                        <asp:Label ID="txtLatrines" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">Any Previous Construction </td>
                                    <td>
                                        <asp:Label ID="txtPreviousConstruction" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">Source of Water for Building Purpose </td>
                                    <td>
                                        <asp:Label ID="txtWaterSource" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>

                        <div class="clearfix"></div>
                        <hr class="myhrline" />

                    </div>



                </div>


            </div>

            <div class="document-upload" style="border: 2px solid #ccc; margin-top: 20px;">
                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>C. Documents Upload</b></div>
                <br />
                <div style="clear: both;"></div>
                <div class="col-md-12 col-sm-12 col-xs-12">

                    <asp:PlaceHolder runat="server" ID="PH2"></asp:PlaceHolder>
                </div>
                <div style="clear: both;"></div>
            </div>
            <div class="payment" style="border: 2px solid #ccc; margin-top: 20px;" id="Paymentdiv" runat="server" visible="false">
                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>D. Payment</b></div>
                <br />
                <div style="clear: both;"></div>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <asp:PlaceHolder runat="server" ID="PH3"></asp:PlaceHolder>
                </div>
                <div style="clear: both;"></div>
            </div>
            <div class="Dues-details" runat="server" id="Dues_Div" style="border: 2px solid #ccc; margin-top: 20px;" visible="false">
                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>E. Dues Cleared</b></div>
                <br />
                <div style="clear: both;"></div>
                <div class="col-md-12 col-sm-12 col-xs-12">

                    <asp:PlaceHolder runat="server" ID="PH_Dues"></asp:PlaceHolder>
                </div>
                <div style="clear: both;"></div>
            </div>
            <div class="Dues-details" runat="server" id="Objection_Div" style="border: 2px solid #ccc; margin-top: 20px;" visible="false">
                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>F. Objection Cleared</b></div>
                <br />
                <div style="clear: both;"></div>
                <div class="col-md-12 col-sm-12 col-xs-12">

                    <asp:PlaceHolder runat="server" ID="ph_Objection"></asp:PlaceHolder>
                </div>
                <div style="clear: both;"></div>
            </div>
        </div>


        <div class="div-report" runat="server" style="text-align: center;">
            <br />
            <div style="border-top: 3px solid #ffc511;">&nbsp;</div>
            <div class="mail-disclaimer">
                <p class="text-justify"><strong>Disclaimer:</strong>The information given in the above applicationis true to the best of my knowledge and belief. The general conditions for allotment of plot/shed and grant of lease indicated in this application form for allotment of plot/shed in the industrial area has been read carefully and understood by me and are fully acceptable to me. I further agree to abide by any and all changes made in the general conditions by the corporation from time to time.</p>
            </div>
        </div>
        <div class="clearfix" style="clear: both;"></div>
    </div>

    <asp:Label ID="lblIAName" runat="server" Visible="false"></asp:Label>
</div>
