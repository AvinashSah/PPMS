using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PPMS.ENTITIES;

namespace PPMS.Web
{
    public partial class ManageCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //BindCustomerList();
        }

        //private void BindCustomerList()
        //{
        //    string finalstring = "";
        //    List<Customer> customerList = new List<Customer>();
        //    List<CustomerType> customerType = new List<CustomerType>();
        //    BAL.BAL_Customer bAL_Customer = new BAL.BAL_Customer();
        //    customerList = bAL_Customer.GetCustomerList();
        //    customerType = bAL_Customer.GetCustomerType();

        //    foreach (Customer customer in customerList)
        //    {
        //        string htmlContent = "<tr>";
        //        htmlContent += "<td>" + Convert.ToString(customer.Name) + "</td>";
        //        foreach (CustomerType custType in customerType)
        //        {
        //            if (custType.Id == customer.Id)
        //            {
        //                htmlContent += "<td>" + Convert.ToString(custType.TypeName) + "</td>";
        //                break;
        //            }
        //            else
        //            {
        //                continue;
        //            }
        //        }
        //        htmlContent += "<td>" + Convert.ToString(customer.ContactNumber) + "</td>";
        //        htmlContent += "<td>" + Convert.ToString(customer.EmailId) + "</td>";
        //        htmlContent += "<td>" + Convert.ToString(customer.AddressLineOne) + " " + Convert.ToString(customer.AddressLineTwo) + "</td>";
        //        htmlContent += "<td>" + Convert.ToString(customer.City) + "</td>";
        //        htmlContent += "<td>" + Convert.ToString(customer.District) + "</td>";
        //        htmlContent += "<td>" + Convert.ToString(customer.State) + "</td>";
        //        htmlContent += "<td>" + Convert.ToString(customer.PinCode) + "</td>";
        //        htmlContent += "<td>" + "<button id=\"itemDelete\" class=\"btn btn-success nopadding\" style=\"padding:2px\"><i class=\"fa fa-edit\"></i></button>";
        //        htmlContent += "<button id=\"itemDelete\" class=\"btn btn-danger nopadding\" style=\"padding:2px\"><i class=\"fa fa-remove\"></i></button>" + "</td>";
        //        htmlContent += "</tr>";
        //        finalstring += htmlContent;
        //    }

        //    customerListBody.Controls.Add(new Literal { Text = finalstring.ToString() });

        //}

        public void AddCustomer()
        {

        }
    }
}