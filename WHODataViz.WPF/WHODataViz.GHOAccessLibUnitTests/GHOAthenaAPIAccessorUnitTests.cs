using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WHODataViz.GHOAccessLib;

namespace WHODataViz.GHOAccessLibUnitTests
{
    [TestClass]
    public class GHOAthenaAPIAccessorUnitTests
    {
        [TestMethod]
        public void TestStuntedKidsInLaosWas52_9In1994()
        {
            const string expectedValue = "52.9";
            GHOAthenaAPIAccessor apiAccessor = new GHOAthenaAPIAccessor();
            Facts facts = apiAccessor.GetFactsAsync("MDG_0000000027").Result;
            string actualValue = facts.fact.First(f => f.dim.YEAR == "1994" && f.dim.COUNTRY == @"Lao People's Democratic Republic").Value;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestStuntedBoysInChileWas2_2In2008()
        {
            const string expectedValue = "2.2";
            Facts facts = new GHOAthenaAPIAccessor().GetFactsAsync("MDG_0000000027").Result;
            string actualValue = facts.fact.First(f => f.dim.YEAR == "2008" && f.dim.COUNTRY == @"Chile" && f.dim.SEX == "Male").Value;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestEmptyFactsIsReturnedWhenCodeIsIncorrect()
        {
            Facts facts = new GHOAthenaAPIAccessor().GetFactsAsync("MD_0000000027").Result;
            Assert.AreEqual(0, facts.fact.Count);
        }

        [TestMethod]
        public void TestStuntedKidsCodeIsMDG_0000000027()
        {
            const string expectedCode = "MDG_0000000027";
            Codes codes = new GHOAthenaAPIAccessor().GetCodesAsync().Result;
            Assert.IsNotNull(codes.dimension, "codes.dimension != null");
            Dimension dimension = codes.dimension.SingleOrDefault();
            Assert.IsNotNull(dimension);
            Code code = dimension.code.FirstOrDefault(c => c.display == "Children aged <5 years stunted (%)");
            Assert.IsNotNull(code);
            string actualCode = code.label;
            Assert.AreEqual(expectedCode, actualCode);
        }

    }
}
