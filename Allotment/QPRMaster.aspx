<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="QPRMaster.aspx.cs" Inherits="Allotment.QPRMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%--<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <%--<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <%--<link rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" />--%>
    <link href="js/datatables.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.2.2/css/buttons.dataTables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>
    <%--   <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.6.0/js/buttons.print.min.js"></script>--%>
    <script type="text/javascript">
        function ShowMessage() {
            alert('your message');
            window.location.href = 'QPRMaster.aspx';
        }
        $(document).ready(function () {

            $('[id*=gridQPR]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({

                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 2,
                buttons: [
                    { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'QPR_Excel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'QPR_Csv', exportOptions: { modifier: { page: 'all' } } },
                    //{ extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'QPR_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                ]

            });

        });

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
    <style>

  



        body {
            font-family: Segoe UI, Helvetica, Calibri;
            font-size: 8px;
            line-height: 1.42857143;
            color: #333;
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

        .div-view.div-scroll {
            overflow-y: scroll;
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
    </style>

    <style>
        .btnMargin {
            margin-bottom: 10px !important;
        }
    </style>
    <script>

        function txtTotalArea_keypress(evt) {

            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {
                var txt = document.getElementById("<%= txtBoxTotalLandAcquired.ClientID %>");
                if (txt.value.length > 0) {
                    txt.style.borderColor = "";
                }
            }
        }
       <%-- function ValidateRequired(obj, txt) {
            var txtObj = document.getElementById(obj.id);
            if (txtObj.value.length > 0) {
                txtObj.style.borderColor = "";
                hideError();
                return true;
            }
            else {
                txtObj.style.borderColor = "Red";
                txtObj.focus();
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = txt + " " + "Is required Field";

                return false;
            }

        }--%>

        function ValidateFill(obj, txt) {
            var txtObj = document.getElementById(obj.id);
            if (txtObj.value.length > 0) {
                txtObj.style.borderColor = "";
                hideError();
                return true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>


    <%--<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">--%>


       <%-- <ContentTemplate>
            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                <ProgressTemplate>
                    <div class="fgh">
                        <div class="hgf">
                            <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
            <%--<cc1:MessageBox ID="MessageBox1" runat="server" />--%>
            <%--<div class="row topbtncollapse" id="topbtncollapse">
                <div class="col-md-12" style="background: #dbdbdb;">
                    <div>
                        
                    </div>
                </div>

                <div class="clearfix"></div>
            </div>--%>
            <%--<div id="divMessageError" class="MessagePennel" runat="server" style="display: none;">
                <label>
                    <span class="check-cross" runat="server">✖</span>

                    <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
                </label>
            </div>--%>
       <%--<cc1:MessageBox ID="MessageBox1" runat="server" />--%>
            <div class="clearfix"></div>
  
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="panel panel-default">

                        <div class="row">
                            <div style="margin: 3px 4px; border: 1px solid #ccc;">
                                <div style="border: 3px solid #ccc;">
                                    <div class="panel-heading font-bold">
                                        <div class="col-md-8 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                            QPR Information
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">

                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Regional Office :
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <asp:DropDownList ID="ddlregion" runat="server" OnSelectedIndexChanged="ddlregion_SelectedIndexChanged" AutoPostBack="true" CssClass="chosen input-sm similar-select1">
                                                </asp:DropDownList>
                                            </div>
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Industrial Area :
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <asp:DropDownList ID="ddlIA" runat="server" CssClass="chosen input-sm similar-select1">
                                                </asp:DropDownList>
                                            </div>
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Land Type :
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <asp:DropDownList ID="ddlLandtype" runat="server" CssClass="chosen input-sm similar-select1">
                                                    <asp:ListItem Selected="True" Text="--Select--" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Industrial" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Commercial" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Residential" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Institutional" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="Bulk Land" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="Other" Value="6"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">

                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Quarter End Date:
                                            </label>

                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <asp:DropDownList ID="ddlQuarterEndDate" runat="server" CssClass="chosen input-sm similar-select1">
                                                    <asp:ListItem Selected="True" Text="--Select--" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="April-June " Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="July-September" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="October-December" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="December-January" Value="4"></asp:ListItem>
                                                </asp:DropDownList>

                                            </div>

                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Year:
                                            </label>

                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <asp:DropDownList ID="ddlyear" runat="server" CssClass="chosen input-sm similar-select1">
                                                    <asp:ListItem Selected="True" Text="--Select--" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text=" 2019" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="2020" Value="2"></asp:ListItem>

                                                </asp:DropDownList>

                                            </div>
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Category:
                                            </label>

                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="chosen input-sm similar-select1">
                                                    <asp:ListItem Selected="True" Text="--Select--" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Fast" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Very Fast" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Slow" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Bulk Land" Value="4"></asp:ListItem>
                                                </asp:DropDownList>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">

                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Total Land Acquired :
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <asp:TextBox ID="txtBoxTotalLandAcquired" runat="server" onblur="validatepan(this,'Total Land Acquired');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                            <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                Rate (Rs.Per sq.mtr.):
                                            </label>
                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                <asp:TextBox ID="txtIARatePerSqmt" runat="server" onblur="validatepan(this,'Total Land Acquired');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4 col-sm-6 col-xs-6">
                                            </div>

                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />

                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                            </div>
                                            <label class="col-md-3 col-sm-6 col-xs-6 text-center">
                                                <b>Plots :</b>
                                            </label>

                                            <label class="col-md-3 col-sm-6 col-xs-6 text-center">
                                                <b>No. of Units: </b>
                                            </label>

                                            <label class="col-md-3 col-sm-6 col-xs-6 text-center">
                                                <b>Area (in acres):</b>
                                            </label>


                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />

                                    <div class="form-group">
                                        <div class="row">

                                            <div class="col-md-3 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                                Alloted Land(including undeveloped land						
                                            </div>

                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                <asp:TextBox ID="txtAllotedLandPlots" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                <asp:TextBox ID="txtAllotedLandUnits" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                <asp:TextBox ID="txtAllotedLandArea" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />

                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                                Total Land for Allotment(Including Un-Developed Land)
                                            </div>

                                            <div class="col-md-3 col-sm-4 col-xs-4">
                                                <asp:TextBox ID="txtTotalLandforAllotmentplots" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3 col-sm-4 col-xs-4">
                                            </div>

                                            <div class="col-md-3 col-sm-4 col-xs-4">
                                                <asp:TextBox ID="txtTotalLandforAllotmentArea" runat="server" ToolTip="only Numeric Value" onblur="validatepan(this,'Total Land For Allotment');" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />

                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                                Land not available for allotment due to litigation etc.			
                                            </div>

                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                <asp:TextBox ID="txtLandNotAvlDueToLitigationPlots" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                            </div>

                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                <asp:TextBox ID="txtLandNotAvlDueToLitigationArea" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>


                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />

                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                                Balance Land available for allotment	
		
                                            </div>

                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                <asp:TextBox runat="server" ID="txtBalLandForAllotmentPlots" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                            </div>
                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                <asp:TextBox ID="txtBalLandForAllotmentArea" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />


                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                                Units Under Construction:	
                                            </div>
                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                            </div>
                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                <asp:TextBox ID="txtUnderConstructionUnits" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>

                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                <asp:TextBox runat="server" ID="txtUnderConstructionArea" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>


                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />


                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                                Units Under Production:	
                                            </div>
                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                            </div>
                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                <asp:TextBox ID="txtConstructedFunctionalUnits" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>

                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                <asp:TextBox runat="server" ID="txtConstructedFunctionalArea" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />



                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                                Units Sick/Closed :	
                                            </div>
                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                            </div>
                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                <asp:TextBox ID="txtSickClosedUnits" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>

                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                <asp:TextBox runat="server" ID="txtSickClosedArea" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                                Alloted but Vacant:	
                                            </div>
                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                            </div>
                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                <asp:TextBox ID="txtNotStartedEvenconstructionunits" runat="server" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3 col-sm-6 col-xs-6">
                                                <asp:TextBox runat="server" ID="txtNotStartedEvenconstructionArea" onblur="validatepan(this,'Total Land For Allotment');" ToolTip="only Numeric Value" onkeypress="return txtTotalArea_keypress(event);" class="input-sm similar-select1"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-5 col-sm-4 col-xs-12" style="margin-top: 6px;">
                                            </div>
                                            <div class="col-md-5 col-sm-6 col-xs-6">
                                            </div>
                                            <div class="col-md-2 col-sm-2 col-xs-6" style="margin-right: -40px;">
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" OnClick="btnSubmit_Click" />
                                            </div>


                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />

                                </div>
                            </div>

                        </div>




                        <div runat="server" visible="false">
                            <asp:TextBox ID="txtSearch" runat="server" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" />
                            <span class="input-group-btn">
                                <button class="btn btn-sm btn-primary" type="button"><i class="fa fa-search" style="color: #fff;"></i></button>
                            </span>
                        </div>
                        <div class="row">
                            

                            <div class="panel-body gallery  table-responsive">

                                <asp:GridView ID="gridQPR" runat="server" AutoGenerateColumns="false" CssClass="w3-table-all w3-hoverable"
                                     ClientIDMode="Static" PagerStyle-HorizontalAlign="Right" OnRowCommand="gridQPR_RowCommand" OnRowDeleting="gridQPR_RowDeleting"  >
                                    <Columns>

                                    
                                        
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:BoundField DataField="RegionID" HeaderText="Region" SortExpression="RegionID" />
                                        <asp:BoundField DataField="IAName" HeaderText="Industrial Area" SortExpression="IAName" />
                                        <asp:BoundField DataField="LandType" HeaderText="Land Type" SortExpression="LandType" />
                                        <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                                        <asp:BoundField DataField="QuarterEndDate" HeaderText="Quarter End Date" SortExpression="QuarterEndDate" />
                                        <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year" />
                                        <asp:BoundField DataField="TotalLandAcquired" HeaderText="Total Land Acquired (in acres)" SortExpression="TotalLandAcquired" />
                                        <asp:BoundField DataField="TotlLandForAllotIncDevPlot" HeaderText="Total Land for Allotment(including un-developed land) Plots" SortExpression="TotlLandForAllotIncDevPlot" />
                                        <asp:BoundField DataField="TotlLandForAllotIncDevArea" HeaderText="Total Land for Allotment(including un-developed land) Area" SortExpression="TotlLandForAllotIncDevArea" />
                                        <asp:BoundField DataField="AllotteedLandIncUnDevUnit" HeaderText="Alloted Land(including undeveloped land Units" SortExpression="AllotteedLandIncUnDevUnit" />
                                        <asp:BoundField DataField="AllotteedLandIncUnDevPlot" HeaderText="Alloted Land(including undeveloped land Plots" SortExpression="AllotteedLandIncUnDevPlot" />
                                        <asp:BoundField DataField="AllotteedLandIncUnDevArea" HeaderText="Alloted Land(including undeveloped land(in acres) Area" SortExpression="AllotteedLandIncUnDevArea" />
                                        <asp:BoundField DataField="Allote" HeaderText="% Allotted" SortExpression="Allote" />
                                        <asp:BoundField DataField="LandNotAvlDueToLitigationPlot" HeaderText="Land not available for allotment due to litigation etc.Plots" SortExpression="LandNotAvlDueToLitigationPlot" />
                                        <asp:BoundField DataField="LandNotAvlDueToLitigationArea" HeaderText="Land not available for allotment due to litigation etc.Area" SortExpression="LandNotAvlDueToLitigationArea" />
                                        <asp:BoundField DataField="BalLandForAllotmentPlot" HeaderText="Balance Land available for allotment Plots" SortExpression="BalLandForAllotmentPlot" />
                                        <asp:BoundField DataField="BalLandForAllotmentArea" HeaderText="Balance Land available for allotment Area" SortExpression="BalLandForAllotmentArea" />
                                        <asp:BoundField DataField="UnderConstructionUnit" HeaderText="Under Construction Plots" SortExpression="UnderConstructionUnit" />
                                        <asp:BoundField DataField="UnderConstructionArea" HeaderText="Under Construction Area" SortExpression="UnderConstructionArea" />
                                        <asp:BoundField DataField="ConstructedFunctionalUnit" HeaderText=" Under Production Plots" SortExpression="ConstructedFunctionalUnit" />
                                        <asp:BoundField DataField="ConstructedFunctionalArea" HeaderText=" Under Production Area" SortExpression="ConstructedFunctionalArea" />
                                        <asp:BoundField DataField="SickClosedUnit" HeaderText=" Sick/Closed Units " SortExpression="SickClosedUnit" />
                                        <asp:BoundField DataField="SickClosedArea" HeaderText=" Sick/Closed Area" SortExpression="SickClosedArea" />
                                        <asp:BoundField DataField="NotStartedEvenconstructionUnit" HeaderText="Not Started Even construction Units " SortExpression="NotStartedEvenconstructionUnit" />
                                        <asp:BoundField DataField="NotStartedEvenconstructionArea" HeaderText="Not Started Even construction Area " SortExpression="NotStartedEvenconstructionArea" />
                                        <asp:BoundField DataField="RatePerSqm" HeaderText="Rate (Rs. Per sq.mtr.)" SortExpression="RatePerSqm" />
                                        <asp:TemplateField HeaderText="Update">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Process" CommandArgument='<%#Eval("ID") %>' ToolTip="Click here For QPR " />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="Delete" CommandArgument='<%#Eval("ID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" ToolTip="Click here to delete Rate" />
                                                </span>  
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <HeaderStyle BackColor="#4dc3ff" />
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

    <%--    </ContentTemplate>

    </asp:UpdatePanel>--%>
</asp:Content>
