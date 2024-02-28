<%@ Page Title="" Language="C#" MasterPageFile="~/AllotteePanel/Allottee_Master.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="Allotment.AllotteePanel.DashBoard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
     <div class="content-wrapper allottee-leadger">
        <section class="content">
            <div class="container-fluid">
                <div class="row">
                    <%-- Total Outstanding Dues Start--%>
                    <div class="col-lg-3 col-xl-3 col-sm-12 col-md-6">
                        <div class="info-box">
                            <span class="info-box-icon bg-info outstanding elevation-1"><i class="fas fa-rupee-sign"></i></span>
                            <div class="info-box-content main-top-in45">
                                <span class="info-box-text">Total Outstanding Dues</span>
                                <span class="info-box-number">
                                    Rs.<asp:Label ID="lblTotDues" runat="server" ></asp:Label> 
                                </span>
                            </div>
                        </div>
                    </div>
                    <%-- Total Outstanding Dues End--%>
                    <%-- Total Services Applied Start--%>
                    <div class="col-lg-3 col-xl-3 col-sm-12 col-md-6">
                        <div class="info-box mb-3">
                            <span class="info-box-icon bg-danger elevation-1"><i class="fas fa-folder-open"></i></span>
                            <div class="info-box-content main-top-in45">
                                <span class="info-box-text">Total Services Applied</span>
                                <span class="info-box-number"><asp:Label ID="lblApplied" runat="server" ></asp:Label></span>
                            </div>
                        </div>
                    </div>
                    <%-- Total Services Applied End--%>
                    <%-- Total Services Pending Start--%>
                    <div class="col-lg-3 col-xl-3 col-sm-12 col-md-6">
                        <div class="info-box mb-3">
                            <span class="info-box-icon bg-success elevation-1"><i class="fas fa-copy"></i></span>
                            <div class="info-box-content main-top-in45">
                                <span class="info-box-text">Total Services Pending</span>
                                <span class="info-box-number"><asp:Label ID="lblPending" runat="server" ></asp:Label></span>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix hidden-md-up"></div>
                    <%-- Total Services Pending End--%>
                    <%-- Total Grievances Start--%>
                    <div class="col-lg-3 col-xl-3 col-sm-12 col-md-6">
                        <div class="info-box mb-3">
                            <span class="info-box-icon bg-warning grievances0 elevation-1"><i class="fas fa-file-audio"></i></span>

                            <div class="info-box-content main-top-in45">
                                <span class="info-box-text">Total Grievances</span>
                                <span class="info-box-number">0</span>
                            </div>
                        </div>
                    </div>
                    <%-- Total Grievances End--%>
                </div>
                <div class="row" style="display:none">
                    <div class="col-md-8">
                        <div class="chart">
                            <canvas id="salesChart" height="180"></canvas>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <%--E-Services Summary Start--%>
                    <div class="col-md-12 col-lg-12 col-xl-12 col-sm-12">
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">E-Services Summary</h3>
                                <%--<div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                    <button type="button" class="btn btn-tool" data-card-widget="remove">
                                        <i class="fas fa-times"></i>
                                    </button>
                                </div>--%>
                            </div>
                            <div class="card-body p-0">
                                <div class="table-responsive scrolling">
                                    <%--<table class="table m-0 allotee-mains table-hover">
                                        <thead>
                                            <tr>
                                                <th>Service Request ID</th>
                                                <th>Service Name</th>
                                                <th>Status</th>
                                                <th>Action/View</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td><a href="#">1</a></td>
                                                <td>E-Service 1</td>
                                                <td><span class="badge e-serveices badge-success">Shipped</span></td>
                                                <td><i class="fa fa-eye view" aria-hidden="true"></i></td>
                                            </tr>
                                            <tr>
                                                <td><a href="#">2</a></td>
                                                <td>E-Service 2</td>
                                                <td><span class="badge e-serveices badge-warning">Pending</span></td>
                                                <td><i class="fa fa-eye view" aria-hidden="true"></i></td>
                                            </tr>
                                            <tr>
                                                <td><a href="#">3</a></td>
                                                <td>E-Service 3</td>
                                                <td><span class="badge e-serveices badge-danger">Delivered</span></td>
                                                <td><i class="fa fa-eye view" aria-hidden="true"></i></td>
                                            </tr>
                                            <tr>
                                                <td><a href="#">4</a></td>
                                                <td>E-Service 4</td>
                                                <td><span class="badge e-serveices badge-info">Processing</span></td>
                                                <td><i class="fa fa-eye view" aria-hidden="true"></i></td>
                                            </tr>
                                            <tr>
                                                <td><a href="#">5</a></td>
                                                <td>E-Service 5</td>
                                                <td><span class="badge e-serveices badge-warning">Pending</span></td>
                                                <td><i class="fa fa-eye view" aria-hidden="true"></i></td>
                                            </tr>
                                            <tr>
                                                <td><a href="#">6</a></td>
                                                <td>E-Service 6</td>
                                                <td><span class="badge e-serveices badge-success">Delivered</span></td>
                                                <td><i class="fa fa-eye view" aria-hidden="true"></i></td>
                                            </tr>
                                            <tr>
                                                <td><a href="#">7</a></td>
                                                <td>E-Service 7</td>
                                                <td><span class="badge e-serveices badge-warning">Shipped</span></td>
                                                <td><i class="fa fa-eye view" aria-hidden="true"></i></td>
                                            </tr>
                                            <tr>
                                                <td><a href="#">8</a></td>
                                                <td>E-Service 8</td>
                                                <td><span class="badge e-serveices badge-danger">Shipped</span></td>
                                                <td><i class="fa fa-eye view" aria-hidden="true"></i></td>
                                            </tr>
                                            <tr>
                                                <td><a href="#">9</a></td>
                                                <td>E-Service 9</td>
                                                <td><span class="badge e-serveices badge-info">Shipped</span></td>
                                                <td><i class="fa fa-eye view" aria-hidden="true"></i></td>
                                            </tr>
                                        </tbody>
                                    </table>--%>
                                    <asp:GridView ID="GridAllotteeService" runat="server"  AutoGenerateColumns="false" CssClass="mGrid2">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SNo" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                            <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" />
                                            <asp:BoundField DataField="ServiceRequestActivity" HeaderText="Service For" />
                                             <asp:BoundField DataField="IndustrialArea1" HeaderText="Industrial Area" />
                                            <%--<asp:TemplateField>
			                              <ItemTemplate>
											 <a href="#" class="view"><i class="fa fa-eye" aria-hidden="true"></i></a>
                                         </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>

                                    </asp:GridView>

                                </div>
                            </div>
                            <div class="card-footer clearfix">
                                <a href="javascript:void(0)" class="btn btn-sm btn-info float-left">Place New Service</a>
                                <a href="javascript:void(0)" class="btn btn-sm btn-secondary float-right">View All Service</a>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <%--E-Services Summary End--%>
                    <%--Outstanding Dues Summary Start--%>
                   <!-- <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12">
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">Outstanding Dues Summary</h3>
                               <%-- <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                    <button type="button" class="btn btn-tool" data-card-widget="remove">
                                        <i class="fas fa-times"></i>
                                    </button>
                                </div>--%>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-7 col-sm-12">
                                        <div class="chart-responsive">
                                            <canvas id="pieChart" height="150" width="150"></canvas>
                                        </div>
                                    </div>
                                    <div class="col-md-5 col-sm-12">
                                        <ul class="chart-legend clearfix">
                                            <li><i class="far fa-circle text-danger"></i>Balance Dues</li>
                                            <li><i class="far fa-circle text-success"></i>Credit Balance</li>
                                            <li><i class="far fa-circle text-warning"></i>Debit Balance</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="card-footer p-0">
                                <ul class="nav nav-pills flex-column">
                                    <li class="nav-item">
                                        <a href="#" class="nav-link">Districts of UP
                                           <span class="float-right text-danger">
                                               <i class="fas fa-arrow-down text-sm"></i>
                                               12%
                                           </span>
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="#" class="nav-link">Kanpur
                                            <span class="float-right text-success">
                                                <i class="fas fa-arrow-up text-sm"></i>
                                                4%
                                            </span>
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="#" class="nav-link">Lucknow
                                            <span class="float-right text-warning">
                                                <i class="fas fa-arrow-left text-sm"></i>
                                                0%
                                            </span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div> -->
                    <%--Outstanding Dues Summary End--%>
                </div>
                <div class="row">
                    <%--Grievance Redressal Summary Start--%>
                    <div class="col-md-4 col-sm-12">
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">Grievance Redressal Summary</h3>
                                <%--<div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                    <button type="button" class="btn btn-tool" data-card-widget="remove">
                                        <i class="fas fa-times"></i>
                                    </button>
                                </div>--%>
                            </div>
                            <div class="card-body p-0 scrolling">
                                <ul class="products-list product-list-in-card pl-2 pr-2">
                                    <li class="item">
                                        <div class="undermentainence">
                                            <a href="javascript:void(0)" class="product-title dddsdtitle">Under Maintenance</a>
                                            <%--<span class="product-description grievance-title6">Grievance description</span>--%>
                                        </div>
                                    </li>
                                    <%--<li class="item">
                                        <div class="">
                                            <a href="javascript:void(0)" class="product-title">Grievance 2</a>
                                            <span class="product-description grievance-title6">Grievance description</span>
                                        </div>
                                    </li>
                                    <li class="item">
                                        <div class="">
                                            <a href="javascript:void(0)" class="product-title">Grievance 3</a>
                                            <span class="product-description grievance-title6">Grievance description</span>
                                        </div>
                                    </li>
                                    <li class="item">
                                        <div class="">
                                            <a href="javascript:void(0)" class="product-title">Grievance 4</a>
                                            <span class="product-description grievance-title6">Grievance description</span>
                                        </div>
                                    </li>
                                    <li class="item">
                                        <div class="">
                                            <a href="javascript:void(0)" class="product-title">Grievance 4</a>
                                            <span class="product-description grievance-title6">Grievance description</span>
                                        </div>
                                    </li>
                                    <li class="item">
                                        <div class="">
                                            <a href="javascript:void(0)" class="product-title">Grievance 4</a>
                                            <span class="product-description grievance-title6">Grievance description</span>
                                        </div>
                                    </li>
                                    <li class="item">
                                        <div class="">
                                            <a href="javascript:void(0)" class="product-title">Grievance 4</a>
                                            <span class="product-description grievance-title6">Grievance description</span>
                                        </div>
                                    </li>--%>
                                </ul>
                            </div>
                            <div class="card-footer text-center">
                                <a href="javascript:void(0)" class="uppercase">View All Grievance </a>
                            </div>
                        </div>
                    </div>
                    <%--Grievance Redressal Summary End--%>
                    <%--Latest Schemes/Notices Start--%>
                    <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 clearfix">
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">Latest Schemes/Notices</h3>
                                <%--<div class="card-tools">
                                    <span class="badge badge-danger notices-notification">12 Notices</span>
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                    <button type="button" class="btn btn-tool" data-card-widget="remove">
                                        <i class="fas fa-times"></i>
                                    </button>
                                </div>--%>
                            </div>
                            <div class="card-body p-0 latest-scheme scrolling">
                                <ul class="users-list">
                                    <div class="undermentainence">
                                            <a href="javascript:void(0)" class="product-title dddsdtitle">Under Maintenance</a>
                                            <%--<span class="product-description grievance-title6">Grievance description</span>--%>
                                        </div>
                                   <%-- <li>
                                        <i class="fa fa-file-pdf latest-scheme-list" aria-hidden="true"></i>
                                        <a class="users-list-name latest-scheme-list" href="#">Maintenance of administrative</a>
                                        <span class="users-list-date latest-scheme-list">Date: 19/12/2022</span>
                                    </li>
                                    <li>
                                        <i class="fa fa-file-pdf latest-scheme-list" aria-hidden="true"></i>
                                        <a class="users-list-name latest-scheme-list" href="#">Maintenance of administrative</a>
                                        <span class="users-list-date latest-scheme-list">Date: 19/12/2022</span>
                                    </li>
                                    <li>
                                        <i class="fa fa-file-pdf latest-scheme-list" aria-hidden="true"></i>
                                        <a class="users-list-name latest-scheme-list" href="#">Maintenance of administrative</a>
                                        <span class="users-list-date latest-scheme-list">Date: 19/12/2022</span>
                                    </li>
                                    <li>
                                        <i class="fa fa-file-pdf latest-scheme-list" aria-hidden="true"></i>
                                        <a class="users-list-name latest-scheme-list" href="#">Maintenance of administrative</a>
                                        <span class="users-list-date latest-scheme-list">Date: 19/12/2022</span>
                                    </li>
                                    <li>
                                        <i class="fa fa-file-pdf latest-scheme-list" aria-hidden="true"></i>
                                        <a class="users-list-name latest-scheme-list" href="#">Maintenance of administrative</a>
                                        <span class="users-list-date latest-scheme-list">Date: 19/12/2022</span>
                                    </li>
                                    <li>
                                        <i class="fa fa-file-pdf latest-scheme-list" aria-hidden="true"></i>
                                        <a class="users-list-name latest-scheme-list" href="#">Maintenance of administrative</a>
                                        <span class="users-list-date latest-scheme-list">Date: 19/12/2022</span>
                                    </li>
                                    <li>
                                        <i class="fa fa-file-pdf latest-scheme-list" aria-hidden="true"></i>
                                        <a class="users-list-name latest-scheme-list" href="#">Maintenance of administrative</a>
                                        <span class="users-list-date latest-scheme-list">Date: 19/12/2022</span>
                                    </li>
                                    <li>
                                        <i class="fa fa-file-pdf latest-scheme-list" aria-hidden="true"></i>
                                        <a class="users-list-name latest-scheme-list" href="#">Maintenance of administrative</a>
                                        <span class="users-list-date latest-scheme-list">Date: 19/12/2022</span>
                                    </li>
                                    <li>
                                        <i class="fa fa-file-pdf latest-scheme-list" aria-hidden="true"></i>
                                        <a class="users-list-name latest-scheme-list" href="#">Maintenance of administrative</a>
                                        <span class="users-list-date latest-scheme-list">Date: 19/12/2022</span>
                                    </li>
                                    <li>
                                        <i class="fa fa-file-pdf latest-scheme-list" aria-hidden="true"></i>
                                        <a class="users-list-name latest-scheme-list" href="#">Maintenance of administrative</a>
                                        <span class="users-list-date latest-scheme-list">Date: 19/12/2022</span>
                                    </li>--%>
                                </ul>
                            </div>
                            <div class="card-footer text-center">
                                <a href="javascript:">View All Users</a>
                            </div>
                        </div>
                    </div>
                    <%--Latest Schemes/Notices End--%>
                    <%--Direct Chat Start--%>
                    <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 clearfix">
                        <div class="card direct-chat direct-chat-warning">
                            <div class="card-header">
                                <h3 class="card-title">Direct Chat</h3>

                               <%-- <div class="card-tools">
                                    <span title="3 New Messages" class="badge badge-warning">3</span>
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                    <button type="button" class="btn btn-tool" title="Contacts" data-widget="chat-pane-toggle">
                                        <i class="fas fa-comments"></i>
                                    </button>
                                    <button type="button" class="btn btn-tool" data-card-widget="remove">
                                        <i class="fas fa-times"></i>
                                    </button>
                                </div>--%>
                            </div>
                            <div class="card-body">
                                <div class="direct-chat-messages">
                                    <div class="direct-chat-msg">
                                        <div class="direct-chat-infos clearfix">
                                            <span class="direct-chat-name float-left">Allottee Name</span>
                                            <span class="direct-chat-timestamp float-right">23 Jan 2:00 pm</span>
                                        </div>
                                        <img class="direct-chat-img" src="dist/img/user2-160x160.jpg" alt="message user image" />
                                        <div class="direct-chat-text">
                                            Office Chat is a free
                                        </div>
                                    </div>
                                    <div class="direct-chat-msg right">
                                        <div class="direct-chat-infos clearfix">
                                            <span class="direct-chat-name float-right">RM Name</span>
                                            <span class="direct-chat-timestamp float-left">23 Jan 2:05 pm</span>
                                        </div>
                                        <img class="direct-chat-img" src="dist/img/user2-160x160.jpg" alt="message user image" />
                                        <div class="direct-chat-text">
                                            I will support 24 Hours
                                        </div>
                                    </div>
                                    <div class="direct-chat-msg">
                                        <div class="direct-chat-infos clearfix">
                                            <span class="direct-chat-name float-left">Allottee Name</span>
                                            <span class="direct-chat-timestamp float-right">23 Jan 5:37 pm</span>
                                        </div>
                                        <img class="direct-chat-img" src="dist/img/user2-160x160.jpg" alt="message user image" />
                                        <div class="direct-chat-text">
                                            Office Chat is a free
                                        </div>
                                    </div>
                                    <div class="direct-chat-msg right">
                                        <div class="direct-chat-infos clearfix">
                                            <span class="direct-chat-name float-right">RM Name</span>
                                            <span class="direct-chat-timestamp float-left">23 Jan 6:10 pm</span>
                                        </div>
                                        <img class="direct-chat-img" src="dist/img/user2-160x160.jpg" alt="message user image" />
                                        <div class="direct-chat-text">
                                            I will support 24 Hours
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card-footer">
                                <div class="input-group">
                                    <div class="image-upload">
                                        <label for="file-input">
                                            <i class="fa fa-paperclip " aria-hidden="true"></i>
                                        </label>
                                        <input id="file-input" type="file" />
                                    </div>
                                </div>
                                <div class="input-group">
                                    <input type="text" name="message" placeholder="Type Message ..." class=" form-control" />
                                    <span class="input-group-append">
                                        <button type="button" class="btn-warning">Send</button>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--Direct Chat End--%>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

