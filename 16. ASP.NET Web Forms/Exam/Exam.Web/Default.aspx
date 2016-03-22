<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Exam.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Welcome to YouTube Playlists.</h1>
    <div class="bg-grey">
        <ul>
            <asp:UpdatePanel runat="server">
              <ContentTemplate>
                    <asp:Repeater runat="server" ID="Playlists" ItemType="Exam.Data.Models.Playlist">
                        <ItemTemplate>
                            <li>
                                 <div class="row">
                                    <div class="col-md-3">
                                        <a href="/Playlists/Details?id=<%#:Item.Id %>"><%#: Item.Title %></a>
                                    </div>
                                    <div class="col-md-3">
                                        Rating: <%#: Item.AvgRating() %>
                                    </div>
                                    <div class="col-md-3">
                                        Category:
                                        <a href=""><%#: Item.Category.Name %></a>
                                    </div>
                                    <div class="col-md-3">
                                        Creator: <%#: Item.Creator.FullName() %>
                                    </div>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
              </ContentTemplate>
            </asp:UpdatePanel>
        </ul>
    </div>
</asp:Content>
