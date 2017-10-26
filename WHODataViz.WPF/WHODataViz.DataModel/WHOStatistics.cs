namespace WHODataViz.DataModel
{
    public class WHOStatistics
    {
        public WHOStatistics(double value, string year, string sex, string country, string region, bool isPublished)
        {
            Value = value;
            Year = year;
            Sex = sex;
            Country = country;
            Region = region;
            IsPublished = isPublished;
        }

        public double Value { get; private set; }
        public string Year { get; private set; }
        public string Sex { get; private set; }
        public string Country { get; private set; }
        public string Region { get; private set; }
        public bool IsPublished { get; private set; }
    }
}