using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using PPMS.BAL;
using PPMS.ENTITIES;

namespace PPMS.Web
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_ServerClick(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string passWord = txtPassword.Text.Trim();
            bool rememberMe = chkRememberMe.Checked;
            if (ValidateCreds(username, passWord, out UserMaster usermaster, out string userRole))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(2880), rememberMe, userRole, FormsAuthentication.FormsCookiePath);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(cookie);
                Response.Redirect(FormsAuthentication.GetRedirectUrl(username, rememberMe));
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
            }

        }

        private bool ValidateCreds(string username, string passWord, out UserMaster userMaster, out string role)
        {
            userMaster = new UserMaster();
            BAL_Common bAL_Common = new BAL_Common();
            userMaster = bAL_Common.GetUserdetailsByUsernamePass(username, bAL_Common.Encrypt(passWord));
            if (userMaster == null)
            {
                role = "";
                return false;
            }
            else
            {
                //GSTSevaAdmin@2018
                //abc@123
                role = bAL_Common.GetUserRole(userMaster.Id);
                return true;
            }
        }

    }
}