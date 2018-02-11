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
                            switch (ctrl.ID)
                            {
                                case "Dashboard":
                                    Dashboard.Attributes.Add("style", "display:block");
                                    break;
                                case "ManageCustomer":
                                    ManageCustomer.Attributes.Add("style", "display:block");
                                    break;
                                case "ManageTanks":
                                    ManageTanks.Attributes.Add("style", "display:block");
                                    break;
                                case "ManageFuel":
                                    ManageFuel.Attributes.Add("style", "display:block");
                                    break;
                                case "CreateSale":
                                    CreateSale.Attributes.Add("style", "display:block");
                                    break;
                                case "ViewSalesReports":
                                    ViewSalesReports.Attributes.Add("style", "display:block");
                                    break;
                                case "ViewInventoryReports":
                                    ViewInventoryReports.Attributes.Add("style", "display:block");
                                    break;
                                default:
                                    ShowAllControls();
                                    break;
                            }
                        }

                        string pageName = GetCurrentPageName();
                        switch (pageName)
                        {
                            case "Dashboard":
                                Dashboard.Attributes.Add("class", "active");
                                ManageCustomer.Attributes["class"].Replace("active", "");
                                ManageTanks.Attributes["class"].Replace("active", "");
                                ManageFuel.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                ViewInventoryReports.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                ViewSalesReports.Attributes["class"].Replace("active", "");
                                reportMainLi.Attributes["class"].Replace("active", "dropdown");
                                servicesMainLi.Attributes["class"].Replace("active", "dropdown");
                                break;
                            case "ManageCustomer":
                                ManageCustomer.Attributes.Add("class", "active");
                                Dashboard.Attributes["class"].Replace("active", "");
                                ManageTanks.Attributes["class"].Replace("active", "");
                                ManageFuel.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                ViewInventoryReports.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                ViewSalesReports.Attributes["class"].Replace("active", "");
                                reportMainLi.Attributes["class"].Replace("active", "dropdown");
                                servicesMainLi.Attributes.Add("class", "dropdown active");
                                break;
                            case "ManageTanks":
                                ManageTanks.Attributes.Add("class", "active");
                                Dashboard.Attributes["class"].Replace("active", "");
                                ManageCustomer.Attributes["class"].Replace("active", "");
                                ManageFuel.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                ViewInventoryReports.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                ViewSalesReports.Attributes["class"].Replace("active", "");
                                reportMainLi.Attributes["class"].Replace("active", "dropdown");
                                servicesMainLi.Attributes.Add("class", "dropdown active");
                                break;
                            case "ManageFuel":
                                ManageFuel.Attributes.Add("class", "active");
                                Dashboard.Attributes["class"].Replace("active", "");
                                ManageCustomer.Attributes["class"].Replace("active", "");
                                ManageTanks.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                ViewInventoryReports.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                ViewSalesReports.Attributes["class"].Replace("active", "");
                                reportMainLi.Attributes["class"].Replace("active", "dropdown");
                                servicesMainLi.Attributes.Add("class", "dropdown active");
                                break;
                            case "CreateSale":
                                CreateSale.Attributes.Add("class", "active");
                                Dashboard.Attributes["class"].Replace("active", "");
                                ManageCustomer.Attributes["class"].Replace("active", "");
                                ManageTanks.Attributes["class"].Replace("active", "");
                                ManageFuel.Attributes["class"].Replace("active", "");
                                ViewInventoryReports.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                ViewSalesReports.Attributes["class"].Replace("active", "");
                                reportMainLi.Attributes["class"].Replace("active", "dropdown");
                                servicesMainLi.Attributes.Add("class", "dropdown active");
                                break;
                            case "InventoryReport":
                                ViewInventoryReports.Attributes.Add("class", "active");
                                Dashboard.Attributes["class"].Replace("active", "");
                                ManageCustomer.Attributes["class"].Replace("active", "");
                                ManageTanks.Attributes["class"].Replace("active", "");
                                ManageFuel.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                ViewSalesReports.Attributes["class"].Replace("active", "");
                                reportMainLi.Attributes.Add("class", "dropdown active");
                                servicesMainLi.Attributes["class"].Replace("active", "dropdown");
                                break;
                            case "SalesReport":
                                ViewSalesReports.Attributes.Add("class", "active");
                                ViewInventoryReports.Attributes["class"].Replace("active", "");
                                Dashboard.Attributes["class"].Replace("active", "");
                                ManageCustomer.Attributes["class"].Replace("active", "");
                                ManageTanks.Attributes["class"].Replace("active", "");
                                ManageFuel.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                reportMainLi.Attributes.Add("class", "dropdown active");
                                servicesMainLi.Attributes["class"].Replace("active", "dropdown");
                                break;
                            case "Sale":
                                CreateSale.Attributes.Add("class", "active");
                                Dashboard.Attributes["class"].Replace("active", "");
                                ManageCustomer.Attributes["class"].Replace("active", "");
                                ManageTanks.Attributes["class"].Replace("active", "");
                                ManageFuel.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                ViewInventoryReports.Attributes["class"].Replace("active", "");
                                ViewSalesReports.Attributes["class"].Replace("active", "");
                                reportMainLi.Attributes["class"].Replace("active", "dropdown");
                                servicesMainLi.Attributes.Add("class", "dropdown active");
                                break;
                            default:
                                Dashboard.Attributes.Add("class", "active");
                                ManageCustomer.Attributes["class"].Replace("active", "");
                                ManageTanks.Attributes["class"].Replace("active", "");
                                ManageFuel.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                ViewInventoryReports.Attributes["class"].Replace("active", "");
                                CreateSale.Attributes["class"].Replace("active", "");
                                ViewSalesReports.Attributes["class"].Replace("active", "");
                                reportMainLi.Attributes["class"].Replace("active", "dropdown");
                                servicesMainLi.Attributes["class"].Replace("active", "dropdown");
                                break;
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

        private void ShowAllControls()
        {
            Dashboard.Attributes.Add("style", "display:block");
            ManageCustomer.Attributes.Add("style", "display:block");
            ManageTanks.Attributes.Add("style", "display:block");
            ManageFuel.Attributes.Add("style", "display:block");
            ManageMeters.Attributes.Add("style", "display:block");
            CreateSale.Attributes.Add("style", "display:block");
            ViewSalesReports.Attributes.Add("style", "display:block");
            ViewInventoryReports.Attributes.Add("style", "display:block");
        }

        private void HideControls()
        {
            Dashboard.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "none";
            ManageCustomer.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "none";
            ManageTanks.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "none";
            ManageFuel.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "none";
            ManageMeters.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "none";
            CreateSale.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "none";
            ViewSalesReports.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "none";
            ViewInventoryReports.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "none";
        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }

        public string GetCurrentPageName()
        {
            string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            return sRet;
        }
    }
}