<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Escaping.aspx.cs" Inherits="Tasks.Escaping" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label AssociatedControlID="htmlInput">Html Input: </asp:Label>
    <asp:TextBox runat="server" ID="htmlInput" TextMode="MultiLine" Text="<h1>HTML</h1>"></asp:TextBox>
    <br />
    
    <asp:Button runat="server" OnClick="ReadHtml" Text="ReadHtml" />
    <br />

    <asp:Label AssociatedControlID="label">Label: </asp:Label>
    <asp:Label runat="server" ID="label"></asp:Label>
    <br />

    <asp:Label AssociatedControlID="literal">Escaped Literal: </asp:Label>
    <asp:Literal runat="server" ID="literal" Mode="Encode"></asp:Literal>
    <br />

    <asp:Label AssociatedControlID="textBox">Another Text Box: </asp:Label>
    <asp:TextBox runat="server" ID="textBox" TextMode="SingleLine"></asp:TextBox>
    <br />
</asp:Content>