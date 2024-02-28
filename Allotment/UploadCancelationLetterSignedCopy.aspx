<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="UploadCancelationLetterSignedCopy.aspx.cs" Inherits="Allotment.UploadCancelationLetterSignedCopy" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableViewState="true" AjaxFrameworkMode="Enabled" EnablePartialRendering="true">
    </asp:ScriptManager>
    <cc1:MessageBox ID="MessageBox1" runat="server" />
    <hr class="myhrline" />
    <div class="form-group">
        <label class="col-md-2 col-sm-6 col-xs-6">
            Notice  Type: 
        </label>
        <div class="col-md-10 col-sm-6 col-xs-6">
            <asp:ListBox runat="server" ID="drpAppointmentType" CssClass="MultiSelect" SelectionMode="Multiple" Width="100%"></asp:ListBox>
        </div>
    </div>

    <div class="clearfix"></div>
    <hr class="myhrline" />
    <div class="form-group">
        <div class="clearfix"></div>
        <label class="col-md-2 col-sm-6 col-xs-6">
            Notice  Description:
        </label>
        <div class="col-md-10 col-sm-6 col-xs-6">
            <asp:TextBox ID="txtComment" runat="server" Rows="10" TextMode="MultiLine" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="panel-heading text-center">Notice Letter</div>
    <div class="col-md-12 col-sm-12 col-xs-12" id="Divwe">
        <asp:UpdatePanel ID="pnlFileUpload" runat="server">
            <ContentTemplate>
                <div class="form-group">

                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            <span style="color: Red">*</span>
                            Notice Letter :
                        </label>
                        <div class="col-md-5 col-sm-12">
                            <span class="col-md-10">
                                <asp:FileUpload ID="FileUpload4" runat="server" /></span><span class="col-md-2">
                                    <asp:LinkButton ID="imgdocuments" runat="server" OnClick="imgdocuments_Click" CommandName="Upload" Text='<i class="fa fa-upload"></i>' /></span>
                            <%--<asp:FileUpload ID="POAPhotoUpload" runat="server"  CssClass="input-sm similar-select" ToolTip="Upload"></asp:FileUpload>--%>
                        </div>
                        <div class="col-md-4 col-sm-12">
                            <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="imgdocuments" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />
    <span class="pull-right">
        <asp:Button runat="server" Text="Create Notice" ID="btnSend" class="btn-primary btn-sm margin-left-z" Style="margin: 7px 10px;" OnClick="btnSend_Click" /></span>
    <div class="clearfix"></div>
    <hr class="myhrline" />
    <div class="clearfix"></div>
    <hr class="myhrline" />
    <div class="panel-heading font-bold" style="padding: 7px 3px !important;">List Of Notice</div>
    <div class="col-md-12 col-sm-12 col-xs-12" id="DivP">
        <asp:GridView ID="GridView1" runat="server"
            CssClass="table table-striped table-bordered table-hover request-table request-table"
            OnRowCommand="GridView1_RowCommand"
            AllowSorting="True"
            AutoGenerateColumns="False"
            DataKeyNames="ServiceRequestNO,NoticeID"
            GridLines="Horizontal"
            Width="100%" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="NoticeID" HeaderText="Notice ID" SortExpression="NoticeID" />
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request NO" SortExpression="ServiceRequestNO" />
                <asp:BoundField DataField="Noticetype" HeaderText="Notice Type" SortExpression="Noticetype" />
                <asp:BoundField DataField="AppointmentDesc" HeaderText="Notice Description" SortExpression="AppointmentDesc" />
                <asp:BoundField DataField="CreatedOn" HeaderText="Created On" SortExpression="CreatedOn" />
                <asp:TemplateField>
                    <HeaderStyle />
                    <HeaderTemplate>
                        <asp:Label ID="hlblimg" runat="server" Text=""></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" usesubmitbehavior="true" Text='<i class="fa fa-download" aria-hidden="true"></i>' />/ 
                   <asp:LinkButton ID="lbView1" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument" usesubmitbehavior="true" Text=''><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <EmptyDataTemplate>
                No Record Available
            </EmptyDataTemplate>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />

            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </div>
    <div class="panel">
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="panel-heading font-bold" style="text-align: center;">
                    Document Viewer                        
                </div>

                <div class="bp-divviewer">
                    <asp:Literal ID="ltEmbed" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
