using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPMS.ENTITIES;
using PPMS.DAL;

namespace PPMS.BAL
{
    public class BAL_Customer
    {
        public List<Customer> GetCustomerList()
        {
            DAL_Customer bAL_Customer = new DAL_Customer();
            return bAL_Customer.GetCustomerList();
        }

        public List<CustomerType> GetCustomerType()
        {
            DAL_Customer bAL_Customer = new DAL_Customer();
            return bAL_Customer.GetCustomerType();
        }

        public long UpdateCutsomer(CustomerData customerData, UserOpMap userOpMap)
        {
            DAL_Customer dAL_Customer = new DAL_Customer();
            Customer customer = new Customer();
            customer.Id = customerData.Id;
            customer.EmailId = customerData.EmailID;
            customer.AddressLineOne = customerData.Addr1;
            customer.AddressLineTwo = customerData.Addr2;
            customer.ContactNumber = Convert.ToInt64(customerData.ContactNumber);
            customer.City = customerData.City;
            customer.State = customerData.State;
            customer.UpdatedOn = DateTime.Now;
            customer.Updatedby = Convert.ToInt64(userOpMap.UserID);
            customer.CustomerTypeId = Convert.ToInt32(customerData.Type);

            return dAL_Customer.UpdateCutsomer(customer);
        }

        public long CreateCustomer(CustomerData customerData, UserOpMap userOpMap)
        {
            DAL_Customer dAL_Customer = new DAL_Customer();
            Customer customer = new Customer();
            customer.Id = customerData.Id;
            customer.Name = customerData.Name;
            customer.EmailId = customerData.EmailID;
            customer.AddressLineOne = customerData.Addr1;
            customer.AddressLineTwo = customerData.Addr2;
            customer.ContactNumber = Convert.ToInt64(customerData.ContactNumber);
            customer.City = customerData.City;
            customer.State = customerData.State;
            customer.UpdatedOn = DateTime.Now;
            customer.Updatedby = Convert.ToInt64(userOpMap.UserID);
            customer.CustomerTypeId = Convert.ToInt32(customerData.Type);
            customer.IsActive = true;
            customer.CreatedBy = Convert.ToInt64(userOpMap.UserID);
            customer.Updatedby = Convert.ToInt64(userOpMap.UserID);
            customer.CreatedOn = DateTime.Now;
            return dAL_Customer.CreateCustomer(customer, userOpMap);
        }
    }
}
