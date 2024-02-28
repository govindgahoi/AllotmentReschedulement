<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ApplicationFinalViewJointMortgageService.ascx.cs" Inherits="Allotment.UC_ApplicationFinalViewJointMortgageService" %>
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
        mywindow.document.write('<html><head><title style="font-weight:bold;">Application Details</title>');
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


            <img src="http://eservices.onlineupsidc.com/images/upsidclogo.png" class="header-logo" style="border-top: none; height: 40px; margin-bottom: 0;" /><br />
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
                <asp:Label runat="server" ID="lblFormName" Text="Application Form For Joint Mortgage"></asp:Label></div>
            <br />
            <div style="clear: both;"></div>
            <div style="width: 75%; float: left; font-weight: 600;" class="col-md-9">
                To,<br />
                &nbsp;&nbsp;&nbsp;&nbsp;The Regional Manager,<br />
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblOfficeName"></asp:Label><br />
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblAddressOffice"></asp:Label><br />
                <br />
                Dear Sir/Madam,<br />
                &nbsp;&nbsp;&nbsp;&nbsp;I Hereby submit the request for permission to mortgage in favour of Financial Institution as per the following details.<br />
            </div>
            <div style="width: 25%; float: left;" class="col-md-3">
                <%--<asp:Image runat="server" ID="Image1" style="max-height:190px;"/>--%>
                <img src="" runat="server" id="ImageSrc" style="max-height: 150px; max-width: 195px;" />

            </div>

            <div style="clear: both;"></div>
            <!--<asp:PlaceHolder ID="ph" runat="server" />-->
            <div class="applicant-detail" style="border: 2px solid #ccc; margin-top: 20px;">
                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>A. Applicant Details</b></div>
                <br />
                <div style="clear: both;"></div>


                <div class="col-md-12 col-sm-12 col-xs-12"><b>Particulars of the Applicant</b></div>
                <br />
                <div style="clear: both;"></div>
                <label style="width: 35%; float: left;" class="col-md-4">Constitution of Firm/Company :</label>
                <div style="width: 60%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                    <asp:Label ID="lblFirmConstitution" runat="server"></asp:Label></div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-9">Name of the Firm/Company :</label>
                <div style="width: 60%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblCompanyName" runat="server"></asp:Label></div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <div style="width: 75%; float: left; display: none;" class="col-md-9"><b>Whether Application is for 100% export oriented unit?</b></div>
                <div style="width: 25%; float: left; display: none;" class="col-md-3">
                    <asp:Label ID="lblexportoriented" runat="server"></asp:Label></div>

                <div class="col-md-12" style="display: none;"><b>B. Particulars of the Applicant</b></div>
                <div style="clear: both;"></div>
                <label style="width: 35%; float: left;" class="col-md-3">Authorised Person :</label>
                <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblName" runat="server"></asp:Label></div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Pan No :</label>
                <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblPanNo" runat="server"></asp:Label></div>
                <label style="width: 35%; float: left;" class="col-md-3">CIN No :</label>
                <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblCINNo" runat="server"></asp:Label></div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Phone :</label>
                <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblTelephone" runat="server"></asp:Label></div>
                <label style="width: 25%; float: left;" class="col-md-3">Email Id :</label>
                <div style="width: 25%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblEmailInd" runat="server"></asp:Label></div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Address :</label>
                <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-9">
                    <asp:Label ID="lblAddress" runat="server"></asp:Label></div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Plot No :</label>
                <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblPlotNo" runat="server"></asp:Label></div>
                <label style="width: 35%; float: left;" class="col-md-3">Plot Size :</label>
                <div style="width: 15%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblPlotSize" runat="server"></asp:Label></div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Application Ref No :</label>
                <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-9">
                    <asp:Label ID="lblServiceReqno" runat="server"></asp:Label></div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Application Date :</label>
                <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-9">
                    <asp:Label ID="lblApplicationDate" runat="server"></asp:Label></div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Application Re-submission Date :</label>
                <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-9">
                    <asp:Label ID="lblApplicationReDate" runat="server"></asp:Label></div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <div class="col-md-12"><b>
                    <asp:Label runat="server" ID="Headerlbl"></asp:Label></b></div>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <asp:PlaceHolder runat="server" ID="PH1"></asp:PlaceHolder>
                </div>
                <div style="clear: both;"></div>
            </div>
            <div style="clear: both;"></div>
            <div class="JointMortgage-detail" style="border: 2px solid #ccc; margin-top: 20px;">
                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>Details of FI/Bank :</b></div>
                <br />
                <div style="clear: both;"></div>

                <label style="width: 35%; float: left;" class="col-md-3">Paid outstanding balance :</label>
                <div style="width: 45%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblPaidoutstanding" runat="server"></asp:Label></div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Sanction letter no</label>
                <div style="width: 45%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblSanctionletternumber" runat="server"></asp:Label></div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Sanction letter Date</label>
                <div style="width: 45%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblletterDate" runat="server"></asp:Label></div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <label style="width: 35%; float: left;" class="col-md-3">Amount :</label>
                <div style="width: 45%; float: left; font-size: 12px; font-weight: 700;" class="col-md-3">
                    <asp:Label ID="lblAmount" runat="server"></asp:Label></div>
                <div style="clear: both;"></div>
                <hr class="myhrline" />
                <hr class="myhrline" />
                <asp:GridView ID="gridJointMortgage" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                </asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="BankName" HeaderText="Bank Name" SortExpression="BankName" />
                        <asp:BoundField DataField="BranchName" HeaderText="Branch Name" SortExpression="BranchName" />
                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                        <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" SortExpression="MobileNumber" />
                        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                        <asp:BoundField DataField="Percentage" HeaderText="Percentage" SortExpression="Percentage" />
                        <asp:BoundField DataField="Bankstatus" HeaderText="Lead/Other Bank" SortExpression="Bankstatus" />

                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>

                </asp:GridView>
            </div>

            <div class="document-upload" style="border: 2px solid #ccc; margin-top: 20px;">
                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>D. Documents Upload</b></div>
                <br />
                <div style="clear: both;"></div>
                <div class="col-md-12 col-sm-12 col-xs-12">

                    <asp:PlaceHolder runat="server" ID="PH2"></asp:PlaceHolder>
                </div>
                <div style="clear: both;"></div>
            </div>
            <div class="payment hidden" style="border: 2px solid #ccc; margin-top: 20px;" id="Paymentdiv" runat="server" visible="false">
                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>E. Payment</b></div>
                <br />
                <div style="clear: both;"></div>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <asp:PlaceHolder runat="server" ID="PH3"></asp:PlaceHolder>
                </div>
                <div style="clear: both;"></div>
            </div>
            <div class="Dues-details" runat="server" id="Dues_Div" style="border: 2px solid #ccc; margin-top: 20px;" visible="false">
                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>F. Dues Cleared</b></div>
                <br />
                <div style="clear: both;"></div>
                <div class="col-md-12 col-sm-12 col-xs-12">

                    <asp:PlaceHolder runat="server" ID="PH_Dues"></asp:PlaceHolder>
                </div>
                <div style="clear: both;"></div>
            </div>
            <div class="Dues-details" runat="server" id="Objection_Div" style="border: 2px solid #ccc; margin-top: 20px;" visible="false">
                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>G. Objection Cleared</b></div>
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
