<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="HospitalWebsite.Appointment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Make Appointment</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="LabelDate" runat="server" Text="Choose Date:"></asp:Label>
        <asp:TextBox ID="TextDate" runat="server"></asp:TextBox>
        <asp:Calendar ID="Calendar1" runat="server" DatePickerMode="true" TextBoxId="TextDate" OnSelectionChanged="dateSelected"></asp:Calendar>

        <asp:Table ID="SlotsTable" runat="server" GridLines="Both">

        </asp:Table>
    </div>
    </form>
</body>
</html>
