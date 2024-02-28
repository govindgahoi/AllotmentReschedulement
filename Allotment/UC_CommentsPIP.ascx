<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_CommentsPIP.ascx.cs" Inherits="Allotment.UC_CommentsPIP" %>


<script type='text/javascript'>
      

        function PrintElem() {

            Popup($('#DivP').html());
        }

        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=1000');
            mywindow.document.write('<html><head><title style="font-weight:bold;">Land Allotment Application</title>');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/bootstrap.min.css\" type=\"text/css\" />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/theme.css\" type=\"text/css\"  />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/print.css\" type=\"text/css\"  />');
            mywindow.document.write('</head><body >');
            mywindow.document.write(data);
            mywindow.document.write('</body></html>');

            setTimeout(function () {
                mywindow.print();
                mywindow.close();
            }, 1000);


            return true;
        }

    </script>
	    
<div class="col-md-12 col-sm-12 col-xs-12" id="DivP">
<div class="panel-heading font-bold" style="padding:7px 3px !important;">Commeettee Member Who Approve MOM</div>                    
                    
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


                                                    <asp:BoundField DataField="Transfer_To" HeaderText="Committee Member" />
                                                    <asp:BoundField DataField="CommentDate" HeaderText="Uploaded On" />
                                                   
                                 
                   <%--  <asp:TemplateField HeaderText="View Doc">
                                
                                
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper22" Target="_blank" NavigateUrl='<%# string.Format(Eval("DocPath").ToString()) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField> 
                      --%>          
                               
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

    <br /><br />

                    </div>
        


<div class="panel-heading font-bold" style="padding:7px 3px !important;">Comments And Recommendations</div>                    
                    <div class="col-md-12 col-sm-12 col-xs-12" id="DivP">
                           <asp:Label ID="DivNotesheet" runat="server" />
                    </div>
               

                    



				<div class="clearfix"></div>