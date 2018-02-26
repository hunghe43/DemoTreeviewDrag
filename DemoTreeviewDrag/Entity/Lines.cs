using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTreeviewDrag.Entity
{
    // (danh sách xuất tuyến)
    public class Lines
    {
        //(EquipmentContainer)
        public string _LineName { get; set; }
        public string _LineID { get; set; }
        public string _SubGeographicalRegionsID { get; set; }
        public List<ACLineSegments> ACLineSegments { get; set; }
        public int node;
        public List<ConnectivityNodes> ConnectivityNodes { get; set; }
    }
}
