<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_Course.aspx.cs" Inherits="FY_Apply_Course" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="css/bootstrap.min.css" />

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
        .table>tbody>tr>td{
            vertical-align:middle;
        }
        table{
            border-color:white;
        }
        .th{
            text-align:center;
        }
    </style>

    <style>
        .topMargin {
            margin-top: 20px;
        }
    </style>

    <script type="text/javascript">
        function OnBlur(textBox) {
            textBox.className = '';
            text - transform: uppercase;
        }
        function OnFocus(textBox) {
            textBox.className += ' FocusedStyle';
            text - transform: uppercase;
        }


    </script>
    <script type="text/javascript">

</script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <span style="font-family: Verdana; font-size: 18pt; padding: 10px;"><strong>Apply Courses</strong></span>
                        <div class="hidden-lg hidden-md">
                            <a class="btn btn-sm btn-success pull-right" href="Document_upload.aspx"><i class="fa fa-plus"></i>Previous Page</a>
                        </div>
                    </div>
                </div>
                <div id="tab" class="panel panel-body" runat="server">
                    <div class="panel panel-default topMargin">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6 col-md-6">
                                    <span style="font-family: Verdana">Course<span style="color: #ff3333">*</span> </span>
                                    <br />
                                    <asp:DropDownList onblur="OnBlur(this);" ID="ddl_course" onfocus="OnFocus(this);" ToolTip="Course" TabIndex="1" runat="server" AutoPostBack="True" CssClass="uppercase form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-3 col-md-3">
                                    <br />
                                    <asp:Button ID="btnApply" runat="server" Text="Apply" class="btn btn-primary btn-block" TabIndex="3" Style="margin-bottom: 15px" OnClick="btnApply_Click"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--<div class="row topMargin">
                        <div class="col-lg-12 col-md-12">
                            <div class="panel panel-danger">
                                <div class="panel-heading">I AGREE</div>
                                <div class="panel-body">
                                    Declaration:
                              <br />
                                    <asp:CheckBox ID="chkIAgree" TabIndex="2" runat="server" Text="I AGREE" CssClass="form-control" AutoPostBack="True" ToolTip="I AGREE"></asp:CheckBox>
                                      I hereby declare that, I have read the rules related to admission and the information filled by me in this form is accurate and true to the best of my knowledge. I will be responsible for any discrepancy, arising out of the form signed by me and I undertake that, in absence of any document the final admission will not be granted and/or admission will stand cancelled.
                              <br />
                                    <br />
                                    students writing any negative and offensive remark about any staff member or institution on any social networking website may be booked under cyber crime law, Indian I.T Act 2000.
                                </div>
                            </div>
                        </div>

                    </div>--%>
                    <div class="row">
                        <div runat="server" id="div_valid" visible="false" class="row topMargin alert alert-danger"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4"></div>
                        <div class="col-lg-4">
                        </div>
                        <div class="col-lg-4"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12">
                            <div class="table-responsive">
                                <asp:GridView ID="dgvData" runat="server" class="table table-hover" DataKeyNames="group_id,Group_title" ForeColor="#333333" AutoGenerateColumns="False" OnRowCommand="dgvData_RowCommand">
                                    <RowStyle HorizontalAlign="Center" BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Previous Faculty" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFaculty" runat="server" Text='<%# Eval("pre_faculty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Course">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCourse" runat="server" Text='<%# Eval("course_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subcourse" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubcourse" runat="server" Text='<%# Eval("subcourse_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Group Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGroup" runat="server" Text='<%# Eval("Group_title") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Groupid" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGroupid" runat="server" Text='<%# Eval("group_id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:CommandField ButtonType="Link" ShowDeleteButton="true" HeaderText="Cancel"></asp:CommandField>
                                        <asp:TemplateField HeaderText="PRINT">
                                            <ItemTemplate>
                                                <asp:Button ID="btnPrint" runat="server" Text="PRINT" CommandName="print" CssClass="btn btn-warning" OnClientClick="aspnetForm.target ='_blank'"></asp:Button>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Admission">
                                            <ItemTemplate>
                                                <asp:Button ID="btn_confirm_add" runat="server" Text="Confirm Admission" CssClass="btn btn-primary" CommandName="Confirm"></asp:Button>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Form No">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_frm_grp" runat="server" Style="text-transform: uppercase" Text='<%# Eval("formno_grp") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                                    <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"></HeaderStyle>
                                    <EditRowStyle BackColor="#999999"></EditRowStyle>
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12 col-md-12">
                        <div class="row" style="background-color: wheat" runat="server" id="div_com" visible="false">
                            <div class="col-lg-12 col-md-12">
                                <br />
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="row">
                                            <div class="col-lg-2">
                                                <asp:Label ID="group_id" runat="server" Visible="false"></asp:Label>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="subcourse" runat="server" Visible="false"></asp:Label>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="tot_fees" runat="server" Visible="false"></asp:Label>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="fees" runat="server" Visible="false"></asp:Label>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="stat" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                        <%--   <asp:Label ID="msg" runat="server" Style="color: green; font-size: 20px; font-family: Century"></asp:Label>
                                        <br />
                                        <asp:Label ID="Fee_stat" runat="server" Visible="false" Style="color: red; font-size: 20px; font-family: Century"></asp:Label>
                                        <br />--%>
                                        <div class="row">
                                            <div class="col-lg-4" style="color: green; font-size: 20px; font-family: Century">Amount To Pay:</div>
                                            <div class="col-lg-2">
                                                <asp:TextBox ID="txt_amount_final" MaxLength="8" CssClass="form-control" runat="server" onkeypress="CheckNumeric(event);" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-3">
                                                <asp:Button ID="btn_confirm" Width="100%" runat="server" CssClass="btn btn-success" Text="PAY" OnClick="btn_confirm_Click" />
                                            </div>
                                            <div class="col-lg-3">
                                                <asp:Button ID="btn_cancel" Width="100%" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="btn_cancel_Click" />
                                            </div>
                                        </div>
                                        <br />

                                        <div class="row" runat="server" id="msgDiv">
                                            <center>
                                                <div id="divMsg" class="col-lg-12" style="margin-top: 5px">
                                                    <strong>
                                                        <asp:Label ID="lbl_msg" runat="server">  </asp:Label>
                                                    </strong>
                                                </div>
                                            </center>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <br />
        </ContentTemplate>
         <Triggers>
            <asp:PostBackTrigger ControlID="btn_confirm" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
