<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="PMView.aspx.cs" Inherits="Allotment.PMView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="ProudMonkey.Common.Controls" namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %> 


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"  EnablePartialRendering="true" >
</asp:ScriptManager>

    

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




     <asp:Label ID="Group_lbl" Visible="false" runat="server" style="margin-right:10px;"></asp:Label>
    <div class="row">
        <div class="col-md-12">
            <asp:PlaceHolder ID="ph" runat="server" />
        </div>
    </div>


     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
