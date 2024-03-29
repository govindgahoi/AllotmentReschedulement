<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Allotment.Default" %>
<!DOCTYPE html>
<html xmlns="https://www.w3.org/1999/xhtml">
<head runat="server">   
 <meta name="viewport" content="width=device-width, initial-scale=1">
<!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-152522174-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'UA-152522174-1');
</script>
<link rel="icon" href="images\upsidclogo.png" />
   <title>Uttar Pradesh Industrial Development Authority</title>
     <meta http-equiv="Page-Enter" content="Alpha(opacity=100)"/>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />
    <style>
.box a {
    width: 48%;
    white-space: pre-line;
    height: 59px;
    background: linear-gradient(3deg, rgb(6 101 165) 3%, rgb(2 153 140) 50%);
    color: #fff;
    /* padding-top: 12px; */
}
        
        .table1  td {
    padding-top: 1px;
    padding-bottom: 1px;
    
}
.list-unstyled li i.fa.fa-angle-double-right {
    padding-right: 10px !important;
    color: #fff !important;
}

body {
    background: #ffffff;
    padding:0;
    display: block !important;
    background-image: url(https://onlineupsida.com/images/banner-23.jpg) !important;
    background-size: cover;
}
.mynewnavmenu a {
    font-size: 15px !important;
}
.nav > li > a {
    padding: 11px 14px !important;
}

.mynewnavmenu {
    background: linear-gradient(0deg, rgb(11 111 179) 17%, rgb(0 177 162) 59%) !important;
}       
.buttonN {
    
  padding: 1px 10px;
  font-size: 12px;
  text-align: center;
  cursor: pointer;
  outline: none;
  color: #fff;
  background-color: #4CAF50;
  border: none;
  border-radius: 5px;
  box-shadow: 0 2px #999;
}

.buttonN:hover {background-color: #3e8e41}

.buttonN:active {
  background-color: #3e8e41;
  box-shadow: 0 5px #666;
  transform: translateY(4px);
}
.bg-mywhite {
            background:#fff;
        }

.performance-textdiv {
                        min-height: 111px;
    margin-top: 20px;
    padding: 0px 0 0 7px;
    font-weight: 500;
    color: #636262;
        }
        .performance-textdiv1 {
                        min-height: 250px;
    margin-top: 20px;
    padding: 0px 0 0 7px;
    font-weight: 500;
    color: #636262;
        }


#myBtn {
  display: none;
  position: fixed;
  bottom: 20px;
  right: 30px;
  z-index: 99;
  font-size: 18px;
  border: none;
  outline: none;
  background-color: red;
  color: white;
  cursor: pointer;
  padding: 15px;
  border-radius: 4px;
}

#myBtn:hover {
  background-color: #555;
}
        * {
            box-sizing: border-box;
        }
        .btn-primary {
        
            background-color: #f3cc48;
            background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#ffe034), to(#e4b306));
            border: 1px solid #e9bb0e;
            font-weight: 500;
            color: #000;
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
 @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 600px;
                /* height: 300px; */
                margin-top: 11%;
            }
        }
        
              #ac-wrapper {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(255, 255, 255, .6);
    z-index: 1001;
   
    
}
#popup {
    width: 880px;
    height:480px;
    background: #FFFFFF;
    border: 5px solid #000;
    border-radius: 25px;
    -moz-border-radius: 25px;
    -webkit-border-radius: 25px;
    box-shadow: #64686e 0px 0px 3px 3px;
    -moz-box-shadow: #64686e 0px 0px 3px 3px;
    -webkit-box-shadow: #64686e 0px 0px 3px 3px;
    position:relative;
    top: 150px;
    left: 375px;
    transition: width 2s;
}
    </style>

    
</head>
<body id="pagewrap">
 <button onClick="topFunction()" id="myBtn" title="Go to top">Top</button>
    <form id="form1" runat="server">

             <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
       
<%--     <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">
          
            <ContentTemplate>--%>
               
 
        <div class="container">

        
            <div id="ac-wrapper" style='display:none'>
     
    <div id="popup" >
    
      <center>
           <asp:Image ID="Image1" CssClass="img-responsive" runat="server" ImageUrl="~/images/LAW.jpeg" Height="400" Width="834" />   
     </center>
            
       <div class="modal-footer">
                                        <div class="pull-right border-buttons">
                                            <a onClick="LAW()" title="" class="btn btn-primary ey-bg">Apply</a>
                                             <a onClick="LAW()" title="" class="btn btn-primary ey-bg">Back to Homepage</a>
                                           </div>
                                    </div>
    </div></div>


            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                        <a href="Default.aspx" class="navbar-brand" style="width:100%;padding: 5px;">
                            <div class="col-md-8">
                                <img class="img-responsive" src="images/upsida-logo-name.png"  />
                            </div>
                            <div class="col-md-4" style="margin-top: 2px;">
                                <img class="img-responsive" src="images/image4.png" />
                            </div>
                        </a>

                    </div>
                </div>
                <div  class="clearfix"></div><div id="main_menu" runat="server"><% Response.WriteFile("top_mainmenu.aspx"); %></div></div>
            <div class="row default-top-header" id="SideDiv" style="
background-color: #fff;
">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-8" style="margin-top: 15px">
                            <img class="img-responsive" src="banner1.jpg" style="height:314px;" />
                        </div>
                        <div class="col-md-4 well well-large offset4">
                            <div class="clearfix"></div>
                            
							<h2 style="color:red;">Website Under Maintenance</h2>
							
							<div class="form-group" style="border: 1px solid #ccc;padding: 8px;">
                                <div style="width: 292px">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                        <asp:ListItem Text="&nbsp;UPSIDA User &nbsp;&nbsp;" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="&nbsp;LIDA User &nbsp;&nbsp;" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="&nbsp;Other Dept &nbsp;&nbsp;" Value="4"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="input-group" style="margin-top: 10px">                              
                                    <asp:TextBox ID="txtUserName" CssClass="form-control margin-left-z" runat="server" Width="250px" Placeholder="Enter User Name" ToolTip="UserName"></asp:TextBox>
                                    <br />
                                </div>
                                <div class="input-group" style="margin-top: 10px">
                                    
                                    <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control margin-left-z" Placeholder="Enter Password" Width="250px"  ToolTip="Password" type="password"></asp:TextBox>

                                </div>
                                 <div class="input-group" style="margin-top: 10px">
                               
                                 <asp:TextBox ID="txtCode" runat="server" CssClass="form-control margin-left-z" Placeholder="Enter Captcha" Width="250px" ToolTip="Enter Captcha" AutoComplete="off"   ></asp:TextBox>

                                </div>
                                <div class="input-group" style="margin-top: 10px">
                                   <asp:Image ImageUrl="ghCaptcha.ashx" runat="server" ID="imgCaptcha" /> 
                                   
                                </div>
                                <div class="login-btn" style="margin-top: 10px">
                                    <asp:Button ID="btnLogin" runat="server" Width="80px" class="btn btn-primary ey-bg" style="margin-left:0;" Text="Login" OnClick="btnLogin_Click" OnClientClick="javascript:return ChkValidVal();" />
                                    <%--<asp:HyperLink ID="lnkforgetPwd" runat="server">Forgot Password</asp:HyperLink>--%>
                                </div>
                                 <div>
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="#FC590A"></asp:Label>
                                </div>
                                <!--<hr class="dash" />-->
                             

                                
                             
                            </div>



                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row well well-large offset4">
                               
                                <div class="clearfix"></div>
                                   <div>
                                 

                                    <br />

<p class="text-center box">
                                   
                                    <a href="http://72.167.225.87/nivesh/" target="_blank" title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;valign: middle;">Application  Under Warehousing &amp; Logistic Policy <br>2022</a>
<a href="http://72.167.225.87/nivesh/Default.aspx" target="_blank" title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;">Apply for Amalgamation of<br> Plot</a>

									 
                                   <a href="https://upsida.obpas.up.gov.in/" target="_blank" title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;">Register for New Building Plan Sanction/ Revision/ Revalidation/ Addition/ Alteration/ Certificate (OBPAS)</a>
                                  <!--<a href="https://upsida.obpas.co.in/new_users.php" target="_blank" title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;">Registration for completion <br>certificate <br>(OBPAS)</a>-->
                                  
                                  <a href="http://72.167.225.87/nivesh/" target="_blank" title="" class="btn ey-bg" style="margin:10px 5px;position:relative;z-index:1;">Apply for Subdivision of <br>Plot</a>
                                   </p>
                                  <!--<p class="text-center box">
                                   
                                    <a href="http://72.167.225.87/nivesh/"    target="_blank" title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;">Application  Under Warehousing & Logistic Policy 2022</a>
									 <%--<a href="IAServices.aspx"    target="_blank" title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;">Apply for Occupancy Certificate</a>--%>
                                   <a href="https://upsida.obpas.up.gov.in/"    target="_blank" title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;">Register for New Building Plan Sanction/ Revision/ Revalidation/ Addition/ Alteration/ Completion Certificate (OBPAS)</a>
                                  <a href="https://upsida.obpas.co.in/new_users.php"    target="_blank" title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;">Registration for completion certificate (OBPAS)</a>
                                  <a href="http://72.167.225.87/nivesh/Default.aspx"    target="_blank" title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;">Apply for Amalgamation of Plot</a>



                               <a href="IAServices.aspx?reqid=1030"    target="_blank" title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;">Apply for Subdivision of Plot</a>
                                   </p>-->
                                  </div>
                               
                            </div>
                            <div class="row well well-large offset4">
                               
                                <div class="clearfix"></div>
                                   <div>
                                 

                                    <br />
                                  <p class="text-center">
                                   
     <a href="ServiceTracker.aspx"  title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;background: linear-gradient(3deg, rgb(6 101 165) 3%, rgb(2 153 140) 50%);color: #fff;">IA Service Tracker</a> 
     <a href="ApplicationTracker.aspx"  title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;background: linear-gradient(3deg, rgb(6 101 165) 3%, rgb(2 153 140) 50%);color: #fff;">Land Allotment Tracker</a> 
     <a onClick="comingsoon()" title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;background: linear-gradient(3deg, rgb(6 101 165) 3%, rgb(2 153 140) 50%);color: #fff;">Apply For RTI</a> 
     <a href="https://onlineupsidc.com/allottee.aspx" target="_blank" title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;background: linear-gradient(3deg, rgb(6 101 165) 3%, rgb(2 153 140) 50%);color: #fff;">Submit Grievance</a>
     <span ><a href="http://eservices.onlineupsidc.com/PropertyHub/Index.aspx" target="_blank" title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;background: linear-gradient(3deg, rgb(6 101 165) 3%, rgb(2 153 140) 50%);color: #fff;">Find Plot </a></span>
   <span ><a href="LandAcquisitionProposal.aspx"  title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;background: linear-gradient(3deg, rgb(6 101 165) 3%, rgb(2 153 140) 50%);color: #fff;">Sell your Land </a></span>
                                        <span ><a href="https://onlineupsidc.com/tracking.aspx" target="_blank" title="" class="btn btn-primary ey-bg" style="margin:10px 5px;position:relative;z-index:1;background: linear-gradient(3deg, rgb(6 101 165) 3%, rgb(2 153 140) 50%);color: #fff;">Grievance Tracker</a></span>
                                   </p>
                                  </div>
                               
                            </div>
                        </div>

   <div class="clearfix"></div>
                        
<div class="col-md-12">
                            <marquee scrolldelay="10" direction="left" style="position:relative;padding: 12px 0;border:6px solid #d6d6d6;margin-top: 20px;">
                                <img src="/images/new_red.gif" style="position:absolute;z-index:2;left: -34px;top: -3px;" alt="new img"/>
                                 <p>All the UPSIDA industrial area services will now available only through nivesh mitra portal.</p>
                                
                            </marquee>

                        </div>
  <div class="clearfix"></div>
                        <div class="col-md-3"></div>
                    </div>
                    <div id="footer_id" class="row" runat="server"> <% Response.WriteFile("public_footer.aspx"); %> </div>  

                </div>

            </div>
        </div>
  <%--     </ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>



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
        function LABP() {
            top.window.location.href = 'http://72.167.225.87/nivesh/';
        }

        function RTI() {
            top.window.location.href = 'http://upsidaservices.onlineupsidc.com';
        }
        function comingsoon() {
            top.window.location.href = 'comingsoon.htm';
        }
        function IAService() {
            top.window.location.href = 'IAServices.aspx';
        }
    
        function ShowTermsAndCondition() {
            $('input:radio[name=Radio]').each(function () { $(this).prop('checked', false); });
            $("#btnModalTerms").click();
        }
        function LAW() {
            //window.location.href = 'RegistrationLogistics.aspx';
            alert("Will be live soon")
        }
        //$(document).ready(function () {
        //    $("form").click(function () {
        //        document.getElementById('ac-wrapper').style.display = "none";
        //    });
        //});


        //function PopUp(hideOrshow) {
        //    if (hideOrshow == 'hide') document.getElementById('ac-wrapper').style.display = "none";
        //    else document.getElementById('ac-wrapper').removeAttribute('style');
        //}
        //window.onload = function () {
        //    setTimeout(function () {
        //        PopUp('show');
        //    }, 1000);
        //}


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
<script>
// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function() {scrollFunction()};

function scrollFunction() {
  if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
    document.getElementById("myBtn").style.display = "block";
  } else {
    document.getElementById("myBtn").style.display = "none";
  }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
  document.body.scrollTop = 0;
  document.documentElement.scrollTop = 0;
}


</script>
</body>
</html>