<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocViewerPossession.aspx.cs" Inherits="Allotment.DocViewerPossession" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title></title>

	<link href="css/bootstrap.min.css" rel="stylesheet" />
	<link href="css/font-awesome.min.css" rel="stylesheet" />
	<link href="css/CssManu.css" rel="stylesheet" />
	<link href="css/Main.css" rel="stylesheet" />
	<link href="css/theme.css" rel="stylesheet" />


	<!--<link href="css/ajax-jquery-ui.css" rel="stylesheet" />-->
	<link href="css/Footer.css" rel="stylesheet" />


</head>


<body id="pagewrap">
	<div id="dialog" style="display: none">
	</div>

	<form id="form1" runat="server">
		<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
		<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
			<ContentTemplate>
				<asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
					<ProgressTemplate>
						<div class="fgh">
							<div class="hgf">
								<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
							</div>
						</div>
					</ProgressTemplate>
				</asp:UpdateProgress>
		


				<div class="container">
					<div class="row">
						<div>
							<div class="navbar-header pull-left top-head-bg">
								<a href="Default.aspx" class="navbar-brand">
									<div class="col-md-8">
										<img class="img-responsive" src="logo.jpg" />
									</div>
									<div class="col-md-4">
										<img class="img-responsive" src="Image.jpg" />
									</div>
								</a>

							</div>
						</div>
						
					</div>
              </div>
                  <div>
                               <div class="col-md-12 col-sm-12 col-xs-12" style="background:#525659;">
                                   
                                   <div class="bp-divviewer">
                                       <asp:Literal ID="ltEmbed" runat="server" />
                                   </div>
                               </div>
                           </div>


			</ContentTemplate>
		</asp:UpdatePanel>


	</form>
    
</body>

   
</html>
