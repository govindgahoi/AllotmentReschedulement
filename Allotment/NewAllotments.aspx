<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="NewAllotments.aspx.cs" Inherits="Allotment.NewAllotments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
   
    
<%@ Register assembly="ProudMonkey.Common.Controls" namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %>


    <style>
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



            .request-cell-width tr td {
                /*border-bottom: 1px solid #949090 !important;*/
            }

        .request-cell-width1 tr td {
            /*border-bottom: 1px solid #949090 !important;*/
        }

        .myreq-col tr td {
            font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
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
            background:#ffd34a !important; 
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


            <div class="row">
                <div class="col-md-6 col-sm-12 col-xs-12">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="bg-mywhite performance-textdiv">
                                <p class="pmt-text pmt-text-color">Industrial Area Activity Tracker</p>
                                <p class="act-track-text">Track & Monitor activities across UPSIDC business processs</p>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="row">
                        <div class="col-md-4 col-sm-4 col-xs-12">
                            <div class="bg-mywhite three-div6in">
                                <div class="my-heading font-bold"></div>
                            </div>
                        </div>
                        <div class="col-md-4 text-center col-sm-4 col-xs-12">
                            <div class="bg-mywhite three-div6in" style="padding-top: 15px;">
                                <div class="dash-status-inr"><span><i class="fa fa-inr"></i>0.00</span></div>
                                <div class="dash-cost-text"><b>Expected Revenue</b></div>
                            </div>
                        </div>
                        <div class="col-md-4 text-center col-sm-4 col-xs-12">
                            <div class="bg-mywhite three-div6in dash-status">
                                <span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span>
                                <div class="dash-status-text"><b>Status</b></div>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="col-md-6 col-sm-12 col-xs-12">
                    <div class="div6-right bg-mywhite">
                        <div class="red announcemnt my-heading">Alerts -</div>



                        <%--    <asp:BoundField  ItemStyle-BorderWidth="0" DataField="ALERTMESSAGE" />  --%>



                        <asp:GridView ID="grid_Announcement_List" CssClass="table table-bordered table-hover request-table myreq-col" runat="server" ShowHeader="false" AutoGenerateColumns="false" BorderWidth="0">
                            <Columns>


                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDetails" runat="server" Text='<%# Eval("ALERTMESSAGE") %>' PostBackUrl='<%# "~/Evaluation.aspx?IAID="+ Eval("IAID")+"&ServicesId="+ Eval("ALERTMESSAGE")  %>'>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>



                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
           


            <div class="bg-mywhite table-divinbox table border_none request-table-col">
                <div class="panel panel-default">
                    <div class="panel-heading font-bold">
                        New Application - (Pending At You)
                    </div>
                </div>

<%--                       <asp:BoundField DataField="ServiceRequestNO" HeaderText="ReQ#" HeaderStyle-CssClass="text-center-imp" SortExpression="ServiceRequestNO"  ItemStyle-Width="8%"/>
                                             --%>
                <div style="overflow-x: auto; overflow-y: auto; max-height: 390px;">
                    <div class="col-md-12" style="padding: 0px;">
                        <asp:GridView ID="GridView2" runat="server"
                            CssClass="table table-striped table-bordered table-hover request-table myreq-col "
                            AllowPaging="True"
                            AllowSorting="True"
                            AutoGenerateColumns="False"
                            DataKeyNames="IAID"
                            GridLines="Horizontal" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="20"
                            OnRowDataBound="GridView2_RowDataBound"
                            OnRowCommand="GridView2_RowCommand"
                            Width="100%" OnSorting="GridView2_Sorting"
                            ItemStyle-Width="10%"
                            OnRowDeleting="GridView2_RowDeleting">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Style="cursor: pointer" ImageUrl="~/images/plus.png" />
                                
                                        <asp:Panel ID="pnlAllotmentRequest" runat="server" Style="display: none">


                                            <asp:GridView ID="GridViewAllotmentRequest" runat="server" AutoGenerateColumns="False" CssClass="request-table table table-hover table-bordered cm-table-heading myreq-col">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="ReQ.#" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink Text='<%# Eval("ServiceRequestNO") %>' runat="server" NavigateUrl='<%# String.Format("Evaluation.aspx?ServicesId={0} &IAID={1}", Eval("ServiceRequestNO"), Eval("IndustrialArea")) %>'>
                                                            </asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                      <asp:TemplateField HeaderText="ReQ#">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/Assessment.aspx?ServiceReqNo={0}",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>' Text='<%# Eval("ServiceRequestNO").ToString()%>'> </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                        


                                                    <asp:BoundField DataField="IAID" HeaderText="IndustrialArea" Visible="false" SortExpression="IAID" />
                                                    <asp:BoundField DataField="APPLICANTNAME" ItemStyle-Wrap="false" HeaderStyle-CssClass="text-center-imp" Visible="True" HeaderText="Applicant" SortExpression="APPLICANTNAME" ItemStyle-Width="6%"/>
                                                      <asp:BoundField DataField="Preference1" HeaderText="Plot Preference1" HeaderStyle-CssClass="text-center-imp" Visible="True"  SortExpression="Preference1" ItemStyle-Width="6%" />
                                                    <asp:BoundField DataField="Preference2" HeaderText="Plot Preference2" HeaderStyle-CssClass="text-center-imp" Visible="True"  SortExpression="Preference2" ItemStyle-Width="6%" />
                                                    <asp:BoundField DataField="Preference3" HeaderText="Plot Preference3" HeaderStyle-CssClass="text-center-imp" Visible="True"  SortExpression="Preference3" ItemStyle-Width="6%" />
                                                    <asp:BoundField DataField="RequestedDate" ItemStyle-Wrap="false" DataFormatString="{0:dd-M-yyyy}" HeaderStyle-CssClass="text-center-imp" HeaderText="Requested Date" SortExpression="RequestedDate" ItemStyle-Width="5%"/>
                                                    <asp:BoundField DataField="STATUS" ItemStyle-Wrap="false" HeaderText="Current Status" Visible="false" SortExpression="STATUS" />
                                                    <asp:TemplateField HeaderText="Accounts Clearance" SortExpression="IsAccountClear" HeaderStyle-CssClass="text-center-imp" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="IsAccountClear" runat="server" Value='<%# Eval("IsAccountClear").ToString().ToLower()%>' />
                                                            <asp:HiddenField ID="IsDataVerified" runat="server" Value='<%# Eval("IsDataVerified").ToString().ToLower()%>' />
                                                            <asp:HiddenField ID="IsDataReviewed" runat="server" Value='<%# Eval("IsDataReviewed").ToString().ToLower()%>' />

                                                            <asp:Label ID="IsAccountCleartrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsAccountClear").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="IsAccountClearfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsAccountClear").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Data Verified" SortExpression="IsDataVerified" HeaderStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="IsDataVerifiedtrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsDataVerified").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="IsDataVerifiedfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsDataVerified").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                               

                                                    <asp:TemplateField HeaderText="Data Approved" SortExpression="IsDataApproved" HeaderStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="isdatatapprovedtrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsDataApproved").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="isdataapprovedfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsDataApproved").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="CMIA Approved" SortExpression="IsDataReviewed" HeaderStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="IsDataReviewedtrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsDataReviewed").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="IsDataReviewedfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsDataReviewed").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="MD Approved" SortExpression="IsFinalApproved" HeaderStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="isfinaltrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsFinalApproved").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="isfinalfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsFinalApproved").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>

                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:BoundField DataField="IAID" HeaderText="IndustrialArea" Visible="false" SortExpression="IAID" />


                                <asp:BoundField DataField="IANAME" ItemStyle-Wrap="false" Visible="True" HeaderText="Concerned IndustrialArea" SortExpression="IANAME" />
                                <asp:BoundField DataField="WEEKSTARTDATE" ItemStyle-Wrap="false" Visible="True" HeaderText="Week Start" DataFormatString="{0:dd-M-yyyy}" SortExpression="WEEKSTARTDATE" />
                                <asp:BoundField DataField="WEEKENDDATE" ItemStyle-Wrap="false" Visible="True" HeaderText="Week End" DataFormatString="{0:dd-M-yyyy}" SortExpression="WEEKENDDATE" />
                                <asp:BoundField DataField="NOOFREQUEST" HeaderText="No of Application" SortExpression="NOOFREQUEST" />
                                <asp:BoundField DataField="CURRENTSTATUS" HeaderText="Current Status" SortExpression="CURRENTSTATUS" />
                                 <asp:TemplateField HeaderText="">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtrequest" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="drpdnRaiseReQ" AutoPostBack="true" runat="server" OnSelectedIndexChanged="drpdnRaiseReQ_IndexChanged" Width="100px">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
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


                <div class="panel panel-default">
                    <div class="panel-heading font-bold">
                        In Process
                    </div>


                    <div class="col-md-12" style="padding: 0px;max-height:390px;overflow-y:auto;">
                   


                          <asp:GridView ID="GridViewInProcess" runat="server"
                            CssClass="table table-striped table-bordered table-hover request-table request-table myreq-col"
                            AllowPaging="True"
                            AllowSorting="True"
                            AutoGenerateColumns="False"
                            DataKeyNames="IAID,PacketID"
                            GridLines="Horizontal"  PageSize="20"
                            OnRowDataBound="GridViewInProcess_RowDataBound"
                            Width="100%" 
                            ItemStyle-Width="10%"
                           >


                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Style="cursor: pointer" ImageUrl="~/images/plus.png" />
                                        <asp:Panel ID="pnlAllotmentRequest" runat="server" Style="display: none">


                                            <asp:GridView ID="GridViewAllotmentRequestInProcess" runat="server" AutoGenerateColumns="False" CssClass="request-table table table-hover table-bordered myreq-col">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                        
                                                    <asp:BoundField DataField="ServiceRequestNO" HeaderText="ReQ#" HeaderStyle-CssClass="text-center-imp" SortExpression="ServiceRequestNO" ItemStyle-Width="7%" />
                                                    <asp:BoundField DataField="IAID" HeaderText="IndustrialArea" Visible="false" HeaderStyle-CssClass="text-center-imp" SortExpression="IAID" ItemStyle-Width="6%" />
                                                    <asp:BoundField DataField="APPLICANTNAME" ItemStyle-Wrap="false" Visible="True" HeaderStyle-CssClass="text-center-imp" HeaderText="Applicant" SortExpression="APPLICANTNAME" ItemStyle-Width="5%"/>
                                                   <asp:BoundField DataField="Preference1" HeaderText="Plot Preference1" HeaderStyle-CssClass="text-center-imp" Visible="True"  SortExpression="Preference1" ItemStyle-Width="6%" />
                                                    <asp:BoundField DataField="Preference2" HeaderText="Plot Preference2" HeaderStyle-CssClass="text-center-imp" Visible="True"  SortExpression="Preference2" ItemStyle-Width="6%" />
                                                    <asp:BoundField DataField="Preference3" HeaderText="Plot Preference3" HeaderStyle-CssClass="text-center-imp" Visible="True"  SortExpression="Preference3" ItemStyle-Width="6%" />
                                                    <asp:BoundField DataField="RequestedDate" ItemStyle-Wrap="false" HeaderStyle-CssClass="text-center-imp" DataFormatString="{0:dd-M-yyyy}" HeaderText="Requested Date" SortExpression="RequestedDate" ItemStyle-Width="8%" />
                                                    <asp:BoundField DataField="STATUS" ItemStyle-Wrap="false" HeaderText="Current Status" Visible="false" SortExpression="STATUS" />
                                                    <asp:TemplateField HeaderText="Accounts Clearance" SortExpression="IsAccountClear" HeaderStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="IsAccountClear" runat="server" Value='<%# Eval("IsAccountClear").ToString().ToLower()%>' />
                                                            <asp:HiddenField ID="IsDataVerified" runat="server" Value='<%# Eval("IsDataVerified").ToString().ToLower()%>' />
                                                            <asp:HiddenField ID="IsDataReviewed" runat="server" Value='<%# Eval("IsDataReviewed").ToString().ToLower()%>' />

                                                            <asp:Label ID="IsAccountCleartrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsAccountClear").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="IsAccountClearfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsAccountClear").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Data Verified" SortExpression="IsDataVerified" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center-imp" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="IsDataVerifiedtrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsDataVerified").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="IsDataVerifiedfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsDataVerified").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                  

                                                    <asp:TemplateField HeaderText="Data Approved" SortExpression="IsDataApproved" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center-imp" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="isdatatapprovedtrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsDataApproved").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="isdataapprovedfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsDataApproved").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="CMIA Approved" SortExpression="IsDataReviewed" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center-imp" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="IsDataReviewedtrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsDataReviewed").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="IsDataReviewedfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsDataReviewed").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="MD Approved" SortExpression="IsFinalApproved" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp"  HeaderStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="isfinaltrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsFinalApproved").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="isfinalfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsFinalApproved").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                       <asp:BoundField DataField="PacketID" HeaderText="Packet" ItemStyle-Width="3%" SortExpression="PacketID" />

                                                </Columns>
                                            </asp:GridView>


                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:BoundField DataField="PacketID" HeaderText="Packet#" SortExpression="PacketID" />
                                <asp:BoundField DataField="IAID" HeaderText="IndustrialArea" Visible="true" SortExpression="IAID" />
                                <asp:TemplateField HeaderText="Concerned IndustrialArea">
                                <ItemTemplate>
                                    <asp:HyperLink Text='<%# Eval("IANAME") %>' runat="server" NavigateUrl='<%# String.Format("Evaluation.aspx?PacketID={0} &IAID={1}", Eval("PacketID"), Eval("IAID")) %>'>
                                    </asp:HyperLink>
                                </ItemTemplate>
                                     </asp:TemplateField>
                            

                                <asp:BoundField DataField="WEEKSTARTDATE" ItemStyle-Wrap="false" Visible="True" HeaderText="Week Start" DataFormatString="{0:dd-M-yyyy}" SortExpression="WEEKSTARTDATE" />
                                <asp:BoundField DataField="WEEKENDDATE" ItemStyle-Wrap="false" Visible="True" HeaderText="Week End" DataFormatString="{0:dd-M-yyyy}" SortExpression="WEEKENDDATE" />
                                <asp:BoundField DataField="NOOFREQUEST" HeaderText="No of Application" SortExpression="NOOFREQUEST" />
                                <asp:BoundField DataField="CURRENTSTATUS" HeaderText="Current Status" SortExpression="CURRENTSTATUS" />
                               
                                 <asp:TemplateField HeaderText="">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtrequest" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField runat="server" ID="PacketId" Value='<%#Eval("PacketID") %>' />
                        
                                        <asp:DropDownList ID="drpdnRaiseReQInprocess" AutoPostBack="true" runat="server" OnSelectedIndexChanged="drpdnRaiseReQInprocess_IndexChanged" Width="100px">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                            <PagerStyle  BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle  ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>


                    </div>
                </div>

                <div class="clearfix"></div>

                <div class="panel panel-default" style="display:none;">
                    <div class="panel-heading font-bold">
                        Completed
                <div class="col-md-12" style="padding: 0px">
                    <asp:GridView ID="GridViewcompleted" runat="server"
                        CssClass="table table-striped table-bordered table-hover request-table request-table"
                        AllowPaging="True"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                        DataKeyNames="ServiceRequestNO"
                        GridLines="Horizontal"
                        Width="100%" OnRowDataBound="GridViewcompleted_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" Style="cursor: pointer" ImageUrl="~/images/plus.png" />
                                    <asp:Panel ID="pnlTicket" runat="server" Style="display: none">
                                        <asp:GridView ID="TicketGrid" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField ItemStyle-Width="150px" DataField="PacketRespondentID" HeaderText="PacketRespondentID" />
                                                <asp:BoundField ItemStyle-Width="150px" DataField="PACKETDESCRIPTION" HeaderText="PACKETDESCRIPTION" />
                                                <asp:BoundField ItemStyle-Width="150px" DataField="TicketCreationDate" HeaderText="TicketCreationDate" />
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ReQ.#" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink Text='<%# Eval("ServiceRequestNO") %>' runat="server" NavigateUrl='<%# String.Format("Evaluation.aspx?ServicesId={0} &IAID={1}", Eval("ServiceRequestNO"), Eval("IndustrialArea")) %>'>
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IndustrialArea" HeaderText="IndustrialArea" Visible="false" SortExpression="IndustrialArea" />
                            <asp:BoundField DataField="IndustrialAreaName" ItemStyle-Wrap="false" Visible="True" HeaderText="Concerned IndustrialArea" SortExpression="IndustrialAreaName" />
                            <asp:BoundField DataField="PacketID" HeaderText="PacketID" Visible="false" SortExpression="PacketID" />
                            <asp:BoundField DataField="ALlotteeName" ItemStyle-Wrap="false" Visible="True" HeaderText="Requested by" SortExpression="ALlotteeName" />
                            <asp:BoundField DataField="CASETYPE" Visible="true" HeaderText="Application For" SortExpression="CASETYPE" />
                            <asp:BoundField DataField="RequestedDate" ItemStyle-Wrap="false" DataFormatString="{0:dd-M-yyyy}" HeaderText="Requested Date" SortExpression="RequestedDate" />
                            <asp:BoundField DataField="STATUS" ItemStyle-Wrap="false" HeaderText="Current Status" Visible="false" SortExpression="STATUS" />
                            <asp:TemplateField HeaderText="Accounts Clearence" SortExpression="IsAccountClear" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                <ItemTemplate>
                                    <asp:Label ID="IsAccountCleartrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsAccountClear").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                    <asp:Label ID="IsAccountClearfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsAccountClear").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Data Verified" SortExpression="IsDataVerified" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                <ItemTemplate>
                                    <asp:Label ID="IsDataVerifiedtrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsDataVerified").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                    <asp:Label ID="IsDataVerifiedfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsDataVerified").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Data Reviewed" SortExpression="IsDataReviewed" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                <ItemTemplate>
                                    <asp:Label ID="IsDataReviewedtrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsDataReviewed").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                    <asp:Label ID="IsDataReviewedfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsDataReviewed").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Data Approved" SortExpression="IsDataApproved" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                <ItemTemplate>
                                    <asp:Label ID="isdatatapprovedtrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsDataApproved").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                    <asp:Label ID="isdataapprovedfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsDataApproved").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Final Approved" SortExpression="IsFinalApproved" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp" HeaderStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                <ItemTemplate>
                                    <asp:Label ID="isfinaltrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsFinalApproved").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                    <asp:Label ID="isfinalfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsFinalApproved").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


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
                </div>




                </div>

                <%--  <uc1:TicketsHandler runat="server" id="TicketsHandler" />--%>



        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
