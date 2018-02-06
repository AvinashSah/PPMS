using PPMS.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPMS.Web
{
    public partial class ManageFuel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindFuelList();
        }

        private void BindFuelList()
        {
            string finalstring = "";
            List<Fuel> fuelList = new List<Fuel>();
            List<DailyFuelCost> dailyFuelCostList = new List<DailyFuelCost>();
            BAL.BAL_Fuel bAL_Fuel = new BAL.BAL_Fuel();
            fuelList = bAL_Fuel.GetFuelList();
            dailyFuelCostList = bAL_Fuel.GetDailyFuelCost();

            foreach (Fuel fuel in fuelList)
            {
                string htmlContent = "<tr>";
                htmlContent += "<td>" + Convert.ToString(fuel.Name) + "</td>";
                htmlContent += "<td>" + Convert.ToString(fuel.Type) + "</td>";
                htmlContent += "<td>" + Convert.ToString(fuel.Description) + "</td>";
                foreach (DailyFuelCost dailyFuelCost in dailyFuelCostList)
                {
                    if (dailyFuelCost.FuelTypeId == fuel.Id)
                    {
                        htmlContent += "<td>" + Convert.ToString(dailyFuelCost.CostPerLiter) + "</td>";
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                htmlContent += "</tr>";
                finalstring += htmlContent;
            }

            fuelListBody.Controls.Add(new Literal { Text = finalstring.ToString() });

        }
    }
}