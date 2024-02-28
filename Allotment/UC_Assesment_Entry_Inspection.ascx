<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Assesment_Entry_Inspection.ascx.cs" Inherits="Allotment.UC_Assesment_Entry_Inspection" %>


<%@ Register assembly="ProudMonkey.Common.Controls" namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %>
	 <cc1:MessageBox ID="MessageBox1" runat="server" /> 




                    <code>Submit Inspection Report</code>
                     <div class="clearfix"></div>
                     <hr class="myhrline" />
                     <div class="form-group">
                        <label class="col-md-2">
                           Upload Inspection Document :
                        </label>
                        <div class="col-md-6">
                             <asp:FileUpload CssClass="form-control"  ID="FileUpload4" runat="server" />
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="submit" OnClick="submit_Click"  runat="server" Text="Submit" CssClass="btn-primary ey-bg" />                           
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="form-group">
                        <label class="col-md-2">
                            Remark :
                        </label>
                        <div class="col-md-6">
                            <asp:TextBox ID="Remark" runat="server" placeholder="Remark Here" TextMode="MultiLine" class="" Width="100%" Height="100px"/>
                        </div>                        
                    </div>
    



