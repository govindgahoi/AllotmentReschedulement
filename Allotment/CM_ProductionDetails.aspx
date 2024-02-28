<%@ Page Title="" Language="C#" MasterPageFile="~/CM_MainUser.Master" AutoEventWireup="true" CodeBehind="CM_ProductionDetails.aspx.cs" Inherits="Allotment.ProductionStartDetails" %>

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
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode = 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {

                var txt = document.getElementById("<%= txtContactNumber.ClientID %>");
                if (txt.value.length > 0) {
                    txt.style.borderColor = "";
                    return true;
                }
            }
        }
        function validatephone(obj) {
            var txt = obj.value;

            if (txt.length > 0) {
                if (txt.length < 10) {
                    ShowMsgBox('Error', 'Invalid Phone No');
                    return true;
                }
                else {
                    return false;
                }

            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <%--    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">
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
                                <i class="fa fa-tachometer" aria-hidden="true"></i>
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
                            <a runat="server" onserverclick="save_ServerClick">
                                <i class="fa fa-floppy-o " aria-hidden="true"></i>
                                <br />
                                Save
                            </a>
                        </li>
                        <li>
                            <a runat="server" onserverclick="reset_ServerClick">
                                <i class="fa fa-refresh" aria-hidden="true"></i>
                                <br />
                                Refresh
                            </a>
                        </li>
                        <li runat="server" id="Li1">
                            <a runat="server" onclick="PrintElem()">
                                <i class="fa fa-print" aria-hidden="true"></i>
                                <br />
                                Print
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
                            <a href="#" class="disable">
                                <i class="fa fa-angle-double-left" aria-hidden="true"></i>
                                <br />
                                Previous
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
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
            <div class="clearfix"></div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="RateIdlbl" runat="server" Visible="false"></asp:Label>
                <div class="panel panel-default">
                    <div class="panel-heading font-bold">
                        Details of Plots where Production Not Started                       
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="row">
                                <label class="col-md-3 col-sm-12 text-right">
                                    <span style="color: Red">*</span>
                                    Corporation/Authority :
                                </label>
                                <div class="col-md-9 col-sm-12">
                                    <asp:DropDownList ID="ddlAuthority" runat="server" OnSelectedIndexChanged="ddlAuthority_SelectedIndexChanged" AutoPostBack="true" CssClass="input-sm dropdown-toggle similar-select1"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <div class="row">
                                <label class="col-md-3 col-sm-12 text-right">
                                    <span style="color: Red">*</span>
                                    Regional Office/Industrial Sectors :
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
                                    Name of Industrial Area/Blocks :
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
                                <label class="col-md-3 text-right">
                                    Plots No:
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtPlotNo" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <div class="row">
                                <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                    <span style="color: Red">*</span>
                                    Allotment Date :
                                </label>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtAllotmenttLetterApplicationDate" runat="server" CssClass="date input-sm similar-select1" placeholder="dd/mm/yyyy"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />

                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <div class="row">
                                <label class="col-md-3 text-right">
                                    <span style="color: Red">*</span>
                                    Area of Plot:
                                </label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtPlotSize" onkeypress="return isDecimalKey(event);" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlSqrmtr" runat="server" CssClass="input-sm dropdown-toggle similar-select1">
                                        <asp:ListItem Text="In Sq.Mtr" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <div class="row">
                                <label class="col-md-3 text-right">
                                    Name of Unit :
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtNameofUnit" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <div class="row">
                                <label class="col-md-3 text-right">
                                    Owner Name :
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtOwnerName" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <div class="row">
                                <label class="col-md-3 text-right">
                                    Contact Number :
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtContactNumber" runat="server" onkeypress="return isNumberKey(event);" onblur="return validatephone(this)" CssClass="input-sm similar-select1"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <div class="row">
                                <label class="col-md-3 text-right">
                                    Address :
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <div class="row">
                                <label class="col-md-3 text-right">
                                    Action Taken :
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="display: none;">
                            <p class="text-right">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-primary" Text="Save" OnClick="btnSubmit_Click" />
                                &nbsp;&nbsp;<asp:Button ID="btnReset" runat="server" CssClass="btn btn-sm btn-primary" Text="Reset" OnClick="btnReset_Click" />
                            </p>
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="clearfix"></div>
                    <div class="panel-heading">
                        <div class="col-md-6 col-sm-12" style="margin-top: 5px;">
                            <label class="col-md-6">
                                Total Plots Where Production Not Started :
                            </label>
                            <asp:Label ID="lblTotal" runat="server" class="col-md-5 "></asp:Label>
                        </div>
                        <div class="col-md-4 col-sm-12" style="margin-top: 5px;">
                            <label>
                                Total  Area :
                            </label>
                            <asp:Label ID="lblArea" runat="server"></asp:Label>
                            (In Acres)
                            
                                (<code>*CF: 1 Acre = 4046.86 Sqmts.</code>)
                        </div>


                        <div class="input-group col-md-2 col-sm-12" style="float: right; padding: 2px 0;">
                            <asp:TextBox ID="txtSearch" Width="100%" CssClass="input-sm" runat="server" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged" />
                            <span class="input-group-btn">
                                <button id="btnSearch" class="btn btn-sm btn-primary" type="button"><i class="fa fa-search" style="color: #fff;"></i></button>
                            </span>
                        </div>
                        <div class="clearfix"></div>

                    </div>
                    <div id="Divv">
                        <div class="panel-body gallery  table-responsive">
                            <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowFooter="true" ShowHeaderWhenEmpty="true"
                                AllowPaging="true" AllowSorting="True" PageSize="20" CssClass="table table-striped table-bordered table-hover request-table"
                                OnRowCommand="GridView1_RowCommand"
                                OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting"
                                PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CName" HeaderStyle-HorizontalAlign="Center" HeaderText=" Corporation/Authority" />
                                   
                                    <asp:BoundField DataField="RegionalOffice" HeaderStyle-HorizontalAlign="Left" HeaderText="Regional Office/Industrial Sectors" ItemStyle-Width="10%" />  
                                    <asp:BoundField DataField="IAName" HeaderStyle-HorizontalAlign="Left" HeaderText="Name of Industrial Area/Blocks" ItemStyle-Width="10%" /> 
                                    
                                    <asp:BoundField DataField="PlotNumber" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%" HeaderText="Plot Number" />
                                    <asp:BoundField DataField="AllotmentIssueDate1" HeaderStyle-HorizontalAlign="Center" HeaderText="AllotmentDate" />
                                    <asp:BoundField DataField="TotalArea" HeaderStyle-HorizontalAlign="Center" HeaderText="Area of Plot (In Sq.Mtr)" ItemStyle-Width="12%" />
                                    <asp:BoundField DataField="NameofUnit" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="14%" HeaderText="Name of Unit" />
                                    <asp:BoundField DataField="NameofOwner" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="14%" HeaderText=" Owner Name" />
                                    <asp:BoundField DataField="ContactNumber" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="14%" HeaderText="Contact Number" />
                                    <asp:BoundField DataField="Address" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="14%" HeaderText="Address" />
                                    <asp:BoundField DataField="Remarks" HeaderStyle-HorizontalAlign="Left" HeaderText="Action Taken" />
                                    <asp:TemplateField HeaderText="Update">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Process" CommandArgument='<%#Eval("ProductionID")+"/"+ Eval("IAID")+"/"+ Eval("RegionalOffice")  %>' ToolTip="Click here For Vacant Plots " />
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="DeleteVacant" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" CommandArgument='<%#Eval("ProductionID") %>' ToolTip="Click here to delete Rate" />
                                            </span>  
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function PrintElem() {

                Popup($('#Divv').html());
            }


            function Popup(data) {
                var mywindow = window.open('', 'my div', 'height=2000,width=2000');
                mywindow.document.write('<html><head><title style="font-weight:bold;">PRODUCTION STOPPED DETAIL</title>');
                mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/bootstrap.min.css\" type=\"text/css\" />');
                mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/theme.css\" type=\"text/css\"  />');
                mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/print.css\" type=\"text/css\"  />');
                mywindow.document.write('</head><body >');
                mywindow.document.write(data);
                mywindow.document.write('</body></html>');

                setTimeout(function () {
                    mywindow.print();
                    mywindow.close();
                }, 1000);


                return true;
            }
        </script>
        <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
