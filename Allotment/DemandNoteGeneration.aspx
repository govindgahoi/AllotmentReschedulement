<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="DemandNoteGeneration.aspx.cs" Inherits="Allotment.DemandNoteGeneration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<cc1:MessageBox ID="MessageBox1" runat="server" />


	<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
	</asp:ScriptManager>


	 <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
   <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                    <ProgressTemplate>
                        <div class="fgh">
                            <div class="hgf text-center">
                              <span style="font-size:18px;font-weight:bold;">Please Wait...</span><br /> <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                                
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>


	<div >
        <style>
        .modal-backdrop.fade {
            display:none !important;
        }
    </style>
            <script type="text/javascript">

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();
        }
    
        
    </script>
	    
            <div  id="SideDiv">
                <div class="row">
                    <div class="">
                    <div class="panel panel-default">
                       <div runat="server" id="divSearch" visible="true">
                        <div class="form-group" style="background: #dedede;padding: 2px 0;border: 1px solid #ccc;">
                            <label class="col-md-2">
                                Search Record:
                            </label>
                            <div class="col-md-10">
                                <asp:RadioButton Text=" By Plot No" runat="server" ID="radioByPlotNo" GroupName="radio" OnCheckedChanged="radioByPlotNo_CheckedChanged" AutoPostBack="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:RadioButton Text=" By Allotment No" GroupName="radio" runat="server" ID="radioByAllotmentNo" OnCheckedChanged="radioByAllotmentNo_CheckedChanged" AutoPostBack="true" />
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div runat="server" id="DivFilterIA" visible="false">
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-2 text-right">
                                Industrial Area:
                            </label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="drpIndusrialArea" CssClass="chosen input-sm similar-select1 margin-left-z" OnSelectedIndexChanged="drpIndusrialArea_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <label class="col-md-2  text-right">
                                Plot No:
                            </label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="drpPlotNo" CssClass="chosen input-sm similar-select1 margin-left-z" OnSelectedIndexChanged="drpPlotNo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>    
                            </div>
                        </div>
                           
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                             </div>
                            <div runat="server" id="DivFilterLetter" visible="false">
                        <div class="form-group">
                            <label class="col-md-4 text-right">
                                Enter Your Allotment Letter Number:
                            </label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtServiceReqNo" runat="server" CssClass="input-sm similar-select1" OnTextChanged="txtServiceReqNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div class="clearfix"></div>
                                 <hr class="separation" />
                            </div>
                       
                            </div>
               </div></div>
                    <br />
                    <div class="panel panel-default" style="border: 1px solid #ccc;" runat="server" id="AllotteeDiv" visible="false">
                        
                            <div class="">
                                <div class="">
                                    <div class="panel-heading font-bold text-center">
                                        Allottee Details                         
                                    </div>
                                    <div class="panel-body" style="padding: 0px !important;">
                                        <div class="div-companydetail" style="background: #ececec;">
                                            <div class="form-group">
                                                <div class="">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Regional Office :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblRegionalOffice" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Industrial Area : 
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblIndustrialArea" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Date of Allotment :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblDateofApplication" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <asp:Label runat="server" ID="lblAllotteeID" Visible="false"></asp:Label>
                                                <asp:Label runat="server" ID="lblIAID" Visible="false"></asp:Label>
                                                <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
                                                <div class="">
                                                  <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Plot Area :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblplotarea" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Allottment Letter No :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblAllotmentLetterNo" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Plot No :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblPlotNo" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Allottee Name :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblAllotteeName" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Firm/Company Name :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblFirmCompanyName" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                      Firm Constitution :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblCompanyConstitution" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="">
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Mobile No :
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblSignatoryMobile" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                        Address :   
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblAddress" runat="server" CssClass="font-bold"></asp:Label></em>
                                                    </div>
                                                    <div class="hidden-lg hidden-md">
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <label class="col-md-2 col-sm-6 col-xs-6 text-right">
                                                         Email ID : 
                                                    </label>
                                                    <div class="col-md-2 col-sm-6 col-xs-6">
                                                        <em>
                                                            <asp:Label ID="lblSIgnatoryEmail" runat="server" CssClass="font-bold"></asp:Label>
                                                        </em>
                                                    </div>
                                                </div>
                                            </div>
                                                 <div class="clearfix"></div>
                                            <hr class="myhrline" />  
                
                                    </div>
                                </div>
                            </div>
                          
                        </div>
                                         <div class="text-center"><asp:Button runat="server" ID="btnRaise" style="font-size: 16px;margin: 3px 0;" CssClass="btn-primary" Text="View" OnClick="btnRaise_Click" />
                                             <asp:Button runat="server" ID="btnGenerate" style="font-size: 16px;margin: 3px 0;" CssClass="btn-primary" OnClientClick="javascript:return confirm('Please check demand details properly');" Text="Generate" OnClick="btnGenerate_Click" Enabled="False" />
                                         </div>  
                 

            <br /><br />
                    <div class="" runat="server" id="PreviousServiceDiv" visible="false">
                 <div class="panel panel-default">
                        <div class="panel-heading text-center">Demand Note</div>
                     </div>

                           
                        <asp:PlaceHolder runat="server" ID="Placeholder"></asp:PlaceHolder>
                       

                        </div>

                        </div>
                </div>    
                
                 
            </div>
        </div>








  </ContentTemplate>
		 </asp:UpdatePanel>









	<style>
		.div-checklist {
			border: 1px solid #ccc;
			background: #f7f7f7;
		}

		.div-companydetail .col-md-3 {
			/*width: 22%;*/
		}

		.ol-checklist li {
			border-bottom: 1px solid #ccc;
		}

		.allottee-details-div .col-md-3 {
			/*width: 22%;
			padding-left: 1px;*/
		}

		.allottee-details-div {
			border: 1px solid #ccc;
		}

			.allottee-details-div .col-md-9 {
				/*width: 74%;*/
			}

		.detail-pattern-bg {
			background: #f9f9f9;
		}

		.div-view {
			padding: 0px 0;
			/*  background: #f7f7f7; */
		}

		.assess-min-height {
			min-height: 800px;
		}

		.content {
			min-height: 300px;
		}

		.view-img {
			max-height: 509px;
			max-width: 765px;
		}

		.div-status-bottom {
			border: 1px solid #ccc;
			margin: 0px 0px;
			margin-bottom: 6px;
			padding: 2px 0;
			/* position: absolute; */
			bottom: 0;
			width: 100%;
		}


		.chair-heading-bot {
			border-bottom: 1px solid #ffc511;
			border-top: 1px solid #ffc511;
			margin-bottom: 3px;
		}

		.my-new-heading {
			padding: 0px 0px 0px 0px !important;
		}




		@media only screen and (min-width: 768px) {
			.check-right {
				padding-left: 2px;
				padding-right: 0px;
			}

			.check-left {
				padding-right: 2px;
				padding-left: 0;
			}
		}



		.sub_menu li a {
			white-space: pre-wrap !important;
			color: #000;
		}

		.sub_menu li {
			position: relative;
			font-size: 11px;
			color: #2d2d2d;
			border: 1px solid #ffc5111f !important;
			padding: 1px 1px !important;
			font-weight: 500;
		}

		a.static.selected {
			text-decoration: none;
			border-style: none;
			/*color: #ffc511;
			background: #000;*/
		}

	   .sub_menu_active
		{
			color:#ffffff;
		}

       #UpdateProgress1 {
               position: fixed;
               width: 100%;
               height: 100%;
               z-index: 99999;
               background: rgba(0,0,0,0.21176470588235294);
           }
           #UpdateProgress1 .fgh{
                position: absolute;
                top: 45%;
                margin: 0px auto;
                left: 45%;
                z-index: 999;
           }

	</style>





    <asp:GridView ID="GridView1" runat="server"  ForeColor="#333333" GridLines="None" ShowFooter="True" Width="500px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>





</asp:Content>
