<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="Repository.aspx.cs" Inherits="Allotment.Repository" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register assembly="ProudMonkey.Common.Controls" namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <cc1:MessageBox ID="MessageBox1" runat="server" /> 
     <div class="panel panel-default">
                                    <div class="panel-heading font-bold text-center">Repositry</div>


<%--         OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="10"
                        OnRowCommand="All_Repository_RowCommand"--%>

<%--                                    <asp:LinkButton ID="lbView1"    runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument"    usesubmitbehavior="true"   </asp:LinkButton> / --%>



            <div class="panel-body" style="margin-top: 10px;">
                                        <div class="table-responsive">                                            
                                              <asp:GridView ID="All_Repository" runat="server"
                        CssClass="table table-striped table-bordered table-hover request-table"
                        AllowPaging="True"
                        PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"
                        AutoGenerateColumns="false"
                        DataKeyNames="ServiceId,ServiceTimeLinesActivity,ServiceRequestNo"
                        GridLines="Horizontal"  
                        Width="95%">
                        <Columns>

                            <asp:TemplateField>
                                    <ItemTemplate> <%#Container.DataItemIndex+1 %></ItemTemplate>
                             </asp:TemplateField>


                            <asp:BoundField DataField="ServiceTimeLinesActivity" HeaderText="Document Type" />
                            <asp:BoundField DataField="ServiceRequestNo" HeaderText="Ref Service NO" />
                            <asp:BoundField DataField="CreatedOn" HeaderText="On Date" />


                            <asp:TemplateField HeaderText="View">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/LetterView_ByServiceRequestNo.aspx?ServiceRequestNo={0}",HttpUtility.UrlEncode(Eval("ServiceRequestNo").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
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








                                             <asp:GridView ID="GridView6" runat="server"
                                                                  PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"
                                                                  AllowPaging="True"
                                                                 PageSize="20"
                                                                    AllowSorting="True"
                                                                    AutoGenerateColumns="False"
                                                                   CssClass="table  Allottee_master_grid  table-bordered table-hover request-table"
                                                                    GridLines="Horizontal"
                                                                    Width="95%" >
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                       

                                                                        <asp:TemplateField HeaderText="Allottee ID">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="lblServiceTimeLines" Text='<%#Eval("AllotmentLetterNo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:BoundField DataField="AllotmentLetterNo" HeaderText="Applicant Id" SortExpression="AllotmentLetterNo" Visible="false" />
                                                                         <asp:BoundField DataField="DocName" HeaderText="Document Name" SortExpression="DocName" ItemStyle-HorizontalAlign="Center"  />
                                                                        <asp:BoundField DataField="DocNo" HeaderText="Allotment Ref No" SortExpression="DocNo"  />
                           
                            
                                                                        <asp:BoundField DataField="DocDate" HeaderText="Document Date" SortExpression="AllotmentDate"  />
                            
                                                                        <asp:TemplateField ItemStyle-CssClass="text-center-imp">
                                                                            <HeaderStyle />
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="hlblimg" runat="server" Text="Document"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/AllotmentLetterView.aspx?AllotteeId={0}",HttpUtility.UrlEncode(Eval("AllotmentLetterNo").ToString())) %>' Text="View Details"></asp:HyperLink>
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



<span class="hide">

                                    <div class="panel-heading font-bold">1. Document Related Allotments</div>
                                    <div class="panel-body" style="margin-top: 10px;">
                                        <div class="table-responsive">                                            
                                                     <asp:GridView ID="GridView2" runat="server" Visible="false"
                                                                  PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"
                                                                  AllowPaging="True"
                                                                 PageSize="20"
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
                                                                        <asp:TemplateField HeaderText="Doc ID" Visible="false">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="lblServiceCheckLists" Text='<%#Eval("DocumentId") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="lblServiceTimeLines" Text='<%#Eval("AllotmentLetterNo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:BoundField DataField="AllotmentLetterNo" HeaderText="Applicant Id" SortExpression="AllotmentLetterNo" Visible="false" />
                                                                         <asp:BoundField DataField="DocName" HeaderText="Document Name" SortExpression="DocName" ItemStyle-HorizontalAlign="Center"  />
                                                                        <asp:BoundField DataField="DocNo" HeaderText="Document Ref No" SortExpression="DocNo"  />
                           
                            
                                                                        <asp:BoundField DataField="AllotmentDate" HeaderText="Document Date" SortExpression="AllotmentDate" DataFormatString="{0:dd-MMM-yyyy}" />
                            
                                                                        <asp:TemplateField ItemStyle-CssClass="text-center-imp">
                                                                            <HeaderStyle />
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="hlblimg" runat="server" Text="Document"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbView" runat="server" OnClientClick="openInNewTab();"  CommandArgument='<%#Eval("DocumentId")+","+ Eval("AllotmentLetterno") %>' CommandName="selectDocument" class="fa fa-cloud-download" aria-hidden="true"></asp:LinkButton>
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


                                             <asp:GridView ID="AllotmentGrid" runat="server"
                                                                  PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"
                                                                  AllowPaging="True"
                                                                 PageSize="20"
                                                                    AllowSorting="True"
                                                                    AutoGenerateColumns="False"
                                                                   CssClass="table  Allottee_master_grid  table-bordered table-hover request-table"
                                                                    GridLines="Horizontal"
                                                                    Width="95%" >
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                       

                                                                        <asp:TemplateField HeaderText="Allottee ID">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="lblServiceTimeLines" Text='<%#Eval("AllotmentLetterNo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:BoundField DataField="AllotmentLetterNo" HeaderText="Applicant Id" SortExpression="AllotmentLetterNo" Visible="false" />
                                                                         <asp:BoundField DataField="DocName" HeaderText="Document Name" SortExpression="DocName" ItemStyle-HorizontalAlign="Center"  />
                                                                        <asp:BoundField DataField="DocNo" HeaderText="Allotment Ref No" SortExpression="DocNo"  />
                           
                            
                                                                        <asp:BoundField DataField="DocDate" HeaderText="Document Date" SortExpression="AllotmentDate"  />
                            
                                                                        <asp:TemplateField ItemStyle-CssClass="text-center-imp">
                                                                            <HeaderStyle />
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="hlblimg" runat="server" Text="Document"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/AllotmentLetterView.aspx?AllotteeId={0}",HttpUtility.UrlEncode(Eval("AllotmentLetterNo").ToString())) %>' Text="View Details"></asp:HyperLink>
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
                                           
                                            <div class="panel-heading font-bold">2. Document Related to Demands</div>
                                            <div class="panel-body" style="margin-top: 10px;">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="GridView1" runat="server" Visible="false"
                                                                  PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"
                                                                  AllowPaging="True"
                                                                 PageSize="20"
                                                                    AllowSorting="True"
                                                                    AutoGenerateColumns="False"
                                                                   CssClass="table  Allottee_master_grid  table-bordered table-hover request-table"
                                                                    GridLines="Horizontal" 
                                                                    OnRowCommand="GridView1_RowCommand"  OnPageIndexChanging="OnPageIndexChanging1"  OnRowDataBound="GridView1_RowDataBound"
                                                                    Width="95%" >
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Doc ID" Visible="false">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="lblServiceCheckLists" Text='<%#Eval("DocumentId") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="lblServiceTimeLines" Text='<%#Eval("AllotmentLetterNo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:BoundField DataField="AllotmentLetterNo" HeaderText="Applicant Id" SortExpression="AllotmentLetterNo" Visible="false" />
                                                                         <asp:BoundField DataField="DocName" HeaderText="Document Name" SortExpression="DocName" ItemStyle-HorizontalAlign="Center"  />
                                                                        <asp:BoundField DataField="DocNo" HeaderText="Document Ref No" SortExpression="DocNo"  />
                           
                            
                                                                        <asp:BoundField DataField="AllotmentDate" HeaderText="Document Date" SortExpression="AllotmentDate" DataFormatString="{0:dd-MMM-yyyy}" />
                            
                                                                        <asp:TemplateField ItemStyle-CssClass="text-center-imp">
                                                                            <HeaderStyle />
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="hlblimg" runat="server" Text="Document"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbView" runat="server"  OnClientClick="openInNewTab();"  CommandArgument='<%#Eval("DocumentId")+","+ Eval("AllotmentLetterno") %>' CommandName="selectDocument" class="fa fa-cloud-download" aria-hidden="true"></asp:LinkButton>
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
                                            <div class="panel-heading font-bold">3. Lease & Possession</div>
                                            <div class="panel-body" style="margin-top: 10px;">
                                                <div class="table-responsive">
                                                         <asp:GridView ID="GridView3" runat="server" 
                                                                  PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"
                                                                  AllowPaging="True"
                                                                 PageSize="20"
                                                                    AllowSorting="True"
                                                                    AutoGenerateColumns="False"
                                                                   CssClass="table  Allottee_master_grid  table-bordered table-hover request-table"
                                                                    GridLines="Horizontal" 
                                                                    OnRowCommand="GridView3_RowCommand"  OnPageIndexChanging="OnPageIndexChanging3"  OnRowDataBound="GridView3_RowDataBound"
                                                                    Width="95%" >
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Doc ID" Visible="false">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="lblServiceCheckLists" Text='<%#Eval("DocumentId") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="lblServiceTimeLines" Text='<%#Eval("AllotmentLetterNo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:BoundField DataField="AllotmentLetterNo" HeaderText="Applicant Id" SortExpression="AllotmentLetterNo" Visible="false" />
                                                                         <asp:BoundField DataField="DocName" HeaderText="Document Name" SortExpression="DocName" ItemStyle-HorizontalAlign="Center"  />
                                                                        <asp:BoundField DataField="DocNo" HeaderText="Document Ref No" SortExpression="DocNo"  />
                           
                            
                                                                        <asp:BoundField DataField="AllotmentDate" HeaderText="Document Date" SortExpression="AllotmentDate" DataFormatString="{0:dd-MMM-yyyy}" />
                            
                                                                        <asp:TemplateField ItemStyle-CssClass="text-center-imp">
                                                                            <HeaderStyle />
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="hlblimg" runat="server" Text="Document"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbView" runat="server" OnClientClick="openInNewTab();"  CommandArgument='<%#Eval("DocumentId")+","+ Eval("AllotmentLetterno") %>' CommandName="selectDocument" class="fa fa-cloud-download" aria-hidden="true"></asp:LinkButton>
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
                                            <div class="panel-heading font-bold">4. Building Plan Related</div>
                                            <div class="panel-body" style="margin-top: 10px;">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="GridView4" runat="server" Visible="false" 
                                                                  PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"
                                                                  AllowPaging="True"
                                                                 PageSize="20"
                                                                    AllowSorting="True"
                                                                    AutoGenerateColumns="False"
                                                                   CssClass="table  Allottee_master_grid  table-bordered table-hover request-table"
                                                                    GridLines="Horizontal" 
                                                                    OnRowCommand="GridView4_RowCommand"  OnPageIndexChanging="OnPageIndexChanging4"  OnRowDataBound="GridView4_RowDataBound"
                                                                    Width="95%" >
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
                                                                                <asp:Label runat="server" ID="lblServiceTimeLines" Text='<%#Eval("AllotmentLetterNo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:BoundField DataField="AllotmentLetterNo" HeaderText="Applicant Id" SortExpression="AllotmentLetterNo" Visible="false" />
                                                                         <asp:BoundField DataField="DocName" HeaderText="Document Name" SortExpression="DocName" ItemStyle-HorizontalAlign="Center"  />
                                                                        <asp:BoundField DataField="DocNo" HeaderText="Document Ref No" SortExpression="DocNo"  />
                           
                            
                                                                        <asp:BoundField DataField="DocDate" HeaderText="Document Date" SortExpression="AllotmentDate" DataFormatString="{0:dd-MMM-yyyy}" />
                            
                                                                        <asp:TemplateField ItemStyle-CssClass="text-center-imp">
                                                                            <HeaderStyle />
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="hlblimg" runat="server" Text="Document"></asp:Label>
                                                                            </HeaderTemplate>
                                                                           <ItemTemplate>
                                                                                <asp:HyperLink runat="server" ID="Hyper2" NavigateUrl='<%# string.Format("~/BuildingPlanLetterView.aspx?AllotteeId={0}",HttpUtility.UrlEncode(Eval("AllotmentLetterNo").ToString())) %>' Text="View Details"></asp:HyperLink>
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
                                                     <asp:GridView ID="BuildingGrid" runat="server" 
                                                                  PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"
                                                                  AllowPaging="True"
                                                                  PageSize="20"
                                                                  AllowSorting="True"
                                                                  AutoGenerateColumns="False"
                                                                  CssClass="table  Allottee_master_grid  table-bordered table-hover request-table"
                                                                  GridLines="Horizontal" 
                                                                  
                                                                  Width="95%" >
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
                                                                                <asp:Label runat="server" ID="lblServiceTimeLines" Text='<%#Eval("AllotmentLetterNo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:BoundField DataField="AllotmentLetterNo" HeaderText="Applicant Id" SortExpression="AllotmentLetterNo" Visible="false" />
                                                                         <asp:BoundField DataField="DocName" HeaderText="Document Name" SortExpression="DocName" ItemStyle-HorizontalAlign="Center"  />
                                                                        <asp:BoundField DataField="DocNo" HeaderText="Document Ref No" SortExpression="DocNo"  />
                           
                            
                                                                        <asp:BoundField DataField="DocDate" HeaderText="Document Date" SortExpression="AllotmentDate" DataFormatString="{0:dd-MMM-yyyy}" />
                            
                                                                        <asp:TemplateField ItemStyle-CssClass="text-center-imp">
                                                                            <HeaderStyle />
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="hlblimg" runat="server" Text="Document"></asp:Label>
                                                                            </HeaderTemplate>
                                                                           <ItemTemplate>
                                                                                <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/BuildingPlanLetterView.aspx?AllotteeId={0}",HttpUtility.UrlEncode(Eval("AllotmentLetterNo").ToString())) %>' Text="View Details"></asp:HyperLink>
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



    </span>
                                         </div>

    <script type="text/javascript">
    function openInNewTab() {
        window.document.forms[0].target = '_blank'; 
        setTimeout(function () { window.document.forms[0].target = ''; }, 0);
    }
</script>
</asp:Content>
