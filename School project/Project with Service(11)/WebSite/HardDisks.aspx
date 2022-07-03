<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HardDisks.aspx.cs" Inherits="HardDisks" %>

<%@ Register src="WebUserControlDataList.ascx" tagname="WebUserControlDataList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <uc1:WebUserControlDataList ID="WebUserControlDataList1" runat="server" />
    <br />
    </asp:Content>

