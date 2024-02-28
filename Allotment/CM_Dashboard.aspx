<%@ Page Title="" Language="C#" MasterPageFile="~/CM_MainUser.Master" AutoEventWireup="true" Debug="true" CodeBehind="CM_Dashboard.aspx.cs"
    Inherits="Allotment.LandingPage" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/cmo/css/IDADashboard.css"/>
    <script type="text/javascript" src="/js/loader.js"></script>
    <script type="text/javascript" src="/js/highcharts.js"></script>
    <script type="text/javascript" src="/js/data.js"></script>
    <script type="text/javascript" src="/js/drilldown.js"></script>
    <style>
        .legend-ul {
            font-size: 9px;
        }

        iframe {
            border: 0px solid #ccc;
        }

        .request-table-margetop {
            margin-top: 5px;
        }

        .request-table-col tr th {
            background-color: #ffe600;
        }

        .tr-total td {
            color: #000;
        }

        .request-table-col tr:hover th {
            color: #000;
        }

        tr.cm-table-heading {
            background-color: #2d2d2d;
        }

            tr.cm-table-heading:hover {
                background-color: #2d2d2d;
            }

            tr.cm-table-heading th {
                color: #ffffff !important;
            }

        .cmtable-bg tr td {
            background: #e0e0e0;
        }

        .cmtable-bg tr th {
            background-color: #ffe600;
        }

        .border_none > tbody > tr > td {
            border: 1px solid #dddddd08;
        }

        .border_none > tbody > tr > th {
            border: 1px solid #dddddd08;
        }

        .border_none {
            border: 1px solid #dddddd08;
        }


        .tr-upsidc {
            background-color: #368EE0;
        }

            .tr-upsidc td {
                color: #fff;
            }

        .tr-gnida {
            background-color: #00ABA9;
        }

            .tr-gnida td {
                color: #fff;
            }

        .tr-noida {
            background-color: #F8A31F;
        }

            .tr-noida td {
                color: #fff;
            }

        .tr-yeida {
            background-color: #E671B8;
        }

            .tr-yeida td {
                color: #fff;
            }

        .tr-total {
            background-color: #e0e0e0;
        }


        .guage-land-div {
            color: #fff;
            padding: 5px 12px 12px 12px;
            margin: 14px 0;
            border-radius: 5px;
        }

            .guage-land-div p {
                font-size: 12px;
                margin: 4px 0 0 0;
            }

            .guage-land-div .guage-heading {
                font-size: 27px;
                margin-bottom: 6px;
            }

        #Allottee_master_grid tr th {
            text-align: center;
            font-size: 12px;
            color: #000;
            font-weight: 600;
        }

        #Allottee_master_grid tr td {
            font-size: 12px;
        }

        .mainbg-div {
            position: relative;
        }

        #GUAGE_UPSIDC {
            position: relative;
            z-index: 1;
        }

        #GUAGE_NOIDA {
            position: relative;
            z-index: 1;
        }

        #GUAGE_GNIDA {
            position: relative;
            z-index: 1;
        }

        #GUAGE_YAMUNA {
            position: relative;
            z-index: 1;
        }

        .bg-div {
            position: absolute;
            z-index: 999;
            width: 100%;
            height: 200px;
            top: 0;
            background: #cccccc40;
        }

        .request-table tr a:before {
            text-align: center !important;
            margin: 0px 14px;
        }

        .request-table {
            margin-top: 10px;
        }

            .request-table tr th a {
                color: #2d2d2d;
            }

            .request-table tr th {
                font-size: 13px;
                font-weight: 500;
            }

            .request-table tr th {
                color: #2d2d2d;
                font-weight: 600;
            }

        .request-cell-width tr th {
            color: #000;
        }

        .request-cell-width1 tr th {
            color: #459bc5;
        }

        .request-table tr th {
            padding: 0 6px !important;
        }

        .request-table tr td {
            font-size: 12px;
            /*color: #2d2d2d;*/
            text-align: left;
            padding: 1px 6px !important;
        }

        .request-table-col tr td {
            /* color: #fff; */
        }

        .request-table-col tr td {
        }

        .request-table-col tr:hover td {
            color: #000;
        }

        .nav > li > a:hover {
            color: #000;
        }

        .request-table tr a:before {
            color: #000;
        }

        .request-table {
            margin-top: 0 !important;
            margin-bottom: 2px;
        }

            .request-table tr th {
                vertical-align: middle !important;
                font-size: 12px;
            }

            .request-table tr td {
                vertical-align: middle !important;
                font-size: 12px;
            }

        .request-cell-width .font-bold {
            width: 300px;
        }

        .font-bold {
            font-weight: 600;
            font-size: 12px !important;
            padding-top: 2px;
        }

        .request-cell-width1 .font-bold {
            width: 300px;
        }

        .request-cell-width tr {
            border-bottom: 1px solid #ccc;
        }



            .request-cell-width tr td {
                /*border-bottom: 1px solid #949090 !important;*/
            }

        .request-cell-width1 tr td {
            /*border-bottom: 1px solid #949090 !important;*/
        }

        .myreq-col tr td {
            font-size: 10px;
            color: #2d2d2d;
            border: 1px solid #fff !important;
            text-align: left;
            background: #e0e0e0;
            padding: 1px 6px !important;
        }

        .myreq-col tr th {
            font-size: 10px;
        }

        .myreq-col tr td a {
            color: #337ab7;
            font-weight: bold;
        }
    </style>
    <%--<style>
        .box-panel {
            -webkit-box-shadow: 0 1px 1px transparent;
            box-shadow: 0 1px 1px transparent;
        }

        .box-back-none {
            background: none !important;
            box-shadow: inset 0px 1px 1px transparent !important;
        }

        @media only screen and (max-width:992px) {
            .form-group label.text-right {
                text-align: left !important;
            }
        }

        .tooltip {
            position: absolute;
            top: 0;
            left: 0;
            z-index: 3;
            display: none;
            background-color: #FB66AA;
            color: White;
            padding: 5px;
            font-size: 10pt;
            font-family: Arial;
        }

        td {
            cursor: pointer;
        }
    </style>




    <style>
        .border_none > tbody > tr > td {
            border: 1px solid #dddddd08;
        }

        .border_none > tbody > tr > th {
            border: 1px solid #dddddd08;
        }

        .border_none {
            border: 1px solid #dddddd08;
        }


        .tr-upsidc {
            background-color: #368EE0;
        }

            .tr-upsidc td {
                color: #fff;
            }

        .tr-gnida {
            background-color: #00ABA9;
        }

            .tr-gnida td {
                color: #fff;
            }

        .tr-noida {
            background-color: #F8A31F;
        }

            .tr-noida td {
                color: #fff;
            }

        .tr-yeida {
            background-color: #E671B8;
        }

            .tr-yeida td {
                color: #fff;
            }

        .guage-land-div {
            color: #fff;
            padding: 5px 12px 12px 12px;
            margin: 14px 0;
            border-radius: 5px;
        }

        .request-table-col tr td {
            color: #fff;
            font-weight: 600;
        }

        .request-table-col tr:hover td {
            color: #000;
        }

        .guage-land-div p {
            font-size: 12px;
            margin: 4px 0 0 0;
        }

        .guage-land-div .guage-heading {
            font-size: 27px;
            margin-bottom: 6px;
        }

        #Allottee_master_grid tr th {
            text-align: center;
            font-size: 13px;
        }

        #Allottee_master_grid tr td {
            font-size: 13px;
        }

        .mainbg-div {
            position: relative;
        }

        #GUAGE_UPSIDC {
            position: relative;
            z-index: 1;
        }

        #GUAGE_NOIDA {
            position: relative;
            z-index: 1;
        }

        #GUAGE_GNIDA {
            position: relative;
            z-index: 1;
        }

        #GUAGE_YAMUNA {
            position: relative;
            z-index: 1;
        }

        .bg-div {
            position: absolute;
            z-index: 999;
            width: 100%;
            height: 200px;
            top: 0;
            background: #cccccc40;
        }

        .request-table tr a:before {
            text-align: center !important;
            margin: 0px 14px;
        }

        .request-table tr th a {
            color: #2d2d2d;
        }

        .request-table tr th {
            font-size: 13px;
            font-weight: 500;
        }

        .request-table tr th {
            color: #2d2d2d;
        }

        .request-cell-width tr th {
            color: #000;
        }

        .request-cell-width1 tr th {
            color: #459bc5;
        }

        .request-table tr th {
            padding: 0 6px !important;
        }

        .request-table tr td {
            font-size: 12px;
            text-align: left;
            padding: 1px 6px !important;
        }

        .request-table tr a:before {
            color: #000;
        }

        .request-table {
            margin-top: 0 !important;
            margin-bottom: 2px;
        }

            .request-table tr th {
                vertical-align: middle !important;
                font-size: 12px;
            }

            .request-table tr td {
                vertical-align: middle !important;
                font-size: 12px;
            }

        .request-cell-width .font-bold {
            width: 300px;
        }

        .font-bold {
            font-weight: 600;
            font-size: 12px !important;
            padding-top: 2px;
        }

        .request-cell-width1 .font-bold {
            width: 300px;
        }

        .request-cell-width tr {
            border-bottom: 1px solid #ccc;
        }

        .tr-total td {
            color: #000;
        }

        .tr-total {
            background-color: #e0e0e0;
        }



        .request-cell-width tr td {
            /*border-bottom: 1px solid #949090 !important;*/
        }

        .request-cell-width1 tr td {
            /*border-bottom: 1px solid #949090 !important;*/
        }
    </style>--%>
    <script type="text/javascript">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">
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
            <cc1:ConfirmBox ID="ConfirmBox1" runat="server" />


            <table runat="server" visible="false" class="table table-striped table-bordered table-hover request-table">
                <tr>
                    <th>User Name</th>
                    <th>Company Id</th>
                    <th>Company Name</th>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblUsername"></asp:Label></td>
                    <td>
                        <asp:Label runat="server" ID="lblCompanyId"></asp:Label></td>
                    <td>
                        <asp:Label runat="server" ID="lblCompanyName"></asp:Label></td>
                </tr>
            </table>
            <div class="clearfix"></div>
            <div class="clearfix"></div>
            </div>
    		<!-- end menu section-->

            <!-- middle page content section-->
            <div id="wrapper">
                <!-- Navigation -->
                <div id="page-wrapper" style="">
                    <div class="row">
                        <div class="">
                            <div class="panel panel-default" style="border-color: transparent; border: 0px solid transparent; margin-bottom: 0;">

                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <div class="">
                                        <div class="row" style="border: 1px solid #ccc; margin: 0px 0;">

                                            <div class="panel-heading font-bold">
                                                INDUSTRIAL LAND BANK, UTTAR PRADESH - SUMMARY<span class="pull-right"><span><b>Total:</b></span>
                                                    <asp:Label ID="land_use_all" runat="server" />
                                                    Acres</span>
                                            </div>


                                            <div class="col-md-3 col-sm-12 col-xs-12">

                                                <!--<div class="mainbg-div">
							<div id="GUAGE_UPSIDC" style="min-width: 100%; height: 200px; max-width: 600px;margin: 0 auto"></div>
						   <div class="bg-div"></div>
						</div>-->

                                                <div class="Guage_UPSIDC guage-land-div" style="background-color: #368EE0;">
                                                    <div class="guage-heading">
                                                        UPSIDC <span class="pull-right">
                                                            <asp:Label ID="land_use_upsid" runat="server" />
                                                        </span>
                                                    </div>

                                                    <asp:GridView ID="GridView_land_use_1"
                                                        runat="server"
                                                        CssClass="table border_none table-bordered table-hover request-table request-table-col"
                                                        AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text="My Header" Visible="False"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text='<%#Eval("Land Type") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField ItemStyle-CssClass="pull-right">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text="My Header" Visible="False"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text='<%#Eval("UPSIDC") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                      <a href="http://118.185.3.27/gisupsidc/" target="_blank" style="color:#ffffff">Visit UPSIDC Industrial Area on GIS</a>
                                                </div>
                                            </div>


                                            <div class="col-md-3 col-sm-12 col-xs-12">
                                                <div class="GUAGE_GNIDA guage-land-div" style="background-color: #F8A31F;">
                                                    <div class="guage-heading">
                                                        NOIDA <span class="pull-right">
                                                            <asp:Label ID="land_use_gnida" runat="server" /></span>
                                                    </div>

                                                    <asp:GridView ID="GridView_land_use_2"
                                                        runat="server"
                                                        CssClass="table border_none table-bordered table-hover request-table request-table-col"
                                                        AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text="My Header" Visible="False"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text='<%#Eval("Land Type") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField ItemStyle-CssClass="pull-right">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text="My Header" Visible="False"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text='<%#Eval("NOIDA") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <a href="#" style="color:#ffffff">Visit Noida on GIS</a>
                                                </div>
                                            </div>


                                            <div class="col-md-3 col-sm-12 col-xs-12">
                                                <div class="GUAGE_NOIDA guage-land-div" style="background-color: #00ABA9;">
                                                    <div class="guage-heading">
                                                        GNIDA <span class="pull-right">
                                                            <asp:Label ID="land_use_noida" runat="server" /></span>
                                                    </div>

                                                    <asp:GridView ID="GridView_land_use_3"
                                                        runat="server"
                                                        CssClass="table border_none table-bordered table-hover request-table request-table-col"
                                                        AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text="My Header" Visible="False"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text='<%#Eval("Land Type") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField ItemStyle-CssClass="pull-right">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text="My Header" Visible="False"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text='<%#Eval("GNIDA") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                     <a href="http://www.investgnida.in/gis/" target="_blank" style="color:#ffffff">Visit GraterNoida on GIS</a>

                                                </div>
                                            </div>


                                            <div class="col-md-3 col-sm-12 col-xs-12">
                                                <div class="GUAGE_YAMUNA guage-land-div" style="background-color: #E671B8;">
                                                    <div class="guage-heading">
                                                        YEIDA <span class="pull-right">
                                                            <asp:Label ID="land_use_yeida" runat="server" /></span>
                                                    </div>

                                                    <asp:GridView ID="GridView_land_use_4"
                                                        runat="server"
                                                        CssClass="table border_none table-bordered table-hover request-table request-table-col"
                                                        AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text="My Header" Visible="False"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text='<%#Eval("Land Type") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField ItemStyle-CssClass="pull-right">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text="My Header" Visible="False"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text='<%#Eval("YEIDA") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                     <a href="http://umd.nic.in/yeida/AppSelect/index.aspx" target="_blank" style="color:#ffffff">Visit YEIDA on GIS</a>
                                                </div>
                                            </div>
                                        </div>

                                        <hr style="margin-top: 6px; margin-bottom: 6px; border: 0; border-top: 2px solid #f5f5f5;" />
                                        <div class="clearfix"></div>
                                        <div class="row" style="border: 1px solid #ccc; margin: 0px 0;">
                                            <div class="panel-heading font-bold">INDUSTRIAL LAND BANK, UTTAR PRADESH - DETAIL</div>
                                            <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top: 10px">
                                                <!--<img src="../images/Capture.PNG" class="img-fluid" alt="Responsive image" style="width: 730px; max-width: 100%">-->
                                                <iframe class="projectmgt-iframe" src="htm/graph.htm" width="100%" height="420"></iframe>
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
                                                    <div class="col-md-1 col-sm-2 col-xs-2">
                                                        <ul class="list-inline legend-ul">
                                                            <li>
                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: green;"></div>
                                                            </li>
                                                            <li>NOIDA</li>
                                                        </ul>
                                                    </div>
                                                    <div class="col-md-1 col-sm-2 col-xs-2">
                                                        <ul class="list-inline legend-ul">
                                                            <li>
                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: red;"></div>
                                                            </li>
                                                            <li>GNIDA</li>
                                                        </ul>
                                                    </div>
                                                    <div class="col-md-1 col-sm-2 col-xs-2">
                                                        <ul class="list-inline legend-ul">
                                                            <li>
                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: pink;"></div>
                                                            </li>
                                                            <li>YEIDA</li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                            
                                        </div>
                                        <hr style="margin-top: 6px; margin-bottom: 6px; border: 0; border-top: 2px solid #f5f5f5;" />
                                        <div class="clearfix"></div>
                                        <div class="row" style="border: 1px solid #ccc; margin: 0px 0;">
                                            <div class="panel-heading font-bold">
                                                INDUSTRIAL LAND BANK, UTTAR PRADESH - DETAIL
                                                <a href="IDAReport.aspx"><span class="pull-right"><i class="fa fa-arrows-alt">Detail View</i></span></a>  <span class="pull-right hide">
                                            </div>
                                            <div class="col-md-12 col-sm-6 col-xs-12">
                                                    <div class="table table-bordered request-table request-table-margetop col-md-12 padding-off" style="background:#2d2d2d">
                                                        <div class="col-md-4"></div>
                                                        <div class="col-md-4"><b style="color:#ffffff; text-align:center">List of Industrial Area </b></div>
                                                        <div class="col-md-4">
                                                            <asp:DropDownList ID="ddlAuthorityName" runat="server"  Style="float:right; height:25px" OnSelectedIndexChanged="ddlAuthorityName_SelectedIndexChanged" AutoPostBack="true" CssClass="input-sm dropdown-toggle similar-select1"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                   
                                                </div>
                                            <div class="panel-body row">
                                             <div class="col-md-12 col-sm-12 col-xs-12">
                                                        <div style="overflow-x: auto; overflow-y: auto; min-height: 500px; max-height: 500px;">
                                                            <div class="">
                                                        <asp:GridView ID="GridlistIndustrial"
                                                            runat="server"
                                                            CssClass="table table-bordered request-table request-table-col cmtable-bg myreq-col"
                                                            AutoGenerateColumns="false" >
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Authority/Corporation" DataField="Authority"></asp:BoundField>
                                                                <asp:TemplateField HeaderText="Location">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("RegionalOffice") %>' />
                                                                        (<asp:Label ID="Label2" runat="server" Text='<%#Eval("IANAME") %>' />)
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Total Area" DataField="TotalIASize"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Rate(In Rs)" DataField="Rate"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Residential Area" DataField="TotalResidentialArea"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Industrial Area" DataField="TotalIndustrialArea"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Facilities Area" DataField="TotalFacilitiesArea"></asp:BoundField>
                                                                <asp:BoundField HeaderText="GreenZone Area" DataField="TotalGreenZoneArea"></asp:BoundField>
                                                                <asp:BoundField HeaderText="TotalCommercial Area" DataField="TotalCommercialArea"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Institutional Area" DataField="TotalInstitutionalArea"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Mix Area" DataField="TotalMixArea"></asp:BoundField>
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
                                        <hr style="margin-top: 6px; margin-bottom: 6px; border: 0; border-top: 2px solid #f5f5f5;" />
                                        <div class="clearfix"></div>
                                        <div class="row" style="border: 1px solid #ccc; margin: 0px 0;">
                                            <div class="panel-heading font-bold">
                                                UNALLOTED LAND/LAND AVAILABLE FOR ALLOTMENT  <a href="IDAReport.aspx"><span class="pull-right"><i class="fa fa-arrows-alt">Detail View</i></span></a>  <span class="pull-right hide">
                                                    <asp:Label ID="sum_unalloted_plot" runat="server" />Acres</span>
                                            </div>
                                            <div class="col-md-8 col-sm-6 col-xs-12">
                                                <div id="container1" style="width: 100%; height: 500px;"></div>
                                            </div>
                                            <div class="col-md-4 col-sm-6 col-xs-12">
                                                <div style="margin: 5px 0;">
                                                    <table class="table table-bordered request-table request-table-margetop">
                                                        <tr class="cm-table-heading">
                                                            <th colspan="3" class="text-center font-bold">
                                                                <b>Total No of UnAllotted Plots</b>
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="padding: 0px !important">

                                                                <asp:GridView ID="GridView_UnAllotted_plot"
                                                                    runat="server"
                                                                    CssClass="table table-bordered request-table request-table-col "
                                                                    AutoGenerateColumns="false" OnRowDataBound="gvdata_RowDataBound"
                                                                    OnRowCommand="GridView_UnAllotted_plot_RowCommand">

                                                                    <Columns>




                                                                        <asp:BoundField HeaderText="Authority/Corporation" DataField="Authority/Corporation"></asp:BoundField>
                                                                        <asp:BoundField HeaderText="In Units" DataField="In Units"></asp:BoundField>
                                                                        <asp:BoundField HeaderText="In Acres" DataField="In Acres"></asp:BoundField>

                                                                        <asp:TemplateField HeaderText="">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton runat="server" ID="btnView" CssClass="fa fa-eye" aria-hidden="true" CommandName="ViewRow" CommandArgument='<%#Eval("Authority/Corporation") %>' ToolTip="Click here to View Request " />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                    </Columns>
                                                                </asp:GridView>

                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="table table-bordered request-table request-table-margetop">
                                                        <tr class="cm-table-heading">
                                                            <th colspan="3" class="text-center font-bold">
                                                                <b>List of UnAllotted Plots</b>
                                                            </th>
                                                        </tr>
                                                    </table>
                                                    <div style="height: 361px; overflow-y: auto;" class="table-responsive">
                                                        <asp:GridView ID="gridlistunallottedplot"
                                                            runat="server"
                                                            CssClass="table table-bordered request-table request-table-col cmtable-bg myreq-col"
                                                            AutoGenerateColumns="false" OnRowDataBound="gridlistunallottedplot_RowDataBound">
                                                            <Columns>

                                                                <asp:BoundField HeaderText="CorporationID" Visible="false" DataField="CorporationID"
                                                                    SortExpression="CorporationID"></asp:BoundField>

                                                                <asp:BoundField HeaderText="" DataField="CorporationName"></asp:BoundField>


                                                                <asp:TemplateField HeaderText="Location">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("RegionalOffice") %>' />
                                                                        (<asp:Label ID="Label2" runat="server" Text='<%#Eval("IANAME") %>' />)

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>



                                                                <%--											<asp:BoundField HeaderText="Location" DataField="RegionalOffice"
												SortExpression="RegionalOffice"></asp:BoundField>
											<asp:BoundField HeaderText="Industrial Area" DataField="IANAME"
												SortExpression="IANAME"></asp:BoundField>--%>


                                                                <asp:BoundField HeaderText="Plot No" DataField="PlotNumber"></asp:BoundField>

                                                                <asp:BoundField HeaderText="In SQMts." DataField="Area"
                                                                    SortExpression="Area"></asp:BoundField>

                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                No Record Available
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>


                                                </div>
                                            </div>
                                        </div>
                                        <hr style="margin-top: 6px; margin-bottom: 6px; border: 0; border-top: 2px solid #f5f5f5;" />
                                        <div class="row" style="border: 1px solid #ccc; margin: 0px 0;">
                                            <div class="panel-heading font-bold">
                                                PLOTS WHERE PRODUCTION NOT STARTED  <a href="IDAReport.aspx"><span class="pull-right"><i class="fa fa-arrows-alt">Detail View</i></span></a>  <span class="pull-right hide">
                                                    <asp:Label ID="sum_production_not_started" runat="server" />Acres</span>
                                            </div>
                                            <div class="col-md-8 col-sm-6 col-xs-12">
                                                <div id="container2" style="width: 100%; height: 500px;"></div>

                                            </div>
                                            <div class="col-md-4 col-sm-6 col-xs-12">
                                                <div style="margin: 5px 0;">
                                                    <table class="table table-bordered request-table request-table-margetop">
                                                        <tr class="cm-table-heading">
                                                            <th colspan="3" class="text-center font-bold">
                                                                <b>Total No of Plots where Production not started</b>
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="padding: 0px !important">
                                                                <asp:GridView ID="GridView_production_notstarted"
                                                                    runat="server"
                                                                    CssClass="table table-bordered request-table request-table-col"
                                                                    AutoGenerateColumns="false" OnRowDataBound="gvdata_RowDataBound"
                                                                    OnRowCommand="GridView_production_notstarted_RowCommand">


                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Authority/Corporation" DataField="Authority/Corporation"></asp:BoundField>
                                                                        <asp:BoundField HeaderText="In Units" DataField="In Units"></asp:BoundField>
                                                                        <asp:BoundField HeaderText="In Acres" DataField="In Acres"></asp:BoundField>

                                                                        <asp:TemplateField HeaderText="">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton runat="server" ID="btnView" CssClass="fa fa-eye" aria-hidden="true" CommandName="ViewRow" CommandArgument='<%#Eval("Authority/Corporation") %>' ToolTip="Click here to View Request " />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                    </Columns>
                                                                </asp:GridView>


                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="table table-bordered request-table request-table-margetop">
                                                        <tr class="cm-table-heading">
                                                            <th colspan="3" class="text-center font-bold">
                                                                <b>List of Companies whose production is not Started</b>
                                                            </th>
                                                        </tr>
                                                    </table>

                                                    <div style="height: 361px; overflow-y: auto" class="table-responsive">

                                                        <asp:GridView ID="grdProductionNotStarted"
                                                            runat="server"
                                                            CssClass="table table-bordered request-table request-table-col cmtable-bg myreq-col"
                                                            AutoGenerateColumns="false">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="CorporationID" Visible="false" DataField="CorporationID"
                                                                    SortExpression="CorporationID"></asp:BoundField>

                                                                <asp:BoundField HeaderText="" DataField="CorporationName"></asp:BoundField>


                                                                <asp:BoundField HeaderText="Location" DataField="IANAME"
                                                                    SortExpression="IANAME" Visible="true"></asp:BoundField>

                                                                <asp:BoundField HeaderText="Unit" DataField="Unit"
                                                                    SortExpression="Unit"></asp:BoundField>

                                                                <asp:BoundField HeaderText="Plot" DataField="PlotNumber"
                                                                    SortExpression="PlotNumber"></asp:BoundField>
                                                                <asp:BoundField HeaderText="In SQMts." DataField="TotalArea"
                                                                    SortExpression="TotalArea"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Allotted Date" DataField="AllotmentIssueDate"
                                                                    SortExpression="AllotmentIssueDate"></asp:BoundField>

                                                                <asp:BoundField HeaderText="Address" DataField="Address"
                                                                    SortExpression="Address"></asp:BoundField>
                                                                <asp:BoundField HeaderText="ContactNumber" DataField="ContactNumber"
                                                                    SortExpression="ContactNumber"></asp:BoundField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                No Record Available
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>

                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <hr style="margin-top: 6px; margin-bottom: 6px; border: 0; border-top: 2px solid #f5f5f5;" />
                                        <div class="row" style="border: 1px solid #ccc; margin: 0px 0;">
                                            <div class="panel-heading font-bold">
                                                SICK UNITS/UNITS WHERE PRODUCTION STOPPED    <a href="IDAReport.aspx"><span class="pull-right"><i class="fa fa-arrows-alt">Detail View</i></span></a>  <span class="pull-right hide">
                                                    <asp:Label ID="sum_sick_unit" runat="server" />Acres</span>
                                            </div>
                                            <div class="col-md-8 col-sm-6 col-xs-12">
                                                <div id="container3" style="width: 100%; height: 500px;"></div>
                                            </div>
                                            <div class="col-md-4 col-sm-6 col-xs-12">
                                                <div style="margin: 5px 0;">
                                                    <table class="table table-bordered request-table request-table-margetop">
                                                        <tr class="cm-table-heading">
                                                            <th colspan="3" class="text-center font-bold">
                                                                <b>Total No of Sick Unit / Production stopped</b>
                                                            </th>
                                                        </tr>

                                                        <tr>
                                                            <td colspan="3" style="padding: 0px !important">
                                                                <asp:GridView ID="GridView_sickunit"
                                                                    runat="server"
                                                                    CssClass="table table-bordered request-table request-table-col"
                                                                    AutoGenerateColumns="false" OnRowDataBound="gvdata_RowDataBound"
                                                                    OnRowCommand="GridView_sickunit_RowCommand">


                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Authority/Corporation" DataField="Authority/Corporation"></asp:BoundField>
                                                                        <asp:BoundField HeaderText="In Units" DataField="In Units"></asp:BoundField>
                                                                        <asp:BoundField HeaderText="In Acres" DataField="In Acres"></asp:BoundField>

                                                                        <asp:TemplateField HeaderText="">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton runat="server" ID="btnView" CssClass="fa fa-eye" aria-hidden="true" CommandName="ViewRow" CommandArgument='<%#Eval("Authority/Corporation") %>' ToolTip="Click here to View Request " />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                    </Columns>
                                                                </asp:GridView>





                                                            </td>
                                                        </tr>

                                                    </table>
                                                    <table class="table table-bordered request-table request-table-margetop">
                                                        <tr class="cm-table-heading">
                                                            <th colspan="3" class="text-center font-bold">
                                                                <b>List of Sick Units</b>
                                                            </th>
                                                        </tr>
                                                    </table>
                                                    <div style="height: 361px; overflow-y: auto;" class="table-responsive">

                                                        <asp:GridView ID="grdSickUnits"
                                                            runat="server"
                                                            CssClass="table table-bordered request-table request-table-col cmtable-bg myreq-col"
                                                            AutoGenerateColumns="false" OnRowDataBound="grdSickUnits_RowDataBound">
                                                            <Columns>

                                                                <asp:BoundField HeaderText="CorporationID" Visible="false" DataField="CorporationID"
                                                                    SortExpression="CorporationID"></asp:BoundField>

                                                                <asp:BoundField HeaderText="" DataField="CorporationName"></asp:BoundField>



                                                                <asp:BoundField HeaderText="Location" DataField="IANAME"
                                                                    SortExpression="IANAME" Visible="true"></asp:BoundField>


                                                                <asp:BoundField HeaderText="Unit" DataField="Unit"
                                                                    SortExpression="Unit"></asp:BoundField>

                                                                <asp:BoundField HeaderText="Plot" DataField="PlotNumber"
                                                                    SortExpression="PlotNumber"></asp:BoundField>
                                                                <asp:BoundField HeaderText="In SQMts." DataField="TotalArea"
                                                                    SortExpression="TotalArea"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Allotted Date" DataField="AllotmentIssueDate"
                                                                    SortExpression="AllotmentIssueDate"></asp:BoundField>

                                                                <asp:BoundField HeaderText="Address" DataField="Address"
                                                                    SortExpression="Address"></asp:BoundField>
                                                                <asp:BoundField HeaderText="ContactNumber" DataField="ContactNumber"
                                                                    SortExpression="ContactNumber"></asp:BoundField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                No Record Available
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                        <div class="clearfix"></div>
                                        <hr style="margin-top: 6px; margin-bottom: 6px; border: 0; border-top: 2px solid #f5f5f5;" />
                                        <div class="panel panel-default">

                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-xs-12">
                                                    <div class="panel-heading">
                                                        <div class="col-md-8 col-sm-4 col-xs-12">
                                                            <h4 class="panel-title" style="margin-top: 7px; font-size: 13px;">
                                                                <b>UPCOMING SCHEMES</b>
                                                            </h4>
                                                        </div>
                                                        <div class="col-md-4 col-sm-8 col-xs-12 input-group">


                                                            <asp:DropDownList ID="ddlAuthority" runat="server" Width="100%" Style="height: 25px; padding: 1px 10px;" OnSelectedIndexChanged="ddlAuthority_SelectedIndexChanged" AutoPostBack="true" CssClass="input-sm dropdown-toggle similar-select1"></asp:DropDownList>



                                                            <%--  <asp:TextBox id="txtsearch" runat="server" Width="100%" CssClass="input-sm" OnTextChanged="txtsearch_TextChanged"    AutoPostBack="true"></asp:TextBox>--%>
                                                            <span class="input-group-btn">
                                                                <button class="btn btn-sm btn-primary" type="button" style="margin-bottom: 0; padding: 2px 9px;"><i class="fa fa-search" style="padding: 2px 0; color: #fff;"></i></button>
                                                            </span>
                                                        </div>
                                                        <div class="clearfix"></div>

                                                    </div>
                                                </div>
                                            </div>
                                            <div id="menuFore" class="panel-collapse collapse in">
                                                <div class="panel-body row">
                                                    <%-- OnRowDataBound="OnRowDataBound"--%>
                                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                                        <div style="overflow-x: auto; overflow-y: auto; min-height: 500px; max-height: 500px;">
                                                            <div class="">
                                                                <asp:GridView ID="Allottee_master_grid"
                                                                    runat="server" ShowFooter="true"
                                                                    PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"
                                                                    CssClass="table table-bordered request-table request-table-col cmtable-bg myreq-col"
                                                                    AutoGenerateColumns="false" Width="1600px">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Corporation/Authority" HeaderStyle-HorizontalAlign="Center" HeaderText=" Corp." ItemStyle-Width="4%" />
                                                                        <asp:TemplateField HeaderText="Name of Scheme" SortExpression="NameofScheme">
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink ID="LbPath" runat="server" Target="_blank"
                                                                                    Text='<%# Eval("NameofScheme") %>'
                                                                                    NavigateUrl='<%#Bind("WebURL") %>'>
                                                                                </asp:HyperLink>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="NumberofArea" HeaderStyle-HorizontalAlign="Center" HeaderText=" Scheme Description" ItemStyle-Width="25%" />
                                                                        <asp:BoundField DataField="SponsorAgency" HeaderStyle-HorizontalAlign="Center" HeaderText="Sponsor/Agency" ItemStyle-Width="6%" />
                                                                        <asp:BoundField DataField="Location" HeaderStyle-HorizontalAlign="Center" HeaderText="Location" ItemStyle-Width="9%" />
                                                                        <asp:BoundField DataField="Developed" HeaderStyle-HorizontalAlign="Center" HeaderText="Place where area are to be developed" ItemStyle-Width="18%" />
                                                                        <asp:BoundField DataField="TotalArea" HeaderStyle-HorizontalAlign="Center" HeaderText="Total Area to be Developered (In Acres)" />
                                                                        <asp:BoundField DataField="LandStatus" HeaderStyle-HorizontalAlign="Center" HeaderText="Current Status" ItemStyle-Width="13%" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!--<div class="col-md-4 col-sm-12 col-xs-12">                                                        
                                                        <iframe class="projectmgt-iframe" src="htm/graph.htm" width="100%" height="450"></iframe>
                                                    </div>-->

                                                </div>

                                            </div>
                                        </div>
                                        <!-- start right side bar-->
                                        <div class="col-md-9"></div>
                                        <!-- end right side bar-->

                                        <!--strart left side bar-->
                                        <div class="col-md-3">
                                        </div>
                                        <!--end left side bar-->
                                    </div>
                                    <!-- middle page content section-->

                                </div>
                                <!-- container page end div-->
                            </div>
                        </div>
                    </div>
                </div>
            </div>








        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
    <asp:Literal ID="Literal3" runat="server"></asp:Literal>
    <asp:Literal ID="Literal4" runat="server"></asp:Literal>

    <asp:Literal ID="Literal5" runat="server"></asp:Literal>
    <asp:Literal ID="Literal6" runat="server"></asp:Literal>
    <asp:Literal ID="Literal7" runat="server"></asp:Literal>
    <asp:Literal ID="Literal8" runat="server"></asp:Literal>


</asp:Content>
