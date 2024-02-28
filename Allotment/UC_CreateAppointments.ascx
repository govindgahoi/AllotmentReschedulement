<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_CreateAppointments.ascx.cs" Inherits="Allotment.UC_CreateAppointments" %>
<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>



<style>

    
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
  
     .tooltip
    {
        position: absolute;
        top: 0;
        left: 0;
        z-index: 3;
        display: none;
        background-color: #FB66AA;
        color: White;
        padding: 5px;
        font-size: 10pt;
        font-family: Arial;
    }
    td
    {
        cursor: pointer;
    }
    
</style>

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="http://cdn.jsdelivr.net/jquery.simpletip/1.3.1/jquery.simpletip-1.3.1.min.js"></script>
<script type="text/javascript">

    $(function () {
        $('[id*=GridView1] tr').each(function () {
            var toolTip = $(this).attr("title");
            $(this).find("td").each(function () {
                $(this).simpletip({
                    content: toolTip
                });
            });
            $(this).removeAttr("title");
        });
    });
     
        function MessageAndRedirect() {
            alert('Application Transfer');
         //  window.location.href = 'AllotmentRequest.aspx';

        }

    function ShowPopupChange() {
            
                    $("#btnModalGridchange").click();
                }
   </script>


	   <cc1:MessageBox ID="MessageBox1" runat="server" />
 <input type="button" value="Click Me" style="display:none;" id="btnModalGridchange" data-toggle="modal" data-target="#ModalGridchange" >
 <div class="modal fade" id="ModalGridchange" style="left:-522px !important;top:-28px !important;" role="dialog">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><asp:Label runat="server" ID="change_title" Text="Account Clearance"/></h4>
        </div>
        <div class="modal-body">        
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Received Date :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtReceivedDate" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" placeholder="dd/mm/yyyy"></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
             <hr class="myhrline" />
        </div>
        <div class="modal-footer">
            <div class="border-buttons pull-right">
           <asp:HiddenField  runat="server"  ID="change_title1" /><asp:HiddenField  runat="server"  ID="change_id" /> <asp:Button ID="Button2" runat="server" CssClass="btn btn-sm btn-primary btn-popup" Text="Submit"  /> 
          <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal">Close</button></div>
        </div>
      </div>
      
    </div>
  </div>

             <div class="form-group">
                    <label class="col-md-2 col-sm-6 col-xs-6">
                        Appointment  Type: 
                    </label>
                    <div class="col-md-10 col-sm-6 col-xs-6">
                        <asp:DropDownList ID="drpAppointmentType" runat="server" CssClass="input-sm similar-select1 margin-left-z" OnSelectedIndexChanged="drpAppointmentType_SelectedIndexChanged" AutoPostBack="true">
                         
                        </asp:DropDownList>
                        
                    </div>
                </div>
          
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">  
                    
                    <div runat="server" id="StampDiv" visible="false">
                         <label class="col-md-2 col-sm-6 col-xs-6">
                        Stamp Paper amount:
                    </label>
                    <div class="col-md-10 col-sm-6 col-xs-6">
                        <asp:TextBox ID="txtStampAmount" runat="server"  CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>                     
                    </div>
                        <div class="clearfix"></div>
                        <label class="col-md-2 col-sm-6 col-xs-6">
                        DM Circle:
                    </label>
                    <div class="col-md-10 col-sm-6 col-xs-6">
                        <asp:TextBox ID="txtDMCircle" runat="server"  CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>                     
                    </div>

                    </div>
                    <div class="clearfix"></div>
                    <label class="col-md-2 col-sm-6 col-xs-6">
                        Appointment Description:
                    </label>
                    <div class="col-md-10 col-sm-6 col-xs-6">
                        <asp:TextBox ID="txtComment" runat="server" Rows="10" TextMode="MultiLine" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>                     
                    </div>
                </div>
              <div class="clearfix"></div>
<div runat="server" id="DivPossession" visible="false">
                <hr class="myhrline" />
                <div class="form-group">                  
                    <label class="col-md-2 col-sm-6 col-xs-6">
                        Appointment Date:
                    </label>
                    <div class="col-md-10 col-sm-6 col-xs-6">
                        <asp:TextBox ID="txtAppDate" runat="server" CssClass="date input-sm similar-select1 margin-left-z"></asp:TextBox>                     
                    </div>
                </div></div>
                 <span class="pull-right"><asp:Button runat="server" Text="Create" id="btnSend" class="btn-primary btn-sm margin-left-z" style="margin: 7px 10px;" OnClick="btnSend_Click"/></span>
<div class="clearfix"></div>
                <hr class="myhrline" />
<div class="panel-heading font-bold" style="padding:7px 3px !important;">List Of Appointments</div>
						                        
                    <div class="col-md-12 col-sm-12 col-xs-12" id="DivP">                   
                         <asp:GridView ID="GridView1" runat="server"
             CssClass="table table-striped table-bordered table-hover request-table request-table"
            OnRowCommand="GridView1_RowCommand"
            OnRowDataBound="GridView1_RowDataBound"
            AllowSorting="True"
            AutoGenerateColumns="False"
            DataKeyNames="ID,AppointmentTypeID"
            GridLines="Horizontal"
            Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:BoundField DataField="AppointmentType" HeaderText="Appointment Type" SortExpression="AppointmentType" />
                <asp:BoundField DataField="AppointmentDesc" HeaderText="Appointment Description" SortExpression="AppointmentDesc" />
                <asp:BoundField DataField="CreatedOn"       HeaderText="Created On" SortExpression="CreatedOn" />
                <asp:BoundField DataField="CreatedBy"       HeaderText="Created By" SortExpression="CreatedBy" />
                 <asp:TemplateField HeaderText="Number" Visible="false" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("AppStatus") %>'> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnk" Text='<%# Eval("AppStatus") %>' CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" CommandName="Select" OnClientClick="javascript:return confirm('Are you sure wanted to close this appointment?');" />
            </ItemTemplate>
        </asp:TemplateField>
                
            </Columns>
            <EmptyDataTemplate>
                No Record Available
            </EmptyDataTemplate>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
           
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
                    </div>
               



				<div class="clearfix"></div>