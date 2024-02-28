<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Allottee_Ledger.ascx.cs" Inherits="Allotment.UC_Allottee_Ledger" %>
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
                        <asp:Button runat="server" ID="btnBack" Text="Back To Objection" OnClick="btnBack_Click" class="btn btn-primary btn-popup" />
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
               <br /><br />
                <div class="row">
                    <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                    <div class="panel">
                        <div class="">
                            <div class="col-md-12">
                                <div class="panel-heading font-bold" style="text-align: center;">
                                    Allottee Payment Entry                        
                                </div>
                                <div class="panel-body">

                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-2 col-sm-12 text-center">
                                                <span style="color: Red">*</span>
                                                 Date 
                                            </label>
                                             <label class="col-md-2 col-sm-12 text-center">
                                                <span style="color: Red">*</span>
                                                Payment Head 
                                            </label>
                                             <label class="col-md-4 col-sm-12 text-center">
                                                <span style="color: Red">*</span>
                                                Description(Demand No/Payment Details) :
                                            </label>
                                             <label class="col-md-2 col-sm-12 text-center">
                                                <span style="color: Red">*</span>
                                                Debit/Credit 
                                            </label>
                                             <label class="col-md-1 col-sm-12 text-center">
                                                
                                               Amount
                                            </label>
                                            <label class="col-md-1 col-sm-12 text-center">
                                               
                                            </label>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                           <div class="col-md-2 col-sm-12">
                                              <asp:TextBox ID="txtTransactionDate" runat="server"  class="date input-sm similar-select1"></asp:TextBox>
                                                   
                                            </div>
                                            <div class="col-md-2 col-sm-12">
                                                <asp:DropDownList ID="ddl_PaymentHead" runat="server" CssClass="chosen input-sm dropdown-toggle similar-select1"  ></asp:DropDownList>
                                            </div>
                                             <div class="col-md-4 col-sm-12">
                                                   <asp:TextBox ID="txtDescription" runat="server" ToolTip="only text Value" class="input-sm similar-select1"></asp:TextBox>                                           
                                            </div>
                                            <div class="col-md-2 col-sm-12">
                                                <asp:DropDownList ID="ddl_PayStatus" runat="server" CssClass="chosen input-sm dropdown-toggle similar-select1"  >
                                                     <asp:ListItem  Value="0">--Select--</asp:ListItem>
                                                     <asp:ListItem  Value="1">Debit-Demanded</asp:ListItem>
                                                     <asp:ListItem  Value="2">Credit-Paid</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                             <div class="col-md-1 col-sm-12">
                                                   <asp:TextBox ID="txtAmount" runat="server" ToolTip="only text Value" class="sinput-sm similar-select1"></asp:TextBox>                                           
                                            </div>
                                            <div class="col-md-1 col-sm-12" >
                                                  
                                            <asp:LinkButton ID="btnAdd" runat="server" CssClass="fa fa-plus"  OnClick="btnAdd_Click" ></asp:LinkButton>
                                             &nbsp;
                                            <asp:LinkButton ID="btnClar" runat="server" CssClass="fa fa-trash-o"  OnClick="btnClar_Click" ></asp:LinkButton>
                                               
                                        </div>
                                        </div>
                                    </div>
                          
                   
           
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
      
                                    <div class="clearfix"></div>
                                    <asp:Label ID="lblID" runat="server" Style="display:none;"></asp:Label>
                                      <asp:TextBox ID="txtID" runat="server" ToolTip="only text Value" Style="display:none;" class="input-sm similar-select1"></asp:TextBox>  
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            <br /><br />                        
                <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-12 font-bold text-center" style="margin-top: 12px;">
                                    Allottee Journal
                                    <ul class="pull-right list-inline">
                    <li>
                        <a runat="server" onclick="PrintElemV()" style="cursor:pointer;">
                            <i style="font-size: 18px;" class="fa fa-print" aria-hidden="true"></i>
                        </a>
                    </li>
                    
                </ul>
                                </div>
                                
                                <div class="clearfix"></div>

                            </div>
                            <div runat="server" id="Journal_Div" class="panel-body gallery  table-responsive">
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                            <asp:GridView ID="AllotteeJournalGrid" runat="server" AutoGenerateColumns="false"  CssClass="table table-striped table-bordered table-hover request-table"
                             OnRowCommand="AllotteeJournalGrid_RowCommand" OnRowDataBound="AllotteeJournalGrid_RowDataBound">
                                    <Columns>

                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField ="TransactionDate" HeaderText ="Transaction Date"/>
                                        <asp:BoundField DataField ="PaymentName"     HeaderText ="Payment Head"    />
                                        <asp:BoundField DataField ="Description"     HeaderText ="Description"     />                                      
                                        <asp:BoundField DataField ="Debit"           HeaderText ="Debit"           />
                                        <asp:BoundField DataField ="Credit"          HeaderText ="Credit"          />
                                       

                                        <asp:TemplateField HeaderText="Update">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandArgument='<%#Eval("TransactionDate")+"|"+ Eval("PaymentHeadID")+"|"+ Eval("Description")+"|"+ Eval("Debit")+"|"+ Eval("Credit")+"|"+ Eval("ID")+"|"+ Eval("PayStatus")+"|"+ Eval("Amount") %>' CommandName="Process" ToolTip="Click here For Update record " />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Delete">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="DeleteRow" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" ToolTip="Click here to delete row" CommandArgument='<%#Eval("ID") %>'  />
                                                </span>  
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
           

    
    <script type="text/javascript">

    
     
              
    </script>



