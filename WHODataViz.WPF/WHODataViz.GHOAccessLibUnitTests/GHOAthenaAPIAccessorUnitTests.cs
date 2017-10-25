﻿using System.Collections.Generic;
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

            const string expectedValue = "52.9";
            Facts facts = new GHOAthenaAPIAccessor().GetFacts(url);
            string actualValue = facts.fact.First(f => f.dim.YEAR == "1994" && f.dim.COUNTRY == @"Lao People's Democratic Republic").Value;
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}