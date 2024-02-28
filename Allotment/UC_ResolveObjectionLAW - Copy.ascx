<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ResolveObjectionLAW.ascx.cs" Inherits="Allotment.UC_ResolveObjectionLAW" %>
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
     .fa
    {
        font-size:20px !important;
    }
</style>






	   <cc1:MessageBox ID="MessageBox1" runat="server" />

<div runat="server" id="CurrentObjection_Div">

       <div class="panel panel-default">
                                             <div class="panel-heading">Objection Raised By UPSIDA <span style="float:right;"><asp:LinkButton ID="lnkView1" runat="server" Class="fa fa-file-pdf-o" aria-hidden="true" OnClick="lnkView1_Click"></asp:LinkButton></span></div>
                                             <asp:TextBox ID="txtclarification" CssClass="similar-select1 margin-left-z" Height="100px" Enabled="false" runat="server" TextMode="MultiLine"></asp:TextBox>
                                             <hr class="separation" />
                                             <div class="panel-heading">Your Response</div>
                                             <asp:TextBox ID="txtResponse" CssClass="similar-select1 margin-left-z" Height="100px" runat="server" TextMode="MultiLine"></asp:TextBox>
                                             <hr class="separation" />
                                         </div>
                                        <div class="form-group">
                                                <div class="col-md-6 col-sm-6 col-xs-6">
                                                    <asp:FileUpload ID="fileupload" Width="100%" CssClass="form-control" runat="server" />                                                    
                                                </div>
                                                <div class="col-md-6 col-sm-6 col-xs-6">
                                                    <span>
                                                         <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="rounded-0 btn btn-primary" style="padding:2px 15px;margin-top: 5px;" OnClick="btnUpload_Click"/> 
                                                                    <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                                                               
                                                    </span>
                                                </div>
                                        </div>
    <div class="clearfix"></div>
                                         <hr class="separation" />
     <div class="form-group">
         <div class="col-md-12 col-sm-12 col-xs-12 text-right">
             <asp:Button ID="btnSubmit" runat="server"  Text="Submit Application" CssClass="rounded-0 btn btn-primary" style="padding:2px 15px;margin-top: 5px;" OnClick="btnSubmit_Click"/> 
                                                         
             </div>
         </div>
                                         <div class="clearfix"></div>
                                         <hr class="separation" />
</div>
<br /><br />
<br /><br />



<div class="panel panel-default">
    <div class="panel-heading font-bold">
        Previously Cleared Objection (If any)       
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
                                     <asp:HyperLink runat="server" ID="Hyper22" Target="_blank" NavigateUrl='<%# string.Format(Eval("UserDocPath").ToString()) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                  </ItemTemplate>
                            </asp:TemplateField> 
                                <asp:TemplateField HeaderText="View Response Doc">
                               
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format(Eval("ApplicantDocPath").ToString()) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
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



