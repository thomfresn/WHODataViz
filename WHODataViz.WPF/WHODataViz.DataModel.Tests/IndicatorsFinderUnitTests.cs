using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WHODataViz.DataModel.Tests
{
    [TestClass]
    public class IndicatorsFinderUnitTests
    {
        [TestMethod]
        public async Task TestCodeForComplaintsAndSanctionsExists()
        {
            IndicatorsFinder indicatorsFinder = new IndicatorsFinder();
            var allIndicators = await indicatorsFinder.GetAllIndicatorsAsync();
            Assert.IsNotNull(allIndicators.First(x=>x.Description == "Up to date list of complaints and sanctions publicly available"));
        }

    }
}