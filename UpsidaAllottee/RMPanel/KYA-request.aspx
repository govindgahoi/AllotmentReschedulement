<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/RM.Master" AutoEventWireup="true" CodeBehind="KYA-request.aspx.cs" Inherits="UpsidaAllottee.RMPanel.KYA_request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function PrintPending() {
var prtGrid = document.getElementById('<%=GridKYAPending.ClientID %>');
prtGrid.border = 0;
var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
prtwin.document.write(prtGrid.outerHTML);
prtwin.document.close();
prtwin.focus();
prtwin.print();
prtwin.close();
}

        function PrintApproved() {
var prtGrid = document.getElementById('<%=GridKYAApproved.ClientID %>');
prtGrid.border = 0;
var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
prtwin.document.write(prtGrid.outerHTML);
prtwin.document.close();
prtwin.focus();
prtwin.print();
prtwin.close();
}

function PrintRejected() {
var prtGrid = document.getElementById('<%=GridKYARejected.ClientID %>');
prtGrid.border = 0;
var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
prtwin.document.write(prtGrid.outerHTML);
prtwin.document.close();
prtwin.focus();
prtwin.print();
prtwin.close();
}

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">
        <section class="section dashboard">
            <div class="card info-card sales-card">
                <div class="container-fluid recent-sales">
                    <div class="row">
                        <div class="nine">
                            <h1>KYA Approval<span>Details of KYA</span></h1>
                        </div>
                    </div>

                    <div class="offices ">
                        <div class="row pt-2 pb-2">
                            <div class="col-lg-3 col-md-3">
                                <p class="float-end">   Regional Office</p>
                            </div>
                            <div class="col-lg-3 col-md-3">
                                 

                           <asp:DropDownList ID="dlRO" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="dlRO_SelectedIndexChanged"></asp:DropDownList>


                            </div>
                            <div class="col-lg-6 col-md-6"></div>
                        </div>
                    </div>
                    <div class="row mt-3 mb-3">
                        <div class="col-md-6"><h4>Pending Requests</h4></div>
                        <div class="col-md-6 text-end">
                            <asp:Button ID="btnXport2XLPending" class="approve" runat="server" Text="Export to Excel" OnClick="btnXport2XLPending_Click" />
                            <!--<input type="button" id="btnPending" vi class="approve" value="Print" onclick="PrintGridDataPending()" />-->
                        </div>
                    </div>
                    <div class="table-responsive pt-4">
                        

                        <%--<table class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>S.No.</th>
                                    <th>Allotment Id</th>
                                    <th>Name of Allottee</th>
                                    <th>Regional Office</th>
                                    <th>Industrial Area</th>
                                    <th>Plot No </th>
                                    <th>Email Id</th>
                                    <th>Mobile No</th>
                                    <th>GST Registration Status</th>
                                    <th>GST Registration No</th>
                                    <th>Date of GST Registration</th>
                                    <th>PAN</th>
                                    <th>Aadhar Card</th>
                                    <th>Remark</th>
                                    <th>View</th>
                                </tr>
                            </thead>
                            <tbody>

                                <tr>
                                    <td>1.</td>
                                    <td>RAG\3153</td>
                                    <td>M/s. Gyan Agri Products</td>
                                    <td>Agra</td>
                                    <td>Bhogaon</td>
                                    <td>35 Acres UD Land</td>
                                    <td>gyanagri.prod@gmail.com</td>
                                    <td>9457332292</td>
                                    <td>Yes</td>
                                    <td>4795-96/SIDC/RMA/UD</td>
                                    <td>01/01/1900</td>
                                    <td>ROKH38945733229</td>
                                    <td>94573322924546456</td>
                                    <td>Remark</td>
                                    <td><a href="KYA-form.aspx" class="approve"><i class="bi bi-eye-fill text-white"></i></a></td>
                                </tr>
                            </tbody>
                        </table>--%>
                        <asp:GridView ID="GridKYAPending" runat="server" AutoGenerateColumns="false" AllowPaging="true" class="mGrid2" OnPageIndexChanging="GridKYAPending_PageIndexChanging">
                            <Columns>
                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerNo" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                                 
                                                <asp:BoundField DataField="AllotmentLetterNo" HeaderText="Allotment Id" />
                                                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                                                <asp:BoundField DataField="RegionalOffice" HeaderText="Regional Office" />
                                                <asp:BoundField DataField="IndustrialArea" HeaderText="Plolt No" />
                                                <asp:BoundField DataField="PloltNo" HeaderText="Industrial Area" />
                                                <asp:BoundField DataField="PhoneNo" HeaderText="Mobile No" />
                                                <asp:BoundField DataField="EmailID" HeaderText="Email-Id" /> 
                                                <asp:BoundField DataField="Remark" HeaderText="Remark" />
                                               
                                               <%-- <asp:TemplateField HeaderText="Grievance-Id" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:HyperLink runat="server" ID="hlnkView"  NavigateUrl='<%# string.Format("grievance-details.aspx?Grievance_Ref_ID={0}",HttpUtility.UrlEncode(Eval("KID").ToString())) %>' Text='<%# Eval("KID").ToString()%>'> </asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>                                               
                                             <asp:TemplateField HeaderText="Current Status">
                                                <ItemTemplate>
                                                   <a href="KYA-form.aspx" class="approve"><i class="bi bi-eye-fill text-white"></i></a>                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                               
                                            </Columns>            

					<EmptyDataTemplate>
                                            No Record Available
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                    </div>
                    <div class="row">
                        <div class="col-md-6"><h4>Approved Requests</h4></div>
                        <div class="col-md-6 text-end">
                            <asp:Button ID="btnXport2XLApproved" class="approve" runat="server" Text="Export to Excel" OnClick="btnXport2XLApproved_Click" />
                            <!--<input type="button" id="btnApproved" class="approve" value="Print" onclick="PrintGridDataApproved()" />-->
                        </div>
                    </div>
                    <div class="table-responsive pt-4">
                        
                      <%--  <table class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>S.No.</th>
                                    <th>Allotment Id</th>
                                    <th>Name of Allottee</th>
                                    <th>Regional Office</th>
                                    <th>Industrial Area</th>
                                    <th>Plot No </th>
                                    <th>Email Id</th>
                                    <th>Mobile No</th>
                                    <th>GST Registration Status</th>
                                    <th>GST Registration No</th>
                                    <th>Date of GST Registration</th>
                                    <th>PAN</th>
                                    <th>Aadhar Card</th>
                                    <th>Remark</th>
                                    <th>View</th>
                                </tr>
                            </thead>
                            <tbody>

                                <tr>
                                    <td>1.</td>
                                    <td>RAG\3153</td>
                                    <td>M/s. Gyan Agri Products</td>
                                    <td>Agra</td>
                                    <td>Bhogaon</td>
                                    <td>35 Acres UD Land</td>
                                    <td>gyanagri.prod@gmail.com</td>
                                    <td>9457332292</td>
                                    <td>Yes</td>
                                    <td>4795-96/SIDC/RMA/UD</td>
                                    <td>01/01/1900</td>
                                    <td>ROKH38945733229</td>
                                    <td>94573322924546456</td>
                                    <td>Remark</td>
                                    <td><a href="KYA-form.aspx" class="approve"><i class="bi bi-eye-fill text-white"></i></a></td>
                                </tr>
                            </tbody>
                        </table>--%>

                        <asp:GridView ID="GridKYAApproved" runat="server" AutoGenerateColumns="false" AllowPaging="true" class="mGrid2" OnPageIndexChanging="GridKYAApproved_PageIndexChanging">
                            
                                           <Columns>
                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerNo" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                                 
                                                <asp:BoundField DataField="AllotmentLetterNo" HeaderText="Allotment Id" />
                                                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                                                <asp:BoundField DataField="RegionalOffice" HeaderText="Regional Office" />
                                                <asp:BoundField DataField="IndustrialArea" HeaderText="Plolt No" />
                                                <asp:BoundField DataField="PloltNo" HeaderText="Industrial Area" />
                                                <asp:BoundField DataField="PhoneNo" HeaderText="Mobile No" />
                                                <asp:BoundField DataField="EmailID" HeaderText="Email-Id" /> 
                                                <asp:BoundField DataField="Remark" HeaderText="Remark" />
                                               
                                               <%-- <asp:TemplateField HeaderText="Grievance-Id" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:HyperLink runat="server" ID="hlnkView"  NavigateUrl='<%# string.Format("grievance-details.aspx?Grievance_Ref_ID={0}",HttpUtility.UrlEncode(Eval("KID").ToString())) %>' Text='<%# Eval("KID").ToString()%>'> </asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>                                               

                                               
                                            </Columns>            

					<EmptyDataTemplate>
                                            No Record Available
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                    </div>

                    <div class="row">
                        <div class="col-md-6"><h4>Rejected Requests</h4></div>
                        <div class="col-md-6 text-end">
                            <asp:Button ID="btnXport2XLRejected" class="approve" runat="server" Text="Export to Excel" OnClick="btnXport2XLRejected_Click" />
                            <!--<input type="button" id="btnRejected" class="approve" value="Print" onclick="PrintGridDataRejected()" />-->
                        </div>
                    </div>
                    <div class="table-responsive pt-4">
                    

                            
                        
                        
                        
                         
                       <%-- <table class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>S.No.</th>
                                    <th>Allotment Id</th>
                                    <th>Name of Allottee</th>
                                    <th>Regional Office</th>
                                    <th>Industrial Area</th>
                                    <th>Plot No </th>
                                    <th>Email Id</th>
                                    <th>Mobile No</th>
                                    <th>GST Registration Status</th>
                                    <th>GST Registration No</th>
                                    <th>Date of GST Registration</th>
                                    <th>PAN</th>
                                    <th>Aadhar Card</th>
                                    <th>Remark</th>
                                    <th>View</th>
                                </tr>
                            </thead>
                            <tbody>
                                
                                <tr>
                                    <td>1.</td>
                                    <td>RAG\3153</td>
                                    <td>M/s. Gyan Agri Products</td>
                                    <td>Agra</td>
                                    <td>Bhogaon</td>
                                    <td>35 Acres UD Land</td>
                                    <td>gyanagri.prod@gmail.com</td>
                                    <td>9457332292</td>
                                    <td>Yes</td>
                                    <td>4795-96/SIDC/RMA/UD</td>
                                    <td>01/01/1900</td>
                                    <td>ROKH38945733229</td>
                                    <td>94573322924546456</td>
                                    <td>Remark</td>
                                    <td><a href="KYA-form.aspx" class="approve"><i class="bi bi-eye-fill text-white"></i></a></td>
                                </tr>
                            </tbody>
                        </table>--%>

                        <asp:GridView ID="GridKYARejected" runat="server" AutoGenerateColumns="false" AllowPaging="true" class="mGrid2" OnPageIndexChanging="GridKYARejected_PageIndexChanging">
                                        <Columns>

                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSerNo" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="AllotmentLetterNo" HeaderText="Allotment Id" />
                                                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                                                <asp:BoundField DataField="RegionalOffice" HeaderText="Regional Office" />
                                                <asp:BoundField DataField="IndustrialArea" HeaderText="Plolt No" />
                                                <asp:BoundField DataField="PloltNo" HeaderText="Industrial Area" />
                                                <asp:BoundField DataField="PhoneNo" HeaderText="Mobile No" />
                                                <asp:BoundField DataField="EmailID" HeaderText="Email-Id" /> 
                                                <asp:BoundField DataField="Remark" HeaderText="Remark" />
                                            
                                            <%--<asp:Label ID="lblCSt" runat="server" Text="<%# Eval("")%>"> </asp:Label>--
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:BoundField DataField="Company_Name" HeaderText="Company Name" />
                                            <asp:BoundField DataField="Mobile_No" HeaderText="Mobile No" />
                                            <asp:BoundField DataField="Email_ID" HeaderText="Email-Id" />

                                            <asp:BoundField DataField="Grievance_Type" HeaderText="Grievance Type" />
                                            <asp:BoundField DataField="Regional_Office" HeaderText="Regional Office" />
                                           <%--<asp:DynamicField DataField="CurrentStatus" HeaderText="Current Status" />-- 
                                            <asp:BoundField DataField="CurrentStatus" HeaderText="Current Status" />%>

                                            <%--<asp:TemplateField HeaderText="Current Status">
                                                <ItemTemplate>
                                                   <a href="KYA-form.aspx" class="approve"><i class="bi bi-eye-fill text-white"></i></a> 
                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
					<EmptyDataTemplate>
                                            No Record Available
                                        </EmptyDataTemplate>
                                    </asp:GridView>

                    </div>
                </div>

            </div>
        </section>
    </main>
</asp:Content>
