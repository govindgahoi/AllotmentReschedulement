<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="LandAllottementCompleted.aspx.cs" Inherits="Allotment.LandAllottementCompleted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
    <script type="text/javascript">
    
        function PrintElem() {

            Popup($('#DivP').html());
        }
        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=1000');
            mywindow.document.write('<html><head><title style="font-weight:bold;">Land Allotment Completed</title>');
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="form-group" style="background: #dadada;padding: 2px 0;margin-bottom: 3px;">
                <div class="">
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        Regional Office :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:DropDownList runat="server" ID="ddloffice" style="background:#fff;" CssClass="input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="Regional_Changed"></asp:DropDownList>
                    </div>
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        Industrial Area :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:DropDownList runat="server" ID="drpdwnIA" style="background:#fff;" CssClass="input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged" ></asp:DropDownList>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        Transaction From Date :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:TextBox runat="server" ID="txtTransactionFromDate" style="background:#fff;" CssClass="date1 input-sm similar-select1"></asp:TextBox>
                    </div>
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        To Date :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:TextBox runat="server" ID="txtTransactionToDate" style="background:#fff;" CssClass="date1 input-sm similar-select1"></asp:TextBox>
                    </div>
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        Search Keyword :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:TextBox runat="server" ID="txtSearch" style="background:#fff;" CssClass="input-sm similar-select1"></asp:TextBox>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="col-md-12 col-sm-2 col-xs-12">
                        <asp:Button ID="btnFetch" runat="server" Text="Fetch" Style="padding:2px 27px;margin:10px 0;" CssClass="btn-primary ey-bg pull-right" OnClick="btnFetch_Click" />
                    </div>
                    
                </div>
                <div class="clearfix"></div>
            </div>
        <code>land Allottement Completed</code>
        <div style="max-height:600px;overflow-y:auto;" class="table-responsive">
            <asp:GridView ID="gvdCompleted" runat="server"
            CssClass="table table-striped table-bordered table-hover request-table request-table"
            AllowSorting="True"
            AutoGenerateColumns="False"
            DataKeyNames="ServiceRequestNO"
            GridLines="Horizontal" 
            Width="100%" OnSorting="gvdCompleted_Sorting"
            OnRowDeleting="gvdCompleted_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                <asp:BoundField DataField="IAName" HeaderText="Industrial Area" SortExpression="IAName" />
                <asp:BoundField DataField="APPLICANTNAME" HeaderText="APPLICANT NAME" SortExpression="APPLICANTNAME" />
                <asp:BoundField DataField="PlotNo" ItemStyle-HorizontalAlign="Justify" HeaderText="Plot Number" SortExpression="PlotNo" />
                <asp:BoundField DataField="Allotmentletterno" HeaderText="Allotmentletter Number" SortExpression="Allotmentletterno" />
                <asp:BoundField DataField="AllotmentletterIssueDate" HeaderText="Allotmentletter IssueDate" SortExpression="AllotmentletterIssueDate" />
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
</asp:Content>
