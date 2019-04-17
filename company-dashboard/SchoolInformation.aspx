<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolInformation.aspx.cs" Inherits="company_dashboard_SchoolInformation" %>



<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<meta name="description" content="">
	<meta name="author" content="">
	<link rel="icon" href="images/favicon.ico">
	<title>School Information</title>

    <!-- Bootstrap core CSS -->
    <link href="dist/css/bootstrap.min.css" rel="stylesheet">
    
    <!-- Icons -->
    <link href="css/font-awesome.css" rel="stylesheet">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous">
    
    <!-- Custom styles -->
    <link href="css/style.css" rel="stylesheet">
    
</head>
<body>
    <form class="form" action="#" runat="server">
	<div class="container-fluid" id="wrapper">
		<div class="row">
			<nav class="sidebar col-xs-12 col-sm-4 col-lg-3 col-xl-2">
			<div class="sitelogo">
				<img src="img/logo.png" alt="logo"><a href="LandingPage.aspx"></a>
			</div>
													
				<a href="#menu-toggle" class="btn btn-default" id="menu-toggle"><em class="fa fa-bars"></em></a>
				<ul class="nav nav-pills flex-column sidebar-nav">
					<li class="nav-item"><a class="nav-link" href="LandingPage.aspx"><em class="fas fa-tachometer-alt"></em> Dashboard </a></li>
					<li class="nav-item"><a class="nav-link" href="StudentContact.aspx"><em class="fas fa-user-graduate"></em> Student Contact</a></li>
					<li class="nav-item"><a class="nav-link active" href="SchoolContact.aspx"><em class="fas fa-school"></em> School Contact <span class="sr-only">(current)</span></a></li>
					<li class="nav-item"><a class="nav-link" href="Listing.aspx"><em class="fas fa-clipboard-list"></em> Job Listings</a></li>
					<li class="nav-item"><a class="nav-link" href="EditProfile.aspx"><em class="fas fa-user-edit"></em> Edit Profile</a></li>
				</ul>
				<a  runat="server" class="logout-button" onServerClick="logoutClick"><em class="fa fa-power-off"></em> Signout</a>
			</nav>
			<main class="col-xs-12 col-sm-8 col-lg-9 col-xl-10 pt-3 pl-4 ml-auto">
				<header class="page-header row justify-center">
					<div class="col-md-6 col-lg-8" >
						<h1 class="float-left text-center text-md-left">School Information</h1>
					</div>
					<div class="dropdown user-dropdown col-md-6 col-lg-4 text-center text-md-right"><a class="btn btn-stripped dropdown-toggle" href="#" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
						<img src="images/profile-pic.jpg" alt="profile photo" class="circle float-left profile-photo" width="50" height="auto">
						<div class="username mt-1">
							<h4 class="mb-1"><asp:Literal runat="server" id="loggedInUser" /></h4>
							<h6 class="text-muted">Admin</h6>
						</div>
						</a>
						<div class="dropdown-menu dropdown-menu-right" style="margin-right: 1.5rem;" aria-labelledby="dropdownMenuLink"><a class="dropdown-item" href="#"><em class="fa fa-user-circle mr-1"></em> View Profile</a>
						     
						     <a class="dropdown-item" runat="server" onServerClick="logoutClick" ><em class="fa fa-power-off mr-1"></em> Logout</a></div>
					</div>
					<div class="clear"></div>
				</header>
                <label class="col-md-3 col-form-label" runat="server">School Name</label>
                <label class="col-md-3 col-form-label" runat="server" id="lblSchoolName"></label>
                <br />
                <label class="col-md-3 col-form-label" runat="server">State</label>
                <label class="col-md-3 col-form-label" runat="server" id="lblState"></label>
                <br />
                <label class="col-md-3 col-form-label" runat="server">City</label>
                <label class="col-md-3 col-form-label" runat="server" id="lblCity"></label>
                <br />
                <label class="col-md-3 col-form-label" runat="server">Street Address</label>
                <label class="col-md-3 col-form-label" runat="server" id="lblStreet"></label>
                <br />
                <label class="col-md-3 col-form-label" runat="server">Counselor First Name</label>
                <label class="col-md-3 col-form-label" runat="server" id="lblCounselorFN"></label>
                <br />
                <label class="col-md-3 col-form-label" runat="server">Counselor Last Name</label>
                <label class="col-md-3 col-form-label" runat="server" id="lblCounselorLN"></label>
                <br />
                <label class="col-md-3 col-form-label" runat="server">Counselor E-mail</label>
                <label class="col-md-3 col-form-label" runat="server" id="lblCounselorEM"></label>
                <br />
                <label class="col-md-3 col-form-label" runat="server">Counselor Phone Number</label>
                <label class="col-md-3 col-form-label" runat="server" id="lblCounselorPN"></label>
                <br />
                <label class="col-md-3 col-form-label" runat="server">Number of Electives Offered</label>
                <label class="col-md-3 col-form-label" runat="server" id="electives"></label>

               
                </main>
            </div>
            <div class="table-responsive">
            </div>
        </div>

        
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="dist/js/bootstrap.min.js"></script>
    
    <script src="js/chart.min.js"></script>
    <script src="js/chart-data.js"></script>
    <script src="js/easypiechart.js"></script>
    <script src="js/easypiechart-data.js"></script>
    <script src="js/bootstrap-datepicker.js"></script>
    <script src="js/custom.js"></script>
    
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js" integrity="sha384-DztdAPBWPRXSA/3eYEEUWrWCy7G5KFbe8fFjk5JAIxUYHKkDx6Qin1DkWx51bBrb" crossorigin="anonymous"></script>
    </form>
</body>
    </html>
