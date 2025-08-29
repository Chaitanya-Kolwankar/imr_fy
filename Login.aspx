<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<meta name="viewport" content="width=device-width, initial-scale=1">
<title>RJCMS Admission</title>
<link href="<%= ResolveUrl("~/images/mu.png") %>" rel="icon" />
<link href="<%= ResolveUrl("~/images/mu.png") %>" rel="icon" />
<%--<link rel="stylesheet" href="css/bootstrap.min.css" />--%>
<link href="css/bootstrap5.min.css" rel="stylesheet" />
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
    }
</script>
<style>
    .topMargin {
        margin-top: 10px;
    }

    body {
        background: url('images/backimg5.jpg');
        background-size: cover;
/*        background-position: center;*/
        background-repeat: no-repeat;
        /*background-attachment: fixed;*/
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

    .row>* {
        padding-right:0;
    }
</style>

<form id="frm1" runat="server">


    <div class="container">
        <section class="section register min-vh-100 d-flex flex-column justify-content-center py-1">
        <div class="row justify-content-center">
            <div class="col-lg-4 col-md-6 d-flex flex-column justify-content-center" style="background-color: rgba(0, 0, 0, .5); color: white; border-radius: 10px">

                <div style="text-align:center;padding:22px 15px 35px 15px;">

                    <div class="mb-3">
                        <img src="images/RGCMS.png" alt="College Logo" style="height: 100px; margin-bottom: 10px;">
                    </div>

                    <span style="color: #fff; font-weight: bold; margin-bottom: 10px; margin-top: 10px">Rajeev Gandhi College of Management Studies</span>
                    <h5 class="fs-4" style="color: #fff; margin-bottom: 20px;margin-top:1rem;">Applicant Login</h5>

                    <div class="mb-3 form-group">
                        <a title="Click here for Registration!" href="Register.aspx" style="text-decoration: none; color: #ffffff; text-decoration: underline overline 5px; display: flex; justify-content: center;" tabindex="4"> Click here for Registration !</a>
                    </div>

                    <div class="form-group mt-3">
                        <label style="color: #fff;float:left;margin-bottom:.5rem;">Username</label>
                        <input id="txtUserid" runat="server" type="text" class="form-control" placeholder="Username" />
                    </div>

                    <div class="form-group mt-3">
                        <label style="color: #fff;float:left;margin-bottom:.5rem;">Password</label>
                        <input id="txtPasswd" runat="server" type="password" class="form-control" placeholder="Password" />
                    </div>

                    <div class="form-group mt-3">
                        <div runat="server" id="errorMessage" visible="false" class="validation"></div>
                    </div>

                    <asp:Button ID="btnLogin" runat="server" Text="Submit"
                        CssClass="btn btn-lg btn-block w-100"
                        OnClick="btnLogin_Click"
                        style="background: #007bff; color: #fff; border: none; margin-top: 10px;"></asp:Button>
                </div>
            </div>
        </div>
            </section>
    </div>
</form>





