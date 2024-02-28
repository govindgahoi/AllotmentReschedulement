<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" Debug="true" CodeBehind="Master-User-Role-Mapping.aspx.cs"
    Inherits="Allotment.UserRoleMapping" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" />
<link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.2.2/css/buttons.dataTables.min.css" />
<script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
<script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
<script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>


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

        $(document).ready(function () {
       
            $('[id*=userAssociationGrid]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 4,
                buttons: [
                    { extend: 'copy',  text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'excel', text: 'Export to Excel',   className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'csv',   text: 'Export to CSV',     className: 'exportExcel', filename: 'Agenda_Csv',   exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'pdf',   text: 'Export to PDF',     className: 'exportExcel', filename: 'Agenda_Pdf',     orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                ]
            });
        });

        
</script>

    <script>  
        function selectDeselect() {
            var listb = document.getElementById("<%= Listbox6.ClientID%>")  
            var len = listb.options.length;  
            for (var i = 0; i < len; i++) {
                listb.options[i].selected = false;  
            }  
             var labelObj = document.getElementById("<%= lblDataManager.ClientID %>");
              labelObj.value = "";
       //  alert("hjhj");
        }  
        
      </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>

    
  

<%--    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional"  >


        
   <ContentTemplate>
        <asp:UpdateProgress ID="UpdWaitImage" runat="server"  DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                 <ProgressTemplate>
                 <div class="fgh">
                 <div class="hgf">
                                <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>   
                               </div>
                               </div>
       </ProgressTemplate>
       </asp:UpdateProgress>--%>



  <cc1:MessageBox ID="MessageBox1" runat="server" />
<div class="row" >
            <div class="col-md-12" style="background: #dbdbdb;">
                <div>
                <div style="width: 100px;float: left;background: #dbdbdb;font-size:11px;" class="text-center">
                    <br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li class="disabled">
                            <a href="#" class="disable">
                                <i class="fa fa-tachometer" aria-hidden="true"></i><br />Dashboard
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;font-size:11px;" class="text-center">
                    Operate<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li>
                            <a runat="server" onserverclick="save_ServerClick">
                                <i class="fa fa-floppy-o " aria-hidden="true"></i><br />Save
                            </a>
                        </li> 
                        <li>
                            <a runat="server" onserverclick="reset_ServerClick">
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
                            <a href="#" class="disable">
                                <i class="fa fa-angle-double-left" aria-hidden="true"></i><br />Previous
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
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
        </div>


    <div class="row">
          <asp:Label runat="server" ID="rowidlbl" Visible="false"></asp:Label>
           <div class="col-lg-2">
                    <div class="panel panel-default">
                        <div class="panel-heading font-bold">
                           Associates Users To                          
                        </div>
                          <div class="panel">
                           <asp:TextBox ID="txtSearchh" runat="server" OnTextChanged="txtSearchh_TextChanged" placeholder="Search User By Name" CssClass="form-control input-sm" ToolTip="Search User"  AutoPostBack="true"></asp:TextBox>                        
                        </div>
                          <div class="panel-body" style="padding:0px !important;">


                              <asp:ListBox runat="server" ID="Listbox3"  CssClass="list-select" SelectionMode="Single" AutoPostBack="true" Rows="13" Width="100%" OnSelectedIndexChanged="Listbox3_SelectedIndexChanged" >
        </asp:ListBox>
                              </div>



                        </div>
                    </div>
                <div class="col-lg-2">
                    <div class="panel panel-default">
                        <div class="panel-heading font-bold">
                           Regional Office                           
                        </div>
                        <div class="panel">
                           <asp:TextBox ID="txtSearchRegion" runat="server" OnTextChanged="txtSearchRegion_TextChanged" placeholder="Search Region By Name" CssClass="form-control input-sm" ToolTip="Search Region"  AutoPostBack="true"></asp:TextBox>                        
                        </div>
                          <div class="panel-body" style="padding:0px !important;">


                              <asp:ListBox runat="server" ID="Listbox1" CssClass="list-select" SelectionMode="Single" Rows="13" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="Listbox1_SelectedIndexChanged">

                          

                              </asp:ListBox>
                              </div>



                        </div>
                    </div>
         <div class="col-lg-2">
                    <div class="panel panel-default">
                        <div class="panel-heading font-bold">
                           Associate IA                          
                        </div>
                        <div class="panel">
                           <asp:TextBox ID="txtSearchIA" runat="server" OnTextChanged="txtSearchIA_TextChanged" placeholder="Search Region By Name" CssClass="form-control input-sm" ToolTip="Search Region"  AutoPostBack="true"></asp:TextBox>                        
                        </div>
                          <div class="panel-body" style="padding:0px !important;">


                              <asp:ListBox runat="server" CssClass="list-select list-select-minht" ID="Listbox2" SelectionMode="Multiple" Rows="13" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="Listbox2_SelectedIndexChanged" >
        </asp:ListBox>
                              </div>



                        </div>
                    </div>

           <div class="col-lg-2">
                    <div class="panel panel-default">
                        <div class="panel-heading font-bold">
                          Associate Services                          
                        </div>
                         <div class="panel">
                           <asp:TextBox ID="txtSearchService" runat="server" placeholder="Search Service By Name" CssClass="form-control input-sm" ToolTip="Search Service"  AutoPostBack="true"></asp:TextBox>                        
                        </div>
                          <div class="panel-body" style="padding:0px !important;">


                              <asp:ListBox runat="server" CssClass="list-select" ID="Listbox5" SelectionMode="Multiple" Rows="13" Width="100%" OnSelectedIndexChanged="Listbox5_SelectedIndexChanged" AutoPostBack="true" >
                              
        </asp:ListBox>
                              </div>



                        </div>
                    </div>

     
       

         <div class="col-lg-2">
                    <div class="panel panel-default">
                        <div class="panel-heading font-bold">
                         Roles                        
                        </div>
                          <div class="panel">
                           <asp:TextBox ID="TextBox1" runat="server" placeholder="Search Role By Name" CssClass="form-control input-sm" ToolTip="Search Role"  AutoPostBack="true"></asp:TextBox>                        
                        </div>
                          <div class="panel-body" style="padding:0px !important;">
                             
                            <asp:ListBox runat="server" ID="Listbox4" CssClass="list-select" SelectionMode="Single" Rows="13" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="Listbox4_SelectedIndexChanged"></asp:ListBox>

                          

                                  </div>



                        </div>
                    </div>

         <div class="col-lg-2">
                    <div class="panel panel-default">
                        <div class="panel-heading font-bold">
                         User Type                          
                        </div>
                           <div class="panel">
                           <asp:TextBox ID="TextBox2" runat="server" placeholder="Search Type By Name" CssClass="form-control input-sm" ToolTip="Search Type"  AutoPostBack="true"></asp:TextBox>                        
                        </div>
                          <div class="panel-body" style="padding:0px !important;">


                              <asp:ListBox runat="server" CssClass="list-select" ID="Listbox9" Height="78px" SelectionMode="Multiple" Rows="4" Width="100%"  AutoPostBack="true" OnSelectedIndexChanged="Listbox9_SelectedIndexChanged" >
                                  <asp:ListItem>Primary</asp:ListItem>  <asp:ListItem>Secondary</asp:ListItem>
                              
        </asp:ListBox>
                              </div>
                        <div class="panel-heading font-bold">
                         Data Manager  <asp:Button id="lstbox" Text="DeSelect All" runat="server" style="text-align:right;" OnClientClick="selectDeselect();"   />                        
                        </div>
                           <div class="panel">
                           <asp:TextBox ID="TextBox3" runat="server" placeholder="Search Type By Name" CssClass="form-control input-sm" ToolTip="Search Type"  AutoPostBack="true"></asp:TextBox>                        
                        </div>
                          <div class="panel-body" style="padding:0px !important;">


                              <asp:ListBox runat="server" CssClass="list-select" ID="Listbox6" SelectionMode="Multiple" Rows="5" Width="100%"  AutoPostBack="true" OnSelectedIndexChanged="Listbox6_SelectedIndexChanged" >
                                  <asp:ListItem>Data Approver</asp:ListItem>  <asp:ListItem>Data Reviewer</asp:ListItem><asp:ListItem>Data Verifier</asp:ListItem>
                                  <asp:ListItem>Account Assistant</asp:ListItem>
                                   <asp:ListItem>Account Manager</asp:ListItem>
                                   <asp:ListItem>CMIA</asp:ListItem>
                                   <asp:ListItem>JMD</asp:ListItem>
                                  <asp:ListItem>Final Approver</asp:ListItem>
                                 
                              
        </asp:ListBox>
                              </div>




                        </div>
                    </div>
      
        </div>
       <div class="clearfix"></div>
            <div class="">
                    <div class="">
                        <div class="panel panel-default">
                            <div class="panel-heading" >
                                
                                    <div class="">                                               
                                                <span class="font-bold">Your Selection</span>                                   
                                        </div>
                                    
                                </div>
                            <div class="clearfix"></div>
                                </div>
                                <div class="panel-body">
                                  <div class="row">
                                      
                           <div class="col-lg-2">
                               <div class="panel box-panel">
                        <div class="panel-heading box-back-none font-bold">
                          Associate User To                          
                        </div>
                          <div class="panel-body" style="padding:0px !important;height:100px;">
                              <asp:Label runat="server" ID="lblSelectedUser" CssClass="list-select"></asp:Label>
                              </div>



                        </div>
                           </div>           
                                      
                        <div class="col-lg-2"><div class="panel box-panel">
                        <div class="panel-heading box-back-none font-bold">
                          Regional Office                          
                        </div>
                          <div class="panel-body" style="padding:0px !important;height:100px;">
                              <asp:Label runat="server" CssClass="list-select" ID="lblSelectedRegOffice"></asp:Label>
                              </div>



                        </div></div>

                                        <div class="col-lg-2"><div class="panel box-panel">
                        <div class="panel-heading box-back-none font-bold">
                         Associate IA                         
                        </div>
                          <div class="panel-body" style="padding:0px !important;overflow-y:scroll;height:100px;">
                              <asp:Label runat="server" CssClass="list-select" ID="lblSelectedIA"></asp:Label>
                              </div>



                        </div></div>
                                         <div class="col-lg-2 col-sm-6">
                    <div class="panel box-panel">
                        <div class="panel-heading box-back-none font-bold">
                          Associate Service                          
                        </div>
                          <div class="panel-body" style="padding:0px !important;overflow-y:scroll;height:100px;">
                              <asp:Label runat="server" CssClass="list-select" ID="lblSelectedServices"></asp:Label>
                              </div>



                        </div>
                    </div>


                                         <div class="col-lg-2">
                    <div class="panel box-panel">
                        <div class="panel-heading box-back-none font-bold">
                          Role                          
                        </div>
                          <div class="panel-body" style="padding:0px !important;height:100px;">
                              <asp:Label runat="server" ID="lblSelectedRole"></asp:Label><br />
                               <asp:Label runat="server" ID="lblselectedtype"></asp:Label>
                              </div>



                        </div>
                    </div>
                                      <div class="col-lg-2">
                    <div class="panel box-panel">
                        <div class="panel-heading box-back-none font-bold">
                          Data Manager                          
                        </div>
                          <div class="panel-body" style="padding:0px !important;height:100px;">
                              <asp:Label runat="server" ID="lblDataManager"></asp:Label><br />
                               
                              </div>



                        </div>
                    </div>

                                  </div>
                                   <br />
                                     <div class="row" style="display:none;">
                                        <div class="col-md-2"><b class="mybody">Effective From</b></div><div class="col-lg-3"><asp:TextBox runat="server" AutoPostBack="true" CssClass="date form-control" ID="txteffectiveFrom" OnTextChanged="txteffectiveFrom_TextChanged"></asp:TextBox></div><div class="col-md-2" runat="server" id="prev1" visible="false"><b class="mybody">Prev Effective To</b></div><div class="col-lg-3" runat="server" id="prev2" visible="false"><asp:TextBox runat="server" CssClass="date form-control" ID="txteffectiveTo" OnTextChanged="txteffectiveTo_TextChanged"></asp:TextBox></div><div class="col-lg-2"><asp:Button runat="server" ID="btnSet" CssClass="btn btn-sm ey-bg" Text="Submit" OnClick="btnNewAss_Click" />&nbsp;&nbsp;<asp:Button runat="server" ID="btnReset" CssClass="btn btn-sm ey-bg" Text="Reset" OnClick="btnReset_Click" /></div>
                                    </div>


                        </div></div>

    <div class="">
        <div class="">
          
                        <div class="panel panel-default">
                            <div class="panel-heading" style="width: 100%;">                               
                                    <div class="col-md-8 font-bold" style="margin: 9px 0 0px 0px;">
                                             Association Details     
                                    </div>
                                    <div class="input-group col-md-4 col-sm-12" style="float:right;">
                                        <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server" AutoPostBack="true"  OnTextChanged="txtSearch_TextChanged"   />
                                          <span class="input-group-btn">
                                            <button class="btn btn-secondary ey-bg" type="button">Search</button>
                                          </span>
                                     </div>
                                <div class="clearfix"></div>
                                </div>
                                <div class="panel-body">
                                    
                                    <div class="clearfix"></div>
                        <div class="table-responsive">

                                    <asp:GridView ID="userAssociationGrid" runat="server" AutoGenerateColumns="false" ClientIDMode="Static" DataKeyNames="userId"  CssClass="request-table" OnRowCommand="userAssociationGrid_RowCommand"  >
                            <Columns>
                  

                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#23527c">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                               </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText ="User Name" HeaderStyle-ForeColor="#23527c" >
                                                    <ItemTemplate><asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName") %>' ToolTip='<%#Eval("UserName") %>'></asp:Label></ItemTemplate>
                                                       </asp:TemplateField>
                              <asp:TemplateField HeaderText ="Regional Office" HeaderStyle-ForeColor="#23527c" >
                                                    <ItemTemplate><asp:Label ID="lblRegionalOffice" runat="server" Text='<%#Eval("RegionalOffice") %>' ToolTip='<%#Eval("RegionalOffice") %>'></asp:Label></ItemTemplate>
                                                       </asp:TemplateField>
                             <asp:TemplateField HeaderText ="Industrial Area" HeaderStyle-ForeColor="#23527c" >
                                                    <ItemTemplate><asp:Label ID="lblIAName" runat="server" Text='<%#Eval("IAName") %>' ToolTip='<%#Eval("IAName") %>'></asp:Label></ItemTemplate>
                                                       </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText ="Services" HeaderStyle-ForeColor="#23527c" >
                                                    <ItemTemplate><asp:Label ID="lblServices" runat="server" Text='<%#Eval("servicesName") %>' ToolTip='<%#Eval("servicesName") %>'></asp:Label></ItemTemplate>
                                                       </asp:TemplateField>
                                <asp:TemplateField HeaderText ="Role" HeaderStyle-ForeColor="#23527c" >
                                                    <ItemTemplate><asp:Label ID="lblLevel" runat="server" Text='<%#Eval("Level") %>' ToolTip='<%#Eval("Level") %>'></asp:Label></ItemTemplate>
                                                       </asp:TemplateField>
                                <asp:TemplateField HeaderText ="Type" HeaderStyle-ForeColor="#23527c" >
                                                    <ItemTemplate><asp:Label ID="lblRole" runat="server" Text='<%#Eval("Role") %>' ToolTip='<%#Eval("Role") %>'></asp:Label></ItemTemplate>
                                                       </asp:TemplateField>

                                 <asp:TemplateField HeaderText ="DataManager" HeaderStyle-ForeColor="#23527c" >
                                                    <ItemTemplate><asp:Label ID="lbldataManager" runat="server" Text='<%#Eval("DataManager") %>' ToolTip='<%#Eval("DataManager") %>'></asp:Label></ItemTemplate>
                                                       </asp:TemplateField>
                           
                               <asp:TemplateField HeaderText ="EffectiveFrom" HeaderStyle-ForeColor="#23527c" >
                                                    <ItemTemplate><asp:Label ID="lblEffectiveFrom" runat="server" Text='<%#Eval("EffectiveFrom", "{0:dd-MMM-yyyy}") %>' ToolTip='<%#Eval("EffectiveFrom", "{0:dd-MMM-yyyy}") %>'></asp:Label></ItemTemplate>
                                                       </asp:TemplateField>
                              <asp:TemplateField HeaderText ="EffectiveTo" HeaderStyle-ForeColor="#23527c" Visible="false">
                                                    <ItemTemplate><asp:Label ID="lblEffectiveTo" runat="server" Text='<%#Eval("EffectiveTo", "{0:dd-MMM-yyyy}") %>' ToolTip='<%#Eval("EffectiveTo", "{0:dd-MMM-yyyy}") %>'></asp:Label></ItemTemplate>
                                                       </asp:TemplateField>
                                 

                                  <asp:TemplateField HeaderText="Update" HeaderStyle-ForeColor="#23527c">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                   
                                       
                                 <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-pencil-square-o" aria-hidden="true" CommandName="Process" CommandArgument='<%#Eval("RowId")+"/"+ Eval("userId")+"/"+ Eval("RegionalOffice")+"/"+ Eval("IAid")+"/"+ Eval("Services")+"/"+ Eval("Level")+"/"+ Eval("Role")+"/"+ Eval("DataManager") %>'  />
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Delete" HeaderStyle-ForeColor="#23527c">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                   
                                       
                                 <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash" aria-hidden="true" CommandName="DeleteUser" CommandArgument='<%#Eval("RowId")+"/"+ Eval("userId") %>'  />
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



    </div>
        
    











   

  



   





<%-- 

    </ContentTemplate>
         </asp:UpdatePanel>--%>





</asp:Content>
