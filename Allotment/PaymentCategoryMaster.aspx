<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" Debug="true" CodeBehind="PaymentCategoryMaster.aspx.cs"
    Inherits="Allotment.PaymentCategoryMaster" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
<link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
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
            .form-group .text-right {
                text-align: left !important;
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
    <script>
        $(document).ready(function () {
            $('.dropdown_search').select2();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>

    
  
    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always" EnableViewState="true"   >

    

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
            <div class="col-md-12 cocl-sm-12 col-xs-12" style="background: #dbdbdb;">
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
    <asp:Label ID="Idlbl" runat="server" Visible="false" ></asp:Label>
      <div class="panel">
                        <div class="panel-heading font-bold" style="text-align:center;">
                          Payment Category Master                          
                        </div>
           <div class="panel-body">
                                        <div class="">
                                         
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        Payment Category :
                                                    </label>
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:DropDownList ID="PaymentCategoryDropdown" runat="server"  CssClass="input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="PaymentCategoryDropdown_SelectedIndexChanged">
                                                             <asp:ListItem Value="0">-----Select-----</asp:ListItem>
                                                            <asp:ListItem Value="1">Dues</asp:ListItem>
                                                            <asp:ListItem Value="2">Other Charges/Services</asp:ListItem>
                                                            <asp:ListItem Value="3">Tax</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                             <div class="form-group">
                                                 <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        Description :
                                                    </label> 
                                                    <div class="col-md-10 col-sm-12">
                                                           <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div runat="server" id="TaxDiv2" visible="false">
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group" >
                                                <label class="col-md-2 col-sm-12 text-right">
                                                    Applicable Tax (If any):
                                                </label>
                                                <div class="col-md-10 col-sm-12">
                                                    <asp:CheckBox runat="server" ID="TaxCheck" OnCheckedChanged="TaxCheck_CheckedChanged" AutoPostBack="true" Text="Check If Any Any Tax Is Included And Select the Tax From Below Dropdown" />
                                                </div>
                                              </div>
                                                <div runat="server" id="taxDiv3" visible="false">

                                                    <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group" >
                                                <label class="col-md-2 col-sm-12 text-right">
                                                   
                                                </label>
                                                <div class="col-md-10 col-sm-12">
                                                   <asp:DropDownList ID="taxDropdown" runat="server"  CssClass="input-sm dropdown-toggle similar-select1" >
                                                   </asp:DropDownList>
                                                    </div>
                                              </div>
                                            
                                                </div>

                                             </div>
                                         
                                           
                                         <div runat="server" id="TaxDiv" visible="false">
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group" >
                                                <label class="col-md-2 col-sm-12 text-right">
                                                    Tax Percentage:
                                                </label>
                                                <div class="col-md-10 col-sm-12">
                                                    <asp:TextBox ID="txtTaxPercentage" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                                </div>
                                              </div>
                                             </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group" style="display:none;">                                              
                                                <div class="col-md-12 col-sm-12" style="text-align:right;padding-top:2px;">
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" OnClick="btnSubmit_Click"  />  &nbsp;&nbsp;<asp:Button ID="btnReset" runat="server" CssClass="btn btn-sm btn-primary" Text="Reset" OnClick="btnReset_Click"  />
                                                 </div>
                                                </div>
                                            <div class="clearfix"></div>
                                            <asp:Label ID="msg" runat="server"></asp:Label>
                                        </div>
                                    </div>

      </div>

      <div class="panel">
                     <div class="clearfix"></div>
                                    <div class="panel-heading">
                                        <div class="col-md-4" style="margin-top:12px;">
                                            <b>Existing Payment Categories</b>
                                        </div>
                                        <div class="input-group col-md-8 col-sm-12 text-right" style="padding:2px;">
                                          <asp:TextBox ID="txtSearch" Width="200px" CssClass="similar-select input-sm" runat="server" AutoPostBack="true"    />
                                          <span class="input-group-btn">
                                            <button class="btn btn-sm btn-primary" type="button"><i class="fa fa-search" style="padding:3px 0;color:#fff;"></i></button>
                                          </span>
                                        </div>
                                        <div class="clearfix"></div>
                                            
                                    </div>
                    <div class="panel-body gallery  table-responsive">
                        <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                        <asp:GridView ID="IARateGrid" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" AllowPaging="true" PageSize="20" CssClass="table table-striped table-bordered table-hover request-table" 
                           PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" OnRowCommand="IARateGrid_RowCommand" OnPageIndexChanging="IARateGrid_PageIndexChanging" >
                            <Columns>
                  

                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="Description" HeaderText="Payment Description" SortExpression="Description" />
                                 <asp:BoundField DataField="PaymentCategory" HeaderText="Category" SortExpression="ApplicableCharge" /> 


                                  <asp:TemplateField HeaderText="Update" >
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                   
                                       
                                 <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandArgument='<%# (Container.DataItemIndex) %>'  CommandName="Process"  ToolTip="Click here For Update Rate " />
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Change">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnDelete" class="fa fa-trash" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="DeleteCharge" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');"  ToolTip="Click here to delete Rate" />
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
