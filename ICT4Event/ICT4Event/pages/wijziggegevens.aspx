﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="wijziggegevens.aspx.cs" Inherits="ICT4Event.pages.wijziggegevens" %>
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
    <h1>Wijzig gegevens</h1>
    <p>Wachtwoord: <asp:TextBox ID="wijzig_wachtwoord" runat="server"></asp:TextBox>
    </p>
    <p>Her-wachtwoord: <asp:TextBox ID="her_wijzig_wachtwoord" runat="server"></asp:TextBox>
    </p>
        <hr/>
     <p>Huidige E-mail: <asp:TextBox ID="huidige_email" runat="server"></asp:TextBox>
    </p>
    <p>E-mail: <asp:TextBox ID="wijzig_email" runat="server"></asp:TextBox>
    </p>
    <p>Her-E-mail: <asp:TextBox ID="her_wijzig_email" runat="server"></asp:TextBox>
    </p>
    <asp:Button ID="btn_wijzig_gegevens" runat="server" Text="Wijzig Gegevens" OnClick="Btn"/>
    <p class="alert-link"></p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
