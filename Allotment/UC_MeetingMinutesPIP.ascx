﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_MeetingMinutesPIP.ascx.cs" Inherits="Allotment.UC_MeetingMinutesPIP" %>
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

<!--

    <div class="panel-heading text-center">Meeting Minutes</div>     
    <div class="form-group">
        <label class="col-md-2 col-sm-6 col-xs-6 text-right">Meeting Type</label>
        <div class="col-md-10 col-sm-6 col-xs-6">
             <asp:DropDownList ID="ddlMeetingType" runat="server"  CssClass="chosen margin-left-z input-sm similar-select1" >
                                                                                                 <asp:ListItem>--Select--</asp:ListItem>
                                                                                                   <asp:ListItem>Empowered Committee</asp:ListItem>
                                                                                                   <asp:ListItem>Steering Committee </asp:ListItem>
                                                                                                   <asp:ListItem>Other              </asp:ListItem>
                                                                    
                                                                                             </asp:DropDownList>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />
    <div class="form-group">
        <label class="col-md-2 col-sm-6 col-xs-6 text-right">Meeting Date</label>
        <div class="col-md-10 col-sm-6 col-xs-6">
            <asp:TextBox runat="server" ID="txtMeetingDate" CssClass="date similar-select1 input-sm"></asp:TextBox>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />
<div class="form-group">
        <label class="col-md-2 col-sm-6 col-xs-6 text-right">Meeting Description</label>
        <div class="col-md-10 col-sm-6 col-xs-6">
            <asp:TextBox runat="server" ID="txtDescription" CssClass="similar-select1 input-sm"></asp:TextBox>
        </div>
    </div>
    <div class="clearfix"></div>
    <hr class="myhrline" />

<div class="form-group">
                                                       
                                                                <label class="col-md-2 text-right">
                                                                   Copy of Minutes
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
    -->
        <div class="clearfix"></div>
        <div class="panel panel-default">
            <p class="panel-heading font-bold text-center">List of Meeting Minutes</p>
            <div class="panel-body">
                <asp:GridView ID="GridView2" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table"                              
                                AutoGenerateColumns="False"
                                ClientIDMode  ="Static"
                                DataKeyNames  ="ID,DocPath"
                                GridLines="Horizontal" 
                                OnRowDataBound="GridView2_RowDataBound"
                                OnRowCommand="GridView2_RowCommand"
                                Width="100%" 
                                PagerStyle-CssClass="pagination-ys" 
                                PagerStyle-HorizontalAlign="Right">
                                <Columns>
                                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    <asp:BoundField DataField="MeetingDate"  HeaderText = "MOM Uploaded Date"   />
                                    <asp:BoundField DataField="statusMOM"      HeaderText = "Status"   />
                                    
                                   

                                    <asp:TemplateField HeaderText="View Letter" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnDownload"  ToolTip="Download Minutes" Text='<i class="fa fa-download" aria-hidden="true"></i>'  CommandName="Download" CausesValidation="false" CommandArgument='<%# (Container.DataItemIndex) %>' />                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    
                                </Columns>
                                <EmptyDataTemplate>
                                    No Record Available
                                </EmptyDataTemplate>
                            </asp:GridView>
            </div>
        </div>

          

