using PPMS.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;

namespace PPMS.Web
{
    /// <summary>
    /// Summary description for FuelService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FuelService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod()]
        public List<FuelData> GetFuelData()
        {
            List<FuelData> list = new List<FuelData>();
            List<Fuel> fuelList = new List<Fuel>();
            List<DailyFuelCost> dailyFuelCostList = new List<DailyFuelCost>();
            BAL.BAL_Fuel bAL_Fuel = new BAL.BAL_Fuel();
            fuelList = bAL_Fuel.GetFuelList();
            dailyFuelCostList = bAL_Fuel.GetDailyFuelCost();
            foreach (Fuel fuel in fuelList)
            {
                FuelData fuelData = new FuelData();
                fuelData.Id = fuel.Id;
                fuelData.Name = fuel.Name;
                fuelData.Type = fuel.Type;
                fuelData.Description = fuel.Description;
                foreach (DailyFuelCost dailyFuelCost in dailyFuelCostList)
                {
                    if (dailyFuelCost.FuelTypeId == fuel.Id)
                    {
                        fuelData.CostPerLiter = dailyFuelCost.CostPerLiter;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                list.Add(fuelData);
            }
            return list;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string SubmitEditFuelData(FuelData FuelData)
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
                BAL.BAL_Fuel bAL_Fuel = new BAL.BAL_Fuel();
                long fuelID = bAL_Fuel.UpdateFuel(FuelData, userOpMap);
                entitySubmittedResponse.submited = true;
                entitySubmittedResponse.message = "Fuel submitted!";
                //return js.Serialize(entitySubmittedResponse);
                return js.Serialize("Fuel submitted!");

            }
            catch (Exception ex)
            {
                entitySubmittedResponse.submited = false;
                entitySubmittedResponse.message = string.Format("Error occured while generating Bill with message:{0}", ex.Message);
                //return js.Serialize(entitySubmittedResponse);
                return js.Serialize(string.Format("Error occured while generating Bill with message:{0}", ex.Message));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string SubmitCreateFuelData(FuelData FuelData)
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
                BAL.BAL_Fuel bAL_Fuel = new BAL.BAL_Fuel();
                long fuelID = bAL_Fuel.CreateFuel(FuelData, userOpMap);
                entitySubmittedResponse.submited = true;
                entitySubmittedResponse.message = "Fuel submitted!";
                return js.Serialize("Fuel Created");
            }
            catch (Exception ex)
            {
                entitySubmittedResponse.submited = false;
                entitySubmittedResponse.message = string.Format("Error occured while generating Bill with message:{0}", ex.Message);
                //return js.Serialize(entitySubmittedResponse);
                return js.Serialize(string.Format("Error occured while generating Bill with message:{0}", ex.Message));
            }
        }

        [WebMethod]
        [ScriptMethod()]
        public FuelData GetFuelDataByID(string fuelID)
        {
            FuelData fuelRetData = new FuelData();
            List<Fuel> fuelList = new List<Fuel>();
            List<DailyFuelCost> dailyFuelCostList = new List<DailyFuelCost>();
            BAL.BAL_Fuel bAL_Fuel = new BAL.BAL_Fuel();
            fuelList = bAL_Fuel.GetFuelList();
            dailyFuelCostList = bAL_Fuel.GetDailyFuelCost();
            foreach (Fuel fuel in fuelList)
            {
                if (Convert.ToString(fuel.Id) == fuelID)
                {
                    FuelData fuelData = new FuelData();
                    fuelData.Id = fuel.Id;
                    fuelData.Name = fuel.Name;
                    fuelData.Type = fuel.Type;
                    fuelData.Description = fuel.Description;
                    foreach (DailyFuelCost dailyFuelCost in dailyFuelCostList)
                    {
                        if (dailyFuelCost.FuelTypeId == fuel.Id)
                        {
                            fuelData.CostPerLiter = dailyFuelCost.CostPerLiter;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    fuelRetData = fuelData;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return fuelRetData;
        }
    }
}
