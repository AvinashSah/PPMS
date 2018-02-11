using PPMS.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPMS.Web
{
    public partial class ManageTanks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindTankerList();
        }

        private void BindTankerList()
        {
            string finalstring = "";
            List<Tanker> tankerList = new List<Tanker>();
            List<DailyTankerReading> dailyTankerReadingList = new List<DailyTankerReading>();
            BAL.BAL_Tanker bAL_Tanker = new BAL.BAL_Tanker();
            tankerList = bAL_Tanker.GetTankerList();
            dailyTankerReadingList = bAL_Tanker.GetDailyTankerReading();

            foreach (Tanker tanker in tankerList)
            {
                string htmlContent = "<tr>";
                htmlContent += "<td>" + Convert.ToString(tanker.Name) + "</td>";
                htmlContent += "<td>" + Convert.ToString(tanker.FuelTypeId) + "</td>";
                htmlContent += "<td>" + Convert.ToString(tanker.Size) + "</td>";
                foreach (DailyTankerReading dailyTankerReading in dailyTankerReadingList)
                {
                    if (dailyTankerReading.TankerId == tanker.Id)
                    {
                        htmlContent += "<td>" + Convert.ToString(dailyTankerReading.DailyStartReading) + "</td>";
                        htmlContent += "<td>" + Convert.ToString(dailyTankerReading.DailyEndReading) + "</td>";
                        htmlContent += "<td>" + Convert.ToString(dailyTankerReading.CreatedOn) + "</td>";
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                htmlContent += "<td>" + Convert.ToString(tanker.Description) + "</td>";
                htmlContent += "<td>" + "<button id=\"itemDelete\" class=\"btn btn-success nopadding\" style=\"padding:2px\"><i class=\"fa fa-edit\"></i></button>";
                htmlContent += "<button id=\"itemDelete\" class=\"btn btn-danger nopadding\" style=\"padding:2px\"><i class=\"fa fa-remove\"></i></button>" + "</td>";
                htmlContent += "</tr>";
                finalstring += htmlContent;
            }

            tankerListBody.Controls.Add(new Literal { Text = finalstring.ToString() });

        }
    }
}