<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TicTacToe.aspx.cs" Inherits="Tasks.TicTacToe" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row text-center">
        <asp:Panel runat="server" ID="Board" CssClass="col-md-offset-4 col-md-4">
            <asp:Panel runat="server">
                <asp:Button runat="server" OnClick="ExecuteTurn" CssClass="btn btn-warning btn-ttt" />
                <asp:Button runat="server" OnClick="ExecuteTurn" CssClass="btn btn-warning btn-ttt" />
                <asp:Button runat="server" OnClick="ExecuteTurn" CssClass="btn btn-warning btn-ttt" />
            </asp:Panel>
            <asp:Panel runat="server">
                <asp:Button runat="server" OnClick="ExecuteTurn" CssClass="btn btn-warning btn-ttt" />
                <asp:Button runat="server" OnClick="ExecuteTurn" CssClass="btn btn-warning btn-ttt" />
                <asp:Button runat="server" OnClick="ExecuteTurn" CssClass="btn btn-warning btn-ttt" />
            </asp:Panel>
            <asp:Panel runat="server">
                <asp:Button runat="server" OnClick="ExecuteTurn" CssClass="btn btn-warning btn-ttt" />
                <asp:Button runat="server" OnClick="ExecuteTurn" CssClass="btn btn-warning btn-ttt" />
                <asp:Button runat="server" OnClick="ExecuteTurn" CssClass="btn btn-warning btn-ttt" />
            </asp:Panel>
            <asp:Button runat="server" OnClick="Start" CssClass="btn btn-primary" Text="Restart" /> Result: <asp:Label runat="server" ID="GameResult"></asp:Label>
        </asp:Panel>
    </div>
    <h1 runat="server" ID="Out"></h1>
</asp:Content>