<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IAServiceReportsApp.aspx.cs" Inherits="UpsidcApi.IAServiceReports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head><link rel="icon" href="images\upsidclogo.png"/><title>
	Uttar Pradesh Industrial Development Authority
</title><link href="/assets/css/bootstrap.min.css" rel="stylesheet"/>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.0/css/all.min.css" />

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js">

    </script>
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css"/>
    <link href="/css/theme.css" rel="stylesheet"/>
    <link href="/css/Wizard.css" rel="stylesheet"/>
    <link href="/css/Main.css" rel="stylesheet"/>
    <link href="css/style4.css" rel="stylesheet"/>
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css"/>
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet"/>
     <script src="js/jquery-ui.js"></script>
    <script src="js/custumt.js"></script>

    <script src="js/chosen.jquery.min.js"></script>
    
    <link href="css/Wizard.css" rel="stylesheet"/>
    <style>
        .Red {
            color: red;
        }

        .Green {
            color: green;
        }

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

        a.static.selected {
            text-decoration: none;
            border-style: none;
            color: #000000 !important;
            background: #ffdb6d;
        }

        .iadsashboard-dayul-inbox ul li a {
            text-decoration: none;
            white-space: nowrap;
            display: block;
            padding: 4px 6px;
            color: #2b2b2b;
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

        #ContentPlaceHolder1_sub_menu a.static {
            padding-left: 10px !important;
            padding-right: 10px !important;
        }

        .iadsashboard-dayul-inbox li {
            /* padding-left: 5px; */
            /* padding-right: 5px; */
            background: #ffc511;
            text-align: center;
            margin: 0px 2px;
            /* width: 127px; */
            /* height: 21px; */
            font-size: 13px;
            font-weight: 600;
            box-shadow: 7px 0 16px #ccc;
            color: #000000;
            border: 1px solid #8e8e8e;
        }
    </style>
    

    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "images/plus.png");
            $(this).closest("tr").next().remove();
        });
        function PrintElem() {

            Popup($('#FinalPrint').html());
        }
        function PrintElemOffice() {

            Popup($('#PrintReginaloffice').html());
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



      <style type="text/css">
       
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            width: 300px;
            border: 3px solid #0DA9D0;
            border-radius: 12px;
            padding: 0;
        }
        .modalPopup .header
        {
            background-color: #2FBDF1;
            height: 30px;
            color: White;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
            border-top-left-radius: 6px;
            border-top-right-radius: 6px;
        }
        .modalPopup .body
        {
            padding: 10px;
            min-height: 50px;
            text-align: center;
            font-weight: bold;
        }
        .modalPopup .footer
        {
            padding: 6px;
        }
        .modalPopup .yes, .modalPopup .no
        {
            height: 23px;
            color: White;
            line-height: 23px;
            text-align: center;
            font-weight: bold;
            cursor: pointer;
            border-radius: 4px;
        }
        .modalPopup .yes
        {
            background-color: #2FBDF1;
            border: 1px solid #0DA9D0;
        }
        .modalPopup .no
        {
            background-color: #9F9F9F;
            border: 1px solid #5C5C5C;
        }
    </style>

     <style type="text/css">

        #myBtn {
  display: none;
  position: fixed;
  bottom: 20px;
  right: 1420px;
  z-index: 99;
  font-size: 18px;
  border: none;
  outline: none;
  background-color: red;
  color: white;
  cursor: pointer;
  padding: 15px;
  border-radius: 4px;
}

#myBtn:hover {
  background-color: #555;
}

        @media only screen and (max-width: 992px) {
            .topbtncollapse {
                display:none;
            }
        }
        @media only screen and (min-width: 768px) {
            .content {
                /*padding: 51px 15px 0px 15px;*/
                min-height: 200px;
            }

            .ul-nav-div {
                min-height: 92vh;
                max-height: 92vh;
                overflow-y: auto;
            }

           
        }

        .fgh {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0
        }

        .hgf {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 130px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1
        }

        #line-chart {
            height: 300px;
            width: 800px;
            margin: 0px auto;
            margin-top: 1em;
        }

        .navbar-default .navbar-brand, .navbar-default .navbar-brand:hover {
            color: rgb(45,45,45);
        }

        .sidebar-nav ul li a {
            cursor: pointer;
        }

        @media only screen and (max-width: 768px) {
            .sidebar-nav.sticky {
                /*display: block !important;*/
                position: relative !important;
            }

            #sidebar {
                max-width: 100% !important;
                min-width: 100% !important;
                margin-left: 0 !important;
            }

                #sidebar ul li a i {
                    display: inline !important;
                }

                #sidebar ul li a {
                    padding: 0 20px !important;
                }

                #sidebar ul ul a {
                    color: #fff !important;
                }

                    #sidebar ul ul a:hover {
                        color: #000 !important;
                    }

                    #sidebar ul ul a.currentPage {
                        color: #000 !important;
                    }
        }

        .my-dash-table-status tr td:nth-child(1) {
            text-align: left;
            position: absolute;
            height: 50px;
            width: 11.3em;
            font-size: 12px;
            left: 28px;
        }

        .my-dash-table-status tr th:nth-child(1) {
            text-align: left;
            position: absolute;
            width: 10.3em;
            left: 28px;
        }

        #divsectionrecommendation {
            min-height: 154px;
        }

        #divoperational {
            min-height: 154px;
        }

        #divvalidation {
            min-height: 154px;
        }

        #divregulations {
            min-height: 154px;
        }

        #divcurrentstatus {
            min-height: 154px;
        }

        .status-bar-bottom {
            position: relative;
            background: #f5f5f5;
            bottom: 0;
            /* margin-top: 1px; */
            border: 1px solid #ccc;
            width: 100%;
            margin-bottom: 0;
        }

        .ul-plot-view li {
            border-right: 1px solid #ccc;
            min-width: 257px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
   <div class="bg-mywhite table-divinbox">
        <div class="panel panel-default">
            <span class="pull-right">
                <a id="A1" runat="server" onclick="PrintElem()" style="cursor: pointer;">
                    <i style="font-size: 18px;" class="fa fa-print" aria-hidden="true"></i>
                </a>
            </span>
        </div>
        <div style="overflow-x: auto; overflow-y: auto; max-height: 100%;" id="FinalPrint">
            <h2 style='background-color: #4CAF50; text-align: center; font-size: 16px; color: #ffffff;'>Consolidated Statement of UPSIDA Citizen services Period from 01-10-2019 till
                 <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></h2>
            <asp:GridView ID="GridView2" runat="server"
                CssClass="table table-striped table-bordered table-hover request-table myreq-col"
                AutoGenerateColumns="False"
                DataKeyNames="ServiceTimeLinesID,ServiceTimelinesActivity,Total_Received,Total_Pending,Total_Completed,Total_Rejection,Total_Objection,DAPending,RMPending,AccountantPending,MOPending,CMIAPending,JMDPending,MDPending"
                GridLines="Horizontal" OnRowDataBound="GridView2_RowDataBound"
                Width="100%"
                ItemStyle-Width="10%">
                <Columns>
                    <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                        <ItemTemplate>
                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Style="cursor: pointer" ImageUrl="~/images/plus.png" />
                            <asp:Panel ID="pnlAllotmentRequest" runat="server" Style="display: none">
                                <span class="pull-right">
                                    <a id="A1" runat="server" onclick="PrintElemOffice()" style="cursor: pointer;">
                                        <i style="font-size: 18px;" class="fa fa-print" aria-hidden="true"></i>
                                    </a>
                                </span>
                                <div id="PrintReginaloffice">
                                    <span class="center-block"></span>
                                    <h2 style='background-color: #4CAF50; text-align: center; font-size: 16px; color: #ffffff;'>
                                        <asp:Label ID="ServiceName" runat="server" Text=""></asp:Label>Period from 01-10-2019 till
                                        <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></h2>
                                    <asp:GridView ID="GridViewAllotmentRequest" runat="server" AutoGenerateColumns="False" CssClass="request-table table table-hover table-bordered cm-table-heading myreq-col">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="RegionalOffice" ItemStyle-Wrap="false" Visible="True" HeaderText="RegionalOffice" SortExpression="RegionalOffice" />
                                            <asp:BoundField DataField="Total_Received" ItemStyle-Wrap="false" Visible="True" HeaderText="Total Received" SortExpression="Total_Received" />
                                            <asp:BoundField DataField="Total_Pending" ItemStyle-Wrap="false" Visible="True" HeaderText="Total Pending" SortExpression="Total_Pending" />
                                            <asp:BoundField DataField="Total_Completed" HeaderText="Total Completed" SortExpression="Total_Completed" />
                                            <asp:BoundField DataField="Total_Rejection" HeaderText="Total Rejection" SortExpression="Total_Rejection" />
                                            <asp:BoundField DataField="Total_Objection" HeaderText="Total Objection" SortExpression="Total_Objection" />
                                            <asp:BoundField DataField="DAPending" HeaderText="Pending at DA" SortExpression="DAPending" />
                                            <asp:BoundField DataField="RMPending" HeaderText="Pending at RM" SortExpression="RMPending" />
                                            <asp:BoundField DataField="AccountantPending" HeaderText="Pending at Accountant" SortExpression="AccountantPending" />
                                            <asp:BoundField DataField="MOPending" HeaderText="Pending at MO" SortExpression="MOPending" />
                                             <asp:BoundField DataField="AMPending" HeaderText="Pending at AM" SortExpression="AMPending" />
                                             <asp:BoundField DataField="DMPending" HeaderText="Pending at DM" SortExpression="DMPending" />
                                            <asp:BoundField DataField="CMIAPending" HeaderText="Pending at CMIA" SortExpression="CMIAPending" />
                                            <asp:BoundField DataField="JMDPending" HeaderText="Pending at JMD" SortExpression="JMDPending" />
                                            <asp:BoundField DataField="MDPending" HeaderText="Pending at MD" SortExpression="MDPending" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="IAID" HeaderText="IndustrialArea" Visible="false" SortExpression="IAID" />
                    <asp:BoundField DataField="ServiceTimelinesActivity" ItemStyle-Wrap="false" Visible="True" HeaderText="Service Name" SortExpression="ServiceTimelinesActivity" />
                    <asp:BoundField DataField="Total_Received" ItemStyle-Wrap="false" Visible="True" HeaderText="Total Received" SortExpression="Total_Received" />
                    <asp:BoundField DataField="Total_Pending" ItemStyle-Wrap="false" Visible="True" HeaderText="Total Pending" SortExpression="Total_Pending" />
                    <asp:BoundField DataField="Total_Completed" HeaderText="Total Completed" SortExpression="Total_Completed" />
                    <asp:BoundField DataField="Total_Rejection" HeaderText="Total Rejection" SortExpression="Total_Rejection" />
                    <asp:BoundField DataField="Total_Objection" HeaderText="Total Objection" SortExpression="Total_Objection" />
                    <asp:BoundField DataField="DAPending" HeaderText="Pending at DA" SortExpression="DAPending" />
                    <asp:BoundField DataField="RMPending" HeaderText="Pending at RM" SortExpression="RMPending" />
                    <asp:BoundField DataField="AccountantPending" HeaderText="Pending at Accountant" SortExpression="AccountantPending" />
                    <asp:BoundField DataField="MOPending" HeaderText="Pending at MO" SortExpression="MOPending" />
                    <asp:BoundField DataField="AMPending" HeaderText="Pending at AM" SortExpression="AMPending" />
                    <asp:BoundField DataField="DMPending" HeaderText="Pending at DM" SortExpression="DMPending" />
                    <asp:BoundField DataField="CMIAPending" HeaderText="Pending at CMIA" SortExpression="CMIAPending" />
                    <asp:BoundField DataField="JMDPending" HeaderText="Pending at JMD" SortExpression="JMDPending" />
                    <asp:BoundField DataField="MDPending" HeaderText="Pending at MD" SortExpression="MDPending" />
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
    <div class="clearfix"></div>



    </form>
    <script>
        var fn3 = (function () {
            var first = true;
            return function () {
                first ? fn1() : fn2();
                first = !first;
            }
        })();
        function fn1() {
            document.getElementById("mycontent").style.marginLeft = "135px";
        }
        function fn2() {
            document.getElementById("mycontent").style.marginLeft = "244px";
        }
        if ($(window).width() <= 768) {
            $(this).closest('').remove();
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#sidebarCollapse').on('click', function () {
                $('#sidebar').toggleClass('active');
            });

        });
    </script>

    <script type="text/javascript">
        $("[rel=tooltip]").tooltip();
        $(function () {
            $('.demo-cancel-click').click(function () { return false; });
        });
    </script>

    <script type="text/javascript">
        $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
            $(this).blur();
            $(this).datepicker('hide');
        });;

        $(".date1").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd MM yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
            $(this).blur();
            $(this).datepicker('hide');
        });;

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });;
            $(".date1").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd MM yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });;
        });
    </script>






    <style>
        .act .currentPage {
            border-left: 4px solid #8989a6;
            overflow: hidden;
            background: #d2d2dd;
        }
    </style>


    <script type="text/javascript">


        $(function () {
            var url = window.location.pathname,
                urlRegExp = new RegExp(url.replace(/\/$/, '') + "$");

            //   alert(urlRegExp);

            $('.sidebar-nav  ul li a').each(function () {
                if (urlRegExp.test(this.href.replace(/\/$/, ''))) {
                    //   alert(this.href.replace(/\/$/, ''));
                    $(this).addClass('act currentPage');
                    $(this).parent().parent(".garima").css('display', 'block');
                    $(this).parent().parent(".garima").removeClass("collapse").addClass("collapse in").css('font-weight', 'bold');
                    $(this).parent().parent(".garima").prev("h3").css('color', 'green');
                    $('#content').css("min-height", $('#sideLeft').height());
                }
            });


            $('.sidebar-nav ul li ul li a').each(function () {
                if (urlRegExp.test(this.href.replace(/\/$/, ''))) {
                    //     alert(this.href.replace(/\/$/, ''));
                    $(this).parent().addClass('act currentPage');
                    $(this).parent().parent("ul").removeClass("collapse").addClass("collapse in");
                    $(this).addClass('act currentPage');

                }
            });



        });



    </script>

    <script language="javascript" type="text/javascript">
        $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
            $(this).blur();
            $(this).datepicker('hide');
        });;
        $(".datePresent").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", maxDate: "0" }).on('changeDate', function (ev) {
            $(this).blur();
            $(this).datepicker('hide');
        });;

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });;
            $(".datePresent").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", maxDate: "0" }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });;
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            console.log("document ready!");

            var $sticky = $('.sticky');
            //var $stickyrStopper = $('.sticky-stopper');
            if (!!$sticky.offset()) { // make sure ".sticky" element exists

                var generalSidebarHeight = $sticky.innerHeight();
                var stickyTop = $sticky.offset().top;
                var stickOffset = 0;


                $(window).scroll(function () { // scroll event
                    var windowTop = $(window).scrollTop(); // returns number


                    if (stickyTop < windowTop + stickOffset) {
                        $sticky.css({ position: 'fixed', top: stickOffset });
                    } else {
                        $sticky.css({ position: 'absolute', top: 'initial' });
                    }
                });

            }

        });

    </script>
    <script type="text/javascript">
        $(function () {
            var match = document.cookie.match(new RegExp('color=([^;]+)'));
            if (match) var color = match[1];
            if (color) {
                $('body').removeClass(function (index, css) {
                    return (css.match(/\btheme-\S+/g) || []).join(' ')
                })
                $('body').addClass('theme-' + color);
            }

            $('[data-popover="true"]').popover({ html: true });

        });
    </script>
    <script>
        // When the user scrolls down 20px from the top of the document, show the button
        window.onscroll = function () { scrollFunction() };

        function scrollFunction() {
            if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
                document.getElementById("myBtn").style.display = "block";
            } else {
                document.getElementById("myBtn").style.display = "none";
            }
        }

        // When the user clicks on the button, scroll to the top of the document
        function topFunction() {
            document.body.scrollTop = 0;
            document.documentElement.scrollTop = 0;
        }
    </script>

<!-- Visual Studio Browser Link -->
<script type="application/json" id="__browserLink_initializationData">
    {"appName":"Firefox","requestId":"865b7811de67402ca3d1cf01544fa775"}
</script>
<!-- End Browser Link -->


</body>
</html>
