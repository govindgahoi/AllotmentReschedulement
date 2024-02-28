<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_NoticeDetails.ascx.cs" Inherits="Allotment.UC_NoticeDetails" %>


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
<div class="panel-heading font-bold" style="padding: 7px 3px !important;">Applicant Notice Reply Details</div>

<div class="col-md-12 col-sm-12 col-xs-12" id="DivP">
    <div class="form-group">
        <asp:GridView ID="gvNotice" runat="server"
            CssClass="table table-striped table-bordered table-hover request-table request-table"
            OnRowCommand="gvNotice_RowCommand"
            AllowSorting="True"
            AutoGenerateColumns="False"
            DataKeyNames="ServiceRequestNO,NoticeID"
            GridLines="Horizontal"
            Width="100%" OnRowDataBound="gvNotice_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="NoticeID" HeaderText="Notice ID" SortExpression="NoticeID" />
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request NO" SortExpression="ServiceRequestNO" />
                <asp:BoundField DataField="Noticetype" HeaderText="Notice Type" SortExpression="Noticetype" />
                <asp:BoundField DataField="AppointmentDesc" HeaderText="Notice Description" SortExpression="AppointmentDesc" />
                <asp:BoundField DataField="NoticeReplyDetails" HeaderText="Notice Reply Details" SortExpression="NoticeReplyDetails" />
                <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNoticeID" Text='<%#Eval("NoticeID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CreatedOn" HeaderText="Created On" SortExpression="CreatedOn" />
                <asp:TemplateField>
                    <HeaderStyle />
                    <HeaderTemplate>
                        <asp:Label ID="hlblimg" runat="server" Text="Applicant Document"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lblApplicantDoc" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocumentApplicant" usesubmitbehavior="true" Text='<i class="fa fa-download" aria-hidden="true"></i>' />/ 
                        <asp:LinkButton ID="lbApplicantDocdownload" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocumentApplicant" usesubmitbehavior="true" Text=''><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle />
                    <HeaderTemplate>
                        <asp:Label ID="hlblimg" runat="server" Text="Notice Letter"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" usesubmitbehavior="true" Text='<i class="fa fa-download" aria-hidden="true"></i>' />/ 
                                                                        <asp:LinkButton ID="lbView1" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument" usesubmitbehavior="true" Text=''><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>
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
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <div class="panel-body">
            <asp:Literal ID="ltviewer" runat="server" />
        </div>
    </div>
</div>




<div class="clearfix"></div>
