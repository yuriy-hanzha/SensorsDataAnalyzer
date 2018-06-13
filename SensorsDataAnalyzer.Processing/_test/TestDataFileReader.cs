using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SensorsDataAnalyzer.Processing
{
    public class TestDataFileReader
    {
        private const int USEFUL_VALUE_RANGE = 3600;
        private const int ONE_PART_SIZE = 1000;

        private Dictionary<string, SmartphonePositions> positionsMappingTable;

        enum SensorTypes { Accelerometer = 1, Gyroscope = 2, Magnetometer = 3 }

        public TestDataFileReader()
        {
            positionsMappingTable = new Dictionary<string, SmartphonePositions>
            {
                { "Backpack", SmartphonePositions.Backpack },
                { "Handheld_using", SmartphonePositions.HandHeldUsing },
                { "Handbag", SmartphonePositions.Handbag },
                { "Hand_held", SmartphonePositions.HandHeld },
                { "Trousers_back_pocket", SmartphonePositions.TrousersBackPocket },
                { "Trousers_front_pocket", SmartphonePositions.TrousersFrontPocket }
            };
        }

        public List<TestDataFileDTO> GetTestData(string directoryPath)
        {
            var result = new List<TestDataFileDTO>();

            foreach (string fileName in Directory.EnumerateFiles(directoryPath))
            {
                SmartphonePositions smartphonePosition;
                if (!IsFileAcceptable(fileName, out smartphonePosition))
                    continue;

                // get all raw coordinate intervals form file
                var parsedCoorsdinateIntervals = ParseCoordinatesFromString(File.ReadAllText(fileName));
                TestDataPreparer dataPreparer = new TestDataPreparer(parsedCoorsdinateIntervals);

                // adjust data to get only useful parts with proper size
                var splittedCoordinateIntervals = dataPreparer.SelectValidIntarvals(USEFUL_VALUE_RANGE)
                                                              .SplitDataIntoSameSizeParts(ONE_PART_SIZE)
                                                              .GetSplittedInvervals();

                result.AddRange(splittedCoordinateIntervals.Select(interval =>
                    new TestDataFileDTO { SmartphonePosition = smartphonePosition, AccelerometerDataRecords = interval }));
            }

            return result;
        }

        private bool IsFileAcceptable(string fileName, out SmartphonePositions smartphonePosition)
        {
            string positionType = fileName.Substring(fileName.IndexOf("cm_") + 3);
            positionType = positionType.Substring(0, positionType.LastIndexOf('.'));

            try
            {
                smartphonePosition = positionsMappingTable[positionType];
            }
            catch (KeyNotFoundException e)
            {
                smartphonePosition = SmartphonePositions.Not_Found;
                return false;
            }

            return positionsMappingTable.ContainsKey(positionType);
        }

        public List<TestDataRowDTO> ParseCoordinatesFromString(string content)
        {
            var parsedCoorsdinates = new List<TestDataRowDTO>();

            string[] rows = content.Split('\n');
            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row)) continue;

                string[] rawData = row.Split(' ');
                if (Int32.Parse(rawData[1]) != (int)SensorTypes.Accelerometer)
                    continue;

                parsedCoorsdinates.Add(new TestDataRowDTO
                {
                    TimeStamp = Decimal.Parse(rawData[0]),
                    X = Double.Parse(rawData[2]),
                    Y = Double.Parse(rawData[3]),
                    Z = Double.Parse(rawData[4])
                });
            }

            return parsedCoorsdinates;
        }
    }
}
