<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentContact.aspx.cs" Inherits="company_dashboard_StudentContact" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="images/favicon.ico">
    <title>Student Contact</title>

    <!-- Bootstrap core CSS -->
    <link href="dist/css/bootstrap.min.css" rel="stylesheet">

    <!-- Icons -->
    <link href="css/font-awesome.css" rel="stylesheet">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous">

    <!-- Custom styles -->
    <link href="css/style.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid" id="wrapper">
        <div class="row">
            <nav class="sidebar col-xs-12 col-sm-4 col-lg-3 col-xl-2">
                <div class="sitelogo">
                    <img src="/img/logo.png" alt="logo"><a href="LandingPage.aspx"></a>
                </div>


                <a href="#menu-toggle" class="btn btn-default" id="menu-toggle"><em class="fa fa-bars"></em></a>
                <ul class="nav nav-pills flex-column sidebar-nav">
                    <li class="nav-item"><a class="nav-link" href="LandingPage.aspx"><em class="fas fa-tachometer-alt"></em> Dashboard </a></li>
                    <li class="nav-item"><a class="nav-link active" href="StudentContact.aspx"><em class="fas fa-user-graduate"></em> Student Contact <span class="sr-only">(current)</span></a></li>
                    <li class="nav-item"><a class="nav-link" href="SchoolContact.aspx"><em class="fas fa-school"></em> School Contact</a></li>
                    <li class="nav-item"><a class="nav-link" href="Listing.aspx"><em class="fas fa-clipboard-list"></em> Job Listings</a></li>
                    <li class="nav-item"><a class="nav-link" href="EditProfile.aspx"><em class="fas fa-user-edit"></em> Edit Profile</a></li>
                </ul>
                <a  runat="server" class="logout-button" onServerClick="logoutClick"><em class="fa fa-power-off"></em> Signout</a>
            </nav>
            <main class="col-xs-12 col-sm-8 col-lg-9 col-xl-10 pt-3 pl-4 ml-auto">
                <header class="page-header row justify-center">
                    <div class="col-md-6 col-lg-8">
                        <h1 class="float-left text-center text-md-left">Student Contact</h1>
                    </div>
                    <div class="dropdown user-dropdown col-md-6 col-lg-4 text-center text-md-right">
                        <a class="btn btn-stripped dropdown-toggle" href="#" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <img src="images/profile-pic.jpg" alt="profile photo" class="circle float-left profile-photo" width="50" height="auto">
                            <div class="username mt-1">
                                <h4 class="mb-1">
                                    <asp:Literal runat="server" ID="loggedInUser" /></h4>
                                <h6 class="text-muted">Employer</h6>
                            </div>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right" style="margin-right: 1.5rem;" aria-labelledby="dropdownMenuLink">
                            <a class="dropdown-item" href="EditProfile.aspx"><em class="fa fa-user-circle mr-1"></em>View Profile</a>

                            <a class="dropdown-item" runat="server" onServerClick="logoutClick" ><em class="fa fa-power-off mr-1"></em> Logout</a></div>
                        </div>
                    
                    <div class="clear"></div>
                </header>
                <section class="row">
                    <div class="col-sm-12">
                        <div class="card mb-4">
                            <div class="card-block">
                                <h3 class="card-title">View Student Candidates</h3>
                                <div class="dropdown card-title-btn-container">
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            
                                            <asp:button runat="server" text="Search" class="btn btn-info margin" type="button"></asp:button>
                                        </div>

                                        <asp:TextBox id="searchbox" runat="server" type="text" class="form-control"></asp:TextBox>
                                    </div>

                                </div>
                                <br>
                                <div class="table-responsive">
                                    
                                        <asp:GridView runat="server" CssClass="table table-striped" OnRowCommand="viewResume" AutoGenerateColumns="False" ID="studentApplicationTable" DataSourceID="StudentApplicationGridView" AllowPaging="True" AllowSorting="True">

                                            <Columns>

                                                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                                                <asp:BoundField DataField="School Name" HeaderText="School Name" SortExpression="School Name"></asp:BoundField>
                                                <asp:BoundField DataField="Applied to" HeaderText="Applied to" SortExpression="Applied to"></asp:BoundField>
                                             
                                                <asp:ButtonField CommandName="viewResume" ControlStyle-CssClass="btn btn-primary" Text="View Resume" ButtonType="Button" ShowHeader="True" HeaderText="View Resume"></asp:ButtonField>                                              
                                                <asp:ButtonField CommandName="viewStudentInformation" ControlStyle-CssClass="btn btn-primary" Text="View Student" ButtonType="Button" ShowHeader="True" HeaderText="Student Information"></asp:ButtonField>
                                                                                   
                                                   </Columns>
                                        </asp:GridView>
                                        <asp:SqlDataSource runat="server" ID="StudentApplicationGridView" ConnectionString='<%$ ConnectionStrings:AWSString %>' SelectCommand="SELECT CONCAT_WS(' ', Student.FirstName, Student.LastName) AS 'Name', School.SchoolName AS 'School Name', Application.jobTitle AS 'Applied to' FROM Student INNER JOIN School ON Student.schoolID = School.SchoolID INNER JOIN Application ON Student.StudentID = Application.studentID" FilterExpression="[Name] LIKE '%{0}%' OR [School Name] LIKE '%{0}%' OR [Applied To] LIKE '%{0}%'">
                                            <FilterParameters>
                                                <asp:ControlParameter Name="Name" ControlID="searchbox" PropertyName="Text" />
                                                <asp:ControlParameter Name="School Name" ControlID="searchbox" PropertyName="Text" />
                                                <asp:ControlParameter Name="Applied To" ControlID="searchbox" PropertyName="Text" />
                                            </FilterParameters>
                                        </asp:SqlDataSource>
                                    
                                    <!--<table class="table table-striped"> 
												<thead>
													<tr>
														<th>Student Name</th>
														<th>School</th>
														<th>Applied to</th>
														<th>Action</th>
													</tr>
												</thead>
												<tbody>
													<tr>
														<td>Mark Hayward</td>
														<td>East Rockingham High School</td>
														<td>Weekly Shadowing</td>
														<td>
															<div class="btn-group">
															<button type="button" class="btn btn-primary">View Resume</button>
															<button type="button" class="btn btn-secondary">View Listing</button>
															</div>
														</td>
													</tr>
													<tr>
														<td>Brittany Monsen</td>
														<td>Spotswood High School</td>
														<td>High School seniors summer program</td>
														<td>
															<div class="btn-group">
															<button type="button" class="btn btn-primary">View Resume</button>
															<button type="button" class="btn btn-secondary">View Listing</button>
															</div>
														</td>
													</tr>
													<tr>
														<td>Derek Mayfield</td>
														<td>Turner Ashby High School</td>
														<td>Freshman Super Day</td>
														<td>
															<div class="btn-group">
															<button type="button" class="btn btn-primary">View Resume</button>
															<button type="button" class="btn btn-secondary">View Listing</button>
															</div>
														</td>
													</tr>
													<tr>
														<td>Sam Salmone</td>
														<td>Broadway High School</td>
														<td>Weekly Shadowing</td>
														<td>
															<div class="btn-group">
															<button type="button" class="btn btn-primary">View Resume</button>
															<button type="button" class="btn btn-secondary">View Listing</button>
															</div>
														</td>
													</tr>
												</tbody>
											</table>-->
                                </div>
                            </div>
                        </div>
                    </div>
                </section>

                <section class="row">

                    <div class="col-md-12 col-lg-8">
                        <div class="card mb-8">

                            <div class="card-block">
										<h3 class="card-title">Notifications</h3>
										<div class="dropdown card-title-btn-container">
											<%--<button class="btn btn-sm btn-subtle" runat="server" type="button"><em class="fa fa-list-ul"></em> View All</button>
											<button class="btn btn-sm btn-subtle dropdown-toggle" runat="server" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><em class="fa fa-cog"></em></button>
											<div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuButton"><a class="dropdown-item" href="#"><em class="fa fa-search mr-1"></em> More info</a>
											    <a class="dropdown-item" href="#"><em class="fa fa-thumb-tack mr-1"></em> Pin Window</a>
											    <a class="dropdown-item" href="#"><em class="fa fa-remove mr-1"></em> Close Window</a></div>--%>
										</div>
										<h6 class="card-subtitle mb-2 text-muted">stay in touch</h6>
										<div class="divider" style="margin-top: 1rem;"></div>
																				<div class="articles-container">
											<div class="article border-bottom">
												<div class="col-xs-12">
													<div class="row">
														<div class="col-2 date">
															<div class="large" ><asp:Literal ID="day1" runat="server"></asp:Literal></div>
                                                            <div class="text-muted" ><asp:Literal ID="month1" runat="server"></asp:Literal></div>
														</div>
														<div class="col-10">
															<h4><asp:Literal ID="notificationTitle1" runat="server"/></h4>
															<p>Check the Top Candidates graph or view the student's information to see if their the right candidate for the job!</p>
														</div>
													</div>
												</div>
												<div class="clear"></div>
											</div><!--End .article-->
											
											<div class="article">
												<div class="col-xs-12">
													<div class="row">
														<div class="col-2 date">
															<div class="large" ><asp:Literal ID="day2" runat="server"></asp:Literal></div>
                                                            <div class="text-muted" ><asp:Literal ID="month2" runat="server"></asp:Literal></div>
														</div>
														<div class="col-10">
															<h4><asp:Literal ID="notificationTitle2" runat="server"/></h4>
															<p>Check the Top Candidates graph or view the student's information to see if their the right candidate for the job!</p>
														</div>
													</div>
												</div>
												<div class="clear"></div>
											</div><!--End .article-->
											
											<div class="article">
												<div class="col-xs-12">
													<div class="row">
														<div class="col-2 date">
															<div class="large" ><asp:Literal ID="day3" runat="server"></asp:Literal></div>
                                                            <div class="text-muted" ><asp:Literal ID="month3" runat="server"></asp:Literal></div>
														</div>
														<div class="col-10">
															<h4><asp:Literal ID="notificationTitle3" runat="server"/></h4>
															<p>Check the Top Candidates graph or view the student's information to see if their the right candidate for the job!</p>
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
													<div runat="server" id="testprogress" class="progress-bar bg-primary" ></div>
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
													<div runat="server" id="testprogress2" class="progress-bar bg-primary"></div>
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
													<div runat="server" id="testprogress3" class="progress-bar bg-primary"></div>
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
                        </form>
                    </div>

                </section>
            </main>
        </div>

    </div>




    <!-- Bootstrap core JavaScript
    ============================================ -->
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
</body>
</html>
