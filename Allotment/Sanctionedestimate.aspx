<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="Sanctionedestimate.aspx.cs" Inherits="Allotment.Sanctionedestimate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        #ContentPlaceHolder1_GridView1 tr th {
            text-align: center;
            font-size: 11px;
        }

        #GridView1 tr th:nth-child(15) {
            background: #f9f4e5;
        }

        #GridView1 tr th:nth-child(16) {
            background: #f9f4e5;
        }

        #GridView1 tr th:nth-child(17) {
            background: #f9f4e5;
        }

        #GridView1 tr:nth-child(1) td {
            font-weight: 600;
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
            margin-left: 0;
            width: 70px;
        }

        #GridView1 input.date {
            width: 142px;
        }

        .hideGridColumn {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">

        <Triggers>
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
            </asp:UpdateProgress>
    <cc1:MessageBox ID="MessageBox1" runat="server" />
    <cc1:ConfirmBox ID="ConfirmBox1" runat="server" />
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12 " style="background: #dbdbdb;">
            <div style="width: 100px; float: left; background: #dbdbdb; font-size: 11px;" class="text-center">
                <br />
                <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                    <li class="disabled">
                        <a href="#" class="disable">
                            <i class="fa fa-tachometer" aria-hidden="true"></i>
                            <br />
                            Dashboard
                        </a>
                    </li>
                </ul>
            </div>
            <div style="float: left; background: #dbdbdb; border-left: 1px solid #000; font-size: 11px;" class="text-center">
                Operate<br />
                <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                    <li>
                        <a href="#" class="disable">
                            <i class="fa fa-floppy-o " aria-hidden="true"></i>
                            <br />
                            Save
                        </a>
                    </li>
                    <li>
                        <a href="#" class="disable">
                            <i class="fa fa-refresh" aria-hidden="true"></i>
                            <br />
                            Refresh
                        </a>
                    </li>
                </ul>
            </div>
            <div style="float: left; background: #dbdbdb; border-left: 1px solid #000; border-right: 1px solid #000; font-size: 11px;" class="text-center">
                Services<br />
                <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                    <li>
                        <a href="#" class="disable">
                            <i class="fa fa-plus" aria-hidden="true"></i>
                            <br />
                            New
                        </a>
                    </li>
                    <li>
                        <a href="#" class="disable">
                            <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                            <br />
                            Drafted
                        </a>
                    </li>
                    <li>
                        <a href="#" class="disable">
                            <i class="fa fa-th-list" aria-hidden="true"></i>
                            <br />
                            Submitted
                        </a>
                    </li>

                    <li>
                        <a href="#" class="disable">
                            <i class="fa fa-credit-card" aria-hidden="true"></i>
                            <br />
                            Track 
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
                        <a href="#" class="disable">
                            <i class="fa fa-angle-double-left" aria-hidden="true"></i>
                            <br />
                            Previous
                        </a>
                    </li>
                    <li>
                        <a href="#" class="disable">
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
                    <li runat="server" id="hrefPrint">
                        <a runat="server" onclick="PrintElem()">
                            <i class="fa fa-print" aria-hidden="true"></i>
                            <br />
                            Print
                        </a>
                    </li>
                </ul>
            </div>
            <div style="float: left; background: #dbdbdb; font-size: 11px; border-left: 1px solid #000;">
                <br />
                <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                    <li>
                        <a href="#" class="disable">
                            <i class="fa fa-credit-card" aria-hidden="true"></i>
                            <br />
                            Dues
                        </a>
                    </li>
                </ul>
            </div>
            <div style="float: left; background: #dbdbdb; font-size: 11px; border-left: 1px solid #000;">
                <br />
                <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                    <li>
                        <a href="#" class="disable">
                            <i class="fa fa-database" aria-hidden="true"></i>
                            <br />
                            Repository
                        </a>
                    </li>
                </ul>
            </div>

        </div>
    </div>
    <div class="row">
        <div class="panel panel-default">
            <div class="clearfix"></div>
            <div class="table-responsive" style="margin: 5px 0">
                <table id="tblsearch" class="table table-striped table-bordered table-hover  margin-b-2px request-table">
                    <tr style="background: #ececec;">
                        <td class="font-bold">
                            <span style="color: Red">*</span>
                            Construction Divisions :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCD" AutoPostBack="true" OnSelectedIndexChanged="Regional_Changed" runat="server" CssClass="btn btn-sm btn-default dropdown-toggle similar-select">
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
                    </tr>
                </table>
            </div>
            <div class="clearfix"></div>
            <div class="panel-heading" style="margin-bottom: 8px;">
                <div class="col-md-8 col-sm-4 col-xs-12 font-bold" style="margin-top: 8px;">
                    <span>Office of the Executive Engineer</span>
                </div>
                <div class="col-md-4 col-sm-8 col-xs-12 input-group pull-right" runat="server" id="Search" style="margin-top: 3px;">
                    <asp:TextBox ID="txtSearch" CssClass="input-sm" Width="100%" Style="height: 29px;" runat="server" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged" />
                    <span class="input-group-btn">
                        <button id="btnSearch" class="btn btn-sm btn-primary" type="button"><i class="fa fa-search" style="color: #fff; padding: 2px 0;"></i></button>
                    </span>
                    <asp:Label ID="Group_lbl" runat="server" Visible="false"></asp:Label>
                </div>
                <div class="clearfix"></div>
            </div>



            <div class="">
                <div class="">
                    <div class="">
                        <div class="">

                            <div class="panel-body">
                                <%--<p>मेरा नाम है</p>--%>
                                <asp:Label runat="server" ID="lblmsg"></asp:Label>
                                <asp:Label ID="lblUserId" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblPass" runat="server" Visible="false"></asp:Label>
                                <input type="button" value="Click Me" style="display: none;" id="btnShowPopup" data-toggle="modal" data-target="#ModalGrid" />

                                <div id="Divv">
                                    <div class="col-md-12 col-sm-12 col-xs-12 ">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" runat="server" CellPadding="0"
                                                GridLines="None" AutoGenerateColumns="False" ShowFooter="True" CssClass="table table-bordered table-hover request-table"
                                                ShowHeaderWhenEmpty="True" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                                                AllowPaging="false" DataKeyNames="EngId" OnRowEditing="GridView1_RowEditing"
                                                OnPageIndexChanging="GridView1_PageIndexChanging"
                                                OnRowCreated="GridView1_Merge_Header_RowCreated" OnPreRender="PlantationGrid_PreRender"
                                                PagerStyle-CssClass="pagination-ys"
                                                OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                                OnRowUpdating="GridView1_RowUpdating">
                                                <Columns>
                                                    <%--  <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />--%>
                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="CDName" HeaderStyle-HorizontalAlign="Left" InsertVisible="False" ReadOnly="True" HeaderText="Construction Division" />
                                                    <asp:BoundField DataField="IAName" HeaderStyle-HorizontalAlign="Left" InsertVisible="False" ReadOnly="True" HeaderText="Industrial Area" />
                                                    <%-- <asp:TemplateField HeaderText="Construction Division" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCDName" runat="server" Text='<%# Eval("CDName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Industrial Area" HeaderStyle-HorizontalAlign="Left" Visible="false" ItemStyle-Width="9%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCDName" runat="server" Text='<%# Eval("CDName")%>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id")%>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblIAName" runat="server" Text='<%# Bind("IAName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Financial Year" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="7%">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtFinancialyear" class="similar-select1" Width="60px" runat="server" Text='<%# Bind("FinancialYear") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFinancialyear" runat="server" Text='<%# Eval("FinancialYear") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name Of Work" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10%">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtNameofworko" class="similar-select1" runat="server" Width="60px" Text='<%# Bind("Nameofwork") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNameofwork" runat="server" Text='<%# Eval("Nameofwork") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Job No & Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="20%">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtJobNo" class="similar-select1" runat="server" Width="80px" Text='<%# Bind("JobNo") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblJobNo" runat="server" Text='<%# Eval("JobNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtDate" CssClass="date input-sm similar-select1" runat="server" Text='<%# Eval("Date","{0:dd, MMM yyyy}") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date","{0:dd, MMM yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="4%">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtAmount" class="similar-select1" onkeypress="return isDecimalKey(event);" runat="server" Text='<%# Bind("Amount") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmount" Width="20px" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="CBNo & Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="20%">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtCBNO" class="similar-select1" runat="server" Text='<%# Bind("CBNO") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCBNO" runat="server" Text='<%# Eval("CBNO") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Ex Date" HeaderStyle-HorizontalAlign="Left">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtExDate" class="mygridinput" CssClass="date input-sm similar-select1" runat="server" Text='<%# Eval("ExDate","{0:dd, MMM yyyy}") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblExDate" runat="server" Text='<%# Eval("ExDate","{0:dd, MMM yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Tender Amount" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="5%">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtExAmount" class="similar-select1" onkeypress="return isDecimalKey(event);" runat="server" Text='<%# Bind("ExAmount") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblExAmount" runat="server" Text='<%# Eval("ExAmount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name of Agency/Contractor Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="12%">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtAgencyName" class="similar-select1" runat="server" Text='<%# Eval("AgencyName") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAgencyName" runat="server" Text='<%# Eval("AgencyName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Gross Work Done(In Lacs Rs)" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="11%">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtGrossworkvalue" onkeypress="return isDecimalKey(event);" class="similar-select1" runat="server" Text='<%# Eval("GrossworkDone") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGrossworkvalue" runat="server" Text='<%# Eval("GrossworkDone") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Completed" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="2%">
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="ddlStatusofWork" runat="server" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1" Width="80px">
                                                                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                                                                <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                                                            </asp:DropDownList>

                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatusofWork" runat="server" Text='<%# Eval("StatusofWork") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Not Completed" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="2%">
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="ddlStatusofWork1" runat="server" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1" Width="80px">
                                                                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                                                                <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                                                            </asp:DropDownList>

                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatusofWork1" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Net Payment" HeaderStyle-HorizontalAlign="Left">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtPayment" class="similar-select1" onkeypress="return isDecimalKey(event);" runat="server" Text='<%# Bind("Payment") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPayment" runat="server" Text='<%# Eval("Payment") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date of Payment" HeaderStyle-HorizontalAlign="Left">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtPaymentDate" CssClass="date input-sm similar-select1" runat="server" Text='<%# Eval("PaymentDate","{0:dd, MMM yyyy}") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPaymentDate" runat="server" Text='<%# Eval("PaymentDate","{0:dd, MMM yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Developed Area(In Acres)" HeaderStyle-HorizontalAlign="center" ItemStyle-CssClass="text-center-imp" ItemStyle-Width="10%">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtAreaDeveloped" class="similar-select1" Width="50px" onkeypress="return isDecimalKey(event);" runat="server" Text='<%# Bind("AreaDeveloped") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAreaDeveloped" runat="server" Text='<%# Eval("AreaDeveloped") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Remark" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="5%">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtRemark" class="similar-select1" runat="server" Text='<%# Bind("Remark") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("Remark") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <%--<asp:TemplateField HeaderText="&nbsp;">
                                                        <ItemTemplate>
                                                            <asp:Button ID="ButtonAdd" runat="server"
                                                                Text="Add New Row"
                                                                OnClick="ButtonAdd_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="" ShowHeader="False" HeaderStyle-HorizontalAlign="center" ItemStyle-CssClass="text-center-imp">
                                                        <EditItemTemplate>
                                                            <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text='<i class="	fa fa-wrench" width="50px" aria-hidden="true"></i>'></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text='<i class="fa fa-remove" width="50px" aria-hidden="true"></i>'></asp:LinkButton>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Visible="False" CommandArgument='<%# (Container.DataItemIndex) %>' Text='<i class="fa fa-pencil-square-o" width="50px" aria-hidden="true"></i>'></asp:LinkButton>
                                                        </ItemTemplate>

                                                        <%--  <FooterStyle HorizontalAlign="Right" />
                                                        <FooterTemplate>
                                                            <asp:Button ID="ButtonAdd" runat="server"
                                                                Text="Add New Row" OnClick="ButtonAdd_Click" />
                                                        </FooterTemplate>--%>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="" ItemStyle-CssClass="text-center-imp">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="False" CommandName="ADD" Visible="False" CommandArgument='<%# (Container.DataItemIndex) %>' Text='<i class="fa fa-plus-square" width="50px" aria-hidden="true"></i>'></asp:LinkButton>
                                                            <%--<asp:LinkButton runat="server" ID="btnShowPopup" CommandName="Select" data-toggle="modal" data-target="#Action" CommandArgument='<%# (Container.DataItemIndex) %>'   CssClass="fa fa-sign-in"  ToolTip="Click here For Update Plantation Detail " />--%>
                                                            <%--<input type="button" value="Click Me"  id="btnShowPopup" data-toggle="modal" data-target="#Action" >  --%>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="" ItemStyle-CssClass="text-center-imp" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" ID="btnDelete" Visible="False" Text='<i class="fa fa-trash-o" aria-hidden="true"></i>' CommandName="DeleteEngineeringDetail" CommandArgument='<%# (Container.DataItemIndex) %>' ToolTip="" OnClientClick="return confirm('Are you sure you want to delete this event?');" />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
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
    <script type="text/javascript">
        function PrintElem() {

            Popup($('#Divv').html());
        }
     

        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=2000');
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
      </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
