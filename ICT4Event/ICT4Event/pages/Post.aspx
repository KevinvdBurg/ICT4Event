<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="ICT4Event.pages.Post" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Home" />
        <asp:Label ID="Label1" runat="server" Text="Huidige map:"></asp:Label>
        <asp:Label ID="lblMap" runat="server" Text="Home\\"></asp:Label>
    </p>
    <p>
    
    <asp:ListBox ID="lbCategorie" runat="server" AutoPostBack="True" Height="200px" OnSelectedIndexChanged="lbCategorie_SelectedIndexChanged" Width="150px"></asp:ListBox>
    <asp:ListBox ID="lbItems" runat="server" AutoPostBack="True" Height="200px" OnSelectedIndexChanged="lbItems_SelectedIndexChanged" Width="200px"></asp:ListBox>
    </p>
    
   
    <asp:Button ID="btnDownload" runat="server" Text="Download" Visible="False" OnClick="btnDownload_Click" />
    <p>
        <asp:Button ID="btnNewPost" runat="server" Text="Nieuw Post" OnClick="btnNewPost_Click" />
        <asp:Button ID="btnComment" runat="server" OnClick="btnComment_Click" Text="Commentaar" Width="85px" />
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />
    </p>
    <p>
        <asp:TextBox ID="tbNewTitle" runat="server" Visible="False"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Titel" Visible="False"></asp:Label>
    </p>
   <p>
       <asp:TextBox ID="tbNewContent" runat="server" Height="106px" TextMode="MultiLine" Width="350px" Visible="False"></asp:TextBox>
       <asp:Label ID="Label3" runat="server" Text="Inhoud" Visible="False"></asp:Label>
   </p>
    <p>
        <asp:Button ID="btnSavePost" runat="server" Text="Post!" OnClick="btnSavePost_Click" Visible="False" />
    </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        
        <asp:Label ID="lblCurrentPost" runat="server" Text="Huidige post: " Visible="False"></asp:Label>
        <asp:Label ID="lblCurrentPostTitle" runat="server" Visible="False"></asp:Label>
        
    </p>

    <p>
     <asp:TextBox ID="tbInhoud" runat="server" Height="200px" ReadOnly="True" TextMode="MultiLine" Visible="False" Width="400px"></asp:TextBox>
    <asp:TextBox ID="tbComments" runat="server" ReadOnly="True" TextMode="MultiLine" Width="400px"></asp:TextBox>
    </p>

</asp:Content>
