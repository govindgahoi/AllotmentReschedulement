SWCstatus<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccountClearence.ascx.cs" EnableViewState="true" Inherits="Allotment.ucAccountClearence" %>



<style>
        @media only screen and (max-width:992px) {
            .form-group label.text-right {
                text-align: left !important;
            }
            .ey-payment {
                background:#ff6a00;
            }
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
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="form-group" style="background: #e6e6e6;padding: 4px 10px;">
                <div class="row">
                    <label class="col-md-2 col-sm-2 col-xs-12 text-left">
                        Service Ref. Number: 
                    </label>
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="drpReportName" width="100%" style="background:#fff;" AutoPostBack="true"  OnSelectedIndexChanged="drpReportName_SelectedIndexChanged" CssClass="input-sm similar-select1" runat="server" >
                         

                           
                         </asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-sm-2 col-xs-12" style="padding:0px">
                        <asp:Button ID="btnFetch" style="background:#ff6a00; color:#fff; border:none; padding: 3px 8px 3px 8px;"  runat="server" Text="Import Pending Tickets" />
                    </div>
                   
                </div>
                
            </div>
           <div class="clearfix"></div>
            <hr class="myhrline" style="border-bottom:1px solid #d8d8d8;"/>
          
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 pad-lt0">
            <div  id="DivP" style="text-align: center;padding: 15px 25px; /*margin: 25px 10%;*/background: #fbfbfb;border: 1px solid #ccc;">
                <div class="div-report" runat="server"  style="text-align: center;">

                    
	                <img src = "images/upsidclogo.png" class="header-logo" style="border-top:none;height: 40px;margin-bottom:0;" /><br>
	                <strong>U.P. STATE INDUSTRIAL DEVELOPMENT CORPORATION LIMITED, KANPUR<br>
	                (Head Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024)</strong><br /><br />
                    <div style = "border-top:3px solid #ffc511;">&nbsp;</div> 
                    
                      <asp:PlaceHolder ID="ph" runat="server" />


                  
                    
                    <br/><br/>
                    <div class="row">
                        <label class="col-md-12 col-sm-12 col-xs-12 text-center" style="border-top:dashed"> </label>
                    </div>
                
                    <div class="row">
                       <table class="table table-bordered table-hover request-table">
                        
                        <tbody>
                        <tr style="background:#f7f7f7;">
                            <th colspan="2" style="text-align:center">  —————— ✂ For Office Use Only ✂ ——————  </th>
                        </tr>
                        <tr> 
                            
                            <td class="text-left"> Get Payment Confirmation</td> 
                            <td class="text-center">
                              <%--  <Button type="button" ID="btnAppliedFrom"  runat="server" class="accordion-toggle btn-default ey-payment  collapsed" data-toggle="collapse" style="font-size: 12px; background:#ff6a00; border:none; color:#fff" data-parent="#accordion" href="#payconfirmation">  
                                        <span class="glyphicon glyphicon-plus"></span>               
                                        Nivesh Mitra
                                 </Button> --%>
                                 <!--<asp:Button ID="btnAppliedthrough"  runat="server" Text="Nivesh Mitra<span class='glyphicon glyphicon-plus'></span> "  OnClick="btnAppliedthrough_Click"  style="font-size: 12px; background:#ff6a00; border:none; color:#fff"/>-->
                                <Button type="button" class="accordion-toggle btn-default ey-payment  collapsed pull-right" data-toggle="collapse" style="font-size: 12px; background:#ff6a00; border:none; color:#fff" data-parent="#accordion" href="#payconfirmation">                                                   
                                        Nivesh Mitra Single Window Clearance
                                 </Button> 
                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="panel-collapse alt-btn collapse" id="payconfirmation">
                                    <div class="form-group">
                                        <label class="col-md-2 col-sm-6 col-xs-6 border-rt">
                                            Control ID :
                                        </label>
                                        <div class="col-md-4 col-sm-6 col-xs-6 ">
                                            <asp:Label ID="lblControlId" runat="server" CssClass="font-bold"></asp:Label>
                                        </div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 border-rt">
                                            Unit ID :
                                        </label>
                                        <div class="col-md-4 col-sm-6 col-xs-6 ">
                                            <asp:Label ID="lblUnitId" runat="server"  CssClass="font-bold"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-2 col-sm-6 col-xs-6 border-rt">
                                            Service ID :
                                        </label>
                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblServiceId" runat="server"  CssClass="font-bold"></asp:Label>
                                        </div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 border-rt">
                                            ProcessIndustry ID :
                                        </label>
                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblProcessIndustryId" runat="server"  CssClass="font-bold"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-2 col-sm-6 col-xs-6 border-rt">
                                            Application ID :
                                        </label>
                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblApplicationId" runat="server"  CssClass="font-bold"></asp:Label>
                                        </div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 border-rt">
                                            Fee Amount :
                                        </label>
                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblFeeAmount" runat="server"  CssClass="font-bold"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-2 col-sm-6 col-xs-6 border-rt">
                                            Fee Status :
                                        </label>
                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblFeeStatus" runat="server"  CssClass="font-bold"></asp:Label>
                                        </div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 border-rt">
                                           Transaction ID:
                                        </label>
                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblTransactionId" runat="server"  CssClass="font-bold"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-2 col-sm-6 col-xs-6 border-rt">
                                            Transaction Date :
                                        </label>
                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblTransactionDate" runat="server"  CssClass="font-bold"></asp:Label>
                                        </div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 border-rt">
                                           Transaction Time :
                                        </label>
                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblTransactionTime" runat="server"  CssClass="font-bold"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-2 col-sm-6 col-xs-6 border-rt">
                                            Transaction DateTIme :
                                        </label>
                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblTransactionDatetime" runat="server"  CssClass="font-bold"></asp:Label>
                                        </div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 border-rt">
                                           Status Code :
                                        </label>
                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblStatusCode" runat="server"  CssClass="font-bold"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-2 col-sm-6 col-xs-6 border-rt">
                                            Remarks :
                                        </label>
                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblRemarks" runat="server"  CssClass="font-bold"></asp:Label>
                                        </div>
                                        <label class="col-md-2 col-sm-6 col-xs-6 ">
                                           
                                        </label>
                                        <div class="col-md-4 col-sm-6 col-xs-6">
                                            
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left">Put Your Comments and Remarks Here </td>
                            <td>
                                  <asp:TextBox ID="txtAmtCredited" width="100%" TextMode="MultiLine" style="border:none" runat="server"></asp:TextBox>
                            </td>
                            
                        </tr>
                        </tbody>

                       </table>
                    </div>
                    <br />
                   <%-- class="row"--%>
                    <div   class="disabled">
                         <label class="col-md-12 col-sm-12 col-xs-12 text-left"><b>Mode of Payment</b></label>  
                         <div class="col-md-6 col-sm-6 col-xs-12 text-left" style="border:dotted">
                             <table class="table table-bordered table-hover request-table">
                        
                                <tbody>
                                <tr style="background:#f7f7f7;">
                                    <th colspan="2" style="text-align:left">  <asp:RadioButton ID="rdOnline" GroupName="PaymentMode" AutoPostBack="true"  runat="server"  Text="Online" Checked="True" OnCheckedChanged="rdOnline_CheckedChanged" /> </th>
                                </tr>
                                <tr> 
                            
                                    <td class="text-left"> Transaction Date</td> 
                                    <td colspan="2" class="text-center">
                                        <asp:TextBox ID="txtTransDate" width="100%" CssClass="date" style="border:none" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr> 
                            
                                    <td class="text-left"> GateWay</td> 
                                    <td colspan="2" class="text-center">
                                        <asp:TextBox ID="txtGateway" width="100%" style="border:none" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr> 
                            
                                    <td class="text-left"> Transaction ID</td> 
                                    <td colspan="2" class="text-center">
                                        <asp:TextBox ID="txtTransID" width="100%" style="border:none" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr> 
                            
                                    <td class="text-left"> Amount</td> 
                                    <td colspan="2" class="text-center">
                                        <asp:TextBox ID="txtOnAmt" width="100%" style="border:none" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                        
                        
                                </tbody>
                                 

                              </table>
                              
                         </div>
                         <div class="col-md-6 col-sm-6 col-xs-12 text-left" style="border:dotted">
                             <table class="table table-bordered table-hover request-table">
                        
                                <tbody>
                                <tr style="background:#f7f7f7;">
                                    <th colspan="2" style="text-align:left">  <asp:RadioButton ID="rdOffline" AutoPostBack="true" GroupName="PaymentMode" runat="server"  Text="Offline" OnCheckedChanged="rdOffline_CheckedChanged"/> </th>
                                </tr>
                                <tr> 
                            
                                    <td class="text-left"> Payment Date</td> 
                                    <td colspan="2" class="text-center">
                                        <asp:TextBox ID="txtpayDate" width="100%" style="border:none" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr> 
                            
                                    <td class="text-left"> Payment Method</td> 
                                    <td colspan="2" class="text-center">
                                        <asp:TextBox ID="txtPayMethod" width="100%" style="border:none" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr> 
                            
                                    <td class="text-left"> Reference Number</td> 
                                    <td colspan="2" class="text-center">
                                        <asp:TextBox ID="txtrefno" width="100%" style="border:none" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr> 
                            
                                    <td clAmount Received</td> 
                                    <td colspan="2" class="text-center">
                                        <asp:TextBox ID="txtamtreceived" width="100%" style="border:none" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                        
                        
                                </tbody>
                                 

                              </table>
                              
                         </div>
                    </div>
                    
                    <br />
                    <div class="row text-left" style="border:1px solid #ddd">
                       
                         <label class="col-md-1 col-sm-1 col-xs-12 text-left">
                        Operation: 
                    </label>
                    <div class="col-md-2 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="drpOperate" width="100%" style="background:#fff;" AutoPostBack="false" CssClass="input-sm similar-select1" runat="server" OnSelectedIndexChanged="drpOperate_SelectedIndexChanged"></asp:DropDownList>
                    </div>  <div class="col-md-12 col-sm-12 col-xs-12 text-left">
                            <asp:CheckBox ID="chkAgree" AutoPostBack="true" runat="server"  Text="  I confirm that the information given in this form is true, complete and accurate. " OnCheckedChanged="chkAgree_CheckedChanged" />
                         </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 text-right">
                            <asp:Button ID="btnSave" style="background:#ff6a00; color:#fff; border:none; padding: 3px 8px 3px 8px;"  runat="server" Text="Save" OnClick="btnSave_Click" />
                        </div>

                    </div>
                    <br />

                    <div class="row" style="border-bottom:dashed">
                       <table class="table table-bordered table-hover request-table">
                        
                        <tbody>
                        <tr style="background:#f7f7f7;">
                            <th colspan="2" style="text-align:center">  —————— ✂ For Office Use Only ✂ ——————  e Only ✂ ——————  </th>
                        </tr>
                        
                       </tbody>
                         
                       </table>
                    </div>
                    <br />
                    <br />
                    <div style = "border-top:3px solid #ffc511;">&nbsp;</div> 	
                    <div class="mail-disclaimer">
	                <p class="text-justify"><strong>Disclaimer:</strong>The information contained in this Report  is intended solely for the use of the individual or entity to whom it is addressed and others authorized to receive it. It may contain confidential or legally privileged information. If you are not the intended recipient you are hereby notified that any disclosure, copying, distribution or taking any action in reliance on the contents of this information is strictly prohibited and may be unlawful. If you have received this Report in error, please notify us immediately by responding at info[at]upsidc[dot]com  and then delete it from your system. In case of any query please contact us at info[at]upsidc[dot]com.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
     
