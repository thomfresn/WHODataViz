using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WHODataViz.DataModel.Tests
{
    [TestClass]
    public class IndicatorDataFetcherUnitTests
    {
        [TestMethod]
        public void TestStatisticsAreReturnedForStuntedKidsInSolomonIslands()
        {
            string code = "MDG_0000000027";
            Assert.IsTrue(IndicatorDataFetcher.GetWHOStatistics(code).Any(s => s.Country == "Solomon Islands"));
        }
    }
}
