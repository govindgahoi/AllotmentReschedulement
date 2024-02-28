<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" Debug="true" CodeBehind="ListOfNotices.aspx.cs"
    Inherits="Allotment.ListOfNotices" MaintainScrollPositionOnPostback="true" %>

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
                            <a runat="server"  >
                                <i class="fa fa-home" aria-hidden="true"></i><br />Home
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;font-size:11px;" class="text-center">
                    Operate<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li>
                            <a runat="server" id="SaveEntry" onserverclick="SaveEntry_ServerClick" >
                                <i class="fa fa-floppy-o " aria-hidden="true"></i><br />Save
                            </a>
                        </li> 
                        <li>
                            <a runat="server" id="refresh" onserverclick="refresh_ServerClick">
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
    <asp:Label ID="RateIdlbl" runat="server" Visible="false"></asp:Label>
      <div class="panel">
                        <div class="panel-heading font-bold" style="text-align:center;">
                          List Of Notices                         
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
                                                        <asp:DropDownList ID="ddloffice" runat="server"  CssClass="input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="Regional_Changed" ></asp:DropDownList>
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
                                                        <asp:DropDownList ID="drpdwnIA" runat="server"  CssClass="input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged" ></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                             <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        Plot No :
                                                    </label>
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:DropDownList ID="ddlPlotNo" runat="server"  CssClass="input-sm dropdown-toggle similar-select1" AutoPostBack="true" OnSelectedIndexChanged="ddlPlotNo_SelectedIndexChanged" ></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        Allotted To :
                                                    </label> 
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:TextBox ID="txtAllotteeName" runat="server" CssClass="input-sm similar-select1" Enabled="false" ></asp:TextBox>
                                                        <asp:Label runat="server" ID="lblAllotteeID" Visible="false"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        Notice For :
                                                    </label>
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:DropDownList ID="ddlService" runat="server"  CssClass="input-sm dropdown-toggle similar-select1" ></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        Notice Ref No:
                                                    </label>
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:TextBox ID="txtNoticeRefNo" runat="server" CssClass="input-sm similar-select1" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">
                                                        <span style="color: Red">*</span>
                                                        Notice Issue Date:
                                                    </label>
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:TextBox ID="txtNoticeIssueDate" runat="server" Class="date input-sm similar-select1" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group" >
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-12 text-right">                                                    
                                                       Notice Description:
                                                    </label>
                                                    <div class="col-md-10 col-sm-12">
                                                        <asp:TextBox ID="txtNoticeDescription" runat="server" CssClass="input-sm similar-select1 margin-left-z" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group" >
                                                <div class="row">
                                                    <label class="col-md-2 col-sm-3 col-xs-4 text-right">Upload Notice<br /><span class="myred">(Pdf of size upto 1mb only)</span></label>
                                                    <div class="col-md-3 col-sm-3 col-xs-4">
                                                        <asp:FileUpload ID="fileupload" Width="300px" CssClass="form-control" runat="server" />                                                    
                                                    </div>
                                                    <div class="col-md-3 col-sm-3 col-xs-4" style="display:none;">
                                                        <span>
                                                            <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-primary ey-bg btn-sm" style="margin:0 1px 0 0;width:65px;" Text="Upload" />
                                                        
                                                        </span>
                                                        <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <div class="form-group" style="display:none;">                                              
                                                <div class="col-md-12 col-sm-12" style="text-align:right;padding-top:2px;">
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="ShowConfirmBox(this,'Are you Sure Withe Data You Entered'); return false;" />  &nbsp;&nbsp;<asp:Button ID="btnReset" runat="server" CssClass="btn btn-sm btn-primary" Text="Reset" />
                                                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-sm btn-primary" Text="Update" OnClick="btnUpdate_Click"  />
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
                                            List Of Notices
                                        </div>
                                        <div class="input-group col-md-4 col-sm-8 col-xs-12" style="float:right;padding:2px;">
                                          <asp:TextBox ID="txtSearch" Width="100%" CssClass="input-sm" runat="server" AutoPostBack="true"    />
                                          <span class="input-group-btn">
                                            <button class="btn btn-sm btn-primary" type="button"><i class="fa fa-search" style="color:#fff;padding:5px 0;"></i></button>
                                          </span>
                                        </div>
                                        <div class="clearfix"></div>
                                            <asp:Label runat="server" ID="lblNoticeId" Visible="false"></asp:Label>
                                    </div>
                    <div class="panel-body  table-responsive">
                        <asp:Label ID="Label10" runat="server" Text=""></asp:Label>

                        <asp:GridView ID="NoticeGrid" runat="server" AutoGenerateColumns="false" DataKeyNames="NoticeID,ServiceID,NoticeRefNo,IssueDate,NoticeDescription" AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" 
                              PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" OnRowCommand="NoticeGrid_RowCommand" OnPageIndexChanging="NoticeGrid_PageIndexChanging" >
                            <Columns>
                  

                                <asp:TemplateField HeaderText="S.No"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                               </asp:TemplateField>
                                 

                                
                                 <asp:BoundField DataField="NoticeRefNo" HeaderText="Notice Ref No" SortExpression="NoticeRefNo" HeaderStyle-Width="10%"/>
                                <asp:BoundField DataField="IssueDate" HeaderText="Notice Date" SortExpression="IAName" HeaderStyle-Width="10%"/>                                
                                <asp:BoundField DataField="ServiceName" HeaderText="Notice For" SortExpression="Rate" HeaderStyle-Width="20%"/>                               
                                <asp:BoundField DataField="NoticeDescription" HeaderText="Description" SortExpression="EffectiveFromDate" HeaderStyle-Width="30%"  />
                                 
                                   <asp:TemplateField HeaderText="View" HeaderStyle-Width="2%">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                                                          
                                 <asp:LinkButton runat="server" ID="btnView" CssClass="fa fa-eye" CommandArgument='<%# (Container.DataItemIndex) %>'   usesubmitbehavior="true"   CommandName="View" />
                                    </ItemTemplate>

                                </asp:TemplateField>

                                  <asp:TemplateField HeaderText="Update" HeaderStyle-Width="2%">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                   
                                       
                                 <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in"  CommandName="Process"  CommandArgument='<%# (Container.DataItemIndex) %>' ToolTip="Click here For Update Notice " />
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remove" HeaderStyle-Width="2%">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnDelete" class="fa fa-trash" CommandName="DeleteNotice" CommandArgument='<%# (Container.DataItemIndex) %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete?');"  ToolTip="Click here to delete Rate" />
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
