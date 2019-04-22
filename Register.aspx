<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" ValidateRequest ="false" %>

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
									<input id="CompanyName" type="text" class="form-control" maxlength="50" runat="server" name="name" required autofocus>
                                    <asp:RequiredFieldValidator ID="CompanyNameRequiredFieldValidator" runat="server" ControlToValidate="CompanyName" ErrorMessage="(Required)" ForeColor="Red"></asp:RequiredFieldValidator>

								</div>

								<div class="form-group">
									<label for="industry" runat="server">Industry</label>
									<input id="industry" type="industry" runat="server" class="form-control" maxlength="50" name="industry" required>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorIndustry" runat="server" ControlToValidate="industry" ErrorMessage="(Required)" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="IndustryRegularExpressionValidator" runat="server" ControlToValidate="industry" ErrorMessage="(Invalid Industry)" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator>

                                    
								</div>

								<div class="form-group">
									<label for="size" runat="server">Size</label>
									<input id="size" type="size" class="form-control" runat="server" maxlength="20" name="size" required data-eye>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSize" runat="server" ControlToValidate="size" ErrorMessage="(Required)" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="size" ErrorMessage="(Invalid Size)" ForeColor="Red" ValidationExpression="[\d -]+"></asp:RegularExpressionValidator>


								</div>

								<div class="form-group">
									<label for="description">Description</label>
									<input id="description" type="description" runat="server" class="form-control" maxlength="200" name="description" required data-eye>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescription" runat="server" ControlToValidate="description" ErrorMessage="(Required)" ForeColor="Red"></asp:RequiredFieldValidator>

								</div>

				<br>
                            
								<h4 class="card-title">Contact Information</h4>
							
								<div class="form-group">
									<label for="name" runat="server">Your Name</label>
									<input id="ContactName" type="text" class="form-control" runat="server" name="name" maxlength="30" required autofocus>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ContactName" ErrorMessage="(Required)" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="ContactName" ErrorMessage="(Invalid Name)" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator>
								</div>

								<div class="form-group">
									<label for="title" runat="server">Title</label>
									<input id="title" type="title" class="form-control" maxlength="30" runat="server" name="title" required>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="title" ErrorMessage="(Required)" ForeColor="Red"></asp:RequiredFieldValidator>

								</div>

								<div class="form-group">
									<label for="username" runat="server">Username</label>
									<input id="username" type="username" class="form-control" maxlength="30" runat="server" name="username" required data-eye>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ControlToValidate="username" ErrorMessage="(Required)" ForeColor="Red"></asp:RequiredFieldValidator>

								</div>

								<div class="form-group">
									<label for="password" runat="server">Password</label>
									<input id="password" type="password" runat="server" class="form-control" maxlength="100" name="password" required data-eye><span class="help-block">8 characteres minimum.</span>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="password" ErrorMessage="(Required)" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="PasswordRegularExpressionValidator" runat="server" ControlToValidate="password" ErrorMessage="(Password less than 8 characters)"  ForeColor="Red" ValidationExpression="^[\s\S]{8,}$"></asp:RegularExpressionValidator>


								</div>

								<div class="form-group">
									<label for="Phone" runat="server">Phone</label>
									<input id="Phone" type="Phone" class="form-control" maxlength="12" runat="server" name="Phone" required data-eye>
                                    <asp:RequiredFieldValidator ID="PhoneRequiredFieldValidator" runat="server" ControlToValidate="Phone" ErrorMessage="(Required)" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="PhoneRegularExpressionValidator" runat="server" ControlToValidate="Phone" ErrorMessage="(Invalid Phone Number)"  ForeColor="Red" ValidationExpression="[\d -]+"></asp:RegularExpressionValidator>
                                    
								</div>

								<div class="form-group">
									<label for="email" runat="server">E-mail</label>
									<input id="email" type="e-mail" class="form-control" maxlength="30" runat="server" name="e-mail" required data-eye>
                                    <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ControlToValidate="email" ErrorMessage="(Required)" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server" ControlToValidate="email" ErrorMessage="(Invalid Email Address)" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    
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
                                <div>
                                    <br />
                                </div>
                               <div class="form-group m-0">
                                <asp:Button type="submit" id="btnPopulate" text="Populate" UseSubmitBehavior="false" CausesValidation="False" OnClick="PopulateBtnClick" runat="server" class="btn btn-primary btn-block">
									</asp:Button>
                                   </div>

								<div class="mt-4 text-center">
									Already have an account? <a href="Login.aspx">Login</a>
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
