<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/RM.Master" AutoEventWireup="true" CodeBehind="grievance-details.aspx.cs" Inherits="UpsidaAllottee.RMPanel.grievance_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        
           function MsgAndRedirectRes() {
               alert('Grievance Resolved Successfully!');
               window.location.href = 'Grievance-Redressal.aspx';
           }

           function MsgAndRedirectHO() {
               alert('Grievance forwarded to Head Office!');
               window.location.href = 'Grievance-Redressal.aspx';
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
                            <h1>Pending At You Grievance Details<span>Details of Grievance Summary</span></h1>
                        </div>
                    </div>

                    <div class="row">
                    <asp:Label ID="lblUploadMsg" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="table-responsive">
                       <asp:GridView ID="grdAllotteeDetails" runat="server" AutoGenerateColumns="false" AllowPaging="true" class="mGrid2">
                                        <Columns>

                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSerNo" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:Label ID="lblCSt" runat="server" Text="<%# Eval("")%>"> </asp:Label>--%>
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:BoundField DataField="Company_Name" HeaderText="Company Name" />
                                            <asp:BoundField DataField="Mobile_No" HeaderText="Mobile No" />
                                            <asp:BoundField DataField="Email_ID" HeaderText="Email-Id" />

                                            <asp:BoundField DataField="Grievance_Type" HeaderText="Grievance Type" />
                                            <asp:BoundField DataField="Regional_Office" HeaderText="Regional Office" />
                                           <%--<asp:DynamicField DataField="CurrentStatus" HeaderText="Current Status" />--%> 
                                            <asp:BoundField DataField="CurrentStatus" HeaderText="Current Status" />

                                            <%--<asp:TemplateField HeaderText="Current Status">
                                                <ItemTemplate>
                                                    
                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
					<EmptyDataTemplate>
                                            No Record Available
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                    </div>



                    <div id ="LevelPermission" runat="server">
                    <div class="row mt-2" >
                        <div class="col-md-12 pagetitle">
                            <h1>A. Submit Report </h1>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="card-title">
                                    <label>1.) Upload Report  <span class="text-danger">*</span></label>
                                </div>
                                <div class="uplodaed-file">
                                    <div class="col-md-12">
                                        <div class="input-group">
                                            <div class="custom-file">
 <%--                                               <input type="file" name="" id="" class="form-control" required="required" accept=".doc .docx .pdf" />--%>
                                                <asp:FileUpload  ID="FileUploadReport" runat="server"  CssClass="form-control" required="required" accept=".doc, .docx, .pdf" />
                                            </div>
                                        </div>
                                        <span>File formats(.doc .docx .pdf)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="card-title">
                                    <label>2.) Remarks <span class="text-danger">*</span></label>
                                </div>
                            </div>
                            <div class="table-responsive">
                                 
                                <asp:GridView ID="GridRemarks" runat="server" AutoGenerateColumns="false" AllowPaging="true" class="mGrid2">
                                        <Columns>

                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSerNo" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:Label ID="lblCSt" runat="server" Text="<%# Eval("")%>"> </asp:Label>--%>
                                            <asp:BoundField DataField="CreateDateTime" HeaderText="Date" />
                                            <asp:BoundField DataField="RM_ID" HeaderText="By" />
                                            <asp:BoundField DataField="Remark" HeaderText="Remark" />
                                            
                                        </Columns>
					<EmptyDataTemplate>
                                            No Record Available
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                            </div>
                        </div>
                         <div class="col-md-12">
                                <div class="form-group">
                                    <div class="card-title">
                                        <label>Add Remarks <span class="text-danger">*</span></label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <%--<textarea name="" class="form-control" placeholder="Add Remarks" required="required"></textarea>--%>
                                    <textarea name="comment" id="txtRemarks" runat="server" class="form-control" row="20" placeholder="Remarks" required="required"></textarea>
                                </div>
                            </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="card-title">
                                    <label>3.) Action <span class="text-danger">*</span></label>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                       <asp:RadioButton ID="radioResolve"  GroupName="Action" runat="server"  />
                                        <span>Resolved</span>
                                    </div>
                                    <div class="col-md-3" id="forwardHO" runat="server">
                                          <asp:RadioButton ID="radioForward" GroupName="Action" runat="server"  />
                                        <span>Forward To Head Office</span>
                                    </div>
                                    <%--<div class="col-md-6" id="dvPassport" visible="false" runat="server">
                                        <div class="row">
                                    <div class="col-md-4 text-end mt-2">
                                        <span>Head Office</span>
                                    </div>

                                        
                                    <div  class="col-md-8"  >
                                        
                                         <asp:DropDownList ID="ddlRegOffice" class="form-select" runat="server" >
                                                        </asp:DropDownList>
                                    </div>

                                        </div>
                                        </div>--%>
                                </div>
                                <div class="row m-5">
                                    <div class="col-md-12">
                                        <div class="form-group text-center">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="submit" OnClick="btnSubmit_Click" />
                                           <%-- <input type="submit" name="" value="Submit" class="submit" />--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                        </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
