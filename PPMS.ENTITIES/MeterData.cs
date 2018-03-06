using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPMS.ENTITIES
{
    public class MeterData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FuelType { get; set; }
        public string DayStartReading { get; set; }
        public string DayEndReading { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Description { get; set; }
        public int FuelTypeID { get; set; }

    }
}
