<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditListing.aspx.cs" Inherits="company_dashboard_EditListing" ValidateRequest ="false" %>

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
    <form id="form1" runat="server">
        <div class="container-fluid" id="wrapper">
            <div class="row">
                <nav class="sidebar col-xs-12 col-sm-4 col-lg-3 col-xl-2">
                    <div class="sitelogo">
                        <img src="/img/logo.png" alt="logo"><a href="LandingPage.aspx"></a>
                    </div>

                    <a href="#menu-toggle" class="btn btn-default" id="menu-toggle"><em class="fa fa-bars"></em></a>
                    <ul class="nav nav-pills flex-column sidebar-nav">

                        <li class="nav-item"><a class="nav-link" href="LandingPage.aspx"><em class="fas fa-tachometer-alt"></em>Dashboard </a></li>
                        <li class="nav-item"><a class="nav-link" href="StudentContact.aspx"><em class="fas fa-user-graduate"></em>Student Contact</a></li>
                        <li class="nav-item"><a class="nav-link" href="SchoolContact.aspx"><em class="fas fa-school"></em>School Contact</a></li>
                        <li class="nav-item"><a class="nav-link active" href="Listing.aspx"><em class="fas fa-clipboard-list"></em>Job Listings <span class="sr-only">(current)</span></a></li>
                        <li class="nav-item"><a class="nav-link" href="EditProfile.aspx"><em class="fas fa-user-edit"></em>Edit Profile</a></li>
                    </ul>
                    <a runat="server" class="logout-button" onserverclick="logoutClick"><em class="fa fa-power-off"></em>Signout</a>
                </nav>
                <main class="col-xs-12 col-sm-8 col-lg-9 col-xl-10 pt-3 pl-4 ml-auto">
                    <header class="page-header row justify-center">
                        <div class="col-md-6 col-lg-8">
                            <%--Maybe pull the listing name from the page that sends to this--%>
                            <h1 class="float-left text-center text-md-left">Edit Listing -
                                <asp:Literal ID="listingToEdit" runat="server"></asp:Literal></h1>
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

                                <a class="dropdown-item" runat="server" onserverclick="logoutClick"><em class="fa fa-power-off mr-1"></em>Logout</a>
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
                                                    <input id="txtJobTitle" type="text" name="regular" runat="server" class="form-control" maxlength="50" required>
                                                    

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
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSourceCity" ConnectionString='<%$ ConnectionStrings:ProjectConnectionString %>' SelectCommand="SELECT [LocationID], [CityCounty] FROM (SELECT CityCounty, MIN(LocationID) LocationID FROM cities GROUP BY CityCounty) A ORDER BY LocationID"></asp:SqlDataSource>

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
                                                <label class="col-md-3 col-form-label" runat="server">Requirements/Credentials</label>
                                                <div runat="server" class="col-md-9">
                                                    <input id="txtRequirements" type="text" name="regular" runat="server" class="form-control" maxlength="200" required>
                                                      

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
                                                    <input id="txtDescription" type="text" name="regular" runat="server" class="form-control" maxlength="200" required><span class="help-block">Students will see this when viewing listings.</span>
                                                    
                                                </div>

                                            </div>
                                            <div runat="server" class="form-group row">
                                                <label class="col-md-3 col-form-label" runat="server">Posting Date</label>
                                                <div runat="server" class="col-md-9">
                                                    <input id="txtpostStart" runat="server" data-provide="datepicker" class="form-control">
                                                </div>

                                            </div>
                                            <div runat="server" class="form-group row">
                                                <label class="col-md-3 col-form-label" runat="server">Posting End Date</label>
                                                <div runat="server" class="col-md-9">
                                                    <input id="txtpostEnd" runat="server" data-provide="datepicker" class="form-control">
                                                </div>

                                            </div>
                                            <div runat="server" class="form-group row">
                                                <label class="col-md-3 col-form-label" runat="server">Opportunity Start Date</label>
                                                <div runat="server" class="col-md-9">
                                                    <input id="txtopportunityStartDate" data-provide="datepicker" runat="server" class="form-control">
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
                                                    
                                                    <asp:RegularExpressionValidator ID="PhoneRegularExpressionValidator" runat="server" ControlToValidate="txtCpPhone" ErrorMessage="(Invalid Phone Number)" ForeColor="Red" ValidationExpression="[\d -]+"></asp:RegularExpressionValidator>
                                                    
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
                                            <div class="form-group row">
                                                <label class="col-md-3 col-form-label" runat="server">Pictures related to posting</label>
                                                
                                                <asp:DataList ID="DataList1" OnDeleteCommand="DataList1_DeleteCommand" runat="server" DataSourceID="postingImages" RepeatColumns="3" RepeatDirection="Horizontal" >
                                                    <ItemTemplate>
                                                        
                                                        
                                                        <asp:Image ID="Image1" ImageUrl='<%# writeImage(Eval("imageFile")) %>' CssClass="imageList" runat="server"/>
                                                        <div>
                                                            <asp:HiddenField ID="imageID" Value='<%#Eval("postingImageID")%>' runat="server" />
                                                            <asp:LinkButton ID="imageDeleteBtn"  CommandName="Delete" CommandArgument='<%# writeImage(Eval("imageFile")) + ";" + Eval("postingImageID")%>' class="btn btn-danger text-center" type="button" Text="Delete Image" runat="server" />
                                                        </div>
                                                        
                                                        <br />
                                                    </ItemTemplate>
                                                </asp:DataList>
                                                
                                                
                                                <asp:SqlDataSource runat="server" ID="postingImages" ConnectionString='<%$ ConnectionStrings:AWSString %>' SelectCommand="SELECT [imageFile], [postingImageID] FROM [Posting_Images] WHERE ([postingID] = @postingID)">
                                                    <SelectParameters>
                                                        <asp:SessionParameter SessionField="postID" Name="postingID" Type="Int32" DefaultValue=""></asp:SessionParameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </div>
                                            <div class="container">

                                                <fieldset>
                                                    <div class="form-horizontal">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 col-form-label">Media Upload</label>


                                                            <div class="col-md-10">
                                                                <div class="input-group">
                                                                    <input runat="server" type="hidden" id="filename" name="filename" value="">

                                                                    <asp:FileUpload ID="fileUp" CssClass="form-control form-control-sm" accept="image/bmp,image/gif,image/jpeg,image/png" AllowMultiple="true" runat="server"></asp:FileUpload>


                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </fieldset>

                                            </div>

                                            <%--<div runat="server" class="row">
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
                                            </div>--%>
                                            <script type="text/javascript">
                                                function window.onunload()
                                                {


                                                    alert('closed');


                                                }
                                            </script>
                                            <br>
                                            <div runat="server" class="row">
                                                <div runat="server" class="col-lg-6 mb-sm-4 mb-lg-0">

                                                    <asp:Button ID="btnSubmitPosting" class="btn btn-primary text-center" type="button" Text="Confirm Changes" runat="server" OnClick="updateBtnClick"></asp:Button>
                                                    <asp:Button ID="populate" UseSubmitBehavior="false" CausesValidation="false" CssClass="btn btn-primary text-center" Text="Populate Fields" runat="server" OnClick="populate_Click" />
                                                    <div>
                                                        <br />
                                                        <asp:Button ID="btnDeletePosting" class="btn btn-danger text-center" type="button" Text="Delete Listing" runat="server" OnClick="messageVisible"></asp:Button>
                                                        <br />
                                                        <br />
                                                        <asp:Label ID="lblConfirmationDelete" Text="Are you sure that you would like to delete this posting?" runat="server" Visible="False"></asp:Label>
                                                        &nbsp;<asp:Button ID="btnYes" class="btn btn-danger text-center" type="button" Text="YES" runat="server" OnClick="deleteBtnClick" Visible="False"></asp:Button>
                                                        &nbsp;<asp:Button ID="btnNo" class="btn btn-danger text-center" type="button" Text="NO" runat="server" OnClick="messageHide" Visible="False"></asp:Button>

                                                    </div>
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
