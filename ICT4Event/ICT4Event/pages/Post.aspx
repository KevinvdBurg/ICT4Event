<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="ICT4Event.pages.Post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Home" />
    <asp:ListBox ID="lbCategorie" runat="server" AutoPostBack="True" Height="200px" OnSelectedIndexChanged="lbCategorie_SelectedIndexChanged" Width="150px"></asp:ListBox>
    <asp:ListBox ID="lbItems" runat="server" AutoPostBack="True" Height="200px" OnSelectedIndexChanged="lbItems_SelectedIndexChanged" Width="200px"></asp:ListBox>
   
    <asp:Button ID="btnDownload" runat="server" Text="Download" Visible="False" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <asp:TextBox ID="tbInhoud" runat="server" Height="200px" ReadOnly="True" TextMode="MultiLine" Visible="False" Width="400px"></asp:TextBox>
</asp:Content>
