<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="inloggen.aspx.cs" Inherits="ICT4Event.pages.inloggen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Inloggen</h1>
<p>Gebruikersnaam: <asp:TextBox ID="inlog_gebruikersnaam" runat="server"></asp:TextBox></p>
<p>Wachtwoord: <asp:TextBox ID="inlog_wachtwoord" runat="server"></asp:TextBox></p>
<asp:Button ID="btn_inloggen" runat="server" Text="Button" OnClick="btn_inloggen_Click" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

</asp:Content>
