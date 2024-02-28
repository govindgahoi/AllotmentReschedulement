<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="ServiceRequestInbox.aspx.cs" Inherits="Allotment.ServiceRequestInbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
    <style>
        .content {
                background: #e2e2e2;
        }
        .bg-mywhite {
            background:#fff;
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
        .performance-textdiv p.act-track-text{
                font-size: 11.3px;
            }
        .grid-div {
            min-height:226px;
            margin-top:20px;
        }
        .three-div6in {
            min-height:99px;
            margin-top:10px;
        }
        .div6-right {
            min-height:230px;
            margin-top:20px;
        }
            .div6-right div.announcemnt {
                color: red;
                font-weight: 500;
            }
        .six-div {
            min-height:133px;
            margin-top: 20px;
        }
        .my-heading {
                background: #f5f5f5;
                padding: 0 5px;
                    font-weight: 700;
        }
        .six-div-ul {
            margin:0 10px;
        }
        .six-div-ul li{
            font-size: 13px;
            border-bottom: 1px solid #e8e8e8;
        }
        .current-open-color {
            color:#c59500;
        }
        .pmt-text-color-green {
               color: #28a500;
        }
         .pmt-text-color-yellow {
            color: #fd8e0e;
        }
        .pmt-text-color-red {
            color:red;
            font-weight: 800;
        }
        iframe {
            border: 0px solid #ccc;
        }
        .dash-status span{
                font-size: 42px;
        }
         .dash-status-inr span {
            font-size:25px;
                color: #006d04;
    font-weight: 600;
        }
         .dash-status-inr span i{
                color: #006d04;
        }
        .three-div6in .dash-cost-text{
            margin-top: 9px;
        }
        .my-dash-table-status tr th {
            text-align:center;
            font-weight: 700;
            border-right: 3px solid #ccc !important;
        }
        .my-dash-table-status tr td {
            text-align:center;
            font-weight:700;
            border-right: 3px solid #ccc !important;
        }
        .my-dash-table-status tr td:nth-child(1) {
            text-align:left;                
            position: absolute;
            width: 13em;
            left: 28px;
        }
        .my-dash-table-status tr th:nth-child(1) {
            text-align:left;                
            position: absolute;
            width: 13em;
            left: 28px;
        }

        .table-divinbox {
            margin-top:20px;
            padding:20px;
        }
        .table-divinbox table tr th{
            font-size:12px;
            font-weight:700;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
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
                    <div class="bg-mywhite three-div6in" style="    padding-top: 15px;">
                        <div class="dash-status-inr"><span><i class="fa fa-inr"></i> 0.00</span></div>
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



               <asp:GridView ID="grid_Announcement_List" runat="server"   ShowHeader="false" AutoGenerateColumns="false"  BorderWidth="0" >
                   <Columns>

                   
      


          <asp:TemplateField>
            <ItemTemplate>

                <asp:LinkButton ID="lnkDetails" runat="server" Text='<%# Eval("ALERTMESSAGE") %>' PostBackUrl='<%# "~/Evaluation.aspx?IAOFFICE="+ Eval("IAOFFICE")+"&ServicesId="+ Eval("ServicesId") +"&IAID="+ Eval("IAID")  %>'>

                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>






                   </Columns>
                   </asp:GridView>



            </div>
        </div>
    </div>
   <div class="clearfix"></div>
    <div class="row" style="display:none;">
        <div class="col-md-2 col-sm-12 col-xs-12">
            <div class="bg-mywhite six-div">
                <div class="my-heading font-bold">New Allotment</div>
                <ul class="list-unstyled six-div-ul">
                    <li>Status: <div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div></li>
                    <li>Currently Open: <div class="pull-right"><span class="current-open-color"><b>13</b></span></div></li>
                    <li>New this week: <div class="pull-right"><b>3</b></div></li>
                    <li>Closed this week: <div class="pull-right"><b>2</b></div></li>
                    <li>Critical: <div class="pull-right"><span class="pmt-text-color-red">3</span></div></li>
                    <li><a href="#" class="pull-right" target="_blank">View Details</a></li>
                </ul>
            </div>
        </div>
        <div class="col-md-2 col-sm-12 col-xs-12">
            <div class="bg-mywhite six-div">
                <div class="my-heading font-bold">Transfer/Reconstitution</div>
                <ul class="list-unstyled six-div-ul">
                    <li>Status: <div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div></li>
                    <li>Currently Open: <div class="pull-right"><span class="current-open-color"><b>13</b></span></div></li>
                    <li>New this week: <div class="pull-right"><b>3</b></div></li>
                    <li>Closed this week: <div class="pull-right"><b>2</b></div></li>
                    <li>Critical: <div class="pull-right"><span class="pmt-text-color-red">3</span></div></li>
                    <li><a href="#" class="pull-right" target="_blank">View Details</a></li>
                </ul>
            </div>
        </div>
        <div class="col-md-2 col-sm-12 col-xs-12">
            <div class="bg-mywhite six-div">
                <div class="my-heading font-bold">Cancellation</div>
                <ul class="list-unstyled six-div-ul">
                    <li>Status: <div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div></li>
                    <li>Currently Open: <div class="pull-right"><span class="current-open-color"><b>13</b></span></div></li>
                    <li>New this week: <div class="pull-right"><b>3</b></div></li>
                    <li>Closed this week: <div class="pull-right"><b>2</b></div></li>
                    <li>Critical: <div class="pull-right"><span class="pmt-text-color-red">3</span></div></li>
                    <li><a href="#" class="pull-right" target="_blank">View Details</a></li>
                </ul>
            </div>
        </div>
        <div class="col-md-2 col-sm-12 col-xs-12">
            <div class="bg-mywhite six-div">
                <div class="my-heading font-bold">Restoration</div>
                <ul class="list-unstyled six-div-ul">
                    <li>Status: <div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div></li>
                    <li>Currently Open: <div class="pull-right"><span class="current-open-color"><b>13</b></span></div></li>
                    <li>New this week: <div class="pull-right"><b>3</b></div></li>
                    <li>Closed this week: <div class="pull-right"><b>2</b></div></li>
                    <li>Critical: <div class="pull-right"><span class="pmt-text-color-red">3</span></div></li>
                    <li><a href="#" class="pull-right" target="_blank">View Details</a></li>
                </ul>
            </div>
        </div>
        <div class="col-md-2 col-sm-12 col-xs-12">
            <div class="bg-mywhite six-div">
                <div class="my-heading font-bold">Subdivision and Amalgamation</div>
                <ul class="list-unstyled six-div-ul">
                    <li>Status: <div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div></li>
                    <li>Currently Open: <div class="pull-right"><span class="current-open-color"><b>13</b></span></div></li>
                    <li>New this week: <div class="pull-right"><b>3</b></div></li>
                    <li>Closed this week: <div class="pull-right"><b>2</b></div></li>
                    <li>Critical: <div class="pull-right"><span class="pmt-text-color-red">3</span></div></li>
                    <li><a href="#" class="pull-right" target="_blank">View Details</a></li>
                </ul>
            </div>
        </div>
        <div class="col-md-2 col-sm-12 col-xs-12">
            <div class="bg-mywhite six-div">
                <div class="my-heading font-bold">Time Extension</div>
                <ul class="list-unstyled six-div-ul">
                    <li>Status: <div class="pull-right"><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></div></li>
                    <li>Currently Open: <div class="pull-right"><span class="current-open-color"><b>13</b></span></div></li>
                    <li>New this week: <div class="pull-right"><b>3</b></div></li>
                    <li>Closed this week: <div class="pull-right"><b>2</b></div></li>
                    <li>Critical: <div class="pull-right"><span class="pmt-text-color-red">3</span></div></li>
                    <li><a href="#" class="pull-right" target="_blank">View Details</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
        <div class="row" style="display:none;">
            <div class="col-md-12 text-center col-sm-12 col-xs-12">
                <div style="padding:20px;background:#fff;margin-top:20px;" class="table-responsive">
                    <div style="overflow-x:scroll;margin-left:10.7em;">
                    <table class="table table-bordered table-hover request-table my-dash-table-status">
                        <tr>
                            <th></th>
                            <th class="my-heading font-bold">New Allotment</th>
                            <th class="my-heading font-bold">Transfer/Reconstitution</th>
                            <th class="my-heading font-bold">Cancellation</th>
                            <th class="my-heading font-bold">Restoration</th>
                            <th class="my-heading font-bold">Subdivision</th>
                            <th class="my-heading font-bold">Amalgamation</th>
                            <th class="my-heading font-bold">Time Extension</th>
                            <th class="my-heading font-bold">Maintainence</th>
                            <th class="my-heading font-bold">Subletting</th>
                            <th>Total</th>
                        </tr>
                        <tr>
                            <td>Status:</td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td><span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Completed:</td>
                            <td>21</td>
                            <td>21</td>
                            <td>21</td>
                            <td>21</td>
                            <td>21</td>
                            <td>21</td>
                            <td>21</td>
                            <td>21</td>
                            <td>21</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>In Progress - on track:</td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td><span class="pmt-text-color-green">30</span></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>In Progress - late:</td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td><span class="pmt-text-color-red">40</span></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Remainning:</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Total</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                            <td>11</td>
                        </tr>
                    </table>
                    </div>
                </div>
            </div>
        </div>
    <div class="clearfix"></div>
    

    <div class="bg-mywhite table-divinbox">
        <div class="panel panel-default">
            <div class="panel-heading font-bold">
                In Process - (Pending At You)
            </div>
        </div>
        <div class="">
            <ul class="list-inline iadsashboard-dayul-inbox">
                <li>New Allotment</li>
                            <li>Transfer/Reconstitution</li>
                            <li>Cancellation</li>
                            <li>Restoration</li>
                            <li>Subdivision</li>
                            <li>Amalgamation</li>
                            <li>Time Extension</li>
                            <li>Maintainence</li>
                            <li>Subletting</li>
            </ul>
        </div>
        <div class="col-md-10">
        <asp:GridView ID="GridView2" runat="server"
             CssClass="table table-striped table-bordered table-hover request-table request-table"
            AllowPaging="True"
            AllowSorting="True"
            AutoGenerateColumns="False"
            DataKeyNames="ServiceRequestNO"
            GridLines="Horizontal" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="20"
            OnRowDataBound="GridView2_RowDataBound"
            OnRowCommand="GridView2_RowCommand"
            Width="100%" OnSorting="GridView2_Sorting"
            OnRowDeleting="GridView2_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
        <ASP:HYPERLINKFIELD text="Process" datanavigateurlfields="ServiceRequestNO" datanavigateurlformatstring="BPServiceRequestInbox.aspx?serviceId={0}"></ASP:HYPERLINKFIELD>  
       <%-- <asp:TemplateField  HeaderText="Service Request">
        <ItemTemplate>
                <asp:HyperLink ID="ServiceRequestNO" runat="server" DataNavigateUrlFields="ServiceRequestNO" NavigateUrl='<%# "~/BuildingPlan.aspx?name={0}" %>' 
                        Text='<%# Eval("ServiceRequestNO") %>' ></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
              
                <asp:BoundField DataField="ServiceRequestID" ItemStyle-HorizontalAlign="Justify" HeaderText="ID" SortExpression="ServiceRequestID" />--%>
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
              <%--  <asp:BoundField DataField="AllotteeID" ItemStyle-HorizontalAlign="Justify" HeaderText="Allottee" SortExpression="AllotteeID" />
                <asp:BoundField DataField="ServiceTimeLinesID" HeaderText="Service ID" SortExpression="ServiceTimeLinesID" />--%>
                <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                <asp:BoundField DataField="ApplicationType" HeaderText="Application Regarding" SortExpression="ApplicationType" />
                <asp:BoundField DataField="CaseType" HeaderText="Case" SortExpression="CaseType" />
                <%--<asp:BoundField DataField="ApplicationType" HeaderText="Application Regarding" SortExpression="ApplicationType" />
                                    <asp:BoundField DataField="CaseType" HeaderText="Case" SortExpression="CaseType" />--%>
                <%-- <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/images/document_edit.png" ToolTip="Edit Record" CommandArgument="<%# Container.DataItemIndex %>" CommandName="EditRow" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgDel" runat="server" ImageUrl="~/images/document_delete.png" ToolTip="Delete Record" CommandArgument="<%# Container.DataItemIndex %>" CommandName="DeleteRow" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
        <div class="col-md-2">
            <table class="table table-bordered table-hover request-table">
                    <tr>
                        <td><asp:CheckBoxList ID="chkall" runat="server"></asp:CheckBoxList></td>
                        <td>All</td>
                        
                    </tr>
                    <tr>
                        <td></td>
                        <td>Completed:</td>
                        
                    </tr>
                    <tr>
                        
                        <td></td>
                        <td>In Progress - on track:</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>In Progress - late:</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>Remainning:</td>                        
                    </tr>
            </table>
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="clearfix"></div>
</asp:Content>
