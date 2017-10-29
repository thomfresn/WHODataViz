namespace WHODataViz.WPFView.ViewModel
{
    public class IndicatorDataRowViewModel
    {
        public IndicatorDataRowViewModel(double value, string year, string sex, string country, string region, bool published)
        {
            Value = value;
            Year = year;
            Sex = sex;
            Country = country;
            Region = region;
            Published = published;
        }

        public double Value { get; }

        public string Year { get; }

        public string Sex { get; }

        public string Country { get; }

        public string Region { get; }

        public bool Published { get; }
    }
}