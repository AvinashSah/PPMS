using PPMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPMS.ENTITIES;
using System.Security.Cryptography;
using System.IO;

namespace PPMS.BAL
{
    public class BAL_Common
    {
        public bool ValidateUserLogin(string username, string pass)
        {
            DAL_Common dAL_Common = new DAL_Common();
            return dAL_Common.ValidateUserLogin(username, pass);
        }

        public UserMaster GetUserdetailsByUsernamePass(string username, string passWord)
        {
            DAL_Common dAL_Common = new DAL_Common();
            return dAL_Common.GetUserdetailsByUsernamePass(username, passWord);
        }

        public string GetUserRole(long userID)
        {
            DAL_Common dAL_Common = new DAL_Common();
            return dAL_Common.GetUserRole(userID);
        }

        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public UserOpMap GetUserOperationMapping(string name, string userRole)
        {
            UserOpMap userOpMap = new UserOpMap();
            UserMaster userMaster = new UserMaster();
            DAL_Common dAL_Common = new DAL_Common();
            userMaster = dAL_Common.GetUserdetailsByUsernameAndRole(name, userRole);
            if (userMaster != null)
            {
                List<Operations> operations = new List<Operations>();
                operations = dAL_Common.GetOperationListForUser(userMaster.Id);
                if (operations != null)
                {
                    userOpMap.Username = userMaster.UserName;
                    userOpMap.UserID = Convert.ToString(userMaster.Id);
                    userOpMap.UserRoleName = userRole;
                    foreach (Operations op in operations)
                    {
                        userOpMap.OperationsList = operations;
                    }
                }
            }
            return userOpMap;
        }

        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public List<State> GetStateListForDropDown()
        {
            List<State> listSate = new List<State>();
            DAL_Common dAL_Common = new DAL_Common();
            listSate = dAL_Common.GetStateList();
            State state = new State();
            state.Name = "--Select State--";
            state.ID = 0;
            listSate.Add(state);
            return listSate;
        }

        public List<City> GetCityByStateIDForDropDown(string selectedState)
        {
            List<City> listCity = new List<City>();
            DAL_Common dAL_Common = new DAL_Common();
            listCity = dAL_Common.GetCityByStateID(selectedState);
            City state = new City();
            state.Name = "--Select City--";
            state.ID = 0;
            listCity.Add(state);
            return listCity;
        }
    }
}
