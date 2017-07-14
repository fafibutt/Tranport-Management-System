<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TransportManagementSystemFYP.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login </title>
    <link href="css/Login/font-awesomeLogin.css" rel="stylesheet" />
    <link href="css/Login/LoginStyle.css" rel="stylesheet" />
    <script src="js/Login/jquery-2.1.4.min.js"></script>
    <script src="js/Login/jquery.vide.min.js"></script>
</head>
<body>
    <div data-vide-bg="images/color1">
	<div class="center-container">
		<!--header-->
		<div class="header-w3l">
			<h1>Login</h1>
		</div>
		<!--//header-->
		<!--main-->
		<div class="main-content-agile">
			<div class="wthree-pro">
				<h2>Login Here</h2>
			</div>
			<div class="sub-main-w3">	
				<form runat="server">
                    <asp:TextBox ID="email" type="email" runat="server"></asp:TextBox>
                    <asp:TextBox ID="pass" type="password" runat="server"></asp:TextBox>
                    <br />
					<!--<div class="rem-w3">
						<span class="check-w3"><input type="checkbox" />Remember Me</span>
						<a href="#">Forgot Password?</a>
						<div class="clear"></div>
					</div>-->
                    <asp:Button ID="BtnLogin" type="submit" OnClick="BtnLogin_Click" runat="server" Text="Login" />
                    <asp:HyperLink ID="HyperLink1" type="submit" runat="server" NavigateUrl="~/Register.aspx">Register</asp:HyperLink>
				</form>
			</div>
		</div>
		<!--//main-->
		<!--footer-->
		<div class="footer">
			<p>&copy; 2017 TMS. All rights reserved </p>
		</div>
		<!--//footer-->
	</div>
</div>

</body>
</html>
