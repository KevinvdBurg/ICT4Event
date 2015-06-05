<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="ReserveItem.aspx.cs" Inherits="ICT4Event.pages.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblName" runat="server" Text="Naam:"></asp:Label>
    <asp:TextBox ID="tbName" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblItem" runat="server" Text="Item"></asp:Label>
    <asp:DropDownList ID="ddlItems" runat="server"></asp:DropDownList><br />
    <asp:Button ID="btnCancel" runat="server" Text="Annuleren" />
    <asp:Button ID="btnReserve" runat="server" Text="Reserveren" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
