<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutsideUploadFile.aspx.cs" Inherits="Allotment.OutsideUploadFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/Main.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />


    <link href="css/ajax-jquery-ui.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />

    <script src="js/ajax-jquery-min.js"></script>
    <script src="js/ajax-jquery-ui.js"></script>
    <script src="assets/js/bootstrap-datepicker.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>

    <style>
        .ui-dialog .ui-dialog-titlebar {
            padding: .4em 1em;
            position: relative;
            background: #D8D8D8 !important;
            border-color: #D8D8D8 !important;
        }

        .ui-dialog .ui-dialog-title {
            font-family: serif !important;
            color: black;
        }


        .ui-dialog .ui-dialog-buttonpane button {
            background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#4c5568), to(#414959)) !important;
            border: 1px solid #fff !important;
            font-weight: normal !important;
            padding: 5px 10px !important;
            font-size: 12px !important;
            line-height: 1.5 !important;
            color: #fff !important;
        }

        /*.ui-dialog
        {
            display: block !important;
    z-index: 1002 !important;
    outline: 0px !important;
    position: absolute !important;
    height: 156px !important;
    width: 286px !important;
    top: 325px !important;
    left: 525px !important;
        }*/


        .ui-dialog .ui-dialog-titlebar-close span {
            color: black !important;
        }
    </style>
    <%--<style>
        * {
            box-sizing: border-box;
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
    </style>--%>
</head>


<body id="pagewrap">
    <div id="dialog" style="display: none">
    </div>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="width: 100%;">
                            Document Upload
                        </div>
                        <div class="panel-body gallery">
                            <table id="tblDocument" class="table table-striped  table-responsive  table-bordered table-hover">
                                <tr>
                                    <td class="auto-style2">Allotment Letter No</td>
                                    <td>
                                        <asp:TextBox ID="txtAllotmentNo" CssClass="form-control" Width="250px" runat="server"></asp:TextBox></td>
                                    <td colspan="4"></td>

                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <p class="title"><b>Allotment letter Issue</b></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <span style="color: Red">*</span>
                                        Date of issue of allotment letter  :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtalltLetterIssueDate" CssClass="date form-control" runat="server" Style="vertical-align: middle; width: 200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <td>Attach Allotment Letter<br />
                                                    <span style="color: Red; font-size: 9px">(Upload only pdf File size max upto 1mb only)</span>
                                                    <td width="50px">
                                                        <asp:FileUpload ID="FileUploadAllotmentLetter" Width="250px" CssClass="form-control" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnAllotmentLetter" runat="server" OnClick="btnAllotmentLetter_Click" CssClass="btn btn-sm btn-primary" Text="Upload" />
                                                    </td>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <p class="title"><b>Lease deed Record </b></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <span style="color: Red">*</span>
                                        Date of lease deed :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLeaseDeed" CssClass="date form-control" runat="server" Style="vertical-align: middle; width: 200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <td>Attach Lease Deed<br />
                                                    <span style="color: Red; font-size: 9px">(Upload only pdf File size max upto 1mb only)</span>
                                                    <td width="50px">
                                                        <asp:FileUpload ID="FuLeaseDeed" Width="250px" CssClass="form-control" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnFuLeaseDeed" runat="server" ValidationGroup="Validationlease" OnClick="btnFuLeaseDeed_Click" CssClass="btn btn-sm btn-primary" Text="Upload" />
                                                        <asp:Label ID="Label8" runat="server" Visible="false"></asp:Label></span>
                                                    </td>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <span style="color: Red">*</span>
                                        Date of execution lease deed  :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtExecLeaseDeed" CssClass="date form-control" runat="server" Style="vertical-align: middle; width: 200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <p class="title"><b>Inspection Report </b></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">Inspection Date  :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtInspectionDate" CssClass="date form-control" runat="server" Style="vertical-align: middle; width: 200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <td>Attach Inspection Report<br />
                                                    <span style="color: Red; font-size: 9px">(Upload only pdf File size max upto 1mb only)</span>
                                                    <td width="50px">
                                                        <asp:FileUpload ID="FileUploadInspection" Width="250px" CssClass="form-control" runat="server" />
                                                    </td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnUploadInspection" runat="server" ValidationGroup="ValidationInspection" OnClick="btnUploadInspection_Click" CssClass="btn btn-sm btn-primary" Text="Upload" />
                                                    <asp:Label ID="Label9" runat="server" Visible="false"></asp:Label></span>

                                                </td>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <p class="title"><b>Building Plan Approval</b> </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <span style="color: Red">*</span>
                                        Date of Submission  :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBuildingDate" CssClass="date form-control" runat="server" Style="vertical-align: middle; width: 200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <td class="auto-style2">Attach Building Plan Document
                                                    <br />
                                                    <span style="color: Red; font-size: 9px">(Upload only pdf File size max upto 1mb only)</span>
                                                    <td width="50px">
                                                        <asp:FileUpload ID="FudBuildingPlan" Width="250px" CssClass="form-control" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnBuildingPlan" runat="server" OnClick="btnBuildingPlan_Click" CssClass="btn btn-sm btn-primary" Text="Upload" />
                                                        <asp:Label ID="Label3" runat="server" Visible="false"></asp:Label></span>

                                                    </td>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <p class="title"><b>Completion Plan Certificate</b></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">Date of Release of Completion Certificate:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcomcertificate" CssClass="date form-control" runat="server" Style="vertical-align: middle; width: 200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <td class="auto-style2">Attach Completion Certificate<br />
                                                    <span style="color: Red; font-size: 9px">(Upload only pdf File size max upto 1mb only)</span>
                                                    <td width="50px">
                                                        <asp:FileUpload ID="FudCompletion" Width="250px" CssClass="form-control" runat="server" />
                                                    </td>
                                                    <td>

                                                        <asp:Button ID="btnCompletion" runat="server" OnClick="btnCompletion_Click" CssClass="btn btn-sm btn-primary" Text="Upload" />
                                                        <asp:Label ID="Label4" runat="server" Visible="false"></asp:Label></span>

                                                    </td>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <p class="title"><b>Occupancy Certificate</b></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">Date of Release of Occupancy Certificate:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReloccertificate" CssClass="date form-control" runat="server" Style="vertical-align: middle; width: 200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <td class="auto-style2">Attach Occupancy Certificate<br />
                                                    <span style="color: Red; font-size: 9px">(Upload only pdf File size max upto 1mb only)</span>
                                                    <td width="50px">
                                                        <asp:FileUpload ID="FudOccupancy" Width="250px" CssClass="form-control" runat="server" />
                                                    </td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnOccupancy" runat="server" OnClick="btnOccupancy_Click" CssClass="btn btn-sm btn-primary" Text="Upload" />
                                                    <asp:Label ID="Label5" runat="server" Visible="false"></asp:Label></span>
                                                </td>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>

                            </table>
                            <%--<table class="table table-striped  table-responsive  table-bordered table-hover">
                                    <tr><td>Allotment Letter No</td><td><asp:TextBox ID="txtAllotmentNo" CssClass="form-control" Width="250px" runat="server"></asp:TextBox></td><td colspan="2"></td></tr>
                                    <tr>
                                       <td class="auto-style2">
                                                <span style="color: Red">*</span>
                                                Allottement Date as per our Record  :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDateofAllottementNo" CssClass="date form-control" runat="server" Style="vertical-align: middle; width: 200px"></asp:TextBox>
                                            </td>
                                        <td class="auto-style3" >
                                            Attach Allotment Letter
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FileUploadAllotmentLetter" Width="250px" CssClass="form-control" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAllotmentLetter" runat="server"   CssClass="btn btn-sm btn-success" Text="Upload" />
                                           </td><td> <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                                        </td>
                                       
                                    </tr>


                                    <tr>
                                         <td class="auto-style3">
                                            Attach Lease Deed
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FuLeaseDeed" Width="250px" CssClass="form-control" runat="server" />

                                        </td>
                                        <td>
                                            <asp:Button ID="btnFuLeaseDeed" runat="server" ValidationGroup="Validationlease"  CssClass="btn btn-sm btn-success" Text="Upload" />
                                          </td><td>  <asp:Label ID="Label8" runat="server" Visible="false"></asp:Label>
                                        </td>

                                    </tr>




                                    <tr>
                                        <td class="auto-style3">
                                            Attach Inspection Report
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FileUploadInspection" Width="250px" CssClass="form-control" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnUploadInspection" runat="server" ValidationGroup="ValidationInspection" CssClass="btn btn-sm btn-success" Text="Upload" />
                                           </td><td> <asp:Label ID="Label9" runat="server" Visible="false"></asp:Label>
                                        </td>
                                         </tr><tr>
                                        <td class="auto-style3">
                                           Attach Building Plan Document
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FudBuildingPlan" Width="250px" CssClass="form-control" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnBuildingPlan" runat="server"  CssClass="btn btn-sm btn-success" Text="Upload" />
                                          </td><td>  <asp:Label ID="Label3" runat="server" Visible="false"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width:20%" class="auto-style3">
                                            Attach Completion Certificate
                                        </td>
                                        <td style="width:20%">
                                            <asp:FileUpload ID="FudCompletion" Width="250px" CssClass="form-control" runat="server" />
                                        </td>
                                        <td  style="width:15%">
                                            <asp:Button ID="btnCompletion" runat="server" CssClass="btn btn-sm btn-success" Text="Upload" />
                                          </td><td  style="width:40%">  <asp:Label ID="Label4" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        </tr><tr>
                                        <td class="auto-style3">
                                            Attach Occupancy Certificate
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FudOccupancy" Width="250px" CssClass="form-control" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnOccupancy" runat="server"    CssClass="btn btn-sm btn-success"  Text="Upload" />
                                          </td><td>  <asp:Label ID="Label5" runat="server" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>--%>
                            <div>
                                <asp:GridView ID="GridViewDocument" runat="server" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Document" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColName" runat="server" Text='<%#Eval("ColName") %>'> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--                                 <asp:TemplateField HeaderText="Issue Date" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblColValue" runat="server" Text='<%# Eval("ColValue", "{0:dd/MMM/yyyy}")%>'> 
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# (Container.DataItemIndex)+1 %>'
                                                    CommandName="selectDocument" Text='<%#Eval("ColName") %>'></asp:LinkButton>
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


            <div id="footer_id" runat="server"> <% Response.WriteFile("public_footer.aspx"); %> </div>  

        </div>
    </form>
    <script type="text/javascript">
        $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });
        });
    </script>

</body>
</html>
