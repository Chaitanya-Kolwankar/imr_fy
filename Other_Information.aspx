<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Other_Information.aspx.cs" Inherits="FY_Other_Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <style>
        .stepwizard-step p {
            margin-top: 10px;
        }

        .stepwizard-row {
            display: table-row;
        }

        .stepwizard {
            display: table;
            width: 100%;
            position: relative;
        }

        .stepwizard-step button[disabled] {
            opacity: 1 !important;
            filter: alpha(opacity=100) !important;
        }

        .stepwizard-row:before {
            top: 14px;
            bottom: 0;
            position: absolute;
            content: " ";
            width: 100%;
            height: 1px;
            background-color: #ccc;
            z-order: 0;
        }

        .stepwizard-step {
            display: table-cell;
            text-align: center;
            position: relative;
        }

        .btn-circle {
            width: 30px;
            height: 30px;
            text-align: center;
            padding: 6px 0;
            font-size: 12px;
            line-height: 1.428571429;
            border-radius: 15px;
        }

        .well {
            margin-bottom: 0;
        }
    </style>



    <script type="text/javascript">

        function validate() {

            if (document.getElementById("<%=ddlCategory.ClientID%>").value == "--Select--") {
                alert("Please Enter Category");
                document.getElementById("<%=ddlCategory.ClientID%>").focus();
                return false;
            }
           <%-- if (document.getElementById("<%=ddlNcc.ClientID%>").value == "--Select--") {
                alert("Please Enter member of NCC/NSS");
                document.getElementById("<%=ddlNcc.ClientID%>").focus();
                return false;
            }--%>
            <%--if (document.getElementById("<%=txtEarning.ClientID%>").value == "") {
                alert("Please Enter Earning");
                document.getElementById("<%=txtEarning.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtNonEarning.ClientID%>").value == "") {
                alert("Please Enter NonEarning");
                document.getElementById("<%=txtNonEarning.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtIncome.ClientID%>").value == "") {
                alert("Please Enter Yearly Income");
                document.getElementById("<%=txtIncome.ClientID%>").focus();
                return false;
            }--%>

            return true;
        }

    </script>

    <script type="text/javascript">

        function Opencaste() {

            window.open("nlogin.aspx", "List", "scrollbars=no,resizable=no,width=400,height=280");

            return false;

        }

    </script>
    <script lang="javascript" type="text/javascript">
        function CheckNumeric(e) {

            if (window.event) // IE
            {
                if ((e.keyCode < 48 || e.keyCode > 57) & e.keyCode != 8) {
                    event.returnValue = false;
                    return false;

                }
            }
            else { // Fire Fox
                if ((e.which < 48 || e.which > 57) & e.which != 8) {
                    e.preventDefault();
                    return false;

                }
            }
        }

    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <span style="font-family: Verdana; font-size: 18pt; padding: 10px;"><strong>Other Informations</strong></span>
                        <div class="hidden-lg hidden-md">
                            <a class="btn btn-sm btn-success pull-right" href="FY_Family_Detail.aspx"><i class="fa fa-plus"></i>Previous Page</a>
                        </div>
                    </div>
                </div>
                <div class="panel panel-body">
                    <div class="panel panel-default topMargin">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <span style="font-family: Verdana">Category</span><span style="color: #ff3333"> *</span>
                                    <asp:DropDownList onblur="OnBlur(this);" ID="ddlCategory" onfocus="OnFocus(this);"
                                        TabIndex="1" runat="server" CssClass="uppercase form-control" Font-Names="Verdana"
                                        AutoPostBack="True" ToolTip="Category" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>OPEN</asp:ListItem>
                                        <asp:ListItem>NT-1 (NT-B)</asp:ListItem>
                                        <asp:ListItem>NT-2 (NT-C)</asp:ListItem>
                                        <asp:ListItem>NT-3 (NT-D)</asp:ListItem>
                                        <asp:ListItem>OBC</asp:ListItem>
                                        <asp:ListItem>SBC</asp:ListItem>
                                        <asp:ListItem>SC</asp:ListItem>
                                        <asp:ListItem>ST</asp:ListItem>
                                        <asp:ListItem>VJ/DT(A)</asp:ListItem>
                                        <asp:ListItem>TWFS</asp:ListItem>
                                        <asp:ListItem>EBC</asp:ListItem>
                                        <asp:ListItem>SEBC</asp:ListItem>
                                        <asp:ListItem>EWS</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-6">
                                    <span style="font-family: Verdana">Caste</span><span style="color: #ff3333"> *</span>
                                    <asp:DropDownList onblur="OnBlur(this);" ID="ddlCast" onfocus="OnFocus(this);"
                                        TabIndex="2" runat="server" ToolTip="Caste" CssClass="uppercase form-control" Font-Names="Verdana"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlCast_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <%--<div class="row">--%>
                            <div runat="server" id="certificate" visible="false">
                                <div class="row">
                                    <div class="col-lg-6">
                                        <b>Certificate No.</b>
                                        <asp:TextBox ID="txtCertificateno" runat="server" CssClass="form-control" Visible="False" MaxLength="50" oninput="blockInvalidChars(event)"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-6" style="color: red">
                                        <br />
                                        Please attach your Caste Certificate with your printed form and specify the Certificate No.
                                    </div>
                                </div>
                            </div>
                            <%-- </div>--%>
                        </div>
                    </div>
                    <div class="row topMargin">
                        <div runat="server" id="errorMessage" visible="false" class="alert alert-danger"></div>
                    </div>
                    <div class="row topMargin">
                        <div class="col-lg-4"></div>
                        <div class="col-lg-4"></div>
                        <div class="col-lg-4 col-xs-12 col-md-12">
                            <asp:Button ID="btnsubmit" runat="server" Text="SAVE & CONTINUE" class="btn btn-primary btn-block btn-lg topMargin" TabIndex="14" Style="margin-top: 20px" OnClick="btnsubmit_Click1"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script>
        function blockInvalidChars(event) {
            let input = event.target;
            // Remove < and > from input
            input.value = input.value.replace(/[.?!;&%^*<>@$#]/g, '');
        }
    </script>
</asp:Content>

