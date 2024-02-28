<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Appontments.ascx.cs" Inherits="Allotment.UC_Appontments" %>


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
<div class="panel-heading font-bold" style="padding:7px 3px !important;">List Of Appointments</div>
						                        
                    <div class="col-md-12 col-sm-12 col-xs-12" id="DivP">                   
                         <asp:GridView ID="GridView1" runat="server"
             CssClass="table table-striped table-bordered table-hover request-table request-table"
           
            AllowSorting="True"
            AutoGenerateColumns="False"
            DataKeyNames="ID"
            GridLines="Horizontal"
            Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:BoundField DataField="AppointmentType" HeaderText="Appointment Type" SortExpression="AppointmentType" />
                <asp:BoundField DataField="AppointmentDesc" HeaderText="Appointment Description" SortExpression="AppointmentDesc" />
                <asp:BoundField DataField="CreatedOn"       HeaderText="Created On" SortExpression="CreatedOn" />
                <asp:BoundField DataField="AppStatus"       HeaderText="Appointment Status" SortExpression="AppStatus" />
                
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
               



				<div class="clearfix"></div>