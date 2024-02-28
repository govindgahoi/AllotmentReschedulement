<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllotteeApplicationVew.aspx.cs" Inherits="Allotment.AllotteeApplicationVew" %>

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
    <script src="js/jquery-1.11.3.min"></script>
    <script src="js/bootstrap.min.js"></script>
 
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
    color:black !important;
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
                
            </div>
            <div class="row" id="SideDiv">
                <div class="col-md-12">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="row well well-large offset4">
                                <div class="panel panel-default">
                                  
                                    <div class="panel-body">
                                         <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="width: 100%;">
                                <div class="row">
                                    <div class="col-md-12">
                          


<asp:Label ID="LblAllotteeId" runat="server" Visible="false"></asp:Label></em>





                                        
                                        <div class="col-md-12">
                                            <p style="font-weight:bold;text-align:center;">Allotee Application Request View</p>
                                        </div>

                                      
                                    </div>
                                </div>
                            </div>
       <div class="row">
                    <div class="col-lg-5">

                        <div class="panel panel-default">
                            <div class="panel-heading" style="text-align: center;font-weight:bold;">
                               Company Details                         
                            </div>
                            <div class="panel-body" style="padding: 0px !important;">
                                <div class="list-group" style="padding: 6px !important;">

                                    

                                    <a class="list-group-item" style="padding: 6px !important;">Date Of Application :                                  
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="Label13" runat="server"></asp:Label></em>
                                    </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;">Plot Size :                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="Label14" runat="server"></asp:Label></em>
                                    </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;">Industrial Area :                                  
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="Label23" runat="server"></asp:Label></em>
                                    </span>
                                    </a>

                                    <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Firm/Company Name :   </span>
                                        <span class="pull-right text-muted small"><em>
                                            <asp:Label ID="Label24" runat="server"></asp:Label></em>
                                        </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Firm/Company Constitution :   </span>
                                        <span class="pull-right text-muted small"><em>
                                            <asp:Label ID="Label25" runat="server"></asp:Label></em>
                                        </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Firm/Company Pan No :   </span>
                                        <span class="pull-right text-muted small"><em>
                                            <asp:Label ID="Label26" runat="server"></asp:Label></em>
                                        </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Firm/Company Cin No :   </span>
                                        <span class="pull-right text-muted small"><em>
                                            <asp:Label ID="Label27" runat="server"></asp:Label></em>
                                        </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Authorised Signatory :   </span>
                                        <span class="pull-right text-muted small"><em>
                                            <asp:Label ID="Label28" runat="server"></asp:Label></em>
                                        </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;">Signatory Mobile :                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="Label29" runat="server"></asp:Label></em>
                                    </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;">Signatory Email :                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="Label30" runat="server"></asp:Label></em>
                                    </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;">Address :                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="Label31" runat="server"></asp:Label></em>
                                    </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;">Current Status :                                   
                                    <span class="pull-right text-muted small" style="font-weight:bold;color:red;"><em>
                                        <asp:Label ID="Label1" runat="server"> </asp:Label></em>
                                    </span>
                                    </a>

                                </div>


                            </div>
                        </div>
                    </div>

                    <div class="col-lg-7">


                                        <div class="panel panel-default">
                                            <p class="panel-heading" style="text-align: center;font-weight:bold;" runat="server" id="P2">Request for Allottee/Transfree Registration (4/5)</p>
                                            <div class="panel-body gallery  table-responsive">
                                                <asp:Label ID="Label32" runat="server" Text=""></asp:Label>
                                                <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false"
                                                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                    <Columns>


                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label16" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                </asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="AllotteeName" HeaderText="Name" SortExpression="AllotteeName" />
                                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                        <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                        <asp:BoundField DataField="emailID" HeaderText="EmailId" SortExpression="EmailId" />

                                                    </Columns>
                                                </asp:GridView>

                                                <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="false"
                                                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                                    <Columns>


                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label17" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                </asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="DirectorName" HeaderText="Director Name" SortExpression="DirectorName" />
                                                        <asp:BoundField DataField="DIN_PAN" HeaderText="Din/Pan" SortExpression="DIN_PAN" />
                                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                        <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="Phone" />
                                                        <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                    </Columns>

                                                  
                                                </asp:GridView>

                                                <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="false"
                                                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                                    <Columns>


                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                </asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ShareholderName" HeaderText="Shareholder Name" SortExpression="ShareholderName" />
                                                        <asp:BoundField DataField="SharePer" HeaderText="Share %" SortExpression="SharePer" />
                                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                        <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                        <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                    </Columns>

                                                    <EmptyDataTemplate>
                                                        No Record Available
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                                 <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="false"
                                                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                                    <Columns>


                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                </asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PartnerName" HeaderText="Partner Name" SortExpression="PartnerName" />
                                                        <asp:BoundField DataField="PartnershipPer" HeaderText="Partnership %" SortExpression="PartnershipPer" />
                                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                        <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                        <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                    </Columns>

                                                    <EmptyDataTemplate>
                                                        No Record Available
                                                    </EmptyDataTemplate>
                                                </asp:GridView>

                                                <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="false"
                                                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                                    <Columns>


                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label19" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                </asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="TrusteeName" HeaderText="Trustee Name" SortExpression="TrusteeName" />
                                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                        <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="Phone" />
                                                        <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                    </Columns>

                                                    <EmptyDataTemplate>
                                                        No Record Available
                                                    </EmptyDataTemplate>
                                                </asp:GridView>

                                                <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="false"
                                                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                                    <Columns>


                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label20" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                </asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="AllotteeName" HeaderText="Individual Name" SortExpression="AllotteeName" />
                                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                        <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                        <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                    </Columns>
                                                </asp:GridView>


                                            </div>
                                        </div>

                                    </div>

                </div>

                          
</div></div></div>

                <div class="row">
    <div class="col-lg-12">
    <div class="panel panel-default">
        <div class="panel-heading" style="text-align:center;">
            Allottee Project Details                        
        </div>
        <div class="panel-body ">
        <div class="panel panel-default">
            <div class="panel-heading" >Type of industry to be set up</div>
            <div class="panel-body" style="padding: 0px !important;">
                <div class="form-group">
                    <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                        <label for="">Description&nbsp;:</label>
                    </label>
                    <div class="col-md-9 col-sm-6 col-xs-12">
                        <asp:Label ID="Label12" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading" >Project Costing Details</div>
            <div class="panel-body" style="padding: 0px !important;">
                <div class="form-group">
                    <div class="col-md-3 col-sm-6 col-xs-12 text-right">
                        <label for="">Estimated Cost Of the project&nbsp;:</label>
                    </div>
                    <div class="col-md-9 col-sm-6 col-xs-12">
                        <asp:Label ID="Label33" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div  class="form-group">
                    <div class="col-md-3 col-sm-6 col-xs-12 text-right">
                        <label for="">Estimated employment generation&nbsp;:</label>
                    </div>
                    <div class="col-md-9 col-sm-6 col-xs-12">
                        <asp:Label ID="Label34" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
            </div>
        </div>


           <div class="panel panel-default">
               <div class="panel-heading">Layout plan of land indicating broadly</div>
               <div class="panel-body" style="padding: 0px !important;">
                   <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                           Covered Area&nbsp;(In %)&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                          <asp:Label ID="Label35" runat="server"></asp:Label>
                       </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div  class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                           Open area required and its purpose&nbsp;(In %)&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                         <asp:Label ID="Label36" runat="server"></asp:Label>
                       </div>
                   </div>
                   <div class="clearfix"></div>
                    <hr class="myhrline" />
               </div>
           </div>



           <div class="panel panel-default">
               <div class="panel-heading">Details of the investment(in Rs)</div>
               <div class="panel-body" style="padding: 0px !important;">
                   <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right" title="date ofsubmission">
                           Land&nbsp;(In Lacs)&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                          <asp:Label ID="Label37" runat="server"></asp:Label>
                       </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                           Building&nbsp;(In Lacs)&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                           <asp:Label ID="Label38" runat="server"></asp:Label>
                       </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right" >
                           Machinery & Equipments&nbsp;(In Lacs)&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                          <asp:Label ID="Label39" runat="server"></asp:Label>
                       </div>                     
                   </div>
                   <div class="clearfix"></div>
                   <hr class="myhrline" />
                    <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right" >
                           Other Fixed Assets&nbsp;(In Lacs)&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                          <asp:Label ID="Label40" runat="server"></asp:Label>
                       </div>                     
                   </div>
                   <div class="clearfix"></div>
                   <hr class="myhrline" />
                    <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right" >
                           Other Expenses&nbsp;(In Lacs)&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                          <asp:Label ID="Label41" runat="server"></asp:Label>
                       </div>                     
                   </div>
                   <div class="clearfix"></div>
                    <hr class="myhrline" />

                   </div>
               </div>
          


          <div class="panel panel-default">
               <div class="panel-heading">Any fumes generated in the process of manufacture and if so, their nature and quantity &nbsp; <span runat="server" id="Span1"></span></div>
               <div class="panel-body" style="padding: 0px !important;" id="Div1" runat="server" visible="false">
                   <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                           Nature&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                            <asp:Label ID="Label42" runat="server"></asp:Label>
                       </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                           Quantity&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                           <asp:Label ID="Label43" runat="server"></asp:Label>
                       </div>
                   </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
               </div>
           </div>


         
         <div class="panel panel-default">
               <div class="panel-heading">Industrial Effluents </div>
               <div class="panel-body" style="padding: 0px !important;">
                   <table class="table table-hover table-bordered request-table" style="width:100%;">
                       <tr>
                           <td style="width:24%;">Name</td>
                           <td style="width:38%;">Quantity</td>
                           <td style="width:38%;">Chemical Composition</td>
                       </tr>
                       <tr>
                           <td><span class="pull-right">(i)&nbsp;Solid :</span></td>
                           <td><asp:Label ID="Label44" runat="server"></asp:Label></td>
                           <td><asp:Label ID="Label45" runat="server"></asp:Label></td>
                       </tr>
                       <tr>
                           <td><span class="pull-right">(ii)&nbsp;Liquid :</span></td>
                           <td><asp:Label ID="Label46" runat="server"></asp:Label></td>
                           <td><asp:Label ID="Label47" runat="server"></asp:Label></td>
                       </tr>
                       <tr>
                           <td><span class="pull-right">(iii)&nbsp;Gaseous :</span></td>
                           <td><asp:Label ID="Label48" runat="server"></asp:Label></td>
                           <td><asp:Label ID="Label49" runat="server"></asp:Label></td>
                       </tr>
                   </table>



               </div>
           </div>

                            
         
          <div class="panel panel-default">
               <div class="panel-heading">Effluent Treatment Measures</div>
               <div class="panel-body" style="padding: 0px !important;">


                   <div class="row aks-row">

                       <div class="col-md-4 col-sm-6 col-xs-12 form-inline font-12px"><asp:Label ID="Label50" runat="server"></asp:Label></div>

                       <div class="col-md-4 col-sm-6 col-xs-12 form-inline font-12px">
                           <asp:Label ID="Label51" runat="server"></asp:Label>
                                       
                       </div>

                     

                       <div class="col-md-4 col-sm-6 col-xs-12 form-inline font-12px"><asp:Label ID="Label52" runat="server"></asp:Label></div>

                   </div>
               </div>
           </div>
            <div class="clearfix"></div>
                
               <div class="panel panel-default">
               <div class="panel-heading">Power Requirement (in KW)</div>
               <div class="panel-body" style="padding: 0px !important;">


                   <div class="form-group">

                       <label class="col-md-3 col-sm-6 col-xs-12 form-inline text-right">Units &nbsp;:</label>

                       <div class="col-md-9 col-sm-6 col-xs-12">
                        <asp:Label ID="Label53" runat="server"></asp:Label>
                                       
                       </div>

                 
                   </div>
                   <div class="clearfix"></div>
                    <hr class="myhrline" />
               </div>
           </div>

            <div class="panel panel-default">
               <div class="panel-heading">Telephone Requirement</div>
               <div class="panel-body" style="padding: 0px !important;">


                   <div class="form-group">

                       <div class="col-md-3 col-sm-6 col-xs-12 text-right">First Year&nbsp;:</div>

                       <div class="col-md-3 col-sm-6 col-xs-12">
                           <asp:Label ID="Label54" runat="server"></asp:Label>
                                       
                       </div>
                       <div class="col-md-3 col-sm-6 col-xs-12">
                       <asp:Label ID="Label55" runat="server"></asp:Label>
                                       
                       </div>
                 
                   </div>
                   <div class="clearfix"></div>
                <hr class="myhrline" />
                     <div class="form-group">
                       <div class="col-md-3 col-sm-6 col-xs-12 text-right">Ultimate Requirement&nbsp;:</div>

                       <div class="col-md-3 col-sm-6 col-xs-12">
                          <asp:Label ID="Label56" runat="server"></asp:Label>
                                       
                       </div>
                       <div class="col-md-3 col-sm-6 col-xs-12">
                          <asp:Label ID="Label57" runat="server"></asp:Label>
                                       
                       </div>
                 </div>
                   <div class="clearfix"></div>
                    <hr class="myhrline" />
                   </div>
               </div>
            <div class="clearfix"></div>
           <hr class="myhrline" />
               <p class="panel-heading font-bold">Other Relevant Information</p>
           <div class="form-group">
               <div class="row">
                    <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                        Net Worth Turnover:
                    </label>
                    <div class="col-md-9 col-sm-6 col-xs-12">
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </div>
                </div>
             </div>
               <div class="clearfix"></div>
           <hr class="myhrline" />
           <div class="form-group">
               <div class="row">
                    <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                        Expansion Of Land:
                    </label>
                    <div class="col-md-9 col-sm-6 col-xs-12">
                        <asp:Label ID="Label3" runat="server"></asp:Label>   </div>
                </div>
            </div>
              <div class="clearfix"></div>
           <hr class="myhrline" />
           <div class="form-group">
               <div class="row">
                    <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                        100% Export Oriented Industry:
                    </label>
                    <div class="col-md-9 col-sm-6 col-xs-12">
                       <asp:Label ID="Label4" runat="server"></asp:Label>     </div>
                </div>
            </div>

            <div class="panel panel-default">
               <div class="panel-heading">Is the applicant under priority category ? Please specify clearly &nbsp; <span runat="server" id="Span2"></span></div>
               <div id="Div2" class="panel-body" style="padding: 0px !important;" runat="server" visible="false">
                   <div class="row aks-row">
                      

                       <div class="col-md-3 col-sm-6 col-xs-12">Specification&nbsp;:</div>

                       <div class="col-md-3 col-sm-6 col-xs-12"><asp:Label ID="Label58" runat="server"></asp:Label></div>

                   </div>
               </div>
           </div>



           </div>
                    </div>
                </div>
                                     

                          </div>
<div class="panel panel-default" style="display:none;">
                  <div class="panel-heading font-bold">
                      <span class="">List Of Documents</span>
                  </div>
              </div>
              <div class="" style="display:none;">
                  <table class="table table-bordered table-hover request-table">
                      <tr>
                          <th>1.</th>
                          <th>Self Attested Copy of:--</th>
                          <th></th><th></th>
                      </tr>
                      <tr>
                          <td>a)</td>
                          <td>Project report</td>
                         
                          <td><asp:ImageButton ImageUrl="~/images/pdf.png" Width="25px" runat="server" ID="ImageButton1" AlternateText="asddasd"  OnClick="ImageButton1_Click" Visible="false" /></td>
                      </tr>
                        <tr>
                          <td>b)</td>
                          <td>Rough layout plan</td>
                       
                            <td><asp:ImageButton ImageUrl="~/images/pdf.png" Width="25px" runat="server" ID="ImageButton2" AlternateText="asddasd" OnClick="ImageButton2_Click" Visible="false" /></td>
                      </tr>
                      <tr>
                          <td>c)</td>
                          <td>Certificate in case of reserved category i.e SC/ST/PH</td>
                        
                          <td><asp:ImageButton ImageUrl="~/images/pdf.png" Width="25px" runat="server" ID="ImageButton3" AlternateText="asddasd" OnClick="ImageButton3_Click" Visible="false"/></td>
                      </tr>
                      <tr>
                          <td>d)</td>
                          <td>Partnership deed/memorandum of association/article of association depending on constitution of the applicant.</td>
                         
                          <td><asp:ImageButton ImageUrl="~/images/pdf.png" Width="25px" runat="server" ID="ImageButton4" AlternateText="asddasd" OnClick="ImageButton4_Click" Visible="false" /></td>
                      </tr>
                       <tr>
                          <td>e)</td>
                          <td>Document showing net worth or turnover of previous year and relevant experience.</td>
                      
                           <td><asp:ImageButton ImageUrl="~/images/pdf.png" Width="25px" runat="server" ID="ImageButton5" AlternateText="asddasd" OnClick="ImageButton5_Click" Visible="false" /></td>
                      </tr>
                      <tr>
                          <td>f)</td>
                          <td>Certificate issued by Directorate of industry and Export promotion council in case of 100% EOU.</td>
                         
                          <td><asp:ImageButton ImageUrl="~/images/pdf.png" Width="25px" runat="server" ID="ImageButton6" AlternateText="asddasd" OnClick="ImageButton6_Click" Visible="false"/></td>
                      </tr>
                      <tr>
                          <td>g)</td>
                          <td>Any other document attached if not listed above.</td>                          
                          
                          <td><asp:ImageButton ImageUrl="~/images/pdf.png" Width="25px" runat="server" ID="ImageButton7" AlternateText="asddasd" OnClick="ImageButton7_Click" Visible="false" /></td>
                      </tr>
                  </table>
                </div>

                                </div>
                            </div>
                        </div>

                    </div>
                    <footer class="nb-footer">
                        <div class="container">
                            <div class="row">
                                <%--<div class="col-sm-12">
                                    <div class="about">
                                        <img src="images/logo.png" class="img-responsive center-block" alt="">
                                        <div class="social-media">
                                            <ul class="list-inline">
                                                <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-facebook"></i></a></li>
                                                <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-twitter"></i></a></li>
                                                <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-google-plus"></i></a></li>
                                                <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-linkedin"></i></a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="col-md-3 col-sm-6">
                                    <div class="footer-info-single">
                                        <h2 class="title">PUBLIC FORUM</h2>
                                        <ul class="list-unstyled">
                                            <%--<li><a href="Allotments.aspx" title=""><i class="fa fa-angle-double-right"></i>View Allottment Status</a></li>--%>
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
        </div>
    </div>
      
    </form>
      <script  type="text/javascript">
          $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });

          var prm = Sys.WebForms.PageRequestManager.getInstance();
          prm.add_endRequest(function () {
              $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });
          });
  </script>
     
</body>
</html>
