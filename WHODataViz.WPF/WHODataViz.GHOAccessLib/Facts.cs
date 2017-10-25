using System.Collections.Generic;

namespace WHODataViz.GHOAccessLib
{
    public class Facts
    {
        public IList<Dimension> dimension { get; set; }
        public IList<Fact> fact { get; set; } = new List<Fact>();
    }
}