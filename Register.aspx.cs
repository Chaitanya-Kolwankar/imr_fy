using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    Class1 cls = new Class1();
    clsvalidate valid = new clsvalidate();
    DataTable dt = new DataTable();
    sy_model mod = new sy_model();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // disable();
            try
            {
                ddl_applicant_type.SelectedIndex = 1;
                ddl_applicant_type.Enabled = false;
                errorMessage.Visible = false;
                btnsubmit.Attributes.Add("onclick", "return validate()");
                lbl_captcha.Text = generateString();

                DataSet ds = cls.fill_dataset("select max(ayid) as 'ayid' from dbo.m_academic");
                Session["AYID"] = ds.Tables[0].Rows[0]["ayid"].ToString();
            }
            catch (Exception ex)
            {
                Session["Formno"] = "";
                Response.Redirect("Register.aspx");
            }
        }

        dt.Columns.Add("f_name");
        dt.Columns.Add("m_name");
        dt.Columns.Add("l_name");
        dt.Columns.Add("mo_name");
        dt.Columns.Add("dob");
        dt.Columns.Add("mob_no");
        dt.Columns.Add("prefaculty");
        dt.Columns.Add("subcourse_name");
        dt.Columns.Add("group_id");
        dt.Columns.Add("passwd");
        dt.Columns.Add("Out_of");
        dt.Columns.Add("Marks_obtained");
        dt.Columns.Add("Percentage");
        dt.Columns.Add("ayid");
        dt.Columns.Add("email_id");
        dt.Columns.Add("seat_no");
        dt.Columns.Add("pass_month");
        dt.Columns.Add("pass_year");
        dt.Columns.Add("is_diploma");
        dt.Columns.Add("SEM_1");
        dt.Columns.Add("SEM_2");
        dt.Columns.Add("SEM_3");
        dt.Columns.Add("SEM_4");
        dt.Columns.Add("applicant_type");

    }

    public static string generateString()
    {
        int Lenght = 6;
        int NonAlphaNumericChars = 1;
        string allowedChars = "abcdefghijkmnopqrstuvwxyz0123";
        string allowedNonAlphaNum = "abcdef";
        Random rd = new Random();

        if (NonAlphaNumericChars > Lenght || Lenght <= 0 || NonAlphaNumericChars < 0)
            throw new ArgumentOutOfRangeException();

        char[] pass = new char[Lenght];
        int[] pos = new int[Lenght];
        int i = 0, j = 0, temp = 0;
        bool flag = false;

        //Random the position values of the pos array for the string Pass
        while (i < Lenght - 1)
        {
            j = 0;
            flag = false;
            temp = rd.Next(0, Lenght);
            for (j = 0; j < Lenght; j++)
                if (temp == pos[j])
                {
                    flag = true;
                    j = Lenght;
                }

            if (!flag)
            {
                pos[i] = temp;
                i++;
            }
        }

        //Random the AlphaNumericChars
        for (i = 0; i < Lenght - NonAlphaNumericChars; i++)
            pass[i] = allowedChars[rd.Next(0, allowedChars.Length)];

        //Random the NonAlphaNumericChars
        for (i = Lenght - NonAlphaNumericChars; i < Lenght; i++)
            pass[i] = allowedNonAlphaNum[rd.Next(0, allowedNonAlphaNum.Length)];

        //Set the sorted array values by the pos array for the rigth posistion
        char[] sorted = new char[Lenght];
        for (i = 0; i < Lenght; i++)
            sorted[i] = pass[pos[i]];

        string Pass = new String(sorted);

        return Pass;


    }

    public bool CheckEmail(string s)
    {
        Regex reg = new Regex("^([0-9a-zA-Z]+[-._])*[0-9a-zA-Z]+@([0-9a-zA-Z]+[.])+[a-zA-Z]{2,3}$");
        return reg.IsMatch(s);
    }

    public bool Valid_data()
    {
        try
        {
            if (ddl_applicant_type.SelectedValue == "02")
            {
                mod.applicant_type = "SY";
            }
            else if (ddl_applicant_type.SelectedValue == "03")
            {
                mod.applicant_type = "TY";
            }
            if (ddl_applicant_type.SelectedValue == "02" || ddl_applicant_type.SelectedValue == "03")
            {
                mod.seat_no = "";
                mod.pass_month = "";
                mod.pass_year = "";
                mod.Out_of = "";
                mod.Marks_obtained = "";
            }
            else
            {
                ErrorMessageDisplay("Please select option.");
                return false;
            }

            DataSet dss = cls.fill_dataset("select email_id  from adm_applicant_registration where email_id='" + valid.replacequote(txtEmailID.Value.ToString()) + "' and ayid='" + Session["AYID"].ToString() + "'");
            if (dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                txtEmailID.Value = "";
                ErrorMessageDisplay("Email ID is already registered with us enter another ID");
                return false;
            }
            else
            {
                txtEmailID.Value = txtEmailID.Value.ToLower();
            }

            if (!txt_code.Value.Equals(lbl_captcha.Text))
            {
                txt_code.Value = "";
                txt_code.Focus();
                ErrorMessageDisplay("Please Enter Exact Security Code");
                return false;
            }
            if (!txtPasswd.Text.Equals(txtVerifyPass.Text))
            {
                txt_code.Value = "";
                txt_code.Focus();
                ErrorMessageDisplay("Please Enter Same Password In Both Fields");
                return false;
            }
        }
        catch (Exception ex)
        {
            ErrorMessageDisplay("Something Went Wrong !!");
        }
        return true;
    }

    public void ErrorMessageDisplay(string ex)
    {
        errorMessage.InnerHtml = "<strong>ERROR!</strong> " + ex;
        errorMessage.Visible = true;
        errorMessage.Attributes["class"] = "row topMargin alert alert-danger";
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Valid_data())
            {
                if (valid.CheckEmail(txtEmailID.Value) != true)
                {
                    ErrorMessageDisplay("Enter Proper Email ID");
                    return;
                }

                mod.f_name = txtFname.Value;
                mod.m_name = txtMname.Value;
                mod.l_name = txtSurname.Value;
                mod.mo_name = txtMoName.Value;
                mod.mob_no = txtMobNo.Value;
                mod.passwd = txtPasswd.Text.Trim();
                mod.ayid = Session["AYID"].ToString();
                mod.email_id = txtEmailID.Value;
                if (ddl_applicant_type.SelectedIndex == 1)
                { mod.applicant_type = "FY"; }
                else if (ddl_applicant_type.SelectedIndex == 2)
                { mod.applicant_type = "SY"; }
                string DOB = ddday.Text.ToString() + '-' + ddmonth.SelectedItem.Text.ToString() + '-' + ddyear.Text.ToString();
                mod.dob = DOB;
                DataSet dss = cls.fill_dataset("select email_id from d_adm_applicant where email_id='" + valid.replacequote(txtEmailID.Value) + "' and ACDID='" + Session["AYID"].ToString() + "'");
                DataSet dss_phone = cls.fill_dataset("select mob_no from d_adm_applicant where mob_no='" + valid.replacequote(txtMobNo.Value) + "' and ACDID='" + Session["AYID"].ToString() + "'");

                if (dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                {
                    txtEmailID.Value = "";

                    ErrorMessageDisplay("Email ID is already registered with us enter another ID");
                }
                else if (dss_phone.Tables.Count > 0 && dss_phone.Tables[0].Rows.Count > 0)
                {
                    txtMobNo.Value = "";

                    ErrorMessageDisplay("Mobile Number is already registered with us enter another Number");
                }
                else
                {
                    string result = cls.insrt_registar(mod);
                    if (result == "fail")
                    {
                        ErrorMessageDisplay("Error Occurred");
                    }
                    else if (result != "")
                    {
                        Session["Formno"] = result;
                        Session["passwd"] = txtPasswd.Text;
                        ErrorMessageDisplay("Your user id is: " + Session["Formno"].ToString() + " and password is: " + Session["Passwd"].ToString() + "");
                        errorMessage.Attributes["class"] = "row topMargin alert alert-success";
                        //For sending mail and msg--------------------------
                        //sendemail();
                        //sendmessage();

                        clear();
                        errorMessage.Visible = true;
                    }
                }
            }
        }
        catch (Exception ex1)
        {
            //btnsubmit.Enabled = true; 
        }

    }

    public bool sendemail()
    {
        try
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            // setup Smtp authentication
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("admission@vivacollege.org", "admission@321");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("admission@vivacollege.org");
            msg.To.Add(new MailAddress(txtEmailID.Value.Trim()));
            msg.Subject = "ThankYou for Registering.";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<html><head></head><body><b>Your User ID is : <font color=red>" + Session["Formno"] + "</font><br/><b>Your Password is : <font color=red>" + Session["passwd"] + "</font> <br/>For Online Admission from VIVA College</pre></b></body>");
            msg.IsBodyHtml = true;
            client.Send(msg);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }


    }

    public bool sendmessage()
    {
        try
        {
            return false;
            string uid = "vivavit347422";
            string pwd = "vss@kit19";
            string gsmsenderid = "VIWAED";
            string cdmasenderid = "VIWAED";

            //string msg = "Dear Student, Your User ID is " + Session["Formno"] + " and password is " + Session["passwd"] + " for online admission. LATE SHRI VISHNU WAMAN THAKUR CHARUTABLE TRUST";
            //string msg = "Dear Student, Your User ID is " + Session["Formno"] + " and Password is " + Session["passwd"] + " for online admission. LATE SHRI VISHNU WAMAN THAKUR CHARITABLE TRUST";

            string msg = "Dear Student, Your User ID is " + Session["Formno"] + " and password is " + Session["passwd"] + " for online admission. VIWAED";

            string strRequest = "username=" + uid + "&password=" + pwd + "&sender=" + gsmsenderid + "&to=" + txtMobNo.Value.Trim() + "&message=" + msg + "&priority=1&dnd=1&unicode=0&dlttemplateid=1707174783653466966";

            // string strRequest = "username=" + uid + "&password=" + pwd + "&sender=" + gsmsenderid + "&to=" + txtMobNo.Value.Trim() + "&message=" + msg + "&priority=1&dnd=1&unicode=0&dlttemplateid=1707162814802286683";
            //string strRequest = "username=" + uid + "&password=" + pwd + "&sender=" + gsmsenderid + "&to=" + txtMobNo.Value.Trim() + "&message=" + msg + "&priority=1&dnd=1&unicode=0&dlttemplateid=" + 1707162814802286683 + "";
            string url = "http://www.kit19.com/ComposeSMS.aspx?";
            string Result_FromSMS = "";
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strRequest);
            objRequest.Method = "POST";
            objRequest.ContentLength = strRequest.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(strRequest);
            myWriter.Close();
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                Result_FromSMS = sr.ReadToEnd();
                sr.Close();
            }

            return true;
        }
        catch (System.Exception ex)
        {
            return false;
        }
    }

    public void disable()
    {
        txtEmailID.Disabled = true;
        txt_code.Disabled = true;
        txtFname.Disabled = true;
        txtMname.Disabled = true;
        txtMobNo.Disabled = true;
        txtMoName.Disabled = true;
        txtPasswd.Enabled = false;
        //txtSeatNo.Disabled=true;
        txtSurname.Disabled = true;
        txtVerifyPass.Enabled = false;
        ddday.Enabled = false;
        ddmonth.Enabled = false;
        ddyear.Enabled = false;
    }

    public void enable()
    {
        txtEmailID.Disabled = false;
        txt_code.Disabled = false;
        txtFname.Disabled = false;
        txtMname.Disabled = false;
        txtMobNo.Disabled = false;
        txtMoName.Disabled = false;
        txtPasswd.Enabled = true;
        txtSurname.Disabled = false;
        txtVerifyPass.Enabled = true;
        ddday.Enabled = true;
        ddmonth.Enabled = true;
        ddyear.Enabled = true;
    }

    public void enableFySy()
    {
        txtEmailID.Disabled = false;
        txt_code.Disabled = false;
        txtFname.Disabled = false;
        txtMname.Disabled = false;
        txtMobNo.Disabled = false;
        txtMoName.Disabled = false;
        txtPasswd.Enabled = true;
        txtSurname.Disabled = false;
        txtVerifyPass.Enabled = true;
        ddday.Enabled = true;
        ddmonth.Enabled = true;
        ddyear.Enabled = true;
    }

    public void clear()
    {
        txtEmailID.Value = "";
        txt_code.Value = "";
        txtFname.Value = "";
        txtMname.Value = "";
        txtMobNo.Value = "";
        txtMoName.Value = "";
        txtPasswd.Text = "";
        //txtSeatNo.Value = "";
        txtSurname.Value = "";
        txtVerifyPass.Text = "";
        //datetimepicker1.Text = "";
        ddday.SelectedIndex = 0;
        ddmonth.SelectedIndex = 0;
        ddyear.SelectedIndex = 0;

        //if (dd12passmonth.SelectedIndex > 0)
        //{
        //    dd12passmonth.SelectedIndex = 0;
        //}
        //if (dd12passyear.SelectedIndex > 0)
        //{
        //    dd12passyear.SelectedIndex = 0;
        //}
        //if (cmbGroupname.SelectedIndex > 0)
        //{
        //    cmbGroupname.SelectedIndex = 0;
        //}
        //if (cmbPrefaculty.SelectedIndex > 0)
        //{
        //    cmbPrefaculty.SelectedIndex = 0;
        //}
        //if (cmbSubcourseName.SelectedIndex > 0)
        //{
        //    cmbSubcourseName.SelectedIndex = 0;
        //}

        //rdbNo.Checked=false;
        //rdbYes.Checked = false;

        //txtPercentage.Text = "";
        //txtCredit1.Text = "";
        //txtCredit2.Text = "";
        //txtCredit3.Text = "";
        //txtCredit4.Text = "";
    }

    

    protected void rdbFyPG_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void rdbTy_CheckedChanged(object sender, EventArgs e)
    {
        enableFySy();
        clear();
        //lblSeatNo.Text = "Enter Seat No.";
        //lblPassingYr.Text = "Select Passing Year";
        //lblPassingMnt.Text = "Select Passing Month";
    }
    protected void rdbSy_CheckedChanged(object sender, EventArgs e)
    {

    }
    
    protected void cmbGroupname_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void rdbSyPG_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void ddl_applicant_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_applicant_type.SelectedIndex > 0)
        {
            //if (ddl_applicant_type.SelectedIndex == 1)
            //{
            //    divdisable.Visible = false;
            //    divdisable2.Visible = true;
            //    enable();
            //    clear();
            //    lblSeatNo.Text = "Enter HSC Seat No.";
            //    lblPassingYr.Text = "Select HSC Passing Year";
            //    lblPassingMnt.Text = "Select HSC Passing Month";
            //}
            //else
            if (ddl_applicant_type.SelectedValue == "02")
            {
                //divdisable.Visible = true;
                //divdisable2.Visible = false;
                enableFySy();
                clear();
                //lblSeatNo.Text = "Enter Seat No.";
                //lblPassingYr.Text = "Select Passing Year";
                //lblPassingMnt.Text = "Select Passing Month";

                //txtCredit1.Visible = true;
                //lblcredit1.Visible = true;

                //txtCredit2.Visible = true;
                //lblcredit2.Visible = true;

                //txtCredit3.Visible = false;
                //lblcredit3.Visible = false;

                //txtCredit4.Visible = false;
                //lblcredit4.Visible = false;
            }
            else if (ddl_applicant_type.SelectedValue == "03")
            {
                //divdisable.Visible = true;
                //divdisable2.Visible = false;
                enableFySy();
                clear();
                //lblSeatNo.Text = "Enter Seat No.";
                //lblPassingYr.Text = "Select Passing Year";
                //lblPassingMnt.Text = "Select Passing Month";

                //txtCredit1.Visible = true;
                //lblcredit1.Visible = true;

                //txtCredit2.Visible = true;
                //lblcredit2.Visible = true;

                //txtCredit3.Visible = true;
                //lblcredit3.Visible = true;

                //txtCredit4.Visible = true;
                //lblcredit4.Visible = true;

            }
            //else if (ddl_applicant_type.SelectedIndex == 4)
            //{
            //    divdisable.Visible = false;
            //    divdisable2.Visible = true;
            //    enable();
            //    clear();
            //    lblSeatNo.Text = "Enter TY Seat No.";
            //    lblPassingYr.Text = "Select TY Passing Year";
            //    lblPassingMnt.Text = "Select TY Passing Month";
            //}
            //else if (ddl_applicant_type.SelectedIndex == 5)
            //{
            //    divdisable.Visible = false;
            //    divdisable2.Visible = true;
            //    enable();
            //    clear();
            //    lblSeatNo.Text = "Enter TY Seat No.";
            //    lblPassingYr.Text = "Select TY Passing Year";
            //    lblPassingMnt.Text = "Select TY Passing Month";
            //}
            else
            {
            }
        }
        else
        {
            disable();
            clear();
        }
    }
    protected void cmbGroupname_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}