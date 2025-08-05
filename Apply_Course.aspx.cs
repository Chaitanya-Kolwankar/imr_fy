using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class FY_Apply_Course : System.Web.UI.Page
{
    Class1 cls = new Class1();
    string str = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Session["Formno"].ToString() == "")
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    string flag = "0";
                    DataTable dt_chk_pay = cls.fill_datatable("select Formno from admProvFees where Formno='" + Session["Formno"].ToString() + "' and ayid='" + Session["AYID"].ToString() + "'");
                    if (dt_chk_pay.Rows.Count != 0)
                    {
                        flag = "1";
                    }
                    DataSet ds = cls.fill_dataset("  select distinct adm.formno+replace(adm.group_id,'GRP','') as formno_grp,pre_faculty,s.subcourse_name,c.course_name,g.Group_title ,adm.group_id," + flag + " [flag] from  dbo.d_adm_applicant app,  dbo.OLA_FY_adm_CourseSelection adm,dbo.m_crs_subcourse_tbl s,dbo.m_crs_course_tbl c,dbo.m_crs_subjectgroup_tbl g,m_FeeMaster as fm where app.Form_no=adm.formno and fm.group_id=(select group_id from m_crs_subjectgroup_tbl where group_id= adm.Group_id )  and app.ACDID=fm.Ayid and fm.del_flag='0' and adm.group_id=g.group_id   and c.course_id=s.course_id and g.Subcourse_id=s.subcourse_id and adm.group_id=g.group_id  and app.form_no='" + Session["Formno"].ToString() + "' and app.acdid='" + Session["AYID"].ToString() + "' and app.del_flag=0");
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        dgvData.DataSource = ds.Tables[0];
                        dgvData.DataBind();
                    }
                    castdata();
                    fillCourse();
                    if (ddl_course.Items.Count > 2)
                    {
                        if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString() == "FY")
                        {
                            ddl_course.SelectedIndex = 1;
                            ddl_course.Enabled = false;
                        }
                        else if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString() == "SY")
                        {
                            ddl_course.SelectedIndex = 2;
                            ddl_course.Enabled = false;
                        }

                    }
                    dgvData.Visible = false;
                    Session["group_id"] = ddl_course.SelectedValue.ToString();
                    DataTable dt = cls.fill_datatable("select * from OLA_FY_adm_CourseSelection where formno='" + Session["Formno"].ToString() + "'and del_flag=0 and group_id='" + ddl_course.SelectedValue.ToString() + "'");
                    string str = "";
                    if (dt.Rows.Count > 0)
                    {
                        btnApply.Attributes["disabled"] = "disabled";
                        dgvData.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
        }

    }

    public void check_flag_withimage()
    {
        DataSet dss = check_flag();
        if (dss.Tables[0].Rows.Count > 0)
        {
            if (dss.Tables[0].Rows[0]["step1_flag"].ToString() == "True")
            {
                Control img1 = this.Master.FindControl("step1img") as Control;
                img1.Visible = true;
                //step1img.Visible = true;
            }
            if (dss.Tables[0].Rows[0]["step2_flag"].ToString() == "True")
            {
                Control img2 = this.Master.FindControl("step2img") as Control;
                img2.Visible = true;
                //step2img.Visible = true;
            }
            if (dss.Tables[0].Rows[0]["step3_flag"].ToString() == "True")
            {
                Control img2 = this.Master.FindControl("step3img") as Control;
                img2.Visible = true;
                //step3img.Visible = true;
            }
            if (dss.Tables[0].Rows[0]["step4_flag"].ToString() == "True")
            {
                Control img = this.Master.FindControl("step4img") as Control;
                img.Visible = true;
                //step4img.Visible = true;

            }
            if (dss.Tables[0].Rows[0]["step5_flag"].ToString() == "True")
            {
                Control img = this.Master.FindControl("step5img") as Control;
                img.Visible = true;
                //step5img.Visible = true;

            }
            if (dss.Tables[0].Rows[0]["step6_flag"].ToString() == "True")
            {
                Control img = this.Master.FindControl("step6img") as Control;
                img.Visible = true;
                //step6img.Visible = true;

            }
            if (dss.Tables[0].Rows[0]["step7_flag"].ToString() == "True")
            {
                Control img = this.Master.FindControl("step7img") as Control;
                img.Visible = true;
                //step7img.Visible = true;

            }
        }
    }

    public void fillcertificate()
    {
        string str = "";
        str = "select category from d_adm_applicant where Form_no='" + Session["Formno"].ToString() + "' and acdid='" + Session["AYID"].ToString() + "'";
        DataTable dt = cls.fill_datatable(str);
        if (dt.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dt.Rows[0]["category"].ToString()))
            {
                if (dt.Rows[0]["category"].ToString() != "OPEN")
                {

                }
            }
        }
    }

    public DataSet check_flag()
    {
        try
        {
            if (Session["Formno"].ToString() != string.Empty || Session["Formno"].ToString() != "")
            {
                DataSet ds_flag = cls.fill_dataset("select step1_flag,step2_flag,step3_flag,step4_flag,step5_flag,step6_flag,step7_flag from d_adm_applicant where Form_no='" + Session["Formno"].ToString() + "' and acdid='" + Session["AYID"].ToString() + "'");
                if (ds_flag.Tables[0].Rows.Count > 0)
                {
                    Session["step1_flag"] = ds_flag.Tables[0].Rows[0]["step1_flag"].ToString();
                    Session["step2_flag"] = ds_flag.Tables[0].Rows[0]["step2_flag"].ToString();
                    Session["step3_flag"] = ds_flag.Tables[0].Rows[0]["step3_flag"].ToString();
                    Session["step4_flag"] = ds_flag.Tables[0].Rows[0]["step4_flag"].ToString();
                    Session["step5_flag"] = ds_flag.Tables[0].Rows[0]["step5_flag"].ToString();
                    Session["step6_flag"] = ds_flag.Tables[0].Rows[0]["step6_flag"].ToString();
                    Session["step7_flag"] = ds_flag.Tables[0].Rows[0]["step7_flag"].ToString();
                    return ds_flag;
                }
                return ds_flag;
            }
            else
            {
                Response.Redirect("Login.aspx");
                return null;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Login.aspx");
            return null;
        }
    }

    public void castdata()
    {
        str = "select category from d_adm_applicant where Form_no='" + Session["Formno"].ToString() + "' and acdid='" + Session["AYID"].ToString() + "'";
        DataTable dt = cls.fill_datatable(str);
        if (dt.Rows.Count > 0)
        {
            Session["cast_new"] = dt.Rows[0]["category"].ToString();
        }
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        Session["group_id"] = ddl_course.SelectedValue.ToString();
        DataTable dt = cls.fill_datatable("select * from OLA_FY_adm_CourseSelection where formno='" + Session["Formno"].ToString() + "'and del_flag=0 and group_id='" + ddl_course.SelectedValue.ToString() + "'");
        string str = "";
        if (dt.Rows.Count > 0)
        {

        }
        else
        {
            str = "insert into OLA_FY_adm_CourseSelection values('" + Session["Formno"].ToString() + "','" + ddl_course.SelectedValue.ToString() + "',null,null,0,null,GETDATE(),null,null,null,null,null);";
        }

        cls.DMLqueries(str);
        dgvData.Visible = true;

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

    public void fillCourse()
    {
        DataSet ddcourse = cls.fill_dataset("select Group_id,Group_title from m_crs_subjectgroup_tbl where del_flag=0 order by Group_title");
        ddl_course.Items.Clear();
        ddl_course.DataSource = ddcourse;
        ddl_course.DataValueField = "Group_id";
        ddl_course.DataTextField = "Group_title";
        ddl_course.DataBind();
        ddl_course.Items.Insert(0, new ListItem("-- Select --"));
    }


    /////sukant
    public void clear_div_con()
    {
        //div_receipt.Visible = false;
        div_valid.Visible = false;
        div_com.Visible = false;
        //div_offline.Visible = false;
        stat.Text = "";
        group_id.Text = "";
        fees.Text = "";
        // msg.Text = "";
        btn_confirm.Text = "PAY";
    }

    public bool validate_amt(string payamt)
    {
        if (Convert.ToInt32(payamt) < Convert.ToInt32(Session["other_amount"]))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Amount Should be greater than " + Convert.ToInt32(Session["other_amount"]) + "')", true);
            return false;
        }
        else
        {
            return true;
        }

    }

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        clear_div_con();
    }

    protected void btn_confirm_Click(object sender, EventArgs e)
    {
        string query = "select AYID,Duration as year from m_academic where ayid=(select MAX(ayid) from dbo.m_academic);";
        query += "select * from processing_fees where stud_id='" + Session["Formno"].ToString() + "' and ayid=(select MAX(ayid) from dbo.m_academic)";
        DataSet ds = cls.fill_dataset(query);
        //--year
        string[] main = ds.Tables[0].Rows[0]["year"].ToString().Split('/');
        string[] curr_year = main[2].Split('-');
        string acdyear = ds.Tables[0].Rows[0]["AYID"].ToString();

        //--transaction id
        string txn_id = "";
        if (ds.Tables[1].Rows.Count > 0)
        {
            txn_id = Session["Formno"].ToString() + curr_year[0] + (Convert.ToInt32(ds.Tables[1].Rows.Count) + 1);
        }
        else
        {
            txn_id = Session["Formno"].ToString() + curr_year[0] + "1";
        }

        string amount = txt_amount_final.Text.Trim();
        string status = Session["Formno"].ToString() + ddl_course.SelectedValue.ToString().Substring(3);
        string qry = "insert into processing_fees (stud_id,ayid,amount,txn_id,IPG_txn_id,process_date,bank_txn,status_code,status_date,bank_name,Status,curr_dt,mod_dt,del_date,del_flag,txn_src) values ('" + Session["Formno"].ToString() + "','" + acdyear + "','" + amount + "','" + txn_id + "',null,GETDATE(),null,null,null,null,'" + status + "',GETDATE(),null,null,0,'ADMISSION')";

        if (cls.DMLqueries(qry))
        {

            //--Payment direct to IMG (Excludes Payment page)
            DataTable dt = cls.fill_datatable("select (F_name + L_name)[Name],Email_id,Mob_No,Address_line1,Address_line2,city,State,pincode from d_adm_applicant where Form_no='" + Session["Formno"].ToString() + "' and ACDID=(select Max(AYID) from m_academic)");
            if (dt != null && dt.Rows.Count > 0)
            {
                Hashtable paymentData = new Hashtable
                {
                    { "name", dt.Rows[0]["Name"].ToString() },
                    { "email", dt.Rows[0]["Email_id"].ToString() },
                    { "phone", dt.Rows[0]["Mob_No"].ToString() },
                    { "order_id", txn_id },
                    { "amount", amount },
                    { "description", "Provisional Admission For Year " + curr_year[0] +"-"+ main[main.Length - 1] },
                    { "address_line_1", dt.Rows[0]["Address_line1"].ToString() },
                    { "address_line_2", dt.Rows[0]["Address_line2"].ToString() },
                    { "city", dt.Rows[0]["city"].ToString() },
                    { "state", dt.Rows[0]["State"].ToString() },
                    { "zip_code", dt.Rows[0]["pincode"].ToString() },
                    { "udf1", status +"|"+ ddl_course.SelectedItem.Text},
                };

                // --- INITIATE PAYMENT ---
                try
                {
                    InitiatePayment(paymentData);
                }
                catch (Exception ex)
                {
                    div_valid.InnerHtml = "An error occurred while processing your payment. Please try again. Details: " + ex.Message;
                    div_valid.Visible = true;
                }
            }
            else
            {
                div_valid.InnerHtml = "An error occurred while processing your payment. Please try again";
                div_valid.Visible = true;
            }
        }
    }

    protected void dgvData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "print")
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            Session["group_id"] = dgvData.DataKeys[row.RowIndex].Values["group_id"].ToString();
            SqlCommand cmd = new SqlCommand("insert into OLA_Form_print values('" + Session["Formno"].ToString() + "',getdate())");
            cmd.Connection = cls.con;
            cls.Conn();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cls.con_close();
            Response.Redirect("WebReport.aspx", false);
        }
        if (e.CommandName == "Confirm")
        {
            clear_div_con();
            div_com.Visible = true;
            Label lbldgv = (Label)dgvData.Rows[0].FindControl("lblGroupid");
            get_amt_pay(lbldgv.Text);
            txt_amount_final.ReadOnly = true;
            //  Fee_stat.Visible = false;
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            GridViewRow row1 = dgvData.Rows[row.RowIndex];

            string val = "";
            Session["group_id"] = dgvData.DataKeys[row.RowIndex].Values["group_id"].ToString();
            Session["subcourse_id_g_check"] = ((Label)row1.FindControl("lblSubcourse")).Text.ToString().Trim();           //lblSubcourse
            group_id.Text = dgvData.DataKeys[row.RowIndex].Values["group_id"].ToString();
            subcourse.Text = ((Label)row1.FindControl("lblSubcourse")).Text.ToString().Trim();
        }
    }


    public void get_amt_pay(string group_id)
    {
        Label lbldgv = (Label)dgvData.Rows[0].FindControl("lblGroupid");
        //ds = ((DataSet)Session["stud_data"]);
        txt_amount_final.Text = "10000";
    }

    protected void dgvData_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < dgvData.Rows.Count; i++)
        {
            if (dgvData.SelectedIndex == i)
            {
                string grpid = (dgvData.SelectedRow.FindControl("lblGroupid") as Label).Text;
                // Session["group_id"] = grpid;
                //string sub = (dgvData.SelectedRow.FindControl("lbl_subject") as Label).Text;
                Response.Redirect("WebReport.aspx", false);
            }
        }
    }


    /// paymentData Hashtable containing all necessary payment fields.
    private void InitiatePayment(Hashtable paymentData)
    {
        // --- GET CONFIGURATION VALUES ---
        string apiKey = ConfigurationManager.AppSettings["API_KEY"];
        string returnUrl = ConfigurationManager.AppSettings["RETURN_URL"];
        string mode = ConfigurationManager.AppSettings["MODE"];
        string salt = ConfigurationManager.AppSettings["SALT"];
        string paymentUrl = ConfigurationManager.AppSettings["UATPAYMENTS_URL"];
        string country = "IND";
        string currency = "INR";

        paymentData.Add("api_key", apiKey);
        paymentData.Add("return_url", returnUrl);
        paymentData.Add("mode", mode);
        paymentData.Add("country", country);
        paymentData.Add("currency", currency);
        paymentData.Add("SALT", salt);

        string[] hashVarsSeq = ConfigurationManager.AppSettings["hashSequence"].Split('|');
        StringBuilder hashStringBuilder = new StringBuilder();
        foreach (string hash_var in hashVarsSeq)
        {
            hashStringBuilder.Append(paymentData.ContainsKey(hash_var) ? paymentData[hash_var] : "");
            hashStringBuilder.Append("|");
        }
        hashStringBuilder.Remove(hashStringBuilder.Length - 1, 1);

        string hashString = hashStringBuilder.ToString();
        string hash = Generatehash512(hashString).ToUpper();

        // --- PREPARE FORM FOR SUBMISSION ---
        Hashtable dataToPost = new Hashtable();

        foreach (DictionaryEntry item in paymentData)
        {
            if (item.Key.ToString() != "SALT")
            {
                dataToPost.Add(item.Key, item.Value);
            }
        }
        dataToPost.Add("hash", hash);

        // Post the form
        string strForm = PreparePOSTForm(paymentUrl, dataToPost);
        Page.Controls.Add(new LiteralControl(strForm));
    }

    /// Generates an SHA512 hash for the transaction request.
    private string Generatehash512(string text)
    {
        byte[] message = Encoding.UTF8.GetBytes(text);
        using (SHA512Managed hashString = new SHA512Managed())
        {
            byte[] hashValue = hashString.ComputeHash(message);
            string hex = "";
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }

    /// Prepares the HTML form for POSTing to the payment gateway.
    private string PreparePOSTForm(string url, Hashtable data)
    {
        string formID = "PostForm";
        StringBuilder strForm = new StringBuilder();
        strForm.Append(string.Format("<form id=\"{0}\" name=\"{0}\" action=\"{1}\" method=\"POST\">", formID, url));

        foreach (System.Collections.DictionaryEntry key in data)
        {
            strForm.Append(string.Format("<input type=\"hidden\" name=\"{0}\" value=\"{1}\">", key.Key, key.Value));
        }
        strForm.Append("</form>");

        StringBuilder strScript = new StringBuilder();
        strScript.Append("<script language='javascript'>");
        strScript.Append(string.Format("var v{0} = document.{0};", formID));
        strScript.Append(string.Format("v{0}.submit();", formID));
        strScript.Append("</script>");

        return strForm.ToString() + strScript.ToString();
    }

}