using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTreeviewDrag.Entity
{
    public class Substations
    {
        public string _SubstationID { get; set; }
        public string _SubstationName { get; set; }
        public string _SubGeographicalRegionsID { get; set; }

        public List<Voltages> _Voltages { get; set; }
        public List<Transfomers> _Transfomers { get; set; }
        public int node;
    }
}
