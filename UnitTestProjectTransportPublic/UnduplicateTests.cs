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
    public class UnduplicateTests
    {
        [TestMethod()]
        public void removeDuplicateTest()
        {
            String longitude = "5.726744267129334";
            String latitude = "45.18521853612248";
            Int32 distance = 400;

            //remove doublons
            FakeConnexion fake = new FakeConnexion();
            fake.resultatJson = Resource1.jsonProximityLines;
            Unduplicate lb = new Unduplicate(fake);
            Dictionary<string, List<string>> resultat = lb.removeDuplicate(latitude, longitude, distance);
            Assert.AreEqual(1 ,resultat.Count);
            Assert.IsTrue(resultat.ContainsKey("GRENOBLE, CASERNE DE BONNE"));
            Assert.AreEqual(resultat["GRENOBLE, CASERNE DE BONNE"].Count, 3);
            Assert.IsTrue(resultat["GRENOBLE, CASERNE DE BONNE"][0] == "SEM:13");
            Assert.IsTrue(resultat["GRENOBLE, CASERNE DE BONNE"][1].Equals("SEM:16"));
            Assert.AreEqual(resultat["GRENOBLE, CASERNE DE BONNE"][2], "SEM:C4");
        }
    }
}