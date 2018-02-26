using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTreeviewDrag.Entity
{
    public class Voltages
    {
        public string _VoltageID { get; set; }
        public string _SubstationID { get; set; }
        public List<Bays> _Bays { get; set; }
        public List<Busbars> _Busbars { get; set; }
        public int node;
        public List<ConnectivityNodes> _ConnectivityNodes { get; set; }
    }
}
