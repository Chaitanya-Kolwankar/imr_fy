using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void BtnPay_Click(object sender, EventArgs e)
    {
        Hashtable dummyData = new Hashtable();
        dummyData.Add("name", "Test User");
        dummyData.Add("email", "test.user@example.com");
        dummyData.Add("phone", "9876543210");
        dummyData.Add("order_id", "ORD" + new Random().Next(1000, 9999).ToString());
        dummyData.Add("amount", "50.00");
        dummyData.Add("description", "Dummy Transaction for Testing");
        dummyData.Add("address_line_1", "123 Test Street");
        dummyData.Add("address_line_2", "Testville");
        dummyData.Add("city", "Test City");
        dummyData.Add("state", "Test State");
        dummyData.Add("zip_code", "123456");
        dummyData.Add("udf1", "CustomInfo1");
        dummyData.Add("udf2", "");
        dummyData.Add("udf3", "");
        dummyData.Add("udf4", "");
        dummyData.Add("udf5", "");

        string apiKey = ConfigurationManager.AppSettings["API_KEY"];
        string returnUrl = ConfigurationManager.AppSettings["RETURN_URL"];
        string mode = ConfigurationManager.AppSettings["MODE"];
        string salt = ConfigurationManager.AppSettings["SALT"];
        string country = "IND";
        string currency = "INR";
        string paymentUrl = ConfigurationManager.AppSettings["UATPAYMENTS_URL"];

        dummyData.Add("api_key", apiKey);
        dummyData.Add("return_url", returnUrl);
        dummyData.Add("mode", mode);
        dummyData.Add("country", country);
        dummyData.Add("currency", currency);
        dummyData.Add("SALT", salt);

        try
        {
            string[] hashVarsSeq = ConfigurationManager.AppSettings["hashSequence"].Split('|');
            StringBuilder hashStringBuilder = new StringBuilder();

            foreach (string hash_var in hashVarsSeq)
            {
                hashStringBuilder.Append(dummyData.ContainsKey(hash_var) ? dummyData[hash_var] : "");
                hashStringBuilder.Append("|");
            }

            hashStringBuilder.Remove(hashStringBuilder.Length - 1, 1);

            string hashString = hashStringBuilder.ToString();
            string hash = Generatehash512(hashString).ToUpper();

            Hashtable dataToPost = new Hashtable();

            dataToPost.Add("name", dummyData["name"]);
            dataToPost.Add("email", dummyData["email"]);
            dataToPost.Add("phone", dummyData["phone"]);
            dataToPost.Add("order_id", dummyData["order_id"]);
            dataToPost.Add("amount", dummyData["amount"]);
            dataToPost.Add("description", dummyData["description"]);
            dataToPost.Add("address_line_1", dummyData["address_line_1"]);
            dataToPost.Add("address_line_2", dummyData["address_line_2"]);
            dataToPost.Add("city", dummyData["city"]);
            dataToPost.Add("state", dummyData["state"]);
            dataToPost.Add("zip_code", dummyData["zip_code"]);
            dataToPost.Add("udf1", dummyData["udf1"]);
            dataToPost.Add("api_key", apiKey);
            dataToPost.Add("return_url", returnUrl);
            dataToPost.Add("mode", mode);
            dataToPost.Add("country", country);
            dataToPost.Add("currency", currency);
            dataToPost.Add("hash", hash);
            string strForm = PreparePOSTForm(paymentUrl, dataToPost);
            Page.Controls.Add(new LiteralControl(strForm));
        }
        catch (Exception ex)
        {
            Response.Write("<span style='color:red'>" + ex.Message + "</span>");
        }
    }

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

    private string PreparePOSTForm(string url, System.Collections.Hashtable data)
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
