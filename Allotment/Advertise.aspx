<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="Advertise.aspx.cs" Inherits="Allotment.Advertise" %>

<%@ Register Src="~/UC_topbutton.ascx" TagPrefix="uc1" TagName="UC_topbutton" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn-advertise {
                width: 132px;
                margin-top: 5px;
                padding: 0px 0;
                font-size: 20px;
                background: #a5a5a5;
        }
        .content {
            min-height:650px;
        }
        .div-listleft {
            border:1px solid #ccc;
            min-height: 65vh;
        }
        @media only screen and (min-width: 960px) {
            .pad-left0 {
                padding-left:2px;
            }
            .pad-right0 {
                padding-right:2px;
            }
        }
        .div-view.div-scroll {
                overflow-y: scroll;
                max-height: 390px;
                margin: 0px 24px;
                border: 1px solid #ccc;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    


	<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
   <ContentTemplate>
          <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                    <ProgressTemplate>
                        <div class="fgh">
                            <div class="hgf text-center">
                              <span style="font-size:25px;font-weight:bold;">Please Wait...</span><br /> <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                                
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
<%--<uc1:UC_topbutton runat="server" ID="UC_topbutton" />--%>
        <cc1:MessageBox ID="MessageBox1" runat="server" />
            <cc1:ConfirmBox ID="ConfirmBox1" runat="server" />
<div class="clearfix"></div>
<div class="">
    <div class="col-md-12 col-sm-12 col-xs-12" style="padding:0;" >
        <div class="panel panel-default">
                    <div class="table-responsive" style="margin-top:3px;margin-bottom:3px;">
                        <table id="tblsearch" class="table table-striped table-bordered table-hover  margin-b-2px request-table">
                            <tr style="background: #ececec;">
                                <td class="font-bold">
                                    <span style="color: Red">*</span>
                                    Regional Office :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddloffice" runat="server"  OnSelectedIndexChanged="Regional_Changed" AutoPostBack="true"  CssClass="btn btn-sm btn-default dropdown-toggle similar-select">
                                    </asp:DropDownList>
                                </td>
                                <td class="font-bold">
                                    <span style="color: Red">*</span>
                                    Industrial Area Name :
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpdwnIA" runat="server"  CssClass="btn btn-sm btn-default dropdown-toggle similar-select" AutoPostBack="true" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged"></asp:DropDownList>                                    
                                </td>
                            </tr>
                            <tr style="display:none;">
                                <td colspan="3">
                                    <span></span>
                                </td>

                                <td>
                                   <asp:Button CssClass="btn btn-sm btn-primary pull-right"  Text="New Registration" ID="New_Allottee_Registration_btn" runat="server" />
                                   <asp:Button CssClass="btn btn-sm btn-primary pull-right"  style="margin-right:2px;" Text="Allottee History Registration" ID ="History_Allottee_Entry_btn" runat="server" />
                                </td>

                            </tr>
                        </table>
                     </div>
                 <div class="row">
                    <div class="col-md-1 col-sm-12 col-xs-12"></div>
                    <div class="col-md-10 col-sm-12 col-xs-12" style="background: #ccc;padding: 10px 10px;">
                        <div class="row" style="background: #fff;border: 1px solid #ccc;">
                            <div class="col-md-4 col-sm-4 col-xs-12 pad-right0 pad-left0">                        
                                <div class="div-listleft">
                                    <div class="panel-heading font-bold">Plots Available for Allotment<span><asp:Button ID="Button5" runat="server" Text="Clear" CssClass="rounded-0 btn btn-primary" style="padding:2px 15px;margin-top: 5px;margin-left:100px;" OnClick="Button5_Click" /></span></div>
                                    <asp:ListBox ID="ListParent" runat="server" Width="100%" SelectionMode ="Single" style="min-height:66vh;" AutoPostBack="true" OnSelectedIndexChanged="ListParent_SelectedIndexChanged"></asp:ListBox>
                                </div>
                            </div>
                    
                            <div class="col-md-4 col-sm-4 col-xs-12 pad-right0 pad-left0">
                                <div class="div-listleft" style="    background: #f3f3f3;">
                                    <div class="panel-heading font-bold">Advertise</div>
                                    <div style="border: 1px solid #ccc;margin: 5px 5px;padding: 5px 0 13px 0;min-height: 160px;background: #fff;">
                                        <div class="panel-heading">Tracing</div>
                                        <div class="" >
                                           
                                            <div class="col-md-12 col-sm-12 col-xs-12" style="margin-right:-25px;">
                                                 <asp:FileUpload ID="fileupload1" runat="server" CssClass="form-control form-control-sm"/>
                                            </div>
                                            <div class="col-md-12 col-sm-12 col-xs-12 text-right" style="margin-right:-20px;" >
                                                <asp:Button ID="btnupload" runat="server" Text="Upload" CssClass="rounded-0 btn btn-primary" style="padding:2px 15px;margin-top: 5px;" OnClick="btnupload_Click"/> <asp:Button ID="Button1" runat="server" Text="View" CssClass="rounded-0 btn btn-primary" style="padding:2px 15px;margin-top: 5px;" OnClick="Button1_Click"/>
                                                
                                            </div>
                                        </div>
                                        
                                        <div class="clearfix"></div>
                                    </div>
                                    
                                    <div style="border: 1px solid #ccc;margin: 5px 5px;padding: 5px 0 13px 0;min-height: 160px;background: #fff;">

                                        <div class="panel-heading">Joint Certificate</div>


                                        <div class="" >
                                           
                                            <div class="col-md-12 col-sm-12 col-xs-12" style="margin-right:-25px;">
                                                 <asp:FileUpload ID="fileupload2" runat="server" CssClass="form-control form-control-sm"/>
                                            </div>
                                            <div class="col-md-12 col-sm-12 col-xs-12 text-right" style="margin-right:-20px;" >
                                                <asp:Button ID="Button2" runat="server" Text="Upload" CssClass="rounded-0 btn btn-primary" style="padding:2px 15px;margin-top: 5px;" OnClick="Button2_Click"/> <asp:Button ID="Button3" runat="server" Text="View" CssClass="rounded-0 btn btn-primary" style="padding:2px 15px;margin-top: 5px;" OnClick="Button3_Click"/>
                                                
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div style="border: 1px solid #ccc;margin: 5px 5px;padding: 5px 0 13px 0;">
                                        <div class="form-group">
                                            <!--<label class="col-md-12 text-center">Advertisement Date</label>
                                            <div class="col-md-12 text-center" style="margin-bottom:20px;">
                                                <asp:TextBox ID="txtAdvertisementdate" CssClass="input-sm similar-select date" Width="100%" runat="server"></asp:TextBox>
                                                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                                            </div>-->
                                            <div class="col-md-12 text-center" style="">
                                                <asp:Button CssClass="btn btn-sm btn-primary btn-advertise"  style="margin-right:2px;" Text=">" ID ="btnSingleForward" runat="server" OnClick="btnSingleForward_Click" /><br />
                                                <asp:Button CssClass="btn btn-sm btn-primary btn-advertise"  Visible="false"  style="margin-right:2px;" Text=">>" ID ="btnDoubleForward" runat="server" OnClick="btnDoubleForward_Click" /><br />
                                                <asp:Button CssClass="btn btn-sm btn-primary btn-advertise"  Visible="false" style="margin-right:2px;" Text="<<" ID ="btnDoubleBack" runat="server" OnClick="btnDoubleBack_Click" /><br />
                                                <asp:Button CssClass="btn btn-sm btn-primary btn-advertise"  style="margin-right:2px;" Text="<" ID ="btnSingleBack" runat="server" OnClick="btnSingleBack_Click" /><br />
                                            </div>
                                           
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                    
                            <div class="col-md-4 col-sm-4 col-xs-12 pad-left0 pad-right0">                        
                                <div class="div-listleft">
                                    <div class="panel-heading font-bold">Plots Selected for Advertisement</div>
                                        <asp:ListBox ID="ListSelected" runat="server" Width="100%" SelectionMode ="Multiple" style="min-height:66vh;"></asp:ListBox>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                            
                    </div>
                     <div class="col-md-1 col-sm-12 col-xs-12"></div>
                     <div class="clearfix"></div>
                     <div class="col-md-1 col-sm-12 col-xs-12"></div>
                     <div class="col-md-10 col-sm-12 col-xs-12">
                         <asp:Button CssClass="btn btn-sm btn-primary pull-right"  style="margin-right:2px;margin-top:10px;" Text="Publish" ID ="btnpublish" runat="server" OnClick="btnpublish_Click" Enabled="false" />
                         <asp:Button CssClass="btn btn-sm btn-primary pull-right"  style="margin-right:2px;margin-top:10px;" Text="Generate OTP" ID ="btnGenerateOTP" runat="server" OnClick="btnGenerateOTP_Click"  />
                     </div>
                      <div runat="server" id="divOTP" visible="false">
                         <label class="col-md-2 col-sm-6 col-xs-6 text-right">Enter OTP : </label>
                     <div class="col-md-2 col-sm-12 col-xs-12"><asp:TextBox runat="server" ID="txtOTP" CssClass="margin-left-z input-sm similar-select1"></asp:TextBox></div>
                          <div class="col-md-2 col-sm-12 col-xs-12"><asp:Button runat="server" ID="btnVerifyOtp" CssClass="btn btn-sm btn-primary" Text="Verify OTP" OnClick="btnVerifyOtp_Click" /></div>
                          <div class="col-md-2 col-sm-12 col-xs-12"><asp:Button runat="server" ID="btnResend" CssClass="btn btn-sm btn-primary" Text="Resend" OnClick="btnResend_Click" visible="false" /></div>
                         </div>
                </div>
        </div>
    </div>
</div>
            
       	   </ContentTemplate>
		 </asp:UpdatePanel>
</asp:Content>
