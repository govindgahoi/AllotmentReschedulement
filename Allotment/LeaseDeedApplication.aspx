<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaseDeedApplication.aspx.cs" Inherits="Allotment.LeaseDeedApplication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
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


    <script type="text/javascript">

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();
        }
    
           function MessageAndRedirect(par) {
           alert("Objection cleared and form re-submitted succesfully");
           window.location.href = 'LeaseDeedApplication.aspx?ViewID=' + par;
        }
    </script>

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
    <script type="text/javascript">

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();
        }

   
            $("[src*=plus]").live("click", function () {
                $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
                $(this).attr("src", "images/minus.png");
            });
            $("[src*=minus]").live("click", function () {
                $(this).attr("src", "images/plus.png");
                $(this).closest("tr").next().remove();
            });

        
    </script>
        
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
       <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">
               <Triggers>
            <asp:PostBackTrigger ControlID="radioByPlotNo" />
                   <asp:PostBackTrigger ControlID="radioByAllotmentNo" />
                    <asp:PostBackTrigger ControlID="radioByAllotmentNo" />
                    <asp:PostBackTrigger ControlID="drpIndusrialArea" />
                    <asp:PostBackTrigger ControlID="drpPlotNo" />
           
        </Triggers>

         
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                    <ProgressTemplate>
                        <div class="fgh">
                            <div class="hgf text-center">
                              <span style="font-size:25px;font-weight:bold;">Please Wait...</span><br /> <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                                
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>

        
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
                              <div class="panel-heading col-md-12 font-bold" style="font-size: 14px !important; font-weight: 600;"><div  class="col-md-6 col-sm-6 col-xs-6 text-left">उत्तर प्रदेश सरकार &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GOVERNMENT OF UTTAR PRADESH</div>
                                  <div class="col-md-6 col-sm-6 col-xs-6 text-right">
                      <asp:Button runat="server" ID="btn_backNmswp" Text="⇦ Go Back" CssClass="pull-right btn btn-info" Style="background-color:#02486d;color:#fff;font-weight:600;" OnClick="btn_backNmswp_Click"  />
                    </div></div>
                                    
                                    <div class="clearfix"></div>
                                    <div class="panel-heading font-bold text-center" style="font-size: 14px !important; font-weight: 600; background: #2d2d2d; color: #ffc511 !important;"><asp:Label runat="server" ID="lblservicename"></asp:Label></div></div>
                    </div>
                </div>
         
            </div>  
               
                
            <div class="row" id="SideDiv">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading text-center">Application For Lease Deed</div>
                        <hr class="separation" />
                        <div runat="server" id="divSearch" visible="false">
                        <div class="form-group" style="background: #dedede;padding: 2px 0;border: 1px solid #ccc;">
                            <label class="col-md-2">
                                Search Record:
                            </label>
                            <div class="col-md-10">
                                <asp:RadioButton Text=" By Plot No" runat="server" ID="radioByPlotNo" GroupName="radio" OnCheckedChanged="radioByPlotNo_CheckedChanged" AutoPostBack="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:RadioButton Text=" By Allotment No" GroupName="radio" runat="server" ID="radioByAllotmentNo" OnCheckedChanged="radioByAllotmentNo_CheckedChanged" AutoPostBack="true" />
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div runat="server" id="DivFilterIA" visible="false">
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-2 text-right">
                                Industrial Area:
                            </label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="drpIndusrialArea" CssClass="chosen input-sm similar-select1 margin-left-z" OnSelectedIndexChanged="drpIndusrialArea_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <label class="col-md-2  text-right">
                                Plot No:
                            </label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="drpPlotNo" CssClass="chosen input-sm similar-select1 margin-left-z" OnSelectedIndexChanged="drpPlotNo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>    
                            </div>
                        </div>
                           
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                             </div>
                            <div runat="server" id="DivFilterLetter" visible="false">
                        <div class="form-group">
                            <label class="col-md-4 text-right">
                                Enter Your Allotment Letter Number:
                            </label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtServiceReqNo" runat="server" CssClass="input-sm similar-select1" OnTextChanged="txtServiceReqNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div class="clearfix"></div>
                                 <hr class="separation" />
                            </div>
                       
                            </div>
               
                      
                        <div class="panel panel-default" style="border: 1px solid #ccc;" runat="server" id="AllotteeDiv" visible="false">
                            <div class="col-md-12 col-sm-12 col-xs-12 pad-rt0 pad-lt0">
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
                                         <div class="" runat="server" id="EligibleDiv" visible="false">
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
                                         <div class="" runat="server" id="AvailDiv" visible="false">
                                              <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                       Are you interested for stamp duty rebate ? :
                                               </label>
                                              <div class="col-md-2 col-sm-6 col-xs-6">
                                                        
                                                            <asp:Label runat="server" ID="eligiblelbl"></asp:Label>
                                                    </div>
                                             <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                       Are you eligible for stamp duty rebate ? :
                                               </label>
                                              <div class="col-md-2 col-sm-6 col-xs-6">
                                                        
                                                            <asp:Label runat="server" ID="lblAvail"></asp:Label>
                                                    </div>
                                         </div>
                                         <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                     </div>
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
                       <div runat="server" id="RODeatailDiv" visible="false">
                                                     <div class="form-group">
                                         <div class="">
                                              <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                       Appointment Date in registrar office :
                                               </label>
                                              <div class="col-md-8 col-sm-6 col-xs-6">
                                                        <asp:Label runat="server" ID="lblRoDate"></asp:Label>
                                                    </div>
                                             </div><div class="clearfix"></div>
                                            <hr class="myhrline" />
                                                         <div class="form-group">
                                                             <div class="">
                                             <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                       Remarks:
                                               </label>
                                              <div class="col-md-8 col-sm-6 col-xs-6">
                                                       <asp:Label runat="server" ID="lblRemarks"></asp:Label>
                                                    </div>
                                         </div></div>
                                         <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                     </div>
                                            </div>
                                    </div>
                                </div>
                            </div>
                          
                        </div>
                        
                            </div>
                                                                  
                        </div>
                          <div runat="server" id="EmailDiv" visible="false">
                                 <div class="form-group">
                            <label class="col-md-2 text-right">
                               Email ID:
                            </label>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtemail" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="separation" /></div>
                     <div runat="server" id="MobileDiv" visible="false">
                                    <div class="form-group">
                            <label class="col-md-2 text-right">
                                Mobile No:
                            </label>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtmobile" runat="server" CssClass="input-sm similar-select1" MaxLength="10"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div></div>
                                        </div>
                    <div class="panel panel-default" style="border: 1px solid #ccc;" runat="server" id="DivDoc" visible="false">
                          <div class="clearfix"></div>
                        <hr class="separation" />
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
                            <div class="text-center"><asp:Button runat="server" ID="btnLeaseDeed" style="font-size: 12px;margin: 3px 0;" CssClass="btn-primary ey-bg" Text="Apply For Lease Deed" OnClick="btnLeaseDeed_Click"/></div>
                    </div>
                        
                        
                    <div class="panel panel-default" style="border: 1px solid #ccc;" runat="server" id="DivApply" visible="false">
                        <div class="clearfix"></div>
                        <hr class="separation" />
                            <div class="col-md-12 col-sm-12 col-xs-12 pad-rt0 pad-lt0">
                                <div class="">
                                    <div class="panel-heading font-bold text-center">
                                       Payment Description                        
                                    </div>
                                    <div class="panel-body" style="padding: 0px !important;">
                                        <div class="div-companydetail" style="background: #ececec;">
                                          <table class="table table-striped table-bordered table-hover request-table">
                                              <tr><th>Service Ref No</th><th>Processing Fee</th><th>GST 18%</th><th>Total Amount</th><th>Action</th></tr>
                                              <tr><td><asp:Label runat="server" ID="lblServiceRefNo"></asp:Label></td><td><i class="fa fa-inr"></i><asp:Label runat="server" ID="lblAmount"></asp:Label></td><td><i class="fa fa-inr"></i><asp:Label runat="server" ID="lblGSTAmount"></asp:Label></td><td><i class="fa fa-inr"></i><asp:Label runat="server" ID="lbl_TotalAmount"></asp:Label></td><td><asp:Button runat="server" ID="btnPay"  CssClass="btn-primary ey-bg pull-centers" Text="Pay & Apply" OnClick="btnPay_Click" Visible="false" /><asp:Button runat="server" ID="btn_Submit"  CssClass="btn-primary ey-bg pull-centers" Text="Submit" OnClick="btn_Submit_Click" Visible="false" /></td></tr>
                                          </table>
                       </div>
                                       
                   </div></div></div></div>
                                            
                    <div class="panel panel-default" style="border: 1px solid #ccc;" runat="server" id="DivPayment" visible="false">
                        <div class="clearfix"></div>
                        <hr class="separation" />
                            <div class="col-md-12 col-sm-12 col-xs-12 pad-rt0 pad-lt0">
                                <div class="">
                                    <div class="panel-heading font-bold text-center">
                                       Payment Description                        
                                    </div>
                                    <div class="panel-body" style="padding: 0px !important;">
                                        <div class="div-companydetail" style="background: #ececec;">
                                          <table class="table table-striped table-bordered table-hover request-table">
                                              <tr><th>Service Ref No</th><th>Transaction Ref No</th><th>Transaction Amount</th><th>Transaction Date</th><th>Payment Mode</th><th>Bank Ref No</th><th>Payment Status</th><th>View Receipt</th></tr>
                                              <tr><td><asp:Label runat="server" ID="lblServiceNo"></asp:Label></td><td><asp:Label runat="server" ID="lblTraRefNo"></asp:Label></td>
                                                  <td><asp:Label runat="server" ID="lblTraAmount"></asp:Label></td>
                                                  <td><asp:Label runat="server" ID="lblTraDate"></asp:Label></td>
                                                  <td><asp:Label runat="server" ID="lblPaymentMode"></asp:Label></td>
                                                  <td><asp:Label runat="server" ID="lblBankRefNo"></asp:Label></td>
                                                  <td><asp:Label runat="server" ID="lblPaymentStatus"></asp:Label></td>
                                                  <td><asp:Button runat="server" ID="btnReceipt"  CssClass="btn-primary ey-bg pull-centers" Text="View" OnClick="btnReceipt_Click" /></td></tr>
                                          </table>
                       </div>
                                       
                   </div></div></div></div>
                       
                    <div class="panel panel-default" style="border: 1px solid #ccc;" runat="server" id="Div_Appointment" visible="false">
                          <div class="clearfix"></div>
                        <hr class="separation" />
                            <div class="col-md-12 col-sm-12 col-xs-12 pad-rt0 pad-lt0">
                                <div class="">
                                    <div class="panel-heading font-bold text-center">
                                       Appointment Schedules                        
                                    </div>
                                    <div class="panel-body" style="padding: 0px !important;">
                                        <div class="div-companydetail" style="background: #ececec;">
                                            <asp:GridView ID="GridView1" runat="server"
             CssClass="table table-striped table-bordered table-hover request-table request-table"
           
            AllowSorting="True"
            AutoGenerateColumns="False"
            DataKeyNames="ID"
            GridLines="Horizontal"
            Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:BoundField DataField="AppointmentType" HeaderText="Appointment Type" SortExpression="AppointmentType" />
                <asp:BoundField DataField="AppointmentDesc" HeaderText="Appointment Description" SortExpression="AppointmentDesc" />
                <asp:BoundField DataField="CreatedOn"       HeaderText="Created On" SortExpression="CreatedOn" />
                <asp:BoundField DataField="AppStatus"       HeaderText="Appointment Status" SortExpression="AppStatus" />
                
            </Columns>
            <EmptyDataTemplate>
                No Record Available
            </EmptyDataTemplate>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
                                            </div>
                                       
                   </div></div></div></div>                   
                    
                    <div class="panel panel-default" style="border: 1px solid #ccc;" runat="server" id="RODiv" visible="false">
                         <div class="clearfix"></div>
                        <hr class="separation" />
                            <div class="col-md-12 col-sm-12 col-xs-12 pad-rt0 pad-lt0">
                                <div class="">
                                    <div class="panel-heading font-bold text-center">
                                       Registry Office Appointment Details (To Be Entered By Allottee)                        
                                    </div>
                                    <div class="panel-body" style="padding: 0px !important;">
                                          <div class="form-group">
                            <label class="col-md-5 text-right">
                                Enter Your Date Of Appointment In The Registry Office :
                            </label>
                            <div class="col-md-7">
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div class="clearfix"></div></div>
                        <hr class="separation" />
                                    <div class="form-group">
                            <label class="col-md-5 text-right">
                                Enter Your Remarks (If Any):
                            </label>
                            <div class="col-md-7">
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="input-sm similar-select1" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div>
                                          <span class="pull-right"><asp:Button runat="server" Text="Update" id="btnUpdate" class="btn-primary btn-sm margin-left-z" style="margin: 7px 10px;" OnClick="btnUpdate_Click" /></span>

                        </div>
                        <div class="clearfix">                                 
                   </div></div></div>
                     
                        
                    </div>

                    <div>
                    <div id="Objection_Div" style="border: 1px solid #ccc;" runat="server" visible="false">
                                        <asp:PlaceHolder ID="PH_Objection" runat="server"></asp:PlaceHolder>
                     </div>
                   </div>

                     <div class="text-center"><asp:Button runat="server" Text="View Registered Lease Deed" id="Button1" Visible="false" OnClick="Button1_Click" class="btn-primary btn-sm margin-left-z" style="margin: 7px 10px;" /><asp:Button runat="server" Visible="false" Text="View Possession Memo" id="Button2" class="btn-primary btn-sm margin-left-z" style="margin: 7px 10px;" OnClick="Button2_Click" /></div>

                </div>
            </div>
                      
        </div>
                  </ContentTemplate>
        </asp:UpdatePanel>
    </form>

    <script language="javascript" type="text/javascript">
        $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
            $(this).blur();
            $(this).datepicker('hide');
        });


        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });;

        });
    </script>
</body>

</html>
