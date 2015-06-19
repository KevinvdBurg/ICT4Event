<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeBehind="Toegang.aspx.cs" Inherits="ICT4Event.pages.Toegang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content_1" runat="server">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnApply">
         <p>
        <asp:Label ID="Label1" runat="server" Text="Inchecken" Font-Underline="True"></asp:Label> 
    </p>
    <p>
    <asp:Label ID="lblResId" runat="server" Text="Reserveringid:"></asp:Label>
    <asp:TextBox ID="tbResId" runat="server"></asp:TextBox>
    <asp:Button ID="btnPaid" runat="server" OnClick="btnPaid_Click" Text="Check betaalstatus" Width="143px" />
    <asp:Label ID="lblBetaald" runat="server"></asp:Label>
    <asp:Button ID="btnPay" runat="server" OnClick="btnPay_Click" Text="Betaal" />
    <p/>
        
        <asp:Label ID="lblUsername" runat="server" Text="Gebruikersnaam:"></asp:Label>
        <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
        
    <p>
        <asp:Label ID="lblPolsband" runat="server" Text="Polsbandje:"></asp:Label>
        <asp:TextBox ID="tbPolsbandje" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnApply" runat="server" Text="Koppel" OnClick="btnApply_Click" />
    </p>
    </asp:Panel>
   
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_2" runat="server">
    
    <asp:Panel ID="Panel2" runat="server" DefaultButton="btnCheckOut">
        <p>
        <asp:Label ID="Label2" runat="server" Text="Uitchecken" Font-Underline="True"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Barcode:"></asp:Label>
        <asp:TextBox ID="tbBarcode" runat="server"></asp:TextBox>

    </p>
    <p>
        <asp:Button ID="btnCheckOut" runat="server" Text="Check uit" OnClick="btnCheckOut_Click" />
    </p>
    </asp:Panel>
    
</asp:Content>
