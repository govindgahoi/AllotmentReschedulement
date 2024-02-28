<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="CreateServiceChecklist.aspx.cs" Inherits="Allotment.Masters.CreateServiceChecklist" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



     <style type="text/css">
        .hideGridColumn {
            display: none;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:MessageBox ID="MessageBox1" runat="server" />
    <cc1:ConfirmBox ID="ConfirmBox1" runat="server" />
    <div class="main-content">
        <!--<ul class="nav nav-tabs">
            <li class="active"><a href="#Timeline" data-toggle="tab">Service Timeline</a></li>
        </ul>-->
        <div class="row">
            <div class="col-md-12">
                <div id="myTabContent" class="tab-content">
                    <div class="tab-pane active in" id="Timeline">
                        <div class="panel panel-default">
                            <p class="panel-heading font-bold">Service Timelines Details</p>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-md-3 text-right">
                                            <span style="color: Red">*</span>ServiceID :
                                        </label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtServiceID" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblServiceID" Visible="false" runat="server" Text=""></asp:Label>
                                            <asp:Label ID="lblCheckListID" Visible="false" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-md-3 text-right">
                                            <span style="color: Red">*</span>
                                            Land Use :
                                        </label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="drplanduse" CssClass="input-sm similar-select1" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-md-3 text-right">
                                            <span style="color: Red">*</span>
                                            Service :
                                        </label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtActivity" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-md-3 text-right">
                                            <span style="color: Red">*</span>
                                            Timelines(Regional Office) :
                                        </label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtTimelines" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-md-3 text-right">
                                            <span style="color: Red">*</span>
                                            Timelines(Head Office)  :
                                        </label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtApprover" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />

                            </div>
                        </div>

                        <div class="panel panel-default">
                            <p class="panel-heading font-bold">Add Service Timelines Checklist</p>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-md-3 text-right">
                                            <span style="color: Red">*</span>
                                            CheckList Heading :
                                        </label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtNorms" CssClass="input-sm similar-select1 margin-left-z" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:CheckBox ID="chkNorms" Text=" Tick if Multiple Checklist are to be created under this Norms?" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-md-3 text-right">
                                            <span style="color: Red">*</span>
                                            CheckList* :
                                        </label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtChecklist" CssClass="input-sm similar-select1 margin-left-z" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group" style="margin-top: 2px; margin-bottom: 2px;">
                                    <div class="row">
                                        <asp:UpdatePanel ID="pnlFileUpload" runat="server">
                                            <ContentTemplate>
                                                <label class="col-md-3">
                                                    Upload Check list Document<br />
                                                    <span class="myred">(Pdf of size upto 1mb only)</span></label>
                                                <div class="col-md-3">
                                                    <asp:FileUpload ID="fileupload" Width="300px" CssClass="form-control" runat="server" />
                                                </div>
                                                <div class="col-md-6">
                                                    <span>
                                                        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" CssClass="btn btn-primary ey-bg btn-sm" Style="margin: 0 1px 0 0; width: 65px;" Text="Upload" />
                                                        <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                                                    </span>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnUpload" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group" style="margin-top: 2px; margin-bottom: 2px;">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <span style="color: blue">Field marked with <span style="color: Red">* </span>are mandatory</span>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-primary btn-sm" Style="margin: 0 1px 0 0; width: 65px;" OnClick="btnSubmit_Click" />
                                        </div>
                                        <div class="col-md-4"></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel panel-default">
                            <p class="panel-heading font-bold">Service CheckList Details</p>
                            <div class="panel-body">
                                <asp:GridView ID="GridView2" runat="server"
                                    CssClass="table table-striped table-bordered table-hover request-table"
                                    AllowPaging="True"
                                    AllowSorting="True"
                                    AutoGenerateColumns="False"
                                    DataKeyNames="ServiceCheckListsID"
                                    GridLines="Horizontal" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="10"
                                    OnRowDataBound="GridView2_RowDataBound"
                                    OnRowCommand="GridView2_RowCommand"
                                    PagerStyle-CssClass="pagination-ys"
                                    PagerStyle-HorizontalAlign="Right"
                                    Width="100%" OnSorting="GridView2_Sorting"
                                    OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
                                    OnRowDeleting="GridView2_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:BoundField DataField="ServiceCheckListsID" HeaderText="" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" SortExpression="ServiceCheckListsID" />
                                        <asp:BoundField DataField="ServiceTimeLinesID" HeaderText="" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" SortExpression="ServiceTimeLinesID" />
                                        <asp:BoundField DataField="ServiceTimeLinesActivity" HeaderText="Service Description" SortExpression="ServiceTimeLinesActivity" />
                                        <asp:BoundField DataField="ServiceTimeLinesCondition" HeaderText="Documents Type" SortExpression="ServiceTimeLinesCondition" />
                                        <asp:BoundField DataField="ServiceTimeLinesDocuments" HeaderText="Document Description" SortExpression="ServiceTimeLinesDocuments" />
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEdit" Text='<i class="fa fa-pencil-square-o" aria-hidden="true"></i>' CssClass="" ToolTip="Edit Record" CommandName="EditRow" CausesValidation="false" CommandArgument='<%# (Container.DataItemIndex) %>' />
                                                <%--  <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/images/document_edit.png" ToolTip="Edit Record" CommandArgument="<%# Container.DataItemIndex %>" CommandName="EditRow" CausesValidation="false" />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Document View" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" Text='<i class="fa fa-download" aria-hidden="true"></i>' />
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
    </div>
</asp:Content>
