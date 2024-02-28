<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IAServicesApplication_PlotCancelation.aspx.cs" Inherits="Allotment.IAServicesApplication_PlotCancelation" %>

<%@ Register Src="~/ucAllotmentDeposits.ascx" TagPrefix="uc1" TagName="ucAllotmentDeposits" %>

<%@ Register Src="~/UC_Service_Allotteee_Detail.ascx" TagPrefix="uc1" TagName="s" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="https://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet" />
    <script src="js/jquery-ui.js"></script>
    <script src="js/chosen.jquery.min.js"></script>

    <%--<link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/Main.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/ajax-jquery-ui.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />
    <script src="js/ajax-jquery-min.js"></script>
    <script src="js/ajax-jquery-ui.js"></script>

    <script src="assets/js/bootstrap.min.js"></script>

    <script src="/js/jquery1.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script src="/js/jquery.js"></script>
    <script src="/js/bootstrap.min.js"></script>

    <link href="css/chosen.min.css" rel="stylesheet" />
    <script src="js/chosen.jquery.min.js"></script>--%>

    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();
        }
    </script>
    <script type="text/javascript">

        function FinalMsg(par) {
            alert("Form Submitted Successfully");
            window.location.href = 'IAServicesApplication_PlotCancelation.aspx?ServiceReqNo=' + par;
        }
        function MessageAndRedirect(par) {
            alert("Objection cleared and form re-submitted successfully");
            window.location.href = 'IAServicesApplication_PlotCancelation.aspx?ServiceReqNo=' + par;
        }
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            var newLine = "\r\n"
            var message = "Dear Applicant"
            message += newLine;
            message += "Please Check All the Data Entered By You.Once Finalised Cannot Be Edited";
            if (confirm(message)) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

        function ShowMessage(msg) {
            alert(msg);

        }


        function ShowFinalMsg() {

            //var txt;
            //var r = confirm("Please Confirm Your Data Before Finalising. After Finalising Data Cannot Be Edited");
            //if (r == true) {
            $("#btnModal").click();
            // } 
        }

        function ShowFinalMsgUPSIDC() {

            //var txt;
            //var r = confirm("Please Confirm Your Data Before Finalising. After Finalising Data Cannot Be Edited");
            //if (r == true) {
            $("#btnModalUPSIDC").click();
            //   } 


        }


    </script>
    <style>
        .modal-open {
            overflow: auto !important;
        }

        .nav-pills {
            margin-left: 0 !important;
        }

            .nav-pills > li + li {
                margin-left: 0px !important;
            }

        .pad-lt0 {
            padding-left: 0 !important;
        }

        .pad-rt0 {
            padding-right: 0 !important;
        }

        @media only screen and (max-width: 768px) {
            .form-group label.text-right {
                text-align: left !important;
            }

            .form-group .col-sm-6 {
                width: 50% !important;
            }

            .right-niveshban {
                text-align: center;
            }

            .left-niveshban {
                text-align: center;
            }
        }

        @media only screen and (min-width: 768px) {
            .right-niveshban {
                text-align: right;
            }

            .left-niveshban {
                text-align: left;
            }
        }

        .form-group label {
            font-weight: 700 !important;
        }

        .modal-open {
            overflow: auto;
        }

        input[type=file] {
            margin: 0 !important;
            width: 207px;
        }

        .hide {
            display: none;
        }

        .show {
            display: block;
        }

        #UpdateProgress1 {
            position: fixed;
            width: 100%;
            height: 100%;
            z-index: 99999;
            background: rgba(0,0,0,0.21176470588235294);
        }

            #UpdateProgress1 .fgh {
                position: absolute;
                top: 45%;
                margin: 0px auto;
                left: 45%;
                z-index: 999;
            }

        .MessagePennel {
            background-color: #f4e542;
            width: 100%;
        }

        .check-cross {
            color: #f70000;
            font-size: 18px;
            line-height: 0.7;
            font-weight: 100;
        }

        .nav-pills > li + li {
            margin-left: 0px;
        }

        .myul-tabs {
            margin-left: 0 !important;
        }

            .myul-tabs li {
                width: 100%;
                border-top: 1px solid #fff;
            }

                .myul-tabs li a:after {
                    display: none;
                }

                .myul-tabs li a:before {
                    display: none;
                }

        h4.modal-title {
            margin-right: 18px !important;
        }

        .mynew-panel-head {
            font-size: 14px !important;
            font-weight: 600;
            background: #2d2d2d;
            color: #ffc511 !important;
            text-align: center !important;
        }

        .modal.fade.in {
            background: rgba(0, 0, 0, 0.51);
        }

        @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 11%;
            }

            .pad-rt0 {
                padding-right: 0;
            }

            .pad-lt0 {
                padding-left: 0;
            }
        }

        .modal-header {
            padding: 2px !important;
        }

        .myreq-col tr td {
            font-size: 12px;
            color: #2d2d2d;
            border: 1px solid #fff !important;
            text-align: left;
            background: #e0e0e0;
            padding: 1px 6px !important;
            font-weight: bold;
        }

        .myreq-col tr th {
            font-size: 12px;
            background-color: #ffe600;
        }

        .myreq-col tr td a {
            color: #337ab7;
            font-weight: bold;
        }
    </style>



</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_backNmswp" />
            </Triggers>
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                    <ProgressTemplate>
                        <div class="fgh">
                            <div class="hgf">
                                <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <cc1:MessageBox ID="MessageBox1" runat="server" />
                <div>
                    <div class="container">

                        <div class="row" id="SideDiv">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="panel panel-default">
                                    <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;" runat="server" id="BannerDiv">
                                        <div class="row">
                                            <div class="col-md-3 col-sm-4 col-xs-12 left-niveshban">
                                                <ul class="mylogo-ul list-inline " style="margin: 0; padding: 6px 0 9px 1px;">
                                                    <li>
                                                        <img src="/images/logo-img/govt_up.png" alt="Goverment" /></li>
                                                    <li></li>
                                                </ul>
                                            </div>
                                            <div class="col-md-6 col-sm-4 col-xs-12 text-center">
                                                <h2 id="chg_head">Nivesh Mitra</h2>
                                                <p><span style="font-size: 20px;">Single Window Portal</span> ,Govt. of Uttar Pradesh</p>
                                            </div>
                                            <div class="col-md-3 col-sm-4 col-xs-12 right-niveshban">
                                                <ul class="mylogo-ul list-inline" style="margin: 0; padding: 6px 0 9px 1px;">
                                                    <li>
                                                        <img src="/images/logo-img/logo_udhyog_bandu_b.jpg" alt="Goverment" /></li>
                                                </ul>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;" runat="server" id="Div1">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                                <h3 id="H1">Uttar Pradesh State Industrial Development Authority</h3>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="panel-heading col-md-12 font-bold" style="font-size: 14px !important; font-weight: 600;">
                                        <div class="col-md-6 col-sm-6 col-xs-6 text-left">उत्तर प्रदेश सरकार &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GOVERNMENT OF UTTAR PRADESH</div>
                                        <div class="col-md-6 col-sm-6 col-xs-6 text-right">
                                            <asp:Button runat="server" ID="btn_backNmswp" Text="⇦ Go Back" CssClass="pull-right btn btn-info" Style="background-color: #02486d; color: #fff; font-weight: 600;" OnClick="btn_backNmswp_Click" />
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="panel-heading font-bold text-center" style="font-size: 14px !important; font-weight: 600; background: #2d2d2d; color: #ffc511 !important;">
                                        <asp:Label runat="server" ID="lblFormName"></asp:Label>
                                        </span>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">

                                            <style>
                                                #sub_menu ul {
                                                    margin-left: 0 !important;
                                                }

                                                .myul-tabs > li .selected {
                                                    background: #c7b42a !important;
                                                }
                                            </style>

                                            <asp:Menu
                                                ID="sub_menu"
                                                Orientation="Vertical"
                                                OnMenuItemClick="Menu1_MenuItemClick"
                                                StaticMenuStyle-CssClass="nav nav-pills myul-tabs"
                                                StaticSelectedStyle-CssClass="active selected highlighted"
                                                runat="server" Style="margin-left: 0; font: x-small">

                                                <Items>
                                                    <asp:MenuItem Text="Applicant Detail" Value="0" />
                                                    <asp:MenuItem Text="View Notices" Value="2" />
                                                    <asp:MenuItem Text="Notice  Reply for Notice" Value="1" />
                                                </Items>

                                            </asp:Menu>
                                        </div>
                                        <div class="col-md-10" style="border-left: 1px solid #ccc;">
                                            <div id="divMessageError" class="MessagePennel" runat="server" style="display: none;">
                                                <label>
                                                    <span class="check-cross" runat="server">✖</span>
                                                    <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
                                                </label>
                                            </div>

                                            <asp:MultiView runat="server" ID="Allotment">
                                                <asp:View runat="server" ID="View1">
                                                    <asp:PlaceHolder ID="PH_AllotteeDetails" runat="server"></asp:PlaceHolder>
                                                </asp:View>

                                                <asp:View runat="server" ID="View_NoticeDetails">
                                                    <input type="button" value="Click Me" style="display: none;" id="btnModalGridchange" data-toggle="modal" data-target="#ModalGridchange">
                                                    <div class="row">
                                                        <div id="divreply" runat="server" visible="false">
                                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                <div class="form-group">
                                                                    <label class="col-md-4 col-sm-4 col-xs-6">
                                                                        Notice ID:
                                                                    </label>
                                                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                                                        <asp:TextBox ID="txtNoticeID" runat="server" CssClass=" date input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />
                                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                <div class="form-group">
                                                                    <label class="col-md-4 col-sm-4 col-xs-6">
                                                                        Service Request NO:
                                                                    </label>
                                                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                                                        <asp:TextBox ID="txtServiceRequestNO" runat="server" CssClass=" date input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />
                                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                <div class="form-group">
                                                                    <label class="col-md-4 col-sm-4 col-xs-6">
                                                                        Notice Type:
                                                                    </label>
                                                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                                                        <asp:TextBox ID="txtNoticeType" runat="server" CssClass=" date input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />
                                                            <div class="col-md-12 col-sm-12 col-xs-12" id="Divwe">
                                                                <asp:UpdatePanel ID="pnlFileUpload" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group">

                                                                            <div class="row">
                                                                                <label class="col-md-3 col-sm-12 text-right">
                                                                                    <span style="color: Red">*</span>
                                                                                    Notice Reply Document :
                                                                                </label>
                                                                                <div class="col-md-5 col-sm-12">
                                                                                    <span class="col-md-10">
                                                                                        <asp:FileUpload ID="FileUpload4" runat="server" /></span><span class="col-md-2">
                                                                                            <asp:LinkButton ID="imgdocuments" runat="server" OnClick="imgdocuments_Click" CommandName="Upload" Text='<i class="fa fa-upload"></i>' /></span>
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
                                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                <div class="form-group">
                                                                    <div class="panel-heading font-bold text-center">
                                                                        Application Description :
                                                                    </div>
                                                                    <div>
                                                                        <CKEditor:CKEditorControl ID="CKEditorControl_PlotCancelation" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 col-sm-12 col-xs-12 ">
                                                                    <asp:Button ID="btnPlotCancelation" CssClass="btn-sm btn-primary ey-bg pull-right" Style="margin-top: 3px; padding: 0px 10px;" Text="Save" runat="server" OnClick="BtnPlotCancelationInsert_Click" OnClientClick="return" />
                                                                </div>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />
                                                        </div>
                                                        <div id="divpendding" runat="server" visible="false" class="panel-heading font-bold text-center">
                                                            No Notice Pendding  :
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="panel">
                                                            <div id="NoticeDoc" class="row" runat="server" visible="false">
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
                                                    </div>
                                                </asp:View>

                                                <asp:View runat="server" ID="View_Notice">
                                                    <div class="panel-heading font-bold text-center">
                                                        Privious Notice Details :
                                                    </div>
                                                    <asp:GridView ID="gvNotice" runat="server"
                                                        CssClass="table table-striped table-bordered table-hover request-table request-table"
                                                        OnRowCommand="gvNotice_RowCommand"
                                                        AllowSorting="True"
                                                        AutoGenerateColumns="False"
                                                        DataKeyNames="ServiceRequestNO,NoticeID"
                                                        GridLines="Horizontal"
                                                        Width="100%" OnRowDataBound="gvNotice_RowDataBound">
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
                                                            <asp:BoundField DataField="NoticeReplyDetails" HeaderText="Notice Reply Details" SortExpression="NoticeReplyDetails" />
                                                            <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblNoticeID" Text='<%#Eval("NoticeID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="CreatedOn" HeaderText="Created On" SortExpression="CreatedOn" />
                                                            <asp:TemplateField>
                                                                <HeaderStyle />
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="hlblimg" runat="server" Text="Notice Letter"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" usesubmitbehavior="true" Text='<i class="fa fa-download" aria-hidden="true"></i>' />/ 
                                                                        <asp:LinkButton ID="lbView1" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument" usesubmitbehavior="true" Text=''><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderStyle />
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="hlblimg" runat="server" Text="Applicant Document"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lblApplicantDoc" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocumentApplicant" usesubmitbehavior="true" Text='<i class="fa fa-download" aria-hidden="true"></i>' />/ 
                                                                        <asp:LinkButton ID="lbApplicantDocdownload" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocumentApplicant" usesubmitbehavior="true" Text=''><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>
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
                                                    <div class="panel-body">
                                                        <asp:Literal ID="ltviewer" runat="server" />
                                                    </div>
                                                </asp:View>

                                                <asp:View runat="server" ID="RejectView">
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-xs-12">

                                                            <div class="panel panel-default">
                                                                <div class="clearfix"></div>
                                                                <div class="panel-heading font-bold">
                                                                    <div class="col-md-8 col-sm-4 col-xs-12" style="margin-top: 6px; padding: 0px !important;">
                                                                        Letter View  <%--(<code style="color: #00bd00;font-weight: bold;">Total available records</code>)--%>
                                                                    </div>
                                                                    <div class="col-md-12 col-sm-12 col-xs-12">

                                                                        <asp:GridView ID="GridView1" runat="server"
                                                                            CssClass="table table-striped table-bordered table-hover request-table"
                                                                            AllowPaging="True"
                                                                            AutoGenerateColumns="False"
                                                                            DataKeyNames="ServiceRequestNO,Service"
                                                                            GridLines="Horizontal" PageSize="10"
                                                                            OnRowCommand="GridView3_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="ServiceRequestNo" HeaderText="ServiceRequestNo" SortExpression="ServiceRequestNo" />
                                                                                <asp:BoundField DataField="Name" HeaderText="Doc Name" SortExpression="Name" />
                                                                                <asp:TemplateField HeaderText="Action" ControlStyle-Width="30%">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lbView13" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" usesubmitbehavior="true" Text='Download' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                No Record Available
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="clearfix"></div>
                                                                </div>

                                                                <div class="panel-body">

                                                                    <asp:Literal ID="ltEmbed" runat="server" />
                                                                </div>
                                                            </div>

                                                        </div>

                                                    </div>

                                                </asp:View>

                                                <asp:View runat="server" ID="View3">

                                                    <asp:HiddenField ID="hfName" runat="server" />
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading font-bold">
                                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                <span style="color: Red" class="">Please upload all document before final submission</span>
                                                            </div>

                                                            <div class="clearfix"></div>
                                                        </div>
                                                        <div class="text-left">

                                                            <%-- <asp:Button runat="server" Visible="false" ID="btnSample" Text="" OnClick="GetServiceChecklists_SP_BY_Condtion_Function" />  --%>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                                            <ul class="nav nav-pills myul-tabs" style="margin-left: 0;">
                                                                <asp:Panel ID="pnlDemo" runat="server"></asp:Panel>
                                                            </ul>

                                                        </div>


                                                        <asp:GridView ID="GridView2" runat="server"
                                                            CssClass="table table-striped table-bordered table-hover request-table"
                                                            AutoGenerateColumns="False"
                                                            DataKeyNames="ServiceCheckListsID,DocumentID"
                                                            GridLines="Horizontal"
                                                            OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound"
                                                            Width="100%"
                                                            OnRowDeleting="GridView2_RowDeleting">
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
                                                                        <asp:Label runat="server" ID="lblServiceCheckLists" Text='<%#Eval("ServiceCheckListsID") %>'></asp:Label>
                                                                        <asp:Label runat="server" ID="DocumentID" Text='<%#Eval("DocumentID") %>'></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" ID="lblServiceTimeLines" Text='<%#Eval("ServiceTimeLinesID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="ServiceTimeLinesCondition" HeaderText="Checklist" SortExpression="ServiceTimeLinesCondition" />
                                                                <asp:BoundField DataField="ServiceTimeLinesDocuments" HeaderText="Checklist Description" SortExpression="ServiceTimeLinesDocuments" />
                                                                <asp:TemplateField HeaderText="Action">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle />
                                                                    <ItemTemplate>
                                                                        <span class="col-md-10">
                                                                            <asp:FileUpload ID="FileUpload4" runat="server" /></span><span class="col-md-2"><asp:LinkButton ID="imgdocuments" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="Upload" Text='<i class="fa fa-upload"></i>' /></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="8%">
                                                                    <HeaderStyle />
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="hlblimg" runat="server" Text=""></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" usesubmitbehavior="true" Text=''><i class="fa fa-download" aria-hidden="true"></i></asp:LinkButton>
                                                                        / 
                                                                <asp:LinkButton ID="lbView1" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument" OnClientClick="return NewWindow();" usesubmitbehavior="true" Text=''><i class="fa fa-file-pdf-o" aria-hidden="true"></i></asp:LinkButton>
                                                                        /
                                                                  <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="Delete" usesubmitbehavior="true" Text='<i class="fa fa-times" aria-hidden="true"></i>' />

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
                                                        <asp:Label ID="DocDisable" runat="server" Visible="false"></asp:Label>
                                                        <div class="text-center">
                                                        </div>
                                                    </div>




                                                </asp:View>

                                            </asp:MultiView>
                                        </div>
                                    </div>
                                    <asp:Label ID="lblAllotteeID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblAllotmentLetterNo" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblRegionalOffice" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblIndustrialArea" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblindustrialid" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblplotno" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblAllotteeName" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblFirmCompanyName" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblAddress" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblSignatoryMobile" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblSIgnatoryEmail" runat="server" Visible="false"></asp:Label>

                                    <asp:Label ID="lblapplicationname" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

    <script>


        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

        });



        function Redirect(parameter) {

            window.location.href = 'LandAllottmentApplication.aspx?ServiceReqNo=' + parameter;

        }

        function showError() {
            if (document.getElementById("<%= divMessageError.ClientID %>").style.display == 'none') {
                document.getElementById("<%= divMessageError.ClientID %>").style.display = 'block';

            }

        }
        function hideError() {
            if (document.getElementById("<%= divMessageError.ClientID %>").style.display == 'block') {
                document.getElementById("<%= divMessageError.ClientID %>").style.display = 'none';
            }
            return false;
        }




        function isDecimalKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {


            }
        }





        function ValidateRequired(obj, txt) {
            var txtObj = document.getElementById(obj.id);
            if (txtObj.value.length > 0) {
                txtObj.style.borderColor = "";
                hideError();
                return true;
            }
            else {
                txtObj.style.borderColor = "Red";
                txtObj.focus();
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = txt + " " + "Is required Field";

                return false;
            }

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

            Popup($('#Payment_Div').html());
        }


        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=1000');
            mywindow.document.write('<html><head><title style="font-weight:bold;">Land Allotment Application</title>');
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
    <script language="javascript" type="text/javascript">
        $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
            $(this).blur();
            $(this).datepicker('hide');
        });


        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });;

        });
    </script>

</body>
</html>






