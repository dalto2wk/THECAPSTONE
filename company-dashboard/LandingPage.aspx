<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LandingPage.aspx.cs" Inherits="company_dashboard_LandingPage" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<meta name="description" content="">
	<meta name="author" content="">
	<link rel="icon" href="images/favicon.ico">
	<title>Company Dashboard</title>

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
				<img src="images/logo.jpg" alt="logo"><a href="LandingPage.aspx"></a>
			</div>
													
				<a href="#menu-toggle" class="btn btn-default" id="menu-toggle"><em class="fa fa-bars"></em></a>
				<ul class="nav nav-pills flex-column sidebar-nav">
					<li class="nav-item"><a class="nav-link active" href="LandingPage.aspx"><em class="fas fa-tachometer-alt"></em> Dashboard <span class="sr-only">(current)</span></a></li>
					<li class="nav-item"><a class="nav-link" href="StudentContact.aspx"><em class="fas fa-user-graduate"></em> Student Contact</a></li>
					<li class="nav-item"><a class="nav-link" href="SchoolContact.aspx"><em class="fas fa-school"></em> School Contact</a></li>
					<li class="nav-item"><a class="nav-link" href="Listing.aspx"><em class="fas fa-clipboard-list"></em> View Listings</a></li>
					<li class="nav-item"><a class="nav-link" href="EditProfile.aspx"><em class="fas fa-user-edit"></em> Edit Profile</a></li>
				</ul>


         
                <p>
                <div class="social">
              
                     <button class="btn btn-info btn-circle margin" type="button">
                        <span class="fab fa-facebook"></span>
                    </button>
        

                    <button class="btn btn-info btn-circle margin" type="button">
                        <span class="fab fa-twitter"></span>
                    </button>

                     <button class="btn btn-info btn-circle margin" type="button">
                        <span class="fab fa-linkedin"></span>
                    </button>
                </div>
                </p>


                <!-- href="https://twitter.com/cued__in" href="https://www.facebook.com/cuedin/" --->
                






				<a  runat="server" class="logout-button" onServerClick="logoutClick"><em class="fa fa-power-off"></em> Signout</a>

			</nav>
			<main class="col-xs-12 col-sm-8 col-lg-9 col-xl-10 pt-3 pl-4 ml-auto">
				<header class="page-header row justify-center">
					<div class="col-md-6 col-lg-8" >
						<h1 class="float-left text-center text-md-left">Dashboard</h1>
					</div>
					<div class="dropdown user-dropdown col-md-6 col-lg-4 text-center text-md-right"><a class="btn btn-stripped dropdown-toggle" href="#" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
						<img src="images/profile-pic.jpg" alt="profile photo" class="circle float-left profile-photo" width="50" height="auto">
						<div class="username mt-1">
							<h4 class="mb-1"><asp:Literal runat="server" id="loggedInUser" /></h4>
							<h6 class="text-muted">Employer</h6>
						</div>
						</a>
						<div class="dropdown-menu dropdown-menu-right" style="margin-right: 1.5rem;" aria-labelledby="dropdownMenuLink"><a class="dropdown-item" href="EditProfile.aspx"><em class="fa fa-user-circle mr-1"></em> View Profile</a>

						     <a class="dropdown-item" runat="server" onServerClick="logoutClick" ><em class="fa fa-power-off mr-1"></em> Logout</a></div>
					</div>
					<div class="clear"></div>
				</header>
                
				<section class="row">
                  
					<div class="col-sm-12">
						<section class="row">
							<div class="col-md-12 col-lg-8">
								<div class="jumbotron">
									<h1 class="mb-4">Hello, <asp:literal runat="server" ID="helloEmpName"></asp:literal>!</h1>
									<p class="lead">Welcome to the Cued In family! This is your Dashboard. Here you will find basic information on students available as well as an overview of your current activity as a verified employer.</p>
									<p>Students have a similar dashboard and will be able to see postings as soon as you upload them.</p>
									<p class="lead"><a class="btn btn-primary btn-lg mt-2" href="JobPostForm.aspx" role="button">Create Listing</a></p>
								</div>
                            
								<div class="card mb-4">
									<div class="card-block">
										<h3 class="card-title">Current Desirability</h3>
										<div class="dropdown card-title-btn-container">
											<button class="btn btn-sm btn-subtle dropdown-toggle" type="button" runat="server" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><em class="fa fa-cog"></em></button>
											<div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuButton"><a class="dropdown-item" href="#"><em class="fa fa-search mr-1"></em> More info</a>
												<a class="dropdown-item" href="#"><em class="fa fa-thumb-tack mr-1"></em> Pin Window</a>
												<a class="dropdown-item" href="#"><em class="fa fa-remove mr-1"></em> Close Window</a></div>
										</div>
										<h6 class="card-subtitle mb-2 text-muted">Students are interested in these areas</h6>
										<div class="canvas-wrapper">
											<canvas class="chart" id="doughnut-chart" height="300" width="600"></canvas>
										</div>
									</div>
								</div>
								<div class="card mb-4">
									<div class="card-block">
										<h3 class="card-title">Recent Applications</h3>
										<div class="dropdown card-title-btn-container">
											<button class="btn btn-sm btn-subtle" type="button" runat="server"><em class="fa fa-list-ul"></em> View All</button>
											<button class="btn btn-sm btn-subtle dropdown-toggle" type="button" runat="server" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><em class="fa fa-cog"></em></button>
											<div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuButton"><a class="dropdown-item" href="#"><em class="fa fa-search mr-1"></em> More info</a>
											    <a class="dropdown-item" href="#"><em class="fa fa-thumb-tack mr-1"></em> Pin Window</a>
											    <a class="dropdown-item" href="#"><em class="fa fa-remove mr-1"></em> Close Window</a></div>
										</div>
										<div class="table-responsive">
                                            <%-- Should eventually connect to DB may neeed to add more runat="server" tags --%>
                                            <asp:GridView ID="recentApplicationsGV"  runat="server" AutoGenerateColumns="False" DataKeyNames="applicationID" CssClass="table table-striped" UseAccessibleHeader="true" DataSourceID="SqlDataSource1">
                                                <Columns>
                                                    <asp:BoundField DataField="applicationID" HeaderText="Application ID" InsertVisible="False" ReadOnly="True" SortExpression="applicationID" />
                                                    <asp:BoundField DataField="jobTitle" HeaderText="Job Title" SortExpression="jobTitle" />
                                                    <asp:BoundField DataField="companyName" HeaderText="Company Name" SortExpression="companyName" />
                                                    <asp:BoundField DataField="postingID" HeaderText="Posting ID" SortExpression="postingID" />
                                                </Columns>


                                            </asp:GridView>
										    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AWSString %>" SelectCommand="SELECT [applicationID], [jobTitle], [companyName], [postingID] FROM [Application]"></asp:SqlDataSource>
										</div>
									</div>
								</div>
								<div class="card mb-8">
									<div class="card-block">
										<h3 class="card-title">Notifications</h3>
										<div class="dropdown card-title-btn-container">
											<button class="btn btn-sm btn-subtle" runat="server" type="button"><em class="fa fa-list-ul"></em> View All</button>
											<button class="btn btn-sm btn-subtle dropdown-toggle" runat="server" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><em class="fa fa-cog"></em></button>
											<div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuButton"><a class="dropdown-item" href="#"><em class="fa fa-search mr-1"></em> More info</a>
											    <a class="dropdown-item" href="#"><em class="fa fa-thumb-tack mr-1"></em> Pin Window</a>
											    <a class="dropdown-item" href="#"><em class="fa fa-remove mr-1"></em> Close Window</a></div>
										</div>
										<h6 class="card-subtitle mb-2 text-muted">stay in touch</h6>
										<div class="divider" style="margin-top: 1rem;"></div>
										<div class="articles-container">
											<div class="article border-bottom">
												<div class="col-xs-12">
													<div class="row">
														<div class="col-2 date">
															<div class="large">30</div>
															<div class="text-muted">Jun</div>
														</div>
														<div class="col-10">
															<h4><a href="#">Lorem ipsum dolor sit amet</a></h4>
															<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer at sodales nisl. Donec malesuada orci ornare risus finibus feugiat.</p>
														</div>
													</div>
												</div>
												<div class="clear"></div>
											</div><!--End .article-->
											
											<div class="article">
												<div class="col-xs-12">
													<div class="row">
														<div class="col-2 date">
															<div class="large">30</div>
															<div class="text-muted">Jun</div>
														</div>
														<div class="col-10">
															<h4><a href="#">Lorem ipsum dolor sit amet</a></h4>
															<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer at sodales nisl. Donec malesuada orci ornare risus finibus feugiat.</p>
														</div>
													</div>
												</div>
												<div class="clear"></div>
											</div><!--End .article-->
											
											<div class="article">
												<div class="col-xs-12">
													<div class="row">
														<div class="col-2 date">
															<div class="large">31</div>
															<div class="text-muted">Jun</div>
														</div>
														<div class="col-10">
															<h4><a href="#">Lorem ipsum dolor sit amet</a></h4>
															<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer at sodales nisl. Donec malesuada orci ornare risus finibus feugiat.</p>
														</div>
													</div>
												</div>
												<div class="clear"></div>
											</div><!--End .article-->
                                       
										</div>
									</div>
								</div>
							</div>
							<div class="col-md-12 col-lg-4">
								<div class="card mb-4">
									<div class="card-block">
										<h3 class="card-title">Top Candidates</h3>
                                        <!-- SubTitle displaying the Posting Title-->
										<h6 class="card-subtitle mb-2 text-muted"><asp:Literal ID="topCandidateSubTitle" runat="server"/></h6>                                     
										<div class="user-progress justify-center">                                         
											<div class="col-sm-3 col-md-2" style="padding: 0;">
												<img src="images/profile-pic2.jpg" alt="profile photo" class="circle profile-photo" style="width: 100%; max-width: 100px;">
											</div>                                          
											<div class="col-sm-9 col-md-10">
                                                <!-- Top Candidate 1 display info-->
												<h6 class="pt-1"><asp:Literal runat="server" id="ApplicantOne" /></h6>
												<div class="progress progress-custom">
                                                    <!-- Information for Top Candidate-->
													<div runat="server" id="testprogress" class="progress-bar" role="progressbar" ></div>
												</div>
											</div>
										</div>                   
										<div class="user-progress justify-center">
											<div class="col-sm-3 col-md-2" style="padding: 0;">
												<img src="images/profile-pic2.jpg" alt="profile photo" class="circle profile-photo" style="width: 100%; max-width: 100px;">
											</div>
											<div class="col-sm-9 col-md-10">
                                                 <!-- Top Candidate 2 display info-->
												<h6 class="pt-1"><asp:Literal runat="server" id="ApplicantTwo" /></h6>
												<div class="progress progress-custom">
                                                    <!-- Information for Second-Most Top Candidate-->
													<div runat="server" id="testprogress2" class="progress-bar" role="progressbar"></div>
												</div>
											</div>
										</div>
										<div class="user-progress justify-center">
											<div class="col-sm-3 col-md-2" style="padding: 0;">
												<img src="images/profile-pic2.jpg" alt="profile photo" class="circle profile-photo" style="width: 100%; max-width: 100px;">
											</div>
											<div class="col-sm-9 col-md-10">
                                                <!-- Top Candidate 3 display info-->
												<h6 class="pt-1"><asp:Literal runat="server" id="ApplicantThree" /></h6>
												<div class="progress progress-custom">
                                                    <!-- Information for Third-Most Top Candidate-->
													<div runat="server" id="testprogress3" class="progress-bar" role="progressbar"></div>
												</div>                                                                                               
											</div>                                            
										</div>
                                         <!-- DropDown List to choose Posting for Top Candidates-->
                                        <br />
                                        <div  class="col-sm-9 col-md-10">
                                            <asp:DropDownList ID="ddlTopCandidate" runat="server" Width="120%" autoPostBack="true" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="postingTitle" DataValueField="postingID" OnPreRender="topCandidate"> 
                                            </asp:DropDownList>
                                            <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:AWSString %>' SelectCommand="SELECT [postingID], [postingTitle] FROM [Posting]"></asp:SqlDataSource>
                                        </div>
										<div class="divider"></div>
										<div id="calendar"></div>
										<div class="divider"></div>
								</div>
                                    </div>
                                
								<div class="card mb-4">
									<div class="card-block">
										<h3 class="card-title">Todo List</h3>
										<div class="dropdown card-title-btn-container">
											<button class="btn btn-sm btn-subtle dropdown-toggle" runat="server" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><em class="fa fa-cog"></em></button>
											<div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuButton"><a class="dropdown-item" href="#"><em class="fa fa-search mr-1"></em> More info</a>
												<a class="dropdown-item" href="#"><em class="fa fa-thumb-tack mr-1"></em> Pin Window</a>
												<a class="dropdown-item" href="#"><em class="fa fa-remove mr-1"></em> Close Window</a></div>
										</div>
										<h6 class="card-subtitle mb-2 text-muted">checklist</h6>
										<ul class="todo-list mt-2 mb-2">
											
											<li class="todo-list-item">
												<div class="checkbox mt-1 mb-2">
													<div class="custom-control custom-checkbox">
														<input type="checkbox" runat="server" class="custom-control-input" id="customCheck1">
														<label class="custom-control-label custom-control-description" runat="server" for="customCheck1">call with conselor</label>
													<div class="float-right action-buttons"><a href="#" class="trash"><em class="fa fa-trash"></em></a></div>
												    </div>
                                                </div>
											</li>
											<li class="todo-list-item">
												<div class="checkbox mt-1 mb-2">
													<div class="custom-control custom-checkbox">
														<input type="checkbox" runat="server" class="custom-control-input" id="customCheck2">
														<label class="custom-control-label custom-control-description" runat="server" for="customCheck2">update posting</label>
													<div class="float-right action-buttons"><a href="#" class="trash"><em class="fa fa-trash"></em></a></div>
												    </div>
                                                </div>
											</li>
											<li class="todo-list-item">
												<div class="checkbox mt-1 mb-2">
													<div class="custom-control custom-checkbox">
														<input type="checkbox" runat="server" class="custom-control-input" id="customCheck3">
														<label class="custom-control-label custom-control-description" runat="server" for="customCheck3">Reply to Jane</label>
													<div class="float-right action-buttons"><a href="#" class="trash"><em class="fa fa-trash"></em></a></div>
												    </div>
                                                </div>
											</li>
											<li class="todo-list-item" runat="server">
												<div class="checkbox mt-1 mb-2">
													<div class="custom-control custom-checkbox">
														<input type="checkbox" runat="server" class="custom-control-input" id="customCheck4">
														<label class="custom-control-label custom-control-description" runat="server" for="customCheck4">new posting</label>
													<div class="float-right action-buttons"><a href="#" class="trash"><em class="fa fa-trash"></em></a></div>
												    </div>
                                                </div>
											</li>
											<li class="todo-list-item" runat="server">
												<div class="checkbox mt-1 mb-2">
													<div class="custom-control custom-checkbox">
														<input type="checkbox" runat="server" class="custom-control-input" id="customCheck5">
														<label class="custom-control-label custom-control-description" runat="server" for="customCheck5">Get feedback</label>
													<div class="float-right action-buttons"><a href="#" class="trash"><em class="fa fa-trash"></em></a></div>
												    </div>
                                                </div>
											</li>
										</ul>
										<div class="card-footer todo-list-footer">
											<div class="input-group">
												<input id="btninput" runat="server" type="text" class="form-control input-md" placeholder="Add new task" /><span class="input-group-btn">
													<button class="btn btn-primary btn-md" runat="server" id="btntodo">Add</button>
											</span></div>
										</div>
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
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="dist/js/bootstrap.min.js"></script>
    
    <script src="js/chart.min.js"></script>
    <script src="js/chart-data.js"></script>
    <script src="js/easypiechart.js"></script>
    <script src="js/easypiechart-data.js"></script>
    <script src="js/bootstrap-datepicker.js"></script>
    <script src="js/custom.js"></script>
    <script>
	var chart3 = document.getElementById("doughnut-chart").getContext("2d");
	window.myDoughnut = new Chart(chart3).Doughnut(doughnutData, {
	responsive: true,
	segmentShowStroke: false
	});
	</script>
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js" integrity="sha384-DztdAPBWPRXSA/3eYEEUWrWCy7G5KFbe8fFjk5JAIxUYHKkDx6Qin1DkWx51bBrb" crossorigin="anonymous"></script>
    </form>
	</body>
</html>

