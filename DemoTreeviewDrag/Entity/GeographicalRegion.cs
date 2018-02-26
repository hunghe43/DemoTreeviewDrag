using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTreeviewDrag.Entity
{
    public class GeographicalRegion
    {
        public string _GeographicalRegionName { get; set; }
        public string _GeographicalRegionID { get; set; }
        public int node;

        public List<SubGeographicalRegions> _SubGeographicalRegions { get; set; }
    }
}
