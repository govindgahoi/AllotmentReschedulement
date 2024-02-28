<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="ChangeStatusNivesh.aspx.cs" Inherits="Allotment.ChangeStatusNivesh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <table>
        <tr><td>controlID</td><td><asp:TextBox ID="txtControlID" runat="server"></asp:TextBox></td></tr>
         <tr><td>unitID</td><td><asp:TextBox ID="txtUnitID" runat="server"></asp:TextBox></td></tr>
         <tr><td>ServiceID</td><td><asp:TextBox ID="txtServiceID" runat="server"></asp:TextBox></td></tr>
         <tr><td>ReqNo</td><td><asp:TextBox ID="txtSerReqNo" runat="server"></asp:TextBox></td></tr>
        <tr><td>Remarks</td><td><asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox></td></tr>
        <tr><td>Request ID</td><td><asp:TextBox ID="txtRequestID" runat="server"></asp:TextBox></td></tr>
        <asp:RadioButtonList ID="radioservice" runat="server">
            <asp:ListItem>BuildingPlan</asp:ListItem>
            <asp:ListItem>LandAllotment</asp:ListItem>
        </asp:RadioButtonList>
        <asp:RadioButtonList ID="radioRejection" runat="server">
            <asp:ListItem>Approval</asp:ListItem>
            <asp:ListItem>Rejection</asp:ListItem>
           
        </asp:RadioButtonList>
    </table>
   
                     
        <asp:Button runat="server"  ID="btnSample" Text="Change_Rejection" OnClick="btnSample_Click"  />   
      <asp:Button runat="server"  ID="BtnFeePaid" Text="FeePaid" OnClick="BtnFeePaid_Click"  />
     <asp:Button runat="server"  ID="btnFormSubmitted" Text="FormSubmit" OnClick="btnFormSubmitted_Click"  />
      <asp:Button runat="server"  ID="btnDraft" Text="Set Draft" OnClick="btnDraft_Click"  />
    
      <asp:Button runat="server"  ID="btnPending" Text="Set Pending" OnClick="btnPending_Click"  />

    <asp:Button runat="server"  ID="btnFeeDraft" Text="Set Fee Draft" OnClick="btnFeeDraft_Click"  />
    <asp:Button runat="server"  ID="btnObjection" Text="Set Objection" OnClick="btnObjection_Click"  />
     <asp:Button runat="server"  ID="FeeStatusNM" Text="Set Fee Status" OnClick="FeeStatusNM_Click"  />
    <asp:Button runat="server"  ID="btnReservationNOC" Text="Reservation money " OnClick="btnReservationNOC_Click"  />
    <asp:Button runat="server"  ID="btnDuesPaymentNOC" Text="Dues Payment" OnClick="btnDuesPaymentNOC_Click"  />
      <asp:Button runat="server"  ID="BtnFinalNoc" Text="Final NOC" OnClick="BtnFinalNoc_Click"  />      
    <asp:Button runat="server"  ID="BtnFinalFwd" Text="Forwarded" OnClick="BtnFinalFwd_Click"  />           
    <asp:Button runat="server"  ID="btnLandPurchase" Text="Land Purchase Yes" OnClick="btnLandPurchase_Click"  /> 
    <asp:Button runat="server"  ID="Button1" Text="Noc Remark" OnClick="BtnFinalNoc_Clicknar "/> 
    <asp:Button runat="server"  ID="Button2" Text="Rejected Remark" OnClick="BtnFinalReject_Clicknar "/> 


</asp:Content>
