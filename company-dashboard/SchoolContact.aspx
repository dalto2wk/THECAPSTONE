<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolContact.aspx.cs" Inherits="company_dashboard_SchoolContact" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<meta name="description" content="">
	<meta name="author" content="">
	<link rel="icon" href="images/favicon.ico">
	<title>School Contact</title>

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
				<img src="images/logo.jpg" alt="logo"><a href="LandingPage.aspx"></a>
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
						<h1 class="float-left text-center text-md-left">School Contact</h1>
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
					
					<div class="clear"></div>
				</header>
				<section class="row">
					<div class="col-sm-12">
								<div class="card mb-4">
									<div class="card-block">
										<div class="input-group">
											<div class="input-group-prepend">
												<button type="button" class="btn btn-info dropdown-toggle" data-toggle="dropdown">State <span class="caret fa fa-search"></span></button>
												<ul class="dropdown-menu">
													<li><a href="#">AL</a></li>
													<li><a href="#">AK</a></li>
													<li><a href="#">AZ</a></li>
													<li><a href="#">AR</a></li>
													<li><a href="#">CA</a></li>
													<li><a href="#">CO</a></li>
													<li><a href="#">CT</a></li>
													<li><a href="#">DE</a></li>
													<li><a href="#">FL</a></li>
													<li><a href="#">GA</a></li>
													<li><a href="#">HI</a></li>
													<li><a href="#">ID</a></li>
													<li><a href="#">IL</a></li>
													<li><a href="#">IN</a></li>
													<li><a href="#">IA</a></li>
													<li><a href="#">KS</a></li>
													<li><a href="#">KY</a></li>
													<li><a href="#">LA</a></li>
													<li><a href="#">ME</a></li>
													<li><a href="#">MD</a></li>
													<li><a href="#">MA</a></li>
													<li><a href="#">MI</a></li>
													<li><a href="#">MN</a></li>
													<li><a href="#">MO</a></li>
													<li><a href="#">MS</a></li>
													<li><a href="#">MT</a></li>
													<li><a href="#">NE</a></li>
													<li><a href="#">NV</a></li>
													<li><a href="#">NH</a></li>
													<li><a href="#">NJ</a></li>
													<li><a href="#">NM</a></li>
													<li><a href="#">NY</a></li>
													<li><a href="#">NC</a></li>
													<li><a href="#">ND</a></li>
													<li><a href="#">OH</a></li>
													<li><a href="#">OK</a></li>
													<li><a href="#">OR</a></li>
													<li><a href="#">PA</a></li>
													<li><a href="#">RI</a></li>
													<li><a href="#">SC</a></li>
													<li><a href="#">SD</a></li>
													<li><a href="#">TN</a></li>
													<li><a href="#">TX</a></li>
													<li><a href="#">UT</a></li>
													<li><a href="#">VT</a></li>
													<li><a href="#">VA</a></li>
													<li><a href="#">WA</a></li>
													<li><a href="#">WV</a></li>
													<li><a href="#">WI</a></li>
													<li><a href="#">WY</a></li>
												</ul>

											</div>

													<asp:Textbox runat="server" class="form-control" type="text" name="placeholder" id="searchbox"></asp:Textbox>
												</div>

										</div>
										</div>

										</div>

                                      
										<br>
                                        <asp:GridView ID="GridView1" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" DataSourceID="Sqldatasource1">
                                            <Columns>
                                                <asp:BoundField DataField="SchoolName"  HeaderText="School" SortExpression="School"></asp:BoundField>
                                                <asp:BoundField DataField="CityCounty" HeaderText="City" SortExpression="City"></asp:BoundField>
                                                <asp:BoundField DataField="state" HeaderText="State" ReadOnly="True" SortExpression="State"></asp:BoundField>
                                                <asp:BoundField DataField="firstName" HeaderText="Counselor First Name" ReadOnly="True" SortExpression="Counselor First Name"></asp:BoundField>
                                                <asp:BoundField DataField="lastName" HeaderText="Counselor Last Name" ReadOnly="True" SortExpression="Counselor Last Name"></asp:BoundField>
                                                <asp:BoundField DataField="email" HeaderText="Counselor E-mail" ReadOnly="True" SortExpression="Counselor E-mail"></asp:BoundField>
                                                <asp:BoundField DataField="phoneNumber" HeaderText="Counselor Phone Number" ReadOnly="True" SortExpression="Counselor Phone Number"></asp:BoundField>
                                            </Columns>
                                        </asp:GridView>

                                        <asp:SqlDataSource runat="server" ID="Sqldatasource1" ConnectionString='<%$ ConnectionStrings:AWSString %>' SelectCommand="SELECT        School.SchoolName, School.CityCounty, School.state, Counselor.firstName, Counselor.lastName, Counselor.email, Counselor.phoneNumber
FROM            School INNER JOIN
                         Counselor ON School.SchoolID = Counselor.schoolID" FilterExpression="[SchoolName] LIKE '%{0}%' OR [CityCounty] LIKE '%{0}%' OR [state] LIKE '%{0}%' OR [firstName] LIKE '%{0}%' OR [lastName] LIKE '%{0}%' OR [email] LIKE '%{0}%'">
                                        <FilterParameters>
                                                <asp:ControlParameter Name="SchoolName" ControlID="searchbox" PropertyName="Text" />
                                                <asp:ControlParameter Name="CityCounty" ControlID="searchbox" PropertyName="Text" />
                                                <asp:ControlParameter Name="state" ControlID="searchbox" PropertyName="Text" />
                                                <asp:ControlParameter Name="firstName" ControlID="searchbox" PropertyName="Text" />
                                                <asp:ControlParameter Name="lastName" ControlID="searchbox" PropertyName="Text" />
                                                <asp:ControlParameter Name="email" ControlID="searchbox" PropertyName="Text" />
                                            </FilterParameters>
                                        </asp:SqlDataSource>

                                  <div class ="table-responsive">
                    <div class='tableauPlaceholder' id='viz1554157927266' style='position: relative'><noscript><a href='#'><img alt=' ' 


                                           src='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Cu&#47;Cued-In_15541566149620&#47;Dashboard1&#47;1_rss.png' 
                                           style='border: none' /></a></noscript><object class='tableauViz'  style='display:none;'><param name='host_url' 
                                           value='https%3A%2F%2Fpublic.tableau.com%2F' /> <param name='embed_code_version' value='3' /> <param name='site_root' 
                                           value='' /><param name='name' value='Cued-In_15541566149620&#47;Dashboard1' /><param name='tabs' value='no' /><param 
                                           name='toolbar' value='yes' /><param name='static_image' value='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Cu&#47;Cued-In_15541566149620&#47;Dashboard1&#47;1.png' /> 
                                           <param name='animate_transition' value='yes' /><param name='display_static_image' value='yes' /><param name='display_spinner'
                                           value='yes' /><param name='display_overlay' value='yes' /><param name='display_count' value='yes' /></object>
                                       </div> 
                                      </div>                
                                           <script type='text/javascript'> var divElement = document.getElementById('viz1554157927266'); var vizElement = divElement.getElementsByTagName('object')[0];
                                               vizElement.style.width = '1000px'; vizElement.style.height = '200px'; var scriptElement = document.createElement('script');
                                               scriptElement.src = 'https://public.tableau.com/javascripts/api/viz_v1.js'; vizElement.parentNode.insertBefore(scriptElement, vizElement);                

                                           </script>

										
										<div class="table-responsive">

											<table class="table table-striped">
												<thead>
													<tr>
														<th>School Name</th>
														<th>Location</th>
														<th>Status</th>
														<th>Action</th>
													</tr>
												</thead>
												<tbody>
													<tr>

														<td>East Rockingham High School</td>
														<td>East Rockingham, VA</td>
														<td>approved</td>
														<td>
															<div class="btn-group">
															<button type="button" class="btn btn-primary">Apply</button>
															<button type="button" class="btn btn-secondary">View Info</button>
															</div>
														</td>
													</tr>
													<tr>

														<td>Spotswood High School</td>
														<td>Spotswood, VA</td>
														<td>pending approval</td>
														<td>
															<div class="btn-group">
															<button type="button" class="btn btn-primary">Apply</button>
															<button type="button" class="btn btn-secondary">View Info</button>
															</div>
														</td>
													</tr>
													<tr>

														<td>Turner Ashby High School</td>
														<td>Bridgewater, VA</td>
														<td>approved</td>
														<td>
															<div class="btn-group">
															<button type="button" class="btn btn-primary">apply</button>
															<button type="button" class="btn btn-secondary">View info</button>
															</div>
														</td>
													</tr>
													<tr>

														<td>Broadway High School</td>
														<td>Broadway, VA</td>
														<td>applied</td>
														<td>
															<div class="btn-group">
															<button type="button" class="btn btn-primary">apply</button>
															<button type="button" class="btn btn-secondary">View info</button>
															</div>
														</td>
													</tr>
												</tbody>
											</table>
										</div>-->
									</div>
								</div>
							</div>
						</section>




			</main>


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


	</script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js" integrity="sha384-DztdAPBWPRXSA/3eYEEUWrWCy7G5KFbe8fFjk5JAIxUYHKkDx6Qin1DkWx51bBrb" crossorigin="anonymous"></script>

        </form>
	</body>
</html> 