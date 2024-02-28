<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ViewPOA.ascx.cs" Inherits="Allotment.UC_ViewPOA" %>
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


<div class="panel-heading font-bold" style="padding:7px 3px !important;">Assigned POA</div>
						                        
                    <div class="col-md-12 col-sm-12 col-xs-12" >                   
                         <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover request-table request-table" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="ID" Visible="false">
            <ItemTemplate>
               <asp:Label ID="POAID" runat="server" Text='<%#Eval("ID")%>'> </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="POAName" HeaderText="POA Name" />
        <asp:BoundField DataField="POAEmailID" HeaderText="Email ID" />
        <asp:BoundField DataField="POAMobileNo" HeaderText="Mobile No" />
        <asp:TemplateField HeaderText="Photo">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" CssClass="Image grow" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sign">
            <ItemTemplate>
                <asp:Image ID="Image2" runat="server" CssClass="Image grow" />
            </ItemTemplate>
        </asp:TemplateField>
        
    </Columns>
</asp:GridView>

                    </div>
          
