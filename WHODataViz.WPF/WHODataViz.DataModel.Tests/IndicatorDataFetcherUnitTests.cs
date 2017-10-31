using System.Collections.Generic;
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
            IndicatorDataFetcher indicatorDataFetcher = new IndicatorDataFetcher();
            IList<WHOStatistics> statistics = indicatorDataFetcher.GetWHOStatistics(code).Result;
            Assert.IsTrue(statistics.Any(s => s.Country == "Solomon Islands"));
        }
    }
}
