<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TransportManagementSystemFYP.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register-Transport Information Information</title>
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
			<h1>Register</h1>
		</div>
		<!--//header-->
		<!--main-->
		<div class="main-content-agile">
			<div class="wthree-pro">
				<h2>Register here</h2>
			</div>
			<div class="sub-main-w3">	
				<form class="login-form" runat="server">
                                <div class="form-group">
                                    <asp:TextBox ID="UniId" placeholder="Your University ID..." type="name"  class="form-username form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="UserName" placeholder="Your name..." type="name"  class="form-username form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="UserEmail" placeholder="Your University Email..." type="email"  class="form-username form-control" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="EmailValidator" runat="server" ErrorMessage="Email format does not match" ControlToValidate="UserEmail" ValidationExpression="([[0-9]{8}@gift.edu.pk)"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="Password" placeholder="Password..." class="form-password form-control" type="password" runat="server"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="ConfirmPassword" placeholder="Confirm Password..." class="form-password form-control" type="password" runat="server"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Your Password does not match" ControlToCompare="Password" ControlToValidate="ConfirmPassword"></asp:CompareValidator>
                                </div>
                                
                                <asp:Button ID="BtnRegister" type="submit" class="btn" runat="server" Text="Register" OnClick="BtnRegister_Click" />
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
    <div class="top-content">
        <div class="inner-bg">
            <div class="container">
                <div class="row">
                    <div class="col-sm-6 col-sm-offset-3 form-box">
                        <div class="form-top">
                            <div class="form-top-left">
                                <h3>Registration</h3>
                                <p>Enter Your Detail To Register:</p>
                            </div>
                            <div class="form-top-right">
                                <i class="fa fa-key"></i>
                            </div>
                        </div>
                        <div class="form-bottom">
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</body>
</html>
