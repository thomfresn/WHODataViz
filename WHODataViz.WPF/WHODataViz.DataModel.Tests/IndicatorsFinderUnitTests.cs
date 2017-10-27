using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WHODataViz.DataModel.Tests
{
    [TestClass]
    public class IndicatorsFinderUnitTests
    {
        [TestMethod]
        public void TestCodeForComplaintsAndSanctionsExists()
        {
            var allIndicators = IndicatorsFinder.GetAllIndicatorsAsync().Result;
            Assert.IsNotNull(allIndicators.First(x=>x.Description == "Up to date list of complaints and sanctions publicly available"));
        }

    }
}