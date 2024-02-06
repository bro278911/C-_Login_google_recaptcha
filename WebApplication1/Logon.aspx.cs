using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Services.Description;

namespace WebApplication1
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.cmdLogin.ServerClick += new System.EventHandler(this.cmdLogin_ServerClick);
        }
        private bool ValidateUser(string userName, string passWord)
        {
            string lookupPassword = null;

            // Check for invalid userName.
            // userName must not be null and must be between 1 and 15 characters.
            if ((null == userName) || (0 == userName.Length) || (userName.Length > 15))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
                return false;
            }

            // Check for invalid passWord.
            // passWord must not be null and must be between 1 and 25 characters.
            if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                return false;
            }

            try
            {
                Method_Login method_Login = new Method_Login();
                DataTable re_ = method_Login.login_check(userName);
                // Consult with your SQL Server administrator for an appropriate connection
                // string to use to connect to your local SQL Server.
                // Create SqlCommand to select pwd field from users table given supplied userName.
                string str_json = JsonConvert.SerializeObject(re_, Formatting.Indented);
                // Execute command and fetch pwd field into lookupPassword string.
                lookupPassword = (string)re_.Rows[0]["Pwd"];
                Console.WriteLine(lookupPassword);
            }
            catch (Exception ex)
            {
                // Add error handling here for debugging.
                // This error message should not be sent back to the caller.
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            }

            // If no password found, return false.
            if (null == lookupPassword)
            {
                // You could write failed login attempts here to event log for additional security.
                return false;
            }

            // Compare lookupPassword and input passWord, using a case-sensitive comparison.
            return (0 == string.Compare(lookupPassword, passWord, false));
        }
        private void cmdLogin_ServerClick(object sender, System.EventArgs e)
        {
            //google reCAPTCHA api key(用這串密鑰來建立網站和 reCAPTCHA 之間的通訊)
            var apiKey = "6LdTK.....vvKa";
            var url = "https://www.google.com/recaptcha/api/siteverify";
            var wc = new System.Net.WebClient();
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var data = "secret=" + apiKey + "&response=" + Request.Form["g-recaptcha-response"];
            var json = wc.UploadString(url, data);
            // JSON 反序化取 .success 屬性 true/false 判斷
            var success = JsonConvert.DeserializeObject<JObject>(json).Value<bool>("success");
            if (!success)
            {
                this.msg.InnerText = "請勾選驗證碼!!";
                return;
            }
            else
            {
                if (ValidateUser(txtUserName.Value, txtUserPass.Value))
                {
                    FormsAuthenticationTicket tkt;
                    string cookiestr;
                    HttpCookie ck;
                    tkt = new FormsAuthenticationTicket(1, txtUserName.Value, DateTime.Now,
                    DateTime.Now.AddMinutes(30), chkPersistCookie.Checked, "your custom data");
                    cookiestr = FormsAuthentication.Encrypt(tkt);
                    ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                    if (chkPersistCookie.Checked)
                        ck.Expires = tkt.Expiration;
                    ck.Path = FormsAuthentication.FormsCookiePath;
                    Response.Cookies.Add(ck);

                    string strRedirect;
                    strRedirect = Request["ReturnUrl"];
                    if (strRedirect == null)
                        strRedirect = "Default.aspx";
                    Response.Redirect(strRedirect, true);
                }
                else
                {
                    Response.Redirect("logon.aspx", true);
                }
            }
        }
    }
}