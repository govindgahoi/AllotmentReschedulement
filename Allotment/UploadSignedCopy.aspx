<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="UploadSignedCopy.aspx.cs" Inherits="Allotment.UploadSignedCopy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div><code><asp:Label ID="Head1" runat="server"></asp:Label></code>
       <asp:GridView ID="GridView2" runat="server"
                        CssClass="table table-striped table-bordered table-hover request-table"
                        AllowPaging="True"
                        PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"
                        AutoGenerateColumns="False"
                        DataKeyNames="ServiceRequestNO,Service"
                        GridLines="Horizontal" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="10"
                        OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound"
                        Width="95%"
                        OnRowDeleting="GridView2_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                           
                            <asp:BoundField DataField="ServiceRequestNo" HeaderText="ServiceRequestNo" SortExpression="ServiceRequestNo" />
                            <asp:BoundField DataField="Name" HeaderText="Doc Name" SortExpression="Name" />
                            
                            
                            
                            <asp:TemplateField HeaderText="Action">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle  />
                                <ItemTemplate>
                                   
     <span class="col-md-10"><asp:FileUpload ID="FileUpload4" runat="server" /></span><span class="col-md-2"><asp:LinkButton ID="imgdocuments" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="Upload" Text='<i class="fa fa-upload" aria-hidden="true"></i>' /></span>                                         


                                </ItemTemplate>
                            </asp:TemplateField>




                            <asp:TemplateField>
                                <HeaderStyle />
                                <HeaderTemplate>
                                    <asp:Label ID="hlblimg" runat="server" Text=""></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbView"     runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument"  usesubmitbehavior="true" Text='<i class="fa fa-download" aria-hidden="true"></i>' /> / 
                                    <asp:LinkButton ID="lbView1"    runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument"    usesubmitbehavior="true"   Text =''><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton> / 
                                    <asp:LinkButton ID="lbDelete"   runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="Delete"      OnClientClick="javascript:return confirm('Are you sure wanted to delete?');"  usesubmitbehavior="true"    Text='<i class="fa fa-times" aria-hidden="true"></i>' />
                           
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
    <div class="row" style="margin-top:15px;">

                    <div class="text-left">
                     
        <%-- <asp:Button runat="server" Visible="false" ID="btnSample" Text="" OnClick="GetServiceChecklists_SP_BY_Condtion_Function" />  --%>    

                        <asp:HiddenField ID="hfName" runat="server" />
                        <ul class="nav nav-pills myul-tabs" style="margin-left:0;">
                            <asp:Panel ID="pnlDemo" runat="server"></asp:Panel>
                        </ul>

                    </div>
                </div>
              
    <div class="panel">
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="panel-heading font-bold" style="text-align: center;">
                    Document Viewer                        
                </div>

                <div class="bp-divviewer">
                    <asp:Literal ID="ltEmbed" runat="server" />
                </div>
            </div>
        </div>
    </div>



</asp:Content>
