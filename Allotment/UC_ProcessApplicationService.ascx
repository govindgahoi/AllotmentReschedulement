<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProcessApplicationService.ascx.cs" Inherits="Allotment.UC_ProcessApplicationService" %>
<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>



<style>
    #comments-recommendation .modal-header{
        padding: 0px 12px;
        background: #e4e4e4;
        border-bottom: 1px solid #ccc;
    }
    #comments-recommendation .modal-footer {
        padding: 0;
    }
    @media only screen and (min-width: 768px) {
       #comments-recommendation .modal-dialog {
            width: 52%;
        }        
    }
    #comments-recommendation .modal-body {
        min-height: 260px;
        padding: 2px 5px !important;
        /* margin: 2px 10px; */
        border: 4px solid #ccc;
    }
    #process-request .modal-header{
        padding: 0px 12px;
        background: #e4e4e4;
        border-bottom: 1px solid #ccc;
    }
    #process-request .modal-footer {
        padding: 0;
    }
    @media only screen and (min-width: 768px) {
       #process-request .modal-dialog {
            width: 52%;
        }        
    }
    #process-request .modal-body {
        min-height: 260px;
        padding: 2px 5px !important;
        /* margin: 2px 10px; */
    }
    
</style>


<script type="text/javascript">


     
        function MessageAndRedirect() {
            alert('Application Transfer');
         //  window.location.href = 'AllotmentRequest.aspx';

        }

   </script>


	   <cc1:MessageBox ID="MessageBox1" runat="server" />

 <table class="request-table" style="border: 2px solid #adadad;width: 100%;" id="UploadTB" runat="server" visible="false">
                        <tr>
                            <td style="width: 25%;">GMDIC Letter:</td>
                            <td><asp:FileUpload ID="fileupload" Width="97%" CssClass="form-control" runat="server" /></td>
                            <td><asp:Button ID="btnGMIDC" runat="server" CssClass="btn btn-primary ey-bg btn-sm" style="margin:0 1px 0 0;width:65px;" Text="Upload" OnClick="btnUpload_Click" /></td>
                            <td><asp:LinkButton runat="server" aria-hidden="true" ID="btn" CssClass="fa fa-eye" OnClick="btnInspectionReport_Click" /></td>
                            </tr>
                    </table>
	
             <div class="form-group">
                    <label class="col-md-2 col-sm-6 col-xs-6">
                        Recommendation: 
                    </label>
                    <div class="col-md-10 col-sm-6 col-xs-6">
                        <asp:DropDownList ID="drpRecommendation" runat="server" CssClass="input-sm similar-select1 margin-left-z">
                         
                        </asp:DropDownList>
                        
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <label class="col-md-2 col-sm-6 col-xs-6">
                        Send to: 
                    </label>
                    <div class="col-md-10 col-sm-6 col-xs-6">
                        <asp:DropDownList ID="drpSendto" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:DropDownList>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">                  
                    <label class="col-md-2 col-sm-6 col-xs-6">
                        Comment:
                    </label>
                    <div class="col-md-10 col-sm-6 col-xs-6">
                        <asp:TextBox ID="txtComment" runat="server" Rows="10" TextMode="MultiLine" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>                     
                    </div>
                </div>
<div class="clearfix"></div>
    <hr class="myhrline" />
<div class="form-group">
                                                       
                                                                <label class="col-md-2 text-right">
                                                                   Copy of Letter
                                                                </label>
                                                                <div class="col-md-6">
                                                                    <asp:FileUpload ID="fileupload2" runat="server" CssClass="form-control form-control-sm" ToolTip="Upload" accept=".pdf" />                                                        
                                                                </div>
                                                 <div class="col-md-4">
                                                                  <asp:Button ID="btnLetterUpload" runat="server" Text="Upload" CssClass="rounded-0 btn btn-primary" style="padding:2px 15px;margin-top: 5px;" OnClick="btnLetterUpload_Click"/> 
                                                                    <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                                                                 </div>
                                                      
                                                            </div>
                <div class="clearfix"></div>
                 <span class="pull-right"><asp:Button runat="server" Text="Send" id="btnSend"  OnClientClick="javascript:return confirm('Please Check the data before transferring application');" class="btn-primary btn-sm margin-left-z" style="margin: 7px 10px;" OnClick="btnSend_Click"/></span>
