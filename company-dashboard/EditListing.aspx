<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditListing.aspx.cs" Inherits="company_dashboard_EditListing" %>

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
    <form class="form" method="POST" action="#"  runat="server">
        <div class="container-fluid" id="wrapper">
            <div class="row">
                <nav class="sidebar col-xs-12 col-sm-4 col-lg-3 col-xl-2">
                    <div class="sitelogo">
                        <img src="images/logo.jpg" alt="logo"><a href="LandingPage.aspx"></a>
                    </div>

                    <a href="#menu-toggle" class="btn btn-default" id="menu-toggle"><em class="fa fa-bars"></em></a>
                    <ul class="nav nav-pills flex-column sidebar-nav">
                        <li class="nav-item"><a class="nav-link active" href="LandingPage.aspx"><em class="fas fa-tachometer-alt"></em>Dashboard </a></li>
                        <li class="nav-item"><a class="nav-link" href="StudentContact.aspx"><em class="fas fa-user-graduate"></em>Student Contact</a></li>
                        <li class="nav-item"><a class="nav-link" href="SchoolContact.aspx"><em class="fas fa-school"></em>School Contact</a></li>
                        <li class="nav-item"><a class="nav-link" href="Listing.aspx"><em class="fas fa-clipboard-list"></em>View Listings <span class="sr-only">(current)</span></a></li>
                        <li class="nav-item"><a class="nav-link" href="EditProfile.aspx"><em class="fas fa-user-edit"></em>Edit Profile</a></li>
                    </ul>
                    <a href="/Login.aspx" class="logout-button"><em class="fa fa-power-off"></em>Signout</a>
                </nav>
                <main class="col-xs-12 col-sm-8 col-lg-9 col-xl-10 pt-3 pl-4 ml-auto">
                    <header class="page-header row justify-center">
                        <div class="col-md-6 col-lg-8">
                            <%--Maybe pull the listing name from the page that sends to this--%>
                            <h1 class="float-left text-center text-md-left">Edit Listing - <asp:Literal ID="listingToEdit" runat="server"></asp:Literal></h1>
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
                                
                                <a class="dropdown-item" href="/Login.aspx"><em class="fa fa-power-off mr-1"></em>Logout</a>
                            </div>
                        </div>
                        <div class="clear"></div>
                    </header>
                    <section runat="server" class="row">
                        <div runat="server" class="col-sm-12">
                            <section runat="server" class="row">
                                <div runat="server" class="col-12">
                                    <div runat="server" class="card mb-4">
                                        <div runat="server" class="card-block">
                                            <h3 class="card-title">Listing Information</h3>
                                            <%-- action = # makes form stay on same page after submission --%>

                                            <div runat="server" class="form-group row">
                                                <label class="col-md-3 col-form-label" runat="server">Job Title</label>
                                                <div runat="server" class="col-md-9">
                                                    <input ID="txtJobTitle" type="text" name="regular" runat="server" class="form-control">
                                                </div>
                                            </div>
                                            <div runat="server" class="form-group row">
                                                <label class="col-md-3 col-form-label" runat="server">Requirements/Credentials</label>
                                                <div runat="server" class="col-md-9">
                                                    <input ID="txtRequirements" type="text" name="regular" runat="server" class="form-control">
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
                                                    <asp:ListBox ID="listBoxInterests" CssClass="form-control" runat="server" DataSourceID="PostingInterest" DataTextField="name" DataValueField="interestID" SelectionMode="Multiple" OnPreRender="Page_PreRender"></asp:ListBox>
                                                    <asp:SqlDataSource runat="server" ID="PostingInterest" ConnectionString='<%$ ConnectionStrings:ProjectConnectionString %>' SelectCommand="SELECT [interestID], [name] FROM [Interest]"></asp:SqlDataSource>
                                                </div>
                                            </div>
                                            <div runat="server" class="form-group row">
                                                <label class="col-md-3 col-form-label" runat="server">Description</label>
                                                <div runat="server" class="col-md-9">
                                                    <input ID="txtDescription" type="text" name="regular" runat="server" class="form-control"><span class="help-block">Students will see this when viewing listings.</span>
                                                </div>

                                            </div>
                                            <div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server">Posting Date</label>
												<div runat="server" class="col-md-9">
												<input ID="txtpostStart"  runat="server" data-provide="datepicker" class="form-control">

												</div>
                                                
											</div>
                                            <div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server">Posting End Date</label>
												<div runat="server" class="col-md-9">
												<input ID="txtpostEnd"  runat="server" data-provide="datepicker" class="form-control">

												</div>
                                                
											</div>
                                            <div runat="server" class="form-group row">
												<label class="col-md-3 col-form-label" runat="server">Opportunity Start Date</label>
												<div runat="server" class="col-md-9">
												<input ID="txtopportunityStartDate"  data-provide="datepicker" runat="server" class="form-control">

												</div>
                                                
											</div>

                                            <br>

                                            <h3 class="card-title">Contact Information</h3>
                                            <div runat="server" class="form-group row">
                                                <label class="col-md-3 col-form-label" runat="server">Contact Name</label>
                                                <div runat="server" class="col-md-9">
                                                    <input ID="txtCpName" type="text" name="regular" runat="server" class="form-control">
                                                </div>
                                            </div>
                                            <div runat="server" class="form-group row">
                                                <label class="col-md-3 col-form-label" runat="server">Phone</label>
                                                <div runat="server" class="col-md-9">
                                                    <input ID="txtCpPhone" type="text" name="regular" class="form-control" runat="server">
                                                </div>
                                            </div>
                                            <div runat="server" class="form-group row">
                                                <label class="col-md-3 col-form-label" runat="server">E-mail</label>
                                                <div runat="server" class="col-md-9">
                                                    <input ID="txtCpEmail" type="text" name="regular" class="form-control" runat="server">
                                                </div>
                                            </div>
                                            <br>
                                            <div runat="server" class="row">
                                                <div runat="server" class="col-lg-6 mb-sm-4 mb-lg-0">
                                                    <div runat="server" class="custom-control custom-radio">
                                                        <input type="radio" id="customRadio1" name="customRadio" class="custom-control-input" runat="server">
                                                        <label class="custom-control-label custom-control-description" for="customRadio1" runat="server">Post Now</label>
                                                    </div>
                                                    <br />
                                                    <div runat="server" class="custom-control custom-radio">
                                                        <input type="radio" id="customRadio2" name="customRadio" class="custom-control-input" runat="server">
                                                        <label class="custom-control-label custom-control-description" for="customRadio2" runat="server">Save for Later</label>
                                                    </div>
                                                </div>
                                            </div>
                                            <br>
                                            <div runat="server" class="row">
                                                <div runat="server" class="col-lg-6 mb-sm-4 mb-lg-0">

                                                    <asp:Button ID="btnSubmitPosting" class="btn btn-primary text-center" type="button" Text="Edit Listing" runat="server" OnClick="updateBtnClick"></asp:Button>
                                                </div>
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


        <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js" integrity="sha384-DztdAPBWPRXSA/3eYEEUWrWCy7G5KFbe8fFjk5JAIxUYHKkDx6Qin1DkWx51bBrb" crossorigin="anonymous"></script>
    </form>
</body>
</html>
