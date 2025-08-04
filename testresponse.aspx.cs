using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testresponse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string[] keys = Request.Form.AllKeys;
            Array.Sort(keys);
            string hash_string = ConfigurationManager.AppSettings["SALT"];

            foreach (string key in keys)
            {
                if (key != "hash" && !string.IsNullOrEmpty(Request.Form[key]))
                {
                    hash_string += "|" + Request.Form[key];
                }
            }

            string calculatedHash = GenerateSHA512Hash(hash_string).ToUpper();
            string receivedHash = Request.Form["hash"];

            if (calculatedHash == receivedHash)
            {
                string responseCode = Request.Form["response_code"];
                string responseMessage = Request.Form["response_message"];

                if (responseCode == "0")
                {
                    Response.Write("<h2 style='color:green;'>Transaction Successful</h2>");
                }
                else
                {
                    Response.Write("<h2 style='color:red;'>Transaction Failed</h2>");
                    if (!string.IsNullOrEmpty(responseMessage))
                    {
                        Response.Write("<p>Error: " + responseMessage + "</p>");
                    }
                }
            }
            else
            {
                Response.Write("<h2 style='color:red;'>Hash Mismatch - Possible Tampering</h2>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<h2 style='color:red;'>Exception: " + ex.Message + "</h2>");
        }
    }

    private string GenerateSHA512Hash(string input)
    {
        using (SHA512 sha512 = SHA512.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha512.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
    }
}