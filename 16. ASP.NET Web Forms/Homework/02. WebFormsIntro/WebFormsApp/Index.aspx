<%@ Page Title="Index" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebFormsApp.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 runat="server" ID="heading"></h1>
    <div>Assembly: <span runat="server" ID="assembly"></span></div>
    <br />
    <br />
    <h3>Page Life Cycle</h3>
    <ol runat="server" ID="lifeCycleList"></ol>
</asp:Content>
