<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientAccountPage.aspx.cs" Inherits="HospitalWebsite.PatientDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }

        .auto-style2 {
            font-size: medium;
            font-weight: bold;
        }

        .auto-style3 {
            font-weight: bold;
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
                <span class="auto-style1"><strong>Account Information </strong></span>
                <br />
                <br />
                <span><strong>Name:</strong></span>
                <asp:Label ID="LbName" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <span><strong>DOB:</strong></span>
                <asp:Label ID="LbDOB" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <span><strong>Height:</strong></span>
                <asp:Label ID="Lbheight" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <span><strong>Weight:</strong></span>
                <asp:Label ID="Lbweight" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <span><strong>Allergies:</strong></span>
                <asp:Label ID="Lballergies" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <p>
                    <asp:Label ID="Lbheading" runat="server" class="auto-style2" Text="Appointment details"></asp:Label>
                </p>
                <asp:Label ID="Lbdoctor" runat="server" class="auto-style3" Text="Consulting Doctor:"></asp:Label>
                <asp:Label ID="Lbdocdetails" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Label ID="Lbdate" runat="server" class="auto-style3" Text="Date:"></asp:Label>
                <asp:Label ID="Lbdatedetails" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Label ID="LbSlot" runat="server" class="auto-style3" Text="Slot:"></asp:Label>
                <asp:Label ID="Lbslotdetails" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" class="btn btn-primary"
                    OnClick="Button1_Click" Text="Home" />
                <asp:Button ID="Button3" runat="server"
                    Text="Logout" class="btn btn-primary" OnClick="Button2_Click" />

            </div>
        </div>
    </form>
</body>
</html>
