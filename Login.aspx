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
        background: url('images/backimg5.jpg');
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


    <div class="container" style="margin-top: 110px">
        <div class="row">
            <div class="col-md-6 col-lg-4 col-md-offset-3 col-lg-offset-4">

                <div style="background: rgba(0,0,0,0.5); padding: 30px; border-radius: 8px; box-shadow: 0 4px 12px rgba(0,0,0,0.4); text-align: center;">

                    <div class="mb-3">
                        <img src="images/RGCMS.png" alt="College Logo" style="height: 100px; margin-bottom: 10px;">
                    </div>

                    <h3 style="color: #fff; font-weight: bold; margin-bottom: 10px; margin-top: 10px">RGCMS</h3>
                    <h4 style="color: #ddd; margin-bottom: 20px;">Applicant Login</h4>

                    <div class="mb-3 form-group">
                        <a title="Click here for Registration!" href="Register.aspx" style="text-decoration: none; color: #ccc; text-decoration: underline overline 5px; display: flex; justify-content: center;" tabindex="4"> Click here for Registration !</a>
                    </div>

                    <div class="form-group text-left">
                        <label style="color: #fff;">Username</label>
                        <input id="txtUserid" runat="server" type="text" class="form-control" placeholder="Username" />
                    </div>

                    <div class="form-group text-left">
                        <label style="color: #fff;">Password</label>
                        <input id="txtPasswd" runat="server" type="password" class="form-control" placeholder="Password" />
                    </div>

                    <div class="form-group">
                        <div runat="server" id="errorMessage" visible="false" class="validation"></div>
                    </div>

                    <asp:Button ID="btnLogin" runat="server" Text="Submit"
                        CssClass="btn btn-lg btn-block"
                        OnClick="btnLogin_Click"
                        style="background: #007bff; color: #fff; border: none; margin-top: 10px;"></asp:Button>
                </div>
            </div>
        </div>
    </div>
</form>





