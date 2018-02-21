using System;
using System.Collections.Generic;
using System.Linq;
using PPMS.ENTITIES;

namespace PPMS.DAL
{
    public class DAL_Customer
    {
        public List<Customer> GetCustomerList()
        {
            List<Customer> customerList = new List<Customer>();
            using (var dbContext = new ppmsEntities())
            {
                customerList = (from a in dbContext.Customers
                                where a.IsActive == true
                                select a).ToList();
            }
            return customerList;
        }

        public List<CustomerType> GetCustomerType()
        {
            List<CustomerType> customerType = new List<CustomerType>();
            //DateTime myDate = new DateTime();
            using (var dbContext = new ppmsEntities())
            {
                customerType = (from a in dbContext.CustomerTypes
                                where a.IsActive == true
                                select a).ToList();
            }
            return customerType;
        }

        public long UpdateCutsomer(Customer customerData)
        {
            using (var dbContext = new ppmsEntities())
            {
                Customer customer = new Customer();
                customer = (from a in dbContext.Customers
                            where a.IsActive == true && a.Id == customerData.Id
                            select a).FirstOrDefault();
                customer.EmailId = customerData.EmailId;
                customer.AddressLineOne = customerData.AddressLineOne;
                customer.AddressLineTwo = customerData.AddressLineTwo;
                customer.ContactNumber = Convert.ToInt64(customerData.ContactNumber);
                customer.City = customerData.City;
                customer.State = customerData.State;
                customer.UpdatedOn = DateTime.Now;
                customer.Updatedby = customerData.Updatedby;
                customer.CustomerTypeId = Convert.ToInt32(customerData.CustomerTypeId);

                dbContext.SaveChanges();
                return customerData.Id;
            }
        }

        public long CreateCustomer(Customer customer, UserOpMap userOpMap)
        {
            using (var dbContext = new ppmsEntities())
            {
                Customer customerData = new Customer();
                customerData = (from a in dbContext.Customers
                                where a.IsActive == true && a.Id == customer.Id && a.Name == customer.Name
                                select a).FirstOrDefault();
                if (customerData == null)
                {
                    try
                    {
                        dbContext.Customers.Add(customer);
                        dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                    return customer.Id;
                }
                else
                {
                    throw new Exception("Customer with same data already exist !");
                }
            }
        }
    }
}
