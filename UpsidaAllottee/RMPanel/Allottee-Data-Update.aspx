<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/RM.Master" AutoEventWireup="true" CodeBehind="Allottee-Data-Update.aspx.cs" Inherits="UpsidaAllottee.RMPanel.Allottee_Data_Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
 
 <style>
         .hide-modal {
             display: none;
         }

     </style>
    <script>function show1() {
    document.getElementById('industrial').style.display = 'none';
}
        function show2() {
            document.getElementById('industrial').style.display = 'block';
        }
        //-----------------------------
        function openModal() {
            // alert("HI");
            //$('#ExtralargeModal').modal('show');
            $("#ExtralargeModal").modal('show');
        }
    </script>
    <style>
         .validation-error {
             display: none;
         }
         /*.reject{
             display:block;
         }*/
     </style>
    <script>
        function show2() {
            document.getElementById('missing-info').style.display = 'block';
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
    <main id="main" class="main">
        <section class="section dashboard">
            <div class="card info-card sales-card">
                <div class="container-fluid recent-sales">
                    <div class="row">
                        <div class="nine">
                            <h1>Update Information <span>Updated Records</span></h1>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4 col-md-4">
                            <div class="row">
                                <div class="col-lg-6 col-md-6">
                                    <p class="col-form-label"><span style="color: Red">*</span> Regional Office</p>
                                </div>
                                <div class="col-lg-6 col-md-6">
                               <asp:DropDownList ID="dlRO" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="dlRO_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                      <div class="col-lg-4 col-md-4">
                            <div class="row">
                                <div class="col-lg-6 col-md-6">
                                    <p class="col-form-label"><span style="color: Red">*</span> Industrial Area</p>
                                </div>
                                <div class="col-lg-6 col-md-6">
                                    <asp:DropDownList ID="ddlIA" runat="server" CssClass="form-select" ></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4">
                            <div class="row">
                               <%-- <div class="col-lg-5 col-md-5">
                                    <p class="col-form-label"><span style="color: Red">*</span> Plot Number</p>
                                </div>--%>
                                <div class="col-lg-7 col-md-7">
                                    <div class="row">
                                        <%--<div class="col-lg-7 col-md-7">
                                            <input type="text" class="form-control" />
                                        </div>--%>
                                         <div class="col-lg-5 col-md-5">
                                              
                                             <asp:Button ID="btnSearch" runat="server" CssClass="save" Text="Search" OnClick="btnSearch_Click" />

                                         </div>
                                    
                                   <%-- <select class="form-select">
                                        <option selected="selected" value="-1">--Select --</option>
                                        <option value="1">AGRA </option>
                                        <option value="1">ALIGARH </option>
                                        <option value="1">AYODHYA </option>
                                        <option value="1">BAREILLY </option>
                                        <option value="1">GHAZIABAD </option>
                                    </select>--%>
                                        </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive mt-4" style="overflow-y: auto; max-height: 590px;">
                         

                       
                        <asp:GridView ID="GridView1" runat="server"  
                            CssClass="mGrid2"
                            ClientIDMode="Static"
                            AllowSorting="True"
                            AutoGenerateColumns="False"
                            DataKeyNames="Allotmentletterno"
                            GridLines="Horizontal"
                           >

                            <Columns>


                                <asp:TemplateField ItemStyle-Width="20px" HeaderText="SR.NO.">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" runat="server" Text='<%# Container.DataItemIndex + 1 %>' />
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                        <asp:BoundField  DataField="IAName" HeaderText="IA Name" HtmlEncode="true" >
                        <ItemStyle  />
                        </asp:BoundField>
                        <asp:BoundField  DataField="AllotteeName" HeaderText="Allottee Name" HtmlEncode="true" >
                        <ItemStyle  />
                        </asp:BoundField>
                        <asp:BoundField  DataField="Allotmentletterno" HeaderText="Allotment Letter No" HtmlEncode="true" >
                        <ItemStyle  />
                        </asp:BoundField>
                       <%-- <asp:BoundField  DataField="DateofAllotmentNo" HeaderText="Dateof Allotment No" DataFormatString="{0:MM-dd-yyyy}" HtmlEncode="true" >
                        <ItemStyle  />
                        </asp:BoundField>--%>
                        <%--<asp:BoundField ItemStyle-Width="80px" DataField="AllotteeID" HeaderText="Allottee ID" HtmlEncode="true" />--%>
                        
                        <asp:BoundField  DataField="PlotNo" HeaderText="Plot No." HtmlEncode="true" >
                        <ItemStyle  />
                        </asp:BoundField>
                        <asp:BoundField  DataField="emailID" HeaderText="Email ID" HtmlEncode="true" >
                        <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField  DataField="PhoneNo" HeaderText="Phone No." HtmlEncode="true" >
                        <ItemStyle  />
                        </asp:BoundField>
                        <%--<asp:BoundField  DataField="InterestRateApplicable" HeaderText="Interest Rate Applicable" HtmlEncode="true" >
                        <ItemStyle  />
                        </asp:BoundField>--%>
                       <%-- <asp:BoundField  DataField="Status" HeaderText="Status" HtmlEncode="true" >
                        
                        <ItemStyle  />
                        </asp:BoundField>--%>
                        
                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" ToolTip="Edit Details"  CssClass="save" Text="Edit" OnClick="Edit" runat="server"></asp:LinkButton>
                                <%--<asp:Button ID="Button" ToolTip="Edit Details"  CssClass="save" Text="Edit" OnClick="Edit" CauseValidation="false" runat="server"></asp:Button>--%>

                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center" />

                        </asp:TemplateField>
                        
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
    <%--  poup modlal box Start--%>
    <div class="modal fade" id="ExtralargeModal" tabindex="-1">
         <div class="modal-dialog popup-update-info modale-design">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<h5 class="modal-title"> </h5>--%>
                    <div class="">
                    </div>
                    <div class="close-hearbar">
                        <button type="button" class="popup-close-btn" data-bs-dismiss="modal" aria-label="Close"><i class="bi bi-x"></i></button>
                    </div>

                </div>
               <div id="missing-info" class="validation-error">
                 <p class="reject"> <asp:Label ID="lblmsg" runat="server" CssClass="form-control" ></asp:Label></p>
                   </div>
                <div class="modal-body">
                      <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                        <label class="col-form-label">Allottee Name</label>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                         
                                        <asp:Label ID="lblAName" runat="server" CssClass="popup-model-span-lable" ></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                         <label class="col-form-label">Allotment Letter No</label>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                        <asp:Label ID="lblALetterNo" runat="server" CssClass="popup-model-span-lable" ></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                        <label class="col-form-label">Email Id</label>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                 
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                         <label class="col-form-label">Phone No.</label>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                          <label class="col-form-label">Product Manufactured</label>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                  <asp:DropDownList ID="ddlTypeOfIndustry" runat="server" CssClass="form-select" ></asp:DropDownList>
                                </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                          <label class="col-form-label">Power Units</label>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                      <asp:TextBox ID="txtUnit" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                          <label class="col-form-label">Investment </label>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                        <asp:TextBox ID="txtInvestment" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                  <label class="col-form-label"> Employment details</label>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                        <asp:TextBox ID="txtEmployment" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                  <label class="col-form-label"> Date of Production Start</label>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6 col-sm-12">
                                    <div class="offices">
                                       <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                         <div class="col-md-6">
                               <div id="industrial" class="hide-modal">
                                   <div class="row">
                                       <div class="col-md-6">
                                            <div class="offices">
                                   <%--<label class="col-form-label">Change Date</label>--%>
                                </div></div>
                                        <div class="col-md-6">
                                            <div class="offices">
                                     
                                
                                </div></div>
                                   </div>
                                   
                               </div>
                         </div>
                    </div>
                </div>
                <div class="modal-footer justify-content-center">
                    
                    <asp:Button ID="btnUpdate" runat="server" CssClass="update" Text="Update" OnClick="btnUpdate_Click" />
                    <button type="button" class="cancel" data-bs-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>
      </ContentTemplate>
                             
                            </asp:UpdatePanel>
</asp:Content>
