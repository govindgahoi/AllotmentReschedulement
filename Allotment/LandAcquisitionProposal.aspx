<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandAcquisitionProposal.aspx.cs" Inherits="Allotment.LandAcquisitionProposal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
     <link href="css/Footer.css" rel="stylesheet" />
    
   

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

        .ui-dialog {
            top: 130% !important;
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




            .ui-dialog .ui-dialog-titlebar-close span {
                color: black !important;
            }
    </style>

     
    <script type="text/javascript">
 $(document).ready(function() {
            $("#files").kendoUpload({
                async: {
                    saveUrl: "save",
                    removeUrl: "remove"
                },
                validation: {
                    allowedExtensions: [".pdf"]
                }
            });

</script>
    <script type="text/javascript">     
       
   
       
   
        function ShowPopup(message) {
            $(function () {
                $("#dialog").html(message);
                $("#dialog").dialog({
                    title: "Alert",
                    buttons: {
                        Close: function () {
                            $(this).dialog('close');
                        }
                    },
                    modal: true
                });
            });
        };

        function ValidateIndividualEmail() {
            var email = document.getElementById("<%= txtEmail.ClientID %>").value;
            if (email.length > 0) {
                if (!IsValidEmail(email)) {

                    ShowPopup("<img src='/images/alert.jpg' width='38' height='38'> &nbsp;&nbsp;<span style='font-family:serif !important'>Invalid Email Id</span>");
                    document.getElementById("<%= txtEmail.ClientID %>").value = "";
                        document.getElementById("<%= txtEmail.ClientID %>").style.borderColor = '#e52213';

                        return false;

                    }
                    else {

                        document.getElementById("<%= txtEmail.ClientID %>").style.borderColor = "";
                        return true;
                    }
                }
            }


       <%-- function validatepan() {

            var panVal = document.getElementById("<%= txtPanNo.ClientID %>").value;
            var regpan = /^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$/;
            if (panVal != "") {
                if (regpan.test(panVal)) {
                    document.getElementById("<%= txtPanNo.ClientID %>").style.borderColor = "";
                    return true;
                } else {

                    ShowPopup("<img src='/images/alert.jpg' width='38' height='38'> &nbsp;&nbsp;<span style='font-family:serif !important'>Invalid Pan Card</span>");
                    document.getElementById("<%= txtPanNo.ClientID %>").value = "";
                    return false;
                }
            }
        }--%>





     






      


        function IsValidEmail(email) {
            var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            return expr.test(email);
        };





        function isDecimalKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {


            }
        }



    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();

            $(".MultiSelect").chosen(
               


            );
        }

    </script>
</head>
<body id="pagewrap">
    <div id="dialog" style="display: none">
    </div>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        
        <div class="container">
             
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                        <a href="Default.aspx" class="navbar-brand" style="width:100%;">
                            <div class="col-md-8">
                                <img class="img-responsive" src="http://www.onlineupsidc.com/OfcUser_pdf/upsida-logo-name.png" />
                            </div>
                            <div class="col-md-4" style="margin-top: 2px;">
                                <img class="img-responsive" src="images/image4.png" />
                            </div>
                        </a>

                    </div>
                </div>
                <div id="main_menu" runat="server"><% Response.WriteFile("top_mainmenu.aspx"); %> </div>
            </div>
              
            <div class="row" id="SideDiv">
                <div class="col-md-12">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="row well well-large offset4">
                                <div class="panel panel-default">
                                    <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <%--<ul class="mylogo-ul list-inline" style="margin:0;padding: 6px 0 9px 1px;">
                                                    <li><img src="/images/logo-img/pm_modi.jpg" alt="Goverment" style="box-shadow: 7px 4px 8px #ccc;"/></li>
                                                    <li><img src="/images/logo-img/govt_up.png" alt="Goverment" /></li>
                                                </ul>--%>
                                            </div>
                                            <%--<div class="col-md-6 text-center">
                                                <div style="font-size: 34px;font-weight: 600;margin-top: 10px;">Nivesh Mitra</div><span style="font-size: 17px;">Single Window Portal ,Govt. of Uttar Pradesh</span>
                                            </div>
                                            <div class="col-md-3 text-right">
                                                <ul class="mylogo-ul list-inline" style="margin:0;padding: 6px 0 9px 1px;">
                                                    <li><img src="/images/logo-img/logo_udhyog_bandu_b.png" alt="Goverment" /></li>
                                                    <li><img src="/images/logo-img/yogi.jpg" alt="Goverment" style="box-shadow: 7px 4px 8px #ccc;"/></li>
                                                </ul>
                                            </div>--%>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <p class="panel-heading text-center" style="font-size:12px"><b>Proposal For Offering Of Land To UPSIDA</b></p>
                                    <div class="panel-body">
                                        <div id="tblallotteeinf">
                                           <%-- <p class="panel-heading"><b>Applicant Profile </b></p>--%>

                                            <div class="form-group">
                                                <div class="row">
                                                   
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                         Name Of Land Owner/Owners :
                                                    </label>
                                                    <div class="col-md-8">
                                                      <asp:TextBox ID="txtNameofLandOwner" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Mobile No.:
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="similar-select1 input-sm" MaxLength="10"  onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        E-mail :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="similar-select1 input-sm" onblur="return ValidateIndividualEmail();"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                             <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">                                                   
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                       District :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="ddlDistrict" runat="server"  CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true"  ></asp:DropDownList> 
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                             <div class="form-group">
                                                <div class="row">                                                   
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                       Sub District :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="ddlSubDistrict" runat="server"  CssClass="similar-select1 margin-left-z dropdown-toggle input-sm"  ></asp:DropDownList> 
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />

                                            <div class="form-group">
                                                <div class="row">                                                   
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                      Type of Land Owner :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="ddllandownerType" runat="server" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm">
                                                          <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                          <asp:ListItem Value="1">Individual</asp:ListItem>
                                                          <asp:ListItem Value="2">Group of individual</asp:ListItem> 
                                                      <asp:ListItem Value="3">Company</asp:ListItem>
                                                            <asp:ListItem Value="4">Trust </asp:ListItem>
                                                             <asp:ListItem Value="5">Society </asp:ListItem>
                                                              </asp:DropDownList>
                                                      
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                                 <div class="form-group">
                                                <div class="row">                                                   
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                      Type of Land :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="ddllandType" runat="server" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm">
                                                          <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                          <asp:ListItem Value="1">Agriculture Land</asp:ListItem>
                                                          <asp:ListItem Value="2">Industrial Land</asp:ListItem> 
                                                      <asp:ListItem Value="3">Commercial Land</asp:ListItem>
                                                            <asp:ListItem Value="4">Residential Land </asp:ListItem>
                                                             <asp:ListItem Value="5">Waste Land </asp:ListItem>
                                                             <asp:ListItem Value="6">Others </asp:ListItem>
                                                              </asp:DropDownList>
                                                      
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                           
                                            <div class="form-group">
                                                  <div id="div_hide" runat="server" visible="true" > 
                                                <div class="row">
                                                   <asp:UpdatePanel ID="pnlFileUpload" runat="server">
                                            <ContentTemplate>
                                                <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Location Map(Upload) :
                                                    </label>
                                                    <div class="col-md-4">
                                                       <asp:FileUpload ID="FileUploadLoaction" runat="server"  CssClass="input-sm similar-select"  ToolTip="Upload" accept=".pdf" ></asp:FileUpload>
                                                        <%--<div class="demo-hint">You can only upload <strong>PDF</strong> files.</div>--%>
                                                        <%--<asp:RegularExpressionValidator id="regpdf" text="*" errormessage="please upload only pdf files" ControlToValidate="FileUploadLoaction" ValidationExpression="^.*\.(pdf|PDF)$" runat="server" />--%>
                                                    </div>
                                                     <div class="col-md-4">
                                                    <span>
                                                        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click"  CssClass="btn btn-primary ey-bg btn-sm" Style="margin: 0 1px 0 0; width: 65px;" Text="Upload" />
                                                        
                                                        <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                                                    </span>  
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnUpload" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                                   
                                                     
                                            </div>                                           
                                            <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                            <div class="form-group">
                                                
                                                <div class="row">
                                                    
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Upload Signed Consent letter :
                                                    </label>
                                                    <div class="col-md-4">
                                                       <asp:FileUpload ID="FileSignedConsentlatter" runat="server" data-file_types="pdf"  CssClass="input-sm similar-select"  ToolTip="Upload"></asp:FileUpload>
                                                    </div>
                                                     <div class="col-md-4">
                                                    <span>
                                                        <asp:Button ID="btnuploadfile" runat="server" OnClick="btnuploadfile_Click" CssClass="btn btn-primary ey-bg btn-sm" Style="margin: 0 1px 0 0; width: 65px;" Text="Upload" />
                                                        <asp:Label ID="lbluploadingMsgs" runat="server" Visible="false"></asp:Label>
                                                        <asp:LinkButton ID="link" runat="server"  Visible="false"></asp:LinkButton>
                                                    </span>  
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnuploadfile" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                                     <div class="row">
                                        <div class="col-md-12">
                                            <asp:Label ID="lblStatus1" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                                 
                                                         
                                                </div>
                                                      
                                            </div>
                                           </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                                 <div id="trnew" runat="server" visible="false" >
                                                     <asp:GridView ID="Land_details_grid1" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" CssClass="table table-striped table-bordered table-hover request-table" 
                                PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right">
                                    <Columns>


                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField DataField="Village" HeaderText="Village Name" SortExpression="Village" />
                                           <asp:BoundField DataField="KhataNo" HeaderText="Khata No." SortExpression="KhataNo" />
                                         <asp:BoundField DataField="KhatedarName" HeaderText="Khatedar Name" SortExpression="KhatedarName" />
                                        <asp:BoundField DataField="FatherHusbandName" HeaderText="Father/Husband Name" SortExpression="FatherHusbandName" />
                                          <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                        <asp:BoundField DataField="GataNo" HeaderText="Gata No." SortExpression="GataNo" />  
                                        <asp:BoundField DataField="GataArea" HeaderText="Gata Area" SortExpression="GataArea" />    
                                                 
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                                     </div>
                                            <div id="tr4" runat="server" >
                                                <hr style="margin:8px 0;border-top: 1px solid #9c9999;" />
                                                        <asp:GridView ID="Land_details_grid" ViewStateMode ="Enabled"   CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true"  ShowHeaderWhenEmpty="true"  runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="Land_details_grid_RowDeleting"    >
                                                    <Columns>

                                                         <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                        </ItemTemplate>
                                                         </asp:TemplateField>

                                     
                                                        <asp:TemplateField ItemStyle-Width="25%" HeaderText="Village">
                                                             <ItemTemplate> <asp:Label ID="lblVillage" runat="server" Text='<%#Eval("Village") %>' ></asp:Label> </ItemTemplate>
                                                              <FooterTemplate><asp:TextBox  ID="txtVillage_insert"    CssClass="input-sm similar-select1" runat="server" ></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                              
                                                        <asp:TemplateField ItemStyle-Width="25%" HeaderText="Khata No.">
                                                             <ItemTemplate> <asp:Label ID="lblKhataNo" runat="server" Text='<%#Eval("KhataNo") %>' ></asp:Label> </ItemTemplate>
                                                              <FooterTemplate><asp:TextBox  ID="txtKhataNo_insert"    CssClass="input-sm similar-select1" runat="server" ></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                              
                                                        <asp:TemplateField  ItemStyle-Width="25%" HeaderText="Khatedar Name">
                                                              <ItemTemplate> <asp:Label ID="lblKhatedarName" runat="server" Text='<%#Eval("KhatedarName") %>' ></asp:Label> </ItemTemplate>                                                   
                                                                <FooterTemplate><asp:TextBox ID="txtKhatedarName_insert"  CssClass="input-sm similar-select1" runat="server"></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                            <asp:TemplateField  ItemStyle-Width="25%" HeaderText="Father/Husband Name">
                                                                  <ItemTemplate> <asp:Label ID="lblFatherHusbandName" runat="server" Text='<%#Eval("FatherHusbandName") %>' ></asp:Label> </ItemTemplate>                                                  
                                                                <FooterTemplate><asp:TextBox ID="txtFatherHusbandName_insert"  CssClass="input-sm similar-select1"  runat="server" ></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField  ItemStyle-Width="25%" HeaderText="Address">
                                                                  <ItemTemplate> <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>' ></asp:Label> </ItemTemplate>                                                  
                                                                <FooterTemplate><asp:TextBox ID="txtAddress_insert"  CssClass="input-sm similar-select1"  runat="server" ></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField  ItemStyle-Width="25%" HeaderText="Gata No">
                                                                  <ItemTemplate> <asp:Label ID="lblGataNo" runat="server" Text='<%#Eval("GataNo") %>' ></asp:Label> </ItemTemplate>                                                  
                                                                <FooterTemplate><asp:TextBox ID="txtGataNo_insert"  CssClass="input-sm similar-select1"  runat="server" ></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                      <asp:TemplateField  ItemStyle-Width="25%" HeaderText="Gata Area(In Hec.)">
                                                                  <ItemTemplate> <asp:Label ID="lblGataArea" runat="server" Text='<%#Eval("GataArea") %>' ></asp:Label> </ItemTemplate>                                                  
                                                                <FooterTemplate><asp:TextBox ID="txtGataArea_insert"  CssClass="input-sm similar-select1"  runat="server" ></asp:TextBox></FooterTemplate>
                                                        </asp:TemplateField>
                                                              <asp:TemplateField>
                                                            <ItemTemplate>
                                                                 <asp:ImageButton   CommandName="Delete" CssClass="fa fa-trash-o"  ToolTip="Delete" ID="btn_delete" runat="server"  
                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

                                                            </ItemTemplate>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                 <asp:ImageButton  ToolTip="Add"  CssClass="fa fa-plus-square"  ID="ButtonAdd" runat="server"  Height="16px" OnClick="ButtonAdd_Click"
                                        ImageUrl="~/images/add.png" Width="16px"  />

                                                        


                                                        
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                         
                                                                    </Columns>
                                                </asp:GridView>

                                            </div>


                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Total Land(In Hectare):
                                                    </label>
                                                    <div class="col-md-8">
                                                       <asp:TextBox ID="txtTotalland" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Road Connectivity Type:
                                                    </label>
                                                    <div class="col-md-8">

                                                          <asp:DropDownList ID="ddlRoadConnectivity" runat="server" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm">
                                                          <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                          <asp:ListItem Value="1">Expressway</asp:ListItem>
                                                          <asp:ListItem Value="2">National Highway</asp:ListItem> 
                                                          <asp:ListItem Value="3">State Highway</asp:ListItem>
                                                          <asp:ListItem Value="4">Major District Road(MDR) </asp:ListItem>
                                                          <asp:ListItem Value="5">Village Link Road</asp:ListItem>
                                                            
                                                              </asp:DropDownList>
                                                       
                                                    </div>
                                                </div>
                                            </div>

                                             <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Road Width:
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtRoadwidth" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />

                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Distance from nearest expressway,NH:
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtDistancefromnearestexpressway" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Nearest Railway Station Name:
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtNearestRailwayStationName" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Distance from nearest Railway Station :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtDistancefromnearestRailwayStation" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />

                                             <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Nearest source of freshwater:
                                                    </label>
                                                    <div class="col-md-8">

                                                        <asp:DropDownList ID="ddlsurcefreshwater" runat="server" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm">
                                                          <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                          <asp:ListItem Value="1">Groundwater</asp:ListItem>
                                                          <asp:ListItem Value="2">Rever</asp:ListItem> 
                                                      <asp:ListItem Value="3">Canal</asp:ListItem>
                                                            </asp:DropDownList>
                                                             
                                                        <%--<asp:TextBox ID="txtNearestIndustrialArea" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>--%>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />

                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                         Distance depth of source water:
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtdepthofsourcewater" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />

                                             <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                         Circle rate per hectare:
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtCirclerateperhectare" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                             <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                         Propose offered rate per hectare:
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtProposeofferedrateperhectare" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />

                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                            Whether the Consent of the all land owners:
                                                    </label>
                                                    <div class="col-md-8">

                                                        <asp:DropDownList ID="ddlalllandowners" runat="server" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm">
                                                          <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                          <asp:ListItem Value="1">Yes</asp:ListItem>
                                                          <asp:ListItem Value="2">No</asp:ListItem> 
                                                    
                                                            </asp:DropDownList>
                                                        
                                                        <%--<asp:TextBox ID="txtalllandowners" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>--%>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                        </div>
                                        

                                    </div>

                                    <div class="form-group" id="mandatoryfield" style="margin-top: 15px;" runat="server">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <span style="color: blue" class="pull-left">Field marked with <span style="color: Red">* </span>are mandatory</span>
                                            </div>
                                            <div class="col-md-4 text-center">
                                                <asp:Button ID="btnSubmit" Style="margin: 0 1px 0 0; width: 65px;" CssClass="btn btn-primary btn-sm" ValidationGroup="ValidationButton" runat="server"  Text="Save" OnClick="btnSubmit_Click" /><asp:Button ID="btnReset" Style="margin: 0; width: 65px;" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnReset_Click"  Text="Reset" />
                                            </div>
                                            <div class="col-md-4"></div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>

                                </div>

                            </div>
                        </div>
                    </div>

                </div>
                <footer class="nb-footer">
                    <div class="container">
                        <div class="row">
                     
                            <div class="col-md-3 col-sm-6">
                                <div class="footer-info-single">
                                    <h2 class="title">PUBLIC FORUM</h2>
                                    <ul class="list-unstyled">
                                     
                                        <li><a href="Inspection.aspx" title=""><i class="fa fa-angle-double-right"></i>View Inspection Detail</a></li>
                                        <li><a href="BuldingPlanDetail.aspx" title=""><i class="fa fa-angle-double-right"></i>Approved Building Plan</a></li>
                                        <li><a href="PviewAllottes.aspx" target="_blank" title=""><i class="fa fa-angle-double-right"></i>View Allotment Document</a></li>
                                        <li><a href="ViewInspectionDocument.aspx" target="_blank" title=""><i class="fa fa-angle-double-right"></i>View Inspection Document</a></li>
                                        <li><a href="ViewBuildingPlanDocument.aspx" target="_blank" title=""><i class="fa fa-angle-double-right"></i>View BuildingPlan Document </a></li>
                                    </ul>
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-6">
                                <div class="footer-info-single">
                                    <h2 class="title">UP SIDA</h2>
                                    <ul class="list-unstyled">
                                        <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>UP Industial Development Act</a></li>
                                        <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>UPSIDA Byelaws</a></li>
                                        <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>Inspection Format For Construction Permit</a></li>
                                        <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>Inspection Format For Completion</a></li>
                                        <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>SOP For Computerised Allocation of Inspectors</a></li>
                                    </ul>
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-6">
                                <div class="footer-info-single">
                                    <h2 class="title">Security & privacy</h2>
                                    <ul class="list-unstyled">
                                        <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Terms Of Use</a></li>
                                        <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Privacy Policy</a></li>
                                        <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Return / Refund Policy</a></li>
                                        <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Store Locations</a></li>
                                    </ul>
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-6">
                                <div class="footer-info-single">
                                    <h2 class="title">Payment</h2>
                                    <ul class="list-unstyled">
                                        <li><a href="PaymentRequest.aspx" title=""><i class="fa fa-angle-double-right"></i>Quick Pay</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>

                    <section class="copyright">
                        <div class="container">
                            <div class="row">
                                <div class="col-sm-6">
                                    <p>Copyright © 2017. UPSIDC Product Version Alpha 1.0 Release</p>
                                </div>
                                <div class="col-sm-6"></div>
                            </div>
                        </div>
                    </section>
                </footer>

            </div>

        </div>

    </form>
 

</body >
</html >
