using SensorsDataAnalyzer.Data;
using SensorsDataAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SensorsDataAnalyzer.Controllers
{
    [RoutePrefix("api")]
    public class AnalysisController : ApiController
    {
        [HttpGet]
        [Route("get/{IMEI}/{id}")]
        public IHttpActionResult Get(string IMEI, int id)
        {
            SensorsDataModel model = new SensorsDataModel();
            SensorsDataViewModel result = model.GetRecord(IMEI, id);

            return Ok(result);
        }

        [HttpGet]
        [Route("getAll/{IMEI}")]
        public IHttpActionResult GetAll(string IMEI)
        {
            SensorsDataModel model = new SensorsDataModel();
            IEnumerable<SensorsDataViewModel> result = model.GetAllRecords(IMEI);

            return Ok(result);
        }

        [HttpGet]
        [Route("getByDay/{IMEI}/{day}")]
        public IHttpActionResult GetByDate(string IMEI, DateTime date)
        {
            SensorsDataModel model = new SensorsDataModel();
            IEnumerable<SensorsDataViewModel> result = model.GetRecordByDate(IMEI, date);

            return Ok(result);
        }

        [HttpGet]
        [Route("getInTimeRange/{IMEI}/{from}/{to}")]
        public IHttpActionResult GetInTimeRange(string IMEI, DateTime from, DateTime to)
        {
            SensorsDataModel model = new SensorsDataModel();
            IEnumerable<SensorsDataViewModel> result = model.GetRecordInTimeRange(IMEI, from, to);

            return Ok(result);
        }

        [HttpPost]
        [Route("save")]
        public IHttpActionResult SetData(SensorsDataBindingModel data)
        {
            if (data == null)
                return BadRequest("data cannot be empty");

            var model = new SensorsDataModel();
            SensorsDataRecord entity = model.StoreData(data);

            return Ok(new { Id = entity.Id });
        }
    }
}