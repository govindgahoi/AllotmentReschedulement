<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="Defaulters.aspx.cs" Inherits="Allotment.Defaulters" %>

<%@ Register Src="~/UC_topbutton.ascx" TagPrefix="uc1" TagName="UC_topbutton" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $("[id*=chkHeader]").live("click", function () {
        var chkHeader = $(this);
        var grid = $(this).closest("table");
        $("input[type=checkbox]", grid).each(function () {
            if (chkHeader.is(":checked")) {
                $(this).attr("checked", "checked");
                $("td", $(this).closest("tr")).addClass("selected");
            } else {
                $(this).removeAttr("checked");
                $("td", $(this).closest("tr")).removeClass("selected");
            }
        });
    });
    $("[id*=chkRow]").live("click", function () {
        var grid = $(this).closest("table");
        var chkHeader = $("[id*=chkHeader]", grid);
        if (!$(this).is(":checked")) {
            $("td", $(this).closest("tr")).removeClass("selected");
            chkHeader.removeAttr("checked");
        } else {
            $("td", $(this).closest("tr")).addClass("selected");
            if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                chkHeader.attr("checked", "checked");
            }
        }
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>

    <uc1:UC_topbutton runat="server" ID="UC_topbutton" />
    <div class="clearfix"></div>
    <div class="row">
        <div class="table-responsive" style="margin-top: 3px;">
            <table id="tblsearch" class="table table-striped table-bordered table-hover  margin-b-2px request-table">
                <tr style="background: #ececec;">
                    <td class="font-bold">
                        <span style="color: Red">*</span>
                        Regional Office :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddloffice" runat="server" CssClass="btn btn-sm btn-default dropdown-toggle similar-select">
                        </asp:DropDownList>
                    </td>
                    <td class="font-bold">
                        <span style="color: Red">*</span>
                        Industrial Area Name :
                    </td>
                    <td>
                        <asp:DropDownList ID="drpdwnIA" runat="server" AutoPostBack="true" CssClass="btn btn-sm btn-default dropdown-toggle similar-select" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>

            </table>
        </div>

        <div class="bg-mywhite border_none request-table-col">
            <div class="panel panel-default">
                <div class="panel-heading font-bold">
                    DEFAULTERS-LEASE DEED
                    <asp:Button runat="server" ID="btnLeaseCancel" visible="false" Text="Forward selected Allotment for Cancellation" tooltips="Press the Button to forward the selected list to Cancel the Plots " OnClick="btnLeaseCancel_Click" Style="margin:3px 0;" CssClass="btn btn-sm btn-primary" />
                </div>
            </div>

            <div class="col-md-12" style="padding: 0px;">
                <div style="overflow-y: auto; max-height: 390px;" class="table-responsive">
                    <asp:GridView ID="GridView2" runat="server"
                        CssClass="table table-striped table-bordered table-hover request-table"
                        AllowPaging="true" PageSize="10"
                        OnPageIndexChanging="GridView2_PageIndexChanging"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                        DataKeyNames="AllotteeID"
                        GridLines="Horizontal"
                        ShowFooter="true"
                        OnRowDataBound="GridView2_RowDataBound"
                        OnRowCommand="GridView2_RowCommand"
                        Width="100%"
                        ItemStyle-Width="10%" OnSorting="GridView2_Sorting">
                        <Columns>
                            <asp:TemplateField HeaderText="SNO" Visible="true" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="AllotteeID" HeaderText="AllotteeID" Visible="false" SortExpression="AllotteeID" />
                            <asp:BoundField DataField="iNDUSTRIALAREA" HeaderText="IndustrialArea" Visible="false" SortExpression="iNDUSTRIALAREA" />
                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" Visible="TRUE" SortExpression="AllotteeName" />
                            <asp:BoundField DataField="PlotNo" HeaderText="Plot No." SortExpression="PlotNo" />
                            <asp:BoundField DataField="TotalAllottedplotArea" Visible="True" HeaderText="Area (In SQMts.)" SortExpression="TotalAllottedplotArea" DataFormatString="{0:N2}" />
                            <asp:BoundField DataField="AllotmentletterIssueDate" ItemStyle-Wrap="false" DataFormatString="{0:dd-M-yyyy}" HeaderText="Allotment Date" SortExpression="AllotmentletterIssueDate" />
                            <asp:BoundField DataField="applicableLeaseDeedexecutionDate" ItemStyle-Wrap="false" DataFormatString="{0:dd-M-yyyy}" HeaderText="Due Date: Lease Deed" SortExpression="applicableLeaseDeedexecutionDate" />
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <EmptyDataTemplate>
                            No Record Available
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>


                </div>

            </div>
            <div class="clearfix"></div>
            <hr class="separation" />

        </div>

        <div class="bg-mywhite border_none request-table-col">
            <div class="panel panel-default">
                <div class="panel-heading font-bold">
                    DEFAULTERS-POSSESSION
                     <asp:Button runat="server" ID="btnPossessionCancel" Text="Forward selected Allotment for Cancellation" tooltips="Press the Button to forward the selected list to Cancel the Plots " visible="false" OnClick="btnPossessionCancel_Click" Style="margin:3px 0;" CssClass="btn btn-sm btn-primary" />
                </div>
            </div>

            <div class="col-md-12" style="padding: 0px;">
                <div style="overflow-y: auto; max-height: 390px;" class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server"
                        CssClass="table table-striped table-bordered table-hover request-table"
                        AllowPaging="true" PageSize="10"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                        DataKeyNames="AllotteeID"
                        GridLines="Horizontal"
                        ShowFooter="true"
                        Width="100%"
                        ItemStyle-Width="10%" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnSorting="GridView1_Sorting">
                        <Columns>
                            <asp:TemplateField HeaderText="SNO" Visible="true" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="AllotteeID" HeaderText="AllotteeID" Visible="false" SortExpression="AllotteeID" />
                            <asp:BoundField DataField="iNDUSTRIALAREA" HeaderText="IndustrialArea" Visible="false" SortExpression="iNDUSTRIALAREA" />
                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" Visible="TRUE" SortExpression="AllotteeName" />
                            <asp:BoundField DataField="PlotNo" HeaderText="Plot No." SortExpression="PlotNo" />
                            <asp:BoundField DataField="TotalAllottedplotArea" Visible="True" HeaderText="Area (In SQMts.)" SortExpression="TotalAllottedplotArea" />
                            <asp:BoundField DataField="leaseDeeddate" ItemStyle-Wrap="false" DataFormatString="{0:dd-M-yyyy}" HeaderText="Lease Exec. Date" SortExpression="leaseDeeddate" />
                            <asp:BoundField DataField="applicablePossessionDate" ItemStyle-Wrap="false" DataFormatString="{0:dd-M-yyyy}" HeaderText="Due Date: Possession" SortExpression="applicablePossessionDate" />
                           <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtrequest" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="drpdnRaiseReQP" runat="server" AutoPostBack="true" EnableViewState="true" CausesValidation="False" OnSelectedIndexChanged="drpdnRaiseReQP_IndexChanged" Width="100px">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        </Columns>
                        <EmptyDataTemplate>
                            No Record Available
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>


                </div>

            </div>
            <div class="clearfix"></div>
            <hr class="separation" />
        </div>

        <div class="bg-mywhite border_none request-table-col">
            <div class="panel panel-default">
                <div class="panel-heading font-bold">
                    DEFAULTERS-BUILDING PLAN APPROVALS
                    <asp:Button runat="server" ID="btnBuildingapprovalCancel" visible="false" Text="Forward selected Allotment for Cancellation" tooltips="Press the Button to forward the selected list to Cancel the Plots " OnClick="btnBuildingapprovalCancel_Click" Style="margin:3px 0;" CssClass="btn btn-sm btn-primary" />
                </div>
            </div>


            <div class="col-md-12" style="padding: 0px;">
                <div style="overflow-y: auto; max-height: 390px;" class="table-responsive">
                    <asp:GridView ID="GridView3" runat="server"
                        CssClass="table table-striped table-bordered table-hover request-table"
                        AllowPaging="true" PageSize="10"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                        DataKeyNames="AllotteeID"
                        GridLines="Horizontal"
                        ShowFooter="true"
                        Width="100%"
                        ItemStyle-Width="10%" OnPageIndexChanging="GridView3_PageIndexChanging" OnRowDataBound="GridView3_RowDataBound" OnSorting="GridView3_Sorting">
                        <Columns>
                            <asp:TemplateField HeaderText="SNO" Visible="true" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="AllotteeID" HeaderText="AllotteeID" Visible="false" SortExpression="AllotteeID" />
                            <asp:BoundField DataField="iNDUSTRIALAREA" HeaderText="IndustrialArea" Visible="false" SortExpression="iNDUSTRIALAREA" />
                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" Visible="TRUE" SortExpression="AllotteeName" />
                            <asp:BoundField DataField="PlotNo" HeaderText="Plot No." SortExpression="PlotNo" />
                            <asp:BoundField DataField="TotalAllottedplotArea" Visible="True" HeaderText="Area (In SQMts.)" SortExpression="TotalAllottedplotArea" />
                            <asp:BoundField DataField="DateOfPossession" ItemStyle-Wrap="false" DataFormatString="{0:dd-M-yyyy}" HeaderText="Possession Date" SortExpression="DateOfPossession" />
                            <asp:BoundField DataField="applicableBuildingPlanSubmissionDate" ItemStyle-Wrap="false" DataFormatString="{0:dd-M-yyyy}" HeaderText="Due Date: Building MAP Approvals" SortExpression="applicableBuildingPlanSubmissionDate" />
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            No Record Available
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>


                </div>

            </div>
            <div class="clearfix"></div>
            <hr class="separation" />

        </div>

        <div class="bg-mywhite border_none request-table-col">
            <div class="panel panel-default">
                <div class="panel-heading font-bold">
                    DEFAULTERS-BUILDING CONSTRUCTION
                     <asp:Button runat="server" ID="btnBuildingConstructionCancel" visible="false" Text="Forward selected Allotment for Cancellation" tooltips="Press the Button to forward the selected list to Cancel the Plots " OnClick="btnBuildingConstructionCancel_Click" Style="margin:3px 0;" CssClass="btn btn-sm btn-primary" />
                </div>
            </div>

            <div class="col-md-12" style="padding: 0px;">
                <div style="overflow-y: auto; max-height: 390px;">
                    <asp:GridView ID="GridView4" runat="server"
                        CssClass="table table-striped table-bordered table-hover request-table"
                        AllowPaging="true" PageSize="10"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                        DataKeyNames="AllotteeID"
                        GridLines="Horizontal"
                        ShowFooter="true"
                        Width="100%"
                        ItemStyle-Width="10%" OnPageIndexChanging="GridView4_PageIndexChanging" OnRowDataBound="GridView4_RowDataBound" OnSorting="GridView4_Sorting">
                        <Columns>
                            <asp:TemplateField HeaderText="SNO" Visible="true" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="AllotteeID" HeaderText="AllotteeID" Visible="false" SortExpression="AllotteeID" />
                            <asp:BoundField DataField="iNDUSTRIALAREA" HeaderText="IndustrialArea" Visible="false" SortExpression="iNDUSTRIALAREA" />
                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" Visible="TRUE" SortExpression="AllotteeName" />
                            <asp:BoundField DataField="PlotNo" HeaderText="Plot No." SortExpression="PlotNo" />
                            <asp:BoundField DataField="TotalAllottedplotArea" Visible="True" HeaderText="Area (In SQMts.)" SortExpression="TotalAllottedplotArea" />
                            <asp:BoundField DataField="DateOfBuldingPlanSubmission" ItemStyle-Wrap="false" DataFormatString="{0:dd-M-yyyy}" HeaderText="Building MAP Submission Date" SortExpression="DateOfBuldingPlanSubmission" />
                            <asp:BoundField DataField="applicableConstructionStartDate" ItemStyle-Wrap="false" DataFormatString="{0:dd-M-yyyy}" HeaderText="Due Date: Building Construction Permit" SortExpression="applicableConstructionStartDate" />
                             <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            No Record Available
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>


                </div>

            </div>
            <div class="clearfix"></div>
            <hr class="separation" />

        </div>

        <div class="bg-mywhite border_none request-table-col">
            <div class="panel panel-default">
                <div class="panel-heading font-bold">
                    DEFAULTERS-COMMENSCEMENT OF PRODUCTION: TO BRING UNIT IN PRODUCTION
                       <asp:Button runat="server" ID="btnProductionCancel" visible="false" Text="Forward selected Allotment for Cancellation" tooltips="Press the Button to forward the selected list to Cancel the Plots " OnClick="btnProductionCancel_Click" Style="margin:3px 0;" CssClass="btn btn-sm btn-primary" />
                </div>
            </div>

            <div class="col-md-12" style="padding: 0px;">
                <div style="overflow-y: auto; max-height: 390px;">
                    <asp:GridView ID="GridView5" runat="server"
                        CssClass="table table-striped table-bordered table-hover request-table"
                        AllowPaging="true" PageSize="10"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                        DataKeyNames="AllotteeID"
                        GridLines="Horizontal"
                        ShowFooter="true"
                        Width="100%"
                        ItemStyle-Width="10%" OnPageIndexChanging="GridView5_PageIndexChanging" OnRowDataBound="GridView5_RowDataBound" OnSorting="GridView5_Sorting">
                        <Columns>
                            <asp:TemplateField HeaderText="SNO" Visible="true" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="AllotteeID" HeaderText="AllotteeID" Visible="false" SortExpression="AllotteeID" />
                            <asp:BoundField DataField="iNDUSTRIALAREA" HeaderText="IndustrialArea" Visible="false" SortExpression="iNDUSTRIALAREA" />
                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" Visible="TRUE" SortExpression="AllotteeName" />
                            <asp:BoundField DataField="PlotNo" HeaderText="Plot No." SortExpression="PlotNo" />
                            <asp:BoundField DataField="TotalAllottedplotArea" Visible="True" HeaderText="Area (In SQMts.)" SortExpression="TotalAllottedplotArea" />
                            <asp:BoundField DataField="AllotmentletterIssueDate" ItemStyle-Wrap="false" DataFormatString="{0:dd-M-yyyy}" HeaderText="Allotment Date" SortExpression="AllotmentletterIssueDate" />
                            <asp:BoundField DataField="EstimatedCostOfProjectINCRORES" Visible="True" HeaderText="Proposed Investment (In Crores. INR)" SortExpression="EstimatedCostOfProjectINCRORES" />
                            <asp:BoundField DataField="Timelines" Visible="True" HeaderText="Allowed Timeframe (In Months.)" SortExpression="Timelines" />
                            <asp:BoundField DataField="applicableProductionStartDate" ItemStyle-Wrap="false" DataFormatString="{0:dd-M-yyyy}" HeaderText="Due Date:Comencement of Production" SortExpression="applicableProductionStartDate" />
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            No Record Available
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>


                </div>

            </div>
            <div class="clearfix"></div>
            <hr class="separation" />
        </div>




    </div>

</asp:Content>
