<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OTSGrievancesMIS.aspx.cs" Inherits="UpsidaAllottee.OTSGrievancesMIS" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <style>
        .request-table tr th {
            font-size: 12px;
            background-color: #006699 !important;
            color:white;
        }
        .DaysRemaining{
            color:green;
            text-align:center;
        }
        .Red{
            color:red;
        }
        .Green{
            color:green;
        }
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
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
                </div>
        <div class="clearfix"></div>
      <nav class="navbar navbar-inverse navbar-dark bg-dark" style="background-color:#006699;">
                             <div class="container-fluid">
         
          <%--<div id="navbar" class="navbar-collapse collapse">--%>
            <ul class="nav navbar-nav nav-tabs" role="tablist">
                <li role="presentation" ><a href="/UpdateAllotmentDetails.aspx" ><b>Interest Rate</b></a></li>
                <%--<li role="presentation"><a href="#"><b>Balance Premium</b></a></li>--%>
                <%--<li role="presentation" ><a href="/OTSGrievances.aspx"><b>OTS Grievances</b></a></li>--%>
                <li role="presentation" ><a href="/OTSGrievancesMIS.aspx"><b>OTS Grievances MIS</b></a></li>
                <li role="presentation" ><a href="/OTSDashboard.aspx"><b>OTS Dashboard</b></a></li>
                <li role="presentation" class="active"><a href="/OTSAllotteeLedgerSummary.aspx"><b>Allottee Ledger Summary</b></a></li>
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
           </nav>  
        <div class="row" id="SideDiv" style="padding-top: 30px; padding-bottom: 30px; margin-top: 0px;">

            <div class="col-md-12 col-sm-12 col-xs-12" style="margin-bottom: 10px; font-size: 16px">
                <div style="background: #ececec; margin-top: 0px; padding: 10px 0;">

                    <div class="row" style="padding-left: 30px; padding-bottom: 30px; padding-right: 30px; text-align: center">
                        <div class="col-md-2 col-lg-2 col-sm-4">
                            <div class="row" style="padding-left: 10px">
                                <div class="col text-center" style="font-size:14px!important">
                                   <%-- <span style="color: Red;font-size:14px!important">*</span>--%>
                                    Regional Office
                                </div>
                                <div class="col">
                                    <asp:DropDownList ID="dlRO" runat="server" CssClass="chosen input-sm similar-select1 margin-left-z" AutoPostBack="true" OnSelectedIndexChanged="dlRO_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-2 col-lg-2 col-sm-4">
                            <div class="row" style="padding-left: 10px">
                                <div class="col text-center" style="font-size:14px!important">
                                    <%--<span style="color: Red">*</span>--%>
                                    Industrial Area
                                </div>
                                <div class="col">
                                    <asp:DropDownList ID="DlIA" runat="server" AutoPostBack="true" CssClass="chosen input-sm similar-select1 margin-left-z" OnSelectedIndexChanged="DlIA_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-2 col-lg-2 col-sm-4">
                            <div class="row" style="padding-left: 10px">
                                <div class="col text-center" style="font-size:14px!important">
                                   <%-- <span style="color: Red">*</span> --%>Plot Number
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged" CssClass="chosen input-sm similar-select1 margin-left-z" Font-Size="small"></asp:TextBox>
                                    
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-lg-2 col-sm-4">
                            <div class="row" style="padding-left: 10px">
                                <div class="col text-center" style="font-size:14px!important">
                                    <%--<span style="color: Red">*</span>--%> Plot Size</div>c
                                <div class="col">
                                    <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="true" OnTextChanged="GetListSearchByComplaintID" CssClass=" chosen input-sm similar-select1 margin-left-z" Font-Size="small"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-lg-2 col-sm-4">
                            <div class="row" style="padding-left: 10px">
                                <div class="col text-center">
                                    &nbsp;
                                </div>
                                <div class="col">
                                    <asp:Button ID="btnSave" runat="server" Text="DOWNLOAD XLS" class="btn btn-info btn-sm" OnClick="ExportExcel" />
                                </div>
                            </div>
                        </div>
                    </div>
                  <div>
                       
                  <div class="table-responsive" style="overflow-y: auto;  max-height: 390px;">
                      <asp:GridView ID="Grid_OTSscheme" runat="server" BackColor="#ffe6e6"
                          CssClass="table table-striped table-bordered table-hover request-table "
                          ClientIDMode="Static"
                          AllowSorting="True"
                          AutoGenerateColumns="False"
                          DataKeyNames="ComplaintID"
                          GridLines="Horizontal"
                          OnRowDataBound="Grid_OTSscheme_RowDataBound"
                          OnRowCommand="Grid_OTSschem_RowCommand"
                          OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                          Width="100%"
                          AllowPaging="true"
                          PageSize="20"
                          OnPageIndexChanging="OnPageIndexChanging"
                          PagerStyle-CssClass="pagination-ys"
                          PagerStyle-HorizontalAlign="Right">
                          <HeaderStyle 
                                BackColor="Crimson" 
                                Font-Italic="false" 
                                ForeColor="Snow" 
                            />
                          <Columns>
                              <asp:TemplateField HeaderText="S.No." HeaderStyle-HorizontalAlign="Center">
                                  <ItemTemplate>
                                      <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                      </asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                  <ItemTemplate>
                                      <asp:HyperLink ID="hlnkView" Visible="true" Text="View" runat="server"></asp:HyperLink>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:BoundField DataField="ComplaintID" HeaderText="Complaint ID"  />
                              <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                              <asp:BoundField DataField="PlotNo" HeaderText="Plot Number" />
                              <asp:BoundField DataField="ComplaintDescription" HeaderText="Complaint Description"  />
                               <asp:TemplateField HeaderText="Days Remaining" HeaderStyle-CssClass="text-center-imp" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                  <ItemTemplate>
                                      <asp:HiddenField ID="DaysStatus" runat="server" Value='<%# Eval("DaysStatus").ToString()%>' />

                                      <asp:Label ID="IsPositive" runat="server" Text='<%# Eval("DaysLeft").ToString()%>' CssClass='<%# (Eval("DaysStatus").ToString())=="False" ? "Red"  : "Green" %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:BoundField DataField="Status" HeaderText="Status"  />
                              <asp:TemplateField>
                                <HeaderStyle />
                                <HeaderTemplate>
                                    <asp:Label ID="hlblimg" runat="server" Text="Document"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbView"     runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument"  usesubmitbehavior="true" Text='<i class="fa fa-download" aria-hidden="true"></i>' /> / 
                                    <asp:LinkButton ID="lbView1"    runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument"  usesubmitbehavior="true"   Text =''><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton> / 
                                   <%-- <asp:LinkButton ID="lbDelete"   runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="Delete"      OnClientClick="javascript:return confirm('Are you sure wanted to delete?');"  usesubmitbehavior="true"    Text='<i class="fa fa-times" aria-hidden="true"></i>' />--%>
                           
                                    </ItemTemplate>
                            </asp:TemplateField>
                          </Columns>
                          <EmptyDataTemplate>
                              No Record Available
                          </EmptyDataTemplate>
                          <FooterStyle BackColor="White" ForeColor="#000066" />
                          <%--//<HeaderStyle Font-Bold="True" ForeColor="Black" BackColor="#003399" />--%>
                          <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                          <RowStyle ForeColor="#000066" />
                          <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                          <SortedAscendingCellStyle BackColor="#F1F1F1" />
                          <SortedAscendingHeaderStyle BackColor="#007DBB" />
                          <SortedDescendingCellStyle BackColor="#CAC9C9" />
                          <SortedDescendingHeaderStyle BackColor="#00547E" />
                      </asp:GridView>
                  </div>

                      <div class="table-responsive" style="overflow-y: auto; max-height: 390px;">
                  </div>
                  <div class="clearfix"></div>
              <%--</asp:View>--%>
                      
                    </div>
                </div>
            </div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </form>

    <%-- <script type="text/javascript">
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
   --%>
</body>
</html>
