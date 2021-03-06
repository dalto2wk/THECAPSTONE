﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobPostForm.aspx.cs" Inherits="company_dashboard_JobPostForm" ValidateRequest ="false" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<meta name="description" content="create listing form">
	<link rel="icon" href="images/favicon.ico">
	<title>Create A Listing</title>

	<!-- Bootstrap core CSS -->
	<link href="dist/css/bootstrap.min.css" rel="stylesheet">
	
	<!-- Icons -->
	<link href="css/font-awesome.css" rel="stylesheet">
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous">
	
	<!-- Custom styles -->
	<link href="css/style.css" rel="stylesheet">
    
	
</head>
<body>
	<div class="container-fluid" runat="server" id="wrapper">
		<div runat="server" class="row">
			<nav class="sidebar col-xs-12 col-sm-4 col-lg-3 col-xl-2">
				<div class="sitelogo">
				<a href="LandingPage.aspx"><img src="/img/logo.png" alt="logo"></a>
			</div>
													
				<a href="#menu-toggle" class="btn btn-default" id="menu-toggle"><em class="fa fa-bars"></em></a>
				<ul class="nav nav-pills flex-column sidebar-nav">
                    <!-- Fix these links to go somewhere -->
					<li class="nav-item"><a class="nav-link active" href="LandingPage.aspx"><em class="fas fa-tachometer-alt"></em> Dashboard <span class="sr-only">(current)</span></a></li>
					<li class="nav-item"><a class="nav-link" href="StudentContact.aspx"><em class="fas fa-user-graduate"></em> Student Contact</a></li>
					<li class="nav-item"><a class="nav-link" href="SchoolContact.aspx"><em class="fas fa-school"></em> School Contact</a></li>
					<li class="nav-item"><a class="nav-link" href="Listing.aspx"><em class="fas fa-clipboard-list"></em> View Listings</a></li>
					<li class="nav-item"><a class="nav-link" href="EditProfile.aspx"><em class="fas fa-user-edit"></em> Edit Profile</a></li>
				</ul>
				<a  runat="server" class="logout-button" onServerClick="logoutClick"><em class="fa fa-power-off"></em> Signout</a>
			</nav>
			<main class="col-xs-12 col-sm-8 col-lg-9 col-xl-10 pt-3 pl-4 ml-auto">
				<header class="page-header row justify-center">
					<div runat="server" class="col-md-6 col-lg-8" >
						<h1 class="float-left text-center text-md-left">Create Job Post</h1>
					</div>
					<div runat="server" class="dropdown user-dropdown col-md-6 col-lg-4 text-center text-md-right"><a class="btn btn-stripped dropdown-toggle" href="https://example.com" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
						<img src="images/profile-pic.jpg" alt="profile photo" class="circle float-left profile-photo" width="50" height="auto">
						<div runat="server" class="username mt-1">
							<h4 class="mb-1"><asp:Literal runat="server" id="loggedInUser" /></h4>
							<h6 class="text-muted">Admin</h6>
						</div>
						</a>
						<div runat="server" class="dropdown-menu dropdown-menu-right" style="margin-right: 1.5rem;" aria-labelledby="dropdownMenuLink"><a class="dropdown-item" href="EditProfile.aspx"><em class="fa fa-user-circle mr-1"></em> View Profile</a>
							 
							 <a class="dropdown-item" runat="server" onServerClick="logoutClick" ><em class="fa fa-power-off mr-1"></em> Logout</a></div>
					</div>
					<div runat="server" class="clear"></div>
				</header>
				<section runat="server" class="row">
					<div runat="server" class="col-sm-12">
						<section runat="server" class="row">
							<div runat="server" class="col-12">
								<div runat="server" class="card mb-4">
									<div runat="server" class="card-block">
										<h3 class="card-title">Listing Information</h3>
                                        <%-- action = # makes form stay on same page after submission --%>
										<form class="form" action="#" runat="server">
											<div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server">Job Title</label>
												<div runat="server" class="col-md-9">

													<input id="txtJobTitle" type="text" name="regular" runat="server" class="form-control" maxlength="50" required >
                                                    
												</div>
											</div>
                                            <div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server">State</label>
												<div runat="server" class="col-md-9">
                                                    <asp:DropDownList ID="DropDownList_State" CssClass="form-control" runat="server" DataSourceID="SqlDataSourceState" DataTextField="State" DataValueField="LocationID" SelectionMode="Single" OnSelectedIndexChanged="StateSelection_Change" AutoPostBack="true"></asp:DropDownList>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSourceState" ConnectionString='<%$ ConnectionStrings:ProjectConnectionString %>' SelectCommand="SELECT [LocationID], [State] FROM (SELECT State, MIN(LocationID) LocationID FROM cities GROUP BY State) A ORDER BY State"></asp:SqlDataSource>
                                     
												</div>
											</div>
                                             <div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server">City</label>
												<div runat="server" class="col-md-9">
                                                    <asp:DropDownList ID="DropDownList_City" CssClass="form-control" runat="server" DataSourceID="SqlDataSourceCity" DataTextField="CityCounty" DataValueField="LocationID" SelectionMode="Single" OnSelectedIndexChanged="CitySelection_Change" AutoPostBack="true"></asp:DropDownList>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSourceCity" ConnectionString='<%$ ConnectionStrings:ProjectConnectionString %>' SelectCommand="SELECT [LocationID], [CityCounty] FROM (SELECT CityCounty, MIN(LocationID) LocationID FROM cities GROUP BY CityCounty) A ORDER BY LocationID;"></asp:SqlDataSource>
                                                    
												</div>
											</div>
                                            <div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server">School</label>
												<div runat="server" class="col-md-9">
													<%--<select id="ddlInterest" class="custom-select form-control" runat="server">
														<option selected runat="server">What category does this job fit to attract students</option>
														<option value="Mechanics" runat="server">Mechanics</option>
														<option value="Technology" runat="server">Technology</option>
														<option value="Business - General" runat="server">Business - General</option>
														<option value="Culinary" runat="server">Culinary</option>
														<option value="Construction" runat="server">Construction</option>
														<option value="Other" runat="server">Other</option>
													</select>--%>
                                                   <%-- <asp:CheckBoxList ID="cboxInterests" runat="server" DataSourceID="PostingInterest" DataTextField="name" DataValueField="name"></asp:CheckBoxList>--%>
                                                    <asp:ListBox ID="listBoxSchool" CssClass="form-control" runat="server" DataSourceID="PostingSchool" DataTextField="SchoolName" DataValueField="SchoolID" SelectionMode="Multiple" AutoPostBack="true"></asp:ListBox>
                                                    <asp:SqlDataSource runat="server" ID="PostingSchool" ConnectionString='<%$ ConnectionStrings:ProjectConnectionString %>' SelectCommand=""></asp:SqlDataSource>
                                                    <%--<asp:SqlDataSource runat="server" ID="SqlDataSourceSchool" ConnectionString='<%$ ConnectionStrings:ProjectConnectionString %>' SelectCommand=""></asp:SqlDataSource>--%>
                                                    
                                                </div>
											</div>
											<div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server"> Requirements/Credentials</label>
												<div runat="server" class="col-md-9">
													<input id="txtRequirements" type="text" name="regular" runat="server" class="form-control" maxlength="200" required  >
                                                      
												</div>
											</div>
											<div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server">Student Interest</label>
												<div runat="server" class="col-md-9">
													<%--<select id="ddlInterest" class="custom-select form-control" runat="server">
														<option selected runat="server">What category does this job fit to attract students</option>
														<option value="Mechanics" runat="server">Mechanics</option>
														<option value="Technology" runat="server">Technology</option>
														<option value="Business - General" runat="server">Business - General</option>
														<option value="Culinary" runat="server">Culinary</option>
														<option value="Construction" runat="server">Construction</option>
														<option value="Other" runat="server">Other</option>
													</select>--%>
                                                   <%-- <asp:CheckBoxList ID="cboxInterests" runat="server" DataSourceID="PostingInterest" DataTextField="name" DataValueField="name"></asp:CheckBoxList>--%>
                                                    <asp:ListBox ID="listBoxInterests" CssClass="form-control" runat="server" DataSourceID="PostingInterest" DataTextField="name" DataValueField="interestID" SelectionMode="Multiple"></asp:ListBox>
                                                    <asp:SqlDataSource runat="server" ID="PostingInterest" ConnectionString='<%$ ConnectionStrings:ProjectConnectionString %>' SelectCommand="SELECT [interestID], [name] FROM [Interest]"></asp:SqlDataSource>
                                                </div>
											</div>
											<div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server">Description</label>
												<div runat="server" class="col-md-9">
												<input id="txtDescription" type="text" name="regular" runat="server" class="form-control " maxlength="200" required><span class="help-block">Students will see this when viewing listings.</span></div>
                                                
											</div>

                                            <div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server">Posting Date</label>
												<div runat="server" class="col-md-9">
												<input id="postStart"  runat="server" data-provide="datepicker" class="form-control">

												</div>
                                                
											</div>
                                            <div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server">Posting End Date</label>
												<div runat="server" class="col-md-9">
												<input id="postEnd"  runat="server" data-provide="datepicker" class="form-control">

												</div>
                                                
											</div>
                                            <div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server">Opportunity Start Date</label>
												<div runat="server" class="col-md-9">
												<input id="opportunityStartDate"  data-provide="datepicker" runat="server" class="form-control">

												</div>
                                                
											</div>

                                            
											<br>

											<h3 class="card-title">Contact Information</h3>
											<div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server">Contact Name</label>
												<div runat="server" class="col-md-9">
													<input id="txtCpName" type="text" name="regular" runat="server" class="form-control" maxlength="50" required>
                                                    
                                                    <asp:RegularExpressionValidator ID="ContactNameRegularExpressionValidator" runat="server" ControlToValidate="txtCpName" ErrorMessage="(Invalid Name)" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                                                  
												</div>
											</div>
											<div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server">Phone</label>
												<div runat="server" class="col-md-9">
													<input id="txtCpPhone" type="text" name="regular" class="form-control" runat="server" maxlength="12" required>
                                                    
                                                    <asp:RegularExpressionValidator ID="PhoneRegularExpressionValidator" runat="server" ControlToValidate="txtCpPhone" ErrorMessage="(Invalid Phone Number)" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                   
                               
												</div>
											</div>
											<div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server">E-mail</label>
												<div runat="server" class="col-md-9">
													<input id="txtCpEmail" type="text" name="regular" class="form-control" runat="server" maxlength="30" required>
                                                    
                                                    <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server" ControlToValidate="txtCpEmail" ErrorMessage="(Invalid Email Address)" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                    
                               
												</div>
											</div>
											<br>
                                            <div class="container">
											
    											<fieldset>
       										 	<div class="form-horizontal">
            									<div class="form-group row">
            									<label class="col-md-3 col-form-label">Media Upload</label>
               									
                								
                								<div class="col-md-10">
                    							<div class="input-group">
                        							<input runat="server" type="hidden" id="filename" name="filename" value="">
                                                    
                        							<asp:fileupload ID="fileUp" CssClass="form-control form-control-sm" accept="image/bmp,image/gif,image/jpeg,image/png" AllowMultiple="true" runat="server"></asp:fileupload>
                        						
                    							
                								</div>
                							</div>
            								</div>                        
        									</div>
    										</fieldset>    
											
											</div>
										<div runat="server" class="row">
                                                <div runat="server" class="col-lg-6 mb-sm-4 mb-lg-0">
                                                    <%--<div runat="server" class="custom-control custom-radio">
                                                        <input type="radio" id="active" value="Y" name="customRadio" class="custom-control-input" runat="server">
                                                        <label class="custom-control-label custom-control-description" for="customRadio1" runat="server">Post Now</label>
                                                    </div>
                                                    <br />
                                                    <div runat="server" class="custom-control custom-radio">
                                                        <input type="radio" id="inactive" value="N" name="customRadio" class="custom-control-input" runat="server">
                                                        <label class="custom-control-label custom-control-description" for="customRadio2" runat="server">Save for Later</label>
                                                    </div>--%>
                                                    <asp:RadioButtonList runat="server" ID="statusRadioBtn" CssClass="custom-control custom-radio">
                                                        <asp:ListItem CssClass="custom-control-input" Value="Y" Text="Post Now"></asp:ListItem>
                                                        <asp:ListItem CssClass="custom-control-input" Value="N" Text="Save for Later"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
										<br>
										<div runat="server" class="row">
											<div runat="server" class="col-lg-6 mb-sm-4 mb-lg-0">

											<asp:Button id="btnSubmitPosting" CssClass="btn btn-primary text-center" type="button" text="Submit" OnClick="submitPostingBtnClick" runat="server"></asp:Button>   

                                            <asp:Button ID="populate" CssClass="btn btn-primary text-center" Text="Populate Fields" runat="server" UseSubmitBehavior="false" CausesValidation="False" OnClick="populate_Click" />

											</div>
										</div>
									</form>		
								</div>
							</div>
                                </div>
						</section>
                       
					</div>
				</section>
			</main>
		</div>
	</div>

	<!-- Bootstrap core JavaScript
	================================================== -->
	<!-- Placed at the end of the document so the pages load faster -->
	<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
	<script src="dist/js/bootstrap.min.js"></script>
	<
	<script src="js/chart.min.js"></script>
	<script src="js/chart-data.js"></script>
	<script src="js/easypiechart.js"></script>
	<script src="js/easypiechart-data.js"></script>
	<script src="js/bootstrap-datepicker.js"></script>
	<script src="js/custom.js"></script>
	
	<script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js" integrity="sha384-DztdAPBWPRXSA/3eYEEUWrWCy7G5KFbe8fFjk5JAIxUYHKkDx6Qin1DkWx51bBrb" crossorigin="anonymous"></script>
	
	</body>
</html>

