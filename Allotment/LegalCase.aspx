<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="LegalCase.aspx.cs" Inherits="Allotment.LegalCase" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>

    <style type="text/css">
        .check-green {
            color: #3bce3b;
            font-size: 20px;
            line-height: 0.7;
            font-weight: 100;
        }

        .MessagePennel {
            background-color: #f4e542;
            width: 100%;
        }

        .check-cross {
            color: #f70000;
            font-size: 18px;
            line-height: 0.7;
            font-weight: 100;
        }
    </style>
    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always"  >
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
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12" style="background: #dbdbdb;">
            <div>
                <div style="width: 100px; float: left; background: #dbdbdb; font-size: 11px;" class="text-center">
                    <br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                        <li class="disabled">
                            <a runat="server" onserverclick="Home_ServerClick">
                                <i class="fa fa-home" aria-hidden="true"></i>
                                <br />
                                Home
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left; background: #dbdbdb; border-left: 1px solid #000; font-size: 11px;" class="text-center">
                    Operate<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                        <li>
                            <a runat="server" id="SaveEntry" onserverclick="SaveEntry_ServerClick">
                                <i class="fa fa-floppy-o " aria-hidden="true"></i>
                                <br />
                                Save
                            </a>
                        </li>
                        <li>
                            <a runat="server" onserverclick="Reset_ServerClick">
                                <i class="fa fa-refresh" aria-hidden="true"></i>
                                <br />
                                Refresh
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left; background: #dbdbdb; border-left: 1px solid #000; border-right: 1px solid #000; font-size: 11px;" class="text-center">
                    Legal Registration<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-plus" aria-hidden="true"></i>
                                <br />
                                New
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                <br />
                                History
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left; background: #dbdbdb; font-size: 11px;" class="text-center">
                    Navigation<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-step-backward" aria-hidden="true"></i>
                                <br />
                                Last
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-angle-double-left" aria-hidden="true"></i>
                                <br />
                                Previous
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-angle-double-right" aria-hidden="true"></i>
                                <br />
                                Next
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-step-forward" aria-hidden="true"></i>
                                <br />
                                Final
                            </a>
                        </li>
                        <li runat="server" id="hrefPrint" visible="false">
                            <a runat="server" onclick="PrintElem()">
                                <i class="fa fa-print" aria-hidden="true"></i>
                                <br />
                                Print
                            </a>
                        </li>
                    </ul>
                </div>

            </div>
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="col-md-12 col-sm-12 col-xs-12 text-center">
        <p>Legal Case History</p>
    </div>
    <div class="form-group">
        <label class="col-md-3 col-sm-12 col-xs-12 text-right">
            Case Releted To :
        </label>
        <div class="col-md-9 col-sm-12 col-xs-12">
            <asp:DropDownList ID="ddllegalcase" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddllegalcase_SelectedIndexChanged" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
            </asp:DropDownList>
            <asp:CheckBox ID="chbregional" runat="server" Text="Is Matter relating regional Offices" AutoPostBack="true" OnCheckedChanged="chbregional_CheckedChanged" />
        </div>
    </div>
    <div class="form-group" id="plotrelating" runat="server" visible="false" style="background: #ececec; margin: 3px 0; padding: 3px 0;">
        <label class="col-md-2 col-sm-6 col-xs-6 font-bold text-right" style="margin-top: 4px;">
            <span style="color: Red">*</span>
            Regional Office :
        </label>
        <div class="col-md-2 col-sm-6 col-xs-6">
            <asp:DropDownList ID="ddloffice" AutoPostBack="true" name="state" OnSelectedIndexChanged="Regional_Changed" runat="server" CssClass="dropdown_search dropdown-toggle similar-select1" Style="width: 180px; background: #ffffff;">
            </asp:DropDownList>
        </div>
        <label class="col-md-2 col-sm-6 col-xs-6 font-bold text-right" style="margin-top: 4px;">
            <span style="color: Red">*</span>
            Industrial Area Name :
        </label>
        <div class="col-md-2 col-sm-6 col-xs-6">
            <asp:DropDownList ID="drpdwnIA" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged" CssClass="dropdown_search dropdown-toggle similar-select1" Style="width: 180px; background: #ffffff;"></asp:DropDownList>
        </div>

        <div class="clearfix"></div>
    </div>
    <hr style="margin: 8px 0; border-top: 2px solid #dedddd;" />
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="panel panel-default">
                <div class="panel-heading" style="width: 100%;">
                    <div class="row">
                        <div class="">
                            <div class="col-md-3" style="display: none;">
                                <div class="btn-group">
                                    <asp:Button ID="btnLegalPrevious" runat="server" CssClass="btn btn-sm btn-primary" Style="margin-right: 2px;" Text="Move Previous" />
                                    <asp:Button ID="btnLegalNext" runat="server" CssClass="btn btn-sm btn-primary" Text="Move Next" />
                                </div>
                            </div>
                            <div class="col-md-3" style="display: none;">
                                <div class="btn-group pull-right">
                                    <asp:Button ID="btnLegalSave" Visible="false" runat="server" CssClass="btn btn-sm btn-primary" Text="Save" />

                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="width: 100%;">Please Enter the Details of legal history </div>
                        <div id="divMessageSucess" class="MessagePennel" runat="server" visible="false">
                            <label>
                                <span class="check-green" runat="server" >✔</span>
                                <asp:Label ID="lblSuccessMessage" Text="" runat="server"></asp:Label>
                            </label>
                        </div>
                        <%-- <div id="divMessageError" class="MessagePennel" runat="server" visible="false">
                            <label>
                                <span class="check-cross" runat="server">✖</span>
                                Mandatory field Need to be Fill
                                <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
                            </label>
                        </div>--%>
                        <div id="divMessage" class="MessagePennel"  style="display: none">
                            <label>
                                <span class="check-cross" runat="server">✖</span>
                                Mandatory field Need to be Fill
                                <asp:Label ID="lblMessage"  Text=""></asp:Label>
                            </label>
                        </div>
                        <div class="form-group" id="plotNumber" runat="server">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                <span style="color: Red">*</span>
                                Plot Number :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:DropDownList ID="ddlPlotNumber" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPlotNumber_SelectedIndexChanged" CssClass="btn btn-sm btn-default dropdown-toggle similar-select1"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group hidden">
                            <span style="color: Red">*</span>
                            <label class="col-md-3 col-sm-6 col-xs-6 text-right">
                                Applicant Id :
                            </label>
                            <div class="col-md-9 col-sm-6 col-xs-6 hidden">
                                <em class="text-muted small">
                                    <asp:Label ID="lblletterno" runat="server"></asp:Label></em>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                <span style="color: Red">*</span>
                                Case :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtCaseNo" runat="server" onblur="return validatextcase()"  CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                            </div>
                        </div>
                         <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                               Date of Registration:
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtNextHearingDate" runat="server" CssClass="date input-sm similar-select1 margin-left-z" placeholder="dd/mm/yyyy"></asp:TextBox>
                            </div>
                        </div>

                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                <span style="color: Red">*</span>
                                Whether We Are :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:RadioButtonList ID="radio1" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem style="padding-right: 21px;">Respondent</asp:ListItem>
                                    <asp:ListItem>Petitioner</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                <span style="color: Red">*</span>
                                LT. Party Name :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtLtPartyName" runat="server"  onblur="return validateLtPartyName()" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                <span style="color: Red">*</span>
                                Jurisdiction :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:DropDownList ID="DdlJurisdiction" runat="server" onblur="return validateDdlJurisdiction()"  CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                <span style="color: Red">*</span>
                                Court Details :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtCourtDetails" runat="server"  onblur="return validateCourtDetails()" CssClass="input-sm similar-select1 margin-left-z" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                <span style="color: Red">*</span>
                                In Court Of :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtInCourtof" runat="server"  onblur="return validateInCourtof()" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                <span style="color: Red">*</span>
                                Matter Details :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtMatterDetails" runat="server"  onblur="return validateMatterDetails()" CssClass="input-sm similar-select1 margin-left-z" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                <span style="color: Red">*</span>
                                Case status :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:DropDownList ID="DdlCaseStatus" runat="server"  CssClass="btn btn-sm btn-default dropdown-toggle similar-select1">
                                    <asp:ListItem>---Select--- </asp:ListItem>
                                    <asp:ListItem>Pending</asp:ListItem>
                                    <asp:ListItem>Disposed</asp:ListItem>
                                    <asp:ListItem>Dismissed</asp:ListItem>
                                    <asp:ListItem>Counter Filed</asp:ListItem>
                                    <asp:ListItem>Rejoinder Filed</asp:ListItem>
                                    <asp:ListItem>Notice Filed</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                <span style="color: Red">*</span>
                                Litigating Party :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtLitigatingParty"  onblur="return validateLitigatingParty()" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="panel-heading" style="width: 100%;">Petitioner Advocate</div>
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                Advocate Name :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtPetAdvocateName" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                Address :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtPetAddress" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                Contact No :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtPetContactNo" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="panel-heading" style="width: 100%;">Respondent Advocate</div>
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                Advocate Name :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtResAdvocateName" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                Address :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtResAddress" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                Contact No :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtResContact" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <%-- <div class="panel-heading" style="width: 100%;">Further Details</div>--%>
                        <%--    <div class="form-group">
                            <label class="col-md-3 col-sm-12 col-xs-12 text-right">
                                Current Status :
                            </label>
                            <div class="col-md-9 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtCurrentStatus" runat="server" CssClass="input-sm similar-select1 margin-left-z"></asp:TextBox>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />--%>
                       
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <br />
                        <div class="form-group" style="display: none;">
                            <div class="col-md-6" style="text-align: right;">
                                <asp:Button ID="btnLegalSaveEntry" CssClass="btn btn-sm btn-primary" runat="server" Text="Submit" OnClick="btnLegalSaveEntry_Click" />
                            </div>
                            <div class="col-md-6" style="text-align: left;">
                                <asp:Button ID="Button7" runat="server" CssClass="btn btn-sm btn-primary" Text="Reset" />
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="panel-heading" style="width: 100%; text-align: center;">Case History</div>
                        <div class="table-responsive" id="Divv">

                            <asp:GridView ID="LegalGrid" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" CssClass="table table-striped table-bordered table-hover request-table"
                                PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" OnPageIndexChanging="LegalGrid_PageIndexChanging" OnRowCommand="LegalGrid_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CaseNo" HeaderText="Case No" SortExpression="CaseNo" />
                                    <asp:BoundField DataField="CaseDate1" HeaderText="Next Hearing Date" SortExpression="CaseDate1" />
                                    <asp:BoundField DataField="RespondentorPetitioner" HeaderText="We Are" SortExpression="RespondentorPetitioner" />
                                    <asp:BoundField DataField="LTPartyName" HeaderText="LT Party Name" SortExpression="LTPartyName" />
                                    <asp:BoundField DataField="JurisdictioryName" HeaderText="Jurisdiction" SortExpression="JurisdictioryName" />
                                    <asp:BoundField DataField="CourtDetails" HeaderText="Court Details" SortExpression="CourtDetails" />
                                    <asp:BoundField DataField="InCourtOf" HeaderText="In Court Of" SortExpression="InCourtOf" />
                                    <asp:BoundField DataField="MatterDetails" HeaderText="Matter Details" SortExpression="MatterDetails" />
                                    <asp:BoundField DataField="CaseStatus" HeaderText="Case Status" SortExpression="CaseStatus" />
                                    <asp:BoundField DataField="LitigatingParty" HeaderText="Litigating Party" SortExpression="LitigatingParty" />
                                    <asp:BoundField DataField="PetAdvocateName" HeaderText="Petitioner Advocate Name" SortExpression="PetAdvocateName" />
                                    <asp:BoundField DataField="PetAdvocateAddress" HeaderText="Petitioner Advocate Address" SortExpression="PetAdvocateAddress" Visible="false" />
                                    <asp:BoundField DataField="PetAdvocateContact" HeaderText="Petitioner Advocate Contact" SortExpression="PetAdvocateContact" Visible="false" />
                                    <asp:BoundField DataField="ResAdvocateName" HeaderText="Respondent Advocate Name" SortExpression="ResAdvocateName" />
                                    <asp:BoundField DataField="ResAdvocateAddress" HeaderText="Respondent Advocate Address" SortExpression="ResAdvocateAddress" Visible="false" />
                                    <asp:BoundField DataField="ResAdvocateContact" HeaderText="Respondent Advocate Contact" SortExpression="ResAdvocateContact" Visible="false" />
                                    <asp:TemplateField HeaderText="Update">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Process" CommandArgument='<%#Eval("CaseNo") %>' ToolTip="Click here For Update Case History " />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  <%--  <asp:TemplateField HeaderText="Delete">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="DeleteCase" CommandArgument='<%#Eval("CaseNo") %>' ToolTip="Click here to delete History" />
                                            </span>  
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
    </div>

    <script type="text/javascript">
       
     function validateLtPartyName() {
            var LtPartyName = document.getElementById("<%= txtLtPartyName.ClientID %>").value;
            if (LtPartyName == "") {
                document.getElementById("<%= txtLtPartyName.ClientID %>").style.borderColor = "red";
                document.getElementById('divMessage').style.display = 'block';
                //lblMessage.innerHTML = "Please Fillup LtPartyName Detail";
                //lblMessage.text ="Please Fill LtPartyName Detail"
                return true;
            }
            else {
                document.getElementById("<%= txtLtPartyName.ClientID %>").style.borderColor = "";
                document.getElementById('divMessage').style.display = 'none';
                lblMessage.innerHTML = "";
                return false;
            }
        }
        function validateCourtDetails() {
            var CourtDetails = document.getElementById("<%= txtCourtDetails.ClientID %>").value;
            if (CourtDetails == "") {
                document.getElementById("<%= txtCourtDetails.ClientID %>").style.borderColor = "red";
                document.getElementById('divMessage').style.display = 'block';
                //lblMessage.innerHTML = "Please Fillup Court Detail";
                return true;
            }
            else {
                document.getElementById("<%= txtCourtDetails.ClientID %>").style.borderColor = "";
                document.getElementById('divMessage').style.display = 'none';
                lblMessage.innerHTML = "";
                return false;
            }
        }
        function validateInCourtof() {
            var InCourtof = document.getElementById("<%= txtInCourtof.ClientID %>").value;
            if (InCourtof == "") {
                document.getElementById("<%= txtInCourtof.ClientID %>").style.borderColor = "red";
                document.getElementById('divMessage').style.display = 'block';
                //lblMessage.innerHTML = "Please Fillup In Court Of";
                return true;
            }
            else {
                document.getElementById("<%= txtInCourtof.ClientID %>").style.borderColor = "";
                document.getElementById('divMessage').style.display = 'none';
                lblMessage.innerHTML = "";
                return false;
            }

        }
        function validateMatterDetails() {
            var MatterDetails = document.getElementById("<%= txtMatterDetails.ClientID %>").value;
            if (MatterDetails == "") {
                document.getElementById("<%= txtMatterDetails.ClientID %>").style.borderColor = "red";
                document.getElementById('divMessage').style.display = 'block';
                //lblMessage.innerHTML = "Please Fillup Matter Details";
                return true;
            }
            else {
                document.getElementById("<%= txtMatterDetails.ClientID %>").style.borderColor = "";
                document.getElementById('divMessage').style.display = 'none';
                lblMessage.innerHTML = "";
                return false;
            }
        }
        function validateLitigatingParty() {
            var LitigatingParty = document.getElementById("<%= txtLitigatingParty.ClientID %>").value;
            if (LitigatingParty == "") {
                document.getElementById("<%= txtLitigatingParty.ClientID %>").style.borderColor = "red";
                document.getElementById('divMessage').style.display = 'block';
                //lblMessage.innerHTML = "Please Fillup  Litigating Party";
                return true;
            }
            else {
                document.getElementById("<%= txtLitigatingParty.ClientID %>").style.borderColor = "";
                document.getElementById('divMessage').style.display = 'none';
                lblMessage.innerHTML = "";
                return false;
            }

        }
        function validatextcase() {
            var CaseNo = document.getElementById("<%= txtCaseNo.ClientID %>").value;
            if (CaseNo == "") {
                document.getElementById("<%= txtCaseNo.ClientID %>").style.borderColor = "red";
                document.getElementById('divMessage').style.display = 'block';
                return true;
            }
            else {
                document.getElementById("<%= txtCaseNo.ClientID %>").style.borderColor = "";
                document.getElementById('divMessage').style.display = 'none';
                return false;
            }

        }
        function radioValidation() {
            var gender = document.getElementsByName('radio1');
            var genValue = false;

            for (var i = 0; i < gender.length; i++) {
                if (gender[i].checked == true) {
                    genValue = true;
                }
            }
            if (!genValue) {
                document.getElementById('divMessage').style.display = 'block';
                return false;
            }

        }

        function validateDdlJurisdiction() {
            var e = document.getElementById("DdlJurisdiction");
            var strUser1 = e.options[e.selectedIndex].text;
            if (strUser1 == "--Select--") //for text use if(strUser1=="Select")  
            {
                document.getElementById("<%= DdlJurisdiction.ClientID %>").style.borderColor = "red";
                document.getElementById('divMessage').style.display = 'block';
                return true;
            }
            else {
                document.getElementById("<%= radio1.ClientID %>").style.borderColor = "";
                document.getElementById('divMessage').style.display = 'none';
                return false;
            }
        }
       
        function PrintElem() {

            Popup($('#Divv').html());
        }
        function PrintElem1() {

            Popup($('#Divv1').html());
        }

        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=1000');
            mywindow.document.write('<html><head><title style="font-weight:bold;">Allottee Details</title>');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/bootstrap.min.css\" type=\"text/css\" />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/theme.css\" type=\"text/css\"  />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/print.css\" type=\"text/css\"  />');
            mywindow.document.write('</head><body >');
            mywindow.document.write(data);
            mywindow.document.write('</body></html>');

            setTimeout(function () {
                mywindow.print();
                mywindow.close();
            }, 1000);


            return true;
        }

    </script>
              </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>
