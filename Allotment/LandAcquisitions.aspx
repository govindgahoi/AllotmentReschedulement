<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandAcquisitions.aspx.cs" Inherits="Allotment.LandAcquisitions" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/Main.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="/css/datepicker.css" rel="stylesheet" type="text/css" />
    
    <link href="css/ajax-jquery-ui.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />

    <script src="js/ajax-jquery-min.js"></script>
    <script src="js/ajax-jquery-ui.js"></script>
    
    <script src="js/jquery-1.11.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="assets/js/bootstrap-datepicker.min.js"></script>
     <script type="text/javascript">
         function isDecimalKey(evt) {
             var charCode = (evt.which) ? evt.which : evt.keyCode
             if (charCode != 46 && charCode > 31
                 && (charCode < 48 || charCode > 57)) {
                 return false;
             } else {
             }
         }
         </script>
    <style type="text/css">
        #GridView1 tr:nth-child(1) td{
        font-weight:600;
        font-size: 14px;
    }
        ##GridView1_ddlIANameNew {
            margin-left: 0;
            width: 127px;
        }
        #GridView1 tr th {
            text-align: center;
        }
        #GridView1 tr td {
            text-align: left;
        }
        #GridView1 .mygridinput {
            margin-left:0;
            width:70px;
        }
        #GridView1 input.date{            
            width:142px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

                <cc1:MessageBox ID="MessageBox1" runat="server" />
                <cc1:ConfirmBox ID="ConfirmBox1" runat="server" />
                <div class="container-fluid">
                    <div class="row">
                        <div>
                            <div class="navbar-header pull-left project-mymgt">

                                <div class="col-md-7">
                                    <a href="Default.aspx" class="navbar-brand project-mgt">
                                        <img style="height: 65px;" class="img-responsive" src="images/activity-tracker-land-aquisition.png" />
                                    </a>
                                </div>
                                <div class="col-md-5">
                                    <img class="img-responsive top-rt-logo pull-right" src="images/image4.png" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" id="SideDiv">
                        <div class="col-md-12">
                            <div class="">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="panel">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-5">
                                                        <ul class="list-inline master-nav-icons">
                                                            <li style="display: none;">
                                                                <a data-toggle="modal" id="signin" runat="server" data-target="#myModal1">
                                                                    <i class="fa fa-sign-in" aria-hidden="true"></i>
                                                                    <br />
                                                                    Sign In
                                                                </a>
                                                                <asp:LinkButton OnClick="signout_Click" Visible="false" runat="server" ID="signout">
                                                            <i class="fa fa-sign-out" aria-hidden="true"></i></i><br />Sign Out
                                                                </asp:LinkButton>

                                                            </li>
                                                             <li>
                                                                <a style="color: #21202080 !important;">
                                                                    <i class="fa fa-folder" aria-hidden="true"></i>
                                                                    <br />
                                                                    New Project
                                                                </a>
                                                            </li>
                                                            <li>
                                                                <a style="color: #21202080 !important;">
                                                                    <i class="fa fa-folder-open" aria-hidden="true"></i>
                                                                    <br />
                                                                    Open Project
                                                                </a>
                                                            </li>

                                                            <li>
                                                                <a style="color: #21202080 !important;">
                                                                    <i class="fa fa-bar-chart" aria-hidden="true"></i>
                                                                    <br />
                                                                    Gantt Chart
                                                                </a>
                                                            </li>


                                                            <li visible="false" runat="server" id="activity_add">
                                                                <a data-toggle="modal" data-target="#Action">
                                                                    <i class="fa fa-plus" aria-hidden="true"></i>
                                                                    <br />
                                                                    New Activity
                                                                </a>
                                                            </li>
                                                            <li visible="false" runat="server" id="group_add">
                                                                <a data-toggle="modal" data-target="#myModal">
                                                                    <i class="fa fa-ticket" aria-hidden="true"></i>
                                                                    <br />
                                                                    New Group
                                                                </a>
                                                            </li>
                                                            <li visible="false" runat="server" id="Group_View">
                                                                <a data-toggle="modal" data-target="#ModalViewGroup">
                                                                    <i class="fa fa-eye" aria-hidden="true"></i>
                                                                    <br />
                                                                    View Groups
                                                                </a>
                                                            </li>
                                                            <li visible="false" runat="server" id="Change_Pass">
                                                                <a data-toggle="modal" data-target="#ChangePassModal">
                                                                    <i class="fa fa-eye" aria-hidden="true"></i>
                                                                    <br />
                                                                    Change Pass
                                                                </a>
                                                            </li>

                                                            <li>
                                                                <a href="javascript:window.location.href=window.location.href">
                                                                    <i class="fa fa-refresh" aria-hidden="true"></i>
                                                                    <br />
                                                                    Refresh
                                                                </a>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                    <div class="col-md-3" runat="server" id="Search" style="margin-top:10px;">
                                                        <asp:TextBox ID="txtSearch" CssClass="similar-select" style="height:29px;float:left;" runat="server" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged" />
                                                                <span class="input-group-btn">
                                                                    <button id="btnSearch" class="btn btn-sm btn-primary" type="button"><i class="fa fa-search" style="color: #fff;"></i></button>
                                                                </span>
                                                        <asp:Label ID="Group_lbl" runat="server" Visible="false" ></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel-body">
                                            <asp:Label runat="server" ID="lblmsg"></asp:Label>
                                            <asp:Label ID="lblUserId" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblPass" runat="server" Visible="false"></asp:Label>

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:GridView ID="GridView1" runat="server" CellPadding="0"
                                                        GridLines="None" AutoGenerateColumns="False" ShowFooter="True" CssClass="table table-striped table-bordered table-hover request-table"
                                                        ShowHeaderWhenEmpty="True" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                                                        AllowPaging="false" DataKeyNames="LandacquisitionId" OnRowEditing="GridView1_RowEditing"
                                                        OnPageIndexChanging="GridView1_PageIndexChanging"
                                                        OnRowCreated="GridView1_Merge_Header_RowCreated" OnPreRender="PlantationGrid_PreRender"
                                                        
                                                         PagerStyle-CssClass="pagination-ys"
                                                        OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                                        OnRowUpdating="GridView1_RowUpdating">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="RegionName" HeaderStyle-HorizontalAlign="Left"  InsertVisible="False" ReadOnly="True" HeaderText="Regional Office"  />
                                                           <%-- <asp:BoundField DataField="Industrial Area" HeaderStyle-HorizontalAlign="Left"  HeaderText="Name of Industrial Area" />
                                                             <asp:TemplateField HeaderText="Region Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRegionName" runat="server" Text='<%# Bind("RegionName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderText="Industrial Area" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id")%>' Visible="false" ></asp:Label>
                                                                    <asp:Label ID="lblIAName" runat="server" Text='<%# Bind("IAName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Total Area(In Sqrmt)" HeaderStyle-HorizontalAlign="Left">
                                                                <%--<EditItemTemplate>
                                                                    <asp:TextBox ID="txtTotalArea" class="mygridinput" onkeypress="return isDecimalKey(event);" runat="server" Text='<%# Bind("TotalArea") %>'></asp:TextBox>
                                                                </EditItemTemplate>--%>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTotalArea" runat="server" Text='<%# Eval("TotalArea") %>'></asp:Label>
                                                                </ItemTemplate>
                                                               <%-- <FooterTemplate>
                                                                    <asp:TextBox ID="txtTotalAreaNew" runat="server" Enabled="false"></asp:TextBox>
                                                                </FooterTemplate>--%>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="GramSabha Land(In Sqrmt)" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtGSLand" class="mygridinput" onkeypress="return isDecimalKey(event);" runat="server" Text='<%# Bind("GSLand") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGSLand" runat="server" Text='<%# Eval("GSLand") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <%--<FooterTemplate>
                                                                    <asp:TextBox ID="txtGSLandNew" runat="server" Enabled="false"></asp:TextBox>
                                                                </FooterTemplate>--%>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Govt Land(In Sqrmt)" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtGovtLand" class="mygridinput" onkeypress="return isDecimalKey(event);" runat="server" Text='<%# Bind("GovtLand") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGovtLand" runat="server" Text='<%# Eval("GovtLand") %>'></asp:Label>
                                                                </ItemTemplate>
                                                               <%-- <FooterTemplate>
                                                                    <asp:TextBox ID="txtGovtLandNew" runat="server" Enabled="false"></asp:TextBox>
                                                                </FooterTemplate>--%>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Private Acquired Land(In Sqrmt)" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtPrivateacquisitionLand" class="mygridinput" onkeypress="return isDecimalKey(event);" runat="server" Text='<%# Bind("PrivateacquisitionLand") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPrivateacquisitionLand" runat="server" Text='<%# Eval("PrivateacquisitionLand") %>'></asp:Label>
                                                                </ItemTemplate>
                                                              <%--  <FooterTemplate>
                                                                    <asp:TextBox ID="txtPrivateacquisitionLandNew" runat="server" Enabled="false"></asp:TextBox>
                                                                </FooterTemplate>--%>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Notification Date" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtNotificationDate" class="mygridinput" CssClass="date input-sm similar-select1" runat="server" Text='<%# Eval("NotificationDate","{0:dd, MMM yyyy}") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNotificationDate" runat="server" Text='<%# Eval("NotificationDate","{0:dd, MMM yyyy}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                               <%-- <FooterTemplate>
                                                                    <asp:TextBox ID="txtNotificationDateNew" CssClass="date input-sm similar-select1" runat="server" Enabled="false"></asp:TextBox>
                                                                </FooterTemplate>--%>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Area(In Sqrmt)" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtAwardArea" class="mygridinput" onkeypress="return isDecimalKey(event);" runat="server" Text='<%# Bind("AwardArea") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAwardArea" runat="server" Text='<%# Eval("AwardArea") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <%--<FooterTemplate>
                                                                    <asp:TextBox ID="txtAwardAreaNew" runat="server" Enabled="false"></asp:TextBox>
                                                                </FooterTemplate>--%>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtAwardDate" class="mygridinput" CssClass="date input-sm similar-select1" runat="server" Text='<%# Eval("AwardDate","{0:dd, MMM yyyy}") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAwardDate" runat="server" Text='<%# Eval("AwardDate","{0:dd, MMM yyyy}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                               <%-- <FooterTemplate>
                                                                    <asp:TextBox ID="txtAwardDateNew" CssClass="date input-sm similar-select1" runat="server" Enabled="false"></asp:TextBox>
                                                                </FooterTemplate>--%>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Area(In Sqrmt)" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtPossessionArea" class="mygridinput" onkeypress="return isDecimalKey(event);" runat="server" Text='<%# Bind("PossessionArea") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPossessionArea" runat="server" Text='<%# Eval("PossessionArea") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <%--<FooterTemplate>
                                                                    <asp:TextBox ID="txtPossessionAreaNew" runat="server" Enabled="false"></asp:TextBox>
                                                                </FooterTemplate>--%>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtPossessionDate" class="mygridinput" CssClass="date input-sm similar-select1" runat="server" Text='<%# Eval("PossessionDate","{0:dd, MMM yyyy}") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPossessionDate" runat="server" Text='<%# Eval("PossessionDate","{0:dd, MMM yyyy}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Expenditure of Land Acquired" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtExpenditureofLA" class="mygridinput" onkeypress="return isDecimalKey(event);"  runat="server" Text='<%# Bind("ExpenditureofLA") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblExpenditureofLA" runat="server" Text='<%# Eval("ExpenditureofLA") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="center" ItemStyle-CssClass="text-center-imp">
                                                                <EditItemTemplate>
                                                                    <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text='<i class="	fa fa-wrench" width="50px" aria-hidden="true"></i>'></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"  Text='<i class="fa fa-remove" width="50px" aria-hidden="true"></i>'></asp:LinkButton>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Visible="false"  CommandArgument='<%# (Container.DataItemIndex) %>' Text='<i class="fa fa-sign-in" width="50px" aria-hidden="true"></i>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-CssClass="text-center-imp">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="center" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="btnDelete" Visible="false"   Text='<i class="fa fa-trash-o" aria-hidden="true"></i>' CommandName="DeleteLandAcquistion" CommandArgument='<%# (Container.DataItemIndex) %>' ToolTip="Click here to Plantation Detail" />
                                                                    </span>  
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <%--<asp:GridView ID="grdContact" runat="server" AutoGenerateColumns="False" DataKeyNames="IAName"
                                                        OnRowCancelingEdit="grdContact_RowCancelingEdit" OnDataBound="grdContact_DataBound" OnRowDataBound="grdContact_RowDataBound"
                                                        OnRowEditing="grdContact_RowEditing" OnRowUpdating="grdContact_RowUpdating"
                                                        OnRowCommand="grdContact_RowCommand" ShowFooter="True" CssClass="table table-striped table-bordered table-hover request-table"
                                                        OnRowDeleting="grdContact_RowDeleting">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="IndustrialArea" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlIAName" runat="server" SelectedValue='<%# Eval("IAName") %>'>
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:DropDownList ID="ddlIANameNew" runat="server">
                                                                    </asp:DropDownList>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIAName" runat="server" Text='<%# Bind("IAName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="TotalArea" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtTotalArea" runat="server" Text='<%# Bind("TotalArea") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTotalArea" runat="server" Text='<%# Eval("TotalArea") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtTotalAreaNew" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="GS Land" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtGSLand" runat="server" Text='<%# Bind("GSLand") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGSLand" runat="server" Text='<%# Eval("GSLand") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtGSLandNew" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Govt Land" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtGovtLand" runat="server" Text='<%# Bind("GovtLand") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGovtLand" runat="server" Text='<%# Eval("GovtLand") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtGovtLandNew" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Private AcquisitionLand" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtPrivateacquisitionLand" runat="server" Text='<%# Bind("PrivateacquisitionLand") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPrivateacquisitionLand" runat="server" Text='<%# Eval("PrivateacquisitionLand") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtPrivateacquisitionLandNew" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Notification Date" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtNotificationDate" runat="server" Text='<%# Bind("NotificationDate") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNotificationDate" runat="server" Text='<%# Eval("NotificationDate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtNotificationDateNew" CssClass="date input-sm similar-select1" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Award Area" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtAwardArea" runat="server" Text='<%# Bind("AwardArea") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAwardArea" runat="server" Text='<%# Eval("AwardArea") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtAwardAreaNew" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Award Date" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtAwardDate" runat="server" Text='<%# Bind("AwardDate") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAwardDate" runat="server" Text='<%# Eval("AwardDate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtAwardDateNew" CssClass="date input-sm similar-select1" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Possession Area" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtPossessionArea" runat="server" Text='<%# Bind("PossessionArea") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPossessionArea" runat="server" Text='<%# Eval("PossessionArea") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtPossessionArea" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Possession Date" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtPossessionDate" runat="server" Text='<%# Bind("PossessionDate") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPossessionDate" runat="server" Text='<%# Eval("PossessionDate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtPossessionDate" CssClass="date input-sm similar-select1" runat="server"></asp:TextBox>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                                                                <EditItemTemplate>
                                                                    <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="False" CommandName="Insert" Text="Insert"></asp:LinkButton>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
                                                        </Columns>
                                                    </asp:GridView>--%>
                                                    <br />
                                                    <br />

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
 
    </form>
    <script language="javascript" type="text/javascript">
        $(".date").datepicker({ changeMonth: true, changeYear: true, format: 'dd M yyyy' });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $(".date").datepicker({ changeMonth: true, changeYear: true, format: 'dd M yyyy' });
        });
    </script>
</body>

</html>
