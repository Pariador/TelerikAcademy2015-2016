<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Exam.Web.Account.Details" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<div class="row">
    <div class="col-md-8 col-md-offset-2 jumbotron">
        <div class="row">
            <div class="col-md-7">
                <asp:Label runat="server" ID="Error" CssClass="text-danger"></asp:Label>
            </div>
        </div>        
        <h3 runat="server" id="Email"></h3>
        <div class="row">
            <div class="col-md-7">
                <%--<asp:RequiredFieldValidator runat="server" ID="RequireNewAvatarUrl" ControlToValidate="NewAvatarUrl" CssClass="text-danger" ErrorMessage="Can't be av empty."></asp:RequiredFieldValidator>--%>
            </div>
        </div>
         <div class="row">
            <div class="col-md-5">
                <asp:Image runat="server" ID="Avatar" Width="100" Height="100" />
            </div>
             <div class="col-md-5">
                <asp:TextBox runat="server" ID="NewAvatarUrl" TextMode="SingleLine" placeholder="Avatar Url"></asp:TextBox>
            </div>
             <div class="col-md-2">
                <asp:Button runat="server" OnClick="ChangeAvatarUrl" CssClass="btn btn-info" Text="change"/>
            </div>
        </div>
      <div class="row">
            <div class="col-md-7">
                <%--<asp:RequiredFieldValidator runat="server" ID="RequireNewFirstName" ControlToValidate="NewFirstName" CssClass="text-danger" ErrorMessage="Can't be fn empty."></asp:RequiredFieldValidator>--%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label runat="server">First Name: </asp:Label>
            </div>
            <div class="col-md-2">
                <asp:Label runat="server" ID="FirstName"></asp:Label>
            </div>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="NewFirstName" TextMode="SingleLine"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Button runat="server" OnClick="ChangeFirstName" CssClass="btn btn-info" Text="change"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-7">
                <%--<asp:RequiredFieldValidator runat="server" ID="RequireNewLastName" ControlToValidate="NewLastName" CssClass="text-danger" ErrorMessage="Can't be empty."></asp:RequiredFieldValidator>--%>
            </div>
        </div>
         <div class="row">
            <div class="col-md-3">
                <asp:Label runat="server">Last Name: </asp:Label>
            </div>
            <div class="col-md-2">
                <asp:Label runat="server" ID="LastName"></asp:Label>
            </div>
             <div class="col-md-5">
                <asp:TextBox runat="server" ID="NewLastName" TextMode="SingleLine"></asp:TextBox>
            </div>
             <div class="col-md-2">
                <asp:Button runat="server" OnClick="ChangeLastName" CssClass="btn btn-info" Text="change"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-7">
                <%--<asp:RequiredFieldValidator runat="server" ID="RequireNewFacebookUrl" ControlToValidate="NewFacebookUrl" CssClass="text-danger" ErrorMessage="Can't be empty."></asp:RequiredFieldValidator>--%>
            </div>
        </div>
       <div class="row">
            <div class="col-md-5">
               <a runat="server" id="FacebookUrl">Facebook Profile</a>
            </div>
           <div class="col-md-5">
                <asp:TextBox runat="server" ID="NewFacebookUrl" TextMode="SingleLine"></asp:TextBox>
            </div>
           <div class="col-md-2">
                <asp:Button runat="server" OnClick="ChangeFacebookUrl" CssClass="btn btn-info" Text="change"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-7">
                <%--<asp:RequiredFieldValidator runat="server" ID="RequireNewYoutubeUrl" ControlToValidate="NewYoutubeUrl" CssClass="text-danger" ErrorMessage="Can't be empty."></asp:RequiredFieldValidator>--%>
            </div>
        </div>
       <div class="row">
            <div class="col-md-5">
               <a runat="server" id="YoutubeUrl">Youtube Profile</a>
            </div>
           <div class="col-md-5">
                <asp:TextBox runat="server" ID="NewYoutubeUrl" TextMode="SingleLine"></asp:TextBox>
            </div>
           <div class="col-md-2">
                <asp:Button runat="server" OnClick="ChangeYoutubeUrl" CssClass="btn btn-info" Text="change"/>
            </div>
        </div>
         <div class="row">
            <div class="col-md-7">
                Playlists:
            </div>
        </div>
        <div class="row">
            <ul>
                <asp:Repeater runat="server" ID="Playlists" ItemType="Exam.Data.Models.Playlist">
                    <ItemTemplate>
                        <li>
                            <a href="/Playlists/Details?id=<%#:Item.Id %>"><%#: Item.Title %></a>
                            <asp:Button runat="server" CommandArgument="<%# Item.Id %>" OnClick="DeletePlaylist" CssClass="btn btn-danger" Text="X" />
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</div>
</asp:Content>