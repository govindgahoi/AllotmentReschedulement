<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LetterView_ByServiceRequestNo.aspx.cs" Inherits="Allotment.LetterView_ByServiceRequestNo" %>

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
	<style>
		* {
			box-sizing: border-box;
		}

		.dash {
			border: 0 none;
			border-top: 1px dashed #FFD200;
			background: none;
			height: 0;
		}

		.mySlides {
			display: none;
		}

		/* Slideshow container */
		.slideshow-container {
			max-width: 1000px;
			position: relative;
			margin: auto;
		}

		/* Caption text */

		.active {
			background-color: #717171;
		}

		/* Fading animation */
		.fade {
			-webkit-animation-name: fade;
			-webkit-animation-duration: 1.5s;
			animation-name: fade;
			animation-duration: 1.5s;
		}

		@-webkit-keyframes fade {
			from {
				opacity: .4;
			}

			to {
				opacity: 1;
			}
		}

		@keyframes fade {
			from {
				opacity: .4;
			}

			to {
				opacity: 1;
			}
		}

		/* On smaller screens, decrease text size */
		@media only screen and (max-width: 300px) {
			.text {
				font-size: 11px;
			}
		}
	</style>

	<script type="text/ecmascript">
		function ErrorClose() {
			var divError = document.getElementById("divError");
			divError.style.display = "none";
		}

		function ChkValidVal() {

			var user_email = document.getElementById("txtUserName");
			var user_password = document.getElementById("txtPwd");
			var IsvalidEmail = 1;

			if (user_email.value == "") {

				alert("Please User ID.")
				return false;
			}

			if (user_password.value == "") {
				alert("Please enter password.");
				return false;
			}
		}

	</script>
	<script type="text/javascript">
		$(function () {
			$("#nav .dropdown").hover(
				function () {
					$('#products-menu.dropdown-menu', this).stop(true, true).fadeIn("fast");
					$(this).toggleClass('open');
				},
				function () {
					$('#products-menu.dropdown-menu', this).stop(true, true).fadeOut("fast");
					$(this).toggleClass('open');
				});
		});
		$(function () {
			$("#nav .dropdown1").hover(
				function () {
					$('#products-menu1.dropdown-menu1', this).stop(true, true).fadeIn("fast");
					$(this).toggleClass('open');
				},
				function () {
					$('#products-menu1.dropdown-menu1', this).stop(true, true).fadeOut("fast");
					$(this).toggleClass('open');
				});
		});
	</script>
</head>
<body id="pagewrap">
	<form id="form1" runat="server">
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
									<div class="panel-heading font-bold">
										<div class="col-md-8 col-sm-4 col-xs-12" style="margin-top:6px; padding:0px !important;">
										Letter View  <%--(<code style="color: #00bd00;font-weight: bold;">Total available records</code>)--%>
										</div>
										<div class="input-group col-md-4 col-sm-8 col-xs-12 text-right" style="float:right;padding:2px;">

										  <asp:TextBox ID="txt1" Width="200px" CssClass="input-sm similar-select" runat="server"  />
										  
											<span class="input-group-btn">
                                                	<asp:Button runat="server" ID="btn" class="btn btn-sm btn-primary" Text="Find" OnClick="btn_Click" />
										<%--	<button  type="button"style="padding:5px 10px;color:#fff;"></button>--%>
										  </span>

										</div>
										<div class="clearfix"></div>
											
									</div>
									
									<div class="panel-body">
                                        
                                        <asp:PlaceHolder runat="server" ID="Placeholder" />

										</div>
									</div>

							</div>
											 
							</div>

						   

		
						


						
						</div>
					</div>








					<div id="footer_id" runat="server"> <% Response.WriteFile("public_footer.aspx"); %> </div>  

				</div>
			</div>
		</div>
	</form>
</body>
</html>
