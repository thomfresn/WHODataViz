using System.Collections.Generic;
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
            foreach (var code in dimension.code)
            {
                yield return new Indicator(code.label, code.display, code.url);
            }
        }
    }

    public class Indicator
    {
        private string label;
        private readonly string display;
        private string url;

        public Indicator(string label, string display, string url)
        {
            this.label = label;
            this.display = display;
            this.url = url;
        }

        public string Description => display;
    }
}