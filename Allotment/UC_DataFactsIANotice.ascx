<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_DataFactsIANotice.ascx.cs" Inherits="Allotment.UC_DataFactsIANotice" %>
<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<style>
    .modal-backdrop.fade {
        display: none !important;
    }

    .assess-min-height {
        min-height: 628px !important;
    }

    .PreviewClass {
        color: red;
    }

    .input-sm {
        height: 20px !important;
    }

    .request-table tr th[colspan='4'] {
        padding: 0 !important;
    }
</style>
<script type="text/javascript">
    $(document).ready(function () {
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
    });

    function PageLoaded(sender, args) {
        $(".chosen").chosen();

        $(".MultiSelect").chosen(



        );
    }


    function openModal() {
        $('#PlotModal').modal('show');
    }



</script>
<script type="text/javascript">
    function SetTarget() {
        document.forms[0].target = "_blank";
    }
</script>
<cc1:MessageBox ID="MessageBox1" runat="server" />



<asp:Label runat="server" ID="lblServiceReqNo" Visible="false"></asp:Label>

<div class="row" runat="server" id="PlotCancelationNotice" visible="false">

    <div class="col-md-4 col-sm-4 col-xs-6 check-left">
        <div class="div-checklist assess-min-height" style="border: 1px solid #ccc; max-height: 439px; overflow-y: auto; min-height: 628px;">
            <div class="panel-heading font-bold">
                Facts
                <asp:Button runat="server" Text="Create Notice" ID="LockNoticeData" CssClass="btn btn-sm btn-primary" OnClick="LockNoticeData_Click" Style="float: right; padding: 0px 8px !important; background: #ffc511; color: #000;" />
                <asp:Button runat="server" Text="View & Update Allottee Ledger" ID="Button1" CssClass="btn btn-sm btn-primary" OnClick="UpdateAllotteeLedger_Click"  Style="float: right; padding: 0px 8px !important; background: #ffc511; color: #000;" OnClientClick="SetTarget();" />
            </div>
            <div>
            </div>
            <br />
            <%-- Priyanshu Design And Seeting data  --%>
            <div class="panel panel-default">
                <div class="panel-body gallery">
                    <div class="">
                        <div class="col-md-12" style="padding: 0px !important;">
                            <asp:Label runat="server" ID="Label1" Visible="false"></asp:Label>
                            <table class="table table-striped table-responsive table-bordered table-hover request-table">
                                <tr>
                                    <th colspan="4">
                                        <div class="panel-heading font-bold">Clause</div>
                                    </th>
                                </tr>
                                <tr>
                                    <td>LeaseDeed  Date</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtLeaseDeedDate" CssClass="date input-sm" Width="80%" Text='<%#Eval("LeaseDeedDate") %>'></asp:TextBox>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>Notice Subject</td>
                                    <td>
                                        <asp:ListBox runat="server" ID="drpAppointmentType" CssClass="MultiSelect" SelectionMode="Multiple" Width="100%"></asp:ListBox>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>Notice Vaild Upto </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtNoticevaildupto" CssClass="date input-sm" Width="80%" Text='<%#Eval("LeaseDeedDate") %>'></asp:TextBox>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>Clause</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtClause" CssClass="input-sm" Width="80%" Text='<%#Eval("Clause") %>'></asp:TextBox>&nbsp;</td>
                                </tr>
                            </table>
                            <div class="Annexure">
                                <asp:GridView ID="gvPlotcancelationNotice" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="NoticeClauseGrid_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" FooterStyle-CssClass="hide_me">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="List of Additional Clauses" FooterStyle-CssClass="hide_me">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClause" runat="server" Text='<%#Eval("Annexures") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtReasonRej" TextMode="MultiLine" Style="min-height: 80px;" CssClass="input-sm similar-select1 margin-left-z" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField FooterStyle-CssClass="hide_me" ItemStyle-CssClass="hide_me" HeaderStyle-CssClass="hide_me">
                                            <ItemTemplate>
                                                <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                    ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />

                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Right" />
                                            <FooterTemplate>
                                                <asp:Button runat="server" ID="btnSaveNoticeClause" OnClick="btnSaveNoticeClause_Click" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="CopyTo">
                                <asp:GridView ID="gvCopyto" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="CopytoClauseGrid_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="2%" HeaderStyle-HorizontalAlign="Center" FooterStyle-CssClass="hide_me">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Copy List" FooterStyle-CssClass="hide_me">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClauseCopy" runat="server" Text='<%#Eval("Annexures") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtCopy" TextMode="MultiLine" Style="min-height: 80px;" CssClass="input-sm similar-select1 margin-left-z" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField FooterStyle-CssClass="hide_me" ItemStyle-CssClass="hide_me" HeaderStyle-CssClass="hide_me">
                                            <ItemTemplate>
                                                <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                    ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />

                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Right" />
                                            <FooterTemplate>
                                                <asp:Button runat="server" ID="btnSaveCopyClause" OnClick="btnSaveCopyClause_Click" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <asp:HiddenField runat="server" ID="HiddenField4" />
                            <asp:HiddenField runat="server" ID="HiddenField5" />
                            <asp:HiddenField runat="server" ID="HiddenField6" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-8 col-sm-8 col-xs-6 check-right">
        <div class="div-assesment-applicant assess-min-height" style="">
            <div class="div-view div-scroll" style="max-height: 628px; overflow-y: auto; border: 1px solid #ccc; background: #fff;">

                <%-- Preview Version  --%>
                <asp:Literal runat="server" ID="Literal1"></asp:Literal>

            </div>
        </div>
    </div>
</div>

<script>


    function AnyChangeCallMe() {


        $(".lblPlotNo").html($(".PlotNo").val());
        $(".ListofClause").html($(".Clause_table").html());
        $(".ListofNotices").html($(".Notices_table").html());
        $(".ListofAnnexres").html($(".Annexre_Table").html());
        $(".BP").html($(".Annexure").html());
        ceg



        $(document).ready(function () {
            AnyChangeCallMe();

            $("select input").change(function () {
                AnyChangeCallMe();
            });

            $("input[type='text']").keyup(function () {
                AnyChangeCallMe();
            });

            function ShowLumpSum() {

                $(".levy_lumpsum").show();
                $(".levy_installment").hide();
            }
            function ShowInstallment() {

                $(".levy_lumpsum").hide();
                $(".levy_installment").show();
            }
        });

        //Re-bind for callbacks
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {

            AnyChangeCallMe();


            $("select input").change(function () {

                AnyChangeCallMe();
            });

            $("input[type='text']").keyup(function () {

                AnyChangeCallMe();
            });

            function ShowLumpSum() {

                $(".levy_lumpsum").show();
                $(".levy_installment").hide();
            }
            function ShowInstallment() {

                $(".levy_lumpsum").hide();
                $(".levy_installment").show();
            }
        });

        $(document).ready(function () {
            $("input#LumpSumRad").click(function () {
                //var test = $(this).val();

                $(".levy_lumpsum").show();
                $(".levy_installment").hide();
            });
            $("input#InstallmentRad").click(function () {
                //var test = $(this).val();

                $(".levy_lumpsum").hide();
                $(".levy_installment").show();
            });
        });



</script>



