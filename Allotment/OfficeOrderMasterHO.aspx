<%@ Page Title="" Language="C#" MasterPageFile="~/MainUserHO.Master" AutoEventWireup="true" CodeBehind="OfficeOrderMasterHO.aspx.cs" Inherits="Allotment.OfficeOrderMasterHO" %>

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
   
<script type="text/javascript">
    $(document).ready(function () {
        $('[id*=GridView2]').prepend($("<thead></thead>").append($('[id*=GridView2]').find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0]}],
            'iDisplayLength': 10,
            buttons: [
                { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible'} }
            ]
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
      <cc1:MessageBox ID="MessageBox1" runat="server" />
    <div>
     
        <div id="header">
            <div class="panel panel-default">
                <p class="panel-heading font-bold text-center">Office Order Master</p>
                <div class="panel-body">
                        <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span>
                                Section :
                            </label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="drpSection" class="input-sm similar-select1" runat="server">
                                    <asp:ListItem Value="---Select Section---">---Select Section---</asp:ListItem>
                                    <asp:ListItem Value="IA Section">IA Section</asp:ListItem>
                                    <asp:ListItem Value="ATP">ATP</asp:ListItem>
                                    <asp:ListItem Value="Engineering Section">Engineering Section</asp:ListItem>
                                    <asp:ListItem Value="Establishment">Establishment</asp:ListItem>
                                    <asp:ListItem Value="Finance & Accounts">Finance & Accounts</asp:ListItem>
                                    <asp:ListItem Value="UPSIDA">UPSIDA</asp:ListItem>
                                    <asp:ListItem Value="State">State</asp:ListItem>
                                    <asp:ListItem Value="Legal">Legal</asp:ListItem>
                                    <asp:ListItem Value="Land Acquisition">Land Acquisition</asp:ListItem>
                                </asp:DropDownList>
                           <asp:RequiredFieldValidator id="reqFavoriteColor" Text="section cannot be blank" InitialValue="---Select Section---" ControlToValidate="drpSection" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" Runat="server" />
                                </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                       <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span>
                                Category :
                            </label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="drpCategory" class="input-sm similar-select1" runat="server">
                                    <asp:ListItem Value="---Select Category---">---Select Category---</asp:ListItem>
                                    <asp:ListItem Value="Office Orders">Office Orders</asp:ListItem>
                                    <asp:ListItem Value="Goverment Orders">Goverment Orders</asp:ListItem>
                                    <asp:ListItem Value="Board Meeting Orders">Board Meeting Orders</asp:ListItem>
                                    <asp:ListItem Value="Courts Order">Courts Order</asp:ListItem>
                                    <asp:ListItem Value="Minutes of Meetings">Minutes of Meetings</asp:ListItem>
                                  
                                </asp:DropDownList>
                           <asp:RequiredFieldValidator id="rfvCategory" Text="Category cannot be blank" InitialValue="---Select Category---" ControlToValidate="drpCategory" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" Runat="server" />
                                </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span>
                                Order Ref No :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtOrderRefNo" runat="server" class="input-sm similar-select1 span12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RfvtxtOrderRefNo" runat="server"
                                    ErrorMessage="Order ref no cannot be blank" ControlToValidate="txtOrderRefNo"
                                    ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator> </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span>
                                Subject :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtSubject" runat="server" class="input-sm similar-select1 span12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtSubject" runat="server"
                                    ErrorMessage="Subject cannot be blank" ControlToValidate="txtSubject"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span>
                                Issued Date :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtIssuedDate" runat="server" class="date input-sm similar-select1 span12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtIssuedDate" runat="server"
                                    ErrorMessage="Activity can't be left blank" ControlToValidate="txtIssuedDate"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span>
                                Issued by :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtIssuedBy" runat="server" class="input-sm similar-select1 span12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTimelines" runat="server"
                                    ErrorMessage="Issued by can't be left blank" ControlToValidate="txtIssuedBy"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span>
                                Description :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtDescription" runat="server" class="input-sm similar-select1 span12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtDescription" runat="server"
                                    ErrorMessage="Description can't be left blank" ControlToValidate="txtDescription"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                   
                     <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                      <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span>
                                Visibility :
                            </label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="drpPrivate" class="input-sm similar-select1" runat="server">
                                    <asp:ListItem Value="Private" Selected="True">Private</asp:ListItem>
                                    <asp:ListItem Value="Public">Public</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                                                       <div class="row">
                                                                <label class="col-md-3 text-right">
                                                                   Office Order Copy :
                                                                </label>
                                                                <div class="col-md-5">
                                                                    <asp:FileUpload ID="fileupload1" runat="server" CssClass="form-control form-control-sm" ToolTip="Upload" accept=".pdf" />                                                        
                                                                </div>
                                                 <div class="col-md-4">
                                                                  <asp:Button ID="btnupload" runat="server" Text="Upload" CssClass="rounded-0 btn btn-primary" style="padding:2px 15px;margin-top: 5px;" OnClick="btnupload_Click"/> 
                                                                    <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                                                                 </div>
                                                      </div> 
                                                            </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblServiceID" Visible="false" runat="server" Text=""></asp:Label>
                                 <asp:Label ID="lblFilePath" Visible="false" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="form-group text-center" style="margin-top:15px;">
                        <div class="col-md-4">
                            <span style="color: blue; margin-right:15px;">Field marked with <span style="color: Red">* </span>are mandatory</span>
                        </div>
                        <div  class="col-md-4 text-center">
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-primary btn-sm" style="margin:0 1px 0 0;width:65px;"  OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-primary btn-sm" style="margin:0 1px 0 0;width:65px;"  OnClick="btnClear_Click" />
                        </div>
                        <div  class="col-md-4"></div>

                        
                    </div>

                 
                    <br />
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
        <br />
        <div class="clearfix"></div>
        <div class="panel panel-default">
            <p class="panel-heading font-bold text-center">List of Office Orders</p>
            <div class="panel-body">
                <asp:GridView ID="GridView2" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table"                              
                                AutoGenerateColumns="False"
                                ClientIDMode  ="Static"
                                DataKeyNames  ="ID,DocPath"
                                GridLines="Horizontal" 
                                OnRowDataBound="GridView2_RowDataBound"
                                OnRowCommand="GridView2_RowCommand"
                                Width="100%" 
                                OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
                                PagerStyle-CssClass="pagination-ys" 
                                PagerStyle-HorizontalAlign="Right">
                                <Columns>
                                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    <asp:BoundField DataField="OrderRefNo" ItemStyle-HorizontalAlign="Justify" HeaderText="Order Ref No" SortExpression="OrderRefNo"/>
                                    <asp:BoundField DataField="Category" ItemStyle-HorizontalAlign="Justify" HeaderText="Category" SortExpression="Category"/>
                                    <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" SortExpression="IssueDate" />
                                    <asp:BoundField DataField="IssuedBy" ItemStyle-HorizontalAlign="Justify" HeaderText="Issued By" SortExpression="IssuedBy" />
                                    <asp:BoundField DataField="Section" HeaderText="Section" SortExpression="Section" />
                                    <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                    <asp:BoundField DataField="PublicPrivate" HeaderText="Visibility" SortExpression="PublicPrivate" />


                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnDownload"  ToolTip="Download Office Order" Text='<i class="fa fa-download" aria-hidden="true"></i>'  CommandName="Download" CausesValidation="false" CommandArgument='<%# (Container.DataItemIndex) %>' />
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnEdit"  ToolTip="Edit Record" Text='<i class="fa fa-pencil-square-o" aria-hidden="true"></i>'  CommandName="EditRow" CausesValidation="false" CommandArgument='<%# (Container.DataItemIndex) %>' />
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnDel"  ToolTip="Delete Record" Text='<i class="fa fa-times" aria-hidden="true"></i>'  CommandName="DeleteRow" CausesValidation="false" CommandArgument='<%# (Container.DataItemIndex) %>' />
                                              </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    No Record Available
                                </EmptyDataTemplate>
                            </asp:GridView>
            </div>
        </div>
        <footer>
            <div>
                <div class="row">
                    
                </div>

            </div>

        </footer>

    </div>
</asp:Content>
