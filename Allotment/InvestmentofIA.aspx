<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="InvestmentofIA.aspx.cs" Inherits="Allotment.InvestmentofIA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="js/loader.js"></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">

                <div style="display:none">

                <table id="tblsearch" class="table table-striped table-bordered table-hover  margin-b-2px request-table">
                    <tr style="background: #ececec;">
                        <td class="font-bold">
                            <span style="color: Red">*</span>
                            Office to which Allottee belongs :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddloffice" AutoPostBack="true" runat="server" OnSelectedIndexChanged="Regional_Changed" CssClass="btn btn-sm btn-default dropdown-toggle similar-select">
                            </asp:DropDownList>
                        </td>
                        <td class="font-bold">
                            <span style="color: Red">*</span>
                            Industrial Area Name :
                        </td>
                        <td>
                            <asp:DropDownList ID="drpdwnIA" runat="server"  CssClass="btn btn-sm btn-default dropdown-toggle similar-select" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpdwnIA" InitialValue="0"
                                ErrorMessage="Select Industrial Area" ValidationGroup="ValidationButton" ToolTip=" Select Industrial Area"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <div class="panel-heading">
                    <div class="col-md-6" style="margin-top:6px;">
                        <b>Existing Allottees Record</b>
                    </div>
                    <div class="input-group col-md-4 col-sm-12" style="float:right;padding:2px;">
                        <asp:TextBox ID="txtSearch" Width="100%" CssClass="input-sm" runat="server" AutoPostBack="true"/>
                        <span class="input-group-btn">
                        <button class="btn btn-sm btn-primary" type="button"style="padding:2px 10px;color:#fff;"><i style="color:#fff;" class="fa fa-search" aria-hidden="true"></i></button>
                        </span>
                    </div>
                    <div class="clearfix"></div>                                            
                </div>                                    
                <div class="panel-body">
     <%--               <asp:GridView ID="Allottee_master_grid" runat="server"  PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" CssClass="request-table table table-striped table-bordered table-hover" OnSorting="Allottee_master_grid_Sorting"  OnPageIndexChanging="OnPageIndexChanging"   AutoGenerateColumns="true" AllowPaging="True"  AllowSorting="True"  PageSize="5"> 
</asp:GridView> --%>
                </div>
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-2 text-right">
                            Name :
                        </label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtName" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-2 text-right">
                            Plot No :
                        </label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtPlotNo" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
          
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-2 text-right">
                            Area :
                        </label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtArea" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-2 text-right">
                            Project Cost (in lakh) :
                        </label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtProjectCost" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-2 text-right">
                            Project Type :
                        </label>
                        <div class="col-md-10">
                            <asp:DropDownList ID="ddlProjectType" runat="server" CssClass="input-sm similar-select1">
                                <asp:ListItem Text="Please Select"/>
                                <asp:ListItem Text="Transfer"  Value="T" />
                                <asp:ListItem Text="In Process" Value="P" />
                                <asp:ListItem Text="Approved" Value="A" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <p><asp:Button ID="btnSave" style="margin:15px 1px 0 0;width:65px;" CssClass="btn-primary btn-sm" runat="server"  Text="Save" /></p>
               
                </div>
                
                <div class="clearfix"></div>
                <div class="row" style="border:1px solid #ccc;margin:10px 0;">
                    <div class="pie-chart col-md-12" >

                                 <div class="col-md-4 pie-char-details" style="min-height: 250px;background: #f7f7f7;border-left: 4px solid #36c;padding:25px;">
                            <div>
                     <asp:GridView ID="gridsummary" runat="server"   PagerStyle-HorizontalAlign="Right" CssClass="request-table table table-striped table-bordered table-hover"   AutoGenerateColumns="true" > 
</asp:GridView> 

                            </div>
                        </div>

                        <div class="col-md-8">
                            
                            <div id="piechart_3d" style="width: 100%; height: 250px;"></div>

                             <asp:Literal ID="lt" runat="server" ></asp:Literal>
                            
                        </div>
               
                    </div>
                </div>
                <div class="row" style="border:1px solid #ccc;margin:10px 0;">
                    <div  class="bar-chart col-md-12">
                        <div id="dual_x_div" style="width: 900px;height:700px;"></div>
                        <asp:Literal ID="lt1" runat="server" ></asp:Literal>
                    </div>
                </div>
                    
             

                  <div class="clearfix"></div>
           <div class="panel panel-default">
<div class="panel-heading">
    <div class="col-md-8">
        <h4 class="panel-title">
        <a class="accordion-toggle in" data-toggle="collapse" data-parent="#accordion" aria-expanded="true" href="#menuFore">  
            <span class="glyphicon glyphicon-minus"></span>               
        Project Investment Detail View
        </a>
        </h4>
    </div>
    <div class="col-md-4 input-group">
        <asp:TextBox id="txtsearch1" runat="server" Width="100%" CssClass="input-sm" OnTextChanged="txtsearch_TextChanged" onfocus="javascript:  this.value = '';"  AutoPostBack="true"></asp:TextBox>
        <span class="input-group-btn">            
            <button class="btn btn-sm btn-primary" type="button"><i class="fa fa-search" style="padding:2px 0;color:#fff;"></i></button>
        </span>
    </div>
    <div class="clearfix"></div>

</div>
<div id="menuFore" class="panel-collapse collapse in">

                         <div class="panel-body">
                             <asp:GridView ID="Allottee_master_grid" 
                                 runat="server"  ShowFooter="true"
                                 PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" 
                                 CssClass="request-table table table-striped table-bordered table-hover" 
                                 OnSorting="Allottee_master_grid_Sorting" 
                                 OnPageIndexChanging="OnPageIndexChanging" 
                                 AutoGenerateColumns="false" AllowPaging="True" AllowSorting="True" PageSize="10"
                                  OnDataBound = "OnDataBound_investment">




                                 <Columns>

                                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                         <ItemTemplate>
                                             <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Regional Office">
                                         <ItemTemplate>
                                             <asp:Label ID="LBLPaymentMode" runat="server" Text='<%#Eval("RegionalOffice") %>'></asp:Label>
                                         </ItemTemplate>

                                     </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Industrial Area">
                                         <ItemTemplate>
                                             <asp:Label ID="LBLIAName" runat="server" Text='<%#Eval("IAName") %>'></asp:Label>
                                         </ItemTemplate>
                                         <FooterTemplate>

                                             <asp:DropDownList ID="drpIndustrialArea"  CssClass="input-sm similar-select1" runat="server">
                     
                                             </asp:DropDownList>
                                         </FooterTemplate>
                                     </asp:TemplateField>





                                     <asp:TemplateField HeaderText="Name">
                                         <ItemTemplate>
                                             <asp:Label ID="LBLname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                                         </ItemTemplate>
                                         <FooterTemplate>
                                             <asp:TextBox ID="txtname"  placeholder="Name"  CssClass="input-sm similar-select1" runat="server"></asp:TextBox></FooterTemplate>
                                     </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Plot No">
                                         <ItemTemplate>
                                             <asp:Label ID="lblplotNo" runat="server" Text='<%#Eval("plot_no") %>'></asp:Label>
                                         </ItemTemplate>
                                         <FooterTemplate>
                                             <asp:TextBox ID="txtplotNo" placeholder="Plot No" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                          
                                         </FooterTemplate>
                                     </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Plot Area<br/>(In Sq.M.)">
                                         <ItemTemplate>
                                             <asp:Label ID="lblplotareaNo" runat="server" Text='<%#Eval("area") %>'></asp:Label>
                                         </ItemTemplate>
                                         <FooterTemplate>
                                             <asp:TextBox ID="txtplotareaSize" placeholder="Plot Area" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                         </FooterTemplate>
                                     </asp:TemplateField>


                                     

                                     <asp:TemplateField HeaderText="Project Cost<br/>(in Lakhs)">
                                         <ItemTemplate>
                                             <asp:Label ID="lblproject_cost" runat="server" Text='<%#Eval("project_cost") %>'></asp:Label></ItemTemplate>
                                         <FooterTemplate>
                                             <asp:TextBox ID="txtproject_cost"  placeholder="Project Cost (in Lakhs)" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);"></asp:TextBox></FooterTemplate>
                                     </asp:TemplateField>


                                      <asp:TemplateField HeaderText="Current Cost<br/>(in Lakhs)">
                                         <ItemTemplate>
                                             <asp:Label ID="lblcurrent_cost" runat="server" Text='<%#Eval("Current_cost") %>'></asp:Label></ItemTemplate>
                                         <FooterTemplate>
                                             <asp:TextBox ID="txtcurrent_cost" placeholder="Current Cost (in Lakhs)" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);"></asp:TextBox></FooterTemplate>
                                     </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Employment Projected">
                                         <ItemTemplate>
                                             <asp:Label ID="lblempl_projected" runat="server" Text='<%#Eval("Employment_Projected") %>'></asp:Label></ItemTemplate>
                                         <FooterTemplate>
                                             <asp:TextBox ID="txtempl_projected"  placeholder="Projected" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);"></asp:TextBox></FooterTemplate>
                                     </asp:TemplateField>


                                      <asp:TemplateField HeaderText="Employment Generated</br>as on date">
                                         <ItemTemplate>
                                             <asp:Label ID="lblempl_generated" runat="server" Text='<%#Eval("Employment_Genreted") %>'></asp:Label></ItemTemplate>
                                         <FooterTemplate>
                                             <asp:TextBox ID="txtempl_generated"  placeholder="Generated" runat="server" CssClass="input-sm similar-select1" ToolTip="Employment Generated (in Lakhs) -- (only Numeric Value)" onkeypress="return isDecimalKey(event);"></asp:TextBox></FooterTemplate>
                                     </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Investment Type">
                                         <ItemTemplate>
                                             <asp:Label ID="lblInvestment_Type" runat="server" Text='<%#Eval("Investment_Type") %>'></asp:Label></ItemTemplate>
                                        <FooterTemplate>
                                             <asp:DropDownList ID="drpdInvestment_Type"  CssClass="input-sm similar-select1" runat="server">
                                                 <asp:ListItem Text="From Transfer of Plots" Value="T"></asp:ListItem>
                                                 <asp:ListItem Text="Approved Allotment in FY" Value="A"></asp:ListItem>
                                                 <asp:ListItem Text="Proposed New Allotment" Value="P"></asp:ListItem>
                                            </asp:DropDownList>
                                        </FooterTemplate>        
                                    </asp:TemplateField>



                                     <asp:TemplateField>
                                    <%--     <ItemTemplate>
                                             <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                 ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="return checkAllotment3()"  OnClick="ButtonAdd_Click"  />

                                         </ItemTemplate>
                                    --%>    

                                         
                                         <FooterStyle HorizontalAlign="Right" />
                                         <FooterTemplate>
                                             <asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square"   OnClick="ButtonAdd_Click" ID ="ButtonAdd" runat="server" Height="16px"
                                                 ImageUrl="~/images/add.png" Width="16px"  />
                                         </FooterTemplate>

                                     </asp:TemplateField>


                                 </Columns>
                             </asp:GridView>



                         </div>

            </div>
        </div>
    </div>


</asp:Content>
