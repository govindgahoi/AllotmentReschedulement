<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/RM.Master" AutoEventWireup="true" CodeBehind="auction-details.aspx.cs" Inherits="UpsidaAllottee.RMPanel.auction_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        
           function MsgAndRedirectRes() {
               alert('Grievance Resolved Successfully!');
               window.location.href = 'Grievance-Redressal.aspx';
           }

           function MsgAndRedirectHO() {
               alert('Grievance forwarded to Head Office!');
               window.location.href = 'Grievance-Redressal.aspx';
           }

           function MsgAndRedirectAuc() {
               alert('Data Mapped successfully!');
               window.location.href = 'eAuction-Data-Mapping.aspx';
           }

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main id="main" class="main">
        <section class="section dashboard">
            <div class="card info-card sales-card">
                <div class="container-fluid recent-sales">
                    <div class="row">
                        <div class="nine">
                            <h1>e-Auction Data Mapping<span>Details of Auction</span></h1>
                        </div>
                    </div>

                    <div class="row">
                    <asp:Label ID="lblUploadMsg" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="table-responsive">
                       <asp:GridView ID="grdAllotteeDetails" runat="server" AutoGenerateColumns="false" AllowPaging="true" class="mGrid2">
                                        <Columns>

                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSerNo" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Auction_Desc" HeaderText="Description" />
                                    <asp:BoundField DataField="Auction_Qty" HeaderText="Quantity" />
                                    <asp:BoundField DataField="Price_Basis" HeaderText="Price Basis" />
                                    <asp:BoundField DataField="Start_Price" HeaderText="Start Price" />
                                    <asp:BoundField DataField="Winner_Bidder" HeaderText="H1 Bidder" />
                                    <asp:BoundField DataField="Winner_Price" HeaderText="H1 Price" />
                                    <asp:BoundField DataField="Gain" HeaderText="Gains in Amount (H1 Price - Start Price)" />
                                    <asp:BoundField DataField="gainPercent" HeaderText="Gain in %" />
                                        </Columns>
					<EmptyDataTemplate>
                                            No Record Available
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                    </div>



                    <div id ="LevelPermission" runat="server">
                        <br />
                        <div class="table-responsive" id="regionData" runat="server">
                        <table class="mGrid2">
                            <thead>
                                <tr>
                                    <th>Regional Office</th>
                                    <th>Industrial Area</th>
                                    <th>Plot</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="dlregion" runat="server" CssClass="chosen input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="dlregion_SelectedIndexChanged"></asp:DropDownList>

                                    </td>
                                    <td>
                                        <asp:DropDownList ID="IaDdl" runat="server" CssClass="chosen input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="IaDdl_SelectedIndexChanged" ></asp:DropDownList>

                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drp_Plot" runat="server" CssClass="chosen input-sm dropdown-toggle similar-select1" AutoPostBack="true"></asp:DropDownList>

                                    </td>
                                    <td>
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="submit" OnClick="btnSubmit_Click" /></td>
                                </tr>
                                </tbody>
                            </table>
                        </div>

                        <div class="table-responsive" id="regionDataMapped" runat="server">
                        <table class="mGrid2">
                            <thead>
                                <tr>
                                    <th>Regional Office</th>
                                    <th>Industrial Area</th>
                                    <th>Plot</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td><asp:Label ID="lblRegion" runat="server" Text=""></asp:Label></td>
                                    <td><asp:Label ID="lblIA" runat="server" Text=""></asp:Label></td>
                                    <td><asp:Label ID="lblPlot" runat="server" Text=""></asp:Label></td>
                                </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="table-responsive" id="letterGenerated" runat="server">
                        <table class="mGrid2">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnGenerateLetter" runat="server" Text="Generate Allotment Letter" class="submit" OnClick="btnGenerateLetter_Click" /></td>
                                </tr>
                                </tbody>
                            </table>
                        </div>


                </div>
            </div>
        </section>
    </main>
</asp:Content>