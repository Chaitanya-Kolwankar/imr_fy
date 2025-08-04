<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<meta name="viewport" content="width=device-width, initial-scale=1">
<title>Online Admission</title>
<link href="<%= ResolveUrl("~/images/mu.png") %>" rel="icon" />
<link href="<%= ResolveUrl("~/images/mu.png") %>" rel="icon" />
<link rel="stylesheet" href="css/bootstrap.min.css" />
<script type="text/javascript">
    function validate() {
        if (document.getElementById("<%=txtUserid.ClientID%>").value == "") {
            alert("Please Enter User ID");
            document.getElementById("<%=txtUserid.ClientID%>").focus();
            return false;
        }
        if (document.getElementById("<%=txtPasswd.ClientID%>").value == "") {
            alert("Please Enter Password");
            document.getElementById("<%=txtPasswd.ClientID%>").focus();
            return false;
        }
        return true;
    } 32
</script>
<style>
    .topMargin {
        margin-top: 10px;
    }

    body {
        background-color: #124a72 !important;
        background-size: cover;
        background-position: center;
        background-repeat: no-repeat;
        background-attachment: fixed;
        margin: 0;
        padding: 0;
    }

    .validation {
        display: flex;
        justify-content: center;
        font-weight: 900;
        color: #ccc;
        border: none;
        padding: 0;
    }
</style>

<form id="frm1" runat="server">


    <div class="container vh-100 d-flex flex-column justify-content-center align-items-center" style="margin-top: 110px">
        <div class="text-center mb-4 institute-header">
            <img src="images/mu.png" height="100" alt="Mu Logo">
            <h4 class="text-dark" style="color: #ccc; font-size: x-large">Institute of Management and Research</h4>
            <h4 class="text-secondary" style="color: #ccc; font-size: x-large">Applicant Portal</h4>
        </div>




        <div style="display: flex; justify-content: center; margin-top: 3pc">
            <div class="col-md-6 col-lg-4">
                <h3 class="text-center mb-4" style="color: #ccc; font-size: 45px; font-family: 'Source Sans 3'; margin-bottom: 24px"><strong>Login</strong></h3>
                <div class="mb-3 form-group">
                    <a title="Click here for Registration!" href="Register.aspx" style="text-decoration: none; color: #ccc; text-decoration: underline; display: flex; justify-content: center;" tabindex="4">Click here for Registration!</a>
                </div>
                <div class="mb-3 form-group">
                    <input id="txtUserid" runat="server" type="text" class="form-control" placeholder="Username" />
                </div>
                <div class="mb-3 form-group">
                    <input id="txtPasswd" runat="server" type="password" class="form-control" placeholder="Password" />
                </div>
                <div class="form-group">
                    <div runat="server" id="errorMessage" visible="false" class="validation"></div>
                </div>
                <div class="text-right" style="margin-bottom: 10px">
                </div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-lg btn-primary btn-block form-group" OnClick="btnLogin_Click" style="background-color: #1a5d8c; color: white; border: none"></asp:Button>

            </div>
        </div>
    </div>

    <%--<div class="panel-default">
        <div class="panel-heading">
           
            <center>
                <div style="margin-top: 15px">
                    <center>
                        <img id="logo" src="images/mu.png" height="100" alt="Logo" />
                        <p style="font-family: 'Times New Roman'; font-size: 15px; text-align: center">
                            <b>
                            </b>
                            <h4 style="font-size: 15pt; font-family: 'Times New Roman'">Affiliated to University Of Mumbai</h4>
                            <h4 style="font-size: 15pt; font-family: 'Verdana'; color: gray">Online Admission</h4>
                        </p>
                    </center>
                </div>
            </center>
        </div>
        <div class="panel-body">
             <br />
            <br />
            <br />
            <br />
            <br />
            <center>
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-2"></div>
                    <div class="col-lg-4 col-md-4 col-sm-8 col-xs-12">
                        <div class="panel panel-info">
                            <div class="panel-heading">LOGIN</div>
                            <div class="panel-body">
                                <div class="row topMargin">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <a title="Click here for Registration!" href="Register.aspx" style="text-decoration: none;" class="thickbox" tabindex="4">Click here for Registration!</a>

                                    </div>
                                </div>
                                <div class="row topMargin">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                            <input id="txtUserid" runat="server" type="text" class="form-control" placeholder="Username" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row topMargin">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                            <input id="txtPasswd" runat="server" type="password" class="form-control" placeholder="Password" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row topMargin">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <asp:Button ID="btnLogin" runat="server" Text="Login" class="form-control btn-primary" OnClick="btnLogin_Click" style="background: linear-gradient(135deg, #FF1493, #1E90FF);color: white;"></asp:Button>
                                    </div>
                                </div>
                                <div runat="server" id="errorMessage" visible="false" class="row topMargin alert alert-danger"></div>

                            </div>
                        </div>
                    </div>
                </div>
            </center>
        </div>
        <div class="panel-footer">
            <center>
                <div class="well">
                    Design and Maintained by <a href="http://www.vssdevelopers.com" style="text-decoration: none">Viva Software Solutions.</a>
                </div>
            </center>
        </div>
    </div>--%>
</form>





