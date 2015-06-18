<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="registreren.aspx.cs" Inherits="ICT4Event.pages.Registreren" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gegevens</h1>
<<<<<<< HEAD
    <p>Gebruikersnaam: <asp:TextBox ID="regi_gebruikersnaam" runat="server">Kevin</asp:TextBox>
    </p>

    <p>Email: <asp:TextBox ID="regi_email" runat="server" TextMode="Email">kevin@ict4events.bb</asp:TextBox>
    </p>

    <p>Her-Email: <asp:TextBox ID="regi_her_email" runat="server" TextMode="Email">kevin@ict4events.bb</asp:TextBox>
    </p>

    <p>Wachtwoord: <asp:TextBox ID="regi_wachtwoord" runat="server">kevin@ict4events.bb</asp:TextBox>
    </p>

    <p>Her-Wachtwoord: <asp:TextBox ID="regi_herwachtwoord" runat="server">kevin@ict4events.bb</asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btn_registeren" runat="server" Text="Registeren" OnClick="BtnRegisterenClick"/>
=======
    <p>Gebruikersnaam: <asp:TextBox ID="regi_gebruikersnaam" runat="server"></asp:TextBox>
    </p>

    <p>Email: <asp:TextBox ID="regi_email" runat="server"></asp:TextBox>
    </p>

    <p>Her-Email: <asp:TextBox ID="regi_her_email" runat="server"></asp:TextBox>
    </p>

    <p>Wachtwoord: <asp:TextBox ID="regi_wachtwoord" runat="server"></asp:TextBox>
    </p>

    <p>Her-Wachtwoord: <asp:TextBox ID="regi_herwachtwoord" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btn_registeren" runat="server" Text="Registeren"/>
>>>>>>> origin/Event-aanmaken
    </p>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Activeren</h1>
<<<<<<< HEAD
    <p>Activerings code: <asp:TextBox ID="tbActivatiecode" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btn_actieveren" runat="server" Text="Activeren" OnClick="BtnActieverenClick"/>
=======
    <p>Activerings code: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btn_actieveren" runat="server" Text="Activeren"/>
>>>>>>> origin/Event-aanmaken
    </p>
</asp:Content>