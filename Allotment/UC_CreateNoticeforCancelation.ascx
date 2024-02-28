<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_CreateNoticeforCancelation.ascx.cs" Inherits="Allotment.UC_CreateNoticeforCancelation" %>
<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<style>
    .content {
        min-height: 650px;
    }

    .div-listleft {
        border: 1px solid #ccc;
        min-height: 73vh;
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

    .left-plotlist option {
        border-bottom: 1px solid #ccc;
        font-size: 12px;
        padding-left: 8px;
    }

    @media only screen and (min-width: 900px) {
        .left-plotlist {
            width: 100%;
            height: 506px !important;
        }
    }
</style>
<style>
    #ModalGridchange .modal-header {
        padding: 0px 12px;
        background: #e4e4e4;
        border-bottom: 1px solid #ccc;
    }

    #ModalGridchange .modal-footer {
        padding: 0;
    }

    #ModalGridchange button {
        margin-top: 1px;
    }

    @media only screen and (min-width: 768px) {
        #ModalGridchange .modal-dialog {
            margin: 17% 56% !important;
            width: 35% !important;
        }

        #ModalGridchange {
            right: 21%;
            top: 10%;
        }

        .modal-dialog {
            width: 389px !important;
            margin-left: 55% !important;
            margin-top: 22% !important;
        }
    }

    @media only screen and (max-width: 768px) {
        .modal-dialog {
            width: 389px !important;
            margin-left: 55% !important;
            margin-top: 22% !important;
        }
    }

    .tooltip {
        position: absolute;
        top: 0;
        left: 0;
        z-index: 3;
        display: none;
        background-color: #FB66AA;
        color: White;
        padding: 5px;
        font-size: 10pt;
        font-family: Arial;
    }

    td {
        cursor: pointer;
    }
</style>


<script type="text/javascript">

    $(function () {
        $('[id*=GridView1] tr').each(function () {
            var toolTip = $(this).attr("title");
            $(this).find("td").each(function () {
                $(this).simpletip({
                    content: toolTip
                });
            });
            $(this).removeAttr("title");
        });
    });

    function MessageAndRedirect() {
        alert('Application Transfer');
        //  window.location.href = 'AllotmentRequest.aspx';

    }

    function ShowPopupChange() {

        $("#btnModalGridchange").click();
    }

</script>


<cc1:MessageBox ID="MessageBox1" runat="server" />
<input type="button" value="Click Me" style="display: none;" id="btnModalGridchange" data-toggle="modal" data-target="#ModalGridchange">
<div class="modal fade" id="ModalGridchange" style="left: -522px !important; top: -28px !important;" role="dialog">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">
                    <asp:Label runat="server" ID="change_title" Text="Account Clearance" /></h4>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <label class="col-md-5 col-sm-6 col-xs-6">
                        Received Date :
                    </label>
                    <div class="col-md-7 col-sm-6 col-xs-6">
                        <asp:TextBox ID="txtReceivedDate" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" placeholder="dd/mm/yyyy"></asp:TextBox>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
            </div>
            <div class="modal-footer">
                <div class="border-buttons pull-right">
                    <asp:HiddenField runat="server" ID="change_title1" />
                    <asp:HiddenField runat="server" ID="change_id" />
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-sm btn-primary btn-popup" Text="Submit" />
                    <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>

    </div>
</div>


<span class="pull-right">
    <asp:Button runat="server" Text="Genrate Notice Letter" ID="Button1" class="btn-primary btn-sm margin-left-z" Style="margin: 7px 10px;" OnClick="btnGenerate_Click" /></span>
<div class="clearfix"></div>
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
<div class="row" style="margin-top: 15px;">

    <div class="text-left">
        <asp:HiddenField ID="hfName" runat="server" />
        <ul class="nav nav-pills myul-tabs" style="margin-left: 0;">
            <asp:Panel ID="pnlDemo" runat="server"></asp:Panel>
        </ul>

    </div>
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

<div class="panel">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="panel-heading font-bold" style="text-align: center;">
                Document Viewer                        
            </div>

            <div class="bp-divviewer">
                <asp:Literal ID="Literal1" runat="server" />
            </div>
        </div>
    </div>
</div>

<div class="clearfix"></div>
