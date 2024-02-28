<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="IAPlotCancelation.aspx.cs" Inherits="Allotment.IAPlotCancelation" %>

<%@ Register Src="~/UC_topbutton.ascx" TagPrefix="uc1" TagName="UC_topbutton" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .div-listleft select option {
            border-bottom: 1px solid #ccc;
            font-size: 13px;
        }

        .btn-advertise {
            width: 132px;
            margin-top: 5px;
            padding: 0px 0;
            font-size: 20px;
            background: #a5a5a5;
        }

        .content {
            min-height: 650px;
        }

        .div-listleft {
            border: 1px solid #ccc;
            min-height: 65vh;
            background: #f7f7f7;
        }

        @media only screen and (min-width: 960px) {
            .pad-left0 {
                padding-left: 2px;
            }

            .pad-right0 {
                padding-right: 2px;
            }
        }

        .div-view.div-scroll {
            overflow-y: scroll;
            max-height: 390px;
            margin: 0px 24px;
            border: 1px solid #ccc;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UC_topbutton runat="server" ID="UC_topbutton" />
    <div class="clearfix"></div>
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12" style="padding: 0;">
            <div class="panel panel-default">
                <div class="row">
                    <div class="table-responsive" style="margin-top: 3px; margin-bottom: 3px;">
                        <table id="tblsearch" class="table table-striped table-bordered table-hover  margin-b-2px request-table">
                            <tr style="background: #ececec;">
                                <td class="font-bold">
                                    <span style="color: Red">*</span>
                                    Regional Office :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddloffice" runat="server" OnSelectedIndexChanged="Regional_Changed" AutoPostBack="true" CssClass="btn btn-sm btn-default dropdown-toggle similar-select">
                                    </asp:DropDownList>
                                </td>
                                <td class="font-bold">
                                    <span style="color: Red">*</span>
                                    Industrial Area Name :
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpdwnIA" runat="server" CssClass="btn btn-sm btn-default dropdown-toggle similar-select" AutoPostBack="true" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td>
                                    <span style="color: Red">*</span>
                                    Plot No:
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="drpPlotNo" CssClass="chosen input-sm similar-select1 margin-left-z" OnSelectedIndexChanged="drpPlotNo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="panel panel-default" style="border: 1px solid #ccc;" runat="server" id="AllotteeDiv" visible="false">

                    <div class="">
                        <div class="">
                            <div class="panel-heading font-bold text-center">
                                Allottee Details                         
                            </div>
                            <div class="panel-body" style="padding: 0px !important;">
                                <div class="div-companydetail" style="background: #ececec;">
                                    <div class="form-group">
                                        <div class="">
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Regional Office :
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <em>
                                                    <asp:Label ID="lblRegionalOffice" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </div>
                                            <div class="hidden-lg hidden-md">
                                                <div class="clearfix"></div>
                                            </div>
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Industrial Area : 
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <em>
                                                    <asp:Label ID="lblIndustrialArea" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </div>
                                            <div class="hidden-lg hidden-md">
                                                <div class="clearfix"></div>
                                            </div>
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Date of Allotment :
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <em>
                                                    <asp:Label ID="lblDateofApplication" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblAllotteeID" Visible="false"></asp:Label>
                                        <asp:Label runat="server" ID="lblIAID" Visible="false"></asp:Label>
                                        <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
                                        <div class="">
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Plot Area :
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <em>
                                                    <asp:Label ID="lblplotarea" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </div>
                                            <div class="hidden-lg hidden-md">
                                                <div class="clearfix"></div>
                                            </div>
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Allottment Letter No :
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <em>
                                                    <asp:Label ID="lblAllotmentLetterNo" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </div>
                                            <div class="hidden-lg hidden-md">
                                                <div class="clearfix"></div>
                                            </div>
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Plot No :
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <em>
                                                    <asp:Label ID="lblPlotNo" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="">
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Allottee Name :
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <em>
                                                    <asp:Label ID="lblAllotteeName" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </div>

                                            <div class="hidden-lg hidden-md">
                                                <div class="clearfix"></div>
                                            </div>
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Firm/Company Name :
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <em>
                                                    <asp:Label ID="lblFirmCompanyName" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </div>
                                            <div class="hidden-lg hidden-md">
                                                <div class="clearfix"></div>
                                            </div>
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Firm Constitution :
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <em>
                                                    <asp:Label ID="lblCompanyConstitution" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="">
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Mobile No :
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <em>
                                                    <asp:Label ID="lblSignatoryMobile" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </div>
                                            <div class="hidden-lg hidden-md">
                                                <div class="clearfix"></div>
                                            </div>
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Address :   
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <em>
                                                    <asp:Label ID="lblAddress" runat="server" CssClass="font-bold"></asp:Label></em>
                                            </div>
                                            <div class="hidden-lg hidden-md">
                                                <div class="clearfix"></div>
                                            </div>
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Email ID : 
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <em>
                                                    <asp:Label ID="lblSIgnatoryEmail" runat="server" CssClass="font-bold"></asp:Label>
                                                </em>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div runat="server" id="EmailDiv" visible="true">
                                        <div class="form-group">
                                            <label class="col-md-2 text-right">
                                                Email ID:
                                            </label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtemail" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="separation" />
                                    </div>
                                    <div runat="server" id="MobileDiv" visible="true">
                                        <div class="form-group">
                                            <label class="col-md-2 text-right">
                                                Mobile No:
                                            </label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtmobile" runat="server" CssClass="input-sm similar-select1" MaxLength="10"></asp:TextBox>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="text-center">
                        <asp:Button runat="server" ID="btnRaise" Style="font-size: 16px; margin: 3px 0;" CssClass="btn-primary" Visible="false" Text="ReqestforPlotCancelation" OnClick="btnRaiseReqestforPlotCancelation_Click" />
                    </div>
                    <br />
                    <br />
                </div>

                <div class="" runat="server" id="PreviousServiceDiv" visible="false">
                    <div class="panel panel-default">
                        <div class="panel-heading text-center">Plot Cancelation Request Details</div>
                    </div>

                    <div class="panel-body">
                        <asp:GridView ID="PreviousServiceGrid" runat="server"
                            CssClass="table table-striped table-bordered table-hover request-table request-table"
                            AllowPaging="True"
                            AllowSorting="True"
                            AutoGenerateColumns="False"
                            DataKeyNames="ServiceRequestNO"
                            GridLines="Horizontal"
                            Width="100%" OnRowCommand="PreviousServiceGrid_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                                <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                                <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" />
                                <asp:BoundField DataField="ServiceRequestNO" ItemStyle-HorizontalAlign="Justify" HeaderText="Service No" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnk" Text='Select' CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" CommandName="Select" />
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
</asp:Content>
