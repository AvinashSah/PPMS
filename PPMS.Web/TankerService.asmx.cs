using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;
using PPMS.ENTITIES;

namespace PPMS.Web
{
    /// <summary>
    /// Summary description for TankerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]
    public class TankerService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod()]
        public List<TankerData> GetTankerData()
        {
            List<TankerData> list = new List<TankerData>();
            List<Tanker> tankerList = new List<Tanker>();
            List<DailyTankerReading> dailyTankerReadingList = new List<DailyTankerReading>();
            Fuel fuel = new Fuel();
            BAL.BAL_Tanker bAL_Tanker = new BAL.BAL_Tanker();
            tankerList = bAL_Tanker.GetTankerList();
            dailyTankerReadingList = bAL_Tanker.GetDailyTankerReading();
            foreach (Tanker tanker in tankerList)
            {
                TankerData tankerData = new TankerData();
                tankerData.Id = tanker.Id;
                tankerData.Name = tanker.Name;
                tankerData.Size = tanker.Size;
                tankerData.Description = tanker.Description;
                tankerData.FuelTypeID = tanker.FuelTypeId;
                tankerData.Date = tanker.CreatedOn;

                fuel = bAL_Tanker.GetFuelByFuelID(tankerData.FuelTypeID);
                tankerData.FuelType = fuel.Type;

                foreach (DailyTankerReading dailyTankerReading in dailyTankerReadingList)
                {
                    if (dailyTankerReading.TankerId == tanker.Id)
                    {
                        tankerData.DayStartReading = dailyTankerReading.DailyStartReading;
                        tankerData.DayEndReading = dailyTankerReading.DailyEndReading;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                list.Add(tankerData);
            }
            return list;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string SubmitCreateTankerData(TankerData TankerData)
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
                BAL.BAL_Tanker bAL_Tanker = new BAL.BAL_Tanker();
                long tankerID = bAL_Tanker.CreateTanker(TankerData, userOpMap);
                entitySubmittedResponse.submited = true;
                entitySubmittedResponse.message = "Tanker Data Created Successfully!";
                return js.Serialize("Tanker Data Created Successfully");
            }
            catch (Exception ex)
            {
                entitySubmittedResponse.submited = false;
                entitySubmittedResponse.message = string.Format("Error occured while creating tanker with message:{0}", ex.Message);
                return js.Serialize(string.Format("Error occured while creating tanker with message:{0}", ex.Message));
            }
        }

        [WebMethod]
        [ScriptMethod()]
        public List<FuelData> GetFuelList()
        {
            List<FuelData> list = new List<FuelData>();
            List<Fuel> fuelList = new List<Fuel>();
            BAL.BAL_Tanker bAL_Tanker = new BAL.BAL_Tanker();
            fuelList = bAL_Tanker.GetFuelList();
            foreach (Fuel fuel in fuelList)
            {
                FuelData fuelData = new FuelData();
                fuelData.Id = fuel.Id;
                fuelData.Type = fuel.Type;
                list.Add(fuelData);
            }
            return list;
        }

        [WebMethod]
        [ScriptMethod()]
        public TankerData GetTankerDataByID(string tankerID)
        {
            TankerData tankerRetData = new TankerData();
            List<Tanker> tankerList = new List<Tanker>();
            List<DailyTankerReading> dailyTankerReadingList = new List<DailyTankerReading>();
            Fuel fuel = new Fuel();
            BAL.BAL_Tanker bAL_Tanker = new BAL.BAL_Tanker();
            tankerList = bAL_Tanker.GetTankerList();
            dailyTankerReadingList = bAL_Tanker.GetDailyTankerReading();

            foreach (Tanker tanker in tankerList)
            {
                if (Convert.ToString(tanker.Id) == tankerID)
                {
                    TankerData tankerData = new TankerData();
                    tankerData.Id = tanker.Id;
                    tankerData.Name = tanker.Name;
                    tankerData.Size = tanker.Size;
                    tankerData.Description = tanker.Description;
                    tankerData.FuelTypeID = tanker.FuelTypeId;
                    fuel = bAL_Tanker.GetFuelByFuelID(tankerData.FuelTypeID);
                    tankerData.FuelType = fuel.Type;
                    foreach (DailyTankerReading dailyTankerReading in dailyTankerReadingList)
                    {
                        if (dailyTankerReading.TankerId == tanker.Id)
                        {
                            tankerData.DayStartReading = dailyTankerReading.DailyStartReading;
                            tankerData.DayEndReading = dailyTankerReading.DailyEndReading;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    tankerRetData = tankerData;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return tankerRetData;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string SubmitEditTankerData(TankerData TankerData)
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
                BAL.BAL_Tanker bAL_Tanker = new BAL.BAL_Tanker();
                long tankerID = bAL_Tanker.UpdateTanker(TankerData, userOpMap);
                entitySubmittedResponse.submited = true;
                entitySubmittedResponse.message = "Tanker Data Updated Successfully!";
                //return js.Serialize(entitySubmittedResponse);
                return js.Serialize("Tanker Data Updated Successfully!");

            }
            catch (Exception ex)
            {
                entitySubmittedResponse.submited = false;
                entitySubmittedResponse.message = string.Format("Error occured while updating tanker data with message:{0}", ex.Message);
                return js.Serialize(string.Format("Error occured while updating tanker data with message:{0}", ex.Message));
            }
        }
    }
}
