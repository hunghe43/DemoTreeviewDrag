using DemoTreeviewDrag.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTreeviewDrag
{
    public class LoadData
    {
        //GeographicalRegion
        public List<GeographicalRegion> ListGeographicalRegion()
        {
            var list = new List<GeographicalRegion>();
            GeographicalRegion obj;
            for (int i = 0; i <= 1; i++)
            {
                obj = new GeographicalRegion();
                obj._GeographicalRegionID = i.ToString();
                obj._GeographicalRegionName = "PCQuangNgai " + i.ToString();
                obj._SubGeographicalRegions = ListSubGeographicalRegion();
                list.Add(obj);
            }
            return list;
        }

        //SubGeographicalRegions
        public List<SubGeographicalRegions> ListSubGeographicalRegion()
        {
            var list = new List<SubGeographicalRegions>();
            SubGeographicalRegions obj;
            for (int i = 0; i <= 3; i++)
            {
                obj = new SubGeographicalRegions();
                obj._GeographicalRegionID = "0";
                obj._SubGeographicalRegionsID = i.ToString();
                obj._Substations = ListSubstation();
                obj._Lines = ListLines();
                list.Add(obj);
            }
            return list;
        }
        //Lines
        public List<Lines> ListLines()
        {
            var list = new List<Lines>();
            Lines obj;
            for (int i = 0; i <= 3; i++)
            {
                obj = new Lines();
                obj._LineName = "Line Name" + i.ToString();
                obj._SubGeographicalRegionsID = "0";
                obj._LineID = i.ToString();
                obj.ACLineSegments = ListACLineSegments();
                obj.ConnectivityNodes = ListConnectivityNodes();
                list.Add(obj);
            }
            return list;
        }
        //substation
        public List<Substations> ListSubstation()
        {
            var list = new List<Substations>();
            Substations obj;
            for (int i = 0; i <= 3; i++)
            {
                obj = new Substations();
                obj._SubGeographicalRegionsID = "0";
                obj._SubstationID = i.ToString();
                obj._SubstationName = "Subtations name " + i.ToString();
                obj._Voltages = ListVoltages();
                obj._Transfomers = ListTransfomers();
                list.Add(obj);
            }
            return list;
        }
        //ACLineSegment
        public List<ACLineSegments> ListACLineSegments()
        {
            var list = new List<ACLineSegments>();
            ACLineSegments obj;
            for (int i = 0; i <= 3; i++)
            {
                obj = new ACLineSegments();
                obj._LineID = "0";
                obj._ACLineSegmentID = i.ToString();
                obj.Towers = ListTowers();
                list.Add(obj);
            }
            return list;
        }
        //Towers
        public List<Towers> ListTowers()
        {
            var list = new List<Towers>();
            Towers obj;
            for (int i = 0; i <= 3; i++)
            {
                obj = new Towers();
                obj._ACLineSegmentID = "0";
                obj._TowerID = i.ToString();
                list.Add(obj);
            }
            return list;
        }

        //ConnectivityNodes
        public List<ConnectivityNodes> ListConnectivityNodes()
        {
            var list = new List<ConnectivityNodes>();
            ConnectivityNodes obj;
            for (int i = 0; i <= 3; i++)
            {
                obj = new ConnectivityNodes();
                obj._ConnectivityNodeID = i.ToString();
                obj._VoltageID = "0";
                obj._LineID = "0";
                list.Add(obj);
            }
            return list;
        }
        //voltage
        public List<Voltages> ListVoltages()
        {
            var list = new List<Voltages>();
            Voltages obj;
            for (int i = 0; i <= 3; i++)
            {
                obj = new Voltages();
                obj._VoltageID = i.ToString();
                obj._SubstationID = "0";
                obj._ConnectivityNodes = ListConnectivityNodes();
                obj._Bays = ListBays();
                obj._Busbars = ListBusbars();
                list.Add(obj);
            }
            return list;
        }
        //tranfer
        public List<Transfomers> ListTransfomers()
        {
            var list = new List<Transfomers>();
            Transfomers obj;
            for (int i = 0; i <= 3; i++)
            {
                obj = new Transfomers();
                obj._SubstationID = "0";
                obj._TransfomerID = i.ToString();
                list.Add(obj);
            }
            return list;
        }
        //Bays
        public List<Bays> ListBays()
        {
            var list = new List<Bays>();
            Bays obj;
            for (int i = 0; i <= 3; i++)
            {
                obj = new Bays();
                obj._VoltageID = "0";
                obj._BayID = i.ToString();
                obj.VoltageTransformers = new VoltageTransformers();
                obj.SurgeArresters = new SurgeArresters();
                obj.ShuntCompensators = new ShuntCompensators();
                obj.SeriesCompensators = new SeriesCompensators();
                //...vvv
                list.Add(obj);
            }
            return list;
        }
        //bubars
        public List<Busbars> ListBusbars()
        {
            var list = new List<Busbars>();
            Busbars obj;
            for (int i = 0; i <= 3; i++)
            {
                obj = new Busbars();
                obj._VoltageID = "0";
                obj._BusbarID = i.ToString();
                list.Add(obj);
            }
            return list;
        }

    }
}
