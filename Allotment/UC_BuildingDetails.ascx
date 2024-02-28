<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_BuildingDetails.ascx.cs" Inherits="Allotment.UC_BuildingDetails" %>

<script type="text/javascript">

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();
        }
    
        
    </script>
  <div class="panel panel-default">
            <div class="panel-heading" style="width: 100%;">
                <div class="row">
                    <div class="col-md-12">

                        <div class="col-md-4">
                           
                        </div>
                        <div class="col-md-4">
                            <p>
                                <b>
                                    <asp:Label ID="lblHead" runat="server" Text="Building Specification"></asp:Label></b>
                            </p>
                        </div>
                        <div class="col-md-4 btn-group">
                          
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-body ">

                <div style="text-align:left;">
                    <span class="font-12px">Plot Size :</span>
                    <asp:Label ID="lblPlotSize" runat="server" Text="Label" CssClass="font-12px"></asp:Label>
                </div>

                <div class="table-responsive">
                    <table class="table table-bordered table-hover request-table" id="datatableService">
                        <thead>
                            <tr>
                                <th style="width: 250px">Description</th>
                                <th style="width:50px;">Byelaws </th>
                                <th>Unit</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Total Covered Area (In Sqr Mtr)</td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="N/A"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCoveredArea" Class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>FAR(in Percentage)</td>
                                <td>
                                    <asp:Label ID="lblFarByelaws" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFar" Class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Ground Coverage (in Percentage)</td>
                                <td>
                                    <asp:Label ID="lblGroundBylo" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGroundcover" class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Height(In mts)</td>
                                <td>
                                    <asp:Label ID="lblHeight" runat="server" Text="N/A"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHeight" class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align:left;">Set Back(In mts)</td>
                            </tr>
                            <tr>
                                <td style="text-align:right;">front</td>
                                <td>
                                    <asp:Label ID="lblSetBackFront" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSetBackFront" class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;">Rear
                                </td>
                                <td>
                                    <asp:Label ID="lblSetBackRear" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSetBackRear" class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;">Side1</td>
                                <td>
                                    <asp:Label ID="lblSetBackSide1" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSetBackSide1" class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;">Side2</td>
                                <td>
                                    <asp:Label ID="lblSetBackSide2" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSetBackSide2" class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align:left;">Classification of Indiustries Based on Degree of Hazard</td>
                            </tr>
                            <tr>
                                <td>Classification of Hazard</td>
                                <td colspan="2">

                                    <asp:DropDownList ID="ddlNature" runat="server"  Class="btn btn-default dropdown-toggle input-sm mynewselect" Enabled="false">
                                        <asp:ListItem Text="Dealing with Chemical ,Inflammable and explosives" Value="Dealing with Chemical ,Inflammable and explosives" />
                                        <asp:ListItem Text="High rise buildings(Hospitals/malls/Hotels)" Value="High rise buildings(Hospitals/malls/Hotels)" />
                                        <asp:ListItem Text="Other" Value="Other" />
                                    </asp:DropDownList>

                                </td>
                            </tr>
                            <tr>
                                <td>Occupancy</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtOccupancy" Class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>


                        </tbody>
                    </table>



                    <table class="table table-bordered table-hover request-table" id="datatableService1">
                            <thead>
                                <tr>
                                    <th style="width:250px">Floors</th>
                                    <th >Existing </th>
                                    <th >Proposed</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>BaseMent(in Sqmts)</td>
                                    <td >
                                        <asp:TextBox ID="txtBaseMent1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text='' Enabled="false"></asp:TextBox>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtBaseMent2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text='' Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ground Floor(in Sqmts)</td>
                                    <td >
                                        <asp:TextBox ID="txtGround1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text='' Enabled="false"></asp:TextBox>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtGround2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text='' Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>First Floor(in Sqmts)</td>
                                    <td >
                                        <asp:TextBox ID="txtFirstfloor1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text='' Enabled="false"></asp:TextBox>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtFirstfloor2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text='' Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td >Second Floor(in Sqmts)</td>
                                    <td >
                                        <asp:TextBox ID="txtSecondFloor1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text='' Enabled="false"></asp:TextBox>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtSecondFloor2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text='' Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>                      
                                <tr>
                                    <td style="text-align:left;">Mezzanine Floor(in Sqmts)</td>
                                    <td >
                                        <asp:TextBox ID="txtMezzanine1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text='' Enabled="false"></asp:TextBox>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtMezzanine2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text='' Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="text-align:left;">Stilt Floor(in Sqmts)</td>
                                    
                                    <td colspan="2" >
                                        <asp:TextBox ID="txtStealth" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"  Enabled="false" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left;">Mumti(in Sqmts)</td>
                                    
                                    <td colspan="2">
                                        <asp:TextBox ID="txtMumti" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"  Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td  style="text-align:left;">Purpose for which  building Use
                                    </td>
                                    <td  colspan="2">
                                        <asp:TextBox ID="txtbuildingPurpose" class="input-sm myyellowbgsmall" runat="server" Text='' Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                     <table class="table table-bordered table-hover request-table" id="RevisionDetailsTbl" runat="server" visible="false" >
                          <thead>
                                <tr>
                                    <th style="width:250px" >Previous Details</th>
                                    <th></th>
                                  
                                </tr>
                            </thead>
                          <tbody>
                                
                               
                                <tr>
                                    <td style="text-align:left;">Previous Approved Builtup Area (In SqrMts)</td>
                                    <td>
                                    <asp:Label runat="server" ID="prevAppBPArea_lbl"></asp:Label>

                                    </td>
                                </tr>
                               <tr>
                                    <td style="text-align:left;">Malba Charges Paid Previously</td>
                                    <td>
                                       <asp:Label runat="server" ID="MalbaPaid_lbl"></asp:Label>

                                    </td>
                                </tr>
                               <tr>
                                    <td style="text-align:left;">Infrastructure Development Charges Paid Previously</td>
                                    <td>
                                      <asp:Label runat="server" ID="InfraPaid_lbl"></asp:Label>


                                    </td>
                                </tr>
                            </tbody>
                         </table>


                     <table class="table table-bordered table-hover request-table" id="TemporaryStructureDetails" >
                           <thead>
                                <tr>
                                    <th style="width:250px" >Temporary Structure Details</th>
                                    <th></th>
                                  
                                </tr>
                            </thead>
                          <tbody>
                                
                               
                                <tr>
                                    <td style="text-align:left;">Is any temporary structure proposed</td>
                                    <td>
                                     <asp:DropDownList ID="drpTemoraryStructure" runat="server" Style="width: 100% !important" Enabled="false" Class="btn btn-default dropdown-toggle input-sm mynewselect" >
                                         <asp:ListItem Value="2">--Select--</asp:ListItem>
                                         <asp:ListItem Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:DropDownList> 

                                    </td>
                                </tr>
                            </tbody>
                      </table>

                    <table class="table table-bordered table-hover request-table" id="TemporaryStructureUse" runat="server" visible="false"  >
                           
                        
                               
                                <tr>
                                    <td style="text-align:left;width:250px;font-weight:700;">Temporary Structure Use</td>
                                    <td style="text-align:center;width:250px;font-weight:700;">Covered Area (In SQM)</td>
                                     <td style="text-align:center;width:250px;font-weight:700;">Amount</td>
                                    </tr>
                               <tr>
                                    <td style="text-align:left;">
                                  Labour Hutment

                                    </td>
                                    <td>
                                      <asp:TextBox ID="txtHutment" onkeyup="Hutment(this)" Enabled="false"  class="input-sm myyellowbgsmall" runat="server"></asp:TextBox> x (0.25)
                                    </td>
                                   <td><asp:Label runat="server" ID="lblHutmentAmount"></asp:Label></td>
                                </tr>
                                 <tr>
                                  
                                    <td>
                                  Other Uses

                                    </td>
                                    <td>
                                      <asp:TextBox ID="txtOtherCharges" onkeyup="OtherCharges(this)" Enabled="false" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox> x 25% of applicable processing fee
                                    </td>
                                      <td><asp:Label runat="server" ID="lblOtherChrges"></asp:Label></td>
                                </tr>
                          
                      </table>
                      
                        <table class="table table-bordered table-hover request-table" id="datatableService2" >
                            <thead>
                                <tr>
                                    <th style="width:250px"></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                               
                                <tr>
                                    <td style="text-align:left;" colspan="2"><b>Construction Specification</b></td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">Foundation</td>
                                    <td>
                                        <asp:TextBox ID="txtFoundation" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">Walls</td>
                                    <td>
                                        <asp:TextBox ID="txtWalls" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                  <tr>
                                    <td style="text-align:right;">Floors</td>
                                    <td>
                                        <asp:TextBox ID="txtFloors" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="text-align:right;">Roofs</td>
                                    <td>
                                        <asp:TextBox ID="txtRoofs" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">Number of storeys</td>
                                    <td>
                                        <asp:TextBox ID="txtStories" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">Number of latrines</td>
                                    <td>
                                        <asp:TextBox ID="txtLatrines" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">Any Previous Construction </td>
                                    <td>
                                        <asp:TextBox ID="txtPreviousConstruction" class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="text-align:right;">Source of Water for Building Purpose </td>
                                    <td>
                                        <asp:TextBox ID="txtWaterSource" class="input-sm myyellowbgsmall" runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                </tbody>
                            </table>
                           
                            <div class="clearfix"></div>
                            <hr class="myhrline" />

                </div>



            </div>
        </div>