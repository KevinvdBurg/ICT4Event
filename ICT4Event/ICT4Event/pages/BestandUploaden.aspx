<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeBehind="BestandUploaden.aspx.cs" Inherits="ICT4Event.BestandUploaden" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content_1" runat="server">
    <h1>Bestand Uploaden</h1>
    <p><asp:FileUpload ID="FileUploadControl" runat="server" /> </p>
    
    <p><asp:Button ID="UploadButton" runat="server" Text="Upload" OnClick="UploadButton_Click1" />  </p>
    
    <p><asp:Label ID="StatusLabel" runat="server" Text="Upload status:"></asp:Label></p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_2" runat="server">
</asp:Content>
