using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class FY_Other_Information : System.Web.UI.Page
{
    Class1 cls = new Class1();
    DataSet ds = new DataSet();
    clsvalidate valid = new clsvalidate();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            try
            {
                btnsubmit.Attributes.Add("onclick", "return validate()");
                if (Session["Formno"].ToString() != string.Empty || Session["Formno"].ToString() != "")
                {
                    if (Session["submit"].ToString() == "True")
                    {
                        Response.Redirect("Apply_Course.aspx", false);

                    }
                    if (Session["step4_flag"] != null)
                    {
                        if (Session["step4_flag"].ToString() == "True")
                        {
                            if (Session["step5_flag"].ToString() == "True")
                            {
                                fill_data();
                            }
                            else
                            {
                                fillCaste();
                                //ddlCategory.Enabled = false;
                                ddlCast.Enabled = false;
                            }
                        }
                        else
                        {
                            Response.Redirect("Family_Detail.aspx");
                        }
                    }


                }
            }
            catch (Exception ex)
            {
            }
        }
    }

    void fillCaste()
    {

        ds = cls.fill_dataset("select Extra_Curricular_Activities ,Other_criteria ,Category ,Caste ,Phy_handicap_Description ,is_NSS_NCC ,is_Scholarship ,Earning , NonEarning , Annual_Income from d_adm_applicant where Form_no ='" + Session["Formno"].ToString() + "' and ACDID='" + Session["AYID"].ToString() + "'");


        //ddlCategory.SelectedItem.Text = ds.Tables[0].Rows[0]["Category"].ToString();
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "OPEN")
        {
            ddlCategory.SelectedIndex = 1;
            Session["category"] = "OPEN";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "NT-1 (NT-B)")
        {
            ddlCategory.SelectedIndex = 2;
            Session["category"] = "NT-1 (NT-B)";


        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "NT-2 (NT-C)")
        {
            ddlCategory.SelectedIndex = 3;
            Session["category"] = "NT-2 (NT-C)";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "NT-3 (NT-D)")
        {
            ddlCategory.SelectedIndex = 4;
            Session["category"] = "NT-3 (NT-D)";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "OBC")
        {
            ddlCategory.SelectedIndex = 5;
            Session["category"] = "OBC";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "SBC")
        {
            ddlCategory.SelectedIndex = 6;
            Session["category"] = "SBC";


        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "SC")
        {
            ddlCategory.SelectedIndex = 7;
            Session["category"] = "SC";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "ST")
        {
            ddlCategory.SelectedIndex = 8;
            Session["category"] = "ST";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "VJ/DT(A)")
        {
            ddlCategory.SelectedIndex = 9;
            Session["category"] = "VJ/DT(A)";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "TWFS")
        {
            ddlCategory.SelectedIndex = 10;
            Session["category"] = "TWFS";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "EBC")
        {
            ddlCategory.SelectedIndex = 11;
            Session["category"] = "EBC";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "SEBC")
        {
            ddlCategory.SelectedIndex = 12;
            Session["category"] = "SEBC";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "EWS")
        {
            ddlCategory.SelectedIndex = 13;
            Session["category"] = "EWS";

        }

        DataSet state_board_name = cls.fill_dataset("select  child from dbo.State_category_details where Main = 'Reserved Category' and parent = '" + ddlCategory.Text.ToString().Trim() + "'");
        ddlCast.DataSource = state_board_name.Tables[0];

        ddlCast.DataTextField = "child";
        ddlCast.DataBind();
        ddlCast.Items.Insert(0, new ListItem("-- Select --", "0"));



        if (ds.Tables[0].Rows[0]["Caste"].ToString() != "")
        {
            ddlCast.Enabled = true;
            ddlCast.SelectedItem.Text = ds.Tables[0].Rows[0]["Caste"].ToString();

        }

        if (ds.Tables[0].Rows[0]["Caste"].ToString() == "0")
        {

            ddlCast.SelectedItem.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
            ddlCast.Enabled = false;
        }

    }

    public void fill_data()
    {
        //ds = cls.fill_dataset("select Category,Certificate_No,Other_criteria,Phy_handicap,Phy_handicap_Description,Extra_Curricular_Activities,is_NSS_NCC,is_Scholarship,Earning,NonEarning,Annual_Income from dbo.d_adm_applicant where Form_no ='" + Session["Formno"].ToString() + "' and ACDID='" + Session["AYID"].ToString() + "'");


        ds = cls.fill_dataset("select Extra_Curricular_Activities,Certificate_No ,Other_criteria ,Category ,Caste ,Phy_handicap_Description ,is_NSS_NCC ,is_Scholarship ,Earning,case when remark is null then '' when Remark like '%|%' then substring(Remark, 1, CHARINDEX('|',Remark)-1) else remark end as Remark,case when remark is null then '' when Remark like '%|%' then substring(Remark, CHARINDEX('|',Remark)+1, LEN(Remark)) else '' end as DTE , NonEarning , Annual_Income from d_adm_applicant where Form_no ='" + Session["Formno"].ToString() + "' and ACDID='" + Session["AYID"].ToString() + "'");


        //ddlCategory.SelectedItem.Text = ds.Tables[0].Rows[0]["Category"].ToString();
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "OPEN")
        {
            ddlCategory.SelectedIndex = 1;
            Session["category"] = "OPEN";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "NT-1 (NT-B)")
        {
            ddlCategory.SelectedIndex = 2;
            Session["category"] = "NT-1 (NT-B)";


        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "NT-2 (NT-C)")
        {
            ddlCategory.SelectedIndex = 3;
            Session["category"] = "NT-2 (NT-C)";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "NT-3 (NT-D)")
        {
            ddlCategory.SelectedIndex = 4;
            Session["category"] = "NT-3 (NT-D)";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "OBC")
        {
            ddlCategory.SelectedIndex = 5;
            Session["category"] = "OBC";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "SBC")
        {
            ddlCategory.SelectedIndex = 6;
            Session["category"] = "SBC";


        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "SC")
        {
            ddlCategory.SelectedIndex = 7;
            Session["category"] = "SC";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "ST")
        {
            ddlCategory.SelectedIndex = 8;
            Session["category"] = "ST";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "VJ/DT(A)")
        {
            ddlCategory.SelectedIndex = 9;
            Session["category"] = "VJ/DT(A)";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "TWFS")
        {
            ddlCategory.SelectedIndex = 10;
            Session["category"] = "TWFS";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "EBC")
        {
            ddlCategory.SelectedIndex = 11;
            Session["category"] = "EBC";
        }

        if (ds.Tables[0].Rows[0]["Category"].ToString() == "SEBC")
        {
            ddlCategory.SelectedIndex = 12;
            Session["category"] = "SEBC";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "EWS")
        {
            ddlCategory.SelectedIndex = 13;
            Session["category"] = "EWS";
        }

        if (ds.Tables[0].Rows[0]["Category"].ToString() != "OPEN" && ds.Tables[0].Rows[0]["Category"].ToString() != "EBC")
        {
            certificate.Visible = true;
            txtCertificateno.Visible = true;
        }

        if (ds.Tables[0].Rows[0]["Certificate_No"].ToString().ToUpper() != string.Empty)
        {
            txtCertificateno.Text = ds.Tables[0].Rows[0]["Certificate_No"].ToString();
            certificate.Visible = true;
            txtCertificateno.Visible = true;
        }

        DataSet state_board_name = cls.fill_dataset("select  child from dbo.State_category_details where Main = 'Reserved Category' and parent = '" + ddlCategory.Text.ToString().Trim() + "'");
        ddlCast.DataSource = state_board_name.Tables[0];

        ddlCast.DataTextField = "child";
        ddlCast.DataBind();
        ddlCast.Items.Insert(0, new ListItem("-- Select --", "0"));



        if (ds.Tables[0].Rows[0]["Caste"].ToString() != "")
        {
            ddlCast.Enabled = true;
            ddlCast.SelectedItem.Text = ds.Tables[0].Rows[0]["Caste"].ToString();

        }

        if (ds.Tables[0].Rows[0]["Caste"].ToString() == "0")
        {

            ddlCast.SelectedItem.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
            ddlCast.Enabled = false;
        }
    }


    public String checkNull(string s)
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][s] == DBNull.Value)
            {
                return "";
            }
            else
            {
                return ds.Tables[0].Rows[0][s].ToString();
            }
        }
        else
        {
            return "";
        }

    }

    public string calc_total(string s1, string s2)
    {
        try
        {
            int earn = Convert.ToInt32(s1);
            int nonearn = Convert.ToInt32(s2);
            int total = earn + nonearn;
            string total_final = Convert.ToString(total);
            return total_final;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool check_radio()
    {
        //if (rbtnYes_isScholorship.Checked == false && rbtnNo_isScholorship.Checked == false)
        //{
        //    return false;
        //}

        return true;
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }
    protected void ddlCast_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void ErrorMessageDisplay(string ex)
    {
        string csError = "PopupError";
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        if (!cs.IsStartupScriptRegistered(cstype, csError))
        {
            String cstext1 = "alert('" + ex + "'" + ");";
            cs.RegisterStartupScript(cstype, csError, cstext1, true);
        }
    }


    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        errorMessage.Visible = false;
        if (ddlCategory.SelectedItem.Text != "OPEN")
        {
            if (ddlCast.SelectedIndex > 0 || ddlCast.SelectedItem.Text != "--Select--")
            {
                if (check_radio() || (!check_radio()))
                {
                    string UpdateQuery = string.Empty;
                    string specialCat = string.Empty;
                    string NCC_NSS = string.Empty;
                    string is_scholorship = string.Empty;
                    Session["category"] = ddlCategory.SelectedItem.Text.ToString().Trim().ToUpper();
                    UpdateQuery = "Update d_adm_applicant set Category='" + ddlCategory.SelectedItem.Text.ToString().Trim().ToUpper() + "', ";

                    

                    string caste;
                    if (ddlCast.SelectedIndex == 0)
                    {
                        caste = "NULL";
                    }
                    else
                    {
                        caste = ddlCast.SelectedItem.Text.Trim();
                        // Session["branch"] = ddbloodgroup.Text.ToString().Trim();
                    }

                    UpdateQuery = UpdateQuery + " Caste='" + caste + "', ";

                    bool chkflag = false;
                    if (ddlCategory.SelectedItem.Text != "OPEN")
                    {
                        if (ddlCategory.SelectedItem.Text == "EBC" || ddlCategory.SelectedItem.Text == "SEBC" || ddlCategory.SelectedItem.Text == "EWS")
                        {
                            UpdateQuery = UpdateQuery + "Certificate_No='" + txtCertificateno.Text + "',";
                        }
                        else
                        {
                           
                            UpdateQuery = UpdateQuery + "Certificate_No='" + txtCertificateno.Text + "',";
                        }
                    }

                    bool updated = false;
                    UpdateQuery = UpdateQuery.Trim().TrimEnd(',');
                    if (chkflag == false)
                    {
                        updated = cls.insert_data_app(UpdateQuery + ",step5_flag=1,step5_dt=getdate() " + "where Form_no='" + Session["Formno"].ToString() + "' and ACDID='" + Session["ayid"].ToString() + "' and del_flag=0");
                        if (updated == true)
                        {
                            Session["step5_flag"] = true;
                            Response.Redirect("Document_upload.aspx");
                        }
                        else
                        {
                            ErrorMessageDisplay("Error!!");
                            //ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Error!!!')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Fill All Cast/Income Details.');", true);
                    }
                }
                else
                {
                    errorMessage.InnerText = "Please Check Scholarship Options";
                    errorMessage.Visible = true;
                }
            }
            else
            {

                errorMessage.InnerText = "Please Select Caste ";
                errorMessage.Visible = true;
            }
        }
        else
        {
            if (check_radio() || (!check_radio()))
            {
                string UpdateQuery = string.Empty;
                string specialCat = string.Empty;
                string NCC_NSS = string.Empty;
                string is_scholorship = string.Empty;
                Session["category"] = ddlCategory.SelectedItem.Text.ToString().Trim().ToUpper();
                UpdateQuery = "Update d_adm_applicant set Category='" + ddlCategory.SelectedItem.Text.ToString().Trim().ToUpper() + "', ";

                string caste;
                if (ddlCast.SelectedIndex == 0)
                {
                    caste = "NULL";
                }
                else
                {
                    caste = ddlCast.SelectedItem.Text.Trim();
                    // Session["branch"] = ddbloodgroup.Text.ToString().Trim();
                }

                UpdateQuery = UpdateQuery + " Caste='" + caste + "', ";



               
                bool chkflag = false;


                bool updated = false;
                UpdateQuery = UpdateQuery.Trim().TrimEnd(',');
                if (chkflag == false)
                {
                    updated = cls.insert_data_app(UpdateQuery + ",step5_flag=1,step5_dt=getdate() " + "where Form_no='" + Session["Formno"].ToString() + "' and ACDID='" + Session["ayid"].ToString() + "' and del_flag=0");
                    if (updated == true)
                    {
                        Session["step5_flag"] = true;
                        Response.Redirect("Document_upload.aspx");
                    }
                    else
                    {
                        ErrorMessageDisplay("Error!!");
                        //ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Error!!!')", true);
                    }
                }
                else
                {

                }
            }
            else
            {
                errorMessage.InnerText = "Please Check Scholarship Options";
                errorMessage.Visible = true;
            }
        }
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.Text == "OPEN")
        {
            ddlCast.Enabled = false;
            if (ddlCast.SelectedIndex > 0)
            {
                ddlCast.SelectedIndex = 0;
            }


            certificate.Visible = false;
            //lblCertificateNo.Visible = false ;
            txtCertificateno.Visible = false;
        }
        else if (ddlCategory.Text == "--Select--")
        {
            txtCertificateno.Visible = false;
            ddlCast.Enabled = false;
        }
        else
        {
            certificate.Visible = true;
            //lblCertificateNo.Visible = true;
            if (ddlCategory.SelectedItem.Text == "EBC" || ddlCategory.SelectedItem.Text == "SEBC" || ddlCategory.SelectedItem.Text == "EWS")
            {
            }
            else
            {
            }
            txtCertificateno.Text = string.Empty;
            txtCertificateno.Visible = true;


            ddlCast.Enabled = true;
            DataSet state_board_name = cls.fill_dataset("select  child from dbo.State_category_details where Main = 'Reserved Category' and parent = '" + ddlCategory.Text.ToString().Trim() + "'");
            ddlCast.DataSource = state_board_name.Tables[0];

            ddlCast.DataTextField = "child";
            ddlCast.DataBind();
            ddlCast.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlCast.Items.Insert(1, new ListItem("Others", "Others"));
        }
    }

}