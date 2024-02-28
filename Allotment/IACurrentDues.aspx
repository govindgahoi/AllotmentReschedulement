<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IACurrentDues.aspx.cs" Inherits="Allotment.IACurrentDues" %>

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
                top: 45%;
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
   
        
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
     
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
                                    <div class="panel-heading font-bold text-center" style="font-size: 14px !important; font-weight: 600; background: #2d2d2d; color: #ffc511 !important;"><asp:Label runat="server" ID="lblservicename" Text="Online Payment of Current Dues"></asp:Label></div></div>
                    </div>
                </div>
         
            </div>         
             <div class="clearfix"></div>     
            <div  id="SideDiv">
                <div class="row">
                  
                    <br />
                    <div class="panel panel-default" style="border: 1px solid #ccc;" runat="server" id="AllotteeDiv">
                        
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
                                            <div class="form-group" style="display:none;">
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
                                    </div>
                                </div>
                            </div>
                          
                        </div>
                                        

            <br /><br />

                                  <div  class="panel-body table-responsive">
                                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                                <div>
                                <asp:GridView ID="AllotteePaymentSummaruGrid" runat="server" ShowFooter="true" AutoGenerateColumns="false"  CssClass="table table-striped table-bordered table-hover request-table" OnRowDataBound="AllotteePaymentSummaruGrid_RowDataBound">
                                    <Columns>

                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField ="PaymentName"   HeaderText ="Payment Head"/>
                                        <asp:BoundField DataField ="Demanded"      HeaderText ="Demanded"    />
                                        <asp:BoundField DataField ="Paid"          HeaderText ="Paid"     />                                      
                                        <asp:BoundField DataField ="Outstanding"   HeaderText ="Outstanding"           />
                                       
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                    </div>
                            </div>
                 <div class="text-center"><asp:Button runat="server" ID="btn_PayNow" style="font-size: 16px;margin: 3px 0;" CssClass="btn-primary" Text="Pay Now"  OnClick="btn_PayNow_Click" /><asp:Button runat="server" ID="btn_Receipt" Visible="false" style="font-size: 16px;margin: 5px 8px;" CssClass="btn-primary" Text="View Receipt"   OnClick="btn_Receipt_Click" /></div>
                        </div>
                </div>    
                
                 
            </div>
        </div>
       
    </form>

    <script type="text/javascript">

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();
        }


    </script>

       <script type="text/javascript">

           $(document).ready(function () {
               Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
           });

           function PageLoaded(sender, args) {
               $(".chosen").chosen();
           } 

           function Alert() {
               alert("Online Payment facility for dues will be online soon...")
           }




    </script>
</body>

</html>
