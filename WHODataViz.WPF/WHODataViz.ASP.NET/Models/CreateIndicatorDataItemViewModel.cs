using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WHODataViz.ASP.NET.Models
{
    public class CreateIndicatorDataItemViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string IndicatorCode { get; set; }
        
        [HiddenInput(DisplayValue = false)]
        public string IndicatorDescription { get; set; }

        [Required]
        public double Value { get; set; }
        public string Year { get; set; }
        public string Sex { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Region { get; set; }
        public bool IsPublished { get; set; }
    }
}