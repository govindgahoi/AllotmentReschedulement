﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlotNameUpdate.aspx.cs" Inherits="Allotment.PlotNameUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
      <link rel="icon" href="images\upsidclogo.png" />
   <title>Uttar Pradesh Industrial Development Authority</title>

    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <%--<link href="/css/theme.css" rel="stylesheet" />--%>
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">--%>
    <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>--%>
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet" />
     <script src="js/jquery-ui.js"></script>
    <script src="js/chosen.jquery.min.js"></script>
   
</head>
<body>
    <form id="form1" runat="server">

        <div style="text-align: center;margin-top:5vh;">
            <asp:Label Font-Bold="true" ID="Label4" runat="server" Text="UPDATE PLOT NO"></asp:Label>
        </div>

        <br />
        <div>

            <div class="row">
                <div class="col-md-offset-3" style="padding-bottom: 15px; display: none">
                    <asp:Label ID="Label7" runat="server" Text="Service Request No."></asp:Label>
                </div>
                <div class="col-md-6" style="padding-bottom: 15px;display: none">
                    <asp:TextBox ID="txtSerNo" CssClass="form-control" Width="280px" runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <div class="col-md-offset-2 col-md-2 text-right" style="padding-bottom: 15px; ">
                        <asp:Label ID="Label6" runat="server" Text="New Plot No."></asp:Label>
                    </div>
                    <div class="col-md-3" style="padding-bottom: 15px;">
                        <asp:TextBox ID="txtPlotNo" ValidationGroup="LoginFrame" CssClass="form-control" Width="280px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqName" ControlToValidate="txtPlotNo" ValidationGroup="LoginFrame" runat="server" ErrorMessage="* Plot No. is required."></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2" style="padding-bottom: 15px;">
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="Update" OnClick="UpdatePlotNo" />
            </div>
                </div>
                
                </div>
            <div class="row" style="margin-top: 25px; text-align: center">

                
            </div>
        </div>
    </form>
</body>
</html>