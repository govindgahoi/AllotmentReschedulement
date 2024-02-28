<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/MainUser.Master" AutoEventWireup="true" CodeBehind="SignedLetterViewEAuction.aspx.cs" Inherits="UpsidaAllottee.RMPanel.SignedLetterViewEAuction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <main id="main" class="main">
        <section class="section dashboard">
            <body id="pagewrap">

		<div class="container">
			<div class="row">
				  <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;" runat="server" id="BannerDiv">
                                        <div class="row">
                                            <div class="col-md-3 col-sm-4 col-xs-12 left-niveshban">
                                                <ul class="mylogo-ul list-inline " style="margin: 0; padding: 6px 0 9px 1px;">
                                                    <li>
                                                        <img src="/images/logo-img/govt_up.png" alt="Goverment" /></li>
                                                    <li></li>
                                                </ul>
                                            </div>
                                            <div class="col-md-6 col-sm-4 col-xs-12 text-center">
                                                <%-- <img src="/images/upsidclogo.png" style="width:211px;margin-top: 12px;" alt="Goverment" />--%>
                                                <h2 id="chg_head">Nivesh Mitra</h2>
                                                <p><span style="font-size:20px;">Single Window Portal</span> ,Govt. of Uttar Pradesh</p>
                                            </div>
                                            <div class="col-md-3 col-sm-4 col-xs-12 right-niveshban">
                                                <ul class="mylogo-ul list-inline" style="margin: 0; padding: 6px 0 9px 1px;">
                                                    <li>
                                                        <img src="/images/logo-img/logo_udhyog_bandu_b.jpg" alt="Goverment" /></li>

                                                </ul>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div> <div class="clearfix"></div>
                                     <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;" runat="server" id="Div1">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                                
                                                     <h3 id="H1">Uttar Pradesh State Industrial Development Authority</h3>
                                                  
                                            </div>
                                           
                                            <div class="clearfix"></div>
                                        </div>
                                    </div> 
                           <div class="clearfix"></div>
                              <div class="panel-heading col-md-12 font-bold" style="font-size: 14px !important; font-weight: 600;"><div  class="col-md-6 col-sm-6 col-xs-6 text-left">उत्तर प्रदेश सरकार &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GOVERNMENT OF UTTAR PRADESH</div>
                                  <div class="col-md-6 col-sm-6 col-xs-6 text-right">
                      <asp:Button runat="server" ID="btn_backNmswp" Text="⇦ Go Back" CssClass="pull-right btn btn-info" Style="background-color:#02486d;color:#fff;font-weight:600;" OnClick="btn_backNmswp_Click"   />
                    </div></div>
                                    <div class="clearfix"></div>

			
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
										<div class="col-md-12 col-sm-12 col-xs-12" >

										  <asp:GridView ID="GridView2" runat="server"
                        CssClass="table table-striped table-bordered table-hover request-table"
                        AllowPaging="True" 
                        AutoGenerateColumns="False"
                        DataKeyNames="ServiceRequestNO,Service,DocType"
                        GridLines="Horizontal"  PageSize="10"
                        OnRowCommand="GridView2_RowCommand"
                        
                        >
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                           
                            <asp:BoundField DataField="ServiceRequestNo" HeaderText="ServiceRequestNo" SortExpression="ServiceRequestNo" />
                            <asp:BoundField DataField="Name" HeaderText="Doc Name" SortExpression="Name" />
                            
                            
                            
                            <asp:TemplateField HeaderText="Action" ControlStyle-Width="30%">
                                
                               
                                <ItemTemplate>
                                   
                                    <asp:LinkButton ID="lbView"     runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument"  usesubmitbehavior="true" Text='<i class="fa fa-download" aria-hidden="true"></i>' /> / 
                                    <asp:LinkButton ID="lbView1"    runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument"    usesubmitbehavior="true"   Text ='<i class="fa fa-eye" aria-hidden="true"></i>'/> 
                                  

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            No Record Available
                        </EmptyDataTemplate>
                       </asp:GridView>
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








				

				</div>
			</div>
		</div>
            </div>
	
</body>
            </section>
            </main>
</asp:Content>
