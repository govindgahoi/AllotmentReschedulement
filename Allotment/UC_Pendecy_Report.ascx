<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Pendecy_Report.ascx.cs" Inherits="Allotment.UC_Pendecy_Report" %>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<link rel="stylesheet" href="css/bootstrap.min.css" />
    <style>
        @media only screen and (max-width:992px) {
            .form-group label.text-right {
                text-align: left !important;
            }
        }

body, h1, h2, h3, h4, h5, h6, p, a, .h1, .h2, .h3, .h4, .h5, .h6 {
    font-family: Segoe UI, Helvetica, Calibri;
}

.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
    </style>
<link type="text/css" rel="stylesheet" href="css/theme.css" />
    <div class="col-md-12 col-sm-12 col-xs-12">
            <div  id="DivP" style="text-align: center;padding: 15px 25px; margin: 25px 0%;background: #fbfbfb;border: 1px solid #ccc;">
                <div class="div-report" runat="server"  style="text-align: center;">

                      <asp:PlaceHolder ID="ph" runat="server" />
                 
                </div>
            </div>
        </div>

