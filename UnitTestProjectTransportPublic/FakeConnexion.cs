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
        public String resultatJson { get; set; }
        public String ApiConnexion(string url)
        {
            return resultatJson;
        }
    }
}
