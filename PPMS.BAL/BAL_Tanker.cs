using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPMS.ENTITIES;
using PPMS.DAL;

namespace PPMS.BAL
{
    public class BAL_Tanker
    {
        public List<Tanker> GetTankerList()
        {
            DAL_Tanker bAL_Tanker = new DAL_Tanker();
            return bAL_Tanker.GetTankerList();
        }

        public List<DailyTankerReading> GetDailyTankerReading()
        {
            DAL_Tanker bAL_Tanker = new DAL_Tanker();
            return bAL_Tanker.GetDailyTankerReading();
        }

    }
}
