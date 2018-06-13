using SensorsDataAnalyzer.Data;

namespace SensorsDataAnalyzer.Models
{
    public class CoordinatesDataBindingModel : ICoorinateContainer
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }
    }
}
