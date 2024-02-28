<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="Cancelation.aspx.cs" Inherits="Allotment.Cancelation" %>

<%@ Register Src="~/UC_topbutton.ascx" TagPrefix="uc1" TagName="UC_topbutton" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .div-listleft select option {
            border-bottom:1px solid #ccc;
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
    <div class="">
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
                        </tr>
                        <tr style="display: none;">
                            <td colspan="3">
                                <span></span>
                            </td>

                            <td>
                                <asp:Button CssClass="btn btn-sm btn-primary pull-right" Text="New Registration" ID="New_Allottee_Registration_btn" runat="server" />
                                <asp:Button CssClass="btn btn-sm btn-primary pull-right" Style="margin-right: 2px;" Text="Allottee History Registration" ID="History_Allottee_Entry_btn" runat="server" />
                            </td>

                        </tr>
                    </table>
                </div>
                </div>
                <div class="row">
                    <!--<div class="col-md-1 col-sm-12 col-xs-12"></div>-->
                    <div class="col-md-12 col-sm-12 col-xs-12" style="background: #ccc; padding: 10px 10px;">
                        <div class="row" style="background: #fff;border: 1px solid #ccc;margin: 0;">
                            <div class="col-md-2 col-sm-3 col-xs-12 pad-right0 pad-left0">
                                <div class="div-listleft">
                                    <div class="panel-heading font-bold">List of Plots</div>
                                    <asp:ListBox ID="ListParent" runat="server" SelectionMode="Single" Style="min-height: 60.7vh;width:100%;background: #f7f7f7;"></asp:ListBox>
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-3 col-xs-12 pad-left0 pad-right0">
                                <div class="div-listleft" style="background: #f3f3f3;">
                                    <div style="border:1px solid #ccc;background: #fff;margin-right: 5px;min-height: 147px;margin-bottom: 5px;margin-left: 5px;border-top:0px solid #ccc;">
                                        <div class="panel-heading font-bold" style="margin-bottom: 3px;">Move for Cancelling the Allotment</div>
                                        <div class="form-group">
                                            <div class="row">
                                                <label class="col-md-12">
                                                    <div class="panel-heading">Ground For Canceling :</div>
                                                </label>
                                                <div class="col-md-12">
                                                    <asp:DropDownList ID="drpCancelationGround" style="margin-bottom: 10px;margin-top: 4px;" runat="server" AutoPostBack="true" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1" OnSelectedIndexChanged="drpCancelationGround_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                                                </div>  
                                             </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="panel-heading font-bold" style="margin: 3px;">Attach the Order for Cancellation</div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-md-12" style="display:none;">
                                                    <asp:Label ID="lblupload" runat="server" Text="Attach the Order for Cancellation"></asp:Label>
                                                </div>
                                                <div class="col-md-12">
                                                    <asp:FileUpload Style="margin:5px 0 7px 0;" runat="server" ID="FuplodApplicantImage" onchange="ShowImagePreview(this);" />
                                                </div>
                                                <div class="col-md-12">
                                                    <button runat="server" id="btnupload" class="btn-primary btn-sm ey-bg" style="display:none;padding: 2px 6px; margin: 5px 0;" onserverclick="btnupload_ServerClick">Upload</button>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div style="border: 1px solid #ccc;margin: 0px 5px;padding: 5px 0 13px 0;">
                                            <div class="form-group">

                                                <div class="col-md-12 text-center">
                                                    <asp:Button CssClass="btn btn-sm btn-primary btn-advertise" Style="margin-right: 2px;" Text=">" ID="btnSingleForward" runat="server" OnClick="btnSingleForward_Click" /><br />
                                                    <asp:Button CssClass="btn btn-sm btn-primary btn-advertise" Style="margin-right: 2px;" Text=">>" ID="btnDoubleForward" runat="server" OnClick="btnDoubleForward_Click" /><br />
                                                    <asp:Button CssClass="btn btn-sm btn-primary btn-advertise" Style="margin-right: 2px;" Text="<<" ID="btnDoubleBack" runat="server" OnClick="btnDoubleBack_Click" /><br />
                                                    <asp:Button CssClass="btn btn-sm btn-primary btn-advertise" Style="margin-right: 2px;" Text="<" ID="btnSingleBack" runat="server" OnClick="btnSingleBack_Click" /><br />
                                                </div>
                                                <!--<label class="col-md-12 text-center" style="margin-top:30px;">Open For Allotment</label>
                                                <div class="col-md-12 text-center">
                                                    <asp:DropDownList ID="drpopenAds" runat="server" Width="100%" class="input-sm similar-select margin-left-z"></asp:DropDownList>
                                                </div>-->
                                            </div>
                                            <div class="clearfix"></div>
                                    </div>
                                    <div style="border: 1px solid #ccc;margin: 5px 5px;padding: 5px 0 13px 0;min-height: 147px;background: #fff;">
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-2 col-sm-3 col-xs-12 pad-left0 pad-right0">
                                <div class="div-listleft">
                                    <div class="panel-heading font-bold">Plots Selected for Cancelation</div>
                                    <asp:ListBox ID="ListSelected" runat="server" SelectionMode="Multiple" Style="min-height: 55vh;background: #f7f7f7;width:100%;"></asp:ListBox>
                                    <asp:Button CssClass="btn btn-sm btn-primary pull-right" Style="margin-right: 2px; margin-top: 10px;" Text="Proceed" ID="btnpublish" runat="server" OnClick="btnpublish_Click" />
                                </div>
                            </div>
                            <div class="col-md-5 col-sm-3 col-xs-12 pad-left0 pad-right0">
                                <div class="div-listleft">
                                    <div class="panel-heading font-bold">Plots in Cancelation List</div>
                                    <div class="table-responsive">
                                             <asp:GridView ID="GridView2" runat="server"
                                                        CssClass="table table-striped table-bordered table-hover request-table"
                                                        AllowPaging="false"
                                                        AllowSorting="True"
                                                        AutoGenerateColumns="False"
                                                        DataKeyNames="PlotNumber,Status"
                                                        GridLines="Horizontal"
                                                        OnRowDataBound="GridView2_RowDataBound"
                                                        OnRowCommand="GridView2_RowCommand"
                                                        OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
                                                        Width="600px"
                                                        ItemStyle-Width="10%" >
                                                        <Columns>
                                                             <ASP:HYPERLINKFIELD text="Process" datanavigateurlfields="ServiceRequestNO" datanavigateurlformatstring="ReportGenration.aspx?ServiceReqNo={0}"></ASP:HYPERLINKFIELD> 
                                                            <asp:BoundField DataField="PlotNumber" HeaderText="PlotNumber" SortExpression="PlotNumber" />
                                                            <asp:BoundField DataField="STATUS" HeaderText="Current Status" Visible="true" SortExpression="STATUS" />
                                                            <asp:BoundField DataField="CancellationrequestDate" HeaderText="Date" Visible="true" SortExpression="CancellationrequestDate" />
                                                            <asp:BoundField DataField="CancellationGround" HeaderText="Cancellation Ground" Visible="true" SortExpression="CancellationGround" />
                                                            <asp:BoundField DataField="ServiceRequestNO" HeaderText="ServiceRequestNO" Visible="false" SortExpression="ServiceRequestNO" />
                                                        </Columns>
                                                    </asp:GridView>
                                     </div>
                                   
                                </div>
                            </div>
                            <div class="clearfix"></div>
                        </div>

                    </div>
                    <div class="clearfix"></div>
                    <!--<div class="col-md-1 col-sm-12 col-xs-12"></div>-->
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
