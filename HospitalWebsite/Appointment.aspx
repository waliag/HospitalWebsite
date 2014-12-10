<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="HospitalWebsite.Appointment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Make Appointment</title>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }

        .row {
            margin: 20px 0px;
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
                <strong><span class="auto-style1">MAKE AN APPOINTMENT</span></strong>
                <br />
                <br />
                <br />
                <asp:Label ID="LabelDate" runat="server" Text="Choose Date:"></asp:Label>
                <asp:TextBox ID="TextDate" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Calendar ID="Calendar1" runat="server" DatePickerMode="true" TextBoxId="TextDate" OnDayRender="Calendar1_DayRender"
                     OnSelectionChanged="dateSelected"></asp:Calendar>
                <br />
                <asp:Label ID="SlotsLabel" runat="server" Text="Choose Slot:"></asp:Label>
                <br />
                <div class="row">
                    <asp:Table ID="SlotsTable" runat="server" class="table table-bordered" Width="350px">
                    </asp:Table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
