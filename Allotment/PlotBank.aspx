<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true"  EnableEventValidation = "false" CodeBehind="PlotBank.aspx.cs" Inherits="Allotment.PlotBank" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <meta charset = "utf-8">
      <meta name = "viewport" content = "width=device-width, initial-scale = 1">
    <style type="text/css">
        @media only screen and (max-width: 768px) {
            .form-group label.text-right {
                text-align:left !important;
            }
            .form-group .col-sm-6 {
                width:50% !important;
            }
        }
        .content {
            min-height: 650px;
        }

        .div-listleft {
            border: 1px solid #ccc;
            min-height: 73vh;
        }

        @media only screen and (min-width: 960px) {
            .pad-left0 {
                padding-left: 2px;
            }

            .pad-right0 {
                padding-right: 2px;
            }
        }
        .modal-open .modal {
    overflow-x: hidden !important;
    overflow-y: hidden !important;
}

        .div-view.div-scroll {
           
            max-height: 390px;
            margin: 0px 24px;
            border: 1px solid #ccc;
        }

        .left-plotlist option {
            border-bottom: 1px solid #ccc;
            font-size: 12px;
            padding-left: 8px;
        }

        @media only screen and (min-width: 900px) {
            .left-plotlist {
                width: 100%;
                height: 506px !important;
            }
        }

         #ModalGridchange .modal-header {
                padding: 0px 12px;
                background: #e4e4e4;
                border-bottom: 1px solid #ccc;  
              }
              #ModalGridchange .modal-footer {
                padding:0;
              }
              #ModalGridchange button {
                margin-top:1px;
              }
              @media only screen and (min-width: 768px) {
                  #ModalGridchange .modal-dialog {
                      margin: 17% 56% !important;
                      width: 35% !important;
                  }
                  #ModalGridchange {
                    right:21%;
                    top:10%;
                  }
                  .modal-dialog
                  {
                      width: 389px !important;
                      margin-left: 55% !important;
                      margin-top: 22% !important;
                  }
              }
          @media only screen and (max-width: 768px) {
               .modal-dialog
                  {
                        width: 389px !important;
                        margin-left: 55% !important;
                        margin-top: 22% !important;
                  }
          
          }
          .modal-backdrop {
    
    z-index: 0 !important;
  
}
.modal-backdrop.in {
    opacity: -0.5 !important;
    
}
    </style>
    <script type="text/javascript">

        function RemoveSpaces(string) {

            return string.split(' ').join('');

        }  
       
    $(document).ready(function () {
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
    });

    function PageLoaded(sender, args) {
        $(".chosen").chosen();

        $(".MultiSelect").chosen(); 
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
    </asp:ScriptManager>
  <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                <ProgressTemplate>
                    <div class="fgh">
                        <div class="hgf">
                            <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress> 
      <input type="button" value="Click Me" style="display:none;" id="btnModalGridchange" data-toggle="modal" data-target="#ModalGridchange" >
             <div class="modal fade" id="ModalGridchange"  role="dialog">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><asp:Label runat="server" ID="change_title" Text="Add Plot Instantly"/></h4>
        </div>
        <div class="modal-body">        
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Regional Office :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:Label ID="lbl_ModalRegionalOffice" runat="server"></asp:Label>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Industrial Area :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:Label ID="lbl_ModalIA" runat="server"></asp:Label>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                 Sector :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:Label ID="lbl_ModalSector" runat="server"></asp:Label>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Plot No :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txt_ModalPlotNo" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" onkeypress="return ( event.charCode != 32 );" onblur="this.value=RemoveSpaces(this.value);"></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Plot Area :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txt_ModalPlotARea" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
             <hr class="myhrline" />
        </div>
        <div class="modal-footer">
            <div class="border-buttons pull-right">
           <asp:HiddenField  runat="server"  ID="change_title1" /><asp:HiddenField  runat="server"  ID="change_id" /> <asp:Button ID="Button2" runat="server" CssClass="btn btn-sm btn-primary btn-popup" Text="Add" OnClick="Button2_Click"   /> 
          <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal">Close</button></div>
        </div>
      </div>
      
    </div>
  </div>

   

     <div class="row topbtncollapse" id="topbtncollapse">
            <div class="col-md-12 col-sm-12 col-xs-12 top-menu-fulldiv12" style="background: #dbdbdb;padding:0;">
                <div>
              
                <div style="border-left:1px solid #000;" class="text-center top-menu-fulldiv">
                    Operate<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                           <a runat="server" id="menunew" onserverclick="menunew_ServerClick"><i class="fa fa-plus" aria-hidden="true"></i><br />New</a>                            
                        </li>
                        <li>
                            <a runat="server" id="menuedit" onserverclick="menuedit_ServerClick"><i class="fa fa-pencil-square-o" aria-hidden="true"></i><br />Edit</a>                            
                        </li>
                        <li>
                            <a runat="server" id="menudelete" onserverclick="menudelete_ServerClick"><i class="fa fa-trash-o" aria-hidden="true"></i><br />Delete</a>                            
                        </li>
                        <li>
                            <a runat="server" id="Save_menu" onserverclick="Save_menu_ServerClick" ><i class="fa fa-floppy-o " aria-hidden="true"></i><br />Save</a>                            
                        </li> 
                        <li>
                            <a runat="server" id="refresh_menu" onserverclick="refresh_menu_ServerClick"><i class="fa fa-refresh" aria-hidden="true"></i><br />Refresh</a>                           
                        </li>
                         <li>
                            <a runat="server" id="add_plot"  data-toggle="modal" data-target="#ModalGridchange"><i class="fa fa-refresh" aria-hidden="true"></i><br />Add Plot</a>                           
                        </li>
                           <li>
                            <a runat="server" id="excel_export" onserverclick="excel_export_ServerClick"><i class="fa fa-file-excel-o" aria-hidden="true"></i><br />Export to Excel</a>                           
                        </li>
                    </ul>
                </div>
              
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
           <div id="divMessageError" class="MessagePennel" runat="server" style="display:none;">
                            <label>
                                <span class="check-cross" runat="server">✖</span>
                                
                                <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
                            </label>
                        </div>
            <div class="clearfix"></div>
            <div class="">
                <div class="col-md-12 col-sm-12 col-xs-12" style="padding: 0;">
                    <div class="panel panel-default">
                        <div class="" style="margin-top: 3px;">
                            <table id="tblsearch" class="table table-striped table-bordered margin-b-2px request-table">
                                <tr style="background: #ececec;">
                                    <td class="font-bold">
                                        <span style="color: Red">*</span>
                                        Regional Office :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddloffice" runat="server" OnSelectedIndexChanged="Regional_Changed" AutoPostBack="true" CssClass="chosen btn btn-sm btn-default dropdown-toggle similar-select">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="font-bold">
                                        <span style="color: Red">*</span>
                                        Industrial Area :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpdwnIA" runat="server" AutoPostBack="true" CssClass="chosen btn btn-sm btn-default dropdown-toggle similar-select" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td class="font-bold">
                                        <span style="color: Red">*</span>
                                       Sector :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpdwnSector" runat="server" AutoPostBack="true" CssClass="chosen btn btn-sm btn-default similar-select" OnSelectedIndexChanged="drpdwnSector_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>

                            </table>
                        </div>
                        <div class="row">

<style>
    @media only screen and (min-width: 960px){
        .myplot-left{
            width:21% !Important;
        }
        .myplot-right
        {
            width:78% !Important;
        }
    }
</style>


                            <div class="col-md-3 col-sm-4 col-xs-12 pad-right0 myplot-left">
                                <div class="div-listleft">
                                   
                                    <div style="max-height:528px;overflow-y:auto;" >
                                          <div class="panel panel-heading font-bold">Search Plot <span style="margin-left:62px;">No of Plots : <asp:Label runat="server" ID="lblNo" Text="0"></asp:Label> </span></div>
                                           <asp:DropDownList ID="DropDownList1" runat="server" CssClass="input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                               <asp:ListItem Value="0">--ALL---</asp:ListItem>
                                               <asp:ListItem Value="1">Allotted</asp:ListItem>
                                               <asp:ListItem Value="2">Available For Allotment</asp:ListItem>
                                               <asp:ListItem Value="3">Not Available for Allotment</asp:ListItem>
                                               <asp:ListItem Value="4">Updated</asp:ListItem>
                                               <asp:ListItem Value="5">Not Updated</asp:ListItem>
                                           </asp:DropDownList> 
                                        <asp:TextBox ID="txtSearch" runat="server" class="input-sm similar-select1" placeholder="Search Plot Here" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:GridView ID="GridView2" runat="server"
                                                CssClass="table table-striped table-bordered table-hover request-table"
                                                AllowPaging="false"
                                                AllowSorting="True"
                                                AutoGenerateColumns="False"
                                                DataKeyNames="PlotMasterId,PlotNumber,PlotArea,Status,LandUse,landuseCode,ReservedCategory,plotSubstatus,SUBSTATUS,NORTH,SOUTH,EAST,WEST,Remarks,ISLOCKED,IsActive,permisesUse,ApplicableLocationCharge,AssetStatus,AssetValue,AssetDescription,NorthID,SouthID,EastID,WestID,TracingName,JoinCertificateName"
                                                GridLines="Horizontal"
                                                OnRowDataBound="GridView2_RowDataBound"
                                                OnRowCommand="GridView2_RowCommand"
                                                OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
                                                Width="100%"
                                                ItemStyle-Width="10%" >
                                                <Columns>
                                                    <asp:BoundField DataField="plots" HeaderText="Plots List" SortExpression="plots" />
                                              
                                                </Columns>
                                            </asp:GridView>
                                     </div>
                                </div>
                            </div>
                            <div class="col-md-9 col-sm-8 col-xs-12 pad-left0 myplot-right">



                                <div class="div-listleft" style="position:relative;">
                                    <div class="note" style="display:none;">
                                        <div class="form-group" style="margin-top:10px;">
                                                <div class="row">
                                                    <div class="col-md-3 col-md-6 col-xs-6 text-right">Total Plots Under Development :</div>
                                                    <div class="col-md-3 col-md-6 col-xs-6"><asp:Label ID="lblTotalPlotUnderdevelopment" runat="server"></asp:Label></div>
                                                    <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                    <div class="col-md-3 col-md-6 col-xs-6 text-right">Total Plots in Numbers :</div>
                                                    <div class="col-md-3 col-md-6 col-xs-6"><asp:Label ID="lblTotalPlotsinNumbers" runat="server"></asp:Label></div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-md-3 col-md-6 col-xs-6 text-right">Total Plots Under Sick Unit :</div>
                                                    <div class="col-md-3 col-md-6 col-xs-6"><asp:Label ID="lblTotalPlotSickUnit" runat="server"></asp:Label></div>
                                                    <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                    <div class="col-md-3 col-md-6 col-xs-6 text-right">Total Plots Area :</div>
                                                    <div class="col-md-3 col-md-6 col-xs-6"><asp:Label ID="lblTotalPlotArea" runat="server"></asp:Label></div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-md-3 col-md-6 col-xs-6 text-right">Total Plots Unallotted(Available) :</div>
                                                    <div class="col-md-3 col-md-6 col-xs-6"><asp:Label ID="Label1" runat="server"></asp:Label></div>
                                                    <div class="col-md-3 col-md-6 col-xs-6 text-right">Total Plots Unallotted(Not Available) :</div>
                                                    <div class="col-md-3 col-md-6 col-xs-6"><asp:Label ID="Label2" runat="server"></asp:Label></div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                    </div>
                                    <div style="margin: 3px 4px;border: 1px solid #ccc;">
                                        <div style="margin: 3px 4px;border: 3px solid #ccc;">


                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Plot No :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtPlotNo" runat="server" Width="100%" class="input-sm similar-select1" onkeypress="return ( event.charCode != 32 );" onblur="this.value=RemoveSpaces(this.value);"></asp:TextBox>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Area(in Sqmts) :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtArea" runat="server" Width="100%" class="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Land Use :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                   <asp:DropDownList ID="drpLandUse" runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Current Status :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                     <asp:TextBox ID="txtBoxDefaulter" Width="100%" runat="server" Enabled ="false" class="input-sm similar-select1"></asp:TextBox>
                                                                    <%--<asp:DropDownList ID="drpCategory" runat="server" CssClass="input-sm similar-select1"></asp:DropDownList>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Status :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:DropDownList ID="drpStatus" runat="server" CssClass="chosen input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="drpStatus_SelectedIndexChanged"></asp:DropDownList>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Sub-Status :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:DropDownList ID="drpSubStatus" runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    North :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                       <asp:DropDownList ID="drpNorth" runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                                                                    <asp:TextBox ID="txtFrontSide" Width="100%" runat="server" class="input-sm similar-select1" Visible="false"></asp:TextBox>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    South :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                     <asp:DropDownList ID="drpSouth" runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                                                                    <asp:TextBox ID="txtBackSide" Width="100%" runat="server" class="input-sm similar-select1" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    East :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:DropDownList ID="drpeast" runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                                                                    <asp:TextBox ID="txtSide1" runat="server" Width="100%" class="input-sm similar-select1" Visible="false"></asp:TextBox>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    West :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                     <asp:DropDownList ID="drpWest" runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                                                                    <asp:TextBox ID="txtSide2" runat="server" Width="100%" class="input-sm similar-select1" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Permises Use :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                   <asp:DropDownList ID="drppermisesUse" runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Lock Record :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:DropDownList ID="drplock" runat="server" CssClass="input-sm similar-select1">
                                                                        <asp:ListItem Value="0">No</asp:ListItem>
                                                                        <asp:ListItem value="1">Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Applicable location charge :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:DropDownList runat="server" ID="drpApplicableLocation" CssClass="chosen  similar-select1 input-sm dropdown-toggle">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                   Remarks :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                   <asp:TextBox runat="server" ID="txtRemarks" Width="100%" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                              <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Is there any existing assets on plot  :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:DropDownList runat="server" ID="DdlAssetStatus" CssClass="chosen similar-select1 input-sm dropdown-toggle" OnSelectedIndexChanged="DdlAssetStatus_SelectedIndexChanged" AutoPostBack="true">
                                                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                                                         <asp:ListItem Value="1">YES</asp:ListItem>
                                                                    </asp:DropDownList>
                                                               
                                                                </div>
                                                            </div>
                                                   <div class="row" runat="server" id="AssetDiv" visible="false">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                   Asset Description  :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:TextBox runat="server" ID="txtAssetDesc" class="input-sm similar-select1"></asp:TextBox>                                                           
                                                                </div>
                                                         <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                   Asset Value  :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:TextBox runat="server" ID="txtAssetValue" class="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>                                                           
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                       <div id="Tracing" class="row" runat="server" visible="false">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                   Tracing :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:FileUpload ID="fileupload1" runat="server" CssClass="form-control form-control-sm" ToolTip="Upload" accept=".pdf" />                                                        
                                                                </div>
                                                 <div class="col-md-6 col-sm-6 col-xs-6">
                                                                  <asp:Button ID="btnupload" runat="server" Text="Upload" CssClass="rounded-0 btn btn-primary" style="padding:2px 15px;margin-top: 5px;" OnClick="btnupload_Click"/> 
                                                                    <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                                                                  <asp:Button ID="btnView" runat="server" Text="View" CssClass="rounded-0 btn btn-primary" style="padding:2px 15px;margin-top: 5px;" OnClick="btnView_Click"/>
                                                                       <asp:Label runat="server" ID="lblPlotID" Visible="false"></asp:Label>                         
                                                                </div>
                                                        
                                                            </div>
                                            <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                       <div id="jc_Div" class="row" runat="server" visible="false">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                   Joint Certificate :
                                                                </label>
                                                              
                                                 <div class="col-md-4 col-sm-6 col-xs-6">
                                                               <asp:Button ID="btn_JCView" runat="server" Text="View" CssClass="rounded-0 btn btn-primary" style="padding:2px 15px;margin-top: 5px;" OnClick="btn_JCView_Click"/>
                                                                                               
                                                                </div>
                                                        
                                                            </div>
                                                        </div>
                                           <asp:Label runat="server" ID="lblLockStatus" Visible="false"></asp:Label>     
                                                           
                                        </div>

                                    </div>
                                    <div class="text-right" style="display:none;">
                                        <button type="button" class="accordion-toggle btn-primary ey-bg" data-toggle="collapse" style="font-size: 12px;" data-parent="#accordion" href="#Allotteedetailbank">
                                            <span class="glyphicon glyphicon-plus"></span>
                                            Allottee Details 
                                        </button>
                                    </div>
                                    <div id="Allotteedetailbank" class="panel-collapse collapse alt-btn">
                                        <div class="div-view div-scroll" style="overflow-y: scroll; max-height: 320px;">
                                        
                                        </div>
                                    </div>



                                    <div class="mynewlegend" style="">
                                        <style type="text/css">
                                            .mynewlegend{
                                                border: 1px solid #ccc;
                                                padding: 0;
                                                
                                                bottom: 0;
                                                width: 100%;
                                            }
                                            @media only screen and (min-width: 1080px){
                                                .mynewlegend
                                                {
                                                    position: absolute;
                                                }
                                            }
                                            @media only screen and (min-width: 960px){
                                                .leg-col
                                                {
                                                    display:table !important;
                                                    width:100% !important;
                                                    border-spacing:3px 1px !important;
                                                    }
                                                    .leg-col1
                                                    {
                                                        display:table-cell !important;
                                                        border: 1px solid #ccc;
                                                        }
                                            }
                                            @media only screen and (min-width: 960px)
                                            {
                                                
                                                
                                            }
                                            .legend-ul {
                                                font-size: 9px;
                                                margin-bottom: 0;
                                            }
                                            .legend-ul li {
                                                width: 165px;
                                                margin-bottom:5px;
                                            }   
                                            .leg-left {
                                                float:left;
                
                                            }
                                            .leg-right {
                                                float:left;
                                                font-size: 9px;
                                                margin-left:5px;
                                            }
                                            .differ-avail {
                                                /*border: 1px solid #ccc;
                                                min-height: 120px;*/
                                            }

                                            .differ-avail p {
                                                border-bottom: 1px solid #ccc;
                                                margin-bottom: 4px;
                                                font-size: 12px;
                                            }
                                            .legend-ul {
                                                padding: 5px;
                                            }
                                        </style>
                                                        <div class="col-md-12 col-sm-12 col-xs-12" style="font-weight: bold; font-size: 12px;">
                                                            Legend:
                                                        </div>
                                                        <div class="col-md-12 col-sm-12 col-xs-12 pad-rt0">
                                                            <div  class="row leg-col">
                                                               
                                                                             <div class="leg-col1">
                                                                                <div class="differ-avail">
                                                                                    <p class="text-center">Available for Allotment</p>
                                                                                    <ul class="list-inline legend-ul">
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #008000;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Developed Land
                                                                                            </div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #93ff93;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                UnDeveloped Land(Available)
                                                                                            </div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #0bd428;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Bulk Land
                                                                                            </div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #8cc394;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Subdivision Available
                                                                                            </div>
                                                                                        </li>
                                                                                    </ul>
                                                                                </div>
                                                                            </div>
                                                                            <div class="leg-col1">
                                                                                <div class="differ-avail">
                                                                                    <p class="text-center">Not Available for Allotment</p>
                                                                                    <ul class="list-inline legend-ul">
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #f9c9bf;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Undeveloped Land(Not Available)
                                                                                            </div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #f1a7a7;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Costing Not Performed
                                                                                            </div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #ff6767;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Under encroachment
                                                                                            </div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #ffe2e2;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Tracing Not Available
                                                                                            </div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #c56399;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Under Litigation
                                                                                            </div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: red;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Wait Period after Cancelation
                                                                                            </div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #d80707;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Reserved as per Court Order
                                                                                            </div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #a00909;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Reserved as per Head Office order
                                                                                            </div>
                                                                                        </li>
                                                                                    </ul>
                                                                                </div>
                                                                            </div>
                                                                            <div class="leg-col1">
                                                                                <div class="differ-avail">
                                                                                    <p class="text-center">Allotted plots</p>
                                                                                    <ul class="list-inline legend-ul">
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #fcffab;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Vacant
                                                                                            </div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #ffe38d;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Sick/Closed
                                                                                            </div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #fbca31;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Functional and Running Unit
                                                                                            </div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #daa500;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Under Construction
                                                                                            </div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div class="leg-left">
                                                                                                <div style="border-radius: 50%; width: 10px; height: 10px; background: #b8bb66;"></div>
                                                                                            </div>
                                                                                            <div class="leg-right">
                                                                                                Land Use Violation
                                                                                            </div>
                                                                                        </li>
                                                                                    </ul>
                                                                                </div>
                                                                            </div>
                                                    
                                                    
                                                                        </div>
                                                               </div>
                                    </div>












                                </div>

                                    



                            </div>
                        </div>

                    </div>
                </div>
            </div>
    </ContentTemplate>

    </asp:UpdatePanel>



    <script type="text/javascript">

        function ShowPopupChange(val) {
            $("#btnModalGridchange").click();
            alert(val);
         }
        $(function () {
            $('.alt-btn').on('shown.bs.collapse', function () {
                $(this).parent().find(".glyphicon-plus").removeClass("glyphicon-plus").addClass("glyphicon-minus");
            }).on('hidden.bs.collapse', function () {
                $(this).parent().find(".glyphicon-minus").removeClass("glyphicon-minus").addClass("glyphicon-plus");
            });
        })



        $(function () {
            $("[id*=GridView2] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });


        function showError() {
            if (document.getElementById("<%= divMessageError.ClientID %>").style.display == 'none') {
                document.getElementById("<%= divMessageError.ClientID %>").style.display = 'block';

            }

        }
        function hideError() {
            if (document.getElementById("<%= divMessageError.ClientID %>").style.display == 'block') {
                document.getElementById("<%= divMessageError.ClientID %>").style.display = 'none';
            }
            return false;
        }

        function InputValidation() {
            var remark = true;
            var RequiredSize = document.getElementById("<%= txtPlotNo.ClientID %>");
               <%-- //var DDlRegion    = document.getElementById("<%= drpCategory.ClientID %>");--%>
                var DDLIA = document.getElementById("<%= drpStatus.ClientID %>");


                if (RequiredSize.value.length <= 0) {
                    RequiredSize.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    RequiredSize.style.borderColor = "";
                }
                if (DDlRegion.selectedIndex == 0) {
                    DDlRegion.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    DDlRegion.style.borderColor = "";
                }
                if (DDLIA.selectedIndex == -1 || DDLIA.selectedIndex == 0) {
                    DDLIA.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    DDLIA.style.borderColor = "";
                }







                if (remark == false) {


                    alert("Fill All Required Field");
                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

                    return false;
                }
                else {
                    hideError();
                    return true;
                }


        }



         function isDecimalKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                    && (charCode < 48 || charCode > 57)) {
                return false;
            } else {


            }
        }

    </script>
</asp:Content>
