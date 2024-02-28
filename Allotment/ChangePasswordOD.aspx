<%@ Page Title="" Language="C#" MasterPageFile="~/MainUserOD.Master" AutoEventWireup="true" CodeBehind="ChangePasswordOD.aspx.cs" Inherits="Allotment.ChangePasswordOD" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: black;
        padding-top: 10px;
        padding-left: 10px;
        width: 300px;
        height: 140px;
    }
</style>
     <script  type="text/javascript">



         function ShowMessage() {
             alert('Your Password Is Changed Successfully. Please Login Again..');
             window.location.href = 'default.aspx';

         }


         var prm = Sys.WebForms.PageRequestManager.getInstance();
         prm.add_endRequest(function (sender, e) {
             $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });


             function ShowMessage() {
                 alert('Your Password Is Changed Successfully. Please Login Again..');
                 window.location.href = 'default.aspx';

             }


         });
  </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional"  >

    

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
      <cc1:ConfirmBox ID="ConfirmBox1" runat="server" /> 
  
     <div class="panel panel-default">
                                    <div class="panel-heading font-bold">Change Your Password</div>
                                    <div class="panel-body">
                                           <div class="form-group">
                                               <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                       Existing Password :
                                                    </label> 
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:TextBox ID="txtExistingPassword" runat="server" CssClass="input-sm similar-select1" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                             <hr class="myhrline" />
                                             <div class="form-group">
                                                 <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        New Password :
                                                    </label> 
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:TextBox ID="txtNewPassword" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                             <hr class="myhrline" />
                                             <div class="form-group">
                                                 <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        Confirm New Password :
                                                    </label> 
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                             <hr class="myhrline" />
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 text-center" style="padding-top:2px;margin-top:15px;">
                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit"  OnClick="btnSubmit_Click"/>  &nbsp;&nbsp;<asp:Button ID="btnReset" runat="server" CssClass="btn btn-sm btn-primary" Text="Reset" OnClick="btnReset_Click" />
                                                        </div>
                                                    </div>
                                            </div>
                                            <div class="clearfix"></div>
                                    </div>
                                </div>


      <%-- <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnReset"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" style = "display:none">
    This is an ASP.Net AJAX ModalPopupExtender Example<br />
    <asp:Button ID="btnClose" runat="server" Text="Close" />
</asp:Panel>--%>
    </ContentTemplate></asp:UpdatePanel>

    
</asp:Content>
