using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WHODataViz.GHOAccessLib;

namespace WHODataViz.DataModel
{
    public class IndicatorsFinder
    {
        public static IEnumerable<Indicator> GetAllIndicators()
        {
            //TODO refactor
            string url = @"http://apps.who.int/gho/athena/api/GHO.json";
            GHOAthenaAPIAccessor athenaApiAccessor = new GHOAthenaAPIAccessor();
            Codes codes = athenaApiAccessor.GetCodes(url);
            Dimension dimension = codes.dimension.SingleOrDefault();
            Debug.Assert(dimension != null, nameof(dimension) + " != null");
            foreach (var code in dimension.code)
            {
                yield return new Indicator(code.label, code.display);
            }
        }
    }

    public class Indicator
    {
        private readonly string label;
        private readonly string display;

        public Indicator(string label, string display)
        {
            this.label = label;
            this.display = display;
        }

        public string Description => display;
        public string Code => label;
    }
}