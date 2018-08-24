using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport
{
    class Toolbox
    {
        public Dictionary<string, List<string>> removeDuplicate(List<BusStationObject> liste)
        {
            Dictionary<string, List<string>> myDictionary =
                new Dictionary<string, List<string>>();

            foreach (BusStationObject station in liste)
            {
                try
                {
                    if (!myDictionary.ContainsKey(station.name))
                    {
                        myDictionary.Add(station.name, station.lines);
                    }
                    else
                    {
                        foreach (string line in station.lines)
                        {
                            if (!myDictionary[station.name].Contains(line))
                            {
                                myDictionary[station.name].Add(line);
                            }
                        }
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("An element with Key = " + station.name + " already exists.");
                }
            }
            return myDictionary;
        }
     }
}
