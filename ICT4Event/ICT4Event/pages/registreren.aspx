<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="registreren.aspx.cs" Inherits="ICT4Event.pages.registreren" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gegevens</h1>
    <p>Gebruikersnaam: <asp:TextBox ID="regi_gebruikersnaam" runat="server">KevinIsCool</asp:TextBox></p>
    
    <p>Email: <asp:TextBox ID="regi_email"  runat="server" TextMode="Email">KevinIsCool@email.com</asp:TextBox></p>
    
    <p>Her-Email: <asp:TextBox ID="regi_her_email" runat="server" TextMode="Email">KevinIsCool@email.com</asp:TextBox></p>
    
    <p>Wachtwoord: <asp:TextBox ID="regi_wachtwoord" runat="server">EenHeelStrerkwachtwoord</asp:TextBox></p>
    
    <p>Her-Wachtwoord:    <asp:TextBox ID="regi_herwachtwoord" runat="server">EenHeelStrerkwachtwoord</asp:TextBox></p>
    <p><asp:Button ID="btn_registeren" runat="server" Text="Registeren" OnClick="btn_registeren_Click" /></p>
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Activeren</h1>
    <p>Activerings code: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></p>
    <p><asp:Button ID="btn_actieveren" runat="server" Text="Activeren" OnClick="btn_actieveren_Click" /></p>
</asp:Content>
