<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDetails.aspx.cs" Inherits="HospitalWebsite.AddDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enter Details</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css" />

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap-theme.min.css" />

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js"></script>
    <style>
        .textfield {
            position: absolute;
            left: 200px;
        }
         .auto-style1 {
        font-size: large;
     }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div>
                <br />
                <br />
                <span class="auto-style1"><strong>Hello
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>!!!</strong></span>
                <br />
                <br />
                Please complete the form below:
                <br />
                <br />
                Date Of Birth:
        <asp:TextBox ID="TbDOB" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Calendar ID="CdDOB" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                <br />
                <br />
                Height(cms):
        <asp:TextBox ID="Tbheight" runat="server" CssClass="textfield"></asp:TextBox>
                <br />
                <br />
                Weight(lbs):
        <asp:TextBox ID="Tbweight" runat="server" CssClass="textfield"></asp:TextBox>
                <br />
                <br />
                Allergies:
        <asp:TextBox ID="Tballergies" runat="server" CssClass="textfield"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="BFinish" runat="server" class="btn btn-primary" Text="Finish" OnClick="BFinish_Click" />
            </div>
        </div>
    </form>
</body>
</html>
