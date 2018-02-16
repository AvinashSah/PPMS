using PPMS.BAL;
using PPMS.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace PPMS.Web
{
    /// <summary>
    /// Summary description for CommonService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CommonService : System.Web.Services.WebService
    {

        [ScriptMethod()]
        [WebMethod]
        public List<DropDownState> GetListOfStates()
        {
            BAL_Common bAL_Common = new BAL_Common();
            List<State> stateList = new List<State>();
            stateList = bAL_Common.GetStateListForDropDown();
            List<DropDownState> dropDownStateList = new List<DropDownState>();
            foreach (State state in stateList)
            {
                DropDownState dropDownState = new DropDownState();
                dropDownState.text = state.Name;
                dropDownState.Value = state.ID;
                dropDownStateList.Add(dropDownState);
            }
            return dropDownStateList;
        }

        [ScriptMethod()]
        [WebMethod]
        public List<DropDownCity> GetListOfCitiesByStates(string valueSelected)
        {
            List<DropDownCity> listDropDownCisty = new List<DropDownCity>();
            BAL_Common bAL_Common = new BAL_Common();
            List<City> cityList = new List<City>();
            cityList = bAL_Common.GetCityByStateIDForDropDown(valueSelected);

            foreach (City city in cityList)
            {
                DropDownCity dropDownCity = new DropDownCity();
                dropDownCity.StateID = city.StateID;
                dropDownCity.text = city.Name;
                dropDownCity.Value = city.ID;
                listDropDownCisty.Add(dropDownCity);
            }
            return listDropDownCisty;
        }
    }
}
