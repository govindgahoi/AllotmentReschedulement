<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Lida_Service_Applicant_details.ascx.cs" Inherits="Allotment.UC_Lida_Service_Applicant_details" %>
<%--<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Service_Allottee_details.ascx.cs" Inherits="LidaApplication.UC_Service_Allottee_details" %>--%>


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
    <style>

    .row {
        margin-left: 0px;
        margin-right: 0px;
    }
    a.static.selected {
			text-decoration: none;
			border-style: none;
			color: #000000 !important;
            background: #ffdb6d;
		}
        .iadsashboard-dayul-inbox ul li a {
            text-decoration: none !important;
            white-space: nowrap;
            display: block;
            padding: 4px 6px;
            color: #2b2b2b;
        }

          .iadsashboard-dayul-inbox li {
                /* padding-left: 5px; */
                /* padding-right: 5px; */
                background: #ffc511;
                text-align: center;
                margin: 0px 2px;
                /* width: 127px; */
                /* height: 21px; */
                font-size: 13px;
                font-weight: 600;
                box-shadow: 7px 0 16px #ccc;
                color: #000000;
                border: 1px solid #8e8e8e;
            }

          #ContentPlaceHolder1_sub_menu a
        {
            padding:3px 8px;
            }
#ContentPlaceHolder1_sub_menu ul
{
    list-style-type:none !important;
        list-style: none !important;
    margin: 0;
    background: #e2e2e2;
    padding: 0;
    width: auto;
    }
		

	
		.sub_menu li {
			position: relative;
			    font-size: 12px;
    color: #2d2d2d;
    border-bottom: 1px solid #ffffff;
    padding: 1px 1px !important;
    font-weight: 500;
		}

        #Service_Building_Plan_sub_menu a.static {
    padding-left: 1.15em !important;
    padding-right: 1.15em !important;
}
        ul, menu, dir {
 
    list-style-type: none !important;
   
}

</style>
   

    
<%-- <button onclick="topFunction()" id="myBtn" title="Go to top">Top</button>
    <form id="form1" runat="server">

             <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
       --%>
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
             <%--   <div  class="clearfix"></div><div id="main_menu" runat="server"><% Response.WriteFile("LidaMainMenu.aspx"); %></div></div>--%>
            <div class="row default-top-header" id="SideDiv">
                <div class="col-md-12">
                      <div style="text-align:center;font-size:18px;font-weight:600;margin-top:3vh;background-color: blanchedalmond;">

                           <div class="radioClass" style="text-align: center; padding-top: 30px; padding-bottom: 6vh;">
                       <div class="row" id="SideDiv">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <a id="Service_Building_Plan_sub_menu_SkipLink"></a>


        <div id="Service_Building_Plan_building_plan" class="panel panel-default">
            <div class="panel-heading" style="width: 100%;">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-4">
                            <div class="btn-group">
                                <input type="submit" name="Service_Building_Plan$Previous1" value="Previous" id="Service_Building_Plan_Previous1" class="btn btn-primary register " style="display: none;">
                                <input type="submit" name="Service_Building_Plan$btnNext1" value="Next" id="Service_Building_Plan_btnNext1" class="btn btn-primary register " style="display: none;">

                            </div>
                        </div>
                        <div class="col-md-4" style="font-weight:700;font-size:14px">
                            <p>Allottee Details</p>
                        </div>
                        <div class="col-md-4">
                            <div class="btn-group">
                                
                                <input type="submit" name="Service_Building_Plan$btnSaveApplicant" value="Save" id="Service_Building_Plan_btnSaveApplicant" class="btn btn-primary register " style="display: none;">
                                <input type="submit" name="Service_Building_Plan$Button4" value="Reset" id="Service_Building_Plan_Button4" class="btn btn-primary register " style="display: none;">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-body">

                <div id="Service_Building_Plan_hideDiv">
                    <div class="panel-heading text-left" style="font-weight:500;font-size:14px">Ex-LIDA Application Details</div>
                     <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Ex-LIDA Service Request No
                        </label>
                        <div class="col-md-4" style="font-weight:500;font-size:14px">
                            <asp:Label ID="lbllidaserviceid" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                         </div>

                         <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Applied Date
                        </label>
                        <div class="col-md-2" style="font-weight:500;font-size:14px">
                            <asp:Label ID="lblapplieddt" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                         </div>


                    </div>
                    <div class="clearfix"></div>

                    <hr class="myhrline">
                     <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Ex-LIDA Allottee ID
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                             <asp:Label ID="lblalloteeid" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Name of Applicants
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                           <asp:ListBox ID="lstboxapplicants" runat="server" Enabled="false" Font-Size="14px" class="input-sm similar-select1"></asp:ListBox>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Applicant Mobile No :
                        </label>
                        <div class="col-md-9" style="font-weight:500;font-size:14px">
                            <asp:Label ID="lblapplicantmob" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Applicant Email Id
                        </label>
                        <div class="col-md-9" style="font-weight:500;font-size:14px">
                             <asp:Label ID="lblemail" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                      
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline">
                    <%--<div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Address of Applicant:
                        </label>
                        <div class="col-md-9" style="font-weight:500;font-size:14px">
                              <asp:Label ID="lbl_address" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                      <input name="Service_Building_Plan$txtStructuralEngineer" type="text" value="ER. MANOJ KUMAR KULSHRESTHA" id="Service_Building_Plan_txtStructuralEngineer" class="input-sm similar-select1">
                        </div>
                    </div>--%>
                    <div class="clearfix"></div>
                    <hr class="myhrline">

                    <div class="panel-heading font-bold">Important Facts</div>
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Service  Type
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                            <asp:Label ID="lblservicetype" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Approved Complex Type :
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                           <asp:Label ID="lblcomplextype" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span> Approved Sub-Complex Type
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                           <asp:Label ID="lblsubcomplextype" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>
                        
                    </div>


<div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">
                        

                            <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Name of Facility :
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                           <asp:Label ID="lblfacilityname" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>


</div>

                <div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Name Of Project (As per Registered In RERA)
                        </label>
                        <div class="col-md-4" style="font-weight:500;font-size:14px">
                             <asp:Label ID="lblprojectname" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>

                        


                    </div>

                    
                    <div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">

                         <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Name Of Developer/ Lead Members
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                             <asp:Label ID="lbldevelopername" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>



                        </div>



                    <div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">

                         <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Completion Number
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                             <asp:Label ID="lblcompnum" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                            
                            </div>


                             <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Completion Date
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                             <asp:Label ID="lblcompdate" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>
                        



                        </div>

                    
                    <div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">

                         <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Land Use Type
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                             <asp:Label ID="lbllandusetype" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>
                         

                         <%--<label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Completion Date
                        </label>
                        <div class="col-md-3">
                             <asp:Label ID="lblcompletedt" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>--%>


                        </div>


 
                    <div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">

                         <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Activity As Per Sale Deed
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                             <asp:Label ID="lblactivityonsale" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>
                         

                         <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Activity As Per Completed Layout
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                             <asp:Label ID="lblactivityoncomplete" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>


                        </div>






                    <div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">

                         <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Plot No.
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                             <asp:Label ID="lblplotno" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>



                        </div>

















                    <div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Block No.
                        </label>
                        <div class="col-md-9" style="font-weight:500;font-size:14px">
                              <asp:Label ID="lblblockno" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>
                    </div>



                    <div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Area As Per Layout(In Sqm)
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                              <asp:Label ID="lblarealayout" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>



                         <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Area As Per Sale Deed(In Sqm)
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                              <asp:Label ID="lblareasaledeed" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>
                    </div>




 <div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Name Of Authorized Person
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                              <asp:Label ID="lblauthorizedpersonname" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>




                         
                   
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Name Of Owner
                        </label>
                        <div class="col-md-3" style="font-weight:500;font-size:14px">
                              <asp:Label ID="lblownername" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                        </div>
                    



                    </div>



                     <div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Authorization Letter
                        </label>
                        <div class="col-md-9" style="font-weight:500;font-size:14px">
                             <asp:Label ID="lblauthoriedletter" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
                            
                              <a class="input-sm similar-select1" runat="server" id="authoriedletter" target="_blank">
                                  <span><i class="fa fa-eye"></i></span>


                              </a>
                         <%--   <embed src="filename.pdf#toolbar=0" width="500" height="375">--%>
                        </div>
                    </div>












                     <div class="clearfix"></div>
                    <hr class="myhrline">


                     <div class="panel-heading font-bold">Important Facts</div>


                    <div class="form-group">
                       <%-- <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Service  Type
                        </label>--%>
                        <div class="col-md-9" style="font-weight:500;font-size:14px">
                            <%--<asp:Label ID="Label1" runat="server" class="input-sm similar-select1" Text=""></asp:Label>--%>

                            <asp:GridView ID="grdview" class="table table-striped table-bordered table-hover request-table" runat="server">




                              </asp:GridView>





                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline">


                    <%--<div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Structural Engineer Registration No :
                        </label>
                        <div class="col-md-9">
                            <input name="Service_Building_Plan$txtStructuralEngineerRegistratinNo" type="text" value="M-1636949" id="Service_Building_Plan_txtStructuralEngineerRegistratinNo" class="input-sm similar-select1">
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline">
                    <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Address of Structural Engineer:
                        </label>
                        <div class="col-md-9">
                            <input name="Service_Building_Plan$txtStructuralEngineerAddress" type="text" value="E-531 KAMLA NAGAR AGRA" id="Service_Building_Plan_txtStructuralEngineerAddress" class="input-sm similar-select1">
                        </div>
                    </div>
                    <div>
                                <input type="submit" name="Service_Building_Plan$btnSaveArchitect" value="Submitted" id="Service_Building_Plan_btnSaveArchitect" disabled="disabled" class="aspNetDisabled btn-primary ey-bg" style="float: right;margin: 8px 0;">
                            </div>--%>
                            <div class="clearfix"></div>
                            <hr class="myhrline">
                   
                </div>
            </div>
        </div>
    












       <script type="text/javascript">



           $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });

           function ShowMessage() {
               alert('Your Application Is submitted Successfully');
               window.location.href = 'ServiceRequestSubmitted.aspx';

           }
           function ShowGroups() {

               $("#btnNewGroup").click();
           }

           var prm = Sys.WebForms.PageRequestManager.getInstance();
           prm.add_endRequest(function (sender, e) {
               $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });


               function ShowMessage() {
                   alert('Your Application Is submitted Successfully');
                   window.location.href = 'ServiceRequestSubmitted.aspx';

               }
               function ShowGroups() {

                   $("#btnNewGroup").click();
               }

           });
       </script>


                                        





                                </div>
                            </div>
                        </div>

<%--                    <table class="table table-striped table-bordered table-hover">
                    <tr style="display: none;">
                        <td colspan="2" style="text-align:left;">
                            <span>Executive authority to intimate:</span>
                            <asp:Label ID="lblAuthority" runat="server" Text=""></asp:Label>
                            <span>Email ID:</span>
                            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                            <span>Phone No:</span>
                            <asp:Label ID="lblPhoneNumber" runat="server" Text=""></asp:Label>
                            <asp:Label runat="server" ID="checkcon" Visible="false"></asp:Label>
                        </td>
                    </tr>

                    <tr style="display: none;">
                        <td class="auto-style2">
                            <span style="color: Red">*</span>
                            Date of lease deed :
                        </td>
                        <td>
                            <asp:TextBox ID="txtLeaseDeed" runat="server" class="form-control" Width="250px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>


                    <tr id="lableMessage" runat="server"  style="display:none;"  visible="false">
                        <td style="display: none;"  colspan="2">
                            <span style="color: Red">Your LeaseDeed Details are not Available with us .Kindly Raise a Request to UPSIDE to Update the Records For Your Leased</span>
                        </td>
                    </tr>


                </table>--%>
</div>
                          </div>
                    </div>
                </div>
            </div>
        <%--</form>--%>

