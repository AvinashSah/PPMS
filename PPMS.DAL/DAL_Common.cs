using PPMS.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPMS.DAL
{
    public class DAL_Common
    {
        public bool ValidateUserLogin(string username, string pass)
        {
            UserMaster userMaster = new UserMaster();
            using (var context = new ppmsEntities())
            {
                userMaster = (from a in context.UserMasters
                              where a.UserName == username && a.Password == pass
                              select a).FirstOrDefault();
            }
            if(userMaster!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
