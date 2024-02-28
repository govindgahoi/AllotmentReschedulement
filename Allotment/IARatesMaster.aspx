<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" Debug="true" EnableEventValidation="false" CodeBehind="IARatesMaster.aspx.cs"
    Inherits="Allotment.IARatesMaster" MaintainScrollPositionOnPostback="true" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


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
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.2.2/css/buttons.dataTables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>


<script type="text/javascript">
    $(document).ready(function () {
        $('[id*=IARateGrid]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0]}],
            'iDisplayLength': 10,
            buttons: [
                { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible'} }
            ]
        });
    }); 

   

    
    
</script>

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



   <%--<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">



        <ContentTemplate>
            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                <ProgressTemplate>
                    <div class="fgh">
                        <div class="hgf">
                            <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>



            <cc1:MessageBox ID="MessageBox1" runat="server" />
            <cc1:ConfirmBox ID="ConfirmBox1" runat="server" />


            <div class="row">
                <div class="col-md-12" style="background: #dbdbdb;">
                    <div>
                        <div style="width: 100px; float: left; background: #dbdbdb; font-size: 11px;" class="text-center">
                            <br />
                            <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                                <li class="disabled">
                                    <a runat="server" onserverclick="Home_ServerClick">
                                        <i class="fa fa-home" aria-hidden="true"></i>
                                        <br />
                                        Home
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div style="float: left; background: #dbdbdb; border-left: 1px solid #000; font-size: 11px;" class="text-center">
                            Operate<br />
                            <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                                <li>
                                    <a runat="server" id="SaveEntry" onserverclick="SaveEntry_ServerClick">
                                        <i class="fa fa-floppy-o " aria-hidden="true"></i>
                                        <br />
                                        Save
                                    </a>
                                </li>
                                <li>
                                    <a runat="server" onserverclick="Unnamed_ServerClick">
                                        <i class="fa fa-refresh" aria-hidden="true"></i>
                                        <br />
                                        Refresh
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div style="float: left; background: #dbdbdb; border-left: 1px solid #000; border-right: 1px solid #000; font-size: 11px;" class="text-center">
                            Allottee Registration<br />
                            <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                                <li>
                                    <a runat="server" class="disable">
                                        <i class="fa fa-plus" aria-hidden="true"></i>
                                        <br />
                                        New
                                    </a>
                                </li>
                                <li>
                                    <a runat="server" class="disable">
                                        <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                        <br />
                                        History
                                    </a>
                                </li>

                            </ul>
                        </div>
                        <div style="float: left; background: #dbdbdb; font-size: 11px;" class="text-center">
                            Navigation<br />
                            <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                                <li>
                                    <a href="#" class="disable">
                                        <i class="fa fa-step-backward" aria-hidden="true"></i>
                                        <br />
                                        Last
                                    </a>
                                </li>
                                <li>
                                    <a runat="server" class="disable">
                                        <i class="fa fa-angle-double-left" aria-hidden="true"></i>
                                        <br />
                                        Previous
                                    </a>
                                </li>
                                <li>
                                    <a runat="server" id="sernext" class="disable">
                                        <i class="fa fa-angle-double-right" aria-hidden="true"></i>
                                        <br />
                                        Next
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="disable">
                                        <i class="fa fa-step-forward" aria-hidden="true"></i>
                                        <br />
                                        Final
                                    </a>
                                </li>


                            </ul>
                        </div>

                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="row">
                    <asp:Label ID="RateIdlbl" runat="server" Visible="false"></asp:Label>
                    <div class="panel">
                        <div class="">
                            <div class="col-md-12">
                                <div class="panel-heading font-bold" style="text-align: center;">
                                    Industrial Area Rate Master                          
                                </div>
                                <div class="panel-body">

                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Regional Office :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:DropDownList ID="dlregion" runat="server" CssClass="input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="dlregion_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Name of Industrial Area :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:DropDownList ID="IaDdl" runat="server" CssClass="input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="IaDdl_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                      <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Name of Sector :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:DropDownList ID="ddlSector" runat="server" CssClass="input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="ddlSector_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Classification of IA:
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="input-sm dropdown-toggle similar-select1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="S">Slow Moving</asp:ListItem>
                                                    <asp:ListItem Value="F">Fast Moving</asp:ListItem>
                                                    <asp:ListItem Value="VF">Very Fast Moving</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                     <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Rate Type of IA:
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:DropDownList ID="ddlRateType" runat="server" CssClass="input-sm dropdown-toggle similar-select1" OnSelectedIndexChanged="ddlRateType_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="N">Normal Rates</asp:ListItem>
                                                    <asp:ListItem Value="T">Telescopic Rates</asp:ListItem>
                                                 
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="panel-heading font-bold" style="text-align: center;">
                                        Set Applicable Rates At Industrial Area Level                         
                                    </div>
                                      <div runat="server" id="Div_Telescopic" visible="false">
                                         <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Min Range :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtMinRange" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                         <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Max Range :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtMaxRange" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" /></div>
                                <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Rate of Plot :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtRateOfPlot" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Interest Rate (In %) :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtInterestRate" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                EMD Rates (In %):
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtEMDRates" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Reservation Money (In %):
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtRegistrationMoneyRate" runat="server" CssClass="input-sm similar-select1" ToolTip="only In Percentage" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />

                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Rebate For Non Defaulter (In %) :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtRebate" runat="server" CssClass="similar-select1 input-sm" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group hide">
                                        <div class="row hidden">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Location Charge (In %):
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtLocationCharge" Text="0"  runat="server" CssClass="input-sm similar-select1 " ToolTip="only Numeric Value"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />



                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                No of Installments
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtNoOfInstallments" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>




                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                EfFective From Date:
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtEffectiveFromDate" runat="server" placeholder="dd/mm/yyyy" CssClass="date input-sm similar-select1" ToolTip="Enter Date In dd/mm/yyyy Format"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                EfFective To Date:
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtEffectiveToDate" runat="server" CssClass="date input-sm similar-select1" placeholder="dd/mm/yyyy" ToolTip="Enter Date In dd/mm/yyyy Format"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="panel-heading font-bold" style="text-align: center;">
                                        Other Information                         
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                Depreciation Rate (In %):
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtDepreciationRate" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group hide">
                                        <div class="row hidden">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Circle Rate:
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtCircleRate" Text="0" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group" style="display: none;">
                                        <div class="col-md-12 col-sm-12" style="text-align: right; padding: 10px 0;">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" OnClick="btnSubmit_Click" />
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <asp:Label ID="msg" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>







                <div class="row">
                    <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-6 font-bold" style="margin-top: 12px;">
                                    Existing Rate Record
                                </div>
                                <div class="input-group col-md-4 col-sm-12" style="float: right; padding: 2px;display:none;">
                                    <asp:TextBox ID="txtSearch" Width="100%" CssClass="input-sm" runat="server" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" />
                                    <span class="input-group-btn">
                                        <button class="btn btn-sm btn-primary" type="button"><i class="fa fa-search" style="color: #fff;"></i></button>
                                    </span>
                                </div>
                                <div class="clearfix"></div>

                            </div>
                            <div class="panel-body gallery  table-responsive">
                                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="IARateGrid" runat="server" AutoGenerateColumns="false"  CssClass="table table-striped table-bordered table-hover request-table" OnRowCommand="IARateGrid_RowCommand"
                                    OnPageIndexChanging="IARateGrid_PageIndexChanging" ClientIDMode="Static">
                                    <Columns>


                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:BoundField DataField="IAName" HeaderText="Industrial Area" SortExpression="IAName" />
                                        <asp:BoundField DataField="RateofPlot" HeaderText="Rate of Plot" SortExpression="RateofPlot" />
                                        <asp:BoundField DataField="InterestRate" HeaderText="Interest Rate" SortExpression="InterestRate" />
                                        <asp:BoundField DataField="Rebate" HeaderText="Rebate" SortExpression="Rebate" />
                                        <asp:BoundField DataField="NoofInstallments" HeaderText="No of Installments" SortExpression="NoofInstallments" />
                                        <asp:BoundField DataField="EMDRate" HeaderText="EMD Rate" SortExpression="EMDRate" />
                                        <asp:BoundField DataField="RegistrationMoneyRate" HeaderText="Reservation Money Rate" SortExpression="RegistrationMoneyRate" />
                                        <asp:BoundField DataField="DepricationRate" HeaderText="Deprication Rate" SortExpression="DepricationRate" />
                                        <%--<asp:BoundField DataField="LocationChage" HeaderText="Location Charge" SortExpression="LocationChage"  />--%>
                                        <%--<asp:BoundField DataField="CircleRate" HeaderText="Circle Rate" SortExpression="CircleRate" />--%>
                                        <asp:BoundField DataField="EffectiveFrom" HeaderText="Effective From Date" SortExpression="EffectiveFromDate" />
                                        <asp:BoundField DataField="EffectiveTo" HeaderText="Effective To Date" SortExpression="EffectiveToDate" />



                                        <asp:TemplateField HeaderText="Update">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>


                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Process" CommandArgument='<%#Eval("RateID")+"/"+ Eval("IAId")+"/"+ Eval("RegionalOffice") %>' ToolTip="Click here For Update Rate " />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Delete">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="DeleteRate" CommandArgument='<%#Eval("RateID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" ToolTip="Click here to delete Rate" />
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
  <%--      </ContentTemplate>
    </asp:UpdatePanel>--%>





</asp:Content>
