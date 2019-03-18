<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<meta name="author" content="company registration">
	<meta name="viewport" content="width=device-width,initial-scale=1">
	<title>Create A New Account</title>
	<link rel="stylesheet" type="text/css" href="bootstrap/css/bootstrap.min.css">
	<link rel="stylesheet" type="text/css" href="css/my-login.css">
</head>
<body class="my-login-page">
	<section class="h-100">
		<div class="container h-100">
			<div class="row justify-content-md-center h-100">
				<div class="card-wrapper1">
					<div class="brand">
						<img src="img/logo.jpg" alt="bootstrap 4 login page">
					</div>
					<div class="card fat">
						<div class="card-body">
							<h4 class="card-title">Company Information</h4>
							<form method="POST" class="my-login-validation" runat="server" novalidate="">
								<div class="form-group">
									<label for="name" runat="server">Company Name</label>
									<input id="CompanyName" type="text" class="form-control" runat="server" name="name" required autofocus>
								</div>

								<div class="form-group">
									<label for="txtIndustry" runat="server">Industry</label>
									<input id="txtIndustry" type="text" class="form-control" runat="server" name="nameasd" required>
								</div>

								<div class="form-group">
									<label for="size" runat="server">Size</label>
									<input id="size" type="text" class="form-control" runat="server" name="size" required data-eye>
								</div>

								<div class="form-group">
									<label for="description">Description</label>
									<input id="description" type="text" runat="server" class="form-control" name="description" required data-eye>
								</div>

				<br>
                            
								<h4 class="card-title">Contact Information</h4>
							
								<div class="form-group">
									<label for="name" runat="server">Your Name</label>
									<input id="ContactName" type="text" class="form-control" runat="server" name="name" required autofocus>
								</div>

								<div class="form-group">
									<label for="title" runat="server">Title</label>
									<input id="title" type="text" class="form-control" runat="server" name="title" required>
								</div>

								<div class="form-group">
									<label for="username" runat="server">Username</label>
									<input id="username" type="text" class="form-control" runat="server" name="username" required data-eye>
								</div>

								<div class="form-group">
									<label for="password" runat="server">Password</label>
									<input id="password" type="text" runat="server" class="form-control" name="password" required data-eye>
								</div>

								<div class="form-group">
									<label for="Phone" runat="server">Phone</label>
									<input id="Phone" type="text" class="form-control" runat="server" name="Phone" required data-eye>
								</div>

								<div class="form-group">
									<label for="email" runat="server">E-mail</label>
									<input id="email" type="text" class="form-control" runat="server" name="e-mail" required data-eye>
								</div>

								<div class="form-group">
									<div class="custom-checkbox custom-control">
										<input type="checkbox" name="agree" id="agree" class="custom-control-input" runat="server" required="">
										<label for="agree" class="custom-control-label" runat="server">I agree to the <a href="#">Terms and Conditions</a></label>
										<div class="invalid-feedback">
											You must agree with our Terms and Conditions
										</div>
									</div>
								</div>

								<div class="form-group m-0">
									<asp:Button type="submit" id="btnRegister" text="Register" OnClick="RegisterBtnClick" runat="server" class="btn btn-primary btn-block">
									</asp:Button>
								</div>
								<div class="mt-4 text-center">
									Already have an account? <a href="index.html">Login</a>
								</div>
							</form>
						</div>
					</div>
					<div class="footer">
						Copyright &copy; 2017 &mdash; Your Company 
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
