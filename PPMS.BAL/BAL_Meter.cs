using PPMS.ENTITIES;
using PPMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPMS.BAL
{
    public class BAL_Meter
    {
        public List<Meter> GetMeterList()
        {
            DAL_Meter dAL_Meter = new DAL_Meter();
            return dAL_Meter.GetMeterList();

        }

        public List<DailyMeterReading> GetDailyMeterReading()
        {
            DAL_Meter dAL_Meter = new DAL_Meter();
            return dAL_Meter.GetDailyMeterReading();
        }
    }
}
