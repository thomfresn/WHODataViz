using System.Collections.Generic;

namespace WHODataViz.GHOAccessLib
{
    public class Dim
    {
        public string REGION { get; set; }
        public string GHO { get; set; }
        public string DATASOURCE { get; set; }
        public string YEAR { get; set; }
        public string SEX { get; set; }
        public string COUNTRY { get; set; }
        public string PUBLISHSTATE { get; set; }
    }

    public class Dimension
    {
        public string label { get; set; }
        public string display { get; set; }
        public bool isMeasure { get; set; }
        public IList<Code> code { get; set; }
    }

    public class Code
    {
        public string label { get; set; }
        public string display { get; set; }
        public int display_sequence { get; set; }
        public string url { get; set; }
        public IList<Attr> attr { get; set; }
    }

    public class Attr
    {
        public string category { get; set; }
        public string value { get; set; }
    }

    public class Attribute
    {
        public string label { get; set; }
        public string display { get; set; }
    }

    public class Codes
    {
        public string copyright { get; set; }
        public IList<object> dataset { get; set; }
        public IList<Attribute> attribute { get; set; }
        public IList<Dimension> dimension { get; set; }
        public IList<object> fact { get; set; }
    }
}