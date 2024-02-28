<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MISReportTotalPaymentReceivedApp.aspx.cs" Inherits="UpsidcApi.MISReportTotalPaymentReceived" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="icon" href="images\upsidclogo.png"/>
    <title>
	Uttar Pradesh Industrial Development Authority
</title>
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet"/>



    <script async="" src="https://www.google-analytics.com/analytics.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
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
    
    <style>
        @media only screen and (max-width:992px) {
            .form-group label.text-right {
                text-align: left !important;
            }
        }

        table tr th[colspan="8"] {
            background: #bfbfbf !important;
        }

        .request-table tr .head-IAname {
            background: #ccc !important;
        }

        .request-table tr .head-region {
            background: #ccc !important;
        }

        .request-table tr .head-total {
            background: #656565 !important;
            color: #fff;
        }
    </style>
    
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css"/>
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.2.2/css/buttons.dataTables.min.css"/>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>






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
<script>(function () {
        // injected DOM script is not a content script anymore,
        // it can modify objects and functions of the page
        var _pushState = history.pushState;
        history.pushState = function (state, title, url) {
            _pushState.call(this, state, title, url);
            window.dispatchEvent(
                new CustomEvent('state-changed', { detail: url })
            );
        };
        // repeat the above for replaceState too
    })();</script>
    <script>(function () {
                              // injected DOM script is not a content script anymore,
                              // it can modify objects and functions of the page
                              var _pushState = history.pushState;
                              history.pushState = function (state, title, url) {
                                  _pushState.call(this, state, title, url);
                                  window.dispatchEvent(
                                      new CustomEvent('state-changed', { detail: url })
                                  );
                              };
                              // repeat the above for replaceState too
                          })();</script>
    <script>(function () {
                              // injected DOM script is not a content script anymore,
                              // it can modify objects and functions of the page
                              var _pushState = history.pushState;
                              history.pushState = function (state, title, url) {
                                  _pushState.call(this, state, title, url);
                                  window.dispatchEvent(
                                      new CustomEvent('state-changed', { detail: url })
                                  );
                              };
                              // repeat the above for replaceState too
                          })();</script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">  
         <div class="row">
       
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="clearfix"></div>
            <hr class="myhrline" style="border-bottom: 1px solid #d8d8d8;" />
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div id="DivP" style="text-align: center; padding: 15px 25px; margin: 25px 0%; background: #fbfbfb; border: 1px solid #ccc;">
                <div class="div-report" runat="server" style="text-align: center;">

                    <%-- CssClass="table table-striped table-bordered table-hover request-table request-table"--%>
                    <img src="images/upsidclogo.png" class="header-logo" style="border-top: none; height: 40px; margin-bottom: 0;" /><br>
                    <strong>U.P. STATE INDUSTRIAL DEVELOPMENT AUTHORITY LIMITED, KANPUR<br>
                        (Head Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024)</strong><br />
                    <br />

                        <div class="table-responsive" >
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover request-table request-table"
                            ClientIDMode="Static" 
                            AutoGenerateColumns="true"
                            GridLines="Horizontal"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
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
                    <div style="border-top: 3px solid #ffc511;">&nbsp;</div>
                    <div class="table-responsive" >
                        <asp:GridView ID="AllGrid" runat="server" CssClass="table table-striped table-bordered table-hover request-table request-table"
                            ClientIDMode="Static"
                            AutoGenerateColumns="true"
                            AllowPaging="true"
                            OnPageIndexChanging="OnPaging"
                            DataKeyNames="ServiceRequestNo"
                            GridLines="Horizontal"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
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




                    <br />
                    <br />
                    <br />
                    <br />
                    <div style="border-top: 3px solid #ffc511;">&nbsp;</div>
                    <div class="mail-disclaimer">
                        <p class="text-justify"><strong>Disclaimer:</strong>The information contained in this Report  is intended solely for the use of the individual or entity to whom it is addressed and others authorized to receive it. It may contain confidential or legally privileged information. If you are not the intended recipient you are hereby notified that any disclosure, copying, distribution or taking any action in reliance on the contents of this information is strictly prohibited and may be unlawful. If you have received this Report in error, please notify us immediately by responding at info[at]upsidc[dot]com  and then delete it from your system. In case of any query please contact us at info[at]upsidc[dot]com.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
            </div>
   <script type="text/javascript">
       $(document).ready(function () {
           $('[id*=AllGrid]').prepend($("<thead></thead>").append($('[id*=AllGrid]').find("tr:first"))).DataTable({
               dom: 'Bfrtip',
               'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
               'iDisplayLength': 20,
               buttons: [
                   { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                   { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all' } } },
                   { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all' } } },
                   { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
               ]
           });

           $('[id*=GridView1]').prepend($("<thead></thead>").append($('[id*=GridView1]').find("tr:first"))).DataTable({
               dom: 'Bfrtip',
               'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
               'iDisplayLength': 10,
               buttons: [
                   { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                   { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all' } } },
                   { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all' } } },
                   { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
               ]
           });

       });


    </script>
    <script type="text/javascript">

        function PrintElem() {

            Popup($('#DivP').html());
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
     <script type="text/javascript">



         $(document).ready(function () {
             Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
         });

         function PageLoaded(sender, args) {
             $(".chosen").chosen();

             $(".MultiSelect").chosen();
         }

</script>

       
    
    

<script type="text/javascript">
    //<![CDATA[

    theForm.oldSubmit = theForm.submit;
    theForm.submit = WebForm_SaveScrollPositionSubmit;

    theForm.oldOnSubmit = theForm.onsubmit;
    theForm.onsubmit = WebForm_SaveScrollPositionOnSubmit;

    theForm.oldOnLoad = window.onload;
    window.onload = WebForm_RestoreScrollPosition;
//]]>
</script>
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
    </script><div id="ui-datepicker-div" class="ui-datepicker ui-widget ui-widget-content ui-helper-clearfix ui-corner-all"></div>






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
    </form>
</body>
</html>
