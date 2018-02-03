using PPMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPMS.BAL
{
    public class BAL_Common
    {
        public bool ValidateUserLogin(string username, string pass)
        {
            DAL_Common dAL_Common = new DAL_Common();
            return dAL_Common.ValidateUserLogin(username, pass);
        }
    }
}
