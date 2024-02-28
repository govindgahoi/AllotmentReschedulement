<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_DocumentFinalViewPIPFIN.ascx.cs" Inherits="Allotment.UC_DocumentFinalViewPIPFIN" %>
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


<div class="panel panel-default">
    <div class="panel-heading font-bold text-center">
        Documents Uploaded       
    </div>
</div>
<div class="form-group">
   
    <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top:3px;">
        <asp:GridView ID="GridView1" runat="server"
                            CssClass="table table-striped table-bordered  request-table myreq-col"                         
                            AllowSorting="True"
                            AutoGenerateColumns="False"
                            
                            GridLines="Horizontal"  
                            Width="100%"
                            ItemStyle-Width="10%">
                            <Columns>
                               
                              <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:BoundField DataField="ServiceTimeLinesDocuments" HeaderText="Document Name" />
                                                    
                    <asp:TemplateField HeaderText="View Doc">
                                
                                
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper22" Target="_blank" NavigateUrl='<%# string.Format(Eval("Path").ToString()) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
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
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
        </div>
</div>