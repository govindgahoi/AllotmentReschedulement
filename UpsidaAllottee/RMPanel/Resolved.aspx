<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/RM.Master" AutoEventWireup="true" CodeBehind="Resolved.aspx.cs" Inherits="UpsidaAllottee.RMPanel.Resolved" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">
        <section class="section dashboard">
            <div class="card info-card sales-card">
                <div class="container-fluid recent-sales">
                    <div class="row">
                        <div class="nine">
                            <h1>Resolved Grievance Details<span>Details of Grievance Summary</span></h1>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered table-hover request-table">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Company Name</th>
                                    <th>Mobile No</th>
                                    <th>Email-Id</th>
                                    <th>Grievance Type</th>
                                    <th>Regional Office</th>
                                    <th>Current Status</th>

                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Amit Kumar Gupta </td>
                                    <td>A113 </td>
                                    <td>7007424522</td>
                                    <td>guptaamit3511@gmail.com</td>
                                    <td>Application status related</td>
                                    <td>PRAYAGRAJ</td>
                                    <td>Resolved</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="row">
                        <div class="col-md-12 pagetitle">
                            <h1>Resolved View Report </h1>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="card-title">
                                    <label>1.) Download Report  <span class="text-danger">*</span></label>
                                </div>
                                <div class="col-md-12">
                                    <div class="custom-file">
                                        <a href="#" class="approve">Download file</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="card-title">
                                    <label>2.) Remarks <span class="text-danger">*</span></label>
                                </div>
                            </div>
                        </div>
                         <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover request-table">
                                    <thead>
                                        <tr>
                                            <th>S.No.</th>
                                            <th>Date</th>
                                            <th>By</th>
                                            <th>Details</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>1.</td>
                                            <td>02/03/2023</td>
                                            <td>Amit Kumar Gupta </td>
                                            <td>Remarks Description message </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="card-title">
                                    <label>3.) Action <span class="text-danger">*</span></label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-4">
                                <span>Resolved</span>
                            </div>
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-2 text-end mt-2">
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
