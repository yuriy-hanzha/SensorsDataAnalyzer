using System;
using System.Collections.Generic;
using System.Linq;

namespace SensorsDataAnalyzer.Processing
{
    class TestDataPreparer
    {
        private IEnumerable<TestDataRowDTO> initialInterval;
        private List<List<TestDataRowDTO>> splittedInvervals;

        public TestDataPreparer(IEnumerable<TestDataRowDTO> coordinateInterval)
        {
            this.initialInterval = coordinateInterval;
        }

        public List<TestDataRowDTO> GetInterval() => initialInterval.ToList();
        public List<List<TestDataRowDTO>> GetSplittedInvervals() => splittedInvervals;

        public TestDataPreparer SelectValidIntarvals(int usefulValueRange)
        {
            if (initialInterval.Count() < usefulValueRange)
                throw new ArgumentException();

            initialInterval = initialInterval
                .Skip((initialInterval.Count() + 1) / 2 - (usefulValueRange / 2))
                .Take(usefulValueRange).ToList();

            return this;
        }

        public TestDataPreparer SplitDataIntoSameSizeParts(int partSize, int step = 100)
        {
            splittedInvervals = new List<List<TestDataRowDTO>>();

            for (int i = 0; i < initialInterval.Count() - partSize; i += step)
            {
                splittedInvervals.Add(initialInterval.Skip(i).Take(partSize).ToList());
            }

            return this;
        }
    }
}
