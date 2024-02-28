<%@ Page Title="" Language="C#" MasterPageFile="~/MainUserOD.Master" AutoEventWireup="true" CodeBehind="DashboardO.aspx.cs" Inherits="Allotment.DashboardO" %>

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
  
            <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

    

    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always"  >
    <ContentTemplate>

     <div id="wrapper">
        <!-- Navigation -->
        <div id="page-wrapper" style="min-height: 319px;">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <h1 class="page-header">Dashboard</h1>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-sm-6 col-xs-6" style="margin-bottom:10px;">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-3 col-sm-3 col-xs-3">
                                    <i class="fa fa-user fa-4x"></i>
                                </div>
                                <div class="col-sm-9 col-sm-9 text-right col-xs-9">
                                    <div class="font-bold">Personal Info</div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <span class="pull-left">View Details</span>
                            <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                            <div class="clearfix"></div>
                        </div>
                        <div class="panel panel-default">
                        <div class="panel-heading">
                            Personal Info                       
                        </div>
                        <div class="panel-body dashboardi-a">
                            <div class="list-group">
                                <a class="list-group-item" href="#">Name                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label></em>
                                    </span>
                                </a>
                                <a class="list-group-item" href="#">Designation.                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lbldesignation" runat="server" Text=""></asp:Label></em>
                                    </span>
                                </a>
                                <a class="list-group-item" href="#">Grade.                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblGrade" runat="server" Text=""></asp:Label></em>
                                    </span>
                                </a>
                                <a class="list-group-item" href="#">Phone No.                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblPhoneNo" runat="server" Text=""></asp:Label></em>
                                    </span>
                                </a>
                                <a class="list-group-item" href="#">Email                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></em>
                                    </span>
                                </a>
                            </div>
                        </div>
                    </div>
                 </div>
              </div>
                <div class="col-md-6 col-sm-6 col-xs-6" style="margin-bottom:10px;">
                    <div class="panel panel-green">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-3 col-sm-3 col-xs-3">
                                    <i class="fa fa-tasks fa-4x"></i>
                                </div>
                                <div class="col-md-9 col-sm-9 text-right col-xs-9">
                                    <div class="font-bold">Warehousing & Logistics</div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <span class="pull-left">View Details</span>
                            <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                            <div class="clearfix"></div>
                        </div>
                        <div class="panel panel-default">
                        <div class="panel-heading">
                            Registrations                       
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body dashboardi-a">
                            <div class="list-group">
                                <a class="list-group-item" href="#">New Allotment Requests                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblnew" runat="server" ></asp:Label></em>
                                    </span>
                                </a>
                                <a class="list-group-item" href="#">Pending/In Process                                  
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblnewsigPending" runat="server" ></asp:Label></em>
                                    </span>
                                </a>
                                <a class="list-group-item" href="#">Under Objection                              
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblNewSignActivated" runat="server"></asp:Label></em>
                                    </span>
                                </a>
                                
                                 <a class="list-group-item" href="#">Rejected                               
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblnewsignRejected" runat="server"></asp:Label></em>
                                    </span>
                                </a>
                                <a class="list-group-item" href="#">Completed                              
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblnewsignCompleted" runat="server"></asp:Label></em>
                                    </span>
                                </a>
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
