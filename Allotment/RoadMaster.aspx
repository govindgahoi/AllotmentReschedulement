<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true"  EnableEventValidation = "false" CodeBehind="RoadMaster.aspx.cs" Inherits="Allotment.RoadMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
         <script type="text/javascript">
    $(document).ready(function () {
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
    });

    function PageLoaded(sender, args) {
        $(".chosen").chosen();
    }

</script>
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

<%--                               OnSelectedIndexChanged="OnSelectedIndexChanged"--%>

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
                                                DataKeyNames="ID,RoadName,RoadWidth,RoadLength,Row,RoadType,Median,MedianWidth,GreenBelt,StreetLight,NoOfStreetLight,StormWaterDrainage,FootPath,CycleTrack,RoadBegPoint,RoadEndPoint,IndustrialDrainage,ISLOCKED"
                                                GridLines="Horizontal"
                                                OnRowDataBound="GridView2_RowDataBound"
                                                OnRowCommand="GridView2_RowCommand"
                                                OnSelectedIndexChanged="GridView2_SelectedIndexChanged"

                                     

                                                Width="100%"
                                                ItemStyle-Width="10%" >
                                                <Columns>
                                                    <asp:BoundField DataField="RoadName" HeaderText="Road List" SortExpression="RoadName" />
                                                    
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
                                                                    Road No :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtRoadNo" runat="server" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                       <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Right Of Way (In Mts) :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                  
                                                                    <asp:TextBox ID="txtRow" runat="server" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                        
                                                                 <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                   Road Width (In Mts) :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtRoadWidth" runat="server" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                               <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                   Road Length (In Mts) :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtLength" runat="server" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                       <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                        
                                                                 <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                   Road Begining Point :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtBegPoint" runat="server" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                               <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                     Road End Point :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtEndPoint" runat="server" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Median :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                     <asp:DropDownList ID="drpMeadian" runat="server" CssClass="chosen input-sm similar-select1" OnSelectedIndexChanged="drpMeadian_SelectedIndexChanged" AutoPostBack="true">
                                                                         <asp:ListItem>--Select--</asp:ListItem>
                                                                         <asp:ListItem>Yes</asp:ListItem>
                                                                         <asp:ListItem>No</asp:ListItem>
                                                                     </asp:DropDownList>
                                                                   
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    GreenBelt :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                     <asp:DropDownList ID="drpGreenBelt" runat="server" CssClass="chosen input-sm similar-select1">
                                                                         <asp:ListItem>--Select--</asp:ListItem>
                                                                         <asp:ListItem>Yes</asp:ListItem>
                                                                         <asp:ListItem>No</asp:ListItem>
                                                                     </asp:DropDownList>
                                                                   
                                                                </div>
                                                            </div>
                                                        </div>
                                            <div class="form-group" runat="server" id="Div1" visible="false">
                                                      <div class="row">
                                                       <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                  Median Width :
                                                                </label>
                                                                <div class="col-md-10 col-sm-6 col-xs-6">
                                                                      <asp:TextBox ID="txtmedianWidth" runat="server" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                          </div>
                                                 </div>
                                            <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Street Light :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                   <asp:DropDownList ID="drpStreetLight" runat="server" CssClass="chosen input-sm similar-select1" OnSelectedIndexChanged="drpStreetLight_SelectedIndexChanged" AutoPostBack="true">
                                                                       <asp:ListItem>--Select--</asp:ListItem>
                                                                       <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                       <asp:ListItem Value="No">No</asp:ListItem>
                                                                   </asp:DropDownList>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Industrial Drainage :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <asp:DropDownList ID="drpIndustrialDrainage" runat="server" CssClass="chosen input-sm similar-select1">
                                                                       <asp:ListItem>--Select--</asp:ListItem>
                                                                       <asp:ListItem>Yes</asp:ListItem>
                                                                       <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                  <div class="form-group" runat="server" id="StreetDiv" visible="false">
                                                      <div class="row">
                                                       <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                  No Of Street Lights :
                                                                </label>
                                                                <div class="col-md-10 col-sm-6 col-xs-6">
                                                                      <asp:TextBox ID="txtNoOfStreetLights" runat="server" class="input-sm similar-select1"></asp:TextBox>
                                                                </div>
                                                          </div>
                                                 </div>
                                            <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Storm Water Drainage :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                      <asp:DropDownList ID="drpStormWaterDrainage" runat="server" CssClass="chosen input-sm similar-select1">
                                                                       <asp:ListItem>--Select--</asp:ListItem>
                                                                       <asp:ListItem>Yes</asp:ListItem>
                                                                       <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                   FootPath :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                   <asp:DropDownList ID="drpFootpath" runat="server" CssClass="chosen input-sm similar-select1">
                                                                       <asp:ListItem>--Select--</asp:ListItem>
                                                                       <asp:ListItem>Yes</asp:ListItem>
                                                                       <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                            
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                    Cycle Track :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                      <asp:DropDownList ID="drpCycleTrack" runat="server" CssClass="chosen input-sm similar-select1">
                                                                       <asp:ListItem>--Select--</asp:ListItem>
                                                                       <asp:ListItem>Yes</asp:ListItem>
                                                                       <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                 <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                                  Road Type :
                                                                </label>
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                     <asp:DropDownList ID="drpRoadType" runat="server" CssClass="chosen input-sm similar-select1">
                                                                         <asp:ListItem>--Select--</asp:ListItem>
                                                                         <asp:ListItem>Kaccha Road</asp:ListItem>
                                                                         <asp:ListItem>Bitumen Road</asp:ListItem>
                                                                         <asp:ListItem>Concrete</asp:ListItem>
                                                                         <asp:ListItem>Inter-Locking Tiles</asp:ListItem>
                                                                     </asp:DropDownList>
                                                                   
                                                                </div>
                                                                
                                                            </div>
                                                        </div>
                                            <div class="clearfix"></div>
                                                        <hr class="myhrline" />
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
                                           <%--  <uc1:UC_ApplicantDetails runat="server" ID="UC_ApplicantDetails" />--%>
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


        function showError()
        {
            if (document.getElementById("<%= divMessageError.ClientID %>").style.display == 'none')
            {
                document.getElementById("<%= divMessageError.ClientID %>").style.display = 'block';

            }

        }
        function hideError()
        {
            if (document.getElementById("<%= divMessageError.ClientID %>").style.display == 'block') {
                document.getElementById("<%= divMessageError.ClientID %>").style.display = 'none';
            }
            return false;
        }

        function InputValidation()
        {
            var remark = true;
            var RequiredSize = document.getElementById("<%= txtRoadNo.ClientID %>");
               

            if (RequiredSize.value.length <= 0) {

                RequiredSize.style.borderColor = '#e52213';
                remark = false;
            }
            else
            {

                RequiredSize.style.borderColor = "";
            }
            if (DDlRegion.selectedIndex == 0) {
                DDlRegion.style.borderColor = '#e52213';
                remark = false;
            }
            else
            {

                DDlRegion.style.borderColor = "";
            }
              

            if (remark == false) {


                alert("Fill All Required Field");
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

                return false;
            }
            else
            {
                hideError();
                return true;
            }


        }





    </script>
</asp:Content>
