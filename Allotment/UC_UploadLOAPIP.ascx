<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_UploadLOAPIP.ascx.cs" Inherits="Allotment.UC_UploadLOAPIP" %>
<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>


<style>
    .Image{
        width:50px;
        height:50px;
    }
.grow { transition: all .3s ease-in-out; }
.grow:hover { transform: scale(3.0); }
    
              #ModalGridchange .modal-header {
                padding: 0px 12px;
                background: #e4e4e4;
                border-bottom: 1px solid #ccc;  
              }
              #ModalGridchange .modal-footer {
                padding:0;
              }
              #ModalGridchange button {
                margin-top:1px;
              }
              @media only screen and (min-width: 768px) {
                  #ModalGridchange .modal-dialog {
                      margin: 17% 56% !important;
                      width: 35% !important;
                  }
                  #ModalGridchange {
                    right:21%;
                    top:10%;
                  }
                  .modal-dialog
                  {
                      width: 389px !important;
                      margin-left: 55% !important;
                      margin-top: 22% !important;
                  }
              }
          @media only screen and (max-width: 768px) {
               .modal-dialog
                  {
                        width: 389px !important;
                        margin-left: 55% !important;
                        margin-top: 22% !important;
                  }
          
          }
  

    
</style>


<script type="text/javascript">


     
        function MessageAndRedirect() {
            alert('Application Transfer');
         //  window.location.href = 'AllotmentRequest.aspx';

        }
    
    function ShowPopupChange() {
            
                    $("#btnModalGridchange").click();
                }
   </script>


	   <cc1:MessageBox ID="MessageBox1" runat="server" />



    <div class="panel-heading text-center">Issue Letter</div>  

    <div class="form-group text-center" >
        <asp:Label ID="lblUid" runat="server"  Visible="true"></asp:Label>
    </div>
    
    
    <div class="form-group">
        <label class="col-md-2 col-sm-6 col-xs-6 text-right">Letter Type</label>
        <div class="col-md-10 col-sm-6 col-xs-6">
             <asp:DropDownList ID="ddlLetterType" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlLetterType_SelectedIndexChanged"  CssClass="margin-left-z input-sm similar-select1" >
                                                                                                 <asp:ListItem>--Select--</asp:ListItem>
                                                                                                   <asp:ListItem Value="2">Issue Rejection Letter</asp:ListItem>
                                                                                                    <asp:ListItem Value="3">Issue UID</asp:ListItem>
                                                                                                   
                                                                                             </asp:DropDownList>
        </div>
    </div>
    
    <div class="clearfix"></div>
    <hr class="myhrline" />
    <div class="form-group">
        <label class="col-md-2 col-sm-6 col-xs-6 text-right">Issue Date</label>
        <div class="col-md-10 col-sm-6 col-xs-6">
            <asp:TextBox runat="server" ID="txtLoaDate" CssClass="date similar-select1 input-sm"></asp:TextBox>
        </div>
    </div>
 
<div class="form-group" id="resontab" runat="server" visible="false" >
    <label class="col-md-3 col-sm-6 col-xs-6 text-right">Please Choose Reason Details</label>
    <div class="col-md-4 col-sm-6 col-xs-6">
        <asp:DropDownList ID="ddlreason" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlreason_SelectedIndexChanged" CssClass="margin-left-z input-sm similar-select1">
            <asp:ListItem Value="0000">--Select--</asp:ListItem>
            
             <asp:ListItem Value="2935">User no more Interested</asp:ListItem>
            <asp:ListItem Value="2936">Wrong Application submitted</asp:ListItem>
            <asp:ListItem Value="2937">Demo / Trial Form</asp:ListItem>
            <asp:ListItem Value="2938">Duplicate Form (License/NOC/Clearance Already Granted)</asp:ListItem>
            <asp:ListItem Value="2939">Not Feasible</asp:ListItem>
            <asp:ListItem Value="2940">Not Eligible as per Eligibility Criteria</asp:ListItem>
            <asp:ListItem Value="2941">Proper document not submitted</asp:ListItem>
            <asp:ListItem Value="2942">Proper information not submitted</asp:ListItem>
            <asp:ListItem Value="2943">Others</asp:ListItem>
        </asp:DropDownList>

    </div>
    <div class="col-md-2 col-sm-6 col-xs-6">
        
        <asp:TextBox ID="txtOtherreason"  CssClass="similar-select1 input-sm" runat="server" placeholder="Please Enter Reason*"  Visible="false" ></asp:TextBox>

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

    <div class="form-group">
        <div class="col-md-12 col-sm-12 col-xs-12 text-right">
            <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-primary ey-bg btn-sm"  OnClientClick="javascript:return confirm('Kindly check details before submmitting after this you cannot change record');" OnClick="btnSave_Click" Text="Save" Style="margin-top:2px;"/>
        </div>
    </div>
   <asp:Label ID="lblFilePath" Visible="false" runat="server" Text=""></asp:Label>
   <asp:Label ID="lblServiceID" Visible="false" runat="server" Text=""></asp:Label>

  <br />
        <div class="clearfix"></div>
      
          

