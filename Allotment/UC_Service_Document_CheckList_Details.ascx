<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Service_Document_CheckList_Details.ascx.cs" Inherits="Allotment.UC_Service_Document_CheckList_Details" %>



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
                            <p>Application Checklist</p>
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
                    <div class="panel-heading text-left" style="font-weight:500;font-size:14px">Application Checklist</div>
                     <div class="form-group">
                        <label class="col-md-3 text-right">
                            <span style="color: Red">*</span>Ex-LIDA Service Request No
                        </label>
                        <div class="col-md-9" style="font-weight:500;font-size:14px">
                            <asp:Label ID="lbllidaserviceid" runat="server" class="input-sm similar-select1" Text=""></asp:Label>
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
                      <div class="form-group">
                      <asp:GridView ID="grdview" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover request-table" runat="server">

                          <Columns>
                              <asp:TemplateField HeaderText = "Sr.No." ItemStyle-Width="100">
        <ItemTemplate>
            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
                           
                              
               <asp:BoundField DataField="ServiceTimelineDocuments" HeaderText="Documents CheckList" />
   <asp:TemplateField HeaderText="URL" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="false">
            <ItemTemplate>
             <img src='<%#Eval("upload_url") %>' width="120px" alt="" />             
            </ItemTemplate>
     </asp:TemplateField>          
                              
            <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:LinkButton ID="imgview" OnClientClick="window.document.forms[0].target='_blank';" runat="server"  CommandArgument='<%# Eval("upload_url") %>' OnClick="imgview_Click" ToolTip="View" CausesValidation="false" ><i class="fa fa-eye"></i></asp:LinkButton>
        </ItemTemplate>
        </asp:TemplateField>

<asp:TemplateField  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
       <%-- <ItemTemplate>
            <asp:LinkButton ID="imgDownload" runat="server" OnClick="imgDownload_Click" ToolTip="Download" CausesValidation="false" CommandArgument='<%# Eval("upload_url") %>' ><i class="fa fa-download"></i></asp:LinkButton>
        </ItemTemplate>--%>
        </asp:TemplateField>



                          </Columns>


                              </asp:GridView>
                          </div>
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
