namespace WHODataViz.DataModel
{
    public class Indicator
    {
        public Indicator(string label, string display)
        {
            Code = label;
            Description = display;
        }

        public string Description { get; }

        public string Code { get; }
    }
}