using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TruckInfoSampleData
    {
        public static IEnumerable<TruckInfo> GetSampleData()
        {
            return new TruckInfo[]
            {
                new TruckInfo() { ID = "1", Name = "Taco Talent", Style = "Mexican" },
                new TruckInfo() { ID = "2", Name = "Cake Shack", Style = "Desserts" },
                new TruckInfo() { ID = "3", Name = "Ice Heaven", Style = "Cold Drinks" },
            };
        }
    }
}
