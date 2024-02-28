<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="ApplyServiceRequest.aspx.cs" Inherits="Allotment.ApplyServiceRequest" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%--<%@ Register TagPrefix="CP"  TagName="UC_Service_Allotteee_Detail"   Src="~/UC_Service_Allotteee_Detail.ascx" %>


<%@ Register Src="~/UC_Service_Building_Plan.ascx" TagPrefix="CP" TagName="UC_Service_Building_Plan" %>--%>

<%@ Register assembly="ProudMonkey.Common.Controls" namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %> 


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .pad-left0 {
            padding-left:0;
        }
        @media only screen and (max-width: 992px) {
            .form-group label.text-right{
                text-align: left !important;
            }
        }
        label {
            margin-bottom:0;
        }
    </style>


<link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"  EnablePartialRendering="true" >
</asp:ScriptManager>



    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
       
   <ContentTemplate>
      <asp:UpdateProgress ID="UpdWaitImage" runat="server"  DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                 <ProgressTemplate>
                 <div class="fgh">
                 <div class="hgf">
                                <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>   
                               </div>
                               </div>
       </ProgressTemplate>
       </asp:UpdateProgress>





     <cc1:MessageBox ID="MessageBox1" runat="server" /> 



<%--    <CP:UC_Service_Allotteee_Detail id="asdf" Title="User Control Test" TextColor="green" Padding=10 runat="server" />--%>



                    <asp:Label ID="lblserRequest"   Visible ="false" runat="server" ></asp:Label>
                    <asp:Label ID="lblServiceRequestID" runat="server" Visible="false"></asp:Label>




        <div class="panel panel-default" style="border: 1px solid #e6e6e6;">
            <div class="panel-heading" style="font-size: 14px !important; font-weight: 600; background: #2d2d2d; color: #ffc511 !important;">
                Request For: <asp:Label ID="lbl_service_name" runat="server" />
                <span class="pull-right">Service No. :<asp:Label ID="lbl_service_no" runat="server" /></span></div>
            <div class="panel-heading font-bold">Apply on behalf of: <asp:Label ID="lbl_allottee" runat="server" /></div>
            <div class="form-group" style="background: #ececec; margin: 3px 0; padding: 3px 0;">
                <label class="col-md-2 col-sm-6 col-xs-6 font-bold text-right" style="margin-top: 4px;">
                    <span style="color: Red">*</span>
                    Regional Office :
                </label>
                <div class="col-md-2 col-sm-6 col-xs-6">
                    <asp:DropDownList ID="ddloffice" AutoPostBack="true" name="state" OnSelectedIndexChanged="Regional_Changed" runat="server" CssClass="dropdown_search dropdown-toggle similar-select1" Style="width: 180px; background: #ffffff;">
                    </asp:DropDownList>


                </div>
                <label class="col-md-2 col-sm-6 col-xs-6 font-bold text-right" style="margin-top: 4px;">
                    <span style="color: Red">*</span>
                    Industrial Area Name :
                </label>
                <div class="col-md-2 col-sm-6 col-xs-6">

                    <asp:DropDownList ID="drpdwnIA" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged" CssClass="dropdown_search dropdown-toggle similar-select1" Style="width: 180px; background: #ffffff;"></asp:DropDownList>

                </div>
                <label class="col-md-1 col-sm-6 col-xs-6 font-bold text-right" style="margin-top: 4px;">
                    Plot no# :
                </label>
                <div class="col-md-2 col-sm-6 col-xs-6">

                    <asp:DropDownList ID="ddlPlotNo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dddlPlotNo_SelectedIndexChanged" CssClass="dropdown_search dropdown-toggle similar-select1" Style="width: 180px; background: #ffffff;"></asp:DropDownList>

                </div>
                <div class="col-md-1 col-sm-4 col-xs-12">
                    <asp:Button CssClass="btn btn-sm btn-primary pull-right" Text="Fetch" runat="server" Style="width: 100%; padding: 2px 1px;" />
                </div>
                <div class="clearfix"></div>
            </div>
            <hr style="margin: 8px 0; border-top: 2px solid #dedddd;" />

           <asp:PlaceHolder runat="server"   ID="Placeholder1" ></asp:PlaceHolder>

     </div>




<%--                <div class="clearfix"></div>
                <hr class="separation" />
                <div class="form-group" runat="server" id="div_raiseservice" style="border:1px solid #d5d5d5;padding:3px 0;">
                    <div class="col-md-12 col-sm-12 col-xs-12 font-bold panel-heading">
                        Do you want to continue &nbsp;&nbsp; <asp:Button CssClass="btn btn-sm btn-primary" Text="Continue" style="padding: 2px 10px;" runat="server"/>
                    </div>


                    
    <div class="clearfix"></div>
    <div class="panel-heading font-bold">Application Nature </div>
    <div class="form-group">
        <label class="col-md-2">
            <span style="color: Red">*</span>Application Type
        </label>
        <div class="col-md-10">
            <asp:DropDownList ID="ddlApplication" runat="server" CssClass="btn btn-default dropdown-toggle input-sm similar-select1"></asp:DropDownList>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />
    <div class="form-group">
        <label class="col-md-2">
            <span style="color: Red">*</span>Case Type :
        </label>
        <div class="col-md-10">
            <asp:DropDownList ID="ddlCaseType" runat="server" CssClass="btn btn-default dropdown-toggle input-sm similar-select1"></asp:DropDownList>
            <asp:Label ID="lblArea" runat="server" Text="" Visible="false"></asp:Label>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />




 <asp:Button ID="btnSubmit" CssClass="btn btn-primary register " runat="server" OnClick="btnSubmit_Click" Text="Save" />


                    <div class="clearfix"></div>
                </div>
--%>






       </ContentTemplate>
        </asp:UpdatePanel>

    <script>
        $(document).ready(function () {
            $('.dropdown_search').select2();
        });
    </script>

</asp:Content>
