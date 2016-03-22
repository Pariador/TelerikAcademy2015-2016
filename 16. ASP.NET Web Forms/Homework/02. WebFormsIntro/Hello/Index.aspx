<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Hello.Index" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Hello</title>
</head>
<body>
    <h1>Hello</h1>
    <form runat="server">
        <label for="name">Name:</label>
        <asp:TextBox runat="server" ID="name"></asp:TextBox>
        <asp:Button runat="server" Text="Display" OnClick="Display"/>
        <asp:Label runat="server" ID="result"></asp:Label>
    </form>
</body>
</html>
