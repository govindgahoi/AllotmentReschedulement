<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" Debug="true" EnableEventValidation="false" CodeBehind="AllotteeLedgerEntry.aspx.cs"
    Inherits="Allotment.AllotteeLedgerEntry" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <style>
        .box-panel {
            -webkit-box-shadow: 0 1px 1px transparent;
            box-shadow: 0 1px 1px transparent;
        }

        .box-back-none {
            background: none !important;
            box-shadow: inset 0px 1px 1px transparent !important;
        }

        .tooltip {
            position: absolute;
            top: 0;
            left: 0;
            z-index: 3;
            display: none;
            background-color: #FB66AA;
            color: White;
            padding: 5px;
            font-size: 10pt;
            font-family: Arial;
        }

        td {
            cursor: pointer;
        }
    </style>

    <script type="text/javascript">




        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

    function PageLoaded(sender, args) {
        $(".chosen").chosen();
    }
    
   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>



    <%--<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">



        <ContentTemplate>--%>
            

            <%--<asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                <ProgressTemplate>
                    <div class="fgh">
                        <div class="hgf">
                            <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>



          
            
            <cc1:MessageBox ID="MessageBox1" runat="server" />
            <cc1:ConfirmBox ID="ConfirmBox1" runat="server" />

        
                <div class="row">
                    <asp:Label ID="RateIdlbl" runat="server" Visible="false"></asp:Label>
                    <div class="panel">
                        <div class="">
                            <div class="col-md-12">
                                <div class="panel-heading font-bold" style="text-align: center;">
                                    Allottee Ledger Entry                         
                                </div>
                                <div class="panel-body">

                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Regional Office :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:DropDownList ID="dlregion" runat="server" CssClass="chosen input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="dlregion_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Name of Industrial Area :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:DropDownList ID="IaDdl" runat="server" CssClass="chosen input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="IaDdl_SelectedIndexChanged" ></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                     <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Allottee Details :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:DropDownList ID="drp_Allottee" runat="server" CssClass="chosen input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="drp_Allottee_SelectedIndexChanged" ></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group" style="display: none;">
                                        <div class="col-md-12 col-sm-12" style="text-align: right; padding: 10px 0;">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" />
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <asp:Label ID="msg" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
               <br /><br />
                <div class="row"  runat="server" id="Summary_Div">
                    <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-12 font-bold text-center" style="margin-top: 12px;">
                                    Allottee Ledger
                                     
                        <ul class="pull-right list-inline">
                    <li>
                        <a runat="server" onclick="PrintElemF()" style="cursor:pointer;">
                            <i style="font-size: 18px;" class="fa fa-print" aria-hidden="true"></i>
                        </a>
                    </li>
                    
                </ul>
                        
                                </div>
                                
                                <div class="clearfix"></div>

                            </div>
                            <div  class="panel-body table-responsive">
                                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                                <div>
                                    <table class="table table-striped table-bordered table-hover request-table">
                                        <tr>
                                            <td>Regional Office</td><td><asp:Label runat="server" ID="lbl_RegionalOffice" ></asp:Label></td>
                                            <td>Industrial Area</td><td><asp:Label runat="server" ID="lbl_IA" ></asp:Label></td>
                                        </tr>
                                         <tr>
                                            <td>Allottee Name</td><td><asp:Label runat="server" ID="lbl_Allottee" ></asp:Label></td>
                                            <td>Plot No</td><td><asp:Label runat="server" ID="lblPlot" ></asp:Label></td>
                                        </tr>
                                    </table>
                                    <br />
                                <asp:GridView ID="AllotteePaymentSummaruGrid" runat="server" ShowFooter="true" AutoGenerateColumns="false"  CssClass="table table-striped table-bordered table-hover request-table" OnRowDataBound="AllotteePaymentSummaruGrid_RowDataBound">
                                    <Columns>

                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField ="PaymentName"   HeaderText ="Payment Head"/>
                                        <asp:BoundField DataField ="Demanded"      HeaderText ="Demanded"    />
                                        <asp:BoundField DataField ="Paid"          HeaderText ="Paid"     />                                      
                                        <asp:BoundField DataField ="Outstanding"   HeaderText ="Outstanding"           />
                                       
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                    </div>
                            </div>
                        </div>
                    </div>
                </div>
               <br /><br />
                <div class="row">
                    <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                    <div class="panel">
                        <div class="">
                            <div class="col-md-12">
                                <div class="panel-heading font-bold" style="text-align: center;">
                                    Allottee Payment Entry                        
                                </div>
                                <div class="panel-body">

                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-1 col-sm-12 text-center">
                                                <span style="color: Red">*</span>
                                                 Date :
                                            </label>
                                             <label class="col-md-2 col-sm-12 text-center">
                                                <span style="color: Red">*</span>
                                                Payment Head :
                                            </label>
                                             <label class="col-md-3 col-sm-12 text-center">
                                                <span style="color: Red">*</span>
                                                Description(Demand No/Payment Details) :
                                            </label>
                                             <label class="col-md-2 col-sm-12 text-center">
                                                <span style="color: Red">*</span>
                                                Debit/Credit :
                                            </label>
                                            <label class="col-md-1 col-sm-12 text-center">
                                                
                                                 <asp:Label runat="server" ID="lblPaymentDateType"></asp:Label>
                                            </label>
                                            
                                             <label class="col-md-1 col-sm-12 text-center">
                                                <span style="color: Red">*</span>
                                               Amount :
                                            </label>
                                            <label class="col-md-2 col-sm-12 text-center"></label>
                                               
                                            
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                           <div class="col-md-1 col-sm-12">
                                              <asp:TextBox ID="txtTransactionDate" runat="server"  class="date input-sm similar-select1"></asp:TextBox>
                                                   
                                            </div>
                                            <div class="col-md-2 col-sm-12">
                                                <asp:DropDownList ID="ddl_PaymentHead" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="ddl_PaymentHead_selectedindex_changed"  CssClass="chosen input-sm dropdown-toggle similar-select1"  ></asp:DropDownList>
                                            </div>
                                             <div class="col-md-3 col-sm-12">
                                                   <asp:TextBox ID="txtDescription" runat="server" ToolTip="only text Value" class="input-sm similar-select1"></asp:TextBox>                                           
                                            </div>
                                            <div class="col-md-2 col-sm-12">
                                                <asp:DropDownList ID="ddl_PayStatus" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="ddl_PayStatus_selectedindex_changed" CssClass="chosen input-sm dropdown-toggle similar-select1"  >
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                     <asp:ListItem Value="1">Debit-Demanded</asp:ListItem>
                                                     <asp:ListItem Value="2">Credit-Paid</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                           <div class="col-md-1 col-sm-12">
                                              <asp:TextBox ID="txtPaymentDate" runat="server"  class="date input-sm similar-select1"></asp:TextBox>
                                                   
                                            </div>
                                           
                                              <div class="col-md-1 col-sm-12">
                                                   <asp:TextBox ID="txtAmount" runat="server" ToolTip="only text Value" class="sinput-sm similar-select1"></asp:TextBox>                                           
                                            </div>
                                            <div class="col-md-2 col-sm-12" >
                                            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-sm btn-primary" Text="Add" OnClick="btnAdd_Click" />
                                            <asp:Button ID="btnClar" runat="server" CssClass="btn btn-sm btn-primary" Text="Clear" OnClick="btnClar_Click" />
                                        </div>
                                        </div>
                                    </div>
                          
                   
           
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
      
                                    <div class="clearfix"></div>
                                    <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
               <br /><br />  
                <div class="row"  runat="server" id="Journal_Div">          
                <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-12 font-bold text-center" style="margin-top: 12px;">
                                    Allottee Journal
                                    <ul class="pull-right list-inline">
                    <li>
                        <a runat="server" onclick="PrintElem()" style="cursor:pointer;">
                            <i style="font-size: 18px;" class="fa fa-print" aria-hidden="true"></i>
                        </a>
                    </li>
                    
                </ul>
                                </div>
                                
                                <div class="clearfix"></div>

                            </div>

                            <div class="panel-body gallery  table-responsive">
                                <table class="table table-striped table-bordered table-hover request-table">
                                        <tr>
                                            <td>Regional Office</td><td><asp:Label runat="server" ID="lbl_RegionalOffice1"></asp:Label></td>
                                            <td>Industrial Area</td><td><asp:Label runat="server" ID="lbl_IA1" ></asp:Label></td>
                                        </tr>
                                         <tr>
                                            <td>Allottee Name</td><td><asp:Label runat="server" ID="lbl_Allottee1"></asp:Label></td>
                                            <td>Plot No</td><td><asp:Label runat="server" ID="lbl_PlotNo1" ></asp:Label></td>
                                        </tr>
                                    </table>
                                <br />
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                            <asp:GridView ID="AllotteeJournalGrid" runat="server" AutoGenerateColumns="false"  CssClass="table table-striped table-bordered table-hover request-table"
                             OnRowCommand="AllotteeJournalGrid_RowCommand" OnRowDataBound="AllotteeJournalGrid_RowDataBound">
                                    <Columns>

                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField ="TransactionDate" HeaderText ="Transaction Date"/>
                                        <asp:BoundField DataField ="PaymentName"     HeaderText ="Payment Head"    />
                                        <asp:BoundField DataField ="Description"     HeaderText ="Description"     />                                      
                                        <asp:BoundField DataField ="Debit"           HeaderText ="Debit"           />
                                       <asp:BoundField DataField ="DueDate"           HeaderText ="Due Date"           />
                                        <asp:BoundField DataField ="Credit"          HeaderText ="Credit"          />
                                        <asp:BoundField DataField ="PaymentDate"          HeaderText ="Payment Date"          />
                                       
                                         <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEntryBy" runat="server" Text='<%# Eval("EntryBy").ToString()%>'> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Update">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" Visible='<%# Eval("EntryBy").ToString() == "System" ? false : true %>' CommandArgument='<%#Eval("TransactionDate")+"|"+ Eval("PaymentHeadID")+"|"+ Eval("Description")+"|"+ Eval("Debit")+"|"+ Eval("Credit")+"|"+ Eval("ID")+"|"+ Eval("PayStatus")+"|"+ Eval("Amount")+"|"+ Eval("DueDate")+"|"+ Eval("PaymentDate") %>' CommandName="Process" ToolTip="Click here For Update record " />
                                         
                                                </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Delete">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" Visible='<%# Eval("EntryBy").ToString() == "System" ? false : true %>' CommandName="DeleteRow" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" ToolTip="Click here to delete row" CommandArgument='<%#Eval("ID") %>'  />
                                                </span>  
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
           </div>

       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>

    
    
    <script type="text/javascript">
         function hideColumn() {
        var gridrows = $("#AllotteeJournalGrid tbody tr");

        for (var i = 0; i < gridrows.length; i++) {
            gridrows[i].cells[6].style.display = "none";
              gridrows[i].cells[7].style.display = "none";
        }
        return false;

    };
    
      function PrintElemF() {

                Popup($('#ContentPlaceHolder1_Summary_Div').html());
        }

        function PrintElem() {
          

                Popup1($('#ContentPlaceHolder1_Journal_Div').html());
            }


        function Popup1(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=1000');

            mywindow.document.write('<html><head><title style="font-weight:bold;">Allottee Payment Report</title>');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/bootstrap.min.css\" type=\"text/css\" />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/theme.css\" type=\"text/css\"  />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/print.css\" type=\"text/css\"  />');
            mywindow.document.write('</head><body >');
            mywindow.document.write(data);
            mywindow.document.write('</body></html>');
            var rows = mywindow.document.getElementById('<%=AllotteeJournalGrid.ClientID %>').rows;
            for (i = 0; i < rows.length; i++) {
                rows[i].cells[6].style.display = "none";
            }

            for (j = 0; j < rows.length; j++) {
                rows[j].cells[7].style.display = "none";
            }
            setTimeout(function () {
                mywindow.print();
                mywindow.close();
            }, 1000);


            return true;
        }
        function Popup(data) {
                var mywindow = window.open('', 'my div', 'height=2000,width=1000');
              
                mywindow.document.write('<html><head><title style="font-weight:bold;">Allottee Payment Report</title>');
                mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/bootstrap.min.css\" type=\"text/css\" />');
                mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/theme.css\" type=\"text/css\"  />');
                mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/print.css\" type=\"text/css\"  />');
                mywindow.document.write('</head><body >');
                mywindow.document.write(data);
                mywindow.document.write('</body></html>');
                 
                setTimeout(function ()
                {
                    mywindow.print();
                    mywindow.close();
                }, 1000);


                return true;
            }
              
    </script>


</asp:Content>
