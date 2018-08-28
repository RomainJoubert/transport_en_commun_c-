using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProjectTransportPublic;

namespace MyLibrary.Tests
{
    [TestClass()]
    public class DataDetailsTransportTests
    {
        [TestMethod()]
        public void GetDetailsLineTest()
        {
            FakeConnexion fake = new FakeConnexion();
            fake.resultatJson = Resource1.jsonDetailLine;
            DataDetailsTransport lb = new DataDetailsTransport(fake);
            DetailsTransport resultat = lb.GetDetailsLine("SEM:12");
            Assert.AreEqual(resultat.shortName, "12") ;
            Assert.IsTrue(resultat.color.Contains("009930"));
            Assert.IsTrue(resultat.longName.Contains("Eybens Maisons Neuves"));

        }
    }
}