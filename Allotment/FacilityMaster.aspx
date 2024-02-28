<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true"  EnableEventValidation = "false" CodeBehind="FacilityMaster.aspx.cs" Inherits="Allotment.FacilityMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">

      
        .selectedCell {
            background-color: lightblue;
        }

        .unselectedCell {
            background-color: white;
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
               
                <div style="border-left:1px solid #000;" class="text-center top-menu-fulldiv">
                    Operate<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                           <a runat="server" id="menunew" onserverclick="menunew_ServerClick" ><i class="fa fa-plus" aria-hidden="true"></i><br />New</a>                            
                        </li>
                        <li>
                            <a runat="server" id="menuedit" onserverclick="menuedit_ServerClick"><i class="fa fa-pencil-square-o" aria-hidden="true"></i><br />Edit</a>                            
                        </li>
                        <li>
                            <a runat="server" id="menudelete" onserverclick="menudelete_ServerClick" ><i class="fa fa-trash-o" aria-hidden="true"></i><br />Delete</a>                            
                        </li>
                        <li>
                            <a runat="server" id="Save_menu" onserverclick="Save_menu_ServerClick" ><i class="fa fa-floppy-o " aria-hidden="true"></i><br />Save</a>                            
                        </li> 
                        <li>
                            <a runat="server" id="refresh_menu" onserverclick="refresh_menu_ServerClick"><i class="fa fa-refresh" aria-hidden="true"></i><br />Refresh</a>                           
                        </li>
                    </ul>
                </div>
              
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="panel panel-default">
                       
                            <table id="tblsearch" class="table table-striped table-bordered margin-b-2px request-table">
                                <tr style="background: #ececec;">
                                    <td class="font-bold">
                                        <span style="color: Red">*</span>
                                        Regional Office :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddloffice" runat="server" OnSelectedIndexChanged="Regional_Changed" AutoPostBack="true" CssClass="chosen btn btn-sm btn-default similar-select">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="font-bold">
                                        <span style="color: Red">*</span>
                                        Industrial Area :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpdwnIA" runat="server" AutoPostBack="true" CssClass="chosen btn btn-sm btn-default similar-select" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged"></asp:DropDownList>
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
                                    <div class="panel panel-heading font-bold"></div>
                                    <div style="max-height:528px;overflow-y:auto;" >
                                             <asp:GridView ID="GridView2" runat="server"
                                                CssClass="table table-striped table-bordered table-hover request-table"
                                                AllowPaging="false"
                                                AllowSorting="True"
                                                AutoGenerateColumns="False"
                                                DataKeyNames="ID,FacilityUniqueID"
                                                GridLines="Horizontal"
                                                Width="100%"
                                                ItemStyle-Width="10%"
                                                OnRowDataBound="GridView2_RowDataBound"
                                                OnRowCommand="GridView2_RowCommand"
                                                 OnSelectedIndexChanged="GridView2_SelectedIndexChanged" >
                                                
                                                <Columns>
                                                    <asp:BoundField DataField="FacilityName" HeaderText="Park List" SortExpression="FacilityName" />                                                 
                                                </Columns>
                                            </asp:GridView>
                                   
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-9 col-sm-8 col-xs-12 pad-left0 myplot-right">



                                <div class="div-listleft" style="position:relative;">
                               
                                    <div style="margin: 3px 4px;border: 1px solid #ccc;">
                                        <div style="margin: 3px 4px;border: 3px solid #ccc;">

                                              <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Facility Type :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:DropDownList ID="ddl_FacilityType" runat="server" CssClass="chosen btn btn-sm btn-default similar-select" Width="100%"></asp:DropDownList>
                                                                    <asp:Label runat="server" ID="lbl_FacilityUniqueID" Visible="false"></asp:Label>
                                                                     <asp:Label runat="server" ID="lbl_FacilityID" Visible="false"></asp:Label>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                   Facility Name :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txt_FacilityName" runat="server" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>                                                                                                       
                                                      <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Facility Desc :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txt_FacilityDesc" runat="server" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Facility Plot No :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txt_FacilityPlotNo" runat="server" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>                                                                                                       
                                                      <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                   Operated & Maintained By :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                      <asp:TextBox runat="server" ID="txt_MaintainedBy" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                   Capicity :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                   <asp:TextBox runat="server" ID="txt_Capicity" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                            <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                   Remarks :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                      <asp:TextBox runat="server" ID="txt_Remarks" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                   Data Lock :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                      <asp:DropDownList ID="ddl_Lock" runat="server" CssClass="chosen btn btn-sm btn-default similar-select" Width="100%">
                                                                           <asp:ListItem Value="0">NO</asp:ListItem>
                                                                           <asp:ListItem Value="1">YES</asp:ListItem>
                                                                      </asp:DropDownList>
                                                                
                                                                </div>
                                                            </div>
                                                        </div>
                                                       
                                            <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                           <asp:Label runat="server" ID="lblLockStatus" Visible="false"></asp:Label>     

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
             $(document).ready(function () {
                 Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
             });

             function PageLoaded(sender, args) {
                 $(".chosen").chosen();
             }

        </script>

</asp:Content>
