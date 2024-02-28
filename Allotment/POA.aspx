<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="POA.aspx.cs" Inherits="Allotment.POA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/themes/start/jquery-ui.css" />
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/jquery-ui.min.js"></script>

    <style>
        .box-panel {
            -webkit-box-shadow: 0 1px 1px transparent;
            box-shadow: 0 1px 1px transparent;
        }

        .box-back-none {
            background: none !important;
            box-shadow: inset 0px 1px 1px transparent !important;
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
        $("#dialog").dialog({
            autoOpen: false,
            modal: true,
            height: 600,
            width: 600,
            title: "Zoomed Image"
        });
        $("[id*=gridPOA] img").click(function () {
            $('#dialog').html('');
            $('#dialog').append($(this).clone());
            $('#dialog').dialog('open');
        });
    });
</script>
    <script type="text/javascript">
         function ValidateIndividualEmail() {
            var email = document.getElementById("<%= txtPOAemailID.ClientID %>").value;
            if (email.length > 0) {
                if (!IsValidEmail(email)) {

                    ShowPopup("<img src='/images/alert.jpg' width='38' height='38'> &nbsp;&nbsp;<span style='font-family:serif !important'>Invalid Email Id</span>");
                    document.getElementById("<%= txtPOAemailID.ClientID %>").value = "";
                        document.getElementById("<%= txtPOAemailID.ClientID %>").style.borderColor = '#e52213';

                        return false;

                    }
                    else {

                        document.getElementById("<%= txtPOAemailID.ClientID %>").style.borderColor = "";
                        return true;
                    }
                }
            }
   <%-- function ValidateEmail() {
            var email = document.getElementById("<%= txtPOAemailID.ClientID %>").value;
            if (email.length > 0) {
                if (!IsValidEmail(email)) {

                    // ShowPopup("<img src='/images/alert.jpg' width='38' height='38'> &nbsp;&nbsp;<span style='font-family:serif !important'>Invalid Email Id</span>");
                    ShowMsgBox('Error', 'Invalid Email Id');
                    document.getElementById("<%= txtPOAemailID.ClientID %>").value = "";
                    document.getElementById("<%= txtPOAemailID.ClientID %>").style.borderColor = '#e52213';

                    return false;

                }
                else {

                    document.getElementById("<%= txtPOAemailID.ClientID %>").style.borderColor = "";
                    return true;
                }
            }
        }--%>
        </script>
    
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>



    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">



        <ContentTemplate>
            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                <ProgressTemplate>
                    <div class="fgh">
                        <div class="hgf">
                            <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                        </div>
                    </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>



            <cc1:MessageBox ID="MessageBox1" runat="server" />
            <cc1:ConfirmBox ID="ConfirmBox1" runat="server" />


            <div class="row">
                <div class="col-md-12" style="background: #dbdbdb;">
                    <div>
                        <div style="width: 100px; float: left; background: #dbdbdb; font-size: 11px;" class="text-center">
                            <br />
                            <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                                <li class="disabled">
                                    <a runat="server" onserverclick="Home_ServerClick">
                                        <i class="fa fa-home" aria-hidden="true"></i>
                                        <br />
                                        Home
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div style="float: left; background: #dbdbdb; border-left: 1px solid #000; font-size: 11px;" class="text-center">
                            Operate<br />
                            <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                                <li>
                                    <a runat="server" id="SaveEntry" onserverclick="SaveEntry_ServerClick">
                                        <i class="fa fa-floppy-o " aria-hidden="true"></i>
                                        <br />
                                        Save
                                    </a>
                                </li>
                                <li>
                                    <a runat="server" onserverclick="Unnamed_ServerClick">
                                        <i class="fa fa-refresh" aria-hidden="true"></i>
                                        <br />
                                        Refresh
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div style="float: left; background: #dbdbdb; border-left: 1px solid #000; border-right: 1px solid #000; font-size: 11px;" class="text-center">
                            User Registration<br />
                            <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                                <li>
                                    <a runat="server" onserverclick="Unnamed_ServerClick">
                                        <i class="fa fa-plus" aria-hidden="true"></i>
                                        <br />
                                        New
                                    </a>
                                </li>
                               

                            </ul>
                        </div>
                       

                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="row">
                    <asp:Label ID="RateIdlbl" runat="server" Visible="false"></asp:Label>
                    <div class="panel">
                        <asp:Panel ID="PanelContainer" runat="server">
                        <div class="">
                            <div class="col-md-12">
                                <div class="panel-heading font-bold" style="text-align: center;">
                                    Power Of Attorney                          
                                </div>
                                <div class="panel-body">

                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                POA Region :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:DropDownList ID="ddlregion" runat="server"  CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" OnSelectedIndexChanged="ddlregion_SelectedIndexChanged" AutoPostBack="true"  ></asp:DropDownList> 
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group" runat="server" id="passworddiv">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                POA Industrial Area :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                              <asp:DropDownList ID="ddlIA" runat="server"  CssClass="similar-select1 margin-left-z dropdown-toggle input-sm"  ></asp:DropDownList> 
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                POA Name :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                 <asp:TextBox ID="txtPOAName" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Email ID:
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtPOAemailID" runat="server" CssClass="input-sm similar-select1" onblur="return ValidateIndividualEmail(); "></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Mobile :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtPOAmobile" runat="server" MaxLength="10" CssClass="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <asp:UpdatePanel ID="pnlFileUpload" runat="server">
                                             <ContentTemplate>
                                    <div class="form-group">
                                        
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                               POA Photo :
                                            </label>
                                            <div class="col-md-9 col-sm-12">  
                                                  <span class="col-md-10"><asp:FileUpload ID="POAPhotoUpload" runat="server" /></span><span class="col-md-2"><asp:LinkButton ID="imgdocuments" runat="server" OnClick="imgdocuments_Click" CommandName="Upload" Text='<i class="fa fa-upload"></i>' /></span>                                         
                                                <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>

                                                 <%--<asp:FileUpload ID="POAPhotoUpload" runat="server"  CssClass="input-sm similar-select" ToolTip="Upload"></asp:FileUpload>--%>
                                            </div>
                                        </div>
                                    </div>
                                                  </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="imgdocuments" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                             <ContentTemplate>
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                               POA Sign:
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                  <span class="col-md-10"><asp:FileUpload ID="POASignupload" runat="server" /></span><span class="col-md-2"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CommandName="Upload" Text='<i class="fa fa-upload"></i>' /></span> 
                                                   <asp:Label ID="lbluploadingMsgs" runat="server" Visible="false"></asp:Label>
                                               <%--<asp:FileUpload ID="FileUpload2" runat="server"  CssClass="input-sm similar-select"  ToolTip="Upload"></asp:FileUpload>--%>
                                            </div>
                                        </div>
                                    </div>
                                     </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="LinkButton1" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:Label ID="lblStatus1" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />                        
                                    <div class="form-group" style="display:none" >
                                        <div class="col-md-12 col-sm-12" style="text-align: right; padding: 10px 0;">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" OnClick="btnSubmit_Click"/>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <asp:Label ID="msg" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
</asp:Panel>
                    </div>
                </div>

                <div class="row">
                    <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-6 font-bold" style="margin-top: 12px;">
                                    Existing POA Record
                                </div>
                                <div class="input-group col-md-4 col-sm-12" style="float: right; padding: 2px;">
                                    <asp:TextBox ID="txtSearch" Width="100%" CssClass="input-sm" runat="server" OnTextChanged="txtSearch_TextChanged"  AutoPostBack="true"/>
                                    <span class="input-group-btn">
                                        <button class="btn btn-sm btn-primary" type="button"><i class="fa fa-search" style="color: #fff;"></i></button>
                                    </span>
                                </div>
                                <div class="clearfix"></div>

                            </div>
                            <div class="panel-body gallery  table-responsive">
                                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="gridPOA" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="3" CssClass="table table-striped table-bordered table-hover request-table" 
                                  OnRowDataBound="gridPOA_RowDataBound" OnPageIndexChanging="gridPOA_PageIndexChanging" OnRowCommand="gridPOA_RowCommand"    PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right">
                                    <Columns>


                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField DataField="POARegion" HeaderText="POA Region" SortExpression="POARegion" />
                                         <asp:BoundField DataField="IAName" HeaderText="POA Industrial Area" SortExpression="IAName" />
                                        <asp:BoundField DataField="POAName" HeaderText="POA Name" SortExpression="POAName" />
                                        <asp:BoundField DataField="POAEmailID" HeaderText="Email" SortExpression="POAEmailID" />
                                        <asp:BoundField DataField="POAMobileNo" HeaderText="Mobile" SortExpression="POAMobileNo" />
                                        <asp:TemplateField HeaderText="POA Photo">
            <ItemTemplate>
                <asp:Image ID="POAPhoto" height="100px" Width="80px"  runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="POA Sign" >
            <ItemTemplate>
                <asp:Image ID="POASign" height="100px" Width="80px"  runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                                       
                                         <%--<asp:TemplateField HeaderText="POAPhoto">
                      <ItemTemplate >
                        <asp:Image ID="Image1" runat="server" ImageUrl ='<%# Eval("POAPhoto") %>' height="120px" Width="150px" />
                      </ItemTemplate>
                    </asp:TemplateField>--%>
                                 <%--        <asp:TemplateField HeaderText="POA Sign">
                      <ItemTemplate >
                        <asp:Image ID="Image1" runat="server" ImageUrl ='<%# Eval("POASign") %>' height="120px" Width="150px" />
                      </ItemTemplate>
                    </asp:TemplateField>--%>
                                          <%--<asp:ImageField DataImageUrlField="POAPhoto" HeaderText="POA Photo" SortExpression="POAPhoto"></asp:ImageField>--%> 
                                        <%--<asp:im DataField="POAPhoto" HeaderText="POA Photo" SortExpression="POAPhoto" />--%>
                                        <%--<asp:ImageField DataImageUrlField="POASign" HeaderText="POA Sign" SortExpression="POASign"></asp:ImageField>--%>
                                        <%--<asp:BoundField DataField="POASign" HeaderText="POA Sign" SortExpression="POASign" />--%>
                                        


                                        <asp:TemplateField HeaderText="Update">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>


                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Process" CommandArgument='<%#Eval("ID") %>' ToolTip="Click here For POA " />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Delete">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="Delete" CommandArgument='<%#Eval("ID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" ToolTip="Click here to delete Rate" />
                                                </span>  
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                 <div id="dialog" style="display: none">
                            </div>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>





</asp:Content>
