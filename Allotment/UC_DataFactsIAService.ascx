<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_DataFactsIAService.ascx.cs" Inherits="Allotment.UC_DataFactsIAService" %>
<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<style>
    .modal-backdrop.fade {
    display:none !important;
    }
    .assess-min-height {
        min-height:628px !important;
    }
    .PreviewClass {
        color: red;
    }

    .input-sm {
        height: 20px !important;
    }

    .request-table tr th[colspan='4'] {
        padding: 0 !important;
    }
</style>
 <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();

            $(".MultiSelect").chosen(
               


            );
     }

    
      function openModal() {
               $('#PlotModal').modal('show');
           }

   

    </script>
<cc1:MessageBox ID="MessageBox1" runat="server" />


<div runat="server" id="BuildingDiv" visible="false">


    
    <div class="col-md-4 col-sm-4 col-xs-6 check-left">
        <div class="div-checklist assess-min-height" style="border: 1px solid #ccc;max-height: 439px;overflow-y: auto;min-height: 628px;">
 
            <div class="panel-heading font-bold">Facts
                <asp:Button runat="server" Text="Lock Data" ID="LockBPData" CssClass="btn btn-sm btn-primary" OnClick="LockBPData_Click"  Style="float: right;padding: 0px 8px !important;background: #ffc511;color: #000;" /></div>
            <div class="panel panel-default">
                <div class="panel-body gallery">
                   
                           
                                   <div class="panel-heading">List Of Additional Clauses</div>
                               <div class="Annexure">
                                  
                                       <asp:GridView ID="BPClauseGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="BPClauseGrid_RowDeleting">
																	                            <Columns>


																		                            <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			                            </ItemTemplate>
																		                            </asp:TemplateField>


																		                            <asp:TemplateField HeaderText="List of Additional Clauses" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblClause" runat="server" Text='<%#Eval("Annexures") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtReasonRej" TextMode="MultiLine" Style="min-height:80px;"  CssClass="input-sm similar-select1 margin-left-z" runat="server"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																		                            

																		                            <asp:TemplateField FooterStyle-CssClass="hide_me" ItemStyle-CssClass="hide_me" HeaderStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />

																			                            </ItemTemplate>
																			                            <FooterStyle HorizontalAlign="Right" />
																			                            <FooterTemplate>
																				                               <asp:Button runat="server" ID="btnSaveBpClause" OnClick="btnSaveBpClause_Click" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />

																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>
                                    

                                </div>
                       
                    

                     <asp:HiddenField runat="server" ID="HiddenField1" />
                            <asp:HiddenField runat="server" ID="HiddenField2" />
                            <asp:HiddenField runat="server" ID="HiddenField3" />
            

                </div>
            </div>
        </div>
    </div>


    <div class="col-md-8 col-sm-8 col-xs-6 check-right">
        <div class="div-assesment-applicant assess-min-height" style="">
            <div class="div-view div-scroll" style="max-height: 628px; overflow-y: auto; border: 1px solid #ccc; background: #fff;">

                <%-- Preview Version  --%>
                <asp:Literal runat="server" ID="Literal2"></asp:Literal>

            </div>
        </div>
    </div>

</div>

<div class="row" runat="server" id="TEFDiv" visible="false">

    <div class="col-md-4 col-sm-4 col-xs-6 check-left">
        <div class="div-checklist assess-min-height" style="border: 1px solid #ccc; max-height: 439px; overflow-y: auto; min-height: 628px;">
            <div class="panel-heading font-bold">
                Facts
                <asp:Button runat="server" Text="Save" ID="Button6" CssClass="btn btn-sm btn-primary" OnClick="LockTimeextensionfeeData_Click" Style="float: right; padding: 0px 8px !important; background: #ffc511; color: #000;" />
            </div>
            <div>
            </div>
            <br />
            <%-- Priyanshu Design And Seeting data  --%>
            <div class="panel panel-default">
                <div class="panel-body gallery">
                    <div class="">
                        <div class="col-md-12" style="padding: 0px !important;">
                            <asp:Label runat="server" ID="Label2" Visible="false"></asp:Label>
                            <table class="table table-striped table-responsive table-bordered table-hover request-table">
                                <tr>
                                    <th colspan="4">
                                        <div class="panel-heading font-bold">Clause</div>
                                    </th>
                                </tr>

                                <tr>
                                    <td>Time Extension Date</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txttefDate" CssClass="date input-sm" Width="80%" Text='<%#Eval("tefDate") %>'></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I5" visible="false"></i><i class="fa fa-check" runat="server" id="I6" visible="false"></i></td>
                                </tr>

                            </table>
                            <div class="Annexre_Table">
                                <asp:GridView ID="AnnexreGridtef" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="AnnexretefDelete_Click">
                                    <Columns>


                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" FooterStyle-CssClass="hide_me">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="List Of Additional Clauses" FooterStyle-CssClass="hide_me">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClause" runat="server" Text='<%#Eval("Annexures") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtReasonRej" TextMode="MultiLine" Style="min-height: 80px;" CssClass="input-sm similar-select1 margin-left-z" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>




                                        <asp:TemplateField FooterStyle-CssClass="hide_me" ItemStyle-CssClass="hide_me" HeaderStyle-CssClass="hide_me">
                                            <ItemTemplate>
                                                <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                    ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />

                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Right" />
                                            <FooterTemplate>
                                                <asp:Button runat="server" ID="BtnSave" OnClick="insert_tefannexre_details" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />

                                            </FooterTemplate>
                                        </asp:TemplateField>


                                    </Columns>
                                </asp:GridView>
                            </div>


                            <asp:HiddenField runat="server" ID="HiddenField16" />
                            <asp:HiddenField runat="server" ID="HiddenField17" />
                            <asp:HiddenField runat="server" ID="HiddenField18" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-8 col-sm-8 col-xs-6 check-right">
        <div class="div-assesment-applicant assess-min-height" style="">
            <div class="div-view div-scroll" style="max-height: 628px; overflow-y: auto; border: 1px solid #ccc; background: #fff;">

                <%-- Preview Version  --%>
                <asp:Literal runat="server" ID="Literaltimeextension"></asp:Literal>

            </div>
        </div>
    </div>
    Note: Please Update  OutStanding Dues on Allottee Ladger"
</div>

<div class="row" runat="server" id="CancelDiv" visible="false">
    <div class="col-md-4 col-sm-4 col-xs-6 check-left">
        <div class="div-checklist assess-min-height" style="border: 1px solid #ccc;">
            <div class="panel-heading font-bold">
                Facts
                <asp:Button runat="server" Text="Lock Data" ID="btnLockPlotCancel" CssClass="btn btn-sm btn-primary" OnClick="btnLockPlotCancel_Click" Style="float: right; padding: 0px 8px !important; background: #ffc511; color: #000;" />
            </div>

            <%-- Priyanshu Design And Seeting data  --%>
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12" style="padding: 0px !important;">

                            <div class="panel-heading">List of Notices</div>
                            <div class="Notices_table">

                                <div class="table-responsive">
                                    <asp:GridView ID="gridNotices" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowHeaderWhenEmpty="true" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center" FooterStyle-CssClass="hide_me">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ServiceRequestNumber" FooterStyle-CssClass="hide_me">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblServiceRequestno" runat="server" Text='<%#Eval("ServiceRequestNo") %>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Notice Ref No" FooterStyle-CssClass="hide_me">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNoticeRefNo" runat="server" Text='<%#Eval("NoticeID") %>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Notice Date" FooterStyle-CssClass="hide_me">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNoticeDate" runat="server" Text='<%#Eval("CreationDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Notice Details" FooterStyle-CssClass="hide_me">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNoticeDate" runat="server" Text='<%#Eval("AppointmentDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="panel-heading">List of Clauses</div>

                            <div class="Clause_table">
                                <div class="table-responsive">
                                    <asp:GridView ID="ClauseGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="ClauseDelete_Click">
                                        <Columns>


                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center" FooterStyle-CssClass="hide_me">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Clause" FooterStyle-CssClass="hide_me">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClause" runat="server" Text='<%#Eval("Annexures") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtClause_insert1" TextMode="MultiLine" Style="min-height: 60px;" CssClass="input-sm similar-select1 margin-left-z" runat="server"></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField FooterStyle-CssClass="hide_me" ItemStyle-CssClass="hide_me" HeaderStyle-CssClass="hide_me">
                                                <ItemTemplate>
                                                    <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                        ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />

                                                </ItemTemplate>
                                                <FooterStyle HorizontalAlign="Right" />
                                                <FooterTemplate>
                                                    <asp:Button runat="server" ID="BtnSave" OnClick="insert_clause_details" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />

                                                </FooterTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>
                                </div>

                            </div>


                        </div>
                    </div>




                </div>
            </div>
        </div>
    </div>


    <div class="col-md-8 col-sm-8 col-xs-6 check-right">
        <div class="div-assesment-applicant assess-min-height" style="">
            <div class="div-view div-scroll" style="max-height: 628px; overflow-y: auto; border: 1px solid #ccc; background: #fff;">

                <%-- Preview Version  --%>
                <asp:Literal runat="server" ID="Literal3"></asp:Literal>

            </div>
        </div>
    </div>
</div>


<div class="row" runat="server" id="SublettingDiv" visible="false">
    <div class="col-md-4 col-sm-4 col-xs-6 check-left">
        <div class="div-checklist assess-min-height" style="border: 1px solid #ccc; max-height: 439px; overflow-y: auto; min-height: 628px;">
            <div class="panel-heading font-bold">
                Facts
                <asp:Button runat="server" Text="Save" ID="LockSubletingData" CssClass="btn btn-sm btn-primary" OnClick="LockSubletingData_Click" Style="float: right; padding: 0px 8px !important; background: #ffc511; color: #000;" />
            </div>
            <%-- Priyanshu Design And Seeting data  --%>
            <div class="panel panel-default">
                <div class="panel-body gallery">
                    <div class="">
                        <div class="col-md-12" style="padding: 0px !important;">
                            <table class="table table-striped table-responsive table-bordered table-hover request-table">
                                <%--<tr>
                                    <th>Parameters</th>
                                    <th>System Data</th>
                                    <th style="display: none;">Verification</th>
                                    <th>Verified Value <span>
                                        <asp:Button runat="server" Text="Edit" OnClick="Button1_Click" ID="Button1" CssClass="btn btn-sm btn-primary" Style="float: right; padding: 0px 8px !important; background: #ffc511; color: #000;" /></span></th>
                                </tr>--%>
                                <tr>
                                    <td>Subletting Year </td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlSublettingYear" Width="100%" Style="padding: 0px 0px !important;">
                                            <asp:ListItem Value="1"> 1 Year</asp:ListItem>
                                            <asp:ListItem Value="2"> 2 Year</asp:ListItem>
                                            <asp:ListItem Value="3"> 3 Year</asp:ListItem>
                                            <asp:ListItem Value="4"> 4 Year</asp:ListItem>
                                            <asp:ListItem Value="5"> 5 Year</asp:ListItem>
                                            <asp:ListItem Value="6"> 6 Year</asp:ListItem>
                                            <asp:ListItem Value="7"> 7 Year</asp:ListItem>
                                            <asp:ListItem Value="8"> 8 Year</asp:ListItem>
                                            <asp:ListItem Value="9"> 9 Year</asp:ListItem>
                                            <asp:ListItem Value="10"> 10 Year</asp:ListItem>
                                            <asp:ListItem Value="11"> 11 Year</asp:ListItem>
                                            <asp:ListItem Value="12"> 12 Year</asp:ListItem>
                                            <asp:ListItem Value="13"> 13 Year</asp:ListItem>
                                            <asp:ListItem Value="14"> 14 Year</asp:ListItem>
                                            <asp:ListItem Value="15"> 15 Year</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>subletting charge/rent</td>
                                    <td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtSublettingcharge" CssClass="FirstInstallment input-sm" Width="80%" onkeypress="return isDecimalKey(event);"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I1" visible="false"></i><i class="fa fa-check" runat="server" id="I2" visible="false"></i>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td>present rates</td>
                                    <td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtpresentrates"  CssClass="FirstInstallment input-sm" Width="80%"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I7" visible="false"></i><i class="fa fa-check" runat="server" id="I8" visible="false"></i>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Sub-Letting Charges</td>
                                    <td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtSubLettingCharges"  CssClass="FirstInstallment input-sm" Width="80%"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I9" visible="false"></i><i class="fa fa-check" runat="server" id="I10" visible="false"></i>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>lease deed Date</td>
                                    <td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtleasedeeddate" CssClass="date" Width="80%"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I11" visible="false"></i><i class="fa fa-check" runat="server" id="I12" visible="false"></i>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td>outstanding  Dues</td>
                                    <td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtoutstandingDues"  CssClass="FirstInstallment input-sm" Width="80%"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I13" visible="false"></i><i class="fa fa-check" runat="server" id="I14" visible="false"></i>
                                    </td>
                                </tr>--%>
                            </table>
                            <div class="panel panel-default">
                                <div class="panel-body gallery">

                                    <div class="panel-heading">List Of Additional Clauses</div>
                                    <div class="Annexure">
                                        <asp:GridView ID="SubletingClauseGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="sublettingClauseGrid_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" FooterStyle-CssClass="hide_me">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="List of Additional Clauses" FooterStyle-CssClass="hide_me">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClause" runat="server" Text='<%#Eval("Annexures") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtReasonRej" TextMode="MultiLine" Style="min-height: 80px;" CssClass="input-sm similar-select1 margin-left-z" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField FooterStyle-CssClass="hide_me" ItemStyle-CssClass="hide_me" HeaderStyle-CssClass="hide_me">
                                                    <ItemTemplate>
                                                        <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <FooterTemplate>
                                                        <asp:Button runat="server" ID="btnSaveSubletingClause" OnClick="btnSavesublettingClause_Click" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <asp:HiddenField runat="server" ID="HiddenField4" />
                                    <asp:HiddenField runat="server" ID="HiddenField5" />
                                    <asp:HiddenField runat="server" ID="HiddenField6" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="col-md-8 col-sm-8 col-xs-6 check-right">
        <div class="div-assesment-applicant assess-min-height" style="">
            <div class="div-view div-scroll" style="max-height: 628px; overflow-y: auto; border: 1px solid #ccc; background: #fff;">

                <%-- Preview Version  --%>
                <asp:Literal runat="server" ID="ltsubleting"></asp:Literal>

            </div>
        </div>
    </div>
</div>

<div class="row" runat="server" id="RestorationDiv" visible="false">
    <div class="col-md-4 col-sm-4 col-xs-6 check-left">
        <div class="div-checklist assess-min-height" style="border: 1px solid #ccc; max-height: 439px; overflow-y: auto; min-height: 628px;">
            <div class="panel-heading font-bold">
                Facts
                <asp:Button runat="server" Text="Save" ID="btnRestoration" CssClass="btn btn-sm btn-primary" OnClick="LockRestorationData_Click" Style="float: right; padding: 0px 8px !important; background: #ffc511; color: #000;" />
            </div>
            <%-- Priyanshu Design And Seeting data  --%>
            <div class="panel panel-default">
                <div class="panel-body gallery">
                    <div class="">
                        <div class="col-md-12" style="padding: 0px !important;">
                            <table class="table table-striped table-responsive table-bordered table-hover request-table">
                                <tr>
                                    <td>Restorationlevy percentage</td>
                                    <td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtRestorationlevypercentage" CssClass="FirstInstallment input-sm" Width="80%" onkeypress="return isDecimalKey(event);"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I3" visible="false"></i><i class="fa fa-check" runat="server" id="I4" visible="false"></i>
                                    </td>
                                </tr>
                                <tr>
                                    <td>construction of factory building Date</td>
                                    <td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtbuildingDate" CssClass="date" Width="80%"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I7" visible="false"></i><i class="fa fa-check" runat="server" id="I8" visible="false"></i>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Production  Date</td>
                                    <td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtProductionDate" CssClass="date" Width="80%"></asp:TextBox>&nbsp;<i class="fa fa-times" runat="server" id="I9" visible="false"></i><i class="fa fa-check" runat="server" id="I10" visible="false"></i>
                                    </td>
                                </tr>
                            </table>
                            <div class="panel panel-default">
                                <div class="panel-body gallery">

                                    <div class="panel-heading">List Of Additional Clauses</div>
                                    <div class="Annexure">
                                        <asp:GridView ID="RestorationClauseGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="RestorationClauseGrid_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" FooterStyle-CssClass="hide_me">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="List of Additional Clauses" FooterStyle-CssClass="hide_me">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClause" runat="server" Text='<%#Eval("Annexures") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtReasonRej" TextMode="MultiLine" Style="min-height: 80px;" CssClass="input-sm similar-select1 margin-left-z" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField FooterStyle-CssClass="hide_me" ItemStyle-CssClass="hide_me" HeaderStyle-CssClass="hide_me">
                                                    <ItemTemplate>
                                                        <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <FooterTemplate>
                                                        <asp:Button runat="server" ID="btnSaveRestorationClause" OnClick="btnSaveRestorationClause_Click" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <asp:HiddenField runat="server" ID="HiddenField7" />
                                    <asp:HiddenField runat="server" ID="HiddenField8" />
                                    <asp:HiddenField runat="server" ID="HiddenField9" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="col-md-8 col-sm-8 col-xs-6 check-right">
        <div class="div-assesment-applicant assess-min-height" style="">
            <div class="div-view div-scroll" style="max-height: 628px; overflow-y: auto; border: 1px solid #ccc; background: #fff;">

                <%-- Preview Version  --%>
                <asp:Literal runat="server" ID="ltRestoration"></asp:Literal>

            </div>
        </div>
    </div>
</div>

<asp:Label runat="server" ID="lblServiceReqNo" Visible="false"></asp:Label>
<script>


    function AnyChangeCallMe() {

       
            $(".lblPlotNo").html($(".PlotNo").val());
            $(".ListofClause").html($(".Clause_table").html());
            $(".ListofNotices").html($(".Notices_table").html());
            $(".ListofAnnexres").html($(".Annexre_Table").html());
            $(".BP").html($(".Annexure").html());
     ceg



    $(document).ready(function () {   
        AnyChangeCallMe();
        
    $("select input").change(function () {
        AnyChangeCallMe();
    });

    $("input[type='text']").keyup(function () {
        AnyChangeCallMe();
    });

    function ShowLumpSum() {

        $(".levy_lumpsum").show();
        $(".levy_installment").hide();
    }
    function ShowInstallment() {

        $(".levy_lumpsum").hide();
        $(".levy_installment").show();
    }   
    });

    //Re-bind for callbacks
    var prm = Sys.WebForms.PageRequestManager.getInstance(); 

    prm.add_endRequest(function () { 

        AnyChangeCallMe();
        
       
    $("select input").change(function () {

        AnyChangeCallMe();
    });

    $("input[type='text']").keyup(function () {

        AnyChangeCallMe();
    });

    function ShowLumpSum() {

        $(".levy_lumpsum").show();
        $(".levy_installment").hide();
    }
    function ShowInstallment() {

        $(".levy_lumpsum").hide();
        $(".levy_installment").show();
    }
    }); 

    $(document).ready(function () {
        $("input#LumpSumRad").click(function () {
            //var test = $(this).val();

            $(".levy_lumpsum").show();
            $(".levy_installment").hide();
        });
        $("input#InstallmentRad").click(function () {
            //var test = $(this).val();

            $(".levy_lumpsum").hide();
            $(".levy_installment").show();
        });
    });

   

</script>



