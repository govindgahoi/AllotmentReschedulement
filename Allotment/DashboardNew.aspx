<%@ Page Title="" Language="C#" MasterPageFile="~/MainUserHO.Master" AutoEventWireup="true" CodeBehind="DashboardNew.aspx.cs" Inherits="Allotment.DashboardNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .request-table tr th[colspan='2'] {
            font-size: 15px !important;
        }

        .div-landbank {
            background: #eb8928;
            border: 1px solid #ccc;
            padding: 10px 0px 0px 0px;
            color: #fff;
            margin: 0;
        }

        iframe {
            border: 0px solid #ccc;
        }

        .request-table tr th {
            white-space: nowrap;
            text-align: center;
        }

        .request-table tr td {k
            white-space: nowrap;
        }

        .mypadding {
            padding: 0 0px;
        }

        .panel-heading {
            text-transform: uppercase !important;
        }
        .panel-heading1 .glyphicon {
            font-size: 20px;
            top: -5px;
        }
    </style>
    <script type="text/javascript">

        function PrintElem() {

            Popup($('#grtindviewP').html());
        }


        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=1000');
            mywindow.document.write('<html><head><title style="font-weight:bold;">Allottee Details</title>');
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
    <div class="row" style="border: 1px solid #ccc;">
        <div class="panel panel-default">
            <div class="panel-heading">UPSIDC Industrial Land Bank- Summary</div>
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="" style="border: 1px solid #ccc; margin: 0px 0;">
                    <div class="">
                        <div class="row div-landbank ">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <span style="font-size: 18px;">Land Bank <span class="pull-right">Total Area:
                                    <asp:Label runat="server" ID="lblgtotal"></asp:Label>
                                    Acres</span></span>
                                <hr style="border-bottom: 0px solid #fff; margin: 4px 0; border-top: 1px solid #ddd;" />
                            </div>
                            <div class="clearfix"></div>
                            <div class="" style="padding: 16px 0px; background: #713800;">
                                <div class="col-md-2 col-sm-12 col-xs-12">
                                    Industrial :
                                    <asp:Label ID="lblIndustrial" CssClass="" runat="server"></asp:Label>
                                    Acres
                                </div>
                                <div class="col-md-2 col-sm-12 col-xs-12 pad-lt0 pad-rt0">
                                    Institutional :
                                    <asp:Label ID="lblInstitutional" CssClass="" runat="server"></asp:Label>
                                    Acres
                                </div>
                                <div class="col-md-2 col-sm-12 col-xs-12 pad-lt0 pad-rt0">
                                    Commercial :
                                    <asp:Label ID="lblCommercial" CssClass="" runat="server"></asp:Label>
                                    Acres
                                </div>
                                <div class="col-md-2 col-sm-12 col-xs-12 pad-lt0 pad-rt0">
                                    Facilities & Others :
                                    <asp:Label ID="lblFacilitiesOthers" CssClass="" runat="server"></asp:Label>
                                    Acres
                                </div>
                                <div class="col-md-2 col-sm-12 col-xs-12 pad-lt0 pad-rt0">
                                    Green Zone :
                                    <asp:Label ID="lblGreenZone" CssClass="" runat="server"></asp:Label>
                                    Acres
                                </div>
                                <div class="col-md-2 col-sm-12 col-xs-12 pad-lt0 pad-rt0">
                                    Residential :
                                    <asp:Label ID="lblResidential" CssClass="" runat="server"></asp:Label>
                                    Acres
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <hr style="margin-top: 6px; margin-bottom: 6px; border: 0; border-top: 2px solid #f5f5f5;" />
    <div class="clearfix"></div>
    <div class="row" style="border: 1px solid #ccc;">
        <div class="panel panel-default">
            <div class="panel-heading font-bold">INDUSTRIAL LAND BANK  - MAP</div>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top: 10px">
            <!--<img src="../images/Capture.PNG" class="img-fluid" alt="Responsive image" style="width: 730px; max-width: 100%">-->
            <iframe class="projectmgt-iframe" src="htm/graph.htm" width="100%" height="600"></iframe>
            <div class="row ">
                <div class="col-md-1 col-sm-2 col-xs-2" style="font-weight: bold; font-size: 12px;">
                    Legend:
                </div>
                <div class="col-md-1 col-sm-2 col-xs-2">
                    <ul class="list-inline legend-ul">
                        <li>
                            <div style="border-radius: 50%; width: 10px; height: 10px; background: yellow;"></div>
                        </li>
                        <li>UPSIDC</li>
                    </ul>
                </div>
              
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr style="margin-top: 6px; margin-bottom: 6px; border: 0; border-top: 2px solid #f5f5f5;" />
    <div class="row" style="border: 1px solid #ccc;display:none;">
        <div class="panel panel-default" >
            <div class="panel-heading">Filter</div>
            <div  style="background: #e4e4e4" >
                <div class="form-group" style="background: #d8d8d8;">
                    <div class="">
                        <label class="col-md-3 col-sm-3 col-xs-12 text-right">
                            Regional Office :
                        </label>
                        <div class="col-md-3 col-sm-3 col-xs-12">
                            <asp:DropDownList runat="server" ID="ddloffice" Style="background: #fff;width:200px;" CssClass="input-sm similar-select1"></asp:DropDownList>
                        </div>
                        <label class="col-md-3 col-sm-3 col-xs-12 text-right">
                            Industrial Area :
                        </label>
                        <div class="col-md-3 col-sm-3 col-xs-12">
                            <asp:DropDownList runat="server" ID="drpdwnIA" Style="background: #fff;width:200px;" CssClass="input-sm similar-select1"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="">
                        <label class="col-md-3 text-right">
                            Plot Bank Status :
                        </label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="drpPlotBankStatus" runat="server" Style="background: #fff;width:200px;" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
                            </asp:DropDownList>
                        </div>
                        <label class="col-md-3 text-right">
                            Categories :
                        </label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="drpCategories" runat="server" Style="background: #fff;width:200px;" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-1 col-sm-1 col-xs-1">Services</div>
                    <label class="col-md-2 text-right">
                        New Allotment :
                    </label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="drpNewAllotment" runat="server" Style="background: #fff;width:200px;" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
                            </asp:DropDownList>
                    </div>
                    <label class="col-md-3 text-right">
                        Transfer/Records :
                    </label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="drpTransfer" runat="server" Style="background: #fff;width:200px;" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-1 col-sm-1 col-xs-1"></div>
                    <label class="col-md-2 text-right">
                        Cancellation :
                    </label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="drpCancellation" runat="server" Style="background: #fff;width:200px;" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
                            </asp:DropDownList>
                    </div>
                    <label class="col-md-3 text-right">
                        Restoration:
                    </label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="drpRestoration" runat="server" Style="background: #fff;width:200px;" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
                            </asp:DropDownList>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-1 col-sm-1 col-xs-1"></div>
                    <label class="col-md-2 text-right">
                        Subdivision :
                    </label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="drpSubdivision" runat="server" Style="background: #fff;width:200px;" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
                            </asp:DropDownList>
                    </div>
                    <label class="col-md-3 text-right">
                        Amalgamation:
                    </label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="drpAmalgamation" runat="server" Style="background: #fff;width:200px;" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
                            </asp:DropDownList>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-1 col-sm-1 col-xs-1"></div>
                    <label class="col-md-2 text-right">
                        Time Extension :
                    </label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="drpTimeExtension" runat="server" Style="background: #fff;width:200px;" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
                            </asp:DropDownList>
                    </div>
                    <label class="col-md-3 text-right">
                        Maintainence:
                    </label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="drpMaintainence" runat="server" Style="background: #fff;width:200px;" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
                            </asp:DropDownList>
                    </div>
                    <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-1 col-sm-1 col-xs-1"></div>
                    <label class="col-md-2 text-right">
                        Subletting :
                    </label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="drpSubletting" runat="server" Style="background: #fff;width:200px;" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
                            </asp:DropDownList>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <asp:Button ID="btnfetch" runat="server" Text="Fetch" CssClass="btn-primary ey-bg pull-right" Width="100px" Style="margin: 8px;" />
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    </div>
    <div class="clearfix"></div>
        <div class="panel-group" id="accordion1">
                
                    <div class="panel panel-default">
                            <div class="panel-heading">
                                <span class="panel-title">
            	                    <a href="#Exampleone" data-toggle="collapse" data-parent="#accordion1">
                                        <span class="glyphicon glyphicon-plus"></span>
                                        UPSIDC Industrial Land Bank- Details 
                                        <span id="print-land-bank-details" class="pull-right">
                                            <i class='fa fa-print'></i>
                                        </span>
                                    </a>
                                </span>
                            </div>
                            <div class="panel-collapse collapse" id="Exampleone">
                                <div id="grtindviewP" class="col-md-12 col-sm-12 col-xs-12">
                                <div class="table-responsive" style="overflow-y: auto; max-height: 500px;">
                                    <asp:GridView ID="grtindview" runat="server"
                                        CssClass="table table-bordered request-table request-table-col cmtable-bg myreq-col"
                                        AutoGenerateColumns="False"
                                        OnDataBound="grtindview_DataBound"
                                        OnRowCreated="grtindview_RowCreated">
                                        <Columns>
                                            <%--<asp:BoundField HeaderText="Land Use" Visible="false" DataField="LANDUSETYPE" SortExpression="LANDUSETYPE" />
                                            <asp:BoundField HeaderText="" DataField="CorporationName" />
                                            <asp:BoundField HeaderText="Location" DataField="IANAME" SortExpression="IANAME" Visible="true" />
                                            <asp:BoundField HeaderText="Unit" DataField="Unit" SortExpression="Unit" />
                                            <asp:BoundField HeaderText="Plot" DataField="PlotNumber" SortExpression="PlotNumber" />
                                            <asp:BoundField HeaderText="In SQMts." DataField="TotalArea" SortExpression="TotalArea" />
                                            <asp:BoundField HeaderText="Allotted Date" DataField="AllotmentIssueDate" SortExpression="AllotmentIssueDate" />
                                            <asp:BoundField HeaderText="Address" DataField="Address" SortExpression="Address" />
                                            <asp:BoundField HeaderText="ContactNumber" DataField="ContactNumber" SortExpression="ContactNumber" />--%>


                                            <asp:BoundField HeaderText="Regional Office" DataField="RegionalOffice" />
                                            <asp:BoundField HeaderText="Industrial Area" DataField="IndustrialArea" />
                                            <asp:BoundField HeaderText="Units" NullDisplayText="0" DataField="Unit_Industrial" />
                                            <asp:BoundField HeaderText="Acres" NullDisplayText="0.00" DataField="Area_Industrial" />
                                            <asp:BoundField HeaderText="Units" NullDisplayText="0" DataField="Unit_Residential" />
                                            <asp:BoundField HeaderText="Acres" NullDisplayText="0.00" DataField="Area_Residential" />
                                            <asp:BoundField HeaderText="Units" NullDisplayText="0" DataField="Unit_Commercial" />
                                            <asp:BoundField HeaderText="Acres" NullDisplayText="0.00" DataField="Area_Commercial" />
                                            <asp:BoundField HeaderText="Units" NullDisplayText="0" DataField="Unit_Institutional" />
                                            <asp:BoundField HeaderText="Acres" NullDisplayText="0.00" DataField="Area_Institutional" />
                                            <asp:BoundField HeaderText="Units" NullDisplayText="0" DataField="Unit_Facilities & Others" />
                                            <asp:BoundField HeaderText="Acres" NullDisplayText="0.00" DataField="Area_Facilities & Others" />
                                            <asp:BoundField HeaderText="Units" NullDisplayText="0" DataField="Unit_Green Zone" />
                                            <asp:BoundField HeaderText="Acres" NullDisplayText="0.00" DataField="Area_Green Zone" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Record Available
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                            </div>
                    </div>
                
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span class="panel-title">
            	                    <a href="#Exampletwo" data-toggle="collapse" data-parent="#accordion1">
                                        <span class="glyphicon glyphicon-plus"></span>
                                        Summary- Plot Status 
                                        <span id="print-summary-plot-status" class="pull-right">
                                            <i class='fa fa-print'></i>
                                        </span>
                                    </a>
                            </span>
                        </div>
                        <div class="panel-collapse collapse" id="Exampletwo">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="plot-statusgrid mypadding table-responsive" style="overflow-y: auto; max-height: 500px;">
                                <asp:GridView ID="GridPlotSummary" runat="server"
                                    CssClass="table table-bordered request-table request-table-col cmtable-bg myreq-col"
                                    AutoGenerateColumns="False">

                                    <Columns>
                                        <asp:BoundField HeaderText="Plot Status" DataField="Status" />
                                        <asp:BoundField HeaderText="Categories" DataField="Substatus" />
                                        <asp:BoundField HeaderText="Units" NullDisplayText="0" DataField="inunits" />
                                        <asp:BoundField HeaderText="Acres" NullDisplayText="0.00" DataField="INACRES" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                        </div>
                    </div>
                
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span class="panel-title">
            	                    <a href="#Examplethree" data-toggle="collapse" data-parent="#accordion1">
                                        <span class="glyphicon glyphicon-plus"></span>
                                            Industrial Area Wise - Plot Summary 
                                            <span id="print-IA-plot-summary" class="pull-right">
                                                <i class='fa fa-print'></i>
                                            </span>
                                        </a>
                                </span>
                        </div>
                        <div class="panel-collapse collapse" id="Examplethree">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="plot-statusgrid mypadding table-responsive" style="overflow-y: auto; max-height: 500px;">
                                <asp:GridView ID="GridViewroPlotSummary" runat="server"
                                    CssClass="table table-bordered request-table request-table-col cmtable-bg myreq-col"
                                    AutoGenerateColumns="False">

                                    <Columns>
                                        <asp:BoundField HeaderText="Regional Office" DataField="REGIONALOFFICE" />
                                        <asp:BoundField HeaderText="IndustrialArea" DataField="IANAme" />
                                        <asp:BoundField HeaderText="Plot Status" DataField="Status" />
                                        <asp:BoundField HeaderText="Categories" DataField="Substatus" />
                                        <asp:BoundField HeaderText="Units" NullDisplayText="0" DataField="inunits" />
                                        <asp:BoundField HeaderText="Acres" NullDisplayText="0.00" DataField="INACRES" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                        </div>
                    </div>
                
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span class="panel-title">
            	                    <a href="#Examplefore" data-toggle="collapse" data-parent="#accordion1">
                                        <span class="glyphicon glyphicon-plus"></span>
                                        Industrial Area Wise - Plot Details 
                                        <span id="print-IA-plot-details" class="pull-right">
                                            <i class='fa fa-print'></i>
                                        </span>
                                    </a>
                            </span>
                        </div>
                        <div class="panel-collapse collapse" id="Examplefore">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="plot-statusgrid mypadding table-responsive" style="overflow-y: auto; max-height: 500px;">
                                <asp:GridView ID="GridViewplots" runat="server"
                                    CssClass="table table-bordered request-table request-table-col cmtable-bg myreq-col"
                                    AutoGenerateColumns="False">

                                    <Columns>
                                        <asp:BoundField HeaderText="PlotMasterId" Visible="false" DataField="PlotMasterId" />
                                        <asp:BoundField HeaderText="Regional Office" DataField="RegionalOffice" />
                                        <asp:BoundField HeaderText="IndustrialArea" DataField="IAName" />
                                        <asp:BoundField HeaderText="PlotNumber" DataField="PlotNumber" />
                                        <asp:BoundField HeaderText="PlotArea(SQMts.)" DataField="PlotArea" />
                                        <asp:BoundField HeaderText="Plot Status" DataField="Status" />
                                        <asp:BoundField HeaderText="Categories" DataField="Substatus" />
                                        <asp:BoundField HeaderText="landuseCode" DataField="landuseCode" />
                                        <asp:BoundField HeaderText="North" DataField="NORTH" />
                                        <asp:BoundField HeaderText="South" DataField="SOUTH" />
                                        <asp:BoundField HeaderText="East" DataField="EAST" />
                                        <asp:BoundField HeaderText="West" DataField="WEST" />
                                        <asp:BoundField HeaderText="Locked" DataField="ISLOCKED" />
                                        <asp:BoundField HeaderText="Remarks" DataField="REMARKS" />

                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span class="panel-title">
            	                    <a href="#Examplefive" data-toggle="collapse" data-parent="#accordion1">
                                        <span class="glyphicon glyphicon-plus"></span>
                                            Industrial Area Wise:Available for Allotment-Summary 
                                            <span id="print-IA-available-alotment-summary" class="pull-right">
                                                <i class='fa fa-print'></i>
                                            </span>
                                        </a>
                                </span>
                        </div>
                        <div class="panel-collapse collapse" id="Examplefive">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="plot-statusgrid mypadding table-responsive" style="overflow-y: auto; max-height: 500px;">
                                <asp:GridView ID="GridViewadv" runat="server"
                                    CssClass="table table-bordered request-table request-table-col cmtable-bg myreq-col"
                                    AutoGenerateColumns="False">

                                    <Columns>
                                        <asp:BoundField HeaderText="Regional Office" DataField="REGIONALOFFICE" />
                                        <asp:BoundField HeaderText="IndustrialArea" DataField="IANAme" />
                                        <asp:BoundField HeaderText="Plot Status" Visible="false" DataField="Status" />
                                        <asp:BoundField HeaderText="Categories" DataField="Substatus" />
                                        <asp:BoundField HeaderText="Units" NullDisplayText="0" DataField="inunits" />
                                        <asp:BoundField HeaderText="Acres" NullDisplayText="0.00" DataField="INACRES" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span class="panel-title">
            	                    <a href="#Examplesix" data-toggle="collapse" data-parent="#accordion1">
                                        <span class="glyphicon glyphicon-plus"></span>
                                        Industrial Area Wise:Available for Allotment Details 
                                        <span id="print-IA-available-alotment-details" class="pull-right">
                                            <i class='fa fa-print'></i>
                                        </span>
                                    </a>
                            </span>
                        </div>
                        <div class="panel-collapse collapse" id="Examplesix">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="details-grid mypadding">
                                <div class="plot-statusgrid mypadding table-responsive" style="overflow-y: auto; max-height: 500px;">
                                    <asp:GridView ID="GridViewadvdetails" runat="server"
                                        CssClass="table table-bordered request-table request-table-col cmtable-bg myreq-col"
                                        AutoGenerateColumns="False">

                                        <Columns>
                                            <asp:BoundField HeaderText="PlotMasterId" Visible="false" DataField="PlotMasterId" />
                                            <asp:BoundField HeaderText="Regional Office" DataField="RegionalOffice" />
                                            <asp:BoundField HeaderText="IndustrialArea" DataField="IAName" />
                                            <asp:BoundField HeaderText="PlotNumber" DataField="PlotNumber" />
                                            <asp:BoundField HeaderText="PlotArea(SQMts.)" DataField="PlotArea" />
                                            <asp:BoundField HeaderText="Plot Status" Visible="false" DataField="Status" />
                                            <asp:BoundField HeaderText="Categories" DataField="Substatus" />
                                            <asp:BoundField HeaderText="landuseCode" DataField="landuseCode" />
                                            <asp:BoundField HeaderText="North" DataField="FRONTSIDE" />
                                            <asp:BoundField HeaderText="South" DataField="SIDE1" />
                                            <asp:BoundField HeaderText="East" DataField="SIDE2" />
                                            <asp:BoundField HeaderText="West" DataField="BACKSIDE" />
                                            <asp:BoundField HeaderText="Locked" DataField="ISLOCKED" />
                                            <asp:BoundField HeaderText="Remarks" DataField="REMARKS" />

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
    <%--<div class="row" style="border: 1px solid #ccc;display:none;">
        <div class="panel panel-default">
            <div class="panel-heading">Land Summary Services - IA <a href="#" id="print-land-summary-IA" class="pull-right"><i class='fa fa-print'></i></a></div>
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="plot-detailsgrid mypadding table-responsive" style="overflow-y: auto; max-height: 500px;">
                    <table class="table table-bordered table-hover request-table">
                        <tr>
                            <th class="my-heading font-bold">IA Service Request</th>
                            <th class="my-heading font-bold">New Allotment</th>
                            <th class="my-heading font-bold">Transfer/Reconstitution</th>
                            <th class="my-heading font-bold">Cancellation</th>
                            <th class="my-heading font-bold">Restoration</th>
                            <th class="my-heading font-bold">Subdivision</th>
                            <th class="my-heading font-bold">Amalgamation</th>
                            <th class="my-heading font-bold">Time Extension</th>
                            <th class="my-heading font-bold">Maintainence</th>
                            <th class="my-heading font-bold">Subletting</th>
                            <th>Total</th>
                        </tr>
                        <tr>
                            <td>Status:</td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Completed:</td>
                            <td>21</td>
                            <td>21</td>
                            <td>21</td>
                            <td>21</td>
                            <td>21</td>
                            <td>21</td>
                            <td>21</td>
                            <td>21</td>
                            <td>21</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>In Progress - on track:</td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>In Progress - late:</td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Remainning:</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Total</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr style="margin-top: 6px; margin-bottom: 6px; border: 0; border-top: 2px solid #f5f5f5;" />
    <div class="row" style="border: 1px solid #ccc;display:none;">
        <div class="panel panel-default">
            <div class="panel-heading">Summary Services - Building Plan Approval <a href="#" id="print-summary-building-approval" class="pull-right"><i class='fa fa-print'></i></a></div>
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="plot-detailsgrid mypadding table-responsive" style="overflow-y: auto; max-height: 500px;">
                    <table class="table table-bordered table-hover request-table">
                        <tr>
                            <th class="my-heading font-bold">IA Service Request</th>
                            <th class="my-heading font-bold">Construction Permit</th>
                            <th class="my-heading font-bold">Completion</th>
                            <th class="my-heading font-bold">Inspection</th>
                            <th>Total</th>
                        </tr>
                        <tr>
                            <td>Status:</td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Completed:</td>
                            <td>21</td>
                            <td>21</td>
                            <td>21</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>In Progress - on track:</td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>In Progress - late:</td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Remainning:</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Total</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr style="margin-top: 6px; margin-bottom: 6px; border: 0; border-top: 2px solid #f5f5f5;" />--%>
        <div class="panel panel-default">
            <div class="panel-heading">
                            <span class="panel-title">
            	                    <a href="#Exampleseven" data-toggle="collapse" data-parent="#accordion1">
                                        <span class="glyphicon glyphicon-plus"></span>
                                            Land Allotment Pendency
                                            <span class="pull-right">
                                                <i class='fa fa-print'></i>
                                            </span>
                                        </a>
                                </span>
                </div>
                <div class="panel-collapse collapse" id="Exampleseven">       
            
                    <div class="LA-grid mypadding table-responsive" style="overflow-y: auto; max-height: 600px;">
                          <asp:PlaceHolder ID="ph" runat="server" />
                    </div>
                </div>
            
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                            <span class="panel-title">
            	                    <a href="#Exampleeight" data-toggle="collapse" data-parent="#accordion1">
                                        <span class="glyphicon glyphicon-plus"></span>
                                           Building Plan Pendency
                                            <span class="pull-right">
                                                <i class='fa fa-print'></i>
                                            </span>
                                        </a>
                                </span>
                </div>
                <div class="panel-collapse collapse" id="Exampleeight"> 
            
                    <div class="BP-grid mypadding table-responsive" style="overflow-y: auto; max-height: 600px;">
                          <asp:PlaceHolder ID="ph1" runat="server" />
                    </div>
                </div>
            
        </div>
    </div>

    <script>
$(document).ready(function(){
$('.collapse').on('shown.bs.collapse', function(){
$(this).parent().find(".glyphicon-plus").removeClass("glyphicon-plus").addClass("glyphicon-minus");
}).on('hidden.bs.collapse', function(){
$(this).parent().find(".glyphicon-minus").removeClass("glyphicon-minus").addClass("glyphicon-plus");
});       
});
</script>

    
    <hr class="separation" />
    <script>
        $(document).ready(function () {
            // Add minus icon for collapse element which is open by default
            $(".collapse.in").each(function () {
                $(this).siblings(".panel-heading1").find(".glyphicon").addClass("glyphicon-minus").removeClass("glyphicon-plus");
            });

            // Toggle plus minus icon on show hide of collapse element
            $(".collapse").on('show.bs.collapse', function () {
                $(this).parent().find(".glyphicon").removeClass("glyphicon-plus").addClass("glyphicon-minus");
            }).on('hide.bs.collapse', function () {
                $(this).parent().find(".glyphicon").removeClass("glyphicon-minus").addClass("glyphicon-plus");
            });
        });
    </script>
</asp:Content>
