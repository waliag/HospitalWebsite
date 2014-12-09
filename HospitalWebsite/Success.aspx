<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="HospitalWebsite.Success" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Success</title>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
            text-align: center;
        }
    </style>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css" />

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap-theme.min.css" />

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="jumbotron">
                <div class="header">
                    <nav>

                        <ul class="nav nav-pills pull-right">
                            <li role="presentation">
                                <asp:Button ID="Button1" runat="server" class="btn btn-primary"
                                    OnClick="Button1_Click" Text="Home" /></li>
                            <li role="presentation">
                                <asp:Button ID="Button2" runat="server" Text="Log In" class="btn btn-primary"
                                    OnClick="Button2_Click" /></li>
                        </ul>
                    </nav>

                    <asp:Label ID="Label1" runat="server" class="auto-style1"
                        Text="You have succesfully completed registration. Thank You."></asp:Label>

                    <asp:Label ID="Label2" runat="server" class="auto-style1"
                        Text="Appointment made successfully.Email has been sent."></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
