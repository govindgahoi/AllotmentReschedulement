<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_RaiseDemandPlusObjection.ascx.cs" Inherits="Allotment.UC_RaiseDemandPlusObjection" %>
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

<div style="min-height: 300px;border: 4px solid #ccc;margin-bottom: 5px;position:relative;z-index:1;">
    <div class="form-group">
                    <label class="col-md-2 col-sm-6 col-xs-6">
                        Objection Type: 
                    </label>
                    <div class="col-md-10 col-sm-6 col-xs-6">
                        <asp:DropDownList ID="drp_NMObjectionType" runat="server" CssClass="input-sm similar-select1 margin-left-z">
                            
                        </asp:DropDownList>
                        
                    </div>
                </div>
     <div class="clearfix"></div>
             <div class="form-group">
                    <label class="col-md-2 col-sm-6 col-xs-6">
                        Objection Type: 
                    </label>
                    <div class="col-md-10 col-sm-6 col-xs-6">
                        <asp:DropDownList ID="drpObjection" runat="server" OnSelectedIndexChanged="drpObjection_SelectedIndexChanged" AutoPostBack="true" CssClass="input-sm similar-select1 margin-left-z">
                           
                        </asp:DropDownList>
                        
                    </div>
                </div>

<div runat="server" id="OthrsDiv" visible="false">
       <div class="clearfix"></div>
                <hr class="myhrline" />
       <div class="form-group">
                    <label class="col-md-2 col-sm-6 col-xs-6">
                        Objection Description: 
                    </label>
                    <div class="col-md-10 col-sm-6 col-xs-6">
                        <asp:TextBox runat="server" id="txtObjectionDesc" MaxLength="300" TextMode="MultiLine" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                        
                    </div>
                </div>
     <div class="clearfix"></div>
                <hr class="myhrline" />
</div>
<div runat="server" id="DuesDiv" visible="false">
       <div class="clearfix"></div>
                <hr class="myhrline" />
       <div class="form-group">
                   
                    <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:GridView ID="AllotteePaymentSummaruGrid" runat="server" ShowFooter="true" AutoGenerateColumns="false"  CssClass="table table-striped table-bordered table-hover request-table" OnRowDataBound="AllotteePaymentSummaruGrid_RowDataBound">
                                    <Columns>

                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField = "PaymentName"   HeaderText = "Payment Head"/>
                                        <asp:BoundField DataField = "Demanded"      HeaderText = "Demanded"    />
                                        <asp:BoundField DataField = "Paid"          HeaderText = "Paid"        />                                      
                                        <asp:BoundField DataField = "Outstanding"   HeaderText = "Outstanding" />
                                       
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                    </div>
                </div>
        <div class="clearfix"></div>
                <hr class="myhrline" />
       <div class="form-group">
                    <label class="col-md-2 col-sm-6 col-xs-6">
                        Objection Description: 
                    </label>
                    <div class="col-md-10 col-sm-6 col-xs-6">
                        <asp:TextBox runat="server" id="TextBox1" TextMode="MultiLine" CssClass="input-sm similar-select1 margin-left-z" MaxLength="300"></asp:TextBox>
                        
                    </div>
                </div>
     <div class="clearfix"></div>
                <hr class="myhrline" />



</div>
<div id="docdiv" runat="server" visible="false">
 <div class="form-group">
                     <label class="col-md-2 text-right">
                                                       
                                                       Objection Document :
                                                    </label>
                                                    <div class="col-md-5">
                                                       <asp:FileUpload ID="FileUploadLoaction" runat="server"  CssClass="input-sm similar-select"  ToolTip="Upload" accept=".pdf" ></asp:FileUpload>
                                                    </div>
                                                     <div class="col-md-5">
                                                    <span>
                                                        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" CssClass="btn btn-primary ey-bg btn-sm" Style="margin: 0 1px 0 0; width: 65px;" Text="Upload" />
                                                        
                                                        <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                                                    </span>  
                                                </div>
                </div>
     <div class="clearfix"></div>
                <hr class="myhrline" />
</div>
              
                <div class="clearfix"></div>
                 <span class="pull-right"><asp:Button runat="server" Text="View/Update Allottee Ledger" OnClick="Button1_Click" id="Button1" class="btn-primary btn-sm margin-left-z" style="margin: 7px 126px;position:absolute;z-index:2;bottom:0;right:0;" />&nbsp;<asp:Button runat="server" Text="Raise Objection" id="btnSend" class="btn-primary btn-sm margin-left-z" style="margin: 7px 10px;position:absolute;z-index:2;bottom:0;right:0;"  OnClientClick="javascript:return confirm('Please check details before submitting. After Submitting you cannot make any changes.');" OnClick="btnSend_Click"/></span>
 <div class="clearfix"></div>
</div>
<div class="clearfix"></div>
<hr class="myhrline" />
<div class="panel panel-default">
    <div class="panel-heading font-bold">
        Previous Due (If any)       
    </div>
</div>
<div class="form-group">
   
    <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top:3px;">
        <asp:GridView ID="GridView2" runat="server"
                            CssClass="table table-striped table-bordered  request-table myreq-col"                         
                            AllowSorting="True"
                            AutoGenerateColumns="False"
                            DataKeyNames="Id,DemandNo,ObjID"
                            GridLines="Horizontal"  OnRowDataBound="GridView2_RowDataBound"
                            Width="100%"
                            ItemStyle-Width="10%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Style="cursor: pointer" ImageUrl="~/images/plus.png" />
                                
                                        <asp:Panel ID="pnlAllotmentRequest" runat="server" Style="display: none">
                                            <asp:GridView ID="GridViewAllotmentRequest" runat="server" AutoGenerateColumns="False" CssClass="request-table table table-hover table-bordered cm-table-heading myreq-col">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="PayDesc" HeaderText="Payment Description" />
                                                    <asp:BoundField DataField="Amount" ItemStyle-Wrap="false" HeaderStyle-CssClass="text-center-imp"  HeaderText="Amount"/>
                                                        
                                                </Columns>
                                            </asp:GridView>

                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>



                              <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:BoundField DataField="DemandNo" HeaderText="Demand No" />
                                                    <asp:BoundField DataField="AllotteeId" ItemStyle-Wrap="false" HeaderStyle-CssClass="text-center-imp"  HeaderText="Allottee ID"/>
                                                    <asp:BoundField DataField="DueAmount" HeaderText="Total Amount" HeaderStyle-CssClass="text-center-imp"   />
                                                    <asp:BoundField DataField="CreatedBy" HeaderText="Created By" HeaderStyle-CssClass="text-center-imp"    />
                                                    <asp:BoundField DataField="Status" HeaderText="Payment Status" HeaderStyle-CssClass="text-center-imp" />
                                                    
                   
                                      <asp:TemplateField HeaderText="View Objection Doc">
                                                            
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper3" Target="_blank" NavigateUrl='<%# string.Format("~/ViewerObjectionInternalDoc.aspx?ID={0}",HttpUtility.UrlEncode(Eval("ObjID").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField> 
                                    <asp:TemplateField HeaderText="View Response Doc">
                               
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/ViewerObjectionPaymentDoc.aspx?ServiceReqNo={0}&DocType=PaymentDue",HttpUtility.UrlEncode(Eval("DemandNo").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
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


<div class="clearfix"></div>
<hr class="myhrline" />
<div class="panel panel-default">
    <div class="panel-heading font-bold">
        Previous Objections (If any)       
    </div>
</div>
<div class="form-group">
   
    <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top:3px;">
        <asp:GridView ID="GridView1" runat="server"
                            CssClass="table table-striped table-bordered  request-table myreq-col"                         
                            AllowSorting="True"
                            AutoGenerateColumns="False"
                            DataKeyNames="Id"
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


                                                    <asp:BoundField DataField="Objection" HeaderText="Objection Raised" />
                                                    <asp:BoundField DataField="RaisedOnDate" ItemStyle-Wrap="false" HeaderStyle-CssClass="text-center-imp"  HeaderText="Raised On"/>
                                                    <asp:BoundField DataField="RaisedBy" ItemStyle-Wrap="false" HeaderStyle-CssClass="text-center-imp"  HeaderText="Raised By"/>
                                                    <asp:BoundField DataField="Response" HeaderText="Response Given" HeaderStyle-CssClass="text-center-imp"   />
                                                    <asp:BoundField DataField="ResponseOnDate" HeaderText="Response Date" HeaderStyle-CssClass="text-center-imp"    />
                                                    <asp:BoundField DataField="ResponseBy" HeaderText="Reponse By" HeaderStyle-CssClass="text-center-imp" />
                                                    
                    <asp:TemplateField HeaderText="View Objection Doc">
                                
                                
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper22" Target="_blank" NavigateUrl='<%# string.Format("~/ViewerObjectionInternalDoc.aspx?ID={0}",HttpUtility.UrlEncode(Eval("ID").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField> 
                                <asp:TemplateField HeaderText="View Response Doc">
                                
                                
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/ViewerObjectionGDoc.aspx?ID={0}",HttpUtility.UrlEncode(Eval("ID").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
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




