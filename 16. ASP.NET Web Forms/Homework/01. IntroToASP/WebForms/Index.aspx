<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebForms.Index" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>Index</title>
    <style>
        body {
            background-color: teal;
        }

        .result {
           background-color: white;
        }
    </style>
</head>
<body>
    <h1>Sum 2 numbers:</h1>
    <form runat="server">
        <label for="first">First: </label><input runat="server" ID="First" type="text" value="0"/>
        <br/>
        <label for="second">Second: </label><input runat="server" ID="Second" type="text" value="0"/>
        <br/>
        <label for="result">Result: </label><span runat="server" ID="Result" class="result">0</span>
        <br/>
        <button runat="server" type="submit" OnServerClick="Sum">Sum</button>
    </form>
</body>
</html>
