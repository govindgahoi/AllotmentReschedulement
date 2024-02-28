<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="RequestReport.aspx.cs" Inherits="Allotment.RequestReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function validateEmail(emailField) {
            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

            if (reg.test(emailField.value) == false) {
                alert('Invalid Email Address');
                return false;
            }

            return true;

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="panel panel-default" style="width: 60%;">
        <p class="panel-heading">Request Report</p>
        <div class="panel-body">
            <h5>You have requested the inspection report of</h5>
            <table class="table">
                <tbody>
                    <tr>
                        <td>Plot No.</td>
                        <td>
                            <asp:Label ID="lblPlotNo" runat="server"></asp:Label></td>
                        <td></td>
                    </tr>
                    <tr id="trAllotmentNo" runat="server">
                        <td>Allotment No.</td>
                        <td>
                            <asp:Label ID="lblAlltmentNo" runat="server"></asp:Label></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblText" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblInspectionType" Visible="false" runat="server"></asp:Label>
                            <asp:Label ID="lblApplcationID" Visible="true" runat="server"></asp:Label></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <h3>Please fill you particulars</h3>
                        </td>
                    </tr>
                    <tr>
                        <td>Name</td>
                        <td>
                            <asp:TextBox ID="txtRequestorName" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td align="right">
                            <asp:RequiredFieldValidator ID="rfvRequestorName" runat="server" ControlToValidate="txtRequestorName"
                                ErrorMessage="*" ValidationGroup="ValidationButton" ToolTip="*"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Phone</td>
                        <td>
                            <asp:TextBox ID="txtReqPhone" MaxLength="10" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td align="right">
                            <asp:RequiredFieldValidator ID="rfvReqPhone" runat="server" ControlToValidate="txtReqPhone"
                                ErrorMessage="*" ValidationGroup="ValidationButton" ToolTip="*"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="txtReqPhone" ErrorMessage="RegularExpressionValidator"
                                ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>EmailID</td>
                        <td>
                            <asp:TextBox ID="txtReqEmailID" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td align="right">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReqEmailID"
                                ErrorMessage="*" ValidationGroup="ValidationButton" ToolTip="*"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server"
                                ErrorMessage="Please enter in valid EmailID." ControlToValidate="txtReqEmailID"
                                SetFocusOnError="true"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="ValidationButton" ForeColor="red" CssClass="Validation-Msg" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Purpose</td>
                        <td>
                            <asp:TextBox ID="txtReqPurpose" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td align="right">
                            <asp:RequiredFieldValidator ID="rfvReqEmailID" runat="server" ControlToValidate="txtReqPurpose"
                                ErrorMessage="*" ValidationGroup="ValidationButton" ToolTip="*"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Enter below code</td>
                        <td>
                            <asp:TextBox ID="txtCaptcha" CssClass="form-control" runat="server" Width="200px"></asp:TextBox></td>
                        <td align="right">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCaptcha"
                                ErrorMessage="*" ValidationGroup="ValidationButton" ToolTip="*"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center" valign="middle">
                            <asp:UpdatePanel ID="UP1" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td style="height: 50px; width: 100px;">
                                                <asp:Image ID="imgCaptcha" runat="server" />
                                            </td>
                                            <td valign="middle">
                                                <span style="margin-left: 5px;">
                                                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" /></span>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="btnSubmit" runat="server" ValidationGroup="ValidationButton" OnClick="btnSubmit_Clcik" Text="Submit" />
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>
</asp:Content>
