<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="ServiceTimelinesCreate.aspx.cs" Inherits="Allotment.Masters.ServiceTimelinesCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../css/index.css" rel="stylesheet" />--%>
    <%-- <link href="../css/myGrid.css" rel="stylesheet" />--%>
<%--    <link href="../css/Main.css" rel="stylesheet" />
    <script src="../js/jquery.knob.js"></script>
    <script src="../js/jquery.js"></script>
    <script src="../js/jquery-1.11.3.min"></script>
    <script src="../js/bootstrap.min.js"></script>--%>
    <style type="text/css">
        .auto-style2 {
            text-align: right;
            width: 212px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <%-- <hr style="border-top: 1px dashed #8c8b8b;" />--%>
        <div id="header">
            <div class="panel panel-default">
                <p class="panel-heading font-bold">Create Service Timelines</p>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span>
                                Land Use Type :
                            </label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="drplanduse" class="input-sm similar-select1" runat="server"></asp:DropDownList>
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
                                <asp:TextBox ID="txtActivity" runat="server" class="input-sm similar-select1 span12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvActivity" runat="server"
                                    ErrorMessage="Activity can't be left blank" ControlToValidate="txtActivity"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span>
                                Set Timelines RM/PO Level :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtTimelines" runat="server" class="input-sm similar-select1 span12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTimelines" runat="server"
                                    ErrorMessage="Timelines can't be left blank" ControlToValidate="txtTimelines"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span>
                                Set Timelines HO Level :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtApprover" runat="server" class="input-sm similar-select1 span12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvApprover" runat="server"
                                    ErrorMessage="Approving Authority can't be left blank" ControlToValidate="txtApprover"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
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
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblServiceID" Visible="false" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="form-group" style="margin-top:15px;">
                        <div class="col-md-3">
                            <span style="color: blue; margin-right:15px;">Field marked with <span style="color: Red">* </span>are mandatory</span><asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-primary btn-sm" style="margin:0 1px 0 0;width:65px;"  OnClick="btnSubmit_Click" />
                        </div>
                        <div  class="col-md-4">
                            <p class=""></p>
                        </div>
                        <div  class="col-md-4"></div>

                        
                    </div>
                    <div class="clearfix"></div>
                        <asp:Panel ID="pnlCheckList" Enabled="false" runat="server">
                                <asp:LinkButton ID="lnkChecklist" runat="server" OnClick="lnkChecklist_Click"><i class="fa fa-hand-o-right" aria-hidden="true"></i>Click here to Add Checklist for this Service?</asp:LinkButton>                                
                        </asp:Panel>
                    <br />
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <p class="panel-heading font-bold">Service Timelines Details</p>
            <div class="panel-body">
                <asp:GridView ID="GridView2" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table"
                                AllowPaging="True"
                                AllowSorting="True"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceTimeLinesID"
                                GridLines="Horizontal" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="10"
                                OnRowDataBound="GridView2_RowDataBound"
                                OnRowCommand="GridView2_RowCommand"
                                Width="100%" OnSorting="GridView2_Sorting"
                                OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
                                PagerStyle-CssClass="pagination-ys" 
                                PagerStyle-HorizontalAlign="Right"
                                OnRowDeleting="GridView2_RowDeleting">
                                <Columns>
                                   <%-- <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="ServiceTimeLinesID" ItemStyle-HorizontalAlign="Justify" HeaderText="ID" SortExpression="ServiceTimeLinesID"/>
                                    <asp:BoundField DataField="ServiceTimeLinesDepartMent" HeaderText="Land Use Type" SortExpression="ServiceTimeLinesDepartMent" />
                                    <asp:BoundField DataField="ServiceTimeLinesActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Activity" SortExpression="ServiceTimeLinesActivity" />
                                    <asp:BoundField DataField="ServiceTimeLines" HeaderText="RM/PO Level" SortExpression="ServiceTimeLines" />
                                    <asp:BoundField DataField="ServiceTimeLinesHOLevel" HeaderText="HO Level" SortExpression="ServiceTimeLinesApprovingLevel" />

                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnEdit"  ToolTip="Edit Record" Text='<i class="fa fa-pencil-square-o" aria-hidden="true"></i>'  CommandName="EditRow" CausesValidation="false" CommandArgument='<%# (Container.DataItemIndex) %>' />
                                            <%--<asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/images/document_edit.png" ToolTip="Edit Record" CommandArgument="<%# Container.DataItemIndex %>" CommandName="EditRow" CausesValidation="false" />--%>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnDel"  ToolTip="Edit Record" Text='<i class="fa fa-times" aria-hidden="true"></i>'  CommandName="DeleteRow" CausesValidation="false" CommandArgument='<%# (Container.DataItemIndex) %>' />
                                           <%-- <asp:ImageButton ID="imgDel" runat="server" ImageUrl="~/images/document_delete.png" ToolTip="Delete Record" CommandArgument="<%# Container.DataItemIndex %>" CommandName="DeleteRow" CausesValidation="false" />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    No Record Available
                                </EmptyDataTemplate>
                            </asp:GridView>
            </div>
        </div>
        <footer>
            <div>
                <div class="row">
                    
                </div>

            </div>

        </footer>

    </div>
</asp:Content>
