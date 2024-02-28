<%@ Page Title="" Language="C#" MasterPageFile="~/MainUserHO.Master" AutoEventWireup="true" CodeBehind="PendencyReportNMCount.aspx.cs" Inherits="Allotment.PendencyReportNMCount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        @media only screen and (max-width:992px) {
            .form-group label.text-right {
                text-align: left !important;
            }
        }
           table tr th[colspan="8"]{
             background: #bfbfbf !important;
         }
         .request-table tr .head-IAname{
            background:#ccc !important;
        }
        .request-table tr .head-region{
            background:#ccc !important;
        }
        .request-table tr .head-total{
            background:#656565 !important;
            color:#fff;
        }
    </style>
    <script type="text/javascript">
    
        function PrintElem() {

            Popup($('#DivP').html());
        }
       

        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=1000');
            mywindow.document.write('<html><head><title style="font-weight:bold;">Allottee Details</title>');
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="form-group" style="background: #e6e6e6;padding: 4px 10px;">
                <div class="row">
                    <label class="col-md-2 col-sm-3 col-xs-3 text-right">
                        Service Name: 
                    </label>
                    <div class="col-md-7 col-sm-7 col-xs-7">
                        <asp:DropDownList ID="drpReportName" width="87.5%" style="background:#fff;" AutoPostBack="true"  CssClass="input-sm similar-select1" runat="server" OnSelectedIndexChanged="drpReportName_SelectedIndexChanged" >
                        <asp:ListItem Text="--Select--" Value="1000"  ></asp:ListItem>
                        <asp:ListItem Text="Land Allotment" Value="1000"></asp:ListItem>
                        <asp:ListItem Text="Building Plan" Value="1"></asp:ListItem>
                        <asp:ListItem Value="1003">Change Of Project</asp:ListItem>
                        <asp:ListItem Value="1004">Addition Of Product</asp:ListItem>
                        <asp:ListItem Value="1001">Request For Execution & Registration of Lease Deed </asp:ListItem>
                        <asp:ListItem Value="10001">Request for Possession of Plot </asp:ListItem>
                        <asp:ListItem Value="200">Online Payment of Reservation Money</asp:ListItem>
                        <asp:ListItem Value="1005">Request For Issuance Of NOC For Mortage</asp:ListItem>
                        <asp:ListItem Value="1006">Request For Issuance Of NOC For Joint Mortgage</asp:ListItem>
                        <asp:ListItem Value="1007">Request For Permission For Creation Of Second Charge</asp:ListItem>
                        <asp:ListItem Value="1011">Application for  Transfer of lease deed</asp:ListItem>
                        <asp:ListItem Value="1002">Application for  Time Extenstion Fee</asp:ListItem>
                        <asp:ListItem Value="4">Request for Transfer of Plot</asp:ListItem>
                        <asp:ListItem Value="1023">Request for No Dues Certificate</asp:ListItem>
                        <asp:ListItem Value="1027">Request for Outstanding dues position</asp:ListItem>
                        <asp:ListItem Value="1028">Online Payment of Outstanding Dues</asp:ListItem>
                        <asp:ListItem Value="1021">Request for legal heir after death</asp:ListItem>
                        <asp:ListItem Value="1017">Request for handover of lease deed to the lessee</asp:ListItem>
                        <asp:ListItem Value="1008">Request for reconstitution allottee firm / company</asp:ListItem>
                        <asp:ListItem Value="1014">Application for  Start of Production Certificate</asp:ListItem>
                        <asp:ListItem Value="1012">Application for Restoration of plot</asp:ListItem>
                        <asp:ListItem Value="1024">Request for Surrender of Plot</asp:ListItem>
                        <asp:ListItem Value="1025">Request for Establishment of Additional Unit</asp:ListItem>
                        <asp:ListItem Value="1026">Request for Subletting of Plot </asp:ListItem>

                         </asp:DropDownList>
                    </div>
                    <div class="col-md-3 col-sm-7 col-xs-7">
                        <ul class="pull-right list-inline">
                    <li>
                        <a runat="server" onclick="PrintElem()" style="cursor:pointer;">
                            <i style="font-size: 18px;" class="fa fa-print" aria-hidden="true"></i>
                        </a>
                    </li>
                    <li>
                        <a href="#" id="btnExport">
                            <i style="font-size: 18px;" class="fa fa-file-excel-o fa-fw"></i>
                        </a>
                    </li>
                </ul>
                        </div>
                </div>
            </div>
       
   
       
        <div class="col-md-12 col-sm-12 col-xs-12">
           <div class="clearfix"></div>
           
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div  id="DivP" style="text-align: center;padding: 15px 25px; margin: 25px 0%;background: #fbfbfb;border: 1px solid #ccc;">
                <div class="div-report" runat="server"  style="text-align: center;">

                    
	                <img src = "images/upsidclogo.png" class="header-logo" style="border-top:none;height: 40px;margin-bottom:0;" /><br/>
	                <strong>U.P. STATE INDUSTRIAL DEVELOPMENT AUTHORITY, KANPUR<br/>
	                (Head Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024)</strong><br /><br />
                    
                    <div style = "border-top:3px solid #ffc511;">&nbsp;</div> 
                    
                      <asp:PlaceHolder ID="ph" runat="server" />


                    
                    
                    <br /><br /><br /><br />
                    <div style = "border-top:3px solid #ffc511;">&nbsp;</div> 	
                    <div class="mail-disclaimer">
	                <p class="text-justify"><strong>Disclaimer:</strong>The information contained in this Report  is intended solely for the use of the individual or entity to whom it is addressed and others authorized to receive it. It may contain confidential or legally privileged information. If you are not the intended recipient you are hereby notified that any disclosure, copying, distribution or taking any action in reliance on the contents of this information is strictly prohibited and may be unlawful. If you have received this Report in error, please notify us immediately by responding at info[at]upsidc[dot]com  and then delete it from your system. In case of any query please contact us at info[at]upsidc[dot]com.</p>
                    </div>
                </div>
            </div>
        </div>

    <script>
                      $("#btnExport").click(function () {
                        window.open('data:application/vnd.ms-excel,' + encodeURIComponent($('#TableDiv').html()));
                        e.preventDefault();

                    });
               

</script>
</asp:Content>
