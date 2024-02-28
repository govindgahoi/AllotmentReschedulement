<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="CMDashboardReportTest.aspx.cs" Inherits="Allotment.CMDashboardReportTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
   
    
<%@ Register assembly="ProudMonkey.Common.Controls" namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %>


    <style>
        .myreq-col tr td {
            
        }
        td a {
    color: #337ab7 !important;
    font-weight: bold !important;
}

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

        .Center{
            text-align:center !important;
        }

            .request-cell-width tr td {
                /*border-bottom: 1px solid #949090 !important;*/
            }

        .request-cell-width1 tr td {
            /*border-bottom: 1px solid #949090 !important;*/
        }

        .myreq-col tr td {
            font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #c1c1c1 !important;
    text-align: left;
    font-weight: 600;
    background: #e0e0e0;
    padding: 1.5px 6px !important;
        }

        .myreq-col tr th {
            font-size: 12px;
        }

        .myreq-col tr td a {
            color: #000000;
            font-weight: 600;
        }
        table.myreq-col tr td table tr th {
            background:#ffc717 !important; 
        }
        table.myreq-col tr td table tr td table tr th {
            background:#bdbdbd !important; 
        }
        table.myreq-col tr td table tr td table tr td table tr th {
                background:#dadada !important;
        }
        table.myreq-col tr td table tr td {
            background:#efefef !important; 
        }
        
    </style>

    <style>
        .content {
            background: #e2e2e2;
        }

        .bg-mywhite {
            background: #fff;
        }

        .performance-textdiv {
            min-height: 111px;
            margin-top: 20px;
            padding: 0px 0 0 7px;
            font-weight: 500;
            color: #636262;
        }

        .pmt-text-color {
            color: #fd8e0e;
        }

        .performance-textdiv p.pmt-text {
            font-size: 34px;
            margin-bottom: 4px;
            margin-top: 20px;
            line-height: 1;
            padding-top: 3px;
        }

            .performance-textdiv p.pmt-text sup {
                font-size: 10px;
                top: -20px;
            }

        .performance-textdiv p.act-track-text {
            font-size: 11.3px;
        }

        .grid-div {
            min-height: 226px;
            margin-top: 20px;
        }

        .three-div6in {
            min-height: 99px;
            margin-top: 10px;
        }

        .div6-right {
            min-height: 230px;
            margin-top: 20px;
        }

            .div6-right div.announcemnt {
                color: red;
                font-weight: 500;
            }

        .six-div {
            min-height: 133px;
            margin-top: 20px;
        }

        .my-heading {
            background: #f5f5f5;
            padding: 0 5px;
            font-weight: 700;
        }

        .six-div-ul {
            margin: 0 10px;
        }

            .six-div-ul li {
                font-size: 13px;
                border-bottom: 1px solid #e8e8e8;
            }

        .current-open-color {
            color: #c59500;
        }

        .pmt-text-color-green {
            color: #28a500;
        }

        .pmt-text-color-yellow {
            color: #fd8e0e;
        }

        .pmt-text-color-red {
            color: red;
            font-weight: 800;
        }

        iframe {
            border: 0px solid #ccc;
        }

        .dash-status span {
            font-size: 42px;
        }

        .dash-status-inr span {
            font-size: 25px;
            color: #006d04;
            font-weight: 600;
        }

            .dash-status-inr span i {
                color: #006d04;
            }

        .three-div6in .dash-cost-text {
            margin-top: 9px;
        }

        .my-dash-table-status tr th {
            text-align: center;
            font-weight: 700;
            border-right: 3px solid #ccc !important;
        }

        .my-dash-table-status tr td {
            text-align: center;
            font-weight: 700;
            border-right: 3px solid #ccc !important;
        }

            .my-dash-table-status tr td:nth-child(1) {
                text-align: left;
                position: absolute;
                width: 13em;
                left: 28px;
            }

        .my-dash-table-status tr th:nth-child(1) {
            text-align: left;
            position: absolute;
            width: 13em;
            left: 28px;
        }

        .table-divinbox {
            margin-top: 20px;
            padding: 20px;
        }

            .table-divinbox table tr th {
                font-size: 12px;
                font-weight: 700;
            }

        .iadsashboard-dayul-inbox {
            margin: 7px 7px 10px 0;
            padding: 3px 0;
        }

            .iadsashboard-dayul-inbox li {
                padding-left: 5px;
                padding-right: 5px;
                background: #ffc511;
                text-align: center;
                /* width: 127px; */
                height: 21px;
                font-size: 12px;
                font-weight: 600;
                box-shadow: 7px 0 16px #ccc;
                color: #000000;
                border: 1px solid #8e8e8e;
            }
    </style>

    <!--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>-->
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "images/plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>






</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
        <ContentTemplate>

      <cc1:MessageBox ID="MessageBox1" runat="server" /> 
                     <cc1:ConfirmBox ID="ConfirmBox1" runat="server" />  

            <div class="bg-mywhite table-divinbox table border_none request-table-col">
                <div class="panel panel-default" >
                    <div class="panel-heading font-bold text-center" style="font-size:19px !important;">
                       Status Report For Land Allotment
                    </div>
                </div>
                                            
                <div style="overflow-x: auto; overflow-y: auto; max-height: 1100px;">
                    <div class="col-md-12" style="padding: 0px;">
                        <asp:GridView ID="GridView2" runat="server"
                            CssClass="table table-striped table-bordered table-hover request-table myreq-col"                         
                            AllowSorting="True"
                            AutoGenerateColumns="False"
                            GridLines="Horizontal"  OnRowDataBound="GridView2_RowDataBound" OnDataBound="GridView2_DataBound"
                            Width="100%"
                            ItemStyle-Width="10%">
                            <Columns>                                        

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Style="cursor: pointer" ImageUrl="~/images/plus.png" />                                
                                        <asp:Panel ID="pnlAllotmentRequest" runat="server" Style="display: none">
                                            <asp:GridView ID="GridLevel1" runat="server" DataKeyNames="RegionalOffice" AutoGenerateColumns="False" CssClass="request-table table table-hover table-bordered cm-table-heading myreq-col" OnRowDataBound="GridLevel1_RowDataBound" OnDataBound="GridLevel1_DataBound" >
                                                <Columns>
                                                     <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Style="cursor: pointer" ImageUrl="~/images/plus.png" />                                
                                        <asp:Panel ID="pnlLevel2" runat="server" Style="display: none">
                                             <asp:GridView ID="GridLevel2" runat="server" DataKeyNames="Id" AutoGenerateColumns="False" CssClass="request-table table table-hover table-bordered cm-table-heading myreq-col" OnRowDataBound="GridLevel2_RowDataBound" OnDataBound="GridLevel2_DataBound" >
                                                <Columns>
                                   <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Style="cursor: pointer" ImageUrl="~/images/plus.png" />                                
                                        <asp:Panel ID="pnlLevel3" runat="server" Style="display: none">
                                     <asp:GridView ID="GridLevel3" runat="server"  AutoGenerateColumns="False" OnDataBound="GridLevel3_DataBound" CssClass="request-table table table-hover table-bordered cm-table-heading myreq-col"  >
                                                <Columns>
                                                   <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                                                 
                                                    <asp:BoundField DataField="ApplicationId"       HeaderText="ApplicationId"   SortExpression="ApplicationId" />
                                <asp:BoundField DataField="AllotmentStatus" ItemStyle-Wrap="false"  HeaderText="Status" SortExpression="TotalCompleted" />
                                <asp:BoundField DataField="AllotmentDays" ItemStyle-Wrap="false"  HeaderText="In Days"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="AccountsStatus" ItemStyle-Wrap="false"  HeaderText="Status" SortExpression="TotalCompleted" />
                                <asp:BoundField DataField="AccountDays" ItemStyle-Wrap="false"  HeaderText="In Days"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="VerifierStatus" ItemStyle-Wrap="false"  HeaderText="Status"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="DataVerifierDays" ItemStyle-Wrap="false"  HeaderText="In Days"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="RMStatus" ItemStyle-Wrap="false"  HeaderText="Status"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="RMDays" ItemStyle-Wrap="false"  HeaderText="In Days"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="CMIAStatus" ItemStyle-Wrap="false"  HeaderText="Status"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="CMIADays" ItemStyle-Wrap="false"  HeaderText="In Days"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="MDStatus" ItemStyle-Wrap="false"  HeaderText="Status"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="MDDays" ItemStyle-Wrap="false"  HeaderText="In Days"  SortExpression="TotalPending" />
                                                      </Columns>
                                      </asp:GridView>                                                    
                                               
                                      </asp:Panel>
                                      </ItemTemplate>
                                      </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                   

                                                    <asp:BoundField DataField="IAName"   HeaderText="IAName"  SortExpression="IAName" />
                                                    <asp:BoundField DataField="TotalWithinSLA" ItemStyle-Wrap="false" HeaderText="Process Within SLA" SortExpression="TotalApplication" />
                                <asp:BoundField DataField="TotalOutSideSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA" SortExpression="TotalCompleted" />
                                <asp:BoundField DataField="TotalInsideSLAPending" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />

                                <asp:BoundField DataField="TotalOutSideSLAPending" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="AccountsProcessWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="AccountsProcessBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="AccountsPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="AccountsPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="VerifierProcessWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="VerifierProcessBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="VerifierPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="VerifierPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="RMProcessWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="RMProcessBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="RMPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="RMPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="CMIAProcessWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="CMIAProcessBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="CMIAPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="CMIAPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="MDProcessWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="MDProcessBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="MDPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="MDPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="LetterIssuedWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="LetterIssuedBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="LetterPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="LetterPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
       </Columns></asp:GridView>
                                            </asp:Panel>

                                            </ItemTemplate></asp:TemplateField>


                                                    <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    


                                                    <asp:BoundField DataField="RegionalOffice"   HeaderText="RegionalOffice"  SortExpression="RegionalOffice" />
                                                 <asp:BoundField DataField="TotalWithinSLA" ItemStyle-Wrap="false" HeaderText="Process Within SLA" SortExpression="TotalApplication" />
                                <asp:BoundField DataField="TotalOutSideSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA" SortExpression="TotalCompleted" />
                                <asp:BoundField DataField="TotalInsideSLAPending" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />

                                <asp:BoundField DataField="TotalOutSideSLAPending" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="AccountsProcessWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="AccountsProcessBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="AccountsPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="AccountsPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="VerifierProcessWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="VerifierProcessBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="VerifierPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="VerifierPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="RMProcessWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="RMProcessBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="RMPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="RMPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="CMIAProcessWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="CMIAProcessBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="CMIAPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="CMIAPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="MDProcessWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="MDProcessBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="MDPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="MDPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="LetterIssuedWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="LetterIssuedBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="LetterPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="LetterPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />

                                                </Columns>
                                            </asp:GridView>

                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                  <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                <asp:BoundField DataField="Authority" HeaderText="Authority"  SortExpression="Authority" />
                                <asp:BoundField DataField="TotalWithinSLA" ItemStyle-Wrap="false" HeaderText="Process Within SLA" SortExpression="TotalApplication" />
                                <asp:BoundField DataField="TotalOutSideSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA" SortExpression="TotalCompleted" />
                                <asp:BoundField DataField="TotalInsideSLAPending" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />

                                <asp:BoundField DataField="TotalOutSideSLAPending" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="AccountsProcessWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="AccountsProcessBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="AccountsPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="AccountsPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="VerifierProcessWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="VerifierProcessBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="VerifierPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="VerifierPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="RMProcessWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="RMProcessBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="RMPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="RMPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="CMIAProcessWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="CMIAProcessBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="CMIAPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="CMIAPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="MDProcessWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="MDProcessBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="MDPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="MDPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="LetterIssuedWithinSLA" ItemStyle-Wrap="false"  HeaderText="Process Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="LetterIssuedBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Process Beyond SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="LetterPendingWithinSLA" ItemStyle-Wrap="false"  HeaderText="Pending Within SLA"  SortExpression="TotalPending" />
                                <asp:BoundField DataField="LetterPendingBeyondSLA" ItemStyle-Wrap="false"  HeaderText="Pending Beyond SLA"  SortExpression="TotalPending" />

                              
                         
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>


                    </div>

                </div>
                <div class="clearfix"></div>

                <br />
                <asp:Label runat="server" ID="msg"></asp:Label>
                </div>            

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
