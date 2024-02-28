<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ApplicationFinalViewHTML.ascx.cs" Inherits="Allotment.UC_ApplicationFinalViewHTML" %>
  

    <style>
        @media only screen and (max-width:992px) {
            .form-group label.text-right {
                text-align: left !important;
            }
        }

body, h1, h2, h3, h4, h5, h6, p, a, .h1, .h2, .h3, .h4, .h5, .h6 {
    font-family: Segoe UI, Helvetica, Calibri;
}

.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
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
<div class="col-md-12 col-sm-12 col-xs-12">
            <div  id="DivP" style="padding: 15px 25px; margin: 25px;background: #fbfbfb;border: 1px solid #ccc;">
                <div class="div-report" runat="server"  style="text-align: center;">

                    
	                <img src = "/images/upsidclogo.png" class="header-logo" style="border-top:none;height: 40px;margin-bottom:0;" /><span style="float:right;text-align:right;"><b>Form No :</b> <asp:Label ID="lblApplicantId" runat="server">12345678</asp:Label><br /><b>Date :</b> <asp:Label ID="lblDate" runat="server">12.01.2018</asp:Label></span><br/>
	                <strong>U.P. STATE INDUSTRIAL DEVELOPMENT CORPORATION LIMITED, KANPUR<br>
	                (Head Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024)</strong><br /><br />
                    <div style = "border-top:3px solid #ffc511;">&nbsp;</div> 
                </div>
                <style>
                    .my-div-report label {
                        font-weight:600;
                    }
                    .my-div-report .col-md-3{
                        margin:4px 0;
                    }
                    .my-div-report .col-md-9{
                        margin:4px 0;
                    }
                    .my-div-report .col-md-12 {
                        margin-top:15px;
                    }
                </style>
                <form runat="server">
            
                    <div class="my-div-report">
                        <div style="text-align:center;font-size: 18px;font-weight: 600;">Application Form For Allotment of Industrial Plot/Shed</div><br />
                        <div style="clear:both;"></div>
                            <div style="width:75%;float:left;" class="col-md-9">
                                To,<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;The Manager Director,<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;U.P. State Industrial Development Corporation Ltd.<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;A/14, Lakhanpur, KANPUR-208024<br /><br /><br />
                                Dear Sir,<br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;I apply for plot/shed in industrial area/estate of the Corporation. The details are given below.<br /><br /><br />
                            </div>
                            <div style="width:25%;float:left;" class="col-md-3">
                                <%--<asp:Image runat="server" ID="Image1" style="max-height:190px;"/>--%>
                                 <img src = "" runat="server" id="ImageSrc" style="max-height:190px;" />
                                
                            </div>

                        <div style="clear:both;"></div>
                      <!--<asp:PlaceHolder ID="ph" runat="server" />-->
                        <div class="col-md-12 col-sm-12 col-xs-12"><b>A. Particulars of the plot required</b></div><br />
                        <div style="clear:both;"></div>
                        <div style="width:25%;float:left;" class="col-md-3">District :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblDistrict" runat="server"></asp:label></div>
                        <div style="width:25%;float:left;" class="col-md-3">Industrial Area :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblIA" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:25%;float:left;" class="col-md-3">Plot Range(In Sqmt) :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblPlotRange" runat="server"></asp:label></div>
                        <div style="width:25%;float:left;" class="col-md-3">Plot Area(In Sqmt) :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblPlotArea" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:75%;float:left;" class="col-md-9"><b>Whether Application is for expansion of existing unit in same industrial area?</b></div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblExpansion" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:75%;float:left;" class="col-md-9"><b>Whether Application is for 100% export oriented unit?</b></div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblexportoriented" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:25%;float:left;" class="col-md-3">Plot Preference :</div>
                        <div style="width:25%;float:left;" class="col-md-3">1.&nbsp;<asp:label ID="lblPlotpreference1" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:25%;float:left;" class="col-md-3">1.&nbsp;<asp:label ID="lblPlotpreference2" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:25%;float:left;" class="col-md-3">1.&nbsp;<asp:label ID="lblPlotpreference3" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div class="col-md-12"><b>B. Particulars of the Applicant</b></div>
                        <div style="clear:both;"></div>
                        <div style="width:25%;float:left;" class="col-md-3">Name :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblName" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:25%;float:left;" class="col-md-3">Telephone No :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblTelephone" runat="server"></asp:label></div>
                        <div style="width:25%;float:left;" class="col-md-3">Email :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblEmailInd" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:75%;float:left;" class="col-md-3">Address</div>
                        <div style="width:25%;float:left;" class="col-md-9"><asp:label ID="lblAddress" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:75%;float:left;" class="col-md-9"><b>Relevant Experience(In years)</b></div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblRelevantExperience" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:75%;float:left;" class="col-md-9"><b>Whether the networth/turnover of previous year is more than 10 crores?</b></div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblNetworth" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:75%;float:left;" class="col-md-9"><b>Constitution of applicant:Individual/sole proprietorship firm</b></div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblIndividualproprietorship" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div class="col-md-12"><b><asp:Label runat="server" ID="Headerlbl"></asp:Label></b></div>
                        <div style="clear:both;"></div>
                    <div class="col-md-12 col-sm-12 col-xs-12">

                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                                            <Columns>


                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label16" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                                        </asp:Label>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="ApplicantName" HeaderText="Name" SortExpression="AllotteeName" />
                                                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                                                <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                                                <asp:BoundField DataField="emailID" HeaderText="EmailId" SortExpression="EmailId" />

                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="table-responsive">

                                                                        <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                                            <Columns>


                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label17" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                                        </asp:Label>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="DirectorName" HeaderText="Director Name" SortExpression="DirectorName" />
                                                                                <asp:BoundField DataField="DIN_PAN" HeaderText="Din/Pan" SortExpression="DIN_PAN" />
                                                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                                                <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="Phone" />
                                                                                <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                                            </Columns>


                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                                            <Columns>


                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                                        </asp:Label>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="ShareholderName" HeaderText="Shareholder Name" SortExpression="ShareholderName" />
                                                                                <asp:BoundField DataField="SharePer" HeaderText="Share %" SortExpression="SharePer" />
                                                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                                                <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                                                <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                                            </Columns>

                                                                            <EmptyDataTemplate>
                                                                                No Record Available
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                                            <Columns>


                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                                        </asp:Label>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="PartnerName" HeaderText="Partner Name" SortExpression="PartnerName" />
                                                                                <asp:BoundField DataField="PartnershipPer" HeaderText="Partnership %" SortExpression="PartnershipPer" />
                                                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                                                <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                                                <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                                            </Columns>

                                                                            <EmptyDataTemplate>
                                                                                No Record Available
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                                            <Columns>


                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label19" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                                        </asp:Label>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="TrusteeName" HeaderText="Trustee Name" SortExpression="TrusteeName" />
                                                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                                                <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="Phone" />
                                                                                <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                                            </Columns>

                                                                            <EmptyDataTemplate>
                                                                                No Record Available
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                                            <Columns>


                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label20" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                                        </asp:Label>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="AllotteeName" HeaderText="Individual Name" SortExpression="AllotteeName" />
                                                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                                                <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                                                <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>

                                                                </div>
                                                     
                        <div style="clear:both;"></div>
                        <div style="width:25%;float:left;" class="col-md-3">Type of industry :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblIndustrytype" runat="server"></asp:label></div>
                        <div style="width:25%;float:left;" class="col-md-3">Time limit to setup industry(In years) :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblTimelimitSetup" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:25%;float:left;" class="col-md-3">Land Cost(Rs. in Lakh) :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblLandCost" runat="server"></asp:label></div>
                        <div style="width:25%;float:left;" class="col-md-3">Building cost(Rs In Lakh) :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblBuildingCost" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:25%;float:left;" class="col-md-3">Plant & machinery cost(Rs. in Lakh) :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblPlantMachineryCost" runat="server"></asp:label></div>
                        <div style="width:25%;float:left;" class="col-md-3">TotalProjectCost :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblTotalProjectCost" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:25%;float:left;" class="col-md-3">Power requirement(in KW) :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblPowerrequirement" runat="server"></asp:label></div>
                        <div style="width:25%;float:left;" class="col-md-3">Direct employment(In Numbers) :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="Label2" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:25%;float:left;" class="col-md-3">Telephone requirement(In years) :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblTelephonerequirement" runat="server"></asp:label></div>
                        <div style="width:25%;float:left;" class="col-md-3">Ultimate requirement :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblUltimaterequirement" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div class="col-md-12"><b>Proposed rough layout plan of land indicating broadly</b></div><br />
                        <div style="clear:both;"></div>
                        <div style="width:25%;float:left;" class="col-md-3">Covered area(In Sqmt) :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblCoveredarea" runat="server"></asp:label></div>
                        <div style="width:25%;float:left;" class="col-md-3">Open area(In Sqmt) :</div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblOpenArea" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div style="width:75%;float:left;" class="col-md-9"><b>Will any fumes be generated in the process of manufacture and if so, their nature and quantity?</b></div>
                        <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblFumesGenerated" runat="server"></asp:label></div>
                        <div style="clear:both;"></div>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <b>Industrial Effluents :</b> 
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <table class="table table-hover table-bordered request-table" style="width:100%;">
                                <tr>
                                    <th>Name</th>
                                    <th>Quantity</th>
                                    <th>Chemical composition</th>
                                </tr>
                                <tr>
                                    <td>(i)Liquid</td>
                                    <td><asp:label ID="lblLiquidQuantity" runat="server"></asp:label></td>
                                    <td><asp:label ID="lblLiquidComposition" runat="server"></asp:label></td>
                                </tr>
                                <tr>
                                    <td>(ii)Solid</td>
                                    <td><asp:label ID="lblSolidQuantity" runat="server"></asp:label></td>
                                    <td><asp:label ID="lblSolidComposition" runat="server"></asp:label></td>
                                </tr>
                                <tr>
                                    <td>(iii)Gaseous</td>
                                    <td><asp:label ID="lblGasQuantity" runat="server"></asp:label></td>
                                    <td><asp:label ID="lblGasComposition" runat="server"></asp:label></td>
                                </tr>
                            </table>
                    </div>
                    <div style="clear:both;"></div>
                    <div style="width:75%;float:left;" class="col-md-12">Proposed effluent treatment measures :</div>
                    <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblProposedEffluents" runat="server"></asp:label></div>
                    <div style="clear:both;"></div>
                    <div class="col-md-12"><b>D. Payment details</b></div>
                    <div style="clear:both;"></div>
                    <div style="width:25%;float:left;" class="col-md-3">Amount(In Rs) :</div>
                    <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblAmount" runat="server"></asp:label></div>
                    <div style="width:25%;float:left;" class="col-md-3">Bank Reference No :</div>
                    <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblBankRefNo" runat="server"></asp:label></div>
                    <div style="clear:both;"></div>
                    <div style="width:25%;float:left;" class="col-md-3">Transaction Date :</div>
                    <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblTransactionDate" runat="server"></asp:label></div>
                    <div style="width:25%;float:left;" class="col-md-3">Payable at :</div>
                    <div style="width:25%;float:left;" class="col-md-3"><asp:label ID="lblPayableAt" runat="server"></asp:label></div>
                    <div style="clear:both;"></div>
                </div>


                    <div class="div-report" runat="server"  style="text-align: center;">
                    <br /><br /><br /><br />
                    <div style = "border-top:3px solid #ffc511;">&nbsp;</div> 	
                    <div class="mail-disclaimer">
	                <p class="text-justify"><strong>Disclaimer:</strong>The information given in the above applicationis true to the best of my knowledge and belief and the general conditions for allotment of plot/shed and grant of lease indicated in this application form for allotment of plot/shed in the industrial area has been read carefully and understood by me and are fully acceptable to me. I further agree to abide by any and all changes made in the general conditions by the corporation from time to time.</p>
                    </div>
                </div>
            </div>
        </div>
</form>