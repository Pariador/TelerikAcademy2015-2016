<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="RNG.aspx.cs" Inherits="Tasks.RNG" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label AssociatedControlID="min">Min: </asp:Label>
    <asp:TextBox runat="server" ID="min" TextMode="SingleLine">1</asp:TextBox>
    <br />
    <asp:Label AssociatedControlID="max">Max: </asp:Label>
    <asp:TextBox runat="server" ID="max" TextMode="SingleLine">10</asp:TextBox>
    <asp:Button runat="server" OnClick="Randomize" Text="Random"/>
    <br />
    <asp:Label>Result: </asp:Label>
    <asp:Label runat="server" ID="result"></asp:Label>
</asp:Content>