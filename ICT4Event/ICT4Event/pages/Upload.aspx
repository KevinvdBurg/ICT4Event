<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="ICT4Event.Upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <p>
        <asp:Label ID="Label1" runat="server" Text="Huidige map:"></asp:Label>   
        <asp:Label ID="lblMap" runat="server" Text="Home\\"></asp:Label>
    </p>
    
    <p>
        <asp:ListBox ID="lbCategorie" runat="server" Height="125px" OnSelectedIndexChanged="lbCategorie_SelectedIndexChanged" Width="121px"></asp:ListBox>
    </p>
</asp:Content>
