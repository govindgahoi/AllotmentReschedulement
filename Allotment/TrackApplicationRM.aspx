<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="TrackApplicationRM.aspx.cs" Inherits="Allotment.TrackApplicationRM" %>

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
                <p class="panel-heading font-bold text-center">Track Application</p>
                <div class="panel-body">
                        <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span>
                                Application Type :
                            </label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="drpSection" class="input-sm similar-select1" runat="server">
                                   <%-- <asp:ListItem Value="---Select Section---">---Select Section---</asp:ListItem>
                                    <asp:ListItem Value="Plannig">Planning</asp:ListItem>
                                    <asp:ListItem Value="Land">Land</asp:ListItem>                                     
                                    <asp:ListItem Value="Infra">Infra</asp:ListItem>--%>
                                    
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
                                <span style="color: Red">*</span> Regional Office :
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
                                Letter Date :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtIssuedDate" runat="server" class="date input-sm similar-select1 span12"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span>
                                Letter No :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtLetterNo" runat="server" class="input-sm similar-select1 span12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span> Industrial Area Name :
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
                                Remark :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtDescription" runat="server" class="input-sm similar-select1 span12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                        <%-- <asp:BoundField DataField="Section" HeaderText="Section" SortExpression="Section" />--%>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span> Plot No :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtServiceId" runat="server" class="input-sm similar-select1 span12"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ErrorMessage="Issued by can't be left blank" ControlToValidate="txtIssuedBy"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                    </div>
                      
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                                                       <div class="row">
                                                                <label class="col-md-3 text-right">
                                                                   Letter Copy :
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
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span>
                                Grievance Received Date :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtGRDate" runat="server" class="date input-sm similar-select1 span12"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <div class="row">
                            <label class="col-md-3 text-right">
                                <span style="color: Red">*</span>
                                Status :
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtStatusRM" runat="server" class="input-sm similar-select1 span12"></asp:TextBox>
								<asp:RequiredFieldValidator id="reqStatusRM" Text="Status cannot be blank" InitialValue="" ControlToValidate="txtStatusRM" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" Runat="server" />
								<asp:RegularExpressionValidator ID="RegExp1" runat="server" ForeColor="Red" ErrorMessage="Status must have minimum 4 characters" ControlToValidate="txtStatusRM" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{4,10000000}$" />
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
                    <div class="form-group text-center" style="margin-top:15px;">
                        <div class="col-md-4">
                            <span style="color: blue; margin-right:15px;">Field marked with <span style="color: Red">* </span>are mandatory</span>
                        </div>
                        <div  class="col-md-4 text-center">
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-primary btn-sm" style="margin:0 1px 0 0;width:65px;"  OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-primary btn-sm" style="margin:0 1px 0 0;width:65px;"  OnClick="btnClear_Click" />
                            <asp:Label ID="lblFilePath" runat="server" Visible="False" ></asp:Label>
                            <asp:Label ID="lblID" runat="server" Visible="False" ></asp:Label>
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
            <p class="panel-heading font-bold text-center">List of Track Application</p>
            <div class="panel-body">
                <asp:GridView ID="GridView2" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table"                              
                                AutoGenerateColumns="False"
                                ClientIDMode  ="Static"
                                DataKeyNames  ="ID,LetterCopyfile"
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


                                   <%-- SELECT ID,ApplicationType,,,Description,serviceRequestNo,LetterCopyfile,CreateDate--%>
                                    <asp:BoundField DataField="ID" ItemStyle-HorizontalAlign="Justify" HeaderText="ID" SortExpression="ID"/>
                                     <asp:BoundField DataField="Subject" HeaderText="Regional Office" SortExpression="Subject" />
                                    <asp:BoundField DataField="LetterNO" ItemStyle-HorizontalAlign="Justify" HeaderText="Letter Number" SortExpression="Lette No"/>
                                    <asp:BoundField DataField="ApplicationType" ItemStyle-HorizontalAlign="Justify" HeaderText="Application Type" SortExpression="Category"/>
                                    <asp:BoundField DataField="IssueDate" HeaderText="Letter Date" SortExpression="IssueDate" />
                                    <asp:BoundField DataField="ForwardedTo" ItemStyle-HorizontalAlign="Justify" HeaderText="Industrial Area Name" SortExpression="IssuedBy" />
                                   <%-- <asp:BoundField DataField="Section" HeaderText="Section" SortExpression="Section" />--%>
                                   
                                    <asp:BoundField DataField="Description" HeaderText="Land Use" SortExpression="Description" />
                                    <asp:BoundField DataField="ServiceRequestNo" HeaderText="Plot No" SortExpression="Service RequestNo" />
                                     <asp:BoundField DataField="CreateDate" HeaderText="Create Date" SortExpression="CreateDate" />
                                   <%-- <asp:BoundField DataField="LetterCopyfile" HeaderText="FileName" SortExpression="FileName" />--%>
                                     <asp:BoundField DataField="GRDate" HeaderText="Grievance Date" SortExpression="GR Date" />
                                    <asp:BoundField DataField="Status" HeaderText="Current Status" SortExpression="GR Date" />
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
