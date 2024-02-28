<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Page Language="C#" %>
<%@ Register TagPrefix="oem" Namespace="OboutInc.EasyMenu_Pro" Assembly="obout_EasyMenu_Pro" %>
<script language="C#" runat="server">
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			EasymenuTabStrip.SelectedItemId = "tab1";
			ShowSelectedTab();
		}
	}
	protected void buttonServerEvent_Click(object sender, EventArgs e)
    {
		// hide the previous selected tab panel
		HideSelectedTab();
		
		string TabID = hiddenServerEvent.Value;
		EasymenuTabStrip.SelectedItemId = TabID;
		
		// show the current selected tab panel
		ShowSelectedTab();
    }
	
	private void HideSelectedTab()
	{
		Panel selectedPanel = (Panel)divTabContainer.FindControl("panel_" + EasymenuTabStrip.SelectedItemId);
		if (selectedPanel != null) selectedPanel.Visible = false;
	}
	
	private void ShowSelectedTab()
	{
		Panel selectedPanel = (Panel)divTabContainer.FindControl("panel_" + EasymenuTabStrip.SelectedItemId);
		if (selectedPanel != null) selectedPanel.Visible = true;
	}
</script>
<html>
	<head>
		<script>
			function SelectTab(itemID)
			{
				document.getElementById('<%=hiddenServerEvent.ClientID %>').value = itemID;
				<%= Page.ClientScript.GetPostBackEventReference(this.buttonServerEvent, "") %>
			}
		</script>
		<title>Example Page - TabStrip1</title>
	
		<!--// Only needed for this page's formatting //-->
		<style>
			body {font-family: Verdana; font-size: XX-Small; margin: 0px; padding: 20px}
			.title {font-size: X-Large; padding: 20px; border-bottom: 2px solid gray;}
		</style>
	</head>
	<body>
		<form runat="server">
			<div class="title"><b>TabStrip</b> - postback occurs after each tab click.</div>
			<br /><br /><br />
			<table>
				<tr>
					<td>
						<table cellpadding="0" cellspacing="0">
							<tr>
								<td>
									<oem:EasyMenu id="EasymenuTabStrip" runat="server" ShowEvent="Always" StyleFolder="styles/TabStrip1"
										Position="Horizontal" Width="400">
										<Components>
											<oem:MenuItem InnerHtml="<span style='cursor:default'>Apples</span>" OnClientClick="SelectTab('tab1')" ID="tab1"></oem:MenuItem>
											<oem:MenuItem InnerHtml="<span style='cursor:default'>Strawberries</span>" OnClientClick="SelectTab('tab2')" ID="tab2"></oem:MenuItem>
											<oem:MenuItem InnerHtml="<span style='cursor:default'>Melons</span>" OnClientClick="SelectTab('tab3')" ID="tab3"></oem:MenuItem>
											<oem:MenuItem InnerHtml="<span style='cursor:default'>Cherry</span>" OnClientClick="SelectTab('tab4')" ID="tab4"></oem:MenuItem>
										</Components>
									</oem:EasyMenu>
									<asp:Button ID="buttonServerEvent" runat="server" OnClick="buttonServerEvent_Click" style="display:none" />
									<input type="hidden" id="hiddenServerEvent" runat="server" />
								</td>
							</tr>
							<tr>
								<td style="padding-left:3px;">
									<div style="border:3px solid #c0cff0;width:500px;height:150px" ID="divTabContainer" runat="server">
										<asp:Panel ID="panel_tab1" runat="server" Visible="false">
											<h3>Tab Content 1</h3>
										</asp:Panel>
										<asp:Panel ID="panel_tab2" runat="server" Visible="false">
											<h3>Tab Content 2</h3>
										</asp:Panel>
										<asp:Panel ID="panel_tab3" runat="server" Visible="false">
											<h3>Tab Content 3</h3>
										</asp:Panel>
										<asp:Panel ID="panel_tab4" runat="server" Visible="false">
											<h3>Tab Content 4</h3>
										</asp:Panel>
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>