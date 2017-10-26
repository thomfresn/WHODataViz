namespace WHODataViz.WPFView
{
    public class IndicatorDesignTimeViewModel : IIndicatorViewModel
    {
        public IndicatorDesignTimeViewModel(string displayName)
        {
            DisplayName = displayName;
        }

        public override string ToString()
        {
            return DisplayName;
        }

        public string DisplayName { get; private set; }
    }

    public interface IIndicatorViewModel
    {
    }
}