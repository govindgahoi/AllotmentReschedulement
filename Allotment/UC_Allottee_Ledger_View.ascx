<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Allottee_Ledger_View.ascx.cs" Inherits="Allotment.UC_Allottee_Ledger_View" %>
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
   
            $("[src*=plus]").live("click", function () {
                $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
                $(this).attr("src", "images/minus.png");
            });
            $("[src*=minus]").live("click", function () {
                $(this).attr("src", "images/plus.png");
                $(this).closest("tr").next().remove();
            });
       
   </script>




          
            
            <cc1:MessageBox ID="MessageBox1" runat="server" />
            <cc1:ConfirmBox ID="ConfirmBox1" runat="server" />

        
     
                <div class="row"  runat="server" id="Summary_Div">
                    <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-12 font-bold text-center" style="margin-top: 12px;">
                                    <ul class="pull-left list-inline">
                    <li>
                    
                    </li>
                    
                </ul>
                                    Allottee Ledger
                                     
                        <ul class="pull-right list-inline">
                    <li>
                        <a runat="server" onclick="PrintElemF()" style="cursor:pointer;">
                            <i style="font-size: 18px;" class="fa fa-print" aria-hidden="true"></i>
                        </a>
                    </li>
                    
                </ul>
                        
                                </div>
                                
                                <div class="clearfix"></div>

                            </div>
                            <div  class="panel-body table-responsive">
                                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                                <div>
                                <asp:GridView ID="AllotteePaymentSummaruGrid" runat="server" ShowFooter="true" AutoGenerateColumns="false"  CssClass="table table-striped table-bordered table-hover request-table" OnRowDataBound="AllotteePaymentSummaruGrid_RowDataBound">
                                    <Columns>

                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField ="PaymentName"   HeaderText ="Payment Head"/>
                                        <asp:BoundField DataField ="Demanded"      HeaderText ="Demanded"    />
                                        <asp:BoundField DataField ="Paid"          HeaderText ="Paid"     />                                      
                                        <asp:BoundField DataField ="Outstanding"   HeaderText ="Outstanding"           />
                                       
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                    </div>
                            </div>
                        </div>
                    </div>
                </div>
       

  


