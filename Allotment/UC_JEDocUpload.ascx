<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_JEDocUpload.ascx.cs" Inherits="Allotment.UC_JEDocUpload" %>
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
  
          .Image{
        width:50px;
        height:50px;
    }
.grow { transition: all .4s ease-in-out; }
.grow:hover { transform: scale(4.0); }

#myImg {
  border-radius: 5px;
  cursor: pointer;
  transition: 0.3s;
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
<div class="panel-heading text-center">Site Inspection Document</div>						                        
    <div class="col-md-12 col-sm-12 col-xs-12" id="DivP">                   
        <table style="width:100%" Class="table table-striped table-bordered table-hover request-table">
            <tr><th>Sr.No</th><th>Document Name</th><th></th><th></th></tr>
            <tr><td>1</td><td>Plot Tracing</td><td><span class="col-md-10"><asp:FileUpload ID="FileUpload4" runat="server" /></span><span class="col-md-2"><asp:LinkButton ID="btnTracing" runat="server" Text='<i class="fa fa-upload" aria-hidden="true"></i>' OnClick="imgdocuments_Click" /></span></td><td><asp:LinkButton runat="server" aria-hidden="true" ID="bttnTracing" CssClass="fa fa-eye" OnClick="bttnTracing_Click"/></td></tr>
            <tr><td>2</td><td>Site Inspection Report</td><td><span class="col-md-10"><asp:FileUpload ID="FileUpload1" runat="server" /></span><span class="col-md-2"><asp:LinkButton ID="btnInspection" runat="server" OnClick="LinkButton1_Click" Text='<i class="fa fa-upload" aria-hidden="true"></i>' /></span></td><td><asp:LinkButton runat="server" aria-hidden="true" ID="btnInspectionReport" CssClass="fa fa-eye" OnClick="btnInspectionReport_Click"/></td></tr>
        </table>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />
    <div class="panel-heading text-center">Site Inspection Details</div>
    <div class="form-group">
        <label class="col-md-4 col-sm-5 col-xs-6 text-right">Is There Any Construction on Plot</label>
        <div class="col-md-8 col-sm-7 col-xs-6">
            <asp:CheckBox runat="server" ID="chkAnyConst" OnCheckedChanged="chkAnyConst_CheckedChanged" AutoPostBack="true" />
        </div>
    </div>
    <div runat="server" id="constrUnitDiv" visible="false">
        <div class="clearfix"></div>
        <hr class="myhrline" />
        <div class="form-group">
            <label class="col-md-2 col-sm-6 col-xs-6 text-right">Value of Construction</label>
            <div class="col-md-10 col-sm-6 col-xs-6">
                <asp:TextBox runat="server" ID="txtValueConst" CssClass="similar-select1 input-sm"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />
    <div class="form-group">
        <label class="col-md-2 col-sm-6 col-xs-6 text-right">Plot Area as per Tracing</label>
        <div class="col-md-10 col-sm-6 col-xs-6">
            <asp:TextBox runat="server" ID="txtArea" CssClass="similar-select1 input-sm"></asp:TextBox>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />
  <div class="form-group">
        <label class="col-md-2 col-sm-6 col-xs-6 text-right">Plot Dimension</label>
        <div class="col-md-10 col-sm-6 col-xs-6">
            <asp:TextBox runat="server" ID="txtDimension" CssClass="similar-select1 input-sm"></asp:TextBox>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />
  <div class="form-group">
        <label class="col-md-2 col-sm-6 col-xs-6 text-right">Plot Direction</label>
        <div class="col-md-10 col-sm-6 col-xs-6">
           <asp:DropDownList ID="drp_PlotDirection" runat="server" CssClass="input-sm similar-select1 margin-left-z" Width="90%">
                <asp:ListItem>--Select--</asp:ListItem>
               <asp:ListItem Value="North">North</asp:ListItem>
               <asp:ListItem Value="North-North-East">North-North-East</asp:ListItem>
               <asp:ListItem Value="North-East">North-East</asp:ListItem>
               <asp:ListItem Value="East-North-East">East-North-East</asp:ListItem>
               <asp:ListItem Value="East">East</asp:ListItem>
               <asp:ListItem Value="East-South-East">East-South-East</asp:ListItem>
               <asp:ListItem Value="South-East">South-East</asp:ListItem>
               <asp:ListItem Value="South-South-East">South-South-East</asp:ListItem>
               <asp:ListItem Value="South">South</asp:ListItem>
               <asp:ListItem Value="South-South-West">South-South-West</asp:ListItem>
               <asp:ListItem Value="South-West">South-West</asp:ListItem>
               <asp:ListItem Value="West-South-West">West-South-West</asp:ListItem>
               <asp:ListItem Value="West">West</asp:ListItem>
               <asp:ListItem Value="West-North-West">West-North-West</asp:ListItem>
               <asp:ListItem Value="North-West">North-West</asp:ListItem>
               <asp:ListItem Value="North-North-West">North-North-West</asp:ListItem>                      
                        </asp:DropDownList>
              <asp:HyperLink ID="hypLnk" runat="server" Target="_blank"  Text="Help" NavigateUrl="~/DirImageView.aspx"> </asp:HyperLink>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />
    <div class="form-group">
        <label class="col-md-2 col-sm-6 col-xs-6 text-right">Site Inspection Date</label>
        <div class="col-md-10 col-sm-6 col-xs-6">
            <asp:TextBox runat="server" ID="txtSiteDate" CssClass="date similar-select1 input-sm"></asp:TextBox>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />
    <div class="form-group">
        <div class="col-md-12 col-sm-12 col-xs-12 text-right">
            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary ey-bg btn-sm" OnClick="btnSave_Click" Text="Save" Style="margin-top:2px;"/>
        </div>
    </div>
<div id="myModal" class="modal">
  <span class="close">&times;</span>
  <img class="modal-content" id="img01">
  <div id="caption"></div>
</div>

          

