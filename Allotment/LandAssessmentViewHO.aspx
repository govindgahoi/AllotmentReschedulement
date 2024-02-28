<%@ Page Title="" Language="C#" MasterPageFile="~/MainUserHO.Master" AutoEventWireup="true" CodeBehind="LandAssessmentViewHO.aspx.cs" Inherits="Allotment.LandAssessmentViewHO" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <style>
        .box-panel {
            -webkit-box-shadow: 0 1px 1px transparent;
            box-shadow: 0 1px 1px transparent;
        }

        .box-back-none {
            background: none !important;
            box-shadow: inset 0px 1px 1px transparent !important;
        }

        .tooltip {
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

        td {
            cursor: pointer;
        }
        .modal-backdrop
        {
            position:inherit !important;
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

           @media screen and (min-width: 992px) {
            #ModalGridchange1 .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 11%;
            }
        }
    </style>
    <script type="text/javascript">
 
        function ShowPopupChange(val) {

            //alert(val);
            $('#<%= change_text.ClientID %>').val(val);
            $('#ModalGridchange').modal('toggle');
            
        }
        function ShowPopupChange2(val) {

            //alert(val);
           
            $('#ModalGridchange1').modal('toggle');

        }
        function ShowPopupChangeAlert(val,val1) {

            alert(val1);
            $('#<%= change_text.ClientID %>').val(val);
             $('#ModalGridchange').modal('toggle');

         }
    </script>
  
    <script type="text/javascript">
        function isDecimalKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {


            }
        }

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>



    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">



        <ContentTemplate>
            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                <ProgressTemplate>
                    <div class="fgh">
                        <div class="hgf">
                            <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>



                <div class="modal fade" id="ModalGridchange1" style="left:-527px !important;top:-322px !important;" role="dialog">
     <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content" style="width:600px;">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><asp:Label runat="server" ID="Label1" Text="View Proceedings"/></h4>
        </div>
        <div class="modal-body" style="font-size: 12px; padding: 4px 15px; overflow: auto; height: 321px;">        
            
             <asp:GridView ID="AllGrid" runat="server" CssClass="table table-striped table-bordered table-hover request-table request-table"
                            
                            ClientIDMode="Static"
                            AutoGenerateColumns="False"
                            DataKeyNames="ID"
                            GridLines="Horizontal"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                     <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                     <asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark" />
                                     <asp:BoundField DataField="UpdatedOn" HeaderText="Updated On" SortExpression="UpdatedOn" />
                                    <asp:BoundField DataField="UpdatedBy" HeaderText="Updated By" SortExpression="UpdatedBy" />
                                    
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
          
        </div>
        <div class="modal-footer">
            <div class="border-buttons pull-right">
          <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal">Close</button></div>
        </div>
      </div>
      
    </div>
  </div>


              <div class="modal fade" id="ModalGridchange" style="left:-522px !important;top:-28px !important;" role="dialog">
     <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><asp:Label runat="server" ID="change_title" Text="Status Updation"/></h4>
        </div>
        <div class="modal-body">        
             <div class="form-group" style="display:none;">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    ID :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="change_text" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Status :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:DropDownList ID="drpStatusType" runat="server" CssClass="input-sm similar-select1 margin-left-z">
                         <asp:ListItem Value="1">In Progress</asp:ListItem>
                         <asp:ListItem Value="2">First Contact Made</asp:ListItem>
                         <asp:ListItem Value="3">False Information Submitted</asp:ListItem>
                         <asp:ListItem Value="4">Land Allotted</asp:ListItem>
                         <asp:ListItem Value="5">Land Not Allotted</asp:ListItem>
                    </asp:DropDownList>    

                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
              <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Remarks :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                     <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm similar-select1 margin-left-z"></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
          
        </div>
        <div class="modal-footer">
            <div class="border-buttons pull-right">
           <asp:HiddenField  runat="server"  ID="change_title1" /><asp:HiddenField  runat="server"  ID="change_id" /> <asp:Button ID="Button2" runat="server" CssClass="btn btn-sm btn-primary btn-popup" Text="Submit" OnClick="Button2_Click"/> 
          <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal">Close</button></div>
        </div>
      </div>
      
    </div>
  </div>


            <cc1:MessageBox ID="MessageBox1" runat="server" />
            <cc1:ConfirmBox ID="ConfirmBox1" runat="server" />


            <div class="row">
            
                <div class="clearfix"></div>
                <div class="row">
                    <asp:Label ID="RateIdlbl" runat="server" Visible="false"></asp:Label>
                    
                </div>

                <div class="row">
                    <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-6 font-bold" style="margin-top: 12px;">
                                    Pending Land Requirement Request At You
                                </div>
                                <div class="input-group col-md-4 col-sm-12" style="float: right; padding: 2px;">
                                    <asp:TextBox ID="txtSearch" Width="100%" CssClass="input-sm" runat="server" OnTextChanged ="txtSearch_TextChanged" AutoPostBack="true"/>
                                    <span class="input-group-btn">
                                        <asp:LinkButton class="btn btn-sm btn-primary" runat="server" ID="btnSearch" Text="<i class='fa fa-search' style='color: #fff;'></i>" OnClick="btnSearch_Click"></asp:LinkButton>
                                    </span>
                                </div>
                                <div class="clearfix"></div>

                            </div>
                            <div class="panel-body gallery  table-responsive">
                                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="gridLAD" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover request-table" ClientIDMode="Static" OnPageIndexChanging="gridLAD_PageIndexChanging" 
                                PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" OnRowCommand="gridLAD_RowCommand"  DataKeyNames  ="LandAssessmentID">
                                    <Columns>


                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField DataField="Census_District" HeaderText="District" SortExpression="Census_District" />
                                         <asp:BoundField DataField="Census_SubDistrictName" HeaderText="Taluka" SortExpression="Census_SubDistrictName" />
                                         <asp:BoundField DataField="NameofInvestor" HeaderText="Name of Investor" SortExpression="NameofInvestor" />
                                     
                                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile No." SortExpression="MobileNo" />
                                        <asp:BoundField DataField="Mail" HeaderText="Mail" SortExpression="Mail" />                                        
                                                         <asp:BoundField DataField="PreferredLocation" HeaderText="Preferred Location" SortExpression="PreferredLocation" />
                                               <asp:BoundField DataField="RequiredLandSize" HeaderText="Required Land Size(in Sq.mtr.)" SortExpression="RequiredLandSize" />

                                        <asp:TemplateField HeaderText="View More">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                   <asp:HyperLink runat="server" NavigateUrl='<%# Eval("LandAssessmentID", "LandAssessmentDetails.aspx?ID={0}") %>' target="_blank"   CssClass="fa fa-eye" />
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Update">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Process" CommandArgument='<%# (Container.DataItemIndex) %>' ToolTip="Click here to update status" />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                       <asp:TemplateField HeaderText="View Status">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="View" CommandArgument='<%# (Container.DataItemIndex) %>'  ToolTip="Click here to View Status" />
                                                </span>  
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                 <div id="dialog" style="display: none">
                            </div>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>





</asp:Content>
