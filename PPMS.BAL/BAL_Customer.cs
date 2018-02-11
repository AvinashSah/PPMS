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
    }
}
