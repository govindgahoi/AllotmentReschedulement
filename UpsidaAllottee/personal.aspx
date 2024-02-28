<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="personal.aspx.cs" Inherits="UpsidaAllottee.personal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--    <script>
        $(Document).ready(function () {
            debugger
            var jsonData = JSON.stringify({ "messages":[{
                "sender": "918010968371",
                "to": "7007108050",
                "messageId": "10001",
                "transactionId": "10011",
                "channel": "wa",
                "type": "template",
                "template": {
                    "body": [],
                    "templateId": "welcome_test",
                    "language":"en"
                }
            }],
                "responseType":"json"
            });
            debugger
            $.ajax({
                url: "http://115.113.127.155:8090/pull-platform-receiver/wa/messages",
                type: "POST",
                dataType: "json",
                data: jsonData,
                contentType: "application/json",
                success: function (response) {
                    debugger
                    alert(JSON.stringify(response));
                },
                error: function (err) {
                    debugger
                    alert(JSON.stringify(err));
                }
            });
        })
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-top:20px">
            <asp:Button Text="Export-DueAmount" OnClick="ExportExcel" runat="server" />
             <asp:Button Text="Export-Payment-Journal" OnClick="ExportpaymentJournal" runat="server" />
             <asp:Button Text="AllotteeDetail" OnClick="altMastr" runat="server" />
            <asp:Button Text="Premium Defaulter" OnClick="PremiumDefaulter" runat="server" />
            <asp:Button Text="Maintenance Defaulter" OnClick="MaintenanceDefaulter" runat="server" />
            <%--<asp:Button Text="Premium Defaulter" OnClick="PremiumDefaulter" runat="server" />--%>
            <asp:Button Text="AllotmentDetail" OnClick="AllotmentAfter2019" runat="server" />
            <asp:Button ID="NivUpdate" runat="server" Text="NivUpdate" />
            <asp:Button ID="btnTransaction" runat="server" Text="OTSTransaction" OnClick="ExportDataFromSQLServer" />

        </div>
    </form>
</body>
</html>
