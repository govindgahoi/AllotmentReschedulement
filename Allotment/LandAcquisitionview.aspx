<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="LandAcquisitionview.aspx.cs" Inherits="Allotment.LandAcquisitionview" %>
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
        $("#dialog2").dialog({
            autoOpen: false,
            modal: true,
            height: 600,
            width: 600,
            title: "Zoomed Image"
        });
        $("[id*=gridPOA] img").click(function () {
            $('#dialog2').html('');
            $('#dialog2').append($(this).clone());
            $('#dialog2').dialog('open');
        });
    });
</script>
    <%--<script type="text/javascript">
    function ValidateEmail() {
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
        }
        </script>--%>
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



<%--    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">



        <ContentTemplate>
            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                <ProgressTemplate>
                    <div class="fgh">
                        <div class="hgf">
                            <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>



            <cc1:MessageBox ID="MessageBox1" runat="server" />
            <cc1:ConfirmBox ID="ConfirmBox1" runat="server" />


            <div class="row">
                <div class="col-md-12" style="background: #dbdbdb;">
                    <div>
                       <%-- <div style="width: 100px; float: left; background: #dbdbdb; font-size: 11px;" class="text-center">
                            <br />
                <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                                <li class="disabled">
                                    <a runat="server" >
                                        <i class="fa fa-home" aria-hidden="true"></i>
                                        <br />
                                        Home
                                    </a>
                                </li>
                            </ul>
                        </div>--%>
                      <%--<div style="float: left; background: #dbdbdb; border-left: 1px solid #000; font-size: 11px;" class="text-center">
                            Operate<br />
                            <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">--%>
                               <%-- <li>
                                    <a runat="server" id="SaveEntry" >
                                        <i class="fa fa-floppy-o " aria-hidden="true"></i>
                                        <br />
                                        Save
                                    </a>
                                </li>--%>
                               <%-- <li>
                                    <a runat="server" >
                                        <i class="fa fa-refresh" aria-hidden="true"></i>
                                        <br />
                                        Refresh
                                    </a>
                                </li>--%>
                            <%--</ul>
                        </div>--%>
                        <%--<div style="float: left; background: #dbdbdb; border-left: 1px solid #000; border-right: 1px solid #000; font-size: 11px;" class="text-center">
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
                        </div>--%>
                       

                    </div>
                </div>
                <div class="clearfix"></div>
               <div class="row">
                    <asp:Label ID="RateIdlbl" runat="server" Visible="false"></asp:Label>
                    <div class="panel" id="mask" runat="server" >
                        <div class="">
                            <div class="col-md-12">
                                <div class="panel-heading font-bold" style="text-align: center;">
                                                              
                                </div>
                                <div class="panel-body">

                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Village Name :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtVillage" runat="server" Enabled="false" CssClass="similar-select1 input-sm"></asp:TextBox> 
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group" runat="server" id="passworddiv">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Khatedar Name :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                               <asp:TextBox ID="txtKhatedarName" runat="server" Enabled="false" CssClass="similar-select1 input-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />

                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Khata No:
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                               <asp:TextBox ID="txtKhataNo" runat="server" Enabled="false" CssClass="date input-sm similar-select1" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />

                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Address :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtAddress" runat="server" Enabled="false" CssClass="similar-select1 input-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                FatherHusbandName :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtFatherHusbandName" runat="server" Enabled="false" CssClass="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Gata No. :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtGataNo" runat="server" Enabled="false" CssClass="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                               Gata Area :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                 <asp:TextBox ID="txtGataArea" runat="server" Enabled="false"  CssClass="date input-sm similar-select1" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    

                                    <asp:Label ID="msg" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <div class="row">
                    <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-6 font-bold" style="margin-top: 12px;">
                                    Existing Land Acquisitions Records
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
                                <asp:GridView ID="gridLAP" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" CssClass="table table-striped table-bordered table-hover request-table" OnRowCommand="gridLAP_RowCommand" OnRowDataBound="gridLAP_RowDataBound"
                               OnPageIndexChanging="gridLAP_PageIndexChanging" PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right">
                                    <Columns>


                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>">
                                                   
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField DataField="TotalLand" HeaderText="Total Land(in Hect.)" SortExpression="TotalLand" />
                                           <asp:BoundField DataField="LandType" HeaderText="Land Type" SortExpression="LandType" />
                                         <asp:BoundField DataField="Census_District" HeaderText="District Name" SortExpression="Census_District" />
                                        <asp:BoundField DataField="NameOfLandOwner" HeaderText="Applicant Name" SortExpression="NameOfLandOwner" />
                                          <asp:BoundField DataField="MobileNo" HeaderText="Mobile No." SortExpression="MobileNo" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                        
                                       
                                        
                                         <%--<asp:BoundField DataField="Alllandowners" HeaderText="All landowners" SortExpression="Alllandowners" />--%>
                                         
                                        <asp:TemplateField HeaderText=" Location Map" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%#(Eval("LandAcquisitionID")) %>' CommandName="selectDocument"  Text='<i class="fa fa-download" aria-hidden="true"></i>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Upload Signed Consent latter" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbView1" runat="server" CommandArgument='<%#(Eval("LandAcquisitionID")) %>' CommandName="Document"  Text='<i class="fa fa-download" aria-hidden="true"></i>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View More">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>


                                               
                                              
                                                   <asp:HyperLink ID="lbhyper" runat="server" NavigateUrl='<%# Eval("LandAcquisitionID", "LandAcquisitionProposal.aspx?ID={0}") %>'
                   target="_blank"   CssClass="fa fa-eye" />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <%--<asp:TemplateField HeaderText="Delete">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="Delete" CommandArgument='<%#Eval("ID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" ToolTip="Click here to delete Rate" />
                                                </span>  
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                 <div id="dialog2" style="display: none">
                            </div>
                        </div>
                    </div>
                </div>
                                                         
      </div>
    </div>
      </div>
</div>
<!-- Central Modal Small -->
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>





</asp:Content>