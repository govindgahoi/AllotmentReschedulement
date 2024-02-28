<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="DuesHistory.aspx.cs" Inherits="Allotment.DuesHistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register assembly="ProudMonkey.Common.Controls" namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />

    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <style>
        #ModalViewGroup .modal-dialog
          {
              width: 529px !important;
              margin: 178px 871px !important;
          }
        .modal-dialog
          {
              width: 396px !important;
              margin: 178px 871px !important;
          }
    </style>
    <script  type="text/javascript">
        function ShowGroups() {
            $("#btnShowGroup").click();


        }
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (sender, e) {
            function ShowGroups() {
                $("#btnShowGroup").click();

            }

        });
  </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional"  >

    

   <ContentTemplate>
        <asp:UpdateProgress ID="UpdWaitImage" runat="server"  DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                 <ProgressTemplate>
                 <div class="fgh">
                 <div class="hgf">
                                <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>   
                               </div>
                               </div>
       </ProgressTemplate>
       </asp:UpdateProgress>
      <cc1:MessageBox ID="MessageBox1" runat="server" /> 
     <div class="panel panel-default">         
     <div class="panel-heading font-bold">Dues History</div>
          <div class="panel-body" style="margin-top: 10px;">
               <input type="button" value="Click Me" style="display:none;" id="btnShowGroup" data-toggle="modal" data-target="#ModalViewGroup" >
                                        <div class="table-responsive">


                                         <asp:GridView ID="GridView2" runat="server"
                      PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"
                      AllowPaging="True"
                     PageSize="10"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                       CssClass="table  Allottee_master_grid  table-bordered table-hover request-table"
                        GridLines="Horizontal" 
                        OnRowCommand="GridView2_RowCommand"  OnPageIndexChanging="OnPageIndexChanging"  OnRowDataBound="GridView2_RowDataBound"
                        Width="95%" >
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
              


                            <asp:BoundField DataField="DemandNo" HeaderText="Demand No" SortExpression="Allotmentletterno"  /> 
                            <asp:BoundField DataField="Allotmentletterno" HeaderText="Allottee Id" SortExpression="Allotmentletterno"  />
                            <asp:BoundField DataField="EntryDate" HeaderText="Notice Date" SortExpression="EntryDate" DataFormatString="{0:dd-MMM-yyyy}"  /> 
                            <asp:BoundField DataField="DueDate" HeaderText="Due Date" SortExpression="DueDate" DataFormatString="{0:dd-MMM-yyyy}" />
                            <asp:BoundField DataField="DueAmount" HeaderText="Due Amount" SortExpression="DueAmount" DataFormatString="{0:c}" />
                             <asp:BoundField DataField="PaidStatus" HeaderText="Payment Status" SortExpression="PaidStatus"  />
                            <asp:TemplateField ItemStyle-CssClass="text-center-imp">
                                <HeaderStyle />
                                <HeaderTemplate>
                                    <asp:Label ID="hlblimg" runat="server" Text="View Details"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbView" runat="server"  CssClass="fa fa-eye"  CommandArgument='<%#Eval("TransactionId") %>' CommandName="selectDocument"  aria-hidden="true"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="text-center-imp">
                                <HeaderStyle />
                                <HeaderTemplate>
                                    <asp:Label ID="hlblimg" runat="server" Text="Pay Dues"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblpay" runat="server"  CssClass="fa fa-credit-card"  CommandArgument='<%#Eval("TransactionId") %>' Visible="false"   aria-hidden="true"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                          <asp:TemplateField ItemStyle-CssClass="text-center-imp">
                                <HeaderStyle />
                                <HeaderTemplate>
                                    <asp:Label ID="hlblimg" runat="server" Text="View Demand Notice"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="lbldemand" runat="server"   CssClass="fa fa-credit-card" OnClientClick ="document.forms[0].target = '_blank';" CommandName="ViewNotice"  CommandArgument='<%#Eval("TransactionId")+","+ Eval("Allotmentletterno") %>'   aria-hidden="true"></asp:LinkButton>
                           --%>    
                                      <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%# string.Format("~/DemandNotice1.aspx?ID={0}&AllotteeId={1}",
                    HttpUtility.UrlEncode(Eval("TransactionId").ToString()), HttpUtility.UrlEncode(Eval("Allotmentletterno").ToString())) %>'
                    CssClass="fa fa-credit-card"  />

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            No Record Available
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                                            </div>
              </div>
<br />

                                            <div class="modal fade" id="ModalViewGroup" role="dialog" style="left:-428px !important;">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Allottee Dues Details</h4>
        </div>
        <div class="modal-body">
<div class="row">

                                          <div class="col-md-12">

                                                <div class="panel">
                                                    <div class="panel-heading my-panel-heading">
                                                        Allottee Dues Details
                                                    </div>
                                                    <div class="panel-body" style="margin-top: 5px;">
                                                        <asp:GridView ID="TransationDetailGrid" PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" AllowPaging="True" AllowSorting="True" PageSize="5" runat="server"   AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover request-table request-table">

                                                            <Columns>


                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                        </asp:Label>
                                                                        <asp:HiddenField ID="hfAllotteeID" runat="server" Value='<%#Eval("ID") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark" />
                                                                <asp:BoundField DataField="amt"      HeaderText="Amount" DataFormatString="{0:c}" SortExpression="amt" />


                                                               


                                                               
                                                            </Columns>

                                                        </asp:GridView>


                                                    </div>
                                                </div>
                                            </div>
    </div>
             </div></div></div></div>

  <div class="panel-heading font-bold">Payment History</div>
         <div class="body"style="margin-top: 10px;">

            <div class="table-responsive">
             <asp:GridView ID="AllotteePaymentGrid" runat="server" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table">
                            <Columns>

                                
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label22" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
              
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PaymentReicvedDate" HeaderText="Payment Received Date" SortExpression="PaymentReicvedDate" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="PaymentAmount" HeaderText="Payment Amount" SortExpression="PaymentAmount" DataFormatString="{0:c}"/>
                                <asp:BoundField DataField="PaymentDescription" HeaderText="Payment Description" SortExpression="PaymentDescription" />
                               
                            </Columns>
                       
                            
                        </asp:GridView>
                </div>
         </div>
                                        
                                    </div>
                                
       </ContentTemplate></asp:UpdatePanel>

    <script type="text/javascript">
        function openInNewTab() {
            window.document.forms[0].target = '_blank';
         setTimeout(function () { window.document.forms[0].target = ''; }, 0);
           
        }
</script>
</asp:Content>
