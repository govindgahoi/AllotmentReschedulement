<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateAllotmentDetails.aspx.cs" Inherits="UpsidaAllottee.UpdateAllotmentDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
   <title>Uttar Pradesh Industrial Development Authority</title>
   <link rel="icon" href="images\upsidclogo.png" />

    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet"/>
    <script src="js/jquery-ui.js"></script>
    <script src="js/chosen.jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>
    
      <style type="text/css">
          .navbar-inverse .navbar-nav > .active > a, .navbar-inverse .navbar-nav > .active > a:focus, .navbar-inverse .navbar-nav > .active > a:hover {
    color: #efefef;
    background-color: #08080861!important;
}
        .mainnavbar {
            height: 38px !important;
        }
        .navbar-nav .dropdown {
    padding: 0px 10px;
    border-radius: 13px 13px 2px 14px;
    background: #08080861;
}
       #gridView{
           /*width:auto !important;*/
       }
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            width: 300px;
            border: 3px solid #0DA9D0;
            border-radius: 12px;
            padding: 0;
        }
        .modalPopup .header
        {
            background-color: #2FBDF1;
            height: 30px;
            color: White;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
            border-top-left-radius: 6px;
            border-top-right-radius: 6px;
        }
        .modalPopup .body
        {
            padding: 10px;
            min-height: 50px;
            text-align: center;
            font-weight: bold;
        }
        .modalPopup .footer
        {
            padding: 6px;
        }
        .modalPopup .yes, .modalPopup .no
        {
            height: 23px;
            color: White;
            line-height: 23px;
            text-align: center;
            font-weight: bold;
            cursor: pointer;
            border-radius: 4px;
        }
        .modalPopup .yes
        {
            background-color: #2FBDF1;
            border: 1px solid #0DA9D0;
        }
        .modalPopup .no
        {
            background-color: #9F9F9F;
            border: 1px solid #5C5C5C;
        }
    
    

        #myBtn {
  display: none;
  position: fixed;
  bottom: 20px;
  right: 1420px;
  z-index: 99;
  font-size: 18px;
  border: none;
  outline: none;
  background-color: red;
  color: white;
  cursor: pointer;
  padding: 15px;
  border-radius: 4px;
}

#myBtn:hover {
  background-color: #555;
}

        @media only screen and (max-width: 992px) {
            .topbtncollapse {
                display:none;
            }
        }
        @media only screen and (min-width: 768px) {
            .content {
                /*padding: 51px 15px 0px 15px;*/
                min-height: 200px;
            }

            .ul-nav-div {
                min-height: 92vh;
                max-height: 92vh;
                overflow-y: auto;
            }

           
        }

        .fgh {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0
        }

        .hgf {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 130px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1
        }

        #line-chart {
            height: 300px;
            width: 800px;
            margin: 0px auto;
            margin-top: 1em;
        }

        .navbar-default .navbar-brand, .navbar-default .navbar-brand:hover {
            color: rgb(45,45,45);
        }

        .sidebar-nav ul li a {
            cursor: pointer;
        }

        @media only screen and (max-width: 768px) {
            .sidebar-nav.sticky {
                /*display: block !important;*/
                position: relative !important;
            }

            #sidebar {
                max-width: 100% !important;
                min-width: 100% !important;
                margin-left: 0 !important;
            }

                #sidebar ul li a i {
                    display: inline !important;
                }

                #sidebar ul li a {
                    padding: 0 20px !important;
                }

                #sidebar ul ul a {
                    color: #fff !important;
                }

                    #sidebar ul ul a:hover {
                        color: #000 !important;
                    }

                    #sidebar ul ul a.currentPage {
                        color: #000 !important;
                    }
        }

        .my-dash-table-status tr td:nth-child(1) {
            text-align: left;
            position: absolute;
            height: 50px;
            width: 11.3em;
            font-size: 12px;
            left: 28px;
        }

        .my-dash-table-status tr th:nth-child(1) {
            text-align: left;
            position: absolute;
            width: 10.3em;
            left: 28px;
        }

        #divsectionrecommendation {
            min-height: 154px;
        }

        #divoperational {
            min-height: 154px;
        }

        #divvalidation {
            min-height: 154px;
        }

        #divregulations {
            min-height: 154px;
        }

        #divcurrentstatus {
            min-height: 154px;
        }

        .status-bar-bottom {
            position: relative;
            background: #f5f5f5;
            bottom: 0;
            /* margin-top: 1px; */
            border: 1px solid #ccc;
            width: 100%;
            margin-bottom: 0;
        }

        .ul-plot-view li {
            border-right: 1px solid #ccc;
            min-width: 257px;
        }
    </style>
</head>
<body>
   
     <form id="form1" runat="server">
         <%-- <div class="row">--%>
             <div class="navbar-header pull-left top-head-bg">
                 <a href="Default.aspx" class="navbar-brand" style="width: 100%;">
                     <div class="col-md-8">
                         <img class="img-responsive" src="images/upsida-logo-name.png" />
                     </div>
                     <div class="col-md-4" style="margin-top: 2px;">
                         <img class="img-responsive" src="images/image4.png" />
                     </div>
                 </a>
             </div>
         <%--</div>--%>
                <div class="clearfix"></div>
            
         <nav class="navbar navbar-inverse navbar-dark" style="background-color:#006699; ">
        <div class="container-fluid">
         
          <%--<div id="navbar" class="navbar-collapse collapse">--%>
            <ul class="nav navbar-nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="/UpdateAllotmentDetails.aspx" ><b>Interest Rate</b></a></li>
                    <%--<li role="presentation"><a href="#"><b>Balance Premium</b></a></li>--%>            <%--<li role="presentation"><a href="/OTSGrievances.aspx"><b>OTS Grievances</b></a></li>--%>
               <%-- <li role="presentation"><a href="/OTSGrievancesMIS.aspx" ><b>OTS Grievances MIS</b></a></li>
                <li role="presentation"><a href="/OTSDashboard.aspx"><b>Dashboard</b></a></li>
                <li role="presentation" class="active"><a href="/OTSAllotteeLedgerSummary.aspx"><b>Allottee Ledger Summary</b></a></li>
                 <li role="presentation"><a href="MOUTrack.aspx"><b>Track MoU</b></a></li>
                    <li role="presentation" class="active"><a href="/KYA-Request.aspx"><b>KYA Approval</b></a></li>--%>
					
					
					
					
					
            </ul>
              <ul class="nav navbar-nav navbar-right">
                  <li class="dropdown">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                          <span style="position: relative; top: 3px;"><b>Welcome </b>
                              <asp:Label ID="lblname" runat="server"></asp:Label></span>
                          <i class="fa fa-caret-down"></i>
                      </a>
                      <ul class="dropdown-menu">
                          <li><a href="./">My Account</a></li>
                          <li class="divider"></li>
                          <li><a tabindex="-1" href="/Default.aspx?logout=true">Logout</a></li>
                      </ul>
                  </li>
              </ul>
            <%--</div><!--/.nav-collapse -->--%>
        </div><!--/.container-fluid -->
      </nav>
           
   <div class="container-fluid">
       <div class="alert alert-danger alert-dismissible" id="warningmsg" runat="server" visible="false">
           <button type="button" class="close" data-dismiss="alert">&times;</button>
           <strong>Warning!</strong> Duplicate Email ID or Phone Number.
       </div>
        <div class="row " style="margin: 20px 0px 20px 0px;">
            <div class="col-md-1 col-sm-12 text-center">
                 </div>
            <div class=" col-md-2 col-lg-2 col-sm-2" style="margin-top: 10px;">
                <span style="color: Red">*</span>
                Industrial Area
            </div>
            <div class="col-md-2 col-lg-2 col-sm-4 col-xs-4 ">
                <asp:DropDownList ID="DlIA" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="DlIA_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <%-- </div>
        <div class="row" style="margin-top: 20px;margin-left:50px">--%>
            <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2 ">
               <span style="color: Red">*</span>
                <asp:Label ID="lblPlotNo" runat="server" Text="Plot Number"></asp:Label>
            </div>
            <div class="col-md-2 col-lg-2 col-sm-4 col-xs-4">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="autosuggest form-control" Font-Size="small"></asp:TextBox>
            </div>
             <div class="col-md-2 col-sm-12 text-center">
                <asp:Button ID="Button1" runat="server" Text="View Detail" CssClass="btn btn-md btn-success" OnClick="GridView_Load" />
            </div>
             <div class="col-md-1 col-sm-12 text-center">
                 </div>
        </div>


       <%-- <div class="row" style="margin-top: 30px; margin-bottom: 20px">
           
        </div>--%>
       
        <hr />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                 <div class="col-md-12 col-lg-12 col-sm-4 col-xs-4">
                <asp:GridView ID="gridView" runat="server"
                    AutoGenerateColumns="False" ShowFooter="True" HeaderStyle-Font-Bold="true"
                    OnRowCancelingEdit="gridView_RowCancelingEdit"
                    OnRowEditing="gridView_RowEditing"
                    OnRowDataBound="gridView_RowDataBound" EmptyDataText="No data found!" ShowHeaderWhenEmpty="True"
                    HorizontalAlign="Center"  CssClass="table table-striped table-bordered table-hover request-table" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Left" Height="25" />
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
                        <asp:BoundField  DataField="DateofAllotmentNo" HeaderText="Dateof Allotment No" DataFormatString="{0:MM-dd-yyyy}" HtmlEncode="true" >
                        <ItemStyle  />
                        </asp:BoundField>
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
                        <asp:BoundField  DataField="InterestRateApplicable" HeaderText="Interest Rate Applicable" HtmlEncode="true" >
                        <ItemStyle  />
                        </asp:BoundField>
                        <asp:BoundField  DataField="Status" HeaderText="Status" HtmlEncode="true" >
                        
                        <ItemStyle  />
                        </asp:BoundField>
                        
                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                                <%--<asp:LinkButton ID="LinkButton2" ToolTip="Edit Details" Text="Edit" OnClick="Edit" runat="server"></asp:LinkButton>--%>
                                <asp:Button ID="Button" ToolTip="Edit Details" Text="Edit" OnClick="Edit" CauseValidation="false" runat="server"></asp:Button>

                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center" />

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Demand" ItemStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                                <%--<asp:LinkButton ID="LinkButton2" ToolTip="Edit Details" Text="Edit" OnClick="Edit" runat="server"></asp:LinkButton>--%>
                                <asp:Button ID="ButtonDemand" ToolTip="Demand Details" Text="Demand" OnClick="Demand" CauseValidation="false" runat="server"></asp:Button>

                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center" />

                        </asp:TemplateField>
                    </Columns>
                        <EmptyDataTemplate>
                        <div style="text-align: center">No records found.</div>
                        </EmptyDataTemplate>
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
                <div>
                    <div>
</div>
                    <div style="margin-left:auto;margin-right:auto;width:100%">
                <asp:Panel ID="pnlAddEdit" runat="server" CssClass="modalPopup" Style="display: block; width:60%;height:60%;padding-top:10px">
                    <div style="text-align:center">
                        <asp:Label Font-Bold="true" ID="Label4" runat="server" Text="UPDATE INFORMATION"></asp:Label>
                    </div>
                    
                    <br />
                    <table id="tblPopup" >
                        <tr style="padding-bottom:15px;display:none">
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Industrial Area"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="txtIAName" CssClass="form-control" Width="280px" runat="server"></asp:TextBox>
                            </td>
                            <%--<td><asp:Label ID="Label8" runat="server" Text="Industrial Area"></asp:Label></td>
                             <td> <asp:TextBox ID="TextBox1" CssClass="form-control" Width="280px" runat="server"></asp:TextBox>

                             </td>--%>
                        </tr>
                        <tr style="padding-bottom:15px">
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Allottee Name"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="txtAllottee" CssClass="form-control" Width="280px" runat="server"></asp:TextBox>
                            </td>
                           <%--<td>
                                <asp:Label ID="Label9" runat="server" Text="Total Cost Of Plot"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="txtTotPCost" CssClass="form-control" Width="280px" runat="server" AutoPostBack="True" OnTextChanged="txtTotPCost_TextChanged">0</asp:TextBox>
                            </td>--%>
                        </tr>
                        <tr style="margin-bottom:15px">
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Plot No."></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPlotNo" CssClass="form-control" Width="280px" runat="server"></asp:TextBox>
                            </td>
                           <%-- <td>
                                <asp:Label ID="Label10" runat="server" Text="Total Cost Paid"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="txtTotPaid" CssClass="form-control" Width="280px" runat="server" AutoPostBack="True" OnTextChanged="txtTotPaid_TextChanged">0</asp:TextBox>
                            </td>--%>
                        </tr>
                        <tr style="margin-bottom:15px">
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="EmailID"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmailID" CssClass="form-control" Width="280px" runat="server"></asp:TextBox>
                            </td>
                           <%--<td>
                                <asp:Label ID="Label15" runat="server" Text="Default Amount"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="txtDAmount" CssClass="form-control" Width="280px" runat="server" AutoPostBack="True" OnTextChanged="txtDAmount_TextChanged">0</asp:TextBox>
                            </td>--%>
                        </tr>
                        <tr style="margin-bottom:15px">
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Phone No."></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhoneNo" CssClass="form-control" Width="280px" runat="server"></asp:TextBox>
                            </td>
                            
                            <%--<td>
                                <asp:Label ID="Label11" runat="server" Text="OutStanding"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="txtOutstanding" CssClass="form-control" Width="280px" Enabled="false" runat="server">0</asp:TextBox>
                            </td>--%>
                            
                        </tr>
                        <tr style="margin-bottom:25px">
                            <td>
                                <asp:Label ID="Label3" runat="server" Width="100px" Text="Interest Rate(%)"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtInterestRate" CssClass="form-control" Width="280px" runat="server"></asp:TextBox>
                            </td>
                            <%--<td>
                                <asp:Label ID="Label16" runat="server" Text="Interest On Default Amount "></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="txtDefaultInt" CssClass="form-control" Width="280px" runat="server">0</asp:TextBox>
                            </td>--%>
                        </tr>
                         <tr style="margin-bottom:25px">
                           <td>
                                <asp:Label ID="Label12" runat="server" Text="Date Of First Allotment"></asp:Label>
                            </td>
                            <td >
                                <%--<asp:DropDownList ID="ddlRebate" runat="server" Width="280px">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Rebate</asp:ListItem>
                                    <asp:ListItem>Panel</asp:ListItem>
                                </asp:DropDownList>--%>
                               <%-- <asp:TextBox ID="TextBox1" CssClass="form-control" Width="280px" runat="server" type="datetime-local" ></asp:TextBox>--%>

                                <asp:TextBox ID="txtFirstAllotment" CssClass="form-control" Width="280px" runat="server" type="date" ></asp:TextBox>
                            </td>
                            
                              <%--<td>
                                <asp:Label ID="Label14" runat="server" Width="100px" Text="Balance No. Of Installment"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBalInstall" CssClass="form-control" Width="280px" runat="server">0</asp:TextBox>
                            </td>--%>
                        </tr>
                         <tr style="margin-bottom:25px">
                           <td>
                                <asp:Label ID="Label13" runat="server" Text="Date Of Transfer "></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="txtTransferDate" CssClass="form-control" Width="280px" runat="server" type="date"></asp:TextBox>
                            </td>
       
                        </tr>
                    </table>
                     <div class="row" style="margin-top:25px;text-align:center">
                                <asp:Button ID="btnSave" runat="server" Text="Update" OnClick = "Save" />&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="return Hidepopup()" />&nbsp;
                               <%-- <asp:Button ID="btnDemand" runat="server" Text="Demand" OnClick = "Demand" />--%>
                        </div>
                </asp:Panel>
                        </div>
                <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
               <cc1:ModalPopupExtender id="popup" runat="server" dropshadow="false"
                    popupcontrolid="pnlAddEdit" targetcontrolid="lnkFake"
                    backgroundcssclass="modalBackground">
                </cc1:ModalPopupExtender>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gridView" />
                <asp:AsyncPostBackTrigger ControlID="btnSave" />
                  <%--<asp:AsyncPostBackTrigger ControlID="txtTotPCost" />--%>
            </Triggers>
        </asp:UpdatePanel>
    </div>
       </form>

    <script type="text/javascript">
        $(document).ready(function () {
            console.log("ready!");
            var userName= 'mayank.mangal';
            //source: function (request, response) {
                $.ajax({
                    type: "POST",
                    //crossDomain: true,
                    dataType: 'json',
                   contentType: "application/json;charset=utf-8",
                        url: '<%=ResolveUrl("~/searchService.asmx/UserDetail") %>',
                    data: "{" +
                        "'UserName':'mayank.mangal'," +
                        "}",
                    //async: false,
                    complete: function (xhr, status) {
                       
                    },
                    success: function (jsondata) {
                        response = jsondata;
                    },
                    error(xhr, status, error) {
                        console.log(status);
                    }
                });
                

            //alert(response);
            //}    //getSessionName();
            });
        
</script>	

    <script type="text/javascript">
        $(document).ready(function () {
            $(".autosuggest").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;charset=utf-8",
                        url: '<%=ResolveUrl("~/searchService.asmx/GetAutoCompleteData") %>',
                        data: "{" +
                        "'txtSearch':'" + request.term + "'," +
                        "'IAName':'" + $('#<%= DlIA.ClientID %>').val() + "'" +
                      
                        "}",
                        dataType: "json",
                        //async:false,
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                //    select: function (e, i) {
                //    $("[id$=hfCustomerId]").val(i.item.val);
                //},
                minLength: 1
            });
        });
        $("input[type=text]").keyup(function () {
            $("#gridView").hide();
            $("#warningmsg").hide();
          
        });

    </script>
    <script type = "text/javascript">
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({
                    message: '<table align = "center"><tr><td>' +
                    '<img src="images/loadingAnim.gif"/></td></tr></table>',
                    css: {},
                    overlayCSS: {
                        backgroundColor: '#000000', opacity: 0.6
                    }
                });
            });
            prm.add_endRequest(function () {
                $("#" + elementID).unblock();
            });
        }
        $(document).ready(function () {

            BlockUI("<%=pnlAddEdit.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function Hidepopup() {
            $find("popup").hide();
            return false;
        }
</script>
</body>

</html>
