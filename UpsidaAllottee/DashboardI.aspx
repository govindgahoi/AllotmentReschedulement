<%@ Page Title="" Language="C#" EnableViewState="true"  MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="DashboardI.aspx.cs" Inherits="UpsidaAllottee.DashboardI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


    <script type="text/javascript" src="/js/loader.js"></script>
    <script type="text/javascript" src="/js/highcharts.js"></script>
<script type="text/javascript" src="/js/data.js"></script>
<script type="text/javascript" src="/js/drilldown.js"></script>

    <style>
        #main-menu li i {
            color:#fff;
        }
        .dashboardi-a .list-group {
            margin-bottom:0;
        }
    </style>
     
            
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
                <div class="col-md-3 col-sm-6 col-xs-12" style="margin-bottom:10px;">
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
                <div class="col-md-3 col-sm-6 col-xs-12" style="margin-bottom:10px;">
                    <div class="panel panel-green">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-3 col-sm-3 col-xs-3">
                                    <i class="fa fa-tasks fa-4x"></i>
                                </div>
                                <div class="col-md-9 col-sm-9 text-right col-xs-9">
                                    <div class="font-bold">Allotments</div>
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
                <div class="col-md-3 col-sm-6 col-xs-12" style="margin-bottom:10px;">
                    <div class="panel panel-green">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-3 col-sm-3 col-xs-3">
                                    <i class="fa fa-tasks fa-4x"></i>
                                </div>
                                <div class="col-md-9 col-sm-9 text-right col-xs-9">
                                    <div class="font-bold">Allottee Registrations</div>
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
                           Registration/Migration                       
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body dashboardi-a">
                            <div class="list-group">
                               
                                <a class="list-group-item" href="#">Allottee Request                                  
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="LblAllotteeRequest" runat="server" ></asp:Label></em>
                                    </span>
                                </a>

                                <a class="list-group-item" href="#">Allottee Request Not in Considration                                
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="LblAllotteeReqNotInCon" runat="server"></asp:Label></em>
                                    </span>
                                </a>

                                 <a class="list-group-item" href="#">Allottee Request Accepted                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="LblReqAccepted" runat="server" ></asp:Label></em>
                                    </span>
                                </a>
                                <a class="list-group-item" href="#">Pending                              
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="LblAllotteeReqPending" runat="server"></asp:Label></em>
                                    </span>
                                </a>
                                
                         
                                <a class="list-group-item" href="#">Completed                              
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="LblAllotteeReqCompleted" runat="server"></asp:Label></em>
                                    </span>
                                </a>
                            </div>
                        </div>
                    </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 col-xs-12" style="margin-bottom:10px;">
                    <div class="panel panel-yellow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-3 col-sm-3 col-xs-3">
                                    <i class="fa fa-suitcase fa-4x" aria-hidden="true"></i>
                                </div>
                                <div class="col-md-9 col-sm-9 text-right col-xs-9">
                                    <div class="font-bold">Service Request</div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <span class="pull-left">Details</span>
                            <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                            <div class="clearfix"></div>
                        </div>
                        <div class="panel panel-default">
                        <div class="panel-heading">
                           Service Requests                     
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body dashboardi-a">
                            <div class="list-group">
                                  <a class="list-group-item" href="#">New Requests                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblserreqnew" runat="server"></asp:Label></em>
                                    </span>
                                </a>
                                <a class="list-group-item" href="#">Pending                                 
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblserpend" runat="server"></asp:Label></em>
                                    </span>
                                </a>

                                <a class="list-group-item" href="#">In Process                               
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblserProcessed" runat="server"></asp:Label></em>
                                    </span>
                                </a>
                                
                                 <a class="list-group-item" href="#">Rejected                               
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblserrej" runat="server" ></asp:Label></em>
                                    </span>
                                </a>
                                <a class="list-group-item" href="#">Completed                              
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblserComp" runat="server" ></asp:Label></em>
                                    </span>
                                </a>
                            </div>
                        </div>
                    </div>
                    </div>
                </div>

            <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="panel panel-default">


                
                <div class="clearfix"></div>
                <div class="row" style="border:1px solid #ccc;margin:10px 0;">
                    <div class="panel-heading font-bold">Investment</div>
                    <div class="pie-chart col-md-12 col-sm-12 col-xs-12" style="margin-top:5px;">

                         <div class="col-md-4 col-sm-12 col-xs-12 pie-char-details" style="margin-bottom:10px;min-height: 250px;background: #f7f7f7;border-left: 4px solid #36c;padding:25px;">
                            <div style="">
                     <asp:GridView ID="gridsummary" runat="server"   PagerStyle-HorizontalAlign="Right" CssClass="request-table table table-striped table-bordered table-hover"   AutoGenerateColumns="true" > 
</asp:GridView> 

                            </div>
                             <div id="piechart_3d" style="width: 100%; height: 120px;"></div>

                             <asp:Literal ID="lt" EnableViewState="true" ViewStateMode="Enabled" runat="server" ></asp:Literal>
                        </div>

                        <div class="col-md-8 col-sm-12 col-xs-12" style="margin-bottom:10px;">
                            
                           <div  class="bar-chart">
                                <div id="dual_x_div" style="width: 100%;height:270px;"></div>
                                <asp:Literal ID="lt1"  EnableViewState="true" ViewStateMode="Enabled"  runat="server" ></asp:Literal>
                            </div> 
                            
                        </div>
               
                    </div>
                </div><br />


                <div class="clearfix"></div>
                <div class="row" style="border:1px solid #ccc;margin:15px 0;">
                    <div class="panel-heading font-bold">Employment</div>
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        
                        <div id="dual_x_div1" style="width: 100%; height: 400px;"></div>
                         <asp:Literal ID="lt2" runat="server" ></asp:Literal>
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="row" style=" display:none; border:1px solid #ccc;margin:15px 0;">
                    <div class="panel-heading font-bold">Employment</div>
                    <div class="col-md-12 col-sm-12 col-xs-12">     
                        
                        <div id="container" style="width: 100%; height: 400px;"></div>
                                                </div>
                    <asp:Literal ID="lt0" runat="server" ></asp:Literal>



                    </div>
                </div>



              
            <div class="clearfix"></div>
           <div class="panel panel-default" style="display:none;">
<div class="panel-heading">
    <div class="col-md-8 col-sm-4 col-xs-12">
        <h4 class="panel-title">
        <a class="accordion-toggle in" data-toggle="collapse" data-parent="#accordion" aria-expanded="true" href="#menuFore">  
            <span class="glyphicon glyphicon-minus"></span>               
        Project Investment Detail View
        </a>
        </h4>
    </div>
    <div class="col-md-4 col-sm-8 col-xs-12 input-group"> 
        <asp:TextBox id="txtsearch" runat="server" Width="100%" CssClass="input-sm" OnTextChanged="txtsearch_TextChanged"    AutoPostBack="true"></asp:TextBox>
        <span class="input-group-btn">            
            <button class="btn btn-sm btn-primary" type="button"><i class="fa fa-search" style="padding:2px 0;color:#fff;"></i></button>
        </span>
    </div>
    <div class="clearfix"></div>

</div>
<div id="menuFore" class="panel-collapse collapse in" >
<div class="panel-body"> <%-- OnRowDataBound="OnRowDataBound"--%>
    <div class="table-responsive">
     <asp:GridView ID="Allottee_master_grid" 
                                 runat="server"  ShowFooter="true"
                                 PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" 
                                 CssClass="request-table table table-striped table-bordered table-hover request-table" 
                                 OnSorting="Allottee_master_grid_Sorting" 
                                 OnPageIndexChanging="OnPageIndexChanging" 
                                 AutoGenerateColumns="false" AllowPaging="True" AllowSorting="True" PageSize="10"
                                  OnDataBound = "OnDataBound_investment">




                                 <Columns>

                                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                         <ItemTemplate>
                                             <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Regional Office">
                                         <ItemTemplate>
                                             <asp:Label ID="LBLPaymentMode" runat="server" Text='<%#Eval("RegionalOffice") %>'></asp:Label>
                                         </ItemTemplate>

                                     </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Industrial Area">
                                         <ItemTemplate>
                                             <asp:Label ID="LBLIAName" runat="server" Text='<%#Eval("IAName") %>'></asp:Label>
                                         </ItemTemplate>
                                         <FooterTemplate>

                                             <asp:DropDownList ID="drpIndustrialArea"  CssClass="input-sm similar-select1" runat="server">
                     
                                             </asp:DropDownList>
                                         </FooterTemplate>
                                     </asp:TemplateField>





                                     <asp:TemplateField HeaderText="Name">
                                         <ItemTemplate>
                                             <asp:Label ID="LBLname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                                         </ItemTemplate>
                                         <FooterTemplate>
                                             <asp:TextBox ID="txtname"  placeholder="Name"  CssClass="input-sm similar-select1" runat="server"></asp:TextBox></FooterTemplate>
                                     </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Plot No">
                                         <ItemTemplate>
                                             <asp:Label ID="lblplotNo" runat="server" Text='<%#Eval("plot_no") %>'></asp:Label>
                                         </ItemTemplate>
                                         <FooterTemplate>
                                             <asp:TextBox ID="txtplotNo" placeholder="Plot No" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                          
                                         </FooterTemplate>
                                     </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Plot Area<br/>(In Sq.M.)">
                                         <ItemTemplate>
                                             <asp:Label ID="lblplotareaNo" runat="server" Text='<%#Eval("area") %>'></asp:Label>
                                         </ItemTemplate>
                                         <FooterTemplate>
                                             <asp:TextBox ID="txtplotareaSize" placeholder="Plot Area" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                         </FooterTemplate>
                                     </asp:TemplateField>


                                     

                                     <asp:TemplateField HeaderText="Project Cost<br/>(in Lakhs)">
                                         <ItemTemplate>
                                             <asp:Label ID="lblproject_cost" runat="server" Text='<%#Eval("project_cost") %>'></asp:Label></ItemTemplate>
                                         <FooterTemplate>
                                             <asp:TextBox ID="txtproject_cost"  placeholder="Project Cost (in Lakhs)" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);"></asp:TextBox></FooterTemplate>
                                     </asp:TemplateField>


                                      <asp:TemplateField HeaderText="Current Cost<br/>(in Lakhs)">
                                         <ItemTemplate>
                                             <asp:Label ID="lblcurrent_cost" runat="server" Text='<%#Eval("Current_cost") %>'></asp:Label></ItemTemplate>
                                         <FooterTemplate>
                                             <asp:TextBox ID="txtcurrent_cost" placeholder="Current Cost (in Lakhs)" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);"></asp:TextBox></FooterTemplate>
                                     </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Employment Projected">
                                         <ItemTemplate>
                                             <asp:Label ID="lblempl_projected" runat="server" Text='<%#Eval("Employment_Projected") %>'></asp:Label></ItemTemplate>
                                         <FooterTemplate>
                                             <asp:TextBox ID="txtempl_projected"  placeholder="Projected" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);"></asp:TextBox></FooterTemplate>
                                     </asp:TemplateField>


                                      <asp:TemplateField HeaderText="Employment Generated</br>as on date">
                                         <ItemTemplate>
                                             <asp:Label ID="lblempl_generated" runat="server" Text='<%#Eval("Employment_Genreted") %>'></asp:Label></ItemTemplate>
                                         <FooterTemplate>
                                             <asp:TextBox ID="txtempl_generated"  placeholder="Generated" runat="server" CssClass="input-sm similar-select1" ToolTip="Employment Generated (in Lakhs) -- (only Numeric Value)" onkeypress="return isDecimalKey(event);"></asp:TextBox></FooterTemplate>
                                     </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Investment Type">
                                         <ItemTemplate>
                                             <asp:Label ID="lblInvestment_Type" runat="server" Text='<%#Eval("Investment_Type") %>'></asp:Label></ItemTemplate>
                                        <FooterTemplate>
                                             <asp:DropDownList ID="drpdInvestment_Type"  CssClass="input-sm similar-select1" runat="server">
                                                 <asp:ListItem Text="From Transfer of Plots" Value="T"></asp:ListItem>
                                                 <asp:ListItem Text="Approved Allotment in FY" Value="A"></asp:ListItem>
                                                 <asp:ListItem Text="Proposed New Allotment" Value="P"></asp:ListItem>
                                            </asp:DropDownList>
                                        </FooterTemplate>        
                                    </asp:TemplateField>



                                     <asp:TemplateField>
                                    <%--     <ItemTemplate>
                                             <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                 ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="return checkAllotment3()"  OnClick="ButtonAdd_Click"  />

                                         </ItemTemplate>
                                    --%>    

                                         
                                         <FooterStyle HorizontalAlign="Right" />
                                         <FooterTemplate>
                                             <asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square"   OnClick="ButtonAdd_Click" ID ="ButtonAdd" runat="server" Height="16px"
                                                 ImageUrl="~/images/add.png" Width="16px"  />
                                         </FooterTemplate>

                                     </asp:TemplateField>


                                 </Columns>
                             </asp:GridView>
    </div>

    </div>
</div>
</div>
    </div>
        
                 

</ContentTemplate>
    </asp:UpdatePanel>

      


    <script type="text/javascript">
        $(function () {
            $('.collapse').on('shown.bs.collapse', function () {
                $(this).parent().find(".glyphicon-plus").removeClass("glyphicon-plus").addClass("glyphicon-minus");
            }).on('hidden.bs.collapse', function () {
                $(this).parent().find(".glyphicon-minus").removeClass("glyphicon-minus").addClass("glyphicon-plus");
            });
        })</script>
</asp:Content>
