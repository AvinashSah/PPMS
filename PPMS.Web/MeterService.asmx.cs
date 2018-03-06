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
    /// Summary description for MeterService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MeterService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod()]
        public List<MeterData> GetMeterData()
        {
            List<MeterData> list = new List<MeterData>();
            List<Meter> meterList = new List<Meter>();
            List<DailyMeterReading> dailyMeterReadingList = new List<DailyMeterReading>();
            Fuel fuel = new Fuel();
            BAL.BAL_Meter bAL_Meter = new BAL.BAL_Meter();
            meterList = bAL_Meter.GetMeterList();
            dailyMeterReadingList = bAL_Meter.GetDailyMeterReading();
            foreach (Meter meter in meterList)
            {
                MeterData meterData = new MeterData();
                meterData.Id = meter.Id;
                meterData.Name = meter.Name;
                meterData.Description = meter.Description;
                meterData.FuelTypeID = meter.FuelTypeId;

                fuel = bAL_Meter.GetFuelByFuelID(meterData.FuelTypeID);
                meterData.FuelType = fuel.Type;

                foreach (DailyMeterReading dailyMeterReading in dailyMeterReadingList)
                {
                    if (dailyMeterReading.MeterId == meter.Id)
                    {
                        meterData.DayStartReading = dailyMeterReading.DayStartReading;
                        meterData.DayEndReading = dailyMeterReading.DayEndReading;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                list.Add(meterData);
            }
            return list;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string SubmitCreateMeterData(MeterData MeterData)
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
                BAL.BAL_Meter bAL_Meter = new BAL.BAL_Meter();
                long meterID = bAL_Meter.CreateMeter(MeterData, userOpMap);
                entitySubmittedResponse.submited = true;
                entitySubmittedResponse.message = "Meter Data Created Successfully!";
                return js.Serialize("Meter Data Created Successfully");
            }
            catch (Exception ex)
            {
                entitySubmittedResponse.submited = false;
                entitySubmittedResponse.message = string.Format("Error occured while creating meter with message:{0}", ex.Message);
                return js.Serialize(string.Format("Error occured while creating meter with message:{0}", ex.Message));
            }
        }

        [WebMethod]
        [ScriptMethod()]
        public List<FuelData> GetFuelList()
        {
            List<FuelData> list = new List<FuelData>();
            List<Fuel> fuelList = new List<Fuel>();
            BAL.BAL_Meter bAL_Meter = new BAL.BAL_Meter();
            fuelList = bAL_Meter.GetFuelList();
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
        public MeterData GetMeterDataByID(string meterID)
        {
            MeterData meterRetData = new MeterData();
            List<Meter> meterList = new List<Meter>();
            List<DailyMeterReading> dailyMeterReadingList = new List<DailyMeterReading>();
            Fuel fuel = new Fuel();
            BAL.BAL_Meter bAL_Meter = new BAL.BAL_Meter();
            meterList = bAL_Meter.GetMeterList();
            dailyMeterReadingList = bAL_Meter.GetDailyMeterReading();

            foreach (Meter meter in meterList)
            {
                if (Convert.ToString(meter.Id) == meterID)
                {
                    MeterData meterData = new MeterData();
                    meterData.Id = meter.Id;
                    meterData.Name = meter.Name;
                    meterData.Description = meter.Description;
                    meterData.FuelTypeID = meter.FuelTypeId;
                    fuel = bAL_Meter.GetFuelByFuelID(meterData.FuelTypeID);
                    meterData.FuelType = fuel.Type;
                    foreach (DailyMeterReading dailyMeterReading in dailyMeterReadingList)
                    {
                        if (dailyMeterReading.MeterId == meter.Id)
                        {
                            meterData.DayStartReading = dailyMeterReading.DayStartReading;
                            meterData.DayEndReading = dailyMeterReading.DayEndReading;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    meterRetData = meterData;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return meterRetData;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string SubmitEditMeterData(MeterData MeterData)
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
                BAL.BAL_Meter bAL_Meter = new BAL.BAL_Meter();
                long meterID = bAL_Meter.UpdateMeter(MeterData, userOpMap);
                entitySubmittedResponse.submited = true;
                entitySubmittedResponse.message = "Meter Data Updated Successfully!";
                return js.Serialize("Meter Data Updated Successfully!");

            }
            catch (Exception ex)
            {
                entitySubmittedResponse.submited = false;
                entitySubmittedResponse.message = string.Format("Error occured while updating meter data with message:{0}", ex.Message);
                return js.Serialize(string.Format("Error occured while updating meter data with message:{0}", ex.Message));
            }
        }
    }
}
