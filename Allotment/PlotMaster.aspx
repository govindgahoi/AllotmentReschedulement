<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true"  EnableEventValidation = "false" CodeBehind="PlotMaster.aspx.cs" Inherits="Allotment.PlotMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    



         <script type="text/javascript">
    $(document).ready(function () {
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
    });

    function PageLoaded(sender, args) {
        $(".chosen").chosen();

        $(".MultiSelect").chosen(); 
    }

</script>
       
    <style type="text/css">
        .chosen-container {
            width:100% !important;
        }
        @media only screen and (max-width: 768px) {
            .form-group label.text-right {
                text-align:left !important;
            }
            .form-group .col-sm-6 {
                width:50% !important;
            }
        }
        .content {
            min-height: 600px;
        }

        .div-listleft {
            border: 1px solid #ccc;
            min-height: 70vh;
        }

      
        .div-view.div-scroll {
            overflow-y: scroll;
            max-height: 400px;
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
                height: 600px !important;
            }
        }
    </style>

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
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
    

         <div class="row topbtncollapse" id="topbtncollapse">
            <div class="col-md-12 col-sm-12 col-xs-12 top-menu-fulldiv12" style="background: #dbdbdb;padding:0;">
                <div>
                <div style="" class="text-center top-menu-fulldiv">
                    Dashboard<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li class="">
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_dashboard"><i class="fa fa-tachometer" aria-hidden="true"></i><br />Dashboard</asp:HyperLink>
                        </li>
                    </ul>
                </div>
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
                            <a runat="server" id="menudelete" onserverclick="menudelete_ServerClick"  ><i class="fa fa-trash-o" aria-hidden="true"></i><br />Delete</a>                            
                        </li>
                        <li>
                            <a runat="server" id="Save_menu" onserverclick="Save_menu_ServerClick" ><i class="fa fa-floppy-o " aria-hidden="true"></i><br />Save</a>                            
                        </li> 
                        <li>
                            <a runat="server" id="refresh_menu" onserverclick="refresh_menu_ServerClick"><i class="fa fa-refresh" aria-hidden="true"></i><br />Refresh</a>                           
                        </li>
                    </ul>
                </div>
                <div style="border-left:1px solid #000;border-right:1px solid #000;" class="text-center top-menu-fulldiv">
                    Services<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_draft"><i class="fa fa-pencil-square-o" aria-hidden="true"></i><br />Drafted</asp:HyperLink>                                                        
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_submitted"><i class="fa fa-th-list" aria-hidden="true"></i><br />Submitted</asp:HyperLink>                            
                        </li> 
                           
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_track"><i class="fa fa-credit-card" aria-hidden="true"></i><br />Track</asp:HyperLink>
                            
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_export"><i class="fa fa-credit-card" aria-hidden="true"></i><br />Export</asp:HyperLink>                            
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_import"><i class="fa fa-credit-card" aria-hidden="true"></i><br />Export</asp:HyperLink>                            
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="print"><i class="fa fa-credit-card" aria-hidden="true"></i><br />Print</asp:HyperLink>                            
                        </li>
                      </ul>
                </div>
                 <div style="" class="text-center top-menu-fulldiv">
                    Navigation<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_last"><i class="fa fa-step-backward" aria-hidden="true"></i><br />Last</asp:HyperLink>
                                                      
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_previous"><i class="fa fa-angle-double-left" aria-hidden="true"></i><br />Previous</asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_next"><i class="fa fa-angle-double-right" aria-hidden="true"></i><br />Next</asp:HyperLink>
                            
                        </li>
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_final"><i class="fa fa-step-forward" aria-hidden="true"></i><br />Final</asp:HyperLink>
                            
                        </li>
                    </ul>
                    </div>
                     <div style="border-left:1px solid #000;" class="text-center top-menu-fulldiv">
                        Reports<br />
                        <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                            <li >
                                <asp:HyperLink Enabled="false" runat="server" ID="menu_reports"><i class="fa fa-credit-card" aria-hidden="true"></i><br />Reports</asp:HyperLink>
                                
                            </li>
                         </ul>
                    </div>
                     <div style="border-left:1px solid #000;" class="text-center top-menu-fulldiv">
                        Repository<br />
                        <ul class="list-inline master-nav-icons master-nav-iconsbr master-nav-iconsbr-last" style="border-top:1px solid #ccc;">
                        <li>
                            <asp:HyperLink Enabled="false" runat="server" ID="menu_repository"><i class="fa fa-database" aria-hidden="true"></i><br />Repository</asp:HyperLink>
                            
                        </li>
                      </ul>
                 </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
       
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="panel panel-default ">
                       <div class="table-responsive">
                            <table id="tblsearch" class="table table-striped table-bordered margin-b-2px request-table">
                                <tr style="background: #ececec;">
                                    <td class="font-bold">
                                        <span style="color: Red">*</span>
                                        Regional Office :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddloffice" runat="server" OnSelectedIndexChanged="Regional_Changed" AutoPostBack="true" CssClass="btn btn-sm btn-default similar-select">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="font-bold">
                                        <span style="color: Red">*</span>
                                        Industrial Area :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpdwnIA" runat="server" AutoPostBack="true" CssClass="btn btn-sm btn-default similar-select" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                     <td class="font-bold">
                                        <span style="color: Red">*</span>
                                       Sector :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpdwnSector" runat="server" AutoPostBack="true" CssClass="btn btn-sm btn-default similar-select" OnSelectedIndexChanged="drpdwnSector_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>

                            </table>
                       
                      </div>

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
                                    <div class="panel panel-heading font-bold"></div>
                                    <div style="max-height:528px;overflow-y:auto;" >
                                            <asp:GridView ID="GridView2" runat="server"
                                                CssClass="table table-striped table-bordered table-hover request-table"
                                                AllowPaging="false"
                                                AllowSorting="True"
                                                AutoGenerateColumns="False"
                                                DataKeyNames="PlotNo,PlotUniqueID,PlotArea,Status,LandUse,landuseCode,ReservedCategory,plotSubstatus,SUBSTATUS,NORTH,SOUTH,EAST,WEST,Remarks,ISLOCKED,IsActive,permisesUse,ApplicableLocationCharge"
                                                GridLines="Horizontal"
                                                OnRowDataBound="GridView2_RowDataBound"
                                                OnRowCommand="GridView2_RowCommand"
                                                Width="100%"
                                                ItemStyle-Width="10%" >
                                                <Columns>
                                                    <asp:BoundField DataField="plots"    HeaderText ="Plots List" SortExpression="plots" />
                                                    <asp:BoundField DataField="PlotNo"   HeaderText ="Plots List" Visible="false" SortExpression="PlotNumber" />
                                                    <asp:BoundField DataField="ForColor" HeaderText ="ForColor" Visible="false" SortExpression="ForColor" />
                                                    <asp:BoundField DataField="PlotArea" HeaderText ="PlotArea" Visible="false" SortExpression="PlotArea" />
                                                    <asp:BoundField DataField="Status"   HeaderText ="Status" Visible="false" SortExpression="Status" />
                                                    <asp:BoundField DataField="LandUse"  HeaderText ="LandUse" Visible="false" SortExpression="LandUse" />
                                                    <asp:BoundField DataField="ReservedCategory" HeaderText="ReservedCategory" Visible="false" SortExpression="ReservedCategory" />
                                                    <asp:BoundField DataField="plotSubstatus" HeaderText="plotSubstatus" Visible="false" SortExpression="plotSubstatus" />
                                                    <asp:BoundField DataField="NORTH" HeaderText="NORTH" Visible="false" SortExpression="NORTH" />
                                                    <asp:BoundField DataField="SOUTH" HeaderText="SOUTH" Visible="false" SortExpression="SOUTH" />
                                                    <asp:BoundField DataField="EAST" HeaderText="EAST" Visible="false" SortExpression="EAST" />
                                                    <asp:BoundField DataField="WEST" HeaderText="WEST" Visible="false" SortExpression="WEST" />
                                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" Visible="false" SortExpression="Remarks" />
                                                    <asp:BoundField DataField="ISLOCKED" HeaderText="ISLOCKED" Visible="false" SortExpression="ISLOCKED" />
                                                    <asp:BoundField DataField="IsActive" HeaderText="IsActive" Visible="false" SortExpression="IsActive" />
                                                    <asp:BoundField DataField="permisesUse" HeaderText="permisesUse" Visible="false" SortExpression="permisesUse" />
                                             
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
                                                                    <asp:TextBox ID="txtPlotNo" runat="server" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Area(in Sqmts) :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtArea" runat="server" class="input-sm similar-select1"></asp:TextBox>
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
                                                                   <asp:DropDownList ID="drpLandUse" runat="server" CssClass="chosen input-sm similar-select1" OnSelectedIndexChanged="drpLandUse_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Current Status :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                     <asp:TextBox ID="txtBoxDefaulter" runat="server" Enabled ="false" class="input-sm similar-select1"></asp:TextBox>
                                                                 
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
                                                                       <asp:DropDownList ID="drpNorth" runat="server" CssClass="chosen input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="drpNorth_SelectedIndexChanged"></asp:DropDownList>
                                                                    <asp:TextBox ID="txtNorth" runat="server" class="input-sm similar-select1" Visible="false"></asp:TextBox>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    South :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                     <asp:DropDownList ID="drpSouth" runat="server" CssClass="chosen input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="drpSouth_SelectedIndexChanged"></asp:DropDownList>
                                                                    <asp:TextBox ID="txtSouth" runat="server" class="input-sm similar-select1" Visible="false"></asp:TextBox>
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
                                                                     <asp:DropDownList ID="drpeast" runat="server" CssClass="chosen input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="drpeast_SelectedIndexChanged"></asp:DropDownList>
                                                                    <asp:TextBox ID="txtEast" runat="server" class="input-sm similar-select1" Visible="false"></asp:TextBox>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    West :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                     <asp:DropDownList ID="drpWest" runat="server" CssClass="chosen input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="drpWest_SelectedIndexChanged"></asp:DropDownList>
                                                                    <asp:TextBox ID="txtWest" runat="server" class="input-sm similar-select1" Visible="false"></asp:TextBox>
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
                                                                   <asp:DropDownList ID="drppermisesUse"  runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>

                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Lock Record :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:DropDownList ID="drplock" runat="server" CssClass="chosen input-sm similar-select1">
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
                                                                    <asp:DropDownList runat="server" ID="drpApplicableLocation" CssClass="chosen similar-select1 input-sm dropdown-toggle">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                   Remarks :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                   <asp:TextBox runat="server" ID="txtRemarks" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                           <asp:Label runat="server" ID="lblLockStatus" Visible="false" ></asp:Label>  
                                             

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
                                                        <div class="col-md-12 col-sm-12 col-xs-12 pad-rt0 pad-lt0">
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
        $(function () {
            $('#drppermisesUse').c

        });


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


 

       
    </script>
</asp:Content>
