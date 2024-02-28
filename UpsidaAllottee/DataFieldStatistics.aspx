<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataFieldStatistics.aspx.cs" Inherits="UpsidaAllottee.DataFieldStatistics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="images\upsidclogo.png" />


    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />

    <link rel="icon" href="images\upsidclogo.png" />
    <title>Uttar Pradesh Industrial Development Authority</title>
    <meta http-equiv="Page-Enter" content="Alpha(opacity=100)" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/CssManu.css" rel="stylesheet" />
    <style>
        .abc {
            margin-top: 4vh;
        }

        th, tr {
            font-size: 18px;
            font-weight: 500;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container p-3 my-3 bg-primary text-white" >
        <div class="row abc" style="padding-bottom:40px;font-size:17px;font-weight:500">
            <div class="col-md-2 text-right">
                <span style="color: Red">*</span>
                <asp:Label ID="Label1" runat="server" Text="Select Data Field"></asp:Label>
            </div>
            <div class="col-md-3 col-lg-3 col-sm-8">
                <%--<asp:ListBox ID="listDatafield" class="form-control" runat="server" Rows="2" Width="200px" SelectionMode="Single" AutoPostBack = 'true'> </asp:ListBox>--%>
                <asp:DropDownList ID="dlDatafield" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlDatafield_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-md-2 text-right">
                <span style="color: Red">*</span>
                Regional Office
            </div>

            <div class="col-md-3 col-lg-3 col-sm-8">
                <asp:DropDownList ID="dlRO" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlRO_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="col-md-2">
                <asp:Button ID="btnsubmit" CssClass="btn btn-info" runat="server" Text="Click here" OnClick="GetStatistic_Click" />
            </div>
        </div>

        <div class="panel panel-default" runat="server" id="panel" style="margin-left: 20px; margin-right: 20px; margin-top: 40px;color:black">
            <div style="padding: 30px 30px 30px 30px">
                <div style="text-align: center; font-size: 22px; font-weight: 600; margin-bottom: 30px">
                    <asp:Label ID="Label2" runat="server" Text="DATA FIELDS STATISTICS"></asp:Label>
                </div>


                <table class="table table-striped table-hover">
                    <thead>
                        <tr>
                            <th scope="col"></th>
                            <th scope="col">Title</th>
                            <th scope="col">No. of Records</th>
                            <th scope="col">Records(In %)</th>

                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th scope="row">1</th>
                            <td>Database Table Name</td>
                            <td runat="server" id="tblName">-----</td>
                            <td runat="server" id="tblNamePer">-----</td>
                        </tr>
                        <tr>
                            <th scope="row">2</th>
                            <td>Mandatory/Optional</td>
                            <td runat="server" id="colOptional">-----</td>
                            <td runat="server" id="colOptionalPer">-----</td>
                        </tr>
                        <tr>
                            <th scope="row">3</th>
                            <td>Data Type</td>
                            <td runat="server" id="colType">-----</td>
                            <td runat="server" id="colTypePer">-----</td>

                        </tr>
                        <tr>
                            <th scope="row">4</th>
                            <td runat="server" id="zRecords">Zero Records</td>
                            <td runat="server" id="wRecords">Wrong Records</td>
                            <td runat="server" id="zeroValue">-----</td>
                            <td runat="server" id="zeroValuePer">-----</td>

                        </tr>
                        
                        <tr>
                            <th scope="row">5</th>
                            <td>Null(Blank) Records</td>
                            <td runat="server" id="nullValue">-----</td>
                            <td runat="server" id="nullValuePer">-----</td>

                        </tr>
                        <tr>
                            <th scope="row">6</th>
                            <td>Filled Records</td>
                            <td runat="server" id="filledValue">----</td>
                            <td runat="server" id="filledValuePer">----</td>
                        </tr>
                        <tr>
                            <th scope="row">7</th>
                            <td>Total Records</td>
                            <td runat="server" id="totalValue">-----</td>
                            <td runat="server" id="totalValuePer">-----</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

            </div>
    </form>

</body>
</html>
