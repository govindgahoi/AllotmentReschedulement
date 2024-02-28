<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="UpdateStatusNiv.aspx.cs" Inherits="UpsidaAllottee.UpdateStatusNiv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<form id="form1" runat="server">--%>  
            
            <br />  
           <%-- <asp:Button ID="Button2" runat="server" OnClick="BaseToImage_Click" Text="Base64 To Image" />  
            <asp:Image ID="Image1" runat="server" Height="157px" style="margin-top: 0px; margin-right: 4px;" Width="168px" />  --%>
        <%--</form>--%> 


    <table>
        <tr><td>controlID</td><td><asp:TextBox ID="txtControlID" runat="server"></asp:TextBox></td></tr>
         <tr><td>unitID</td><td><asp:TextBox ID="txtUnitID" runat="server"></asp:TextBox></td></tr>
         <tr><td>ServiceID</td><td><asp:TextBox ID="txtServiceID" runat="server"></asp:TextBox></td></tr>
         <tr><td>ReqNo</td><td><asp:TextBox ID="txtSerReqNo" runat="server"></asp:TextBox></td></tr>
        <tr><td>Remarks</td><td><asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox></td></tr>
        <tr><td>RequestID</td><td><asp:TextBox ID="txtRequestID" runat="server"></asp:TextBox></td></tr>
        <%--<tr><td><asp:Button ID="Button1" runat="server" OnClick="ImageToBase_Click" Text="Image to Base64" />  
            <asp:TextBox ID="TextBox1" runat="server" Height="146px" TextMode="MultiLine"></asp:TextBox>  </td></tr>--%>
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
    <asp:Button runat="server"  ID="btnFeeDraft" Text="Set Fee Draft" OnClick="btnFeeDraft_Click"  />
    <asp:Button runat="server"  ID="btnObjection" Text="Set Objection" OnClick="btnObjection_Click"  />
     <asp:Button runat="server"  ID="FeeStatusNM" Text="Set Fee Status" OnClick="FeeStatusNM_Click"  />
    <asp:Button runat="server"  ID="btnReservationNOC" Text="Reservation money " OnClick="btnReservationNOC_Click"  />
    <asp:Button runat="server"  ID="btnDuesPaymentNOC" Text="Dues Payment" OnClick="btnDuesPaymentNOC_Click"  />
      <asp:Button runat="server"  ID="BtnFinalNoc" Text="Final NOC" OnClick="BtnFinalNoc_Click"  />           
    <asp:Button runat="server"  ID="btnLandPurchase" Text="Land Purchase Yes" OnClick="btnLandPurchase_Click"  /> 

    <hr />
    <table>
        <tr><td>controlID</td><td><asp:TextBox ID="NMControl" runat="server"></asp:TextBox></td></tr>
         <tr><td>unitID</td><td><asp:TextBox ID="NMUnit" runat="server"></asp:TextBox></td></tr>
         <tr><td>ServiceID</td><td><asp:TextBox ID="NMService" runat="server"></asp:TextBox></td></tr>
         <tr><td>RequestID</td><td><asp:TextBox ID="NMRequestID" runat="server"></asp:TextBox></td></tr>
         <tr><td>ProcessIndustryID</td><td><asp:TextBox ID="NMIndustryID" runat="server"></asp:TextBox></td></tr>
        <tr><td>Base64</td><td><asp:TextBox ID="NMBase64" runat="server"></asp:TextBox></td></tr>
        <tr><td>NOC_Certificate_Number</td><td><asp:TextBox ID="NMNoc" runat="server"></asp:TextBox></td></tr>
        <tr><td>Passsalt</td><td><asp:TextBox ID="NMPasssalt" runat="server"></asp:TextBox></td></tr>
        <tr><td><asp:Button ID="Button3" runat="server" OnClick="ImageToBase_Click" Text="Image to Base64" />  
            <asp:TextBox ID="TextBox8" runat="server" Height="146px" TextMode="MultiLine"></asp:TextBox>  </td></tr>
    </table>
    <asp:Button runat="server"  ID="Button4" Text="NMPaid With NOC Certificate" OnClick="btnNMPaidCertificate_Click"  /> 
</asp:Content>
