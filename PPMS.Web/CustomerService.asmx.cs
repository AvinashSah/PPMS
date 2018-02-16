using PPMS.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
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
        public CustomerData GetFuelDataByID(string customerID)
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
    }
}
