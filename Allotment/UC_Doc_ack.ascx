<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Doc_ack.ascx.cs" Inherits="Allotment.UC_Doc_ack" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>
<style>
    .modal-backdrop.fade {
    display:none !important;
    }
    .assess-min-height {
        min-height:628px !important;
    }
    .PreviewClass {
        color: red;
    }

    .input-sm {
        height: 20px !important;
    }

    .request-table tr th[colspan='4'] {
        padding: 0 !important;
    }
</style>
 <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();

            $(".MultiSelect").chosen(
               


            );
     }

    
      function openModal() {
               $('#PlotModal').modal('show');
           }
       function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;
 
            //Get the reference of GridView
            var GridView = row.parentNode;
 
            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");
 
            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];
 
                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;
 
        }
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        if (row.rowIndex % 2 == 0) {
                           // row.style.backgroundColor = "#C2D69B";
                        }
                        else {
                            //row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }
   

    </script>


<cc1:MessageBox ID="MessageBox1" runat="server" />
<div runat="server" id="BuildingDiv" visible="false">


    
    <div class="col-md-4 col-sm-4 col-xs-6 check-left">
        <div class="div-checklist assess-min-height" style="border: 1px solid #ccc;max-height: 439px;overflow-y: auto;min-height: 628px;">
 <asp:Label ID="lblServiceReqNo" runat="server" Visible="false"></asp:Label>
            <div class="panel-heading font-bold">Facts
                <asp:Button runat="server" Text="Lock Data" ID="LockBPData" OnClick="LockBPData_Click" CssClass="btn btn-sm btn-primary"  Style="float: right;padding: 0px 8px !important;background: #ffc511;color: #000;" /></div>
            <div class="panel panel-default">
                <div class="panel-body gallery">
                   
                           
                                   <div class="panel-heading">List Of Documents To Be Received</div>
                               <div class="Annexure">
                                  
                                   <asp:GridView ID="GridView2" runat="server" 
                                                    CssClass="table table-striped table-bordered table-hover request-table"
                                                   
                                                    AutoGenerateColumns="False"
                                                    DataKeyNames="ServiceCheckListsID"
                                                    GridLines="Horizontal" 
                                                 
                                                    Width="100%"
                                                    >
                                                    <Columns>
                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			                            </ItemTemplate>
																		                            </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="ServiceCheckListsID" HeaderStyle-HorizontalAlign="Center" Visible="false" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblCheckListID" runat="server" Text='<%#Eval("ServiceCheckListsID")%>'> </asp:Label>
																			                            </ItemTemplate>
																		                            </asp:TemplateField>
                                                        <asp:BoundField DataField="ServiceTimeLinesCondition" HeaderText="Checklist" SortExpression="ServiceTimeLinesCondition" />
                                                        <asp:BoundField DataField="ServiceTimeLinesDocuments" HeaderText="Checklist Description" SortExpression="ServiceTimeLinesDocuments" />
                           
                            
                            <asp:TemplateField>
                                                      
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        No Record Available
                                                    </EmptyDataTemplate>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle Font-Bold="True" ForeColor="Black" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <RowStyle ForeColor="#000066" HorizontalAlign="Left" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
                                </div>
    <b>List Of Received Documents</b>
                    <div>
  <asp:GridView ID="GridView1" runat="server" 
                                                    CssClass="table table-striped table-bordered table-hover request-table"
                                                   
                                                    AutoGenerateColumns="False"
                                                    DataKeyNames="CheckListID"
                                                    GridLines="Horizontal" 
                                                 
                                                    Width="100%"
                                                    >
                                                    <Columns>
                                                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			                            </ItemTemplate>
																		                            </asp:TemplateField>
                                                        <asp:BoundField DataField="CheckListHead" HeaderText="Checklist" SortExpression="CheckListHead" />
                                                        <asp:BoundField DataField="CheckListDesc" HeaderText="Checklist Description" SortExpression="CheckListDesc" />


                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        No Record Available
                                                    </EmptyDataTemplate>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle Font-Bold="True" ForeColor="Black" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <RowStyle ForeColor="#000066" HorizontalAlign="Left" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
                     <asp:HiddenField runat="server" ID="HiddenField1" />
                            <asp:HiddenField runat="server" ID="HiddenField2" />
                            <asp:HiddenField runat="server" ID="HiddenField3" />
            
                        </div>
                </div>
            </div>
        </div>
    </div>


    <div class="col-md-8 col-sm-8 col-xs-6 check-right">
        <div class="div-assesment-applicant assess-min-height" style="">
            <div class="div-view div-scroll" style="max-height: 628px; overflow-y: auto; border: 1px solid #ccc; background: #fff;">

                <%-- Preview Version  --%>
                <asp:Literal runat="server" ID="Literal2"></asp:Literal>

            </div>
        </div>
    </div>

</div>





<script>
    var prm = Sys.WebForms.PageRequestManager.getInstance(); 

    prm.add_endRequest(function () { 

        AnyChangeCallMe();
        
       
    $("select input").change(function () {

        AnyChangeCallMe();
    });

    $("input[type='text']").keyup(function () {

        AnyChangeCallMe();
    });

    });

    function AnyChangeCallMe() {


        
        $(".DocList").html($(".DocList").html());
        


    }

         
</script>



