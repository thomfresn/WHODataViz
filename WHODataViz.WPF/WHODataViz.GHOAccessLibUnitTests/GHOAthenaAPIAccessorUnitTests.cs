using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Serilog;
using Serilog.Core;
using WHODataViz.GHOAccessLib;

namespace WHODataViz.GHOAccessLibUnitTests
{
    [TestClass]
    public class GHOAthenaAPIAccessorUnitTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default); 
            SimpleIoc.Default.Register(CreateLogger);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            SimpleIoc.Default.Unregister<ILogger>();
        }

        private ILogger CreateLogger()
        {
            //Load configure for Serilog logger (https://github.com/serilog/serilog)
            Logger logger = new LoggerConfiguration().WriteTo.Debug().CreateLogger();
            Log.Logger = logger;
            return Log.Logger;
        }

        [TestMethod]
        public async Task TestStuntedKidsInLaosWas52_9In1994() 
        {
            const string expectedValue = "52.9";
            GHOAthenaAPIAccessor apiAccessor = new GHOAthenaAPIAccessor();
            Facts facts = await apiAccessor.GetFactsAsync("MDG_0000000027");
            string actualValue = facts.fact.First(f => f.dim.YEAR == "1994" && f.dim.COUNTRY == @"Lao People's Democratic Republic").Value;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public async Task TestStuntedBoysInChileWas2_2In2008()
        {
            const string expectedValue = "2.2";
            Facts facts = await new GHOAthenaAPIAccessor().GetFactsAsync("MDG_0000000027");
            string actualValue = facts.fact.First(f => f.dim.YEAR == "2008" && f.dim.COUNTRY == @"Chile" && f.dim.SEX == "Male").Value;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public async Task TestEmptyFactsIsReturnedWhenCodeIsIncorrect()
        {
            Facts facts = await new GHOAthenaAPIAccessor().GetFactsAsync("MD_0000000027");
            Assert.AreEqual(0, facts.fact.Count);
        }

        [TestMethod]
        public async Task TestStuntedKidsCodeIsMDG_0000000027()
        {
            const string expectedCode = "MDG_0000000027";
            Codes codes = await new GHOAthenaAPIAccessor().GetCodesAsync();
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
