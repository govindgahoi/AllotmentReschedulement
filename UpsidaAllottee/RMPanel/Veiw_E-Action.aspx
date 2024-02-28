<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/RM.Master" AutoEventWireup="true" CodeBehind="Veiw_E-Action.aspx.cs" Inherits="UpsidaAllottee.RMPanel.Veiw_E_Action" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">
        <section class="section dashboard">
            <div class="card info-card sales-card">
                <div class="container-fluid recent-sales">
                    <div class="row">
                        <div class="nine">
                            <h1>View E-Auction Data Mapping <span>Details of E-Auction Data Mapping</span></h1>
                        </div>
                    </div>
                    <div class="view-action">
                        <div class="form-group">
                            <label class="heading-action">S.No </label>
                            <div class="offices">1.</div>
                        </div>
                        <div class="form-group">
                            <label class="heading-action">Description</label>
                            <div class="offices">Description	</div>
                        </div>
                        <div class="form-group">
                            <label class="heading-action">Qty </label>
                            <div class="offices">500.</div>
                        </div>
                        <div class="form-group">
                            <label class="heading-action">Price Basis </label>
                            <div class="offices">500</div>
                        </div>
                        <div class="form-group">
                            <label class="heading-action">Start price</label>
                            <div class="offices">400</div>
                        </div>
                        <div class="form-group">
                            <label class="heading-action">H1 Bidder</label>
                            <div class="offices">Bidder</div>
                        </div>
                        <div class="form-group">
                            <label class="heading-action">H1 Price</label>
                            <div class="offices">Price</div>
                        </div>
                        <div class="form-group">
                            <label class="heading-action">Gains in amount (h1 price - start price) </label>
                            <div class="offices">100</div>
                        </div>
                        <div class="form-group">
                            <label class="heading-action">Gains in % </label>
                            <div class="offices">1%</div>
                        </div>
                        <div class="form-group">
                            <label class="heading-action">No. of bid </label>
                            <div class="offices">5</div>
                        </div>
                        <div class="form-group">
                            <label class="heading-action">No. of bidder</label>
                            <div class="offices">99</div>
                        </div>
                        <div class="form-group">
                            <label class="heading-action">Regional Office</label>
                            <select class="form-select">
                                <option value="01">--Select--</option>
                                <option value="02">AGRA</option>
                                <option value="03">ALIGARH</option>
                                <option value="04">AYODHYA</option>
                                <option value="05">BAREILLY</option>
                                <option value="06">GHAZIABAD</option>
                                <option value="07">GNEPIP</option>
                                <option value="08">GORAKHPUR</option>
                                <option value="09">JHANSI</option>
                                <option value="11">KANPUR</option>
                                <option value="12">LUCKNOW</option>
                                <option value="13">MEERUT</option>
                                <option value="13">PO TDS CITY</option>
                                <option value="14">PO TRANS GANGA</option>
                                <option value="15">PRAYAGRAJ</option>
                                <option value="16">SEZ MORADABAD</option>
                                <option value="17">SURAJPUR</option>
                                <option value="18">VARANASI</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label class="heading-action">Industrial Area</label>

                            <select class="form-select">
                                <option selected="selected" value="-1">--Select All--</option>
                                <option value="1">EPIP Agra </option>
                                <option value="1">Foundry Nagar </option>
                                <option value="1">Sikandara A </option>
                                <option value="1">Sikandara C </option>
                                <option value="1">Leather Park, Agra </option>
                                <option value="1">Kosi Kalan </option>
                            </select>

                        </div>
                        <div class="form-group">
                            <label class="heading-action">Plot No</label>

                            <select class="form-select">
                                <option selected="selected" value="-1">--Select All--</option>
                                <option value="1">EPIP Agra </option>
                                <option value="1">Foundry Nagar </option>
                                <option value="1">Sikandara A </option>
                                <option value="1">Sikandara C </option>
                                <option value="1">Leather Park, Agra </option>
                                <option value="1">Kosi Kalan </option>
                            </select>
                        </div>

                        <div class="mb-3 mt-3">
                            <input type="submit" name="" value="Save" id="" class="save" />
                        </div>
                    </div>
                </div>

                 <div class="row">
                     <div class="text-center mb-3 mt-3">
                            <input type="submit" name="" value="Generate Allotment Letter" id="" class="approve" />
                        </div>
                 </div>
               <%-- <div class="table-responsive">
                    <table class="mGrid2">
                        <thead>
                            <tr>
                                <th>S.No.</th>
                                <th>Description</th>
                                <th>Qty</th>
                                <th>Price Basis</th>
                                <th>Start price</th>
                                <th>H1 bidder</th>
                                <th>H1 price</th>
                                <th>Gains in amount (h1 price - start price)</th>
                                <th>Gains in %</th>
                                <th>No. of bid</th>
                                <th>No. of bidder</th>
                                <th>Regional Office</th>
                                <th>Industrial Area</th>
                                <th>Plot</th>

                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1.</td>
                                <td>Description</td>
                                <td>Qty</td>
                                <td>Price Basis</td>
                                <td>Start price</td>
                                <td>H1 bidder</td>
                                <td>H1 price</td>
                                <td>Gains in amount (h1 price - start price)</td>
                                <td>Gains in %</td>
                                <td>No. of bid</td>
                                <td>No. of bidder</td>
                                <td>Regional Office</td>
                                <td>Industrial Area</td>
                                <td>Plot</td>
                            </tr>
                            <tr>
                                <td>2.</td>
                                <td>Description</td>
                                <td>Qty</td>
                                <td>Price Basis</td>
                                <td>Start price</td>
                                <td>H1 bidder</td>
                                <td>H1 price</td>
                                <td>Gains in amount (h1 price - start price)</td>
                                <td>Gains in %</td>
                                <td>No. of bid</td>
                                <td>No. of bidder</td>
                                <td>Regional Office</td>
                                <td>Industrial Area</td>
                                <td>Plot</td>
                            </tr>
                            <tr>
                                <td>3.</td>
                                <td>Description</td>
                                <td>Qty</td>
                                <td>Price Basis</td>
                                <td>Start price</td>
                                <td>H1 bidder</td>
                                <td>H1 price</td>
                                <td>Gains in amount (h1 price - start price)</td>
                                <td>Gains in %</td>
                                <td>No. of bid</td>
                                <td>No. of bidder</td>
                                <td>Regional Office</td>
                                <td>Industrial Area</td>
                                <td>Plot</td>
                            </tr>
                            <tr>
                                <td>4.</td>
                                <td>Description</td>
                                <td>Qty</td>
                                <td>Price Basis</td>
                                <td>Start price</td>
                                <td>H1 bidder</td>
                                <td>H1 price</td>
                                <td>Gains in amount (h1 price - start price)</td>
                                <td>Gains in %</td>
                                <td>No. of bid</td>
                                <td>No. of bidder</td>
                                <td>Regional Office</td>
                                <td>Industrial Area</td>
                                <td>Plot</td>
                            </tr>
                            <tr>
                                <td>5.</td>
                                <td>Description</td>
                                <td>Qty</td>
                                <td>Price Basis</td>
                                <td>Start price</td>
                                <td>H1 bidder</td>
                                <td>H1 price</td>
                                <td>Gains in amount (h1 price - start price)</td>
                                <td>Gains in %</td>
                                <td>No. of bid</td>
                                <td>No. of bidder</td>
                                <td>Regional Office</td>
                                <td>Industrial Area</td>
                                <td>Plot</td>
                            </tr>
                            <tr>
                                <td>6.</td>
                                <td>Description</td>
                                <td>Qty</td>
                                <td>Price Basis</td>
                                <td>Start price</td>
                                <td>H1 bidder</td>
                                <td>H1 price</td>
                                <td>Gains in amount (h1 price - start price)</td>
                                <td>Gains in %</td>
                                <td>No. of bid</td>
                                <td>No. of bidder</td>
                                <td>Regional Office</td>
                                <td>Industrial Area</td>
                                <td>Plot</td>
                            </tr>
                        </tbody>
                    </table>
                </div>--%>
            </div>
        </section>
    </main>
</asp:Content>
