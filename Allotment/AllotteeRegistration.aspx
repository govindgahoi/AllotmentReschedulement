<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" Debug="true" CodeBehind="AllotteeRegistration.aspx.cs"
    Inherits="Allotment.Allottee_Registration" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/UC_Allottee_Ledger.ascx" TagPrefix="cc1" TagName="s" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .hideGridColumn {
            display: none;
        }

        #ContentPlaceHolder1_radio1 {
            margin-top: 0;
        }

        @media only screen and (max-width: 992px) {
            .form-group label.text-right {
                text-align: left !important;
            }
        }

        .form-group em span {
            color: #000000 !important;
            font-size: 12px;
            /*font-weight:500;*/
        }

        .panel .allot-heading {
            padding: 0 7px;
            background: -webkit-gradient(linear, left bottom, left top, color-stop(0, #e2e2e2), color-stop(1, #fafafa)) !important;
            background: -ms-linear-gradient(bottom, #e2e2e2, #fafafa) !important;
            background: -moz-linear-gradient(center bottom, #e2e2e2 0%, #fafafa 100%) !important;
            background: -o-linear-gradient(bottom, #e2e2e2, #fafafa) !important;
            filter: progid:dximagetransform.microsoft.gradient(startColorStr='#e3e3e3', EndColorStr='#ffffff') !important;
        }

            .panel .allot-heading:not(.no-collapse):hover {
                background: -webkit-gradient(linear, left bottom, left top, color-stop(0, #efefef), color-stop(1, #fafafa));
                background: -ms-linear-gradient(bottom, #efefef, #fafafa);
                background: -moz-linear-gradient(center bottom, #efefef 0%, #fafafa 100%);
                background: -o-linear-gradient(bottom, #efefef, #fafafa);
                filter: progid:dximagetransform.microsoft.gradient(startColorStr='#e3e3e3', EndColorStr='#ffffff');
                -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorStr='#fafafa',EndColorStr='#efefef')";
                box-shadow: inset 0px 1px 1px white;
            }
    </style>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.2.2/css/buttons.dataTables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>


    <%--<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
            <asp:PostBackTrigger ControlID="btnUploadLeaseDeed" />
            <asp:PostBackTrigger ControlID="btnUploadPossession" />
            <asp:PostBackTrigger ControlID="btnUploadPossessionMemo" />
            <asp:PostBackTrigger ControlID="btnUploadReservationMoney" />
            <asp:PostBackTrigger ControlID="btnOccupancy" />
        </Triggers>
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                <ProgressTemplate>
                    <div class="fgh">
                        <div class="hgf">
                            <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>


    <cc1:MessageBox ID="MessageBox1" runat="server" />
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12" style="background: #dbdbdb;">
            <div>
                <div style="width: 100px; float: left; background: #dbdbdb; font-size: 11px;" class="text-center">
                    <br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                        <li class="disabled">
                            <a runat="server" onserverclick="Home_ServerClick">
                                <i class="fa fa-home" aria-hidden="true"></i>
                                <br />
                                Home
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left; background: #dbdbdb; border-left: 1px solid #000; font-size: 11px;" class="text-center">
                    Operate<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                        <li>
                            <a runat="server" id="SaveEntry" onserverclick="SaveEntry_ServerClick">
                                <i class="fa fa-floppy-o " aria-hidden="true"></i>
                                <br />
                                Save
                            </a>
                        </li>
                        <li>
                            <a runat="server" onserverclick="Reset_ServerClick">
                                <i class="fa fa-refresh" aria-hidden="true"></i>
                                <br />
                                Refresh
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left; background: #dbdbdb; border-left: 1px solid #000; border-right: 1px solid #000; font-size: 11px;" class="text-center">
                    Allottee Registration<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                        <li>
                            <a runat="server" onserverclick="NewAllottee_ServerClick">
                                <i class="fa fa-plus" aria-hidden="true"></i>
                                <br />
                                New
                            </a>
                        </li>
                        <li>
                            <a runat="server" onserverclick="HistoryAllottee_ServerClick">
                                <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                <br />
                                History
                            </a>
                        </li>

                    </ul>
                </div>
                <div style="float: left; background: #dbdbdb; font-size: 11px;" class="text-center">
                    Navigation<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-step-backward" aria-hidden="true"></i>
                                <br />
                                Last
                            </a>
                        </li>
                        <li>
                            <a runat="server" onserverclick="prev_server_click">
                                <i class="fa fa-angle-double-left" aria-hidden="true"></i>
                                <br />
                                Previous
                            </a>
                        </li>
                        <li>
                            <a runat="server" onserverclick="next_server_click" id="sernext">
                                <i class="fa fa-angle-double-right" aria-hidden="true"></i>
                                <br />
                                Next
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-step-forward" aria-hidden="true"></i>
                                <br />
                                Final
                            </a>
                        </li>
                        <li runat="server" id="hrefPrint" visible="false">
                            <a runat="server" onclick="PrintElem1()">
                                <i class="fa fa-print" aria-hidden="true"></i>
                                <br />
                                Print
                            </a>
                        </li>
                        <li runat="server" id="hrefPrint1" visible="false">
                            <a onclick="PrintElem1()">
                                <i class="fa fa-print" aria-hidden="true"></i>
                                <br />
                                Print
                            </a>
                        </li>

                    </ul>
                </div>

            </div>
        </div>
        <div class="clearfix"></div>
    </div>
    <ol class="breadcrumb" style="display: none;">
        <li><a href="#">Home</a></li>
        <li><a href="#">Private</a></li>
        <li><a href="#">Pictures</a></li>
        <li><a href="#">Vacation</a></li>
    </ol>

    <div id="dialog" style="display: none">
    </div>


    <div style="border-bottom-color: antiquewhite; border-bottom-width: inherit; border-width: 10px">
        <br />
        <div class="table-responsive">
            <table id="tblsearch" class="table table-striped table-bordered table-hover  margin-b-2px request-table">
                <tr style="background: #ececec;">
                    <td class="font-bold">
                        <span style="color: Red">*</span>
                        Office to which Allottee belongs :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddloffice" AutoPostBack="true" OnSelectedIndexChanged="Regional_Changed" runat="server" CssClass="btn btn-sm btn-default dropdown-toggle similar-select">
                        </asp:DropDownList>
                    </td>
                    <td class="font-bold">
                        <span style="color: Red">*</span>
                        Industrial Area Name :
                    </td>
                    <td>
                        <asp:DropDownList ID="drpdwnIA" runat="server" CssClass="btn btn-sm btn-default dropdown-toggle similar-select" AutoPostBack="true" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpdwnIA" InitialValue="0"
                            ErrorMessage="Select Industrial Area" ValidationGroup="ValidationButton" ToolTip=" Select Industrial Area"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>

                    <td></td>

                </tr>
                <tr style="display: none;">
                    <td colspan="3">
                        <span>Allottee/Transfree Registration</span>
                    </td>

                    <td>
                        <asp:Button CssClass="btn btn-sm btn-primary pull-right" Text="New Registration" ID="New_Allottee_Registration_btn" OnClick="New_Allottee_Registration_btn_click" runat="server" />
                        <asp:Button CssClass="btn btn-sm btn-primary pull-right" Style="margin-right: 2px;" Text="Allottee History Registration" ID="History_Allottee_Entry_btn" OnClick="New_Allottee_Registration_btn_click" runat="server" />
                    </td>

                </tr>
            </table>
        </div>

        <div id="divMessageError" class="MessagePennel" runat="server" style="display: none;">
            <label>
                <span class="check-cross" runat="server">✖</span>

                <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
            </label>
        </div>

        <%--  <asp:Button CssClass="btn btn-sm btn-primary pull-right"  style="margin-right:2px;" Text="Print" ID ="btnPrint"  runat="server" />--%>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="NewAllottee" runat="server">
                <hr style="margin: 15px 0; border-top: 2px solid #dedddd" />
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div>
                            <div class="panel panel-default">
                                <div class="clearfix"></div>
                                <div class="panel-heading font-bold">
                                    <div class="col-md-8 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                        Existing allottees record<%--(<code style="color: #00bd00;font-weight: bold;">Total available records</code>)--%></div>
                                    <div class="input-group col-md-4 col-sm-8 col-xs-12 text-right" style="float: right; padding: 2px; display: none;">
                                        <asp:TextBox ID="txtSearch" Width="200px" CssClass="input-sm similar-select" runat="server" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged" />
                                        <span class="input-group-btn">
                                            <button class="btn btn-sm btn-primary" type="button" style="padding: 5px 10px; color: #fff;"><i style="color: #fff;" class="fa fa-search" aria-hidden="true"></i></button>
                                        </span>
                                    </div>
                                    <div class="clearfix"></div>

                                </div>

                                <div class="panel-body">

                                    <div class="table-responsive">

                                        <asp:GridView ID="Allottee_master_grid" runat="server" ClientIDMode="Static"
                                            CssClass="request-table table table-striped table-bordered table-hover"
                                            OnPageIndexChanging="OnPageIndexChanging" AutoGenerateColumns="false" DataKeyNames="AllotteeID" OnRowCommand="Allottee_master_grid_RowCommand">
                                            <Columns>
                                                <asp:BoundField DataField="AllotteeID" HeaderText="AllotteeID" SortExpression="AllotteeID" Visible="false" />
                                                <asp:BoundField DataField="RegionalOffice" HeaderText="Regional Office" SortExpression="RegionalOffice" />
                                                <asp:BoundField DataField="IAName" HeaderText="IndustrialArea" SortExpression="IAName" />
                                                <asp:BoundField DataField="AllotteeName" HeaderText="Company Name" SortExpression="AllotteeName" />
                                                <asp:BoundField DataField="AllotmentNo" HeaderText="Allotment No" SortExpression="AllotmentNo" />
                                                <asp:BoundField DataField="PlotNo" HeaderText="PlotNo" SortExpression="PlotNo" />
                                                <asp:BoundField DataField="FileNo" HeaderText="File No" SortExpression="FileNo" />
                                                <asp:BoundField DataField="TotalAllottedplotArea" HeaderText="TotalAllottedplotArea" SortExpression="TotalAllottedplotArea" />
                                                <asp:BoundField DataField="IndustryType" HeaderText="IndustryType" SortExpression="IndustryType" />
                                                <asp:BoundField DataField="AllotmentDate" HeaderText="AllotmentDate" SortExpression="AllotmentDate" />
                                                <asp:BoundField DataField="EmailID" HeaderText="EmailID" SortExpression="EmailID" />
                                                <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                <%--<asp:BoundField DataField="AllotteeID" HeaderText="AllotteeID" SortExpression="AllotteeID" Visible="false" />
                                                <asp:BoundField DataField="Plot No" HeaderText="Plot No" SortExpression="Plot No" />
                                                <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector" />
                                                <asp:BoundField DataField="File No" HeaderText="File No" SortExpression="File No" />
                                                <asp:BoundField DataField="Allotment No" HeaderText="Applicant Id" SortExpression="Allotment No" />
                                                <asp:BoundField DataField="Company Name" HeaderText="Company Name" SortExpression="Company Name" />
                                                <asp:BoundField DataField="Authorised Signatory" HeaderText="Authorised Signatory" SortExpression="Authorised Signatory" />
                                                <asp:BoundField DataField="Allotment Date" HeaderText="Allotment Date" SortExpression="Allotment Date" />--%>
                                                <asp:TemplateField HeaderText="View">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btnView" CssClass="fa fa-eye" aria-hidden="true" CommandName="ViewRow" CommandArgument='<%#Eval("AllotteeID") %>' ToolTip="Click here to View Request " />
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Revert" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btnUnFinalized" CssClass="fa fa-mail-forward" aria-hidden="true" CommandName="Unfinalized" CommandArgument='<%#Eval("AllotteeID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to Revert Record?');" ToolTip="Click here to View Request " />
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="UnLock" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btnUnlok" CssClass="fa fa-unlock" aria-hidden="true" CommandName="Unlock" CommandArgument='<%#Eval("AllotteeID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to Unlock Record?');" ToolTip="Click here to View Request " />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Lock" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btnlock" CssClass="fa fa-lock" aria-hidden="true" CommandName="lock" CommandArgument='<%#Eval("AllotteeID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to lock Record?');" ToolTip="Click here to View Request " />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                No Record Available
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <hr style="margin: 15px 0; border-top: 2px solid #dedddd" />
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="panel panel-default">
                            <p class="panel-heading font-bold">Request under process at you<%--(<code style="color: #00bd00;font-weight: bold;">Total available records</code>)--%></p>
                            <div class="panel-body gallery  table-responsive">
                                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="GridView1_pending_process" runat="server" AutoGenerateColumns="false" DataKeyNames="AllotteeID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                    ClientIDMode="Static" CssClass="table table-striped table-bordered table-hover request-table" OnRowCommand="GridView1_pending_process_RowCommand"
                                    OnPageIndexChanging="GridView1_pending_process_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="RegionalOffice" HeaderText="Regional Office" SortExpression="RegionalOffice" />
                                        <asp:BoundField DataField="IAName" HeaderText="IndustrialArea" SortExpression="IAName" />
                                        <asp:BoundField DataField="AllotteeName" HeaderText="Company Name" SortExpression="AllotteeName" />
                                        <asp:BoundField DataField="AllotmentNo" HeaderText="Allotment No" SortExpression="AllotmentNo" />
                                        <asp:BoundField DataField="PlotNo" HeaderText="PlotNo" SortExpression="PlotNo" />
                                        <asp:BoundField DataField="FileNo" HeaderText="File No" SortExpression="FileNo" />
                                        <asp:BoundField DataField="TotalAllottedplotArea" HeaderText="TotalAllottedplotArea" SortExpression="TotalAllottedplotArea" />
                                        <asp:BoundField DataField="IndustryType" HeaderText="IndustryType" SortExpression="IndustryType" />
                                        <asp:BoundField DataField="AllotmentDate" HeaderText="AllotmentDate" SortExpression="AllotmentDate" />
                                        <asp:BoundField DataField="EmailID" HeaderText="EmailID" SortExpression="EmailID" />
                                        <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                        <asp:TemplateField HeaderText="Process">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Select_allotee_for_process" CommandArgument='<%#Eval("AllotteeID") %>' ToolTip="Click here For Registrations Process " />
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Deactivate">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandArgument='<%#Eval("AllotteeID") %>' CommandName="DeleteAllotteeRecords" OnClientClick="javascript:return confirm('Are you sure wanted to Deactived Records?');" ToolTip="Click here to reject" />
                                                </span>  
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--                                <asp:TemplateField HeaderText="Reject">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandArgument='<%#Eval("AllotteeRegisterID") %>' CommandName="Delete" OnClientClick="return confirm('Are you sure that the detail entered by requester does't match your record and you want to reject the request.');" ToolTip="Click here to reject" />
                                        </span>  
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

                </div>
                <hr style="margin: 15px 0; border-top: 2px solid #dedddd" />
                <div class="row" style="display: none;">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="panel panel-default">
                            <p class="panel-heading font-bold">New request from allottee<%--(<code style="color: #00bd00;font-weight: bold;">Total available records</code>)--%></p>
                            <div class="panel-body  table-responsive">
                                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="AllotteeID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" OnRowCommand="GridView1_RowCommand"
                                    PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right">
                                    <Columns>


                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                                <asp:HiddenField ID="hfAllotteeID" runat="server" Value='<%#Eval("AllotteeID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Allotmentletterno" HeaderText="Allotment Letter No" SortExpression="AllotteeID" />
                                        <asp:BoundField DataField="AllotteeName" HeaderText="Requester Name" SortExpression="AllotteeName" />
                                        <asp:BoundField DataField="emailID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" HeaderText="e-Mail" SortExpression="emailID" />
                                        <asp:BoundField DataField="PhoneNo" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" HeaderText="Contact No" SortExpression="PhoneNo" />
                                        <asp:BoundField DataField="Address" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" HeaderText="Communication Address" SortExpression="Address1" />
                                        <asp:BoundField DataField="Address1" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" HeaderText="Alternate Address" SortExpression="Address2" />
                                        <asp:BoundField DataField="FatherName" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" HeaderText="Father Name" SortExpression="FatherName" />
                                        <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                                        <asp:BoundField DataField="IndustrialArea" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" HeaderText="Industrial Area" SortExpression="IndustrialArea" />
                                        <asp:BoundField DataField="AdharCardNo" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" HeaderText="Adhar No" SortExpression="AdharCardNo" />
                                        <asp:BoundField DataField="DateofAllotmentNo" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date of Allotment" SortExpression="DateofAllotmentNo" />

                                        <asp:TemplateField HeaderText="View">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnView" CssClass="fa fa-eye" aria-hidden="true" CommandName="ViewRow" CommandArgument='<%#Eval("AllotteeID") %>' ToolTip="Click here to View Request " />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Process" Visible="false">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="EditRow" CommandArgument='<%#(Container.DataItemIndex) %>' ToolTip="Click here For Registrations Process " />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Reject">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandArgument='<%#Eval("AllotteeID") %>' CommandName="DeleteAllottee" ToolTip="Click here to reject" />
                                                </span>  
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>



            </asp:View>

            <asp:View ID="View0" runat="server">
                <a onclick="Registration1()">
                    <i class="fa fa-print" aria-hidden="true"></i>
                    <br />

                </a>
                <div class="row" id="AllotteeRegistration1">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="width: 100%;">
                                <div class="row">
                                    <div class="">
                                        <div class="col-md-3 btn-group" style="display: none;">
                                            <div class="btn-group">
                                                <asp:Button ID="Button2" runat="server" CssClass="btn btn-sm btn-primary" Style="margin-right: 2px;" Text="Move Previous" OnClick="Previous_home_Click" />
                                                <asp:Button ID="btnNext" CssClass="btn btn-sm btn-primary" runat="server" OnClick="btnNext_Click" Text="Move Next" />
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                            <p>Allottee/Transfree Registration (1/5)</p>
                                        </div>

                                        <div class="col-md-3 btn-group" style="display: none;">
                                            <div class="btn-group pull-right">
                                                <asp:Button ID="btn_first_save" OnClick="btn_first_Click" CssClass="btn btn-sm btn-primary" runat="server" Text="Save" Enabled="false" OnClientClick="return check1()" />
                                                <asp:Button ID="Button9" CssClass="btn btn-sm btn-primary " runat="server" Enabled="false" Text="Reset" />
                                            </div>


                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <table id="Table2" class="table table-striped table-responsive table-bordered  table-hover" style="display: none;">
                                    <tr>
                                        <td class="auto-style2">
                                            <span style="color: Red">*</span>
                                            Allotment Letter No :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAllotment" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
                                        </td>

                                        <td class="auto-style2">
                                            <span style="color: Red">*</span>
                                            Industrial Area Name :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIndustrialArea" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <span style="color: Red">*</span>
                                            Name as per our Record :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Width="200px" onkeypress="return ValidateAlpha(event);"></asp:TextBox>
                                        </td>

                                        <td class="auto-style2">
                                            <span style="color: Red">*</span>
                                            Father's as per our Record :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFatherName" runat="server" CssClass="form-control" Width="200px" onkeypress="return ValidateAlpha1(event);"></asp:TextBox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <span style="color: Red">*</span>
                                            Registerd Address as per our Record   :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAllotteeAddress" runat="server" CssClass="form-control" Width="200px" onkeypress="address_keypress()"></asp:TextBox>
                                        </td>

                                        <td class="auto-style2">
                                            <span style="color: Red"></span>
                                            Allottee Address1  :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAllotteeAddress1" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <span style="color: Red">*</span>
                                            Allotted Plot No/Shed No.  :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPlotNo1" runat="server" onkeypress="plot_keypress()" CssClass="form-control" Width="200px"></asp:TextBox>
                                        </td>

                                        <td class="auto-style2">
                                            <span style="color: Red">*</span>
                                            Phone No  :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" Width="200px" MaxLength="10" onkeypress="return isNumberKey(event);" onblur="return validatephone(this)"></asp:TextBox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <span style="color: Red">*</span>
                                            Email ID :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmailid" runat="server" CssClass="form-control" Width="200px" onblur="ValidateEmail()"></asp:TextBox>
                                        </td>

                                        <td class="auto-style2">
                                            <span style="color: Red">*</span>
                                            Aadhar Card No :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddharcardNo" runat="server" CssClass="form-control" Width="200px" MaxLength="10" onkeypress="return isNumberKey1(event);" onblur="Validateadhar()"></asp:TextBox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <span style="color: Red">*</span>
                                            Allottement Date as per our Record  :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDateofAllottementNo" CssClass="date form-control" runat="server" Style="vertical-align: middle; width: 200px" placeholder="dd/mm/yyyy"></asp:TextBox>
                                        </td>
                                        <%--  Enabled="false"--%>

                                        <td class="auto-style2">
                                            <span style="color: Red">*</span>
                                            Allottee Register ID :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAllotteeRegisterID" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="lblPlotUniqueID" runat="server" Visible="false" />
                                <%-- 28 sep 2017  --%>

                                <div id="tblallotteeinf">
                                    <p class="panel-heading">Allotment Information</p>
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red">*</span>
                                            Name of Industrial Area in which plot belongs : 
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:DropDownList ID="ddlArea" runat="server" CssClass="chosen input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label for="txtalltLetterIssueDate" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            Case Type :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:DropDownList runat="server" ID="DdlCaseType" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="DdlCaseType_SelectedIndexChanged">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem>Fresh Allotment</asp:ListItem>
                                                <asp:ListItem>Transfer Case</asp:ListItem>
                                                <asp:ListItem>Change of Plot</asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div id="tccase" runat="server" visible="false">
                                        <div class="form-group">
                                            <label for="lblfirstAllotmentDate" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Date of First Allotment(Allotment date of First Allottee of plots):
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <!--<i class="fa fa-inr" style="margin-right: 5px;"></i>-->
                                                <asp:TextBox ID="txtfirstAllotmentDate" runat="server" CssClass="date input-sm similar-select1" placeholder="dd/mm/yyyy" Width="98%"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label for="lblAllotmentreferencenumber" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Allotment reference number of first allotment :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                <asp:TextBox ID="txtAllotmentreferencenumber" runat="server" CssClass="input-sm similar-select1" Width="98%"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                    </div>
                                    <div runat="server" id="Case1" visible="false">
                                        <div class="form-group">
                                            <label for="txtalltLetterIssueDate" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Applicable Transfer Levy :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:DropDownList runat="server" ID="ddlTranserCase" CssClass="similar-select1 input-sm dropdown-toggle">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label for="txtalltLetterIssueDate" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Pending dues from previous allottee carry forward (If any) :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                <asp:TextBox ID="txtCarry" runat="server" CssClass="input-sm similar-select1" Width="98%" onkeypress="return isDecimalKey(event);" sssplaceholder="In Rupees"></asp:TextBox>

                                            </div>
                                        </div>

                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="ChangeofPlot" visible="false">
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">Change Of Plot Details</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Change Of Plot Ref. No :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtChangePlotRefNo" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Change Of Plot Ref. Date :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtChangePlotRefDate" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Additional Charges :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtAdditionalChargesforplot" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                New Deed after Change of Plot :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtDeedafterChangeofPlot" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="panel-heading">Details From Allotment letter</div>
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red">*</span>
                                            Applicant Id : 
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtAllotment1" runat="server" CssClass="similar-select1 input-sm" onkeypress="return Allotment_keypress();"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div id="Chooseplot" runat="server">
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                <span style="color: Red">*</span>
                                                Choose Plot/Shed : 
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="PlotDDl" runat="server" CssClass="chosen input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="PlotDDl_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red">*</span>
                                            Allotted Plot No/Shed No. : 
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtPlotNo" runat="server" CssClass="similar-select1 input-sm" onkeypress="return plot_keypress();" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            Sector Name : 
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:DropDownList ID="drpdwnSector" runat="server" CssClass="chosen input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="drpdwnSector_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            Sector. : 
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtSector" runat="server" CssClass="similar-select1 input-sm" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            File No :
                                        </label>
                                        <div class="col-md-9  col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtFileNo" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red">*</span>
                                            Application Date :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtAllotmenttLetterApplicationDate" runat="server" CssClass="date input-sm similar-select1" placeholder="dd/mm/yyyy"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red">*</span>
                                            Allotted Area(in Sqmts.) :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtTotalArea" runat="server" CssClass="input-sm similar-select1" OnTextChanged="txtTotalArea_TextChanged" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" disabled></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red">*</span>
                                            Allotment Rate :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtAllotmentRate" runat="server" CssClass="input-sm similar-select1" OnTextChanged="txtTotalArea_TextChanged" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red"></span>
                                            LocationCharge(if Any) :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtlocationcharge" runat="server" CssClass="input-sm similar-select1" OnTextChanged="txtTotalArea_TextChanged" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red"></span>
                                            InterestRateApplicable(%) :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtInterestRateApplicable" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red"></span>
                                            PanelRateApplicable(%) :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtPanelRateApplicable" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red"></span>
                                            Maximum Ground Coverage(%) :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtGroundCoverage" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red"></span>
                                            Maximum Permisable FAR :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtPermisableFAR" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />

                                    <div class="form-group">
                                        <label for="txtalltLetterIssueDate" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red">*</span>
                                            Date of Allotment/Transfer :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtalltLetterIssueDate" runat="server" CssClass="date input-sm similar-select1" placeholder="dd/mm/yyyy"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label for="txtalltLetterIssueDate" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            Allotment/Transfer Ref. No :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtallotment_ref_no" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right" for="txtConstructionValueAtTimeofAllotment">
                                            Existing Construction Value at plot :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                            <asp:TextBox ID="txtConstructionValueAtTimeofAllotment" Width="98%" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            Allotment Letter :
                                        </label>
                                        <div class="col-md-5 col-sm-12 col-xs-12">
                                            <asp:FileUpload ID="fileupload" Width="97%" CssClass="form-control" runat="server" />
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-primary ey-bg btn-sm" Style="margin: 0 1px 0 0; width: 65px;" Text="Upload" OnClick="btnUpload_Click" />
                                        </div>
                                        <div class="col-md-1 col-sm-12 col-xs-12">
                                            <asp:LinkButton runat="server" aria-hidden="true" ID="btnMinutes" CssClass="fa fa-download" OnClick="btnMinutes_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                            </div>

                            <div id="tblcompanyprofile">
                                <p class="panel-heading">Particulars of the Allottee in whose name plot/shed is Allotted</p>
                                <div class="form-group">
                                    <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        <span style="color: Red">*</span>
                                        Constitution of Firm/Company/Society :
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList ID="ddlcompanytype" runat="server" AutoPostBack="true" CssClass="similar-select1 dropdown-toggle input-sm" OnSelectedIndexChanged="CompanyTypeddl_selectedindex_changed"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        CA Certificate :
                                    </label>
                                    <div class="col-md-5 col-sm-12 col-xs-12">
                                        <asp:FileUpload ID="fupcacertificate" Width="97%" CssClass="form-control" runat="server" />
                                    </div>
                                    <div class="col-md-3 col-sm-12 col-xs-12">
                                        <asp:Button ID="btnCA" runat="server" CssClass="btn btn-primary ey-bg btn-sm" Style="margin: 0 1px 0 0; width: 65px;" Text="Upload" OnClick="btnUploadCACertificate_Click" />
                                    </div>
                                    <div class="col-md-1 col-sm-12 col-xs-12">
                                        <asp:LinkButton runat="server" aria-hidden="true" ID="LinkButton6" CssClass="fa fa-download" OnClick="btnCACertificate_Click" />
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        <span style="color: Red">*</span>
                                        Name Of The Firm/Company/Society:
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:TextBox ID="txtCompanyname" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red">*</span>
                                            Address :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox TextMode="MultiLine" ID="txtIndividualAddress" runat="server" CssClass="similar-select1 margin-left-z input-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div id="tr5" runat="server" visible="false" style="display: none;">
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red">*</span>
                                            <asp:Label ID="lblnameremark" runat="server" />
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtIndividualName" runat="server" CssClass="similar-select1 input-sm" onkeypress="return Validate_individual_name(event);"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                </div>
                                <div id="tr6" runat="server" visible="false">
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red">*</span>
                                            Mobile Number :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtIndividualPhone" runat="server" CssClass="similar-select1 input-sm" MaxLength="10" onkeypress="retun validate_individual_phone(event);" onblur="return validatephone(this)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            <span style="color: Red">*</span>
                                            Email Id :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtIndividualEmail" runat="server" CssClass="similar-select1 input-sm" onblur="return ValidateEmail(this);"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        Pan No :
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:TextBox ID="txtPanNo" runat="server" CssClass="similar-select1 input-sm" onblur="return validatepan()"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        CIN No :
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:TextBox ID="txtCinNo" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />

                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                            GST No :
                                        </label>
                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                            <asp:TextBox ID="txtGstNo" runat="server" CssClass="similar-select1 input-sm" Style="text-transform: uppercase;" onblur="validatepan(this,'Pan No');"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                            Udyog Aadhar No :
                                        </label>
                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                            <asp:TextBox ID="txtUdyogAdhar" runat="server" CssClass="similar-select1 input-sm" Style="text-transform: uppercase;"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                            Aadhar No :
                                        </label>
                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                            <asp:TextBox ID="txtAadharNo" runat="server" CssClass="similar-select1 input-sm" Style="text-transform: uppercase;" onblur="validatepan(this,'Pan No');"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <div class="col-md-12 col-sm-12 col-xs-12" id="tr7" runat="server" visible="false">
                                    <asp:CheckBox ID="chk2" runat="server" Text="&nbsp;&nbsp;Check if the person who will be operating the application is same as the Allottee" OnCheckedChanged="checkbox2_checked_changed" AutoPostBack="true" />
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    <span style="color: Red">*</span>
                                    Name of the person who  will operate :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtAuthorisedSignatory" runat="server" CssClass="similar-select1 input-sm" onkeypress="return Validate_signatory_name(event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    <span style="color: Red">*</span>
                                    Address :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtSignatoryAddress" TextMode="MultiLine" runat="server" CssClass="similar-select1 margin-left-z input-sm"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    <span style="color: Red">*</span>
                                    Mobile Number :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtSignatoryPhone" runat="server" CssClass="similar-select1 input-sm" MaxLength="10" onkeypress="return isNumberKey(event);" onblur="return validatephone(this)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Email Id :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtSignatoryEmail" runat="server" CssClass="similar-select1 input-sm" onblur="return ValidateEmail(this);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div id="tr2" runat="server" visible="false">
                                <div class="table-responsive">
                                    <asp:GridView ID="gridshareholder" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="ShareHolderDelete_Click">
                                        <Columns>

                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Shareholder Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShareholderName" runat="server" Text='<%#Eval("ShareHolderName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtShareholderName_insert" CssClass="form-control input-sm" runat="server" Width="150px"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Share %">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShareper" runat="server" Text='<%#Eval("SharePer") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtShareper_insert" runat="server" CssClass="form-control input-sm" Width="150px" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtAddress_insert" CssClass="form-control input-sm" runat="server" Width="150px"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Phone No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("PhoneNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtPhone_insert" CssClass="form-control input-sm" runat="server" Width="150px" MaxLength="15" onkeypress="return isNumberKey(event);"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Email ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("EmailId") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtEmail_insert" CssClass="form-control input-sm" runat="server" Width="150px"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                        ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

                                                </ItemTemplate>
                                                <FooterStyle HorizontalAlign="Right" />
                                                <FooterTemplate>
                                                    <asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square" ID="ButtonAdd" runat="server" Height="16px" OnClick="insert_shareholder_details"
                                                        ImageUrl="~/images/add.png" Width="16px" />





                                                </FooterTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>
                                </div>

                            </div>
                            <div id="tr4" runat="server" visible="false">
                                <div class="table-responsive">
                                    <asp:GridView ID="Trustee_details_grid" ViewStateMode="Enabled" CssClass="table request-table table-striped table-responsive table-bordered table-hover" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="TrusteeDelete_Click">
                                        <Columns>

                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField ItemStyle-Width="25%" HeaderText="Trustee Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTrusteeName" runat="server" Text='<%#Eval("TrusteeName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtTrusteeName_insert" CssClass="form-control input-sm" runat="server" Width="200px"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField ItemStyle-Width="25%" HeaderText="Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtTAddress_insert" CssClass="form-control input-sm" runat="server" Width="200px"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="25%" HeaderText="Phone No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtTPhone_insert" CssClass="form-control input-sm" MaxLength="15" runat="server" Width="200px" onkeypress="return isNumberKey(event);"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="25%" HeaderText="Email ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTEmail" runat="server" Text='<%#Eval("EmailId") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtTEmail_insert" CssClass="form-control input-sm" runat="server" Width="200px"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                        ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

                                                </ItemTemplate>
                                                <FooterStyle HorizontalAlign="Right" />
                                                <FooterTemplate>
                                                    <asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square" ID="ButtonAdd" runat="server" Height="16px" OnClick="insert_trustee_details"
                                                        ImageUrl="~/images/add.png" Width="16px" />





                                                </FooterTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div id="tr8" runat="server" visible="false">
                                <div class="table-responsive">
                                    <asp:GridView ID="DirectorsGrid" ViewStateMode="Enabled" CssClass="table request-table table-striped table-responsive table-bordered table-hover" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="DirectorDelete_Click">
                                        <Columns>

                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Director Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDirectorName" runat="server" Text='<%#Eval("DirectorName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtDirectorName_insert" CssClass="form-control input-sm" runat="server" Width="150px"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Din/Pan">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDIN_PAN" runat="server" Text='<%#Eval("DIN_PAN") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtDIN_PAN_insert" runat="server" CssClass="form-control input-sm" Width="150px"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDirectorAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtDirectorAddress_insert" CssClass="form-control input-sm" runat="server" Width="150px"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Phone No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtDirectorPhone_insert" CssClass="form-control input-sm" MaxLength="15" runat="server" Width="150px" onkeypress="return isNumberKey(event);"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Email ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("EmailId") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtDirectorEmail_insert" CssClass="form-control input-sm" runat="server" Width="150px"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                        ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

                                                </ItemTemplate>
                                                <FooterStyle HorizontalAlign="Right" />
                                                <FooterTemplate>
                                                    <asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square" ID="ButtonAdd" runat="server" Height="16px" OnClick="insert_Director_details"
                                                        ImageUrl="~/images/add.png" Width="16px" />
                                                </FooterTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div id="tr88" runat="server" visible="false">
                                <hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
                                <div class="table-responsive">
                                    <asp:GridView ID="PartnershipFirmGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="PartnershipDelete_Click">
                                        <Columns>

                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Partner Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPartnerName" runat="server" Text='<%#Eval("PartnerName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtPartnerName_insert" CssClass="input-sm similar-select1" runat="server" onkeypress="return Validate_director_name(event);"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Partnership Per">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPartnershipPer" runat="server" Text='<%#Eval("PartnershipPer") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtPartnershipPer_insert" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPartnerAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtPartnerAddress_insert" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Phone No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPartnerPhone" runat="server" Text='<%#Eval("PhoneNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtPartnerPhone_insert" CssClass="input-sm similar-select1" MaxLength="15" runat="server" onkeypress="return isNumberKey(event);"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Email ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPartnerEmail" runat="server" Text='<%#Eval("EmailId") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtPartnerEmail_insert" CssClass="input-sm similar-select1" runat="server" onblur="return ValidatePartnerEmail();"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                        ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

                                                </ItemTemplate>
                                                <FooterStyle HorizontalAlign="Right" />
                                                <FooterTemplate>
                                                    <asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square" ID="ButtonAdd" runat="server" Height="16px" OnClick="insert_Partnership_details"
                                                        ImageUrl="~/images/add.png" Width="16px" />





                                                </FooterTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group">
                                <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                    <%-- <span style="color: blue">Field marked with <span style="color: Red">* </span>are mandatory</span>
                                                    <asp:Button ID="Button3" CssClass="btn btn-primary btn-sm" ValidationGroup="ValidationButton" runat="server" OnClick="btnSubmit_Click1" Text="Save" OnClientClick="return check1()"/>
                                                    <asp:Button ID="Button4" CssClass="btn btn-primary btn-sm" runat="server" OnClick="Reset_Click1" Text="Reset" />
                                    --%>
                                    <asp:CheckBox
                                        ID="Conform_CheckBox_multiview_1"
                                        runat="server"
                                        Text=" &nbsp;&nbsp;I hereby certify that the Above Record are true and correct to the best of my knowledge."
                                        OnCheckedChanged="Conform_CheckBox_multiview_1_CheckChanged"
                                        AutoPostBack="true"
                                        Font-Names="Serif"
                                        Font-Size="14px" />
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                        </div>

                        <asp:Label ID="lblNewButton" runat="server" Style="display: none"></asp:Label>
                    </div>

                </div>
    </div>
    </asp:View>

            <asp:View ID="View1" runat="server">
                <a onclick="Registration2()">
                    <i class="fa fa-print" aria-hidden="true"></i>
                    <br />

                </a>
                <div class="row" id="AllotteeRegistration2">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="panel panel-default ">
                            <div class="panel-heading" style="width: 100%;">
                                <div class="row">
                                    <div class="">
                                        <div class="col-md-3 btn-group" style="display: none;">
                                            <div class="btn-group">
                                                <asp:Button ID="Previous" runat="server" CssClass="btn btn-sm btn-primary" Style="margin-right: 2px;" Text="Move Previous" OnClick="Previous_Click" />
                                                <asp:Button ID="btnNext2" CssClass="btn btn-sm btn-primary" runat="server" OnClick="btnNext1_Click" Text="Move Next" />

                                            </div>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                            <p>Allottee/Transfree Registration (3/5)</p>
                                        </div>

                                        <div class="col-md-3 btn-group" style="display: none;">
                                            <div class="btn-group pull-right">
                                                <asp:Button ID="btnSubmit" CssClass="btn btn-sm btn-primary" ValidationGroup="ValidationButton" runat="server" OnClick="btnSubmit_Click" Text="Save" />
                                                <%-- <asp:Button ID="btnSubmit" CssClass ="btn btn-sm btn-primary" ValidationGroup="ValidationButton" runat="server" OnClick="btn_second_Click" Text="Save" />--%>
                                                <asp:Button ID="btnReset" CssClass="btn btn-sm btn-primary" runat="server" OnClick="Reset_Click" Text="Reset" />
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="panel-body ">
                                <div style="display: none">
                                    <div class="panel-heading">Allotted Plot Detail</div>
                                    <div class="row aks-row ">
                                        <div class="col-md-4 col-sm-12 col-xs-12 first_td">
                                            <label for="txtalltLetterIssueDate">Product Manufactured:</label>
                                        </div>
                                        <div class="col-md-8 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtProductManufactured" runat="server" CssClass="input-sm similar-select1" onkeypress="return product_manu_keypress()"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <label for="ReservationMoneyPaid" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        Operational maintenance charges Applicable :
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlOperationalmaintenancecharges" CssClass="similar-select1 input-sm dropdown-toggle">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label for="ReservationMoneyPaid" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            Reservation Money Paid :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:DropDownList runat="server" ID="ddlReservationmoney" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlReservationmoney_SelectedIndexChanged">

                                                <asp:ListItem Value="False">No</asp:ListItem>
                                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                    </div>
                                    <div runat="server" id="ReservationMoney" visible="false">
                                        <div class="panel-heading">Details of Reservation Money </div>
                                        <div class="form-group">
                                            <label for="ReservationPaymentDate" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Reservation Money Payment Date :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtReservationPaymentDate" runat="server" CssClass="date input-sm similar-select1" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label for="txtPaymentAmount" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Reservation Money Payment Amount:
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                <asp:TextBox ID="txtReservationPaymentAmount" runat="server" CssClass="input-sm similar-select1" Width="98%" onkeypress="return isDecimalKey(event);" sssplaceholder="In Rupees"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Copy of Payment Recepit :
                                            </label>
                                            <div class="col-md-5 col-sm-12 col-xs-12">
                                                <asp:FileUpload ID="fileuploadReservation" Width="97%" CssClass="form-control" runat="server" />
                                            </div>
                                            <div class="col-md-3 col-sm-12 col-xs-12">
                                                <asp:Button ID="btnUploadReservationMoney" runat="server" CssClass="btn btn-primary ey-bg btn-sm" Style="margin: 0 1px 0 0; width: 65px;" Text="Upload" OnClick="btnUploadReservationMoney_Click" />
                                            </div>
                                            <div class="col-md-1 col-sm-12 col-xs-12">
                                                <asp:LinkButton runat="server" aria-hidden="true" ID="LinkButton2" CssClass="fa fa-download" OnClick="btnReservationMoney_Click" />
                                            </div>
                                        </div>

                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <label for="LeaseDeed" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        LeaseDeed Signed :
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlLeaseDeedSigned" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlLeaseDeedSigned_SelectedIndexChanged">

                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="LeaseDeed" visible="false">
                                        <div class="panel-heading">Lease Deed Detail</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Date of Lease Deed :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtLeaseDeed" runat="server" CssClass="date input-sm similar-select1" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Lease Deed Ref. No :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtLeaseDeed_ref_no" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Date of execution lease deed :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtExecLeaseDeed" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Copy of LeaseDeed :
                                            </label>
                                            <div class="col-md-5 col-sm-12 col-xs-12">
                                                <asp:FileUpload ID="fileuploadLeaseDeed" Width="97%" CssClass="form-control" runat="server" />
                                            </div>
                                            <div class="col-md-3 col-sm-12 col-xs-12">
                                                <asp:Button ID="btnUploadLeaseDeed" runat="server" CssClass="btn btn-primary ey-bg btn-sm" Style="margin: 0 1px 0 0; width: 65px;" Text="Upload" OnClick="btnUploadLeaseDeed_Click" />
                                            </div>
                                            <div class="col-md-1 col-sm-12 col-xs-12">
                                                <asp:LinkButton runat="server" aria-hidden="true" ID="LinkButton3" CssClass="fa fa-download" OnClick="btnLeaseDeed_Click" />
                                            </div>
                                        </div>

                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">

                                            <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                                                Book No(Bahi) :
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <asp:TextBox ID="txt_Lease_bookno" CssClass="input-sm similar-select1" runat="server" onkeypress="return txtExecLeaseDeed_keypress()"></asp:TextBox>
                                            </div>

                                            <label class="col-md-5 col-sm-6 col-xs-12 text-right">
                                                Bookbinding No(Jild) :
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <asp:TextBox ID="txt_Lease_bookbinding" CssClass="input-sm similar-select1" runat="server" onkeypress="return txtExecLeaseDeed_keypress()"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                                                Page From :</label>
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <asp:TextBox ID="txt_Lease_pagefrom" CssClass=" input-sm similar-select1" runat="server" onkeypress="return txtExecLeaseDeed_keypress()"></asp:TextBox>
                                            </div>

                                            <label class="col-md-2 col-sm-6 col-xs-12 text-right">
                                                Page To :</label>
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <asp:TextBox ID="txt_Lease_pageto" CssClass=" input-sm similar-select1" runat="server" onkeypress="return txtExecLeaseDeed_keypress()"></asp:TextBox>
                                            </div>

                                            <label class="col-md-1 col-sm-6 col-xs-12 text-right">
                                                S.No :</label>
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <asp:TextBox ID="txt_Lease_srno" CssClass=" input-sm similar-select1" runat="server" onkeypress="return txtExecLeaseDeed_keypress()"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />

                                    <label for="PossessionLetter" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        Time extension Fees :
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddltef" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddltef_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="DivTEF" visible="false">
                                        <div class="panel-heading">Time extension Fees</div>
                                        <hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
                                        <div class="table-responsive">
                                            <asp:GridView ID="TEFGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="TEFDelete_Click">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTEFDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="TEF Reffrence Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTEFReff" runat="server" Text='<%#Eval("TEFRefferenceNumber") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtTEFReff_insert" CssClass="input-sm similar-select1" runat="server" onkeypress="return Validate_director_name(event);"></asp:TextBox>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="TEF Approval Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTEFApprovalDate" runat="server" Text='<%#Eval("TEFApprovalDate") %>' placeholder="dd/mm/yyyy"></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtTEFApprovalDate_insert" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="TEF Period (In Year)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTEFPeriod" runat="server" Text='<%#Eval("TEFPeriod") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:DropDownList ID="drpdTEFPeriod" CssClass="input-sm similar-select1" runat="server">
                                                                <asp:ListItem Text="1 Year" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="2 Year" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="3 Year" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="4 Year" Value="4"></asp:ListItem>

                                                            </asp:DropDownList>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="TEF Fees">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTEFFees" runat="server" Text='<%#Eval("TEFFees") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtTEFFees_insert" CssClass="input-sm similar-select1" MaxLength="15" runat="server" onkeypress="return isNumberKey(event);"></asp:TextBox>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                                ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <FooterTemplate>
                                                            <asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square" ID="ButtonAdd" runat="server" Height="16px" OnClick="insert_TEF_details"
                                                                ImageUrl="~/images/add.png" Width="16px" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>


                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />

                                    <label for="PossessionLetter" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        Possession Letter Issued :
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlPossessionLetter" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="PossessionLetter_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="Possession" visible="false">
                                        <div class="panel-heading">Possession Detail</div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Date of Possession :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtPossessiondate" runat="server" CssClass="date input-sm similar-select1" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Possession Letter Copy :
                                            </label>
                                            <div class="col-md-5 col-sm-12 col-xs-12">
                                                <asp:FileUpload ID="fileuploadPossession" Width="97%" CssClass="form-control" runat="server" />
                                            </div>
                                            <div class="col-md-3 col-sm-12 col-xs-12">
                                                <asp:Button ID="btnUploadPossession" runat="server" CssClass="btn btn-primary ey-bg btn-sm" Style="margin: 0 1px 0 0; width: 65px;" Text="Upload" OnClick="btnUploadPossession_Click" />
                                            </div>
                                            <div class="col-md-1 col-sm-12 col-xs-12">
                                                <asp:LinkButton runat="server" aria-hidden="true" ID="LinkButton4" CssClass="fa fa-download" OnClick="btnPossession_Click" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <label for="PhysicalPossession" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        Physical Possession:
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlPhysicalPossession" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlPhysicalPossession_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="PhysicalPossession" visible="false">
                                        <div class="panel-heading">Physical Possession Detail</div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Physical Possession Date :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtPhysicalPossessionDate" runat="server" CssClass="date input-sm similar-select1" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Possession Area :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtPossessionArea" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                •	Is possession area is different from allotted area :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:DropDownList runat="server" ID="ddlpossessionarea" CssClass="similar-select1 input-sm dropdown-toggle">
                                                    <asp:ListItem Value="False">No</asp:ListItem>
                                                    <asp:ListItem Value="True">Yes</asp:ListItem>

                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Difference in area (SQM) :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtpossessionareadiff" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Amount recover /adjusted (INR) :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtAmountrecover" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Physical Possession Memo :
                                            </label>
                                            <div class="col-md-5 col-sm-12 col-xs-12">
                                                <asp:FileUpload ID="fileuploadPossessionMemo" Width="97%" CssClass="form-control" runat="server" />
                                            </div>
                                            <div class="col-md-3 col-sm-12 col-xs-12">
                                                <asp:Button ID="btnUploadPossessionMemo" runat="server" CssClass="btn btn-primary ey-bg btn-sm" Style="margin: 0 1px 0 0; width: 65px;" Text="Upload" OnClick="btnUploadPossessionMemo_Click" />
                                            </div>
                                            <div class="col-md-1 col-sm-12 col-xs-12">
                                                <asp:LinkButton runat="server" aria-hidden="true" ID="LinkButton5" CssClass="fa fa-download" OnClick="btnPossessionMemo_Click" />
                                            </div>
                                        </div>
                                    </div>


                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <label for="BuildingPlan" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        Building Plan:
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlBuildingPlan" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlBuildingPlan_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="BuildingPlan" visible="false">
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">Bulding Plan Approval Detail</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Date of Building plan Approval :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtBuildingDate" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Building plan Ref. No :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtBuildingDate_ref_no" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Other Charges :
                                            </label>

                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                <asp:TextBox ID="txtothercharges" CssClass="input-sm similar-select1" Width="98%" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Compounding Charges :
                                            </label>

                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                <asp:TextBox ID="txtCompoundingCharges" CssClass="input-sm similar-select1" Width="98%" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <%-- <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                            Covered Area :
                                        </label>
                                        <div class="col-md-9 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtCoveredArea" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                        </div>
                                    </div>--%>

                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">Completion Certificate Detail</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Date of Release of Completion Certificate :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtcomcertificate" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Completion Certificate Ref. No :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtcomcertificate_ref_no" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">Occupancy Certificate Detail</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Date of Release of Occupancy Certificate :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtReloccertificate" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Occupancy Certificate Ref. No :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtReloccertificate_ref_no" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">Inspection Detail</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Date of Inspection for construction permit :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtInspectionDate" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Inspection Ref. No for construction :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtInspectionDate_ref_no" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Date of Inspection for completion :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtInspectioncompletion" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Inspection Ref. No for completion :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtInspectioncompletion_ref_no" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />

                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <label for="Restoration" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        Restoration:
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlRestoration" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlRestoration_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="Restoration" visible="false">
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">Restoration Details</div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Restoration Ref no :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtRestorationRefNo" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Restoration Ref Date :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtRestorationRefDate" runat="server" CssClass="date input-sm similar-select1" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Restoration Levy :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtRestorationLevy" runat="server" CssClass=" input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Deed after Restoration(%) :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtDeedafterRestoration" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                    </div>

                                    <%-- <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <label for="ChangeofPlot" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    ChangeofPlot:
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:DropDownList runat="server" ID="ddlChangeofPlot" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlChangeofPlot_SelectedIndexChanged">
                                        <asp:ListItem Value="False">No</asp:ListItem>
                                        <asp:ListItem Value="True">Yes</asp:ListItem>

                                    </asp:DropDownList>
                                </div>--%>


                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <label for="ChangeofProject" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        ChangeofProject:
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlChangeofProject" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlChangeofProject_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="ChangeofProject" visible="false">
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">Change Of Project Details</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Change Of Project Ref. No :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtChangeProjectRefNo" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Change Of Project Ref. Date :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtChangeProjectRefDate" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Change for Changes :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtChangeforChanges" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Lease Deed executed for increase of FAR :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtincreaseofFAR" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <label for="Amalgamation" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        Amalgamation:
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlAmalgamation" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlAmalgamation_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="Amalgamation" visible="false">
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">Amalgamation Details</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Amalgamation Ref. No :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtAmalgamationRefNo" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Amalgamation Ref. Date :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtAmalgamationRefDate" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Amalgamation Fees :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtAmalgamationFees" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Increase in Usability Fees :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtUsabilityFees" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Rectification Deed Date :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtRectificationDeedDate" CssClass=" date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <label for="SubDivision" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        SubDivision:
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlSubDivision" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlSubDivision_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="SubDivision" visible="false">
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">Sub Division Details</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Sub Div Ref. No :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtSubDivRefNo" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Sub Div Ref. Date :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtSubDivRefDate" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                No of Plot Created :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtNoofPlotCreated" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Sub Div Type :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtSubDivType" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Sub Div Charges :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtSubDivCharges" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Extension Charges :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtExtensionCharges" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <label for="Subletting" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        Subletting:
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlSubletting" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlSubletting_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="Subletting" visible="false">
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">Subletting Details</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Subletting Ref. No :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtSublettingRefNo" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Subletting Ref. Date :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtSublettingRefDate" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Subletting Party Name :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtSublettingPartyName" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Subletting Area (In Sqr.Mts) :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtSublettingArea" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Subletting For Years :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtSublettingYears" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Subletting Project Name :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtSublettingProjectName" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Subletting Charge:
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtSublettingCharge" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <label for="Agreement" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        Agreement:
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlAgreement" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlAgreement_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="Agreement" visible="false">
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">Agreement Details</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Agreement Date :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtAgreementDate" CssClass="Date input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Agreement Execution Date :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtAgreementExecDate" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Agreement On Plot Size :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtAgreementPlotSize" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <label for="EStamp" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        EStamp:
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlEStamp" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlEStamp_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="EStamp" visible="false">
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">E Stamp Details</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Certificate No :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtCertificateNo" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Issue Date :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtIssueDate" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Stamp Duty Amount :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                <asp:TextBox ID="txtstampDutyAmount" CssClass="input-sm similar-select1" runat="server" Width="98%" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Account Reference :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtAccountReference" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Unique Doc Refence :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtUniqueDocReference" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <label for="BankGuarantee" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        Bank Guarantee Details:
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlBankGuarantee" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlBankGuarantee_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="BankGuarantee" visible="false">
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">Bank Guarantee Details</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Guarantee No :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtGuaranteeNo" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Guarantee Amount :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                <asp:TextBox ID="txtGuaranteeAmount" CssClass="input-sm similar-select1" Width="98%" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Guarantee Cover from :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtCoverFrom" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Guarantee Cover To :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtCoverTo" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Last Date Of Claim :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtLastDateClaim" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <label for="Mortgage" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        Mortgage Details:
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlMortgage" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlMortgage_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="Mortgage" visible="false">

                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">Mortgage Details</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Bank Proposal Letter :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtPoposalLetter" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Bank Sanction Letter :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtSanctionLetter" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Sanction letter Of UPSIDC :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtSanctionLetterUpsidc" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                No of Stamp :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtNoOfStamp" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group" style="display: none;">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Stamp Amount :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtStampAmoount" CssClass="input-sm similar-select1" runat="server" AutoPostBack="true" OnTextChanged="txtNoOfStamp_TextChanged" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Total Stamp Duty :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                <asp:TextBox ID="txtTotalStampDuty" CssClass="input-sm similar-select1" Width="98%" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <label for="InterestWaiver" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        Interest Waiver :
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlinterestWaiver" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlinterestWaiver_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="interestWaiver" visible="false">

                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">Interest Waiver</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Period for which use  :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="timePeriod" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Time extension Waiver from  :
                                            </label>

                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                <asp:TextBox ID="txtTimeextensionWaiverfrom" CssClass="date input-sm similar-select1" Width="98%" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Time extension Waiver To :
                                            </label>

                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                <asp:TextBox ID="txtTimeextensionWaiverTo" CssClass="date input-sm similar-select1" runat="server" Width="98%" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Intt. on Time extension Waiver :
                                            </label>

                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                <asp:TextBox ID="txtInttonTimeextension" CssClass="input-sm similar-select1" runat="server" Width="98%" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Intt. on balance dues waiver :
                                            </label>

                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                <asp:TextBox ID="txtbalancedues" CssClass="input-sm similar-select1" runat="server" Width="98%" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Maintenance Charges Waiver :
                                            </label>

                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                <asp:TextBox ID="txtMaintenanceChargesWaiver" CssClass="input-sm similar-select1" runat="server" Width="98%" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                    </div>


                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <label for="InterestWaiver" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        Increase In FAR :
                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlincreaseinfar" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlincreaseinfar_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="increaseinfar" visible="false">

                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading">Increase In FAR</div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Date of Increase In FAR   :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="dateofIncreaseinfar" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Letter Number :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtletternumber" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Letter Date :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtletterdate" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Changes in FAR :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtchangesinfar" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Payment :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtPayment" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="form-group">
                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                Excution of Deed :
                                            </label>
                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtexcutionofdeed" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                    </div>
                                </div>

                                <div class="table-responsive">

                                    <table id="tblUploading" class="table table-striped table-responsive table-bordered table-hover" style="display: none">

                                        <tr>
                                            <td class="auto-style2">Date Of Request For Completion:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDateCompletion" CssClass="date form-control" runat="server" Style="vertical-align: middle; width: 200px" placeholder="dd/mm/yyyy"></asp:TextBox>

                                            </td>


                                            <td class="auto-style2">Date of Request of Occupancy Certificate:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtoccertificate" CssClass="date form-control" runat="server" Style="vertical-align: middle; width: 200px" placeholder="dd/mm/yyyy"></asp:TextBox>

                                            </td>
                                        </tr>

                                    </table>
                                </div>

                            </div>
                        </div>


                        <asp:Label ID="allotteeID" runat="server" Visible="false"> </asp:Label>
                    </div>
                </div>
            </asp:View>


    <asp:View ID="View2" runat="server">
        <a onclick="Registration3()">
            <i class="fa fa-print" aria-hidden="true"></i>
            <br />

        </a>
        <div class="row" id="AllotteeRegistration3">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="panel panel-default">
                    <div class="panel-heading" style="width: 100%;">
                        <div class="row">
                            <div class="">


                                <div class="col-md-3" style="display: none;">
                                    <div class="btn-group">

                                        <asp:Button ID="Previous1" runat="server" CssClass="btn btn-sm btn-primary" Style="margin-right: 2px;" Text="Move Previous" OnClick="Previous1_Click" />
                                        <asp:Button ID="Next3" runat="server" CssClass="btn btn-sm btn-primary" Text="Move Next" OnClick="Next3_Click" />
                                    </div>
                                </div>

                                <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                    <p>Allottee Installment Schedule (4/5)</p>

                                </div>

                                <div class="col-md-3" style="display: none;">
                                    <div class="btn-group pull-right">
                                        <asp:Button ID="installmentSave" CssClass="btn btn-sm btn-primary" ValidationGroup="ValidationButton" runat="server" Text="Save" OnClick="installmentSave_Click" />
                                        <asp:Button ID="btnPaymentSave" Visible="false" runat="server" CssClass="btn btn-sm btn-primary" Text="Save" OnClick="btnPaymentSave_Click" OnClientClick="return checkAllotment2()" />
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="panel panel-default">
                            <%--<div class="panel-heading" style="width: 100%;">Recieved payment as on date</div>--%>
                            <div class="panel-body">
                                <%-- OnRowCreated="gridviewpayment_RowCreated" --%>
                                <div class="table-responsive hidden">
                                    <asp:GridView ID="gridviewpayment" ViewStateMode="Enabled" DataKeyNames="Id" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" Width="100%" runat="server" ShowFooter="true"
                                        AutoGenerateColumns="false" OnDataBound="OnDataBound"
                                        OnRowDeleting="LinkDelete_Click">
                                        <Columns>

                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Payment Mode">
                                                <ItemTemplate>
                                                    <asp:Label ID="LBLPaymentMode" runat="server" Text='<%#Eval("ModeOfPayment") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="drpdPaymentMode" AutoPostBack="true" OnSelectedIndexChanged="drpdPaymentMode_SelectedIndexChanged" CssClass="input-sm similar-select1" runat="server">
                                                        <asp:ListItem Text="Demand Draft" Value="Demand Draft"></asp:ListItem>
                                                        <asp:ListItem Text="Online Payment" Value="Online Payment"></asp:ListItem>
                                                        <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                                        <asp:ListItem Text="Bank Guarantee" Value="Bank Guarantee"></asp:ListItem>

                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Bank">
                                                <ItemTemplate>
                                                    <asp:Label ID="LBLPaymentBank" runat="server" Text='<%#Eval("BankName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtPaymentBank" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Detail No">
                                                <ItemTemplate>

                                                    <asp:Label ID="lblDraftNo" runat="server" Text='<%#Eval("DraftNo") %>'></asp:Label>
                                                    <asp:Label ID="lblTransactionNo" runat="server" Text='<%#Eval("TransactionNo") %>'></asp:Label>
                                                    <asp:Label ID="lblChequeNo" runat="server" Text='<%#Eval("ChequeNo") %>'></asp:Label>

                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtDraftNo" placeholder="Draft No" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                                    <asp:TextBox Visible="false" ID="txtTransactionNo" placeholder="Transaction No" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                                    <asp:TextBox Visible="false" ID="txtChequeNo" placeholder="Cheque No" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>

                                                </FooterTemplate>
                                            </asp:TemplateField>




                                            <asp:TemplateField HeaderText="Issue Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="LBLPaymentIssueDate" runat="server" Text='<%#Eval("EssueDate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtPaymentIssueDate" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Received Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="LBLPaymentReceivedDate" runat="server" Text='<%#Eval("PaymentReicvedDate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtPaymentReceivedDate" CssClass="date input-sm similar-select1" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>



                                            <asp:TemplateField HeaderText="Amount(INR)">
                                                <ItemTemplate>
                                                    <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("PaymentAmount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                    <asp:TextBox ID="txtAmount" Width="90%" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField ItemStyle-Width="30%" HeaderText="Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("PaymentDescription") %>'></asp:Label>
                                                </ItemTemplate>

                                                <FooterTemplate>


                                                    <asp:TextBox ID="txtPaymentDescription" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>


                                                    <asp:PopupControlExtender
                                                        ID="TextBox1_PopupControlExtender" runat="server"
                                                        Enabled="True" ExtenderControlID=""
                                                        TargetControlID="txtPaymentDescription"
                                                        PopupControlID="Panel1" OffsetY="25" OffsetX="-80">
                                                    </asp:PopupControlExtender>
                                                    <asp:Panel ID="Panel1" runat="server"
                                                        Height="250px" BorderStyle="Ridge" BorderWidth="1px"
                                                        Direction="LeftToRight" ScrollBars="Auto" BackColor="#EEEEEE" Style="display: none">

                                                        <asp:CheckBoxList ID="chkListPaymentDescription" runat="server" AutoPostBack="True"
                                                            OnSelectedIndexChanged="chkListPaymentDescription_SelectedIndexChanged">


                                                            <asp:ListItem Text="Adv. Premium" Value="Adv. Premium"></asp:ListItem>
                                                            <asp:ListItem Text="Advance Interest" Value="Advance Interest"></asp:ListItem>
                                                            <asp:ListItem Text="Building Plan & Approval Fee" Value="Building Plan & Approval Fee"></asp:ListItem>
                                                            <asp:ListItem Text="Cost of Existing Construction" Value="Cost of Existing Construction"></asp:ListItem>
                                                            <asp:ListItem Text="CETP Charges" Value="CETP Charges"></asp:ListItem>
                                                            <asp:ListItem Text="Compounding Fees (MAP)" Value="Compounding Fees (MAP"></asp:ListItem>
                                                            <asp:ListItem Text="Drain Charges" Value="Drain Charges"></asp:ListItem>
                                                            <asp:ListItem Text="Development Charges" Value="Development Charges"></asp:ListItem>
                                                            <asp:ListItem Text="Earnest Money" Value="Earnest Money"></asp:ListItem>
                                                            <asp:ListItem Text="GST" Value="GST"></asp:ListItem>
                                                            <asp:ListItem Text="Interest on Premium" Value="Interest"></asp:ListItem>
                                                            <asp:ListItem Text="Interest on Maintenance Charge" Value="Interest on Maintenance Charge"></asp:ListItem>
                                                            <asp:ListItem Text="Interest on T.E.F." Value="Interest on T.E.F."></asp:ListItem>
                                                            <asp:ListItem Text="Interest on Transfer Levy" Value="Interest on Transfer Levy"></asp:ListItem>
                                                            <asp:ListItem Text="Interest on Reservation Money" Value="Interest on Reservation Money"></asp:ListItem>
                                                            <asp:ListItem Text="Interest on Restoration Levy" Value="Interest on Restoration Levy"></asp:ListItem>
                                                            <asp:ListItem Text="Interest on Sub-Letting Charges" Value="Interest on Sub-Letting Charges"></asp:ListItem>
                                                            <asp:ListItem Text="Interest on Sub-Division Fees" Value="Interest on Sub-Division Fees"></asp:ListItem>
                                                            <asp:ListItem Text="Interest on Water Charges" Value="Interest on Water Charges"></asp:ListItem>
                                                            <asp:ListItem Text="Interest on Sewer Charges" Value="Interest on Sewer Charges"></asp:ListItem>
                                                            <asp:ListItem Text="Interest on Drain Charges" Value="Interest on Drain Charges"></asp:ListItem>
                                                            <asp:ListItem Text="Interest on Development Charges" Value="Interest on Development Charges"></asp:ListItem>
                                                            <asp:ListItem Text="Interest on Cost of Existing Construction" Value="Interest on Cost of Existing Construction"></asp:ListItem>
                                                            <asp:ListItem Text="Interest on Service Charges" Value="Interest on Service Charges"></asp:ListItem>
                                                            <asp:ListItem Text="Lease Rent" Value="Lease Rent"></asp:ListItem>
                                                            <asp:ListItem Text="Maintenance Charges" Value="Maintenance Charges"></asp:ListItem>
                                                            <asp:ListItem Text="Map Fees(UPSIDA)" Value="Payable to UPSIDA (Map Fees)"></asp:ListItem>
                                                            <asp:ListItem Text="Map Fees(Dev. Authority)" Value="Map Charges Payable to Dev. Authority"></asp:ListItem>
                                                            <asp:ListItem Text="Processing Fee" Value="Processing Fee"></asp:ListItem>
                                                            <asp:ListItem Text="Reservation Money" Value="Reservation Money"></asp:ListItem>
                                                            <asp:ListItem Text="Restoration Levy" Value="Restoration Levy"></asp:ListItem>
                                                            <asp:ListItem Text="Service Tax" Value="Service Tax"></asp:ListItem>
                                                            <asp:ListItem Text="Service Charges" Value="Service Charges"></asp:ListItem>
                                                            <asp:ListItem Text="Subletting Charge" Value="Subletting Charge"></asp:ListItem>
                                                            <asp:ListItem Text="Sub-Division Fees" Value="Sub-Division Fees"></asp:ListItem>
                                                            <asp:ListItem Text="Sewer Charges" Value="Sewer Charges"></asp:ListItem>
                                                            <asp:ListItem Text="Supervision & Stacking Charges" Value="Supervision & Stacking Charges"></asp:ListItem>
                                                            <asp:ListItem Text="Transfer Levy" Value="Transfer Levy"></asp:ListItem>
                                                            <asp:ListItem Text="Time Extension Fees" Value="Time Extension Fees"></asp:ListItem>
                                                            <asp:ListItem Text="Use & Occupation Charge" Value="Use & Occupation Charge"></asp:ListItem>
                                                            <asp:ListItem Text="Water Connection Charge" Value="Water Connection Charge"></asp:ListItem>
                                                            <asp:ListItem Text="Water Charges" Value="Water Charges"></asp:ListItem>

                                                        </asp:CheckBoxList>
                                                    </asp:Panel>

                                                    <%-- <asp:TextBox ID="txtDescription"  CssClass="form-control" runat="server"></asp:TextBox>--%>
                                                </FooterTemplate>
                                            </asp:TemplateField>



                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                        ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

                                                </ItemTemplate>
                                                <FooterStyle HorizontalAlign="Right" />
                                                <FooterTemplate>
                                                    <asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square" OnClick="ButtonAdd_Click" ID="ButtonAdd" runat="server" Height="16px"
                                                        ImageUrl="~/images/add.png" Width="16px" OnClientClick="return checkAllotment3()" />


                                                </FooterTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <script>
                                        $().ready(function () {
                                            $("#<%= gridviewinstallment.ClientID%>").find("tr").each(function () {
                                                $(this).find("td").each(function () {
                                                    $(this).find("input[id*=txtInterestDue_insert]").keyup(function () {
                                                        var val1 = $(this).parent("td").parent("tr").find(".txtclass1").val();
                                                        var val2 = $(this).parent("td").parent("tr").find(".txtclass2").val();
                                                        if (val2 == "") {
                                                            val2 = 0
                                                        }
                                                        var valT = parseFloat(isNaN(val1) ? 0 : val1) + parseFloat(isNaN(val2) ? 0 : val2);
                                                        $(this).parent("td").parent("tr").find(".lblClass1").text(valT);

                                                    });
                                                });
                                            });
                                            $("#<%= gridviewinstallment.ClientID%>").find("tr").each(function () {
                                                $(this).find("td").each(function () {
                                                    $(this).find("input[id*=txtPremiumDue_insert]").keyup(function () {
                                                        var val1 = $(this).parent("td").parent("tr").find(".txtclass1").val();
                                                        if (val1 == "") {
                                                            val1 = 0;
                                                        }
                                                        var val2 = $(this).parent("td").parent("tr").find(".txtclass2").val();
                                                        if (val2 == "") {
                                                            val2 = 0;
                                                        }
                                                        var val3 = $(this).parent("td").parent("tr").find(".txtclass3").val();
                                                        if (val3 == "") {
                                                            val3 = 0;
                                                        }
                                                        var valT = parseFloat(isNaN(val1) ? 0 : val1) + parseFloat(isNaN(val2) ? 0 : val2);
                                                        var valT2 = parseFloat(isNaN(val3) ? 0 : val3) + parseFloat(isNaN(val2) ? 0 : val2);
                                                        $(this).parent("td").parent("tr").find(".lblClass1").text(valT);
                                                        $(this).parent("td").parent("tr").find(".lblClass2").text(valT2);

                                                    });
                                                });
                                            });
                                            $("#<%= gridviewinstallment.ClientID%>").find("tr").each(function () {
                                                $(this).find("td").each(function () {
                                                    $(this).find("input[id*=txtInterestDuewithout_insert]").keyup(function () {
                                                        var val1 = $(this).parent("td").parent("tr").find(".txtclass3").val();
                                                        if (val1 == "") {
                                                            val1 = 0
                                                        }
                                                        var val2 = $(this).parent("td").parent("tr").find(".txtclass2").val();
                                                        if (val2 == "") {
                                                            val2 = 0;
                                                        }
                                                        var valT = parseFloat(isNaN(val1) ? 0 : val1) + parseFloat(isNaN(val2) ? 0 : val2);
                                                        $(this).parent("td").parent("tr").find(".lblClass2").text(valT);

                                                    });
                                                });
                                            });
                                        });

                                    </script>
                                    <label for="InstalmentPaid" class="col-md-2 col-sm-12 col-xs-12 text-right">
                                        All Instalment Paid :
                                    </label>
                                    <div class="col-md-10 col-sm-12 col-xs-12">
                                        <asp:DropDownList runat="server" ID="ddlInstalment" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlInstalment_SelectedIndexChanged">
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <div runat="server" id="Instalmentpaid" visible="false">
                                        <div class="panel-heading">Installment Schedule </div>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gridviewinstallment" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="gridviewinstallment_Click">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="Due Date of Installment">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDueDateofInstallment" runat="server" Text='<%#Eval("DueDateofInstallment") %>' placeholder="dd/mm/yyyy"></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtDueDateofInstallment_insert" CssClass="date input-sm similar-select1" runat="server" Width="150px"></asp:TextBox>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="Interest Due(With Rebate)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInterestDue" runat="server" Text='<%#Eval("InterestDue") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtInterestDue_insert" runat="server" CssClass="txtclass1 form-control input-sm" onkeypress="return isDecimalKey(event);" Width="150px"></asp:TextBox>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="Interest Due(Without Rebate)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="InterestDuewithout" runat="server" Text='<%#Eval("InterestDuewithout") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtInterestDuewithout_insert" CssClass="txtclass3 form-control input-sm" runat="server" onkeypress="return isDecimalKey(event);" Width="150px"></asp:TextBox>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="Premium Due">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPremiumDue" runat="server" Text='<%#Eval("PremiumDue") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtPremiumDue_insert" CssClass="txtclass2 form-control input-sm" runat="server" Width="150px" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="Total Amount(With Rebate)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblTotalAmount" CssClass="lblClass1" runat="server"></asp:Label>
                                                            <%--<asp:TextBox ID="txtTotalAmount_insert" CssClass="form-control input-sm" runat="server" Width="150px" onkeypress="return isDecimalKey(event);" Enabled="false"></asp:TextBox>--%>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="Total Amount(Without Rebate)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmountRebate" CssClass="lblClass2" runat="server" Text='<%#Eval("TotalAmountRebate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblTotalAmountRebate" CssClass="lblClass2" runat="server"></asp:Label>

                                                            <%--<asp:TextBox ID="txtTotalAmountRebate_insert" CssClass="form-control input-sm"  runat="server" Width="150px" Enabled="false"></asp:TextBox>--%>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                                ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <FooterTemplate>
                                                            <%-- <asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square" ID="ButtonAdd" runat="server" Height="16px" OnClick="insert_shareholder_details"
                                                            ImageUrl="~/images/add.png" Width="16px" />--%>
                                                            <asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square" ID="ButtonAdd" runat="server" Height="16px" OnClick="insert_installment_details"
                                                                ImageUrl="~/images/add.png" Width="16px" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:GridView ID="gridInstallment" runat="server" AutoGenerateColumns="false"
                                                AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                            </asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DueDateofInstallment" HeaderText="Due Date of Installment" SortExpression="DueDateofInstallment" />
                                                    <asp:BoundField DataField="InterestDue" HeaderText="Interest Due(Without Rebate)" SortExpression="InterestDue" />
                                                    <asp:BoundField DataField="InterestDuewithout" HeaderText="Interest Due(Without Rebate)" SortExpression="InterestDuewithout" />
                                                    <asp:BoundField DataField="PremiumDue" HeaderText="Premium Due" SortExpression="PremiumDue" />
                                                    <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount(With Rebate)" SortExpression="TotalAmount" />
                                                    <asp:BoundField DataField="TotalAmountRebate" HeaderText="Total Amount(Without Rebate)" SortExpression="TotalAmountRebate" />

                                                </Columns>
                                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>

                                            </asp:GridView>
                                        </div>
                                        <div class="btn-group pull-right">
                                            <asp:Button ID="btnInstallmentSave" runat="server" CssClass="btn btn-sm btn-primary" Text="Save" OnClick="btnInstallmentSave_Click" />
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <table id="tblPayment" style="display: none" class="table table-striped table-responsive table-bordered table-hover">
                            <tr>
                                <td class="auto-style2">
                                    <span style="color: Red">*</span>
                                    Total Area :
                                </td>
                                <td>
                                    <asp:TextBox ID="txttotalAreaPayment" runat="server" CssClass="form-control" Width="200px" onkeypress="return validate_total_area(event)"></asp:TextBox>

                                </td>

                                <td class="auto-style2">
                                    <span style="color: Red">*</span>
                                    Rate of Interest:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRateofInterest" runat="server" CssClass="form-control" Width="200px" onkeypress="return validate_Roi(event)"></asp:TextBox>

                                </td>

                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <span style="color: Red">*</span>
                                    Rate at time of allotment
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRateatTimeAllotment" runat="server" CssClass="form-control" Width="200px" onkeypress="return validate_rate_allotment(event)"></asp:TextBox>

                                </td>


                                <td class="auto-style2">
                                    <span style="color: Red">*</span>
                                    Allotment Date
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAllotmentDate" CssClass="date form-control" runat="server" Width="200px" placeholder="dd/mm/yyyy"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <span style="color: Red">*</span>
                                    Rebate for Non Defaulters 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDefaulters" runat="server" CssClass="form-control" Width="200px" onkeypress="return validate_rebate(event)"></asp:TextBox>

                                </td>

                                <td class="auto-style2">
                                    <span style="color: Red">*</span>
                                    No of Installments
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInstallment" runat="server" CssClass="form-control" Width="200px" onkeypress="return validate_no_of_installment(event)"></asp:TextBox>

                                </td>

                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <span style="color: Red">*</span>
                                    Location Charges
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLocationCharges" runat="server" CssClass="form-control" Width="200px" onkeypress="return validate_loc_charges(event)"></asp:TextBox>

                                </td>

                                <td class="auto-style2">
                                    <span style="color: Red">*</span>
                                    Earnest Money Rate
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMoneyRate" runat="server" CssClass="form-control" Width="200px" onkeypress="return validate_earn_money_rate(event)"></asp:TextBox>

                                </td>

                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <span style="color: Red">*</span>
                                    Reservation Money Paid witin 30 days
                                </td>
                                <td>
                                    <asp:TextBox ID="txtReservationMoney" runat="server" CssClass="form-control" Width="200px" onkeypress="return validate_reservation_money(event)"></asp:TextBox>

                                </td>


                                <td class="auto-style2">
                                    <span style="color: Red">*</span>
                                    Demant Notice Date 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDemantNoticeDate" CssClass="date form-control" runat="server" Width="200px" placeholder="dd/mm/yyyy"></asp:TextBox>

                                </td>

                            </tr>
                            <tr>


                                <td class="auto-style2">
                                    <span style="color: Red">*</span>
                                    Demant Notice Date2
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDemantNoticeDate2" CssClass="date form-control" runat="server" Width="200px" placeholder="dd/mm/yyyy"></asp:TextBox>

                                </td>

                                <td colspan="3"></td>

                            </tr>
                        </table>
                    </div>
                </div>

            </div>
        </div>
    </asp:View>

    <asp:View ID="View4" runat="server">
        <a onclick="Registration4()">
            <i class="fa fa-print" aria-hidden="true"></i>
            <br />

        </a>
        <div class="btn-group">
        </div>
        <div class="row" id="AllotteeRegistration4">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="panel panel-default">
                    <div class="panel-heading" style="width: 100%;">
                        <div class="row">
                            <div class="">
                                <div class="col-md-3 col-sm-3 col-xs-3" style="display: none;">
                                    <div class="btn-group">
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-sm btn-primary" Text="Move Previous" OnClick="Previous3_Click" />
                                        <%--  <asp:Button ID="Button2" runat="server" class="btn btn-sm btn-primary" Text="Move Next"  OnClick="Next4_Click" />--%>
                                    </div>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                    <p>Allottee/Transfree Registration (5/5) Details </p>
                                </div>

                                <div class="col-md-3 col-sm-3 col-xs-3" style="display: none;">
                                    <div class="btn-group">
                                        <%--   <asp:Button ID="Button2" runat="server" class="btn btn-sm btn-primary" Text="Move Previous" OnClick="Previous2_Click" />
                                               <asp:Button ID="Button2" runat="server" class="btn btn-sm btn-primary" Text="Move Next"  OnClick="Next4_Click" />--%>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="panel-body" id="Divv1">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12 mydiv-left">
                                <div class="panel panel-default">
                                    <div class="panel-heading font-bold allot-heading" style="">
                                        General Information (1/5)                           
                                    </div>
                                    <div class="panel-body allottee-project-details" style="padding: 0px !important;">
                                        <div class="list-group" style="padding: 0px !important;">

                                            <div class="form-group">
                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                    Industrial Area :
                                                </label>
                                                <div class="col-md-9 col-sm-6 col-xs-6">
                                                    <em class="text-muted small">
                                                        <asp:Label ID="lblindarea" runat="server"></asp:Label></em>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div style="border: 1px solid #ccc;">
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Applicant Id :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblletterno" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Allotment Letter No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAllotmentRef" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Date of Application :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblallotmentdate" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Plot No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblPlotno" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        File No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblfileNo" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Sector :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSector" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Total Allotted Plot Area (in Sqmts.) : 
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lbl_alloted_parea" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        Allotment Rate :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAllotmentRate" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        LocationCharge(if Any) :
                                                    </label>
                                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblLocationCharge" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        InterestRateApplicable :
                                                    </label>
                                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblInterestRateApplicable" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        PanelRateApplicable :
                                                    </label>
                                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblPanelRateApplicable" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Ground Coverage :
                                                    </label>
                                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblGroundCoverage" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Permisable FAR :
                                                    </label>
                                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblPermisableFAR" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Name Of The Firm/Company/Society :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblCompany" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Firm/Company Constitution :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblConstitution" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Firm/Company Pan No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblPan" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Firm/Company Cin No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblCin" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Authorised User :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAuthorisedSignatory" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Mobile : 
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblmobile" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Email : 
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAuthoriseduseremail" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Address :   
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAuthoriseduseraddress" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading" style="text-align: center;">
                                        Allottee Project Details                        
                                    </div>
                                    <div class="panel-body allottee-project-details">
                                        <div class="panel panel-default">
                                            <div class="panel-heading allot-heading">Type of industry to be set up</div>
                                            <div class="panel-body" style="padding: 0px !important;">
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <label for="">Type Of Industry&nbsp;:</label>
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <asp:Label ID="lblTypeOfIndustry" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                            <div class="panel-body" style="padding: 0px !important;">
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <label for="">Product Category&nbsp;:</label>
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <asp:Label ID="lblHSProductCategory" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                            <div class="panel-body" style="padding: 0px !important;">
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <label for="">Product Sub Category&nbsp;:</label>
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <asp:Label ID="lblHSProductSubCategory" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                            <div class="panel-body" style="padding: 0px !important;">
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <label for="">Product Name&nbsp;:</label>
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <asp:Label ID="lblHSProductName" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                        </div>

                                        <div class="panel panel-default">
                                            <div class="panel-heading allot-heading">Project Costing Details</div>
                                            <div class="panel-body" style="padding: 0px !important;">
                                                <div class="form-group">
                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <label for="">Estimated Cost Of the project(In Lacs)&nbsp;:</label>
                                                    </div>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                        <asp:Label ID="lblestimatedcost" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <label for="">Estimated employment generation&nbsp;:</label>
                                                    </div>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <asp:Label ID="lblestimatedemployment" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <label for="">Work Experience&nbsp;:</label>
                                                    </div>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <asp:Label ID="lblworkexperience" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <label for="">Project Start Period(In Months) &nbsp;:</label>
                                                    </div>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <asp:Label ID="lblProjectStartPeriod" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                        </div>


                                        <div class="panel panel-default">
                                            <div class="panel-heading allot-heading">Layout plan of land indicating broadly</div>
                                            <div class="panel-body" style="padding: 0px !important;">
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Covered Area&nbsp;(In %)&nbsp;:
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <asp:Label ID="lblcoveredarea" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Open area required and its purpose&nbsp;(In %)&nbsp;:
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <asp:Label ID="lblopenarea" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        FAR&nbsp;(In %)&nbsp;:
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <asp:Label ID="lblFAR" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                        </div>



                                        <div class="panel panel-default">
                                            <div class="panel-heading allot-heading">Details of the investment(in Rs)</div>
                                            <div class="panel-body" style="padding: 0px !important;">
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right" title="date ofsubmission">
                                                        Land&nbsp;(In Lacs)&nbsp;:
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                        <asp:Label ID="lblland" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Building&nbsp;(In Lacs)&nbsp;:
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                        <asp:Label ID="lblbuilding" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Machinery & Equipments&nbsp;(In Lacs)&nbsp;:
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                        <asp:Label ID="lblMachinery" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Other Fixed Assets&nbsp;(In Lacs)&nbsp;:
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                        <asp:Label ID="lblFixedAssets" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Net TurnOver&nbsp;(In Lacs)&nbsp;:
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                        <asp:Label ID="lblNetTurnOver" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Net Worth&nbsp;(In Lacs)&nbsp;:
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                        <asp:Label ID="lblNetWorth" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Other Expenses&nbsp;(In Lacs)&nbsp;:
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                        <asp:Label ID="lblOtherExpenses" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Bank/FI(Financial Institutions):
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                        <asp:Label ID="lblFI" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        own resources:
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                        <asp:Label ID="lblownresources" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                        <div class="panel panel-default">
                                            <div class="panel-heading">Any fumes generated in the process of manufacture and if so, their nature and quantity &nbsp; <span runat="server" id="fume_span"></span></div>
                                            <div class="panel-body" style="padding: 0px !important;" id="fumeDiv1" runat="server" visible="false">
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Nature&nbsp;:
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <asp:Label ID="lblFumeNature" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Quantity&nbsp;:
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <asp:Label ID="lblFumeQty" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                        </div>



                                        <div class="panel panel-default">
                                            <div class="panel-heading allot-heading">Industrial Effluents </div>
                                            <div class="panel-body table-responsive" style="padding: 0px !important;">
                                                <table class="table table-hover table-bordered request-table" style="width: 100%;">
                                                    <tr>
                                                        <td style="width: 24%;">Name</td>
                                                        <td style="width: 38%;">Quantity</td>
                                                        <td style="width: 38%;">Chemical Composition</td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="pull-right">(i)&nbsp;Solid :</span></td>
                                                        <td>
                                                            <asp:Label ID="lblEffluentSolidQty" runat="server"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblEffluentSolidComposition" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="pull-right">(ii)&nbsp;Liquid :</span></td>
                                                        <td>
                                                            <asp:Label ID="lblEffluentLiquidQty" runat="server"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblEffluentLiquidComposition" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="pull-right">(iii)&nbsp;Gaseous :</span></td>
                                                        <td>
                                                            <asp:Label ID="lblEffluentGaseousQty" runat="server"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblEffluentGaseousComposition" runat="server"></asp:Label></td>
                                                    </tr>
                                                </table>



                                            </div>
                                        </div>



                                        <div class="panel panel-default">
                                            <div class="panel-heading allot-heading">Effluent Treatment Measures</div>
                                            <div class="panel-body" style="padding: 0px !important;">


                                                <div class="row aks-row">

                                                    <div class="col-md-4 col-sm-6 col-xs-12 form-inline font-12px">
                                                        <asp:Label ID="lblEffluentMeasure1" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-4 col-sm-6 col-xs-12 form-inline font-12px">
                                                        <asp:Label ID="lblEffluentMeasure2" runat="server"></asp:Label>

                                                    </div>



                                                    <div class="col-md-4 col-sm-6 col-xs-12 form-inline font-12px">
                                                        <asp:Label ID="lblEffluentMeasure3" runat="server"></asp:Label>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>

                                        <div class="panel panel-default">
                                            <div class="panel-heading allot-heading">Power Requirement (in KW)</div>
                                            <div class="panel-body" style="padding: 0px !important;">


                                                <div class="form-group">

                                                    <label class="col-md-3 col-sm-6 col-xs-6 form-inline text-right">Units &nbsp;:</label>

                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <asp:Label ID="lblPowerReq" runat="server"></asp:Label>

                                                    </div>


                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                        </div>

                                        <div class="panel panel-default">
                                            <div class="hidden">
                                                <div class="panel-heading allot-heading">Telephone Requirement</div>
                                                <div class="panel-body" style="padding: 0px !important;">


                                                    <div class="form-group">

                                                        <div class="col-md-3 col-sm-6 col-xs-6 text-right">First Year&nbsp;:</div>

                                                        <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:Label ID="lblTReq1" runat="server"></asp:Label>

                                                        </div>
                                                        <div class="col-md-3 col-sm-3 col-xs-3">
                                                            <asp:Label ID="lblTReq2" runat="server"></asp:Label>

                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">Ultimate Requirement&nbsp;:</div>

                                                    <div class="col-md-3 col-sm-3 col-xs-3">
                                                        <asp:Label ID="lblTUReq1" runat="server"></asp:Label>

                                                    </div>
                                                    <div class="col-md-3 col-sm-3 col-xs-3">
                                                        <asp:Label ID="lblTUReq2" runat="server"></asp:Label>

                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                        </div>


                                        <div class="panel panel-default">
                                            <div class="panel-heading">Is the applicant under priority category ? Please specify clearly &nbsp; <span runat="server" id="priority_span"></span></div>
                                            <div id="Prioritydiv1" class="panel-body" style="padding: 0px !important;" runat="server" visible="false">
                                                <div class="row aks-row">


                                                    <div class="col-md-3 col-sm-6 col-xs-6">Specification&nbsp;:</div>

                                                    <div class="col-md-3 col-sm-6 col-xs-6">
                                                        <asp:Label ID="lblspec" runat="server"></asp:Label>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>



                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12 col-sm-12 col-xs-12 mydiv-right">
                                <div class="panel panel-default">
                                    <div class="panel-heading font-bold allot-heading" style="">
                                        <div class="row">

                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                Allottees Important Facts (2/5) 
                                            </div>

                                        </div>


                                    </div>
                                    <div class="panel-body allottee-project-details" style="padding: 0px !important;">

                                        <div class="" style="padding: 0px !important;">
                                            <div style="border: 1px solid #ccc;">
                                                <div class="form-group" style="display: none;">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Product Manufactured : 
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lbl_manufactured_product" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Case Type : 
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblCaseType" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div runat="server" id="Case2" visible="false">
                                                    <div class="panel-heading allot-heading" style="">
                                                        Transfer Case                         
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Date of First Allotment(Allotment date of First Allottee of plots) : 
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="lblDateofFirstAllotment" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Allotment reference number of first allotment : 
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="lblAllotmentreferencenumber" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Applicable Transfer Levy : 
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="lblTransferLevy" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Pending Dues from previous allottee carry forward  : 
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                                <asp:Label ID="lblPendingdues" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div runat="server" id="Changeofplot1" visible="false">
                                                        <div class="panel-heading allot-heading" style="">
                                                            Change of Plot Detail                         
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Date of First Allotment(Allotment date of First Allottee of plots) : 
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <em class="text-muted small">
                                                                    <asp:Label ID="lblDateofFirstAllotment1" runat="server"></asp:Label></em>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Allotment reference number of first allotment : 
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <em class="text-muted small">
                                                                    <asp:Label ID="lblAllotmentreferencenumber1" runat="server"></asp:Label></em>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Change of Plot Ref No :
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <em class="text-muted small">
                                                                    <asp:Label ID="lblChangeofPlotRefNo" runat="server"></asp:Label></em>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Change of Plot Ref Date :
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <em class="text-muted small">
                                                                    <asp:Label ID="lblChangeofPlotRefDate" runat="server"></asp:Label></em>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Additional Charges for plot :
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <em class="text-muted small">
                                                                    <asp:Label ID="lblAdditionalChargesforplot" runat="server"></asp:Label></em>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Deed after Change of Plot :
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <em class="text-muted small">
                                                                    <asp:Label ID="lblDeedafterChangeofPlot" runat="server"></asp:Label></em>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Existing Construction Value at plot : 
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label89" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Allotment letter IssueDate :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lbl_allotment_issue_date" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Details of Reservation Money                          
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        If Reservation Money Paid   :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblReservationMoneyStatus" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        Reservation Money Payment Date  :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblReservationMoneyPaymentDate" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        Reservation Money Payment Amount  :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblReservationMoneyPaymentAmount" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        If Operational maintenance charges Applicable   :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblOperationalmaintenance" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Lease Deed Detail                         
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        If Lease Deed Signed    :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblLeaseDeedStatus" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Lease Deed Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lbl_lease_date" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Lease Deed Exec Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lbl_lease_agreement_date" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Book No(Bahi) :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblBookNo" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Bookbinding No(Jild) :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="LblBookBinding" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        S.No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="LblSNo" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Physical Possession  Detail                         
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        If Physical Possession    :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblPossessionLetterStatus" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Date Of Possession :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblPossessionDate" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Possession Area :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblPossessionArea" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Is possession area is different from allotted area :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lbldifferentareapossession" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Difference in area (SQM) :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblDifferenceinarea" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Amount recover /adjusted (INR) :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAmountadjusted" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Bulding Plan Detail                         
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Building Plan Approval :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblBuildingPlanStatus" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Date Of Bulding Plan Submission :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lbl_date_of_bps" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        other charges :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblothercharges" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Compounding Charges :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblCompoundingCharges" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Date Of Release For Completion :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lbl_date_of_rel_completion" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Release Date of Occupancy Certificate :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lbl_date_of_roc" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Date Of Inspection For Construction : 
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lbl_inspection_date" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Date Of Inspection For Completion :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lbl_inspection_date_for_complition" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Restoration Detail                         
                                                </div>

                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Restoration Ref No :
                                                    </label>
                                                    <div class="col-md-3 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblRestorationRefNo" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Restoration Ref Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblRestorationRefDate" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Restoration Levy :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblRestorationLevy" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Deed after Restoration :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblDeedafterRestoration" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />

                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Change of Project Detail                         
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Change of Project :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblChangeofProject1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Change of Project Ref No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblChangeofProjectRefNo" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Change of Project Ref Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblChangeofProjectRefDate" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Change for Changes :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblChangeforChanges" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Lease deed exceuted for increase of FAR :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblincreaseofFAR" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Amalgamation Detail                         
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Amalgamation :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label32" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Amalgamation Ref No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAmalgamationRefNo" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Amalgamation Ref Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAmalgamationDate" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Amalgamation Fees :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAmalgamationFees" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        UsabilityFees :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblUsabilityFees" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Rectification Deed Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblRectificationDeedDate" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Sub Division  Detail                         
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Sub Division :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label93" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Sub Div Ref No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSubDivRefNo" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Sub Div Ref Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSubDivRefDate" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Sub Div Type :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSubDivType" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        No of Plot Created :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblNoofPlotCreated" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        SubDiv Charges :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSubDivCharges" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Extension Charges :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblExtensionCharges" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Subletting  Detail                         
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Subletting :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label94" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Subletting Ref No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSublettingRefNo" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Subletting Ref Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSublettingRefDate" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Subletting Party Name :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSublettingPartyName" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Subletting Area (In Sqr.Mts) :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSubleetingArea" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Subletting For Years :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSublettingYears" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Subletting Project Name :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSublettingProjectName" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Subletting Project Name :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label2" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Subletting Charge :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSublettingCharge" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Agreement  Detail                         
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Agreement :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label95" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Date Of Agreement :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblDateOfAgreement" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Agreement Execution Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblDateOfAgreementExec" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Agreement On Plot Size :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAgreementOnPlotSize" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <hr style="margin: 8px 0;" />
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading allot-heading" style="">
                                        E-Stamp Details                           
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                            E-Stamp :
                                        </label>
                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                            <em class="text-muted small">
                                                <asp:Label ID="Label96" runat="server"></asp:Label></em>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="panel-body allottee-project-details" style="padding: 0px !important;">
                                        <div class="" style="padding: 0px !important;">

                                            <div style="border: 1px solid #ccc;">
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Certificate No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblCertificateNo" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Issue Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblIssueDate" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Stamp Duty Amount :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                            <asp:Label ID="lblStampDutyAmount" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Account Reference :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAccountReference" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Unique Doc Refence :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblUniqueDocReference" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                            </div>

                                        </div>


                                    </div>
                                </div>


                            </div>


                            <div class="col-md-12 col-sm-12 col-xs-12 ">

                                <div class="panel panel-default">
                                    <div class="panel-heading allot-heading" style="">
                                        Bank Guarantee Details                           
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                            Bank Guarantee :
                                        </label>
                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                            <em class="text-muted small">
                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                <asp:Label ID="Label97" runat="server"></asp:Label></em>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="panel-body allottee-project-details" style="padding: 0px !important;">
                                        <div class="" style="padding: 0px !important;">

                                            <div style="border: 1px solid #ccc;">
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Guarantee No : 
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblGuaranteeNo" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Guarantee Amount :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                            <asp:Label ID="lblGuaranteeAmount" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Guarantee Cover from :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblCoverFrom" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Guarantee Cover To :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblCoverTo" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Last Date Of Claim :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblLastDateOfClaim" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                            </div>

                                        </div>


                                    </div>
                                </div>

                            </div>

                            <div class="col-md-12 col-sm-12 col-xs-12 mydiv-right">

                                <div class="panel panel-default">
                                    <div class="panel-heading allot-heading" style="">
                                        Mortgage Details                           
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                            Mortgage :
                                        </label>
                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                            <em class="text-muted small">
                                                <asp:Label ID="Label98" runat="server"></asp:Label></em>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="panel-body allottee-project-details" style="padding: 0px !important;">
                                        <div class="" style="padding: 0px !important;">

                                            <div style="border: 1px solid #ccc;">
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Bank Proposal Letter :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblBankProposalLetter" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Bank Sanction Letter :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblBankSanctionLetter" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        UPSIDC Sanction letter:
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSanctionLetterUpsidc" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        No of Stamp :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblNoOfStamp" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Total Stamp Duty :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblTotalStampDuty" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                            </div>

                                        </div>


                                    </div>
                                </div>

                            </div>


                            <div class="col-md-12 col-sm-12 col-xs-12 mydiv-right">

                                <div class="panel panel-default">
                                    <div class="panel-heading allot-heading" style="">
                                        Interest Waiver Details                           
                                    </div>
                                    <div class="panel-body allottee-project-details" style="padding: 0px !important;">
                                        <div class="" style="padding: 0px !important;">

                                            <div style="border: 1px solid #ccc;">
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Period for which use at Possible  :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lbltimePeriod" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                        Time extension Waiver from :
                                                    </label>
                                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblTimeextensionWaiverfrom" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                        Time extension Waiver To :
                                                    </label>
                                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblTimeextensionWaiverTo" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Intt.on Time extension :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblInttonTimeextension" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Intt.on balance dues :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblbalancedues" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Maintenance Charges Waiver :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblMaintenanceChargesWaiver" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                            </div>

                                        </div>


                                    </div>
                                </div>

                            </div>


                            <div class="col-md-12 col-sm-12 col-xs-12 mydiv-right">

                                <div class="panel panel-default">
                                    <div class="panel-heading allot-heading" style="">
                                        Increase in FAR Details                           
                                    </div>
                                    <div class="panel-body allottee-project-details" style="padding: 0px !important;">
                                        <div class="" style="padding: 0px !important;">

                                            <div style="border: 1px solid #ccc;">
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        date of Increase in far  :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lbldateofIncreaseinfar" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        letter number :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblfarletternumber" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        letter date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblletterdate" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        changes in far :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblchangesinfar" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Payment :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblPayment" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        excution of deed :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblexcutionofdeed" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                            </div>

                                        </div>


                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="panel panel-default">
                            <p class="panel-heading font-bold allot-heading" style="">TEF  Details</p>
                            <div class="panel-body table-responsive">
                                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="TEFViewDetails" runat="server" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="Label22" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="TEFApprovalDate" HeaderText="TEF Approval Date" SortExpression="TEFApprovalDate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="TEFRefferenceNumber" HeaderText="TEF Refference Number" SortExpression="TEFRefferenceNumber" />
                                        <asp:BoundField DataField="TEFPeriod" HeaderText="TEF Period" SortExpression="TEFPeriod" />
                                        <asp:BoundField DataField="TEFFees" HeaderText="TEF Fees" SortExpression="TEFFees" />
                                    </Columns>


                                </asp:GridView>

                            </div>
                        </div>
                        <hr style="margin: 8px 0;" />
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="panel panel-default">
                                    <p class="panel-heading font-bold allot-heading" style="">Installment  Details</p>
                                    <div class="panel-body table-responsive">
                                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                        <asp:GridView ID="gvdInstallment" runat="server" AutoGenerateColumns="false"
                                            CssClass="table table-striped table-bordered table-hover request-table">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label22" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                        </asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DueDateofInstallment" HeaderText="Due Date of Installment" SortExpression="DueDateofInstallment" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="InterestDue" HeaderText="Interest Due" SortExpression="InterestDue" />
                                                <asp:BoundField DataField="InterestDuewithout" HeaderText="Interest Due without Rebet" SortExpression="InterestDuewithout" />
                                                <asp:BoundField DataField="PremiumDue" HeaderText="Premium Due" SortExpression="PremiumDue" />
                                                <asp:BoundField DataField="TotalAmount" HeaderText="TotalAmount" SortExpression="TotalAmount" />
                                                <asp:BoundField DataField="TotalAmountRebate" HeaderText="TotalAmountRebate" SortExpression="TotalAmountRebate" />

                                            </Columns>


                                        </asp:GridView>

                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <p class="panel-heading font-bold allot-heading" style="">Allottee Ledger</p>
                                    <div class="panel-body table-responsive">
                                        <asp:Label ID="Label21" runat="server" Text=""></asp:Label>
                                        <div class="panel-body table-responsive">
                                            <asp:Label ID="Label99" runat="server" Text=""></asp:Label>
                                            <div>
                                                <asp:GridView ID="AllotteePaymentSummaruGrid" runat="server" ShowFooter="true" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover request-table" OnRowDataBound="AllotteePaymentSummaruGrid_RowDataBound">
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PaymentName" HeaderText="Payment Head" />
                                                        <asp:BoundField DataField="Demanded" HeaderText="Demanded" />
                                                        <asp:BoundField DataField="Paid" HeaderText="Paid" />
                                                        <asp:BoundField DataField="Outstanding" HeaderText="Outstanding" />

                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        No Record Available
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <p class="panel-heading font-bold allot-heading" style="">Allottee Journal</p>
                                        <div runat="server" id="Journal_Div" class="panel-body gallery  table-responsive">
                                            <asp:Label ID="Label100" runat="server" Text=""></asp:Label>
                                            <asp:GridView ID="AllotteeJournalGrid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover request-table" OnRowDataBound="AllotteeJournalGrid_RowDataBound">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" />
                                                    <asp:BoundField DataField="PaymentName" HeaderText="Payment Head" />
                                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                                    <asp:BoundField DataField="Debit" HeaderText="Debit" />
                                                    <asp:BoundField DataField="Credit" HeaderText="Credit" />
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    No Record Available
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>


                                        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false"
                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                            <Columns>


                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label22" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                        </asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="PaymentReicvedDate" HeaderText="Payment Reicved Date" SortExpression="PaymentReicvedDate" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="PaymentAmount" HeaderText="Payment Amount" SortExpression="PaymentAmount" />
                                                <asp:BoundField DataField="PaymentDescription" HeaderText="Payment Description" SortExpression="PaymentDescription" />

                                            </Columns>


                                        </asp:GridView>

                                    </div>
                                </div>
                                <div class="panel panel-default" style="display: none;">
                                    <div class="panel-heading allot-heading" style="text-align: center;">
                                        Request For Allottee/Transfree Registration (3/5)                           
                                    </div>
                                    <div class="panel-body allottee-project-details" style="padding: 0px !important;">
                                        <div class="list-group" style="padding: 6px !important;">

                                            <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Rate Of Interest :   </span>
                                                <span class="pull-right text-muted small"><em>
                                                    <asp:Label ID="lbl_rate_of_interest" runat="server" Text="Ankit"></asp:Label></em>
                                                </span>
                                            </a>
                                            <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Rate at time of allotment :   </span>
                                                <span class="pull-right text-muted small"><em>
                                                    <asp:Label ID="lbl_rate_time_of_allotment" runat="server"></asp:Label></em>
                                                </span>
                                            </a>
                                            <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Rebate For Non Defaulters :   </span>
                                                <span class="pull-right text-muted small"><em>
                                                    <asp:Label ID="lbl_Rebate_For_Non_Defaulters" runat="server"></asp:Label></em>
                                                </span>
                                            </a>
                                            <a class="list-group-item" style="padding: 6px !important;">No Of Installment :                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lbl_No_Of_Installment" runat="server"></asp:Label></em>
                                    </span>
                                            </a>
                                            <a class="list-group-item" style="padding: 6px !important;">Location Charges :                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lbl_Location_Charges" runat="server"></asp:Label></em>
                                    </span>
                                            </a>

                                            <a class="list-group-item" style="padding: 6px !important;">Earnest Money Rate :                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lbl_Earnest_Money_Rate" runat="server"></asp:Label></em>
                                    </span>
                                            </a>
                                            <a class="list-group-item" style="padding: 6px !important;">Reservation Money Paid witin 30 days :                                  
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lbl_Reservation_Money_Paid_witin_30_days" runat="server"></asp:Label></em>
                                    </span>
                                            </a>
                                            <a class="list-group-item" style="padding: 6px !important;">Demant Notice Date1 :                                  
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lbl_Demant_Notice_Date1" runat="server"></asp:Label></em>
                                    </span>
                                            </a>
                                            <a class="list-group-item" style="padding: 6px !important;">Demant Notice Date2 :                                  
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lbl_Demant_Notice_Date2" runat="server"></asp:Label></em>
                                    </span>
                                            </a>

                                        </div>


                                    </div>
                                </div>
                            </div>


                            <%-- Propritar Grid --%>
                            <div class="col-md-12 col-sm-12 col-xs-12">


                                <div class="panel panel-default">
                                    <p class="panel-heading allot-heading" style="" runat="server" id="heading">Request for Allottee Transfree (4/5)</p>
                                    <div class="panel-body table-responsive">
                                        <asp:Label ID="Label15" runat="server" Text=""></asp:Label>
                                        <asp:GridView ID="Proprietar_Grid" runat="server" AutoGenerateColumns="false"
                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label16" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                        </asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="AllotteeName" HeaderText="Name" SortExpression="AllotteeName" />
                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />

                                            </Columns>
                                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                        </asp:GridView>

                                        <asp:GridView ID="Publiclimited_Grid" runat="server" AutoGenerateColumns="false"
                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                            <Columns>


                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label17" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                        </asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DirectorName" HeaderText="Director Name" SortExpression="DirectorName" />
                                                <asp:BoundField DataField="DIN_PAN" HeaderText="Din/Pan" SortExpression="DIN_PAN" />
                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="Phone" />
                                                <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />

                                            </Columns>
                                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>

                                        </asp:GridView>

                                        <asp:GridView ID="PrivateGrid" runat="server" AutoGenerateColumns="false"
                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                        </asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ShareholderName" HeaderText="Shareholder Name" SortExpression="ShareholderName" />
                                                <asp:BoundField DataField="SharePer" HeaderText="Share %" SortExpression="SharePer" />
                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />

                                            </Columns>
                                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>

                                        </asp:GridView>

                                        <asp:GridView ID="TrusteeGrid" runat="server" AutoGenerateColumns="false"
                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                            <Columns>


                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label19" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                        </asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="TrusteeName" HeaderText="Trustee Name" SortExpression="TrusteeName" />
                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="Phone" />
                                                <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />

                                            </Columns>
                                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>

                                        </asp:GridView>

                                        <asp:GridView ID="IndividualGrid" runat="server" AutoGenerateColumns="false"
                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                            <Columns>


                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label20" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                        </asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="AllotteeName" HeaderText="Proprietar Name" SortExpression="AllotteeName" />
                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />

                                            </Columns>
                                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                        </asp:GridView>

                                        <asp:GridView ID="PartnershipGrid" runat="server" AutoGenerateColumns="false"
                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                            <Columns>


                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                        </asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="PartnerName" HeaderText="Partner Name" SortExpression="PartnerName" />
                                                <asp:BoundField DataField="PartnershipPer" HeaderText="Partnership %" SortExpression="PartnershipPer" />
                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                <asp:BoundField DataField="EmailId" HeaderText="Email Id" SortExpression="EmailId" />

                                            </Columns>
                                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>

                                        </asp:GridView>


                                    </div>
                                </div>

                            </div>


                        </div>
                        <hr style="margin: 8px 0;" />
                        <p class="panel-heading allot-heading hidden" style="" runat="server" id="P3">Plot Legal History    </p>
                        <div class="table-responsive hidden">
                            <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" CssClass="table table-striped table-bordered table-hover request-table"
                                PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" OnPageIndexChanging="LegalGrid_PageIndexChanging" OnRowCommand="LegalGrid_RowCommand">
                                <Columns>


                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:BoundField DataField="CaseNo" HeaderText="Case No" SortExpression="CaseNo" />
                                    <asp:BoundField DataField="WeAre" HeaderText="We Are" SortExpression="WeAre" />
                                    <asp:BoundField DataField="LTPartyName" HeaderText="LT Party Name" SortExpression="LTPartyName" />
                                    <asp:BoundField DataField="Jurisdiction" HeaderText="Jurisdiction" SortExpression="Jurisdiction" />
                                    <asp:BoundField DataField="CourtDetails" HeaderText="Court Details" SortExpression="CourtDetails" />
                                    <asp:BoundField DataField="InCourtOf" HeaderText="In Court Of" SortExpression="InCourtOf" />
                                    <asp:BoundField DataField="MatterDetails" HeaderText="Matter Details" SortExpression="MatterDetails" />
                                    <asp:BoundField DataField="CaseStatus" HeaderText="Case Status" SortExpression="CaseStatus" />
                                    <asp:BoundField DataField="LitigatingParty" HeaderText="Litigating Party" SortExpression="LitigatingParty" />
                                    <asp:BoundField DataField="PetAdvocateName" HeaderText="Petitioner Advocate Name" SortExpression="PetAdvocateName" />
                                    <asp:BoundField DataField="PetAdvocateAddress" HeaderText="Petitioner Advocate Address" SortExpression="PetAdvocateAddress" Visible="false" />
                                    <asp:BoundField DataField="PetAdvocateContact" HeaderText="Petitioner Advocate Contact" SortExpression="PetAdvocateContact" Visible="false" />
                                    <asp:BoundField DataField="ResAdvocateName" HeaderText="Respondent Advocate Name" SortExpression="ResAdvocateName" />
                                    <asp:BoundField DataField="ResAdvocateAddress" HeaderText="Respondent Advocate Address" SortExpression="ResAdvocateAddress" Visible="false" />
                                    <asp:BoundField DataField="ResAdvocateContact" HeaderText="Respondent Advocate Contact" SortExpression="ResAdvocateContact" Visible="false" />
                                    <asp:BoundField DataField="CurrentStatus" HeaderText="Current Status" SortExpression="CurrentStatus" />
                                    <asp:BoundField DataField="NextHearingDate1" HeaderText="Next Hearing Date" SortExpression="NextHearingDate1" />
                                </Columns>
                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>

                            </asp:GridView>
                        </div>
                        <p class="panel-heading allot-heading " style="" runat="server" id="P5">Upload Document  Details  </p>
                        <asp:GridView ID="gvuploaddoc" runat="server"
                            CssClass="table table-striped table-bordered table-hover request-table" DataKeyNames="DocID"
                            AutoGenerateColumns="False"
                            GridLines="Horizontal"
                            OnRowCommand="gvuploaddoc_RowCommand"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DocType" HeaderText="Checklist" SortExpression="DocType" />
                                <asp:TemplateField>
                                    <HeaderStyle />
                                    <HeaderTemplate>
                                        <asp:Label ID="hlblimg" runat="server" Text=""></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" usesubmitbehavior="true" Text=''><i class="fa fa-download" aria-hidden="true"></i></asp:LinkButton>
                                        / 
                                               <asp:LinkButton ID="lbView1" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument" OnClientClick="return NewWindow();" usesubmitbehavior="true" Text=''><i class="fa fa-file-pdf-o" aria-hidden="true"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" HorizontalAlign="Left" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>

                        <hr style="margin: 8px 0;" />
                        <div class="row">
                        </div>
                        <div class="text-center">
                            <asp:CheckBox
                                ID="CheckBox_Final"
                                runat="server"
                                Text="&nbsp;&nbsp;I hereby Declared & certify that the Above Allotment Record are true and correct to the best of my knowledge."
                                OnCheckedChanged="Confirm_CheckBox_final"
                                AutoPostBack="true"
                                Font-Names="Serif"
                                Font-Size="14px" /><br />
                            <span style="text-align: center">
                                <asp:Button ID="Final_Submit" Visible="false" CssClass="btn btn-sm btn-primary text-right" runat="server" Text="Submit" OnClick="Final_Submit_Click" Enabled="false" /></span>
                        </div>
                        <%----------------------------------box----------------------------------------%>
                    </div>
                </div>
            </div>
        </div>


    </asp:View>

    <asp:View ID="View3" runat="server">
        <a onclick="Registration5()">
            <i class="fa fa-print" aria-hidden="true"></i>
            <br />

        </a>
        <div class="btn-group">
        </div>
        <div class="row" id="AllotteeRegistration5">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading" style="width: 100%;">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-3">
                                    <div class="btn-group">
                                        <asp:Button ID="Previous2" runat="server" CssClass="btn btn-sm btn-primary" Text="Move Previous" OnClick="Previous2_Click" />
                                        <asp:Button ID="Next4" runat="server" CssClass="btn btn-sm btn-primary" Text="Move Next" OnClick="Next4_Click" />
                                    </div>
                                </div>
                                <div class="col-md-8">
                                    <p>Allottee/Transfree Registration (4/5) - Document Details</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body gallery">
                        <span style="color: Red; font-size: 9px">(Upload only pdf File size max upto 1mb only)</span>
                        <table class="table table-striped  table-responsive  table-bordered table-hover">
                            <tr>
                                <td class="auto-style3">Attach Allotment Letter
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUploadAllotmentLetter" Width="250px" CssClass="form-control" runat="server" />

                                </td>
                                <td>
                                    <asp:Button ID="btnAllotmentLetter" runat="server" OnClick="btnAllotmentLetter_Click" CssClass="btn btn-sm btn-success" Text="Upload" />
                                </td>
                                <td>
                                    <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                                </td>

                            </tr>


                            <tr>
                                <td class="auto-style3">Attach Lease Deed
                                </td>
                                <td>
                                    <asp:FileUpload ID="FuLeaseDeed" Width="250px" CssClass="form-control" runat="server" />

                                </td>
                                <td>
                                    <asp:Button ID="btnFuLeaseDeed" runat="server" ValidationGroup="Validationlease" OnClick="btnFuLeaseDeed_Click" CssClass="btn btn-sm btn-success" Text="Upload" />
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Visible="false"></asp:Label>
                                </td>

                            </tr>




                            <tr>
                                <td class="auto-style3">Attach Inspection Report
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUploadInspection" Width="250px" CssClass="form-control" runat="server" />
                                </td>
                                <td>
                                    <asp:Button ID="btnUploadInspection" runat="server" ValidationGroup="ValidationInspection" OnClick="btnUploadInspection_Click" CssClass="btn btn-sm btn-success" Text="Upload" />
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">Attach Building Plan Document
                                </td>
                                <td>
                                    <asp:FileUpload ID="FudBuildingPlan" Width="250px" CssClass="form-control" runat="server" />
                                </td>
                                <td>
                                    <asp:Button ID="btnBuildingPlan" runat="server" OnClick="btnBuildingPlan_Click" CssClass="btn btn-sm btn-success" Text="Upload" />
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 20%" class="auto-style3">Attach Completion Certificate
                                </td>
                                <td style="width: 20%">
                                    <asp:FileUpload ID="FudCompletion" Width="250px" CssClass="form-control" runat="server" />
                                </td>
                                <td style="width: 15%">
                                    <asp:Button ID="btnCompletion" runat="server" OnClick="btnCompletion_Click" CssClass="btn btn-sm btn-success" Text="Upload" />
                                </td>
                                <td style="width: 40%">
                                    <asp:Label ID="Label4" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">Attach Occupancy Certificate
                                </td>
                                <td>
                                    <asp:FileUpload ID="FudOccupancy" Width="250px" CssClass="form-control" runat="server" />
                                </td>
                                <td>
                                    <asp:Button ID="btnOccupancy" runat="server" OnClick="btnOccupancy_Click" CssClass="btn btn-sm btn-success" Text="Upload" />
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <asp:GridView ID="GridViewDocument" runat="server" AutoGenerateColumns="false" OnRowCommand="GridViewDocument_RowCommand"
                                AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover"
                                OnPageIndexChanging="OnPagingChange">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColName" runat="server" Text='<%#Eval("ColName") %>'> 
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--                                 <asp:TemplateField HeaderText="Issue Date" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblColValue" runat="server" Text='<%# Eval("ColValue", "{0:dd/MMM/yyyy}")%>'> 
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# (Container.DataItemIndex)+1 %>'
                                                CommandName="selectDocument" Text='<%#Eval("ColName") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <EmptyDataTemplate>
                                    No Record Available
                                </EmptyDataTemplate>
                            </asp:GridView>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:View>
    <asp:View runat="server" ID="view8">
        <a onclick="Registration6()">
            <i class="fa fa-print" aria-hidden="true"></i>
            <br />
        </a>
        <div class="row" id="AllotteeRegistration6">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="panel panel-default ">
                    <div class="panel-heading" style="width: 100%;">
                        <div class="row">
                            <div class="">
                                <div class="col-md-3 btn-group" style="display: none;">
                                    <div class="btn-group">
                                        <asp:Button ID="Previous5" runat="server" CssClass="btn btn-sm btn-primary" Text="Move Previous" OnClick="Previous5_Click" />
                                        <asp:Button ID="Next5" CssClass="btn btn-sm btn-primary" runat="server" OnClick="Next5_Click" Text="Move Next" />
                                    </div>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                    <p>Allottee/Transfree Registration (2/5)</p>
                                </div>
                                <div class="col-md-3 btn-group" style="display: none;">
                                    <div class="btn-group pull-right">
                                        <asp:Button ID="btn_project_detail_submit" CssClass="btn btn-sm btn-primary" ValidationGroup="ValidationButton" OnClientClick="return ccheck2();" runat="server" Text="Save" OnClick="btn_project_detail_submit_Click" />
                                        <%-- <asp:Button ID="btnSubmit" CssClass ="btn btn-sm btn-primary" ValidationGroup="ValidationButton" runat="server" OnClick="btn_second_Click" Text="Save" />--%>
                                        <asp:Button ID="btn_project_details_reset" CssClass="btn btn-sm btn-primary" runat="server" OnClick="btn_project_details_reset_Click" Text="Reset" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <p class="panel-heading font-bold">Type of industry to be set up</p>
                        <div class="form-group">
                            <div class="row">
                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                    Type Of Industry :
                                </label>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <asp:DropDownList ID="ddlTypeOfIndustry" runat="server" CssClass="chosen margin-left-z input-sm similar-select1"></asp:DropDownList>
                                </div>
                                <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                                    Product Description :
                                </label>
                                <div class="col-md-4 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txttypeofindustry" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <p class="panel-heading font-bold">Product Details (As per HSN Code)</p>
                            <div class="form-group">
                                <div class="row">
                                    <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                        <span style="color: Red">*</span>
                                        Product Category(HSN_2 Code) :
                                    </label>
                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                        <asp:DropDownList ID="ddl_ProductCategory" runat="server" CssClass="chosen margin-left-z input-sm similar-select1" OnSelectedIndexChanged="ddl_ProductCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="row">
                                    <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                        <span style="color: Red">*</span>
                                        Product Sub Category(HSN_4 Code) :
                                    </label>
                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                        <asp:ListBox runat="server" ID="ddl_ProductSubCategory" CssClass="MultiSelect" SelectionMode="Multiple" Width="100%" OnSelectedIndexChanged="ddl_ProductSubCategory_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="row">
                                    <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                        <span style="color: Red">*</span>
                                        Product Name(HSN_8 Code) :
                                    </label>
                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                        <asp:ListBox runat="server" ID="lst_ProductName" CssClass="MultiSelect" SelectionMode="Multiple" Width="100%"></asp:ListBox>
                                    </div>
                                </div>
                            </div>

                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <p class="panel-heading">Project Costing Details</p>
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Cost Of the project(In Lacs):&nbsp;<i class="fa fa-inr" style="margin-right: 5px;"></i>
                                </label>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtestimatedcost" Width="98%" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Estimated Cost of the project');"></asp:TextBox>
                                </div>
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Employment generation:
                                </label>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtestimatedemployment" runat="server" CssClass="input-sm similar-select1" onkeypress="return isNumberKey(event);" onblur="ValidateRequired(this,'Estimated Employment Generation');"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Project Start Period(In Months):
                                </label>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtProjectStartPeriod" runat="server" CssClass="input-sm similar-select1" onkeypress="return isNumberKey(event);" onblur="ValidateRequired(this,'Estimated Project Start Period(In Months)');"></asp:TextBox>
                                </div>
                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                    Related Work Experience(In Years):
                                </label>
                                <div class="col-md-3 col-sm-6 col-xs-6">
                                    <asp:TextBox ID="txtWorkExperience" runat="server" CssClass="input-sm similar-select1" MaxLength="4" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Related Work Experience(In Months)');"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <p class="panel-heading">Layout plan of land</p>
                            <div class="form-group">
                                <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                    Covered Area&nbsp;(In %)&nbsp;:
                                </label>
                                <div class="col-md-3 col-sm-3 col-xs-3">
                                    <asp:TextBox ID="txtcoveredarea" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Covered Area');"></asp:TextBox>
                                </div>
                                <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                    Open area required and its purpose&nbsp;(In %)&nbsp;:
                                </label>
                                <div class="col-md-3 col-sm-3 col-xs-3">
                                    <asp:TextBox ID="txtopenarearequired" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Open Area');"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                    FAR :
                                </label>
                                <div class="col-md-3 col-sm-3 col-xs-3">
                                    <asp:TextBox ID="txtFAR" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <p class="panel-heading">Details of the investment(in Rs)</p>
                            <div class="form-group">
                                <label class="col-md-3 col-sm-3 col-xs-3 text-right" title="date ofsubmission">
                                    Land&nbsp;(In Lacs)&nbsp;:&nbsp; <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                </label>
                                <div class="col-md-3 col-sm-3 col-xs-3">
                                    <asp:TextBox ID="txtland" CssClass="input-sm similar-select1" Width="98%" runat="server" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Land');"></asp:TextBox>
                                </div>
                                <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                    Building&nbsp;(In Lacs)&nbsp;:&nbsp;<i class="fa fa-inr" style="margin-right: 5px;"></i>
                                </label>
                                <div class="col-md-3 col-sm-3 col-xs-3">
                                    <asp:TextBox ID="txtbuilding" CssClass="input-sm similar-select1" Width="98%" runat="server" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Building');"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                    Machinery & Equipments&nbsp;(In Lacs)&nbsp;:&nbsp;<i class="fa fa-inr" style="margin-right: 5px;"></i>
                                </label>
                                <div class="col-md-3 col-sm-3 col-xs-3">
                                    <asp:TextBox ID="txtmachinery" CssClass="input-sm similar-select1" Width="98%" runat="server" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Machinery & Equipments');"></asp:TextBox>
                                </div>
                                <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                    Other Fixed Assets&nbsp;(In Lacs)&nbsp;:&nbsp;<i class="fa fa-inr" style="margin-right: 5px;"></i>
                                </label>
                                <div class="col-md-3 col-sm-3 col-xs-3">
                                    <asp:TextBox ID="txtFixedAssets" CssClass="input-sm similar-select1" Width="98%" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                    Other Expenses&nbsp;(In Lacs)&nbsp;:&nbsp;<i class="fa fa-inr" style="margin-right: 5px;"></i>
                                </label>
                                <div class="col-md-3 col-sm-3 col-xs-3">
                                    <asp:TextBox ID="txtOtherExpenses" CssClass="input-sm similar-select1" Width="98%" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                </div>
                                <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                    Own Resources&nbsp;(In Lacs)&nbsp; :&nbsp;<i class="fa fa-inr" style="margin-right: 5px;"></i>
                                </label>
                                <div class="col-md-3 col-sm-3 col-xs-3">
                                    <asp:TextBox ID="txtOwnResources" CssClass="input-sm similar-select1" Width="98%" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                    Bank/FI(financial institutions)&nbsp;(In Lacs)&nbsp;:&nbsp;<i class="fa fa-inr" style="margin-right: 5px;"></i>
                                </label>
                                <div class="col-md-9 col-sm-9 col-xs-9">
                                    <asp:TextBox ID="txtFI" CssClass="input-sm similar-select1" Width="98%" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <p class="panel-heading">
                                Any fumes generated in the process of manufacture if so, their nature and quantity &nbsp; <span class="checkbox-inline" style="padding-bottom: 20px;">
                                    <asp:CheckBox runat="server" ID="chkfumes" AutoPostBack="true" OnCheckedChanged="chkfumes_CheckedChanged" /></span>
                            </p>
                            <div id="fumesdiv" runat="server" visible="false">
                                <div class="form-group">
                                    <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                        Nature&nbsp;:
                                    </label>
                                    <div class="col-md-9 col-sm-9 col-xs-9">
                                        <asp:TextBox ID="txtfumenature" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                        Quantity&nbsp;:
                                    </label>
                                    <div class="col-md-9 col-sm-9 col-xs-9">
                                        <asp:TextBox ID="txtfumeqty" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">Industrial Effluents </div>
                        <div class="panel-body" style="padding: 0px !important;">
                            <div class="table-responsive">
                                <table class="table table-bordered table-hover request-table">
                                    <tr>
                                        <td>Name</td>
                                        <td>Quantity</td>
                                        <td>Chemical Composition</td>
                                    </tr>
                                    <tr>
                                        <td><span class="pull-right">(i)&nbsp;Solid :</span></td>
                                        <td>
                                            <asp:TextBox ID="txteffluentsolidqty" CssClass="input-sm similar-select1" runat="server" placeholder="Enter Only Quantity" onkeypress="return isDecimalKey(event);"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txteffluentsolidcomposition" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25.3%"><span class="pull-right">(ii)&nbsp;Liquid :</span></td>
                                        <td>
                                            <asp:TextBox ID="txteffluentliquidqty" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);" placeholder="Enter Only Quantity"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txteffluentliquidcomposition" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td><span class="pull-right">(iii)&nbsp;Gaseous :</span></td>
                                        <td>
                                            <asp:TextBox ID="txteffluentgaseousqty" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);" placeholder="Enter Only Quantity"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txteffluentgaseouscomposition" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Pollution Category:
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:DropDownList ID="drppollutionCategory" runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading"></div>
                        <div class="panel-body" style="padding: 0px !important;">

                            <div class="row">
                                <div class="form-group">
                                    <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                        Effluent Treatment Measures :

                                    </label>
                                    <div class="col-md-9 col-sm-12 col-xs-12 form-inline font-12px">
                                        <asp:TextBox ID="txteffluenttreatmentmeasure1" CssClass="input-sm similar-select1" runat="server"></asp:TextBox><br />
                                        <hr class="myhrline" />
                                        <asp:TextBox ID="txteffluenttreatmentmeasure2" CssClass="input-sm similar-select1" runat="server"></asp:TextBox><br />
                                        <hr class="myhrline" />
                                        <asp:TextBox ID="txteffluenttreatmentmeasure3" CssClass="input-sm similar-select1" runat="server"></asp:TextBox><br />
                                        <hr class="myhrline" />
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="panel panel-default">
                            <div class="panel-heading">Power Requirement (in KW)</div>
                            <div class="panel-body" style="padding: 0px !important;">
                                <div class="row aks-row">

                                    <label class="col-md-3 col-sm-12 col-xs-12 form-inline text-right">Units &nbsp;:</label>

                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                        <asp:TextBox ID="txtpowerreq" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" runat="server" onblur="ValidateRequired(this,'Power Requirement (in KW)');"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="panel panel-default">
                            <div class="panel-heading">Telephone Requirement</div>
                            <div class="panel-body" style="padding: 0px !important;">
                                <div class="row aks-row">
                                    <label class="col-md-3  col-sm-12 col-xs-12 text-right">First Year&nbsp;:</label>
                                    <div class="col-md-5 col-sm-6 col-xs-12">
                                        <asp:TextBox ID="txttelephonefirstyearreq1" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-6 col-xs-12">
                                        <asp:TextBox ID="txttelephonefirstyearreq2" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row aks-row">
                                    <label class="col-md-3 col-sm-12 col-xs-12 text-right">Ultimate Requirement&nbsp;:</label>
                                    <div class="col-md-5 col-sm-6 col-xs-12">
                                        <asp:TextBox ID="txttelephoneUltimateyearreq1" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>

                                    </div>
                                    <div class="col-md-4 col-sm-6 col-xs-12">
                                        <asp:TextBox ID="txttelephoneUltimateyearreq2" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <p class="panel-heading font-bold">Other Relevant Information</p>
                        <div class="form-group">
                            <div class="row">
                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                    Net Worth(In Lac):
                                </label>
                                <div class="col-md-8 col-sm-6 col-xs-6">
                                    <div style="float: left; width: 2%;"><i class="fa fa-inr"></i></div>
                                    <div style="float: left; width: 98%;">
                                        <asp:TextBox ID="txtNetWorth" Width="100%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Net Worth');"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="row">
                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                    Net Turn Over(In Lac):
                                </label>
                                <div class="col-md-8 col-sm-6 col-xs-6">
                                    <div style="float: left; width: 2%;"><i class="fa fa-inr"></i></div>
                                    <div style="float: left; width: 98%;">
                                        <asp:TextBox ID="txtTurnover" Width="100%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Net Worth Turnover');"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <div class="row">
                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                    <span style="color: Red">*</span>
                                    Whether The Company Is 100% Export Oriented Industry:
                                </label>
                                <div class="col-md-8 col-sm-6 col-xs-6">
                                    <asp:DropDownList runat="server" ID="Drop1" CssClass="chosen similar-select1 margin-left-z dropdown-toggle input-sm">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="YES">YES</asp:ListItem>
                                        <asp:ListItem Value="No">No</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Is the applicant under priority category ? Please specify clearly &nbsp; <span class="checkbox-inline" style="padding-bottom: 20px;">
                                    <asp:CheckBox runat="server" ID="chkpriority" AutoPostBack="true" OnCheckedChanged="chkpriority_CheckedChanged" /></span>
                            </div>
                            <div id="prioritydiv" class="panel-body" style="padding: 0px !important;" runat="server" visible="false">
                                <div class="row aks-row">
                                    <div class="col-md-4 col-sm-6 col-xs-6">
                                        Specification&nbsp;:
                                    </div>
                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                        <asp:DropDownList runat="server" ID="ddlPriority" CssClass="chosen similar-select1 margin-left-z dropdown-toggle input-sm"></asp:DropDownList>
                                        <asp:TextBox ID="txtapplicantpriorityspecification" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </asp:View>

    <asp:View ID="view7" runat="server">
        <a onclick="Registration7()">
            <i class="fa fa-print" aria-hidden="true"></i>
            <br />

        </a>
        <div class="row" id="AllotteeRegistration7">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading" style="width: 100%;">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-3 btn-group">
                                    <div class="btn-group">
                                        <asp:Button ID="Button3" runat="server" CssClass="btn btn-sm btn-primary" Text="Move Previous" OnClick="Previous4_Click" Visible="false" />

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <p style="font-weight: bold;">Allotee Request View</p>
                                </div>


                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-5">

                            <div class="panel panel-default">
                                <div class="panel-heading" style="text-align: center; font-weight: bold;">
                                    Company Details                         
                                </div>
                                <div class="panel-body" style="padding: 0px !important;">
                                    <div class="list-group" style="padding: 6px !important;">

                                        <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Allotment Letter No :   </span>
                                            <span class="pull-right text-muted small"><em>
                                                <asp:Label ID="lblAllotmentLetterNo" runat="server"></asp:Label></em>
                                            </span>
                                        </a>

                                        <a class="list-group-item" style="padding: 6px !important;">Date Of Allotment :                                  
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="LblallotmentLetterDate" runat="server"></asp:Label></em>
                                    </span>
                                        </a>
                                        <a class="list-group-item" style="padding: 6px !important;">Plot No :                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblplot" runat="server"></asp:Label></em>
                                    </span>
                                        </a>
                                        <a class="list-group-item" style="padding: 6px !important;">Industrial Area :                                  
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="LblindustrialArea" runat="server"></asp:Label></em>
                                    </span>
                                        </a>

                                        <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Firm/Company Name :   </span>
                                            <span class="pull-right text-muted small"><em>
                                                <asp:Label ID="lblCompany_firm" runat="server"></asp:Label></em>
                                            </span>
                                        </a>
                                        <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Firm/Company Constitution :   </span>
                                            <span class="pull-right text-muted small"><em>
                                                <asp:Label ID="lblCompanyFirmConstitution" runat="server"></asp:Label></em>
                                            </span>
                                        </a>
                                        <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Firm/Company Pan No :   </span>
                                            <span class="pull-right text-muted small"><em>
                                                <asp:Label ID="lblCompanyPan" runat="server"></asp:Label></em>
                                            </span>
                                        </a>
                                        <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Firm/Company Cin No :   </span>
                                            <span class="pull-right text-muted small"><em>
                                                <asp:Label ID="lblCompanyCin" runat="server"></asp:Label></em>
                                            </span>
                                        </a>
                                        <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Authorised Signatory :   </span>
                                            <span class="pull-right text-muted small"><em>
                                                <asp:Label ID="lblAuthorisedSignatoryName" runat="server"></asp:Label></em>
                                            </span>
                                        </a>
                                        <a class="list-group-item" style="padding: 6px !important;">Signatory Mobile :                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblSignatoryMob" runat="server"></asp:Label></em>
                                    </span>
                                        </a>
                                        <a class="list-group-item" style="padding: 6px !important;">Signatory Email :                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="lblAuthorisedEmailId" runat="server"></asp:Label></em>
                                    </span>
                                        </a>
                                        <a class="list-group-item" style="padding: 6px !important;">Address :                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="LblSignatoryAddress" runat="server"></asp:Label></em>
                                    </span>
                                        </a>

                                    </div>


                                </div>
                            </div>
                        </div>

                        <div class="col-lg-7">


                            <div class="panel panel-default">
                                <p class="panel-heading" style="text-align: center; font-weight: bold;" runat="server" id="P1">Request for Allottee/Transfree Registration (4/5)</p>
                                <div class="panel-body gallery  table-responsive">
                                    <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                                    <asp:GridView ID="Pgrid" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                        <Columns>


                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label16" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                    </asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="AllotteeName" HeaderText="Name" SortExpression="AllotteeName" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                            <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" />
                                            <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />

                                        </Columns>
                                    </asp:GridView>

                                    <asp:GridView ID="Dgrid" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                        <Columns>


                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label17" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                    </asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DirectorName" HeaderText="Director Name" SortExpression="DirectorName" />
                                            <asp:BoundField DataField="DIN_PAN" HeaderText="Din/Pan" SortExpression="DIN_PAN" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                            <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="Phone" />
                                            <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />

                                        </Columns>


                                    </asp:GridView>

                                    <asp:GridView ID="Sgrid" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                        <Columns>


                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                    </asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ShareholderName" HeaderText="Shareholder Name" SortExpression="ShareholderName" />
                                            <asp:BoundField DataField="SharePer" HeaderText="Share %" SortExpression="SharePer" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                            <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" />
                                            <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />

                                        </Columns>

                                        <EmptyDataTemplate>
                                            No Record Available
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:GridView ID="ParGrid" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                        <Columns>


                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                    </asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="PartnerName" HeaderText="Shareholder Name" SortExpression="PartnerName" />
                                            <asp:BoundField DataField="PartnershipPer" HeaderText="Partnership %" SortExpression="PartnershipPer" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                            <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" />
                                            <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />

                                        </Columns>

                                        <EmptyDataTemplate>
                                            No Record Available
                                        </EmptyDataTemplate>
                                    </asp:GridView>

                                    <asp:GridView ID="Tgrid" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                        <Columns>


                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label19" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                    </asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="TrusteeName" HeaderText="Trustee Name" SortExpression="TrusteeName" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                            <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="Phone" />
                                            <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />

                                        </Columns>

                                        <EmptyDataTemplate>
                                            No Record Available
                                        </EmptyDataTemplate>
                                    </asp:GridView>

                                    <asp:GridView ID="Igrid" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                        <Columns>


                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label20" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                    </asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="AllotteeName" HeaderText="Individual Name" SortExpression="AllotteeName" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                            <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" />
                                            <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />

                                        </Columns>
                                    </asp:GridView>


                                </div>
                            </div>

                        </div>

                    </div>


                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">

                            <div class="panel panel-default">
                                <div class="row form-inline">
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <div class="panel-heading">Communication Mode: </div>
                                        <fieldset>
                                            <asp:CheckBoxList ID="CommunicationModeChk" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Email">&nbsp;Email</asp:ListItem>
                                                <asp:ListItem Value="Phone">&nbsp;Phone</asp:ListItem>
                                                <asp:ListItem Value="Registered Post">&nbsp;Registered Post</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </fieldset>

                                    </div>
                                </div>
                                <div class="panel-body" style="padding: 0px !important;">

                                    <asp:Label ID="temp_allotteeid_lbl" runat="server" Visible="false"></asp:Label>
                                    <table id="Table1" class="table table-striped table-responsive table-bordered  table-hover">
                                        <tr>
                                            <th colspan="6" style="text-align: center;">Official Communication</th>
                                        </tr>
                                        <tr id="row1" runat="server" visible="false">
                                            <td class="auto-style2" style="text-align: left;">
                                                <span style="color: Red">*</span>
                                                Email Id :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtmail" runat="server" CssClass="form-control" Width="220px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style2" style="text-align: left;">
                                                <span style="color: Red">*</span>
                                                DateTime :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDatetime" runat="server" CssClass="date form-control" Width="220px" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="row2" runat="server" visible="false">
                                            <td class="auto-style2" style="text-align: left;">
                                                <span style="color: Red">*</span>
                                                Phone No :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtphonec" runat="server" CssClass="form-control" Width="220px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style2" style="text-align: left;">
                                                <span style="color: Red">*</span>
                                                DateTime :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtpdatetime" runat="server" CssClass="date form-control" Width="220px" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="row3" runat="server" visible="false">
                                            <td class="auto-style2" style="text-align: left;">
                                                <span style="color: Red">*</span>
                                                Communication Address :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtcomaddress" runat="server" CssClass="form-control" Width="220px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style2" style="text-align: left;">
                                                <span style="color: Red;">*</span>
                                                DateTime :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtaddressdatetime" runat="server" CssClass="date form-control" Width="220px" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </td>
                                            <td class="auto-style2" style="text-align: left;">
                                                <span style="color: Red;">*</span>
                                                Speed Post Id :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtspeedpost" runat="server" CssClass="form-control" Width="220px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="row4" runat="server" visible="false">
                                            <td class="auto-style2" colspan="6" style="text-align: right;">
                                                <asp:Button ID="Button4" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnComupdate_Click" Text="Submit" />
                                                <asp:Button ID="Button5" CssClass="btn btn-primary btn-sm" runat="server" Text="Reset" OnClick="btnResetCom1_Click" /></td>
                                        </tr>
                                    </table>
                                    <table id="Tabl2" class="table table-striped table-responsive table-bordered  table-hover">
                                        <tr>
                                            <th colspan="4" style="text-align: center;">Allottee Response</th>
                                        </tr>
                                        <tr id="Tr9" runat="server">
                                            <td class="auto-style2" style="text-align: left;">
                                                <span style="color: Red">*</span>
                                                Allottee Response :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtResponse" runat="server" CssClass="form-control" Width="220px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                            <td class="auto-style2" style="text-align: left;">
                                                <span style="color: Red">*</span>
                                                Datetime :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtResponseDatetime" runat="server" CssClass="date form-control" Width="220px" placeholder="dd/mm/yyyy"></asp:TextBox>
                                            </td>

                                        </tr>

                                    </table>
                                    <div style="text-align: right;">



                                        <asp:Button ID="btn_proceed" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnProceed_Click" Text="Proceed" />
                                        <asp:Button ID="btn_reset" CssClass="btn btn-primary btn-sm" runat="server" Text="Reset" OnClick="btnResetCom_Click" />


                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </asp:View>

    <asp:View ID="View5" runat="server">
        <a onclick="Registration8()">
            <i class="fa fa-print" aria-hidden="true"></i>
            <br />

        </a>
        <div class="btn-group">
        </div>
        <div class="row" id="AllotteeRegistration8">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="panel panel-default">
                    <div class="panel-heading" style="width: 100%;">
                        <div class="row">
                            <div class="">
                                <div class="col-md-3" style="display: none;">
                                    <div class="btn-group">
                                        <asp:Button ID="Button6" runat="server" CssClass="btn btn-sm btn-primary" Text="Move Previous" OnClick="Previous3_Click" />
                                        <%--  <asp:Button ID="Button2" runat="server" class="btn btn-sm btn-primary" Text="Move Next"  OnClick="Next4_Click" />--%>
                                    </div>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                    <p>
                                        Allottee/Transfree Registration Details<span class="pull-right"><asp:Button ID="btnLock" runat="server" Text="Lock Record" OnClick="btnLock_Click" Visible="false" />
                                            <asp:Button ID="btnUnlock" runat="server" Text="UnLock Record" OnClick="btnUnlock_Click" Visible="false" /></span>
                                    </p>
                                </div>
                                <asp:Label ID="lblAllotteeID" runat="server" Visible="false"></asp:Label>
                                <div class="col-md-3" style="display: none;">
                                    <div class="btn-group">
                                        <%--   <asp:Button ID="Button2" runat="server" class="btn btn-sm btn-primary" Text="Move Previous" OnClick="Previous2_Click" />
                                               <asp:Button ID="Button2" runat="server" class="btn btn-sm btn-primary" Text="Move Next"  OnClick="Next4_Click" />--%>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="panel-body" id="Divv">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="panel panel-default">
                                    <p class="panel-heading allot-heading" style="">
                                        General Information (1/5)                           
                                    </p>
                                    <div class="panel-body allottee-project-details" style="padding: 0px !important;">
                                        <div class="" style="padding: 0px !important;">

                                            <div style="border: 1px solid #ccc;">
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Industrial Area :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label14" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Applicant Id :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label11" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Allotment Letter No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAllotmentref1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Date of Application :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label12" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Plot No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label13" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        File No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="LblFileNo1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Sector :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSector1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Total Allotted Plot Area : 
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lbltotalplotArea1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        Allotment Rate :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAllotmentRate1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        LocationCharge(if Any) :
                                                    </label>
                                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblLocationCharge1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>

                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        InterestRateApplicable :
                                                    </label>
                                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblInterestRateApplicable1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Ground Coverage :
                                                    </label>
                                                    <div class="col-md-9 col-sm-12 col-xs-12">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblGroundCoverage1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Name Of The Firm/Company/Society :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label23" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Firm/Company Constitution :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label24" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Firm/Company Pan No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label25" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Firm/Company Cin No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label26" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Authorised User :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label27" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Mobile : 
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label28" runat="server"></asp:Label></em>

                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Email : 
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label29" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Address :   
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label30" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="col-md-12 col-sm-12 col-xs-12 mydiv-right">
                                <div class="panel panel-default">
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading allot-heading" style="">
                                                Allottee Project Details                        
                                            </div>
                                            <div class="panel-body allottee-project-details">
                                                <div class="panel panel-default">
                                                    <div class="panel-heading">Type of industry to be set up</div>
                                                    <div class="panel-body" style="padding: 0px !important;">
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                <label for="">Description&nbsp;:</label>
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <asp:Label ID="Label55" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                    </div>
                                                </div>

                                                <div class="panel panel-default">
                                                    <div class="panel-heading allot-heading">Project Costing Details</div>
                                                    <div class="panel-body" style="padding: 0px !important;">
                                                        <div class="form-group">
                                                            <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                <label for="">Estimated Cost Of the project&nbsp;(In Lacs):</label>
                                                            </div>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                                <asp:Label ID="Label56" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                <label for="">Estimated employment generation&nbsp;:</label>
                                                            </div>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <asp:Label ID="Label57" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                <label for="">Project Start Period(In Months) &nbsp;:</label>
                                                            </div>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <asp:Label ID="lblStartPeriod" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                    </div>
                                                </div>


                                                <div class="panel panel-default">
                                                    <div class="panel-heading allot-heading">Layout plan of land indicating broadly</div>
                                                    <div class="panel-body" style="padding: 0px !important;">
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Covered Area&nbsp;(In %)&nbsp;:
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <asp:Label ID="Label58" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Open area required and its purpose&nbsp;(In %)&nbsp;:
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <asp:Label ID="Label59" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                FAR&nbsp;(In %)&nbsp;:
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <asp:Label ID="lblFAR1" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                    </div>
                                                </div>
                                                <div class="panel panel-default">
                                                    <div class="panel-heading allot-heading">Details of the investment(in Rs)</div>
                                                    <div class="panel-body" style="padding: 0px !important;">
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-16 text-right" title="date ofsubmission">
                                                                Land&nbsp;(In Lacs)&nbsp;:
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                                <asp:Label ID="Label60" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Building&nbsp;(In Lacs)&nbsp;:
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                                <asp:Label ID="Label61" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Machinery & Equipments&nbsp;(In Lacs)&nbsp;:
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                                <asp:Label ID="Label62" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Other Fixed Assets&nbsp;(In Lacs)&nbsp;:
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                                <asp:Label ID="Label63" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Other Expenses&nbsp;(In Lacs)&nbsp;:
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                                <asp:Label ID="Label64" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Bank/FI(Financial Institutions):
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                                <asp:Label ID="lblFI1" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                own resources:
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                                <asp:Label ID="lblownresources1" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel panel-default">
                                                    <div class="panel-heading">Any fumes generated in the process of manufacture and if so, their nature and quantity &nbsp; <span runat="server" id="Span1"></span></div>
                                                    <div class="panel-body" style="padding: 0px !important;" id="Div1" runat="server" visible="false">
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Nature&nbsp;:
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <asp:Label ID="Label65" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Quantity&nbsp;:
                                                            </label>
                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <asp:Label ID="Label66" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                    </div>
                                                </div>



                                                <div class="panel panel-default">
                                                    <div class="panel-heading allot-heading">Industrial Effluents </div>
                                                    <div class="panel-body" style="padding: 0px !important;">
                                                        <table class="table table-hover table-bordered request-table" style="width: 100%;">
                                                            <tr>
                                                                <td style="width: 24%;">Name</td>
                                                                <td style="width: 38%;">Quantity</td>
                                                                <td style="width: 38%;">Chemical Composition</td>
                                                            </tr>
                                                            <tr>
                                                                <td><span class="pull-right">(i)&nbsp;Solid :</span></td>
                                                                <td>
                                                                    <asp:Label ID="Label67" runat="server"></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="Label68" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td><span class="pull-right">(ii)&nbsp;Liquid :</span></td>
                                                                <td>
                                                                    <asp:Label ID="Label69" runat="server"></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="Label70" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td><span class="pull-right">(iii)&nbsp;Gaseous :</span></td>
                                                                <td>
                                                                    <asp:Label ID="Label71" runat="server"></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="Label72" runat="server"></asp:Label></td>
                                                            </tr>
                                                        </table>

                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                                Pollution Category:
                                                            </label>
                                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                                <asp:Label ID="lblpollutionCategory1" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />



                                                    </div>
                                                </div>
                                                <div class="panel panel-default">
                                                    <div class="panel-heading allot-heading">Effluent Treatment Measures</div>
                                                    <div class="panel-body" style="padding: 0px !important;">


                                                        <div class="row aks-row">

                                                            <div class="col-md-4 col-sm-6 col-xs-12 form-inline font-12px">
                                                                <asp:Label ID="Label73" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-4 col-sm-6 col-xs-12 form-inline font-12px">
                                                                <asp:Label ID="Label74" runat="server"></asp:Label>

                                                            </div>



                                                            <div class="col-md-4 col-sm-6 col-xs-12 form-inline font-12px">
                                                                <asp:Label ID="Label75" runat="server"></asp:Label>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>

                                                <div class="panel panel-default">
                                                    <div class="panel-heading allot-heading">Power Requirement (in KW)</div>
                                                    <div class="panel-body" style="padding: 0px !important;">


                                                        <div class="form-group">

                                                            <label class="col-md-3 col-sm-6 col-xs-6 form-inline text-right">Units &nbsp;:</label>

                                                            <div class="col-md-9 col-sm-6 col-xs-6">
                                                                <asp:Label ID="Label76" runat="server"></asp:Label>

                                                            </div>


                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                    </div>
                                                </div>

                                                <div class="panel panel-default" style="display: none;">
                                                    <div class="panel-heading allot-heading">Telephone Requirement</div>
                                                    <div class="panel-body" style="padding: 0px !important;">


                                                        <div class="form-group">

                                                            <div class="col-md-3 col-sm-6 col-xs-6 text-right">First Year&nbsp;:</div>

                                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                                <asp:Label ID="Label77" runat="server"></asp:Label>

                                                            </div>
                                                            <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Second Year :
                                       
                                                            </div>
                                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                                <asp:Label ID="Label78" runat="server"></asp:Label>

                                                            </div>

                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="col-md-3 col-sm-6 col-xs-6 text-right">Ultimate Requirement&nbsp;:</div>

                                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                                <asp:Label ID="Label79" runat="server"></asp:Label>

                                                            </div>
                                                            <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                Second Req :
                                       
                                                            </div>
                                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                                <asp:Label ID="Label80" runat="server"></asp:Label>

                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading">Is the applicant under priority category ? Please specify clearly &nbsp; <span runat="server" id="Span2"></span></div>
                                                        <div id="Div2" class="panel-body" style="padding: 0px !important;" runat="server" visible="false">
                                                            <div class="row aks-row">


                                                                <div class="col-md-3 col-sm-6 col-xs-6">Specification&nbsp;:</div>

                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                    <asp:Label ID="Label81" runat="server"></asp:Label>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="panel-body allottee-project-details" style="padding: 0px !important;">
                                        <div class="" style="padding: 6px !important;">
                                            <div style="border: 1px solid #ccc;">
                                                <div class="form-group" style="display: none;">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Product Manufactured : 
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label31" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Case Type : 
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblCaseType1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div runat="server" id="Case3" visible="false">
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Applicable Transfer Levy : 
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="LblTransferCase1" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Pending Dues from previous allottee carry forward  : 
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                                <asp:Label ID="lblPendingDues1" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                </div>

                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Existing Construction Value at plot : 
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label52" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Allotment letter IssueDate :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label33" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Details of Reservation Money                          
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        Reservation Money Payment Date  :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblReservationMoneyPaymentDate1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        Reservation Money Payment Amount  :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblReservationMoneyPaymentAmount1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Possession Detail                         
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Date Of Possession :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label90" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Possession Area :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label91" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Lease Deed Detail                         
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Lease Deed Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label34" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Lease Deed Exec Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label35" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Book No(Bahi) :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label41" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Bookbinding No(Jild) :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label42" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        S.No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label43" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Bulding Plan Detail                         
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Date Of Bulding Plan Submission :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label36" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        other charges :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblothercharges1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Compounding Charges :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblCompoundingCharges1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Date Of Release For Completion :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label37" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Release Date of Occupancy Certificate :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label38" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Date Of Inspection For Construction : 
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label39" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Date Of Inspection For Completion :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label40" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Restoration Ref No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="Label92" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Restoration Ref Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblRestorationRefDate1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Restoration Levy :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblRestorationLevy1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Deed after Restoration :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblDeedafterRestoration1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Change of Plot Detail                         
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Change of Plot Ref No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblChangeOfPlotRefNo1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Change of Plot Ref Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblChangeOfPlotRefDate1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Additional Charges for plot :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAdditionalChargesforplot1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Deed after Change of Plot :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblDeedafterChangeofPlot1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="panel-heading allot-heading" style="">
                                                    Change of Project Detail                         
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Change of Project Ref No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblChangeOfProjectRefNo1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Change of Project Ref Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblChangeOfProjectRefDate1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Change for Charges :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblChangeforChanges1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Lease deed exceuted for increase of FAR :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblincreaseofFAR1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Amalgamation Ref No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAmalgamationRefNo1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Amalgamation Ref Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAmalgamationRefDate1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Sub Div Ref No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSubDivRefNo1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Sub Div Ref Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSubDivRefDate1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Subletting Ref No :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSublettingRefNo1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Subletting Ref Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSublettingRefDate1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Subletting Party Name :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSublettingPartyName1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Subletting Area (In Sqr.Mts) :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSublettingArea1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Subletting For Years :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSublettingYears1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Subletting Project Name :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblSublettingProjectName1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Date Of Agreement :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAgreementDate1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Agreement Execution Date :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAgreementExecDate1" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="form-group">
                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        Agreement On Plot Size :
                                                    </label>
                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                        <em class="text-muted small">
                                                            <asp:Label ID="lblAgreementOn" runat="server"></asp:Label></em>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <hr style="margin: 8px 0;" />
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-xs-12 mydiv-right">
                                    <div class="panel panel-default">
                                        <div class="panel-heading allot-heading" style="">
                                            E-Stamp Details                           
                                        </div>
                                        <div class="panel-body allottee-project-details" style="padding: 0px !important;">
                                            <div class="" style="padding: 0px !important;">

                                                <div style="border: 1px solid #ccc;">
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Certificate No :
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="Label47" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Issue Date :
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="Label48" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Stamp Duty Amount :
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                                <asp:Label ID="Label49" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Account Reference :
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="Label50" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Unique Doc Refence :
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="Label51" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 mydiv-right">
                                    <div class="panel panel-default">
                                        <div class="panel-heading allot-heading" style="">
                                            Bank Guarantee Details                           
                                        </div>
                                        <div class="panel-body allottee-project-details" style="padding: 0px !important;">
                                            <div class="" style="padding: 0px !important;">

                                                <div style="border: 1px solid #ccc;">
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Guarantee No : 
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="Label53" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Guarantee Amount :
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <i class="fa fa-inr" style="margin-right: 5px;"></i>
                                                                <asp:Label ID="Label82" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Guarantee Cover from :
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="Label83" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Guarantee Cover To :
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="Label84" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Last Date Of Claim :
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="Label85" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 mydiv-right">
                                    <div class="panel panel-default">
                                        <div class="panel-heading allot-heading" style="">
                                            Mortgage Details                           
                                        </div>
                                        <div class="panel-body allottee-project-details" style="padding: 0px !important;">
                                            <div class="" style="padding: 0px !important;">

                                                <div style="border: 1px solid #ccc;">
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Bank Proposal Letter :
                                                        </label>
                                                        <div class="col-md-9  col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="Label45" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Bank Sanction Letter :
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="Label46" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>

                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            UPSIDC Sanction letter:
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="Label86" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            No of Stamp :
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="Label87" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                            Total Stamp Duty :
                                                        </label>
                                                        <div class="col-md-9 col-sm-6 col-xs-6">
                                                            <em class="text-muted small">
                                                                <asp:Label ID="Label88" runat="server"></asp:Label></em>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr style="margin: 8px 0;" />
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <div class="panel panel-default">
                                        <p class="panel-heading allot-heading" style="">Payment Details</p>
                                        <div class="panel-body gallery  table-responsive">
                                            <asp:Label ID="Label44" runat="server" Text=""></asp:Label>
                                            <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false"
                                                AllowPaging="false" CssClass="table table-striped table-bordered table-hover request-table">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label22" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                            </asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PaymentReicvedDate" HeaderText="Payment Reicved Date" SortExpression="PaymentReicvedDate" DataFormatString="{0:dd/MM/yyyy}" />
                                                    <asp:BoundField DataField="PaymentAmount" HeaderText="Payment Amount" SortExpression="PaymentAmount" />
                                                    <asp:BoundField DataField="PaymentDescription" HeaderText="Payment Description" SortExpression="PaymentDescription" />

                                                </Columns>


                                            </asp:GridView>

                                        </div>
                                    </div>

                                </div>


                                <%-- Propritar Grid --%>
                                <div class="col-md-12 col-sm-12 col-xs-12">


                                    <div class="panel panel-default">
                                        <p class="panel-heading" style="text-align: center;" runat="server" id="P2">Request for Allottee Transfree (4/5)</p>
                                        <div class="panel-body gallery  table-responsive">
                                            <asp:Label ID="Label54" runat="server" Text=""></asp:Label>
                                            <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="false"
                                                AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                <Columns>


                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label16" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                            </asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="AllotteeName" HeaderText="Name" SortExpression="AllotteeName" />
                                                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                    <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                    <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />

                                                </Columns>
                                            </asp:GridView>

                                            <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="false"
                                                AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                <Columns>


                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label17" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                            </asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DirectorName" HeaderText="Director Name" SortExpression="DirectorName" />
                                                    <asp:BoundField DataField="DIN_PAN" HeaderText="Din/Pan" SortExpression="DIN_PAN" />
                                                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                    <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="Phone" />
                                                    <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />

                                                </Columns>


                                            </asp:GridView>

                                            <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="false"
                                                AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                <Columns>


                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                            </asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ShareholderName" HeaderText="Shareholder Name" SortExpression="ShareholderName" />
                                                    <asp:BoundField DataField="SharePer" HeaderText="Share %" SortExpression="SharePer" />
                                                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                    <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                    <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />

                                                </Columns>


                                            </asp:GridView>

                                            <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="false"
                                                AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                <Columns>


                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label19" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                            </asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="TrusteeName" HeaderText="Trustee Name" SortExpression="TrusteeName" />
                                                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                    <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="Phone" />
                                                    <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />

                                                </Columns>


                                            </asp:GridView>


                                            <asp:GridView ID="GridView12" runat="server" AutoGenerateColumns="false"
                                                AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                <Columns>


                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                            </asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PartnerName" HeaderText="Partner Name" SortExpression="PartnerName" />
                                                    <asp:BoundField DataField="PartnershipPer" HeaderText="Partnership %" SortExpression="PartnershipPer" />
                                                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                    <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                    <asp:BoundField DataField="EmailId" HeaderText="Email Id" SortExpression="EmailId" />

                                                </Columns>


                                            </asp:GridView>


                                        </div>
                                    </div>

                                </div>


                            </div>

                            <hr style="margin: 8px 0;" />
                            <p class="panel-heading allot-heading" style="" runat="server" id="P4">Plot Legal History</p>
                            <div class="table-responsive">
                                <asp:GridView ID="GridView13" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" CssClass="table table-striped table-bordered table-hover request-table"
                                    PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" OnPageIndexChanging="LegalGrid_PageIndexChanging" OnRowCommand="LegalGrid_RowCommand">
                                    <Columns>


                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:BoundField DataField="CaseNo" HeaderText="Case No" SortExpression="CaseNo" />
                                        <asp:BoundField DataField="WeAre" HeaderText="We Are" SortExpression="WeAre" />
                                        <asp:BoundField DataField="LTPartyName" HeaderText="LT Party Name" SortExpression="LTPartyName" />
                                        <asp:BoundField DataField="Jurisdiction" HeaderText="Jurisdiction" SortExpression="Jurisdiction" />
                                        <asp:BoundField DataField="CourtDetails" HeaderText="Court Details" SortExpression="CourtDetails" />
                                        <asp:BoundField DataField="InCourtOf" HeaderText="In Court Of" SortExpression="InCourtOf" />
                                        <asp:BoundField DataField="MatterDetails" HeaderText="Matter Details" SortExpression="MatterDetails" />
                                        <asp:BoundField DataField="CaseStatus" HeaderText="Case Status" SortExpression="CaseStatus" />
                                        <asp:BoundField DataField="LitigatingParty" HeaderText="Litigating Party" SortExpression="LitigatingParty" />
                                        <asp:BoundField DataField="PetAdvocateName" HeaderText="Petitioner Advocate Name" SortExpression="PetAdvocateName" />
                                        <asp:BoundField DataField="PetAdvocateAddress" HeaderText="Petitioner Advocate Address" SortExpression="PetAdvocateAddress" Visible="false" />
                                        <asp:BoundField DataField="PetAdvocateContact" HeaderText="Petitioner Advocate Contact" SortExpression="PetAdvocateContact" Visible="false" />
                                        <asp:BoundField DataField="ResAdvocateName" HeaderText="Respondent Advocate Name" SortExpression="ResAdvocateName" />
                                        <asp:BoundField DataField="ResAdvocateAddress" HeaderText="Respondent Advocate Address" SortExpression="ResAdvocateAddress" Visible="false" />
                                        <asp:BoundField DataField="ResAdvocateContact" HeaderText="Respondent Advocate Contact" SortExpression="ResAdvocateContact" Visible="false" />
                                        <asp:BoundField DataField="CurrentStatus" HeaderText="Current Status" SortExpression="CurrentStatus" />
                                        <asp:BoundField DataField="NextHearingDate1" HeaderText="Next Hearing Date" SortExpression="NextHearingDate1" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>

                                </asp:GridView>
                            </div>



                            <hr style="margin: 8px 0;" />



                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:View>

    <asp:View ID="View6" runat="server">
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="panel panel-default">
                    <div class="panel-heading" style="width: 100%;">
                        <div class="row">
                            <div class="">


                                <div class="col-md-3" style="display: none;">
                                    <div class="btn-group">
                                        <asp:Button ID="btnLegalPrevious" runat="server" CssClass="btn btn-sm btn-primary" Style="margin-right: 2px;" Text="Move Previous" OnClick="btnLegalPrevious_Click" />
                                        <asp:Button ID="btnLegalNext" runat="server" CssClass="btn btn-sm btn-primary" Text="Move Next" OnClick="btnLegalNext_Click" />
                                    </div>
                                </div>

                                <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                    <p>Legal History</p>

                                </div>

                                <div class="col-md-3" style="display: none;">
                                    <div class="btn-group pull-right">
                                        <asp:Button ID="btnLegalSave" Visible="false" runat="server" CssClass="btn btn-sm btn-primary" Text="Save" />

                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="panel-body">



                        <div class="panel panel-default">
                            <div class="panel-heading" style="width: 100%;">Please Enter the Details of legal history associated with plots(If Any)</div>


                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Case No :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtCaseNo" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Whether We Are :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:RadioButtonList ID="radio1" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem style="padding-right: 21px;">Respondent</asp:ListItem>
                                        <asp:ListItem>Petitioner</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    LT. Party Name :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtLtPartyName" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Jurisdiction :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:DropDownList ID="DdlJurisdiction" runat="server" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
                                        <asp:ListItem>---Select--- </asp:ListItem>
                                        <asp:ListItem>Supreme Court</asp:ListItem>
                                        <asp:ListItem>High Court</asp:ListItem>
                                        <asp:ListItem>District Court</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Court Details :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtCourtDetails" runat="server" CssClass="input-sm similar-select1 margin-left-z" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    In Court Of :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtInCourtof" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Matter Details :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtMatterDetails" runat="server" CssClass="input-sm similar-select1 margin-left-z" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Case status :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:DropDownList ID="DdlCaseStatus" runat="server" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
                                        <asp:ListItem>---Select--- </asp:ListItem>
                                        <asp:ListItem>Pending</asp:ListItem>
                                        <asp:ListItem>Disposed</asp:ListItem>
                                        <asp:ListItem>Dismissed</asp:ListItem>
                                        <asp:ListItem>Counter Filed</asp:ListItem>
                                        <asp:ListItem>Rejoinder Filed</asp:ListItem>
                                        <asp:ListItem>Notice Filed</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Litigating Party :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtLitigatingParty" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="panel-heading" style="width: 100%;">Petitioner Advocate</div>
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Advocate Name :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtPetAdvocateName" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Address :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtPetAddress" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Contact No :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtPetContactNo" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="panel-heading" style="width: 100%;">Respondent Advocate</div>
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Advocate Name :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtResAdvocateName" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Address :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtResAddress" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Contact No :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtResContact" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="panel-heading" style="width: 100%;">Further Details</div>
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Current Status :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtCurrentStatus" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    Next Hearing Date:
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtNextHearingDate" runat="server" CssClass="date input-sm similar-select1 margin-left-z" placeholder="dd/mm/yyyy"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <br />
                            <div class="form-group" style="display: none;">
                                <div class="col-md-6" style="text-align: right;">
                                    <asp:Button ID="btnLegalSaveEntry" CssClass="btn btn-sm btn-primary" runat="server" Text="Submit" OnClick="btnLegalSaveEntry_Click" />
                                </div>
                                <div class="col-md-6" style="text-align: left;">
                                    <asp:Button ID="Button7" runat="server" CssClass="btn btn-sm btn-primary" Text="Reset" />
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="panel-heading" style="width: 100%; text-align: center;">Respected Case History</div>

                            <div class="table-responsive">

                                <asp:GridView ID="LegalGrid" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" CssClass="table table-striped table-bordered table-hover request-table"
                                    PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" OnPageIndexChanging="LegalGrid_PageIndexChanging" OnRowCommand="LegalGrid_RowCommand">
                                    <Columns>


                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:BoundField DataField="CaseNo" HeaderText="Case No" SortExpression="CaseNo" />
                                        <asp:BoundField DataField="WeAre" HeaderText="We Are" SortExpression="WeAre" />
                                        <asp:BoundField DataField="LTPartyName" HeaderText="LT Party Name" SortExpression="LTPartyName" />
                                        <asp:BoundField DataField="Jurisdiction" HeaderText="Jurisdiction" SortExpression="Jurisdiction" />
                                        <asp:BoundField DataField="CourtDetails" HeaderText="Court Details" SortExpression="CourtDetails" />
                                        <asp:BoundField DataField="InCourtOf" HeaderText="In Court Of" SortExpression="InCourtOf" />
                                        <asp:BoundField DataField="MatterDetails" HeaderText="Matter Details" SortExpression="MatterDetails" />
                                        <asp:BoundField DataField="CaseStatus" HeaderText="Case Status" SortExpression="CaseStatus" />
                                        <asp:BoundField DataField="LitigatingParty" HeaderText="Litigating Party" SortExpression="LitigatingParty" />
                                        <asp:BoundField DataField="PetAdvocateName" HeaderText="Petitioner Advocate Name" SortExpression="PetAdvocateName" />
                                        <asp:BoundField DataField="PetAdvocateAddress" HeaderText="Petitioner Advocate Address" SortExpression="PetAdvocateAddress" Visible="false" />
                                        <asp:BoundField DataField="PetAdvocateContact" HeaderText="Petitioner Advocate Contact" SortExpression="PetAdvocateContact" Visible="false" />
                                        <asp:BoundField DataField="ResAdvocateName" HeaderText="Respondent Advocate Name" SortExpression="ResAdvocateName" />
                                        <asp:BoundField DataField="ResAdvocateAddress" HeaderText="Respondent Advocate Address" SortExpression="ResAdvocateAddress" Visible="false" />
                                        <asp:BoundField DataField="ResAdvocateContact" HeaderText="Respondent Advocate Contact" SortExpression="ResAdvocateContact" Visible="false" />
                                        <asp:BoundField DataField="CurrentStatus" HeaderText="Current Status" SortExpression="CurrentStatus" />
                                        <asp:BoundField DataField="NextHearingDate1" HeaderText="Next Hearing Date" SortExpression="NextHearingDate1" />



                                        <asp:TemplateField HeaderText="Update">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>


                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Process" CommandArgument='<%#Eval("CaseNo") %>' ToolTip="Click here For Update Case History " />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Delete">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="DeleteCase" CommandArgument='<%#Eval("CaseNo") %>' ToolTip="Click here to delete History" />
                                                </span>  
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>

                            </div>



                        </div>




                    </div>
                </div>

            </div>
        </div>

    </asp:View>

    <asp:View ID="DemandView" runat="server">
        <a onclick="Registration9()">
            <i class="fa fa-print" aria-hidden="true"></i>
            <br />

        </a>
        <div class="row" id="AllotteeRegistration9">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="panel panel-default">
                    <div class="panel-heading" style="width: 100%;">
                        <div class="row">
                            <div class="">
                                <div class="col-md-3" style="display: none;">
                                    <div class="btn-group">
                                        <asp:Button ID="btnDuesPre" runat="server" CssClass="btn btn-sm btn-primary" Style="margin-right: 2px;" Text="Move Previous" OnClick="btnDuesPre_Click" />
                                        <asp:Button ID="btnDuesNext" runat="server" CssClass="btn btn-sm btn-primary" Text="Move Next" OnClick="btnDuesNext_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="panel panel-default">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </asp:View>
    </asp:MultiView>
    </div>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>

    <script type="text/javascript">

        function isDecimalKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {


            }
        }

        //PaymentGridView

        $("[id*=PaymentGridView] input[type=text]").live("blur", function () {
            Calculate1(this);
        });
        $("[id*=PaymentGridView] input[type=text]").live("keyup", function () {
            Calculate(this);
        });
        $("[id*=PaymentGridView] input[type=text]").live("keydown", function () {
            Calculate(this);
        });

        function Calculate(t) {
            // if (!jQuery.trim($(t).val()) == '') {
            if (!isNaN(parseFloat($(t).val()))) {
                var row = $("tr:last-child", $(t).closest("table"));
                var idx = $(t).closest("td").index();
            }
            // } else {
            //     $(t).val('0');
            //}
            var grandTotalPayment = 0;
            $("[id*=PaymentGridView] tr").each(function () {
                if ($(this).index() != $("[id*=PaymentGridView] tr:first-child").index() && $(this).index() != $("[id*=PaymentGridView] tr:last-child").index()) {
                    grandTotalPayment = parseFloat(grandTotalPayment) + (isNaN(parseFloat($("input", $("td", this).eq(idx)).val())) ? 0 : parseFloat($("input", $("td", this).eq(idx)).val()));
                }
            });
            $("td", "[id*=PaymentGridView] tr:last-child").eq(idx).html(grandTotalPayment);
        }
        function Calculate1(t) {
            if (!jQuery.trim($(t).val()) == '') {
                if (!isNaN(parseFloat($(t).val()))) {
                    var row = $("tr:last-child", $(t).closest("table"));
                    var idx = $(t).closest("td").index();
                }
            } else {
                $(t).val('0');
            }
            var grandTotalPayment = 0;
            $("[id*=PaymentGridView] tr").each(function () {
                if ($(this).index() != $("[id*=PaymentGridView] tr:first-child").index() && $(this).index() != $("[id*=PaymentGridView] tr:last-child").index()) {
                    grandTotalPayment = parseFloat(grandTotalPayment) + (isNaN(parseFloat($("input", $("td", this).eq(idx)).val())) ? 0 : parseFloat($("input", $("td", this).eq(idx)).val()));
                }
            });
            $("td", "[id*=PaymentGridView] tr:last-child").eq(idx).html(grandTotalPayment);
        }
        // Payment Recived
        $("[id*=PaymentRecived] input[type=text]").live("blur", function () {
            CalculatePaymentRecived(this);
        });
        $("[id*=PaymentRecived] input[type=text]").live("keyup", function () {
            CalculatePaymentRecived(this);
        });
        $("[id*=PaymentRecived] input[type=text]").live("keydown", function () {
            CalculatePaymentRecived(this);
        });
        function CalculatePaymentRecived(t) {
            // if (!jQuery.trim($(t).val()) == '') {
            if (!isNaN(parseFloat($(t).val()))) {
                var row = $("tr:last-child", $(t).closest("table"));
                var idx = $(t).closest("td").index();
            }
            // } else {
            //     $(t).val('0');
            //}
            var grandTotal = 0;
            $("[id*=PaymentRecived] tr").each(function () {
                if ($(this).index() != $("[id*=PaymentRecived] tr:first-child").index() && $(this).index() != $("[id*=PaymentRecived] tr:last-child").index()) {
                    grandTotal = parseFloat(grandTotal) + (isNaN(parseFloat($("input", $("td", this).eq(idx)).val())) ? 0 : parseFloat($("input", $("td", this).eq(idx)).val()));
                }
            });
            $("td", "[id*=PaymentRecived] tr:last-child").eq(idx).html(grandTotal);
        }
        function CalculatePaymentRecived(t) {
            if (!jQuery.trim($(t).val()) == '') {
                if (!isNaN(parseFloat($(t).val()))) {
                    var row = $("tr:last-child", $(t).closest("table"));
                    var idx = $(t).closest("td").index();
                }
            } else {
                $(t).val('0');
            }
            var grandTotal = 0;
            $("[id*=PaymentRecived] tr").each(function () {
                if ($(this).index() != $("[id*=PaymentRecived] tr:first-child").index() && $(this).index() != $("[id*=PaymentRecived] tr:last-child").index()) {
                    grandTotal = parseFloat(grandTotal) + (isNaN(parseFloat($("input", $("td", this).eq(idx)).val())) ? 0 : parseFloat($("input", $("td", this).eq(idx)).val()));
                }
            });
            $("td", "[id*=PaymentRecived] tr:last-child").eq(idx).html(grandTotal);
        }
        function ValidateFill(obj, txt) {
            var txtObj = document.getElementById(obj.id);
            if (txtObj.value.length > 0) {
                txtObj.style.borderColor = "";
                hideError();
                return true;
            }


        }
        function PrintElem() {

            Popup($('#Divv').html());
        }
        function PrintElem1() {

            Popup($('#Divv1').html());
        }
        function Registration1() {

            Popup($('#AllotteeRegistration1').html());
        }
        function Registration2() {

            Popup($('#AllotteeRegistration2').html());
        }
        function Registration3() {

            Popup($('#AllotteeRegistration3').html());
        }
        function Registration4() {

            Popup($('#AllotteeRegistration4').html());
        }
        function Registration5() {

            Popup($('#AllotteeRegistration5').html());
        }
        function Registration6() {

            Popup($('#AllotteeRegistration6').html());
        }
        function Registration7() {

            Popup($('#AllotteeRegistration7').html());
        }
        function Registration8() {

            Popup($('#AllotteeRegistration8').html());
        }
        function Registration9() {

            Popup($('#AllotteeRegistration9').html());
        }
        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=1000');
            mywindow.document.write('<html><head><title style="font-weight:bold;">Allottee Details</title>');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/bootstrap.min.css\" type=\"text/css\" />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/theme.css\" type=\"text/css\"  />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/print.css\" type=\"text/css\"  />');
            mywindow.document.write('</head><body >');
            mywindow.document.write(data);
            mywindow.document.write('</body></html>');

            setTimeout(function () {
                mywindow.print();
                mywindow.close();
            }, 1000);


            return true;
        }

    </script>

    <script type="text/javascript">

        $(".calculate").live("keyup", function () {

            var row = $(this).closest('tr');
            var Subject1 = $(row).find('[id*=GtxtSubject1]');
            var Subject2 = $(row).find('[id*=GtxtSubject2]');
            var Subject3 = $(row).find('[id*=GtxtSubject3]');


            if (!jQuery.trim($(Subject1).val()) == '' && !jQuery.trim($(Subject2).val()) == '' && !jQuery.trim($(Subject3).val()) == '') {
                if (!isNaN(parseFloat($(Subject1).val())) && !isNaN(parseFloat($(Subject2).val())) && !isNaN(parseFloat($(Subject2).val()))) {

                    $("[id*=GtxtTotal]", row).val(parseFloat($(Subject1).val()) + parseFloat($(Subject2).val()) + parseFloat($(Subject3).val()));

                }
            }
            else {
                $(Subject1).val('');
                $(Subject2).val('');
                $(Subject2).val('');
            }
            var grandTotal = 0;
            $("[id*=GtxtTotal]").each(function () {
                grandTotal = grandTotal + parseFloat($(this).val());
            });
            $("[id*=lblGrandTotal]").html(grandTotal.toString());
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('[id*=Allottee_master_grid]').prepend($("<thead></thead>").append($('[id*=Allottee_master_grid]').find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 10,
                buttons: [
                    { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                ]
            });



            $('[id*=GridView1_pending_process]').prepend($("<thead></thead>").append($('[id*=GridView1_pending_process]').find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 10,
                buttons: [
                    { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                ]
            });


        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();

            $(".MultiSelect").chosen();
        }

    </script>
    <script type="text/javascript">
        function somefunction() {
            var dateEntered = document.getElementById("<%= txtalltLetterIssueDate.ClientID %>").value;
            var date = dateEntered.substring(0, 2);
            var month = dateEntered.substring(3, 5);
            var year = dateEntered.substring(6, 10);

            var dateToCompare = new Date(year, month - 1, date);
            var currentDate = new Date("01 june 2018");

            if (dateToCompare > currentDate) {
                alert("Date Entered is greater than Current Date ");
            }
            else {
                alert("Date Entered is lesser than Current Date");
            }
        }

        function validatepan() {

            var panVal = document.getElementById("<%= txtPanNo.ClientID %>").value;
            var regpan = /^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$/;
            if (panVal != "") {
                if (regpan.test(panVal)) {
                    document.getElementById("<%= txtPanNo.ClientID %>").style.borderColor = "";
                    return true;
                } else {

                    //ShowPopup("<img src='/images/alert.jpg' width='38' height='38'> &nbsp;&nbsp;<span style='font-family:serif !important'>Invalid Pan Card</span>");
                    ShowMsgBox('Error', 'Invalid Pan Card');
                    document.getElementById("<%= txtPanNo.ClientID %>").value = "";
                    return false;
                }
            }
        }

        function IsValidEmail(email) {
            var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            return expr.test(email);
        };
        function ValidateEmail() {
            var email = document.getElementById("<%= txtEmailid.ClientID %>").value;
            if (email.length > 0) {
                if (!IsValidEmail(email)) {

                    // ShowPopup("<img src='/images/alert.jpg' width='38' height='38'> &nbsp;&nbsp;<span style='font-family:serif !important'>Invalid Email Id</span>");
                    ShowMsgBox('Error', 'Invalid Email Id');
                    document.getElementById("<%= txtEmailid.ClientID %>").value = "";
                    document.getElementById("<%= txtEmailid.ClientID %>").style.borderColor = '#e52213';

                    return false;

                }
                else {

                    document.getElementById("<%= txtEmailid.ClientID %>").style.borderColor = "";
                    return true;
                }
            }
        }
        function ValidateEmail(obj) {
            var email = obj.value;
            if (email.length > 0) {
                if (!IsValidEmail(email)) {

                    ShowMsgBox('Error', 'Invalid Email Id');
                    obj.style.borderColor.value = "";
                    obj.style.borderColor = '#e52213';

                    return false;

                }
                else {

                    obj.style.borderColor = "";
                    return true;
                }
            }
        }
        function ValidateAlpha(evt) {
            var keyCode = (evt.which) ? evt.which : evt.keyCode
            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32) {
                return false;
            }
            else {
                var txt = document.getElementById("<%= txtAuthorisedSignatory.ClientID %>");
                if (txt.value != "") {
                    if (txt.value.length > 0) {
                        txt.style.borderColor = "";
                        return true;
                    }
                }
            }
        }
        function ValidateAlpha2(evt2) {
            var keyCode = (evt2.which) ? evt2.which : evt2.keyCode
            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32) {
                return false;
            }
            else {
                var txt = document.getElementById("<%= txtIndividualName.ClientID %>");
                if (txt.value.length > 0) {
                    txt.style.borderColor = "";
                    return true;
                }
            }
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode = 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById("<%= txtSignatoryPhone.ClientID %>");
                if (txt.value.length > 0) {
                    txt.style.borderColor = "";
                    return true;
                }
            }
        }
        function isDecimalKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {


            }
        }
        function ValidateSignatoryPhone() {
            var txt7 = document.getElementById("<%= txtPhone.ClientID %>");
            if (txt7.value.length > 0) {
                if (txt7.value.length < 10) {

                    txt7.style.borderColor = '#e52213';
                    ShowMsgBox('Error', 'Invalid Phone No');
                    txt7.value = "";
                }
                else {
                    txt7.style.borderColor = "";
                }
            }

        }
        function Validateadhar() {
            var txt7 = document.getElementById("<%= txtAddharcardNo.ClientID %>");
            if (txt7.value.length > 0) {
                if (txt7.value.length < 10) {
                    txt7.value = "";
                    txt7.style.borderColor = '#e52213';
                    ShowMsgBox('Error', 'Invalid Aadhar Card No');
                }
                else {
                    txt7.style.borderColor = "";
                }
            }
        }

        function check1() {
            var remark = true;


            var txt = document.getElementById("<%= txtAllotment1.ClientID %>");

            var txt1 = document.getElementById("<%= txtPlotNo.ClientID %>");
            var txt2 = document.getElementById("<%= txtCompanyname.ClientID %>");
            var txt9 = document.getElementById("<%= txtIndividualName.ClientID %>");
            var txt10 = document.getElementById("<%= txtIndividualAddress.ClientID %>");

            var txt12 = document.getElementById("<%= txtIndividualPhone.ClientID %>");
            var txt13 = document.getElementById("<%= txtAuthorisedSignatory.ClientID %>");
            var txt14 = document.getElementById("<%= txtSignatoryPhone.ClientID %>");
            var txt15 = document.getElementById("<%= txtSignatoryAddress.ClientID %>");
            var txt16 = document.getElementById("<%= txtTotalArea.ClientID %>");

            var ddl = document.getElementById("<%= ddlArea.ClientID%>");
            var ddl1 = document.getElementById("<%= ddlcompanytype.ClientID%>");


            if (txt.value.length <= 0) {
                txt.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt.style.borderColor = "";
            }
            if (txt1.value.length <= 0) {
                txt1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt1.style.borderColor = "";
            }
            if (ddl1.selectedIndex == 1) {

                if (txt3.value.length <= 0) {
                    txt3.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txt3.style.borderColor = "";
                }
                if (txt4.value.length <= 0) {
                    txt4.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txt4.style.borderColor = "";
                }
                if (txt7.value.length <= 0) {
                    txt7.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txt7.style.borderColor = "";
                }
                if (txt8.value.length <= 0) {
                    txt8.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txt8.style.borderColor = "";
                }

            } else {
                if (txt2.value.length <= 0) {
                    txt2.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txt2.style.borderColor = "";
                }

            }
            if (ddl1.selectedIndex == 5) {

                if (txt9.value.length <= 0) {
                    txt9.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txt9.style.borderColor = "";
                }
                if (txt10.value.length <= 0) {
                    txt10.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txt10.style.borderColor = "";
                }

                if (txt12.value.length <= 0) {
                    txt12.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txt12.style.borderColor = "";
                }

            }
            if (txt13.value.length <= 0) {
                txt13.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt13.style.borderColor = "";
            }

            if (txt15.value.length <= 0) {
                txt15.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt15.style.borderColor = "";
            }
            if (txt16.value.length <= 0) {
                txt16.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt16.style.borderColor = "";
            }





            if (remark == false) {

                ShowMsgBox('Error', 'Please Fill All Required Value');
                return false;
            } else {
                return true;
            }


        }

        function ccheck2() {
            var remark = true;
            var ddl_ProductCategory = document.getElementById("<%= ddl_ProductCategory.ClientID %>");
            var ddl_ProductSubCategory = document.getElementById("<%= ddl_ProductSubCategory.ClientID %>");
            var lst_ProductName = document.getElementById("<%= lst_ProductName.ClientID %>");
            var ddlIndType = document.getElementById("<%= ddlTypeOfIndustry.ClientID %>");
            var ddlPoluctionCat = document.getElementById("<%= drppollutionCategory.ClientID %>");
            var txtProjectStartMonths = document.getElementById("<%= txtProjectStartPeriod.ClientID %>");
            var txtestimatedcost = document.getElementById("<%= txtestimatedcost.ClientID %>");
            var txtestimatedemployment = document.getElementById("<%= txtestimatedemployment.ClientID %>");
            var txtcoveredarea = document.getElementById("<%= txtcoveredarea.ClientID %>");
            var txtopenarearequired = document.getElementById("<%= txtopenarearequired.ClientID %>");
            var txtland = document.getElementById("<%= txtland.ClientID %>");
            var txtbuilding = document.getElementById("<%= txtbuilding.ClientID %>");
            var txtmachinery = document.getElementById("<%= txtmachinery.ClientID %>");
            var txtOtherExpenses = document.getElementById("<%= txtOtherExpenses.ClientID %>");
            var txtFixedAssets = document.getElementById("<%= txtFixedAssets.ClientID %>");
            var txtpowerreq = document.getElementById("<%= txtpowerreq.ClientID %>");
            var txtNetWorth = document.getElementById("<%= txtNetWorth.ClientID %>");
            var txtNetTurn = document.getElementById("<%= txtTurnover.ClientID %>");
            var Drop1 = document.getElementById("<%= Drop1.ClientID %>");
            var workExp = document.getElementById("<%= txtWorkExperience.ClientID %>");

            if (lst_ProductName.value.length <= 0) {
                lst_ProductName.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                lst_ProductName.style.borderColor = "";
            }
            if (ddl_ProductSubCategory.value.length <= 0) {
                ddl_ProductSubCategory.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ddl_ProductSubCategory.style.borderColor = "";
            }
            if (ddl_ProductCategory.value.length <= 0) {
                ddl_ProductCategory.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ddl_ProductCategory.style.borderColor = "";
            }
            if (txtProjectStartMonths.value.length <= 0) {
                txtProjectStartMonths.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtProjectStartMonths.style.borderColor = "";
            }
            if (workExp.value.length <= 0) {
                workExp.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                workExp.style.borderColor = "";
            }

            if (txtestimatedcost.value.length <= 0) {
                txtestimatedcost.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtestimatedcost.style.borderColor = "";
            }
            if (txtestimatedemployment.value.length <= 0) {
                txtestimatedemployment.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtestimatedemployment.style.borderColor = "";
            }

            if (txtcoveredarea.value.length <= 0) {
                txtcoveredarea.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtcoveredarea.style.borderColor = "";
            }
            if (txtopenarearequired.value.length <= 0) {
                txtopenarearequired.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtopenarearequired.style.borderColor = "";
            }
            if (txtland.value.length <= 0) {
                txtland.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtland.style.borderColor = "";
            }
            if (txtbuilding.value.length <= 0) {
                txtbuilding.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtbuilding.style.borderColor = "";
            }
            if (txtmachinery.value.length <= 0) {
                txtmachinery.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtmachinery.style.borderColor = "";
            }

            if (txtpowerreq.value.length <= 0) {
                txtpowerreq.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtpowerreq.style.borderColor = "";
            }
            if (txtNetWorth.value.length <= 0) {
                txtNetWorth.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtNetWorth.style.borderColor = "";
            }
            if (txtNetTurn.value.length <= 0) {
                txtNetTurn.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtNetTurn.style.borderColor = "";
            }


            if (ddlIndType.selectedIndex == 0) {
                ddlIndType.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ddlIndType.style.borderColor = "";
            }
            if (ddlPoluctionCat.selectedIndex == 0) {
                ddlPoluctionCat.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ddlPoluctionCat.style.borderColor = "";
                if (ddlPoluctionCat.selectedIndex == 1 || ddlIAcat.selectedIndex == 2) {
                    var txteffluentsolidqty = document.getElementById("<%= txteffluentsolidqty.ClientID %>");
                    var txteffluentsolidcomposition = document.getElementById("<%= txteffluentsolidcomposition.ClientID %>");
                    var txteffluentliquidqty = document.getElementById("<%= txteffluentliquidqty.ClientID %>");
                    var txteffluentliquidcomposition = document.getElementById("<%= txteffluentliquidcomposition.ClientID %>");
                    var txteffluentgaseousqty = document.getElementById("<%= txteffluentgaseousqty.ClientID %>");
                    var txteffluentgaseouscomposition = document.getElementById("<%= txteffluentgaseouscomposition.ClientID %>");

                    if (txteffluentsolidqty.value.length <= 0) {
                        txteffluentsolidqty.style.borderColor = '#e52213';
                        remark = false;
                    }
                    else {
                        txteffluentsolidqty.style.borderColor = "";
                    }

                    if (txteffluentsolidcomposition.value.length <= 0) {
                        txteffluentsolidcomposition.style.borderColor = '#e52213';
                        remark = false;
                    }
                    else {
                        txteffluentsolidcomposition.style.borderColor = "";
                    }

                    if (txteffluentliquidqty.value.length <= 0) {
                        txteffluentliquidqty.style.borderColor = '#e52213';
                        remark = false;
                    }
                    else {
                        txteffluentliquidqty.style.borderColor = "";
                    }

                    if (txteffluentliquidcomposition.value.length <= 0) {
                        txteffluentliquidcomposition.style.borderColor = '#e52213';
                        remark = false;
                    }
                    else {
                        txteffluentliquidcomposition.style.borderColor = "";
                    }

                    if (txteffluentgaseousqty.value.length <= 0) {
                        txteffluentgaseousqty.style.borderColor = '#e52213';
                        remark = false;
                    }
                    else {
                        txteffluentgaseousqty.style.borderColor = "";
                    }

                    if (txteffluentgaseouscomposition.value.length <= 0) {
                        txteffluentgaseouscomposition.style.borderColor = '#e52213';
                        remark = false;
                    }
                    else {
                        txteffluentgaseouscomposition.style.borderColor = "";
                    }
                }
            }
            if (Drop1.selectedIndex == 0) {
                Drop1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Drop1.style.borderColor = "";
            }
            if (remark == false) {
                alert("Fill All Required Field");
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";
                return false;
            }
            else {
                hideError();
                return true;
            }
        }


        function checkAllotment1() {
            var remark = true;

            var txt = document.getElementById("<%= txtProductManufactured.ClientID %>");

            var txt1 = document.getElementById("<%= txtTotalArea.ClientID %>");
            var txt2 = document.getElementById("<%= txtalltLetterIssueDate.ClientID %>");
            var txt3 = document.getElementById("<%= txtLeaseDeed.ClientID %>");
            var txt4 = document.getElementById("<%= txtExecLeaseDeed.ClientID %>");

            var txt7 = document.getElementById("<%= txtBuildingDate.ClientID %>");

            if (txt.value.length <= 0) {
                txt.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt.style.borderColor = "";
            }
            if (txt1.value.length <= 0) {
                txt1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt1.style.borderColor = "";
            }

            if (txt2.value.length <= 0) {
                txt2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt2.style.borderColor = "";
            }
            if (txt3.value.length <= 0) {
                txt3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt3.style.borderColor = "";
            }

            if (txt4.value.length <= 0) {
                txt4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt4.style.borderColor = "";
            }




            if (txt7.value.length <= 0) {
                txt7.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt7.style.borderColor = "";
            }



            if (remark == false) {
                ShowMsgBox('Error', 'Please Fill All Required Value');
                return false;
            } else {
                return true;
            }

        }


        function checkAllotment2() {
            var remark = true;

            var txt = document.getElementById("<%= txttotalAreaPayment.ClientID %>");

            var txt1 = document.getElementById("<%= txtRateofInterest.ClientID %>");
            var txt2 = document.getElementById("<%= txtRateatTimeAllotment.ClientID %>");
            var txt3 = document.getElementById("<%= txtAllotmentDate.ClientID %>");
            var txt4 = document.getElementById("<%= txtDefaulters.ClientID %>");

            var txt7 = document.getElementById("<%= txtInstallment.ClientID %>");
            var txt8 = document.getElementById("<%= txtLocationCharges.ClientID %>");
            var txt9 = document.getElementById("<%= txtMoneyRate.ClientID %>");
            var txt10 = document.getElementById("<%= txtReservationMoney.ClientID %>");
            var txt11 = document.getElementById("<%= txtDemantNoticeDate.ClientID%>");
            var txt12 = document.getElementById("<%= txtDemantNoticeDate2.ClientID%>");

            if (txt.value.length <= 0) {
                txt.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt.style.borderColor = "";
            }
            if (txt1.value.length <= 0) {
                txt1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt1.style.borderColor = "";
            }

            if (txt2.value.length <= 0) {
                txt2.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt2.style.borderColor = "";
            }
            if (txt3.value.length <= 0) {
                txt3.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt3.style.borderColor = "";
            }

            if (txt4.value.length <= 0) {
                txt4.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt4.style.borderColor = "";
            }




            if (txt7.value.length <= 0) {
                txt7.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt7.style.borderColor = "";
            }
            if (txt8.value.length <= 0) {
                txt8.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt8.style.backgroundColor = "";
            }
            if (txt9.value.length <= 0) {
                txt9.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt9.style.borderColor = "";
            }
            if (txt10.value.length <= 0) {
                txt10.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt10.style.borderColor = "";
            }
            if (txt11.value.length <= 0) {
                txt11.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt11.style.borderColor = "";
            }
            if (txt12.value.length <= 0) {
                txt12.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt12.style.borderColor = "";
            }


            if (remark == false) {
                ShowMsgBox('Error', 'Please Fill All Required Value');
                return false;
            } else {
                return true;
            }

        }

        function checkAllotment3() {
            var remark = true;

            var txt = document.getElementById('<%=((TextBox)gridviewpayment.FooterRow.FindControl("txtAmount")).ClientID %>');

            var txt1 = document.getElementById('<%=((TextBox)gridviewpayment.FooterRow.FindControl("txtPaymentReceivedDate")).ClientID %>');

            if (txt.value.length <= 0) {
                txt.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt.style.borderColor = "";
            }
            if (txt1.value.length <= 0) {
                txt1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txt1.style.borderColor = "";
            }



            if (remark == false) {
                // ShowPopup("<img src='/images/alert.jpg' width='38' height='38'> &nbsp;&nbsp;<span style='font-family:serif !important'>Please Fill All Required Value</span>");
                ShowMsgBox('Error', 'Please Fill All Required Value');
                return false;
            } else {
                return true;
            }

        }

        function Allotment_keypress() {

            var txt = document.getElementById("<%= txtAllotment.ClientID %>");

            if (txt.value.length > 0) {
                txt.style.borderColor = "";

            }

        }

        function address_keypress() {
            var txt = document.getElementById("<%= txtAllotteeAddress.ClientID %>");

            if (txt.value.length > 0) {
                txt.style.borderColor = "";

            }

        }
        function plot_keypress() {
            var txt = document.getElementById("<%= txtPlotNo1.ClientID %>");

            if (txt.value.length > 0) {
                txt.style.borderColor = "";

            }

        }

        function product_manu_keypress() {
            var txt = document.getElementById("<%= txtProductManufactured.ClientID %>");

            if (txt.value.length > 0) {
                txt.style.borderColor = "";

            }

        }
        function txtTotalArea_keypress(evt) {

            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {
                var txt = document.getElementById("<%= txtTotalArea.ClientID %>");
                if (txt.value.length > 0) {
                    txt.style.borderColor = "";
                }
            }
        }
        function txtalltLetterIssueDate_keypress() {
            var txt = document.getElementById("<%= txtalltLetterIssueDate.ClientID %>");

            if (txt.value.length > 0) {
                txt.style.borderColor = "";

            }

        }
        function txtLeaseDeed_keypress() {
            var txt = document.getElementById("<%= txtLeaseDeed.ClientID %>");

            if (txt.value.length > 0) {
                txt.style.borderColor = "";

            }

        }
        function txtExecLeaseDeed_keypress() {
            var txt = document.getElementById("<%= txtExecLeaseDeed.ClientID %>");

            if (txt.value.length > 0) {
                txt.style.borderColor = "";

            }

        }

        function txtBuildingDate_keypress() {
            var txt = document.getElementById("<%= txtBuildingDate.ClientID %>");

            if (txt.value.length > 0) {
                txt.style.borderColor = "";

            }

        }

        function validate_total_area(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById("<%= txttotalAreaPayment.ClientID %>");

                if (txt.value.length > 0) {
                    txt.style.borderColor = "";

                }
            }
        }

        function validate_Roi(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById("<%= txtRateofInterest.ClientID %>");

                if (txt.value.length > 0) {
                    txt.style.borderColor = "";

                }
            }
        }
        function validate_rate_allotment(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById("<%= txtRateatTimeAllotment.ClientID %>");

                if (txt.value.length > 0) {
                    txt.style.borderColor = "";

                }
            }
        }
        function validate_rebate(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById("<%= txtDefaulters.ClientID %>");

                if (txt.value.length > 0) {
                    txt.style.borderColor = "";

                }
            }
        }

        function validate_no_of_installment(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById("<%= txtInstallment.ClientID %>");

                if (txt.value.length > 0) {
                    txt.style.borderColor = "";

                }
            }
        }

        function validate_loc_charges(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById("<%= txtLocationCharges.ClientID %>");

                if (txt.value.length > 0) {
                    txt.style.borderColor = "";

                }
            }
        }

        function validate_earn_money_rate(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById("<%= txtMoneyRate.ClientID %>");

                if (txt.value.length > 0) {
                    txt.style.borderColor = "";

                }
            }
        }

        function validate_reservation_money(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById("<%= txtReservationMoney.ClientID %>");

                if (txt.value.length > 0) {
                    txt.style.borderColor = "";

                }
            }
        }
        function validatephone(obj) {
            var txt = obj.value;

            if (txt.length > 0) {
                if (txt.length < 10) {
                    ShowMsgBox('Error', 'Invalid Phone No');
                    return true;
                }
                else {
                    return false;
                }

            }

        }

    </script>

</asp:Content>
