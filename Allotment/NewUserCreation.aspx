<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="NewUserCreation.aspx.cs" Inherits="Allotment.NewUserCreation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


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
    function ValidateEmail() {
            var email = document.getElementById("<%= txtEmail.ClientID %>").value;
            if (email.length > 0) {
                if (!IsValidEmail(email)) {

                    // ShowPopup("<img src='/images/alert.jpg' width='38' height='38'> &nbsp;&nbsp;<span style='font-family:serif !important'>Invalid Email Id</span>");
                    ShowMsgBox('Error', 'Invalid Email Id');
                    document.getElementById("<%= txtEmail.ClientID %>").value = "";
                    document.getElementById("<%= txtEmail.ClientID %>").style.borderColor = '#e52213';

                    return false;

                }
                else {

                    document.getElementById("<%= txtEmail.ClientID %>").style.borderColor = "";
                    return true;
                }
            }
        }
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
                                    <a runat="server" onserverclick="Unnamed_ServerClick1">
                                        <i class="fa fa-plus" aria-hidden="true"></i>
                                        <br />
                                        New
                                    </a>
                                </li>
                               <%-- <li>
                                    <a runat="server" class="disable">
                                        <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                        <br />
                                        History
                                    </a>
                                </li>--%>

                            </ul>
                        </div>
                       <%-- <div style="float: left; background: #dbdbdb; font-size: 11px;" class="text-center">
                            Navigation<br />
                            <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                                <li>
                                    <a href="#" class="disable">
                                        <i class="fa fa-step-backward" aria-hidden="true"></i>
                                        <br />
                                        Last
                                    </a>
                                </li>
                                <li>
                                    <a runat="server" class="disable">
                                        <i class="fa fa-angle-double-left" aria-hidden="true"></i>
                                        <br />
                                        Previous
                                    </a>
                                </li>
                                <li>
                                    <a runat="server" id="sernext" class="disable">
                                        <i class="fa fa-angle-double-right" aria-hidden="true"></i>
                                        <br />
                                        Next
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="disable">
                                        <i class="fa fa-step-forward" aria-hidden="true"></i>
                                        <br />
                                        Final
                                    </a>
                                </li>


                            </ul>
                        </div>--%>

                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="row">
                    <asp:Label ID="RateIdlbl" runat="server" Visible="false"></asp:Label>
                    <div class="panel">
                        <div class="">
                            <div class="col-md-12">
                                <div class="panel-heading font-bold" style="text-align: center;">
                                    User Creation                          
                                </div>
                                <div class="panel-body">

                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                User Name :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtusername" runat="server"  CssClass="similar-select1 input-sm"></asp:TextBox> 
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group" runat="server" id="passworddiv">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Password :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                               <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="similar-select1 input-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Designation :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:DropDownList ID="ddlDesignation" runat="server"  CssClass="similar-select1 margin-left-z dropdown-toggle input-sm"  ></asp:DropDownList> 
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Qualification :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtQualification" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Employee Code :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtEmpcode" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                               Joining Date :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                 <asp:TextBox ID="txtJoiningDate" runat="server" placeholder="dd/mm/yyyy" CssClass="date input-sm similar-select1" ToolTip="Enter Date In dd/mm/yyyy Format"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Retirement Date :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                               <asp:TextBox ID="txtRetirementDate" runat="server" placeholder="dd/mm/yyyy" CssClass="date input-sm similar-select1" ToolTip="Enter Date In dd/mm/yyyy Format"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />

                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Contract Type :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                               <asp:TextBox ID="txtContractType" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group ">
                                        <div class="row ">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Email ID:
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="input-sm similar-select1" onblur="ValidateEmail()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />



                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Phone Number :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                               <asp:TextBox ID="txtphoneNo" runat="server" MaxLength="10" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Employee Name :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                               <asp:TextBox ID="txtEmployee" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>                                                                        
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group" style="display: none;">
                                        <div class="col-md-12 col-sm-12" style="text-align: right; padding: 10px 0;">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" OnClick="btnSubmit_Click" />
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
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
                                    Existing Users Record
                                </div>
                                <div class="input-group col-md-4 col-sm-12" style="float: right; padding: 2px;">
                                    <asp:TextBox ID="txtSearch" Width="100%" CssClass="input-sm" runat="server" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"/>
                                    <span class="input-group-btn">
                                        <button class="btn btn-sm btn-primary" type="button"><i class="fa fa-search" style="color: #fff;"></i></button>
                                    </span>
                                </div>
                                <div class="clearfix"></div>

                            </div>
                            <div class="panel-body gallery  table-responsive">
                                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="gridUsercreationdetails" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="table table-striped table-bordered table-hover request-table" OnRowCommand="gridUsercreationdetails_RowCommand"
                                    OnPageIndexChanging="gridUsercreationdetails_PageIndexChanging" PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right">
                                    <Columns>


                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName" />
                                        <asp:BoundField DataField="DesignationName" HeaderText="Designation Name" SortExpression="DesignationName" />
                                        <asp:BoundField DataField="Qualification" HeaderText="Qualification" SortExpression="Qualification" />
                                        <asp:BoundField DataField="emailID" HeaderText="Email ID" SortExpression="emailID" />
                                        <asp:BoundField DataField="phoneNo" HeaderText="Phone Number" SortExpression="phoneNo" />
                                        


                                        <asp:TemplateField HeaderText="Update">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>


                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Process" CommandArgument='<%#Eval("UserID") %>' ToolTip="Click here For Update Rate " />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Delete">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="Delete" CommandArgument='<%#Eval("UserID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" ToolTip="Click here to delete Rate" />
                                                </span>  
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
        </ContentTemplate>
    </asp:UpdatePanel>





</asp:Content>
