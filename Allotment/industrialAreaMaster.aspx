<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="industrialAreaMaster.aspx.cs" Inherits="Allotment.industrialAreaMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


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
    <style>
        .content {
            min-height: 650px;
        }

        .div-listleft {
            border: 1px solid #ccc;
            min-height: 73vh;
        }

        @media only screen and (min-width: 960px) {
            .pad-left0 {
                padding-left: 2px;
            }

            .pad-right0 {
                padding-right: 2px;
            }
        }

        .div-view.div-scroll {
            overflow-y: scroll;
            max-height: 390px;
            margin: 0px 24px;
            border: 1px solid #ccc;
        }

        .left-plotlist option {
            border-bottom: 1px solid #ccc;
            font-size: 10px;
            padding-left: 8px;
        }

        @media only screen and (min-width: 900px) {
            .left-plotlist {
                width: 100%;
                height: 506px !important;
            }
        }
    </style>
    <script>


</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>


    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">


        <ContentTemplate>
            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                <ProgressTemplate>
                    <div class="fgh">
                        <div class="hgf">
                            <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <cc1:MessageBox ID="MessageBox1" runat="server" />
            <div class="row topbtncollapse" id="topbtncollapse">
                <div class="col-md-12 col-sm-12 col-xs-12 top-menu-fulldiv12" style="background: #dbdbdb;">
                    <div>
                        <div style="" class="text-center top-menu-fulldiv">
                            Dashboard<br />
                            <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                                <li class="">
                                    <asp:HyperLink Enabled="false" runat="server" ID="menu_dashboard"><i class="fa fa-tachometer" aria-hidden="true"></i><br />Dashboard</asp:HyperLink>
                                </li>
                            </ul>
                        </div>
                        <div style="border-left: 1px solid #000;" class="text-center top-menu-fulldiv">
                            Operate<br />
                            <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                                <li>
                                    <a runat="server" id="menunew" onserverclick="menunew_ServerClick"><i class="fa fa-plus" aria-hidden="true"></i>
                                        <br />
                                        New</a>
                                </li>
                                <li>
                                    <a runat="server" id="menuedit" onserverclick="menuedit_ServerClick"><i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                        <br />
                                        Edit</a>
                                </li>
                                <li>
                                    <a runat="server" id="menudelete" onserverclick="menudelete_ServerClick"><i class="fa fa-trash-o" aria-hidden="true"></i>
                                        <br />
                                        Delete</a>
                                </li>
                                <li>
                                    <a runat="server" id="Save_menu" onserverclick="Save_menu_ServerClick"><i class="fa fa-floppy-o " aria-hidden="true"></i>
                                        <br />
                                        Save</a>
                                </li>
                                <li>
                                    <a runat="server" id="refresh_menu" onserverclick="refresh_menu_ServerClick"><i class="fa fa-refresh" aria-hidden="true"></i>
                                        <br />
                                        Refresh</a>
                                </li>
                            </ul>
                        </div>
                        <div style="border-left: 1px solid #000; border-right: 1px solid #000;" class="text-center top-menu-fulldiv">
                            Services<br />
                            <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">

                                <li>
                                    <asp:HyperLink Enabled="false" runat="server" ID="menu_draft"><i class="fa fa-pencil-square-o" aria-hidden="true"></i><br />Drafted</asp:HyperLink>
                                </li>
                                <li>
                                    <asp:HyperLink Enabled="false" runat="server" ID="menu_submitted"><i class="fa fa-th-list" aria-hidden="true"></i><br />Submitted</asp:HyperLink>
                                </li>

                                <li>
                                    <asp:HyperLink Enabled="false" runat="server" ID="menu_track"><i class="fa fa-credit-card" aria-hidden="true"></i><br />Track</asp:HyperLink>

                                </li>
                                <li>
                                    <asp:HyperLink Enabled="false" runat="server" ID="menu_export"><i class="fa fa-credit-card" aria-hidden="true"></i><br />Export</asp:HyperLink>
                                </li>
                                <li>
                                    <asp:HyperLink Enabled="false" runat="server" ID="menu_import"><i class="fa fa-credit-card" aria-hidden="true"></i><br />Export</asp:HyperLink>
                                </li>
                                <li>
                                    <asp:HyperLink Enabled="false" runat="server" ID="print"><i class="fa fa-credit-card" aria-hidden="true"></i><br />Print</asp:HyperLink>
                                </li>
                            </ul>
                        </div>
                        <div style="" class="text-center top-menu-fulldiv">
                            Navigation<br />
                            <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                                <li>
                                    <asp:HyperLink Enabled="false" runat="server" ID="menu_last"><i class="fa fa-step-backward" aria-hidden="true"></i><br />Last</asp:HyperLink>

                                </li>
                                <li>
                                    <asp:HyperLink Enabled="false" runat="server" ID="menu_previous"><i class="fa fa-angle-double-left" aria-hidden="true"></i><br />Previous</asp:HyperLink>
                                </li>
                                <li>
                                    <asp:HyperLink Enabled="false" runat="server" ID="menu_next"><i class="fa fa-angle-double-right" aria-hidden="true"></i><br />Next</asp:HyperLink>

                                </li>
                                <li>
                                    <asp:HyperLink Enabled="false" runat="server" ID="menu_final"><i class="fa fa-step-forward" aria-hidden="true"></i><br />Final</asp:HyperLink>

                                </li>
                            </ul>
                        </div>
                        <div style="border-left: 1px solid #000;" class="text-center top-menu-fulldiv">
                            Reports<br />
                            <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                                <li>
                                    <asp:HyperLink Enabled="false" runat="server" ID="menu_reports"><i class="fa fa-credit-card" aria-hidden="true"></i><br />Reports</asp:HyperLink>

                                </li>
                            </ul>
                        </div>
                        <div style="border-left: 1px solid #000;" class="text-center top-menu-fulldiv">
                            Repository<br />
                            <ul class="list-inline master-nav-icons master-nav-iconsbr master-nav-iconsbr-last" style="border-top: 1px solid #ccc;">
                                <li>
                                    <asp:HyperLink Enabled="false" runat="server" ID="menu_repository"><i class="fa fa-database" aria-hidden="true"></i><br />Repository</asp:HyperLink>

                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
            <div id="divMessageError" class="MessagePennel" runat="server" style="display: none;">
                <label>
                    <span class="check-cross" runat="server">✖</span>

                    <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
                </label>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="panel panel-default">
                        <div>
                            <table id="tblsearch" class="table table-striped table-bordered table-hover  margin-b-2px request-table">
                                <tr style="background: #ececec;">
                                    <td class="font-bold">
                                        <span style="color: Red">*</span>
                                        Regional Office :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddloffice" runat="server" OnSelectedIndexChanged="Regional_Changed" AutoPostBack="true" CssClass="chosen input-sm similar-select1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                            </table>
                        </div>
                        <div class="row">
                            <div class="col-md-2 col-sm-4 col-xs-12 pad-right0">
                                <div class="div-listleft">
                                    <div class="panel panel-heading font-bold"></div>
                                    <div style="max-height: 528px; overflow-y: auto;">
                                        <asp:GridView ID="GridView2" runat="server"
                                            CssClass="table table-striped table-bordered table-hover request-table"
                                            AllowPaging="false"
                                            AllowSorting="True"
                                            AutoGenerateColumns="False"
                                            DataKeyNames="Id,IAName,IACategory,SectorStatus,TotalLandAcquired,TotIALandForAllotment,DistrictID,
                                            TotIAPlotsForAllotment,IARatePerSqmt,TotResLandForAllotment,TotResPlotForAllotment,ResRatePerSqmt ,TotCommLandForAllotment
                                             ,TotCommPlotsForAllotment,CommRatePerSqmt,TotInstPlotsForAllotment,InstRatePerSqmt,LandForFacilities,LandForRoad,LandUnderGreenBelt,LandForPark
                                            ,BulkLand,OtherLandArea,OtherLandDesc,IndustriesAllowed,FacilitiesAvailable,IndustrialSpecific,PollutionCategory,TotInstLandForAllotment,UseZone,pollutioncategoryStatus,ParkSD,IAType,EnvtClOb,
                                            MixedSector,SubSector,NHighway,DistNH,SHighway,DistSH,RStation,DistRS,Airport,DistAir,Seaport,Distport,DryPort,Distdryport,DistRailS,Zonal,DistZonal,PoliceSt,DistPolice,FireSt,DistFire,Bank,DistBank,Hospital
                                            ,DistHosp,ElectA,ElectC,ElectU,WaterA,WaterC,WaterU,GasA,GasC,GasU,STPA,STPC,STPU,EPoleA,PowerSSA,PowerSSC,PowerSSU,WTPA,WTPC,WTPU,ICTA,ICTS,SWDA,SWDC,SWDU,DhA,PtA,OtherInformation,VillageID,SubDistictID,TruckparkingCapecity,DormitoriesCapecity,EVMApprovalReffno,InstantAllotmentAvailable "
                                            GridLines="Horizontal"
                                            OnRowDataBound="GridView2_RowDataBound"
                                            OnRowCommand="GridView2_RowCommand"
                                            OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
                                            Width="100%"
                                            ItemStyle-Width="10%">
                                            <Columns>
                                                <asp:BoundField DataField="IAName" HeaderText="Industrial Area" SortExpression="IAName" />
                                                <asp:BoundField DataField="IACategory" HeaderText="IACategory" Visible="false" SortExpression="IACategory" />
                                                <asp:BoundField DataField="SectorStatus" HeaderText="SectorStatus" Visible="false" SortExpression="SectorStatus" />
                                                <asp:BoundField DataField="TotalLandAcquired" HeaderText="TotalLandAcquired" Visible="false" SortExpression="TotalLandAcquired" />
                                                <asp:BoundField DataField="TotIALandForAllotment" HeaderText="TotIALandForAllotment" Visible="false" SortExpression="TotIALandForAllotment" />
                                                <asp:BoundField DataField="TotIAPlotsForAllotment" HeaderText="TotIAPlotsForAllotment" Visible="false" SortExpression="TotIAPlotsForAllotment" />
                                                <asp:BoundField DataField="IARatePerSqmt" HeaderText="IARatePerSqmt" Visible="false" SortExpression="IARatePerSqmt" />
                                                <asp:BoundField DataField="TotResLandForAllotment" HeaderText="TotResLandForAllotment" Visible="false" SortExpression="TotResLandForAllotment" />
                                                <asp:BoundField DataField="TotResPlotForAllotment" HeaderText="SIDE1" Visible="false" SortExpression="TotResPlotForAllotment" />
                                                <asp:BoundField DataField="ResRatePerSqmt" HeaderText="ResRatePerSqmt" Visible="false" SortExpression="ResRatePerSqmt" />
                                            </Columns>
                                        </asp:GridView>
                                        <%--<asp:ListView ID="lstPlot" runat="server" CssClass="left-plotlist"  AutoPostBack="true" Width="100%" ForeColor="Black"></asp:ListView>--%>
                                        <%--<asp:ListView ID="lstPlots" runat="server" CssClass="left-plotlist"  AutoPostBack="true" Width="100%" ForeColor="Black" ></asp:ListView>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-10 col-sm-8 col-xs-12 pad-left0">
                                <div class="div-listleft" style="position: relative;">
                                    <div style="margin: 3px 4px; border: 1px solid #ccc;">
                                        <div style="border: 3px solid #ccc;">
                                            <div class="panel-heading font-bold">
                                                <div class="col-md-8 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                                    Industrial Area Information
                                                </div>
                                                <div class="clearfix"></div>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">

                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Distict :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="drpDistict" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="drpDistict_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Sub Distict :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlSubDistict" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="ddlSubDistict_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Village Name :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:ListBox runat="server" ID="ddlVillage" CssClass="MultiSelect" SelectionMode="Multiple"></asp:ListBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Industrial Area :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtIndustrialArea" Enabled="false" runat="server" onblur="validatepan(this,'Industrial Area');" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Total Land Acquired (In Acres):
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtBoxTotalLandAcquired" runat="server" onblur="validatepan(this,'Total Land Acquired');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" Enabled="false" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Industrial Area Category:
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="IACategory" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                                                    </div>


                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Use Zone :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlUsezone" runat="server" CssClass="chosen input-sm similar-select1" Enabled="false">
                                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Value="M0- Industrial General / Mixed/Existing" Text="M0- Industrial General / Mixed/Existing"></asp:ListItem>
                                                            <asp:ListItem Value="M1-.Industries (Polluting)" Text="M1-.Industries (Polluting)"></asp:ListItem>
                                                            <asp:ListItem Value="M2- Industries (Non- Polluting)" Text="M2- Industries (Non- Polluting)"></asp:ListItem>
                                                            <asp:ListItem Value="M3- Service Industries" Text="M3- Service Industries"></asp:ListItem>
                                                            <asp:ListItem Value="M4- Flatted Industries" Text="M4- Flatted Industries"></asp:ListItem>
                                                            <asp:ListItem Value="M5-Household Industries" Text="M5-Household Industries"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Type of Industrial  Category:
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlIAType" runat="server" CssClass="chosen input-sm similar-select1" Enabled="false">
                                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Value="Coastal Economic Zone" Text="Coastal Economic Zone"></asp:ListItem>
                                                            <asp:ListItem Value="Industrial Area" Text="Industrial Area"></asp:ListItem>
                                                            <asp:ListItem Value="Industrial Corridor Node" Text="Industrial Corridor Node"></asp:ListItem>
                                                            <asp:ListItem Value="Industrial Cluster" Text="Industrial Cluster"></asp:ListItem>
                                                            <asp:ListItem Value="Industrial Estate" Text="Industrial Estate"></asp:ListItem>
                                                            <asp:ListItem Value="Industrial Park" Text="Industrial Park"></asp:ListItem>
                                                            <asp:ListItem Value="Industrial Region" Text="Industrial Region"></asp:ListItem>
                                                            <asp:ListItem Value="Export Promotion Industrial Parks" Text="Export Promotion Industrial Parks"></asp:ListItem>
                                                            <asp:ListItem Value="National Investment and Manufacturing" Text="National Investment and Manufacturing"></asp:ListItem>
                                                            <asp:ListItem Value="Special Economic Zones" Text="Special Economic Zones"></asp:ListItem>
                                                            <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Industries Sector Allowed :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:ListBox runat="server" ID="drpIndustriesAllowed" CssClass="MultiSelect" Width="100%" OnSelectedIndexChanged="drpIndustriesAllowed_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="form-group" id="divMixedSector" runat="server" visible="false">
                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            Mixed Sector :
                                                        </label>
                                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtMixedSector" runat="server" class="input-sm similar-select1" onblur="validatepan(this,'Mixed Sector');" Enabled="false"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        SubSector :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtSubSector" runat="server" class="input-sm similar-select1" Enabled="false" onblur="validatepan(this,'SubSector Details');"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Short Description of Industrial Area :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtparksd" runat="server" class="input-sm similar-select1" Enabled="false" onblur="validatepan(this,'Short Description of Industrial Area');"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Instant Allotment  :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlInstantAllotment" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1">
                                                            <asp:ListItem>--select--</asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="panel-heading font-bold">
                                                <div class="col-md-8 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                                    Industrial Area 
                                                </div>
                                                <div class="clearfix"></div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-4 col-xs-4 text-right">
                                                        Total Land For Allotment(In Acres) :
                                                    </label>
                                                    <div class="col-md-2 col-sm-4 col-xs-4">
                                                        <asp:TextBox ID="textBoxTotIALandForAllotment" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" Enabled="false" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-4 col-xs-4 text-right">
                                                        Total Plots For Allotment :
                                                    </label>
                                                    <div class="col-md-2 col-sm-4 col-xs-4">
                                                        <asp:TextBox ID="textBoxTotIAPlotsForAllotment" runat="server" ToolTip="only Numeric Value" onblur="validatepan(this,'Total Land For Allotment');" onkeypress="return txtTotalArea_keypress(event);" Enabled="false" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-4 col-xs-4 text-right">
                                                        Industrial Area Rate(Per Sqmt) :
                                                    </label>
                                                    <div class="col-md-2 col-sm-4 col-xs-4">
                                                        <asp:TextBox ID="txtIARatePerSqmt" runat="server" ToolTip="only Numeric Value" onblur="validatepan(this,'Total Land For Allotment');" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="panel-heading font-bold">
                                                <div class="col-md-8 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                                    Residential Area 
                                                </div>
                                                <div class="clearfix"></div>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Total Land For Allotment (In Acres):
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtBackTotResLandForAllotment" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Total Plot For Allotment :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtTotResPlotForAllotment" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Residential Rate (Per Sqmt) :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtResRatePerSqmt" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="panel-heading font-bold">
                                                <div class="col-md-8 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                                    Commercial Area 
                                                </div>
                                                <div class="clearfix"></div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Total Land For Allotment (In Acres):
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtTotCommLandForAllotment" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>

                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Total Plots For Allotment :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtTotCommPlotsForAllotment" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Commercial Rate (Per Sqmt) :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtCommRatePerSqmt" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="panel-heading font-bold">
                                                <div class="col-md-8 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                                    Institutional Area 
                                                </div>
                                                <div class="clearfix"></div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Total Land For Allotment (In Acres):
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox runat="server" ID="txtTotInstLandForAllotment" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Total Plots For Allotment :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtTotInstPlotsForAllotment" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Institute Rate(Per Sqmt) :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox runat="server" ID="txtInstRatePerSqmt" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="panel-heading font-bold">
                                                <div class="col-md-8 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                                    Other Area 
                                                </div>
                                                <div class="clearfix"></div>
                                            </div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Land For Facilities (In Acres):
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtLandForFacilities" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Land For Road (In Acres):
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox runat="server" ID="txtLandForRoad" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Land For GreenBelt (In Acres):
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtLandUnderGreenBelt" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Land For Park (In Acres):
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox runat="server" ID="txtLandForPark" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Bulk Land (In Acres):
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtBulkLand" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Other Land Area (In Acres):
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox runat="server" ID="txtOtherLandArea" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Other Land Desc (In Acres):
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox runat="server" ID="txtOtherLandDesc" ToolTip="only Numeric Value" Enabled="false" class="input-sm similar-select1"></asp:TextBox>
                                                    </div>

                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        FacilitiesAvailable :
                                                    </label>
                                                    <div class="col-md-6 col-sm-6 col-xs-6">

                                                        <asp:ListBox runat="server" ID="List1" CssClass="MultiSelect" SelectionMode="Multiple"></asp:ListBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        National Highway :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtNHighway" runat="server" ToolTip="Like : NH 5, NH 122" class="input-sm similar-select1" Enabled="false" onblur="validatepan(this,'National Highway');"></asp:TextBox>
                                                    </div>

                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Distance from NH(in Km) :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtDistNH" runat="server" onblur="validatepan(this,'Distance from NH(in Km)');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        State Highway :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtSHighway" runat="server" ToolTip="Like: SH4, SH89" class="input-sm similar-select1" onblur="validatepan(this,'State Highway');" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Distance from SH(in Km) :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtDistSH" runat="server" onblur="validatepan(this,'Distance from SH(in Km)');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Railway Station :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtRStation" runat="server" ToolTip="Kanpur center" onblur="validatepan(this,'State Highway');" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>

                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Distance from Railway Station(in Km) :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtDistRS" runat="server" onblur="validatepan(this,'Distance from Railway Station(in Km)');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Airport :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtAirport" runat="server" ToolTip="Kanpur Airport" onblur="validatepan(this,'Airport Name');" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>

                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Distance from Airport(in km) :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtDistAir" runat="server" onblur="validatepan(this,'Distance from Airport(in km)');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Seaport :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtSeaport" runat="server" ToolTip="Kanpur center" onblur="validatepan(this,'Seaport Name');" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Distance from seaport(in Km) :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtDistport" runat="server" onblur="validatepan(this,'Distance from seaport(in km)');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        ICD/Dry port :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtDryPort" runat="server" ToolTip="Kanpur center" onblur="validatepan(this,'ICD/Dry port');" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>

                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Distance from Dry Port/ICD(in Km) :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtDistdryport" runat="server" onblur="validatepan(this,'Distance from Dry Port/ICD(in km)');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Distance from Railway Silding :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtDistRailS" runat="server" onblur="validatepan(this,'Distance from Railway Silding');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>

                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Zonal Name :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlZonal" runat="server" CssClass="chosen input-sm similar-select1" Enabled="false">
                                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Value="Northern Railway" Text="Northern Railway,Baroda House, New Delhi"></asp:ListItem>
                                                            <asp:ListItem Value="North Central  Railway" Text="North Central  Railway,Allahabad"></asp:ListItem>
                                                            <asp:ListItem Value="North Eastern  Railway" Text="North Eastern  Railway,Gorakhpur"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%--<asp:TextBox ID="txtZonal" runat="server" ToolTip="only Numeric Value" class="input-sm similar-select1" Enabled="false"></asp:TextBox>--%>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Distance from Zonal :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtDistZonal" runat="server" onblur="validatepan(this,'Distance from Zonal(in km)');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Police Station :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtPoliceSt" runat="server" onblur="validatepan(this,'Police Station');" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>

                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Distance from Police Station(in Km) :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtDistPolice" runat="server" onblur="validatepan(this,'Distance from Police Station(in km)');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Fire Station :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtFireSt" runat="server" onblur="validatepan(this,'Fire Station');" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>

                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Distance from Fire Station(in Km) :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtDistFire" runat="server" onblur="validatepan(this,'Distance from Fire Station(in km)');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Bank :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtBank" runat="server" ToolTip="like :Bank of Baroda" onblur="validatepan(this,'Bank Name');" class="input-sm similar-select1" Enabled="false"> </asp:TextBox>
                                                    </div>

                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Distance from Bank(in Km) :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtDistBank" runat="server" onblur="validatepan(this,'Distance from Bank(in km)');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Hospital :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtHospital" runat="server" ToolTip="like :AIMS" onblur="validatepan(this,'Hospital Name');" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>

                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Distance from Hospital(in Km) :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtDistHosp" runat="server" onblur="validatepan(this,'Distance from Hospital(in km)');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Other Information :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtOtherInformation" onblur="validatepan(this,'Other Information;)" runat="server" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>

                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Electricity/Power availability :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlElectA" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1" OnSelectedIndexChanged="ddlElectA_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem>--select--</asp:ListItem>
                                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group" id="divElectU" runat="server" visible="false">
                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            Electricity/Power Capacity(KVA) :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtElectC" runat="server" onblur="validatepan(this,'Electricity/Power Capacity(KVA)');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>

                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            Electricity/Power (Utilization (in %)) :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtElectU" runat="server" onblur="validatepan(this,'Electricity/Power (Utilization (in %));" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Water availability :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlWaterA" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1" OnSelectedIndexChanged="ddlWaterA_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem>--select--</asp:ListItem>
                                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group" id="divWaterC" runat="server" visible="false">
                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            Water Capacity(MLD) :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtWaterC" runat="server" onblur="validatepan(this,'Water Capacity(MLD);" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>
                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            Water (Utilization (in %)) :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtWaterU" runat="server" onblur="validatepan(this,'Water (Utilization (in %));" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr class="myhrline" />
                                            <div class="clearfix"></div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Gas Line availability :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlGasLine" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1" OnSelectedIndexChanged="ddlGasLine_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem>--select--</asp:ListItem>
                                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group" id="divGasC" runat="server" visible="false">
                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            Gas  Capacity (MBH) :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtGasC" runat="server" onblur="validatepan(this,'Gas  Capacity (MBH);" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>

                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            Gas Utilization (in %) :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtGasU" runat="server" onblur="validatepan(this,'Gas Utilization (in %);" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr class="myhrline" />
                                            <div class="clearfix"></div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        STP :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlSTP" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1" OnSelectedIndexChanged="ddlSTP_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem>--select--</asp:ListItem>
                                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group" id="divSTPC" runat="server" visible="false">
                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            STP  Capacity (MLD) :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtSTPC" runat="server" onblur="validatepan(this,'STP  Capacity (MLD);" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>

                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            STP Utilization (in %) :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtSTPU" runat="server" onblur="validatepan(this,'STP Utilization (in %);" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr class="myhrline" />
                                            <div class="clearfix"></div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Electric Pole :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlEPoleA" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1">
                                                            <asp:ListItem>--select--</asp:ListItem>
                                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr class="myhrline" />
                                            <div class="clearfix"></div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Power Sub Station :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlPowerSSA" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1" OnSelectedIndexChanged="ddlPowerSSA_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem>--select--</asp:ListItem>
                                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group" id="divPowerSSC" runat="server" visible="false">

                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            Power Sub Station Capacity (KVA) :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtPowerSSC" runat="server" onblur="validatepan(this,'Power Sub Station Capacity (KVA);" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>

                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            Power Sub Station Utilization (in %) :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtPowerSSU" runat="server" onblur="validatepan(this,'Power Sub Station Utilization (in %);" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                            <hr class="myhrline" />
                                            <div class="clearfix"></div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        WTP :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlWTP" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1" OnSelectedIndexChanged="ddlWTP_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem>--select--</asp:ListItem>
                                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group" id="divWTPC" runat="server" visible="false">
                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            WTP Capacity (MLD) :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtWTPC" runat="server" onblur="validatepan(this,'WTP Capacity (MLD);" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>

                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            WTP Utilization (in %) :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtWTPU" runat="server" onblur="validatepan(this,'WTP Utilization (in %);" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr class="myhrline" />
                                            <div class="clearfix"></div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        ICT :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlICT" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1" OnSelectedIndexChanged="ddlICT_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem>--select--</asp:ListItem>
                                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group" id="divICTS" runat="server" visible="false">
                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            ICTS Speed (Mbps):
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtICTS" runat="server" onblur="validatepan(this,'ICTS Speed (Mbps);" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                            <hr class="myhrline" />
                                            <div class="clearfix"></div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Solid Waste Disposal Facility :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlSWDA" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1" OnSelectedIndexChanged="ddlSWDA_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem>--select--</asp:ListItem>
                                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group" id="divSWDC" runat="server" visible="false">
                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            Solid Waste Disposal Capacity (TDP) :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtSWDC" runat="server" onblur="validatepan(this,'Solid Waste Disposal Capacity (TDP);" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>

                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            Solid Waste Disposal Utilization (in %) :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtSWDU" runat="server" onblur="validatepan(this,'Solid Waste Disposal Utilization (in %);" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr class="myhrline" />
                                            <div class="clearfix"></div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Dormitories/Hostels for workers available :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlDhA" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1" OnSelectedIndexChanged="ddlDhA_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem>--select--</asp:ListItem>
                                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group" id="divDormitoriesCapecity" runat="server" visible="false">
                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            Dormitories Capecity :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtDormitoriesCapecity" runat="server" onblur="validatepan(this,'Dormitories Capecity;)" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <hr class="myhrline" />
                                            <div class="clearfix"></div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Designated Truck parking available inside the park :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlPtA" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1" OnSelectedIndexChanged="ddlPtA_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem>--select--</asp:ListItem>
                                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group" id="divTruckparkingCapecity" runat="server" visible="false">
                                                        <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                            Designated Truck parking Capecity :
                                                        </label>
                                                        <div class="col-md-2 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtTruckparkingCapecity" runat="server" onblur="validatepan(this,'Designated Truck parking Capecity;)" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr class="myhrline" />
                                            <div class="clearfix"></div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Is there any pollution category Restriction :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlpollutionCategorystatus" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1" OnSelectedIndexChanged="ddlpollutionCategorystatus_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem>--select--</asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        pollution category :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="drppollutionCategory" Enabled="false" runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr class="myhrline" />
                                            <div class="clearfix"></div>
                                            <div class="row">
                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                    Environmental Clearance Obtained :
                                                </label>
                                                <div class="col-md-2 col-sm-6 col-xs-6">
                                                    <asp:DropDownList ID="ddlEnvtClOb" runat="server" Enabled="false" CssClass="chosen input-sm similar-select1" OnSelectedIndexChanged="ddlEnvtClOb_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem>--select--</asp:ListItem>
                                                        <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                        <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group" id="divApprovalreffno" runat="server" visible="false">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Approval  reff No :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <asp:TextBox ID="txtApprovalReffno" onblur="validatepan(this,'Approval  reff No;)" runat="server" class="input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div id="Tracing" class="row" runat="server" visible="false">
                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                    Upload  Relevant Order :
                                                </label>
                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                    <asp:FileUpload ID="fileupload1" runat="server" CssClass="form-control form-control-sm" />
                                                </div>
                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                    <asp:Button ID="btnupload" runat="server" Text="Upload" CssClass="rounded-0 btn btn-primary" Style="padding: 2px 15px; margin-top: 5px;" OnClick="btnupload_Click" />
                                                    <asp:Button ID="btnView" runat="server" Text="View" CssClass="rounded-0 btn btn-primary" Style="padding: 2px 15px; margin-top: 5px;" OnClick="btnView_Click" />
                                                </div>

                                            </div>


                                            <asp:Label runat="server" ID="lblIAID" Visible="false"></asp:Label>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="text-right" style="display: none;">
                                <button type="button" class="accordion-toggle btn-primary ey-bg" data-toggle="collapse" style="font-size: 12px;" data-parent="#accordion" href="#Allotteedetailbank">
                                    <span class="glyphicon glyphicon-plus"></span>
                                    Allottee Details 
                                </button>
                            </div>
                            <div id="Allotteedetailbank" class="panel-collapse collapse alt-btn">
                                <div class="div-view div-scroll" style="overflow-y: scroll; max-height: 320px;">
                                    <%--  <uc1:UC_ApplicantDetails runat="server" ID="UC_ApplicantDetails" />--%>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            </div>
        </ContentTemplate>

    </asp:UpdatePanel>
    <script>
        function txtTotalArea_keypress(evt) {

            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {
                var txt = document.getElementById("<%= txtBoxTotalLandAcquired.ClientID %>");
                if (txt.value.length > 0) {
                    txt.style.borderColor = "";
                }
            }
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
        function validatepan(obj, txt) {
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


        function isDecimalKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {


            }
        }

    </script>
</asp:Content>
