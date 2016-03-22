<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="Tasks.Students" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label AssociatedControlID="FirstName">First Name: </asp:Label>
    <asp:TextBox runat="server" ID="FirstName" TextMode="SingleLine" Text="John" ></asp:TextBox>
    <br/>

    <asp:Label AssociatedControlID="LastName">Last Name: </asp:Label>
    <asp:TextBox runat="server" ID="LastName" TextMode="SingleLine" Text="Dough"></asp:TextBox>
    <br/>

    <asp:Label AssociatedControlID="FacultyNumber">Faculty Number: </asp:Label>
    <asp:TextBox runat="server" ID="FacultyNumber" TextMode="SingleLine" Text="8080"></asp:TextBox>
    <br/>

    <asp:Label AssociatedControlID="Universities">University: </asp:Label>
    <asp:DropDownList runat="server" ID="Universities">
        <asp:ListItem>Cat World Domination Uni</asp:ListItem>
        <asp:ListItem>HEAVY METAL UNIVERSITY !!!<%-- SO FUCKING METAL --%></asp:ListItem>
        <asp:ListItem>University of Pure Awesomeness</asp:ListItem>
    </asp:DropDownList>
    <br/>
    
    <asp:Label AssociatedControlID="Specialities">Speciality: </asp:Label>
    <asp:DropDownList runat="server" ID="Specialities">
        <asp:ListItem>Chicken</asp:ListItem>
        <asp:ListItem>Rock</asp:ListItem>
        <asp:ListItem>Pickle</asp:ListItem>
    </asp:DropDownList>
    <br/>

    <asp:Label AssociatedControlID="Courses">Course: </asp:Label>
    <asp:ListBox runat="server" ID="Courses" SelectionMode="Multiple">
        <asp:ListItem>Witchcraft and Wizardry</asp:ListItem>
        <asp:ListItem>How to exit Vim</asp:ListItem>
        <asp:ListItem>Unicorns</asp:ListItem>
    </asp:ListBox>
    <br/>

    <asp:Button runat="server" OnClick="Register" Text="Register" />
    <br/>
    
    <asp:Label AssociatedControlID="RegisteredStudents">Registered Students: </asp:Label>
    <asp:BulletedList runat="server" ID="RegisteredStudents"></asp:BulletedList>
</asp:Content>