<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultLida.aspx.cs" Inherits="Allotment.DefaultLida" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/jquery-ui.css" rel="stylesheet" />
    <script src="js/jquery-1.8.3.min.js.js"></script>
    <script src="js/jquery-ui.js"></script>
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet"/>
    
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />

  <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.0/jquery-ui.js"></script>
    <%--<script src="js/chosen.jquery.min.js"></script>--%>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>
    <style>
        
        .table1  td {
    padding-top: 1px;
    padding-bottom: 1px;
    
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
        td>input,td>select{
            width:150px !important;
            margin: 0 0 0 0;
            background: #fff9e7 !important;
            width: 100%;
            height:23px !important;
    border-radius: 0px !important;
    height: 22px;
    border: 1px solid #fff;
        }
        #btnAddrow{
                margin-top: 3vh;
    background-color: mediumslateblue;
    color: white;
    font-weight: bold;
    font-size: 12px;
    margin-left: 10px;
        }
        hr{
            text-align:center;
            /*width:1000px;*/
            margin-top:1vh;
            border-top: 2px solid #d4e1df;
    border-bottom: 2px solid #eaf9f7;

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
 <button onclick="topFunction()" id="myBtn" title="Go to top">Top</button>
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
                                            <a onclick="LAW()" title="" class="btn btn-primary ey-bg">Apply</a>
                                             <a onclick="LAW()" title="" class="btn btn-primary ey-bg">Back to Homepage</a>
                                           </div>
                                    </div>
    </div></div>


            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                        <a href="Default.aspx" class="navbar-brand" style="width:100%;">
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
            <div class="row default-top-header" id="SideDiv">
                <div class="col-md-12">
                    <%--<div class="container" >--%>
        <!--first half-->
        <div style="text-align:center;font-size:18px;font-weight:600;margin-top:3vh;background-color: blanchedalmond;"> Application for Building Plan (LIDA)</div><hr />
                    <div class="radioClass" style="text-align: center; padding-top: 30px; padding-bottom: 6vh;">
                        <div class="form-check">
                            <asp:RadioButton ID="RadioOneTime" runat="server" class="form-check-input"
                                GroupName="paymentScheme"
                                AutoPostBack="true" />&nbsp;
                                                        <label class="" for="option1">New Application</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                            <asp:RadioButton ID="RadioInstallment" runat="server" class="form-check-input"
                                GroupName="paymentScheme"
                                AutoPostBack="true" />&nbsp;
                                                <label class="" for="option2">Already Applied?</label>
                        </div>
                    </div>
                                                
                        

        <!--second half-->
                    <div class="row">
                        <div class="col-md-offset-1 col-lg-offset-1">
                            <asp:Table ID="Table1" runat="server" Style="align-content: center; float: left; padding-top: 50px; margin-left: 120px; margin-bottom: 4vh">

                                <asp:TableRow Style="text-align: center">
                                    <asp:TableCell>
                                        <asp:Label ID="Label1" runat="server" Text="Khesra/Gata Number"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Label ID="Label2" runat="server" Text="Area"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Label ID="Label3" runat="server" Text="Tehsil"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Label ID="Label4" runat="server" Text="Village"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Label ID="Label5" runat="server" Text="Owner Name"></asp:Label>

                                    </asp:TableCell>


                                </asp:TableRow>


                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="chosen input-sm similar-select1 margin-left-z form-control"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="chosen input-sm similar-select1 margin-left-z form-control"></asp:TextBox>
                                    </asp:TableCell>


                                    <asp:TableCell>
                                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="chosen input-sm similar-select1 margin-left-z form-control"></asp:DropDownList>

                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="DropDownList4" runat="server" CssClass="chosen input-sm similar-select1 margin-left-z form-control"></asp:DropDownList>
                                    </asp:TableCell>

                                    <asp:TableCell>
                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="chosen input-sm similar-select1 margin-left-z form-control"></asp:TextBox>
                                    </asp:TableCell>


                                </asp:TableRow>
                            </asp:Table>
                            <div>
                                <asp:Button ID="btnAddrow" class="btn btn-default btn-sm" runat="server" Text="&#43;" OnClick="Button1_Click" />
                            </div>
                    <asp:Table ID="Table2" runat="server" Style="align-content: center; float: left; padding-top: 70px">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="Label6" runat="server" Text="Enter ownership details"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList ID="DropDownList5" Style="width: 150px; height: 26px" runat="server"></asp:DropDownList>
                            </asp:TableCell>

                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="Label7" runat="server" Text="Enter land use"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList ID="DropDownList6" Style="width: 150px; height: 26px" runat="server"></asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>

                       <%-- <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="Label8" runat="server" Text="Are you applying for first time ?"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:RadioButton ID="RadioButton1" runat="server" />
                                <asp:Label ID="Label9" runat="server" Text="Yes"></asp:Label>
                            </asp:TableCell>

                            <asp:TableCell>
                                <asp:RadioButton ID="RadioButton2" runat="server" />
                                <asp:Label ID="Label10" runat="server" Text="No"></asp:Label>

                            </asp:TableCell>

                        </asp:TableRow>--%>
                    </asp:Table>
                        </div>
                    </div>


                    <%--</div>--%>
                    <%--<div id="footer_id" runat="server"> <% Response.WriteFile("public_footer.aspx"); %> </div>--%>  

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
            alert("Will be live soon")
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
