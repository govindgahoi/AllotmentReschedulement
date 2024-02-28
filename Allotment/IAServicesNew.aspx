<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IAServicesNew.aspx.cs" Inherits="Allotment.IAServicesNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet"/>
    <script src="js/jquery-ui.js"></script>
    <script src="js/chosen.jquery.min.js"></script>


 
    <style type="text/css">
        .form-group label{
            margin-bottom:0;
        }
        .form-group input[type='radio'] {
            margin-right:3px;
        }

        @media screen and (max-width: 768px) {
            .form-group .col-xs-6 {
                width: 50% !important;
            }
        }

        .content {
            min-height: 600px;
        }

        #UpdateProgress1 {
            position: fixed;
            width: 100%;
            height: 100%;
            z-index: 99999;
            background: rgba(0,0,0,0.21176470588235294);
        }

            #UpdateProgress1 .fgh {
                position: absolute;
                top: 10%;
                margin: 0px auto;
                left: 45%;
                z-index: 999;
            }
                   h4.modal-title {
            margin-right: 18px !important;
        }

        .mynew-panel-head {
            font-size: 14px !important;
            font-weight: 600;
            background: #2d2d2d;
            color: #ffc511 !important;
            text-align: center !important;
        }

        .modal.fade.in {
            background: rgba(0, 0, 0, 0.51);
           /*  background:none !important;
           display:none !important;*/
        }
        .modal-backdrop {
            background:none !important;
        }

        .modal-backdrop.in {
    display: none  !important;
}
        @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 11%;
            }
            #ModalGridchange .modal-dialog{
                top:10% !important;
                left:14% !important;
            }
        }

          @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 11%;
            }
            #ModalGridchange1 .modal-dialog{
                top:10% !important;
                left:14% !important;
            }
        }


           @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 11%;
            }
            #ModalGridchange2 .modal-dialog{
                top:10% !important;
                left:14% !important;
            }
        }

        .modal-header {
            padding: 2px !important;
        }
     
    </style>
    <script>
        function ShowTermsAndCondition() {
            $("#btnModalTerms").click();
        }

        function RemoveSpaces(string) {
            return string.split(' ').join('');
        }  


        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();
        }

    </script>
        
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
            
  <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">
       <Triggers>
            <asp:PostBackTrigger ControlID="btn_backNmswp" />
        </Triggers>
            <ContentTemplate>

                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                    <ProgressTemplate>
                        <div class="fgh">
                            <div class="hgf text-center">
                                <span style="font-size: 25px; font-weight: bold;">Please Wait...</span><br />
                                <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>

                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>

                <div class="modal fade" id="myModal" role="dialog" tabindex="-1">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title mynew-panel-head text-center">Transfer Conditions</h4>
                            </div>
                            <div class="modal-body">
                                <div class="scr" id="agreement" style="font-size: 12px; padding: 4px 15px; overflow: auto; height: 130px;">
                                    <div class="form-group">
                                        <label class="col-md-6 text-right">
                                            Condition for Transfer of Plot:
                                        </label>
                                        <div class="col-md-6">
                                            <asp:DropDownList runat="server" ID="DropDown" CssClass="input-sm similar-select1 margin-left-z">
                                                <asp:ListItem Value="1">Normal Case of Trasfer</asp:ListItem>
                                                <asp:ListItem Value="2">Trasfer as per Court/Bank Auction</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="modal-footer">
                                <div class="pull-right border-buttons">
                                    <asp:Button ID="btnIAccept" runat="server" OnClick="btnIAccept_Click" CssClass="btn btn-sm btn-primary btn-popup" Style="margin-right: 3px;" Text="Proceed" />
                                    <button type="button" id="closeBtn" class="btn btn-primary btn-popup" data-dismiss="modal" style="margin-right: 0;">Cancel</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                        <input type="button" id="btnModalTerms" style="display: none;" data-toggle="modal" data-target="#myModal" data-backdrop="static" />
 
        <div class="container">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                          <div class="panel panel-default">
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
                                              
                                                <h2 id="chg_head">Nivesh Mitra</h2>
                                                <p><span style="font-size:20px;">Single Window Portal</span> ,Govt. of Uttar Pradesh</p>
                                            </div>
                                            <div class="col-md-3 col-sm-4 col-xs-12 right-niveshban">
                                                <ul class="mylogo-ul list-inline" style="margin: 0; padding: 6px 0 9px 1px;margin-left:170px;">
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
                              <div class="panel-heading col-md-12 font-bold" style="font-size: 14px !important; font-weight: 600;">
                                  <div class="col-md-6 col-sm-6 col-xs-6 text-left">उत्तर प्रदेश सरकार &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GOVERNMENT OF UTTAR PRADESH</div>
                                  <div class="col-md-6 col-sm-6 col-xs-6 text-right">
                                      <asp:Button runat="server" ID="btn_backNmswp" Text="⇦ Go Back" CssClass="pull-right btn btn-info" Style="background-color: #02486d; color: #fff; font-weight: 600;" OnClick="btn_backNmswp_Click" />
                                  </div>

                              </div>
                                    <div class="clearfix"></div>
                                    <div class="panel-heading font-bold text-center" style="font-size: 14px !important; font-weight: 600; background: #2d2d2d; color: #ffc511 !important;"><asp:Label runat="server" ID="lblservicename"></asp:Label></div></div>
                    </div>
                </div>
         
            </div>         
             <div class="clearfix"></div>
            <div  id="SideDiv">
                <div class="row">
                    <div class="">
                    <div class="panel panel-default" runat="server" id="FilterDiv" style="margin-top:12px;">
                        
                      
                
                        <div class="form-group">
                            <label class="col-md-2 text-right">
                                Industrial Area:
                            </label>
                            <div class="col-md-2">
                                <asp:DropDownList runat="server" ID="drpIndusrialArea" CssClass="chosen input-sm similar-select1 margin-left-z" ></asp:DropDownList>
                            </div>
                            <label class="col-md-1 text-right">
                                Plot Type:
                            </label>
                            <div class="col-md-2">
                                <asp:DropDownList runat="server" ID="drpPlotType" CssClass="chosen input-sm similar-select1 margin-left-z" >
                                
                                </asp:DropDownList>
                            </div>
                            <label class="col-md-1  text-right">
                                Plot No:
                            </label>
                            <div class="col-md-2">
                              <asp:TextBox runat="server" ID="txtPlotNo" CssClass="margin-left-z input-sm similar-select1"></asp:TextBox>
                            </div>
                            
                            <div class="col-md-2">
                           <asp:Button runat="server" ID="btnfind" Text="Find" CssClass="btn-group-lg alert-success" OnClick="btnfind_Click" />
                            </div>
                        </div>
                           
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div id="DivOTP" runat="server" visible="false">
                        <div class="form-group" style="margin-top:1px;">
                            <label class="col-md-4 text-right">
                                Enter OTP:
                            </label>
                            <div class="col-md-2">
                               <asp:TextBox runat="server" ID="txtOTP" CssClass="margin-left-z input-sm similar-select1"></asp:TextBox></div>
                           
                        <div class="col-md-4">
                               <asp:Button runat="server" ID="Button1" Text="Verify" OnClick="Button1_Click" CssClass="btn-group-lg alert-success"  />
                            </div>
                             </div></div>
                            
               </div>
                    <br />
                    <div class="panel panel-default" style="border: 1px solid #ccc;" runat="server" id="AllotteeDiv" visible="false">
                        
                            <div class="">
                                <div class="">
                                    <div class="panel-heading font-bold text-center">
                                        Allottee Details                         
                                    </div>
                                    <div class="panel-body" style="padding: 0px !important;">
                                        <div class="div-companydetail" style="background: #ececec;">
                                            <div class="form-group">
                                                <div class="">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Regional Office :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblRegionalOffice" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Industrial Area : 
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblIndustrialArea" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Date of Allotment :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblDateofApplication" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <asp:Label runat="server" ID="lblAllotteeID" Visible="false"></asp:Label>
                                                <asp:Label runat="server" ID="lblIAID" Visible="false"></asp:Label>
                                                <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
                                                <div class="">
                                                  <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Plot Area :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblplotarea" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Allottment Letter No :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblAllotmentLetterNo" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Plot No :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblPlotNo" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Allottee Name :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblAllotteeName" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Firm/Company Name :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblFirmCompanyName" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                      Firm Constitution :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblCompanyConstitution" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Mobile No :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblSignatoryMobile" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Address :   
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblAddress" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                         Email ID : 
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblSIgnatoryEmail" runat="server" CssClass="font-bold"></asp:Label>
                                                        </em>
                                                    </div>
                                                </div>
                                            </div>
                                                 <div class="clearfix"></div>
                                            <hr class="myhrline" />  
                                            <div class="form-group">
                                                <div class="">
                                                    <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                       Service Applying For :
                                                    </label>
                                                    <div class="col-md-5 col-sm-6 col-xs-6">
                                                        <asp:DropDownList ID="ddlServices" runat="server" CssClass="chosen input-sm similar-select1 margin-left-z" Enabled="false">
                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1003">Change Of Project</asp:ListItem>
                                                            <asp:ListItem Value="1004">Addition Of Product</asp:ListItem>
                                                            <asp:ListItem Value="1001">Request For Execution & Registration of Lease Deed </asp:ListItem>
                                                            <asp:ListItem Value="200">Online Payment of Reservation Money</asp:ListItem>                                                      
                                                            <asp:ListItem Value="1005">Request For Issuance Of NOC For Mortage</asp:ListItem>
                                                            <asp:ListItem Value="1006">Request For Issuance Of NOC For Joint Mortgage</asp:ListItem>
                                                            <asp:ListItem Value="1007">Request For Permission For Creation Of Second Charge</asp:ListItem>
                                                            <asp:ListItem Value="1011">Application for  Transfer of lease deed</asp:ListItem>
                                                            <asp:ListItem Value="1002">Application for  Time Extenstion Fee</asp:ListItem>
                                                            <asp:ListItem Value="4">Request for Transfer of Plot</asp:ListItem>
                                                            <asp:ListItem Value="1023">Request for No Dues Certificate</asp:ListItem>
                                                            <asp:ListItem Value="1027">Request for Outstanding dues position</asp:ListItem>
                                                            <asp:ListItem Value="1028">Online Payment of Outstanding Dues</asp:ListItem>
                                                            <asp:ListItem Value="1021">Request for legal heir after death</asp:ListItem>
                                                            <asp:ListItem Value="1017">Request for handover of lease deed to the lessee</asp:ListItem>
                                                            <asp:ListItem Value="1008">Request for reconstitution allottee firm / company</asp:ListItem>
                                                            <asp:ListItem Value="1014">Application for  Start of Production Certificate</asp:ListItem>
                                                            <asp:ListItem Value="1012">Application for Restoration of plot</asp:ListItem>
                                                            <asp:ListItem Value="1024">Request for Surrender of Plot</asp:ListItem>
                                                            <asp:ListItem Value="1025">Request for Establishment of Additional Unit</asp:ListItem>
                                                            <asp:ListItem Value="1026">Request for Subletting of Plot </asp:ListItem>
                                                            <asp:ListItem Value="1029">Request for Amalgamation Post Allotment </asp:ListItem>
                                                              </asp:DropDownList>
                                                     </div>
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>                                               
                                                </div>
                                            </div>
                                             <div class="clearfix"></div>
                                            <hr class="myhrline" />  
                                            <div class="form-group">
                                                <div class="">
                                                    <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                       Enter GST No :
                                                    </label>
                                                    <div class="col-md-5 col-sm-6 col-xs-6">
                                                           <asp:TextBox ID="txtGstNo"  class="input-sm myyellowbgsmall" Style="height:24px !important;" runat="server" Text='' Width="100%" placeholder="Enter GST No"></asp:TextBox>
                                  
                                                        </div>
                                                    </div>

                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" /> 
                                            <div runat="server" id="LeaseDeedDiv" visible="false">
                                               <div class="form-group">
                                        
                                              <label class="col-md-6 col-sm-6 col-xs-6 text-right">
                                                       Are you interested for stamp duty rebate ? :
                                               </label>
                                              <div class="col-md-6 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:CheckBox runat="server" ID="StampChk1s" OnCheckedChanged="StampChk1s_CheckedChanged" AutoPostBack="true" />
                                                        </em>
                                                  &nbsp;&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" Target="_blank"  Text="Please Refer Govt Order for Eligibility" NavigateUrl="~/DirImageView.aspx"> </asp:HyperLink>                              
                                             
                                              </div>
                                              
                                                                              
                                     </div>
                                       
                                             <div class="clearfix"></div>
                                            <hr class="myhrline" /> 
                                             <div runat="server" id="RebateDiv" visible="false">
                                                     <div class="form-group">
                                         <div class="">
                                              <label class="col-md-6 col-sm-6 col-xs-6 text-right">
                                                       Are you eligible for stamp duty rebate ? :
                                               </label>
                                              <div class="col-md-6 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:CheckBox runat="server" ID="AvailChk" /></em>
                                                    </div>
                                         </div>
                                         <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                     </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" /> 
                                            <div class="col-md-12 col-sm-12 col-xs-12 pad-rt0 pad-lt0">
                                <div class="">
                                    <div class="panel-heading font-bold text-center">
                                       List of documents required to be submitted                         
                                    </div>
                                    <div class="panel-body" style="padding: 0px !important;">
                                        <div class="div-companydetail" style="background: #ececec;">
                                           <asp:GridView ID="GridView2" runat="server" 
                                                    CssClass="table table-striped table-bordered table-hover request-table"
                                                   
                                                    AutoGenerateColumns="False"
                                                    DataKeyNames="ServiceCheckListsID"
                                                    GridLines="Horizontal" 
                                                 
                                                    Width="100%"
                                                    >
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
               
                                                        <asp:BoundField DataField="ServiceTimeLinesCondition" HeaderText="Checklist" SortExpression="ServiceTimeLinesCondition" />
                                                        <asp:BoundField DataField="ServiceTimeLinesDocuments" HeaderText="Checklist Description" SortExpression="ServiceTimeLinesDocuments" />
                           
                            
                            
                                                        <asp:TemplateField HeaderText="Acknowledge">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle  />
                                                            <ItemTemplate>
                                   
                           <asp:CheckBox ID="chkAck" runat="server" />                                       


                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        No Record Available
                                                    </EmptyDataTemplate>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle Font-Bold="True" ForeColor="Black" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <RowStyle ForeColor="#000066" HorizontalAlign="Left" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
                       </div>
                                       
                                        </div></div></div>

                                    </div>
                                </div>
                            </div>
                          
                        </div>
                                         <div class="text-center"><asp:Button runat="server" ID="btnRaise" style="font-size: 16px;margin: 3px 0;" CssClass="btn-primary" Text="Apply" OnClick="btnRaise_Click" /></div>  
                 

                     </div>
                </div>    
                
                 </div>
            </div>
        </div>
       </div>
           </ContentTemplate>
        </asp:UpdatePanel>
    </form>

   
</body>

</html>
