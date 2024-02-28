<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/RM.Master" AutoEventWireup="true" CodeBehind="ots-transaction-details.aspx.cs" Inherits="UpsidaAllottee.RMPanel.ots_transaction_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main id="main" class="main">
        <section class="section dashboard">
            <div class="card info-card sales-card">
                <div class="container-fluid recent-sales">
                    <div class="row">
                        <div class="nine">
                            <h1>OTS TRANSACTION DETAILS <span>DETAILS of OTS</span></h1>
                        </div>
                    </div>
                    <div class="row align-items-center">
                        <div class="col-lg-4 col-md-4">
                            <div class="mou-summary">
                                <h4 class="card-title">Paid Amount (In Lacs)</h4>
                                <p>One Time Payment = <span>4776.69</span></p>
                                <p>Instalment Amounts = <span>1852.75</span></p>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4">
                            <div class="mou-summary">
                                <h4 class="card-title">Number of Applications</h4>
                                <p>Allottees applied for One Time Payment = <span>2372</span></p>
                                <p>Allottees applied for Instalment-wise Payment = <span>777</span></p>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4">
                            <div class="mou-summary">
                                <h4 class="card-title">No. of Applications in terms of Transaction Mode</h4>
                                <p>Online = <span>2663</span></p>
                                <p>Offline = <span>486</span></p>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-md-8 col-lg-8">
                            <input type="submit" name="btnTransactionExport" value="Download Report" class="approve" />
                            <input type="submit" name="btnPayOffline" value="Pay Offline" class="save" />
                        </div>

                        <div class="col-md-2 col-lg-2 mb-3">
                            <select name="DropDownList1" class=" form-select chosen input-sm similar-select1 margin-left-z">
                                <option selected="selected" value="0">--All Type--</option>
                                <option value="1">Online</option>
                                <option value="2">Offline</option>
                            </select>
                        </div>
                        <div class="col-md-2 col-lg-2">
                            <input name="txtDate" type="date" class=" form-control chosen input-sm similar-select1" />
                        </div>
                    </div>
                    <div class="table-responsive">
                            <table class="table table-bordered table-hover">
                                <thead>
                                     <tr>
                                        <th>S.No.</th>
                                        <th>Regional Office</th>
                                        <th>IA Name</th>
                                        <th>Plot NO.</th>
                                        <th>To Be Paid (In Rs.)</th>
                                        <th>Waive_Off (In Rs.)</th>
                                        <th>Paid (In Rs.)</th>
                                        <th>PT Date</th>
                                        <th>Balance Amount (In Rs.)</th>
                                        <th>BT Date</th>
                                        <th>1st Instalment (In Rs.)</th>
                                        <th>2nd Instalment (In Rs.)</th>
                                        <th>3rd Instalment (In Rs.)</th>
                                        <th>Transaction Mode</th>
                                        <th>Payment Type</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <span>1</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>K-21</td>
                                        <td>113939.90</td>
                                        <td>17369.96</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>2</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>K-23</td>
                                        <td>17079.44</td>
                                        <td>619.72</td>
                                        <td>16412.00</td>
                                        <td>1/20/2022</td>
                                        <td>48.61</td>
                                        <td>2/7/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>3</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>K-22</td>
                                        <td>116959.41</td>
                                        <td>14259.72</td>
                                        <td>25545.00</td>
                                        <td>1/21/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>4</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>H-55,H-56,H-57,H-58</td>
                                        <td>67309.62</td>
                                        <td>7759.30</td>
                                        <td>59284.00</td>
                                        <td>1/7/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>5</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>G-32</td>
                                        <td>85273.69</td>
                                        <td>9456.85</td>
                                        <td>18948.00</td>
                                        <td>2/5/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>18957.00</td>
                                        <td>18957.00</td>
                                        <td>18957.00</td>
                                        <td>Online</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>6</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>G-23</td>
                                        <td>15615.12</td>
                                        <td>607.56</td>
                                        <td>15003.00</td>
                                        <td>2/5/2022</td>
                                        <td>5.52</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>7</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>G-85</td>
                                        <td>15615.12</td>
                                        <td>607.56</td>
                                        <td>15003.00</td>
                                        <td>2/5/2022</td>
                                        <td>5.52</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>8</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>J-8</td>
                                        <td>27441.82</td>
                                        <td>1840.91</td>
                                        <td>25592.00</td>
                                        <td>2/5/2022</td>
                                        <td>9.11</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>9</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>H-13, H-14</td>
                                        <td>66690.74</td>
                                        <td>6345.37</td>
                                        <td>60301.00</td>
                                        <td>2/7/2022</td>
                                        <td>44.39</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>10</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>H-43</td>
                                        <td>44273.94</td>
                                        <td>4771.39</td>
                                        <td>39410.00</td>
                                        <td>2/19/2022</td>
                                        <td>93.25</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>11</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>G-33</td>
                                        <td>90552.14</td>
                                        <td>14076.08</td>
                                        <td>19114.00</td>
                                        <td>2/7/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>19122.00</td>
                                        <td>19122.00</td>
                                        <td>19122.00</td>
                                        <td>Online</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>12</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>G-30</td>
                                        <td>73416.56</td>
                                        <td>10308.28</td>
                                        <td>15773.00</td>
                                        <td>2/7/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>15779.00</td>
                                        <td>15779.00</td>
                                        <td>15779.00</td>
                                        <td>Online</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>13</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>J-77/80</td>
                                        <td>163021.02</td>
                                        <td>13067.04</td>
                                        <td>37489.00</td>
                                        <td>2/7/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>14</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>A-7</td>
                                        <td>591114.95</td>
                                        <td>57365.70</td>
                                        <td>533750.00</td>
                                        <td>2/8/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>15</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>G-38</td>
                                        <td>83952.31</td>
                                        <td>11976.16</td>
                                        <td>71954.00</td>
                                        <td>2/11/2022</td>
                                        <td>23.02</td>
                                        <td>2/19/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>16</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>G-51</td>
                                        <td>16976.19</td>
                                        <td>1288.10</td>
                                        <td>15689.00</td>
                                        <td>2/9/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>17</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>D-326</td>
                                        <td>161318.45</td>
                                        <td>24373.22</td>
                                        <td>34237.00</td>
                                        <td>2/10/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>34237.00</td>
                                        <td>34237.00</td>
                                        <td>34237.00</td>
                                        <td>Online</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>18</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>K-49</td>
                                        <td>20886.44</td>
                                        <td>843.22</td>
                                        <td>20044.00</td>
                                        <td>2/14/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>19</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>K-50</td>
                                        <td>20886.44</td>
                                        <td>843.22</td>
                                        <td>20044.00</td>
                                        <td>2/14/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>20</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>J-12</td>
                                        <td>58949.89</td>
                                        <td>5474.94</td>
                                        <td>13369.00</td>
                                        <td>2/15/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>13369.00</td>
                                        <td>13369.00</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>21</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>J-13</td>
                                        <td>58949.89</td>
                                        <td>5474.94</td>
                                        <td>13369.00</td>
                                        <td>2/15/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>13369.00</td>
                                        <td>13369.00</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>22</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>H-1</td>
                                        <td>99367.64</td>
                                        <td>19451.22</td>
                                        <td>19980.00</td>
                                        <td>2/17/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>19980.00</td>
                                        <td>19980.00</td>
                                        <td>19980.00</td>
                                        <td>Online</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>23</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>B-8, B-9, B-10</td>
                                        <td>584648.84</td>
                                        <td>95075.55</td>
                                        <td>122415.00</td>
                                        <td>2/19/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Offline</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>24</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>H-78</td>
                                        <td>46777.32</td>
                                        <td>5388.66</td>
                                        <td>10348.00</td>
                                        <td>2/18/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>25</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>H-79</td>
                                        <td>48635.86</td>
                                        <td>4347.34</td>
                                        <td>11073.00</td>
                                        <td>2/18/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>26</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>G-71</td>
                                        <td>15686.93</td>
                                        <td>643.46</td>
                                        <td>15044.00</td>
                                        <td>2/18/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>27</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>K-16</td>
                                        <td>21051.90</td>
                                        <td>1069.95</td>
                                        <td>19982.00</td>
                                        <td>2/18/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>28</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>K-17</td>
                                        <td>21051.90</td>
                                        <td>1069.95</td>
                                        <td>19982.00</td>
                                        <td>2/18/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>29</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>K-18</td>
                                        <td>21051.90</td>
                                        <td>1069.95</td>
                                        <td>19982.00</td>
                                        <td>2/18/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>30</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>J-25</td>
                                        <td>27838.69</td>
                                        <td>1919.34</td>
                                        <td>25920.00</td>
                                        <td>2/18/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>31</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>J-26</td>
                                        <td>27838.69</td>
                                        <td>1919.34</td>
                                        <td>25920.00</td>
                                        <td>2/18/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>32</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>G-53</td>
                                        <td>35403.07</td>
                                        <td>3301.54</td>
                                        <td>8026.00</td>
                                        <td>2/18/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>33</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>G-52</td>
                                        <td>62796.16</td>
                                        <td>7398.08</td>
                                        <td>13850.00</td>
                                        <td>2/18/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>34</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>J-74/76</td>
                                        <td>121673.98</td>
                                        <td>10197.77</td>
                                        <td>27869.00</td>
                                        <td>2/19/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Offline</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>35</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>J-73</td>
                                        <td>57075.23</td>
                                        <td>4670.96</td>
                                        <td>13101.00</td>
                                        <td>2/19/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Offline</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>36</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>H-70</td>
                                        <td>42130.65</td>
                                        <td>4865.32</td>
                                        <td>9317.00</td>
                                        <td>2/19/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Offline</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>37</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>K-24</td>
                                        <td>37494.37</td>
                                        <td>2907.18</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Offline</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>38</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>K-8</td>
                                        <td>44780.50</td>
                                        <td>3478.25</td>
                                        <td>10326.00</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Offline</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>39</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>J-33</td>
                                        <td>59041.95</td>
                                        <td>5520.98</td>
                                        <td>13380.00</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Offline</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>40</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>H-11</td>
                                        <td>94732.90</td>
                                        <td>18477.06</td>
                                        <td>76256.00</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>41</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>J-16</td>
                                        <td>95759.94</td>
                                        <td>11879.97</td>
                                        <td>83880.00</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>42</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>J-17</td>
                                        <td>101204.32</td>
                                        <td>14602.16</td>
                                        <td>86603.00</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>43</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>G-83</td>
                                        <td>16208.22</td>
                                        <td>2704.11</td>
                                        <td>15756.00</td>
                                        <td>2/18/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Offline</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>44</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>K-5</td>
                                        <td>68044.17</td>
                                        <td>5654.08</td>
                                        <td>15598.00</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>45</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>H-37</td>
                                        <td>93021.68</td>
                                        <td>21310.84</td>
                                        <td>71711.00</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>46</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>K-6</td>
                                        <td>120282.68</td>
                                        <td>12877.84</td>
                                        <td>26852.00</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>Instalment</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>47</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>K-33</td>
                                        <td>21387.23</td>
                                        <td>1093.62</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Offline</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>48</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>B-20</td>
                                        <td>424517.97</td>
                                        <td>73658.98</td>
                                        <td>350859.00</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Online</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>49</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>K-36</td>
                                        <td>21387.22</td>
                                        <td>1093.61</td>
                                        <td>20293.61</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Offline</td>
                                        <td>One Time</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>50</span>
                                        </td>
                                        <td>LUCKNOW</td>
                                        <td>Agro Park</td>
                                        <td>K-37</td>
                                        <td>21387.22</td>
                                        <td>1093.61</td>
                                        <td>20293.61</td>
                                        <td>2/20/2022</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Offline</td>
                                        <td>One Time</td>
                                    </tr>
                                </tbody>
                            </table>
                        <div class="dataTable-bottom">
                            <div class="dataTable-info">Showing 1 to 5 of 5 entries</div>
                            <nav aria-label="Page navigation example">
                                <ul class="pagination">
                                    <li class="page-item disabled">
                                        <a class="page-link" href="#" tabindex="-1" aria-disabled="true">Previous</a>
                                    </li>
                                    <li class="page-item"><a class="page-link" href="#">1</a></li>
                                    <li class="page-item"><a class="page-link" href="#">2</a></li>
                                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                                    <li class="page-item">
                                        <a class="page-link" href="#">Next</a>
                                    </li>
                                </ul>
                            </nav>
                        </div>
                        </div>
                </div>
            </div>
        </section>
    </main>

</asp:Content>
