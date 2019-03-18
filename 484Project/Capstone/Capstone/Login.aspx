<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<meta name="Cued-in" content="login">
	<meta name="viewport" content="width=device-width,initial-scale=1">
	<title>Login</title>
	<link rel="stylesheet" type="text/css" href="bootstrap/css/bootstrap.min.css">
	<link rel="stylesheet" type="text/css" href="css/my-login.css">
	<link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet">
</head>

    <body class="my-login-page">
        
	    <section class="h-100">
		    <div class="container h-100">
			    <div class="row justify-content-md-center h-100">
			    <div class="row justify-content-md-center h-100">
				    <div class="card-wrapper">
					    <div class="brand">
						    <img src="img/logo.jpg" alt="logo">
					    </div>
					    <div class="card fat">
						    <div class="card-body">
							    <h4 class="card-title">Login</h4>
							    <form runat="server" method="POST" class="my-login-validation" novalidate="">
								    <div class="form-group">
									    <asp:Label runat="server" for="email">E-Mail Address</asp:Label>
									    <asp:TextBox runat="server" id="email" type="email" class="form-control" name="email" ></asp:TextBox>
									    <div class="invalid-feedback">
										    Email is invalid
									    </div>
								    </div>

								    <div class="form-group">
									    <label for="password">Password
										    <a href="forgot.html" class="float-right" id="forgot-color">
											    Forgot Password?
										    </a>
									    </label>
									    <asp:TextBox runat="server" id="password" type="password" class="form-control" name="password" ></asp:TextBox>
								        <div class="invalid-feedback">
								    	    Password is required
							    	    </div>
								    </div>

								    <div class="form-group">
									    <div class="custom-checkbox custom-control">
										    <input type="checkbox" name="remember" id="remember" class="custom-control-input">
										    <label for="remember" class="custom-control-label">Remember Me</label>
									    </div>
								    </div>

								    <div class="form-group m-0">
									    <asp:button runat="server" type="submit" href="LandingPage.aspx" text="Login" class="btn btn-primary btn-block" OnClick="Unnamed2_Click">
										
									    </asp:button>
								    </div>
								    <div class="mt-4 text-center">
									    Don't have an account? <a href="register.aspx">Create One</a>
								    </div>
							    </form>
						    </div>
					    </div>
					    <div class="footer">
						    Copyright &copy; 2019 &mdash; CuedIn
					    </div>
				    </div>
			    </div>
		    </div>
         </div>
	    </section>

	    <script src="js/jquery.min.js"></script>
	    <script src="bootstrap/js/bootstrap.min.js"></script>
	    <script src="js/my-login.js"></script>
	  
    </body>

</html>

