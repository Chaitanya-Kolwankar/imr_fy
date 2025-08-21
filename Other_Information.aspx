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
                    <div class="panel panel-default topMargin">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-4">
                                    <span style="font-family: Verdana">Special Category</span>
                                </div>
                                <div class="col-lg-8">
                                    <asp:DropDownList onblur="OnBlur(this);" ID="specialcategory" onfocus="OnFocus(this);"
                                        TabIndex="3" runat="server" Font-Names="Verdana"
                                        AutoPostBack="True" CssClass="form-control" ToolTip="Special Category">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>None</asp:ListItem>
                                        <asp:ListItem>Ex-Serviceman/Ward of Ex-Serviceman </asp:ListItem>
                                        <asp:ListItem>Active-Serviceman/Ward of Active-Serviceman</asp:ListItem>
                                        <asp:ListItem>Ward of Primary Teacher</asp:ListItem>
                                        <asp:ListItem>Ward of Secondary Teacher</asp:ListItem>
                                        <asp:ListItem>Deserted/Divorced/Wodowed Woman</asp:ListItem>
                                        <asp:ListItem>Member of project Affected Family</asp:ListItem>
                                        <asp:ListItem>Member of Earthquake Affected Family</asp:ListItem>
                                        <asp:ListItem>Member of Flood/Famine Affected Family</asp:ListItem>
                                        <asp:ListItem>Resident of Tribal Area</asp:ListItem>
                                        <asp:ListItem>Kashmir Migrant</asp:ListItem>
                                        <asp:ListItem>Economically Backward Class</asp:ListItem>
                                        <asp:ListItem>University Staff Quota</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-4">
                                    <span style="font-family: Verdana">Is Physically Reserved</span>
                                </div>
                                <div class="col-lg-8">
                                    <asp:DropDownList ID="ddhandicap" ToolTip="Physical Handicap" Font-Names="Verdana" CssClass="form-control" runat="server"
                                        AutoPostBack="True" TabIndex="4">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>Visually Impaired</asp:ListItem>
                                        <asp:ListItem>Speech and/or Hearing Impaired</asp:ListItem>
                                        <asp:ListItem>Orthopedic Disorder</asp:ListItem>
                                        <asp:ListItem>Mentally Retarded</asp:ListItem>
                                        <asp:ListItem>Learning Disability</asp:ListItem>
                                        <asp:ListItem>Dyslexia</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default topMargin">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-8">
                                    <span style="font-family: Verdana">Proficiency Acquired in extra Curricular Activities<span style="color: #ff3333">&nbsp;</span> </span>
                                </div>
                                <div class="col-lg-4">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <asp:RadioButton ID="rbtYesCuriculum" TabIndex="5" runat="server" Text="Yes" AutoPostBack="True" CssClass="form-control" ToolTip="Extra Curricular Activities" GroupName="Activity"></asp:RadioButton>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:RadioButton ID="rbtNoCuricullum" TabIndex="6" CssClass="form-control" runat="server" Text="No" AutoPostBack="True" ToolTip="Extra Curricular Activities" GroupName="Activity"></asp:RadioButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-8">
                                    <span style="font-family: Verdana">Whether a Member of NCC / NSS<span style="color: #ff3333">*</span>&nbsp;</span>
                                </div>
                                <div class="col-lg-4">
                                    <asp:DropDownList ID="ddlNcc" runat="server" CssClass="form-control" ToolTip="Member of NCC / NSS" Font-Names="Verdana" AutoPostBack="True" TabIndex="7">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>NSS</asp:ListItem>
                                        <asp:ListItem>NCC</asp:ListItem>
                                        <asp:ListItem>Both</asp:ListItem>
                                        <asp:ListItem>None</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-8">
                                    <span style="font-family: Verdana">Are you proposed to apply for Scholarship/Freeship<span style="color: #ff3333"> *</span>&nbsp;</span>
                                </div>
                                <div class="col-lg-4">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <asp:RadioButton ID="rbtnYes_isScholorship" TabIndex="8" CssClass="form-control" runat="server" Text="Yes" ToolTip="Scholarship/Freeship" GroupName="Scholorship"></asp:RadioButton>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:RadioButton ID="rbtnNo_isScholorship" TabIndex="9" CssClass="form-control" runat="server" Text="No" ToolTip="Scholarship/Freeship" GroupName="Scholorship"></asp:RadioButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default topMargin">
                        <div class="panel-heading">
                            <span style="font-family: Verdana">No. of Persons in the Family &nbsp;<span
                                style="color: #ff3333"> *</span></span>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-4">
                                    <span style="font-family: Verdana">Earning: </span>
                                    <asp:TextBox ID="txtEarning" TabIndex="10" onkeypress="CheckNumeric(event);" runat="server" Font-Size="10pt" Font-Names="Times New Roman" AutoPostBack="True"
                                        ToolTip="EARNING" CssClass="form-control" MaxLength="1" OnTextChanged="txtEarning_TextChanged"></asp:TextBox>

                                </div>
                                <div class="col-lg-4">
                                    <span style="font-family: Verdana">Non-Earning: </span>
                                    <asp:TextBox ID="txtNonEarning" TabIndex="11" onkeypress="CheckNumeric(event);" runat="server"
                                        Font-Names="Times New Roman" AutoPostBack="True" ToolTip="NON-EARNING" CssClass="form-control" MaxLength="1" OnTextChanged="txtNonEarning_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <span style="font-family: Verdana">Total: </span>
                                    <asp:TextBox ID="txtTotal" TabIndex="12" onkeypress="CheckNumeric(event);" runat="server"
                                        Font-Names="Times New Roman" AutoPostBack="True" ToolTip="TOTAL" CssClass="form-control" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default topMargin">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <span style="font-family: Verdana">Aadhar No.: <span style="color: #ff3333">*</span>&nbsp;</span>
                                    <asp:TextBox onblur="OnBlur(this);" ID="txtaadhar" onfocus="OnFocus(this);" TabIndex="17" onkeypress="CheckNumeric(event);" runat="server" Font-Names="Verdana" ToolTip="Aadhar No." CssClass="form-control" MaxLength="12"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">
                                    <span style="font-family: Verdana">DTE/ARA Application ID: <span style="color: #ff3333">*</span>&nbsp;</span>
                                    <asp:TextBox onblur="OnBlur(this);" ID="txtdteid" onfocus="OnFocus(this);" TabIndex="18" runat="server" Font-Names="Verdana" ToolTip="DTE Application ID" CssClass="form-control" MaxLength="12" oninput="blockInvalidChars(event)"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-8">
                                    <span style="font-family: Verdana">Yearly income of the Family from
                                    all sources (in RS.): <span style="color: #ff3333">*</span>&nbsp;</span>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox onblur="OnBlur(this);" ID="txtIncome" onfocus="OnFocus(this);" TabIndex="13"
                                        onkeypress="CheckNumeric(event);" runat="server" Font-Names="Verdana" ToolTip="Yearly Income" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                </div>
                            </div>
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

