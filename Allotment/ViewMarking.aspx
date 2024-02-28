<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMarking.aspx.cs" Inherits="Allotment.ViewMarking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">   
	<title></title>
	 <meta http-equiv="Page-Enter" content="Alpha(opacity=100)"/>
	<link href="css/bootstrap.min.css" rel="stylesheet" />
	<link href="css/font-awesome.min.css" rel="stylesheet" />
	<script src="js/jquery-1.11.3.min.js"></script>
	<script src="js/bootstrap.min.js"></script>
	<link href="css/CssManu.css" rel="stylesheet" />
	<link href="css/theme.css" rel="stylesheet" />
	<link href="css/Footer.css" rel="stylesheet" />


</head>
<body id="pagewrap">
	<form id="form1" runat="server">
        	<asp:ScriptManager ID="ScriptManager1" runat="server" EnableViewState="true" AjaxFrameworkMode="Enabled" EnablePartialRendering="true">
	</asp:ScriptManager>

		<div class="container">
			<div class="row">
				<div>
					<div class="navbar-header pull-left top-head-bg">
						<a href="Default.aspx" class="navbar-brand">
							<div class="col-md-8">
								<img class="img-responsive" src="logo.jpg" />
							</div>
							<div class="col-md-4" style="margin-top: 2px;">
								<img class="img-responsive" src="images/image4.png" />
							</div>
						</a>

					</div>
				</div>


			<div  class="clearfix"></div><div id="main_menu" runat="server"><% Response.WriteFile("top_mainmenu.aspx"); %></div></div>
			<div class="row default-top-header" id="SideDiv">
				<div class="col-md-12">



					<div class="row">
						<div class="col-md-12" style="margin-top: 15px;  min-height:500px;">

											 <div class="row">
						<div class="col-md-12 col-sm-12 col-xs-12">
						
								<div class="panel panel-default">
									<div class="clearfix"></div>
									
									<div class="panel-body">
                                        
                                        <asp:PlaceHolder runat="server" ID="Placeholder" />

										</div>
									</div>

							</div>
											 
							</div>

						   

		
						


						
						</div>
					</div>








					

				</div>
			</div>
		</div>
	</form>
</body>
</html>
