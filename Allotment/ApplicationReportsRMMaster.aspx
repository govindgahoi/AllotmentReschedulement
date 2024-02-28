<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="ApplicationReportsRMMaster.aspx.cs" Inherits="Allotment.ApplicationReportsRMMaster" %>
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
    <div class="row" >
            <div class="col-md-12 col-sm-12 col-xs-12" style="background: #dbdbdb;">
                <div>
                <div style="width: 100px;float: left;background: #dbdbdb;font-size:11px;" class="text-center">
                    <br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li class="disabled">
                            <a runat="server"  class="disable">
                                <i class="fa fa-home" aria-hidden="true"></i><br />Home
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;font-size:11px;" class="text-center">
                    Operate<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li>
                            <a runat="server" id="SaveEntry"  class="disable" >
                                <i class="fa fa-floppy-o " aria-hidden="true"></i><br />Save
                            </a>
                        </li> 
                        <li>
                            <a runat="server"   class="disable">
                                <i class="fa fa-refresh" aria-hidden="true"></i><br />Refresh
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;border-right:1px solid #000;font-size:11px;" class="text-center">
                    Allottee Registration<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                            <a runat="server"  class="disable">
                                <i class="fa fa-plus" aria-hidden="true"></i><br />New
                            </a>
                        </li>
                        <li>
                            <a runat="server"  class="disable">
                                <i class="fa fa-pencil-square-o" aria-hidden="true"></i><br />History
                            </a>
                        </li>
                       
                      </ul>
                </div>
                 <div style="float: left;background: #dbdbdb;font-size:11px;" class="text-center">
                    Navigation<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                                <a href="#" class="disable">
                                    <i class="fa fa-step-backward" aria-hidden="true"></i><br />Last
                                </a>                        
                        </li>
                        <li>
                            <a runat="server"  class="disable">
                                <i class="fa fa-angle-double-left" aria-hidden="true"></i><br />Previous
                            </a>
                        </li>
                        <li>
                            <a runat="server" id="sernext"  class="disable">
                                <i class="fa fa-angle-double-right" aria-hidden="true"></i><br />Next
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-step-forward" aria-hidden="true"></i><br />Final
                            </a>
                        </li>
                          <li runat="server" id="hrefPrint">
                            <a runat="server" onclick="PrintElem()" >
                                <i class="fa fa-print" aria-hidden="true"></i><br />Print
                            </a>
                        </li>
                         
                        
                    </ul>
                    </div>     
                    
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    <hr style="margin: 4px 0;border-top: 1px solid #d8d8d8;"  />
    <div class="row">
        <div class="form-group" style="background: #dadada;padding: 2px 0;margin-bottom: 3px;">
                <div class="">
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        Regional Office :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:DropDownList runat="server" ID="ddloffice" style="background:#fff;" CssClass="input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="Regional_Changed"></asp:DropDownList>
                    </div>
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        Industrial Area :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:DropDownList runat="server" ID="drpdwnIA" style="background:#fff;" CssClass="input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged" ></asp:DropDownList>
                    </div>
                    <label class="col-md-2 col-sm-1 col-xs-12">
                       Payment Mode :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:DropDownList runat="server" ID="ddlPayMode" style="background:#fff;" CssClass="input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="ddlPayMode_SelectedIndexChanged">
                          <asp:ListItem Value="All">--All--</asp:ListItem>
                             <asp:ListItem Value="HDFC">HDFC</asp:ListItem>
                            <asp:ListItem Value="ICICI">ICICI</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        Transaction From Date :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:TextBox runat="server" ID="txtTransactionFromDate" style="background:#fff;" CssClass="date1 input-sm similar-select1"></asp:TextBox>
                    </div>
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        To Date :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:TextBox runat="server" ID="txtTransactionToDate" style="background:#fff;" CssClass="date1 input-sm similar-select1"></asp:TextBox>
                    </div>
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        Search Keyword :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:TextBox runat="server" ID="txtSearch" style="background:#fff;" CssClass="input-sm similar-select1"></asp:TextBox>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="col-md-12 col-sm-2 col-xs-12">
                        <asp:Button ID="btnFetch" runat="server" Text="Fetch" Style="padding:2px 27px;margin:10px 0;" CssClass="btn-primary ey-bg pull-right" OnClick="btnFetch_Click" />
                    </div>
                    
                </div>
                <div class="clearfix"></div>
            </div>
        <div class="col-md-12 col-sm-12 col-xs-12">
           <div class="clearfix"></div>
            <hr class="myhrline" style="border-bottom:1px solid #d8d8d8;"/>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div  id="DivP" style="text-align: center;padding: 15px 25px; margin: 25px 0%;background: #fbfbfb;border: 1px solid #ccc;">
                <div class="div-report" runat="server"  style="text-align: center;">

                    
	                <img src = "images/upsidclogo.png" class="header-logo" style="border-top:none;height: 40px;margin-bottom:0;" /><br>
	                <strong>U.P. STATE INDUSTRIAL DEVELOPMENT CORPORATION LIMITED, KANPUR<br>
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
    </div>
</asp:Content>
