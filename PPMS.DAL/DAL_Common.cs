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
            if (userMaster != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public UserMaster GetUserdetailsByUsernamePass(string username, string passWord)
        {
            UserMaster userMaster = new UserMaster();
            using (var context = new ppmsEntities())
            {
                userMaster = (from a in context.UserMasters
                              where a.UserName == username && a.Password == passWord
                              select a).FirstOrDefault();
            }
            return userMaster;
        }

        public string GetUserRole(long userID)
        {
            string role = string.Empty;
            using (var context = new ppmsEntities())
            {
                var userRoleMapping = (from a in context.UserRoleMappings
                                       where a.UserId == userID
                                       select a).FirstOrDefault();

                var rolemaster = (from a in context.RoleMasters
                                  where a.Id == userRoleMapping.RoleId
                                  select a).FirstOrDefault();
                if (rolemaster != null)
                {
                    role = rolemaster.RoleName;
                }
            }
            return role;
        }

        public UserMaster GetUserdetailsByUsernameAndRole(string name, string userRole)
        {
            UserMaster userMaster = new UserMaster();
            using (var context = new ppmsEntities())
            {
                userMaster = (from a in context.UserMasters
                              where a.UserName == name
                              select a).FirstOrDefault();

                var userRoleMapping = (from a in context.UserRoleMappings
                                       where a.UserId == userMaster.Id
                                       select a).FirstOrDefault();


                var rolemaster = (from a in context.RoleMasters
                                  where a.Id == userRoleMapping.RoleId
                                  select a).FirstOrDefault();

                if (string.Equals(rolemaster.RoleName, userRole, StringComparison.InvariantCultureIgnoreCase))
                {
                    return userMaster;
                }
                else
                {
                    return null;
                }
            }

        }

        public List<Operations> GetOperationListForUser(int userId)
        {
            List<Operations> opList = new List<Operations>();
            using (var context = new ppmsEntities())
            {
                var userRoleMapping = (from a in context.UserRoleMappings
                                       where a.UserId == userId
                                       select a).FirstOrDefault();

                var rolemaster = (from a in context.RoleMasters
                                  where a.Id == userRoleMapping.RoleId
                                  select a).FirstOrDefault();
                List<RoleOperationMapping> roleOpMapping = new List<RoleOperationMapping>();
                roleOpMapping = (from a in context.RoleOperationMappings
                                 where a.RoleId == userRoleMapping.RoleId
                                 select a).ToList();
                foreach (RoleOperationMapping opMapp in roleOpMapping)
                {
                    Operations op = new Operations();
                    OperationMaster opm = new OperationMaster();
                    opm = (from a in context.OperationMasters
                           where a.Id == opMapp.OperationId
                           select a).FirstOrDefault();

                    if (opm != null)
                    {
                        op.OperationName = opm.OperationName;
                        opList.Add(op);
                    }
                }

            }
            return opList;
        }

        public List<State> GetStateList()
        {
            List<State> listSate = new List<State>();
            using (var context = new ppmsEntities())
            {
                listSate = (from a in context.States
                            where a.Name != null
                            select a).ToList();
            }

            return listSate;

        }

        public List<City> GetCityByStateID(string selectedState)
        {
            List<City> listCity = new List<City>();
            int id = Convert.ToInt32(selectedState);
            using (var context = new ppmsEntities())
            {
                listCity = (from a in context.Cities
                            where a.StateID == id
                            select a).ToList();
            }
            return listCity;
        }

    }
}
