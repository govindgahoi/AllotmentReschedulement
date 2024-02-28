<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="AllotteeDashBoard.aspx.cs" Inherits="Allotment.AllotteeDashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
 <style>
     .alottee-dash-panel{
         min-height:20px;
     }
     .panel-min-height{
 min-height: 152px;
}
.panel-min-height-3{
    min-height: 183px;
}
 </style>   

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wrapper">
        <!-- Navigation -->
        <div id="page-wrapper" style="min-height: 250px;">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header" style="margin:0px !important">Dashboard</h1>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3  col-sm-12">
                    <div class="panel panel-primary alottee-dash-panel">
                        <div class="panel-heading panel-min-height">
                            <div class="row">
                                <div class="col-xs-2">
                                    <i class="fa fa-user fa-4x"></i>
                                </div>
                                <div class="col-xs-10 font-12px">
                                    
                                     <div  class="" style="font-size:18px;margin-left:12px;"><b><asp:Label runat="server" ID="lblAuthorisedSignatory" CssClass="" ></asp:Label></b></div>
                                    <div class="address-line-ht"style="margin-left:12px;margin-top:7px;"><asp:Label runat="server" ID="lblCompanyAddress"></asp:Label></div>
                                    <div style="margin-left:12px;"><asp:Label runat="server" ID="lblSignatoryEmail"></asp:Label></div>
                                      <div style="margin-left:12px;"><asp:Label runat="server" ID="lblSignatoryPhone"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <span class="pull-left">View Details</span>
                            <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4  col-sm-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading panel-min-height">
                            <div class="row">
                                <div class="col-xs-2">
                                    <i class="fa fa-building-o fa-4x"></i>
                                </div>
                                <div class="col-xs-10 text-left font-12px">
                                    <div style="font-size:18px;"><b><asp:Label runat="server" ID="lblCompanyName"></asp:Label></b></div>
                                     <div></div>

                                    <div>Plot No&nbsp;:&nbsp;<b><asp:Label runat="server" ID="lblPlotNo"></asp:Label></b></div>
                                <div>Allotted Area &nbsp;:&nbsp;<b><asp:Label runat="server" ID="lblPlotArea"></asp:Label>(In Sqmt)</b></div>
                                    <div>Industrial Area &nbsp;:&nbsp;<b><asp:Label runat="server" ID="lblIndArea"></asp:Label></b></div>
                                    <div>Project Scope &nbsp;:&nbsp;<b><asp:Label runat="server" ID="lblProject"></asp:Label></b></div>
                          
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <span class="pull-left">View Details</span>
                            <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>  
                  <div class="col-md-2 col-sm-12 font-12px">
                  
                    <div class="panel panel-yellow">
                        <div class="panel-heading panel-min-height">
                             <div class="row"><center><span class="font-14px"><b></b></span></center>
                            </div>
                            <div class="row"><center><span class="font-14px"><b></b></span><div id="chart_div"></div></center>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <span class="pull-left">Details</span>
                            <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>              
                <div class="col-md-3 col-sm-12">
                    <div class="panel panel-yellow">
                        <div class="panel-heading panel-min-height">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-shopping-cart fa-4x"></i>
                                </div>
                                <div class="col-xs-9 font-12px">
                                    <div><b>Due Amount:</b> <i class="fa fa-inr" aria-hidden="true" style="margin-right:3px;"></i><asp:Label ID="lbl_DueAmount" runat="server" /> </div>
                                    <div runat="server" id="duedatelbl"><b>Due Date:</b><asp:Label ID="lbl_DueDate" runat="server" /></div>
                                    <div> <asp:Button ID="Pay_Now" OnClick="PaymentDue_Click"   runat="server" Text="Pay Now" class="btn btn-sm pay-now-btn" style="margin-top:22px;" />
                           
                                        
                                        
                                       <%-- <a runat="server" id="Pay_Now" href="https://infinity.icicibank.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI" target="_blank" class="btn btn-sm pay-now-btn" style="margin-top:22px;">Pay Now</a></div>
                --%>                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <span class="pull-left">Details</span>
                            <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
            </div>
          
            
<%--- Accordion1 -----%>
            <asp:HiddenField ID="hfServerValue" runat="server" />
<div class="row"> <div class="col-lg-12">
                <div class="panel panel-default">
<div class="panel-heading">
<h4 class="panel-title">
<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#menuFive">  
    <span class="glyphicon glyphicon-plus"></span>               
History of The Plot
</a>
</h4>
</div>
<div id="menuFive" class="panel-collapse collapse in">
<div class="panel-body">
  <asp:GridView ID="PlotHistoryGrid" runat="server" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table">
                            <Columns>

                                
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label22" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
              
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:BoundField DataField="Allotmentletterno" HeaderText="Allottee ID" SortExpression="AllotteeID" />
                                <asp:BoundField DataField="ref_AllotmentNo" HeaderText="Allotment No" SortExpression="Allotmentletterno" />                           
                                <asp:BoundField DataField="AllotmentletterIssueDate" HeaderText="Allottment Date" SortExpression="AllotmentletterIssueDate" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="CompanyName" HeaderText="Register in name of" SortExpression="CompanyName" />
                                <asp:BoundField DataField="AuthorisedSignatory" HeaderText="Authorised User" SortExpression="AuthorisedSignatory" />
                                <asp:BoundField DataField="SignatoryPhone" HeaderText="Phone No" SortExpression="SignatoryPhone" />
                                <asp:BoundField DataField="SignatoryEmail" HeaderText="Email ID" SortExpression="SignatoryEmail" />
                           
                            </Columns>
                       
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>
                        </asp:GridView>
</div>
</div>
</div></div>

            </div>



<div class="row">
                        <div class="col-lg-12">
                <div class="panel panel-default">
<div class="panel-heading">
<h4 class="panel-title">
<a class="accordion-toggle" data-toggle="collapse in" data-parent="#accordion" href="#menuThree" aria-expanded="true">
<span class="glyphicon glyphicon-plus"></span>
Instalment Schedule
</a>
</h4>
</div>
<div id="menuThree" class="panel-collapse collapse in">
<div class="panel-body">

    <asp:GridView ID="PScheduleGrid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover request-table">
                            <Columns>

                                
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label22" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
              
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Duedate" HeaderText="Due Date" SortExpression="Duedate" DataFormatString="{0:dd MMM yyyy}" />
                                <asp:BoundField DataField="Interest"   HeaderText="Interest"   SortExpression="Interest" DataFormatString="{0:c}" HtmlEncode="false" />
                                 <asp:BoundField DataField="Premium"   HeaderText="Premium"   SortExpression="Premium" DataFormatString="{0:c}" HtmlEncode="false" />
                                <asp:BoundField DataField="TotalAmount"   HeaderText="Total Amount"   SortExpression="TotalAmount" DataFormatString="{0:c}" HtmlEncode="false" />
                                
                            </Columns>
                       
                            
                        </asp:GridView>
    <div class="row"><div class="col-lg-6 font-12px">
  <asp:GridView ID="LeaseGrid" runat="server" AutoGenerateColumns="false"  caption="<div class='panel-heading'>Lease Schedule</div>"
                             CssClass="table table-striped table-bordered table-hover request-table">
                            <Columns>

                                
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label22" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
              
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Period" HeaderText="Period" SortExpression="Period" />
                                <asp:BoundField DataField="Rate"   HeaderText="Rate"   SortExpression="Rate" DataFormatString="{0:c}"/>
                                
                            </Columns>
                       
                            
                        </asp:GridView>
       </div> 
    <div class="col-lg-6 font-12px">
        <asp:GridView ID="MaintenanceGrid" runat="server" AutoGenerateColumns="false"  caption="<div class='panel-heading font-12px'>Maintenance Schedule</div>"
                            CssClass="table table-striped table-bordered table-hover request-table">
                            <Columns>

                                
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label22" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
              
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Period" HeaderText="Period" SortExpression="Period" />
                                <asp:BoundField DataField="Rate"   HeaderText="Rate"   SortExpression="Rate" DataFormatString="{0:c}"/>
                                
                            </Columns>
                       
                            
                        </asp:GridView>

      </div>  </div>
    
</div>
</div>
</div></div>


            </div>
            <div class="row"> <div class="col-lg-12">
                <div class="panel panel-default">
<div class="panel-heading">
<h4 class="panel-title">
<a class="accordion-toggle in" data-toggle="collapse" data-parent="#accordion" aria-expanded="true" href="#menuFore">  
    <span class="glyphicon glyphicon-plus"></span>               
Payment History
</a>
</h4>
</div>
<div id="menuFore" class="panel-collapse collapse in">
<div class="panel-body">
   <asp:GridView ID="AllotteePaymentGrid" runat="server" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table">
                            <Columns>

                                
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label22" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
              
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PaymentReicvedDate" HeaderText="Payment Received Date" SortExpression="PaymentReicvedDate" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="PaymentAmount" HeaderText="Payment Amount" SortExpression="PaymentAmount" DataFormatString="{0:c}"/>
                                <asp:BoundField DataField="PaymentDescription" HeaderText="Payment Description" SortExpression="PaymentDescription" />
                               
                            </Columns>
                       
                            
                        </asp:GridView>
</div>
</div>
</div></div>

            </div>

            <div class="row"> <div class="col-lg-12">
                <div class="panel panel-default">
<div class="panel-heading">
<h4 class="panel-title">
<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#menuOne">  
    <span class="glyphicon glyphicon-plus"></span>               
Premium
</a>
</h4>
</div>
<div id="menuOne" class="panel-collapse collapse in">
<div class="panel-body">
   <asp:GridView ID="AllotteePremiumGrid" runat="server" AutoGenerateColumns="false"
                          CssClass="table table-striped table-bordered table-hover request-table">
                            <Columns>

                                
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label22" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="DueDate" HeaderText="Due Date" SortExpression="DueDate" DataFormatString="{0:dd MMM yyyy}" />
                                <asp:BoundField DataField="Dues" HeaderText="Dues" SortExpression="Dues"  HtmlEncode="false"  DataFormatString="{0:c}"   ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="TotalInterestDues" HeaderText="Premim Interest" SortExpression="Interest" HtmlEncode="true"  DataFormatString="{0:c}"  ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="TotalPremiumDues" HeaderText="Premium" SortExpression="Premium"  HtmlEncode="false" DataFormatString="{0:c}"  ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="TotalLeaseDues" HeaderText="Lease" HtmlEncode="false"  DataFormatString="{0:c}"  ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="TotalMaintenance_IntrestDues" HeaderText="Maintenance Interest" HtmlEncode="false"  DataFormatString="{0:c}"  ItemStyle-HorizontalAlign="Right"/>
                                <asp:BoundField DataField="TotalMaintenanceDues" HeaderText="Maintenance" HtmlEncode="false"  DataFormatString="{0:c}"  ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="PayReceivedDate" HeaderText="Payment Date" HtmlEncode="false"  ItemStyle-HorizontalAlign="Center"  />
                                <asp:BoundField DataField="Payments" HeaderText="Payment Amt." HtmlEncode="false" DataFormatString="{0:c}"   ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="BalancePremium" HeaderText="Balance Amt." ItemStyle-HorizontalAlign="Right" HtmlEncode="false" DataFormatString="{0:c}" />
                           
                                </Columns>
                       
                           
                        </asp:GridView>
</div>
</div>
</div></div>

            </div>

<input type="hidden" runat="server" id="Percentage" />
            <%--- Accordion2 -----%>

           



                    
    </div>
        </div>
     <script type="text/javascript">
         $(function () {
             $('.collapse').on('shown.bs.collapse', function () {
                 $(this).parent().find(".glyphicon-plus").removeClass("glyphicon-plus").addClass("glyphicon-minus");
             }).on('hidden.bs.collapse', function () {
                 $(this).parent().find(".glyphicon-minus").removeClass("glyphicon-minus").addClass("glyphicon-plus");
             });
         })


        

         google.charts.load('current', { 'packages': ['gauge'] });
         google.charts.setOnLoadCallback(drawChart);

         function drawChart() {
           
             var val = document.getElementById("<%= Percentage.ClientID %>").value;
            
             var data = google.visualization.arrayToDataTable([
               ['Label', 'Value'],
               ['', parseInt(val)]

             ]);

             var options = {
                 width: 400, height: 120,
                 greenFrom: 0, greenTo: 25,
                 yellowFrom: 25, yellowTo: 75,
                 redFrom: 75,  redTo:100,
                 minorTicks: 5
             };

             var chart = new google.visualization.Gauge(document.getElementById('chart_div'));

             chart.draw(data, options);

             //setInterval(function () {
             //    data.setValue(0, 1, 40 + Math.round(60 * Math.random()));
             //    chart.draw(data, options);
             //}, 13000);
             //setInterval(function () {
             //    data.setValue(1, 1, 40 + Math.round(60 * Math.random()));
             //    chart.draw(data, options);
             //}, 5000);
             //setInterval(function () {
             //    data.setValue(2, 1, 60 + Math.round(20 * Math.random()));
             //    chart.draw(data, options);
             //}, 26000);
         }


</script>
    
</asp:Content>
