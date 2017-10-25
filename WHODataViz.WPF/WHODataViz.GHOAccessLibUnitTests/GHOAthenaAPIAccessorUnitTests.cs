using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WHODataViz.GHOAccessLib;

namespace WHODataViz.GHOAccessLibUnitTests
{
    [TestClass]
    public class GHOAthenaAPIAccessorUnitTests
    {
        [TestMethod]
        public void TestStuntedKidsInLaosWas52_9In1994()
        {
            string url = @"http://apps.who.int/gho/athena/api/GHO/MDG_0000000027.json?profile=simple";

            const string expectedValue = "52.9f";
            IEnumerable<Fact> facts = new GHOAthenaAPIAccessor().GetFacts(url);
            string actualValue = facts.First(f => f.Dim.Year == "1994" && f.Dim.Country == @"Lao People's Democratic Republic").Value;
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
