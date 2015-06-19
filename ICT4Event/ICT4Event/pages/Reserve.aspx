<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="Reserve.aspx.cs" Inherits="ICT4Event.pages.Reserve" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Plek reserveren</h1> <br />
    <p> Voornaam: <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox> <br />
        Tussenvoegsel: <asp:TextBox ID="tbInsertion" runat="server"></asp:TextBox> <br />
        Achternaam: <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox> <br />
        Straat: <asp:TextBox ID="tbStreet" runat="server"></asp:TextBox> <br />
        Huisnr: <asp:TextBox ID="tbHouseNumber" runat="server"></asp:TextBox> <br />
        Woonplaats: <asp:TextBox ID="tbCity" runat="server"></asp:TextBox> <br/>
        banknr: <asp:TextBox ID="tbBank" runat="server"></asp:TextBox> <br />
    </p>
    <p> Plek: <asp:DropDownList ID="ddlSpot" runat="server"></asp:DropDownList> <asp:Button ID="btnSpecificaties" runat="server" Text="Laad Specificaties" OnClick="btnSpecificaties_Click" />
    <p> Specificaties: <asp:ListBox ID="lbSpecificaties" runat="server"></asp:ListBox> </p> <br />
    <asp:Button ID="btnAnulleren" runat="server" Text="Annuleren" />
    <asp:Button ID="btnReserve" runat="server" Text="Reserveren" OnClick="btnReserve_Click" />
    </p>
        
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
