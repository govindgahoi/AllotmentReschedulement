<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_RejectionLetterDataFacts.ascx.cs" Inherits="Allotment.UC_RejectionLetterDataFacts" %>


<style>
    .content {
        border-left:0 solid #ccc;
    }
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

   

    </script>



<div class="row" runat="server" id="CancelDiv" visible="false">


      
    <asp:Label runat="server" ID="lblServiceReqNo" Visible="false"></asp:Label>

    <div class="col-md-4 col-sm-4 col-xs-6 check-left">
        <div class="div-checklist assess-min-height" style="border: 1px solid #ccc;">
            <div class="panel-heading font-bold">Facts
                <asp:Button runat="server" Text="Lock Data" ID="btnLockPlotCancel" CssClass="btn btn-sm btn-primary" OnClick="btnLockPlotCancel_Click" Style="float: right;padding: 0px 8px !important;background: #ffc511;color: #000;" /></div>

            <%-- Priyanshu Design And Seeting data  --%>
            <div class="panel panel-default">
                <div class="panel-body">
                    <div>
                        <div class="col-md-12" style="padding:0px !important;">
                        
                            <div class="panel-heading">Nivesh Mitra Rejection Type</div>
                           <div ><asp:DropDownList ID="drp_NMObjectionType" runat="server" CssClass="input-sm similar-select1 margin-left-z">
                            
                        </asp:DropDownList></div>
                           
                                   <div class="panel-heading">List Of Reasons</div>

                               <div class="Clause_table">
                                   <div class="table-responsive">
                                       <asp:GridView ID="ClauseGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="ClauseDelete_Click">
																	                            <Columns>


																		                            <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			                            </ItemTemplate>
																		                            </asp:TemplateField>


																		                            <asp:TemplateField HeaderText="Clause" FooterStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblClause" runat="server" Text='<%#Eval("Clause") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtReasonRej" TextMode="MultiLine" Style="min-height:80px;"  CssClass="input-sm similar-select1 margin-left-z" runat="server"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																		                            

																		                            <asp:TemplateField FooterStyle-CssClass="hide_me" ItemStyle-CssClass="hide_me" HeaderStyle-CssClass="hide_me">
																			                            <ItemTemplate>
																				                            <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />

																			                            </ItemTemplate>
																			                            <FooterStyle HorizontalAlign="Right" />
																			                            <FooterTemplate>
																				                               <asp:Button runat="server" ID="BtnSave" OnClick="insert_clause_details" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />

																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>
                                    </div>

                                </div>


                           
                           
                             
                        </div>
                       
                    </div>

                     <asp:HiddenField runat="server" ID="lblResultSet1" />
                            <asp:HiddenField runat="server" ID="lblResultSet2" />
                            <asp:HiddenField runat="server" ID="lblResultSet3" />
            

                </div>
            </div>
        </div>
    </div>


    <div class="col-md-8 col-sm-8 col-xs-6 check-right">
        <div class="div-assesment-applicant assess-min-height" style="">
            <div class="div-view div-scroll" style="max-height:628px;overflow-y:auto;border: 1px solid #ccc; background: #fff;">

                <%-- Preview Version  --%>
                <asp:Literal runat="server" ID="Literal3"></asp:Literal>

            </div>
        </div>
    </div>
</div>


<script>

    function AnyChangeCallMe() {

       
            $(".lblPlotNo").html($(".PlotNo").val());
            $(".ListofClause").html($(".Clause_table").html());
                  
    }



    $(document).ready(function () {   
        AnyChangeCallMe();
        
    $("select input").change(function () {
        AnyChangeCallMe();
    });

    $("input[type='text']").keyup(function () {
        AnyChangeCallMe();
    });

   
    });

    //Re-bind for callbacks
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

  

   

</script>



