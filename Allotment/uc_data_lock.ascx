<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_data_lock.ascx.cs" Inherits="Allotment.uc_data_lock" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>




<style>
    .my-dash-table-status tr td:nth-child(1) {
        text-align: left;
        position: absolute;
        height: 50px;
        width: 11.3em;
        font-size: 12px;
        left: 28px;
    }

    .my-dash-table-status tr th:nth-child(1) {
        text-align: left;
        position: absolute;
        width: 10.3em;
        left: 28px;
    }

    #divsectionrecommendation {
        min-height: 86px;
    }

    #divoperational {
        min-height: 86px;
    }

    #divvalidation {
        min-height: 86px;
    }

    #divregulations {
        min-height: 86px;
    }

    #divcurrentstatus {
        min-height: 154px;
    }

    .status-bar-bottom {
        position: relative;
        background: #f5f5f5;
        bottom: 0;
        /* margin-top: 1px; */
        border: 1px solid #ccc;
        width: 100%;
        margin-bottom: 0;
    }

    .ul-plot-view li {
        border-right: 1px solid #ccc;
        min-width: 257px;
    }

    .content {
        min-height: 200px;
    }

    #ContentPlaceHolder1_uc_data_lock_txtRemarks {
        width: 100% !important;
    }

    .levelclstxts {
        font-weight: bolder;
        color: green;
    }
</style>
<style type="text/css">
    .modalBackground {
        background-color: black;
        filter: alpha(opacity=90);
        opacity: 0.4;
    }

    .modalPopup {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: black;
        padding-top: 10px;
        padding-left: 10px;
        width: 505px;
        height: 197px;
    }

    #ContentPlaceHolder1_uc_data_lock_btnClose {
        margin-top: 95px;
        background-color: #ffc511;
        border: 1px solid #ffc511;
        font-weight: normal;
        color:#000000;
        padding:3px 14px 3px 14px;
    }
</style>

<%--<asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" >
</asp:ScriptManager>--%>





<div class="row" style="border: 3px solid #c5c506; margin: 5px 0 0 0px; padding: 5px 0;">
    <div class="col-md-8 col-sm-12 col-xs-12" style="border-right: 1px solid #ccc">
        <div class="col-left-Service">
            <div class="tab-content clearfix">
                <div class="tab-pane active" id="divoperational">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12" style="border-right: 1px solid #ccc">

                                <div class="row" style="margin-top: 0px;">
                                    <label class="col-md-2 col-sm-6 col-xs-6 font-bold  text-right ">
                                        Lock Data:
                                    </label>


                                    <%--data-toggle="modal" data-target="#exampleModalCenter"--%>
                                    <div class="col-md-7 col-sm-6 col-xs-6">
                                        <asp:DropDownList ID="drpOperations" AutoPostBack="true" class="input-sm similar-select1" runat="server" OnSelectedIndexChanged="drpOperations_SelectedIndexChanged"></asp:DropDownList>
                                    </div>

                                    <asp:Label ID="lblDataStatus1" runat="server" Text="" class="col-md-2 col-sm-6 col-xs-6 levelclstxts"></asp:Label>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" style="margin-bottom: 3px;" />
                            </div>

                        </div>
                    </div>
                    <div class="form-group">


                        <div class="row">
                            <label class="col-md-2 col-sm-6 col-xs-6 font-bold text-right">
                                Remarks:
                                <!--<div class="panel-heading" style="margin-top:15px;" data-toggle="collapse" data-target="#bp-divtabs-notesheet">Remarks: <span class="pull-right"><span class="glyphicon glyphicon-plus"></span></span></div>-->
                            </label>
                            <!--<div class="col-md-12 col-sm-12 col-xs-12 collapse" id="bp-divtabs-notesheet">-->
                            <div class="col-md-7  col-sm-6 col-xs-6">
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="input-sm similar-select1 margin-left-z multi-bg" Style="height: 52px;" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <%--data-toggle="modal" data-target="#exampleModalCenter"--%>
                            <div class="col-md-1 col-sm-12 col-xs-12">
                                <asp:Button ID="btnOperaSave" CssClass="btn btn-sm btn-primary text-right btn-bpservice pull-right" runat="server" Text="Proceed" OnClick="btnOperaSave_Click" />
                            </div>
                            <div class="col-md-2  col-sm-12 col-xs-12">
                                <asp:Button ID="btnAssesment" CssClass="btn btn-sm btn-primary text-right btn-bpservice pull-right" runat="server" Text="Assessment" OnClick="btnAssesment_Click" />
                            </div>
                            <!--</div>-->
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                </div>
                <div class="tab-pane" id="divvalidation">
                    <asp:TextBox ID="txtValidate" runat="server" CssClass="input-sm similar-select1 margin-left-z multi-bg" Style="height: 48px;" TextMode="MultiLine"></asp:TextBox>
                    <asp:Button ID="btnvalidate" CssClass="btn btn-sm btn-primary text-right btn-bpservice pull-right" runat="server" Text="Validate" Style="margin-left: 3px;" />
                    <asp:Button ID="btnclear" CssClass="btn btn-sm btn-primary text-right btn-bpservice pull-right" runat="server" Text="Clear" />
                </div>
                <div class="tab-pane" id="divregulations">
                    <asp:TextBox ID="txtRegulations" runat="server" CssClass="input-sm similar-select1 margin-left-z multi-bg" Style="height: 72px;" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="tab-pane" id="divsectionrecommendation">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12" style="border-right: 1px solid #ccc">

                                <div class="row" style="margin-top: 0px;">
                                    <label class="col-md-3  col-sm-6 col-xs-6 font-bold">
                                        Seek Additional Information:
                                    </label>
                                    <div class="col-md-8  col-sm-6 col-xs-6">
                                        <asp:DropDownList ID="drpSeekinfo" class="input-sm similar-select1" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr class="myhrline" style="margin-bottom: 3px;" />
                            </div>
                            <!--<div class="col-md-4" style="">
                                <div class="panel panel-default">
                                    <div class="chair-heading-bot font-bold">
                                        Notesheet Settings
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-6 text-right font-bold">
                                                Annex Document:
                                            </label>
                                            <div class="col-md-6">
                                                <asp:DropDownList ID="DropDownList3" class="input-sm similar-select1" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <asp:Button ID="Button1" CssClass ="btn btn-sm btn-primary text-right btn-bpservice" runat="server" Text="Current Status"/>
                                    <asp:Button ID="Button2" CssClass ="btn btn-sm btn-primary text-right btn-bpservice" runat="server" Text="Notesheet"/>
                                </div>
                            </div>-->
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3  col-sm-6 col-xs-6 font-bold text-right">
                                Request
                            </label>
                            <div class="col-md-8  col-sm-6 col-xs-6">
                                <asp:TextBox ID="txtRecommendRequest" runat="server" CssClass="input-sm similar-select1 margin-left-z multi-bg" Style="height: 52px;" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="col-md-1  col-sm-12 col-xs-12">
                                <asp:Button ID="btnSave" CssClass="btn btn-sm btn-primary text-right btn-bpservice pull-right" CausesValidation="false" runat="server" Text="Save" />
                                <%--<asp:Button ID="BtnSave1" runat="server" Text="Button" />--%>
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="tab-pane" id="divcurrentstatus">
                    <%--<asp:TextBox ID="txtErrorMessage" runat="server" CssClass="input-sm similar-select1 margin-left-z multi-bg" style="height:72px;" TextMode="MultiLine"></asp:TextBox>--%>
                </div>
            </div>
            <div class="clearfix"></div>

            <div class="col-md-12 col-sm-12 col-xs-12">
                <!--<asp:Menu id="Menu1" Orientation="Horizontal" CssClass="selected highlighted" StaticMenuStyle-CssClass="nav nav-pills myul-tabs" StaticSelectedStyle-CssClass="active selected highlighted" Runat="server">
     <Items>
     <asp:MenuItem Text="Operational" Value="0" NavigateUrl="#1a"/>
     <asp:MenuItem Text="Validations" Value="1"  NavigateUrl="#2a" />
     <asp:MenuItem Text="Regulations" Value="2"  NavigateUrl="#3a"/>
     <asp:MenuItem Text="Section Recommendation" />
     </Items>    
 </asp:Menu>-->

                <ul class="nav nav-pills myul-tabs">
                    <li><a href="#divoperational" data-toggle="tab" class="font-bold active">Operational</a></li>
                    <li><a href="#divvalidation" data-toggle="tab" class="font-bold">Validations</a></li>
                    <li><a href="#divregulations" data-toggle="tab" class="font-bold">Regulations</a></li>
                    <li><a href="#divsectionrecommendation" data-toggle="tab" class="font-bold">Other Information</a></li>
                    <%--<li><a href="#divcurrentstatus" data-toggle="tab" class="font-bold">Messages</a></li>--%>
                </ul>

            </div>


        </div>
    </div>

    <div class="col-md-4 col-sm-12 col-xs-12">

        <!--<hr style="border-top: 1px solid #929090;border-bottom: 1px solid #fff;margin-top: 12px;"/>-->
        <div class="panel panel-default">
            <div class="chair-heading-bot font-bold">Data Author</div>
        </div>
        <div class="form-group">
            <div class="row">
                <label class="col-md-4 col-sm-6 col-xs-6 text-right font-bold">
                    Approver:
                </label>
                <div class="col-md-8 col-sm-6 col-xs-6">
                    <asp:DropDownList ID="drpApprover" class="input-sm similar-select1" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
        <hr class="myhrline" />
        <div class="form-group">
            <div class="row">
                <label class="col-md-4 col-sm-6 col-xs-6 text-right font-bold">
                    Reviewer:
                </label>
                <div class="col-md-8 col-sm-6 col-xs-6">
                    <asp:DropDownList ID="drpReviewer" class="input-sm similar-select1" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
        <hr class="myhrline" />
        <div class="form-group">
            <div class="row">
                <label class="col-md-4 col-sm-6 col-xs-6 text-right font-bold">
                    Verifier:
                </label>
                <div class="col-md-8 col-sm-6 col-xs-6">
                    <asp:DropDownList ID="drpVerifier" class="input-sm similar-select1" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
        <hr class="myhrline" />

    </div>
</div>

<div class="status-bar-bottom">

    <div class="form-group">
        <ul class="list-inline ul-plot-view">
            <li>Message:
                <asp:Label ID="lblMessage" runat="server" CssClass="font-bold"></asp:Label>
            </li>
            <li>Mode:
                <asp:Label ID="lblMode" runat="server" CssClass="font-bold"></asp:Label></li>
            <li>Data Status:
                <asp:Label ID="lblDataStatus" runat="server" CssClass="font-bold"></asp:Label>
            </li>
            <li>Change Date:
                <asp:Label ID="lblChangeDate" runat="server" CssClass="font-bold"></asp:Label></li>
            <li>
                <asp:DropDownList ID="ddllog" runat="server" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1" Style="width: 86px; height: 20px;">
                    <asp:ListItem>log</asp:ListItem>
                </asp:DropDownList>
            </li>


        </ul>
    </div>
</div>
<%--<!-- ModalPopupExtender -->
<asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnOperaSave"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
   <h5> <b><u>ERP Message Box</u></b></h5><br />
    <asp:Label ID="lblPopMessage" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="btnpok" runat="server"  Text="Confirm" OnClick="btnpok_Click" />
    <asp:Button ID="btnClose" runat="server" Text="Close" />

</asp:Panel>
<!-- ModalPopupExtender -->--%>

<!-- Modal -->

