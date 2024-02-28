<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_FileUploader.ascx.cs" Inherits="Allotment.UC_FileUploader" %>
<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>
<style>
    .pad-left0 {
        padding-left: 0;
    }

    @media only screen and (max-width: 992px) {
        .form-group label.text-right {
            text-align: left !important;
        }
    }

    label {
        margin-bottom: 0;
    }
</style>
<div runat="server" id="uc_alloottee_details" class="row">
      <cc1:MessageBox ID="MessageBox1" runat="server" />
    <div class="panel-heading" style="width: 100%;">Upload  Notices/Orders/Judgment/Any Other Refrence Document </div>
    <div class="col-md-8 col-sm-12 col-xs-12" style="padding: 0;">
        <div class="panel panel-default" style="border: 1px solid #e6e6e6;">
            
            <div class="form-group ">
                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                     <span style="color: Red">*</span>
                    Attachment Name :
                </label>
                <div class="col-md-9 col-sm-6 col-xs-6 ">
                    <asp:TextBox ID="txtReffrence" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                </div>
            </div>
            <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group ">
                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                    Description :
                </label>
                <div class="col-md-9 col-sm-6 col-xs-6 ">
                    <asp:TextBox ID="txtdescription" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                </div>
            </div>
            <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                    Upload order/Judgement :
                </label>
                <div class="col-md-9 col-sm-12 col-xs-12">
                    <span class="col-md-10">
                        <asp:FileUpload ID="FileUpload4" runat="server" AllowMultiple="true" /></span><span class="col-md-2">
                            <asp:Button ID="btnUpload" runat="server"
                                Text="Upload" OnClick="btnUpload_Click" />
                        <%--    <a runat="server" id="A1" onserverclick="UploadFile_ServerClick">
                                <i class="fa fa-upload" aria-hidden="true"></i>
                            </a>--%>
                </div>
            </div>
            <div class="clearfix"></div>
            <hr class="myhrline" />
            <br />
        </div>

        <div class="clearfix"></div>
    </div>
    <div class="col-md-4 col-sm-12 col-xs-12" style="padding: 0;">
        <asp:GridView ID="GridView2" runat="server"
            CssClass="table table-striped table-bordered table-hover request-table"
            AllowPaging="True"
            PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"
            AutoGenerateColumns="False"
            GridLines="Horizontal">
            <Columns>
                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="DocumentID" Text='<%#Eval("CaseNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Document Name" SortExpression="Name" />
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
    </div>
    <%--<div class="col-md-12 col-sm-12 col-xs-12" style="padding: 0;">

        <div class="row" style="margin-top: 15px;">
            <div class="text-left">
                <asp:HiddenField ID="hfName" runat="server" />
                <ul class="nav nav-pills myul-tabs" style="margin-left: 0;">
                    <asp:Panel ID="pnlDemo" runat="server"></asp:Panel>
                </ul>

            </div>
        </div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="panel-heading" style="margin-top: 5px;">Viewer :</div>
                <div class="bp-divviewer">
                    <asp:Literal ID="ltEmbed" runat="server" />
                </div>
            </div>
        </div>
    </div>--%>
    <%--<script type = "text/javascript">
$(window).load(
    function() {
    $("#<%=FileUpload4.ClientID %>").fileUpload({
        'uploader': 'scripts/uploader.swf',
        'cancelImg': 'images/cancel.png',
        'buttonText': 'Browse Files',
        'script': 'Upload.ashx',
        'folder': 'uploads',
        'fileDesc': 'Image Files',
        'fileExt': '*.jpg;*.jpeg;*.gif;*.png',
        'multi': true,
        'auto': true
    });
   }
);
</script>--%>
</div>
