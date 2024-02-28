<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_TransferPIPFINApplication.ascx.cs" Inherits="Allotment.UC_TransferPIPFINApplication" %>
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
    
          .Red{
            color:red;
        }
        .Green{
            color:green;
        }
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
    $(document).ready(function () {
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
    });

    function PageLoaded(sender, args) {
        $(".chosen").chosen();
        $(".MultiSelect").chosen(
        );
    }

    function ShowPopup() {
        $("#btnModalGridchange").click();
    }

</script>


	   <cc1:MessageBox ID="MessageBox1" runat="server" />

<input type="button" value="Click Me" style="display:none;" id="btnModalGridchange" data-toggle="modal" data-target="#ModalGridchange" >
                   
 <div class="modal fade" id="ModalGridchange" style="left:238px !important;top:112px !important;" role="dialog">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><asp:Label runat="server" ID="change_title" /></h4>
        </div>
        <div class="modal-body">        
             <asp:Label ID="lblComments" runat="server"></asp:Label>
        </div>
        <div class="modal-footer">
            <div class="border-buttons pull-right">
           <asp:HiddenField  runat="server"  ID="change_title1" /> 
          <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal">Close</button></div>
        </div>
      </div>
      
    </div>
  </div>

        <div class="clearfix"></div>
                <hr class="myhrline" />
                
           <div class="form-group">
                    <label class="col-md-2 col-sm-6 col-xs-6">
                        Status: 
                    </label>
                    <div class="col-md-10 col-sm-6 col-xs-6"> 
                        <%--<asp:ListItem>Recommended</asp:ListItem>   
                            <asp:ListItem>Non-Recommended</asp:ListItem>                        
                            <asp:ListItem>Approve</asp:ListItem>
                            <asp:ListItem>Reject</asp:ListItem>--%>
                        <asp:DropDownList ID="ddlTransferStatus" runat="server" Enabled="false"  CssClass="chosen margin-left-z input-sm similar-select1" >
                           
                        </asp:DropDownList>
                        
                    </div>
                </div>
     <div class="clearfix"></div>
                <hr class="myhrline" />
            
            <div class="col-md-12 col-sm-12 col-xs-12" runat="server" id="OtherDept" visible="false">
          
                <div class="form-group">
                    <label class="col-md-2 col-sm-6 col-xs-6">
                        Send to: 
                    </label>
                    <div class="col-md-10 col-sm-6 col-xs-6">
                        <asp:ListBox ID="drpSendto" SelectionMode="Multiple" runat="server" Class="MultiSelect" Width="100%"></asp:ListBox>
                        
                    </div>


                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
        </div>

<div runat="server" id="CommDiv" visible="true">
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
                                                                    <asp:Label ID="lblUploadStatus" runat="server" Visible="true"></asp:Label>
                                                                </label>
                                                                <div class="col-md-6">
                                                                    <asp:FileUpload ID="fileupload1" runat="server" CssClass="form-control form-control-sm" ToolTip="Upload" accept=".pdf" />                                                        
                                                                </div>
                                                 <div class="col-md-4">
                                                                  <asp:Button ID="btnupload" runat="server" Text="Upload" CssClass="rounded-0 btn btn-primary" style="padding:2px 15px;margin-top: 5px;" OnClick="btnupload_Click"/> 
                                                                    <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblLevel" runat="server" Visible="False"></asp:Label>
                                                                 </div>
                                                      
                                                            </div>
    </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />

                 <span class="pull-right">
                     <asp:Button runat="server" Text="Forward" id="btnSend" class="btn-primary btn-sm margin-left-z" style="margin: 7px 10px;" OnClientClick="javascript:return confirm('Please Check the data before transferring application');" OnClick="btnSend_Click"/>
                     <asp:Button ID="btnPIPComment" runat="server" Text="Submit" class="btn-primary btn-sm margin-left-z" style="margin: 7px 10px;"  OnClientClick="javascript:return confirm('Please Check the data before submit application');"  OnClick="btnPIPComment_Click"/>
                 </span>

                 


                 <div class="clearfix"></div>
<hr class="myhrline" />


<div id="divDisableReminder" visible="false" runat="server">

<div class="panel panel-default">
    <div class="panel-heading font-bold">
        Send Reminder       
    </div>
</div>

<div class="form-group">
    <asp:Panel ID="PanelReminder" runat="server" Visible="false" ScrollBars="Auto">
    <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top:3px;">
       <div class="col-md-4">
 <asp:DropDownList ID="ddlFrom" runat="server"></asp:DropDownList>
           </div>
       
         <div class="col-md-4">
                  <asp:FileUpload ID="FileUploadReminder" runat="server"  CssClass="input-sm similar-select"  ToolTip="Upload" accept=".pdf"   ></asp:FileUpload>

         </div>
                <div class="col-md-4"> <asp:Button ID="btnReminder" runat="server" OnClick="btnUploadReminder_Click" CssClass="btn btn-primary ey-bg btn-sm" Style="margin: 0 1px 0 0; width: 125px;" Text="Upload Reminder"   /> </div>
        </div>
         
       
      
      
</asp:Panel>
</div>
    <div class="clearfix"></div>
    <hr class="myhrline" />
 
        <div class="panel panel-default">
            <p class="panel-heading font-bold text-center">List of Users Application Forwarded for Comments</p>
            <div class="panel-body">
                <asp:GridView ID="GridView2" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table"                              
                                AutoGenerateColumns="False"
                                ClientIDMode  ="Static"
                                DataKeyNames  ="ID"
                                GridLines="Horizontal" 
                                Width="100%" 
                                PagerStyle-CssClass="pagination-ys" 
                                PagerStyle-HorizontalAlign="Right"
                                 OnRowCommand="GridView2_RowCommand" >
                                <Columns>
                                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    <asp:BoundField DataField="ForwardedTo"  HeaderText = "Forwarded To" />
                                    <asp:BoundField DataField="ForwardedOn"  HeaderText = "Forwarded On"   />
                                    <asp:TemplateField HeaderText="Current Status" HeaderStyle-CssClass="text-center-imp" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            
                                                            <asp:Label ID="IsPositive" runat="server" Text='<%# Eval("Status").ToString()%>'   CssClass='<%# (Eval("Status").ToString())=="Comments Pending" ? "Red"  : "Green" %>'></asp:Label>
                                                                 </ItemTemplate>
                                                    </asp:TemplateField>
                                    
                                   

                                       <asp:TemplateField>
                                                            <HeaderStyle />
                                                            <HeaderTemplate>
                                                                <asp:Label ID="hlblimg" runat="server" Text=""></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbView"     runat="server"  CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="View" Text='' ><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton> 
                                                               
                                                                </ItemTemplate>
                                                        </asp:TemplateField>

                                    <asp:TemplateField HeaderText="View Reminder 1" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                
                                
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="HyperR1" Target="_blank" NavigateUrl='<%# string.Format(Eval("Reminder1").ToString()) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField> 
                               
                                <asp:TemplateField HeaderText="View Reminder 2" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                
                                
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="HyperR2" Target="_blank" NavigateUrl='<%# string.Format(Eval("Reminder2").ToString()) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField> 
                                <asp:TemplateField HeaderText="View Reminder 3" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                
                                
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="HyperR3" Target="_blank" NavigateUrl='<%# string.Format(Eval("Reminder3").ToString()) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField>
                                     <asp:TemplateField HeaderText="View Reminder 4" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                
                                
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="HyperR4" Target="_blank" NavigateUrl='<%# string.Format(Eval("Reminder4").ToString()) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField>
                                   
                                   <asp:TemplateField HeaderText="View Reminder 5" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                
                                
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="HyperR5" Target="_blank" NavigateUrl='<%# string.Format(Eval("Reminder5").ToString()) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    No Record Available
                                </EmptyDataTemplate>
                            </asp:GridView>
            </div>
        </div>
    </div>