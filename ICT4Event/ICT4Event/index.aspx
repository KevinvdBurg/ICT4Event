<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ICT4Event.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Inloggen</h1>
    <p>Gebruikersnaam: <asp:TextBox ID="inlog_gebruikersnaam" runat="server"></asp:TextBox>
    </p>
    <p>Wachtwoord: <asp:TextBox ID="inlog_wachtwoord" runat="server"></asp:TextBox>
    </p>
    <asp:Button ID="btn_inloggen" runat="server" Text="Button" OnClick="BtnInloggenClick"/>
    <p class="alert-link"><a href="pages/registreren.aspx">Registeren</a></p>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
