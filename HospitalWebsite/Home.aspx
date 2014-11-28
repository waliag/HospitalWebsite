<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HospitalWebsite.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>Hospital Management System</h3>
        <p>
        <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="SearchButton" runat="server" OnClick="Button1_Click" Text="Search" />
        </p>
        <p>
            <asp:Button ID="LoginButton" runat="server" Text="Log in" OnClick="LoginButton_Click" />
            <asp:Button ID="RegisterButton" runat="server" OnClick="RegisterButton_Click" Text="Register" />
        </p>
   </form>
</body>
</html>
