using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTreeviewDrag.Entity
{
    public class ACLineSegments
    {
        public string _ACLineSegmentID { get; set; }
        public string _LineID { get; set; }
        public List<Towers> Towers { get; set; }
        public int node;
    }
}
