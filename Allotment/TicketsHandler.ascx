<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TicketsHandler.ascx.cs" Inherits="Allotment.TicketsHandler" %>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "images/arrowvb.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "images/arrowhr.png");
            $(this).closest("tr").next().remove();
        });
    </script>
  <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
            
        }
        .Grid td
        {
            background-color: #A1DCF2;
            color: black;
            font-size: 10pt;
            line-height:200%
        }
        .Grid th
        {
            background-color: #3AC0F2;
            color: White;
            font-size: 10pt;
            line-height:200%
        }
        .ChildGrid td
        {
            background-color: #eee !important;
            color: black;
            font-size: 10pt;
            line-height:200%
        }
        .ChildGrid th
        {
            background-color: #6C6C6C !important;
            color: White;
            font-size: 10pt;
            line-height:200%
        }
    </style>



<div class="row" style="border: 3px solid #c5c506; margin: 5px 0 0 0px; padding: 5px 0;">
    <div class="col-md-8 col-sm-12 col-xs-12" style="border-right: 1px solid #ccc">

 <div class="col-md-10">
                <asp:GridView ID="universityGrid" runat="server" AutoGenerateColumns="False" CssClass="Grid" OnRowDataBound="universityGrid_RowDataBound" DataKeyNames="ServiceRequestNO">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>

                                <asp:Image ID="Image1" runat="server" Style="cursor: pointer" ImageUrl="~/images/arrowhr.png" />
                                <asp:Panel ID="pnlunivesity" runat="server" Style="display: none">
                                    <asp:GridView ID="clgGrid" runat="server" AutoGenerateColumns="false" CssClass="ChildGrid" OnRowDataBound="clgGrid_RowDataBound" DataKeyNames="CollegeCode">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" Style="cursor: pointer" ImageUrl="~/images/arrowhr.png" />
                                                    <asp:Panel ID="pnlcollege" runat="server" Style="display: none">

                                                        <asp:GridView ID="branchGrid" runat="server" AutoGenerateColumns="false" CssClass="ChildGrid" OnRowDataBound="branchGrid_RowDataBound" DataKeyNames="BranchCode">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Style="cursor: pointer" ImageUrl="~/images/arrowhr.png" />
                                                                        <asp:Panel ID="pnlbranch" runat="server" Style="display: none">
                                                                            <asp:GridView ID="studentGrid" runat="server" AutoGenerateColumns="false">
                                                                                <Columns>
                                                                                    <asp:BoundField ItemStyle-Width="150px" DataField="StudentID" HeaderText="Student ID" />
                                                                                    <asp:BoundField ItemStyle-Width="150px" DataField="StudentName" HeaderText="Student Name" />
                                                                                    <asp:BoundField ItemStyle-Width="150px" DataField="BranchName" HeaderText="Branch Name" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </asp:Panel>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField ItemStyle-Width="150px" DataField="BranchCode" HeaderText="Branch Code" />
                                                                <asp:BoundField ItemStyle-Width="150px" DataField="BranchName" HeaderText="Branch Name" />
                                                            </Columns>
                                                        </asp:GridView>


                                                       
                                                    </asp:Panel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="ApplicationType" HeaderText="College Code" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="CaseType" HeaderText="College Name" />
                                        </Columns>
                                    </asp:GridView>
                                   
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField ItemStyle-Width="150px" DataField="ServiceTimelinesID" HeaderText="Univercity Code">
                            <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="ApplicationType" HeaderText="University Name">
                              <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="IndustrialArea" HeaderText="University Name">
                              <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="DataStatus" HeaderText="University Name">
                              <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                    </Columns>
                </asp:GridView>

       

            </div>
        </div>
    </div>
            <div class="clearfix"></div>
