<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Exam.Web.Playlists.Details" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<div class="row">
    <div class="col-md-8 col-md-offset-2 jumbotron">
        <h3 runat="server" id="title"></h3>
        <div class="row">
            <div class="col-md-3">
                <asp:Label runat="server">Description: </asp:Label>
            </div>
            <div class="col-md-4">
            </div>
        </div>
        <div class="row">
            <div class="col-md-7">
                <p runat="server" ID="Description"></p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label runat="server">Category: </asp:Label>
            </div>
            <div class="col-md-4">
                <asp:Label runat="server" ID="Category"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label runat="server">Created On: </asp:Label>
            </div>
            <div class="col-md-4">
                <asp:Label runat="server" ID="CreatedOn"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label runat="server">Creator: </asp:Label>
            </div>
            <div class="col-md-4">
                <asp:Label runat="server" ID="Creator"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label runat="server">Rating: </asp:Label>
            </div>
            <div class="col-md-4">
                <asp:Label runat="server" ID="Rating"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label runat="server">Videos: </asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-7">
                <asp:Repeater runat="server" ID="Videos" ItemType="Exam.Data.Models.Video">
                    <ItemTemplate>
                        <% if (this.CreatorLoggedIn) { %>
                            <asp:Button runat="server" CommandArgument="<%# Item.Id %>" OnClick="DeleteVideo" CssClass="btn btn-danger" Text="X" />
                        <% } %>
                        <iframe width="420" height="315"src="<%#: Item.GetEmbededUrl() %>"></iframe>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</div>
</asp:Content>