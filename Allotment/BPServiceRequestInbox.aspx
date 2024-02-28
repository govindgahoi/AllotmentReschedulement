<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="BPServiceRequestInbox.aspx.cs" Inherits="Allotment.BPServiceRequestInbox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register assembly="ProudMonkey.Common.Controls" namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %>
<%@ Register Src="~/UC_Service_Building_Plan.ascx" TagPrefix="uc1" TagName="UC_Service_Building_Plan" %>
<%@ Register Src="~/UC_Service_Approval.ascx" TagPrefix="uc1" TagName="UC_Service_Approval" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <script  type="text/javascript">


           function ShowMessage(parp,message11) {
               alert(message11);
               window.location.href = parp;
           }

           var prm = Sys.WebForms.PageRequestManager.getInstance();
           prm.add_endRequest(function (sender, e) {
               $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });

               function ShowMessage(parp, message11) {
                   alert(message11);
                   window.location.href = parp;
               }

           });
  </script>



        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" >
</asp:ScriptManager>



    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
       
   <ContentTemplate>
      <asp:UpdateProgress ID="UpdWaitImage" runat="server"  DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                 <ProgressTemplate>
                 <div class="fgh">
                 <div class="hgf">
                                <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>   
                               </div>
                               </div>
       </ProgressTemplate>
       </asp:UpdateProgress>




       <cc1:MessageBox ID="MessageBox1" runat="server" /> 
                     <cc1:ConfirmBox ID="ConfirmBox1" runat="server" />  

       <div class="">
            
            <div class="row" id="SideDiv">
                <div class="col-md-12">
                      <asp:Label ID="lblserRequest" Visible="false" runat="server" ></asp:Label>
                  
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row well well-large offset4">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                    <span><b>Service Request - <asp:Label ID="headertext" runat="server"></asp:Label> </b></span>
                                    <span style=" float:right !important;color:red;""> <asp:Label ID="lblRole" runat="server" style="margin-right:10px;"></asp:Label>
                                            </span>
                                 
                                    </div>
                                    

                                    <div class="panel-body">
                                 




             <div class="panel panel-default">
              <%--  <div class="panel-heading" style="width: 100%;">
                    <div class="row">
                      <div class="col-md-12">

                            <div class="col-md-2">
                                <div class="btn-group">
                </div>
                            </div>
                            <div class="col-md-4">
                                <p></p>
                            </div>
                            <div class="col-md-6 btn-group">
                                <div class="btn-group">
                     </div>
                            </div>
                        </div>
                    </div>
                </div>--%>

                 <br />
                 <div class="panel-body ">


                     <asp:PlaceHolder runat="server" ID="Placeholder1"    />

            


           <div runat="server" id="transferDataDiv" visible="false">
                    <div class="panel-heading font-bold">Application form  Data for Transfer of Industrial Plot</div>
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Plot No :
                        </label>
                        <div class="col-md-9">
                            <asp:Label ID="lblPlotNo" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Name of the Area :
                        </label>
                        <div class="col-md-9">
                            <asp:Label ID="lblAreaName" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Name of Allottee :
                        </label>
                        <div class="col-md-9">
                            <asp:Label ID="lblNameofAllottee" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Tel. No. :
                        </label>
                        <div class="col-md-9">
                            <asp:Label ID="lblTelNo" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            GIR/PAN No. :
                        </label>
                        <div class="col-md-9">
                            <asp:Label ID="lblPanNo" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Name of Proposed Transferee :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtProposedTransfereeName" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Address of Proposed Transferee :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtProposedTransfereeAddress" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Tel. No. :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtTransfereeTelNo" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            GIR/PAN No. :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtTransfereePan" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Reason of Transfer :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox TextMode="MultiLine"  ID="txtReasonofTransfer"  runat="server" CssClass="similar-select1 margin-left-z input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />

                   

                 <div id="tblProjectDetails">
                <p class="panel-heading"><b>Transferee Project Details</b></p>
            <p class="panel-heading font-bold" >Type of industry to be set up</p>
            <div class="form-group">
                <div class="row">
                    <label class="col-md-4 text-right">
                        Description :
                    </label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txttypeofindustry" runat="server" CssClass="input-sm similar-select1 margin-left-z" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
           <hr class="myhrline" />
           <p class="panel-heading font-bold" >Project Costing Details</p>
            <div class="form-group">
                <div class="row">
                    <label class="col-md-4 text-right">
                        Estimated Cost of the project&nbsp;(In Lacs)&nbsp;:
                    </label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtestimatedcost" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                    </div>
                 </div>
            </div>
            <div class="clearfix"></div>
           <hr class="myhrline" />
           <div class="form-group">
               <div class="row">
                    <label class="col-md-4 text-right">
                        Estimated employment generation&nbsp;:
                    </label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtestimatedemployment" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
           <hr class="myhrline" />
           <p class="panel-heading font-bold" >Layout plan of land</p>
            <div class="form-group">
                <div class="row">
                    <label class="col-md-4 text-right">
                        Covered Area&nbsp;(In %)&nbsp;:
                    </label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtcoveredarea" runat="server" CssClass="input-sm similar-select1" onkeypress="return txtLeaseDeed_keypress()"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
           <hr class="myhrline" />
           <div class="form-group">
               <div class="row">
                    <label class="col-md-4 text-right">
                        Open area required and its purpose:
                    </label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtopenarearequired" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
           <hr class="myhrline" />
           <p class="panel-heading font-bold">Details of the investment(in Rs)</p>
           <div class="form-group">
               <div class="row">
                    <label class="col-md-4 text-right" title="date ofsubmission">
                        Land&nbsp;(In Lacs)&nbsp;:
                    </label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtland" CssClass="input-sm similar-select1" runat="server" ></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
           <hr class="myhrline" />
           <div class="form-group">
               <div class="row">
                    <label class="col-md-4 text-right">
                        Building&nbsp;(In Lacs)&nbsp;:
                    </label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtbuilding" CssClass="input-sm similar-select1" runat="server" ></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
           <hr class="myhrline" />
           <div class="form-group">
               <div class="row">
                    <label class="col-md-4 text-right">
                        Machinery & Equipments&nbsp;(In Lacs)&nbsp;:
                    </label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtmachinery" CssClass="input-sm similar-select1" runat="server" ></asp:TextBox>
                    </div>
                </div>
             </div>
            
            <div class="clearfix"></div>
                                                 <hr class="myhrline" />
           <div class="form-group">
                <label class="col-md-4 text-right">
                    Other Fixed Assets&nbsp;(In Lacs)&nbsp;:
                </label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtFixedAssets" CssClass="input-sm similar-select1" runat="server" ></asp:TextBox>

                </div>
             </div>
            
            <div class="clearfix"></div>
                                                <hr class="myhrline" />
           <div class="form-group">
                <label class="col-md-4 text-right">
                    Other Expenses&nbsp;(In Lacs)&nbsp;:
                </label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtOtherExpenses" CssClass="input-sm similar-select1" runat="server" ></asp:TextBox>

                </div>
             </div>
            
            <div class="clearfix"></div>
     <%--      <hr class="myhrline" />
           <p class="panel-heading">Any fumes generated in the process of manufacture if so, their nature and quantity &nbsp; <span class="checkbox-inline" style="padding-bottom:20px;"><asp:CheckBox runat="server" ID="chkfumes"/></span></p>
     --%>   
                     <div id="fumesdiv" runat="server" visible="false">
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-4 text-right">
                            Nature&nbsp;:
                        </label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtfumenature" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
               <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-4 text-right">
                            Quantity&nbsp;:
                        </label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtfumeqty" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
               <hr class="myhrline" />
            </div>
 </div>       
         

                          
         <div class="panel panel-default">
               <div class="panel-heading font-bold">Industrial Effluents </div>
               <div class="panel-body" style="padding: 0px !important;">

                   <table class="table table-bordered table-hover request-table">
                    <tr>
                        <th>Name</th>
                        <th>Quantity</th>
                        <th>Chemical Composition</th>
                    </tr>
                    <tr>
                        <td><span class="pull-right">(i)&nbsp;Solid :</span></td>
                        <td><asp:TextBox ID="txteffluentsolidqty" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox ID="txteffluentsolidcomposition" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width:33.7%;"><span class="pull-right">(ii)&nbsp;Liquid :</span></td>
                        <td><asp:TextBox ID="txteffluentliquidqty" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox ID="txteffluentliquidcomposition" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><span class="pull-right">(iii)&nbsp;Gaseous :</span></td>
                        <td><asp:TextBox ID="txteffluentgaseousqty" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox ID="txteffluentgaseouscomposition" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
                    </tr>

                </table>

               </div>
           </div>

                            
         
          <div class="panel panel-default">
               
               <div class="panel-body" style="padding: 0px !important;">

                   
                   <div class="form-group">
                       <div class="row">
                           <label class="col-md-4 text-right">
                               Effluent Treatment Measures :
                           </label>
                           <div class="col-md-8 col-sm-6 col-xs-12 form-inline font-12px">
                               <asp:TextBox ID="txteffluenttreatmentmeasure1" CssClass="input-sm similar-select1"  runat="server"></asp:TextBox><br/><hr class="myhrline" />
                               <asp:TextBox ID="txteffluenttreatmentmeasure2" CssClass="input-sm similar-select1"  runat="server"></asp:TextBox><br /><hr class="myhrline" />
                               <asp:TextBox ID="txteffluenttreatmentmeasure3" CssClass="input-sm similar-select1" runat="server"></asp:TextBox><br /><hr class="myhrline" />
                           </div>
                        </div>
                   </div>
                   <div class="clearfix"></div>
               
           </div>
<div class="clearfix"></div>
               <div class="panel panel-default">
               <div class="panel-heading font-bold">Power Requirement (in KW)</div>
               <div class="panel-body" style="padding: 0px !important;">
                   <div class="row aks-row">                        
                           <label class="col-md-4 col-sm-6 col-xs-12 form-inline text-right">
                               Units &nbsp;:
                           </label>
                           <div class="col-md-8 col-sm-6 col-xs-12">
                               <asp:TextBox ID="txtpowerreq" CssClass="input-sm similar-select1"  runat="server"></asp:TextBox>                                       
                           </div>                            
                   </div>
               </div>
           </div>
            <div class="clearfix"></div>


            <div class="panel panel-default">
     <%--          <div class="panel-heading">Is the applicant under priority category ? Please specify clearly &nbsp; <span class="checkbox-inline" style="padding-bottom:20px;">
                   <asp:CheckBox runat="server" ID="chkpriority" /></span></div>
     --%>          <div id="prioritydiv" class="panel-body" style="padding: 0px !important;" runat="server" visible="true">
                   <div class="row aks-row">
                       <div class="col-md-4 col-sm-6 col-xs-12">
                        priority category  Specification&nbsp;:
                       </div>
                       <div class="col-md-8 col-sm-6 col-xs-12">
                           <asp:TextBox ID="txtapplicantpriorityspecification"  CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                       </div>
                   </div>
               </div>
           </div>
          </div>    

                              </div> 




            <div runat="server" id="plot_allotment" visible="false" class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="width: 100%;">
                                <div class="row">
                                    <div class="col-md-12">
                          


<asp:Label ID="LblAllotteeId" runat="server" Visible="false"></asp:Label>

                                        
                                        <div class="col-md-12">
                                            <p style="font-weight:bold;text-align:center;">Allotee Application Request View</p>
                                        </div>

                                      
                                    </div>
                                </div>
                            </div>
       <div class="row">
                    <div class="col-lg-5">

                        <div class="panel panel-default">
                            <div class="panel-heading" style="text-align: center;font-weight:bold;">
                               Company Details                         
                            </div>
                            <div class="panel-body" style="padding: 0px !important;">
                                <div class="list-group" style="padding: 6px !important;">

                                    

                                    <a class="list-group-item" style="padding: 6px !important;">Date Of Application :                                  
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="Label13" runat="server"></asp:Label></em>
                                    </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;">Plot Size :                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="Label14" runat="server"></asp:Label></em>
                                    </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;">Industrial Area :                                  
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="Label23" runat="server"></asp:Label></em>
                                    </span>
                                    </a>

                                    <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Firm/Company Name :   </span>
                                        <span class="pull-right text-muted small"><em>
                                            <asp:Label ID="Label24" runat="server"></asp:Label></em>
                                        </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Firm/Company Constitution :   </span>
                                        <span class="pull-right text-muted small"><em>
                                            <asp:Label ID="Label25" runat="server"></asp:Label></em>
                                        </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Firm/Company Pan No :   </span>
                                        <span class="pull-right text-muted small"><em>
                                            <asp:Label ID="Label26" runat="server"></asp:Label></em>
                                        </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Firm/Company Cin No :   </span>
                                        <span class="pull-right text-muted small"><em>
                                            <asp:Label ID="Label27" runat="server"></asp:Label></em>
                                        </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;"><span style="text-align: left;">Authorised Signatory :   </span>
                                        <span class="pull-right text-muted small"><em>
                                            <asp:Label ID="Label28" runat="server"></asp:Label></em>
                                        </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;">Signatory Mobile :                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="Label29" runat="server"></asp:Label></em>
                                    </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;">Signatory Email :                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="Label30" runat="server"></asp:Label></em>
                                    </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;">Address :                                   
                                    <span class="pull-right text-muted small"><em>
                                        <asp:Label ID="Label31" runat="server"></asp:Label></em>
                                    </span>
                                    </a>
                                    <a class="list-group-item" style="padding: 6px !important;">Current Status :                                   
                                    <span class="pull-right text-muted small" style="font-weight:bold;color:red;"><em>
                                        <asp:Label ID="Label1" runat="server"> </asp:Label></em>
                                    </span>
                                    </a>

                                </div>


                            </div>
                        </div>
                    </div>

                    <div class="col-lg-7">


                                        <div class="panel panel-default">
                                            <p class="panel-heading" style="text-align: center;font-weight:bold;" runat="server" id="P2">Request for Allottee/Transfree Registration (4/5)</p>
                                            <div class="panel-body gallery  table-responsive">
                                                <asp:Label ID="Label32" runat="server" Text=""></asp:Label>
                                                <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false"
                                                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
                                                    <Columns>


                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label16" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                </asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="AllotteeName" HeaderText="Name" SortExpression="AllotteeName" />
                                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                        <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                        <asp:BoundField DataField="emailID" HeaderText="EmailId" SortExpression="EmailId" />

                                                    </Columns>
                                                </asp:GridView>

                                                <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="false"
                                                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                                    <Columns>


                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label17" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                </asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="DirectorName" HeaderText="Director Name" SortExpression="DirectorName" />
                                                        <asp:BoundField DataField="DIN_PAN" HeaderText="Din/Pan" SortExpression="DIN_PAN" />
                                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                        <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="Phone" />
                                                        <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                    </Columns>

                                                  
                                                </asp:GridView>

                                                <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="false"
                                                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                                    <Columns>


                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                </asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ShareholderName" HeaderText="Shareholder Name" SortExpression="ShareholderName" />
                                                        <asp:BoundField DataField="SharePer" HeaderText="Share %" SortExpression="SharePer" />
                                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                        <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                        <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                    </Columns>

                                                    <EmptyDataTemplate>
                                                        No Record Available
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                                 <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="false"
                                                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                                    <Columns>


                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label18" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                </asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PartnerName" HeaderText="Partner Name" SortExpression="PartnerName" />
                                                        <asp:BoundField DataField="PartnershipPer" HeaderText="Partnership %" SortExpression="PartnershipPer" />
                                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                        <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                        <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                    </Columns>

                                                    <EmptyDataTemplate>
                                                        No Record Available
                                                    </EmptyDataTemplate>
                                                </asp:GridView>

                                                <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="false"
                                                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                                    <Columns>


                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label19" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                </asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="TrusteeName" HeaderText="Trustee Name" SortExpression="TrusteeName" />
                                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                        <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="Phone" />
                                                        <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                    </Columns>

                                                    <EmptyDataTemplate>
                                                        No Record Available
                                                    </EmptyDataTemplate>
                                                </asp:GridView>

                                                <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="false"
                                                    AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                                    <Columns>


                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label20" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                </asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="AllotteeName" HeaderText="Individual Name" SortExpression="AllotteeName" />
                                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                        <asp:BoundField DataField="Phone" HeaderText="Phone No" SortExpression="PhoneNo" />
                                                        <asp:BoundField DataField="Email" HeaderText="EmailId" SortExpression="EmailId" />

                                                    </Columns>
                                                </asp:GridView>


                                            </div>
                                        </div>

                                    </div>

                </div>

                          
</div></div>

      <div class="row">
    <div class="col-lg-12">
    <div class="panel panel-default">
        <div class="panel-heading" style="text-align:center;">
            Allottee Project Details                        
        </div>
        <div class="panel-body ">
        <div class="panel panel-default">
            <div class="panel-heading" >Type of industry to be set up</div>
            <div class="panel-body" style="padding: 0px !important;">
                <div class="form-group">
                    <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                        <label for="">Description&nbsp;:</label>
                    </label>
                    <div class="col-md-9 col-sm-6 col-xs-12">
                        <asp:Label ID="Label12" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading" >Project Costing Details</div>
            <div class="panel-body" style="padding: 0px !important;">
                <div class="form-group">
                    <div class="col-md-3 col-sm-6 col-xs-12 text-right">
                        <label for="">Estimated Cost Of the project&nbsp;:</label>
                    </div>
                    <div class="col-md-9 col-sm-6 col-xs-12">
                        <asp:Label ID="Label33" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div  class="form-group">
                    <div class="col-md-3 col-sm-6 col-xs-12 text-right">
                        <label for="">Estimated employment generation&nbsp;:</label>
                    </div>
                    <div class="col-md-9 col-sm-6 col-xs-12">
                        <asp:Label ID="Label34" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
            </div>
        </div>


           <div class="panel panel-default">
               <div class="panel-heading">Layout plan of land indicating broadly</div>
               <div class="panel-body" style="padding: 0px !important;">
                   <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                           Covered Area&nbsp;(In %)&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                          <asp:Label ID="Label35" runat="server"></asp:Label>
                       </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div  class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                           Open area required and its purpose&nbsp;(In %)&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                         <asp:Label ID="Label36" runat="server"></asp:Label>
                       </div>
                   </div>
                   <div class="clearfix"></div>
                    <hr class="myhrline" />
               </div>
           </div>



           <div class="panel panel-default">
               <div class="panel-heading">Details of the investment(in Rs)</div>
               <div class="panel-body" style="padding: 0px !important;">
                   <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right" title="date ofsubmission">
                           Land&nbsp;(In Lacs)&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                          <asp:Label ID="Label37" runat="server"></asp:Label>
                       </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                           Building&nbsp;(In Lacs)&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                           <asp:Label ID="Label38" runat="server"></asp:Label>
                       </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right" >
                           Machinery & Equipments&nbsp;(In Lacs)&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                          <asp:Label ID="Label39" runat="server"></asp:Label>
                       </div>                     
                   </div>
                   <div class="clearfix"></div>
                   <hr class="myhrline" />
                    <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right" >
                           Other Fixed Assets&nbsp;(In Lacs)&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                          <asp:Label ID="Label40" runat="server"></asp:Label>
                       </div>                     
                   </div>
                   <div class="clearfix"></div>
                   <hr class="myhrline" />
                    <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right" >
                           Other Expenses&nbsp;(In Lacs)&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                          <asp:Label ID="Label41" runat="server"></asp:Label>
                       </div>                     
                   </div>
                   <div class="clearfix"></div>
                    <hr class="myhrline" />

                   </div>
               </div>
          


          <div class="panel panel-default">
               <div class="panel-heading">Any fumes generated in the process of manufacture and if so, their nature and quantity &nbsp; <span runat="server" id="Span1"></span></div>
               <div class="panel-body" style="padding: 0px !important;" id="Div2" runat="server" visible="false">
                   <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                           Nature&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                            <asp:Label ID="Label42" runat="server"></asp:Label>
                       </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                       <label class="col-md-3 col-sm-6 col-xs-12 text-right">
                           Quantity&nbsp;:
                       </label>
                       <div class="col-md-9 col-sm-6 col-xs-12">
                           <asp:Label ID="Label43" runat="server"></asp:Label>
                       </div>
                   </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
               </div>
           </div>


         
         <div class="panel panel-default">
               <div class="panel-heading">Industrial Effluents </div>
               <div class="panel-body" style="padding: 0px !important;">
                   <table class="table table-hover table-bordered request-table" style="width:100%;">
                       <tr>
                           <td style="width:24%;">Name</td>
                           <td style="width:38%;">Quantity</td>
                           <td style="width:38%;">Chemical Composition</td>
                       </tr>
                       <tr>
                           <td><span class="pull-right">(i)&nbsp;Solid :</span></td>
                           <td><asp:Label ID="Label44" runat="server"></asp:Label></td>
                           <td><asp:Label ID="Label45" runat="server"></asp:Label></td>
                       </tr>
                       <tr>
                           <td><span class="pull-right">(ii)&nbsp;Liquid :</span></td>
                           <td><asp:Label ID="Label46" runat="server"></asp:Label></td>
                           <td><asp:Label ID="Label47" runat="server"></asp:Label></td>
                       </tr>
                       <tr>
                           <td><span class="pull-right">(iii)&nbsp;Gaseous :</span></td>
                           <td><asp:Label ID="Label48" runat="server"></asp:Label></td>
                           <td><asp:Label ID="Label49" runat="server"></asp:Label></td>
                       </tr>
                   </table>



               </div>
           </div>

                            
         
          <div class="panel panel-default">
               <div class="panel-heading">Effluent Treatment Measures</div>
               <div class="panel-body" style="padding: 0px !important;">


                   <div class="row aks-row">

                       <div class="col-md-4 col-sm-6 col-xs-12 form-inline font-12px"><asp:Label ID="Label50" runat="server"></asp:Label></div>

                       <div class="col-md-4 col-sm-6 col-xs-12 form-inline font-12px">
                           <asp:Label ID="Label51" runat="server"></asp:Label>
                                       
                       </div>

                     

                       <div class="col-md-4 col-sm-6 col-xs-12 form-inline font-12px"><asp:Label ID="Label52" runat="server"></asp:Label></div>

                   </div>
               </div>
           </div>
            <div class="clearfix"></div>
                
               <div class="panel panel-default">
               <div class="panel-heading">Power Requirement (in KW)</div>
               <div class="panel-body" style="padding: 0px !important;">


                   <div class="form-group">

                       <label class="col-md-3 col-sm-6 col-xs-12 form-inline text-right">Units &nbsp;:</label>

                       <div class="col-md-9 col-sm-6 col-xs-12">
                        <asp:Label ID="Label53" runat="server"></asp:Label>
                                       
                       </div>

                 
                   </div>
                   <div class="clearfix"></div>
                    <hr class="myhrline" />
               </div>
           </div>

            <div class="panel panel-default">
               <div class="panel-heading">Telephone Requirement</div>
               <div class="panel-body" style="padding: 0px !important;">


                   <div class="form-group">

                       <div class="col-md-3 col-sm-6 col-xs-12 text-right">First Year&nbsp;:</div>

                       <div class="col-md-3 col-sm-6 col-xs-12">
                           <asp:Label ID="Label54" runat="server"></asp:Label>
                                       
                       </div>
                       <div class="col-md-3 col-sm-6 col-xs-12">
                       <asp:Label ID="Label55" runat="server"></asp:Label>
                                       
                       </div>
                 
                   </div>
                   <div class="clearfix"></div>
                <hr class="myhrline" />
                     <div class="form-group">
                       <div class="col-md-3 col-sm-6 col-xs-12 text-right">Ultimate Requirement&nbsp;:</div>

                       <div class="col-md-3 col-sm-6 col-xs-12">
                          <asp:Label ID="Label56" runat="server"></asp:Label>
                                       
                       </div>
                       <div class="col-md-3 col-sm-6 col-xs-12">
                          <asp:Label ID="Label57" runat="server"></asp:Label>
                                       
                       </div>
                 </div>
                   <div class="clearfix"></div>
                    <hr class="myhrline" />
                   </div>
               </div>


            <div class="panel panel-default">
               <div class="panel-heading">Is the applicant under priority category ? Please specify clearly &nbsp; <span runat="server" id="Span2"></span></div>
               <div id="Div3" class="panel-body" style="padding: 0px !important;" runat="server" visible="false">
                   <div class="row aks-row">
                      

                       <div class="col-md-3 col-sm-6 col-xs-12">Specification&nbsp;:</div>

                       <div class="col-md-3 col-sm-6 col-xs-12"><asp:Label ID="Label58" runat="server"></asp:Label></div>

                   </div>
               </div>
           </div>



           </div>
                    </div>
                </div>
                                     

                          </div>
</div>




                     <div id="datatableService" class="table-responsive" runat="server" visible="false">

                         

                       

                             <div style="text-align: left">
                                 <span class="font-12px">Plot Size :</span>
                                 <asp:Label ID="lblPlotSize" runat="server" Text="" CssClass="font-12px"></asp:Label>
                             </div>

                             <table class="table table-bordered table-hover request-table" width="100%" cellspacing="0">
                                 <thead>
                                     <tr>
                                         <th style="width: 150px !important">Description</th>
                                         <th style="width: 10px !important">Byelaws </th>
                                         <th>Unit</th>
                                     </tr>
                                 </thead>
                                 <tbody>
                                     <tr>
                                         <td>FAR(in Percentage)</td>
                                         <td>
                                             <asp:Label ID="lblFarByelaws" runat="server"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtFar" Enabled="false" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>Ground Coverage (in Percentage)</td>
                                         <td>
                                             <asp:Label ID="lblGroundBylo" runat="server" Text=""></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtGroundcover" Enabled="false" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>Height(In mts)</td>
                                         <td>
                                             <asp:Label ID="lblHeight" runat="server" Text=""></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtHeight" Enabled="false" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td colspan="8" style="text-align: left">Set Back(In mts)</td>
                                     </tr>
                                     <tr>
                                         <td style="text-align: right">front</td>
                                         <td>
                                             <asp:Label ID="lblSetBackFront" runat="server"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtSetBackFront" Enabled="false" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td style="text-align: right">Rear
                                         </td>
                                         <td>
                                             <asp:Label ID="lblSetBackRear" runat="server" Text=""></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtSetBackRear" Enabled="false" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td style="text-align: right">Side1</td>
                                         <td>
                                             <asp:Label ID="lblSetBackSide1" runat="server" Text=""></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtSetBackSide1" Enabled="false" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td style="text-align: right">Side2</td>
                                         <td>
                                             <asp:Label ID="lblSetBackSide2" runat="server" Text=""></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtSetBackSide2" Enabled="false" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td colspan="3" style="text-align: left"><code>Classification of Indiustries Based on Degree of Hazard</code></td>
                                     </tr>
                                     <tr>
                                         <td>Classification of Hazard</td>
                                         <td colspan="2">

                                             <asp:DropDownList Width="190px" ID="ddlNature" Enabled="false" runat="server" CssClass="btn btn-default dropdown-toggle input-sm mynewselect">
                                             </asp:DropDownList>

                                         </td>
                                     </tr>


                                     <tr>
                                         <td>Occupancy</td>
                                         <td colspan="2">


                                             <asp:TextBox Width="190px" ID="txtOccupancy" Enabled="false" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>


                                         </td>
                                     </tr>

                                     </tbody>
                             </table>

                             <table class="table table-bordered table-hover request-table" width="100%">
                                 <thead>
                                     <tr>
                                         <th style="width: 150px">Floors</th>
                                         <th style="width: 100px">Existing </th>
                                         <th>Proposed</th>
                                     </tr>
                                 </thead>
                                 <tbody>
                                     <tr>
                                         <td>BaseMent(in Sqmts)</td>
                                         <td>
                                             <asp:TextBox ID="txtBaseMent1" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtBaseMent2" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>Ground Floor(in Sqmts)</td>
                                         <td>
                                             <asp:TextBox ID="txtGround1" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtGround2" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>First Floor(in Sqmts)</td>
                                         <td>
                                             <asp:TextBox ID="txtFirstfloor1" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtFirstfloor2" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>Second Floor(in Sqmts)</td>
                                         <td>
                                             <asp:TextBox ID="txtSecondFloor1" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtSecondFloor2" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="right">Mezzanine Floor(in Sqmts)</td>
                                         <td>
                                             <asp:TextBox ID="txtMezzanine1" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtMezzanine2" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                         </td>
                                     </tr>
                                 </tbody>
                             </table>

                             <table class="table table-bordered table-hover request-table" id="datatableService2">
                                 <thead>
                                     <tr>
                                         <th style="width: 150px"></th>
                                         <th></th>
                                     </tr>
                                 </thead>
                                 <tbody>
                                     <tr>
                                         <td align="right">Purpose for which  building Use
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbuildingPurpose" Enabled="false" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="right" colspan="2">Construction Specification</td>
                                     </tr>
                                     <tr>
                                         <td align="right">Foundation</td>
                                         <td>
                                             <asp:TextBox ID="txtFoundation" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="right">Walls</td>
                                         <td>
                                             <asp:TextBox ID="txtWalls" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="right">Floors</td>
                                         <td>
                                             <asp:TextBox ID="txtFloors" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="right">Roofs</td>
                                         <td>
                                             <asp:TextBox ID="txtRoofs" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="right">Number of storeys</td>
                                         <td>
                                             <asp:TextBox ID="txtStories" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="right">Number of latrines</td>
                                         <td>
                                             <asp:TextBox ID="txtLatrines" Enabled="false" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="right">Any Previous Construction </td>
                                         <td>
                                             <asp:TextBox ID="txtPreviousConstruction" Enabled="false" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="right">Source of Water for Building Purpose </td>
                                         <td>
                                             <asp:TextBox ID="txtWaterSource" Enabled="false" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                 </tbody>
                             </table>

                     
                     </div>

                            



                     <uc1:UC_Service_Approval runat="server" id="UC_Service_Approval" />





                          <span runat="server" >

                     <div class="panel-heading">
                                    <span><h4>For Office Use</h4></span>         
                                    </div>
                                   
                        <table class="table table-bordered table-hover request-table" id="datatableService1" width="100%" cellspacing="0">
                        <tr>
                                    
                                   <asp:GridView ID="GridViewService"   EnableViewState="true"   DataKeyNames="ServiceCheckListsID,ServiceTimeLinesID" CssClass="table table-bordered table-hover request-table" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridViewService_RowDataBound" OnRowCommand="GridViewService_RowCommand" Width="100%">
                                         <Columns>
                                            <asp:TemplateField  HeaderText="ChekList" ItemStyle-Width="360px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_ServiceTimeLines" runat="server" Text='<%# Eval("ServiceTimeLinesCondition") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:BoundField DataField="ServiceTimeLinesDocuments" HeaderText="Chechklist Description" ItemStyle-Width="150" />


                                                <asp:TemplateField HeaderText="Document" ItemStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:LinkButton   usesubmitbehavior="true" ID="lbView" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" Text=''><i class="fa fa-download" aria-hidden="true"></i></asp:LinkButton> / 
                                                   <asp:LinkButton   usesubmitbehavior="true" ID="lbView1" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument" Text=''><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>
                                            
                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              

                                            
                                            <asp:TemplateField  HeaderText="RM">
                                                  <ItemTemplate>
                                              

                                                    <asp:DropDownList Width="150px" ID="ddlVerifiedRM" AutoPostBack="true" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" runat="server"  CssClass="btn btn-default dropdown-toggle" >
                                                        <asp:ListItem Value="0"> - </asp:ListItem>
                                                        <asp:ListItem Value="1">Approved</asp:ListItem>
                                                        <asp:ListItem Value="2">Issues</asp:ListItem>
                                                         <asp:ListItem Value="3">Clearification from applicant</asp:ListItem>
                                                <asp:ListItem Value="4">N/A</asp:ListItem>
                                                        </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>



                                            <asp:TemplateField  HeaderText="AM" >
                                                <ItemTemplate>
                                               
                                                    
                                             <asp:DropDownList ID="ddlVerifiedAM" Width="150px"   AutoPostBack="true" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged"  runat ="server"  CssClass="btn btn-default dropdown-toggle" >
                                                        <asp:ListItem Value="0"> - </asp:ListItem>
                                                        <asp:ListItem Value="1">Reviewed</asp:ListItem>
                                                        <asp:ListItem Value="2">Issues</asp:ListItem>
                                                         <asp:ListItem Value="3">Clearification from applicant</asp:ListItem>
                                                  <asp:ListItem Value="4">N/A</asp:ListItem>
                                               
                                                 </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField   HeaderText="JE" >
                                                <ItemTemplate>
                                                    
                                              
                                                    <asp:DropDownList ID="ddlVerifiedJE" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" runat="server"  CssClass="btn btn-default dropdown-toggle" >
                                                        <asp:ListItem Value="0"> - </asp:ListItem>
                                                        <asp:ListItem Value="1">Verified</asp:ListItem>
                                                        <asp:ListItem Value="2">Issues</asp:ListItem>
                                                         <asp:ListItem Value="3">Clearification from applicant</asp:ListItem>
                                                         <asp:ListItem Value="4">N/A</asp:ListItem>
                                                    </asp:DropDownList> 

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            
                                            
                                            
                                 
                                        </Columns>
                                    </asp:GridView>






                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:Literal ID="ltEmbed" runat="server" />
                                </div>
                            </div>












                            <br />
                                    <code>Service Request Forwarding</code>
                                            <div class="clearfix"></div>
                        <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-2">
                           
                        </label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlTransfer" runat="server"  CssClass="similar-select1 dropdown-toggle">
               
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="submit" OnClick="submit_Click"  runat="server" Text="Submit" CssClass="btn-primary ey-bg" />
                           <asp:Button ID="btnApprove" OnClick="Approve_Click" Visible="false"  runat="server" Text="Approve" CssClass="btn-primary ey-bg" />
                           <asp:Button ID="btnReject" OnClick="Reject_Click"  Visible="false" runat="server" Text="Reject" CssClass="btn-primary ey-bg" />
                             <asp:Button ID="btnQuery" OnClick="btnQuery_Click"  Visible="false" runat="server" Text="Query" CssClass="btn-primary ey-bg" />
                           <asp:Button ID="btnMail" OnClick="btnMail_Click"  runat="server" Text="Send Mail" CssClass="btn-primary ey-bg" />
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-2">
                            Remark :
                        </label>
                        <div class="col-md-6">
                            <asp:TextBox ID="Remark" runat="server" placeholder="Remark Here" TextMode="MultiLine" class="" Width="100%" Height="100px"/>
                        </div>                        
                    </div>
                                               <div class="clearfix"></div>

                                    <br />
                                    <code>Service Request Tracker</code>
                                <asp:GridView ID="GridView1"   EnableViewState="true"   CssClass="table table-bordered table-hover request-table" runat="server" AutoGenerateColumns="true" Width="100%">
                                <EmptyDataTemplate>
                                 Request Submitted To RM
                                </EmptyDataTemplate>                                     
                                    </asp:GridView>
                                </tr>
                            </tbody>
                        </table>


                              </span>

                    </div>
                    

              <asp:Label ID="lblEmailId" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblPhoneNo" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblRMName" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblServiceNAme" runat="server" Visible="false"></asp:Label>
                            
<asp:Label runat="server" ID="lblallotteName" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblAllotteeAddress" Visible="false"></asp:Label>
<asp:Label runat="server" ID="LblallotteeIA" Visible="false"></asp:Label>
<asp:Label runat="server" ID="LblallotteeReg" Visible="false"></asp:Label>
<asp:Label runat="server" ID="LblallotteePlotNo" Visible="false"></asp:Label>
  
                
                     <span runat="server" visible="false">     
                     
                     <div runat="server" id="officeTransferDiv"  visible="false">
                                 <code>Transfer Levy Chart</code>
                          
            <table class="table table-striped table-bordered table-hover request-table request-table">
                <tr><th rowspan="2">1. In Blood Relation</th><td>Vacant Plot</td><td>No Levy</td></tr>
                <tr><td>Under Production</td><td>No Levy</td></tr>

                   <tr><th rowspan="5">2. Reconstitution</th><td>Vacant Plot (major Change in share)</td><td>Levy</td></tr>
                <tr><td>Vacant Plot (No major Change in share)</td><td>No Levy</td></tr>

                <tr><td>Under Production(< 2 year) (major Change in share)</td><td>Levy</td></tr>
                <tr><td>Under Production(< 2 year) (No major Change in share)</td><td>No Levy</td></tr>

                <tr><td>Under Production(> 2 year) </td><td>No Levy</td></tr>

                <tr><th rowspan="2">3. Merger</th><td>Vacant Plot</td><td>No Levy</td></tr>
                <tr><td>Under Production</td><td>No Levy</td></tr>

                   <tr><th rowspan="5">2. Other</th><td>Vacant Plot</td><td>Levy</td></tr>
                <tr><td>Under Production(< 2 year)</td><td>Levy</td></tr>
                <tr><td>Under Production(> 2 year) </td><td>Half Levy</td></tr>

            </table>           

           
                         
                         <div class="col-lg-6 font-12px">
  <asp:GridView ID="LevyGrid" runat="server" AutoGenerateColumns="true"  caption="<div class='panel-heading'>Full Transfer Levy</div>"
                             CssClass="table table-striped table-bordered table-hover request-table">                            
                        </asp:GridView>
       </div> 


                      </div>



                     <div runat="server" id="inspector_div"  visible="false">

                    <div class="" style="border: 1px solid #ccc;margin-top: 15px;">
                        <div class="form-group">
                            <label class="col-md-2">
                                 <code>Risk Assesment</code>
                            </label>
                            <div class="col-md-2"  runat="server" id="riskcolor"> 
                            </div>
                             <div class="col-md-2">    

                                 <asp:Button ID="lblRisk" OnClick="lblRisk_Click" runat="server"  CssClass="btn-primary ey-bg" />
                            
                             </div>

                <label class="col-md-2">
                                   </label>
                            <div class="col-md-4">
                                       
                            </div>

                        </div>


                    <div class="clearfix"></div>
                 
                    </div> 
                    

                     
                        <%--         </ContentTemplate>
                    </asp:UpdatePanel>--%>


                     <div class="" id="inspector_div1" runat="server" style="border: 1px solid #ccc;margin-top: 15px;">
                        <div class="form-group">
                            <label class="col-md-2">
                                 <asp:Button ID="btnInspection" OnClick="InspectorSelecor_Click" runat="server" Text="Initiate Inspection" CssClass="btn-primary ey-bg" />
                            </label>
                            <div class="col-md-10"  runat="server" id="Div1"> 
                                <asp:Label ID="lbl_Inspection" Visible="false" runat="server" Text=''></asp:Label>

                                   <asp:GridView ID="GridView2" runat="server"
             CssClass="table table-striped table-bordered table-hover request-table request-table"
  OnRowDataBound="GridView2_RowDataBound"
                                     OnRowCommand="GridView2_RowCommand"
            AutoGenerateColumns="False"
            DataKeyNames="ServiceRequestNO"
            GridLines="Horizontal" 
            Width="100%" 
            >
            <Columns>
              
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                 <asp:BoundField DataField="IndustrialArea" ItemStyle-HorizontalAlign="Justify" HeaderText="Industrial Area" SortExpression="ServiceRequestActivity" />
                <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="ApplicationType" />
                     <asp:BoundField DataField="EMPLOYEENAME" HeaderText="Inspector" SortExpression="ApplicationType" />
                <asp:BoundField DataField="Remark" HeaderText="Remark" ItemStyle-Wrap="true" ItemStyle-Width="200px" SortExpression="CaseType" />
           
                 <asp:TemplateField  HeaderText="Inspection Report">
                 <ItemTemplate>
                    <asp:Label ID="file_name"  Text='<%# Eval("ColName") %>' runat="server" Visible ="false" />
                  <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" Text='<i class="fa fa-download" aria-hidden="true"></i>' />
                  </ItemTemplate>
                  </asp:TemplateField>

                </Columns>
            <EmptyDataTemplate>
                No Record Available
            </EmptyDataTemplate>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>



                            </div>
                            
                    <div class="clearfix"></div>
                 
                    </div> 

</div>
                    </div>
                    
                    </span>
                           

                </div>
            </div>



                                    <span runat="server" visible="false">
                                        <asp:Label ID="riskDetail" runat="server" Visible="false" />
                                    </span>



                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>



                </div>

            </div>
        </div>

  </ContentTemplate>
 </asp:UpdatePanel>
                   

    <style>
        select {
    height: 20px !important;
    border-radius: 0;
    /* width: auto; */
    font-size: 12px;
    /* padding: 0px 2px; */
    margin-left: 0;
    padding: 0px 20px !important;
    background: #ececec !important;
}

    </style>




</asp:Content>
