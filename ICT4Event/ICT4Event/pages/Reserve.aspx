<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="Reserve.aspx.cs" Inherits="ICT4Event.pages.Reserve" %>

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
    <p> Plek: <asp:DropDownList ID="ddlSpot" runat="server"></asp:DropDownList> 
    <asp:TextBox ID="tbInfo" runat="server"></asp:TextBox> <br />
    <asp:Button ID="btnAnulleren" runat="server" Text="Annulleren" />
    <asp:Button ID="btnReserve" runat="server" Text="Reserveren" OnClick="btnReserve_Click" />
    </p>
        
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
