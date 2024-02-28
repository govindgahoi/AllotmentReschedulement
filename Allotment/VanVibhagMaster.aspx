<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="VanVibhagMaster.aspx.cs" Inherits="Allotment.Van_VibhagMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         function isDecimalKey(evt) {
             var charCode = (evt.which) ? evt.which : evt.keyCode
             if (charCode != 46 && charCode > 31
                 && (charCode < 48 || charCode > 57)) {
                 return false;
             } else {
             }
         }
    </script>
    <style>
        .box-panel {
            -webkit-box-shadow: 0 1px 1px transparent;
            box-shadow: 0 1px 1px transparent;
        }

        .box-back-none {
            background: none !important;
            box-shadow: inset 0px 1px 1px transparent !important;
        }

        .tooltip {
            position: absolute;
            top: 0;
            left: 0;
            z-index: 3;
            display: none;
            background-color: #FB66AA;
            color: White;
            padding: 5px;
            font-size: 10pt;
            font-family: Arial;
        }

        td {
            cursor: pointer;
        }
    </style>

    <script type="text/javascript">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
   <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">
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
            <cc1:messagebox id="MessageBox1" runat="server" />
            <cc1:confirmbox id="ConfirmBox1" runat="server" />
     <div class="row">
            <div class="col-md-12" style="background: #dbdbdb;">
                <div>
                <div style="width: 100px;float: left;background: #dbdbdb;font-size:11px;" class="text-center">
                    <br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li class="disabled">
                            <a runat="server"  onserverclick="Home_ServerClick">
                                <i class="fa fa-tachometer" aria-hidden="true"></i><br />Home
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;font-size:11px;" class="text-center">
                    Operate<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li>
                            <a runat="server"  onserverclick="save_ServerClick">
                                <i class="fa fa-floppy-o " aria-hidden="true"></i><br />Save
                            </a>
                        </li> 
                        <li>
                            <a runat="server"  onserverclick="Upload_ServerClick">
                                <i class="fa fa-refresh" aria-hidden="true"></i><br />Upload
                            </a>
                        </li>
                         <li>
                            <a runat="server" onserverclick="reset_ServerClick">
                                <i class="fa fa-refresh" aria-hidden="true"></i><br />Refresh
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;border-right:1px solid #000;font-size:11px;" class="text-center">
                    Services<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-plus" aria-hidden="true"></i><br />New
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-pencil-square-o" aria-hidden="true"></i><br />Drafted
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-th-list" aria-hidden="true"></i><br />Submitted
                            </a>
                        </li> 
                           
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-credit-card" aria-hidden="true"></i><br />Track 
                            </a>
                        </li>
                      </ul>
                </div>
                 <div style="float: left;background: #dbdbdb;font-size:11px;" class="text-center">
                    Navigation<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                                <a href="#" class="disable">
                                    <i class="fa fa-step-backward" aria-hidden="true"></i><br />Last
                                </a>                        
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-angle-double-left" aria-hidden="true"></i><br />Previous
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-angle-double-right" aria-hidden="true"></i><br />Next
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-step-forward" aria-hidden="true"></i><br />Final
                            </a>
                        </li>
                    </ul>
                    </div>
                     <div style="float: left;background: #dbdbdb;font-size:11px;border-left:1px solid #000;">
                        <br />
                        <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                            <li >
                                <a href="#" class="disable">
                                    <i class="fa fa-credit-card" aria-hidden="true"></i><br />Dues
                                </a>
                            </li>
                         </ul>
                    </div>
                     <div style="float: left;background: #dbdbdb;font-size:11px;border-left:1px solid #000;">
                        <br />
                        <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-database" aria-hidden="true"></i><br />Repository
                            </a>
                        </li>
                      </ul>
                 </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
            <div class="row">
            <div class="col-md-12">
                <asp:Label ID="RateIdlbl" runat="server" Visible="false"></asp:Label>
                <div class="panel panel-default">
                    <div class="panel-heading font-bold">
                        Plantation Industrial Area  Master                          
                    </div>
                    <div class="panel-body">
                            <div class="form-group">
                                <div class="row">
                                    <label class="col-md-3 text-right">
                                        <span style="color: Red">*</span>
                                        Name of Industrial Area :
                                    </label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlArea" runat="server" Width="100%" CssClass="input-sm dropdown-toggle similar-select1" ></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <div class="row">
                                    <label class="col-md-3 text-right">
                                        Location Address :
                                    </label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtLocationAddress" runat="server" CssClass="input-sm similar-select1" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <div class="row">
                                    <label class="col-md-3 text-right">
                                        Plot No :
                                    </label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtPlotNo" runat="server" CssClass="input-sm similar-select1" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <div class="row">
                                    <label class="col-md-3 text-right">
                                        Plot Size :
                                    </label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtPlotSize" onkeypress="return isDecimalKey(event);" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <div class="row">
                                    <label class="col-md-3 text-right">
                                        Species Of Trees
                                    </label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtSpeciesofTrees" runat="server" CssClass="input-sm similar-select1" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">
                                <div class="row">
                                    <label class="col-md-3 text-right">
                                        No Of Trees:
                                    </label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtNoofTrees" runat="server" CssClass="input-sm similar-select1" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                             <div class="clearfix"></div>
                                <hr class="myhrline" />
                                <div class="form-group" style="margin-top:4px;margin-bottom:0;">
                                    <div class="row">
                                        <asp:UpdatePanel ID="pnlFileUpload" runat="server">
                                            <ContentTemplate>
                                                <label class="col-md-3 col-sm-12 text-right">Upload Plantation Document<br /><span class="myred">(Pdf of size upto 1mb only)</span></label>
                                                <div class="col-md-3">
                                                    <asp:FileUpload ID="fileupload" Width="300px" CssClass="form-control" runat="server" />                                                    
                                                </div>
                                                <div class="col-md-3" style="display:none;">
                                                    <span>
                                                        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" CssClass="btn btn-primary ey-bg btn-sm" style="margin:0 1px 0 0;width:65px;" Text="Upload" />
                                                        
                                                    </span>
                                                    <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                                                </div>
                                            </ContentTemplate>
                                              <Triggers>
                                                <asp:PostBackTrigger ControlID="btnUpload" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <div class="col-md-3">
                                            <div class="row" style="display:none;">
                                            <p class="text-right">
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-primary" Text="Save" OnClick="btnSubmit_Click" />
                                    &nbsp;&nbsp;<asp:Button ID="btnReset" runat="server" CssClass="btn btn-sm btn-primary" Text="Reset" OnClick="btnReset_Click" /></p>
                                                </div>
                                        </div>
                                    </div>
                                </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="form-group">

                                <div class="col-md-12 col-sm-12" style="padding-top: 2px;">
                                    
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <asp:Label ID="msg" runat="server"></asp:Label>
                        
                    </div>
                </div>
            
                <div class="panel panel-default">
                    <div class="clearfix"></div>
                    <div class="panel-heading">
                        <div class="col-md-6 font-bold" style="margin-top: 5px;">
                           Plantation  Detail
                        </div>
                        <div class="input-group col-md-4 col-sm-12" style="float: right; padding: 2px 0;">
                            <asp:TextBox ID="txtSearch" Width="100%" CssClass="input-sm" runat="server" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged"  />
                            <span class="input-group-btn">
                                <button id="btnSearch" class="btn btn-sm btn-primary" type="button" ><i class="fa fa-search" style="color:#fff;"></i></button>
                            </span>
                        </div>
                        <div class="clearfix"></div>

                    </div>
                    <div class="panel-body gallery  table-responsive">
                        <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                        <asp:GridView ID="PlantationGrid" runat="server" AutoGenerateColumns="false" DataKeyNames="ID,IAId,Industrial Area" 
                            AllowPaging="true" AllowSorting="True" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" 
                            OnRowCommand="PlantationGrid_RowCommand"
                            OnPageIndexChanging="PlantationGrid_PageIndexChanging" OnSorting="PlantationGrid_Sorting" 
                            OnRowDataBound="PlantationGrid_RowDataBound" OnPreRender="PlantationGrid_PreRender" 
                            PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="selectDocument" CommandArgument='<%#Eval("Industrial Area")%>' OnClientClick="return openInNewTab();"><i class="fa fa-file-pdf-o" style="font-size:25px; color:red;" aria-hidden="true"  ></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Industrial Area" HeaderStyle-HorizontalAlign="Left"  HeaderText="Name of Industrial Area" ItemStyle-Width="10%" />
                                    <asp:BoundField DataField="Location Address" HeaderStyle-HorizontalAlign="Center"   HeaderText="Location Address" />
                                    <asp:BoundField DataField="PlotNo" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="14%"    HeaderText="Plot No"  />
                                    <asp:BoundField DataField="PlotSize" HeaderStyle-HorizontalAlign="Center"   HeaderText="Plot size (Square meter)" />
                                    <asp:BoundField DataField="Species of Trees" HeaderStyle-HorizontalAlign="Left"   HeaderText="Species of Trees" />
                                    <asp:BoundField DataField="No of Trees" HeaderStyle-HorizontalAlign="Left"   HeaderText="No of Trees According to Species at Plot" />
                                 <asp:TemplateField HeaderText="Update">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                 <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in"  CommandName="Process" CommandArgument='<%# (Container.DataItemIndex) %>' ToolTip="Click here For Update Plantation Detail " />
                                    </ItemTemplate>

                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Delete">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="DeletePlantation"  CommandArgument='<%# (Container.DataItemIndex) %>'   ToolTip="Click here to Plantation Detail" />
                                        </span>  
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
