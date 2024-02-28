<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maintenance.aspx.cs" Inherits="UpsidaAllottee.Maintenance" Culture="en-IN" UICulture="en-IN" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />



    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet" />
    <script src="js/jquery-ui.js"></script>
    <script src="js/chosen.jquery.min.js"></script>

    <script type="text/javascript" lang="js">
        $(function () {
            $("input[type=text]").keyup(function () {

                $("#btnLedger").hide();
                $("#lblLedger").hide();
                $("#gridAllotDetail").hide();
                $("#lblMsg").hide();
                $("#btnDemand").hide();
                $("#gridTotalDetail").hide();
                $("#totransection").hide();
                $("#lbldebit").hide();
                $("#lblcredit").hide();
                $("#Label1").hide();
                $("#lblRecoverable").hide();
                $("#PreviousServiceDiv").hide();
                $("#btnpay").hide();
            });

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".autosuggest1").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;charset=utf-8",
                        url: '<%=ResolveUrl("~/searchService.asmx/GetAutoCompletePlot") %>',
                        data: "{" +
                        "'txtSearch1':'" + request.term + "'," +
                        "'IAName':'" + $('#<%= DlIA.ClientID %>').val() + "'" +

                        "}",
                        dataType: "json",
                        //async:false,
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                minLength: 1
            });
        });

    </script>
    <script type="text/javascript">
        if (document.layers) {
            //Capture the MouseDown event.
            document.captureEvents(Event.MOUSEDOWN);

            //Disable the OnMouseDown event handler.
            $(document).mousedown(function () {
                return false;
            });
        }
        else {
            //Disable the OnMouseUp event handler.
            $(document).mouseup(function (e) {
                if (e != null && e.type == "mouseup") {
                    //Check the Mouse Button which is clicked.
                    if (e.which == 2 || e.which == 3) {
                        //If the Button is middle or right then disable.
                        return false;
                    }
                }
            });
        }

        //Disable the Context Menu event.
        $(document).contextmenu(function () {
            return false;
        });
    </script>
    <title></title>
    <style type="text/css">
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
                margin-top: 1%;
            }
        }

        .fill-view-mytable td {
            font-size: 16px !important;
        }

        .modal-header {
            padding: 2px !important;
        }

        @media screen and (max-width: 768px) {
            .form-group .col-xs-6 {
                width: 50% !important;
            }
        }

        .content {
            min-height: 600px;
        }


        .my-app-status li:after {
            content: "\f178";
            font-family: FontAwesome;
            font-weight: 800;
            font-style: normal;
            margin: 0 0 0px 5px;
            text-decoration: none;
        }

        .my-app-status {
            margin: 10px auto;
            border: 1px solid #ccc;
            padding: 14px 0px;
            text-align: center;
            background: #dfdfdf;
            border: 1px solid #ccc;
        }

            .my-app-status li span {
                border: 1px solid #ccc;
                padding: 8px 6px;
                font-size: 11px;
                background: #f4cd4c;
            }

            .my-app-status li:nth-last-child(1):after {
                display: none !important;
            }

            .my-app-status li {
                margin: 10px 0;
                padding: 0;
            }

                .my-app-status li span.orange {
                    background: orange;
                    color: #fff;
                }

                .my-app-status li span.red {
                    background: red;
                    color: #fff;
                }

                .my-app-status li span.green {
                    background: green;
                    color: #fff;
                }

        .row {
            margin-bottom: 10px;
        }

        .lblmessage {
            background-color: gainsboro;
            width: 100%;
            text-align: center;
            margin-top: 10PX;
            margin-bottom: 10PX;
        }

        .btnledger {
            text-align: center;
            margin-top: 15px;
            margin-bottom: 10px;
        }

        .GridViewledger1 {
            text-align: center;
            margin-bottom: 15px;
        }

        .lblViewledger {
            background-color: ghostwhite;
            width: 100%;
            text-align: center;
            margin-top: 20PX;
            margin-bottom: 5PX;
            font-size: larger;
            font-weight: 600;
        }

        .col-sm-9 {
            margin-right: 20px;
        }
    </style>

</head>
>
<body oncontextmenu="return false">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

        <div class="container">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                        <a href="Default.aspx" class="navbar-brand">
                            <div class="col-md-8">
                                <img class="img-responsive" src="https://www.onlineupsidc.com/OfcUser_pdf/upsida-logo-name.png" />
                            </div>
                            <div class="col-md-4">
                                <img class="img-responsive" src="Image.jpg" />
                            </div>
                        </a>

                    </div>
                </div>
                <div id="main_menu" runat="server"><% Response.WriteFile("top_mainmenu.aspx"); %> </div>
            </div>
            <div class="row table-responsive" id="SideDiv">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading text-center">
                            <h4>ONE TIME SETTLEMENT (OTS) FOR MAINTENANCE DUES</h4>
                        </div>
                        <hr class="separation" />

                        <div class="row">
                            <div class="col-md-7">
                                <div class="row" style="margin-top: 30px; margin-bottom: 20px">
                                    <div class="col-md-4 col-lg-3 col-sm-3">
                                        <span style="color: Red">*</span>
                                        Regional Office
                                    </div>
                                    <div class="col-md-8 col-lg-8 col-sm-8">
                                        <asp:DropDownList ID="dlRO" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlRO_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-4 col-lg-3 col-sm-3">
                                        <span style="color: Red">*</span>
                                        Industrial Area
                                    </div>
                                    <div class="col-lg-8 col-md-8 col-sm-8 ">
                                        <asp:DropDownList ID="DlIA" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="DlIA_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-4 col-lg-3 col-sm-3">
                                        <span style="color: Red">*</span>
                                        Plot Number
                                    </div>
                                    <div class="col-lg-8 col-md-8 col-sm-8">
                                        <%--<asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" CssClass="autosuggest form-control" Font-Size="small" ></asp:TextBox>--%>
                                        <asp:TextBox runat="server" ID="txtSearch1" CssClass="autosuggest1 form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5" style="text-align: -webkit-center;">
                                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calender1_OnSelectionChanged" BackColor="White" BorderColor="black"
                                    BorderWidth="1px" CssClass="btn-primary disabled active" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black"
                                    Height="190px" NextPrevFormat="FullMonth" Width="350px">
                                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" HorizontalAlign="center" />
                                    <DayStyle HorizontalAlign="Center" />
                                    <NextPrevStyle BorderColor="#66CCFF" Font-Bold="True" Font-Size="10pt" ForeColor="white" VerticalAlign="Bottom" HorizontalAlign="Center" Wrap="True" />
                                    <OtherMonthDayStyle ForeColor="#999999" HorizontalAlign="center" />
                                    <SelectedDayStyle BackColor="#333399" BorderColor="White" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectorStyle HorizontalAlign="Center" />
                                    <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" HorizontalAlign="Center" />
                                    <TodayDayStyle BackColor="#CCCCCC" HorizontalAlign="Center" />
                                    <WeekendDayStyle HorizontalAlign="Center" />
                                </asp:Calendar>



                            </div>

                        </div>
                        <div class="row" style="margin-top: 10px">
                            <div class="col-md-12 col-sm-12 text-center">
                                <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-sm btn-primary" Text="View Details" OnClick="Demand_Click" />
                            </div>
                        </div>
                    </div>


                </div>
                <div class="panel panel-default" runat="server" id="panel">
                    <%--<hr class="separation" />--%>
                    <div class="">
                        <asp:GridView ID="gridTotalDetail" EmptyDataText="No data found!" Font-Size="X-Large" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover request-table" OnRowDataBound="gridTotalDetail_RowDataBound">
                            <RowStyle Font-Size="X-Large"></RowStyle>

                            <Columns>

                                <asp:BoundField ItemStyle-Width="80px" DataField="Description" HeaderText="DESCRIPTION" ItemStyle-Font-Names="18px" />
                                <asp:BoundField ItemStyle-Width="25px" DataField="Dues" DataFormatString="{0:c}" HeaderText="DUES" HtmlEncode="false" />
                                <asp:BoundField ItemStyle-Width="180px" DataField="TotalInterest" DataFormatString="{0:c}" HeaderText="INTEREST UPTO" HtmlEncode="false" />
                               
                                <asp:TemplateField ItemStyle-Width="120px" HeaderText="GRAND TOTAL">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="grandTotal" runat="server" DataFormatString="{0:c}" HtmlEncode="false" Text='<% GrandTotal %>' />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div align="center">NO DUES.</div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <div style="text-align: center; margin-top: 50px; margin-bottom: 40px;">
                            <asp:Button id="btnpay" runat="server" Text="Next" CssClass="btn btn-sm btn-primary" OnClick="pageredirectToNivesh" />
                        </div>
                    </div>
                </div>

                <div style="font-size: 18px; margin-right: 170px">
                    <%--<span style="color: Red">**</span><span><b>Terms and Conditions for availing Maintenance OTS Scheme</b></span>

                    <ol style="font-size: 13px">
                        <li>If the applicant is PSU
                    <ul style="list-style-type: disc">
                        <li>Maintenance Charge Due Till Application Date</li>
                        <li>Subsidy 75% on Interest of Maintenance Till Application Date</li>
                    </ul>
                        </li>
                        <li>If Non-PSU, the applicant has to deposit:
                    <ul style="list-style-type: disc">
                        <li>Maintenance Charge Due Till Application Date</li>
                        <li>Subsidy 50% on Interest of Maintenance Till Application Date</li>
                    </ul>
                        </li>
                        <li>The applicant has to deposit 25% of the Total Dues ( Maintenance Charge + Subsidized Interest on Maintenance Charge ) 
                      against Maintenance at the time of application.</li>
                        <li>Rest 75% of Total Dues (Maintenance charge + Subsidized Interest on Maintenance Charge) against Maintenance will be
                       divided into 4 equal monthly installments which will be calculated from the date of application. 
                        </li>
                    </ol>
                    <small>Note : If the applicant is unable to deposit the dues as per above terms and conditions, they will be ineligible for
                    the Maintenance OTS Scheme.</small>--%>
                    <div style="margin-bottom: 10px">
                        <span style="color: Red">**</span><small>Disclaimer : Demand is auto-generated as per data fed in the system.</small>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>

