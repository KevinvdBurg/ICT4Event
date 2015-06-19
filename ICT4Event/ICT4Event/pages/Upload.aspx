<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="ICT4Event.Upload" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <p>
        <asp:Label ID="Label1" runat="server" Text="Huidige map:"></asp:Label>   
        <asp:Label ID="lblMap" runat="server" Text="Home\\"></asp:Label>
    </p>
    
    <p>
        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Home" />
        <asp:HiddenField ID="HFcategory" runat="server" />
   </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Selecteer een map!"></asp:Label>
    </p>
    <p>
        <asp:ListBox ID="lbCategorie" runat="server" AutoPostBack="True" Height="125px" OnSelectedIndexChanged="lbCategorie_SelectedIndexChanged" Width="121px"></asp:ListBox>
    </p>
    
    <p>
        <asp:FileUpload ID="fileUpload" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
    </p>
    

</asp:Content>
