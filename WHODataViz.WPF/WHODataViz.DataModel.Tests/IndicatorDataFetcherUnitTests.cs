using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WHODataViz.DataModel.Tests
{
    [TestClass]
    public class IndicatorDataFetcherUnitTests
    {
        [TestMethod]
        public async Task TestStatisticsAreReturnedForStuntedKidsInSolomonIslands()
        {
            string code = "MDG_0000000027";
            IndicatorDataFetcher indicatorDataFetcher = new IndicatorDataFetcher();
            IndicatorDataItems indicatorDataItems = await indicatorDataFetcher.GetWHOStatistics(new Indicator(code, string.Empty));
            Assert.IsTrue(indicatorDataItems.Items.Any(s => s.Country == "Solomon Islands"));
        }
    }
}
