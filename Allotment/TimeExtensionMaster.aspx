<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="TimeExtensionMaster.aspx.cs" Inherits="Allotment.TimeExtensionMaster" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style>
        .box-panel
        {
   -webkit-box-shadow: 0 1px 1px transparent; 
    box-shadow: 0 1px 1px transparent;
        }
         .box-back-none
        {
   background:none !important;
box-shadow: inset 0px 1px 1px transparent !important; 
}
        @media only screen and (max-width:992px) {
            .form-group label.text-right {
                text-align:left !important;
            }
        }
     
    .tooltip
    {
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
    td
    {
        cursor: pointer;
    }


    </style>

     <script type="text/javascript">
         function isDecimalKey(evt) {
             var charCode = (evt.which) ? evt.which : evt.keyCode
             if (charCode != 46 && charCode > 31
             && (charCode < 48 || charCode > 57)) {
                 return false;
             } else {


             }
         }

         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>

    
 
    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional"  >

    

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

       <div class="row" >
            <div class="col-md-12 col-sm-12 col-xs-12" style="background: #dbdbdb;">
                <div>
                <div style="width: 100px;float: left;background: #dbdbdb;font-size:11px;" class="text-center">
                    <br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li class="disabled">
                            <a runat="server" onserverclick="Home_ServerClick"  >
                                <i class="fa fa-home" aria-hidden="true"></i><br />Home
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;font-size:11px;" class="text-center">
                    Operate<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li>
                            <a runat="server" id="SaveEntry" onserverclick="SaveEntry_ServerClick"   >
                                <i class="fa fa-floppy-o " aria-hidden="true"></i><br />Save
                            </a>
                        </li> 
                        <li>
                            <a runat="server" onserverclick="Unnamed_ServerClick">
                                <i class="fa fa-refresh" aria-hidden="true"></i><br />Refresh
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;border-right:1px solid #000;font-size:11px;" class="text-center">
                    Allottee Registration<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                            <a runat="server" class="disable"  >
                                <i class="fa fa-plus" aria-hidden="true"></i><br />New
                            </a>
                        </li>
                        <li>
                            <a runat="server" class="disable" >
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
                            <a runat="server" class="disable" >
                                <i class="fa fa-angle-double-left" aria-hidden="true"></i><br />Previous
                            </a>
                        </li>
                        <li>
                            <a runat="server" id="sernext" class="disable">
                                <i class="fa fa-angle-double-right" aria-hidden="true"></i><br />Next
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-step-forward" aria-hidden="true"></i><br />Final
                            </a>
                        </li>
                         
                        
                    </ul>
                    </div>     
                    
                </div>
            </div>
            <div class="clearfix"></div>
<div class="">
    <div class="col-md-12 col-sm-12 col-xs-12">
    <asp:Label ID="RateIdlbl" runat="server" Visible="false"></asp:Label>
      <div class="panel">
                        <div class="panel-heading font-bold" style="text-align:center;">
                          Industrial Area Time Extension Percentage                         
                        </div>
           <div class="panel-body">
                                        <div class="">
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-12 col-xs-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        Regional Office :
                                                    </label>
                                                    <div class="col-md-10 col-sm-12 col-xs-12">
                                                        <asp:DropDownList ID="dlregion" runat="server"  CssClass="input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="dlregion_SelectedIndexChanged" ></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        Name of Industrial Area :
                                                    </label>
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:DropDownList ID="IaDdl" runat="server"  CssClass="input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="IaDdl_SelectedIndexChanged" ></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                             <div class="form-group">
                                                 <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        Min Period :
                                                    </label> 
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:TextBox ID="txtMinPeriod" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        Max Period :
                                                    </label> 
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:TextBox ID="txtMaxPeriod" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"  ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        Time Extension % :
                                                    </label> 
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:TextBox ID="txtRate" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"  ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        EfFective From Date:
                                                    </label>
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:TextBox ID="txtEffectiveFromDate" runat="server" CssClass="date input-sm similar-select1" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group" >
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">                                                    
                                                        EfFective To Date:
                                                    </label>
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:TextBox ID="txtEffectiveToDate" runat="server" CssClass="date input-sm similar-select1" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="form-group" style="display:none;">                                              
                                                <div class="col-md-12 col-sm-12" style="text-align:right;padding-top:2px;">
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="ShowConfirmBox(this,'Are you Sure Withe Data You Entered'); return false;" />  &nbsp;&nbsp;<asp:Button ID="btnReset" runat="server" CssClass="btn btn-sm btn-primary" Text="Reset" OnClick="btnReset_Click" />
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <asp:Label ID="msg" runat="server"></asp:Label>
                                        </div>
                                    </div>

      </div>
</div>







       <div class="col-md-12 col-sm-12 col-xs-12">
      <div class="panel">
                     <div class="clearfix"></div>
                                    <div class="panel-heading">
                                        <div class="col-md-8 col-sm-4 col-xs-12 font-bold" style="margin-top:6px;">
                                            Existing Time Extension Percentage
                                        </div>
                                        <div class="input-group col-md-4 col-sm-8 col-xs-12" style="float:right;padding:2px;">
                                          <asp:TextBox ID="txtSearch" Width="100%" CssClass="input-sm" runat="server" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged"   />
                                          <span class="input-group-btn">
                                            <button class="btn btn-sm btn-primary" type="button"><i class="fa fa-search" style="color:#fff;padding:5px 0;"></i></button>
                                          </span>
                                        </div>
                                        <div class="clearfix"></div>
                                            
                                    </div>
                    <div class="panel-body  table-responsive">
                        <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                        <asp:GridView ID="IARateGrid" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" OnRowCommand="IARateGrid_RowCommand"
                            OnPageIndexChanging="IARateGrid_PageIndexChanging"  PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right"  >
                            <Columns>
                  

                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                               </asp:TemplateField>
                                
                                 <asp:BoundField DataField="RegionalOffice" HeaderText="Regional Office" SortExpression="RegionalOffice" />
                                <asp:BoundField DataField="IAName" HeaderText="Industrial Area" SortExpression="IAName" />
                                 <asp:BoundField DataField="MinPeriod" HeaderText="Min Period" SortExpression="MinPeriod" />
                                <asp:BoundField DataField="MaxPeriod" HeaderText="Max Period" SortExpression="MaxPeriod" />
                                <asp:BoundField DataField="Rate" HeaderText="Time Extension %" SortExpression="Rate" />
                               
                                <asp:BoundField DataField="effective_from1" HeaderText="Effective From Date" SortExpression="effective_from1"  />
                                 <asp:BoundField DataField="effective_to1" HeaderText="Effective To Date" SortExpression="effective_to1"  />
                                


                                  <asp:TemplateField HeaderText="Update" >
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                   
                                       
                                 <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in"  CommandName="Process" CommandArgument='<%#Eval("Id") %>' ToolTip="Click here For Update Rate " />
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remove">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnDelete" class="fa fa-trash" CommandName="DeleteRate" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" CommandArgument='<%#Eval("Id")+"/"+ Eval("IndustrialArea")+"/"+Eval("MinPeriod")%>'    ToolTip="Click here to delete Rate" />
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

   

  



   





 

    </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>
