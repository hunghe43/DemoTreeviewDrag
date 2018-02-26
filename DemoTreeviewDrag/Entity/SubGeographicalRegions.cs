using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTreeviewDrag.Entity
{
    //cao the
    public class SubGeographicalRegions
    {
        public string _SubGeographicalRegionsID { get; set; }
        public string _GeographicalRegionID { get; set; }
        public List<Substations> _Substations { get; set; }
        public int node;
        public List<Lines> _Lines { get; set; }
    }
}
