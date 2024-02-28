<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_TransferLAWCommentsEntry.ascx.cs" Inherits="Allotment.UC_TransferLAWCommentsEntry" %>
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
    $(document).ready(function () {
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
    });

    function PageLoaded(sender, args) {
        $(".chosen").chosen();
        $(".MultiSelect").chosen(
        );
    }

</script>


	   <cc1:MessageBox ID="MessageBox1" runat="server" />          
              
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
                                                                    <asp:FileUpload ID="fileupload1" runat="server" CssClass="form-control form-control-sm" ToolTip="Upload" accept=".pdf" />                                                        
                                                                </div>
                                                 <div class="col-md-4">
                                                                  <asp:Button ID="btnupload" runat="server" Text="Upload" CssClass="rounded-0 btn btn-primary" style="padding:2px 15px;margin-top: 5px;" OnClick="btnupload_Click"/> 
                                                                    <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                                                                 </div>
                                                      
                                                            </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                 <span class="pull-right"><asp:Button runat="server" Text="Submit" id="btnSend" class="btn-primary btn-sm margin-left-z" style="margin: 7px 10px;" OnClientClick="javascript:return confirm('Please check the data before submitting your comments');" OnClick="btnSend_Click"/></span>
