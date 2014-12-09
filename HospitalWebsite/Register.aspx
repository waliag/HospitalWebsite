<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HospitalWebsite.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Registration</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css"/>

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap-theme.min.css"/>

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js"></script>

    <style type="text/css">

	input[type=text],input[type=password]
	{
		position: absolute;
        left: 200px;
	}
    .errormesg
    {
        position: absolute;
        left: 400px;
        color: red;
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
    <p>
      <span class="auto-style1"><strong>REGISTRATION</strong></span></p>
        <p>
            Please enter you details below:</p>
        <p>
            <asp:Label ID="LabelName" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" 
                ControlToValidate="TxtName"
                ErrorMessage="Required field" CssClass="errormesg">
            </asp:RequiredFieldValidator>
        </p>
         
        <p>
            <asp:Label ID="LabelEmail" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server"  CssClass="errormesg"
                ControlToValidate="TxtEmail" Display="Dynamic" 
                ErrorMessage="Required field">
            </asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                 ErrorMessage="Invalid Email" Display="Dynamic"  CssClass="errormesg"
                 ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                 ControlToValidate="TxtEmail">
             </asp:RegularExpressionValidator>
        </p>
        <p>
            <asp:Label ID="LabelPassword" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" />
            <asp:RequiredFieldValidator runat="server"  CssClass="errormesg"
                ControlToValidate="TxtPassword" Display="Dynamic" 
                ErrorMessage="Required field">
            </asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="LabelConfirmPassword" runat="server" Text="Confirm Password: "></asp:Label>
            <asp:TextBox ID="TxtConfirmPassword" runat="server" TextMode="Password" />
            <asp:RequiredFieldValidator runat="server"  CssClass="errormesg"
                ControlToValidate="TxtConfirmPassword" Display="Dynamic" 
                ErrorMessage="Required field">
            </asp:RequiredFieldValidator>
            <asp:CompareValidator ErrorMessage="Passwords do not match." CssClass="errormesg" ControlToCompare="TxtPassword"
                ControlToValidate="TxtConfirmPassword" runat="server" />
        </p>
        <br />
          <asp:Button ID="CreateAccountButton" runat="server" OnClick="Create_Account" class="btn btn-primary" Text="Create Account"  Width="150px"/>
    </div>
            </div>
    </form>
</body>
</html>
