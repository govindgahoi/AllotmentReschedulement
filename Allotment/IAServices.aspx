<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IAServices.aspx.cs" Inherits="Allotment.IAServices" %>

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
    <link href="css/chosen.min.css" rel="stylesheet" />
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
        .form-group label {
            margin-bottom: 0;
        }

        .form-group input[type='radio'] {
            margin-right: 3px;
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

            #ModalGridchange .modal-dialog {
                top: 10% !important;
                left: 14% !important;
            }
        }

        @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 11%;
            }

            #ModalGridchange1 .modal-dialog {
                top: 10% !important;
                left: 14% !important;
            }
        }


        @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 11%;
            }

            #ModalGridchange2 .modal-dialog {
                top: 10% !important;
                left: 14% !important;
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
                                <img class="img-responsive" src="/images/upsida-logo-name.png" />
                            </div>
                            <div class="col-md-4">
                                <img class="img-responsive" src="Image.jpg" />
                            </div>
                        </a>
                    </div>
                </div>
                <div id="main_menu" runat="server"><% Response.WriteFile("top_mainmenu.aspx"); %> </div>
            </div>
            <div id="SideDiv">
                <div class="row">
                    <div class="">
                        <div class="panel panel-default">
                            <div class="panel-heading text-center">Application For UPSIDA Services</div>
                            <div class="clearfix"></div>
                            <hr class="separation" />






                               <%--********************************Akshat Code****************--%>
                         <div class="" runat="server" id="divfamilyinfo" visible="false">
                              <div class="panel panel-default">
                           
                            <div class="clearfix"></div>
                            <hr class="separation" />
                             <div class="row">

                                 <div class="hidden-lg hidden-md">
                                     <div class="clearfix"></div>
                                 </div>
                                 <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                     Type of Applicant:
                                 </label>
                                  <style>
                                            input[type="CheckBox"] {
                                                margin-right: 10px;
                                            }
                                        </style>
                               <%--  <script type="text/javascript">
    function MutExChkList(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
    }
</script>--%>
                                
<script type="text/javascript">
    function MutExChkList(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
    }
</script>

                                 <div class="col-md-8 col-sm-6 col-xs-6">
                                     <em>
                                         <asp:CheckBoxList ID="chkinfo" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="drpPlotNo1_SelectedIndexChanged"  AutoPostBack="true">
                                             <asp:ListItem >Family&nbsp;&nbsp;</asp:ListItem>
                                             <asp:ListItem >Partners&nbsp;&nbsp;</asp:ListItem>
                                             <asp:ListItem >Mega or more investment&nbsp;&nbsp;</asp:ListItem>
                                             <asp:ListItem >Other &nbsp;&nbsp;</asp:ListItem>
                                        
                                         </asp:CheckBoxList></em>
                                         
                                 </div>


                                 </div>
                                  <br />

                                   <div class="row" runat="server" id="partnerinfo" visible="false">

                                 <div class="hidden-lg hidden-md">
                                     <div class="clearfix"></div>
                                 </div>
                                 <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                    Enter Date of Partnership: 

                                 </label>
                                  <div class="col-md-2 col-sm-6 col-xs-6">
                                     <em>

                                         <asp:TextBox ID="txtpartnershipDate" autocomplete="off" TextMode="Date" runat="server" CssClass="input-sm similar-select1">

                                         </asp:TextBox>


                                     </em>

                                 </div>
                                       </div>

                                <%-- <div class="col-md-2 col-sm-6 col-xs-6">
                                     <em>

                                         <asp:TextBox ID="txtCompletionDate" autocomplete="off" TextMode="Date" runat="server" CssClass="input-sm similar-select1"></asp:TextBox></em>
                                 </div>--%>
                                

                                <%-- <div class="hidden-lg hidden-md">
                                     <div class="clearfix"></div>
                                 </div>
                                 <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                     Completion ID :
                                 </label>
                                 <div class="col-md-2 col-sm-6 col-xs-6">
                                     <em>

                                         <asp:TextBox ID="txtcompletionID" autocomplete="off" runat="server" CssClass="input-sm similar-select1"></asp:TextBox></em>
                                 </div>--%>


                             </div>
                         </div>

                            <br />



                            <div runat="server" id="divSearch" visible="false">
                                <div class="form-group" style="background: #dedede; padding: 2px 0; border: 1px solid #ccc;">
                                    <label class="col-md-2">
                                        Search Record:
                                    </label>
                                    <div class="col-md-10">
                                        <asp:RadioButton Text=" By Plot No" runat="server" ID="radioByPlotNo" GroupName="radio" OnCheckedChanged="radioByPlotNo_CheckedChanged" AutoPostBack="true" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                        <asp:RadioButton Text=" By Allotment No" GroupName="radio" runat="server" ID="radioByAllotmentNo" OnCheckedChanged="radioByAllotmentNo_CheckedChanged" AutoPostBack="true" />
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
                        </div>
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
                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                    Service Applying For :
                                                </label>
                                                <div class="col-md-5 col-sm-6 col-xs-6">
                                                    <asp:DropDownList ID="ddlServices" runat="server" CssClass="chosen input-sm similar-select1 margin-left-z">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1009">Request For Issuance Of Completion Certificate </asp:ListItem>
                                                        <asp:ListItem Value="1010">Request For Issuance Of Occupancy Certificate</asp:ListItem>
                                                        <asp:ListItem Value="1029">Request for Amalgamation of Plot : Post Allotment</asp:ListItem>
                                                        <asp:ListItem Value="1030">Request for Subdivision of Plot : Post Allotment</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="hidden-lg hidden-md">
                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div runat="server" id="GSTDiv" visible="true">
                                            <div class="form-group">
                                                <label class="col-md-2 text-right">
                                                    GST NO:
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtGstNo" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                                </div>
                                                <div class="clearfix"></div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="separation" />
                                        </div>

                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="text-center">
                            <asp:Button runat="server" ID="btnRaise" Style="font-size: 16px; margin: 3px 0;" CssClass="btn-primary" Text="Apply" OnClick="btnRaise_Click" /></div>


                        <br />
                        <br />
                     



                    </div>


                    <div class="" runat="server" id="PreviousServiceDiv" visible="false">
                        <div class="panel panel-default">
                            <div class="panel-heading text-center">Previously Applied Services</div>
                        </div>

                        <div class="panel-body">
                            <asp:GridView ID="PreviousServiceGrid" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                AllowPaging="True"
                                AllowSorting="True"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                Width="100%" OnRowCommand="PreviousServiceGrid_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                                    <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                                    <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                                    <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" />
                                    <asp:BoundField DataField="ServiceRequestNO" ItemStyle-HorizontalAlign="Justify" HeaderText="Service No" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" Text='Select' CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" CommandName="Select" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataTemplate>
                                    No Record Available
                                </EmptyDataTemplate>

                            </asp:GridView>
                        </div>

                    </div>

                </div>
            </div>


        </div>
        <%--</div>
       --%>
    </form>


</body>

</html>

