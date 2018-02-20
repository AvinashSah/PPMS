using PPMS.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;

namespace PPMS.Web
{
    /// <summary>
    /// Summary description for CustomerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CustomerService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod()]
        public List<CustomerData> GetCustomerList()
        {
            List<CustomerData> list = new List<CustomerData>();
            List<Customer> customerList = new List<Customer>();
            List<CustomerType> customerTypeList = new List<CustomerType>();
            BAL.BAL_Customer bAL_Customer = new BAL.BAL_Customer();
            customerList = bAL_Customer.GetCustomerList();
            customerTypeList = bAL_Customer.GetCustomerType();
            foreach (Customer customer in customerList)
            {
                CustomerData customerData = new CustomerData();
                customerData.Id = customer.Id;
                customerData.Name = customer.Name;
                customerData.Addr1 = customer.AddressLineOne;
                customerData.Addr2 = customer.AddressLineTwo;
                customerData.City = customer.City;
                customerData.State = customer.State;
                customerData.EmailID = customer.EmailId;
                customerData.ContactNumber = Convert.ToString(customer.ContactNumber);
                foreach (CustomerType customerType in customerTypeList)
                {
                    if (customer.CustomerTypeId == customerType.Id)
                    {
                        customerData.Type = customerType.TypeName;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                list.Add(customerData);
            }
            return list;
        }

        [WebMethod]
        [ScriptMethod()]
        public List<DropDownCustomerType> GetListOfCustomerTypes()
        {
            List<DropDownCustomerType> list = new List<DropDownCustomerType>();
            List<CustomerType> customerTypeList = new List<CustomerType>();
            BAL.BAL_Customer bAL_Customer = new BAL.BAL_Customer();
            customerTypeList = bAL_Customer.GetCustomerType();
            foreach (CustomerType ct in customerTypeList)
            {
                DropDownCustomerType dropDownCustomerType = new DropDownCustomerType();
                dropDownCustomerType.Value = ct.Id;
                dropDownCustomerType.text = ct.TypeName;
                list.Add(dropDownCustomerType);
            }
            return list;
        }

        [WebMethod]
        [ScriptMethod()]
        public CustomerData GetCustomerDataByID(string customerID)
        {
            CustomerData retCustomerData = new CustomerData();
            List<Customer> customerList = new List<Customer>();
            List<CustomerType> customerTypeList = new List<CustomerType>();
            BAL.BAL_Customer bAL_Customer = new BAL.BAL_Customer();
            customerList = bAL_Customer.GetCustomerList();
            customerTypeList = bAL_Customer.GetCustomerType();
            foreach (Customer customer in customerList)
            {
                if (customer.Id == Convert.ToInt32(customerID))
                {
                    CustomerData customerData = new CustomerData();
                    customerData.Id = customer.Id;
                    customerData.Name = customer.Name;
                    customerData.Addr1 = customer.AddressLineOne;
                    customerData.Addr2 = customer.AddressLineTwo;
                    customerData.City = customer.City;
                    customerData.State = customer.State;
                    customerData.EmailID = customer.EmailId;
                    customerData.ContactNumber = Convert.ToString(customer.ContactNumber);
                    foreach (CustomerType customerType in customerTypeList)
                    {
                        if (customer.CustomerTypeId == customerType.Id)
                        {
                            customerData.Type = customerType.TypeName;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    retCustomerData = customerData;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return retCustomerData;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string SubmitEditCustomerData(CustomerData CustomerData)
        {
            var User = System.Web.HttpContext.Current.User.Identity.Name;
            FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            string userData = ticket.UserData;
            string[] roles = userData.Split(',');
            string userRole = roles[0];
            UserOpMap userOpMap = new UserOpMap();
            BAL.BAL_Common bAL_Common = new BAL.BAL_Common();
            userOpMap = bAL_Common.GetUserOperationMapping(HttpContext.Current.User.Identity.Name, userRole);

            EntitySubmittedResponse entitySubmittedResponse = new EntitySubmittedResponse();
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            try
            {
                BAL.BAL_Customer bAL_Customer = new BAL.BAL_Customer();
                long customerID = bAL_Customer.UpdateCutsomer(CustomerData, userOpMap);
                entitySubmittedResponse.submited = true;
                entitySubmittedResponse.message = "Customer updated!";
                return js.Serialize("Customer updated!");

            }
            catch (Exception ex)
            {
                entitySubmittedResponse.submited = false;
                entitySubmittedResponse.message = string.Format("Error occured while updating Customer with message:{0}", ex.Message);
                //return js.Serialize(entitySubmittedResponse);
                return js.Serialize(string.Format("Error occured while updating Customer with message:{0}", ex.Message));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string SubmitCreateCustomerData(CustomerData CustomerData)
        {
            var User = System.Web.HttpContext.Current.User.Identity.Name;
            FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            string userData = ticket.UserData;
            string[] roles = userData.Split(',');
            string userRole = roles[0];
            UserOpMap userOpMap = new UserOpMap();
            BAL.BAL_Common bAL_Common = new BAL.BAL_Common();
            userOpMap = bAL_Common.GetUserOperationMapping(HttpContext.Current.User.Identity.Name, userRole);

            EntitySubmittedResponse entitySubmittedResponse = new EntitySubmittedResponse();
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            try
            {
                BAL.BAL_Customer bAL_Customer = new BAL.BAL_Customer();
                long customerID = bAL_Customer.CreateCustomer(CustomerData, userOpMap);
                entitySubmittedResponse.submited = true;
                entitySubmittedResponse.message = "Customer Created!";
                return js.Serialize("Customer Created!");

            }
            catch (Exception ex)
            {
                entitySubmittedResponse.submited = false;
                entitySubmittedResponse.message = string.Format("Error occured while creating Customer with message:{0}", ex.Message);
                //return js.Serialize(entitySubmittedResponse);
                return js.Serialize(string.Format("Error occured while creating Customer with message:{0}", ex.Message));
            }
        }
    }
}
