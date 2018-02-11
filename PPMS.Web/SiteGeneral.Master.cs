using PPMS.ENTITIES;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace PPMS.Web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        HideControls();
                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;
                        string userData = ticket.UserData;
                        string[] roles = userData.Split(',');
                        HttpContext.Current.User = new GenericPrincipal(id, roles);
                        string userRole = roles[0];
                        UserOpMap userOpMap = new UserOpMap();
                        BAL.BAL_Common bAL_Common = new BAL.BAL_Common();
                        userOpMap = bAL_Common.GetUserOperationMapping(HttpContext.Current.User.Identity.Name, userRole);
                        foreach (Operations op in userOpMap.OperationsList)
                        {
                            var ctrl = this.FindControl(op.OperationName);
                            ctrl.Visible = true;
                        }
                    }
                }
                else
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Login.aspx");
                }

            }
        }

        private void HideControls()
        {
            Dashboard.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
            ManageCustomer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
            ManageTanks.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
            ManageFuel.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
            ManageMeters.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
            CreateSale.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
            ViewReports.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}