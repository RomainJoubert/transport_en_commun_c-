using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectTransportPublic

{
    public class FakeConnexion : IConnexion
    {
        public String ApiConnexion(string url)
        {
            return Resource1.jsonProximityLines;
        }
    }
}
