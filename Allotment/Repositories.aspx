
<%@ Page Title="" Language="C#" MasterPageFile="~/MainUserHO.Master" AutoEventWireup="true" CodeBehind="Repositories.aspx.cs" Inherits="Allotment.Repositories" %>
<%@ Register TagPrefix="GleamTech" Assembly="GleamTech.FileUltimate" Namespace="GleamTech.FileUltimate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%;">
        <GleamTech:FileManagerControl ID="fileManager" runat="server" />
    </div>
</asp:Content>
