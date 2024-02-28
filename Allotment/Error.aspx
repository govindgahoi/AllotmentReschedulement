<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Allotment.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:panel id="pnlError" runat="server" visible="false">
    <asp:label id="lblError" runat="server" text="Oops! 
	An error occurred while performing your request. 
	Sorry for any convenience."></asp:label>
    <asp:label id="lblGoBack" runat="server" 

	text="You may want to get back to the previous page 
	and perform other activities."></asp:label>
    <asp:hyperlink id="hlinkPreviousPage" runat="server">Go back</asp:hyperlink>
  </asp:panel>
    </div>
    </form>
</body>
</html>
