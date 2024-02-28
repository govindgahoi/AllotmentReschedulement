<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="TransferResidentialPlot.aspx.cs" Inherits="Allotment.TransferResidentialPlot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
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
                            <a href="#" class="disable">
                                <i class="fa fa-floppy-o " aria-hidden="true"></i><br />Save
                            </a>
                        </li> 
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-refresh" aria-hidden="true"></i><br />Refresh
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;border-right:1px solid #000;font-size:11px;" class="text-center">
                    Services<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-plus" aria-hidden="true"></i><br />New
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-pencil-square-o" aria-hidden="true"></i><br />Drafted
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-th-list" aria-hidden="true"></i><br />Submitted
                            </a>
                        </li> 
                           
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-credit-card" aria-hidden="true"></i><br />Track 
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
                     <div style="float: left;background: #dbdbdb;font-size:11px;border-left:1px solid #000;">
                        <br />
                        <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                            <li >
                                <a href="#" class="disable">
                                    <i class="fa fa-credit-card" aria-hidden="true"></i><br />Dues
                                </a>
                            </li>
                         </ul>
                    </div>
                     <div style="float: left;background: #dbdbdb;font-size:11px;border-left:1px solid #000;">
                        <br />
                        <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-database" aria-hidden="true"></i><br />Repository
                            </a>
                        </li>
                      </ul>
                 </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading font-bold">Application form for Transfer of Residential Plot</div>
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Plot No :
                        </label>
                        <div class="col-md-9">
                            <asp:Label ID="lblPlotNo" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Name of the Area :
                        </label>
                        <div class="col-md-9">
                            <asp:Label ID="lblAreaName" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Name of Allottee :
                        </label>
                        <div class="col-md-9">
                            <asp:Label ID="lblNameofAllottee" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Tel. No. :
                        </label>
                        <div class="col-md-9">
                            <asp:Label ID="lblTelNo" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            GIR/PAN No. :
                        </label>
                        <div class="col-md-9">
                            <asp:Label ID="lblPanNo" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Name of Proposed Transferee :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtProposedTransfereeName" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Address of Proposed Transferee :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtProposedTransfereeAddress" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Tel. No. :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtTransfereeTelNo" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            GIR/PAN No. :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtTransfereePan" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 text-right">
                            Reason of Transfer :
                        </label>
                        <div class="col-md-9">
                            <asp:TextBox TextMode="MultiLine"  ID="txtReasonofTransfer"  runat="server" CssClass="similar-select1 margin-left-z input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
            </div>
        </div>
    </div>
</asp:Content>
