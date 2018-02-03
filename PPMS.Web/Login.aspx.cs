using PPMS.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPMS.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_ServerClick()
        {
            var username = txtUserName.Text;
            var pass = txtPassword.Text;
            BAL_Common bAL_Common = new BAL_Common();
            if (bAL_Common.ValidateUserLogin(username,pass))
            {

            }
        }
    }
}