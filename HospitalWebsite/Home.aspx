<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HospitalWebsite.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css"/>

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap-theme.min.css"/>

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js"></script>
    <style>
        .row {
            margin: 50px 0px;
        }
        h2 {
            text-align: center;
            padding-bottom: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="jumbotron">
                <h2 class="">Hospital Management System</h2>
                <div class="header">
                    <nav>
                        <ul class="nav nav-pills pull-left">
                            <li role="presentation">
                                </li>
                            <li role="presentation">
                                </li>

                        </ul>
                        <ul class="nav nav-pills pull-right">
                            <li role="presentation">
                                <asp:Button ID="MyAccountButton" runat="server" class="btn btn-primary"
                                    OnClick="ViewAccount_Click" Text="My Account" /></li>
                            <li role="presentation">
                                <asp:Button ID="LogoutButton" runat="server" class="btn btn-primary"
                                    Text="Log Out" OnClick="LogoutButton_Click" /></li>

                            <li role="presentation">
                                <asp:Button ID="RegisterButton" runat="server" class="btn btn-primary"
                                    OnClick="RegisterButton_Click" Text="Register" /></li>
                            <li role="presentation">
                                <asp:Button ID="LoginButton" runat="server" Text="Log In" class="btn btn-primary"
                                    OnClick="LoginButton_Click" /></li>
                        </ul>
                    </nav>
                </div>
                <div class="row">
                    <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
                    <asp:Button ID="SearchButton" runat="server" class="btn btn-primary" 
                                     OnClick="SearchButton_Click" Text="Find Doctor" />
                </div>
                <p>
                    Welcome to the HMS, you can search Doctors by name/specialization and book an appointment. 
                    Please register to book an appointment, 
                    and check confirmed appointments in the account page.
                </p>
                <div class="row">
                    <asp:Table ID="DoctorTable" runat="server" class="table table-bordered">
                    </asp:Table>
                </div>
                
            </div>
        </div>
    </form>
</body>
</html>
