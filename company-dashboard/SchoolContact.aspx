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
					<li class="nav-item"><a class="nav-link" href="LandingPage.aspx"><em class="fas fa-tachometer-alt"></em>  Dashboard </a></li>
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
											<div class="input-group-prepend col-sm-12">
												<asp:button runat="server" type="button" Text="Search" class="btn btn-info" OnClick="Unnamed_Click"></asp:button>
												

											

													<asp:Textbox runat="server" class="form-control" type="text" name="placeholder" id="searchbox" placeholder="filter data by School Name or Location"></asp:Textbox>
												</div>
                                            </div>

										</div>
										</div>
                                       

										
                         <h3> Approval Requests</h3>
                                      <div class="table-responsive col-sm-12"></div>
										<br>
                                        <asp:GridView ID="GridView1" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" DataSourceID="Sqldatasource1" OnRowCommand="viewInfo">
                                            <Columns>
                                                <asp:BoundField DataField="SchoolID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="School ID" SortExpression="School"></asp:BoundField>
                                                <asp:BoundField DataField="SchoolName"  HeaderText="School" SortExpression="SchoolName"></asp:BoundField>
                                                <asp:BoundField DataField="CityCounty" HeaderText="City" SortExpression="CityCounty"></asp:BoundField>
                                                <asp:BoundField DataField="state" HeaderText="State" ReadOnly="True" SortExpression="state"></asp:BoundField>
                                                <asp:BoundField DataField="Approval_Status" HeaderText="Approval Status" ReadOnly="True" SortExpression="Approval_Status"></asp:BoundField>
                                                <asp:ButtonField CommandName="viewInfo" ControlStyle-CssClass="btn btn-primary" Text="View Info" ButtonType="Button" ShowHeader="True" HeaderText="Info"></asp:ButtonField>                                              
                                            </Columns>
                                        </asp:GridView>

                        <asp:SqlDataSource runat="server" ID="Sqldatasource1" ConnectionString='<%$ ConnectionStrings:AWSString %>' SelectCommand="SELECT  School.SchoolID,       School.SchoolName, School.CityCounty, School.state, School.Approval_Status
FROM            School where School.Approval_Status != 'Approved'" FilterExpression="[SchoolName] LIKE '%{0}%' OR [CityCounty] LIKE '%{0}%' OR [state] LIKE '%{0}%'">
                                        <FilterParameters>
                                                <asp:ControlParameter Name="SchoolName" ControlID="searchbox" PropertyName="Text" />
                                                <asp:ControlParameter Name="CityCounty" ControlID="searchbox" PropertyName="Text" />
                                                <asp:ControlParameter Name="state" ControlID="searchbox" PropertyName="Text" />
                                               <%-- <asp:ControlParameter Name="firstName" ControlID="searchbox" PropertyName="Text" />
                                                <asp:ControlParameter Name="lastName" ControlID="searchbox" PropertyName="Text" />
                                                <asp:ControlParameter Name="email" ControlID="searchbox" PropertyName="Text" />--%>
                                            </FilterParameters>
                                        </asp:SqlDataSource>
                        </div>

                       <h3> Approved Schools</h3>
                        <div class="col-sm-12">
                        	<div class="card mb-4">
									<div class="card-block">
										<div class="input-group">
											<div class="input-group-prepend col-sm-12">
												<asp:button runat="server" type="button" Text="Search" class="btn btn-info" OnClick="Unnamed_Click"></asp:button>
												

											

													<asp:Textbox runat="server" class="form-control" type="text" name="placeholder" id="Searchbox1" placeholder="filter data by School Name or Location"></asp:Textbox>
												</div>
                                            </div>
                                        </div>
										</div>
										
                         <div class="table-responsive col-sm-12"></div>
										<br>
                                        <asp:GridView ID="GridView2" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" DataSourceID="Sqldatasource2" OnRowCommand="viewInfo">
                                            <Columns>
                                                <asp:BoundField DataField="SchoolID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="School ID" SortExpression="School"></asp:BoundField>
                                                <asp:BoundField DataField="SchoolName"  HeaderText="School" SortExpression="School"></asp:BoundField>
                                                <asp:BoundField DataField="CityCounty" HeaderText="City" SortExpression="City"></asp:BoundField>
                                                <asp:BoundField DataField="state" HeaderText="State" ReadOnly="True" SortExpression="State"></asp:BoundField>
                                                <asp:BoundField DataField="Approval_Status" HeaderText="Approval Status" ReadOnly="True" SortExpression="Approval Status"></asp:BoundField>
                                                <asp:ButtonField CommandName="viewInfo" ControlStyle-CssClass="btn btn-primary" Text="View Info" ButtonType="Button" ShowHeader="True" HeaderText="Info"></asp:ButtonField>                                              
                                            </Columns>
                                        </asp:GridView>

                        
                                        

                             <asp:SqlDataSource runat="server" ID="Sqldatasource2" ConnectionString='<%$ ConnectionStrings:AWSString %>' SelectCommand="SELECT  School.SchoolID,       School.SchoolName, School.CityCounty, School.state, School.Approval_Status
FROM            School where School.Approval_Status = 'Approved'" FilterExpression="[SchoolName] LIKE '%{0}%' OR [CityCounty] LIKE '%{0}%' OR [state] LIKE '%{0}%'">
                                        <FilterParameters>
                                                <asp:ControlParameter Name="SchoolName" ControlID="searchbox1" PropertyName="Text" />
                                                <asp:ControlParameter Name="CityCounty" ControlID="searchbox1" PropertyName="Text" />
                                                <asp:ControlParameter Name="state" ControlID="searchbox1" PropertyName="Text" />
                                            </FilterParameters>
                                        </asp:SqlDataSource>

                     <br />
                        </div>

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
                                               vizElement.style.width = '1200px'; vizElement.style.height = '900px'; var scriptElement = document.createElement('script');
                                               scriptElement.src = 'https://public.tableau.com/javascripts/api/viz_v1.js'; vizElement.parentNode.insertBefore(scriptElement, vizElement);                

                                           </script>

									</div>	
										
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