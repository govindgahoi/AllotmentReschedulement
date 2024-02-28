<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Service_Applicant_Detail.ascx.cs" Inherits="Allotment.UC_Service_Applicant_Detail" %>




<div runat="server" id="uc_alloottee_details" class="row">
    <div class="col-md-12 col-sm-12 col-xs-12" style="padding: 0;">





             <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-xs-12">

                                                            <div class="panel panel-default">
                                                                <div class="panel-heading font-bold">
                                                                    Applicant Details  <span class="pull-right">Application No: <asp:Label ID="lblApplicationNo" runat="server" CssClass="font-bold"></asp:Label></span>                       
                                                                </div>
                                                                <div class="panel-body" style="padding: 0px !important;">
                                                                    <div class="div-companydetail" style="background: #ececec;">
                                                                        <div class="form-group">
                                                                            <div class="row">
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Regional Office :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblRegionalOffice" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Industrial Area : 
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblIndustrialArea" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />
                                                                        <div class="form-group">
                                                                            <div class="row">
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Date of Application :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblDateofApplication" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Required Plot Size :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblRequiredplot" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />

                                                                        <div class="form-group">
                                                                            <div class="row">
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Firm/Company Name :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblFirmCompanyName" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Firm/Company Constitution :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblCompanyConstitution" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />
                                                                        <div class="form-group">
                                                                            <div class="row">

                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Firm/Company PAN No :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="Label1" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Firm/Company CIN No :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblCinNo" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />

                                                                        <div class="form-group">
                                                                            <div class="row">

                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Authorised Signatory :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblAuthorisedSignatory" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Signatory Mobile :
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblSignatoryMobile" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />
                                                                        <div class="form-group">
                                                                            <div class="row">
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Address :   
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblAddress" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                                    Signatory Email : 
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6">
                                                                                    <span class="pull-right text-muted small"><em>
                                                                                        <asp:Label ID="lblSIgnatoryEmail" runat="server" CssClass="font-bold"></asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />
                                                                        <div class="form-group">
                                                                            <div class="row">
                                                                                <label class="col-md-6 col-sm-6 col-xs-6 text-right font-bold" style="width:58%;    font-size: 13px !important;">
                                                                                    Application Current Status:
                                                                                </label>
                                                                                <div class="col-md-3 col-sm-6 col-xs-6" style="width:32%;"">
                                                                                    <span class="pull-left text-muted small"><em>
                                                                                        <asp:Label ID="lblStatusAsonDate" runat="server" CssClass="font-bold"> </asp:Label></em>
                                                                                    </span>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />

                                                                    </div>


                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 col-sm-12 col-xs-12">


                                                            <div class="panel panel-default">
                                                                <p class="panel-heading font-bold" runat="server" id="P2">Shareholding</p>
                                                                <div class="panel-body gallery">

                                                                    <asp:Label ID="Label32" runat="server" Text=""></asp:Label>
                                                                    <div class="table-responsive">
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
                                                                    </div>
                                                                    <div class="table-responsive">

                                                                        <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
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
                                                                    </div>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
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
                                                                    </div>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
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
                                                                    </div>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
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
                                                                    </div>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover request-table" Visible="false">
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

                                                    </div>







          <div class="row" >
                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="allottee-details-div">
                                                <div class="panel panel-default">
                                                    <div class="panel-heading font-bold">
                                                        Project Details                        
                                                    </div>
                                                    <div class="panel-body ">
                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Proposed industry</div>
                                                            <div class="panel-body" style="padding: 0px !important;">
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        <label for="">Description&nbsp;:</label>
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                            </div>
                                                        </div>

                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Project Costing Details</div>
                                                            <div class="panel-body" style="padding: 0px !important;">
                                                                <div class="form-group">
                                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        <label for="">Estimated Cost :</label>
                                                                    </div>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <i class="fa fa-inr"></i> <asp:Label ID="lblEstimatedCost" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        <label for="">Estimated employment:</label>
                                                                    </div>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <i class="fa fa-inr"></i> <asp:Label ID="LabelblEstimatedEmployment" runat="server"></asp:Label>
                                                                    </div> 
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                            </div>
                                                        </div>


                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Layout plan of land indicating broadly</div>
                                                            <div class="panel-body" style="padding: 0px !important;">
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Covered Area&nbsp;(In %)&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblCoveredArea" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Open area required(In %)&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblOpenArea" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                            </div>
                                                        </div>



                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Details of the investment (in <i class="fa fa-inr"></i>)</div>
                                                            <div class="panel-body" style="padding: 0px !important;">
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right" title="date ofsubmission">
                                                                        Land&nbsp;(In Lacs)&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <i class="fa fa-inr"></i> <asp:Label ID="lblLand" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Building&nbsp;(In Lacs)&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <i class="fa fa-inr"></i> <asp:Label ID="lblBuilding" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Machinery & Equipments&nbsp;(In Lacs)&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <i class="fa fa-inr"></i> <asp:Label ID="lblMachineryEquipment" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Other Fixed Assets&nbsp;(In Lacs)&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <i class="fa fa-inr"></i> <asp:Label ID="lblOtherAssets" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Other Expenses&nbsp;(In Lacs)&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <i class="fa fa-inr"></i> <asp:Label ID="lblOtherExpenses" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />

                                                            </div>
                                                        </div>



                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Any fumes generated in the process of manufacture and if so, their nature and quantity &nbsp; <span runat="server" id="Span1"></span></div>
                                                            <div class="panel-body" style="padding: 0px !important;" id="Div3" runat="server" visible="false">
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Nature&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblNature" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                        Quantity&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                            </div>
                                                        </div>



                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Industrial Effluents </div>
                                                            <div class="panel-body" style="padding: 0px !important;">
                                                                <table class="table table-hover table-bordered request-table" style="width: 100%;">
                                                                    <tr>
                                                                        <th style="width: 24%;text-align:center;">Name</th>
                                                                        <th style="width: 38%;text-align:center;">Quantity</th>
                                                                        <th style="width: 38%;text-align:center;">Chemical Composition</th>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><span class="pull-right">(i)&nbsp;Solid :</span></td>
                                                                        <td>
                                                                            <asp:Label ID="lblQtySolid" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblChemicalSolid" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><span class="pull-right">(ii)&nbsp;Liquid :</span></td>
                                                                        <td>
                                                                            <asp:Label ID="lblQtyLiquid" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblChemicalLiquid" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><span class="pull-right">(iii)&nbsp;Gaseous :</span></td>
                                                                        <td>
                                                                            <asp:Label ID="lblQtyGaseous" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblChemicalGaseous" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </table>



                                                            </div>
                                                        </div>



                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Effluent Treatment Measures</div>
                                                            <div class="panel-body" style="padding: 0px !important;">


                                                                <div class="row aks-row">

                                                                    <div class="col-md-4 col-sm-12 col-xs-12 form-inline font-12px">
                                                                        <asp:Label ID="lblmeasure1" runat="server"></asp:Label></div>

                                                                    <div class="col-md-4 col-sm-12 col-xs-12 form-inline font-12px">
                                                                        <asp:Label ID="lblmeasure2" runat="server"></asp:Label>

                                                                    </div>



                                                                    <div class="col-md-4 col-sm-12 col-xs-12 form-inline font-12px">
                                                                        <asp:Label ID="lblmeasure3" runat="server"></asp:Label></div>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>

                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Power Requirement (in KW)</div>
                                                            <div class="panel-body" style="padding: 0px !important;">


                                                                <div class="form-group">

                                                                    <label class="col-md-3 col-sm-6 col-xs-6 form-inline text-right">Units &nbsp;:</label>

                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblUnits" runat="server"></asp:Label>

                                                                    </div>


                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                            </div>
                                                        </div>

                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Telephone Requirement</div>
                                                            <div class="panel-body" style="padding: 0px !important;">


                                                                <div class="form-group">

                                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">First Year&nbsp;:</div>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblFirstYear1" runat="server"></asp:Label>&nbsp;&nbsp;
                               <asp:Label ID="lblFirstYear2" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                                <div class="form-group">
                                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">Ultimate Requirement&nbsp;:</div>
                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblUltimateRequirement1" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;
                              <asp:Label ID="lblUltimateRequirement2" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <hr class="myhrline" />
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="sub-heading font-bold">Other Relevant Information</div>
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                    Net Worth Turnover :
                                                                </label>
                                                                <div class="col-md-9 col-sm-6 col-xs-6">
                                                                    <asp:Label ID="lblNetworth" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                    Expansion Of Land :
                                                                </label>
                                                                <div class="col-md-9 col-sm-6 col-xs-6">
                                                                    <asp:Label ID="lblExpansionland" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                                    100% Export Oriented Industry :
                                                                </label>
                                                                <div class="col-md-9 col-sm-6 col-xs-6">
                                                                    <asp:Label ID="lblExportOriented" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="panel panel-default">
                                                            <div class="sub-heading font-bold">Is the applicant under priority category ? Please specify clearly &nbsp; <span runat="server" id="Span2"></span></div>
                                                            <div id="Div4" class="panel-body" style="padding: 0px !important;" runat="server" visible="false">
                                                                <div class="row aks-row">


                                                                    <div class="col-md-3 col-sm-6 col-xs-6">Specification&nbsp;:</div>

                                                                    <div class="col-md-9 col-sm-6 col-xs-6">
                                                                        <asp:Label ID="lblSpecification" runat="server"></asp:Label></div>

                                                                </div>
                                                            </div>
                                                        </div>



                                                    </div>
                                                </div>

                                                </div>

                                            </div>


                                        </div>




    </div>
</div>

