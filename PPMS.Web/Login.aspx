<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PPMS.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PPMS Login</title>

    <!-- Meta Tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Login PPMS" />
    <script type="application/x-javascript">
		addEventListener("load", function () {
			setTimeout(hideURLbar, 0);
		}, false);

		function hideURLbar() {
			window.scrollTo(0, 1);
		}
    </script>
    <!-- //Meta Tags -->
    <!-- Font-Awesome-CSS -->
    <link href="Content/css/font-awesome-login.css" rel="stylesheet" />
    <!--// Font-Awesome-CSS -->
    <!-- Required Css -->
    <link href="Content/css/login.css" rel='stylesheet' type='text/css' />
    <!--// Required Css -->
    <!--fonts-->
    <link href="//fonts.googleapis.com/css?family=Montserrat:300,400,500,600" rel="stylesheet" />
    <!--//fonts-->
</head>
<body>
    <!--background-->
    <h1>PPMS</h1>
    <!-- Main-Content -->
    <div class="main-w3layouts-form">
        <h2><img src="Content/images/logo.png" alt="logo" /></h2>
        <!-- main-w3layouts-form -->
        <form id="loginForm" runat="server">
            <div class="fields-w3-agileits">
                <span class="fa fa-user" aria-hidden="true"></span>
                <asp:TextBox ID="txtUserName" runat="server" type="text" name="UserName" required="" placeholder="Username" />
            </div>
            <div class="fields-w3-agileits">
                <span class="fa fa-key" aria-hidden="true"></span>
                <asp:TextBox ID="txtPassword" runat="server" type="password" name="Password" placeholder="Password" />
            </div>
            <div class="remember-section-wthree">
                <ul>
                    <li>
                        <label class="anim">
                            <asp:CheckBox ID="chkRememberMe" class="checkbox" runat="server" type="checkbox" />
                            <span>Remember me ?</span>
                        </label>
                    </li>
                    <li><a href="#">Forgot password?</a> </li>
                </ul>
                <div class="clear"></div>
            </div>
            <input id="login" type="submit" value="Login" runat="server" onserverclick="login_ServerClick" form="loginForm" />
        </form>
        <!--// main-w3layouts-form -->
    </div>
    <!--// Main-Content-->
    <!-- copyright -->
    <div class="copyright-w3-agile">
        <p>&copy; 2017 PPMS Login All Rights Reserved | Design by <a href="http://w3layouts.com/" target="_blank">W3layouts</a>			</p>
    </div>
    <!--// copyright -->
    <!--//background-->
</body>
</html>
