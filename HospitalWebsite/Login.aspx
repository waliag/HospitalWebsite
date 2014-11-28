<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HospitalWebsite.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
</head>
<body>

    <form id="form1" runat="server">
        <asp:Login ID="Login1" runat="server" Height="168px" Width="355px" OnAuthenticate="AuthenticateUser">
        </asp:Login>
    </form>

</body>
</html>
