using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTreeviewDrag.Entity
{
    public class Bays
    {
        public string _VoltageID { get; set; }
        public string _BayID { get; set; }
        public int node;
        public Breakers Breakers { get; set; }
        public Disconnectors Disconnectors { get; set; }
        public GroundDisconnectors GroundDisconnectors { get; set; }
        public SeriesCompensators SeriesCompensators { get; set; }
        public Fuses Fuses { get; set; }
        public ShuntCompensators ShuntCompensators { get; set; }
        public Generators Generators { get; set; }
        public SurgeArresters SurgeArresters { get; set; }
        public VoltageTransformers VoltageTransformers { get; set; }
        public CurrentTransformers CurrentTransformers { get; set; }
        public Relays Relays { get; set; }
        public Meters Meters { get; set; }
        public EnergySources EnergySources { get; set; }
        public EnergyConsumers EnergyConsumers { get; set; }
    }
}
