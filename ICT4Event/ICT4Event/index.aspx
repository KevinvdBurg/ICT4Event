
<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ICT4Event.Index" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Inloggen</h1>
    <p>Gebruikersnaam: <asp:TextBox ID="inlog_gebruikersnaam" runat="server"></asp:TextBox>
    </p>
    <p>Wachtwoord: <asp:TextBox ID="inlog_wachtwoord" runat="server"></asp:TextBox>
    </p>
    <asp:Button ID="btn_inloggen" runat="server" Text="Button" OnClick="BtnInloggenClick"/>
    <asp:LinkButton ID="btn_to_registeren" runat="server" OnClick="btn_to_registeren_Click">Registeren</asp:LinkButton>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
