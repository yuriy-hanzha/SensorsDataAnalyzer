using SensorsDataAnalyzer.Data;
using System.Collections.Generic;

namespace SensorsDataAnalyzer.Processing
{
    public class TestDataFileDTO : ISensorsDataContainer<TestDataRowDTO>
    {
        public SmartphonePositions SmartphonePosition { get; set; }
        public ICollection<TestDataRowDTO> AccelerometerDataRecords { get; set; }

        public TestDataFileDTO()
        {
            AccelerometerDataRecords = new List<TestDataRowDTO>();
        }
    }

    public class TestDataRowDTO : ICoorinateContainer
    {
        public decimal TimeStamp { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
