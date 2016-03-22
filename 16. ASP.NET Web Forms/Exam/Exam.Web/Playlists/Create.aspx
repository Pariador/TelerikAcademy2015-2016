<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Exam.Web.Playlists.Create" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<div class="row">
    <div class="col-md-12 jumbotron">
        <h1>Create Playlist</h1>
        <div class="row">
            <div class="col-md-3">
                <asp:Label runat="server" AssociatedControlID="Title">Tite: </asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="Title" TextMode="Singleline" placeholder="Title"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label runat="server" AssociatedControlID="Description">Description: </asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="Description" TextMode="Multiline" placeholder="Description"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label runat="server" AssociatedControlID="Categories">Category: </asp:Label>
            </div>
            <div class="col-md-4">
                <asp:DropDownList runat="server" ID="Categories" DataValueField="Id" DataTextField="Name"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label runat="server" AssociatedControlID="VideoUrls">VideoUrls separated with ", ": </asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="VideoUrls" TextMode="Multiline" placeholder="Video Url"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-7">
                <asp:Button runat="server" OnClick="Submit" CssClass="btn btn-primary" Text="Submit" />
            </div>
        </div>
    </div>    
</div>
</asp:Content>