using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
