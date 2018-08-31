using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportWPF.Model
{
    public class Transport 
    {
        public Transport(string key, List<DetailsTransport> value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public List<DetailsTransport> Value { get; set; }
    }


}
