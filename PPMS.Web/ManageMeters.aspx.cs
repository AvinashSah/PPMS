using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PPMS.ENTITIES;

namespace PPMS.Web
{
    public partial class ManageMeters : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindMeterList();
        }

        private void BindMeterList()
        {
            string finalstring = "";
            List<Meter> meterList = new List<Meter>();
            List<DailyMeterReading> dailyMeterReadingList = new List<DailyMeterReading>();
            BAL.BAL_Meter bAL_Meter = new BAL.BAL_Meter();
            meterList = bAL_Meter.GetMeterList();
            dailyMeterReadingList = bAL_Meter.GetDailyMeterReading();

            foreach (Meter meter in meterList)
            {
                string htmlContent = "<tr>";
                htmlContent += "<td>" + Convert.ToString(meter.Name) + "</td>";
                htmlContent += "<td>" + Convert.ToString(meter.FuelTypeId) + "</td>";
                foreach (DailyMeterReading dailyMeterReading in dailyMeterReadingList)
                {
                    if (dailyMeterReading.MeterId == meter.Id)
                    {
                        htmlContent += "<td>" + Convert.ToString(dailyMeterReading.DayStartReading) + "</td>";
                        htmlContent += "<td>" + Convert.ToString(dailyMeterReading.DayEndReading) + "</td>";
                        htmlContent += "<td>" + Convert.ToString(dailyMeterReading.CreatedOn) + "</td>";
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                htmlContent += "<td>" + Convert.ToString(meter.Description) + "</td>";
                htmlContent += "<td>" + "<button id=\"itemDelete\" class=\"btn btn-success nopadding\" style=\"padding:2px\"><i class=\"fa fa-edit\"></i></button>";
                htmlContent += "<button id=\"itemDelete\" class=\"btn btn-danger nopadding\" style=\"padding:2px\"><i class=\"fa fa-remove\"></i></button>" + "</td>";
                htmlContent += "</tr>";
                finalstring += htmlContent;
            }

            MeterListBody.Controls.Add(new Literal { Text = finalstring.ToString() });

        }
    }
}