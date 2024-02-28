<%@ Page Title="" Language="C#" MasterPageFile="~/AllotteePanel/Allottee_Master.Master" AutoEventWireup="true" CodeBehind="AllotteeServiceTrack.aspx.cs" Inherits="Allotment.AllotteePanel.AllotteeServiceTrack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Allottee Service  |  Tracker</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper allottee-leadger">
        <section class="content">
            <div class="box">
                <div class="heading-main-top">
                    <h1 class="subtitle fancy"><span>Service Tracker </span></h1>
                </div>

                <div class="search-box-tatla">
                    <div class="row">
                        <div class="col-md-4 ">
                            <div class="findnumber">
                                <h3>Service Request No:</h3>
                            </div>
                        </div>
                        <div class="col-md-4 ">
                            <div class="findnumber">
                                <asp:TextBox ID="TextBox1" CssClass="allotment-letter2" placeholder="Service Request No:" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4 ">
                            <div class="findnumber">
                                <asp:Button ID="Button1" CssClass="button9" runat="server" Text="Go."></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box-header">
                    <h3 class="box-title">Existing Service Record</h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div id="example1_wrapper" class="dataTables_wrapper form-inline" role="grid">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6 text-left">
                                    <div id="example1_length" class="dataTables_length">
                                        <label>
                                            <select size="1" name="example1_length" aria-controls="example1">
                                                <option value="10" selected="selected">1</option>
                                                <option value="25">25</option>
                                                <option value="50">50</option>
                                                <option value="100">100</option>
                                            </select>
                                            Records per page</label>
                                    </div>
                                </div>
                                <div class="col-md-3"></div>
                                <div class="col-md-3 text-right">
                                    <div class="dataTables_filter" id="example1_filter">
                                        <asp:TextBox ID="TextBox2" CssClass="allotment-letter22" placeholder="Search......." runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="table-responsive">
                            <table class="table table-hover table-bordered table-striped  allotee-mains">
                                <thead>
                                    <tr>
                                        <th class="sorting_asc" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Rendering engine: activate to sort column descending">S.No.</th>
                                        <th class="sorting_asc" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Rendering engine: activate to sort column descending">Regional Office</th>
                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Industrial Area</th>
                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending">Service Request No</th>
                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">Allotment No</th>
                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="CSS grade: activate to sort column ascending">Plot No</th>
                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">Applicant Name</th>
                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="CSS grade: activate to sort column ascending">Service Name</th>
                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="CSS grade: activate to sort column ascending">Final Submission Date</th>
                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="CSS grade: activate to sort column ascending">Status</th>
                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="CSS grade: activate to sort column ascending">Veiw</th>
                                    </tr>
                                </thead>


                                <tbody role="alert" aria-live="polite" aria-relevant="all">
                                    <tr>
                                        <td>1.</td>
                                        <td>LUCKNOW</td>
                                        <td>Raebareli Site-II</td>
                                        <td>SER20221109/1/21686/61546</td>
                                        <td>21686</td>
                                        <td>61546</td>
                                        <td>SHRI HANSRAJ CHANDANI</td>
                                        <td>Building Plan Approval -Construction Permits</td>
                                        <td>17/11/2022</td>
                                        <td>NOC Issued</td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton6" CssClass="viewbtn0" runat="server" ImageUrl="dist/img/view2.png" OnClick="ShowPopup" /></td>
                                    </tr>
                                    <tr>
                                        <td>2.</td>
                                        <td>LUCKNOW</td>
                                        <td>Raebareli Site-II</td>
                                        <td>SER20221109/1/21686/61546</td>
                                        <td>21686</td>
                                        <td>61546</td>
                                        <td>SHRI HANSRAJ CHANDANI</td>
                                        <td>Building Plan Approval -Construction Permits</td>
                                        <td>17/11/2022</td>
                                        <td>NOC Issued</td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton5" CssClass="viewbtn0" runat="server" ImageUrl="dist/img/view2.png" OnClick="ShowPopup" /></td>
                                    </tr>
                                    <tr>
                                        <td>3.</td>
                                        <td>LUCKNOW</td>
                                        <td>Raebareli Site-II</td>
                                        <td>SER20221109/1/21686/61546</td>
                                        <td>21686</td>
                                        <td>61546</td>
                                        <td>SHRI HANSRAJ CHANDANI</td>
                                        <td>Building Plan Approval -Construction Permits</td>
                                        <td>17/11/2022</td>
                                        <td>NOC Issued</td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton4" CssClass="viewbtn0" runat="server" ImageUrl="dist/img/view2.png" OnClick="ShowPopup" /></td>
                                    </tr>
                                    <tr>
                                        <td>4.</td>
                                        <td>LUCKNOW</td>
                                        <td>Raebareli Site-II</td>
                                        <td>SER20221109/1/21686/61546</td>
                                        <td>21686</td>
                                        <td>61546</td>
                                        <td>SHRI HANSRAJ CHANDANI</td>
                                        <td>Building Plan Approval -Construction Permits</td>
                                        <td>17/11/2022</td>
                                        <td>NOC Issued</td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton3" CssClass="viewbtn0" runat="server" ImageUrl="dist/img/view2.png" OnClick="ShowPopup" /></td>
                                    </tr>
                                   


                                </tbody>
                            </table>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6 text-left">
                                        <div class="dataTables_info" id="example1_info">Showing 1 to 10 of 57 entries</div>
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <div class="dataTables_paginate paging_bootstrap">
                                            <ul class="pagination">
                                                <li class="prev disabled"><a href="#">← Previous</a></li>
                                                <li class="active"><a href="#">1</a></li>
                                                <li><a href="#">2</a></li>
                                                <li><a href="#">3</a></li>
                                                <li><a href="#">4</a></li>
                                                <li><a href="#">5</a></li>
                                                <li class="next"><a href="#">Next → </a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <div id="MyPopup" class="modal fade" role="dialog">
        <div class="modal-dialog servicestrackr ">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title">Application Proceedings</h4>
                </div>
                <div class="modal-body">
                    <table class="table table-striped table-bordered table-hover request-table allotee-mains">
                        <tbody>
                            <tr>
                                <th>S.No</th>
                                <th>From</th>
                                <th>To</th>
                                <th>Status</th>
                                <th>Remarks</th>
                                <th>Date</th>
                            </tr>
                            <tr>
                                <td>
                                    <span>1</span>
                                </td>
                                <td>SHRI HANSRAJ CHANDANI(Applicant)</td>
                                <td>Manoj. Verma(DA)</td>
                                <td>Application Resubmission                                                                                                                              </td>
                                <td>Resubmitted</td>
                                <td>11/17/2022 6:16:07 PM</td>
                            </tr>
                            <tr>
                                <td>
                                    <span>2</span>
                                </td>
                                <td>Shubhendu_Amitabh(DA)</td>
                                <td>Santosh Kumar(RM)</td>
                                <td>Recommended                                                                                                                                           </td>
                                <td>Please take necessary action</td>
                                <td>11/19/2022 12:05:43 PM</td>
                            </tr>
                            <tr>
                                <td>
                                    <span>3</span>
                                </td>
                                <td>santosh kumar(RM)</td>
                                <td>Brejnandan Srivastava(JE)</td>
                                <td>Recommended                                                                                                                                           </td>
                                <td>Please Check and put-up within time.</td>
                                <td>11/29/2022 12:17:08 PM</td>
                            </tr>
                            <tr>
                                <td>
                                    <span>4</span>
                                </td>
                                <td>Brejnandan Srivastava(JE)</td>
                                <td>Santosh Kumar(RM)</td>
                                <td>Recommended                                                                                                                                           </td>
                                <td>Recommended for necessary approval, please</td>
                                <td>12/1/2022 6:28:44 PM</td>
                            </tr>
                            <tr>
                                <td>
                                    <span>5</span>
                                </td>
                                <td>Santosh Kumar (RM)</td>
                                <td>Santosh Kumar (RM)</td>
                                <td>Approved                                                                                                                                              </td>
                                <td>Approved</td>
                                <td>12/8/2022 7:55:54 PM</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ShowPopup(title) {
            $("#MyPopup");
            $("#MyPopup").modal("show");
        }
    </script>
</asp:Content>

