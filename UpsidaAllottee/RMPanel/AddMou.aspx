<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/RM.Master" AutoEventWireup="true" CodeBehind="AddMou.aspx.cs" Inherits="UpsidaAllottee.RMPanel.AddMou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
         
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main id="main" class="main">
        <section class="section dashboard">
            <div class="card info-card sales-card">
                <div class="container-fluid recent-sales">
                    <div class="row">
                        <div class="nine">
                            <h1>MoU Form<span>Update Mou Details</span></h1>
                        </div>
                    </div>
                    <div class="addmou-form">
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Regional Office</label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                             <asp:DropDownList ID="dlRO" runat="server" CssClass="form-select" ></asp:DropDownList>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                    <label>Intent  Id  </label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                    <%--<input id="Text1" type="text" class="form-control" />--%>
                                    <asp:TextBox ID="txtIntentId" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Company  Name  </label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                   <%-- <input id="Text1" type="text" class="form-control" />--%>
                                     <asp:TextBox ID="txtCompany" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Company Address</label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                    <%--<input id="Text1" type="text" class="form-control" />--%>
                                     <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Office Location (State)  </label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                  <%--  <input id="Text1" type="text" class="form-control" />--%>

                                    <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-select" >
                                        <asp:ListItem>Uttar Pradesh</asp:ListItem>
                                        <asp:ListItem>Arunachal Pradesh</asp:ListItem>
                                         <asp:ListItem>Assam </asp:ListItem>
                                            <asp:ListItem>Bihar </asp:ListItem>
                                            <asp:ListItem>Chhattisgarh </asp:ListItem>
                                            <asp:ListItem>Goa </asp:ListItem>
                                            <asp:ListItem>Gujarat</asp:ListItem>
                                            <asp:ListItem>Haryana </asp:ListItem>
                                            <asp:ListItem>Himachal Pradesh</asp:ListItem>
                                            <asp:ListItem>Jharkhand</asp:ListItem>
                                            <asp:ListItem>Karnataka </asp:ListItem>
                                            <asp:ListItem>Kerala </asp:ListItem>
                                            <asp:ListItem>Madhya Pradesh</asp:ListItem>
                                           <asp:ListItem>Maharashtra </asp:ListItem>
                                           <asp:ListItem>Manipur </asp:ListItem>
                                            <asp:ListItem>Meghalaya</asp:ListItem>
                                            <asp:ListItem>Mizoram</asp:ListItem>
                                           <asp:ListItem>Nagaland </asp:ListItem>
                                           <asp:ListItem>Odisha</asp:ListItem>
                                           <asp:ListItem>Punjab</asp:ListItem>
                                            <asp:ListItem>Rajasthan</asp:ListItem>
                                           <asp:ListItem>Sikkim</asp:ListItem>
                                            <asp:ListItem>Tamil Nadu </asp:ListItem>
                                            <asp:ListItem>Telangana</asp:ListItem>
                                           <asp:ListItem>Tripura </asp:ListItem>                                        
                                           <asp:ListItem>Uttarakhand</asp:ListItem>
                                            <asp:ListItem>West Bengal</asp:ListItem>
                                    </asp:DropDownList>
                                      
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Sector </label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                     <asp:TextBox ID="txtSector" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Investor Name </label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                     <asp:TextBox ID="txtInvestorName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Investor Email Id </label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                    <asp:TextBox ID="txtInvestorEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Investor Designation </label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                    <asp:TextBox ID="txtInvestorDesignation" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Investor Mobile </label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                   <asp:TextBox ID="txtInvestorMobile" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Project Name</label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                   <asp:TextBox ID="txtProjectName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Project Type</label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                     <asp:DropDownList ID="ddlProjectType" runat="server" CssClass="form-select" >
                                       <asp:ListItem>Select</asp:ListItem>                                         
                                       <asp:ListItem>Super Mega</asp:ListItem>
                                       <asp:ListItem>Ultra Mega</asp:ListItem>
                                       <asp:ListItem>Mega</asp:ListItem>
                                       <asp:ListItem>Large</asp:ListItem>
                                       <asp:ListItem>MSME</asp:ListItem>
                                   </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Project Details (Long Text)</label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                    <asp:TextBox ID="txtProjectDetails" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Investment (in Cr.) </label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                     <asp:TextBox ID="txtInvestment" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Employment </label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                    <asp:TextBox ID="txtEmployment" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Preferred Location (District)  </label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                   <asp:TextBox ID="txtPreferredLocation" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Land Availability</label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                    <asp:DropDownList ID="ddlLandAvail" runat="server" CssClass="form-select" >
                                       <asp:ListItem>Select</asp:ListItem>  
                                       <asp:ListItem>New project expansion</asp:ListItem>
                                       <asp:ListItem>Existing land UPSIDA  </asp:ListItem>
                                      </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Current Stage </label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                   <asp:DropDownList ID="ddlCurrentStage" runat="server" CssClass="form-select" >
                                       <asp:ListItem>Select</asp:ListItem> 
                                       <asp:ListItem>Need land</asp:ListItem> 
                                        <%--<option value="1" class="approval1">Need approval</option>--%>
                                        <asp:ListItem>Need approval</asp:ListItem> 
                                        <asp:ListItem>Allotment under process</asp:ListItem> 
                                        <asp:ListItem>Allotment completed</asp:ListItem> 
                                        <asp:ListItem>Lease deed</asp:ListItem> 
                                        <asp:ListItem>Possession </asp:ListItem> 
                                        <asp:ListItem>Construction</asp:ListItem> 
                                       <%-- <option value="1" class="others1">Other</option>--%>
                                        <asp:ListItem>Other</asp:ListItem>
                                     </asp:DropDownList>
                                    <%--<div class="offices">
                                        <input id="Text2" type="text" class="form-control approval2" />

                                        <input id="Text3" type="text" class="form-control others2" />
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                        <%-------------------------------------------------------------------------%>
                        <div class="row mt-2 mb-2">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Support Required From</label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="row offices">

                                    <asp:RadioButtonList ID="RadioButtonList1"  CssClass="form-check-input" runat="server" RepeatDirection="Horizontal" Width="22px">
                                        <asp:ListItem>ATP</asp:ListItem>
                                        <asp:ListItem>Infrastructure</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:RadioButtonList>
                                   <%-- <div class="col-md-3">
                                        <input class="form-check-input" type="radio" name="gridRadios" id="gridRadios1" value="option1"/>
                                        <span class="form-check-label" for="gridRadios1">
                                           ATP
                                        </span>
                                    </div>--%>
                                   
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Details of Support Required</label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                    <asp:TextBox ID="txtSupportReq" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mt-2 mb-2">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Is Land Identified</label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                 <div class="row offices">
                                      <div class="col-md-12">
                                      <asp:RadioButtonList ID="RadioButtonList2"  CssClass="form-check-input" runat="server" RepeatDirection="Horizontal" Width="22px" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                                         
                                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                          </div>
                                    <%--<div class="col-md-3">
                                        <input class="form-check-input" type="radio" name="gridRadios" id="gridRadios4" value="option1" onclick="show2()";  />
                                        <span class="form-check-label" for="gridRadios1">Yes</span>
                                    </div>
                                    <div class="col-md-5">
                                        <input class="form-check-input" type="radio" name="gridRadios" id="gridRadios5" value="option1"  onclick="show1()"; />
                                        <span class="form-check-label" for="gridRadios1">No</span>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div id="industrial" class="hide-modal">
                              <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Select industrial area of land identify</label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                   <%-- <select class="form-select" onchange="showDiv(this)">
                                        <option selected="selected" value="0">--Select --</option>
                                     <option value="1">UPSIDA </option>
                                        <option value="2">Privet Land</option>
                                        <option value="3">Other Government Land</option>
                                    </select>--%>
                                    <asp:DropDownList ID="ddlLandIdentify" runat="server" CssClass="form-select" onchange="showDiv(this);"   >
                                       <asp:ListItem>Select</asp:ListItem> 
                                        <asp:ListItem Value="1">UPSIDA </asp:ListItem>
                                        <asp:ListItem Value="2">Privet Land</asp:ListItem>
                                        <asp:ListItem Value="3">Other Government Land</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                              </div>
                        </div>
                        <%--   droupdown selection land identifeiy  Start--%>
                        <div class="row">
                        <div id="hidden_div1" style="display:none;">
                            <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Regional Office </label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                   <asp:DropDownList ID="ddlRO2" runat="server" CssClass="form-select" >

                   </asp:DropDownList>

                                   <%--<select class="form-select">
                                    <option selected="selected" value="-1">--Select All--</option>
                                    <option value="1">AGRA </option>
                                    <option value="1">ALIGARH </option>
                                    <option value="1">AYODHYA </option>
                                    <option value="1">BAREILLY </option>
                                    <option value="1">GHAZIABAD </option>
                                    <option value="1">GNEPIP </option>
                                    <option value="1">GORAKHPUR</option>
                                    <option value="1">JHANSI </option>
                                    <option value="1">KANPUR</option>
                                    <option value="1">LUCKNOW</option>
                                    <option value="1">MEERUT </option>
                                    <option value="1">PRAYAGRAJ </option>
                                    <option value="1">SEZ MORADABAD </option>
                                    <option value="1">SURAJPUR </option>
                                    <option value="1">VARANASI </option>
                                    <option value="1">PO TDS CITY</option>
                                    <option value="1">PO TRANS GANGA</option>
                                </select>--%>
                                </div>
                            </div>
                        </div>
                              <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Industrial Area</label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                  
                                       <asp:DropDownList ID="ddlIndustrialArea" runat="server" CssClass="form-select" >
                                       <asp:ListItem>Select</asp:ListItem>
                                   <asp:ListItem>EPIP Agra</asp:ListItem>
                                   <asp:ListItem>	Foundry Nagar</asp:ListItem>
                                   <asp:ListItem>	Sikandara A </asp:ListItem>
                                   <asp:ListItem>Sikandara C </asp:ListItem>
                                    <asp:ListItem>Leather Park, Agra </asp:ListItem>
                                    <asp:ListItem>Kosi Kalan </asp:ListItem>
                                    </asp:DropDownList>
                            <%--   <select class="form-select">
                                       <option selected="selected" value="-1">--Select All--</option>
                                    <option value="1">EPIP Agra </option>
                                    <option value="1">	Foundry Nagar </option>
                                    <option value="1">	Sikandara A </option>
                                    <option value="1">Sikandara C </option>
                                    <option value="1">Leather Park, Agra </option>
                                    <option value="1">Kosi Kalan </option>
                                </select>--%>
                                </div>
                            </div>
                        </div>
                             <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Plot No</label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                   <%--<select class="form-select">--%>
                                       <asp:DropDownList ID="ddlPlot" runat="server" CssClass="form-select" >
                                       <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>EPIP Agra </asp:ListItem>
                                   <asp:ListItem>Foundry Nagar </asp:ListItem>
                                    <asp:ListItem>Sikandara A </asp:ListItem>
                                    <asp:ListItem>Sikandara C </asp:ListItem>
                                   <asp:ListItem>Leather Park, Agra </asp:ListItem>
                                    <asp:ListItem>Kosi Kalan </asp:ListItem>
                                           </asp:DropDownList>
                                    <%--<option selected="selected" value="-1">--Select All--</option>
                                    <option value="1">EPIP Agra </option>
                                    <option value="1">	Foundry Nagar </option>
                                    <option value="1">	Sikandara A </option>
                                    <option value="1">Sikandara C </option>
                                    <option value="1">Leather Park, Agra </option>
                                    <option value="1">Kosi Kalan </option>
                                </select>--%>
                                </div>
                            </div>
                        </div>
                        </div>
                         <div id="hidden_div2" style="display:none;">
                             <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Plot No or Gov Land </label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                   <%-- <input id="Text30" type="text" placeholder="Enter plot details" class="form-control"/>--%>
                                    <asp:TextBox ID="txtGovLand" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         </div>
                        <div id="hidden_div3" style="display:none;"> <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Plot No or Gov Land </label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">
                                    <%--<input id="Text30" type="text" placeholder="Enter plot details" class="form-control"/>--%>
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div></div>
                        </div>
                        <%--   droupdown selection land identifeiy  Start--%>


                        <%-------------------------------------------------------------------------%>
                       
                        <%-- <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="">
                                    <label>Last follow up taken on</label>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-12">
                                <div class="offices">                                  
                                     <asp:TextBox ID="txtFollowup" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>--%>

                        <div class="row m-4">
                            <div class="col-md-12 col-lg-12 col-sm-12 text-center">
                                <div class="">
                                    <%--<button class=" submit">Submit</button>
                                    --%>
                                   
                                    <asp:Button ID="btnSubmit" CssClass=" submit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         <%--   droupdown selection land identifeiy javascript Start--%>
            <script type="text/javascript">
                function showDiv(select) {
                    if (select.value == 1) {
                        document.getElementById('hidden_div1').style.display = "block";
                    } else {
                        document.getElementById('hidden_div1').style.display = "none";
                    }
                    if (select.value == 2) {
                        document.getElementById('hidden_div2').style.display = "block";
                    } else {
                        document.getElementById('hidden_div2').style.display = "none";
                    }
                    if (select.value == 3) {
                        document.getElementById('hidden_div3').style.display = "block";
                    } else {
                        document.getElementById('hidden_div3').style.display = "none";
                    }
                }
                 </script>
             <%--   droupdown selection land identifeiy javascript End--%>
        </section>
    </main>

</asp:Content>
