<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_JEUploadPossession.ascx.cs" Inherits="Allotment.UC_JEUploadPossession" %>
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

<div class="clearfix"></div>
                <hr class="myhrline" />
<div class="panel-heading text-center">Possession Memo</div>						                        
    <div class="col-md-12 col-sm-12 col-xs-12" id="DivP">                   
        <table style="width:100%" Class="table table-striped table-bordered table-hover request-table">
            <tr><th>Sr.No</th><th>Document Name</th><th></th><th></th></tr>
            <tr><td>1</td><td>Possession Memo</td><td><span class="col-md-10"><asp:FileUpload ID="FileUploadLease" runat="server" /></span><span class="col-md-2"><asp:LinkButton ID="btnTracing" runat="server" Text='<i class="fa fa-upload" aria-hidden="true"></i>' OnClick="imgdocuments_Click" /></span></td><td><asp:LinkButton runat="server" aria-hidden="true" ID="bttnTracing" CssClass="fa fa-eye" OnClick="bttnTracing_Click"/></td></tr>
              </table>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />
    <div class="panel-heading text-center">Plot Possession Details</div>
    
    
    <div class="form-group">
        <label class="col-md-2 col-sm-6 col-xs-6 text-right">Possession Details</label>
        <div class="col-md-10 col-sm-6 col-xs-6">
            <asp:TextBox runat="server" ID="txtRDate" CssClass="date similar-select1 input-sm"></asp:TextBox>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />
<div class="form-group">
        <label class="col-md-2 col-sm-6 col-xs-6 text-right">Area of Possession Given</label>
        <div class="col-md-10 col-sm-6 col-xs-6">
            <asp:TextBox runat="server" ID="txtPossessionArea" CssClass="similar-select1 input-sm"></asp:TextBox>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />
<div class="form-group">
        <label class="col-md-2 col-sm-6 col-xs-6 text-right">Possession Given To</label>
        <div class="col-md-10 col-sm-6 col-xs-6">
            <asp:TextBox runat="server" ID="txtGivenTo" CssClass="similar-select1 input-sm"></asp:TextBox>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />


    <div class="form-group">
        <div class="col-md-12 col-sm-12 col-xs-12 text-right">
            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary ey-bg btn-sm"  OnClientClick="javascript:return confirm('Kindly check details before submmitting after this you cannot change record');" OnClick="btnSave_Click" Text="Save" Style="margin-top:2px;"/>
        </div>
    </div>


          

