using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WHODataViz.GHOAccessLib
{
    public class GHOAthenaAPIAccessor
    {
        public IEnumerable<Fact> GetFacts(string url)
        {
            return new ReadOnlyCollection<Fact>(new List<Fact>());
        }
    }
}