<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Service_Payment_Detail.ascx.cs" Inherits="Allotment.UC_Service_Payment_Detail" %>

<style>
    .pad-left0 {
        padding-left: 0;
    }

    @media only screen and (max-width: 992px) {
        .form-group label.text-right {
            text-align: left !important;
        }
    }

    label {
        margin-bottom: 0;
    }

     
</style>



<div runat="server" id="uc_alloottee_details" class="row">
    <div class="col-md-12 col-sm-12 col-xs-12" style="padding: 0;">
        <div class="panel panel-default" style="border: 1px solid #e6e6e6;">

           <asp:Label ID="lblAllotmentNo" Visible="false" runat="server" CssClass="font-bold"></asp:Label>
            
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="panel-heading font-bold">Fees & Current Dues</div>
            <br />

            <div class="panel-heading font-bold text-left">Payment</div>

                <div class="form-group">

                    <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover request-table" runat="server" AutoGenerateColumns="false" AllowPaging="true" ShowFooter="true" ShowHeader="True">
                        <Columns>
                            <asp:BoundField DataField="Payment_Head" HeaderText="Payment Description" ItemStyle-Width="210" />
                            <asp:BoundField DataField="Ammount" HeaderText="Amount" ItemStyle-Width="60" DataFormatString="{0:N2}"
                                ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Remark" HeaderText="Remark" />
                        </Columns>
                    </asp:GridView>
                    <br />
                    <div runat="server" id="DemandNoteDiv">
                    <div class="panel-heading font-bold text-left">Demand Note</div>

                <div class="form-group">
                    <asp:GridView ID="GridView2" CssClass="table table-bordered table-hover request-table" runat="server" AutoGenerateColumns="false" AllowPaging="true" ShowFooter="true" ShowHeader="True">
                        <Columns>
                            <asp:BoundField DataField="Payment_Head" HeaderText="Payment Description" ItemStyle-Width="210" />
                            <asp:BoundField DataField="Ammount" HeaderText="Amount" ItemStyle-Width="60" DataFormatString="{0:N2}"
                                ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Remark" HeaderText="Remark" />
                        </Columns>
                    </asp:GridView>


    </div></div>


                    <table class="table request-table">
                        <tr runat="server" id="PayTr" visible="false"><td>Pay Mode :<asp:RadioButtonList runat="server" ID="PayTypeRadio" RepeatDirection="Horizontal"><asp:ListItem Value="Offline">Offline</asp:ListItem><asp:ListItem Value="Online">Online</asp:ListItem></asp:RadioButtonList></td></tr>
                        <tr runat="server" id="PayTr1" visible="false"><td><span style="color:red;">Payment Through Single Window Portal</span></td></tr>
                       
                        <tr><td><span>Total Amount Payable : <b><asp:Label runat="server" ID="lblTotalAmount"></asp:Label></b></span>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnPayNow" CssClass ="btn-sm btn-primary text-right btn-bpservice" runat="server" Text="Pay Now" OnClick="btnPayNow_Click"/><asp:Label runat="server" ID="Status_lbl"></asp:Label></td></tr>
                    </table>




            </div>






        </div>
    </div>
</div>


<%--  <div class="status-bar-bottom hide">

        <div class="form-group">
            <label class="col-md-1 col-sm-12 col-xs-12">
                Data Status:
            </label>
            <div class="col-md-2 col-sm-12 col-xs-12">
                <asp:Label ID="lblDataStatus" runat="server" CssClass="font-bold"></asp:Label>
            </div>
            <label class="col-md-1 col-sm-12 col-xs-12">
                Status Date:
            </label>
            <div class="col-md-2 col-sm-12 col-xs-12">
                <asp:Label ID="lblStatusDate" runat="server" CssClass="font-bold"></asp:Label>
            </div>
            <label class="col-md-1 col-sm-12 col-xs-12">
                Status Date:
            </label>
            <div class="col-md-2 col-sm-12 col-xs-12">
                <asp:Label ID="Label2" runat="server" CssClass="font-bold"></asp:Label>
            </div>
            <div class="col-md-2 col-sm-12 col-xs-12">
                <asp:DropDownList ID="DdlValidation" runat="server" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1" Style="width: 86px; height: 20px;">
                    <asp:ListItem>Validation</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>

--%>
