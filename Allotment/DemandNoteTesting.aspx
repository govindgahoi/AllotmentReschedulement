<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemandNoteTesting.aspx.cs" Inherits="Allotment.DemandNoteTesting" %>

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
    <script type="text/javascript">

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
     
        <div class="container">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                        <a href="Default.aspx" class="navbar-brand">
                            <div class="col-md-8">
                                <img class="img-responsive" src="logo.jpg" />
                            </div>
                            <div class="col-md-4">
                                <img class="img-responsive" src="Image.jpg" />
                            </div>
                        </a>
                    </div>
                </div>
                <div id="main_menu" runat="server"><% Response.WriteFile("top_mainmenu.aspx"); %> </div>
            </div>               
            <div  id="SideDiv">
                <div class="row">
                    <div class="">
                    <div class="panel panel-default">
                        <div class="panel-heading text-center">Application For UPSIDA Services</div>
                        <div class="clearfix"></div>
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
               </div></div>
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
                
                                    </div>
                                </div>
                            </div>
                          
                        </div>
                                         <div class="text-center"><asp:Button runat="server" ID="btnRaise" style="font-size: 16px;margin: 3px 0;" CssClass="btn-primary" Text="Generate" OnClick="btnRaise_Click" /></div>  
                 

            <br /><br />
                    <div class="" runat="server" id="PreviousServiceDiv" visible="false">
                 <div class="panel panel-default">
                        <div class="panel-heading text-center">Demand Note</div>
                     </div>

                        <div class="panel-body">
                        <asp:GridView ID="AllGrid" runat="server"
                        CssClass="table table-striped table-bordered table-hover request-table request-table"
                        AutoGenerateColumns="true"
                         ShowFooter="true"    
                        GridLines="Horizontal"      
                        Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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

                        </div>

                        </div>
                </div>    
                
                 
            </div>
        </div>
       
    </form>

   
</body>

</html>
