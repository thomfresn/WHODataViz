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
            IndicatorDataItems indicatorDataItems = indicatorDataFetcher.GetWHOStatistics(new Indicator(code, string.Empty)).Result;
            Assert.IsTrue(indicatorDataItems.Items.Any(s => s.Country == "Solomon Islands"));
        }
    }
}
