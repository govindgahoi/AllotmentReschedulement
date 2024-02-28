﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_LidaDocument_Report_VG.ascx.cs" Inherits="Allotment.UC_LidaDocument_Report_VG" %>
<%--<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Document_Report_VG.ascx.cs" Inherits="Allotment.UC_Document_Report_VG" %>--%>


	<asp:PlaceHolder runat="server" ID="Placeholder" />       
			
<BR />

<div class="clearfix"></div>

<div runat="server" class="row" style="border: 1px solid #c5c506;background: #e4e4e4; margin: 6px 0 0 0px; padding: 2px 0;">
    <div class="col-md-4 col-sm-4 col-xs-4">
        <asp:CheckBox ID="chkmail" Text="Send Mail to Applicant" runat="server" /> 
    </div>
    <div class="col-md-8 col-sm-8 col-xs-8">
        <asp:Button ID="btnSave_Genrate" OnClick="btnSave_Genrate_Click" CssClass="btn btn-sm btn-primary text-right btn-bpservice pull-right" Style="margin-top:0;"  runat="server" Text="Generate Letter" />
    <asp:Button ID="btn_Sign" OnClick="btn_Sign_Click" CssClass="btn btn-sm btn-primary text-right btn-bpservice pull-right" Style="margin-top:0;"  runat="server" Text="Upload Signed Letter" Visible="false" />
        </div>

</div>
<style>
    object {
        width: 100% !important;
    }
</style>
<script>
function ShowLumpSum() {

        $(".levy_lumpsum").show();
        $(".levy_installment").hide();
    }
    function ShowInstallment() {

        $(".levy_lumpsum").hide();
        $(".levy_installment").show();
    }
    </script>