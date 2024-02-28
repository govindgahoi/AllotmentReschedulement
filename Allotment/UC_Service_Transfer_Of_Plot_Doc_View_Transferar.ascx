<%@ Control Language="C#" AutoEventWireup="true" 
            CodeBehind ="UC_Service_Transfer_Of_Plot_Doc_View_Transferar.ascx.cs" 
            Inherits="Allotment.UC_Service_Transfer_Of_Plot_Doc_View_Transferar" %>

<style>
    .active{
    	background:#ccc!important;
    }
</style>


                <div class="panel-body">                



                <div class="" style="min-height: 236px;max-height:236px;overflow-y:scroll;">
                    <asp:GridView ID="GridView2" runat="server"
                        CssClass="table table-striped table-bordered table-hover request-table"
                        AutoGenerateColumns="False"
                        DataKeyNames="ServiceCheckListsID,DocumentID"
                        GridLines="Horizontal"
                        OnRowCommand="GridView2_RowCommand" 
                        Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblServiceCheckLists" Text='<%#Eval("ServiceCheckListsID") %>'></asp:Label>
                                <asp:Label runat="server" ID="DocumentID"  Text='<%#Eval("DocumentID") %>'></asp:Label>
                        
                                    </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblServiceTimeLines" Text='<%#Eval("ServiceTimeLinesID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ServiceTimeLinesCondition" HeaderText="Checklist" SortExpression="ServiceTimeLinesCondition" />
                            <asp:BoundField DataField="ServiceTimeLinesDocuments" HeaderText="Checklist Description" SortExpression="ServiceTimeLinesDocuments" />
                            <asp:TemplateField >
                                <HeaderStyle />
                                <HeaderTemplate>
                                    <asp:Label ID="hlblimg" runat="server" Text=""></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbView"     runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument"  usesubmitbehavior="true" Text='<i class="fa fa-download" aria-hidden="true"></i>' /> / 
                                    <asp:LinkButton ID="lbView1"    runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument"    usesubmitbehavior="true"   Text =''><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>  
                                   
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
                 
              

                <div class="row">
                               <div class="col-md-12 col-sm-12 col-xs-12">
                                   <div class="panel-heading" style="margin-top: 5px;">Viewer :</div>
                                   <div class="bp-divviewer">
                                       <asp:Literal ID="ltEmbed" runat="server" />
                                   </div>
                               </div>
                           </div>


            </div>


