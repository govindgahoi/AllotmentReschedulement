<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Of_Password.aspx.cs" Inherits="Allotment.Change_Of_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <!-- CSS only -->
    <link rel="icon" href="images\upsidclogo.png" />
    <title>Uttar Pradesh Industrial Development Authority</title>
    <meta http-equiv="Page-Enter" content="Alpha(opacity=100)" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
   <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />
     <script src="https://www.google.com/recaptcha/api.js?render=6Lfm7NUiAAAAAOjA3CNbEOyUTh_zRnQeNjE3GqvM"></script>

     <script>
      //function onClick(e) {
      //  e.preventDefault();
        grecaptcha.ready(function() {
            grecaptcha.execute('6Lfm7NUiAAAAAOjA3CNbEOyUTh_zRnQeNjE3GqvM', { action: 'homepage' }).then(function (token) {
              // Add your logic to submit to your backend server here.
                //console.log(token);
                document.getElementById('g-token').value = token;
          });
        });
      //}
  </script>
    <style>
        
        .table1  td {
    padding-top: 1px;
    padding-bottom: 1px;
    
}
        #button1{
            font-size: 11px;  
     font-weight: bold;  
     font-family: Arial;  
     color: white;
     background-color:#474943;
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
#Table3{
    border-collapse: separate;
  border-spacing: 0 15px;
}
    </style>
        <script type="text/javascript">
        $(function () {
            $(document).on('input', 'input', function (e) {
                var keyCode = e.keyCode || e.which;

                //  $("#lblError").html("");

                //Regex for Valid Characters i.e. Alphabets and Numbers.
                var regex = /^[. @/A-Za-z0-9]+$/;

                //Validate TextBox value against the Regex.
                var value = this.value;
                var isValid = regex.test(value);
                if (!isValid && this.value != '') {
                    //  $("#lblError").html("Only Alphabets and Numbers allowed.");
                    // alert("Special Character Not Allowed");
                    e.preventDefault();
                }
                var newValue = '';
                for (var i = 0; i < value.length; i++) {
                    if (regex.test(value[i]) || value[i] == '') {
                        newValue += value[i];
                    }
                }
                this.value = newValue;

                return isValid;
            });
        });


        //var myFile = "";


        //$('INPUT[type="file"]').on('change', function () {
            
        //    myFile = $('INPUT[type="file"]').val();
        //    console.log(myFile);
        //    var upld = myFile.split('.').pop();
        //    if (upld == 'pdf') {
        //       // alert("File uploaded is pdf")
        //    } else {
        //        alert("Only PDF are allowed")
        //        $('INPUT[type="file"]').val('')
        //    }

          //})

        $(document).on('keypress', 'textarea', function (event) {
            var regex = new RegExp("^[. @/A-Za-z0-9]+$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }
        });


        var myFile = "";

       
        $(document).on('change', 'INPUT[type="file"]', function () {

            myFile = $('INPUT[type="file"]').val();
            console.log(myFile);
            var upld = myFile.split('.').pop();
            if (upld != 'pdf') {
                alert("Only PDF are allowed");
                $('INPUT[type="file"]').val('');
                // alert("File uploaded is pdf");

            } else {



            }

        });




          </script>
    <%--  <script type="text/javascript">
        $(function () {
            $(document).on('input', 'input', function (e) {
                var keyCode = e.keyCode || e.which;

                //  $("#lblError").html("");

                //Regex for Valid Characters i.e. Alphabets and Numbers.
                var regex = /^[. @/A-Za-z0-9]+$/;

                //Validate TextBox value against the Regex.
                var value = this.value;
                var isValid = regex.test(value);
                if (!isValid && this.value != '') {
                    //  $("#lblError").html("Only Alphabets and Numbers allowed.");
                    // alert("Special Character Not Allowed");
                    e.preventDefault();
                }
                var newValue = '';
                for (var i = 0; i < value.length; i++) {
                    if (regex.test(value[i]) || value[i] == '') {
                        newValue += value[i];
                    }
                }
                this.value = newValue;

                return isValid;
            });
        });
    </script>--%>

</head>
<body id="pagewrap">
    <form id="form1" runat="server">
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
                
            <br />
            <br />
             <a  class="btn btn-primary ey-bg pull-right" href="Default.aspx?backcase=1">Back</a>
            <br /><br />
            <div class="row default-top-header" id="SideDiv">
                <div class="col-md-12">

                    <div style="text-align:center;font-size:18px;font-weight:600;margin-top:3vh;background-color:antiquewhite;color:black">Password Reset</div><hr />


        <div>
            <asp:Panel ID="pnlotpverify" Visible="true" runat="server">

                  

                    
                        <asp:Table ID="Table1" CssClass="table-responsive" runat="server" Style="align-content: center;  padding-top: 50px; margin-left: 350px; margin-bottom: 4vh" Width="450px"  >
                       
                           <asp:TableRow Style="text-align: left">
                               <asp:TableCell>
                        <asp:Label ID="Label5" runat="server" Text="Please Enter Your OTP"></asp:Label>
                                   </asp:TableCell>
                                       <asp:TableCell>
                        <asp:TextBox ID="txtotp" runat="server" MaxLength="6" CssClass="chosen input-sm similar-select1 margin-left-z form-control" AutoComplete="off"></asp:TextBox>
                             </asp:TableCell></asp:TableRow>       
                      </asp:Table>

                

                    <asp:Button ID="btn_verify" OnClick="btn_verify_Click" class="btn btn-primary btn-md center-block" runat="server" Text="Verify"  />
                        <asp:Label ID="lblmsg" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="Red"></asp:Label>
                        
             </asp:Panel>


               <asp:Panel ID="pnlatrchidetails" Visible="false" runat="server">

                        


                    <div class="container">
                        <asp:Table ID="Table3" CssClass="table-responsive" runat="server" Style="align-content: center;  padding-top: 50px; margin-left: 400px; margin-bottom: 4vh" Width="450px"  >
                            <asp:TableRow Style="text-align: center">

                            </asp:TableRow>
                                <asp:TableRow Style="text-align: left">
                                    <asp:TableCell>
                                        <label class="col-md-4 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        New Password :
                                                    </label>
                                    </asp:TableCell>
                                     <asp:TableCell>
                                        <asp:TextBox ID="txtNewPassword" runat="server" CssClass="input-sm similar-select1" AutoComplete="off"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter New password"    
    ControlToValidate="txtNewPassword"></asp:RequiredFieldValidator>  
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" style="color:red" runat="server" ErrorMessage="Password must contain atleast 8 character ,1 uppercase ,1 lowercase,1 digit and 1 special symbol"  
        ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"  
        ControlToValidate="txtNewPassword"></asp:RegularExpressionValidator> 
                                         </asp:TableCell>
                                    </asp:TableRow>
                             <asp:TableRow Style="text-align: left">
                                     <asp:TableCell>
                                        <label class="col-md-4 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        Confirm New Password :
                                                    </label> 
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="input-sm similar-select1" AutoComplete="off" ></asp:TextBox>
                                    </asp:TableCell>
                        </asp:TableRow>
                                   
                                        
                            




                            </asp:Table>

                        <br />
                        <br />

                            <asp:Table ID="Table2" CssClass="table-responsive" runat="server" Style="align-content: center;  padding-top: 50px; margin-left: 350px; margin-bottom: 4vh" Width="450px"  >
                    
                             <asp:TableRow Style="text-align: left">
                               <asp:TableCell>
                                   <br /> <br />
                               </asp:TableCell>
                                 <asp:TableCell>
                                 <asp:TextBox ID="txtCode" runat="server" CssClass="form-control margin-left-z" Placeholder="Enter Captcha" Width="250px" ToolTip="Enter Captcha" AutoComplete="off" ></asp:TextBox>
                                   </asp:TableCell>
                                 <asp:TableCell>
                                     </asp:TableCell>
                                       <asp:TableCell>
                                   <asp:Image ImageUrl="ghCaptcha.ashx" runat="server" ID="imgCaptcha" /> 
                                   <input type="hidden" id="g-token" name="g-token" />
                               
                              </asp:TableCell>
                    </asp:TableRow> 
                    </asp:Table>     








                         
                <div class="row">
                    <div class="col-md-7">


                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnsave"  class="btn btn-primary btn-md" OnClick="btnsave_Click"  runat="server" Text="Save Details"  />
                    </div>
                    </div>


                        <br />
                        <br />
               
                    </div>



                    </asp:Panel>


                             


        </div>
                    </div>
          
                        

                    </div>
                </div>
        <div>
        </div>
    </form>
    <script src="https://www.google.com/recaptcha/api.js"></script>
</body>
</html>
