<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="Tasks.Calculator" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<div class="row">
    <asp:Panel runat="server" ID="CalculatorPanel" CssClass="col-md-offset-4 col-md-4 bg-warning">
        <div><asp:TextBox runat="server" ID="Screen" TextMode="SingleLine"></asp:TextBox></div>
        <div>
            <asp:Button runat="server" OnClick="EnterSymbol" Text="1" />
            <asp:Button runat="server" OnClick="EnterSymbol" Text="2" />
            <asp:Button runat="server" OnClick="EnterSymbol" Text="3" />
            <asp:Button runat="server" ID="ButtonPlus" OnClick="EnterSymbol" />
        </div>
        <div>
            <asp:Button runat="server" OnClick="EnterSymbol" Text="4" />
            <asp:Button runat="server" OnClick="EnterSymbol" Text="5" />
            <asp:Button runat="server" OnClick="EnterSymbol" Text="6" />
            <asp:Button runat="server" ID="ButtonMinus" OnClick="EnterSymbol" />
        </div>
        <div>
            <asp:Button runat="server" OnClick="EnterSymbol" Text="7" />
            <asp:Button runat="server" OnClick="EnterSymbol" Text="8" />
            <asp:Button runat="server" OnClick="EnterSymbol" Text="9" />
            <asp:Button runat="server" ID="ButtonTimes" OnClick="EnterSymbol" />
        </div>
        <div>
            <asp:Button runat="server" OnClick="Clear" Text="Clear" />
            <asp:Button runat="server" OnClick="EnterSymbol" Text="0" />
            <asp:Button runat="server" ID="ButtonDevide" OnClick="EnterSymbol" />
            <asp:Button runat="server" ID="ButtonSqrt" OnClick="EnterSymbol"  />
        </div>        
        <div>
            <asp:Button runat="server" OnClick="Calculate" Text="=" />
        </div>
    </asp:Panel>
    <h1 runat="server" id="Out"></h1>
</div>
</asp:Content>