<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="ReserveItem.aspx.cs" Inherits="ICT4Event.pages.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>Free items: <asp:ListBox ID="lbFreeItems" runat="server"></asp:ListBox></p>

    <asp:Button ID="btnCancel" runat="server" Text="Annuleren" />
    <asp:Button ID="btnReserve" runat="server" Text="Reserveren" OnClick="btnReserve_Click" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
