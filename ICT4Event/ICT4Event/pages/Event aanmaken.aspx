<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Event aanmaken.aspx.cs" Inherits="ICT4Event.Event_aanmaken" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content_1" runat="server">
    <h1>Event aanmaken</h1>
    <p>Naam: <asp:TextBox ID="tbNaam" runat="server"></asp:TextBox>
    </p>
    <p>Nummer: <asp:TextBox ID="tbNummer" runat="server"></asp:TextBox>
    </p>
    <p>Locatienaam: <asp:TextBox ID="tbLocatienaam" runat="server"></asp:TextBox>
    </p>
    <p>Adres: <asp:TextBox ID="tbAdres" runat="server"></asp:TextBox>
    </p>
    <p>Stad: <asp:TextBox ID="tbStad" runat="server"></asp:TextBox>
    </p>
    <p>Postcode: <asp:TextBox ID="tbPostcode" runat="server"></asp:TextBox>
    </p>
    <p>Huisnummer: <asp:TextBox ID="tbHuisnummer" runat="server"></asp:TextBox>
    </p>
    <p>Max Bezoekers:<asp:TextBox ID="tbBezoekers" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnEvent" runat="server" Text="Maak event" OnClick="btnEvent_Click"/>
    </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_2" runat="server">
    <p>Datum begin: <asp:Calendar ID="calDatumBegin" runat="server"></asp:Calendar>
    </p>
    <p>Datum eind: <asp:Calendar ID="calDatumEind" runat="server"></asp:Calendar>
    </p>
</asp:Content>