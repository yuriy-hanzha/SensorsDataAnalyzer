using SensorsDataAnalyzer.Data;
using SensorsDataAnalyzer.Processing;
using SensorsDataAnalyzer.Processing.Classifiers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SensorsDataAnalyzer.Models
{
    public class SensorsDataModel
    {
        SensorsDataRepository _repository;

        public SensorsDataModel()
        {
            _repository = new SensorsDataRepository();
        }

        public SensorsDataViewModel GetRecord(string IMEI, int id)
        {
            SensorsDataRecord entity = _repository.GetByPK(IMEI, id);

            return MapToDisplayForm(entity);
        }

        public List<SensorsDataViewModel> GetAllRecords(string IMEI)
        {
            IEnumerable<SensorsDataRecord> entity = _repository.GetByIMEI(IMEI).AsEnumerable();

            return entity.Select(e => MapToDisplayForm(e)).ToList();
        }

        public List<SensorsDataViewModel> GetRecordByDate(string IMEI, DateTime date)
        {
            IEnumerable<SensorsDataRecord> entity = _repository.GetByDate(IMEI, date).AsEnumerable();

            return entity.Select(e => MapToDisplayForm(e)).ToList();
        }

        public List<SensorsDataViewModel> GetRecordInTimeRange(string IMEI, DateTime from, DateTime to)
        {
            IEnumerable<SensorsDataRecord> entity = _repository.GetInTimeRange(IMEI, from, to).AsEnumerable();

            return entity.Select(e => MapToDisplayForm(e)).ToList();
        }

        public SensorsDataRecord StoreData(SensorsDataBindingModel sensorsRecord)
        {
            var sensorsDataEntity = new SensorsDataRecord
            {
                IMEI = sensorsRecord.IMEI,
                LightSensor = sensorsRecord.LightSensor,
                Latitude = sensorsRecord.Latitude,
                Longitude = sensorsRecord.Longitude,
                Proximity = sensorsRecord.Proximity,
                SentDate = sensorsRecord.SentDate
            };

            if (sensorsRecord.AccelerometerDataArray != null)
            {
                sensorsDataEntity.AccelerometerDataRecords = sensorsRecord.AccelerometerDataArray
                    .Select(a => new AccelerometerDataRecord { X = a.X, Y = a.Y, Z = a.Z }).ToList();
            }

            if (sensorsRecord.GyroscopeDataArray != null)
            {
                sensorsDataEntity.GyroscopeDataRecords = sensorsRecord.GyroscopeDataArray
                    .Select(a => new GyroscopeDataRecord { X = a.X, Y = a.Y, Z = a.Z }).ToList();
            }

            if (sensorsRecord.MagnetometerDataArray != null)
            {
                sensorsDataEntity.MagnetometerDataRecords = sensorsRecord.MagnetometerDataArray
                    .Select(a => new MagnetometerDataRecord { X = a.X, Y = a.Y, Z = a.Z }).ToList();
            }

            _repository.Add(sensorsDataEntity);
            _repository.SaveChanges();

            return sensorsDataEntity;
        }

        private SmartphonePositions AnalyzeAccelerometerData(IEnumerable<ICoorinateContainer> coordinates)
        {
            if (coordinates == null || coordinates.Count() == 0)
                return SmartphonePositions.Not_Found;

            return KNearestNeighborsClassifier.GetInstance().DefineMove(coordinates);
        }

        private SensorsDataViewModel MapToDisplayForm(SensorsDataRecord entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var viewModel = new SensorsDataViewModel
            {
                Id = entity.Id,
                IMEI = entity.IMEI,

                LightSensor = entity.LightSensor,
                Proximity = entity.Proximity,

                SentDate = entity.SentDate
            };

            if (entity.Latitude.HasValue && entity.Longitude.HasValue)
            {
                GoogleMapsApiLocator locator = new GoogleMapsApiLocator();
                viewModel.Location = locator.Define(entity.Latitude.Value, entity.Longitude.Value);
            }

            IEnumerable<AccelerometerDataRecord> acceleromenerCoordinates = _repository.GetAccelerometerData(entity);
            if (acceleromenerCoordinates.Count() > 0)
                viewModel.Position = AnalyzeAccelerometerData(acceleromenerCoordinates).ToString();

            return viewModel;
        }
    }
}