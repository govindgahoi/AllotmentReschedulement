<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ApplicationStatusHistoryLease.ascx.cs" Inherits="Allotment.UC_ApplicationStatusHistoryLease" %>


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
<div class="panel-heading font-bold" style="padding:7px 3px !important;">Status History</div>
						                        
                    <div class="col-md-12 col-sm-12 col-xs-12" id="DivP">
                         <asp:GridView ID="GridView1" runat="server"
             CssClass="table table-striped table-bordered table-hover request-table request-table"
           
            AllowSorting="True"
            AutoGenerateColumns="False"
           
            GridLines="Horizontal"
            Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:BoundField DataField="statusType" HeaderText="Status Type" SortExpression="statusType" />
                <asp:BoundField DataField="Status_Desc" HeaderText="Description" SortExpression="Status_Desc" />
                <asp:BoundField DataField="Datetime"       HeaderText="Date & Time" SortExpression="Datetime" />
                
                
                
            </Columns>
            <EmptyDataTemplate>
                No Record Available
            </EmptyDataTemplate>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
           
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
                    </div>
                    </div>
               



				<div class="clearfix"></div>